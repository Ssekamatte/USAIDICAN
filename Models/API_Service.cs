using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Collections;
using System.Linq.Expressions;
using System.Reflection;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using SQL = System.Data;
using System.Configuration;
using System.Net.Sockets;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

using USAIDICANBLAZOR.EmailScheduler;

//using System.Web;
namespace USAIDICANBLAZOR.Models
{
    public class API_Service : IServiceApi
    {
        private USAID_ICANContext _context;
        public API_Service(USAID_ICANContext context)
        {
            this._context = context;
        }

        string userName = "ican";
        string password = "abt@1can";

        private static string Uri = String.Format("https://api.ona.io/api/v1/data/");
        public string Public_Uri = Uri;

        public List<McareGroupsData> mcgData { get; set; }
        public List<ChilliData> chilliData { get; set; }
        public List<CrcData> crcData { get; set; }
        public List<LgroupsData> LgroupsData { get; set; }
        public List<SamplegrpsData> samgrpsData { get; set; }
        public List<AGYW2020Data> agData { get; set; }
        public List<BSPSurveyData> bspsurData { get; set; }
        public List<BSPSurveyfinalData> bspsurfinData { get; set; }
        public List<BSPSurveyrevisedData> spsurevData { get; set; }
        public List<CellProfilingData> cellproData { get; set; }
        public List<CGAssessmentData> cgassData { get; set; }
        public List<COMMUNITYGROUPSummaryVer5Data> commgrosumVer5Data { get; set; }
        public List<CRCWeeklySummaryVer4Data> crcwesumData { get; set; }
        public List<EreProfilingData> ereproData { get; set; }
        public List<EventTracker2Data> evetrac2Data { get; set; }
        public List<HHProfileData> hhproData { get; set; }
        public List<InstitutionMappingData> InsMapData { get; set; }
        public List<mcgData> mcggData { get; set; }
        public List<MIYCAN_MonthlySummaryVer4Data> MIYCANMonSumData { get; set; }
        public List<refNoteData> refnoData { get; set; }
        public List<RMS1Data> rmss1Data { get; set; }
        public List<ukuRegisterData> ukuregData { get; set; }
        public List<Update_Livelihood_groupData> UpdlivgroupData { get; set; }
        public List<Update_MIYCAN_groupData> UpdmiycanData { get; set; }
        public List<OnaPosttestAgyw> PosttestAgywData { get; set; }
        public List<OnaIbs2020> Ibs2020Data { get; set; }
        public List<OnaCommunityTeamRegister> CommTeamRegData { get; set; }

        #region IBS2020
        public IEnumerable<OnaIbs2020> GetIbs2020Records()
        {
            //Load the data from the API
            var model = new object[0];
            var targeturl = string.Format("https://api.ona.io/api/v1/data/533769");
            //Jan - Mar
            HttpMessageHandler handler = new HttpClientHandler()
            {
            };

            var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(targeturl),
                Timeout = new TimeSpan(0, 30, 0)
            };

            List<OnaIbs2020> Ibs2020 = new List<OnaIbs2020>();
            httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");

            //This is the key section you were missing    
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes("ican:abt@1can");
            string val = System.Convert.ToBase64String(plainTextBytes);
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + val);

            var method = new HttpMethod("GET");
            List<string> myList = new List<string>();

            JArray jArray = new JArray();
            HttpResponseMessage response = httpClient.GetAsync(targeturl).Result;
            if (response.ReasonPhrase == "Not Found")
            {
                //TempData["Message"] = string.Format("No records found for  {0}-{1}", reportingPeriod.Replace("%20", ""), financialYear.ToString()); ;
            }
            else
            {
                string content = string.Empty;

                using (StreamReader stream = new StreamReader(response.Content.ReadAsStreamAsync().Result, true))
                {
                    content = stream.ReadToEnd();
                }

                jArray = JArray.Parse(content);
                // Strip off the [] from _tags and Notes

                foreach (JObject j in jArray)
                {
                    var cgib = new OnaIbs2020();

                    string dvalue = string.Empty;
                    double dnumber;
                    bool success = false;

                    if (j.GetValue("Qn/Z4") != null)
                    {
                        cgib.QnZ4 = j.GetValue("Qn/Z4").ToString();
                    }

                    //if (j.GetValue("Qn/_Z4_latitude") != null)
                    //{
                    //    cgib.QnZ4Latitude = Convert.ToDouble(j.GetValue("Qn/_Z4_latitude").ToString());
                    //}

                    //if (j.GetValue("Qn/_Z4_longitude") != null)
                    //{
                    //    cgib.QnZ4Longitude = Convert.ToDouble(j.GetValue("Qn/_Z4_longitude").ToString());
                    //}

                    var a = j.GetValue("_geolocation") as object;
                    var c = a.ToString().Replace("\r", "").Replace("\n", "").Replace("[", "").Replace("]", "").Trim();
                    var b = c.Split(',');
                    if (b.Length == 2)
                    {
                        double d = 0;
                        if (double.TryParse(b[0], out d))
                        {
                            cgib.QnZ4Latitude = d;
                        }
                        if (double.TryParse(b[1], out d))
                        {
                            cgib.QnZ4Longitude = d;
                        }
                    }
                    if (j.GetValue("Qn/_Z4_altitude") != null)
                    {
                        cgib.QnZ4Altitude = j.GetValue("Qn/_Z4_altitude").ToString();
                    }

                    if (j.GetValue("Qn/_Z4_precision") != null)
                    {
                        cgib.QnZ4Precision = j.GetValue("Qn/_Z4_precision").ToString();
                    }

                    cgib.Id = Convert.ToInt32(j.GetValue("_id").ToString());

                    if (j.GetValue("ra") != null)
                    {
                        cgib.Ra = j.GetValue("ra").ToString();
                    }

                    if (j.GetValue("A/Z6") != null)
                    {
                        cgib.AZ6 = j.GetValue("A/Z6").ToString();
                    }

                    if (j.GetValue("A/Z7") != null)
                    {
                        cgib.AZ7 = j.GetValue("A/Z7").ToString();
                    }

                    if (j.GetValue("A/Z8") != null)
                    {
                        cgib.AZ8 = j.GetValue("A/Z8").ToString();
                    }

                    if (j.GetValue("Qn/Z4") != null)
                    {
                        cgib.QnZ4 = j.GetValue("Qn/Z4").ToString();
                    }

                    if (j.GetValue("Qn/end") != null)
                    {
                        cgib.QnEnd = j.GetValue("Qn/end").ToString();
                    }

                    if (j.GetValue("Qn/fw1") != null)
                    {
                        cgib.QnFw1 = j.GetValue("Qn/fw1").ToString();
                    }

                    if (j.GetValue("Qn/fw2") != null)
                    {
                        cgib.QnFw2 = j.GetValue("Qn/fw2").ToString();
                    }

                    if (j.GetValue("Qn/C/c1") != null)
                    {
                        cgib.QnCC1 = j.GetValue("Qn/C/c1").ToString();
                    }

                    if (j.GetValue("Qn/C/c2") != null)
                    {
                        cgib.QnCC2 = j.GetValue("Qn/C/c2").ToString();
                    }

                    if (j.GetValue("Qn/C/c3") != null)
                    {
                        cgib.QnCC3 = Convert.ToDouble(j.GetValue("Qn/C/c3").ToString());
                    }

                    if (j.GetValue("Qn/C/c4") != null)
                    {
                        cgib.QnCC4 = j.GetValue("Qn/C/c4").ToString();
                    }

                    if (j.GetValue("Qn/C/c5") != null)
                    {
                        cgib.QnCC5 = j.GetValue("Qn/C/c5").ToString();
                    }

                    if (j.GetValue("Qn/C/c6") != null)
                    {
                        cgib.QnCC6 = j.GetValue("Qn/C/c6").ToString();
                    }

                    if (j.GetValue("Qn/F/F1") != null)
                    {
                        cgib.QnFF1 = j.GetValue("Qn/F/F1").ToString();
                    }

                    if (j.GetValue("Qn/F/F2") != null)
                    {
                        cgib.QnFF2 = Convert.ToDouble(j.GetValue("Qn/F/F2").ToString());
                    }
                    if (j.GetValue("Qn/F/F3") != null)
                    {
                        cgib.QnFF3 = j.GetValue("Qn/F/F3").ToString();
                    }

                    if (j.GetValue("Qn/F/F5") != null)
                    {
                        cgib.QnFF5 = Convert.ToDouble(j.GetValue("Qn/F/F5").ToString());
                    }

                    if (j.GetValue("Qn/F/F6") != null)
                    {
                        cgib.QnFF6 = j.GetValue("Qn/F/F6").ToString();
                    }

                    if (j.GetValue("Qn/F/F7") != null)
                    {
                        cgib.QnFF7 = j.GetValue("Qn/F/F7").ToString();
                    }

                    if (j.GetValue("Qn/F/F8") != null)
                    {
                        cgib.QnFF8 = j.GetValue("Qn/F/F8").ToString();
                    }

                    if (j.GetValue("Qn/F/F9") != null)
                    {
                        cgib.QnFF9 = j.GetValue("Qn/F/F9").ToString();
                    }

                    if (j.GetValue("Qn/L/L1") != null)
                    {
                        cgib.QnLL1 = j.GetValue("Qn/L/L1").ToString();
                    }

                    if (j.GetValue("Qn/L/L4") != null)
                    {
                        cgib.QnLL4 = j.GetValue("Qn/L/L4").ToString();
                    }

                    if (j.GetValue("Qn/L/L6") != null)
                    {
                        cgib.QnLL6 = j.GetValue("Qn/L/L6").ToString();
                    }

                    if (j.GetValue("Qn/L/L7") != null)
                    {
                        cgib.QnLL7 = j.GetValue("Qn/L/L7").ToString();
                    }

                    if (j.GetValue("Qn/L/L8") != null)
                    {
                        cgib.QnLL8 = j.GetValue("Qn/L/L8").ToString();
                    }

                    if (j.GetValue("Qn/ack2") != null)
                    {
                        cgib.QnAck2 = j.GetValue("Qn/ack2").ToString();
                    }

                    if (j.GetValue("village") != null)
                    {
                        cgib.Village = j.GetValue("village").ToString();
                    }

                    if (j.GetValue("Qn/B/age") != null)
                    {
                        cgib.QnBAge = Convert.ToDouble(j.GetValue("Qn/B/age").ToString());
                    }

                    if (j.GetValue("Qn/F/F10") != null)
                    {
                        cgib.QnFF10 = j.GetValue("Qn/F/F10").ToString();
                    }

                    if (j.GetValue("Qn/F/F11") != null)
                    {
                        cgib.QnFF11 = j.GetValue("Qn/F/F11").ToString();
                    }
                    if (j.GetValue("Qn/F/F12") != null)
                    {
                        cgib.QnFF12 = j.GetValue("Qn/F/F12").ToString();
                    }
                    if (j.GetValue("Qn/F/F13") != null)
                    {
                        cgib.QnFF13 = j.GetValue("Qn/F/F13").ToString();
                    }
                    if (j.GetValue("Qn/F/F14") != null)
                    {
                        cgib.QnFF14 = j.GetValue("Qn/F/F14").ToString();
                    }
                    if (j.GetValue("Qn/F/F15") != null)
                    {
                        cgib.QnFF15 = j.GetValue("Qn/F/F15").ToString();
                    }
                    if (j.GetValue("Qn/F/F1a") != null)
                    {
                        cgib.QnFF1a = Convert.ToDouble(j.GetValue("Qn/F/F1a").ToString());
                    }

                    if (j.GetValue("Qn/r1909") != null)
                    {
                        cgib.QnR1909 = j.GetValue("Qn/r1909").ToString();
                    }

                    if (j.GetValue("Qn/start") != null)
                    {
                        cgib.QnStart = j.GetValue("Qn/start").ToString();
                    }

                    if (j.GetValue("district") != null)
                    {
                        cgib.District = j.GetValue("district").ToString();
                    }

                    if (j.GetValue("Qn/F/crp1") != null)
                    {
                        cgib.QnFCrp1 = j.GetValue("Qn/F/crp1").ToString();
                    }

                    if (j.GetValue("Qn/enfood") != null)
                    {
                        cgib.QnEnfood = j.GetValue("Qn/enfood").ToString();
                    }

                    if (j.GetValue("subcounty") != null)
                    {
                        cgib.Subcounty = j.GetValue("subcounty").ToString();
                    }

                    if (j.GetValue("Qn/enFood3") != null)
                    {
                        cgib.QnEnFood3 = j.GetValue("Qn/enFood3").ToString();
                    }

                    if (j.GetValue("Qn/r5/r501") != null)
                    {
                        cgib.QnR5R501 = j.GetValue("Qn/r5/r501").ToString();
                    }

                    if (j.GetValue("Qn/r5/r502") != null)
                    {
                        cgib.QnR5R502 = j.GetValue("Qn/r5/r502").ToString();
                    }

                    if (j.GetValue("Qn/r5/r508") != null)
                    {
                        cgib.QnR5R508 = j.GetValue("Qn/r5/r508").ToString();
                    }

                    if (j.GetValue("Qn/B/sexres") != null)
                    {
                        cgib.QnBSexres = j.GetValue("Qn/B/sexres").ToString();
                    }

                    if (j.GetValue("Qn/C/c_note") != null)
                    {
                        cgib.QnCCNote = j.GetValue("Qn/C/c_note").ToString();
                    }

                    if (j.GetValue("Qn/comments") != null)
                    {
                        cgib.QnComments = j.GetValue("Qn/comments").ToString();
                    }

                    if (j.GetValue("Qn/mr6/r601") != null)
                    {
                        cgib.QnMr6R601 = j.GetValue("Qn/mr6/r601").ToString();
                    }

                    if (j.GetValue("Qn/F/F7trees") != null)
                    {
                        cgib.QnFF7trees = j.GetValue("Qn/F/F7trees").ToString();
                    }

                    if (j.GetValue("Qn/F/F_intro") != null)
                    {
                        cgib.QnFFIntro = j.GetValue("Qn/F/F_intro").ToString();
                    }

                    if (j.GetValue("Qn/ack_noteM") != null)
                    {
                        cgib.QnAckNoteM = j.GetValue("Qn/ack_noteM").ToString();
                    }

                    if (j.GetValue("Qn/mdr1/r108") != null)
                    {
                        cgib.QnMdr1R108 = j.GetValue("Qn/mdr1/r108").ToString();
                    }

                    if (j.GetValue("Qn/mdr3/r308") != null)
                    {
                        cgib.QnMdr3R308 = j.GetValue("Qn/mdr3/r308").ToString();
                    }

                    if (j.GetValue("Qn/mr13/r139") != null)
                    {
                        cgib.QnMr13R139 = j.GetValue("Qn/mr13/r139").ToString();
                    }

                    if (j.GetValue("Qn/mr2/r201b") != null)
                    {
                        cgib.QnMr2R201b = j.GetValue("Qn/mr2/r201b").ToString();
                    }

                    if (j.GetValue("Qn/mr2/r201c") != null)
                    {
                        cgib.QnMr2R201c = j.GetValue("Qn/mr2/r201c").ToString();
                    }

                    if (j.GetValue("Qn/mr2/r201d") != null)
                    {
                        cgib.QnMr2R201d = j.GetValue("Qn/mr2/r201d").ToString();
                    }

                    if (j.GetValue("Qn/mr6/r602a") != null)
                    {
                        cgib.QnMr6R602a = j.GetValue("Qn/mr6/r602a").ToString();
                    }

                    if (j.GetValue("Qn/r5/ack_r5") != null)
                    {
                        cgib.QnR5AckR5 = j.GetValue("Qn/r5/ack_r5").ToString();
                    }

                    if (j.GetValue("Qn/signature") != null)
                    {
                        cgib.QnSignature = j.GetValue("Qn/signature").ToString();
                    }

                    if (j.GetValue("Qn/mr13/r1314") != null)
                    {
                        cgib.QnMr13R1314 = j.GetValue("Qn/mr13/r1314").ToString();
                    }

                    if (j.GetValue("Qn/mr13/r139a") != null)
                    {
                        cgib.QnMr13R139a = j.GetValue("Qn/mr13/r139a").ToString();
                    }

                    if (j.GetValue("Qn/profile/c7") != null)
                    {
                        cgib.QnProfileC7 = Convert.ToDouble(j.GetValue("Qn/profile/c7").ToString());
                    }

                    if (j.GetValue("Qn/profile/c8") != null)
                    {
                        cgib.QnProfileC8 = Convert.ToDouble(j.GetValue("Qn/profile/c8").ToString());
                    }

                    if (j.GetValue("Qn/profile/c9") != null)
                    {
                        cgib.QnProfileC9 = Convert.ToDouble(j.GetValue("Qn/profile/c9").ToString());
                    }

                    if (j.GetValue("Qn/secionI/i1") != null)
                    {
                        cgib.QnSecionII1 = j.GetValue("Qn/secionI/i1").ToString();
                    }

                    if (j.GetValue("_submitted_by") != null)
                    {
                        cgib.SubmittedBy = j.GetValue("_submitted_by").ToString();
                    }

                    if (j.GetValue("Qn/md_other/t1") != null)
                    {
                        cgib.QnMdOtherT1 = j.GetValue("Qn/md_other/t1").ToString();
                    }

                    if (j.GetValue("Qn/md_other/t3") != null)
                    {
                        cgib.QnMdOtherT3 = j.GetValue("Qn/md_other/t3").ToString();
                    }

                    if (j.GetValue("Qn/md_other/t4") != null)
                    {
                        cgib.QnMdOtherT4 = j.GetValue("Qn/md_other/t4").ToString();
                    }

                    if (j.GetValue("Qn/md_other/t5") != null)
                    {
                        cgib.QnMdOtherT5 = j.GetValue("Qn/md_other/t5").ToString();
                    }

                    if (j.GetValue("Qn/mdr1/r3_2a1") != null)
                    {
                        cgib.QnMdr1R32a1 = j.GetValue("Qn/mdr1/r3_2a1").ToString();
                    }

                    if (j.GetValue("Qn/mdr1/r3_2b2") != null)
                    {
                        cgib.QnMdr1R32b2 = j.GetValue("Qn/mdr1/r3_2b2").ToString();
                    }

                    if (j.GetValue("Qn/mdr1/r3_3a1") != null)
                    {
                        cgib.QnMdr1R33a1 = j.GetValue("Qn/mdr1/r3_3a1").ToString();
                    }

                    if (j.GetValue("Qn/mdr1/r3_3b2") != null)
                    {
                        cgib.QnMdr1R33b2 = j.GetValue("Qn/mdr1/r3_3b2").ToString();
                    }

                    if (j.GetValue("Qn/mdr1/shocks") != null)
                    {
                        cgib.QnMdr1Shocks = j.GetValue("Qn/mdr1/shocks").ToString();
                    }

                    if (j.GetValue("Qn/mr2/ack_mr2") != null)
                    {
                        cgib.QnMr2AckMr2 = j.GetValue("Qn/mr2/ack_mr2").ToString();
                    }

                    if (j.GetValue("Qn/profile/c10") != null)
                    {
                        cgib.QnProfileC10 = Convert.ToDouble(j.GetValue("Qn/profile/c10").ToString());
                    }

                    if (j.GetValue("Qn/profile/c11") != null)
                    {
                        cgib.QnProfileC11 = Convert.ToDouble(j.GetValue("Qn/profile/c11").ToString());
                    }

                    if (j.GetValue("Qn/profile/c12") != null)
                    {
                        cgib.QnProfileC12 = Convert.ToDouble(j.GetValue("Qn/profile/c12").ToString());
                    }

                    if (j.GetValue("Qn/profile/c13") != null)
                    {
                        cgib.QnProfileC13 = j.GetValue("Qn/profile/c13").ToString();
                    }

                    if (j.GetValue("Qn/profile/c14") != null)
                    {
                        cgib.QnProfileC14 = j.GetValue("Qn/profile/c14").ToString();
                    }

                    if (j.GetValue("Qn/profile/c15") != null)
                    {
                        cgib.QnProfileC14 = j.GetValue("Qn/profile/c15").ToString();
                    }

                    if (j.GetValue("Qn/profile/c16") != null)
                    {
                        cgib.QnProfileC16 = j.GetValue("Qn/profile/c16").ToString();
                    }

                    if (j.GetValue("Qn/covid/covid5") != null)
                    {
                        cgib.QnCovidCovid5 = j.GetValue("Qn/covid/covid5").ToString();
                    }

                    if (j.GetValue("Qn/covid/covid7") != null)
                    {
                        cgib.QnCovidCovid7 = j.GetValue("Qn/covid/covid7").ToString();
                    }

                    if (j.GetValue("Qn/mdr1/ackmdr1") != null)
                    {
                        cgib.QnMdr1Ackmdr1 = j.GetValue("Qn/mdr1/ackmdr1").ToString();
                    }

                    if (j.GetValue("Qn/modr14/r1403") != null)
                    {
                        cgib.QnModr14R1403 = j.GetValue("Qn/modr14/r1403").ToString();
                    }

                    if (j.GetValue("Qn/mr6/ack_mdr6") != null)
                    {
                        cgib.QnMr6AckMdr6 = j.GetValue("Qn/mr6/ack_mdr6").ToString();
                    }

                    if (j.GetValue("Qn/profile/c15x") != null)
                    {
                        cgib.QnProfileC15x = j.GetValue("Qn/profile/c15x").ToString();
                    }

                    if (j.GetValue("Qn/sectionR/mis") != null)
                    {
                        cgib.QnSectionRMis = j.GetValue("Qn/sectionR/mis").ToString();
                    }

                    if (j.GetValue("Qn/wn/decisions") != null)
                    {
                        cgib.QnWnDecisions = j.GetValue("Qn/wn/decisions").ToString();
                    }


                    if (j.GetValue("Qn/covid/covid5a") != null)
                    {
                        cgib.QnCovidCovid5a = j.GetValue("Qn/covid/covid5a").ToString();
                    }

                    if (j.GetValue("Qn/covid/covid7a") != null)
                    {
                        cgib.QnCovidCovid7a = j.GetValue("Qn/covid/covid7a").ToString();
                    }

                    if (j.GetValue("Qn/mr13/ack_md13") != null)
                    {
                        cgib.QnMr13AckMd13 = j.GetValue("Qn/mr13/ack_md13").ToString();
                    }

                    if (j.GetValue("Qn/profile/c15x1") != null)
                    {
                        cgib.QnProfileC15x1 = j.GetValue("Qn/profile/c15x1").ToString();
                    }

                    if (j.GetValue("Qn/r2a/livestock") != null)
                    {
                        cgib.QnR2aLivestock = j.GetValue("Qn/r2a/livestock").ToString();
                    }

                    if (j.GetValue("Qn/section9/q900") != null)
                    {
                        cgib.QnSection9Q900 = j.GetValue("Qn/section9/q900").ToString();
                    }

                    if (j.GetValue("Qn/section9/q901") != null)
                    {
                        cgib.QnSection9Q901 = j.GetValue("Qn/section9/q901").ToString();
                    }

                    if (j.GetValue("Qn/section9/q902") != null)
                    {
                        cgib.QnSection9Q902 = j.GetValue("Qn/section9/q902").ToString();
                    }

                    if (j.GetValue("Qn/wn/decisions6") != null)
                    {
                        cgib.QnWnDecisions6 = j.GetValue("Qn/wn/decisions6").ToString();
                    }

                    if (j.GetValue("location/groupid") != null)
                    {
                        cgib.LocationGroupid = j.GetValue("location/groupid").ToString();
                    }

                    if (j.GetValue("Qn/covid/covid_19") != null)
                    {
                        cgib.QnCovidCovid19 = j.GetValue("Qn/covid/covid_19").ToString();
                    }

                    if (j.GetValue("Qn/mr2/prodAssets") != null)
                    {
                        cgib.ProdAssets = j.GetValue("Qn/mr2/prodAssets").ToString();
                    }

                    if (j.GetValue("Qn/profile/lesspri") != null)
                    {
                        cgib.QnProfileLesspri = j.GetValue("Qn/profile/lesspri").ToString();
                    }

                    if (j.GetValue("location/groupname") != null)
                    {
                        cgib.LocationGroupname = j.GetValue("location/groupname").ToString();
                    }

                    if (j.GetValue("Qn/seasons/activity") != null)
                    {
                        cgib.QnSeasonsActivity = j.GetValue("Qn/seasons/activity").ToString();
                    }

                    if (j.GetValue("Qn/prep_shock/ackmdr2") != null)
                    {
                        cgib.QnPrepShockAckmdr2 = j.GetValue("Qn/prep_shock/ackmdr2").ToString();
                    }

                    if (j.GetValue("Qn/prep_shock/shocks2") != null)
                    {
                        cgib.QnPrepShockShocks2 = j.GetValue("Qn/prep_shock/shocks2").ToString();
                    }

                    if (j.GetValue("Qn/r2a/livestock_sold") != null)
                    {
                        cgib.QnR2aLivestock = j.GetValue("Qn/r2a/livestock_sold").ToString();
                    }

                    if (j.GetValue("Qn/mr2/prodAssets_sold") != null)
                    {
                        cgib.QnMr2ProdAssetsSold = j.GetValue("Qn/mr2/prodAssets_sold").ToString();
                    }

                    if (j.GetValue("Qn/prep_shock/r110_2a1") != null)
                    {
                        cgib.QnPrepShockR1102a1 = j.GetValue("Qn/prep_shock/r110_2a1").ToString();
                    }

                    if (j.GetValue("Qn/prep_shock/r110_2b2") != null)
                    {
                        cgib.QnPrepShockR1102b2 = j.GetValue("Qn/prep_shock/r110_2b2").ToString();
                    }


                    if (j.GetValue("Qn/prep_shock/r110_2b9") != null)
                    {
                        cgib.QnPrepShockR1102b9 = j.GetValue("Qn/prep_shock/r110_2b9").ToString();
                    }

                    if (j.GetValue("Qn/prep_shock/r110_3a1") != null)
                    {
                        cgib.QnPrepShockR1103a1 = j.GetValue("Qn/prep_shock/r110_3a1").ToString();
                    }

                    if (j.GetValue("Qn/prep_shock/r110_3b2") != null)
                    {
                        cgib.QnPrepShockR1103b2 = j.GetValue("Qn/prep_shock/r110_3b2").ToString();
                    }

                    if (j.GetValue("Qn/prep_shock/r110_3b9") != null)
                    {
                        cgib.QnPrepShockR1103b9 = j.GetValue("Qn/prep_shock/r110_3b9").ToString();
                    }

                    if (j.GetValue("Qn/women/foodgrpsWomen") != null)
                    {
                        cgib.QnWomenFoodgrpsWomen = j.GetValue("Qn/women/foodgrpsWomen").ToString();
                    }

                    if (j.GetValue("Qn/info_training/info_t") != null)
                    {
                        cgib.QnInfoTrainingInfoT = j.GetValue("Qn/info_training/info_t").ToString();
                    }

                    if (j.GetValue("Qn/rankingR/src_income1") != null)
                    {
                        cgib.QnRankingRSrcIncome1 = j.GetValue("Qn/rankingR/src_income1").ToString();
                    }

                    if (j.GetValue("Qn/rankingR/src_income11") != null)
                    {
                        cgib.QnRankingRSrcIncome11 = j.GetValue("Qn/rankingR/src_income11").ToString();
                    }

                    if (j.GetValue("Qn/mr13/r137") != null)
                    {
                        cgib.QnMr13R137 = j.GetValue("Qn/mr13/r137").ToString();
                    }

                    if (j.GetValue("_submission_time") != null)
                    {
                        CultureInfo enUS = new CultureInfo("en-US");
                        string dateString;
                        DateTime dateValue;
                        // Use custom formats with M and MM.
                        dateString = j.GetValue("_submission_time").ToString();
                        //if (DateTime.TryParseExact(dateString, "M/dd/yyyy hh:mm", enUS,
                        if (DateTime.TryParse(dateString, out dateValue))
                        {
                            cgib.SubmissionTime = dateValue;// Convert.ToDateTime(j.GetValue("_submission_time").ToString());
                        }
                    }


                    cgib.LastUpdatedAt = DateTime.Now;

                    Ibs2020.Add(cgib);
                }
                // careGroups = JsonConvert.DeserializeObject<List<McareGroupsData>>(content);

            }

            //this.chilliData = chilliGroups;

            return Ibs2020;
        }

        public async Task SaveIBS2020Data()
        {
            try
            {
                using (var IcanContext = new USAID_ICANContext())
                {
                    var data = GetIbs2020Records().ToList();
                    IcanContext.OnaIbs2020.RemoveRange(IcanContext.OnaIbs2020.ToList());
                    await IcanContext.SaveChangesAsync();
                    IcanContext.OnaIbs2020.AddRange(data);
                    await IcanContext.SaveChangesAsync();

                    //send email after update                   
                    EmailModel email = new EmailModel(_context);
                    email.OnaIbs2020Email();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion IBS2020

        #region PostTestAGYW

        public IEnumerable<OnaPosttestAgyw> GetPosttestAgywRecords()
        {
            //Load the data from the API
            var model = new object[0];
            var targeturl = string.Format("https://api.ona.io/api/v1/data/480497");
            //Jan - Mar
            HttpMessageHandler handler = new HttpClientHandler()
            {
            };

            var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(targeturl),
                Timeout = new TimeSpan(0, 20, 0)
            };

            List<OnaPosttestAgyw> PostTest = new List<OnaPosttestAgyw>();
            httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");

            //This is the key section you were missing    
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes("ican:abt@1can");
            string val = System.Convert.ToBase64String(plainTextBytes);
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + val);

            var method = new HttpMethod("GET");
            List<string> myList = new List<string>();

            JArray jArray = new JArray();
            HttpResponseMessage response = httpClient.GetAsync(targeturl).Result;
            if (response.ReasonPhrase == "Not Found")
            {
                //TempData["Message"] = string.Format("No records found for  {0}-{1}", reportingPeriod.Replace("%20", ""), financialYear.ToString()); ;
            }
            else
            {
                string content = string.Empty;

                using (StreamReader stream = new StreamReader(response.Content.ReadAsStreamAsync().Result, true))
                {
                    content = stream.ReadToEnd();
                }

                jArray = JArray.Parse(content);
                // Strip off the [] from _tags and Notes

                foreach (JObject j in jArray)
                {
                    var cg = new OnaPosttestAgyw();

                    string dvalue = string.Empty;
                    double dnumber;
                    bool success = false;

                    var a = j.GetValue("_geolocation") as object;
                    var c = a.ToString().Replace("\r", "").Replace("\n", "").Replace("[", "").Replace("]", "").Trim();
                    var b = c.Split(',');
                    if (b.Length == 2)
                    {
                        double d = 0;
                        if (double.TryParse(b[0], out d))
                        {
                            cg.QnGpsLatitude = d;
                        }
                        if (double.TryParse(b[1], out d))
                        {
                            cg.QnGpsLongitude = d;
                        }
                    }

                    cg.Id = Convert.ToInt32(j.GetValue("_id").ToString());

                    if (j.GetValue("_uuid") != null)
                    {
                        cg.Uuid = j.GetValue("_uuid").ToString();
                    }

                    if (j.GetValue("Qn/gps") != null)
                    {
                        cg.QnGps = j.GetValue("Qn/gps").ToString();
                    }

                    if (j.GetValue("Qn/vsla") != null)
                    {
                        cg.QnVsla = j.GetValue("Qn/vsla").ToString();
                    }

                    if (j.GetValue("_version") != null)
                    {
                        cg.Version = j.GetValue("_version").ToString();
                    }

                    if (j.GetValue("_duration") != null)
                    {
                        cg.Duration = Convert.ToDouble(j.GetValue("_duration").ToString());
                    }

                    if (j.GetValue("_xform_id") != null)
                    {
                        cg.XformId = Convert.ToDouble(j.GetValue("_xform_id").ToString());
                    }

                    if (j.GetValue("fieldteam") != null)
                    {
                        cg.Fieldteam = j.GetValue("fieldteam").ToString();
                    }

                    if (j.GetValue("Qn/comments") != null)
                    {
                        cg.QnComments = j.GetValue("Qn/comments").ToString();
                    }

                    if (j.GetValue("Qn/secA/end") != null)
                    {
                        cg.QnSecAEnd = j.GetValue("Qn/secA/end").ToString();
                    }

                    if (j.GetValue("Qn/secA/loc") != null)
                    {
                        cg.QnSecALoc = j.GetValue("Qn/secA/loc").ToString();
                    }

                    if (j.GetValue("Qn/secA/qn1") != null)
                    {
                        cg.QnSecAQn1 = j.GetValue("Qn/secA/qn1").ToString();
                    }

                    if (j.GetValue("Qn/secA/qn2") != null)
                    {
                        cg.QnSecAQn2 = j.GetValue("Qn/secA/qn2").ToString();
                    }

                    if (j.GetValue("Qn/secA/qn3") != null)
                    {
                        cg.QnSecAQn3 = j.GetValue("Qn/secA/qn3").ToString();
                    }

                    if (j.GetValue("Qn/secA/qn4") != null)
                    {
                        cg.QnSecAQn4 = j.GetValue("Qn/secA/qn4").ToString();
                    }

                    if (j.GetValue("Qn/secA/qn5") != null)
                    {
                        cg.QnSecAQn5 = j.GetValue("Qn/secA/qn5").ToString();
                    }

                    if (j.GetValue("Qn/secA/qn6") != null)
                    {
                        cg.QnSecAQn6 = j.GetValue("Qn/secA/qn6").ToString();
                    }
                    if (j.GetValue("Qn/secA/qn7") != null)
                    {
                        cg.QnSecAQn7 = j.GetValue("Qn/secA/qn7").ToString();
                    }

                    if (j.GetValue("Qn/secA/qn8") != null)
                    {
                        cg.QnSecAQn8 = j.GetValue("Qn/secA/qn8").ToString();
                    }

                    if (j.GetValue("Qn/secA/qn9") != null)
                    {
                        cg.QnSecAQn9 = j.GetValue("Qn/secA/qn9").ToString();
                    }

                    if (j.GetValue("Qn/secA/qn10") != null)
                    {
                        cg.QnSecAQn10 = j.GetValue("Qn/secA/qn10").ToString();
                    }

                    if (j.GetValue("Qn/secA/qn11") != null)
                    {
                        cg.QnSecAQn11 = j.GetValue("Qn/secA/qn11").ToString();
                    }

                    if (j.GetValue("Qn/secA/qn12") != null)
                    {
                        cg.QnSecAQn12 = j.GetValue("Qn/secA/qn12").ToString();
                    }


                    if (j.GetValue("_submission_time") != null)
                    {
                        CultureInfo enUS = new CultureInfo("en-US");
                        string dateString;
                        DateTime dateValue;
                        // Use custom formats with M and MM.
                        dateString = j.GetValue("_submission_time").ToString();
                        //if (DateTime.TryParseExact(dateString, "M/dd/yyyy hh:mm", enUS,
                        if (DateTime.TryParse(dateString, out dateValue))
                        {
                            cg.SubmissionTime = dateValue;// Convert.ToDateTime(j.GetValue("_submission_time").ToString());
                        }
                    }

                    if (j.GetValue("Qn/secA/qn13") != null)
                    {
                        cg.QnSecAQn13 = j.GetValue("Qn/secA/qn13").ToString();
                    }

                    if (j.GetValue("Qn/secB/qn14") != null)
                    {
                        cg.QnSecBQn14 = j.GetValue("Qn/secB/qn14").ToString();
                    }

                    if (j.GetValue("Qn/secB/qn15") != null)
                    {
                        cg.QnSecBQn15 = j.GetValue("Qn/secB/qn15").ToString();
                    }

                    if (j.GetValue("Qn/secB/qn16") != null)
                    {
                        cg.QnSecBQn16 = j.GetValue("Qn/secB/qn16").ToString();
                    }

                    if (j.GetValue("Qn/secB/qn17") != null)
                    {
                        cg.QnSecBQn17 = j.GetValue("Qn/secB/qn17").ToString();
                    }

                    if (j.GetValue("Qn/secB/qn18") != null)
                    {
                        cg.QnSecBQn18 = j.GetValue("Qn/secB/qn18").ToString();

                    }

                    if (j.GetValue("Qn/secB/qn19") != null)
                    {
                        cg.QnSecBQn19 = j.GetValue("Qn/secB/qn19").ToString();
                    }

                    if (j.GetValue("Qn/secB/qn20") != null)
                    {
                        cg.QnSecBQn20 = j.GetValue("Qn/secB/qn20").ToString();
                    }

                    if (j.GetValue("Qn/secB/qn21") != null)
                    {
                        cg.QnSecBQn21 = j.GetValue("Qn/secB/qn21").ToString();
                    }
                    if (j.GetValue("Qn/secB/qn22") != null)
                    {
                        cg.QnSecBQn22 = j.GetValue("Qn/secB/qn22").ToString();
                    }
                    if (j.GetValue("Qn/secB/qn23") != null)
                    {
                        cg.QnSecBQn23 = j.GetValue("Qn/secB/qn23").ToString();
                    }
                    if (j.GetValue("Qn/secC/qn24") != null)
                    {
                        cg.QnSecCQn24 = j.GetValue("Qn/secC/qn24").ToString();
                    }
                    if (j.GetValue("Qn/secC/qn25") != null)
                    {
                        cg.QnSecCQn25 = j.GetValue("Qn/secC/qn25").ToString();
                    }
                    if (j.GetValue("Qn/secC/qn26") != null)
                    {
                        cg.QnSecCQn26 = j.GetValue("Qn/secC/qn26").ToString();

                    }

                    if (j.GetValue("Qn/secC/qn27") != null)
                    {
                        cg.QnSecCQn27 = j.GetValue("Qn/secC/qn27").ToString();
                    }

                    if (j.GetValue("Qn/secC/qn28") != null)
                    {
                        cg.QnSecCQn28 = j.GetValue("Qn/secC/qn28").ToString();
                    }

                    if (j.GetValue("Qn/secC/qn29") != null)
                    {
                        cg.QnSecCQn29 = j.GetValue("Qn/secC/qn29").ToString();
                    }

                    if (j.GetValue("Qn/secC/qn30") != null)
                    {
                        cg.QnSecCQn30 = j.GetValue("Qn/secC/qn30").ToString();
                    }

                    if (j.GetValue("Qn/secC/qn31") != null)
                    {
                        cg.QnSecCQn31 = j.GetValue("Qn/secC/qn31").ToString();
                    }

                    if (j.GetValue("Qn/secC/qn32") != null)
                    {
                        cg.QnSecCQn32 = j.GetValue("Qn/secC/qn32").ToString();
                    }

                    if (j.GetValue("Qn/secC/qn33") != null)
                    {
                        cg.QnSecCQn33 = j.GetValue("Qn/secC/qn33").ToString();
                    }

                    if (j.GetValue("Qn/secC/qn34") != null)
                    {
                        cg.QnSecCQn34 = j.GetValue("Qn/secC/qn34").ToString();
                    }

                    if (j.GetValue("Qn/secC/qn35") != null)
                    {
                        cg.QnSecCQn35 = j.GetValue("Qn/secC/qn35").ToString();
                    }

                    if (j.GetValue("Qn/secC/qn36") != null)
                    {
                        cg.QnSecCQn36 = j.GetValue("Qn/secC/qn36").ToString();
                    }

                    if (j.GetValue("Qn/secC/qn37") != null)
                    {
                        cg.QnSecCQn37 = j.GetValue("Qn/secC/qn37").ToString();
                    }

                    if (j.GetValue("Qn/secD/qn38") != null)
                    {
                        cg.QnSecDQn38 = j.GetValue("Qn/secD/qn38").ToString();
                    }

                    if (j.GetValue("Qn/secD/qn39") != null)
                    {
                        cg.QnSecDQn39 = j.GetValue("Qn/secD/qn39").ToString();
                    }

                    if (j.GetValue("Qn/secD/qn40") != null)
                    {
                        cg.QnSecDQn40 = j.GetValue("Qn/secD/qn40").ToString();
                    }

                    if (j.GetValue("Qn/secD/qn41") != null)
                    {
                        cg.QnSecDQn41 = j.GetValue("Qn/secD/qn41").ToString();
                    }

                    if (j.GetValue("Qn/secD/qn42") != null)
                    {
                        cg.QnSecDQn42 = j.GetValue("Qn/secD/qn42").ToString();
                    }

                    if (j.GetValue("Qn/secD/qn43") != null)
                    {
                        cg.QnSecDQn43 = j.GetValue("Qn/secD/qn43").ToString();
                    }

                    if (j.GetValue("Qn/secD/qn44") != null)
                    {
                        cg.QnSecDQn44 = j.GetValue("Qn/secD/qn44").ToString();
                    }

                    if (j.GetValue("Qn/secD/qn45") != null)
                    {
                        cg.QnSecDQn45 = j.GetValue("Qn/secD/qn45").ToString();
                    }

                    if (j.GetValue("Qn/secD/qn46") != null)
                    {
                        cg.QnSecDQn46 = j.GetValue("Qn/secD/qn46").ToString();
                    }

                    if (j.GetValue("Qn/secD/qn47") != null)
                    {
                        cg.QnSecDQn47 = j.GetValue("Qn/secD/qn47").ToString();
                    }

                    if (j.GetValue("Qn/secD/qn48") != null)
                    {
                        cg.QnSecDQn48 = j.GetValue("Qn/secD/qn48").ToString();
                    }

                    if (j.GetValue("Qn/secD/qn49") != null)
                    {
                        cg.QnSecDQn49 = j.GetValue("Qn/secD/qn49").ToString();
                    }

                    if (j.GetValue("Qn/secD/qn50") != null)
                    {
                        cg.QnSecDQn50 = j.GetValue("Qn/secD/qn50").ToString();
                    }

                    if (j.GetValue("Qn/secD/qn51") != null)
                    {
                        cg.QnSecDQn51 = j.GetValue("Qn/secD/qn51").ToString();
                    }

                    if (j.GetValue("Qn/secD/qn52") != null)
                    {
                        cg.QnSecDQn52 = j.GetValue("Qn/secD/qn52").ToString();
                    }

                    if (j.GetValue("Qn/secD/qn53") != null)
                    {
                        cg.QnSecDQn53 = j.GetValue("Qn/secD/qn53").ToString();
                    }

                    if (j.GetValue("Qn/secD/qn54") != null)
                    {
                        cg.QnSecDQn54 = j.GetValue("Qn/secD/qn54").ToString();
                    }

                    if (j.GetValue("Qn/secA/patno") != null)
                    {
                        cg.QnSecAPatno = Convert.ToDouble(j.GetValue("Qn/secA/patno").ToString());
                    }

                    if (j.GetValue("Qn/secA/start") != null)
                    {
                        cg.QnSecAStart = j.GetValue("Qn/secA/start").ToString();
                    }

                    if (j.GetValue("meta/instanceID") != null)
                    {
                        cg.MetaInstanceId = j.GetValue("meta/instanceID").ToString();
                    }

                    if (j.GetValue("Qn/secA/ass_date") != null)
                    {
                        CultureInfo enUS = new CultureInfo("en-US");
                        string dateString;
                        DateTime dateValue;
                        // Use custom formats with M and MM.
                        dateString = j.GetValue("Qn/secA/ass_date").ToString();
                        //if (DateTime.TryParseExact(dateString, "M/dd/yyyy hh:mm", enUS,
                        if (DateTime.TryParse(dateString, out dateValue))
                        {
                            cg.QnSecAAssDate = dateValue;// Convert.ToDateTime(j.GetValue("_submission_time").ToString());
                        }
                    }
                    if (j.GetValue("Qn/secA/deviceid") != null)
                    {
                        cg.QnSecADeviceid = j.GetValue("Qn/secA/deviceid").ToString();
                    }

                    if (j.GetValue("Qn/secA/lastname") != null)
                    {
                        cg.QnSecALastname = j.GetValue("Qn/secA/lastname").ToString();
                    }

                    if (j.GetValue("Qn/secA/firstname") != null)
                    {
                        cg.QnSecAFirstname = j.GetValue("Qn/secA/firstname").ToString();
                    }

                    if (j.GetValue("Qn/secA/loc_parish") != null)
                    {
                        cg.QnSecALocParish = j.GetValue("Qn/secA/loc_parish").ToString();
                    }

                    if (j.GetValue("Qn/secA/loc_region") != null)
                    {
                        cg.QnSecALocRegion = j.GetValue("Qn/secA/loc_region").ToString();
                    }

                    if (j.GetValue("Qn/secA/loc_district") != null)
                    {
                        cg.QnSecALocDistrict = j.GetValue("Qn/secA/loc_district").ToString();
                    }

                    if (j.GetValue("Qn/secA/loc_subcounty") != null)
                    {
                        cg.QnSecALocSubcounty = j.GetValue("Qn/secA/loc_subcounty").ToString();
                    }


                    cg.LastUpdatedAt = DateTime.Now;

                    PostTest.Add(cg);
                }
                // careGroups = JsonConvert.DeserializeObject<List<McareGroupsData>>(content);

            }

            //this.chilliData = chilliGroups;

            return PostTest;
        }

        public async Task SavePostTestData()
        {
            try
            {
                using (var IcanContext = new USAID_ICANContext())
                {
                    var data = GetPosttestAgywRecords().ToList();
                    IcanContext.OnaPosttestAgyw.RemoveRange(IcanContext.OnaPosttestAgyw.ToList());
                    await IcanContext.SaveChangesAsync();
                    IcanContext.OnaPosttestAgyw.AddRange(data);
                    await IcanContext.SaveChangesAsync();

                    //send email after update                   
                    EmailModel email = new EmailModel(_context);
                    email.OnaPosttestAgywEmail();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion PostTestAGYW

        #region ChilliGroups

        public IEnumerable<Ona1Chilligrps> GetRecords()
        {
            //Load the data from the API
            var model = new object[0];
            var targeturl = string.Format("https://api.ona.io/api/v1/data/544915");
            //Jan - Mar
            HttpMessageHandler handler = new HttpClientHandler()
            {
            };

            var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(targeturl),
                Timeout = new TimeSpan(0, 20, 0)
            };

            List<Ona1Chilligrps> chilliGroups = new List<Ona1Chilligrps>();
            httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");

            //This is the key section you were missing    
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes("ican:abt@1can");
            string val = System.Convert.ToBase64String(plainTextBytes);
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + val);

            var method = new HttpMethod("GET");
            List<string> myList = new List<string>();

            JArray jArray = new JArray();
            HttpResponseMessage response = httpClient.GetAsync(targeturl).Result;
            if (response.ReasonPhrase == "Not Found")
            {
                //TempData["Message"] = string.Format("No records found for  {0}-{1}", reportingPeriod.Replace("%20", ""), financialYear.ToString()); ;
            }
            else
            {
                string content = string.Empty;

                using (StreamReader stream = new StreamReader(response.Content.ReadAsStreamAsync().Result, true))
                {
                    content = stream.ReadToEnd();
                }

                jArray = JArray.Parse(content);
                // Strip off the [] from _tags and Notes

                foreach (JObject j in jArray)
                {
                    var cg = new Ona1Chilligrps();

                    string dvalue = string.Empty;
                    double dnumber;
                    bool success = false;

                    cg.Id = Convert.ToInt32(j.GetValue("_id").ToString());

                    if (j.GetValue("_uuid") != null)
                    {
                        cg.Uuid = j.GetValue("_uuid").ToString();
                    }

                    if (j.GetValue("parish") != null)
                    {
                        cg.Parish = j.GetValue("parish").ToString();
                    }

                    if (j.GetValue("groupid") != null)
                    {

                        cg.Groupid = j.GetValue("groupid").ToString();
                    }

                    if (j.GetValue("village") != null)
                    {
                        cg.Village = j.GetValue("village").ToString();
                    }

                    if (j.GetValue("_version") != null)
                    {
                        cg.Version = j.GetValue("_version").ToString();
                    }

                    if (j.GetValue("district") != null)
                    {
                        cg.District = j.GetValue("district").ToString();
                    }

                    if (j.GetValue("_duration") != null)
                    {
                        cg.Duration = j.GetValue("_duration").ToString();
                    }

                    if (j.GetValue("groupname") != null)
                    {
                        cg.Groupname = j.GetValue("groupname").ToString();
                    }

                    //cg.Maleyouth = Convert.ToDouble(j.GetValue("maleyouth").ToString());
                    if (j.GetValue("maleyouth") != null)
                    {
                        cg.Maleyouth = Convert.ToDouble(j.GetValue("maleyouth").ToString());
                    }

                    if (j.GetValue("subcounty") != null)
                    {
                        cg.Subcounty = j.GetValue("subcounty").ToString();
                    }

                    //cg.Maleadults = Convert.ToDouble(j.GetValue("maleadults").ToString());
                    if (j.GetValue("maleadults") != null)
                    {
                        cg.Maleadults = Convert.ToDouble(j.GetValue("maleadults").ToString());
                    }

                    //cg.Femaleyouth = Convert.ToDouble(j.GetValue("femaleyouth").ToString());
                    if (j.GetValue("femaleyouth") != null)
                    {
                        cg.Femaleyouth = Convert.ToDouble(j.GetValue("femaleyouth").ToString());
                    }

                    //cg.Femaleadults = Convert.ToDouble(j.GetValue("femaleadults").ToString());
                    if (j.GetValue("femaleadults") != null)
                    {
                        cg.Femaleadults = Convert.ToDouble(j.GetValue("femaleadults").ToString());
                    }

                    if (j.GetValue("_submitted_by") != null)
                    {
                        cg.SubmittedBy = j.GetValue("_submitted_by").ToString();
                    }

                    if (j.GetValue("meta/instanceID") != null)
                    {
                        cg.MetaInstanceId = j.GetValue("meta/instanceID").ToString();
                    }

                    if (j.GetValue("_submission_time") != null)
                    {
                        CultureInfo enUS = new CultureInfo("en-US");
                        string dateString;
                        DateTime dateValue;
                        // Use custom formats with M and MM.
                        dateString = j.GetValue("_submission_time").ToString();
                        //if (DateTime.TryParseExact(dateString, "M/dd/yyyy hh:mm", enUS,
                        if (DateTime.TryParse(dateString, out dateValue))
                        {
                            cg.SubmissionTime = dateValue;// Convert.ToDateTime(j.GetValue("_submission_time").ToString());
                        }
                    }

                    //cg.Totalnumberofparticipants = Convert.ToDouble(j.GetValue("totalnumberofparticipants").ToString());
                    if (j.GetValue("totalnumberofparticipants") != null)
                    {
                        cg.Totalnumberofparticipants = Convert.ToDouble(j.GetValue("totalnumberofparticipants").ToString());
                    }

                    var a = j.GetValue("_geolocation") as object;
                    var c = a.ToString().Replace("\r", "").Replace("\n", "").Replace("[", "").Replace("]", "").Trim();
                    var b = c.Split(',');
                    if (b.Length == 2)
                    {
                        double d = 0;
                        if (double.TryParse(b[0], out d))
                        {
                            cg.Latitude = d;
                        }
                        if (double.TryParse(b[1], out d))
                        {
                            cg.Longitude = d;
                        }
                    }

                    cg.LastUpdatedAt = DateTime.Now;

                    chilliGroups.Add(cg);
                }
                // careGroups = JsonConvert.DeserializeObject<List<McareGroupsData>>(content);

            }

            //this.chilliData = chilliGroups;

            return chilliGroups;
        }

        public async Task SaveChilliData()
        {
            try
            {
                using (var IcanContext = new USAID_ICANContext())
                {
                    var data = GetRecords().ToList();
                    IcanContext.Ona1Chilligrps.RemoveRange(IcanContext.Ona1Chilligrps.ToList());
                    await IcanContext.SaveChangesAsync();
                    IcanContext.Ona1Chilligrps.AddRange(data);
                    await IcanContext.SaveChangesAsync();

                    //send email after update                   
                    EmailModel email = new EmailModel(_context);
                    email.Ona1ChilligrpsEmail();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion ChilliGroups

        #region CRCData       
        public IEnumerable<Ona1Crc> GetCRCRecords()
        {
            //Load the data from the API
            var model = new object[0];
            var targeturl = string.Format("https://api.ona.io/api/v1/data/488217");
            //Jan - Mar
            HttpMessageHandler handler = new HttpClientHandler()
            {
            };

            var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(targeturl),
                Timeout = new TimeSpan(0, 20, 0)
            };

            List<Ona1Crc> crcGroups = new List<Ona1Crc>();
            httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");

            //This is the key section you were missing    
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes("ican:abt@1can");
            string val = System.Convert.ToBase64String(plainTextBytes);
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + val);

            var method = new HttpMethod("GET");
            List<string> myList = new List<string>();

            JArray jArray = new JArray();
            HttpResponseMessage response = httpClient.GetAsync(targeturl).Result;
            if (response.ReasonPhrase == "Not Found")
            {
                //TempData["Message"] = string.Format("No records found for  {0}-{1}", reportingPeriod.Replace("%20", ""), financialYear.ToString()); ;
            }
            else
            {
                string content = string.Empty;

                using (StreamReader stream = new StreamReader(response.Content.ReadAsStreamAsync().Result, true))
                {
                    content = stream.ReadToEnd();
                }

                jArray = JArray.Parse(content);
                // Strip off the [] from _tags and Notes

                foreach (JObject j in jArray)
                {
                    var cg = new Ona1Crc();

                    string dvalue = string.Empty;
                    double dnumber;
                    bool success = false;

                    cg.Id = Convert.ToInt32(j.GetValue("_id").ToString());

                    if (j.GetValue("_uuid") != null)
                    {
                        cg.Uuid = j.GetValue("_uuid").ToString();
                    }

                    if (j.GetValue("parish") != null)
                    {
                        cg.Parish = j.GetValue("parish").ToString();
                    }

                    if (j.GetValue("school") != null)
                    {
                        cg.School = j.GetValue("school").ToString();
                    }



                    if (j.GetValue("village") != null)
                    {
                        cg.Village = j.GetValue("village").ToString();
                    }

                    if (j.GetValue("_version") != null)
                    {
                        cg.Version = j.GetValue("_version").ToString();
                    }

                    if (j.GetValue("district") != null)
                    {
                        cg.District = j.GetValue("district").ToString();
                    }

                    if (j.GetValue("latitude") != null)
                    {
                        cg.Latitude = Convert.ToDouble(j.GetValue("latitude").ToString());
                    }

                    if (j.GetValue("schoolid") != null)
                    {
                        cg.Schoolid = j.GetValue("schoolid").ToString();
                    }

                    if (j.GetValue("_duration") != null)
                    {
                        cg.Duration = j.GetValue("_duration").ToString();
                    }

                    cg.XformId = Convert.ToInt32(j.GetValue("_xform_id").ToString());

                    if (j.GetValue("longitude") != null)
                    {
                        cg.Longitude = Convert.ToDouble(j.GetValue("longitude").ToString());
                    }

                    if (j.GetValue("subcounty") != null)
                    {
                        cg.Subcounty = j.GetValue("subcounty").ToString();
                    }

                    if (j.GetValue("schoolname") != null)
                    {
                        cg.Schoolname = j.GetValue("schoolname").ToString();
                    }

                    if (j.GetValue("_submitted_by") != null)
                    {
                        cg.SubmittedBy = j.GetValue("_submitted_by").ToString();
                    }

                    if (j.GetValue("meta/instanceID") != null)
                    {
                        cg.MetaInstanceId = j.GetValue("meta/instanceID").ToString();
                    }

                    if (j.GetValue("_submission_time") != null)
                    {
                        CultureInfo enUS = new CultureInfo("en-US");
                        string dateString;
                        DateTime dateValue;
                        // Use custom formats with M and MM.
                        dateString = j.GetValue("_submission_time").ToString();
                        //if (DateTime.TryParseExact(dateString, "M/dd/yyyy hh:mm", enUS,
                        if (DateTime.TryParse(dateString, out dateValue))
                        {
                            cg.SubmissionTime = dateValue;// Convert.ToDateTime(j.GetValue("_submission_time").ToString());
                        }

                        cg.LastUpdatedAt = DateTime.Now;
                    }
                    crcGroups.Add(cg);
                }
            }

            //this.crcData = crcGroups;

            return crcGroups;
        }

        public async Task SaveCRCData()
        {
            try
            {
                using (var IcanContext = new USAID_ICANContext())
                {
                    var data = GetCRCRecords().ToList();
                    IcanContext.Ona1Crc.RemoveRange(IcanContext.Ona1Crc.ToList());
                    await IcanContext.SaveChangesAsync();
                    IcanContext.Ona1Crc.AddRange(data);
                    await IcanContext.SaveChangesAsync();

                    //send email after update                   
                    EmailModel email = new EmailModel(_context);
                    email.Ona1CRCEmail();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion CRCData

        #region Lgroups
        public IEnumerable<Ona1Lgroups> GetLgroupsRecords()
        {
            //Load the data from the API
            var model = new object[0];
            var targeturl = string.Format("https://api.ona.io/api/v1/data/487256");
            //Jan - Mar
            HttpMessageHandler handler = new HttpClientHandler()
            {
            };

            var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(targeturl),
                Timeout = new TimeSpan(0, 20, 0)
            };

            List<Ona1Lgroups> LGroups = new List<Ona1Lgroups>();
            httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");

            //This is the key section you were missing    
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes("ican:abt@1can");
            string val = System.Convert.ToBase64String(plainTextBytes);
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + val);

            var method = new HttpMethod("GET");
            List<string> myList = new List<string>();

            JArray jArray = new JArray();
            HttpResponseMessage response = httpClient.GetAsync(targeturl).Result;
            if (response.ReasonPhrase == "Not Found")
            {
                //TempData["Message"] = string.Format("No records found for  {0}-{1}", reportingPeriod.Replace("%20", ""), financialYear.ToString()); ;
            }
            else
            {
                string content = string.Empty;

                using (StreamReader stream = new StreamReader(response.Content.ReadAsStreamAsync().Result, true))
                {
                    content = stream.ReadToEnd();
                }

                jArray = JArray.Parse(content);
                // Strip off the [] from _tags and Notes

                foreach (JObject j in jArray)
                {
                    var cg = new Ona1Lgroups();

                    string dvalue = string.Empty;
                    double dnumber;
                    bool success = false;

                    cg.Id = Convert.ToInt32(j.GetValue("_id").ToString());

                    if (j.GetValue("_uuid") != null)
                    {
                        cg.Uuid = j.GetValue("_uuid").ToString();
                    }

                    if (j.GetValue("parish") != null)
                    {
                        cg.Parish = j.GetValue("parish").ToString();
                    }

                    if (j.GetValue("groupid") != null)
                    {
                        cg.Groupid = j.GetValue("groupid").ToString();
                    }

                    if (j.GetValue("village") != null)
                    {
                        cg.Village = j.GetValue("village").ToString();
                    }

                    if (j.GetValue("_version") != null)
                    {
                        cg.Version = j.GetValue("_version").ToString();
                    }

                    if (j.GetValue("district") != null)
                    {
                        cg.District = j.GetValue("district").ToString();
                    }

                    if (j.GetValue("latitude") != null)
                    {
                        string a = j.GetValue("latitude").ToString().Trim();
                        double b = 0;
                        if (double.TryParse(a, out b))
                        {
                            cg.Latitude = b;
                        }
                        else
                        {

                        }
                    }

                    //cg._latitude_latitude = Convert.ToInt32(j.GetValue("_latitude_latitude").ToString());

                    if (j.GetValue("_duration") != null)
                    {
                        cg.Duration = j.GetValue("_duration").ToString();
                    }

                    cg.XformId = Convert.ToInt32(j.GetValue("_xform_id").ToString());

                    if (j.GetValue("groupname") != null)
                    {
                        cg.Groupname = j.GetValue("groupname").ToString();
                    }

                    if (j.GetValue("longitude") != null)
                    {
                        //cg.Longitude = Convert.ToDouble(j.GetValue("longitude").ToString().Trim());

                        string a = j.GetValue("longitude").ToString().Trim();
                        double b = 0;
                        if (double.TryParse(a, out b))
                        {
                            cg.Longitude = b;
                        }
                        else
                        {

                        }
                    }

                    //cg._longitude_latitude = Convert.ToInt32(j.GetValue("_longitude_latitude").ToString());

                    if (j.GetValue("subcounty") != null)
                    {
                        cg.Subcounty = j.GetValue("subcounty").ToString();
                    }

                    if (j.GetValue("_submitted_by") != null)
                    {
                        cg.SubmittedBy = j.GetValue("_submitted_by").ToString();
                    }

                    if (j.GetValue("meta/instanceID") != null)
                    {
                        cg.MetaInstanceId = j.GetValue("meta/instanceID").ToString();
                    }

                    if (j.GetValue("_submission_time") != null)
                    {
                        CultureInfo enUS = new CultureInfo("en-US");
                        string dateString;
                        DateTime dateValue;
                        // Use custom formats with M and MM.
                        dateString = j.GetValue("_submission_time").ToString();
                        //if (DateTime.TryParseExact(dateString, "M/dd/yyyy hh:mm", enUS,
                        if (DateTime.TryParse(dateString, out dateValue))
                        {
                            cg.SubmissionTime = dateValue;// Convert.ToDateTime(j.GetValue("_submission_time").ToString());
                        }
                    }

                    if (j.GetValue("maleyouth") != null)
                    {
                        cg.Maleyouth = Convert.ToDouble(j.GetValue("maleyouth").ToString());
                    }

                    if (j.GetValue("femaleyouth") != null)
                    {
                        cg.Femaleyouth = Convert.ToDouble(j.GetValue("femaleyouth").ToString());
                    }

                    if (j.GetValue("maleadults") != null)
                    {
                        cg.Maleadults = Convert.ToDouble(j.GetValue("maleadults").ToString());
                    }

                    if (j.GetValue("femaleadults") != null)
                    {
                        cg.Femaleadults = Convert.ToDouble(j.GetValue("femaleadults").ToString());
                    }

                    if (j.GetValue("total") != null)
                    {
                        cg.Total = Convert.ToDouble(j.GetValue("total").ToString());
                    }

                    cg.LastUpdatedAt = DateTime.Now;

                    LGroups.Add(cg);
                }
                // careGroups = JsonConvert.DeserializeObject<List<McareGroupsData>>(content);
            }

            //this.LgroupsData = LGroups;

            return LGroups;
        }

        public async Task SaveLgroupsData()
        {
            try
            {
                using (var IcanContext = new USAID_ICANContext())
                {
                    var data = GetLgroupsRecords().ToList();
                    IcanContext.Ona1Lgroups.RemoveRange(IcanContext.Ona1Lgroups.ToList());
                    await IcanContext.SaveChangesAsync();
                    IcanContext.Ona1Lgroups.AddRange(data);
                    await IcanContext.SaveChangesAsync();

                    //send email after update                   
                    EmailModel email = new EmailModel(_context);
                    email.Ona1LgroupsEmail();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Lgroups

        #region MCareGroups

        public IEnumerable<Ona1McareGroups> GetMCareGroupsRecords()
        {
            //Load the data from the API
            var model = new object[0];
            var targeturl = string.Format("https://api.ona.io/api/v1/data/489367");
            //Jan - Mar
            HttpMessageHandler handler = new HttpClientHandler()
            {
            };

            var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(targeturl),
                Timeout = new TimeSpan(0, 20, 0)
            };

            List<Ona1McareGroups> careGroups = new List<Ona1McareGroups>();
            httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");

            //This is the key section you were missing    
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes("ican:abt@1can");
            string val = System.Convert.ToBase64String(plainTextBytes);
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + val);

            var method = new HttpMethod("GET");
            List<string> myList = new List<string>();

            JArray jArray = new JArray();
            HttpResponseMessage response = httpClient.GetAsync(targeturl).Result;
            if (response.ReasonPhrase == "Not Found")
            {
                //TempData["Message"] = string.Format("No records found for  {0}-{1}", reportingPeriod.Replace("%20", ""), financialYear.ToString()); ;
            }
            else
            {
                string content = string.Empty;

                using (StreamReader stream = new StreamReader(response.Content.ReadAsStreamAsync().Result, true))
                {
                    content = stream.ReadToEnd();
                }

                jArray = JArray.Parse(content);
                // Strip off the [] from _tags and Notes

                foreach (JObject j in jArray)
                {
                    var cg = new Ona1McareGroups();

                    string dvalue = string.Empty;
                    double dnumber;
                    bool success = false;

                    cg.Id = Convert.ToInt32(j.GetValue("_id").ToString());

                    if (j.GetValue("_uuid") != null)
                    {
                        cg.Uuid = j.GetValue("_uuid").ToString();
                    }

                    if (j.GetValue("groupid") != null)
                    {

                        cg.Groupid = j.GetValue("groupid").ToString();
                    }

                    if (j.GetValue("village") != null)
                    {
                        cg.Village = j.GetValue("village").ToString();
                    }

                    if (j.GetValue("_version") != null)
                    {
                        cg.Version = j.GetValue("_version").ToString();
                    }

                    if (j.GetValue("district") != null)
                    {
                        cg.District = j.GetValue("district").ToString();
                    }

                    if (j.GetValue("latitude") != null)
                    {
                        cg.Latitude = Convert.ToDouble(j.GetValue("latitude").ToString());
                    }

                    if (j.GetValue("_duration") != null)
                    {
                        cg.Duration = j.GetValue("_duration").ToString();
                    }

                    cg.XformId = Convert.ToInt32(j.GetValue("_xform_id").ToString());

                    if (j.GetValue("groupname") != null)
                    {
                        cg.Groupname = j.GetValue("groupname").ToString();
                    }

                    if (j.GetValue("longitude") != null)
                    {
                        cg.Longitude = Convert.ToDouble(j.GetValue("longitude").ToString());
                    }

                    if (j.GetValue("subcounty") != null)
                    {
                        cg.Subcounty = j.GetValue("subcounty").ToString();
                    }

                    if (j.GetValue("_submitted_by") != null)
                    {
                        cg.SubmittedBy = j.GetValue("_submitted_by").ToString();
                    }

                    if (j.GetValue("meta/instanceID") != null)
                    {
                        cg.MetaInstanceId = j.GetValue("meta/instanceID").ToString();
                    }

                    if (j.GetValue("_submission_time") != null)
                    {
                        CultureInfo enUS = new CultureInfo("en-US");
                        string dateString;
                        DateTime dateValue;
                        // Use custom formats with M and MM.
                        dateString = j.GetValue("_submission_time").ToString();
                        //if (DateTime.TryParseExact(dateString, "M/dd/yyyy hh:mm", enUS,
                        if (DateTime.TryParse(dateString, out dateValue))
                        {
                            cg.SubmissionTime = dateValue;// Convert.ToDateTime(j.GetValue("_submission_time").ToString());
                        }
                    }

                    cg.LastUpdatedAt = DateTime.Now;

                    careGroups.Add(cg);
                }
                // careGroups = JsonConvert.DeserializeObject<List<McareGroupsData>>(content);

                //content = content.TrimStart(new char[] { '[' }).TrimEnd(new char[] { ']' });
                //JObject ovcmis = JObject.Parse(content); 
            }

            //this.mcgData = careGroups;

            return careGroups;
        }

        public async Task SaveMCareGroupsData()
        {
            try
            {
                using (var IcanContext = new USAID_ICANContext())
                {
                    var data = GetMCareGroupsRecords().ToList();
                    IcanContext.Ona1McareGroups.RemoveRange(IcanContext.Ona1McareGroups.ToList());
                    await IcanContext.SaveChangesAsync();
                    IcanContext.Ona1McareGroups.AddRange(data);
                    await IcanContext.SaveChangesAsync();

                    //send email after update                   
                    EmailModel email = new EmailModel(_context);
                    email.Ona1McareGroupsEmail();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion MCareGroups

        #region Samplegrps
        public IEnumerable<Ona1samplegrps> GetsamplegrpsRecords()
        {
            //Load the data from the API
            var model = new object[0];
            var targeturl = string.Format("https://api.ona.io/api/v1/data/537317");
            //Jan - Mar
            HttpMessageHandler handler = new HttpClientHandler()
            {
            };

            var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(targeturl),
                Timeout = new TimeSpan(0, 20, 0)
            };


            List<Ona1samplegrps> samGroups = new List<Ona1samplegrps>();
            httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");

            //This is the key section you were missing    
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes("ican:abt@1can");
            string val = System.Convert.ToBase64String(plainTextBytes);
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + val);

            var method = new HttpMethod("GET");
            List<string> myList = new List<string>();

            JArray jArray = new JArray();
            HttpResponseMessage response = httpClient.GetAsync(targeturl).Result;
            if (response.ReasonPhrase == "Not Found")
            {
                //TempData["Message"] = string.Format("No records found for  {0}-{1}", reportingPeriod.Replace("%20", ""), financialYear.ToString()); ;
            }
            else
            {
                string content = string.Empty;

                using (StreamReader stream = new StreamReader(response.Content.ReadAsStreamAsync().Result, true))
                {
                    content = stream.ReadToEnd();
                }

                jArray = JArray.Parse(content);
                // Strip off the [] from _tags and Notes


                foreach (JObject j in jArray)
                {
                    var cg = new Ona1samplegrps();

                    string dvalue = string.Empty;
                    double dnumber;
                    bool success = false;

                    cg.Id = Convert.ToInt32(j.GetValue("_id").ToString());

                    if (j.GetValue("_uuid") != null)
                    {
                        cg.Uuid = j.GetValue("_uuid").ToString();
                    }

                    if (j.GetValue("parish") != null)
                    {
                        cg.Parish = j.GetValue("parish").ToString();
                    }

                    if (j.GetValue("groupid") != null)
                    {

                        cg.Groupid = j.GetValue("groupid").ToString();
                    }

                    if (j.GetValue("village") != null)
                    {
                        cg.Village = j.GetValue("village").ToString();
                    }

                    if (j.GetValue("_version") != null)
                    {
                        cg.Version = j.GetValue("_version").ToString();
                    }

                    if (j.GetValue("district") != null)
                    {
                        cg.District = j.GetValue("district").ToString();
                    }

                    cg.Latitude = Convert.ToDouble(j.GetValue("latitude").ToString());

                    if (j.GetValue("_duration") != null)
                    {
                        cg.Duration = j.GetValue("_duration").ToString();
                    }

                    cg.XformId = Convert.ToInt32(j.GetValue("_xform_id").ToString());

                    if (j.GetValue("groupname") != null)
                    {
                        cg.Groupname = j.GetValue("groupname").ToString();
                    }

                    cg.Longitude = Convert.ToDouble(j.GetValue("longitude").ToString());


                    if (j.GetValue("subcounty") != null)
                    {
                        cg.Subcounty = j.GetValue("subcounty").ToString();
                    }

                    if (j.GetValue("_submitted_by") != null)
                    {
                        cg.SubmittedBy = j.GetValue("_submitted_by").ToString();
                    }

                    if (j.GetValue("meta/instanceID") != null)
                    {
                        cg.MetaInstanceId = j.GetValue("meta/instanceID").ToString();
                    }

                    if (j.GetValue("_submission_time") != null)
                    {
                        CultureInfo enUS = new CultureInfo("en-US");
                        string dateString;
                        DateTime dateValue;
                        // Use custom formats with M and MM.
                        dateString = j.GetValue("_submission_time").ToString();
                        //if (DateTime.TryParseExact(dateString, "M/dd/yyyy hh:mm", enUS,
                        if (DateTime.TryParse(dateString, out dateValue))
                        {
                            cg.SubmissionTime = dateValue;// Convert.ToDateTime(j.GetValue("_submission_time").ToString());
                        }
                    }

                    cg.LastUpdatedAt = DateTime.Now;

                    samGroups.Add(cg);
                }
            }
            // careGroups = JsonConvert.DeserializeObject<List<McareGroupsData>>(content);


            //this.samgrpsData = samGroups;

            return samGroups;
        }

        public async Task SaveSampleGroupsData()
        {
            try
            {
                using (var IcanContext = new USAID_ICANContext())
                {
                    var data = GetsamplegrpsRecords().ToList();
                    IcanContext.Ona1samplegrps.RemoveRange(IcanContext.Ona1samplegrps.ToList());
                    await IcanContext.SaveChangesAsync();
                    IcanContext.Ona1samplegrps.AddRange(data);
                    await IcanContext.SaveChangesAsync();

                    //send email after update                   
                    EmailModel email = new EmailModel(_context);
                    email.Ona1samplegrpsEmail();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Samplegrps

        #region AGYW2020

        public IEnumerable<OnaAgyw2020> GetagywRecords()
        {
            //Load the data from the API
            var model = new object[0];
            var targeturl = string.Format("https://api.ona.io/api/v1/data/523795");
            //Jan - Mar
            HttpMessageHandler handler = new HttpClientHandler()
            {
            };

            var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(targeturl),
                Timeout = new TimeSpan(0, 20, 0)
            };

            List<OnaAgyw2020> agyw2020 = new List<OnaAgyw2020>();
            httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");

            //This is the key section you were missing    
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes("ican:abt@1can");
            string val = System.Convert.ToBase64String(plainTextBytes);
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + val);

            var method = new HttpMethod("GET");
            List<string> myList = new List<string>();

            JArray jArray = new JArray();
            HttpResponseMessage response = httpClient.GetAsync(targeturl).Result;
            if (response.ReasonPhrase == "Not Found")
            {
                //TempData["Message"] = string.Format("No records found for  {0}-{1}", reportingPeriod.Replace("%20", ""), financialYear.ToString()); ;
            }
            else
            {
                string content = string.Empty;

                using (StreamReader stream = new StreamReader(response.Content.ReadAsStreamAsync().Result, true))
                {
                    content = stream.ReadToEnd();
                }

                jArray = JArray.Parse(content);
                // Strip off the [] from _tags and Notes


                foreach (JObject j in jArray)
                {
                    var cg = new OnaAgyw2020();

                    string dvalue = string.Empty;
                    double dnumber;
                    bool success = false;

                    if (j.GetValue("fo") != null)
                    {
                        cg.Fo = j.GetValue("fo").ToString();
                    }

                    cg.Id = Convert.ToInt32(j.GetValue("_id").ToString());

                    if (j.GetValue("end") != null)
                    {
                        cg.Endd = j.GetValue("end").ToString();
                    }

                    if (j.GetValue("year") != null)
                    {
                        cg.Year = j.GetValue("year").ToString();
                    }

                    if (j.GetValue("_uuid") != null)
                    {
                        cg.Uuid = j.GetValue("_uuid").ToString();
                    }

                    if (j.GetValue("month") != null)
                    {
                        cg.Month = j.GetValue("month").ToString();
                    }

                    if (j.GetValue("start") != null)
                    {
                        cg.Start = j.GetValue("start").ToString();
                    }

                    if (j.GetValue("calc_yr") != null)
                    {
                        cg.CalcYr = j.GetValue("calc_yr").ToString();
                    }

                    if (j.GetValue("curr_yr") != null)
                    {
                        cg.CurrYr = j.GetValue("curr_yr").ToString();
                    }

                    if (j.GetValue("village") != null)
                    {
                        cg.Village = j.GetValue("village").ToString();
                    }

                    if (j.GetValue("_version") != null)
                    {
                        cg.Version = j.GetValue("_version").ToString();
                    }

                    if (j.GetValue("deviceid") != null)
                    {
                        cg.Deviceid = j.GetValue("deviceid").ToString();
                    }

                    if (j.GetValue("district") != null)
                    {
                        cg.District = j.GetValue("district").ToString();
                    }

                    cg.Duration = Convert.ToDouble(j.GetValue("_duration").ToString());

                    cg.XformId = Convert.ToInt32(j.GetValue("_xform_id").ToString());

                    if (j.GetValue("subcounty") != null)
                    {
                        cg.Subcounty = j.GetValue("subcounty").ToString();
                    }

                    if (j.GetValue("sectionA/ms") != null)
                    {
                        cg.SectionAMs = j.GetValue("sectionA/ms").ToString();
                    }


                    if (j.GetValue("sectionA/act") != null)
                    {
                        cg.SectionAAct = j.GetValue("sectionA/act").ToString();
                    }

                    cg.SectionAAge = Convert.ToInt32(j.GetValue("sectionA/age").ToString());


                    if (j.GetValue("sectionB/biz") != null)
                    {
                        cg.SectionBBiz = j.GetValue("sectionB/biz").ToString();
                    }

                    if (j.GetValue("_submitted_by") != null)
                    {
                        cg.SubmittedBy = j.GetValue("_submitted_by").ToString();
                    }

                    if (j.GetValue("sectionA/educ") != null)
                    {
                        cg.SectionAEduc = j.GetValue("sectionA/educ").ToString();
                    }

                    if (j.GetValue("sectionA/preg") != null)
                    {
                        cg.SectionAPreg = j.GetValue("sectionA/preg").ToString();
                    }

                    if (j.GetValue("sectionA/read") != null)
                    {
                        cg.SectionARead = j.GetValue("sectionA/read").ToString();
                    }

                    if (j.GetValue("sectionB/make") != null)
                    {
                        cg.SectionBMake = j.GetValue("sectionB/make").ToString();
                    }

                    if (j.GetValue("sectionA/fname") != null)
                    {
                        cg.SectionAFname = j.GetValue("sectionA/fname").ToString();
                    }

                    if (j.GetValue("sectionB/money") != null)
                    {
                        cg.SectionBMoney = j.GetValue("sectionB/money").ToString();
                    }

                    if (j.GetValue("sectionB/spent") != null)
                    {
                        cg.SectionBSpent = j.GetValue("sectionB/spent").ToString();
                    }

                    if (j.GetValue("meta/instanceID") != null)
                    {
                        cg.MetaInstanceId = j.GetValue("meta/instanceID").ToString();
                    }

                    if (j.GetValue("sectionB/income") != null)
                    {
                        cg.SectionBIncome = j.GetValue("sectionB/income").ToString();
                    }

                    if (j.GetValue("_submission_time") != null)
                    {
                        CultureInfo enUS = new CultureInfo("en-US");
                        string dateString;
                        DateTime dateValue;
                        // Use custom formats with M and MM.
                        dateString = j.GetValue("_submission_time").ToString();
                        //if (DateTime.TryParseExact(dateString, "M/dd/yyyy hh:mm", enUS,
                        if (DateTime.TryParse(dateString, out dateValue))
                        {
                            cg.SubmissionTime = dateValue;// Convert.ToDateTime(j.GetValue("_submission_time").ToString());
                        }
                    }

                    if (j.GetValue("sectionA/disable") != null)
                    {
                        cg.SectionADisable = j.GetValue("sectionA/disable").ToString();
                    }

                    if (j.GetValue("sectionA/surname") != null)
                    {
                        cg.SectionASurname = j.GetValue("sectionA/surname").ToString();
                    }

                    if (j.GetValue("sectionB/live_tr") != null)
                    {
                        cg.SectionBLiveTr = j.GetValue("sectionB/live_tr").ToString();
                    }

                    if (j.GetValue("sectionA/noschool") != null)
                    {
                        cg.SectionANoschool = j.GetValue("sectionA/noschool").ToString();
                    }
                    if (j.GetValue("sectionB/live_act") != null)
                    {
                        cg.SectionBLiveAct = j.GetValue("sectionB/live_act").ToString();
                    }

                    if (j.GetValue("sectionA/live_with") != null)
                    {
                        cg.SectionALiveWith = j.GetValue("sectionA/live_with").ToString();
                    }

                    if (j.GetValue("sectionB/saving_grp") != null)
                    {
                        cg.SectionBSavingGrp = j.GetValue("sectionB/saving_grp").ToString();
                    }

                    if (j.GetValue("sec2sectionA/prepost1") != null)
                    {
                        cg.Sec2sectionAPrepost1 = j.GetValue("sec2sectionA/prepost1").ToString();
                    }

                    if (j.GetValue("sec2sectionA/prepost2") != null)
                    {
                        cg.Sec2sectionAPrepost2 = j.GetValue("sec2sectionA/prepost2").ToString();
                    }

                    if (j.GetValue("sec2sectionA/prepost3") != null)
                    {
                        cg.Sec2sectionAPrepost3 = j.GetValue("sec2sectionA/prepost3").ToString();
                    }

                    if (j.GetValue("sec2sectionA/prepost4") != null)
                    {
                        cg.Sec2sectionAPrepost4 = j.GetValue("sec2sectionA/prepost4").ToString();
                    }

                    if (j.GetValue("sec2sectionA/prepost5") != null)
                    {
                        cg.Sec2sectionAPrepost5 = j.GetValue("sec2sectionA/prepost5").ToString();
                    }

                    if (j.GetValue("sec2sectionA/prepost6") != null)
                    {
                        cg.Sec2sectionAPrepost6 = j.GetValue("sec2sectionA/prepost6").ToString();
                    }

                    if (j.GetValue("sec2sectionA/prepost7") != null)
                    {
                        cg.Sec2sectionAPrepost7 = j.GetValue("sec2sectionA/prepost7").ToString();
                    }

                    if (j.GetValue("sec2sectionA/prepost8") != null)
                    {
                        cg.Sec2sectionAPrepost8 = j.GetValue("sec2sectionA/prepost8").ToString();
                    }

                    if (j.GetValue("sec2sectionB/prepost9") != null)
                    {
                        cg.Sec2sectionBPrepost9 = j.GetValue("sec2sectionB/prepost9").ToString();
                    }

                    if (j.GetValue("sec2sectionB/prepost10") != null)
                    {
                        cg.Sec2sectionBPrepost10 = j.GetValue("sec2sectionB/prepost10").ToString();
                    }

                    if (j.GetValue("sec2sectionB/prepost11") != null)
                    {
                        cg.Sec2sectionBPrepost11 = j.GetValue("sec2sectionB/prepost11").ToString();
                    }

                    if (j.GetValue("sec2sectionB/prepost12") != null)
                    {
                        cg.Sec2sectionBPrepost12 = j.GetValue("sec2sectionB/prepost12").ToString();
                    }

                    if (j.GetValue("sec2sectionB/prepost13") != null)
                    {
                        cg.Sec2sectionBPrepost13 = j.GetValue("sec2sectionB/prepost13").ToString();
                    }

                    if (j.GetValue("sec2sectionB/prepost14") != null)
                    {
                        cg.Sec2sectionBPrepost14 = j.GetValue("sec2sectionB/prepost14").ToString();
                    }

                    if (j.GetValue("sec2sectionB/prepost15") != null)
                    {
                        cg.Sec2sectionBPrepost15 = j.GetValue("sec2sectionB/prepost15").ToString();
                    }

                    if (j.GetValue("sec2sectionB/prepost16") != null)
                    {
                        cg.Sec2sectionBPrepost16 = j.GetValue("sec2sectionB/prepost16").ToString();
                    }

                    if (j.GetValue("sec2sectionC/prepost17") != null)
                    {
                        cg.Sec2sectionCPrepost17 = j.GetValue("sec2sectionC/prepost17").ToString();
                    }

                    if (j.GetValue("sec2sectionC/prepost18") != null)
                    {
                        cg.Sec2sectionCPrepost18 = j.GetValue("sec2sectionC/prepost18").ToString();
                    }

                    if (j.GetValue("sec2sectionC/prepost19") != null)
                    {
                        cg.Sec2sectionCPrepost19 = j.GetValue("sec2sectionC/prepost19").ToString();
                    }

                    if (j.GetValue("sec2sectionC/prepost20") != null)
                    {
                        cg.Sec2sectionCPrepost20 = j.GetValue("sec2sectionC/prepost20").ToString();
                    }

                    if (j.GetValue("sec2sectionC/prepost21") != null)
                    {
                        cg.Sec2sectionCPrepost21 = j.GetValue("sec2sectionC/prepost21").ToString();
                    }

                    if (j.GetValue("sec2sectionC/prepost22") != null)
                    {
                        cg.Sec2sectionCPrepost22 = j.GetValue("sec2sectionC/prepost22").ToString();
                    }

                    if (j.GetValue("sec2sectionD/prepost23") != null)
                    {
                        cg.Sec2sectionDPrepost23 = j.GetValue("sec2sectionD/prepost23").ToString();
                    }

                    if (j.GetValue("sec2sectionD/prepost24") != null)
                    {
                        cg.Sec2sectionDPrepost24 = j.GetValue("sec2sectionD/prepost24").ToString();
                    }

                    if (j.GetValue("sec2sectionD/prepost25") != null)
                    {
                        cg.Sec2sectionDPrepost25 = j.GetValue("sec2sectionD/prepost25").ToString();
                    }

                    if (j.GetValue("sec2sectionD/prepost26") != null)
                    {
                        cg.Sec2sectionDPrepost26 = j.GetValue("sec2sectionD/prepost26").ToString();
                    }

                    if (j.GetValue("sec2sectionD/prepost27") != null)
                    {
                        cg.Sec2sectionDPrepost27 = j.GetValue("sec2sectionD/prepost27").ToString();
                    }

                    if (j.GetValue("sec2sectionD/prepost28") != null)
                    {
                        cg.Sec2sectionDPrepost28 = j.GetValue("sec2sectionD/prepost28").ToString();
                    }

                    if (j.GetValue("sec2sectionE/prepost29") != null)
                    {
                        cg.Sec2sectionEPrepost29 = j.GetValue("sec2sectionE/prepost29").ToString();
                    }

                    if (j.GetValue("sec2sectionE/prepost30") != null)
                    {
                        cg.Sec2sectionEPrepost30 = j.GetValue("sec2sectionE/prepost30").ToString();
                    }

                    if (j.GetValue("sec2sectionE/prepost31") != null)
                    {
                        cg.Sec2sectionEPrepost31 = j.GetValue("sec2sectionE/prepost31").ToString();
                    }

                    if (j.GetValue("sec2sectionE/prepost32") != null)
                    {
                        cg.Sec2sectionEPrepost32 = j.GetValue("sec2sectionE/prepost32").ToString();
                    }

                    if (j.GetValue("sec2sectionE/prepost33") != null)
                    {
                        cg.Sec2sectionEPrepost33 = j.GetValue("sec2sectionE/prepost33").ToString();
                    }

                    if (j.GetValue("sec2sectionE/prepost34") != null)
                    {
                        cg.Sec2sectionEPrepost34 = j.GetValue("sec2sectionE/prepost34").ToString();
                    }

                    if (j.GetValue("sec2sectionF/prepost35") != null)
                    {
                        cg.Sec2sectionFPrepost35 = j.GetValue("sec2sectionF/prepost35").ToString();
                    }

                    if (j.GetValue("sec2sectionF/prepost36") != null)
                    {
                        cg.Sec2sectionFPrepost36 = j.GetValue("sec2sectionF/prepost36").ToString();
                    }

                    if (j.GetValue("sec2sectionF/prepost37") != null)
                    {
                        cg.Sec2sectionFPrepost37 = j.GetValue("sec2sectionF/prepost37").ToString();
                    }

                    if (j.GetValue("sec2sectionF/prepost38") != null)
                    {
                        cg.Sec2sectionFPrepost38 = j.GetValue("sec2sectionF/prepost38").ToString();
                    }

                    if (j.GetValue("sec2sectionF/prepost39") != null)
                    {
                        cg.Sec2sectionFPrepost39 = j.GetValue("sec2sectionF/prepost39").ToString();
                    }

                    if (j.GetValue("sec2sectionF/prepost40") != null)
                    {
                        cg.Sec2sectionFPrepost40 = j.GetValue("sec2sectionF/prepost40").ToString();
                    }

                    if (j.GetValue("sec2sectionG/prepost41") != null)
                    {
                        cg.Sec2sectionGPrepost41 = j.GetValue("sec2sectionG/prepost41").ToString();
                    }

                    if (j.GetValue("sec2sectionG/prepost42") != null)
                    {
                        cg.Sec2sectionGPrepost42 = j.GetValue("sec2sectionG/prepost42").ToString();
                    }

                    if (j.GetValue("sec2sectionG/prepost43") != null)
                    {
                        cg.Sec2sectionGPrepost43 = j.GetValue("sec2sectionG/prepost43").ToString();
                    }

                    if (j.GetValue("sec2sectionG/prepost44") != null)
                    {
                        cg.Sec2sectionGPrepost44 = j.GetValue("sec2sectionG/prepost44").ToString();
                    }

                    if (j.GetValue("sec2sectionG/prepost45") != null)
                    {
                        cg.Sec2sectionGPrepost45 = j.GetValue("sec2sectionG/prepost45").ToString();
                    }

                    if (j.GetValue("sec2sectionG/prepost46") != null)
                    {
                        cg.Sec2sectionGPrepost46 = j.GetValue("sec2sectionG/prepost46").ToString();
                    }

                    if (j.GetValue("sec2sectionG/prepost47") != null)
                    {
                        cg.Sec2sectionGPrepost47 = j.GetValue("sec2sectionG/prepost47").ToString();
                    }

                    var a = j.GetValue("_geolocation") as object;
                    var c = a.ToString().Replace("\r", "").Replace("\n", "").Replace("[", "").Replace("]", "").Trim();
                    var b = c.Split(',');
                    if (b.Length == 2)
                    {
                        double d = 0;
                        if (double.TryParse(b[0], out d))
                        {
                            cg.Latitude = d;
                        }
                        if (double.TryParse(b[1], out d))
                        {
                            cg.Longitude = d;
                        }
                    }

                    cg.LastUpdatedAt = DateTime.Now;

                    agyw2020.Add(cg);
                }
            }

            //this.agData = agyw2020;

            return agyw2020;
        }

        public async Task SaveAGYW2020Data()
        {
            try
            {
                using (var IcanContext = new USAID_ICANContext())
                {
                    var data = GetagywRecords().ToList();
                    IcanContext.OnaAgyw2020.RemoveRange(IcanContext.OnaAgyw2020.ToList());
                    await IcanContext.SaveChangesAsync();
                    IcanContext.OnaAgyw2020.AddRange(data);
                    await IcanContext.SaveChangesAsync();

                    //send email after update                   
                    EmailModel email = new EmailModel(_context);
                    email.OnaAgyw2020Email();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion AGYW2020

        #region BSP_Survey_final
        public IEnumerable<OnaBspSurveyFinal> GetBSPSurveyfinalRecords()
        {
            //Load the data from the API
            var model = new object[0];
            var targeturl = string.Format("https://api.ona.io/api/v1/data/543731");
            //Jan - Mar
            HttpMessageHandler handler = new HttpClientHandler()
            {
            };

            var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(targeturl),
                Timeout = new TimeSpan(0, 20, 0)
            };

            List<OnaBspSurveyFinal> bspsurveyfinal2020 = new List<OnaBspSurveyFinal>();
            httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");

            //This is the key section you were missing    
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes("ican:abt@1can");
            string val = System.Convert.ToBase64String(plainTextBytes);
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + val);

            var method = new HttpMethod("GET");
            List<string> myList = new List<string>();

            JArray jArray = new JArray();
            HttpResponseMessage response = httpClient.GetAsync(targeturl).Result;
            if (response.ReasonPhrase == "Not Found")
            {
                //TempData["Message"] = string.Format("No records found for  {0}-{1}", reportingPeriod.Replace("%20", ""), financialYear.ToString()); ;
            }
            else
            {
                string content = string.Empty;

                using (StreamReader stream = new StreamReader(response.Content.ReadAsStreamAsync().Result, true))
                {
                    content = stream.ReadToEnd();
                }

                jArray = JArray.Parse(content);
                // Strip off the [] from _tags and Notes


                foreach (JObject j in jArray)
                {
                    var cg = new OnaBspSurveyFinal();

                    string dvalue = string.Empty;
                    double dnumber;
                    bool success = false;

                    if (j.GetValue("fo") != null)
                    {
                        cg.Fo = j.GetValue("fo").ToString();
                    }

                    cg.Age = j.GetValue("Age").ToString();

                    if (j.GetValue("Sex") != null)
                    {
                        cg.Sex = j.GetValue("Sex").ToString();
                    }

                    cg.Id = Convert.ToInt32(j.GetValue("_id").ToString());

                    if (j.GetValue("end") != null)
                    {
                        cg.Endd = j.GetValue("end").ToString();
                    }

                    if (j.GetValue("ack2") != null)
                    {
                        cg.Ack2 = j.GetValue("ack2").ToString();
                    }

                    if (j.GetValue("year") != null)
                    {
                        cg.Year = j.GetValue("year").ToString();
                    }

                    if (j.GetValue("_uuid") != null)
                    {
                        cg.Uuid = j.GetValue("_uuid").ToString();
                    }

                    if (j.GetValue("month") != null)
                    {
                        cg.Month = j.GetValue("month").ToString();
                    }

                    if (j.GetValue("start") != null)
                    {
                        cg.Start = j.GetValue("start").ToString();
                    }

                    if (j.GetValue("BSPName") != null)
                    {
                        cg.Bspname = j.GetValue("BSPName").ToString();
                    }

                    if (j.GetValue("Mstatus") != null)
                    {
                        cg.Mstatus = j.GetValue("Mstatus").ToString();
                    }

                    if (j.GetValue("calc_yr") != null)
                    {
                        cg.CalcYr = j.GetValue("calc_yr").ToString();
                    }

                    if (j.GetValue("curr_yr") != null)
                    {
                        cg.CurrYr = j.GetValue("curr_yr").ToString();
                    }

                    if (j.GetValue("village") != null)
                    {
                        cg.Village = j.GetValue("village").ToString();
                    }

                    if (j.GetValue("_version") != null)
                    {
                        cg.Version = j.GetValue("_version").ToString();
                    }

                    if (j.GetValue("deviceid") != null)
                    {
                        cg.Deviceid = j.GetValue("deviceid").ToString();
                    }

                    if (j.GetValue("district") != null)
                    {
                        cg.District = j.GetValue("district").ToString();
                    }

                    cg.Numgroups = j.GetValue("Numgroups").ToString();

                    cg.Duration = j.GetValue("_duration").ToString();

                    cg.XformId = j.GetValue("_xform_id").ToString();

                    if (j.GetValue("subcounty") != null)
                    {
                        cg.Subcounty = j.GetValue("subcounty").ToString();
                    }

                    if (j.GetValue("PhoneNumber") != null)
                    {
                        cg.PhoneNumber = j.GetValue("PhoneNumber").ToString();
                    }

                    cg.TrainedInVsla = j.GetValue("TrainedInVSLA").ToString();

                    if (j.GetValue("_submitted_by") != null)
                    {
                        cg.SubmittedBy = j.GetValue("_submitted_by").ToString();
                    }

                    if (j.GetValue("meta/instanceID") != null)
                    {
                        cg.MetaInstanceId = j.GetValue("meta/instanceID").ToString();
                    }

                    if (j.GetValue("BSPTrainedInVSLA") != null)
                    {
                        cg.BsptrainedInVsla = j.GetValue("BSPTrainedInVSLA").ToString();
                    }

                    if (j.GetValue("_submission_time") != null)
                    {
                        cg.SubmissionTime = j.GetValue("_submission_time").ToString();
                    }

                    cg.LinkedToInputMarket = j.GetValue("LinkedToInputMarket").ToString();
                    cg.LinkedToutputMarket = j.GetValue("LinkedToutputMarket").ToString();


                    if (j.GetValue("BSPTrainedInFee4service") != null)
                    {
                        cg.BsptrainedInFee4service = j.GetValue("BSPTrainedInFee4service").ToString();
                    }

                    cg.IncomeIncomeInputSales = j.GetValue("income/IncomeInputSales").ToString();

                    if (j.GetValue("LinkedToFinancialServices") != null)
                    {
                        cg.LinkedToFinancialServices = j.GetValue("LinkedToFinancialServices").ToString();
                    }

                    cg.TrainedInAgriPreneurship = j.GetValue("TrainedInAgri-preneurship").ToString();

                    cg.SkilledInPriorityInterprise = j.GetValue("SkilledInPriorityInterprise").ToString();

                    if (j.GetValue("BSPTrainingInAgri-preneurship") != null)
                    {
                        cg.BsptrainingInAgriPreneurship = j.GetValue("BSPTrainingInAgri-preneurship").ToString();
                    }

                    if (j.GetValue("SupportedOnCLimateTechnoloies") != null)
                    {
                        cg.SupportedOnClimateTechnoloies = j.GetValue("SupportedOnCLimateTechnoloies").ToString();
                    }

                    if (j.GetValue("income/IncomeExtensionProvision") != null)
                    {
                        cg.IncomeIncomeExtensionProvision = j.GetValue("income/IncomeExtensionProvision").ToString();
                    }

                    if (j.GetValue("income/IncomeProduceAggregation") != null)
                    {
                        cg.IncomeIncomeProduceAggregation = j.GetValue("income/IncomeProduceAggregation").ToString();
                    }

                    if (j.GetValue("income/incomeSalesofTecthnology") != null)
                    {
                        cg.IncomeIncomeSalesofTecthnology = j.GetValue("income/incomeSalesofTecthnology").ToString();
                    }

                    cg.LastUpdatedAt = DateTime.Now;

                    bspsurveyfinal2020.Add(cg);
                }
            }

            //this.bspsurfinData = bspsurveyfinal2020;

            return bspsurveyfinal2020;
        }

        public async Task SaveBSPSurveyfinalData()
        {
            try
            {
                using (var IcanContext = new USAID_ICANContext())
                {
                    var data = GetBSPSurveyfinalRecords().ToList();
                    IcanContext.OnaBspSurveyFinal.RemoveRange(IcanContext.OnaBspSurveyFinal.ToList());
                    await IcanContext.SaveChangesAsync();
                    IcanContext.OnaBspSurveyFinal.AddRange(data);
                    await IcanContext.SaveChangesAsync();

                    //send email after update                   
                    EmailModel email = new EmailModel(_context);
                    email.OnaBspSurveyFinalEmail();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion BSP_Survey_final

        #region BSP_Survey_revised
        public IEnumerable<OnaBspSurveyRevised> GetBSPSurveyrevisedRecords()
        {
            //Load the data from the API
            var model = new object[0];
            var targeturl = string.Format("https://api.ona.io/api/v1/data/545756");
            //Jan - Mar
            HttpMessageHandler handler = new HttpClientHandler()
            {
            };

            var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(targeturl),
                Timeout = new TimeSpan(0, 20, 0)
            };

            List<OnaBspSurveyRevised> bspsurrev = new List<OnaBspSurveyRevised>();
            httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");

            //This is the key section you were missing    
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes("ican:abt@1can");
            string val = System.Convert.ToBase64String(plainTextBytes);
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + val);

            var method = new HttpMethod("GET");
            List<string> myList = new List<string>();

            JArray jArray = new JArray();
            HttpResponseMessage response = httpClient.GetAsync(targeturl).Result;
            if (response.ReasonPhrase == "Not Found")
            {
                //TempData["Message"] = string.Format("No records found for  {0}-{1}", reportingPeriod.Replace("%20", ""), financialYear.ToString()); ;
            }
            else
            {
                string content = string.Empty;

                using (StreamReader stream = new StreamReader(response.Content.ReadAsStreamAsync().Result, true))
                {
                    content = stream.ReadToEnd();
                }

                jArray = JArray.Parse(content);
                // Strip off the [] from _tags and Notes


                foreach (JObject j in jArray)
                {
                    var cg = new OnaBspSurveyRevised();

                    string dvalue = string.Empty;
                    double dnumber;
                    bool success = false;

                    var a = j.GetValue("_geolocation") as object;
                    var c = a.ToString().Replace("\r", "").Replace("\n", "").Replace("[", "").Replace("]", "").Trim();
                    var b = c.Split(',');
                    if (b.Length == 2)
                    {
                        double d = 0;
                        if (double.TryParse(b[0], out d))
                        {
                            cg.Latitude = d;
                        }
                        if (double.TryParse(b[1], out d))
                        {
                            cg.Longitude = d;
                        }
                    }


                    if (j.GetValue("fo") != null)
                    {
                        cg.Fo = j.GetValue("fo").ToString();
                    }

                    cg.Age = Convert.ToInt32(j.GetValue("Age").ToString());

                    if (j.GetValue("Sex") != null)
                    {
                        cg.Sex = Convert.ToInt32(j.GetValue("Sex").ToString());
                    }
                    cg.Id = Convert.ToInt32(j.GetValue("_id").ToString());

                    if (j.GetValue("end") != null)
                    {
                        cg.Endd = j.GetValue("end").ToString();
                    }

                    if (j.GetValue("ack2") != null)
                    {
                        cg.Ack2 = j.GetValue("ack2").ToString();
                    }

                    if (j.GetValue("year") != null)
                    {
                        cg.Year = j.GetValue("year").ToString();
                    }

                    if (j.GetValue("_uuid") != null)
                    {
                        cg.Uuid = j.GetValue("_uuid").ToString();
                    }

                    if (j.GetValue("month") != null)
                    {
                        cg.Month = j.GetValue("month").ToString();
                    }

                    if (j.GetValue("start") != null)
                    {
                        cg.Start = j.GetValue("start").ToString();
                    }

                    if (j.GetValue("BSPName") != null)
                    {
                        cg.Bspname = j.GetValue("BSPName").ToString();
                    }

                    if (j.GetValue("Mstatus") != null)
                    {
                        cg.Mstatus = j.GetValue("Mstatus").ToString();
                    }

                    if (j.GetValue("calc_yr") != null)
                    {
                        cg.CalcYr = j.GetValue("calc_yr").ToString();
                    }


                    if (j.GetValue("curr_yr") != null)
                    {
                        cg.CurrYr = j.GetValue("curr_yr").ToString();
                    }

                    if (j.GetValue("village") != null)
                    {
                        cg.Village = j.GetValue("village").ToString();
                    }

                    if (j.GetValue("_version") != null)
                    {
                        cg.Version = j.GetValue("_version").ToString();
                    }

                    if (j.GetValue("comments") != null)
                    {
                        cg.Comments = j.GetValue("comments").ToString();
                    }
                    if (j.GetValue("deviceid") != null)
                    {
                        cg.Deviceid = j.GetValue("deviceid").ToString();
                    }
                    if (j.GetValue("district") != null)
                    {
                        cg.District = j.GetValue("district").ToString();
                    }
                    cg.Numgroups = Convert.ToInt32(j.GetValue("Numgroups").ToString());

                    if (j.GetValue("Training2") != null)
                    {
                        cg.Training2 = j.GetValue("Training2").ToString();
                    }

                    if (j.GetValue("Training3") != null)
                    {
                        cg.Training3 = j.GetValue("Training3").ToString();
                    }
                    cg.Duration = Convert.ToDouble(j.GetValue("_duration").ToString());

                    cg.XformId = Convert.ToInt32(j.GetValue("_xform_id").ToString());

                    if (j.GetValue("subcounty") != null)
                    {
                        cg.Subcounty = j.GetValue("subcounty").ToString();
                    }

                    if (j.GetValue("PhoneNumber") != null)
                    {
                        cg.PhoneNumber = j.GetValue("PhoneNumber").ToString();
                    }

                    cg.TrainedInVsla = Convert.ToInt32(j.GetValue("TrainedInVSLA").ToString());

                    if (j.GetValue("_submitted_by") != null)
                    {
                        cg.SubmittedBy = j.GetValue("_submitted_by").ToString();
                    }

                    if (j.GetValue("likebeingaBSP") != null)
                    {
                        cg.LikebeingaBsp = j.GetValue("likebeingaBSP").ToString();
                    }

                    if (j.GetValue("meta/instanceID") != null)
                    {
                        cg.MetaInstanceId = j.GetValue("meta/instanceID").ToString();
                    }

                    if (j.GetValue("BSPTrainedInVSLA") != null)
                    {
                        cg.BsptrainedInVsla = j.GetValue("BSPTrainedInVSLA").ToString();
                    }


                    if (j.GetValue("_submission_time") != null)
                    {
                        CultureInfo enUS = new CultureInfo("en-US");
                        string dateString;
                        DateTime dateValue;
                        // Use custom formats with M and MM.
                        dateString = j.GetValue("_submission_time").ToString();
                        //if (DateTime.TryParseExact(dateString, "M/dd/yyyy hh:mm", enUS,
                        if (DateTime.TryParse(dateString, out dateValue))
                        {
                            cg.SubmissionTime = dateValue;
                        }
                    }

                    if (j.GetValue("meetexpectations") != null)
                    {
                        cg.Meetexpectations = j.GetValue("meetexpectations").ToString();
                    }

                    if (j.GetValue("training/Training1") != null)
                    {
                        cg.TrainingTraining1 = j.GetValue("training/Training1").ToString();
                    }

                    cg.LinkedToInputMarket = Convert.ToInt32(j.GetValue("LinkedToInputMarket").ToString());
                    cg.LinkedToutputMarket = Convert.ToInt32(j.GetValue("LinkedToutputMarket").ToString());

                    if (j.GetValue("income/IncomeLivestock") != null)
                    {
                        cg.IncomeIncomeLivestock = Convert.ToDouble(j.GetValue("income/IncomeLivestock").ToString());
                    }

                    if (j.GetValue("BSPTrainedInFee4service") != null)
                    {
                        cg.BsptrainedInFee4service = j.GetValue("BSPTrainedInFee4service").ToString();
                    }

                    cg.IncomeIncomeInputSales = Convert.ToInt32(j.GetValue("income/IncomeInputSales").ToString());
                    cg.LinkedToFinancialServices = Convert.ToInt32(j.GetValue("LinkedToFinancialServices").ToString());

                    if (j.GetValue("LinkedToGovermentPrograms") != null)
                    {
                        cg.LinkedToGovermentPrograms = Convert.ToDouble(j.GetValue("LinkedToGovermentPrograms").ToString());
                    }

                    cg.TrainedInAgriPreneurship = Convert.ToInt32(j.GetValue("TrainedInAgri-preneurship").ToString());
                    cg.SupportedToOpenBankaccount = Convert.ToInt32(j.GetValue("SupportedToOpenBankaccount").ToString());

                    if (j.GetValue("SkilledInPriorityInterprise") != null)
                    {
                        cg.SkilledInPriorityInterprise = Convert.ToDouble(j.GetValue("SkilledInPriorityInterprise").ToString());
                    }

                    if (j.GetValue("ReasonNotLinkedToutputMarket") != null)
                    {
                        cg.ReasonNotLinkedToutputMarket = j.GetValue("ReasonNotLinkedToutputMarket").ToString();
                    }

                    if (j.GetValue("BSPTrainingInAgri-preneurship") != null)
                    {
                        cg.BsptrainingInAgriPreneurship = j.GetValue("BSPTrainingInAgri-preneurship").ToString();
                    }

                    if (j.GetValue("SupportedOnCLimateTechnoloies") != null)
                    {
                        cg.SupportedOnClimateTechnoloies = Convert.ToDouble(j.GetValue("SupportedOnCLimateTechnoloies").ToString());
                    }

                    cg.IncomeIncomeExtensionProvision = Convert.ToInt32(j.GetValue("income/IncomeExtensionProvision").ToString());
                    //cg.IncomeIncomeProduceAggregation = Convert.ToInt32(j.GetValue("IncomeIncomeProduceAggregation").ToString());


                    if (j.GetValue("income/incomeSalesofTecthnology") != null)
                    {
                        cg.IncomeIncomeSalesofTecthnology = Convert.ToDouble(j.GetValue("income/incomeSalesofTecthnology").ToString());
                    }

                    if (j.GetValue("ReasonNotLinkedToGovernmentPrograms") != null)
                    {
                        cg.ReasonNotLinkedToGovernmentPrograms = j.GetValue("ReasonNotLinkedToGovernmentPrograms").ToString();
                    }

                    if (j.GetValue("ReasonNotSupportedToOpenBankaccount") != null)
                    {
                        cg.ReasonNotSupportedToOpenBankaccount = j.GetValue("ReasonNotSupportedToOpenBankaccount").ToString();
                    }

                    if (j.GetValue("CompareIncome/ExtensionIncomeInCOVID") != null)
                    {
                        cg.CompareIncomeExtensionIncomeInCovid = j.GetValue("CompareIncome/ExtensionIncomeInCOVID").ToString();
                    }
                    if (j.GetValue("CompareIncome/LivestockIncomeInCOVID") != null)
                    {
                        cg.CompareIncomeLivestockIncomeInCovid = j.GetValue("CompareIncome/LivestockIncomeInCOVID").ToString();
                    }
                    if (j.GetValue("ReasonNotSkilledInPriorityInterprise") != null)
                    {
                        cg.ReasonNotSkilledInPriorityInterprise = j.GetValue("ReasonNotSkilledInPriorityInterprise").ToString();
                    }
                    if (j.GetValue("CompareIncome/InputSalesIncomeInCOVID") != null)
                    {
                        cg.CompareIncomeInputSalesIncomeInCovid = j.GetValue("CompareIncome/InputSalesIncomeInCOVID").ToString();
                    }

                    if (j.GetValue("ReasonNotSupportedOnCLimateTechnoloies") != null)
                    {
                        cg.ReasonNotSupportedOnClimateTechnoloies = j.GetValue("ReasonNotSupportedOnCLimateTechnoloies").ToString();
                    }
                    if (j.GetValue("CompareIncome/ProduceAggregationIncomeInCOVID") != null)
                    {
                        cg.CompareIncomeProduceAggregationIncomeInCovid = j.GetValue("CompareIncome/ProduceAggregationIncomeInCOVID").ToString();
                    }

                    if (j.GetValue("CompareIncome/SalesofTecthnologyIncomeInCOVID") != null)
                    {
                        cg.CompareIncomeSalesofTecthnologyIncomeInCovid = j.GetValue("CompareIncome/SalesofTecthnologyIncomeInCOVID").ToString();
                    }

                    cg.LastUpdatedAt = DateTime.Now;

                    bspsurrev.Add(cg);
                }
            }

            //this.spsurevData = bspsurrev;

            return bspsurrev;
        }

        public async Task SavebspsurrevData()
        {
            try
            {
                using (var IcanContext = new USAID_ICANContext())
                {
                    var data = GetBSPSurveyrevisedRecords().ToList();
                    IcanContext.OnaBspSurveyRevised.RemoveRange(IcanContext.OnaBspSurveyRevised.ToList());
                    await IcanContext.SaveChangesAsync();
                    IcanContext.OnaBspSurveyRevised.AddRange(data);
                    await IcanContext.SaveChangesAsync();

                    //send email after update                   
                    EmailModel email = new EmailModel(_context);
                    email.OnaBspSurveyRevisedEmail();
                }

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion BSP_Survey_revised

        #region Cell_Profiling
        public IEnumerable<OnaCellProfiling> GetCellProfilingRecords()
        {
            //Load the data from the API
            var model = new object[0];
            var targeturl = string.Format("https://api.ona.io/api/v1/data/465965");
            //Jan - Mar
            HttpMessageHandler handler = new HttpClientHandler()
            {
            };

            var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(targeturl),
                Timeout = new TimeSpan(0, 20, 0)
            };

            List<OnaCellProfiling> cellprof = new List<OnaCellProfiling>();
            httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");

            //This is the key section you were missing    
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes("ican:abt@1can");
            string val = System.Convert.ToBase64String(plainTextBytes);
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + val);

            var method = new HttpMethod("GET");
            List<string> myList = new List<string>();

            JArray jArray = new JArray();
            HttpResponseMessage response = httpClient.GetAsync(targeturl).Result;
            if (response.ReasonPhrase == "Not Found")
            {
                //TempData["Message"] = string.Format("No records found for  {0}-{1}", reportingPeriod.Replace("%20", ""), financialYear.ToString()); ;
            }
            else
            {
                string content = string.Empty;

                using (StreamReader stream = new StreamReader(response.Content.ReadAsStreamAsync().Result, true))
                {
                    content = stream.ReadToEnd();
                }

                jArray = JArray.Parse(content);
                // Strip off the [] from _tags and Notes


                foreach (JObject j in jArray)
                {
                    var cg = new OnaCellProfiling();

                    string dvalue = string.Empty;
                    double dnumber;
                    bool success = false;


                    if (j.GetValue("fo") != null)
                    {
                        cg.Fo = j.GetValue("fo").ToString();
                    }

                    if (j.GetValue("GPS") != null)
                    {
                        cg.Gps = j.GetValue("GPS").ToString();
                    }

                    var a = j.GetValue("_geolocation") as object;
                    var c = a.ToString().Replace("\r", "").Replace("\n", "").Replace("[", "").Replace("]", "").Trim();
                    var b = c.Split(',');
                    if (b.Length == 2)
                    {
                        double d = 0;
                        if (double.TryParse(b[0], out d))
                        {
                            cg.GpsLatitude = d;
                        }
                        if (double.TryParse(b[1], out d))
                        {
                            cg.GpsLongitude = d;
                        }
                    }

                    cg.Id = Convert.ToInt32(j.GetValue("_id").ToString());

                    if (j.GetValue("sex") != null)
                    {
                        cg.Sex = j.GetValue("sex").ToString();
                    }

                    if (j.GetValue("_uuid") != null)
                    {
                        cg.Uuid = j.GetValue("_uuid").ToString();
                    }

                    if (j.GetValue("dcode") != null)
                    {
                        cg.Dcode = j.GetValue("dcode").ToString();
                    }

                    if (j.GetValue("Market") != null)
                    {
                        cg.Market = Convert.ToDouble(j.GetValue("Market").ToString());
                    }
                    if (j.GetValue("Parish") != null)
                    {
                        cg.Parish = j.GetValue("Parish").ToString();
                    }

                    if (j.GetValue("Cell_ID") != null)
                    {
                        cg.CellId = j.GetValue("Cell_ID").ToString();
                    }

                    if (j.GetValue("Num_HHs") != null)
                    {
                        cg.NumHhs = Convert.ToInt32(j.GetValue("Num_HHs").ToString());
                    }

                    if (j.GetValue("Village") != null)
                    {
                        cg.Village = j.GetValue("Village").ToString();
                    }

                    if (j.GetValue("Cell_Num") != null)
                    {
                        cg.CellNum = j.GetValue("Cell_Num").ToString();
                    }

                    if (j.GetValue("District") != null)
                    {
                        cg.District = j.GetValue("District").ToString();
                    }

                    if (j.GetValue("Num_Eres") != null)
                    {
                        cg.NumEres = Convert.ToInt32(j.GetValue("Num_Eres").ToString());
                    }

                    if (j.GetValue("Pschools") != null)
                    {
                        cg.Pschools = Convert.ToDouble(j.GetValue("Pschools").ToString());
                    }

                    if (j.GetValue("Sschools") != null)
                    {
                        cg.Sschools = Convert.ToDouble(j.GetValue("Sschools").ToString());
                    }

                    if (j.GetValue("_version") != null)
                    {
                        cg.Version = j.GetValue("_version").ToString();
                    }

                    if (j.GetValue("Hfacility") != null)
                    {
                        cg.Hfacility = Convert.ToDouble(j.GetValue("Hfacility").ToString());
                    }

                    if (j.GetValue("Subcounty") != null)
                    {
                        cg.Subcounty = j.GetValue("Subcounty").ToString();
                    }

                    if (j.GetValue("_duration") != null)
                    {
                        cg.Duration = j.GetValue("_duration").ToString();
                    }

                    cg.XformId = Convert.ToInt32(j.GetValue("_xform_id").ToString());
                    cg.Vinstitute = Convert.ToInt32(j.GetValue("Vinstitute").ToString());

                    if (j.GetValue("Visit_Date") != null)
                    {
                        CultureInfo enUS = new CultureInfo("en-US");
                        string dateString;
                        DateTime dateValue;
                        // Use custom formats with M and MM.
                        dateString = j.GetValue("Visit_Date").ToString();
                        //if (DateTime.TryParseExact(dateString, "M/dd/yyyy hh:mm", enUS,
                        if (DateTime.TryParse(dateString, out dateValue))
                        {
                            cg.VisitDate = dateValue;
                        }
                    }

                    if (j.GetValue("Waterpoint") != null)
                    {
                        cg.Waterpoint = Convert.ToDouble(j.GetValue("Waterpoint").ToString());
                    }

                    if (j.GetValue("Other_Groups") != null)
                    {
                        cg.OtherGroups = Convert.ToDouble(j.GetValue("Other_Groups").ToString());
                    }

                    if (j.GetValue("_submitted_by") != null)
                    {
                        cg.SubmittedBy = j.GetValue("_submitted_by").ToString();
                    }

                    if (j.GetValue("meta/instanceID") != null)
                    {
                        cg.MetaInstanceId = j.GetValue("meta/instanceID").ToString();
                    }

                    if (j.GetValue("_submission_time") != null)
                    {
                        CultureInfo enUS = new CultureInfo("en-US");
                        string dateString;
                        DateTime dateValue;
                        // Use custom formats with M and MM.
                        dateString = j.GetValue("_submission_time").ToString();
                        //if (DateTime.TryParseExact(dateString, "M/dd/yyyy hh:mm", enUS,
                        if (DateTime.TryParse(dateString, out dateValue))
                        {
                            cg.SubmissionTime = dateValue;
                        }
                    }

                    if (j.GetValue("Saving_Groups") != null)
                    {
                        cg.SavingGroups = Convert.ToDouble(j.GetValue("Saving_Groups").ToString());
                    }

                    if (j.GetValue("Villageleader") != null)
                    {
                        cg.Villageleader = j.GetValue("Villageleader").ToString();
                    }

                    if (j.GetValue("NumMCGPartners") != null)
                    {
                        cg.NumMcgpartners = Convert.ToInt32(j.GetValue("NumMCGPartners").ToString());
                    }

                    if (j.GetValue("NumVSLAPartners") != null)
                    {
                        cg.NumVslapartners = Convert.ToDouble(j.GetValue("NumVSLAPartners").ToString());
                    }

                    if (j.GetValue("MCGpartners_count") != null)
                    {
                        cg.McgpartnersCount = j.GetValue("MCGpartners_count").ToString();
                    }

                    if (j.GetValue("MotherCare_Groups") != null)
                    {
                        cg.MotherCareGroups = Convert.ToDouble(j.GetValue("MotherCare_Groups").ToString());
                    }

                    if (j.GetValue("Othergroups_count") != null)
                    {
                        cg.OthergroupsCount = j.GetValue("Othergroups_count").ToString();
                    }

                    if (j.GetValue("Production_Groups") != null)
                    {
                        cg.ProductionGroups = Convert.ToDouble(j.GetValue("Production_Groups").ToString());
                    }

                    if (j.GetValue("Savingpartners_count") != null)
                    {
                        cg.SavingpartnersCount = j.GetValue("Savingpartners_count").ToString();
                    }

                    if (j.GetValue("Funeralinsurance_Groups") != null)
                    {
                        cg.FuneralinsuranceGroups = Convert.ToDouble(j.GetValue("Funeralinsurance_Groups").ToString());
                    }

                    if (j.GetValue("NumFarmingPartners") != null)
                    {
                        cg.NumFarmingPartners = Convert.ToDouble(j.GetValue("NumFarmingPartners").ToString());
                    }

                    if (j.GetValue("Farmingpartners_count") != null)
                    {
                        cg.FarmingpartnersCount = j.GetValue("Farmingpartners_count").ToString();
                    }

                    if (j.GetValue("NumOtherPartners") != null)
                    {
                        cg.NumOtherPartners = j.GetValue("NumOtherPartners").ToString();
                    }

                    if (j.GetValue("Other_partners_count") != null)
                    {
                        cg.OtherPartnersCount = j.GetValue("Other_partners_count").ToString();
                    }

                    if (j.GetValue("phonecontact") != null)
                    {
                        cg.Phonecontact = j.GetValue("phonecontact").ToString();
                    }

                    cg.LastUpdatedAt = DateTime.Now;

                    cellprof.Add(cg);
                }
            }

            //this.UpdmiycanData = upmiycangpdata;

            return cellprof;
        }

        public async Task SavecellprofilingData()
        {
            try
            {
                using (var IcanContext = new USAID_ICANContext())
                {
                    var data = GetCellProfilingRecords().ToList();
                    IcanContext.OnaCellProfiling.RemoveRange(IcanContext.OnaCellProfiling.ToList());
                    await IcanContext.SaveChangesAsync();
                    IcanContext.OnaCellProfiling.AddRange(data);
                    await IcanContext.SaveChangesAsync();

                    //send email after update                   
                    EmailModel email = new EmailModel(_context);
                    email.OnaCellProfilingEmail();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Cell_Profiling

        #region CG_Assessment
        public IEnumerable<OnaCgAssessment> GetCGAssessmentRecords()
        {
            //Load the data from the API
            var model = new object[0];
            var targeturl = string.Format("https://api.ona.io/api/v1/data/390583");
            //Jan - Mar
            HttpMessageHandler handler = new HttpClientHandler()
            {
            };

            var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(targeturl),
                Timeout = new TimeSpan(0, 20, 0)
            };

            List<OnaCgAssessment> cgassmentdt = new List<OnaCgAssessment>();
            httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");

            //This is the key section you were missing    
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes("ican:abt@1can");
            string val = System.Convert.ToBase64String(plainTextBytes);
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + val);

            var method = new HttpMethod("GET");
            List<string> myList = new List<string>();

            JArray jArray = new JArray();
            HttpResponseMessage response = httpClient.GetAsync(targeturl).Result;

            if (response.ReasonPhrase == "Not Found")
            {
                //TempData["Message"] = string.Format("No records found for  {0}-{1}", reportingPeriod.Replace("%20", ""), financialYear.ToString()); ;
            }
            else
            {
                string content = string.Empty;

                using (StreamReader stream = new StreamReader(response.Content.ReadAsStreamAsync().Result, true))
                {
                    content = stream.ReadToEnd();
                }

                jArray = JArray.Parse(content);
                // Strip off the [] from _tags and Notes


                foreach (JObject j in jArray)
                {
                    var cg = new OnaCgAssessment();

                    string dvalue = string.Empty;
                    double dnumber;
                    bool success = false;

                    cg.Id = Convert.ToInt32(j.GetValue("_id").ToString());

                    if (j.GetValue("_uuid") != null)
                    {
                        cg.Uuid = j.GetValue("_uuid").ToString();
                    }

                    if (j.GetValue("Qn/gps") != null)
                    {
                        cg.QnGps = j.GetValue("Qn/gps").ToString();
                    }

                    if (j.GetValue("Qn/A/a1") != null)
                    {
                        cg.QnAA1 = j.GetValue("Qn/A/a1").ToString();
                    }
                    if (j.GetValue("Qn/A/a2") != null)
                    {
                        cg.QnAA2 = j.GetValue("Qn/A/a2").ToString();
                    }
                    if (j.GetValue("Qn/A/a3") != null)
                    {
                        cg.QnAA3 = j.GetValue("Qn/A/a3").ToString();
                    }
                    if (j.GetValue("Qn/A/a4") != null)
                    {
                        cg.QnAA4 = j.GetValue("Qn/A/a4").ToString();
                    }
                    if (j.GetValue("Qn/A/a5") != null)
                    {
                        cg.QnAA5 = Convert.ToInt32(j.GetValue("Qn/A/a5").ToString());
                    }
                    if (j.GetValue("Qn/A/a6") != null)
                    {
                        cg.QnAA6 = j.GetValue("Qn/A/a6").ToString();
                    }
                    if (j.GetValue("Qn/A/a7") != null)
                    {
                        cg.QnAA7 = j.GetValue("Qn/A/a7").ToString();
                    }
                    if (j.GetValue("Qn/A/a8") != null)
                    {
                        cg.QnAA8 = j.GetValue("Qn/A/a8").ToString();
                    }

                    if (j.GetValue("Qn/A/a9") != null)
                    {
                        cg.QnAA9 = j.GetValue("Qn/A/a9").ToString();
                    }

                    if (j.GetValue("Qn/B/b1") != null)
                    {
                        cg.QnBB1 = j.GetValue("Qn/B/b1").ToString();
                    }

                    if (j.GetValue("Qn/B/b2") != null)
                    {
                        cg.QnBB2 = j.GetValue("Qn/B/b2").ToString();
                    }

                    if (j.GetValue("Qn/B/b3") != null)
                    {
                        cg.QnBB3 = j.GetValue("Qn/B/b3").ToString();
                    }

                    if (j.GetValue("Qn/B/b7") != null)
                    {
                        cg.QnBB7 = j.GetValue("Qn/B/b7").ToString();
                    }

                    if (j.GetValue("Qn/D/d1") != null)
                    {
                        cg.QnDD1 = j.GetValue("Qn/D/d1").ToString();
                    }

                    if (j.GetValue("Qn/D/d5") != null)
                    {
                        cg.QnDD5 = j.GetValue("Qn/D/d5").ToString();
                    }

                    if (j.GetValue("Qn/D/d7") != null)
                    {
                        cg.QnDD7 = j.GetValue("Qn/D/d7").ToString();
                    }

                    if (j.GetValue("Qn/D/d8") != null)
                    {
                        cg.QnDD8 = j.GetValue("Qn/D/d8").ToString();
                    }

                    //cg.Qn_D_d9 = Convert.ToInt32(j.GetValue("Qn/D/d9").ToString());


                    if (j.GetValue("Qn/E/e1") != null)
                    {
                        cg.QnEE1 = j.GetValue("Qn/E/e1").ToString();
                    }

                    if (j.GetValue("Qn/E/e3") != null)
                    {
                        cg.QnEE3 = j.GetValue("Qn/E/e3").ToString();
                    }
                    if (j.GetValue("Qn/E/e5") != null)
                    {
                        cg.QnEE5 = j.GetValue("Qn/E/e5").ToString();
                    }
                    if (j.GetValue("Qn/E/e7") != null)
                    {
                        cg.QnEE7 = j.GetValue("Qn/E/e7").ToString();
                    }
                    if (j.GetValue("Qn/E/e9") != null)
                    {
                        cg.QnEE9 = j.GetValue("Qn/E/e9").ToString();
                    }
                    if (j.GetValue("Qn/ack2") != null)
                    {
                        cg.QnAck2 = j.GetValue("Qn/ack2").ToString();
                    }

                    if (j.GetValue("Qn/A/a10") != null)
                    {
                        cg.QnAA10 = j.GetValue("Qn/A/a10").ToString();
                    }
                    if (j.GetValue("Qn/A/a11") != null)
                    {
                        cg.QnAA11 = j.GetValue("Qn/A/a11").ToString();
                    }
                    if (j.GetValue("Qn/A/a12") != null)
                    {
                        cg.QnAA12 = j.GetValue("Qn/A/a12").ToString();
                    }
                    if (j.GetValue("Qn/A/a13") != null)
                    {
                        cg.QnAA13 = j.GetValue("Qn/A/a13").ToString();
                    }
                    if (j.GetValue("Qn/A/a14") != null)
                    {
                        cg.QnAA14 = j.GetValue("Qn/A/a14").ToString();
                    }
                    if (j.GetValue("Qn/A/a15") != null)
                    {
                        cg.QnAA15 = j.GetValue("Qn/A/a15").ToString();
                    }
                    if (j.GetValue("Qn/A/a16") != null)
                    {
                        cg.QnAA16 = j.GetValue("Qn/A/a16").ToString();
                    }
                    if (j.GetValue("Qn/D/d10") != null)
                    {
                        cg.QnDD10 = j.GetValue("Qn/D/d10").ToString();
                    }
                    if (j.GetValue("Qn/D/d11") != null)
                    {
                        cg.QnDD11 = j.GetValue("Qn/D/d11").ToString();
                    }
                    if (j.GetValue("Qn/D/d12") != null)
                    {
                        cg.QnDD12 = j.GetValue("Qn/D/d12").ToString();
                    }
                    if (j.GetValue("Qn/D/d13") != null)
                    {
                        cg.QnDD13 = j.GetValue("Qn/D/d13").ToString();
                    }
                    if (j.GetValue("Qn/D/d14") != null)
                    {
                        cg.QnDD14 = j.GetValue("Qn/D/d14").ToString();
                    }
                    if (j.GetValue("Qn/D/d16") != null)
                    {
                        cg.QnDD16 = j.GetValue("Qn/D/d16").ToString();
                    }
                    if (j.GetValue("Qn/D/d19") != null)
                    {
                        cg.QnDD19 = j.GetValue("Qn/D/d19").ToString();
                    }
                    if (j.GetValue("Qn/E/e11") != null)
                    {
                        cg.QnEE11 = j.GetValue("Qn/E/e11").ToString();
                    }
                    if (j.GetValue("Qn/E/e12") != null)
                    {
                        cg.QnEE12 = j.GetValue("Qn/E/e12").ToString();
                    }
                    if (j.GetValue("Qn/E/e13") != null)
                    {
                        cg.QnEE13 = j.GetValue("Qn/E/e13").ToString();
                    }

                    if (j.GetValue("Qn/E/e14") != null)
                    {
                        cg.QnEE14 = j.GetValue("Qn/E/e14").ToString();
                    }
                    if (j.GetValue("Qn/E/e15") != null)
                    {
                        cg.QnEE15 = j.GetValue("Qn/E/e15").ToString();
                    }

                    if (j.GetValue("Qn/E/e16") != null)
                    {
                        cg.QnEE16 = j.GetValue("Qn/E/e16").ToString();
                    }

                    if (j.GetValue("Qn/E/e17") != null)
                    {
                        cg.QnEE17 = j.GetValue("Qn/E/e17").ToString();
                    }

                    if (j.GetValue("Qn/E/e19") != null)
                    {
                        cg.QnEE19 = j.GetValue("Qn/E/e19").ToString();
                    }

                    if (j.GetValue("Qn/E/e21") != null)
                    {
                        cg.QnEE21 = j.GetValue("Qn/E/e21").ToString();
                    }

                    if (j.GetValue("_version") != null)
                    {
                        cg.Version = j.GetValue("_version").ToString();
                    }

                    cg.Duration = Convert.ToDouble(j.GetValue("_duration").ToString());

                    cg.XformId = Convert.ToInt32(j.GetValue("_xform_id").ToString());

                    if (j.GetValue("fieldteam") != null)
                    {
                        cg.Fieldteam = j.GetValue("fieldteam").ToString();
                    }

                    if (j.GetValue("Qn/scorea1") != null)
                    {
                        cg.QnScorea1 = j.GetValue("Qn/scorea1").ToString();
                    }

                    if (j.GetValue("Qn/scorea2") != null)
                    {
                        cg.QnScorea2 = j.GetValue("Qn/scorea2").ToString();
                    }

                    if (j.GetValue("Qn/scorea3") != null)
                    {
                        cg.QnScorea3 = j.GetValue("Qn/scorea3").ToString();
                    }

                    if (j.GetValue("Qn/scorea4") != null)
                    {
                        cg.QnScorea4 = j.GetValue("Qn/scorea4").ToString();
                    }

                    if (j.GetValue("Qn/scorea5") != null)
                    {
                        cg.QnScorea5 = j.GetValue("Qn/scorea5").ToString();
                    }

                    if (j.GetValue("Qn/scorea6") != null)
                    {
                        cg.QnScorea6 = j.GetValue("Qn/scorea6").ToString();
                    }

                    if (j.GetValue("Qn/comments") != null)
                    {
                        cg.QnComments = j.GetValue("Qn/comments").ToString();
                    }

                    if (j.GetValue("Qn/gv/scheme") != null)
                    {
                        cg.QnGvScheme = j.GetValue("Qn/gv/scheme").ToString();
                    }

                    if (j.GetValue("Qn/intro/end") != null)
                    {
                        CultureInfo enUS = new CultureInfo("en-US");
                        string dateString;
                        DateTime dateValue;
                        // Use custom formats with M and MM.
                        dateString = j.GetValue("Qn/intro/end").ToString();
                        //if (DateTime.TryParseExact(dateString, "M/dd/yyyy hh:mm", enUS,
                        if (DateTime.TryParse(dateString, out dateValue))
                        {
                            cg.QnIntroEnd = dateValue.ToShortDateString();
                        }
                    }
                    //if (j.GetValue("Qn/intro/id1") != null)
                    //{
                    //    cg.QnIntroI = j.GetValue("Qn/intro/id1").ToString();
                    //}

                    //if (j.GetValue("Qn/intro/id2") != null)
                    //{
                    //    cg.Qn_intro_id2 = j.GetValue("Qn/intro/id2").ToString();
                    //}                                      

                    //if (j.GetValue("Qn/intro/id3") != null)
                    //{
                    //    cg.Qn_intro_id3 = j.GetValue("Qn/intro/id3").ToString();
                    //}

                    if (j.GetValue("Qn/intro/loc") != null)
                    {
                        cg.QnIntroLoc = j.GetValue("Qn/intro/loc").ToString();
                    }

                    cg.QnIntroTel = Convert.ToInt32(j.GetValue("Qn/intro/tel").ToString());

                    //cg.Media_count = Convert.ToInt32(j.GetValue("_media_count").ToString());

                    //cg.TotalMedia = Convert.ToInt32(j.GetValue("_total_media").ToString());

                    //if (j.GetValue("formhub/uuid") != null)
                    //{
                    //    cg.formhub_uuid = j.GetValue("formhub/uuid").ToString();
                    //}

                    if (j.GetValue("Qn/gv/grptype") != null)
                    {
                        cg.QnGvGrptype = j.GetValue("Qn/gv/grptype").ToString();
                    }

                    if (j.GetValue("_submitted_by") != null)
                    {
                        cg.SubmittedBy = j.GetValue("_submitted_by").ToString();
                    }

                    if (j.GetValue("Qn/intro/start") != null)
                    {
                        CultureInfo enUS = new CultureInfo("en-US");
                        string dateString;
                        DateTime dateValue;
                        // Use custom formats with M and MM.
                        dateString = j.GetValue("Qn/intro/start").ToString();
                        //if (DateTime.TryParseExact(dateString, "M/dd/yyyy hh:mm", enUS,
                        if (DateTime.TryParse(dateString, out dateValue))
                        {
                            cg.QnIntroStart = dateValue.ToShortDateString();
                        }
                    }

                    if (j.GetValue("Qn/gv/contr_mem") != null)
                    {
                        cg.QnGvContrMem = j.GetValue("Qn/gv/contr_mem").ToString();
                    }

                    if (j.GetValue("meta/instanceID") != null)
                    {
                        cg.MetaInstanceId = j.GetValue("meta/instanceID").ToString();
                    }

                    //cg.Qn_gv_sav_scheme = j.GetValue("Qn/gv/sav_scheme").ToString();

                    if (j.GetValue("_submission_time") != null)
                    {
                        CultureInfo enUS = new CultureInfo("en-US");
                        string dateString;
                        DateTime dateValue;
                        // Use custom formats with M and MM.
                        dateString = j.GetValue("_submission_time").ToString();
                        //if (DateTime.TryParseExact(dateString, "M/dd/yyyy hh:mm", enUS,
                        if (DateTime.TryParse(dateString, out dateValue))
                        {
                            cg.SubmissionTime = dateValue;
                        }
                    }

                    //if (j.GetValue("_xform_id_string") != null)
                    //{
                    //    cg._xform_id_string = j.GetValue("_xform_id_string").ToString();
                    //}

                    if (j.GetValue("Qn/intro/ass_date") != null)
                    {
                        CultureInfo enUS = new CultureInfo("en-US");
                        string dateString;
                        DateTime dateValue;
                        if (DateTime.TryParse(j.GetValue("Qn/intro/ass_date").ToString(), out dateValue))
                        {
                            cg.QnIntroAssDate = dateValue;
                        }

                    }
                    if (j.GetValue("Qn/intro/deviceid") != null)
                    {
                        cg.QnIntroDeviceid = j.GetValue("Qn/intro/deviceid").ToString();
                    }
                    if (j.GetValue("Qn/intro/form_date") != null)
                    {
                        cg.QnIntroFormDate = j.GetValue("Qn/intro/form_date").ToString();
                    }
                    if (j.GetValue("Qn/intro/groupname") != null)
                    {
                        cg.QnIntroGroupname = j.GetValue("Qn/intro/groupname").ToString();
                    }
                    if (j.GetValue("Qn/intro/grouppost") != null)
                    {
                        cg.QnIntroGrouppost = j.GetValue("Qn/intro/grouppost").ToString();
                    }

                    cg.QnIntroMaleyouth = Convert.ToDouble(j.GetValue("Qn/intro/maleyouth").ToString());

                    //if (j.GetValue("_bamboo_dataset_id") != null)
                    //{
                    //    cg.BambooDatasetId = j.GetValue("_bamboo_dataset_id").ToString();
                    //}

                    if (j.GetValue("Qn/intro/loc_parish") != null)
                    {
                        cg.QnIntroLocParish = j.GetValue("Qn/intro/loc_parish").ToString();
                    }

                    if (j.GetValue("Qn/intro/loc_region") != null)
                    {
                        cg.QnIntroLocRegion = j.GetValue("Qn/intro/loc_region").ToString();
                    }

                    cg.QnIntroMaleadults = Convert.ToInt32(j.GetValue("Qn/intro/maleadults").ToString());

                    //if (j.GetValue("_media_all_received") != null)
                    //{
                    //    dvalue = j.GetValue("_media_all_received").ToString();
                    //    success = double.TryParse(dvalue, out dnumber);
                    //    if (success)
                    //    {
                    //        cg.MediaAllReceived = success;
                    //    }
                    //}

                    if (j.GetValue("Qn/intro/altcontact1") != null)
                    {
                        cg.QnIntroAltcontact1 = j.GetValue("Qn/intro/altcontact1").ToString();
                    }

                    if (j.GetValue("Qn/intro/altcontact2") != null)
                    {
                        cg.QnIntroAltcontact2 = j.GetValue("Qn/intro/altcontact2").ToString();
                    }

                    cg.QnIntroFemaleyouth = Convert.ToDouble(j.GetValue("Qn/intro/femaleyouth").ToString());

                    cg.QnIntroFemaleadults = Convert.ToInt32(j.GetValue("Qn/intro/femaleadults").ToString());

                    if (j.GetValue("Qn/intro/loc_district") != null)
                    {
                        cg.QnIntroLocDistrict = j.GetValue("Qn/intro/loc_district").ToString();
                    }
                    if (j.GetValue("Qn/intro/contactperson") != null)
                    {
                        cg.QnIntroContactperson = j.GetValue("Qn/intro/contactperson").ToString();
                    }
                    if (j.GetValue("Qn/intro/loc_subcounty") != null)
                    {
                        cg.QnIntroLocSubcounty = j.GetValue("Qn/intro/loc_subcounty").ToString();
                    }

                    if (j.GetValue("Qn/intro/altcontact2") != null)
                    {
                        cg.QnIntroAltcontact2 = j.GetValue("Qn/intro/altcontact2").ToString();
                    }
                    if (j.GetValue("Qn/intro/altcontact2") != null)
                    {
                        cg.QnIntroAltcontact2 = j.GetValue("Qn/intro/altcontact2").ToString();
                    }

                    var a = j.GetValue("_geolocation") as object;
                    var c = a.ToString().Replace("\r", "").Replace("\n", "").Replace("[", "").Replace("]", "").Trim();
                    var b = c.Split(',');
                    if (b.Length == 2)
                    {
                        double d = 0;
                        if (double.TryParse(b[0], out d))
                        {
                            cg.QnGpsLatitude = d;
                        }
                        if (double.TryParse(b[1], out d))
                        {
                            cg.QnGpsLongitude = d;
                        }
                    }

                    cg.LastUpdatedAt = DateTime.Now;

                    cgassmentdt.Add(cg);
                }
            }

            //this.cgassData = cgassmentdt;

            return cgassmentdt;


        }
        public async Task SaveCGAssessmentData()
        {
            try
            {
                using (var IcanContext = new USAID_ICANContext())
                {
                    var data = GetCGAssessmentRecords().ToList();
                    IcanContext.OnaCgAssessment.RemoveRange(IcanContext.OnaCgAssessment.ToList());
                    await IcanContext.SaveChangesAsync();
                    IcanContext.OnaCgAssessment.AddRange(data);
                    await IcanContext.SaveChangesAsync();

                    //send email after update                   
                    EmailModel email = new EmailModel(_context);
                    email.OnaCgAssessmentEmail();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion CG_Assessment

        #region COMMUNITYGROUP_Summary2021

        public IEnumerable<OnaCommunitygroupSummary2021> GetcommunitygroupsummaryDataRecords()
        {
            //Load the data from the API
            var model = new object[0];
            var targeturllast = string.Format("https://api.ona.io/api/v1/data/586397");
            List<OnaCommunitygroupSummary2021> commgrpsummver5 = new List<OnaCommunitygroupSummary2021>();

            //Here
            HttpMessageHandler handlerlast = new HttpClientHandler()
            {
            };

            var httpClientlast = new HttpClient(handlerlast)
            {
                BaseAddress = new Uri(targeturllast),
                Timeout = new TimeSpan(0, 20, 0)
            };

            httpClientlast.DefaultRequestHeaders.Add("ContentType", "application/json");

            //This is the key section you were missing    
            var plainTextByteslast = System.Text.Encoding.UTF8.GetBytes("ican:abt@1can");
            string vallast = System.Convert.ToBase64String(plainTextByteslast);
            httpClientlast.DefaultRequestHeaders.Add("Authorization", "Basic " + vallast);

            var methodlast = new HttpMethod("GET");
            List<string> myListlast = new List<string>();

            JArray jArraylast = new JArray();
            HttpResponseMessage responselast = httpClientlast.GetAsync(targeturllast).Result;

            var alink = responselast.Headers.FirstOrDefault(o => o.Key == "Link");
            var pages = alink.Value.FirstOrDefault();
            var page_1 = pages.Split(",");
            string lastpage = null;
            foreach (var nw in page_1)
            {
                if (nw.Contains("last"))
                {
                    var ax = nw.Split(";");
                    lastpage = ax[0].Replace('<', ' ').Replace('>', ' ').Trim();
                }
            }

            int i = 1;

            while (true)
            {
                var targeturl = "https://api.ona.io/api/v1/data/586397" + "?page=" + i + "&page_size=10000";

                HttpMessageHandler handler = new HttpClientHandler()
                {
                };

                var httpClient = new HttpClient(handler)
                {
                    BaseAddress = new Uri(targeturl),
                    Timeout = new TimeSpan(0, 20, 0)
                };

                //List<OnaCommunitygroupSummary2021> commgrpsummver5 = new List<OnaCommunitygroupSummary2021>();
                httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");

                //This is the key section you were missing    
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes("ican:abt@1can");
                string val = System.Convert.ToBase64String(plainTextBytes);
                httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + val);

                var method = new HttpMethod("GET");
                List<string> myList = new List<string>();

                JArray jArray = new JArray();
                HttpResponseMessage response = httpClient.GetAsync(targeturl).Result;

                if (response.ReasonPhrase == "Not Found")
                {
                    //TempData["Message"] = string.Format("No records found for  {0}-{1}", reportingPeriod.Replace("%20", ""), financialYear.ToString()); ;
                }
                else
                {
                    string content = string.Empty;

                    using (StreamReader stream = new StreamReader(response.Content.ReadAsStreamAsync().Result, true))
                    {
                        content = stream.ReadToEnd();
                    }

                    jArray = JArray.Parse(content);

                    foreach (JObject j in jArray)
                    {
                        var cg = new OnaCommunitygroupSummary2021();

                        string dvalue = string.Empty;
                        double dnumber;
                        bool success = false;

                        if (j.GetValue("fo") != null)
                        {
                            cg.Fo = j.GetValue("fo").ToString();
                        }
                        if (j.GetValue("mgt") != null)
                        {
                            cg.Mgt = j.GetValue("mgt").ToString();
                        }
                        if (j.GetValue("tech") != null)
                        {
                            cg.Tech = j.GetValue("tech").ToString();
                        }
                        if (j.GetValue("tr") != null)
                        {
                            cg.Tr = j.GetValue("tr").ToString();
                        }
                        if (j.GetValue("lm") != null)
                        {
                            cg.Lm = j.GetValue("lm").ToString();
                        }

                        cg.Id = Convert.ToInt32(j.GetValue("_id").ToString());

                        if (j.GetValue("bsp") != null)
                        {
                            cg.Bsp = j.GetValue("bsp").ToString();
                        }

                        if (j.GetValue("acty") != null)
                        {
                            cg.Acty = j.GetValue("acty").ToString();
                        }

                        if (j.GetValue("year") != null)
                        {
                            cg.Year = j.GetValue("year").ToString();
                        }

                        if (j.GetValue("month") != null)
                        {
                            cg.Month = j.GetValue("month").ToString();
                        }

                        if (j.GetValue("calc_yr") != null)
                        {
                            cg.CalcYr = j.GetValue("calc_yr").ToString();
                        }

                        if (j.GetValue("curr_yr") != null)
                        {
                            cg.CurrYr = j.GetValue("curr_yr").ToString();
                        }

                        if (j.GetValue("village") != null)
                        {
                            cg.Village = j.GetValue("village").ToString();
                        }

                        if (j.GetValue("district") != null)
                        {
                            cg.District = j.GetValue("district").ToString();
                        }

                        if (j.GetValue("subcounty") != null)
                        {
                            cg.Subcounty = j.GetValue("subcounty").ToString();
                        }

                        if (j.GetValue("Numbers/maleA") != null)
                        {
                            cg.NumbersMaleA = Convert.ToDouble(j.GetValue("Numbers/maleA").ToString());
                        }

                        if (j.GetValue("Numbers/maleY") != null)
                        {
                            cg.NumbersMaleY = Convert.ToDouble(j.GetValue("Numbers/maleY").ToString());
                        }

                        if (j.GetValue("Numbers/femaleA") != null)
                        {
                            cg.NumbersFemaleA = Convert.ToDouble(j.GetValue("Numbers/femaleA").ToString());
                        }

                        if (j.GetValue("Numbers/femaleY") != null)
                        {
                            cg.NumbersFemaleY = Convert.ToDouble(j.GetValue("Numbers/femaleY").ToString());
                        }

                        if (j.GetValue("location/groupid") != null)
                        {
                            cg.LocationGroupid = j.GetValue("location/groupid").ToString();
                        }


                        if (j.GetValue("location/groupname") != null)
                        {
                            cg.LocationGroupname = j.GetValue("location/groupname").ToString();
                        }

                        cg.LastUpdatedAt = DateTime.Now;

                        using (var dbContext = new USAID_ICANContext())
                        {
                            var exist = dbContext.OnaCommunitygroupSummary2021.FirstOrDefault(o => o.Id == cg.Id);
                            if (exist == null)
                            {
                                commgrpsummver5.Add(cg);
                            }
                        }

                        //commgrpsummver5.Add(cg);
                    }
                }
                i++;

                if (targeturl == lastpage)
                    break;
            }

            return commgrpsummver5;
        }

        public async Task SavecommgrpsumData()
        {
            try
            {
                using (var IcanContext = new USAID_ICANContext())
                {
                    var data = GetcommunitygroupsummaryDataRecords().ToList();
                    //IcanContext.OnaCommunitygroupSummary2021.RemoveRange(IcanContext.OnaCommunitygroupSummary2021.ToList());
                    //await IcanContext.SaveChangesAsync();

                    IcanContext.OnaCommunitygroupSummary2021.AddRange(data);
                    await IcanContext.SaveChangesAsync();

                    //send email after update                   
                    EmailModel email = new EmailModel(_context);
                    email.OnaCommunitygroupSummary2021Email();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion COMMUNITYGROUP_Summary2021

        #region CRC_WeeklySummaryVer4

        public IEnumerable<OnaCrcWeeklySummaryVer4> GetCRCWeekSmryVer4DataRecords()
        {
            //Load the data from the API
            var model = new object[0];
            var targeturl = string.Format("https://api.ona.io/api/v1/data/488651");
            //Jan - Mar
            HttpMessageHandler handler = new HttpClientHandler()
            {
            };

            var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(targeturl),
                Timeout = new TimeSpan(0, 20, 0)
            };

            List<OnaCrcWeeklySummaryVer4> crcweekdata = new List<OnaCrcWeeklySummaryVer4>();
            httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");

            //This is the key section you were missing    
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes("ican:abt@1can");
            string val = System.Convert.ToBase64String(plainTextBytes);
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + val);

            var method = new HttpMethod("GET");
            List<string> myList = new List<string>();

            JArray jArray = new JArray();
            HttpResponseMessage response = httpClient.GetAsync(targeturl).Result;
            if (response.ReasonPhrase == "Not Found")
            {
                //TempData["Message"] = string.Format("No records found for  {0}-{1}", reportingPeriod.Replace("%20", ""), financialYear.ToString()); ;
            }
            else
            {
                string content = string.Empty;

                using (StreamReader stream = new StreamReader(response.Content.ReadAsStreamAsync().Result, true))
                {
                    content = stream.ReadToEnd();
                }

                jArray = JArray.Parse(content);
                // Strip off the [] from _tags and Notes


                foreach (JObject j in jArray)
                {
                    var cg = new OnaCrcWeeklySummaryVer4();

                    string dvalue = string.Empty;
                    double dnumber;
                    bool success = false;

                    if (j.GetValue("location/schoolname") != null)
                    {
                        cg.Schoolname = j.GetValue("location/schoolname").ToString();
                    }

                    if (j.GetValue("location/clubname") != null)
                    {
                        cg.Clubname = j.GetValue("location/clubname").ToString();
                    }

                    if (j.GetValue("location/school") != null)
                    {
                        cg.School = j.GetValue("location/school").ToString();
                    }


                    if (j.GetValue("fo") != null)
                    {
                        cg.Fo = j.GetValue("fo").ToString();
                    }

                    cg.Id = Convert.ToInt32(j.GetValue("_id").ToString());

                    if (j.GetValue("end") != null)
                    {
                        cg.Endd = j.GetValue("end").ToString();
                    }

                    if (j.GetValue("ack2") != null)
                    {
                        cg.Ack2 = j.GetValue("ack2").ToString();
                    }

                    cg.Boys = Convert.ToInt32(j.GetValue("boys").ToString());

                    if (j.GetValue("year") != null)
                    {
                        cg.Year = j.GetValue("year").ToString();
                    }

                    if (j.GetValue("_uuid") != null)
                    {
                        cg.Uuid = j.GetValue("_uuid").ToString();
                    }

                    cg.Girls = Convert.ToInt32(j.GetValue("girls").ToString());

                    if (j.GetValue("image") != null)
                    {
                        cg.Image = j.GetValue("image").ToString();
                    }

                    if (j.GetValue("month") != null)
                    {
                        cg.Month = j.GetValue("month").ToString();
                    }

                    if (j.GetValue("start") != null)
                    {
                        cg.Start = j.GetValue("start").ToString();
                    }

                    if (j.GetValue("topic") != null)
                    {
                        cg.Topic = j.GetValue("topic").ToString();
                    }

                    //cg._notes = j.GetValue("_notes").ToString();

                    if (j.GetValue("patron") != null)
                    {
                        cg.Patron = j.GetValue("patron").ToString();
                    }

                    if (j.GetValue("calc_yr") != null)
                    {
                        cg.CalcYr = j.GetValue("calc_yr").ToString();
                    }

                    if (j.GetValue("curr_yr") != null)
                    {
                        cg.CurrYr = j.GetValue("curr_yr").ToString();
                    }

                    if (j.GetValue("village") != null)
                    {
                        cg.Village = j.GetValue("village").ToString();
                    }

                    if (j.GetValue("_version") != null)
                    {
                        cg.Version = j.GetValue("_version").ToString();
                    }

                    if (j.GetValue("comments") != null)
                    {
                        cg.Comments = j.GetValue("comments").ToString();
                    }

                    if (j.GetValue("deviceid") != null)
                    {
                        cg.Deviceid = j.GetValue("deviceid").ToString();
                    }

                    if (j.GetValue("district") != null)
                    {
                        cg.District = j.GetValue("district").ToString();
                    }

                    cg.Duration = Convert.ToDouble(j.GetValue("_duration").ToString());

                    cg.XformId = Convert.ToInt32(j.GetValue("_xform_id").ToString());


                    if (j.GetValue("subcounty") != null)
                    {
                        cg.Subcounty = j.GetValue("subcounty").ToString();
                    }

                    if (j.GetValue("_submitted_by") != null)
                    {
                        cg.SubmittedBy = j.GetValue("_submitted_by").ToString();
                    }

                    if (j.GetValue("meta/instanceID") != null)
                    {
                        cg.InstanceId = j.GetValue("meta/instanceID").ToString();
                    }

                    if (j.GetValue("_submission_time") != null)
                    {
                        CultureInfo enUS = new CultureInfo("en-US");
                        string dateString;
                        DateTime dateValue;
                        // Use custom formats with M and MM.
                        dateString = j.GetValue("_submission_time").ToString();
                        //if (DateTime.TryParseExact(dateString, "M/dd/yyyy hh:mm", enUS,
                        if (DateTime.TryParse(dateString, out dateValue))
                        {
                            cg.SubmissionTime = dateValue;
                        }

                        var a = j.GetValue("_geolocation") as object;
                        var c = a.ToString().Replace("\r", "").Replace("\n", "").Replace("[", "").Replace("]", "").Trim();
                        var b = c.Split(',');
                        if (b.Length == 2)
                        {
                            double d = 0;
                            if (double.TryParse(b[0], out d))
                            {
                                cg.Latitude = d;
                            }
                            if (double.TryParse(b[1], out d))
                            {
                                cg.Longitude = d;
                            }
                        }
                        cg.LastUpdatedAt = DateTime.Now;
                    }

                    crcweekdata.Add(cg);
                }
            }

            //this.crcwesumData = crcweekdata;

            return crcweekdata;
        }

        public async Task SavecrcweeklysummData()
        {
            try
            {
                using (var IcanContext = new USAID_ICANContext())
                {
                    var data = GetCRCWeekSmryVer4DataRecords().ToList();
                    IcanContext.OnaCrcWeeklySummaryVer4.RemoveRange(IcanContext.OnaCrcWeeklySummaryVer4.ToList());
                    await IcanContext.SaveChangesAsync();
                    IcanContext.OnaCrcWeeklySummaryVer4.AddRange(data);
                    await IcanContext.SaveChangesAsync();

                    //send email after update                   
                    EmailModel email = new EmailModel(_context);
                    email.OnaCrcWeeklySummaryVer4Email();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion CRC_WeeklySummaryVer4

        #region Ere_Profiling
        public IEnumerable<OnaEreProfiling> GetEreProfilingDataRecords()
        {
            //Load the data from the API
            var model = new object[0];
            var targeturl = string.Format("https://api.ona.io/api/v1/data/465702");
            //Jan - Mar
            HttpMessageHandler handler = new HttpClientHandler()
            {
            };

            var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(targeturl),
                Timeout = new TimeSpan(0, 20, 0)
            };

            List<OnaEreProfiling> erprofdata = new List<OnaEreProfiling>();
            httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");

            //This is the key section you were missing    
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes("ican:abt@1can");
            string val = System.Convert.ToBase64String(plainTextBytes);
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + val);

            var method = new HttpMethod("GET");
            List<string> myList = new List<string>();

            JArray jArray = new JArray();
            HttpResponseMessage response = httpClient.GetAsync(targeturl).Result;
            if (response.ReasonPhrase == "Not Found")
            {
                //TempData["Message"] = string.Format("No records found for  {0}-{1}", reportingPeriod.Replace("%20", ""), financialYear.ToString()); ;
            }
            else
            {
                string content = string.Empty;

                using (StreamReader stream = new StreamReader(response.Content.ReadAsStreamAsync().Result, true))
                {
                    content = stream.ReadToEnd();
                }

                jArray = JArray.Parse(content);
                // Strip off the [] from _tags and Notes

                foreach (JObject j in jArray)
                {
                    var cg = new OnaEreProfiling();

                    string dvalue = string.Empty;
                    double dnumber;
                    bool success = false;

                    if (j.GetValue("FO") != null)
                    {
                        cg.Fo = j.GetValue("FO").ToString();
                    }

                    if (j.GetValue("Ere") != null)
                    {
                        cg.Ere = j.GetValue("Ere").ToString();
                    }

                    if (j.GetValue("GPS") != null)
                    {
                        cg.Gps = j.GetValue("GPS").ToString();
                    }

                    cg.Id = Convert.ToInt32(j.GetValue("_id").ToString());

                    if (j.GetValue("sex") != null)
                    {
                        cg.Sex = j.GetValue("sex").ToString();
                    }

                    if (j.GetValue("_uuid") != null)
                    {
                        cg.Uuid = j.GetValue("_uuid").ToString();
                    }

                    if (j.GetValue("EreNum") != null)
                    {
                        cg.EreNum = j.GetValue("EreNum").ToString();
                    }

                    if (j.GetValue("Ere_ID") != null)
                    {
                        cg.EreId = j.GetValue("Ere_ID").ToString();
                    }

                    if (j.GetValue("Parish") != null)
                    {
                        cg.Parish = j.GetValue("Parish").ToString();
                    }

                    if (j.GetValue("Cell_ID") != null)
                    {
                        cg.CellId = j.GetValue("Cell_ID").ToString();
                    }

                    cg.NumHhs = Convert.ToInt32(j.GetValue("Num_HHs").ToString());

                    if (j.GetValue("Village") != null)
                    {
                        cg.Village = j.GetValue("Village").ToString();
                    }

                    if (j.GetValue("District") != null)
                    {
                        cg.District = j.GetValue("District").ToString();
                    }

                    if (j.GetValue("_version") != null)
                    {
                        cg.Version = j.GetValue("_version").ToString();
                    }

                    if (j.GetValue("Subcounty") != null)
                    {
                        cg.Subcounty = j.GetValue("Subcounty").ToString();
                    }

                    if (j.GetValue("_duration") != null)
                    {
                        cg.Duration = j.GetValue("_duration").ToString();
                    }

                    cg.XformId = Convert.ToInt32(j.GetValue("_xform_id").ToString());

                    if (j.GetValue("Visit_Date") != null)
                    {
                        CultureInfo enUS = new CultureInfo("en-US");
                        string dateString;
                        DateTime dateValue;
                        // Use custom formats with M and MM.
                        dateString = j.GetValue("Visit_Date").ToString();
                        //if (DateTime.TryParseExact(dateString, "M/dd/yyyy hh:mm", enUS,
                        if (DateTime.TryParse(dateString, out dateValue))
                        {
                            cg.VisitDate = dateValue;// Convert.ToDateTime(j.GetValue("_submission_time").ToString());
                        }
                    }

                    if (j.GetValue("Villageleader") != null)
                    {
                        cg.Villageleader = j.GetValue("Villageleader").ToString();
                    }

                    if (j.GetValue("_submitted_by") != null)
                    {
                        cg.SubmittedBy = j.GetValue("_submitted_by").ToString();
                    }

                    if (j.GetValue("meta/instanceID") != null)
                    {
                        cg.MetaInstanceId = j.GetValue("meta/instanceID").ToString();
                    }

                    if (j.GetValue("_submission_time") != null)
                    {
                        CultureInfo enUS = new CultureInfo("en-US");
                        string dateString;
                        DateTime dateValue;
                        // Use custom formats with M and MM.
                        dateString = j.GetValue("_submission_time").ToString();
                        //if (DateTime.TryParseExact(dateString, "M/dd/yyyy hh:mm", enUS,
                        if (DateTime.TryParse(dateString, out dateValue))
                        {
                            cg.SubmissionTime = dateValue;
                        }
                    }

                    if (j.GetValue("phonecontact") != null)
                    {
                        cg.Phonecontact = j.GetValue("phonecontact").ToString();
                    }

                    var a = j.GetValue("_geolocation") as object;
                    var c = a.ToString().Replace("\r", "").Replace("\n", "").Replace("[", "").Replace("]", "").Trim();
                    var b = c.Split(',');
                    if (b.Length == 2)
                    {
                        double d = 0;
                        if (double.TryParse(b[0], out d))
                        {
                            cg.GpsLatitude = d;
                        }
                        if (double.TryParse(b[1], out d))
                        {
                            cg.GpsLongitude = d;
                        }
                    }
                    cg.LastUpdatedAt = DateTime.Now;

                    erprofdata.Add(cg);
                }
            }

            //this.ereproData = erprofdata;

            return erprofdata;
        }

        public async Task SaveEreProfilingData()
        {
            try
            {
                using (var IcanContext = new USAID_ICANContext())
                {
                    var data = GetEreProfilingDataRecords().ToList();
                    IcanContext.OnaEreProfiling.RemoveRange(IcanContext.OnaEreProfiling.ToList());
                    await IcanContext.SaveChangesAsync();
                    IcanContext.OnaEreProfiling.AddRange(data);
                    await IcanContext.SaveChangesAsync();

                    //send email after update                   
                    EmailModel email = new EmailModel(_context);
                    email.OnaEreProfilingEmail();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Ere_Profiling

        #region EventTracker2
        public IEnumerable<OnaEventTracker2> GetEventTracker2DataRecords()
        {
            //Load the data from the API
            var model = new object[0];
            var targeturl = string.Format("https://api.ona.io/api/v1/data/392868");
            //Jan - Mar
            HttpMessageHandler handler = new HttpClientHandler()
            {
            };

            var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(targeturl),
                Timeout = new TimeSpan(0, 20, 0)
            };

            List<OnaEventTracker2> evetr2data = new List<OnaEventTracker2>();
            httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");

            //This is the key section you were missing    
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes("ican:abt@1can");
            string val = System.Convert.ToBase64String(plainTextBytes);
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + val);

            var method = new HttpMethod("GET");
            List<string> myList = new List<string>();

            JArray jArray = new JArray();
            HttpResponseMessage response = httpClient.GetAsync(targeturl).Result;
            if (response.ReasonPhrase == "Not Found")
            {
                //TempData["Message"] = string.Format("No records found for  {0}-{1}", reportingPeriod.Replace("%20", ""), financialYear.ToString()); ;
            }
            else
            {
                string content = string.Empty;

                using (StreamReader stream = new StreamReader(response.Content.ReadAsStreamAsync().Result, true))
                {
                    content = stream.ReadToEnd();
                }

                jArray = JArray.Parse(content);
                // Strip off the [] from _tags and Notes


                foreach (JObject j in jArray)
                {
                    var cg = new OnaEventTracker2();

                    string dvalue = string.Empty;
                    double dnumber;
                    bool success = false;

                    cg.Id = Convert.ToInt32(j.GetValue("_id").ToString());

                    if (j.GetValue("event") != null)
                    {
                        cg.Event = Convert.ToInt32(j.GetValue("event").ToString());
                    }

                    var a = j.GetValue("_geolocation") as object;
                    var c = a.ToString().Replace("\r", "").Replace("\n", "").Replace("[", "").Replace("]", "").Trim();
                    var b = c.Split(',');
                    if (b.Length == 2)
                    {
                        double d = 0;
                        if (double.TryParse(b[0], out d))
                        {
                            cg.GpsLatitude = d;
                        }
                        if (double.TryParse(b[1], out d))
                        {
                            cg.GpsLongitude = d;
                        }
                    }
                    if (j.GetValue("Plan_Type") != null)
                    {
                        cg.PlanType = j.GetValue("Plan_Type").ToString();
                    }
                    if (j.GetValue("topic") != null)
                    {
                        cg.Topic = j.GetValue("topic").ToString();
                    }

                    if (j.GetValue("meeting") != null)
                    {
                        cg.Meeting = Convert.ToInt32(j.GetValue("meeting").ToString());
                    }

                    if (j.GetValue("actionPlan") != null)
                    {
                        cg.ActionPlan = j.GetValue("actionPlan").ToString();
                    }

                    if (j.GetValue("_gps_altitude") != null)
                    {
                        cg.GpsAltitude = Convert.ToDouble(j.GetValue("_gps_altitude").ToString());
                    }

                    if (j.GetValue("_gps_latitude") != null)
                    {
                        cg.GpsLatitude = Convert.ToDouble(j.GetValue("_gps_latitude").ToString());
                    }

                    if (j.GetValue("_gps_longitude") != null)
                    {
                        cg.GpsLongitude = Convert.ToDouble(j.GetValue("_gps_longitude").ToString());
                    }

                    if (j.GetValue("_gps_precision") != null)
                    {
                        cg.GpsPrecision = Convert.ToDouble(j.GetValue("_gps_precision").ToString());
                    }

                    if (j.GetValue("males") != null)
                    {
                        cg.Males = j.GetValue("males").ToString();
                    }

                    if (j.GetValue("females") != null)
                    {
                        cg.Females = j.GetValue("females").ToString();
                    }

                    if (j.GetValue("end") != null)
                    {
                        cg.Endd = j.GetValue("end").ToString();
                    }

                    if (j.GetValue("gps") != null)
                    {
                        cg.Gps = j.GetValue("gps").ToString();
                    }

                    if (j.GetValue("loc") != null)
                    {
                        cg.Loc = j.GetValue("loc").ToString();
                    }

                    if (j.GetValue("vip") != null)
                    {
                        cg.Vip = j.GetValue("vip").ToString();
                    }

                    if (j.GetValue("ack2") != null)
                    {
                        cg.Ack2 = j.GetValue("ack2").ToString();
                    }

                    if (j.GetValue("_uuid") != null)
                    {
                        cg.Uuid = j.GetValue("_uuid").ToString();
                    }

                    if (j.GetValue("start") != null)
                    {
                        cg.Start = j.GetValue("start").ToString();
                    }

                    if (j.GetValue("_version") != null)
                    {
                        cg.Version = j.GetValue("_version").ToString();
                    }

                    if (j.GetValue("comments") != null)
                    {
                        cg.Comments = j.GetValue("comments").ToString();
                    }

                    if (j.GetValue("deviceid") != null)
                    {
                        cg.Deviceid = j.GetValue("deviceid").ToString();
                    }

                    if (j.GetValue("location") != null)
                    {
                        cg.Location = j.GetValue("location").ToString();
                    }

                    cg.Duration = Convert.ToDouble(j.GetValue("_duration").ToString());

                    cg.XformId = Convert.ToInt32(j.GetValue("_xform_id").ToString());

                    if (j.GetValue("fieldteam") != null)
                    {
                        cg.Fieldteam = j.GetValue("fieldteam").ToString();
                    }

                    if (j.GetValue("event_date") != null)
                    {
                        CultureInfo enUS = new CultureInfo("en-US");
                        string dateString;
                        DateTime dateValue;
                        // Use custom formats with M and MM.
                        dateString = j.GetValue("event_date").ToString();
                        //if (DateTime.TryParseExact(dateString, "M/dd/yyyy hh:mm", enUS,
                        if (DateTime.TryParse(dateString, out dateValue))
                        {
                            cg.EventDate = dateValue;
                        }
                    }

                    if (j.GetValue("loc_parish") != null)
                    {
                        cg.LocParish = j.GetValue("loc_parish").ToString();
                    }

                    if (j.GetValue("loc_region") != null)
                    {
                        cg.LocRegion = j.GetValue("loc_region").ToString();
                    }


                    if (j.GetValue("event_other") != null)
                    {
                        cg.EventOther = j.GetValue("event_other").ToString();
                    }

                    if (j.GetValue("loc_district") != null)
                    {
                        cg.LocDistrict = j.GetValue("loc_district").ToString();
                    }

                    if (j.GetValue("_submitted_by") != null)
                    {
                        cg.SubmittedBy = j.GetValue("_submitted_by").ToString();
                    }

                    if (j.GetValue("loc_subcounty") != null)
                    {
                        cg.LocSubcounty = j.GetValue("loc_subcounty").ToString();
                    }

                    if (j.GetValue("vpersons/name1") != null)
                    {
                        cg.VpersonsName1 = j.GetValue("vpersons/name1").ToString();
                    }

                    if (j.GetValue("vpersons/name2") != null)
                    {
                        cg.VpersonsName2 = j.GetValue("vpersons/name2").ToString();
                    }

                    if (j.GetValue("meta/instanceID") != null)
                    {
                        cg.MetaInstanceId = j.GetValue("meta/instanceID").ToString();
                    }

                    if (j.GetValue("vpersons/title1") != null)
                    {
                        cg.VpersonsTitle1 = j.GetValue("vpersons/title1").ToString();
                    }

                    if (j.GetValue("vpersons/title2") != null)
                    {
                        cg.VpersonsTitle2 = j.GetValue("vpersons/title2").ToString();
                    }

                    if (j.GetValue("_submission_time") != null)
                    {
                        CultureInfo enUS = new CultureInfo("en-US");
                        string dateString;
                        DateTime dateValue;
                        // Use custom formats with M and MM.
                        dateString = j.GetValue("_submission_time").ToString();
                        //if (DateTime.TryParseExact(dateString, "M/dd/yyyy hh:mm", enUS,
                        if (DateTime.TryParse(dateString, out dateValue))
                        {
                            cg.SubmissionTime = dateValue;
                        }
                    }


                    if (j.GetValue("image") != null)
                    {
                        cg.Image = j.GetValue("image").ToString();
                    }

                    cg.LastUpdatedAt = DateTime.Now;

                    evetr2data.Add(cg);
                }
            }
            return evetr2data;
        }

        public async Task Savevetrac2Data()
        {
            try
            {
                using (var IcanContext = new USAID_ICANContext())
                {
                    var data = GetEventTracker2DataRecords().ToList();
                    IcanContext.OnaEventTracker2.RemoveRange(IcanContext.OnaEventTracker2.ToList());
                    await IcanContext.SaveChangesAsync();
                    IcanContext.OnaEventTracker2.AddRange(data);
                    await IcanContext.SaveChangesAsync();

                    //send email after update                   
                    EmailModel email = new EmailModel(_context);
                    email.OnaEventTracker2Email();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public IEnumerable<OnaHhprofile> GetHHProfileRecords()
        //{
        //    //Load the data from the API
        //    var model = new object[0];
        //    var targeturl = string.Format("https://api.ona.io/api/v1/data/415515");
        //    //Jan - Mar
        //    HttpMessageHandler handler = new HttpClientHandler()
        //    {
        //    };

        //    var httpClient = new HttpClient(handler)
        //    {
        //        BaseAddress = new Uri(targeturl),
        //        Timeout = new TimeSpan(0, 10, 0)
        //    };

        //    List<OnaHhprofile> hhprof = new List<OnaHhprofile>();
        //    httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");

        //    //This is the key section you were missing    
        //    var plainTextBytes = System.Text.Encoding.UTF8.GetBytes("ican:abt@1can");
        //    string val = System.Convert.ToBase64String(plainTextBytes);
        //    httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + val);

        //    var method = new HttpMethod("GET");
        //    List<string> myList = new List<string>();

        //    JArray jArray = new JArray();
        //    HttpResponseMessage response = httpClient.GetAsync(targeturl).Result;
        //    if (response.ReasonPhrase == "Not Found")
        //    {
        //        //TempData["Message"] = string.Format("No records found for  {0}-{1}", reportingPeriod.Replace("%20", ""), financialYear.ToString()); ;
        //    }
        //    else
        //    {
        //        string content = string.Empty;

        //        using (StreamReader stream = new StreamReader(response.Content.ReadAsStreamAsync().Result, true))
        //        {
        //            content = stream.ReadToEnd();
        //        }

        //        jArray = JArray.Parse(content);
        //        // Strip off the [] from _tags and Notes


        //        foreach (JObject j in jArray)
        //        {
        //            var cg = new OnaHhprofile();

        //            string dvalue = string.Empty;
        //            double dnumber;
        //            bool success = false;

        //            if (j.GetValue("grouptype") != null)
        //            {
        //                cg.Grouptype = j.GetValue("grouptype").ToString();
        //            }

        //            cg.Id = Convert.ToInt32(j.GetValue("_id").ToString());


        //            if (j.GetValue("end") != null)
        //            {
        //                cg.Endd = j.GetValue("end").ToString();
        //            }

        //            if (j.GetValue("exp") != null)
        //            {
        //                cg.Exp = j.GetValue("exp").ToString();
        //            }

        //            if (j.GetValue("fac") != null)
        //            {
        //                cg.Fac = j.GetValue("fac").ToString();
        //            }

        //            //cg.Fd4 = Convert.ToInt32(j.GetValue("fd4").ToString());
        //            //cg.fd6 = Convert.ToInt32(j.GetValue("fd6").ToString());

        //            if (j.GetValue("gps") != null)
        //            {
        //                cg.Gps = j.GetValue("gps").ToString();
        //            }

        //            if (j.GetValue("loc") != null)
        //            {
        //                cg.Loc = j.GetValue("loc").ToString();
        //            }
        //            if (j.GetValue("use") != null)
        //            {
        //                cg.Usee = Convert.ToInt32(j.GetValue("use").ToString());
        //            }

        //            if (j.GetValue("ack2") != null)
        //            {
        //                cg.Ack2 = j.GetValue("ack2").ToString();
        //            }

        //            if (j.GetValue("agri") != null)
        //            {
        //                cg.Agri = j.GetValue("agri").ToString();
        //            }
        //            if (j.GetValue("gpid") != null)
        //            {
        //                cg.Gpid = j.GetValue("gpid").ToString();
        //            }
        //            if (j.GetValue("use1") != null)
        //            {
        //                cg.Use1 = Convert.ToInt32(j.GetValue("use1").ToString());
        //            }
        //            //Startup here
        //            if (j.GetValue("_uuid") != null)
        //            {
        //                cg.Uuid = j.GetValue("_uuid").ToString();
        //            }

        //            //cg.meals = Convert.ToInt32(j.GetValue("meals").ToString());

        //            if (j.GetValue("start") != null)
        //            {
        //                CultureInfo enUS = new CultureInfo("en-US");
        //                string dateString;
        //                DateTime dateValue;
        //                // Use custom formats with M and MM.
        //                dateString = j.GetValue("start").ToString();
        //                //if (DateTime.TryParseExact(dateString, "M/dd/yyyy hh:mm", enUS,
        //                if (DateTime.TryParse(dateString, out dateValue))
        //                {
        //                    cg.Start = dateValue.ToShortDateString();
        //                }
        //            }

        //            //cg.AmtSav = Convert.ToInt32(j.GetValue("amt_sav").ToString());

        //            if (j.GetValue("foodgrp") != null)
        //            {
        //                cg.Foodgrp = j.GetValue("foodgrp").ToString();
        //            }
        //            if (j.GetValue("hh_head ") != null)
        //            {
        //                cg.HhHead = j.GetValue("hh_head ").ToString();
        //            }

        //            //cg.MemNum = Convert.ToInt32(j.GetValue("mem_num").ToString());

        //            if (j.GetValue("pr_date") != null)
        //            {
        //                CultureInfo enUS = new CultureInfo("en-US");
        //                string dateString;
        //                DateTime dateValue;
        //                // Use custom formats with M and MM.
        //                dateString = j.GetValue("pr_date").ToString();
        //                //if (DateTime.TryParseExact(dateString, "M/dd/yyyy hh:mm", enUS,
        //                if (DateTime.TryParse(dateString, out dateValue))
        //                {
        //                    cg.PrDate = dateValue;// Convert.ToDateTime(j.GetValue("_submission_time").ToString());
        //                }
        //            }

        //            if (j.GetValue("srcfood") != null)
        //            {
        //                cg.Srcfood = j.GetValue("srcfood").ToString();
        //            }
        //            if (j.GetValue("_version") != null)
        //            {
        //                cg.Version = j.GetValue("_version").ToString();
        //            }
        //            if (j.GetValue("deviceid") != null)
        //            {
        //                cg.Deviceid = j.GetValue("deviceid").ToString();
        //            }

        //            if (j.GetValue("fm_count") != null)
        //            {
        //                cg.FmCount = Convert.ToInt32(j.GetValue("fm_count").ToString());
        //            }

        //            if (j.GetValue("gvt/govt") != null)
        //            {
        //                cg.GvtGovt = j.GetValue("gvt/govt").ToString();
        //            }

        //            if (j.GetValue("hhs/hhs1") != null)
        //            {
        //                cg.HhsHhs1 = j.GetValue("hhs/hhs1").ToString();
        //            }

        //            if (j.GetValue("hhs/hhs2") != null)
        //            {
        //                cg.HhsHhs2 = j.GetValue("hhs/hhs2").ToString();
        //            }

        //            //if (j.GetValue("hhs/hhs3") != null)
        //            //{
        //            //    cg.HhsHhs3 = j.GetValue("hhs/hhs23").ToString();
        //            //}

        //            if (j.GetValue("hhs/hhs4") != null)
        //            {
        //                cg.HhsHhs4 = j.GetValue("hhs/hhs4").ToString();
        //            }

        //            if (j.GetValue("hhs/hhs5") != null)
        //            {
        //                cg.HhsHhs5 = j.GetValue("hhs/hhs5").ToString();
        //            }

        //            if (j.GetValue("hhs/hhs6") != null)
        //            {
        //                cg.HhsHhs6 = j.GetValue("hhs/hhs6").ToString();
        //            }

        //            if (j.GetValue("hhs/hhs7") != null)
        //            {
        //                cg.HhsHhs7 = j.GetValue("hhs/hhs7").ToString();
        //            }

        //            if (j.GetValue("hhs/hhs8") != null)
        //            {
        //                cg.HhsHhs8 = j.GetValue("hhs/hhs8").ToString();
        //            }

        //            if (j.GetValue("hhs/hhs9") != null)
        //            {
        //                cg.HhsHhs9 = j.GetValue("hhs/hhs9").ToString();
        //            }

        //            cg.Duration = j.GetValue("_duration").ToString();

        //            cg.XformId = j.GetValue("_xform_id").ToString();


        //            if (j.GetValue("fieldteam") != null)
        //            {
        //                cg.Fieldteam = j.GetValue("fieldteam").ToString();
        //            }
        //            if (j.GetValue("hhs/hhs1a") != null)
        //            {
        //                cg.HhsHhs1a = j.GetValue("hhs/hhs1a").ToString();
        //            }
        //            if (j.GetValue("hhs/hhs2a") != null)
        //            {
        //                cg.HhsHhs2a = j.GetValue("hhs/hhs2a").ToString();
        //            }
        //            if (j.GetValue("hhs/hhs3a") != null)
        //            {
        //                cg.HhsHhs3a = j.GetValue("hhs/hhs3a").ToString();
        //            }
        //            if (j.GetValue("hhs/hhs4a") != null)
        //            {
        //                cg.HhsHhs4a = j.GetValue("hhs/hhs4a").ToString();
        //            }

        //            if (j.GetValue("hhs/hhs5a") != null)
        //            {
        //                cg.HhsHhs5a = j.GetValue("hhs/hhs5a").ToString();
        //            }
        //            if (j.GetValue("hhs/hhs6a") != null)
        //            {
        //                cg.HhsHhs6a = j.GetValue("hhs/hhs6a").ToString();
        //            }
        //            if (j.GetValue("hhs/hhs7a") != null)
        //            {
        //                cg.HhsHhs7a = j.GetValue("hhs/hhs7a").ToString();
        //            }
        //            if (j.GetValue("hhs/hhs9a") != null)
        //            {
        //                cg.HhsHhs9a = j.GetValue("hhs/hhs9a").ToString();
        //            }
        //            if (j.GetValue("loc_parish") != null)
        //            {
        //                cg.LocParish = j.GetValue("loc_parish").ToString();
        //            }
        //            if (j.GetValue("loc_region") != null)
        //            {
        //                cg.LocRegion = j.GetValue("loc_region").ToString();
        //            }
        //            if (j.GetValue("src_income") != null)
        //            {
        //                cg.SrcIncome = j.GetValue("src_income").ToString();
        //            }

        //            if (j.GetValue("agi/aginputs") != null)
        //            {
        //                cg.AgiAginputs = j.GetValue("agi/aginputs").ToString();
        //            }

        //            if (j.GetValue("loc_district") != null)
        //            {
        //                cg.LocDistrict = j.GetValue("loc_district").ToString();
        //            }

        //            if (j.GetValue("_submitted_by") != null)
        //            {
        //                cg.SubmittedBy = j.GetValue("_submitted_by").ToString();
        //            }

        //            if (j.GetValue("loc_subcounty") != null)
        //            {
        //                cg.LocSubcounty = j.GetValue("loc_subcounty").ToString();
        //            }
        //            if (j.GetValue("respondent/hh1") != null)
        //            {
        //                cg.RespondentHh1 = j.GetValue("respondent/hh1").ToString();
        //            }
        //            if (j.GetValue("respondent/hh2") != null)
        //            {
        //                cg.RespondentHh2 = j.GetValue("respondent/hh2").ToString();
        //            }
        //            if (j.GetValue("livestock/agent") != null)
        //            {
        //                cg.LivestockAgent = j.GetValue("livestock/agent").ToString();
        //            }

        //            //cg.LivestockGoats = Convert.ToInt32(j.GetValue("livestock/goats").ToString());

        //            if (j.GetValue("meta/instanceID") != null)
        //            {
        //                cg.MetaInstanceId = j.GetValue("meta/instanceID").ToString();
        //            }

        //            if (j.GetValue("respondent/hhid") != null)
        //            {
        //                cg.RespondentHhid = j.GetValue("respondent/hhid").ToString();
        //            }
        //            if (j.GetValue("respondent/q118") != null)
        //            {
        //                cg.RespondentQ118 = j.GetValue("respondent/q118").ToString();
        //            }
        //            if (j.GetValue("respondent/q119") != null)
        //            {
        //                cg.RespondentQ119 = j.GetValue("respondent/q119").ToString();
        //            }

        //            if (j.GetValue("respondent/q120") != null)
        //            {
        //                cg.RespondentQ120 = j.GetValue("respondent/q120").ToString();
        //            }

        //            if (j.GetValue("econ/src_income1") != null)
        //            {
        //                cg.EconSrcIncome1 = j.GetValue("econ/src_income1").ToString();
        //            }

        //            if (j.GetValue("econ/src_income2") != null)
        //            {
        //                cg.EconSrcIncome2 = j.GetValue("econ/src_income2").ToString();
        //            }

        //            if (j.GetValue("econ/src_income3") != null)
        //            {
        //                cg.EconSrcIncome3 = j.GetValue("econ/src_income3").ToString();
        //            }

        //            if (j.GetValue("econ/src_income5") != null)
        //            {
        //                cg.EconSrcIncome5 = j.GetValue("econ/src_income5").ToString();
        //            }

        //            if (j.GetValue("expenditure/exp1") != null)
        //            {
        //                cg.ExpenditureExp1 = j.GetValue("expenditure/exp1").ToString();
        //            }

        //            if (j.GetValue("expenditure/exp5") != null)
        //            {
        //                cg.ExpenditureExp5 = j.GetValue("expenditure/exp5").ToString();
        //            }

        //            if (j.GetValue("expenditure/exp6") != null)
        //            {
        //                cg.ExpenditureExp6 = j.GetValue("expenditure/exp6").ToString();
        //            }

        //            if (j.GetValue("expenditure/exp7") != null)
        //            {
        //                cg.ExpenditureExp7 = j.GetValue("expenditure/exp7").ToString();
        //            }

        //            if (j.GetValue("livestock/assets") != null)
        //            {
        //                cg.LivestockAssets = j.GetValue("livestock/assets").ToString();
        //            }

        //            if (j.GetValue("prod_assets/prod") != null)
        //            {
        //                cg.ProdAssetsProd = j.GetValue("prod_assets/prod").ToString();
        //            }

        //            if (j.GetValue("respondent/fname") != null)
        //            {
        //                cg.RespondentFname = j.GetValue("respondent/fname").ToString();
        //            }

        //            //cg.RespondentHhnum = Convert.ToInt32(j.GetValue("respondent/hhnum").ToString());

        //            if (j.GetValue("respondent/lname") != null)
        //            {
        //                cg.RespondentLname = j.GetValue("respondent/lname").ToString();
        //            }

        //            if (j.GetValue("respondent/msres") != null)
        //            {
        //                cg.RespondentMsres = j.GetValue("respondent/msres").ToString();
        //            }

        //            //cg.LivestockChicken = Convert.ToInt32(j.GetValue("livestock/chicken").ToString());
        //            //cg.prod_assets_prod4 = Convert.ToInt32(j.GetValue("prod_assets/prod4").ToString());
        //            //cg.prod_assets_prod6 = Convert.ToInt32(j.GetValue("prod_assets/prod6").ToString());
        //            //cg.prod_assets_prod7 = Convert.ToInt32(j.GetValue("prod_assets/prod7").ToString());
        //            //cg.RespondentAgeres = Convert.ToInt32(j.GetValue("respondent/ageres").ToString());

        //            if (j.GetValue("respondent/ageres") != null)
        //            {
        //                cg.RespondentAgeres = Convert.ToDouble(j.GetValue("respondent/ageres").ToString());
        //            }


        //            if (j.GetValue("respondent/sexres") != null)
        //            {
        //                cg.RespondentSexres = j.GetValue("respondent/sexres").ToString();
        //            }

        //            if (j.GetValue("respondent/educres") != null)
        //            {
        //                cg.RespondentEducres = j.GetValue("respondent/educres").ToString();
        //            }

        //            //cg.RespondentPhoneres = Convert.ToInt32(j.GetValue("respondent/phoneres").ToString());

        //            if (j.GetValue("hh_decision/decision1") != null)
        //            {
        //                cg.HhDecisionDecision1 = j.GetValue("hh_decision/decision1").ToString();
        //            }

        //            if (j.GetValue("hh_decision/decision2") != null)
        //            {
        //                cg.HhDecisionDecision2 = j.GetValue("hh_decision/decision2").ToString();
        //            }

        //            if (j.GetValue("hh_decision/decision3") != null)
        //            {
        //                cg.HhDecisionDecision3 = j.GetValue("hh_decision/decision3").ToString();
        //            }

        //            if (j.GetValue("hh_decision/decision4") != null)
        //            {
        //                cg.HhDecisionDecision4 = j.GetValue("hh_decision/decision4").ToString();
        //            }

        //            if (j.GetValue("hh_decision/decision5") != null)
        //            {
        //                cg.HhDecisionDecision5 = j.GetValue("hh_decision/decision5").ToString();
        //            }

        //            if (j.GetValue("hh_decision/decision6") != null)
        //            {
        //                cg.HhDecisionDecision6 = j.GetValue("hh_decision/decision6").ToString();
        //            }
        //            if (j.GetValue("respondent/hivstatus_res") != null)
        //            {
        //                cg.RespondentHivstatusRes = j.GetValue("respondent/hivstatus_res").ToString();
        //            }

        //            var a = j.GetValue("_geolocation") as object;
        //            var c = a.ToString().Replace("\r", "").Replace("\n", "").Replace("[", "").Replace("]", "").Trim();
        //            var b = c.Split(',');
        //            if (b.Length == 2)
        //            {
        //                double d = 0;
        //                if (double.TryParse(b[0], out d))
        //                {
        //                    cg.GpsLatitude = d;
        //                }
        //                if (double.TryParse(b[1], out d))
        //                {
        //                    cg.GpsLongitude = d;
        //                }
        //            }
        //            cg.LastUpdatedAt = DateTime.Now;

        //            hhprof.Add(cg);
        //        }
        //    }

        //    //this.hhproData = hhprof;

        //    return hhprof;


        //}

        //public async Task SaveHHProfileData()
        //{
        //    try
        //    {
        //        using (var IcanContext = new USAID_ICANContext())
        //        {
        //            var data = GetHHProfileRecords().ToList();
        //            IcanContext.OnaHhprofile.RemoveRange(IcanContext.OnaHhprofile.ToList());
        //            await IcanContext.SaveChangesAsync();
        //            IcanContext.OnaHhprofile.AddRange(data);
        //            await IcanContext.SaveChangesAsync();
        //        }
        //    }

        //    catch (Exception ex)
        //    {

        //    }
        //}

        //public async async Task SaveHHProfileData()
        //{
        //    try
        //    {
        //        //var w = await GetHHProfileRecords2();
        //        var data = GetHHProfileRecords().ToList();

        //        foreach (var n in data)
        //        {
        //            OnaHhprofile x = new OnaHhprofile()
        //            {
        //                Id = Convert.ToDouble(n._id),
        //                Ack2 = n.ack2,
        //                AgiAginputs = n.agi_aginputs,
        //                //AgiAginputs1 = n.i,
        //                //AgiAginputs10 = n.agiagi,
        //                //AgiAginputs2 = n.ag,
        //                MetaInstanceId = n.meta_instanceID,
        //                //AgiAgr1 = n.agiagr,
        //                //AgiAgr7 = n.agr7,
        //                Agri = n.agri,
        //                AmtSav = n.amt_sav,
        //                HhsHhs1a = n.hhs_hhs1a,
        //                HhsHhs2a = n.hhs_hhs2a,
        //                HhsHhs1 = n.hhs_hhs1,
        //                HhsHhs2 = n.hhs_hhs2,
        //                HhsHhs3 = n.hhs_hhs3,
        //                HhsHhs3a = n.hhs_hhs3a,
        //                HhsHhs4 = n.hhs_hhs4,
        //                HhsHhs4a = n.hhs_hhs4a,
        //                HhsHhs5 = n.hhs_hhs5,
        //                HhsHhs5a = n.hhs_hhs5a,
        //                HhsHhs6 = n.hhs_hhs6,
        //                HhsHhs6a = n.hhs_hhs6a,
        //                HhsHhs7 = n.hhs_hhs7,
        //                HhsHhs7a = n.hhs_hhs7a,
        //                HhsHhs8 = n.hhs_hhs8,
        //                //HhsHhs8a = n.hhs_hhs8a,
        //                Fieldteam = n.fieldteam,
        //                HhsHhs9 = n.hhs_hhs9,
        //                HhsHhs9a = n.hhs_hhs9a,
        //                HhDecisionDecision1 = n.hh_decision_decision1,
        //                HhDecisionDecision2 = n.hh_decision_decision2,
        //                HhDecisionDecision3 = n.hh_decision_decision3,
        //                HhDecisionDecision4 = n.hh_decision_decision4,
        //                HhDecisionDecision5 = n.hh_decision_decision5,
        //                HhDecisionDecision6 = n.hh_decision_decision6,
        //                //HhDecisionOtherDc6 = n.dc6,
        //                //HhDecisionOtherDcs1 = n.,
        //                //GpsAltitude = n.gps,
        //                Gps = n.gps,
        //                //HeadAgehh = n.age,
        //                LivestockAgent = n.livestock_agent,
        //                //LivestockAssetOther = n.live,
        //                LivestockAssets = n.livestock_assets,
        //                //LivestockAssets1 = n.ass,
        //                //LivestockAssets10 = n.asse,
        //                ProdAssetsProd = n.prod_assets_prod,
        //                //ProdAssetsProd1 = n.prod,
        //                ProdAssetsProd4 = Convert.ToBoolean(n.prod_assets_prod4),
        //                ProdAssetsProd6 = Convert.ToBoolean(n.prod_assets_prod6),
        //                ProdAssetsProd7 = Convert.ToBoolean(n.prod_assets_prod7),
        //                RespondentAgeres = n.respondent_ageres,
        //                RespondentEducres = n.respondent_educres,
        //                RespondentFname = n.respondent_fname,
        //                RespondentHh1 = n.respondent_hh1,
        //                RespondentHh2 = n.respondent_hh2,
        //                RespondentHhid = n.respondent_hhid,
        //                RespondentHhnum = n.respondent_hhnum,
        //                RespondentHivstatusRes = n.respondent_hivstatus_res,
        //                RespondentLname = n.respondent_lname,
        //                RespondentMsres = n.respondent_msres,
        //                RespondentPhoneres = n.respondent_phoneres,
        //                RespondentQ118 = n.respondent_q118,
        //                RespondentQ119 = n.respondent_q119,
        //                RespondentQ120 = n.respondent_q120,
        //                RespondentSexres = n.respondent_sexres,
        //                //Comments = n.com,
        //                Deviceid = n.deviceid,
        //                //Duration = n._duration,
        //                //EconReservedNameForFieldListLabels48 = n.econ_src_in,
        //                EconSrcIncome1 = n.econ_src_income1,
        //                EconSrcIncome2 = n.econ_src_income2,
        //                EconSrcIncome3 = n.econ_src_income3,
        //                EconSrcIncome5 = n.econ_src_income5,
        //                //Endd = n.end,
        //                Exp = n.exp,
        //                ExpenditureExp1 = n.expenditure_exp1,
        //                ExpenditureExp5 = n.expenditure_exp5,
        //                ExpenditureExp6 = n.expenditure_exp6,
        //                ExpenditureExp7 = n.expenditure_exp7,
        //                //Ereid = n.erei,
        //                Fac = n.fac,
        //                Fd4 = n.fd4,
        //                Fd6 = n.fd6,
        //                FmCount = Convert.ToInt32(n.fm_count),
        //                Foodgrp = n.foodgrp,
        //                Uuid = n._uuid,
        //                Gpid = n.gpid,
        //                GvtGovt = n.gvt_govt,
        //                Loc = n.loc,
        //                LocDistrict = n.loc_district,
        //                LocParish = n.loc_parish,
        //                LocRegion = n.loc_region,
        //                LocSubcounty = n.loc_subcounty,
        //                MemNum = n.mem_num,
        //                Meals = n.meals,
        //                Version = n._version,
        //                SubmissionTime = Convert.ToString(n._submission_time),
        //                SubmittedBy = n._submitted_by,
        //                Notes = Convert.ToString(n._notes),
        //                PrDate = Convert.ToDateTime(n.pr_date),
        //                Srcfood = n.srcfood,
        //                SrcIncome = n.src_income,
        //                Start = Convert.ToString(n.start),
        //                XformId= Convert.ToString(n._xform_id),
        //                Tags = Convert.ToString(n._tags),
        //                Usee= Convert.ToInt32(n.use),
        //                Use1 = Convert.ToInt32(n.use1)

        //            };

        //            var exist = _context.OnaHhprofile.FirstOrDefault(o => o.Id == x.Id);
        //            if (exist != null)
        //            {

        //            }
        //            else
        //            {
        //                _context.OnaHhprofile.Add(x);
        //                await _context.SaveChangesAsync();

        //                //var attachment = n._attachments;
        //                //foreach (var t in attachment)
        //                //{
        //                //    var a = (t as Ona1Attachmentsamplegrps);
        //                //    if (a != null)
        //                //    {
        //                //        _context.Ona1Attachmentsamplegrps.Add(a);
        //                //        await _context.SaveChangesAsync();
        //                //    }
        //                //}
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        #endregion HHProfile

        #region InstitutionMapping
        public IEnumerable<OnaInstitutionMapping> GetInstitnMappingRecords()
        {
            //Load the data from the API
            var model = new object[0];
            var targeturl = string.Format("https://api.ona.io/api/v1/data/390584");
            //Jan - Mar
            HttpMessageHandler handler = new HttpClientHandler()
            {
            };

            var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(targeturl),
                Timeout = new TimeSpan(0, 20, 0)
            };

            List<OnaInstitutionMapping> instmap = new List<OnaInstitutionMapping>();
            httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");

            //This is the key section you were missing    
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes("ican:abt@1can");
            string val = System.Convert.ToBase64String(plainTextBytes);
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + val);

            var method = new HttpMethod("GET");
            List<string> myList = new List<string>();

            JArray jArray = new JArray();
            HttpResponseMessage response = httpClient.GetAsync(targeturl).Result;
            if (response.ReasonPhrase == "Not Found")
            {
                //TempData["Message"] = string.Format("No records found for  {0}-{1}", reportingPeriod.Replace("%20", ""), financialYear.ToString()); ;
            }
            else
            {
                string content = string.Empty;

                using (StreamReader stream = new StreamReader(response.Content.ReadAsStreamAsync().Result, true))
                {
                    content = stream.ReadToEnd();
                }

                jArray = JArray.Parse(content);
                // Strip off the [] from _tags and Notes


                foreach (JObject j in jArray)
                {
                    var cg = new OnaInstitutionMapping();

                    string dvalue = string.Empty;
                    double dnumber;
                    bool success = false;


                    if (j.GetValue("_id") != null)
                    {
                        cg.Id = Convert.ToInt32(j.GetValue("_id").ToString());
                    }

                    if (j.GetValue("_uuid") != null)
                    {
                        cg.Uuid = j.GetValue("_uuid").ToString();
                    }

                    if (j.GetValue("Qn/crc") != null)
                    {
                        cg.QnCrc = j.GetValue("Qn/crc").ToString();
                    }

                    if (j.GetValue("Qn/end") != null)
                    {
                        cg.QnEnd = j.GetValue("Qn/end").ToString();
                    }

                    if (j.GetValue("Qn/gps") != null)
                    {
                        cg.QnGps = j.GetValue("Qn/gps").ToString();
                    }

                    if (j.GetValue("Qn/id1") != null)
                    {
                        cg.QnId1 = j.GetValue("Qn/id1").ToString();
                    }
                    if (j.GetValue("Qn/id2") != null)
                    {
                        cg.QnId2 = j.GetValue("Qn/id2").ToString();
                    }

                    if (j.GetValue("Qn/id3") != null)
                    {
                        cg.QnId3 = j.GetValue("Qn/id3").ToString();
                    }

                    if (j.GetValue("Qn/loc") != null)
                    {
                        cg.QnLoc = j.GetValue("Qn/loc").ToString();
                    }

                    if (j.GetValue("Qn/pta") != null)
                    {
                        cg.QnPta = j.GetValue("Qn/pta").ToString();
                    }

                    if (j.GetValue("Qn/ack2") != null)
                    {
                        cg.QnAck2 = j.GetValue("Qn/ack2").ToString();
                    }

                    if (j.GetValue("Qn/crc1") != null)
                    {
                        cg.QnCrc1 = j.GetValue("Qn/crc1").ToString();
                    }

                    if (j.GetValue("Qn/type") != null)
                    {
                        cg.QnType = j.GetValue("Qn/type").ToString();
                    }

                    if (j.GetValue("Qn/start") != null)
                    {
                        cg.QnStart = j.GetValue("Qn/start").ToString();
                    }

                    if (j.GetValue("_version") != null)
                    {
                        cg.Version = j.GetValue("_version").ToString();
                    }

                    if (j.GetValue("_duration") != null)
                    {
                        cg.Duration = Convert.ToDouble(j.GetValue("_duration").ToString());
                    }

                    if (j.GetValue("fieldteam") != null)
                    {
                        cg.Fieldteam = j.GetValue("fieldteam").ToString();
                    }

                    if (j.GetValue("Qn/ass_date") != null)
                    {
                        CultureInfo enUS = new CultureInfo("en-US");
                        string dateString;
                        DateTime dateValue;
                        // Use custom formats with M and MM.
                        dateString = j.GetValue("Qn/ass_date").ToString();
                        //if (DateTime.TryParseExact(dateString, "M/dd/yyyy hh:mm", enUS,
                        if (DateTime.TryParse(dateString, out dateValue))
                        {
                            cg.QnAssDate = dateValue;
                        }
                    }

                    if (j.GetValue("Qn/comments") != null)
                    {
                        cg.QnComments = j.GetValue("Qn/comments").ToString();
                    }

                    if (j.GetValue("Qn/deviceid") != null)
                    {
                        cg.QnDeviceid = j.GetValue("Qn/deviceid").ToString();
                    }

                    if (j.GetValue("Qn/sch_male") != null)
                    {
                        cg.QnSchMale = Convert.ToDouble(j.GetValue("Qn/sch_male").ToString());
                    }


                    if (j.GetValue("Qn/males_crc") != null)
                    {
                        cg.QnMalesCrc = Convert.ToDouble(j.GetValue("Qn/males_crc").ToString());
                    }

                    if (j.GetValue("Qn/strucName") != null)
                    {
                        cg.QnStrucName = j.GetValue("Qn/strucName").ToString();
                    }

                    if (j.GetValue("Qn/loc_parish") != null)
                    {
                        cg.QnLocParish = j.GetValue("Qn/loc_parish").ToString();
                    }

                    if (j.GetValue("Qn/loc_region") != null)
                    {
                        cg.QnLocRegion = j.GetValue("Qn/loc_region").ToString();
                    }

                    if (j.GetValue("Qn/sch_female") != null)
                    {
                        cg.QnSchFemale = Convert.ToDouble(j.GetValue("Qn/sch_female").ToString());
                    }

                    if (j.GetValue("Qn/schooltype") != null)
                    {
                        cg.QnSchooltype = Convert.ToInt32(j.GetValue("Qn/schooltype").ToString());
                    }

                    if (j.GetValue("_submitted_by") != null)
                    {
                        cg.SubmittedBy = j.GetValue("_submitted_by").ToString();
                    }

                    if (j.GetValue("Qn/atten_males") != null)
                    {
                        cg.QnAttenMales = Convert.ToDouble(j.GetValue("Qn/atten_males").ToString());
                    }

                    if (j.GetValue("Qn/crc_partner") != null)
                    {
                        cg.QnCrcPartner = j.GetValue("Qn/crc_partner").ToString();
                    }

                    if (j.GetValue("Qn/females_crc") != null)
                    {
                        cg.QnFemalesCrc = Convert.ToDouble(j.GetValue("Qn/females_crc").ToString());
                    }

                    if (j.GetValue("Qn/num_partner") != null)
                    {
                        cg.QnNumPartner = Convert.ToDouble(j.GetValue("Qn/num_partner").ToString());
                    }

                    if (j.GetValue("Qn/loc_district") != null)
                    {
                        cg.QnLocDistrict = j.GetValue("Qn/loc_district").ToString();
                    }

                    if (j.GetValue("Qn/maleteachers") != null)
                    {
                        cg.QnMaleteachers = Convert.ToDouble(j.GetValue("Qn/maleteachers").ToString());
                    }

                    if (j.GetValue("meta/instanceID") != null)
                    {
                        cg.MetaInstanceId = j.GetValue("meta/instanceID").ToString();
                    }

                    if (j.GetValue("Qn/atten_females") != null)
                    {
                        cg.QnAttenFemales = Convert.ToDouble(j.GetValue("Qn/atten_females").ToString());
                    }

                    if (j.GetValue("Qn/loc_subcounty") != null)
                    {
                        cg.QnLocSubcounty = j.GetValue("Qn/loc_subcounty").ToString();
                    }

                    if (j.GetValue("Qn/partner_count") != null)
                    {
                        cg.QnPartnerCount = j.GetValue("Qn/partner_count").ToString();
                    }

                    if (j.GetValue("_submission_time") != null)
                    {
                        CultureInfo enUS = new CultureInfo("en-US");
                        string dateString;
                        DateTime dateValue;
                        // Use custom formats with M and MM.
                        dateString = j.GetValue("_submission_time").ToString();
                        //if (DateTime.TryParseExact(dateString, "M/dd/yyyy hh:mm", enUS,
                        if (DateTime.TryParse(dateString, out dateValue))
                        {
                            cg.SubmissionTime = dateValue;
                        }
                    }

                    if (j.GetValue("Qn/femaleteachers") != null)
                    {
                        cg.QnFemaleteachers = Convert.ToDouble(j.GetValue("Qn/femaleteachers").ToString());
                    }

                    if (j.GetValue("Qn/func") != null)
                    {
                        cg.QnFunc = j.GetValue("Qn/func").ToString();
                    }

                    if (j.GetValue("Qn/plan") != null)
                    {
                        cg.QnPlan = j.GetValue("Qn/plan").ToString();
                    }

                    if (j.GetValue("Qn/venue") != null)
                    {
                        cg.QnVenue = j.GetValue("Qn/venue").ToString();
                    }

                    if (j.GetValue("Qn/mem/men") != null)
                    {
                        cg.QnMemMen = Convert.ToDouble(j.GetValue("Qn/mem/men").ToString());
                    }

                    if (j.GetValue("Qn/freqmeet") != null)
                    {
                        cg.QnFreqmeet = j.GetValue("Qn/freqmeet").ToString();
                    }

                    if (j.GetValue("Qn/mem/women") != null)
                    {
                        cg.QnMemWomen = Convert.ToDouble(j.GetValue("Qn/mem/women").ToString());
                    }

                    if (j.GetValue("Qn/typestruc") != null)
                    {
                        cg.QnTypestruc = Convert.ToInt32(j.GetValue("Qn/typestruc").ToString());
                    }

                    if (j.GetValue("Qn/numVillages") != null)
                    {
                        cg.QnNumVillages = Convert.ToDouble(j.GetValue("Qn/numVillages").ToString());
                    }

                    if (j.GetValue("Qn/period/years") != null)
                    {
                        cg.QnPeriodYears = Convert.ToDouble(j.GetValue("Qn/period/years").ToString());
                    }

                    if (j.GetValue("Qn/leaders/name1") != null)
                    {
                        cg.QnLeadersName1 = j.GetValue("Qn/leaders/name1").ToString();
                    }

                    if (j.GetValue("Qn/leaders/name2") != null)
                    {
                        cg.QnLeadersName2 = j.GetValue("Qn/leaders/name2").ToString();
                    }

                    if (j.GetValue("Qn/leaders/contact1") != null)
                    {
                        cg.QnLeadersContact1 = Convert.ToDouble(j.GetValue("Qn/leaders/contact1").ToString());
                    }

                    if (j.GetValue("Qn/leaders/contact2") != null)
                    {
                        cg.QnLeadersContact2 = Convert.ToDouble(j.GetValue("Qn/leaders/contact2").ToString());
                    }


                    if (j.GetValue("Qn/leaders/position1") != null)
                    {
                        cg.QnLeadersPosition1 = j.GetValue("Qn/leaders/position1").ToString();
                    }

                    if (j.GetValue("Qn/leaders/position2") != null)
                    {
                        cg.QnLeadersPosition2 = j.GetValue("Qn/leaders/position2").ToString();
                    }

                    if (j.GetValue("Qn/hu") != null)
                    {
                        cg.QnHu = j.GetValue("Qn/hu").ToString();
                    }

                    if (j.GetValue("Qn/maleVHT") != null)
                    {
                        cg.QnMaleVht = Convert.ToDouble(j.GetValue("Qn/maleVHT").ToString());
                    }

                    if (j.GetValue("Qn/train_fp") != null)
                    {
                        cg.QnTrainFp = Convert.ToDouble(j.GetValue("Qn/train_fp").ToString());
                    }

                    if (j.GetValue("Qn/femaleVHT") != null)
                    {
                        cg.QnFemaleVht = Convert.ToDouble(j.GetValue("Qn/femaleVHT").ToString());
                    }

                    if (j.GetValue("Qn/maleStaff") != null)
                    {
                        cg.QnMaleStaff = Convert.ToDouble(j.GetValue("Qn/maleStaff").ToString());
                    }

                    if (j.GetValue("Qn/train_nutr") != null)
                    {
                        cg.QnTrainNutr = Convert.ToDouble(j.GetValue("Qn/train_nutr").ToString());
                    }

                    if (j.GetValue("Qn/femaleStaff") != null)
                    {
                        cg.QnFemaleStaff = Convert.ToDouble(j.GetValue("Qn/femaleStaff").ToString());
                    }

                    if (j.GetValue("Qn/type_other") != null)
                    {
                        cg.QnTypeOther = j.GetValue("Qn/type_other").ToString();
                    }

                    if (j.GetValue("Qn/male_voca") != null)
                    {
                        cg.QnMaleVoca = j.GetValue("Qn/male_voca").ToString();
                    }

                    if (j.GetValue("Qn/voca_skill") != null)
                    {
                        cg.QnVocaSkill = j.GetValue("Qn/voca_skill").ToString();
                    }

                    if (j.GetValue("Qn/female_voca") != null)
                    {
                        cg.QnFemaleVoca = j.GetValue("Qn/female_voca").ToString();
                    }

                    if (j.GetValue("Qn/period/month") != null)
                    {
                        cg.QnPeriodMonth = j.GetValue("Qn/period/month").ToString();
                    }

                    if (j.GetValue("Qn/ps") != null)
                    {
                        cg.QnPs = j.GetValue("Qn/ps").ToString();
                    }

                    if (j.GetValue("Qn/trader") != null)
                    {
                        cg.QnTrader = j.GetValue("Qn/trader").ToString();
                    }

                    var a = j.GetValue("_geolocation") as object;
                    var c = a.ToString().Replace("\r", "").Replace("\n", "").Replace("[", "").Replace("]", "").Trim();
                    var b = c.Split(',');
                    if (b.Length == 2)
                    {
                        double d = 0;
                        if (double.TryParse(b[0], out d))
                        {
                            cg.QnGpsLatitude = d;
                        }
                        if (double.TryParse(b[1], out d))
                        {
                            cg.QnGpsLongitude = d;
                        }
                    }
                    cg.LastUpdatedAt = DateTime.Now;

                    instmap.Add(cg);
                }
            }

            //this.UpdmiycanData = upmiycangpdata;

            return instmap;
        }

        public async Task SaveInstnMappgData()
        {
            try
            {
                using (var IcanContext = new USAID_ICANContext())
                {
                    var data = GetInstitnMappingRecords().ToList();
                    IcanContext.OnaInstitutionMapping.RemoveRange(IcanContext.OnaInstitutionMapping.ToList());
                    await IcanContext.SaveChangesAsync();
                    IcanContext.OnaInstitutionMapping.AddRange(data);
                    await IcanContext.SaveChangesAsync();

                    //send email after update                   
                    EmailModel email = new EmailModel(_context);
                    email.OnaInstitutionMappingEmail();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion InstitutionMapping

        #region vhtregister
        public IEnumerable<OnavhtRegister> GetVhtrRegisterRecords()
        {
            //Load the data from the API
            var model = new object[0];
            var targeturl = string.Format("https://api.ona.io/api/v1/data/418606");
            //Jan - Mar
            HttpMessageHandler handler = new HttpClientHandler()
            {
            };

            var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(targeturl),
                Timeout = new TimeSpan(0, 20, 0)
            };

            List<OnavhtRegister> vhtdatavar = new List<OnavhtRegister>();

            httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");

            //This is the key section you were missing    
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes("ican:abt@1can");
            string val = System.Convert.ToBase64String(plainTextBytes);
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + val);

            var method = new HttpMethod("GET");
            List<string> myList = new List<string>();

            JArray jArray = new JArray();
            HttpResponseMessage response = httpClient.GetAsync(targeturl).Result;
            if (response.ReasonPhrase == "Not Found")
            {
                //TempData["Message"] = string.Format("No records found for  {0}-{1}", reportingPeriod.Replace("%20", ""), financialYear.ToString()); ;
            }
            else
            {
                string content = string.Empty;

                using (StreamReader stream = new StreamReader(response.Content.ReadAsStreamAsync().Result, true))
                {
                    content = stream.ReadToEnd();
                }

                jArray = JArray.Parse(content);
                // Strip off the [] from _tags and Notes
                _context.Onavhtregistermm5.RemoveRange(_context.Onavhtregistermm5.ToList());
                _context.Onavhtregisterchildren.RemoveRange(_context.Onavhtregisterchildren.ToList());

                foreach (JObject j in jArray)
                {
                    var cg = new OnavhtRegister();
                    var cw = new Onavhtregistermm5();
                    var cf = new Onavhtregisterchildren();
                    string dvalue = string.Empty;
                    double dnumber;
                    bool success = false;
                    //JObject watt = j.GetValue("watt");
                    JArray jxArray = new JArray();
                    var a = j.GetValue("mm5") as JObject;
                    List<Onavhtregistermm5> mm5datavar = new List<Onavhtregistermm5>();
                    List<Onavhtregisterchildren> childrendatavar = new List<Onavhtregisterchildren>();

                    cg.Id = Convert.ToInt32(j.GetValue("_id").ToString());

                    if (j["mm5"] != null)
                    {
                        IEnumerable<JToken> data = j["mm5"].Children().ToList();
                        foreach (JObject js in data)
                        {

                            cw = new Onavhtregistermm5();
                            cw.Id = cg.Id.ToString();
                            cw.Mm5Id = Guid.NewGuid().ToString();

                            if (js.GetValue("mm5/fp") != null)
                            {
                                cw.Mm5Fp = js.GetValue("mm5/fp").ToString();
                            }

                            if (js.GetValue("mm5/tb") != null)
                            {
                                cw.Mm5Tb = js.GetValue("mm5/tb").ToString(); ;
                            }
                            if (js.GetValue("mm5/tx") != null)
                            {
                                cw.Mm5Tx = js.GetValue("mm5/tx").ToString();
                            }
                            if (js.GetValue("mm5/age") != null)
                            {
                                //cw.WattNumUnder2 = js.GetValue("watt/numUnder2").ToString();
                                double ddvalue;
                                if (Double.TryParse(js.GetValue("mm5/age").ToString(), out ddvalue))
                                {
                                    cw.Mm5Age = ddvalue;
                                }
                            }

                            if (js.GetValue("mm5/died") != null)
                            {
                                cw.Mm5Died = js.GetValue("mm5/died").ToString();
                            }

                            if (js.GetValue("mm5/mFname") != null)
                            {
                                cw.Mm5MFname = js.GetValue("mm5/mFname").ToString();
                            }

                            if (js.GetValue("mm5/school") != null)
                            {
                                cw.Mm5School = js.GetValue("mm5/school").ToString();
                            }

                            if (js.GetValue("mm5/mLastname") != null)
                            {
                                cw.Mm5MLastname = js.GetValue("mm5/mLastname").ToString();
                            }

                            if (js.GetValue("mm5/preg") != null)
                            {
                                cw.Mm5Preg = js.GetValue("mm5/preg").ToString();
                            }
                            cw.LastUpdatedAt = DateTime.Now;

                            mm5datavar.Add(cw);
                            //_context.Add(cw);
                            //await _context.SaveChangesAsync();
                        }
                        _context.SaveChanges();
                        _context.Onavhtregistermm5.AddRange(mm5datavar);
                        _context.SaveChanges();
                    }

                    ////Children Here

                    //if (j["children"] != null)
                    //{
                    //    IEnumerable<JToken> data = j["children"].Children().ToList();
                    //    foreach (JObject js in data)
                    //    {

                    //        cf = new Onavhtregisterchildren();
                    //        cf.Id = cg.Id;

                    //        if (js.GetValue("children/art") != null)
                    //        {
                    //            cf.ChildrenArt = js.GetValue("children/art").ToString();
                    //        }

                    //        if (js.GetValue("children/immu") != null)
                    //        {
                    //            cf.ChildrenImmu = js.GetValue("children/immu").ToString(); ;
                    //        }
                    //        if (js.GetValue("children/itn2") != null)
                    //        {
                    //            cf.ChildrenItn2 = js.GetValue("children/itn2").ToString();
                    //        }

                    //        if (js.GetValue("children/muac") != null)
                    //        {
                    //            cf.ChildrenMuac = js.GetValue("children/muac").ToString();
                    //        }

                    //        if (js.GetValue("children/worm") != null)
                    //        {
                    //            cf.ChildrenWorm = js.GetValue("children/worm").ToString();
                    //        }

                    //        if (js.GetValue("children/diedC") != null)
                    //        {
                    //            cf.ChildrenDiedC = js.GetValue("children/diedC").ToString();
                    //        }

                    //        if (js.GetValue("children/ageChild") != null)
                    //        {                              
                    //            int ddvalue;
                    //            if (int.TryParse(js.GetValue("children/ageChild").ToString(), out ddvalue))
                    //            {
                    //                cf.ChildrenAgeChild = ddvalue;
                    //            }
                    //        }

                    //        if (js.GetValue("children/vitaminA") != null)
                    //        {
                    //            cf.ChildrenVitaminA = js.GetValue("children/vitaminA").ToString();
                    //        }

                    //        if (js.GetValue("children/fnameChild") != null)
                    //        {
                    //            cf.ChildrenFnameChild = js.GetValue("children/fnameChild").ToString();
                    //        }

                    //        if (js.GetValue("children/lnameChild") != null)
                    //        {
                    //            cf.ChildrenLnameChild = js.GetValue("children/lnameChild").ToString();
                    //        }
                    //        cf.LastUpdatedAt = DateTime.Now;

                    //        childrendatavar.Add(cf);

                    //    }
                    //    await _context.SaveChangesAsync();
                    //    _context.Onavhtregisterchildren.AddRange(childrendatavar);
                    //    await _context.SaveChangesAsync();
                    //}

                    ////Children Here

                    if (j.GetValue("hc") != null)
                    {
                        cg.Hc = j.GetValue("hc").ToString();
                    }

                    if (j.GetValue("ch5") != null)
                    {
                        cg.Ch5 = j.GetValue("ch5").ToString();
                    }

                    if (j.GetValue("loc") != null)
                    {
                        cg.Loc = j.GetValue("loc").ToString();
                    }

                    if (j.GetValue("id1") != null)
                    {
                        cg.Id1 = j.GetValue("id1").ToString();
                    }

                    if (j.GetValue("id2") != null)
                    {
                        cg.Id2 = j.GetValue("id2").ToString();
                    }

                    //if (j.GetValue("mm5") != null)
                    //{
                    //    cg.mm = j.GetValue("mm5").ToString();
                    //}

                    if (j.GetValue("fname") != null)
                    {
                        cg.Fname = j.GetValue("fname").ToString();
                    }

                    if (j.GetValue("lname") != null)
                    {
                        cg.Lname = j.GetValue("lname").ToString();
                    }

                    if (j.GetValue("loc_parish") != null)
                    {
                        cg.LocParish = j.GetValue("loc_parish").ToString();
                    }

                    if (j.GetValue("loc_region") != null)
                    {
                        cg.LocParish = j.GetValue("loc_region").ToString();
                    }

                    //cg.Duration = Convert.ToDouble(j.GetValue("_duration").ToString());

                    //cg.XformId = Convert.ToInt32(j.GetValue("_xform_id").ToString());

                    if (j.GetValue("loc_district") != null)
                    {
                        cg.LocDistrict = j.GetValue("loc_district").ToString();
                    }

                    if (j.GetValue("loc_subcounty") != null)
                    {
                        cg.LocSubcounty = j.GetValue("loc_subcounty").ToString();
                    }

                    if (j.GetValue("_submission_time") != null)
                    {
                        CultureInfo enUS = new CultureInfo("en-US");
                        string dateString;
                        DateTime dateValue;
                        // Use custom formats with M and MM.
                        dateString = j.GetValue("_submission_time").ToString();
                        //if (DateTime.TryParseExact(dateString, "M/dd/yyyy hh:mm", enUS,
                        if (DateTime.TryParse(dateString, out dateValue))
                        {
                            cg.SubmissionTime = dateValue;// Convert.ToDateTime(j.GetValue("_submission_time").ToString());
                        }
                    }

                    var geo = j.GetValue("_geolocation") as object;
                    var c = geo.ToString().Replace("\r", "").Replace("\n", "").Replace("[", "").Replace("]", "").Trim();
                    var b = c.Split(',');
                    if (b.Length == 2)
                    {
                        double d = 0;
                        if (double.TryParse(b[0], out d))
                        {
                            cg.GpsLatitude = d;
                        }
                        if (double.TryParse(b[1], out d))
                        {
                            cg.GpsLongitude = d;
                        }
                    }

                    cg.LastUpdatedAt = DateTime.Now;

                    vhtdatavar.Add(cg);
                }
            }

            //this.mcggData = mcgdatavar;

            return vhtdatavar;
        }
        public async Task SavevhtregData()
        {
            try
            {
                using (var IcanContext = new USAID_ICANContext())
                {
                    var data = GetVhtrRegisterRecords().ToList();
                    IcanContext.OnavhtRegister.RemoveRange(IcanContext.OnavhtRegister.ToList());
                    await IcanContext.SaveChangesAsync();
                    IcanContext.OnavhtRegister.AddRange(data);
                    await IcanContext.SaveChangesAsync();

                    //send email after update                   
                    EmailModel email = new EmailModel(_context);
                    email.OnavhtRegisterEmail();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion vhtregister

        #region mcg       
        public IEnumerable<Onamcg> GetMCGRecords()
        {
            //Load the data from the API
            var model = new object[0];
            var targeturl = string.Format("https://api.ona.io/api/v1/data/432398");
            //Jan - Mar
            HttpMessageHandler handler = new HttpClientHandler()
            {
            };

            var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(targeturl),
                Timeout = new TimeSpan(0, 20, 0)
            };

            List<Onamcg> mcgdatavar = new List<Onamcg>();

            httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");

            //This is the key section you were missing    
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes("ican:abt@1can");
            string val = System.Convert.ToBase64String(plainTextBytes);
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + val);

            var method = new HttpMethod("GET");
            List<string> myList = new List<string>();

            JArray jArray = new JArray();
            HttpResponseMessage response = httpClient.GetAsync(targeturl).Result;
            if (response.ReasonPhrase == "Not Found")
            {
                //TempData["Message"] = string.Format("No records found for  {0}-{1}", reportingPeriod.Replace("%20", ""), financialYear.ToString()); ;
            }
            else
            {
                string content = string.Empty;

                using (StreamReader stream = new StreamReader(response.Content.ReadAsStreamAsync().Result, true))
                {
                    content = stream.ReadToEnd();
                }

                jArray = JArray.Parse(content);
                // Strip off the [] from _tags and Notes
                _context.Onamcgwatt.RemoveRange(_context.Onamcgwatt.ToList());

                foreach (JObject j in jArray)
                {
                    var cg = new Onamcg();
                    var cw = new Onamcgwatt();
                    string dvalue = string.Empty;
                    double dnumber;
                    bool success = false;
                    //JObject watt = j.GetValue("watt");
                    int len = 0;
                    JArray jxArray = new JArray();
                    var a = j.GetValue("watt") as JObject;
                    List<Onamcgwatt> mcgwattdatavar = new List<Onamcgwatt>();


                    cg.Id = Convert.ToInt32(j.GetValue("_id").ToString());

                    if (j["watt"] != null)
                    {
                        IEnumerable<JToken> data = j["watt"].Children().ToList();

                        foreach (JObject js in data)
                        {

                            cw = new Onamcgwatt();
                            cw.Id = cg.Id;
                            cw.UniqueMcgid = Guid.NewGuid().ToString();

                            if (js.GetValue("watt/yob") != null)
                            {
                                cw.WattYob = Convert.ToDouble(js.GetValue("watt/yob").ToString());
                            }

                            if (js.GetValue("watt/fName") != null)
                            {
                                var wfname = js.GetValue("watt/fName").ToString().Length;
                                var result = wfname > 24 ? 24 : wfname;
                                cw.WattFName = js.GetValue("watt/fName").ToString().Substring(0, result);
                            }
                            if (js.GetValue("watt/gLead") != null)
                            {
                                cw.WattGLead = js.GetValue("watt/gLead").ToString();
                            }
                            if (js.GetValue("watt/lName") != null)
                            {
                                cw.WattLName = js.GetValue("watt/lName").ToString();
                            }
                            if (js.GetValue("watt/mStatus") != null)
                            {
                                cw.WattMStatus = js.GetValue("watt/mStatus").ToString();
                            }
                            if (js.GetValue("watt/numUnder2") != null)
                            {
                                //cw.WattNumUnder2 = js.GetValue("watt/numUnder2").ToString();
                                double ddvalue;
                                if (Double.TryParse(js.GetValue("watt/numUnder2").ToString(), out ddvalue))
                                {
                                    cw.WattNumUnder2 = ddvalue;
                                }
                            }

                            if (js.GetValue("watt/numUnder5") != null)
                            {
                                cw.WattNumUnder5 = Convert.ToDouble(js.GetValue("watt/numUnder5").ToString());
                            }
                            cw.LastUpdatedAt = DateTime.Now;
                            mcgwattdatavar.Add(cw);

                        }

                    }
                    _context.SaveChanges();
                    _context.Onamcgwatt.AddRange(mcgwattdatavar);
                    _context.SaveChanges();

                    //cg.Id = Convert.ToInt32(j.GetValue("_id").ToString());

                    if (j.GetValue("end") != null)
                    {
                        var locc = j.GetValue("end").ToString().Length;
                        var x = locc > 24 ? 24 : locc;
                        cg.Endd = j.GetValue("end").ToString().Substring(0, x);
                    }

                    //if (j.GetValue("gps") != null)
                    //{
                    //    cg.Gps = j.GetValue("gps").ToString();
                    //}

                    if (j.GetValue("loc") != null)
                    {
                        var locc = j.GetValue("loc").ToString().Length;
                        var x = locc > 24 ? 24 : locc;
                        cg.Loc = j.GetValue("loc").ToString().Substring(0, x);
                    }

                    //if (j.GetValue("ack2") != null)
                    //{
                    //    cg.Ack2 = j.GetValue("ack2").ToString();
                    //}

                    //if (j.GetValue("_uuid") != null)
                    //{
                    //    cg.Uuid = j.GetValue("_uuid").ToString();
                    //}

                    if (j.GetValue("start") != null)
                    {
                        var locc = j.GetValue("start").ToString().Length;
                        var x = locc > 24 ? 24 : locc;
                        cg.Start = j.GetValue("start").ToString().Substring(0, x);

                    }

                    if (j.GetValue("venue") != null)
                    {
                        var locc = j.GetValue("venue").ToString().Length;
                        var x = locc > 24 ? 24 : locc;
                        cg.Venue = j.GetValue("venue").ToString().Substring(0, x);

                    }

                    if (j.GetValue("grpname") != null)
                    {
                        var locc = j.GetValue("grpname").ToString().Length;
                        var x = locc > 24 ? 24 : locc;
                        cg.Grpname = j.GetValue("grpname").ToString().Substring(0, x);

                    }

                    //if (j.GetValue("_version") != null)
                    //{
                    //    cg.Version = j.GetValue("_version").ToString();
                    //}

                    //if (j.GetValue("deviceid") != null)
                    //{
                    //    cg.Deviceid = j.GetValue("deviceid").ToString();
                    //}

                    //cg.Duration = Convert.ToDouble(j.GetValue("_duration").ToString());

                    //cg.XformId = Convert.ToInt32(j.GetValue("_xform_id").ToString());

                    if (j.GetValue("fieldteam") != null)
                    {
                        var locc = j.GetValue("fieldteam").ToString().Length;
                        var x = locc > 24 ? 24 : locc;
                        cg.Fieldteam = j.GetValue("fieldteam").ToString().Substring(0, x);

                    }

                    if (j.GetValue("loc_parish") != null)
                    {
                        var locc = j.GetValue("loc_parish").ToString().Length;
                        var x = locc > 24 ? 24 : locc;
                        cg.LocParish = j.GetValue("loc_parish").ToString().Substring(0, x);

                    }

                    if (j.GetValue("loc_region") != null)
                    {
                        var locc = j.GetValue("loc_region").ToString().Length;
                        var x = locc > 24 ? 24 : locc;
                        cg.LocRegion = j.GetValue("loc_region").ToString().Substring(0, x);

                    }

                    if (j.GetValue("loc_district") != null)
                    {
                        var locc = j.GetValue("loc_district").ToString().Length;
                        var x = locc > 24 ? 24 : locc;
                        cg.LocDistrict = j.GetValue("loc_district").ToString().Substring(0, x);

                    }

                    //if (j.GetValue("_submitted_by") != null)
                    //{
                    //    cg.SubmittedBy = j.GetValue("_submitted_by").ToString();
                    //}

                    if (j.GetValue("activity_date") != null)
                    {
                        CultureInfo enUS = new CultureInfo("en-US");
                        string dateString;
                        DateTime dateValue;
                        // Use custom formats with M and MM.
                        dateString = j.GetValue("activity_date").ToString();
                        //if (DateTime.TryParseExact(dateString, "M/dd/yyyy hh:mm", enUS,
                        if (DateTime.TryParse(dateString, out dateValue))
                        {
                            cg.ActivityDate = dateValue;// Convert.ToDateTime(j.GetValue("_submission_time").ToString());
                        }
                    }

                    if (j.GetValue("dateFormation") != null)
                    {
                        CultureInfo enUS = new CultureInfo("en-US");
                        string dateString;
                        DateTime dateValue;
                        // Use custom formats with M and MM.
                        dateString = j.GetValue("dateFormation").ToString();
                        //if (DateTime.TryParseExact(dateString, "M/dd/yyyy hh:mm", enUS,
                        if (DateTime.TryParse(dateString, out dateValue))
                        {
                            cg.DateFormation = dateValue;// Convert.ToDateTime(j.GetValue("_submission_time").ToString());
                        }
                    }


                    if (j.GetValue("loc_subcounty") != null)
                    {
                        var locc = j.GetValue("loc_subcounty").ToString().Length;
                        var x = locc > 24 ? 24 : locc;
                        cg.LocSubcounty = j.GetValue("loc_subcounty").ToString().Substring(0, x);

                    }

                    //if (j.GetValue("meta/instanceID") != null)
                    //{
                    //    cg.MetaInstanceId = j.GetValue("meta/instanceID").ToString();
                    //}

                    if (j.GetValue("_submission_time") != null)
                    {
                        CultureInfo enUS = new CultureInfo("en-US");
                        string dateString;
                        DateTime dateValue;
                        // Use custom formats with M and MM.
                        dateString = j.GetValue("_submission_time").ToString();
                        //if (DateTime.TryParseExact(dateString, "M/dd/yyyy hh:mm", enUS,
                        if (DateTime.TryParse(dateString, out dateValue))
                        {
                            cg.SubmissionTime = dateValue;
                        }
                    }

                    if (j.GetValue("comments") != null)
                    {

                        var comm = j.GetValue("comments").ToString().Length;
                        var result = comm > 24 ? 24 : comm;
                        cg.Comments = j.GetValue("comments").ToString().Substring(0, result);
                    }

                    var geo = j.GetValue("_geolocation") as object;
                    var c = geo.ToString().Replace("\r", "").Replace("\n", "").Replace("[", "").Replace("]", "").Trim();
                    var b = c.Split(',');
                    if (b.Length == 2)
                    {
                        double d = 0;
                        if (double.TryParse(b[0], out d))
                        {
                            cg.GpsLatitude = d;
                        }
                        if (double.TryParse(b[1], out d))
                        {
                            cg.GpsLongitude = d;
                        }
                    }

                    cg.LastUpdatedAt = DateTime.Now;

                    mcgdatavar.Add(cg);
                }
            }

            //this.mcggData = mcgdatavar;

            return mcgdatavar;
        }
        public async Task SavemcgData()
        {
            try
            {
                using (var IcanContext = new USAID_ICANContext())
                {
                    var data = GetMCGRecords().ToList();
                    IcanContext.Onamcg.RemoveRange(IcanContext.Onamcg.ToList());
                    await IcanContext.SaveChangesAsync();
                    IcanContext.Onamcg.AddRange(data);
                    await IcanContext.SaveChangesAsync();

                    //send email after update                   
                    EmailModel email = new EmailModel(_context);
                    email.OnamcgEmail();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion mcg

        #region MIYCAN_MonthlySummaryVer4
        public IEnumerable<OnaMiycanMonthlySummaryVer4> GetMIYCANMonSumer4DataRecords()
        {
            //Load the data from the API
            var model = new object[0];
            var targeturllast = string.Format("https://api.ona.io/api/v1/data/488652");
            List<OnaMiycanMonthlySummaryVer4> micannonsum = new List<OnaMiycanMonthlySummaryVer4>();
            //Here
            HttpMessageHandler handlerlast = new HttpClientHandler()
            {
            };

            var httpClientlast = new HttpClient(handlerlast)
            {
                BaseAddress = new Uri(targeturllast),
                Timeout = new TimeSpan(0, 20, 0)
            };

            httpClientlast.DefaultRequestHeaders.Add("ContentType", "application/json");

            //This is the key section you were missing    
            var plainTextByteslast = System.Text.Encoding.UTF8.GetBytes("ican:abt@1can");
            string vallast = System.Convert.ToBase64String(plainTextByteslast);
            httpClientlast.DefaultRequestHeaders.Add("Authorization", "Basic " + vallast);

            var methodlast = new HttpMethod("GET");
            List<string> myListlast = new List<string>();

            JArray jArraylast = new JArray();
            HttpResponseMessage responselast = httpClientlast.GetAsync(targeturllast).Result;

            var alink = responselast.Headers.FirstOrDefault(o => o.Key == "Link");
            var pages = alink.Value.FirstOrDefault();
            var page_1 = pages.Split(",");
            string lastpage = null;
            foreach (var nw in page_1)
            {
                if (nw.Contains("last"))
                {
                    var ax = nw.Split(";");
                    lastpage = ax[0].Replace('<', ' ').Replace('>', ' ').Trim();
                }
            }

            int i = 1;

            while (true)
            {
                var targeturl = "https://api.ona.io/api/v1/data/488652" + "?page=" + i + "&page_size=10000";

                HttpMessageHandler handler = new HttpClientHandler()
                {
                };

                var httpClient = new HttpClient(handler)
                {
                    BaseAddress = new Uri(targeturl),
                    Timeout = new TimeSpan(0, 20, 0)
                };

                //List<OnaCommunitygroupSummary2021> commgrpsummver5 = new List<OnaCommunitygroupSummary2021>();
                httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");

                //This is the key section you were missing    
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes("ican:abt@1can");
                string val = System.Convert.ToBase64String(plainTextBytes);
                httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + val);

                var method = new HttpMethod("GET");
                List<string> myList = new List<string>();

                JArray jArray = new JArray();
                HttpResponseMessage response = httpClient.GetAsync(targeturl).Result;

                if (response.ReasonPhrase == "Not Found")
                {
                    //TempData["Message"] = string.Format("No records found for  {0}-{1}", reportingPeriod.Replace("%20", ""), financialYear.ToString()); ;
                }
                else
                {
                    string content = string.Empty;

                    using (StreamReader stream = new StreamReader(response.Content.ReadAsStreamAsync().Result, true))
                    {
                        content = stream.ReadToEnd();
                    }

                    jArray = JArray.Parse(content);

                    foreach (JObject j in jArray)
                    {
                        var cg = new OnaMiycanMonthlySummaryVer4();

                        string dvalue = string.Empty;
                        double dnumber;
                        bool success = false;

                        if (j.GetValue("district") != null)
                        {
                            cg.District = j.GetValue("district").ToString();
                        }
                        if (j.GetValue("location/groupid") != null)
                        {
                            cg.Groupid = j.GetValue("location/groupid").ToString();
                        }

                        if (j.GetValue("subcounty") != null)
                        {
                            cg.Subcounty = j.GetValue("subcounty").ToString();
                        }

                        if (j.GetValue("village") != null)
                        {
                            cg.Village = j.GetValue("village").ToString();
                        }

                        if (j.GetValue("location/groupname") != null)
                        {
                            cg.Groupname = j.GetValue("location/groupname").ToString();
                        }

                        if (j.GetValue("fo") != null)
                        {
                            cg.Fo = j.GetValue("fo").ToString();
                        }

                        if (j.GetValue("calc_yr") != null)
                        {
                            cg.CalcYr = j.GetValue("calc_yr").ToString();
                        }

                        if (j.GetValue("curr_yr") != null)
                        {
                            cg.CurrYr = j.GetValue("curr_yr").ToString();
                        }

                        if (j.GetValue("curr_mth") != null)
                        {
                            cg.CurrMth = j.GetValue("curr_mth").ToString();
                        }

                        if (j.GetValue("month") != null)
                        {
                            cg.Month = j.GetValue("month").ToString();
                        }

                        if (j.GetValue("year") != null)
                        {
                            cg.Year = j.GetValue("year").ToString();
                        }

                        if (j.GetValue("mod") != null)
                        {
                            cg.Mod = j.GetValue("mod").ToString();
                        }

                        if (j.GetValue("mod1") != null)
                        {
                            cg.Mod1 = j.GetValue("mod1").ToString();
                        }

                        if (j.GetValue("mod1_1") != null)
                        {
                            cg.Mod11 = Convert.ToDouble(j.GetValue("mod1_1").ToString());
                        }

                        if (j.GetValue("mod1_2") != null)
                        {
                            cg.Mod12 = Convert.ToDouble(j.GetValue("mod1_2").ToString());
                        }

                        if (j.GetValue("mod1_3") != null)
                        {
                            cg.Mod13 = Convert.ToDouble(j.GetValue("mod1_3").ToString());
                        }

                        if (j.GetValue("mod1_4") != null)
                        {
                            cg.Mod14 = Convert.ToDouble(j.GetValue("mod1_4").ToString());
                        }

                        if (j.GetValue("mod1_5") != null)
                        {
                            cg.Mod15 = Convert.ToDouble(j.GetValue("mod1_5").ToString());
                        }
                        if (j.GetValue("mod1_6") != null)
                        {
                            cg.Mod16 = Convert.ToDouble(j.GetValue("mod1_6").ToString());
                        }
                        if (j.GetValue("mod1_7") != null)
                        {
                            cg.Mod17 = Convert.ToDouble(j.GetValue("mod1_7").ToString());
                        }
                        if (j.GetValue("mod1_10") != null)
                        {
                            cg.Mod110 = Convert.ToDouble(j.GetValue("mod1_10").ToString());
                        }
                        if (j.GetValue("mod1_8") != null)
                        {
                            cg.Mod18 = Convert.ToDouble(j.GetValue("mod1_8").ToString());
                        }
                        if (j.GetValue("mod1_9") != null)
                        {
                            cg.Mod19 = Convert.ToDouble(j.GetValue("mod1_9").ToString());
                        }
                        if (j.GetValue("mod1_11") != null)
                        {
                            cg.Mod111 = Convert.ToDouble(j.GetValue("mod1_11").ToString());
                        }
                        if (j.GetValue("mod2") != null)
                        {
                            cg.Mod2 = j.GetValue("mod2").ToString();
                        }
                        if (j.GetValue("mod2_1") != null)
                        {
                            cg.Mod21 = Convert.ToDouble(j.GetValue("mod2_1").ToString());
                        }
                        if (j.GetValue("mod2_2") != null)
                        {
                            cg.Mod22 = Convert.ToDouble(j.GetValue("mod2_2").ToString());
                        }
                        if (j.GetValue("mod2_3") != null)
                        {
                            cg.Mod23 = Convert.ToDouble(j.GetValue("mod2_3").ToString());
                        }
                        if (j.GetValue("mod2_4") != null)
                        {
                            cg.Mod24 = Convert.ToDouble(j.GetValue("mod2_4").ToString());
                        }
                        if (j.GetValue("mod3") != null)
                        {
                            cg.Mod3 = j.GetValue("mod3").ToString();
                        }
                        if (j.GetValue("mod3_1") != null)
                        {
                            cg.Mod31 = Convert.ToDouble(j.GetValue("mod3_1").ToString());
                        }
                        if (j.GetValue("mod3_2") != null)
                        {
                            cg.Mod32 = Convert.ToDouble(j.GetValue("mod3_2").ToString());
                        }
                        if (j.GetValue("mod3_3") != null)
                        {
                            cg.Mod33 = Convert.ToDouble(j.GetValue("mod3_3").ToString());
                        }
                        if (j.GetValue("mod3_4") != null)
                        {
                            cg.Mod34 = Convert.ToDouble(j.GetValue("mod3_4").ToString());
                        }
                        if (j.GetValue("mod3_5") != null)
                        {
                            cg.Mod35 = Convert.ToDouble(j.GetValue("mod3_5").ToString());
                        }
                        if (j.GetValue("mod3_6") != null)
                        {
                            cg.Mod36 = Convert.ToDouble(j.GetValue("mod3_6").ToString());
                        }
                        if (j.GetValue("mod3_7") != null)
                        {
                            cg.Mod37 = Convert.ToDouble(j.GetValue("mod3_7").ToString());
                        }
                        if (j.GetValue("mod4") != null)
                        {
                            cg.Mod4 = j.GetValue("mod4").ToString();
                        }
                        if (j.GetValue("mod4_1") != null)
                        {
                            cg.Mod41 = Convert.ToDouble(j.GetValue("mod4_1").ToString());
                        }
                        if (j.GetValue("mod4_2") != null)
                        {
                            cg.Mod42 = Convert.ToDouble(j.GetValue("mod4_2").ToString());
                        }
                        if (j.GetValue("mod4_3") != null)
                        {
                            cg.Mod43 = Convert.ToDouble(j.GetValue("mod4_3").ToString());
                        }
                        if (j.GetValue("mod4_4") != null)
                        {
                            cg.Mod44 = Convert.ToDouble(j.GetValue("mod4_4").ToString());
                        }
                        if (j.GetValue("mod4_5") != null)
                        {
                            cg.Mod45 = Convert.ToDouble(j.GetValue("mod4_5").ToString());
                        }
                        if (j.GetValue("mod4_6") != null)
                        {
                            cg.Mod46 = Convert.ToDouble(j.GetValue("mod4_6").ToString());
                        }
                        if (j.GetValue("moth/l19") != null)
                        {
                            cg.L19 = Convert.ToDouble(j.GetValue("moth/l19").ToString());
                        }
                        if (j.GetValue("moth/p19") != null)
                        {
                            cg.P19 = Convert.ToDouble(j.GetValue("moth/p19").ToString());
                        }
                        if (j.GetValue("moth/pA19") != null)
                        {
                            cg.PA19 = Convert.ToDouble(j.GetValue("moth/pA19").ToString());
                        }
                        if (j.GetValue("moth/lA19") != null)
                        {
                            cg.LA19 = Convert.ToDouble(j.GetValue("moth/lA19").ToString());
                        }
                        if (j.GetValue("oth/o19f") != null)
                        {
                            cg.O19f = Convert.ToDouble(j.GetValue("oth/o19f").ToString());
                        }
                        if (j.GetValue("oth/o19m") != null)
                        {
                            cg.O19m = Convert.ToDouble(j.GetValue("oth/o19m").ToString());
                        }

                        if (j.GetValue("oth/oA19f") != null)
                        {
                            cg.OA19f = Convert.ToDouble(j.GetValue("oth/oA19f").ToString());
                        }

                        if (j.GetValue("oth/oA19m") != null)
                        {
                            cg.OA19m = Convert.ToDouble(j.GetValue("oth/oA19m").ToString());
                        }

                        if (j.GetValue("alll") != null)
                        {
                            cg.Alll = j.GetValue("alll").ToString();
                        }

                        if (j.GetValue("PregMothers") != null)
                        {
                            cg.PregMothers = j.GetValue("PregMothers").ToString();
                        }

                        if (j.GetValue("LacMothers") != null)
                        {
                            cg.LacMothers = j.GetValue("LacMothers").ToString();
                        }

                        if (j.GetValue("OtherM") != null)
                        {
                            cg.OtherM = j.GetValue("OtherM").ToString();
                        }

                        if (j.GetValue("OtherF") != null)
                        {
                            cg.OtherF = j.GetValue("OtherF").ToString();
                        }

                        if (j.GetValue("maleChilddeath") != null)
                        {
                            cg.MaleChilddeath = Convert.ToDouble(j.GetValue("maleChilddeath").ToString());
                        }

                        if (j.GetValue("femaleChilddeath") != null)
                        {
                            cg.FemaleChilddeath = Convert.ToDouble(j.GetValue("femaleChilddeath").ToString());
                        }

                        if (j.GetValue("mothers_dead") != null)
                        {
                            cg.MothersDead = Convert.ToDouble(j.GetValue("mothers_dead").ToString());
                        }

                        if (j.GetValue("muac/scrMale") != null)
                        {
                            cg.ScrMale = Convert.ToDouble(j.GetValue("muac/scrMale").ToString());
                        }

                        if (j.GetValue("muac/scrFemale") != null)
                        {
                            cg.ScrFemale = Convert.ToDouble(j.GetValue("muac/scrFemale").ToString());
                        }

                        if (j.GetValue("muac/scrMale2") != null)
                        {
                            cg.ScrMale2 = Convert.ToDouble(j.GetValue("muac/scrMale2").ToString());
                        }

                        if (j.GetValue("muac/scrFemale2") != null)
                        {
                            cg.ScrFemale2 = Convert.ToDouble(j.GetValue("muac/scrFemale2").ToString());
                        }

                        if (j.GetValue("muac/yellowMale5") != null)
                        {
                            cg.YellowMale5 = Convert.ToDouble(j.GetValue("muac/yellowMale5").ToString());
                        }

                        if (j.GetValue("muac/yellowFemale5") != null)
                        {
                            cg.YellowFemale5 = Convert.ToDouble(j.GetValue("muac/yellowFemale5").ToString());
                        }

                        if (j.GetValue("muac/yellowMale2") != null)
                        {
                            cg.YellowMale2 = Convert.ToDouble(j.GetValue("muac/yellowMale2").ToString());
                        }

                        if (j.GetValue("muac/yellowFemale2") != null)
                        {
                            cg.YellowFemale2 = Convert.ToDouble(j.GetValue("muac/yellowFemale2").ToString());
                        }

                        if (j.GetValue("muac/redMale5") != null)
                        {
                            cg.RedMale5 = Convert.ToDouble(j.GetValue("muac/redMale5").ToString());
                        }

                        if (j.GetValue("muac/redFemale5") != null)
                        {
                            cg.RedFemale5 = Convert.ToDouble(j.GetValue("muac/redFemale5").ToString());
                        }

                        if (j.GetValue("muac/redMale2") != null)
                        {
                            cg.RedMale2 = Convert.ToDouble(j.GetValue("muac/redMale2").ToString());
                        }

                        if (j.GetValue("muac/redFemale2") != null)
                        {
                            cg.RedFemale2 = Convert.ToDouble(j.GetValue("muac/redFemale2").ToString());
                        }

                        if (j.GetValue("muac/scr") != null)
                        {
                            cg.Scr = j.GetValue("muac/scr").ToString();
                        }

                        if (j.GetValue("referrals") != null)
                        {
                            cg.Referrals = j.GetValue("referrals").ToString();
                        }

                        if (j.GetValue("referrals_1") != null)
                        {
                            cg.Referrals1 = Convert.ToDouble(j.GetValue("referrals_1").ToString());
                        }

                        if (j.GetValue("referrals_2") != null)
                        {
                            cg.Referrals2 = Convert.ToDouble(j.GetValue("referrals_2").ToString());
                        }

                        if (j.GetValue("referrals_3") != null)
                        {
                            cg.Referrals3 = Convert.ToDouble(j.GetValue("referrals_3").ToString());
                        }

                        if (j.GetValue("otheref") != null)
                        {
                            cg.Otheref = j.GetValue("otheref").ToString();
                        }

                        if (j.GetValue("referrals_4") != null)
                        {
                            cg.Referrals4 = Convert.ToDouble(j.GetValue("referrals_4").ToString());
                        }

                        if (j.GetValue("referrals_5") != null)
                        {
                            cg.Referrals5 = Convert.ToDouble(j.GetValue("referrals_5").ToString());
                        }

                        if (j.GetValue("numANC") != null)
                        {
                            cg.NumAnc = j.GetValue("numANC").ToString();
                        }

                        if (j.GetValue("numFP") != null)
                        {
                            cg.NumFp = j.GetValue("numFP").ToString();
                        }

                        if (j.GetValue("numMal") != null)
                        {
                            cg.NumMal = j.GetValue("numMal").ToString();
                        }

                        if (j.GetValue("numOther") != null)
                        {
                            cg.NumOther = j.GetValue("numOther").ToString();
                        }

                        if (j.GetValue("image") != null)
                        {
                            cg.Image = j.GetValue("image").ToString();
                        }

                        if (j.GetValue("_index") != null)
                        {
                            cg.Index = Convert.ToDouble(j.GetValue("_index").ToString());
                        }

                        cg.Id = Convert.ToInt32(j.GetValue("_id").ToString());

                        //if (j.GetValue("end") != null)
                        //{
                        //    CultureInfo enUS = new CultureInfo("en-US");
                        //    string dateString;
                        //    DateTime dateValue;
                        //    // Use custom formats with M and MM.
                        //    dateString = j.GetValue("end").ToString();
                        //    //if (DateTime.TryParseExact(dateString, "M/dd/yyyy hh:mm", enUS,
                        //    if (DateTime.TryParse(dateString, out dateValue))
                        //    {
                        //        cg.Endd = dateValue;
                        //    }
                        //}

                        if (j.GetValue("end") != null)
                        {
                            cg.Endd = j.GetValue("end").ToString();
                        }

                        //if (j.GetValue("gps") != null)
                        //{
                        //    cg.gps = j.GetValue("gps").ToString();
                        //}

                        //cg.h20 = j.GetValue("h20").ToString();

                        //if (j.GetValue("id1") != null)
                        //{
                        //    cg.id1 = j.GetValue("id1").ToString();
                        //}

                        //if (j.GetValue("id2") != null)
                        //{
                        //    cg.id2 = j.GetValue("id2").ToString();
                        //}

                        //if (j.GetValue("loc") != null)
                        //{
                        //    cg.loc = j.GetValue("loc").ToString();
                        //}

                        //cg.red = j.GetValue("red").ToString();

                        if (j.GetValue("ack2") != null)
                        {
                            cg.Ack2 = j.GetValue("ack2").ToString();
                        }

                        //cg.food = j.GetValue("food").ToString();
                        //cg.preg = j.GetValue("preg").ToString();

                        //cg.watt = j.GetValue("watt").ToString();
                        //cg._tags = j.GetValue("_tags").ToString();

                        if (j.GetValue("_uuid") != null)
                        {
                            cg.Uuid = j.GetValue("_uuid").ToString();
                        }
                        if (j.GetValue("grpid") != null)
                        {
                            cg.Groupid = j.GetValue("grpid").ToString();
                        }

                        //if (j.GetValue("start") != null)
                        //{
                        //    CultureInfo enUS = new CultureInfo("en-US");
                        //    string dateString;
                        //    DateTime dateValue;
                        //    // Use custom formats with M and MM.
                        //    dateString = j.GetValue("start").ToString();
                        //    //if (DateTime.TryParseExact(dateString, "M/dd/yyyy hh:mm", enUS,
                        //    if (DateTime.TryParse(dateString, out dateValue))
                        //    {
                        //        cg.Start = dateValue;
                        //    }
                        //}

                        if (j.GetValue("start") != null)
                        {
                            cg.Start = j.GetValue("start").ToString();
                        }

                        if (j.GetValue("grpname") != null)
                        {
                            cg.Groupname = j.GetValue("grpname").ToString();
                        }

                        //cg.washfac = j.GetValue("washfac").ToString();

                        if (j.GetValue("_version") != null)
                        {
                            cg.Version = j.GetValue("_version").ToString();
                        }

                        if (j.GetValue("comments") != null)
                        {
                            cg.Comments = j.GetValue("comments").ToString();
                        }

                        if (j.GetValue("deviceid") != null)
                        {
                            cg.Deviceid = j.GetValue("deviceid").ToString();
                        }

                        //cg.sessions = j.GetValue("sessions").ToString();

                        if (j.GetValue("vhtFname") != null)
                        {
                            cg.VhtFname = j.GetValue("vhtFname").ToString();
                        }

                        if (j.GetValue("vhtLname") != null)
                        {
                            cg.VhtLname = j.GetValue("vhtLname").ToString();
                        }

                        cg.Duration = Convert.ToDouble(j.GetValue("_duration").ToString());

                        cg.XformId = Convert.ToInt32(j.GetValue("_xform_id").ToString());

                        if (j.GetValue("loc_district") != null)
                        {
                            cg.District = j.GetValue("loc_district").ToString();
                        }

                        if (j.GetValue("loc_subcounty") != null)
                        {
                            cg.Subcounty = j.GetValue("loc_subcounty").ToString();
                        }

                        if (j.GetValue("mothers_dead") != null)
                        {
                            cg.MothersDead = Convert.ToDouble(j.GetValue("mothers_dead").ToString());
                        }
                        if (j.GetValue("_submitted_by") != null)
                        {
                            cg.SubmittedBy = j.GetValue("_submitted_by").ToString();
                        }

                        if (j.GetValue("meta/instanceID") != null)
                        {
                            cg.InstanceId = j.GetValue("meta/instanceID").ToString();
                        }

                        if (j.GetValue("_submission_time") != null)
                        {
                            CultureInfo enUS = new CultureInfo("en-US");
                            string dateString;
                            DateTime dateValue;
                            // Use custom formats with M and MM.
                            dateString = j.GetValue("_submission_time").ToString();
                            //if (DateTime.TryParseExact(dateString, "M/dd/yyyy hh:mm", enUS,
                            if (DateTime.TryParse(dateString, out dateValue))
                            {
                                cg.SubmissionTime = dateValue;
                            }

                            var a = j.GetValue("_geolocation") as object;
                            var c = a.ToString().Replace("\r", "").Replace("\n", "").Replace("[", "").Replace("]", "").Trim();
                            var b = c.Split(',');
                            if (b.Length == 2)
                            {
                                double d = 0;
                                if (double.TryParse(b[0], out d))
                                {
                                    cg.Latitude = d;
                                }
                                if (double.TryParse(b[1], out d))
                                {
                                    cg.Longitude = d;
                                }
                            }

                            cg.LastUpdatedAt = DateTime.Now;

                            using (var dbContext = new USAID_ICANContext())
                            {
                                var exist = dbContext.OnaMiycanMonthlySummaryVer4.FirstOrDefault(o => o.Id == cg.Id);
                                if (exist == null)
                                {
                                    micannonsum.Add(cg);
                                }
                            }
                        }
                        //micannonsum.Add(cg);
                    }
                }
                i++;

                if (targeturl == lastpage)
                    break;
            }

            return micannonsum;
        }

        public async Task SavemiycanmonSumData()
        {
            try
            {
                using (var IcanContext = new USAID_ICANContext())
                {
                    var data = GetMIYCANMonSumer4DataRecords().ToList();
                    //IcanContext.OnaMiycanMonthlySummaryVer4.RemoveRange(IcanContext.OnaMiycanMonthlySummaryVer4.ToList());
                    //await IcanContext.SaveChangesAsync();
                    IcanContext.OnaMiycanMonthlySummaryVer4.AddRange(data);
                    await IcanContext.SaveChangesAsync();

                    //send email after update                   
                    EmailModel email = new EmailModel(_context);
                    email.OnaMiycanMonthlySummaryVer4Email();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion MIYCAN_MonthlySummaryVer4

        #region refNote
        public IEnumerable<OnarefNote> GetrefNoteRecords()
        {
            //Load the data from the API
            var model = new object[0];
            var targeturl = string.Format("https://api.ona.io/api/v1/data/418614");
            //Jan - Mar
            HttpMessageHandler handler = new HttpClientHandler()
            {
            };

            var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(targeturl),
                Timeout = new TimeSpan(0, 20, 0)
            };

            List<OnarefNote> refnt = new List<OnarefNote>();
            httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");

            //This is the key section you were missing    
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes("ican:abt@1can");
            string val = System.Convert.ToBase64String(plainTextBytes);
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + val);

            var method = new HttpMethod("GET");
            List<string> myList = new List<string>();

            JArray jArray = new JArray();
            HttpResponseMessage response = httpClient.GetAsync(targeturl).Result;

            if (response.ReasonPhrase == "Not Found")
            {
                //TempData["Message"] = string.Format("No records found for  {0}-{1}", reportingPeriod.Replace("%20", ""), financialYear.ToString()); ;
            }
            else
            {
                string content = string.Empty;

                using (StreamReader stream = new StreamReader(response.Content.ReadAsStreamAsync().Result, true))
                {
                    content = stream.ReadToEnd();
                }

                jArray = JArray.Parse(content);
                // Strip off the [] from _tags and Notes


                foreach (JObject j in jArray)
                {
                    var cg = new OnarefNote();

                    string dvalue = string.Empty;
                    double dnumber;
                    bool success = false;

                    cg.Id = Convert.ToInt32(j.GetValue("_id").ToString());

                    if (j.GetValue("age") != null)
                    {
                        cg.Age = Convert.ToDouble(j.GetValue("age").ToString());
                    }

                    if (j.GetValue("_uuid") != null)
                    {
                        cg.Uuid = j.GetValue("_uuid").ToString();
                    }

                    if (j.GetValue("end") != null)
                    {
                        CultureInfo enUS = new CultureInfo("en-US");
                        string dateString;
                        DateTime dateValue;
                        // Use custom formats with M and MM.
                        dateString = j.GetValue("end").ToString();
                        //if (DateTime.TryParseExact(dateString, "M/dd/yyyy hh:mm", enUS,
                        if (DateTime.TryParse(dateString, out dateValue))
                        {
                            cg.Endd = dateValue.ToShortDateString();
                        }
                    }

                    if (j.GetValue("id1") != null)
                    {
                        cg.Id1 = j.GetValue("id1").ToString();
                    }
                    if (j.GetValue("id2") != null)
                    {
                        cg.Id2 = j.GetValue("id2").ToString();
                    }
                    if (j.GetValue("loc") != null)
                    {
                        cg.Loc = j.GetValue("loc").ToString();
                    }
                    if (j.GetValue("ref") != null)
                    {
                        cg.Ref = j.GetValue("ref").ToString();
                    }
                    if (j.GetValue("sex") != null)
                    {
                        cg.Sex = j.GetValue("sex").ToString();
                    }

                    if (j.GetValue("ack2") != null)
                    {
                        cg.Ack2 = j.GetValue("ack2").ToString();
                    }

                    if (j.GetValue("hhid") != null)
                    {
                        cg.Hhid = j.GetValue("hhid").ToString();
                    }

                    if (j.GetValue("fName") != null)
                    {
                        cg.FName = j.GetValue("fName").ToString();
                    }

                    if (j.GetValue("lName") != null)
                    {
                        cg.LName = j.GetValue("lName").ToString();
                    }

                    if (j.GetValue("start") != null)
                    {
                        CultureInfo enUS = new CultureInfo("en-US");
                        string dateString;
                        DateTime dateValue;
                        // Use custom formats with M and MM.
                        dateString = j.GetValue("start").ToString();
                        //if (DateTime.TryParseExact(dateString, "M/dd/yyyy hh:mm", enUS,
                        if (DateTime.TryParse(dateString, out dateValue))
                        {
                            cg.Start = dateValue.ToShortDateString();
                        }
                    }

                    if (j.GetValue("venue") != null)
                    {
                        cg.Venue = j.GetValue("venue").ToString();
                    }

                    if (j.GetValue("serial") != null)
                    {
                        cg.Serial = Convert.ToDouble(j.GetValue("serial").ToString());
                    }

                    if (j.GetValue("_version") != null)
                    {
                        cg.Version = j.GetValue("_version").ToString();
                    }

                    if (j.GetValue("comments") != null)
                    {
                        cg.Comments = j.GetValue("comments").ToString();
                    }

                    if (j.GetValue("deviceid") != null)
                    {
                        cg.Deviceid = j.GetValue("deviceid").ToString();
                    }

                    if (j.GetValue("ref_date") != null)
                    {
                        CultureInfo enUS = new CultureInfo("en-US");
                        string dateString;
                        DateTime dateValue;
                        if (DateTime.TryParse(j.GetValue("ref_date").ToString(), out dateValue))
                        {
                            cg.RefDate = dateValue;
                        }

                    }

                    if (j.GetValue("_xform_id") != null)
                    {
                        cg.XformId = Convert.ToInt32(j.GetValue("_xform_id").ToString());
                    }

                    if (j.GetValue("fieldteam") != null)
                    {
                        cg.Fieldteam = j.GetValue("fieldteam").ToString();
                    }

                    if (j.GetValue("loc_parish") != null)
                    {
                        cg.LocParish = j.GetValue("loc_parish").ToString();
                    }

                    if (j.GetValue("loc_region") != null)
                    {
                        cg.LocRegion = j.GetValue("loc_region").ToString();
                    }

                    if (j.GetValue("motherName") != null)
                    {
                        cg.MotherName = j.GetValue("motherName").ToString();
                    }

                    if (j.GetValue("loc_district") != null)
                    {
                        cg.LocDistrict = j.GetValue("loc_district").ToString();
                    }
                    if (j.GetValue("_submitted_by") != null)
                    {
                        cg.SubmittedBy = j.GetValue("_submitted_by").ToString();
                    }
                    if (j.GetValue("loc_subcounty") != null)
                    {
                        cg.LocSubcounty = j.GetValue("loc_subcounty").ToString();
                    }

                    if (j.GetValue("meta/instanceID") != null)
                    {
                        cg.MetaInstanceId = j.GetValue("meta/instanceID").ToString();
                    }

                    if (j.GetValue("_submission_time") != null)
                    {
                        CultureInfo enUS = new CultureInfo("en-US");
                        string dateString;
                        DateTime dateValue;
                        // Use custom formats with M and MM.
                        dateString = j.GetValue("_submission_time").ToString();
                        //if (DateTime.TryParseExact(dateString, "M/dd/yyyy hh:mm", enUS,
                        if (DateTime.TryParse(dateString, out dateValue))
                        {
                            cg.SubmissionTime = dateValue;
                        }
                    }

                    if (j.GetValue("other_ref") != null)
                    {
                        cg.OtherRef = j.GetValue("other_ref").ToString();
                    }
                    if (j.GetValue("muac") != null)
                    {
                        cg.Muac = j.GetValue("muac").ToString();
                    }
                    if (j.GetValue("vhtfn") != null)
                    {
                        cg.Vhtfn = j.GetValue("vhtfn").ToString();
                    }
                    if (j.GetValue("vhtln") != null)
                    {
                        cg.Vhtln = j.GetValue("vhtln").ToString();
                    }

                    var a = j.GetValue("_geolocation") as object;
                    var c = a.ToString().Replace("\r", "").Replace("\n", "").Replace("[", "").Replace("]", "").Trim();
                    var b = c.Split(',');
                    if (b.Length == 2)
                    {
                        double d = 0;
                        if (double.TryParse(b[0], out d))
                        {
                            cg.Latitude = d;
                        }
                        if (double.TryParse(b[1], out d))
                        {
                            cg.Longitude = d;
                        }
                    }

                    cg.LastUpdatedAt = DateTime.Now;

                    refnt.Add(cg);
                }
            }

            //this.cgassData = cgassmentdt;

            return refnt;


        }
        public async Task SaverefNoteData()
        {
            try
            {
                using (var IcanContext = new USAID_ICANContext())
                {
                    var data = GetrefNoteRecords().ToList();
                    IcanContext.OnarefNote.RemoveRange(IcanContext.OnarefNote.ToList());
                    await IcanContext.SaveChangesAsync();
                    IcanContext.OnarefNote.AddRange(data);
                    await IcanContext.SaveChangesAsync();

                    //send email after update                   
                    EmailModel email = new EmailModel(_context);
                    email.OnarefNoteEmail();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion refNote

        #region RMS1
        public IEnumerable<OnaRms1> GetRMS1Records()
        {
            //Load the data from the API
            var model = new object[0];
            var targeturl = string.Format("https://api.ona.io/api/v1/data/544916");
            //Jan - Mar
            HttpMessageHandler handler = new HttpClientHandler()
            {
            };

            var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(targeturl),
                Timeout = new TimeSpan(0, 20, 0)
            };

            List<OnaRms1> rms1 = new List<OnaRms1>();
            httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");

            //This is the key section you were missing    
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes("ican:abt@1can");
            string val = System.Convert.ToBase64String(plainTextBytes);
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + val);

            var method = new HttpMethod("GET");
            List<string> myList = new List<string>();

            JArray jArray = new JArray();
            HttpResponseMessage response = httpClient.GetAsync(targeturl).Result;

            if (response.ReasonPhrase == "Not Found")
            {
                //TempData["Message"] = string.Format("No records found for  {0}-{1}", reportingPeriod.Replace("%20", ""), financialYear.ToString()); ;
            }
            else
            {
                string content = string.Empty;

                using (StreamReader stream = new StreamReader(response.Content.ReadAsStreamAsync().Result, true))
                {
                    content = stream.ReadToEnd();
                }

                jArray = JArray.Parse(content);
                // Strip off the [] from _tags and Notes


                foreach (JObject j in jArray)
                {
                    var cg = new OnaRms1();

                    string dvalue = string.Empty;
                    double dnumber;
                    bool success = false;

                    if (j.GetValue("ra") != null)
                    {
                        cg.Ra = j.GetValue("ra").ToString();
                    }

                    cg.Id = Convert.ToInt32(j.GetValue("_id").ToString());

                    if (j.GetValue("A/Z6") != null)
                    {
                        cg.AZ6 = j.GetValue("A/Z6").ToString();
                    }

                    if (j.GetValue("A/Z7") != null)
                    {
                        cg.AZ7 = j.GetValue("A/Z7").ToString();
                    }

                    if (j.GetValue("A/Z8") != null)
                    {
                        cg.AZ8 = j.GetValue("A/Z8").ToString();
                    }

                    if (j.GetValue("Qn/Z4") != null)
                    {
                        cg.QnZ4 = j.GetValue("Qn/Z4").ToString();
                    }

                    if (j.GetValue("_uuid") != null)
                    {
                        cg.Uuid = j.GetValue("_uuid").ToString();
                    }

                    if (j.GetValue("Qn/end") != null)
                    {
                        CultureInfo enUS = new CultureInfo("en-US");
                        string dateString;
                        DateTime dateValue;
                        // Use custom formats with M and MM.
                        dateString = j.GetValue("Qn/end").ToString();
                        //if (DateTime.TryParseExact(dateString, "M/dd/yyyy hh:mm", enUS,
                        if (DateTime.TryParse(dateString, out dateValue))
                        {
                            cg.QnEnd = dateValue;
                        }
                    }

                    if (j.GetValue("Qn/ack2") != null)
                    {
                        cg.QnAck2 = j.GetValue("Qn/ack2").ToString();
                    }
                    if (j.GetValue("Qn/qn11") != null)
                    {
                        cg.QnQn11 = j.GetValue("Qn/qn11").ToString();
                    }
                    if (j.GetValue("Qn/qn13") != null)
                    {
                        cg.QnQn13 = j.GetValue("Qn/qn13").ToString();
                    }
                    if (j.GetValue("Qn/qn14") != null)
                    {
                        cg.QnQn14 = j.GetValue("Qn/qn14").ToString();
                    }
                    if (j.GetValue("Qn/qn15") != null)
                    {
                        cg.QnQn15 = j.GetValue("Qn/qn15").ToString();
                    }

                    if (j.GetValue("Qn/qn16") != null)
                    {
                        cg.QnQn16 = j.GetValue("Qn/qn16").ToString();
                    }

                    if (j.GetValue("village") != null)
                    {
                        cg.Village = j.GetValue("village").ToString();
                    }

                    if (j.GetValue("Qn/qn121") != null)
                    {
                        cg.QnQn121 = Convert.ToDouble(j.GetValue("Qn/qn121").ToString());
                    }

                    if (j.GetValue("_version") != null)
                    {
                        cg.Version = j.GetValue("_version").ToString();
                    }

                    if (j.GetValue("district") != null)
                    {
                        cg.District = j.GetValue("district").ToString();
                    }

                    //if (j.GetValue("_duration") != null)
                    //{
                    //    cg.Duration = j.GetValue("_duration").ToString();
                    //}

                    if (j.GetValue("_xform_id") != null)
                    {
                        cg.XformId = Convert.ToInt32(j.GetValue("_xform_id").ToString());
                    }

                    if (j.GetValue("subcounty") != null)
                    {
                        cg.Subcounty = j.GetValue("subcounty").ToString();
                    }

                    if (j.GetValue("Qn/comments") != null)
                    {
                        cg.QnComments = j.GetValue("Qn/comments").ToString();
                    }

                    if (j.GetValue("Qn/ack_noteM") != null)
                    {
                        cg.QnAckNoteM = j.GetValue("Qn/ack_noteM").ToString();
                    }

                    if (j.GetValue("Qn/signature") != null)
                    {
                        cg.QnSignature = j.GetValue("Qn/signature").ToString();
                    }

                    if (j.GetValue("Qn/qn16_times") != null)
                    {
                        cg.QnQn16Times = Convert.ToDouble(j.GetValue("Qn/qn16_times").ToString());
                    }

                    if (j.GetValue("_submitted_by") != null)
                    {
                        cg.SubmittedBy = j.GetValue("_submitted_by").ToString();
                    }

                    if (j.GetValue("Qn/qn16_seasons") != null)
                    {
                        cg.QnQn16Seasons = Convert.ToDouble(j.GetValue("Qn/qn16_seasons").ToString());
                    }

                    if (j.GetValue("meta/instanceID") != null)
                    {
                        cg.MetaInstanceId = j.GetValue("meta/instanceID").ToString();
                    }

                    if (j.GetValue("Qn/sectionc/qn21") != null)
                    {
                        cg.QnSectioncQn21 = Convert.ToDouble(j.GetValue("Qn/sectionc/qn21").ToString());
                    }

                    if (j.GetValue("Qn/sectionc/qn22") != null)
                    {
                        cg.QnSectioncQn22 = j.GetValue("Qn/sectionc/qn22").ToString();
                    }

                    if (j.GetValue("Qn/sectionc/qn23") != null)
                    {
                        cg.QnSectioncQn23 = j.GetValue("Qn/sectionc/qn23").ToString();
                    }

                    if (j.GetValue("Qn/sectionc/qn24") != null)
                    {
                        cg.QnSectioncQn24 = Convert.ToDouble(j.GetValue("Qn/sectionc/qn24").ToString());
                    }

                    if (j.GetValue("Qn/sectionc/qn25") != null)
                    {
                        cg.QnSectioncQn25 = j.GetValue("Qn/sectionc/qn25").ToString();
                    }

                    if (j.GetValue("Qn/sectionc/qn27") != null)
                    {
                        cg.QnSectioncQn27 = Convert.ToDouble(j.GetValue("Qn/sectionc/qn27").ToString());
                    }

                    if (j.GetValue("Qn/sectionc/qn28") != null)
                    {
                        cg.QnSectioncQn28 = j.GetValue("Qn/sectionc/qn28").ToString();
                    }

                    if (j.GetValue("Qn/sectionc/qn29") != null)
                    {
                        cg.QnSectioncQn29 = j.GetValue("Qn/sectionc/qn29").ToString();
                    }

                    if (j.GetValue("Qn/sectiond/cap2") != null)
                    {
                        cg.QnSectiondCap2 = j.GetValue("Qn/sectiond/cap2").ToString();
                    }

                    if (j.GetValue("_submission_time") != null)
                    {
                        CultureInfo enUS = new CultureInfo("en-US");
                        string dateString;
                        DateTime dateValue;
                        // Use custom formats with M and MM.
                        dateString = j.GetValue("_submission_time").ToString();
                        //if (DateTime.TryParseExact(dateString, "M/dd/yyyy hh:mm", enUS,
                        if (DateTime.TryParse(dateString, out dateValue))
                        {
                            cg.SubmissionTime = dateValue;
                        }
                    }

                    if (j.GetValue("location/groupid") != null)
                    {
                        cg.LocationGroupid = j.GetValue("location/groupid").ToString();
                    }

                    if (j.GetValue("Qn/sectionc/qn211") != null)
                    {
                        cg.QnSectioncQn211 = j.GetValue("Qn/sectionc/qn211").ToString();
                    }

                    if (j.GetValue("Qn/sectionc/qn212") != null)
                    {
                        cg.QnSectioncQn212 = Convert.ToDouble(j.GetValue("Qn/sectionc/qn212").ToString());
                    }

                    if (j.GetValue("Qn/sectionc/qn216") != null)
                    {
                        cg.QnSectioncQn216 = Convert.ToDouble(j.GetValue("Qn/sectionc/qn216").ToString());
                    }

                    if (j.GetValue("Qn/sectionc/qn221") != null)
                    {
                        cg.QnSectioncQn221 = Convert.ToDouble(j.GetValue("Qn/sectionc/qn221").ToString());
                    }

                    if (j.GetValue("Qn/sectionc/qn251") != null)
                    {
                        cg.QnSectioncQn251Main = j.GetValue("Qn/sectionc/qn251").ToString();
                    }

                    if (j.GetValue("Qn/sectiond/cap14") != null)
                    {
                        cg.QnSectiondCap14Main = j.GetValue("Qn/sectiond/cap14").ToString();
                    }

                    if (j.GetValue("Qn/sectiond/cap17") != null)
                    {
                        cg.QnSectiondCap17Main = j.GetValue("Qn/sectiond/cap17").ToString();
                    }

                    if (j.GetValue("Qn/sectione/necpa") != null)
                    {
                        cg.QnSectioneNecpa = j.GetValue("Qn/sectione/necpa").ToString();
                    }

                    if (j.GetValue("Qn/sectiond/shocks") != null)
                    {
                        cg.QnSectiondShocks = j.GetValue("Qn/sectiond/shocks").ToString();
                    }

                    if (j.GetValue("Qn/sectione/necpa1") != null)
                    {
                        cg.QnSectioneNecpa1 = j.GetValue("Qn/sectione/necpa1").ToString();
                    }

                    if (j.GetValue("Qn/sectiond/shocks2") != null)
                    {
                        cg.QnSectiondShocks2Main = j.GetValue("Qn/sectiond/shocks2").ToString();
                    }

                    if (j.GetValue("Qn/sectiond/shocks14") != null)
                    {
                        cg.QnSectiondShocks14Main = j.GetValue("Qn/sectiond/shocks14").ToString();
                    }

                    if (j.GetValue("Qn/sectiond/shocks17") != null)
                    {
                        cg.QnSectiondShocks17Main = j.GetValue("Qn/sectiond/shocks17").ToString();
                    }

                    if (j.GetValue("Qn/sectiond/cap4") != null)
                    {
                        cg.QnSectiondCap4Main = j.GetValue("Qn/sectiond/cap4").ToString();
                    }

                    if (j.GetValue("Qn/sectiond/cap9") != null)
                    {
                        cg.QnSectiondCap9Main = j.GetValue("Qn/sectiond/cap9").ToString();
                    }

                    if (j.GetValue("Qn/sectione/necpa3") != null)
                    {
                        cg.QnSectioneNecpa3 = j.GetValue("Qn/sectione/necpa3").ToString();
                    }

                    if (j.GetValue("Qn/sectione/necpa4") != null)
                    {
                        cg.QnSectioneNecpa4 = j.GetValue("Qn/sectione/necpa4").ToString();
                    }

                    if (j.GetValue("Qn/sectiond/shocks4") != null)
                    {
                        cg.QnSectiondShocks4Main = j.GetValue("Qn/sectiond/shocks4").ToString();
                    }

                    if (j.GetValue("Qn/sectiond/shocks9") != null)
                    {
                        cg.QnSectiondShocks9Main = j.GetValue("Qn/sectiond/shocks9").ToString();
                    }

                    if (j.GetValue("Qn/sectionc/other_qn23") != null)
                    {
                        cg.QnSectioncOtherQn23 = j.GetValue("Qn/sectionc/other_qn23").ToString();
                    }

                    if (j.GetValue("Qn/sectionc/qn252") != null)
                    {
                        cg.QnSectioncQn252Main = j.GetValue("Qn/sectionc/qn252").ToString();
                    }

                    if (j.GetValue("Qn/sectione/necpa6") != null)
                    {
                        cg.QnSectioneNecpa6 = j.GetValue("Qn/sectione/necpa6").ToString();
                    }

                    if (j.GetValue("Qn/sectione/necpa7") != null)
                    {
                        cg.QnSectioneNecpa7 = j.GetValue("Qn/sectione/necpa7").ToString();
                    }

                    if (j.GetValue("Qn/sectionc/other_situation") != null)
                    {
                        cg.QnSectioncOtherSituation = j.GetValue("Qn/sectionc/other_situation").ToString();
                    }

                    if (j.GetValue("Qn/sectionc/qn213") != null)
                    {
                        cg.QnSectioncQn213 = j.GetValue("Qn/sectionc/qn213").ToString();
                    }

                    if (j.GetValue("Qn/sectionc/qn254") != null)
                    {
                        cg.QnSectioncQn254Main = j.GetValue("Qn/sectionc/qn254").ToString();
                    }

                    if (j.GetValue("Qn/sectionc/qn256") != null)
                    {
                        cg.QnSectioncQn256Main = j.GetValue("Qn/sectionc/qn256").ToString();
                    }

                    if (j.GetValue("Qn/sectiond/cap18") != null)
                    {
                        cg.QnSectiondCap18Main = j.GetValue("Qn/sectiond/cap18").ToString();
                    }

                    if (j.GetValue("Qn/sectionc/qn2131") != null)
                    {
                        cg.QnSectioncQn2131 = j.GetValue("Qn/sectionc/qn2131").ToString();
                    }

                    if (j.GetValue("Qn/sectiond/shocks18") != null)
                    {
                        cg.QnSectiondShocks18Main = j.GetValue("Qn/sectiond/shocks18").ToString();
                    }

                    if (j.GetValue("Qn/sectiond/cap6") != null)
                    {
                        cg.QnSectiondCap6Main = j.GetValue("Qn/sectiond/cap6").ToString();
                    }

                    if (j.GetValue("Qn/sectione/necpa2") != null)
                    {
                        cg.QnSectioneNecpa2 = j.GetValue("Qn/sectione/necpa2").ToString();
                    }

                    if (j.GetValue("Qn/sectiond/shocks6") != null)
                    {
                        cg.QnSectiondShocks6Main = j.GetValue("Qn/sectiond/shocks6").ToString();
                    }

                    if (j.GetValue("Qn/sectiond/cap1") != null)
                    {
                        cg.QnSectiondCap1 = j.GetValue("Qn/sectiond/cap1").ToString();
                    }

                    if (j.GetValue("Qn/sectiond/shocks1") != null)
                    {
                        cg.QnSectiondShocks1Main = j.GetValue("Qn/sectiond/shocks1").ToString();
                    }

                    if (j.GetValue("Qn/sectiond/cap13") != null)
                    {
                        cg.QnSectiondCap13Main = j.GetValue("Qn/sectiond/cap13").ToString();
                    }

                    if (j.GetValue("Qn/sectione/necpa8") != null)
                    {
                        cg.QnSectioneNecpa8 = j.GetValue("Qn/sectione/necpa8").ToString();
                    }

                    if (j.GetValue("Qn/sectione/necpa9") != null)
                    {
                        cg.QnSectioneNecpa9 = j.GetValue("Qn/sectione/necpa9").ToString();
                    }

                    if (j.GetValue("Qn/sectione/necpa10") != null)
                    {
                        cg.QnSectioneNecpa10 = j.GetValue("Qn/sectione/necpa10").ToString();
                    }

                    if (j.GetValue("Qn/sectione/necpa13") != null)
                    {
                        cg.QnSectioneNecpa13 = j.GetValue("Qn/sectione/necpa13").ToString();
                    }

                    if (j.GetValue("Qn/sectione/necpa15") != null)
                    {
                        cg.QnSectioneNecpa15 = j.GetValue("Qn/sectione/necpa15").ToString();
                    }

                    if (j.GetValue("Qn/sectiond/shocks13") != null)
                    {
                        cg.QnSectiondShocks13Main = j.GetValue("Qn/sectiond/shocks13").ToString();
                    }

                    if (j.GetValue("Qn/sectiond/cap10") != null)
                    {
                        cg.QnSectiondCap10Main = j.GetValue("Qn/sectiond/cap10").ToString();
                    }

                    if (j.GetValue("Qn/sectiond/shocks10") != null)
                    {
                        cg.QnSectiondShocks10Main = j.GetValue("Qn/sectiond/shocks10").ToString();
                    }

                    if (j.GetValue("Qn/sectionc/qn255") != null)
                    {
                        cg.QnSectioncQn255Main = j.GetValue("Qn/sectionc/qn255").ToString();
                    }

                    if (j.GetValue("Qn/sectionc/qn258") != null)
                    {
                        cg.QnSectioncQn258Main = j.GetValue("Qn/sectionc/qn258").ToString();
                    }

                    if (j.GetValue("Qn/sectionc/qn253") != null)
                    {
                        cg.QnSectioncQn253Main = j.GetValue("Qn/sectionc/qn253").ToString();
                    }

                    if (j.GetValue("Qn/sectionc/qn231") != null)
                    {
                        cg.QnSectioncQn231Main = j.GetValue("Qn/sectionc/qn231").ToString();
                    }
                    if (j.GetValue("Qn/sectiond/cap15") != null)
                    {
                        cg.QnSectiondCap15Main = j.GetValue("Qn/sectiond/cap15").ToString();
                    }

                    if (j.GetValue("Qn/sectiond/shocks15") != null)
                    {
                        cg.QnSectiondShocks15Main = j.GetValue("Qn/sectiond/shocks15").ToString();
                    }

                    if (j.GetValue("Qn/sectione/necpa16") != null)
                    {
                        cg.QnSectioneNecpa16 = j.GetValue("Qn/sectione/necpa16").ToString();
                    }

                    if (j.GetValue("Qn/sectiond/shocks19") != null)
                    {
                        cg.QnSectiondShocks19Main = j.GetValue("Qn/sectiond/shocks19").ToString();
                    }

                    if (j.GetValue("Qn/sectiond/cap8") != null)
                    {
                        cg.QnSectiondCap8Main = j.GetValue("Qn/sectiond/cap8").ToString();
                    }

                    if (j.GetValue("Qn/sectiond/cap11") != null)
                    {
                        cg.QnSectiondCap11Main = j.GetValue("Qn/sectiond/cap11").ToString();
                    }

                    if (j.GetValue("Qn/sectiond/shocks8") != null)
                    {
                        cg.QnSectiondShocks8Main = j.GetValue("Qn/sectiond/shocks8").ToString();
                    }

                    if (j.GetValue("Qn/sectiond/shocks11") != null)
                    {
                        cg.QnSectiondShocks11Main = j.GetValue("Qn/sectiond/shocks11").ToString();
                    }

                    if (j.GetValue("Qn/sectione/necpa20") != null)
                    {
                        cg.QnSectioneNecpa20 = j.GetValue("Qn/sectione/necpa20").ToString();
                    }

                    if (j.GetValue("Qn/sectione/other_necpa") != null)
                    {
                        cg.QnSectioneOtherNecpa = j.GetValue("Qn/sectione/other_necpa").ToString();
                    }

                    if (j.GetValue("Qn/sectiond/cap5") != null)
                    {
                        cg.QnSectiondCap5Main = j.GetValue("Qn/sectiond/cap5").ToString();
                    }

                    if (j.GetValue("Qn/sectiond/shocks5") != null)
                    {
                        cg.QnSectiondShocks5Main = j.GetValue("Qn/sectiond/shocks5").ToString();
                    }

                    if (j.GetValue("Qn/sectionc/qn259") != null)
                    {
                        cg.QnSectioncQn259Main = j.GetValue("Qn/sectionc/qn259").ToString();
                    }

                    cg.LastUpdatedAt = DateTime.Now;

                    rms1.Add(cg);
                }
            }
            //this.cgassData = cgassmentdt;
            return rms1;
        }

        public async Task SaveRMS1Data()
        {
            try
            {
                using (var IcanContext = new USAID_ICANContext())
                {
                    var data = GetRMS1Records().ToList();
                    IcanContext.OnaRms1.RemoveRange(IcanContext.OnaRms1.ToList());
                    await IcanContext.SaveChangesAsync();
                    IcanContext.OnaRms1.AddRange(data);
                    await IcanContext.SaveChangesAsync();

                    //send email after update                   
                    EmailModel email = new EmailModel(_context);
                    email.OnaRms1Email();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion RMS1

        #region ukuRegister
        public IEnumerable<OnaukuRegister> GetukuregisterRecords()
        {
            //Load the data from the API
            var model = new object[0];
            var targeturl = string.Format("https://api.ona.io/api/v1/data/433849");
            //Jan - Mar
            HttpMessageHandler handler = new HttpClientHandler()
            {
            };

            var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(targeturl),
                Timeout = new TimeSpan(0, 20, 0)
            };

            List<OnaukuRegister> ukur = new List<OnaukuRegister>();
            httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");

            //This is the key section you were missing    
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes("ican:abt@1can");
            string val = System.Convert.ToBase64String(plainTextBytes);
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + val);

            var method = new HttpMethod("GET");
            List<string> myList = new List<string>();

            JArray jArray = new JArray();
            HttpResponseMessage response = httpClient.GetAsync(targeturl).Result;
            if (response.ReasonPhrase == "Not Found")
            {
                //TempData["Message"] = string.Format("No records found for  {0}-{1}", reportingPeriod.Replace("%20", ""), financialYear.ToString()); ;
            }
            else
            {
                string content = string.Empty;

                using (StreamReader stream = new StreamReader(response.Content.ReadAsStreamAsync().Result, true))
                {
                    content = stream.ReadToEnd();
                }

                jArray = JArray.Parse(content);
                // Strip off the [] from _tags and Notes

                _context.OnaukuRegisterAttendance.RemoveRange(_context.OnaukuRegisterAttendance.ToList());

                foreach (JObject j in jArray)
                {
                    var cg = new OnaukuRegister();
                    var cw = new OnaukuRegisterAttendance();

                    string dvalue = string.Empty;
                    double dnumber;
                    bool success = false;

                    var a = j.GetValue("attendance") as JObject;
                    List<OnaukuRegisterAttendance> ukuattend = new List<OnaukuRegisterAttendance>();

                    cg.Id = Convert.ToInt32(j.GetValue("_id").ToString());

                    if (j["attendance"] != null)
                    {
                        IEnumerable<JToken> data = j["attendance"].Children().ToList();

                        foreach (JObject js in data)
                        {

                            cw = new OnaukuRegisterAttendance();

                            cw.Id = cg.Id;

                            cw.UniqueAttendanceId = Guid.NewGuid().ToString();

                            if (js.GetValue("attendance/age") != null)
                            {
                                cw.AttendanceAge = Convert.ToInt32(js.GetValue("attendance/age").ToString());
                            }

                            if (js.GetValue("attendance/sex") != null)
                            {
                                cw.AttendanceSex = js.GetValue("attendance/sex").ToString(); ;
                            }
                            if (js.GetValue("attendance/class") != null)
                            {
                                cw.AttendanceClass = js.GetValue("attendance/class").ToString();
                            }
                            if (js.GetValue("attendance/fname") != null)
                            {
                                cw.AttendanceFname = js.GetValue("attendance/fname").ToString();
                            }
                            if (js.GetValue("attendance/lname") != null)
                            {
                                cw.AttendanceLname = js.GetValue("attendance/lname").ToString();
                            }
                            if (js.GetValue("attendance/age") != null)
                            {
                                int ddvalue;
                                if (int.TryParse(js.GetValue("attendance/age").ToString(), out ddvalue))
                                {
                                    cw.AttendanceAge = ddvalue;
                                }
                            }
                            cw.LastUpdatedAt = DateTime.Now;
                            ukuattend.Add(cw);
                            //_context.Add(cw);
                            //await _context.SaveChangesAsync();
                        }
                    }
                    _context.SaveChanges();
                    _context.OnaukuRegisterAttendance.AddRange(ukuattend);
                    _context.SaveChanges();

                    if (j.GetValue("clubname") != null)
                    {
                        cg.Clubname = j.GetValue("clubname").ToString();
                    }

                    if (j.GetValue("schoolid") != null)
                    {
                        cg.Schoolid = j.GetValue("schoolid").ToString();
                    }

                    if (j.GetValue("clubid") != null)
                    {
                        cg.Clubid = j.GetValue("clubid").ToString();
                    }

                    if (j.GetValue("comments") != null)
                    {
                        cg.Comments = j.GetValue("comments").ToString();
                    }

                    if (j.GetValue("_gps_latitude") != null)
                    {
                        cg.GpsLatitude = Convert.ToDouble(j.GetValue("_gps/latitude").ToString());
                    }

                    if (j.GetValue("_gps_longitude") != null)
                    {
                        cg.GpsLongitude = Convert.ToDouble(j.GetValue("_gps_longitude").ToString());
                    }

                    if (j.GetValue("_gps_altitude") != null)
                    {
                        cg.GpsAltitude = Convert.ToDouble(j.GetValue("_gps_altitude").ToString());
                    }

                    if (j.GetValue("_gps_precision") != null)
                    {
                        cg.GpsPrecision = Convert.ToDouble(j.GetValue("_gps_precision").ToString());
                    }

                    if (j.GetValue("_index") != null)
                    {
                        cg.Index = Convert.ToDouble(j.GetValue("_index").ToString());
                    }

                    if (j.GetValue("_parent_index") != null)
                    {
                        cg.ParentIndex = Convert.ToDouble(j.GetValue("_parent_index").ToString());
                    }

                    cg.Id = Convert.ToInt32(j.GetValue("_id").ToString());

                    if (j.GetValue("end") != null)
                    {
                        cg.Endd = j.GetValue("end").ToString();
                    }

                    if (j.GetValue("gps") != null)
                    {
                        cg.Gps = j.GetValue("gps").ToString();
                    }

                    if (j.GetValue("loc") != null)
                    {
                        cg.Loc = j.GetValue("loc").ToString();
                    }

                    if (j.GetValue("ack2") != null)
                    {
                        cg.Ack2 = j.GetValue("ack2").ToString();
                    }

                    if (j.GetValue("term") != null)
                    {
                        cg.Term = j.GetValue("term").ToString();
                    }

                    if (j.GetValue("_uuid") != null)
                    {
                        cg.Uuid = j.GetValue("_uuid").ToString();
                    }

                    if (j.GetValue("start") != null)
                    {
                        cg.Start = j.GetValue("start").ToString();
                    }

                    if (j.GetValue("patron") != null)
                    {
                        cg.Patron = j.GetValue("patron").ToString();
                    }

                    if (j.GetValue("school") != null)
                    {
                        cg.School = j.GetValue("school").ToString();
                    }

                    if (j.GetValue("_version") != null)
                    {
                        cg.Version = j.GetValue("_version").ToString();
                    }

                    //cg.comments = j.GetValue("comments").ToString();

                    if (j.GetValue("deviceid") != null)
                    {
                        cg.Deviceid = j.GetValue("deviceid").ToString();
                    }

                    cg.Duration = Convert.ToDouble(j.GetValue("_duration").ToString());

                    cg.XformId = Convert.ToInt32(j.GetValue("_xform_id").ToString());

                    if (j.GetValue("fieldteam") != null)
                    {
                        cg.Fieldteam = j.GetValue("fieldteam").ToString();
                    }

                    if (j.GetValue("loc_parish") != null)
                    {
                        cg.LocParish = j.GetValue("loc_parish").ToString();
                    }

                    if (j.GetValue("loc_region") != null)
                    {
                        cg.LocRegion = j.GetValue("loc_region").ToString();
                    }


                    if (j.GetValue("loc_district") != null)
                    {
                        cg.LocDistrict = j.GetValue("loc_district").ToString();
                    }
                    if (j.GetValue("_submitted_by") != null)
                    {
                        cg.SubmittedBy = j.GetValue("_submitted_by").ToString();
                    }

                    if (j.GetValue("activity_date") != null)
                    {
                        CultureInfo enUS = new CultureInfo("en-US");
                        string dateString;
                        DateTime dateValue;
                        // Use custom formats with M and MM.
                        dateString = j.GetValue("activity_date").ToString();
                        //if (DateTime.TryParseExact(dateString, "M/dd/yyyy hh:mm", enUS,
                        if (DateTime.TryParse(dateString, out dateValue))
                        {
                            cg.ActivityDate = dateValue;
                        }
                    }

                    if (j.GetValue("loc_subcounty") != null)
                    {
                        cg.LocSubcounty = j.GetValue("loc_subcounty").ToString();
                    }

                    if (j.GetValue("meta/instanceID") != null)
                    {
                        cg.MetaInstanceId = j.GetValue("meta/instanceID").ToString();
                    }

                    if (j.GetValue("_submission_time") != null)
                    {
                        CultureInfo enUS = new CultureInfo("en-US");
                        string dateString;
                        DateTime dateValue;
                        // Use custom formats with M and MM.
                        dateString = j.GetValue("_submission_time").ToString();
                        //if (DateTime.TryParseExact(dateString, "M/dd/yyyy hh:mm", enUS,
                        if (DateTime.TryParse(dateString, out dateValue))
                        {
                            cg.SubmissionTime = dateValue;
                        }

                        cg.LastUpdatedAt = DateTime.Now;
                    }

                    ukur.Add(cg);
                }
            }
            //this.ukuregData = ukur;
            return ukur;
        }

        public async Task SaveukuregData()
        {
            try
            {
                using (var IcanContext = new USAID_ICANContext())
                {
                    var data = GetukuregisterRecords().ToList();
                    IcanContext.OnaukuRegister.RemoveRange(IcanContext.OnaukuRegister.ToList());
                    await IcanContext.SaveChangesAsync();
                    IcanContext.OnaukuRegister.AddRange(data);
                    await IcanContext.SaveChangesAsync();

                    //send email after update                   
                    EmailModel email = new EmailModel(_context);
                    email.OnaukuRegisterEmail();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion ukuRegister

        #region Update_Livelihood_groupData
        public IEnumerable<OnaUpdateLivelihoodGroupData> GetUpdateLvhdgrpDataRecords()
        {
            //Load the data from the API
            var model = new object[0];
            var targeturllast = string.Format("https://api.ona.io/api/v1/data/512267");
            List<OnaUpdateLivelihoodGroupData> uplivegpdata = new List<OnaUpdateLivelihoodGroupData>();
            //Here
            HttpMessageHandler handlerlast = new HttpClientHandler()
            {
            };

            var httpClientlast = new HttpClient(handlerlast)
            {
                BaseAddress = new Uri(targeturllast),
                Timeout = new TimeSpan(0, 20, 0)
            };

            httpClientlast.DefaultRequestHeaders.Add("ContentType", "application/json");

            //This is the key section you were missing    
            var plainTextByteslast = System.Text.Encoding.UTF8.GetBytes("ican:abt@1can");
            string vallast = System.Convert.ToBase64String(plainTextByteslast);
            httpClientlast.DefaultRequestHeaders.Add("Authorization", "Basic " + vallast);

            var methodlast = new HttpMethod("GET");
            List<string> myListlast = new List<string>();

            JArray jArraylast = new JArray();
            HttpResponseMessage responselast = httpClientlast.GetAsync(targeturllast).Result;

            var alink = responselast.Headers.FirstOrDefault(o => o.Key == "Link");
            var pages = alink.Value.FirstOrDefault();
            var page_1 = pages.Split(",");
            string lastpage = null;
            foreach (var nw in page_1)
            {
                if (nw.Contains("last"))
                {
                    var ax = nw.Split(";");
                    lastpage = ax[0].Replace('<', ' ').Replace('>', ' ').Trim();
                }
            }

            int i = 1;

            while (true)
            {
                var targeturl = "https://api.ona.io/api/v1/data/512267" + "?page=" + i + "&page_size=10000";

                HttpMessageHandler handler = new HttpClientHandler()
                {
                };

                var httpClient = new HttpClient(handler)
                {
                    BaseAddress = new Uri(targeturl),
                    Timeout = new TimeSpan(0, 20, 0)
                };

                //List<OnaCommunitygroupSummary2021> commgrpsummver5 = new List<OnaCommunitygroupSummary2021>();
                httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");

                //This is the key section you were missing    
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes("ican:abt@1can");
                string val = System.Convert.ToBase64String(plainTextBytes);
                httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + val);

                var method = new HttpMethod("GET");
                List<string> myList = new List<string>();

                JArray jArray = new JArray();
                HttpResponseMessage response = httpClient.GetAsync(targeturl).Result;

                if (response.ReasonPhrase == "Not Found")
                {
                    //TempData["Message"] = string.Format("No records found for  {0}-{1}", reportingPeriod.Replace("%20", ""), financialYear.ToString()); ;
                }
                else
                {
                    string content = string.Empty;

                    using (StreamReader stream = new StreamReader(response.Content.ReadAsStreamAsync().Result, true))
                    {
                        content = stream.ReadToEnd();
                    }

                    jArray = JArray.Parse(content);

                    foreach (JObject j in jArray)
                    {
                        var cg = new OnaUpdateLivelihoodGroupData();

                        string dvalue = string.Empty;
                        double dnumber;
                        bool success = false;

                        var a = j.GetValue("_geolocation") as object;
                        var c = a.ToString().Replace("\r", "").Replace("\n", "").Replace("[", "").Replace("]", "").Trim();
                        var b = c.Split(',');
                        if (b.Length == 2)
                        {
                            double d = 0;
                            if (double.TryParse(b[0], out d))
                            {
                                cg.Latitude = d;
                            }
                            if (double.TryParse(b[1], out d))
                            {
                                cg.Longitude = d;
                            }
                        }

                        if (j.GetValue("fo") != null)
                        {
                            cg.Fo = j.GetValue("fo").ToString();
                        }

                        cg.Id = Convert.ToInt32(j.GetValue("_id").ToString());

                        if (j.GetValue("end") != null)
                        {
                            cg.Endd = j.GetValue("end").ToString();
                        }

                        if (j.GetValue("ack2") != null)
                        {
                            cg.Ack2 = j.GetValue("ack2").ToString();
                        }

                        if (j.GetValue("_uuid") != null)
                        {
                            cg.Uuid = j.GetValue("_uuid").ToString();
                        }

                        if (j.GetValue("fname") != null)
                        {
                            cg.Fname = j.GetValue("fname").ToString();
                        }

                        if (j.GetValue("image") != null)
                        {
                            cg.Image = j.GetValue("image").ToString();
                        }

                        if (j.GetValue("maleA") != null)
                        {
                            cg.MaleA = Convert.ToDouble(j.GetValue("maleA").ToString());
                        }

                        if (j.GetValue("maleY") != null)
                        {
                            cg.MaleY = Convert.ToDouble(j.GetValue("maleY").ToString());
                        }

                        if (j.GetValue("start") != null)
                        {
                            cg.Start = j.GetValue("start").ToString();
                        }

                        if (j.GetValue("saving") != null)
                        {
                            cg.Saving = j.GetValue("saving").ToString();
                        }

                        if (j.GetValue("contact") != null)
                        {
                            cg.Contact = j.GetValue("contact").ToString();
                        }

                        if (j.GetValue("femaleA") != null)
                        {
                            cg.FemaleA = Convert.ToDouble(j.GetValue("femaleA").ToString());
                        }

                        if (j.GetValue("femaleY") != null)
                        {
                            cg.FemaleY = Convert.ToDouble(j.GetValue("femaleY").ToString());
                        }

                        if (j.GetValue("surname") != null)
                        {
                            cg.Surname = j.GetValue("surname").ToString();
                        }

                        if (j.GetValue("village") != null)
                        {
                            cg.Village = j.GetValue("village").ToString();
                        }

                        if (j.GetValue("_version") != null)
                        {
                            cg.Version = j.GetValue("_version").ToString();
                        }

                        if (j.GetValue("deviceid") != null)
                        {
                            cg.Deviceid = j.GetValue("deviceid").ToString();
                        }

                        if (j.GetValue("district") != null)
                        {
                            cg.District = j.GetValue("district").ToString();
                        }

                        cg.Duration = Convert.ToDouble(j.GetValue("_duration").ToString());

                        cg.XformId = Convert.ToInt32(j.GetValue("_xform_id").ToString());

                        if (j.GetValue("subcounty") != null)
                        {
                            cg.Subcounty = j.GetValue("subcounty").ToString();
                        }

                        if (j.GetValue("_submitted_by") != null)
                        {
                            cg.SubmittedBy = j.GetValue("_submitted_by").ToString();
                        }

                        if (j.GetValue("meta/instanceID") != null)
                        {
                            cg.MetaInstanceId = j.GetValue("meta/instanceID").ToString();
                        }

                        if (j.GetValue("_submission_time") != null)
                        {
                            CultureInfo enUS = new CultureInfo("en-US");
                            string dateString;
                            DateTime dateValue;
                            // Use custom formats with M and MM.
                            dateString = j.GetValue("_submission_time").ToString();
                            //if (DateTime.TryParseExact(dateString, "M/dd/yyyy hh:mm", enUS,
                            if (DateTime.TryParse(dateString, out dateValue))
                            {
                                cg.SubmissionTime = dateValue;
                            }
                        }

                        if (j.GetValue("location/groupid") != null)
                        {
                            cg.LocationGroupid = j.GetValue("location/groupid").ToString();
                        }

                        if (j.GetValue("location/groupname") != null)
                        {
                            cg.LocationGroupname = j.GetValue("location/groupname").ToString();
                        }


                        if (j.GetValue("contact1") != null)
                        {
                            cg.Contact1 = j.GetValue("contact1").ToString();
                        }


                        if (j.GetValue("contact2") != null)
                        {
                            cg.Contact2 = j.GetValue("contact2").ToString();
                        }

                        if (j.GetValue("comments") != null)
                        {
                            cg.Comments = j.GetValue("comments").ToString();
                        }

                        cg.LastUpdatedAt = DateTime.Now;

                        uplivegpdata.Add(cg);
                    }
                }
                i++;

                if (targeturl == lastpage)
                    break;
            }

            return uplivegpdata;
        }

        public async Task SaveUpdlivgroupData()
        {
            try
            {
                using (var IcanContext = new USAID_ICANContext())
                {
                    var data = GetUpdateLvhdgrpDataRecords().ToList();
                    IcanContext.OnaUpdateLivelihoodGroupData.RemoveRange(IcanContext.OnaUpdateLivelihoodGroupData.ToList());
                    await IcanContext.SaveChangesAsync();
                    IcanContext.OnaUpdateLivelihoodGroupData.AddRange(data);
                    await IcanContext.SaveChangesAsync();

                    //send email after update                   
                    EmailModel email = new EmailModel(_context);
                    email.OnaUpdateLivelihoodGroupDataEmail();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Update_Livelihood_groupData --here

        #region Update_MIYCAN_groupData
        public IEnumerable<OnaUpdateMiycanGroupData> GetUpdatemiycangrpDataRecords()
        {
            //Load the data from the API
            var model = new object[0];
            var targeturllast = string.Format("https://api.ona.io/api/v1/data/512272");
            List<OnaUpdateMiycanGroupData> upmiycangpdata = new List<OnaUpdateMiycanGroupData>();
            //Here
            HttpMessageHandler handlerlast = new HttpClientHandler()
            {
            };

            var httpClientlast = new HttpClient(handlerlast)
            {
                BaseAddress = new Uri(targeturllast),
                Timeout = new TimeSpan(0, 20, 0)
            };

            httpClientlast.DefaultRequestHeaders.Add("ContentType", "application/json");

            //This is the key section you were missing    
            var plainTextByteslast = System.Text.Encoding.UTF8.GetBytes("ican:abt@1can");
            string vallast = System.Convert.ToBase64String(plainTextByteslast);
            httpClientlast.DefaultRequestHeaders.Add("Authorization", "Basic " + vallast);

            var methodlast = new HttpMethod("GET");
            List<string> myListlast = new List<string>();

            JArray jArraylast = new JArray();
            HttpResponseMessage responselast = httpClientlast.GetAsync(targeturllast).Result;

            var alink = responselast.Headers.FirstOrDefault(o => o.Key == "Link");
            var pages = alink.Value.FirstOrDefault();
            var page_1 = pages.Split(",");
            string lastpage = null;
            foreach (var nw in page_1)
            {
                if (nw.Contains("last"))
                {
                    var ax = nw.Split(";");
                    lastpage = ax[0].Replace('<', ' ').Replace('>', ' ').Trim();
                }
            }

            int i = 1;

            while (true)
            {
                var targeturl = "https://api.ona.io/api/v1/data/512272" + "?page=" + i + "&page_size=10000";

                HttpMessageHandler handler = new HttpClientHandler()
                {
                };

                var httpClient = new HttpClient(handler)
                {
                    BaseAddress = new Uri(targeturl),
                    Timeout = new TimeSpan(0, 20, 0)
                };

                //List<OnaCommunitygroupSummary2021> commgrpsummver5 = new List<OnaCommunitygroupSummary2021>();
                httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");

                //This is the key section you were missing    
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes("ican:abt@1can");
                string val = System.Convert.ToBase64String(plainTextBytes);
                httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + val);

                var method = new HttpMethod("GET");
                List<string> myList = new List<string>();

                JArray jArray = new JArray();
                HttpResponseMessage response = httpClient.GetAsync(targeturl).Result;

                if (response.ReasonPhrase == "Not Found")
                {
                    //TempData["Message"] = string.Format("No records found for  {0}-{1}", reportingPeriod.Replace("%20", ""), financialYear.ToString()); ;
                }
                else
                {
                    string content = string.Empty;

                    using (StreamReader stream = new StreamReader(response.Content.ReadAsStreamAsync().Result, true))
                    {
                        content = stream.ReadToEnd();
                    }

                    jArray = JArray.Parse(content);

                    foreach (JObject j in jArray)
                    {
                        var cg = new OnaUpdateMiycanGroupData();

                        string dvalue = string.Empty;
                        double dnumber;
                        bool success = false;

                        var a = j.GetValue("_geolocation") as object;
                        var c = a.ToString().Replace("\r", "").Replace("\n", "").Replace("[", "").Replace("]", "").Trim();
                        var b = c.Split(',');
                        if (b.Length == 2)
                        {
                            double d = 0;
                            if (double.TryParse(b[0], out d))
                            {
                                cg.Latitude = d;
                            }
                            if (double.TryParse(b[1], out d))
                            {
                                cg.Longitude = d;
                            }
                        }

                        if (j.GetValue("fo") != null)
                        {
                            cg.Fo = j.GetValue("fo").ToString();
                        }

                        cg.Id = Convert.ToInt32(j.GetValue("_id").ToString());

                        if (j.GetValue("end") != null)
                        {
                            cg.Endd = j.GetValue("end").ToString();
                        }

                        if (j.GetValue("l19") != null)
                        {
                            cg.L19 = Convert.ToDouble(j.GetValue("l19").ToString());
                        }

                        if (j.GetValue("p19") != null)
                        {
                            cg.P19 = Convert.ToDouble(j.GetValue("p19").ToString());
                        }

                        if (j.GetValue("ack2") != null)
                        {
                            cg.Ack2 = j.GetValue("ack2").ToString();
                        }

                        if (j.GetValue("lA19") != null)
                        {
                            cg.LA19 = Convert.ToDouble(j.GetValue("lA19").ToString());
                        }
                        if (j.GetValue("pA19") != null)
                        {
                            cg.PA19 = Convert.ToDouble(j.GetValue("pA19").ToString());
                        }

                        if (j.GetValue("_uuid") != null)
                        {
                            cg.Uuid = j.GetValue("_uuid").ToString();
                        }

                        if (j.GetValue("fname") != null)
                        {
                            cg.Fname = j.GetValue("fname").ToString();
                        }

                        if (j.GetValue("image") != null)
                        {
                            cg.Image = j.GetValue("image").ToString();
                        }

                        if (j.GetValue("start") != null)
                        {
                            cg.Start = j.GetValue("start").ToString();
                        }

                        if (j.GetValue("saving") != null)
                        {
                            cg.Saving = j.GetValue("saving").ToString();
                        }


                        if (j.GetValue("contact") != null)
                        {
                            cg.Contact = j.GetValue("contact").ToString();
                        }

                        if (j.GetValue("surname") != null)
                        {
                            cg.Surname = j.GetValue("surname").ToString();
                        }

                        if (j.GetValue("village") != null)
                        {
                            cg.Village = j.GetValue("village").ToString();
                        }

                        if (j.GetValue("_version") != null)
                        {
                            cg.Version = j.GetValue("_version").ToString();
                        }

                        if (j.GetValue("deviceid") != null)
                        {
                            cg.Deviceid = j.GetValue("deviceid").ToString();
                        }

                        if (j.GetValue("oth/o19f") != null)
                        {
                            cg.OthO19f = Convert.ToDouble(j.GetValue("oth/o19f").ToString());
                        }

                        if (j.GetValue("oth/o19m") != null)
                        {
                            cg.OthO19m = Convert.ToDouble(j.GetValue("oth/o19m").ToString());
                        }

                        cg.Duration = Convert.ToDouble(j.GetValue("_duration").ToString());

                        cg.XformId = Convert.ToInt32(j.GetValue("_xform_id").ToString());

                        if (j.GetValue("oth/oA19f") != null)
                        {
                            cg.OthOA19f = Convert.ToInt32(j.GetValue("oth/oA19f").ToString());
                        }

                        if (j.GetValue("oth/oA19m") != null)
                        {
                            cg.OthOA19m = Convert.ToInt32(j.GetValue("oth/oA19m").ToString());
                        }

                        if (j.GetValue("subcounty") != null)
                        {
                            cg.Subcounty = j.GetValue("subcounty").ToString();
                        }


                        if (j.GetValue("_submitted_by") != null)
                        {
                            cg.SubmittedBy = j.GetValue("_submitted_by").ToString();
                        }

                        if (j.GetValue("meta/instanceID") != null)
                        {
                            cg.MetaInstanceId = j.GetValue("meta/instanceID").ToString();
                        }

                        if (j.GetValue("_submission_time") != null)
                        {
                            CultureInfo enUS = new CultureInfo("en-US");
                            string dateString;
                            DateTime dateValue;
                            // Use custom formats with M and MM.
                            dateString = j.GetValue("_submission_time").ToString();
                            //if (DateTime.TryParseExact(dateString, "M/dd/yyyy hh:mm", enUS,
                            if (DateTime.TryParse(dateString, out dateValue))
                            {
                                cg.SubmissionTime = dateValue;
                            }
                        }

                        if (j.GetValue("location/groupid") != null)
                        {
                            cg.LocationGroupid = j.GetValue("location/groupid").ToString();
                        }

                        if (j.GetValue("location/groupname") != null)
                        {
                            cg.LocationGroupname = j.GetValue("location/groupname").ToString();
                        }


                        if (j.GetValue("contact1") != null)
                        {
                            cg.Contact1 = j.GetValue("contact1").ToString();
                        }

                        if (j.GetValue("contact2") != null)
                        {
                            cg.Contact2 = j.GetValue("contact2").ToString();
                        }

                        if (j.GetValue("comments") != null)
                        {
                            cg.Comments = j.GetValue("comments").ToString();
                        }

                        cg.LastUpdatedAt = DateTime.Now;

                        upmiycangpdata.Add(cg);
                    }
                }
                i++;

                if (targeturl == lastpage)
                    break;
            }

            return upmiycangpdata;
        }

        public async Task SavemiycangroupData()
        {
            try
            {
                using (var IcanContext = new USAID_ICANContext())
                {
                    var data = GetUpdatemiycangrpDataRecords().ToList();
                    IcanContext.OnaUpdateMiycanGroupData.RemoveRange(IcanContext.OnaUpdateMiycanGroupData.ToList());
                    await IcanContext.SaveChangesAsync();
                    IcanContext.OnaUpdateMiycanGroupData.AddRange(data);
                    await IcanContext.SaveChangesAsync();

                    //send email after update                   
                    EmailModel email = new EmailModel(_context);
                    email.OnaUpdateMiycanGroupDataEmail();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Update_MIYCAN_groupData

        #region communityteamregister
        public IEnumerable<OnaCommunityTeamRegister> GetCommTeamRegRecords()
        {
            //Load the data from the API
            var model = new object[0];
            var targeturl = string.Format("https://api.ona.io/api/v1/data/571385");
            //Jan - Mar
            HttpMessageHandler handler = new HttpClientHandler()
            {
            };
            var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(targeturl),
                Timeout = new TimeSpan(0, 20, 0)
            };
            List<OnaCommunityTeamRegister> comdatavar = new List<OnaCommunityTeamRegister>();
            httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");

            //This is the key section you were missing    
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes("ican:abt@1can");
            string val = System.Convert.ToBase64String(plainTextBytes);
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + val);

            var method = new HttpMethod("GET");
            List<string> myList = new List<string>();

            JArray jArray = new JArray();
            HttpResponseMessage response = httpClient.GetAsync(targeturl).Result;
            if (response.ReasonPhrase == "Not Found")
            {
                //TempData["Message"] = string.Format("No records found for  {0}-{1}", reportingPeriod.Replace("%20", ""), financialYear.ToString()); ;
            }
            else
            {
                string content = string.Empty;
                using (StreamReader stream = new StreamReader(response.Content.ReadAsStreamAsync().Result, true))
                {
                    content = stream.ReadToEnd();
                }
                jArray = JArray.Parse(content);
                // Strip off the [] from _tags and Notes
                _context.OnaCommunityTeamRegisterMemberDetails.RemoveRange(_context.OnaCommunityTeamRegisterMemberDetails.ToList());
                foreach (JObject j in jArray)
                {
                    var cg = new OnaCommunityTeamRegister();
                    var cw = new OnaCommunityTeamRegisterMemberDetails();

                    string dvalue = string.Empty;
                    double dnumber;
                    bool success = false;

                    var a = j.GetValue("MemberDetails") as JObject;
                    List<OnaCommunityTeamRegisterMemberDetails> memdetdatavar = new List<OnaCommunityTeamRegisterMemberDetails>();

                    cg.Id = Convert.ToInt32(j.GetValue("_id").ToString());

                    if (j["MemberDetails"] != null)
                    {
                        IEnumerable<JToken> data = j["MemberDetails"].Children().ToList();

                        foreach (JObject js in data)
                        {

                            cw = new OnaCommunityTeamRegisterMemberDetails();
                            cw.Id = cg.Id;
                            cw.MemberDetailsId = Guid.NewGuid().ToString();
                            if (js.GetValue("MemberDetails/Age") != null)
                            {
                                double ddvalue;
                                if (Double.TryParse(js.GetValue("MemberDetails/Age").ToString(), out ddvalue))
                                {
                                    cw.MemberDetailsAge = ddvalue;
                                }
                            }

                            if (js.GetValue("MemberDetails/Sex") != null)
                            {
                                cw.MemberDetailsSex = Convert.ToInt32(js.GetValue("MemberDetails/Sex").ToString());
                            }
                            if (js.GetValue("MemberDetails/Name") != null)
                            {
                                cw.MemberDetailsName = js.GetValue("MemberDetails/Name").ToString();
                            }

                            if (js.GetValue("MemberDetails/Cadre") != null)
                            {
                                cw.MemberDetailsCadre = js.GetValue("MemberDetails/Cadre").ToString();
                            }

                            if (js.GetValue("MemberDetails/SerialNo") != null)
                            {
                                cw.MemberDetailsSerialNo = js.GetValue("MemberDetails/SerialNo").ToString();
                            }

                            if (js.GetValue("MemberDetails/UniqueID") != null)
                            {
                                cw.MemberDetailsUniqueId = js.GetValue("MemberDetails/UniqueID").ToString();
                            }

                            if (js.GetValue("MemberDetails/Member_ID") != null)
                            {
                                cw.MemberDetailsMemberId = js.GetValue("MemberDetails/Member_ID").ToString();
                            }

                            if (js.GetValue("MemberDetails/TelNumber") != null)
                            {
                                cw.MemberDetailsTelNumber = js.GetValue("MemberDetails/TelNumber").ToString();
                            }

                            if (js.GetValue("MemberDetails/RegesteredVHT") != null)
                            {
                                cw.MemberDetailsRegesteredVht = js.GetValue("MemberDetails/RegesteredVHT").ToString();
                            }

                            cw.LastUpdatedAt = DateTime.Now;
                            memdetdatavar.Add(cw);
                        }
                    }
                    _context.SaveChanges();
                    _context.OnaCommunityTeamRegisterMemberDetails.AddRange(memdetdatavar);
                    _context.SaveChanges();

                    if (j.GetValue("end") != null)
                    {
                        cg.Endd = j.GetValue("end").ToString();
                    }
                    if (j.GetValue("ack2") != null)
                    {
                        cg.Ack2 = j.GetValue("ack2").ToString();
                    }
                    if (j.GetValue("_uuid") != null)
                    {
                        cg.Uuid = j.GetValue("_uuid").ToString();
                    }
                    if (j.GetValue("dcode") != null)
                    {
                        cg.Dcode = j.GetValue("dcode").ToString();
                    }
                    if (j.GetValue("start") != null)
                    {
                        cg.Start = j.GetValue("start").ToString();
                    }
                    if (j.GetValue("District") != null)
                    {
                        cg.District = j.GetValue("District").ToString();
                    }
                    if (j.GetValue("subc") != null)
                    {
                        cg.SubCounty = j.GetValue("subc").ToString();
                    }
                    if (j.GetValue("Activity_Date") != null)
                    {
                        CultureInfo enUS = new CultureInfo("en-US");
                        string dateString;
                        DateTime dateValue;
                        // Use custom formats with M and MM.
                        dateString = j.GetValue("Activity_Date").ToString();
                        //if (DateTime.TryParseExact(dateString, "M/dd/yyyy hh:mm", enUS,
                        if (DateTime.TryParse(dateString, out dateValue))
                        {
                            cg.ActivityDate = dateValue;// Convert.ToDateTime(j.GetValue("_submission_time").ToString());
                        }
                    }
                    if (j.GetValue("_submitted_by") != null)
                    {
                        cg.SubmittedBy = j.GetValue("_submitted_by").ToString();
                    }
                    if (j.GetValue("_submission_time") != null)
                    {
                        CultureInfo enUS = new CultureInfo("en-US");
                        string dateString;
                        DateTime dateValue;
                        // Use custom formats with M and MM.
                        dateString = j.GetValue("_submission_time").ToString();
                        //if (DateTime.TryParseExact(dateString, "M/dd/yyyy hh:mm", enUS,
                        if (DateTime.TryParse(dateString, out dateValue))
                        {
                            cg.SubmissionTime = dateValue;// Convert.ToDateTime(j.GetValue("_submission_time").ToString());
                        }
                    }
                    if (j.GetValue("Verification/Vdate") != null)
                    {
                        CultureInfo enUS = new CultureInfo("en-US");
                        string dateString;
                        DateTime dateValue;
                        // Use custom formats with M and MM.
                        dateString = j.GetValue("Verification/Vdate").ToString();
                        //if (DateTime.TryParseExact(dateString, "M/dd/yyyy hh:mm", enUS,
                        if (DateTime.TryParse(dateString, out dateValue))
                        {
                            cg.VerificationVdate = dateValue;// Convert.ToDateTime(j.GetValue("_submission_time").ToString());
                        }
                    }
                    if (j.GetValue("Verification/Tittle") != null)
                    {
                        cg.VerificationTittle = j.GetValue("Verification/Tittle").ToString();
                    }
                    if (j.GetValue("Verification/Verifiedby") != null)
                    {
                        cg.VerificationVerifiedby = j.GetValue("Verification/Verifiedby").ToString();
                    }
                    cg.LastUpdatedAt = DateTime.Now;
                    comdatavar.Add(cg);
                }
            }
            return comdatavar;
        }

        public async Task SavecommteamregData()
        {
            try
            {
                using (var IcanContext = new USAID_ICANContext())
                {
                    var data = GetCommTeamRegRecords().ToList();
                    IcanContext.OnaCommunityTeamRegister.RemoveRange(IcanContext.OnaCommunityTeamRegister.ToList());
                    await IcanContext.SaveChangesAsync();
                    IcanContext.OnaCommunityTeamRegister.AddRange(data);
                    await IcanContext.SaveChangesAsync();

                    //send email after update                   
                    EmailModel email = new EmailModel(_context);
                    email.OnaCommunityTeamRegisterEmail();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion communityteamregister

        #region DistrictMonthlySummary
        public IEnumerable<OnaDistrictMonthlySummary> GetDisMonSum()
        {
            //Load the data from the API
            var model = new object[0];
            var targeturl = string.Format("https://api.ona.io/api/v1/data/571021");
            //Jan - Mar
            HttpMessageHandler handler = new HttpClientHandler()
            {
            };
            var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(targeturl),
                Timeout = new TimeSpan(0, 20, 0)
            };

            List<OnaDistrictMonthlySummary> dismonsum = new List<OnaDistrictMonthlySummary>();

            httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");

            //This is the key section you were missing    
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes("ican:abt@1can");
            string val = System.Convert.ToBase64String(plainTextBytes);
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + val);

            var method = new HttpMethod("GET");
            List<string> myList = new List<string>();

            JArray jArray = new JArray();
            HttpResponseMessage response = httpClient.GetAsync(targeturl).Result;
            if (response.ReasonPhrase == "Not Found")
            {
                //TempData["Message"] = string.Format("No records found for  {0}-{1}", reportingPeriod.Replace("%20", ""), financialYear.ToString()); ;
            }
            else
            {
                string content = string.Empty;

                using (StreamReader stream = new StreamReader(response.Content.ReadAsStreamAsync().Result, true))
                {
                    content = stream.ReadToEnd();
                }

                jArray = JArray.Parse(content);
                // Strip off the [] from _tags and Notes
                _context.OnaDistrictMonthlySummary.RemoveRange(_context.OnaDistrictMonthlySummary.ToList());
                _context.OnaDistrictMonthlySummarySchools.RemoveRange(_context.OnaDistrictMonthlySummarySchools.ToList());
                _context.OnaDistrictMonthlySummaryVdmpvillages.RemoveRange(_context.OnaDistrictMonthlySummaryVdmpvillages.ToList());
                _context.OnaDistrictMonthlySummaryNrmpparishes.RemoveRange(_context.OnaDistrictMonthlySummaryNrmpparishes.ToList());
                _context.OnaDistrictMonthlySummaryNrmpsubcounty.RemoveRange(_context.OnaDistrictMonthlySummaryNrmpsubcounty.ToList());
                _context.OnaDistrictMonthlySummaryNrmpvillages.RemoveRange(_context.OnaDistrictMonthlySummaryNrmpvillages.ToList());

                foreach (JObject j in jArray)
                {
                    var cg = new OnaDistrictMonthlySummary();
                    var cw = new OnaDistrictMonthlySummarySchools();
                    var cx = new OnaDistrictMonthlySummaryVdmpvillages();
                    var cy = new OnaDistrictMonthlySummaryNrmpparishes();
                    var cz = new OnaDistrictMonthlySummaryNrmpsubcounty();
                    var ct = new OnaDistrictMonthlySummaryNrmpvillages();

                    string dvalue = string.Empty;
                    double dnumber;
                    bool success = false;
                    JArray jxArray = new JArray();
                    var a = j.GetValue("Schools") as JObject;
                    var b = j.GetValue("VDMPVillages") as JObject;
                    var c = j.GetValue("parishes") as JObject;
                    var d = j.GetValue("Sub-County") as JObject;

                    List<OnaDistrictMonthlySummarySchools> monsumschools = new List<OnaDistrictMonthlySummarySchools>();
                    List<OnaDistrictMonthlySummaryVdmpvillages> vdmpvillage = new List<OnaDistrictMonthlySummaryVdmpvillages>();
                    List<OnaDistrictMonthlySummaryNrmpvillages> nrmpvillage = new List<OnaDistrictMonthlySummaryNrmpvillages>();
                    List<OnaDistrictMonthlySummaryNrmpsubcounty> nrmpsubcounty = new List<OnaDistrictMonthlySummaryNrmpsubcounty>();
                    List<OnaDistrictMonthlySummaryNrmpparishes> nrmpparishes = new List<OnaDistrictMonthlySummaryNrmpparishes>();

                    cg.Id = Convert.ToInt32(j.GetValue("_id").ToString());
                    //Schools
                    if (j["Schools"] != null)
                    {
                        IEnumerable<JToken> data = j["Schools"].Children().ToList();
                        foreach (JObject js in data)
                        {
                            cw = new OnaDistrictMonthlySummarySchools();
                            cw.UniqueSchoolId = Guid.NewGuid().ToString();
                            cw.Id = cg.Id;
                            if (js.GetValue("Schools/school") != null)
                            {
                                cw.SchoolsSchool = js.GetValue("Schools/school").ToString();
                            }
                            if (js.GetValue("Schools/schoolCount") != null)
                            {
                                cw.SchoolsSchoolCount = js.GetValue("Schools/schoolCount").ToString();
                            }

                            if (js.GetValue("Schools/SchoolSub-County") != null)
                            {
                                cw.SchoolsSchoolSubCounty = js.GetValue("Schools/SchoolSub-County").ToString();
                            }
                            cw.LastUpdatedAt = DateTime.Now;
                            monsumschools.Add(cw);
                        }
                        _context.SaveChanges();
                        _context.OnaDistrictMonthlySummarySchools.AddRange(monsumschools);
                        _context.SaveChanges();
                    }
                    //VDMPVillages
                    if (j["VDMPVillages"] != null)
                    {
                        IEnumerable<JToken> data = j["VDMPVillages"].Children().ToList();
                        foreach (JObject js in data)
                        {
                            cx = new OnaDistrictMonthlySummaryVdmpvillages();
                            cx.UniqueVdpmid = Guid.NewGuid().ToString(); ;
                            cx.Id = cg.Id;
                            if (js.GetValue("VDMPVillages/VDMPCount") != null)
                            {
                                cx.VdmpvillagesVdmpcount = js.GetValue("VDMPVillages/VDMPCount").ToString();
                            }
                            if (js.GetValue("VDMPVillages/DMPVillages") != null)
                            {
                                cx.VdmpvillagesDmpvillages = js.GetValue("VDMPVillages/DMPVillages").ToString();
                            }

                            if (js.GetValue("VDMPVillages/VDMPSub-County") != null)
                            {
                                cx.VdmpvillagesVdmpsubCounty = js.GetValue("VDMPVillages/VDMPSub-County").ToString();
                            }
                            cx.LastUpdatedAt = DateTime.Now;
                            vdmpvillage.Add(cx);
                        }
                        _context.SaveChanges();
                        _context.OnaDistrictMonthlySummaryVdmpvillages.AddRange(vdmpvillage);
                        _context.SaveChanges();
                    }
                    //parishes
                    if (j["parishes"] != null)
                    {
                        IEnumerable<JToken> data = j["parishes"].Children().ToList();
                        foreach (JObject js in data)
                        {
                            cy = new OnaDistrictMonthlySummaryNrmpparishes();
                            cy.UniqueParishId = Guid.NewGuid().ToString();
                            cy.Id = cg.Id;
                            if (js.GetValue("parishes/DMPparishes") != null)
                            {
                                cy.ParishesDmpparishes = js.GetValue("parishes/DMPparishes").ToString();
                            }
                            if (js.GetValue("parishes/CountParishes") != null)
                            {
                                cy.ParishesCountParishes = js.GetValue("parishes/CountParishes").ToString();
                            }

                            if (js.GetValue("parishes/PDMPSub-County") != null)
                            {
                                cy.ParishesPdmpsubCount = js.GetValue("parishes/PDMPSub-County").ToString();
                            }
                            cy.LastUpdatedAt = DateTime.Now;
                            nrmpparishes.Add(cy);
                        }
                        _context.SaveChanges();
                        _context.OnaDistrictMonthlySummaryNrmpparishes.AddRange(nrmpparishes);
                        _context.SaveChanges();
                    }
                    //Sub-County
                    if (j["Sub-County"] != null)
                    {
                        IEnumerable<JToken> data = j["Sub-County"].Children().ToList();
                        foreach (JObject js in data)
                        {
                            cz = new OnaDistrictMonthlySummaryNrmpsubcounty();
                            cz.UniqueSubcountyId = Guid.NewGuid().ToString();
                            cz.Id = cg.Id;
                            if (js.GetValue("Sub-County/CountSubcounty") != null)
                            {
                                cz.SubCountyCountSubcounty = js.GetValue("Sub-County/CountSubcounty").ToString();
                            }
                            if (js.GetValue("Sub-County/DMPSubcounties") != null)
                            {
                                cz.SubCountyDmpsubcounties = js.GetValue("Sub-County/DMPSubcounties").ToString();
                            }
                            cz.LastUpdatedAt = DateTime.Now;
                            nrmpsubcounty.Add(cz);
                        }
                        _context.SaveChanges();
                        _context.OnaDistrictMonthlySummaryNrmpsubcounty.AddRange(nrmpsubcounty);
                        _context.SaveChanges();
                    }
                    //Ona District Monthly Summary
                    if (j.GetValue("SDP") != null)
                    {
                        cg.Sdp = Convert.ToInt32(j.GetValue("SDP").ToString());
                    }
                    if (j.GetValue("_id") != null)
                    {
                        cg.Id = Convert.ToInt32(j.GetValue("_id").ToString());
                    }
                    if (j.GetValue("end") != null)
                    {
                        cg.Endd = j.GetValue("end").ToString();
                    }
                    if (j.GetValue("DDMP") != null)
                    {
                        cg.Ddmp = Convert.ToInt32(j.GetValue("DDMP").ToString());
                    }
                    if (j.GetValue("PDMP") != null)
                    {
                        cg.Pdmp = Convert.ToInt32(j.GetValue("PDMP").ToString());
                    }
                    if (j.GetValue("SDMP") != null)
                    {
                        cg.Sdmp = Convert.ToInt32(j.GetValue("SDMP").ToString());
                    }
                    if (j.GetValue("VDMP") != null)
                    {
                        cg.Vdmp = Convert.ToInt32(j.GetValue("VDMP").ToString());
                    }
                    if (j.GetValue("Fyear") != null)
                    {
                        cg.Fyear = j.GetValue("Fyear").ToString();
                    }
                    if (j.GetValue("_submission_time") != null)
                    {
                        CultureInfo enUS = new CultureInfo("en-US");
                        string dateString;
                        DateTime dateValue;
                        // Use custom formats with M and MM.
                        dateString = j.GetValue("_submission_time").ToString();
                        //if (DateTime.TryParseExact(dateString, "M/dd/yyyy hh:mm", enUS,
                        if (DateTime.TryParse(dateString, out dateValue))
                        {
                            cg.SubmissionTime = dateValue;// Convert.ToDateTime(j.GetValue("_submission_time").ToString());
                        }
                    }
                    if (j.GetValue("Month") != null)
                    {
                        cg.Month = j.GetValue("Month").ToString();
                    }
                    if (j.GetValue("VNRMP") != null)
                    {
                        double ddvalue;
                        if (Double.TryParse(j.GetValue("VNRMP").ToString(), out ddvalue))
                        {
                            cg.Vnrmp = ddvalue;
                        }
                    }
                    if (j.GetValue("start") != null)
                    {
                        cg.Start = j.GetValue("start").ToString();
                    }
                    if (j.GetValue("District") != null)
                    {
                        cg.District = j.GetValue("District").ToString();
                    }
                    if (j.GetValue("Latrines") != null)
                    {
                        cg.Latrines = Convert.ToInt32(j.GetValue("Latrines").ToString());
                    }
                    if (j.GetValue("Fruit_Trees") != null)
                    {
                        cg.FruitTrees = Convert.ToInt32(j.GetValue("Fruit_Trees").ToString());
                    }
                    if (j.GetValue("Other_Trees") != null)
                    {
                        cg.OtherTrees = Convert.ToInt32(j.GetValue("Other_Trees").ToString());
                    }
                    if (j.GetValue("Schools_count") != null)
                    {
                        cg.SchoolsCount = Convert.ToInt32(j.GetValue("Schools_count").ToString());
                    }
                    if (j.GetValue("_submitted_by") != null)
                    {
                        cg.SubmittedBy = j.GetValue("_submitted_by").ToString();
                    }
                    if (j.GetValue("parishes_count") != null)
                    {
                        cg.ParishesCount = Convert.ToInt32(j.GetValue("parishes_count").ToString());
                    }
                    if (j.GetValue("Sub-County_count") != null)
                    {
                        cg.SubCountyCount = Convert.ToInt32(j.GetValue("Sub-County_count").ToString());
                    }
                    if (j.GetValue("_submission_time") != null)
                    {
                        CultureInfo enUS = new CultureInfo("en-US");
                        string dateString;
                        DateTime dateValue;
                        // Use custom formats with M and MM.
                        dateString = j.GetValue("_submission_time").ToString();
                        //if (DateTime.TryParseExact(dateString, "M/dd/yyyy hh:mm", enUS,
                        if (DateTime.TryParse(dateString, out dateValue))
                        {
                            cg.SubmissionTime = dateValue;// Convert.ToDateTime(j.GetValue("_submission_time").ToString());
                        }
                    }
                    if (j.GetValue("NRMPVillages_count") != null)
                    {
                        cg.NrmpvillagesCount = Convert.ToInt32(j.GetValue("NRMPVillages_count").ToString());
                    }
                    if (j.GetValue("VDMPVillages_count") != null)
                    {
                        cg.VdmpvillagesCount = Convert.ToInt32(j.GetValue("VDMPVillages_count").ToString());
                    }
                    if (j.GetValue("input_aggr") != null)
                    {
                        cg.InputAggr = Convert.ToInt32(j.GetValue("input_aggr").ToString());
                    }
                    if (j.GetValue("output_aggr") != null)
                    {
                        cg.OutputAggr = Convert.ToInt32(j.GetValue("output_aggr").ToString());
                    }
                    if (j.GetValue("Month") != null)
                    {
                        cg.Month = j.GetValue("Month").ToString();
                    }
                    cg.LastUpdatedAt = DateTime.Now;

                    dismonsum.Add(cg);
                }
            }
            return dismonsum;
        }
        public async Task SaveDisMonSumm()
        {
            try
            {
                using (var IcanContext = new USAID_ICANContext())
                {
                    var data = GetDisMonSum().ToList();
                    IcanContext.OnaDistrictMonthlySummary.RemoveRange(IcanContext.OnaDistrictMonthlySummary.ToList());
                    await IcanContext.SaveChangesAsync();
                    IcanContext.OnaDistrictMonthlySummary.AddRange(data);
                    await IcanContext.SaveChangesAsync();

                    //send email after update                   
                    EmailModel email = new EmailModel(_context);
                    email.OnaDistrictMonthlySummaryEmail();
                }
            }
            catch (Exception ex)
            {
                string m = ex.ToString();
                throw ex;
            }
        }
        #endregion DistrictMonthlySummary

        #region MIYCAN_MonthlySummaryVer5
        public IEnumerable<OnaMiycanMonthlySummaryVer5> GetMIYCANMonSumer5DataRecords()
        {
            //Load the data from the API
            var model = new object[0];
            var targeturllast = string.Format("https://api.ona.io/api/v1/data/574049");
            List<OnaMiycanMonthlySummaryVer5> micannonsumver5 = new List<OnaMiycanMonthlySummaryVer5>();
            //Here
            HttpMessageHandler handlerlast = new HttpClientHandler()
            {
            };

            var httpClientlast = new HttpClient(handlerlast)
            {
                BaseAddress = new Uri(targeturllast),
                Timeout = new TimeSpan(0, 20, 0)
            };

            httpClientlast.DefaultRequestHeaders.Add("ContentType", "application/json");

            //This is the key section you were missing    
            var plainTextByteslast = System.Text.Encoding.UTF8.GetBytes("ican:abt@1can");
            string vallast = System.Convert.ToBase64String(plainTextByteslast);
            httpClientlast.DefaultRequestHeaders.Add("Authorization", "Basic " + vallast);

            var methodlast = new HttpMethod("GET");
            List<string> myListlast = new List<string>();

            JArray jArraylast = new JArray();
            HttpResponseMessage responselast = httpClientlast.GetAsync(targeturllast).Result;

            var alink = responselast.Headers.FirstOrDefault(o => o.Key == "Link");
            var pages = alink.Value.FirstOrDefault();
            var page_1 = pages.Split(",");
            string lastpage = null;
            foreach (var nw in page_1)
            {
                if (nw.Contains("last"))
                {
                    var ax = nw.Split(";");
                    lastpage = ax[0].Replace('<', ' ').Replace('>', ' ').Trim();
                }
            }

            int i = 1;

            while (true)
            {
                var targeturl = "https://api.ona.io/api/v1/data/574049" + "?page=" + i + "&page_size=10000";

                HttpMessageHandler handler = new HttpClientHandler()
                {
                };

                var httpClient = new HttpClient(handler)
                {
                    BaseAddress = new Uri(targeturl),
                    Timeout = new TimeSpan(0, 20, 0)
                };

                //List<OnaCommunitygroupSummary2021> commgrpsummver5 = new List<OnaCommunitygroupSummary2021>();
                httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");

                //This is the key section you were missing    
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes("ican:abt@1can");
                string val = System.Convert.ToBase64String(plainTextBytes);
                httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + val);

                var method = new HttpMethod("GET");
                List<string> myList = new List<string>();

                JArray jArray = new JArray();
                HttpResponseMessage response = httpClient.GetAsync(targeturl).Result;

                if (response.ReasonPhrase == "Not Found")
                {
                    //TempData["Message"] = string.Format("No records found for  {0}-{1}", reportingPeriod.Replace("%20", ""), financialYear.ToString()); ;
                }
                else
                {
                    string content = string.Empty;

                    using (StreamReader stream = new StreamReader(response.Content.ReadAsStreamAsync().Result, true))
                    {
                        content = stream.ReadToEnd();
                    }

                    jArray = JArray.Parse(content);

                    foreach (JObject j in jArray)
                    {
                        var cg = new OnaMiycanMonthlySummaryVer5();

                        string dvalue = string.Empty;
                        double dnumber;
                        bool success = false;

                        if (j.GetValue("fo") != null)
                        {
                            cg.District = j.GetValue("fo").ToString();
                        }

                        cg.Id = Convert.ToInt32(j.GetValue("_id").ToString());

                        if (j.GetValue("all") != null)
                        {
                            cg.All = j.GetValue("all").ToString();
                        }
                        if (j.GetValue("end") != null)
                        {
                            cg.Endd = j.GetValue("end").ToString();
                        }
                        if (j.GetValue("mod") != null)
                        {
                            cg.Mod = j.GetValue("mod").ToString();
                        }
                        if (j.GetValue("ack2") != null)
                        {
                            cg.Ack2 = j.GetValue("ack2").ToString();
                        }

                        if (j.GetValue("year") != null)
                        {
                            cg.Year = j.GetValue("year").ToString();
                        }
                        if (j.GetValue("image") != null)
                        {
                            cg.Image = j.GetValue("image").ToString();
                        }
                        if (j.GetValue("month") != null)
                        {
                            cg.Month = j.GetValue("month").ToString();
                        }
                        if (j.GetValue("start") != null)
                        {
                            cg.Start = j.GetValue("start").ToString();
                        }
                        if (j.GetValue("OtherF") != null)
                        {
                            cg.OtherF = j.GetValue("OtherF").ToString();
                        }
                        if (j.GetValue("OtherM") != null)
                        {
                            cg.OtherM = j.GetValue("OtherM").ToString();
                        }
                        if (j.GetValue("numMal") != null)
                        {
                            cg.NumMal = Convert.ToDouble(j.GetValue("numMal").ToString());
                        }
                        if (j.GetValue("vht_id") != null)
                        {
                            cg.VhtId = j.GetValue("vht_id").ToString();
                        }
                        if (j.GetValue("calc_yr") != null)
                        {
                            cg.CalcYr = j.GetValue("calc_yr").ToString();
                        }
                        if (j.GetValue("curr_yr") != null)
                        {
                            cg.CurrYr = j.GetValue("curr_yr").ToString();
                        }
                        if (j.GetValue("village") != null)
                        {
                            cg.Village = j.GetValue("village").ToString();
                        }
                        if (j.GetValue("district") != null)
                        {
                            cg.District = j.GetValue("district").ToString();
                        }
                        if (j.GetValue("moth/l19") != null)
                        {
                            cg.MothL19 = Convert.ToDouble(j.GetValue("moth/l19").ToString());
                        }
                        if (j.GetValue("moth/p19") != null)
                        {
                            cg.MothP19 = Convert.ToDouble(j.GetValue("moth/p19").ToString());
                        }
                        if (j.GetValue("muac/scr") != null)
                        {
                            cg.MuacScr = j.GetValue("muac/scr").ToString();
                        }
                        if (j.GetValue("oth/o19f") != null)
                        {
                            cg.OthO19f = Convert.ToDouble(j.GetValue("oth/o19f").ToString());
                        }
                        if (j.GetValue("oth/o19m") != null)
                        {
                            cg.OthO19m = Convert.ToDouble(j.GetValue("oth/o19m").ToString());
                        }
                        if (j.GetValue("moth/lA19") != null)
                        {
                            cg.MothLA19 = Convert.ToDouble(j.GetValue("moth/lA19").ToString());
                        }
                        if (j.GetValue("moth/pA19") != null)
                        {
                            cg.MothPA19 = Convert.ToDouble(j.GetValue("moth/pA19").ToString());
                        }
                        if (j.GetValue("th/oA19f") != null)
                        {
                            cg.OthOA19f = Convert.ToDouble(j.GetValue("th/oA19f").ToString());
                        }
                        if (j.GetValue("oth/oA19m") != null)
                        {
                            cg.OthOA19m = Convert.ToDouble(j.GetValue("oth/oA19m").ToString());
                        }
                        if (j.GetValue("referrals") != null)
                        {
                            cg.Referrals = j.GetValue("referrals").ToString();
                        }
                        if (j.GetValue("subcounty") != null)
                        {
                            cg.Subcounty = j.GetValue("subcounty").ToString();
                        }
                        if (j.GetValue("LacMothers") != null)
                        {
                            cg.LacMothers = j.GetValue("LacMothers").ToString();
                        }
                        if (j.GetValue("PregMothers") != null)
                        {
                            cg.PregMothers = j.GetValue("PregMothers").ToString();
                        }
                        if (j.GetValue("muac/scrMale") != null)
                        {
                            cg.MuacScrMale = Convert.ToDouble(j.GetValue("muac/scrMale").ToString());
                        }
                        if (j.GetValue("odema/vita_f") != null)
                        {
                            cg.OdemaVitaF = Convert.ToDouble(j.GetValue("odema/vita_f").ToString());
                        }
                        if (j.GetValue("odema/vita_m") != null)
                        {
                            cg.OdemaVitaM = Convert.ToDouble(j.GetValue("odema/vita_m").ToString());
                        }
                        if (j.GetValue("_submitted_by") != null)
                        {
                            cg.SubmittedBy = j.GetValue("_submitted_by").ToString();
                        }
                        if (j.GetValue("MuacRedMale5") != null)
                        {
                            cg.MuacRedMale5 = Convert.ToDouble(j.GetValue("MuacRedMale5").ToString());
                        }
                        if (j.GetValue("odema/odema_f") != null)
                        {
                            cg.OdemaOdemaF = Convert.ToDouble(j.GetValue("odema/odema_f").ToString());
                        }
                        if (j.GetValue("odema/odema_m") != null)
                        {
                            cg.OdemaOdemaM = Convert.ToDouble(j.GetValue("odema/odema_m").ToString());
                        }
                        if (j.GetValue("muac/scrFemale") != null)
                        {
                            cg.MuacScrFemale = Convert.ToDouble(j.GetValue("muac/scrFemale").ToString());
                        }
                        if (j.GetValue("muac/redFemale5") != null)
                        {
                            cg.MuacRedFemale5 = Convert.ToDouble(j.GetValue("muac/redFemale5").ToString());
                        }
                        if (j.GetValue("_submission_time") != null)
                        {
                            CultureInfo enUS = new CultureInfo("en-US");
                            string dateString;
                            DateTime dateValue;
                            // Use custom formats with M and MM.
                            dateString = j.GetValue("_submission_time").ToString();
                            //if (DateTime.TryParseExact(dateString, "M/dd/yyyy hh:mm", enUS,
                            if (DateTime.TryParse(dateString, out dateValue))
                            {
                                cg.SubmissionTime = dateValue;
                            }
                        }
                        if (j.GetValue("location/groupid") != null)
                        {
                            cg.LocationGroupid = j.GetValue("location/groupid").ToString();
                        }
                        if (j.GetValue("muac/yellowMale5") != null)
                        {
                            cg.MuacYellowMale5 = Convert.ToDouble(j.GetValue("muac/yellowMale5").ToString());
                        }

                        if (j.GetValue("odema/no_odema_f") != null)
                        {
                            cg.OdemaNoOdemaF = Convert.ToDouble(j.GetValue("odema/no_odema_f").ToString());
                        }
                        if (j.GetValue("odema/no_odema_m") != null)
                        {
                            cg.OdemaNoOdemaM = Convert.ToDouble(j.GetValue("odema/no_odema_m").ToString());
                        }
                        if (j.GetValue("location/groupname") != null)
                        {
                            cg.LocationGroupname = j.GetValue("location/groupname").ToString();
                        }
                        if (j.GetValue("muac/yellowFemale5") != null)
                        {
                            cg.MuacYellowFemale5 = Convert.ToDouble(j.GetValue("muac/yellowFemale5").ToString());
                        }
                        if (j.GetValue("odema/odemaplus2_f") != null)
                        {
                            cg.OdemaOdemaplus2F = Convert.ToDouble(j.GetValue("odema/odemaplus2_f").ToString());
                        }
                        if (j.GetValue("odema/odemaplus2_m") != null)
                        {
                            cg.OdemaOdemaplus2M = Convert.ToDouble(j.GetValue("odema/odemaplus2_m").ToString());
                        }
                        if (j.GetValue("odema/odemaplus3_f") != null)
                        {
                            cg.OdemaOdemaplus3F = Convert.ToDouble(j.GetValue("odema/odemaplus3_f").ToString());
                        }
                        if (j.GetValue("odema/odemaplus3_m") != null)
                        {
                            cg.OdemaOdemaplus3M = Convert.ToDouble(j.GetValue("odema/odemaplus3_m").ToString());
                        }

                        if (j.GetValue("numANC") != null)
                        {
                            cg.NumAnc = Convert.ToDouble(j.GetValue("numANC").ToString());
                        }
                        if (j.GetValue("numFP") != null)
                        {
                            cg.NumFp = Convert.ToDouble(j.GetValue("numFP").ToString());
                        }
                        if (j.GetValue("numOther") != null)
                        {
                            cg.NumOther = Convert.ToDouble(j.GetValue("numOther").ToString());
                        }

                        if (j.GetValue("comments") != null)
                        {
                            cg.Comments = j.GetValue("comments").ToString();
                        }

                        if (j.GetValue("mod1") != null)
                        {
                            cg.Mod1 = j.GetValue("mod1").ToString();
                        }
                        if (j.GetValue("mod1_1") != null)
                        {
                            cg.Mod11 = Convert.ToDouble(j.GetValue("mod1_1").ToString());
                        }
                        if (j.GetValue("mod1_2") != null)
                        {
                            cg.Mod12 = Convert.ToDouble(j.GetValue("mod1_2").ToString());
                        }
                        if (j.GetValue("mod1_3") != null)
                        {
                            cg.Mod13 = Convert.ToDouble(j.GetValue("mod1_3").ToString());
                        }
                        if (j.GetValue("mod1_4") != null)
                        {
                            cg.Mod14 = Convert.ToDouble(j.GetValue("mod1_4").ToString());
                        }
                        if (j.GetValue("mod1_5") != null)
                        {
                            cg.Mod15 = Convert.ToDouble(j.GetValue("mod1_5").ToString());
                        }
                        if (j.GetValue("mod1_6") != null)
                        {
                            cg.Mod16 = Convert.ToDouble(j.GetValue("mod1_6").ToString());
                        }
                        if (j.GetValue("mod1_7") != null)
                        {
                            cg.Mod17 = Convert.ToDouble(j.GetValue("mod1_7").ToString());
                        }
                        if (j.GetValue("mod1_10") != null)
                        {
                            cg.Mod110 = Convert.ToDouble(j.GetValue("mod1_10").ToString());
                        }
                        if (j.GetValue("mod1_8") != null)
                        {
                            cg.Mod18 = Convert.ToDouble(j.GetValue("mod1_8").ToString());
                        }
                        if (j.GetValue("mod1_9") != null)
                        {
                            cg.Mod19 = Convert.ToDouble(j.GetValue("mod1_9").ToString());
                        }
                        if (j.GetValue("mod1_10") != null)
                        {
                            cg.Mod110 = Convert.ToDouble(j.GetValue("mod1_10").ToString());
                        }
                        if (j.GetValue("mod1_11") != null)
                        {
                            cg.Mod111 = Convert.ToDouble(j.GetValue("mod1_11").ToString());
                        }
                        if (j.GetValue("mod2_1") != null)
                        {
                            cg.Mod21 = j.GetValue("mod2_1").ToString();
                        }
                        if (j.GetValue("mod2_2") != null)
                        {
                            cg.Mod22 = j.GetValue("mod2_2").ToString();
                        }
                        if (j.GetValue("mod2_3") != null)
                        {
                            cg.Mod23 = j.GetValue("mod2_3").ToString();
                        }
                        if (j.GetValue("mod2_4") != null)
                        {
                            cg.Mod24 = j.GetValue("mod2_4").ToString();
                        }
                        if (j.GetValue("mod3") != null)
                        {
                            cg.Mod3 = j.GetValue("mod3").ToString();
                        }
                        if (j.GetValue("mod3_1") != null)
                        {
                            cg.Mod31 = j.GetValue("mod3_1").ToString();
                        }
                        if (j.GetValue("mod3_2") != null)
                        {
                            cg.Mod32 = j.GetValue("mod3_2").ToString();
                        }
                        if (j.GetValue("mod3_3") != null)
                        {
                            cg.Mod33 = j.GetValue("mod3_3").ToString();
                        }
                        if (j.GetValue("mod3_4") != null)
                        {
                            cg.Mod34 = j.GetValue("mod3_4").ToString();
                        }
                        if (j.GetValue("mod3_5") != null)
                        {
                            cg.Mod35 = j.GetValue("mod3_5").ToString();
                        }
                        if (j.GetValue("mod3_6") != null)
                        {
                            cg.Mod36 = j.GetValue("mod3_6").ToString();
                        }
                        if (j.GetValue("mod3_7") != null)
                        {
                            cg.Mod37 = j.GetValue("mod3_7").ToString();
                        }
                        if (j.GetValue("mod4") != null)
                        {
                            cg.Mod4 = j.GetValue("mod4").ToString();
                        }
                        if (j.GetValue("mod4_1") != null)
                        {
                            cg.Mod41 = Convert.ToDouble(j.GetValue("mod4_1").ToString());
                        }
                        if (j.GetValue("mod4_2") != null)
                        {
                            cg.Mod42 = Convert.ToDouble(j.GetValue("mod4_2").ToString());
                        }
                        if (j.GetValue("mod4_3") != null)
                        {
                            cg.Mod43 = Convert.ToDouble(j.GetValue("mod4_3").ToString());
                        }
                        if (j.GetValue("mod4_4") != null)
                        {
                            cg.Mod44 = Convert.ToDouble(j.GetValue("mod4_4").ToString());
                        }
                        if (j.GetValue("mod4_5") != null)
                        {
                            cg.Mod45 = Convert.ToDouble(j.GetValue("mod4_5").ToString());
                        }
                        if (j.GetValue("mod4_6") != null)
                        {
                            cg.Mod46 = Convert.ToDouble(j.GetValue("mod4_6").ToString());
                        }

                        cg.LastUpdatedAt = DateTime.Now;
                        
                        using (var dbContext = new USAID_ICANContext())
                        {
                            var exist = dbContext.OnaMiycanMonthlySummaryVer5.FirstOrDefault(o => o.Id == cg.Id);
                            if (exist == null)
                            {
                                micannonsumver5.Add(cg);
                            }
                        }

                        //micannonsumver5.Add(cg);
                    }
                }
                i++;

                if (targeturl == lastpage)
                    break;
            }

            return micannonsumver5;
        }

        public async Task SavemiycanmonVer5SumData()
        {
            try
            {
                using (var IcanContext = new USAID_ICANContext())
                {
                    var data = GetMIYCANMonSumer5DataRecords().ToList();
                    //IcanContext.OnaMiycanMonthlySummaryVer5.RemoveRange(IcanContext.OnaMiycanMonthlySummaryVer5.ToList());
                    //await IcanContext.SaveChangesAsync();

                    IcanContext.OnaMiycanMonthlySummaryVer5.AddRange(data);
                    await IcanContext.SaveChangesAsync();

                    //send email after update                   
                    EmailModel email = new EmailModel(_context);
                    email.OnaMiycanMonthlySummaryVer5Email();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion MIYCAN_MonthlySummaryVer5

        #region Targets
        public IEnumerable<OnaTargets> GetTargetData()
        {
            //Load the data from the API
            var model = new object[0];
            var targeturl = string.Format("https://api.ona.io/api/v1/data/658551");
            //Jan - Mar
            HttpMessageHandler handler = new HttpClientHandler()
            {
            };

            var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(targeturl),
                Timeout = new TimeSpan(0, 20, 0)
            };

            List<OnaTargets> targets = new List<OnaTargets>();
            httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");

            //This is the key section you were missing    
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes("ican:abt@1can");
            string val = System.Convert.ToBase64String(plainTextBytes);
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + val);

            var method = new HttpMethod("GET");
            List<string> myList = new List<string>();

            JArray jArray = new JArray();
            HttpResponseMessage response = httpClient.GetAsync(targeturl).Result;
            if (response.ReasonPhrase == "Not Found")
            {
                //TempData["Message"] = string.Format("No records found for  {0}-{1}", reportingPeriod.Replace("%20", ""), financialYear.ToString()); ;
            }
            else
            {
                string content = string.Empty;

                using (StreamReader stream = new StreamReader(response.Content.ReadAsStreamAsync().Result, true))
                {
                    content = stream.ReadToEnd();
                }

                jArray = JArray.Parse(content);
                // Strip off the [] from _tags and Notes


                foreach (JObject j in jArray)
                {
                    var cg = new OnaTargets();

                    string dvalue = string.Empty;
                    double dnumber;
                    bool success = false;

                    cg.TargetId = Convert.ToInt32(j.GetValue("_id").ToString());

                    if (j.GetValue("Indicator") != null)
                    {
                        cg.Indicator = j.GetValue("Indicator").ToString();
                    }
                    if (j.GetValue("Region") != null)
                    {
                        cg.Region = j.GetValue("Region").ToString();
                    }
                    if (j.GetValue("District") != null)
                    {
                        cg.District = j.GetValue("District").ToString();
                    }

                    cg.Target = Convert.ToInt32(j.GetValue("Target").ToString());

                    //if (j.GetValue("Target") != null)
                    //{
                    //    cg.Target = Convert.ToDouble(j.GetValue("Target").ToString());
                    //}

                    cg.Year = Convert.ToInt32(j.GetValue("Year").ToString());
                   
                    if (j.GetValue("_submission_time") != null)
                    {
                        CultureInfo enUS = new CultureInfo("en-US");
                        string dateString;
                        DateTime dateValue;
                        // Use custom formats with M and MM.
                        dateString = j.GetValue("_submission_time").ToString();
                        //if (DateTime.TryParseExact(dateString, "M/dd/yyyy hh:mm", enUS,
                        if (DateTime.TryParse(dateString, out dateValue))
                        {
                            cg.SubmissionTime = dateValue;
                        }
                    }

                    cg.LastUpdatedAt = DateTime.Now;

                    using (var dbContext = new USAID_ICANContext())
                    {
                        var exist = dbContext.OnaTargets.FirstOrDefault(o => o.TargetId == cg.TargetId);
                        if (exist == null)
                        {
                            targets.Add(cg);
                        }
                    }

                    //targets.Add(cg);
                }
            }
            return targets;
        }

        public async Task SaveTargetsData()
        {
            try
            {
                using (var IcanContext = new USAID_ICANContext())
                {
                    var data = GetTargetData().ToList();
                    //IcanContext.OnaTargets.RemoveRange(IcanContext.OnaTargets.ToList());
                    //await IcanContext.SaveChangesAsync();
                    IcanContext.OnaTargets.AddRange(data);
                    await IcanContext.SaveChangesAsync();

                    //send email after update                   
                    EmailModel email = new EmailModel(_context);
                    email.OnaTargetsEmail();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Targets

    }

    public class ChilliData
    {
        public int _id { get; set; }
        public List<object> _tags { get; set; }
        public string _uuid { get; set; }
        public List<object> _notes { get; set; }
        public string parish { get; set; }
        public bool _edited { get; set; }
        public string _status { get; set; }
        public string groupid { get; set; }
        public string village { get; set; }
        public string _version { get; set; }
        public string district { get; set; }
        public string _duration { get; set; }
        public int _xform_id { get; set; }
        public string groupname { get; set; }
        public object maleyouth { get; set; }
        public string subcounty { get; set; }
        public object maleadults { get; set; }
        public double femaleyouth { get; set; }
        public List<object> _attachments { get; set; }
        public List<object> _geolocation { get; set; }
        public int _media_count { get; set; }
        public int _total_media { get; set; }
        public object femaleadults { get; set; }
        public string formhub_uuid { get; set; }
        public object _submitted_by { get; set; }
        public string meta_instanceID { get; set; }
        public DateTime _submission_time { get; set; }
        public string _xform_id_string { get; set; }
        public string _bamboo_dataset_id { get; set; }
        public bool _media_all_received { get; set; }
        public double totalnumberofparticipants { get; set; }
    }

    public class CrcData
    {
        public int _id { get; set; }
        public List<object> _tags { get; set; }
        public string _uuid { get; set; }
        public List<object> _notes { get; set; }
        public string parish { get; set; }
        public string school { get; set; }
        public bool _edited { get; set; }
        public string _status { get; set; }
        public string village { get; set; }
        public string _version { get; set; }
        public string district { get; set; }
        public string latitude { get; set; }
        public string schoolid { get; set; }
        public string _duration { get; set; }
        public int _xform_id { get; set; }
        public string longitude { get; set; }
        public string subcounty { get; set; }
        public string schoolname { get; set; }
        public List<object> _attachments { get; set; }
        public List<object> _geolocation { get; set; }
        public int _media_count { get; set; }
        public int _total_media { get; set; }
        public string formhub_uuid { get; set; }
        public object _submitted_by { get; set; }
        public string meta_instanceID { get; set; }
        public DateTime _submission_time { get; set; }
        public string _xform_id_string { get; set; }
        public string _bamboo_dataset_id { get; set; }
        public bool _media_all_received { get; set; }
    }

    public class LgroupsData
    {
        public int _id { get; set; }
        public List<object> _tags { get; set; }
        public string _uuid { get; set; }
        public List<object> _notes { get; set; }
        public string parish { get; set; }
        public bool _edited { get; set; }
        public string _status { get; set; }
        public string groupid { get; set; }
        public string village { get; set; }
        public string _version { get; set; }
        public string district { get; set; }
        public string latitude { get; set; }
        public float _latitude_latitude { get; set; }
        public string _duration { get; set; }
        public int _xform_id { get; set; }
        public string groupname { get; set; }
        public string longitude { get; set; }
        public float _longitude_latitude { get; set; }
        public string subcounty { get; set; }
        public List<object> _attachments { get; set; }
        public List<object> _geolocation { get; set; }
        public int _media_count { get; set; }
        public int _total_media { get; set; }
        public string formhub_uuid { get; set; }
        public object _submitted_by { get; set; }
        public string meta_instanceID { get; set; }
        public DateTime _submission_time { get; set; }
        public string _xform_id_string { get; set; }
        public string _bamboo_dataset_id { get; set; }
        public bool _media_all_received { get; set; }
        public int? total { get; set; }
        public Nullable<double> maleyouth { get; set; }
        public Nullable<double> femaleyouth { get; set; }
        public Nullable<double> maleadults { get; set; }
        public Nullable<double> femaleadults { get; set; }

        //public object maleyouth { get; set; }
        //public object maleadults { get; set; }
        //public object femaleyouth { get; set; }
        //public object femaleadults { get; set; } 
    }

    // Ona1McareGroups

    public class McareGroupsData
    {
        public int _id { get; set; }
        public List<object> _tags { get; set; }
        public string _uuid { get; set; }
        public List<object> _notes { get; set; }
        public bool _edited { get; set; }
        public string _status { get; set; }
        public string groupid { get; set; }
        public string village { get; set; }
        public string _version { get; set; }
        public string district { get; set; }
        public string latitude { get; set; }
        public string _duration { get; set; }
        public int _xform_id { get; set; }
        public string groupname { get; set; }
        public string longitude { get; set; }
        public string subcounty { get; set; }
        public List<object> _attachments { get; set; }
        public List<object> _geolocation { get; set; }
        public int _media_count { get; set; }
        public int _total_media { get; set; }
        public string formhub_uuid { get; set; }
        public object _submitted_by { get; set; }
        public string meta_instanceID { get; set; }
        public DateTime _submission_time { get; set; }
        public string _xform_id_string { get; set; }
        public string _bamboo_dataset_id { get; set; }
        public bool _media_all_received { get; set; }
    }
    // Ona1samplegrps

    public class SamplegrpsData
    {
        public int _id { get; set; }
        public List<object> _tags { get; set; }
        public string _uuid { get; set; }
        public List<object> _notes { get; set; }
        public string parish { get; set; }
        public bool _edited { get; set; }
        public string _status { get; set; }
        public string groupid { get; set; }
        public string village { get; set; }
        public string _version { get; set; }
        public string district { get; set; }
        public double latitude { get; set; }
        public string _duration { get; set; }
        public int _xform_id { get; set; }
        public string groupname { get; set; }
        public double longitude { get; set; }
        public string subcounty { get; set; }
        public List<object> _attachments { get; set; }
        public List<object> _geolocation { get; set; }
        public int _media_count { get; set; }
        public int _total_media { get; set; }
        public string formhub_uuid { get; set; }
        public object _submitted_by { get; set; }
        public string meta_instanceID { get; set; }
        public DateTime _submission_time { get; set; }
        public string _xform_id_string { get; set; }
        public string _bamboo_dataset_id { get; set; }
        public bool _media_all_received { get; set; }
    }

    public class AGYW2020Data
    {
        public string fo { get; set; }
        public int _id { get; set; }
        public DateTime end { get; set; }
        public string year { get; set; }
        public List<object> _tags { get; set; }
        public string _uuid { get; set; }
        public string month { get; set; }
        public DateTime start { get; set; }
        public List<object> _notes { get; set; }
        public bool _edited { get; set; }
        public string _status { get; set; }
        public DateTime calc_yr { get; set; }
        public string curr_yr { get; set; }
        public string village { get; set; }
        public string _version { get; set; }
        public string deviceid { get; set; }
        public string district { get; set; }
        public double _duration { get; set; }
        public int _xform_id { get; set; }
        public string subcounty { get; set; }
        public string sectionA_ms { get; set; }
        public List<object> _attachments { get; set; }
        public List<object> _geolocation { get; set; }
        public int _media_count { get; set; }
        public int _total_media { get; set; }
        public string formhub_uuid { get; set; }
        public string sectionA_act { get; set; }
        public object sectionA_age { get; set; }
        public string sectionB_biz { get; set; }
        public string _submitted_by { get; set; }
        public string sectionA_educ { get; set; }
        public string sectionA_preg { get; set; }
        public string sectionA_read { get; set; }
        public string sectionB_make { get; set; }
        public string sectionA_fname { get; set; }
        public string sectionB_money { get; set; }
        public string sectionB_spent { get; set; }
        public string meta_instanceID { get; set; }
        public string sectionB_income { get; set; }
        public DateTime _submission_time { get; set; }
        public string _xform_id_string { get; set; }
        public string sectionA_disable { get; set; }
        public string sectionA_surname { get; set; }
        public string sectionB_live_tr { get; set; }
        public string sectionA_children { get; set; }
        public string sectionA_noschool { get; set; }
        public string sectionB_live_act { get; set; }
        public string _bamboo_dataset_id { get; set; }
        public int sectionA_age_birth { get; set; }
        public string sectionA_live_with { get; set; }
        public bool _media_all_received { get; set; }
        public string sectionB_saving_grp { get; set; }
        public string sec2sectionA_prepost1 { get; set; }
        public string sec2sectionA_prepost2 { get; set; }
        public string sec2sectionA_prepost3 { get; set; }
        public string sec2sectionA_prepost4 { get; set; }
        public string sec2sectionA_prepost5 { get; set; }
        public string sec2sectionA_prepost6 { get; set; }
        public string sec2sectionA_prepost7 { get; set; }
        public string sec2sectionA_prepost8 { get; set; }
        public string sec2sectionB_prepost9 { get; set; }
        public string sec2sectionB_prepost10 { get; set; }
        public string sec2sectionB_prepost11 { get; set; }
        public string sec2sectionB_prepost12 { get; set; }
        public string sec2sectionB_prepost13 { get; set; }
        public string sec2sectionB_prepost14 { get; set; }
        public string sec2sectionB_prepost15 { get; set; }
        public string sec2sectionB_prepost16 { get; set; }
        public string sec2sectionC_prepost17 { get; set; }
        public string sec2sectionC_prepost18 { get; set; }
        public string sec2sectionC_prepost19 { get; set; }
        public string sec2sectionC_prepost20 { get; set; }
        public string sec2sectionC_prepost21 { get; set; }
        public string sec2sectionC_prepost22 { get; set; }
        public string sec2sectionD_prepost23 { get; set; }
        public string sec2sectionD_prepost24 { get; set; }
        public string sec2sectionD_prepost25 { get; set; }
        public string sec2sectionD_prepost26 { get; set; }
        public string sec2sectionD_prepost27 { get; set; }
        public string sec2sectionD_prepost28 { get; set; }
        public string sec2sectionE_prepost29 { get; set; }
        public string sec2sectionE_prepost30 { get; set; }
        public string sec2sectionE_prepost31 { get; set; }
        public string sec2sectionE_prepost32 { get; set; }
        public string sec2sectionE_prepost33 { get; set; }
        public string sec2sectionE_prepost34 { get; set; }
        public string sec2sectionF_prepost35 { get; set; }
        public string sec2sectionF_prepost36 { get; set; }
        public string sec2sectionF_prepost37 { get; set; }
        public string sec2sectionF_prepost38 { get; set; }
        public string sec2sectionF_prepost39 { get; set; }
        public string sec2sectionF_prepost40 { get; set; }
        public string sec2sectionG_prepost41 { get; set; }
        public string sec2sectionG_prepost42 { get; set; }
        public string sec2sectionG_prepost43 { get; set; }
        public string sec2sectionG_prepost44 { get; set; }
        public string sec2sectionG_prepost45 { get; set; }
        public string sec2sectionG_prepost46 { get; set; }
        public string sec2sectionG_prepost47 { get; set; }
        public string sectionB_src_live_tr { get; set; }
        public string sectionB_src_live_act { get; set; }
        public string sectionB_other_spent { get; set; }
        public string sectionA_other { get; set; }
        public string sectionB_other_money { get; set; }
        public string sectionA_disable2 { get; set; }
        public string sectionB_other_make { get; set; }
        public string sectionA_other_relative { get; set; }
        public string sectionA_other_disable { get; set; }

    }

    public class BSPSurveyData
    {
        public string fo { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public int _id { get; set; }
        public DateTime end { get; set; }
        public string ack2 { get; set; }
        public string year { get; set; }
        public List<object> _tags { get; set; }
        public string _uuid { get; set; }
        public string month { get; set; }
        public DateTime start { get; set; }
        public List<object> _notes { get; set; }
        public string BSPName { get; set; }
        public string Mstatus { get; set; }
        public bool _edited { get; set; }
        public string _status { get; set; }
        public DateTime calc_yr { get; set; }
        public string curr_yr { get; set; }
        public string village { get; set; }
        public string _version { get; set; }
        public string deviceid { get; set; }
        public string district { get; set; }
        public int Numgroups { get; set; }
        public double _duration { get; set; }
        public int _xform_id { get; set; }
        public string subcounty { get; set; }
        public string PhoneNumber { get; set; }
        public List<object> _attachments { get; set; }
        public List<object> _geolocation { get; set; }
        public int _media_count { get; set; }
        public int _total_media { get; set; }
        public string formhub_uuid { get; set; }
        public int TrainedInVSLA { get; set; }
        public string _submitted_by { get; set; }
        public string meta_instanceID { get; set; }
        public string BSPTrainedInVSLA { get; set; }
        public DateTime _submission_time { get; set; }
        public string _xform_id_string { get; set; }
        public string _bamboo_dataset_id { get; set; }
        public object LinkedToInputMarket { get; set; }
        public object LinkedToutputMarket { get; set; }
        public bool _media_all_received { get; set; }
        public string ReasonNotTrainedInVSLA { get; set; }
        public object income_IncomeLivestock { get; set; }
        public string BSPTrainedInFee4service { get; set; }
        public object income_IncomeInputSales { get; set; }
        public object LinkedToFinancialServices { get; set; }
        public object LinkedToGovermentPrograms { get; set; }
        public object TrainedInAgri_preneurship { get; set; }
        public string ReasonBSPNotTrainredinVSLA { get; set; }
        public object SupportedToOpenBankaccount { get; set; }
        public object SkilledInPriorityInterprise { get; set; }
        public string ReasonNotLinkedToutputMarket { get; set; }
        public string BSPTrainingInAgri_preneurship { get; set; }
        public string ReasonNotTrainedInfee4service { get; set; }
        public string ReasontNotLinkedToInputMarket { get; set; }
        public object SupportedOnCLimateTechnoloies { get; set; }
        public object income_IncomeExtensionProvision { get; set; }
        public object income_IncomeProduceAggregation { get; set; }
        public object income_incomeSalesofTecthnology { get; set; }
        public string ReasonNotLinkedToFinancialServices { get; set; }
        public string ReasonNotTrainedInAgri_preneurship { get; set; }
        public string ReasonNotLinkedToGovernmentPrograms { get; set; }
        public string ReasonNotSupportedToOpenBankaccount { get; set; }
        public string ReasonNotSkilledInPriorityInterprise { get; set; }
        public string ReasonNotSupportedOnCLimateTechnoloies { get; set; }
        public string comments { get; set; }

    }

    public class BSPSurveyfinalData
    {
        public string fo { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public int _id { get; set; }
        public DateTime end { get; set; }
        public string ack2 { get; set; }
        public string year { get; set; }
        public List<object> _tags { get; set; }
        public string _uuid { get; set; }
        public string month { get; set; }
        public DateTime start { get; set; }
        public List<object> _notes { get; set; }
        public string BSPName { get; set; }
        public string Mstatus { get; set; }
        public bool _edited { get; set; }
        public string _status { get; set; }
        public DateTime calc_yr { get; set; }
        public string curr_yr { get; set; }
        public string village { get; set; }
        public string _version { get; set; }
        public string deviceid { get; set; }
        public string district { get; set; }
        public int Numgroups { get; set; }
        public double _duration { get; set; }
        public int _xform_id { get; set; }
        public string subcounty { get; set; }
        public string PhoneNumber { get; set; }
        public List<object> _attachments { get; set; }
        public List<object> _geolocation { get; set; }
        public int _media_count { get; set; }
        public int _total_media { get; set; }
        public string formhub_uuid { get; set; }
        public int TrainedInVSLA { get; set; }
        public string _submitted_by { get; set; }
        public string meta_instanceID { get; set; }
        public string BSPTrainedInVSLA { get; set; }
        public DateTime _submission_time { get; set; }
        public string _xform_id_string { get; set; }
        public string _bamboo_dataset_id { get; set; }
        public object LinkedToInputMarket { get; set; }
        public object LinkedToutputMarket { get; set; }
        public bool _media_all_received { get; set; }
        public string ReasonNotTrainedInVSLA { get; set; }
        public object income_IncomeLivestock { get; set; }
        public string BSPTrainedInFee4service { get; set; }
        public object income_IncomeInputSales { get; set; }
        public object LinkedToFinancialServices { get; set; }
        public object LinkedToGovermentPrograms { get; set; }
        public object TrainedInAgri_preneurship { get; set; }
        public string ReasonBSPNotTrainredinVSLA { get; set; }
        public object SupportedToOpenBankaccount { get; set; }
        public object SkilledInPriorityInterprise { get; set; }
        public string ReasonNotLinkedToutputMarket { get; set; }
        public string BSPTrainingInAgri_preneurship { get; set; }
        public string ReasonNotTrainedInfee4service { get; set; }
        public string ReasontNotLinkedToInputMarket { get; set; }
        public object SupportedOnCLimateTechnoloies { get; set; }
        public object income_IncomeExtensionProvision { get; set; }
        public object income_IncomeProduceAggregation { get; set; }
        public object income_incomeSalesofTecthnology { get; set; }
        public string ReasonNotLinkedToFinancialServices { get; set; }
        public string ReasonNotTrainedInAgri_preneurship { get; set; }
        public string ReasonNotLinkedToGovernmentPrograms { get; set; }
        public string ReasonNotSupportedToOpenBankaccount { get; set; }
        public string ReasonNotSkilledInPriorityInterprise { get; set; }
        public string ReasonNotSupportedOnCLimateTechnoloies { get; set; }
        public string comments { get; set; }
    }

    public class BSPSurveyrevisedData
    {
        public string fo { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public int _id { get; set; }
        public DateTime end { get; set; }
        public string ack2 { get; set; }
        public string year { get; set; }
        public List<object> _tags { get; set; }
        public string _uuid { get; set; }
        public string month { get; set; }
        public DateTime start { get; set; }
        public List<object> _notes { get; set; }
        public string BSPName { get; set; }
        public string Mstatus { get; set; }
        public bool _edited { get; set; }
        public string _status { get; set; }
        public DateTime calc_yr { get; set; }
        public string curr_yr { get; set; }
        public string village { get; set; }
        public int BSPyears { get; set; }
        public string _version { get; set; }
        public string comments { get; set; }
        public string deviceid { get; set; }
        public string district { get; set; }
        public int Numgroups { get; set; }
        public string Training2 { get; set; }
        public string Training3 { get; set; }
        public double _duration { get; set; }
        public int _xform_id { get; set; }
        public string subcounty { get; set; }
        public string PhoneNumber { get; set; }
        public List<object> _attachments { get; set; }
        public List<object> _geolocation { get; set; }
        public int _media_count { get; set; }
        public int _total_media { get; set; }
        [JsonProperty("formhub/uuid")]
        public string FormhubUuid { get; set; }
        public int TrainedInVSLA { get; set; }
        public string _submitted_by { get; set; }
        public string likebeingaBSP { get; set; }
        [JsonProperty("meta/instanceID")]
        public string MetaInstanceID { get; set; }
        public string BSPTrainedInVSLA { get; set; }
        public DateTime _submission_time { get; set; }
        public string _xform_id_string { get; set; }
        public string meetexpectations { get; set; }
        public string _bamboo_dataset_id { get; set; }
        [JsonProperty("training/Training1")]
        public string TrainingTraining1 { get; set; }
        public int LinkedToInputMarket { get; set; }
        public int LinkedToutputMarket { get; set; }
        public bool _media_all_received { get; set; }
        [JsonProperty("income/IncomeLivestock")]
        public string IncomeIncomeLivestock { get; set; }
        public string BSPTrainedInFee4service { get; set; }
        [JsonProperty("income/IncomeInputSales")]
        public int IncomeIncomeInputSales { get; set; }
        public int LinkedToFinancialServices { get; set; }
        public string LinkedToGovermentPrograms { get; set; }
        [JsonProperty("TrainedInAgri-preneurship")]
        public int TrainedInAgriPreneurship { get; set; }
        public int SupportedToOpenBankaccount { get; set; }
        public string SkilledInPriorityInterprise { get; set; }
        public string ReasonNotLinkedToutputMarket { get; set; }
        [JsonProperty("BSPTrainingInAgri-preneurship")]
        public string BSPTrainingInAgriPreneurship { get; set; }
        public string SupportedOnCLimateTechnoloies { get; set; }
        [JsonProperty("income/IncomeExtensionProvision")]
        public int IncomeIncomeExtensionProvision { get; set; }
        [JsonProperty("income/IncomeProduceAggregation")]
        public int IncomeIncomeProduceAggregation { get; set; }
        [JsonProperty("income/incomeSalesofTecthnology")]
        public string IncomeIncomeSalesofTecthnology { get; set; }
        public string ReasonNotLinkedToGovernmentPrograms { get; set; }
        public string ReasonNotSupportedToOpenBankaccount { get; set; }
        [JsonProperty("CompareIncome/ExtensionIncomeInCOVID")]
        public string CompareIncomeExtensionIncomeInCOVID { get; set; }
        [JsonProperty("CompareIncome/LivestockIncomeInCOVID")]
        public string CompareIncomeLivestockIncomeInCOVID { get; set; }
        public string ReasonNotSkilledInPriorityInterprise { get; set; }
        [JsonProperty("CompareIncome/InputSalesIncomeInCOVID")]
        public string CompareIncomeInputSalesIncomeInCOVID { get; set; }
        public string ReasonNotSupportedOnCLimateTechnoloies { get; set; }
        [JsonProperty("CompareIncome/ProduceAggregationIncomeInCOVID")]
        public string CompareIncomeProduceAggregationIncomeInCOVID { get; set; }
        [JsonProperty("CompareIncome/SalesofTecthnologyIncomeInCOVID")]
        public string CompareIncomeSalesofTecthnologyIncomeInCOVID { get; set; }
    }

    public class CellProfilingData
    {
        public string FO { get; set; }
        public string GPS { get; set; }
        public int _id { get; set; }
        public string sex { get; set; }
        public List<object> _tags { get; set; }
        public string _uuid { get; set; }
        public string dcode { get; set; }
        public int Market { get; set; }
        public string Parish { get; set; }
        public List<object> _notes { get; set; }
        public string Cell_ID { get; set; }
        public int Num_HHs { get; set; }
        public string Village { get; set; }
        public bool _edited { get; set; }
        public string _status { get; set; }
        public string Cell_Num { get; set; }
        public string District { get; set; }
        public int Num_Eres { get; set; }
        public int Pschools { get; set; }
        public int Sschools { get; set; }
        public string _version { get; set; }
        public int Hfacility { get; set; }
        public string Subcounty { get; set; }
        public string _duration { get; set; }
        public int _xform_id { get; set; }
        public int Vinstitute { get; set; }
        public string Visit_Date { get; set; }
        public int Waterpoint { get; set; }
        // public List<MCGpartner> MCGpartners { get; set; }
        public List<object> MCGpartners { get; set; }
        public string Other_Groups { get; set; }
        public List<object> _attachments { get; set; }
        public List<double> _geolocation { get; set; }
        public int _media_count { get; set; }
        public int _total_media { get; set; }
        public string formhub_uuid { get; set; }
        public int Saving_Groups { get; set; }
        public string Villageleader { get; set; }
        public string _submitted_by { get; set; }
        public int NumMCGPartners { get; set; }
        public string NumVSLAPartners { get; set; }
        public string meta_instanceID { get; set; }
        public DateTime _submission_time { get; set; }
        public string _xform_id_string { get; set; }
        public string MCGpartners_count { get; set; }
        public int MotherCare_Groups { get; set; }
        public string Othergroups_count { get; set; }
        public string Production_Groups { get; set; }
        public string _bamboo_dataset_id { get; set; }
        public bool _media_all_received { get; set; }
        public string Savingpartners_count { get; set; }
        public string Funeralinsurance_Groups { get; set; }
    }

    public class CGAssessmentData
    {
        public int _id { get; set; }
        public List<object> _tags { get; set; }
        public string _uuid { get; set; }
        public string Qn_gps { get; set; }
        public List<object> _notes { get; set; }
        public string Qn_A_a1 { get; set; }
        public string Qn_A_a2 { get; set; }
        public string Qn_A_a3 { get; set; }
        public string Qn_A_a4 { get; set; }
        public string Qn_A_a5 { get; set; }
        public string Qn_A_a6 { get; set; }
        public string Qn_A_a7 { get; set; }
        public string Qn_A_a8 { get; set; }
        public string Qn_A_a9 { get; set; }
        public string Qn_B_b1 { get; set; }
        public string Qn_B_b2 { get; set; }
        public string Qn_B_b3 { get; set; }
        public string Qn_B_b7 { get; set; }
        public string Qn_D_d1 { get; set; }
        public string Qn_D_d5 { get; set; }
        public string Qn_D_d7 { get; set; }
        public string Qn_D_d8 { get; set; }
        public int Qn_D_d9 { get; set; }
        public string Qn_E_e1 { get; set; }
        public string Qn_E_e3 { get; set; }
        public string Qn_E_e5 { get; set; }
        public string Qn_E_e7 { get; set; }
        public string Qn_E_e9 { get; set; }
        public string Qn_ack2 { get; set; }
        public bool _edited { get; set; }
        public string _status { get; set; }
        public string Qn_A_a10 { get; set; }
        public string Qn_A_a11 { get; set; }
        public string Qn_A_a12 { get; set; }
        public string Qn_A_a13 { get; set; }
        public string Qn_A_a14 { get; set; }
        public string Qn_A_a15 { get; set; }
        public string Qn_A_a16 { get; set; }
        public string Qn_D_d10 { get; set; }
        public string Qn_D_d11 { get; set; }
        public string Qn_D_d12 { get; set; }
        public string Qn_D_d13 { get; set; }
        public string Qn_D_d14 { get; set; }
        public string Qn_D_d16 { get; set; }
        public string Qn_D_d19 { get; set; }
        public string Qn_E_e11 { get; set; }
        public string Qn_E_e12 { get; set; }
        public string Qn_E_e13 { get; set; }
        public string Qn_E_e14 { get; set; }
        public string Qn_E_e15 { get; set; }
        public string Qn_E_e16 { get; set; }
        public string Qn_E_e17 { get; set; }
        public string Qn_E_e19 { get; set; }
        public string Qn_E_e21 { get; set; }
        public string _version { get; set; }
        public double _duration { get; set; }
        public int _xform_id { get; set; }
        public string fieldteam { get; set; }
        public string Qn_scorea1 { get; set; }
        public string Qn_scorea2 { get; set; }
        public string Qn_scorea3 { get; set; }
        public string Qn_scorea4 { get; set; }
        public string Qn_scorea5 { get; set; }
        public string Qn_scorea6 { get; set; }
        public string Qn_comments { get; set; }
        public string Qn_gv_scheme { get; set; }
        public DateTime Qn_intro_end { get; set; }
        public string Qn_intro_id1 { get; set; }
        public string Qn_intro_id2 { get; set; }
        public string Qn_intro_id3 { get; set; }
        public string Qn_intro_loc { get; set; }
        public int Qn_intro_tel { get; set; }
        public List<object> _attachments { get; set; }
        public List<double> _geolocation { get; set; }
        public int _media_count { get; set; }
        public int _total_media { get; set; }
        public string formhub_uuid { get; set; }
        public string Qn_gv_grptype { get; set; }
        public string _submitted_by { get; set; }
        public DateTime Qn_intro_start { get; set; }
        public string Qn_gv_contr_mem { get; set; }
        public string meta_instanceID { get; set; }
        public int Qn_gv_contr_seat { get; set; }
        public string Qn_gv_sav_scheme { get; set; }
        public DateTime _submission_time { get; set; }
        public string _xform_id_string { get; set; }
        public string Qn_intro_ass_date { get; set; }
        public string Qn_intro_deviceid { get; set; }
        public string Qn_intro_form_date { get; set; }
        public string Qn_intro_groupname { get; set; }
        public string Qn_intro_grouppost { get; set; }
        public string Qn_intro_maleyouth { get; set; }
        public string _bamboo_dataset_id { get; set; }
        public string Qn_intro_loc_parish { get; set; }
        public string Qn_intro_loc_region { get; set; }
        public int Qn_intro_maleadults { get; set; }
        public bool _media_all_received { get; set; }
        public string Qn_intro_altcontact1 { get; set; }
        public string Qn_intro_altcontact2 { get; set; }
        public string Qn_intro_femaleyouth { get; set; }
        public int Qn_intro_femaleadults { get; set; }
        public string Qn_intro_loc_district { get; set; }
        public string Qn_intro_contactperson { get; set; }
        public string Qn_intro_loc_subcounty { get; set; }
    }

    public class COMMUNITYGROUPSummaryVer5Data
    {
        public string fo { get; set; }
        public string tr { get; set; }
        public int _id { get; set; }
        public DateTime end { get; set; }
        public string ack2 { get; set; }
        public string acty { get; set; }
        public string year { get; set; }
        public List<object> _tags { get; set; }
        public string _uuid { get; set; }
        public string image { get; set; }
        public int maleA { get; set; }
        public string maleY { get; set; }
        public string month { get; set; }
        public DateTime start { get; set; }
        public List<object> _notes { get; set; }
        public bool _edited { get; set; }
        public string _status { get; set; }
        public DateTime calc_yr { get; set; }
        public string curr_yr { get; set; }
        public int femaleA { get; set; }
        public string femaleY { get; set; }
        public string village { get; set; }
        public string _version { get; set; }
        public string comments { get; set; }
        public string deviceid { get; set; }
        public string district { get; set; }
        public double _duration { get; set; }
        public int _xform_id { get; set; }
        public string subcounty { get; set; }
        //public List<Attachment> _attachments { get; set; }
        public List<object> _geolocation { get; set; }
        public int _media_count { get; set; }
        public int _total_media { get; set; }
        [JsonProperty("formhub/uuid")]
        public string FormhubUuid { get; set; }
        public string _submitted_by { get; set; }
        [JsonProperty("meta/instanceID")]
        public string MetaInstanceID { get; set; }
        public DateTime _submission_time { get; set; }
        public string _xform_id_string { get; set; }
        [JsonProperty("location/groupid")]
        public string LocationGroupid { get; set; }
        public string _bamboo_dataset_id { get; set; }
        [JsonProperty("location/groupname")]
        public string LocationGroupname { get; set; }
        public bool _media_all_received { get; set; }
    }

    public class CRCWeeklySummaryVer4Data
    {
        public string fo { get; set; }
        public int _id { get; set; }
        public DateTime end { get; set; }
        public string ack2 { get; set; }
        public int boys { get; set; }
        public string year { get; set; }
        public List<object> _tags { get; set; }
        public string _uuid { get; set; }
        public int girls { get; set; }
        public string image { get; set; }
        public string month { get; set; }
        public DateTime start { get; set; }
        public string topic { get; set; }
        public List<object> _notes { get; set; }
        public string patron { get; set; }
        public bool _edited { get; set; }
        public string _status { get; set; }
        public DateTime calc_yr { get; set; }
        public string curr_yr { get; set; }
        public string village { get; set; }
        public string _version { get; set; }
        public string comments { get; set; }
        public string deviceid { get; set; }
        public string district { get; set; }
        public double _duration { get; set; }
        public int _xform_id { get; set; }
        public string subcounty { get; set; }
        //public List<Attachment> _attachments { get; set; }
        public List<object> _geolocation { get; set; }
        public int _media_count { get; set; }
        public int _total_media { get; set; }
        [JsonProperty("formhub/uuid")]
        public string FormhubUuid { get; set; }
        public string _submitted_by { get; set; }
        [JsonProperty("location/school")]
        public string LocationSchool { get; set; }
        [JsonProperty("meta/instanceID")]
        public string MetaInstanceID { get; set; }
        public DateTime _submission_time { get; set; }
        public string _xform_id_string { get; set; }
        [JsonProperty("location/clubname")]
        public string LocationClubname { get; set; }
        public string _bamboo_dataset_id { get; set; }
        public bool _media_all_received { get; set; }
        [JsonProperty("location/schoolname")]
        public string LocationSchoolname { get; set; }
    }

    public class EreProfilingData
    {
        public string FO { get; set; }
        public string Ere { get; set; }
        public string GPS { get; set; }
        public int _id { get; set; }
        public string sex { get; set; }
        public List<object> _tags { get; set; }
        public string _uuid { get; set; }
        public string EreNum { get; set; }
        public string Ere_ID { get; set; }
        public string Parish { get; set; }
        public List<object> _notes { get; set; }
        public string Cell_ID { get; set; }
        public int Num_HHs { get; set; }
        public string Village { get; set; }
        public bool _edited { get; set; }
        public string _status { get; set; }
        public string District { get; set; }
        public string _version { get; set; }
        public string Subcounty { get; set; }
        public string _duration { get; set; }
        public int _xform_id { get; set; }
        public string Visit_Date { get; set; }
        public List<object> _attachments { get; set; }
        public List<double> _geolocation { get; set; }
        public int _media_count { get; set; }
        public int _total_media { get; set; }
        [JsonProperty("formhub/uuid")]
        public string FormhubUuid { get; set; }
        public string Villageleader { get; set; }
        public string _submitted_by { get; set; }
        [JsonProperty("meta/instanceID")]
        public string MetaInstanceID { get; set; }
        public DateTime _submission_time { get; set; }
        public string _xform_id_string { get; set; }
        public string _bamboo_dataset_id { get; set; }
        public bool _media_all_received { get; set; }
        public string phonecontact { get; set; }
    }

    public class EventTracker2Data
    {
        public int _id { get; set; }
        public DateTime end { get; set; }
        public string gps { get; set; }
        public string id1 { get; set; }
        public string id2 { get; set; }
        public string id3 { get; set; }
        public string loc { get; set; }
        public string vip { get; set; }
        public string ack2 { get; set; }
        public List<object> _tags { get; set; }
        public string _uuid { get; set; }
        public string @event { get; set; }
        public DateTime start { get; set; }
        public List<object> _notes { get; set; }
        public bool _edited { get; set; }
        public string _status { get; set; }
        public string _version { get; set; }
        public string comments { get; set; }
        public string deviceid { get; set; }
        public string location { get; set; }
        public object services { get; set; }
        public double _duration { get; set; }
        public int _xform_id { get; set; }
        public string fieldteam { get; set; }
        public string event_date { get; set; }
        public string loc_parish { get; set; }
        public string loc_region { get; set; }
        public string serv_count { get; set; }
        public string event_other { get; set; }
        //public List<Attachment> _attachments { get; set; }
        public List<double> _geolocation { get; set; }
        public int _media_count { get; set; }
        public int _total_media { get; set; }
        [JsonProperty("formhub/uuid")]
        public string FormhubUuid { get; set; }
        public string loc_district { get; set; }
        public string _submitted_by { get; set; }
        public string loc_subcounty { get; set; }
        [JsonProperty("vpersons/name1")]
        public string VpersonsName1 { get; set; }
        [JsonProperty("vpersons/name2")]
        public string VpersonsName2 { get; set; }
        [JsonProperty("meta/instanceID")]
        public string MetaInstanceID { get; set; }
        [JsonProperty("vpersons/title1")]
        public string VpersonsTitle1 { get; set; }
        [JsonProperty("vpersons/title2")]
        public string VpersonsTitle2 { get; set; }
        public DateTime _submission_time { get; set; }
        public string _xform_id_string { get; set; }
        public string _bamboo_dataset_id { get; set; }
        public bool _media_all_received { get; set; }
        //public List<Serv> serv { get; set; }
        public string image { get; set; }
        public int? males { get; set; }
        public int? females { get; set; }
    }

    public class HHProfileData
    {
        public int _id { get; set; }
        public DateTime end { get; set; }
        public string exp { get; set; }
        public string fac { get; set; }
        public int fd4 { get; set; }
        public int fd6 { get; set; }
        public string gps { get; set; }
        public string loc { get; set; }
        public string use { get; set; }
        public string ack2 { get; set; }
        public string agri { get; set; }
        public string gpid { get; set; }
        public string use1 { get; set; }
        public List<object> _tags { get; set; }
        public string _uuid { get; set; }
        public int meals { get; set; }
        public DateTime start { get; set; }
        public List<object> _notes { get; set; }
        public bool _edited { get; set; }
        public string _status { get; set; }
        public int amt_sav { get; set; }
        public string foodgrp { get; set; }
        public string hh_head { get; set; }
        public int mem_num { get; set; }
        public string pr_date { get; set; }
        public string srcfood { get; set; }
        public string _version { get; set; }
        public string deviceid { get; set; }
        public string fm_count { get; set; }
        public string gvt_govt { get; set; }
        public string hhs_hhs1 { get; set; }
        public string hhs_hhs2 { get; set; }
        public string hhs_hhs3 { get; set; }
        public string hhs_hhs4 { get; set; }
        public string hhs_hhs5 { get; set; }
        public string hhs_hhs6 { get; set; }
        public string hhs_hhs7 { get; set; }
        public string hhs_hhs8 { get; set; }
        public string hhs_hhs9 { get; set; }
        public double _duration { get; set; }
        public int _xform_id { get; set; }
        public string fieldteam { get; set; }
        public string hhs_hhs1a { get; set; }
        public string hhs_hhs2a { get; set; }
        public string hhs_hhs3a { get; set; }
        public string hhs_hhs4a { get; set; }
        public string hhs_hhs5a { get; set; }
        public string hhs_hhs6a { get; set; }
        public string hhs_hhs7a { get; set; }
        public string hhs_hhs9a { get; set; }
        public string loc_parish { get; set; }
        public string loc_region { get; set; }
        public string src_income { get; set; }
        public List<object> _attachments { get; set; }
        public List<double> _geolocation { get; set; }
        public int _media_count { get; set; }
        public int _total_media { get; set; }
        public string agi_aginputs { get; set; }
        public string formhub_uuid { get; set; }
        public string loc_district { get; set; }
        public string _submitted_by { get; set; }
        public string loc_subcounty { get; set; }
        public string respondent_hh1 { get; set; }
        public string respondent_hh2 { get; set; }
        public string livestock_agent { get; set; }
        public int livestock_goats { get; set; }
        public string meta_instanceID { get; set; }
        public string respondent_hhid { get; set; }
        public string respondent_q118 { get; set; }
        public string respondent_q119 { get; set; }
        public string respondent_q120 { get; set; }
        public DateTime _submission_time { get; set; }
        public string _xform_id_string { get; set; }
        public string econ_src_income1 { get; set; }
        public string econ_src_income2 { get; set; }
        public string econ_src_income3 { get; set; }
        public string econ_src_income5 { get; set; }
        public string expenditure_exp1 { get; set; }
        public string expenditure_exp5 { get; set; }
        public string expenditure_exp6 { get; set; }
        public string expenditure_exp7 { get; set; }
        public string livestock_assets { get; set; }
        public string prod_assets_prod { get; set; }
        public string respondent_fname { get; set; }
        public int respondent_hhnum { get; set; }
        public string respondent_lname { get; set; }
        public string respondent_msres { get; set; }
        public int livestock_chicken { get; set; }
        public int prod_assets_prod4 { get; set; }
        public int prod_assets_prod6 { get; set; }
        public int prod_assets_prod7 { get; set; }
        public int respondent_ageres { get; set; }
        public string respondent_sexres { get; set; }
        public string _bamboo_dataset_id { get; set; }
        public string respondent_educres { get; set; }
        public bool _media_all_received { get; set; }
        public int respondent_phoneres { get; set; }
        public string hh_decision_decision1 { get; set; }
        public string hh_decision_decision2 { get; set; }
        public string hh_decision_decision3 { get; set; }
        public string hh_decision_decision4 { get; set; }
        public string hh_decision_decision5 { get; set; }
        public string hh_decision_decision6 { get; set; }
        public string respondent_hivstatus_res { get; set; }

    }

    public class InstitutionMappingData
    {
        public int _id { get; set; }
        public List<object> _tags { get; set; }
        public string _uuid { get; set; }
        public string Qn_crc { get; set; }
        public DateTime Qn_end { get; set; }
        public string Qn_gps { get; set; }
        public string Qn_id1 { get; set; }
        public string Qn_id2 { get; set; }
        public string Qn_id3 { get; set; }
        public string Qn_loc { get; set; }
        public string Qn_pta { get; set; }
        public List<object> _notes { get; set; }
        public string Qn_ack2 { get; set; }
        public string Qn_crc1 { get; set; }
        public string Qn_type { get; set; }
        public bool _edited { get; set; }
        public string _status { get; set; }
        public DateTime Qn_start { get; set; }
        public string _version { get; set; }
        public double _duration { get; set; }
        public int _xform_id { get; set; }
        public string fieldteam { get; set; }
        //public List<QnPartner> Qn_partner { get; set; }
        public List<object> Qn_partner { get; set; }
        public string Qn_ass_date { get; set; }
        public string Qn_comments { get; set; }
        public string Qn_deviceid { get; set; }
        public object Qn_sch_male { get; set; }
        public object Qn_males_crc { get; set; }
        public string Qn_strucName { get; set; }
        public List<object> _attachments { get; set; }
        public List<double> _geolocation { get; set; }
        public int _media_count { get; set; }
        public int _total_media { get; set; }
        public string formhub_uuid { get; set; }
        public string Qn_loc_parish { get; set; }
        public string Qn_loc_region { get; set; }
        public object Qn_sch_female { get; set; }
        public string Qn_schooltype { get; set; }
        public string _submitted_by { get; set; }
        public object Qn_atten_males { get; set; }
        public string Qn_crc_partner { get; set; }
        public int Qn_females_crc { get; set; }
        public object Qn_num_partner { get; set; }
        public string Qn_loc_district { get; set; }
        public object Qn_maleteachers { get; set; }
        public string meta_instanceID { get; set; }
        public object Qn_atten_females { get; set; }
        public string Qn_loc_subcounty { get; set; }
        public string Qn_partner_count { get; set; }
        public DateTime _submission_time { get; set; }
        public string _xform_id_string { get; set; }
        public object Qn_femaleteachers { get; set; }
        public string _bamboo_dataset_id { get; set; }
        public bool _media_all_received { get; set; }
        public string Qn_func { get; set; }
        public string Qn_plan { get; set; }
        public string Qn_venue { get; set; }
        public int? Qn_mem_men { get; set; }
        public string Qn_freqmeet { get; set; }
        public int? Qn_mem_women { get; set; }
        public string Qn_typestruc { get; set; }
        public int? Qn_numVillages { get; set; }
        public object Qn_period_years { get; set; }
        public string Qn_leaders_name1 { get; set; }
        public string Qn_leaders_name2 { get; set; }
        public object Qn_leaders_contact1 { get; set; }
        public object Qn_leaders_contact2 { get; set; }
        public string Qn_leaders_position1 { get; set; }
        public string Qn_leaders_position2 { get; set; }
        public string Qn_hu { get; set; }
        public object Qn_maleVHT { get; set; }
        public object Qn_train_fp { get; set; }
        public object Qn_femaleVHT { get; set; }
        public object Qn_maleStaff { get; set; }
        public object Qn_train_nutr { get; set; }
        public int? Qn_femaleStaff { get; set; }
        public string Qn_type_other { get; set; }
        public int? Qn_male_voca { get; set; }
        public string Qn_voca_skill { get; set; }
        public int? Qn_female_voca { get; set; }
        public string Qn_period_month { get; set; }
        public string Qn_ps { get; set; }
        public string Qn_trader { get; set; }
    }

    public class mcgData
    {
        public int _id { get; set; }
        public DateTime end { get; set; }
        public string gps { get; set; }
        public string loc { get; set; }
        public string ack2 { get; set; }
        //public List<Watt> watt { get; set; }
        public List<object> watt { get; set; }
        public List<object> _tags { get; set; }
        public string _uuid { get; set; }
        public DateTime start { get; set; }
        public string venue { get; set; }
        public List<object> _notes { get; set; }
        public bool _edited { get; set; }
        public string _status { get; set; }
        public string grpname { get; set; }
        public string _version { get; set; }
        public string deviceid { get; set; }
        public double _duration { get; set; }
        public int _xform_id { get; set; }
        public string fieldteam { get; set; }
        public string loc_parish { get; set; }
        public string loc_region { get; set; }
        //public List<Attachment> _attachments { get; set; }
        public List<object> _attachments { get; set; }
        public List<double> _geolocation { get; set; }
        public int _media_count { get; set; }
        public int _total_media { get; set; }
        public string formhub_uuid { get; set; }
        public string loc_district { get; set; }
        public string _submitted_by { get; set; }
        public string activity_date { get; set; }
        public string dateFormation { get; set; }
        public string loc_subcounty { get; set; }
        public string meta_instanceID { get; set; }
        public DateTime _submission_time { get; set; }
        public string _xform_id_string { get; set; }
        public string _bamboo_dataset_id { get; set; }
        public bool _media_all_received { get; set; }
        public string comments { get; set; }
        public string image { get; set; }
    }

    public class MIYCAN_MonthlySummaryVer4Data
    {
        public int _id { get; set; }
        public DateTime end { get; set; }
        public string gps { get; set; }
        public object h20 { get; set; }
        public string id1 { get; set; }
        public string id2 { get; set; }
        public string loc { get; set; }
        public object red { get; set; }
        public string ack2 { get; set; }
        public object food { get; set; }
        public object preg { get; set; }
        //public List<Watt> watt { get; set; }
        public List<object> _tags { get; set; }
        public string _uuid { get; set; }
        public string grpid { get; set; }
        public DateTime start { get; set; }
        public string venue { get; set; }
        public int women { get; set; }
        public List<object> _notes { get; set; }
        public int lesson { get; set; }
        public object module { get; set; }
        public object serial { get; set; }
        public object yellow { get; set; }
        public bool _edited { get; set; }
        public string _status { get; set; }
        public string grpname { get; set; }
        public object washfac { get; set; }
        public string _version { get; set; }
        public string comments { get; set; }
        public string deviceid { get; set; }
        public object sessions { get; set; }
        public string vhtFname { get; set; }
        public string vhtLname { get; set; }
        public double _duration { get; set; }
        public int _xform_id { get; set; }
        public string fieldteam { get; set; }
        public object referrals { get; set; }
        public object childbirth { get; set; }
        public object childdeath { get; set; }
        public string loc_parish { get; set; }
        public string loc_region { get; set; }
        public List<object> _attachments { get; set; }
        public List<double> _geolocation { get; set; }
        public int _media_count { get; set; }
        public int _total_media { get; set; }
        [JsonProperty("formhub/uuid")]
        public string FormhubUuid { get; set; }
        public string loc_district { get; set; }
        public string mothers_dead { get; set; }
        public string _submitted_by { get; set; }
        public string activity_date { get; set; }
        public string loc_subcounty { get; set; }
        [JsonProperty("meta/instanceID")]
        public string MetaInstanceID { get; set; }
        public DateTime _submission_time { get; set; }
        public string _xform_id_string { get; set; }
        public string _bamboo_dataset_id { get; set; }
        public bool _media_all_received { get; set; }
    }

    public class refNoteData
    {
        public int _id { get; set; }
        public object age { get; set; }
        public DateTime end { get; set; }
        public string gps { get; set; }
        public string id1 { get; set; }
        public string id2 { get; set; }
        public string loc { get; set; }
        public string @ref { get; set; }
        public string sex { get; set; }
        public string ack2 { get; set; }
        public string hhid { get; set; }
        public List<object> _tags { get; set; }
        public string _uuid { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public DateTime start { get; set; }
        public string venue { get; set; }
        public List<object> _notes { get; set; }
        public object serial { get; set; }
        public bool _edited { get; set; }
        public string _status { get; set; }
        public string _version { get; set; }
        public string comments { get; set; }
        public string deviceid { get; set; }
        public string ref_date { get; set; }
        public double _duration { get; set; }
        public int _xform_id { get; set; }
        public string fieldteam { get; set; }
        public string loc_parish { get; set; }
        public string loc_region { get; set; }
        public string motherName { get; set; }
        public List<object> _attachments { get; set; }
        public List<double?> _geolocation { get; set; }
        public int _media_count { get; set; }
        public int _total_media { get; set; }
        [JsonProperty("formhub/uuid")]
        public string FormhubUuid { get; set; }
        public string loc_district { get; set; }
        public string _submitted_by { get; set; }
        public string loc_subcounty { get; set; }
        [JsonProperty("meta/instanceID")]
        public string MetaInstanceID { get; set; }
        public DateTime _submission_time { get; set; }
        public string _xform_id_string { get; set; }
        public string _bamboo_dataset_id { get; set; }
        public bool _media_all_received { get; set; }
        public string other_ref { get; set; }
        public string muac { get; set; }
        public string vhtfn { get; set; }
        public string vhtln { get; set; }
    }

    public class RMS1Data
    {
        public string ra { get; set; }
        public int _id { get; set; }
        [JsonProperty("A/Z6")]
        public string AZ6 { get; set; }
        [JsonProperty("A/Z7")]
        public string AZ7 { get; set; }
        [JsonProperty("A/Z8")]
        public string AZ8 { get; set; }
        [JsonProperty("Qn/Z4")]
        public string QnZ4 { get; set; }
        public List<object> _tags { get; set; }
        public string _uuid { get; set; }
        [JsonProperty("Qn/end")]
        public DateTime QnEnd { get; set; }
        public List<object> _notes { get; set; }
        [JsonProperty("Qn/ack2")]
        public string QnAck2 { get; set; }
        [JsonProperty("Qn/qn11")]
        public string QnQn11 { get; set; }
        [JsonProperty("Qn/qn13")]
        public string QnQn13 { get; set; }
        [JsonProperty("Qn/qn14")]
        public string QnQn14 { get; set; }
        [JsonProperty("Qn/qn15")]
        public string QnQn15 { get; set; }
        [JsonProperty("Qn/qn16")]
        public string QnQn16 { get; set; }
        public bool _edited { get; set; }
        public string _status { get; set; }
        public string village { get; set; }
        [JsonProperty("Qn/qn121")]
        public int QnQn121 { get; set; }
        public string _version { get; set; }
        public string district { get; set; }
        public string _duration { get; set; }
        public int _xform_id { get; set; }
        public string subcounty { get; set; }
        [JsonProperty("Qn/comments")]
        public string QnComments { get; set; }
        [JsonProperty("Qn/ack_noteM")]
        public string QnAckNoteM { get; set; }
        [JsonProperty("Qn/signature")]
        public string QnSignature { get; set; }
        //public List<Attachment> _attachments { get; set; }
        public List<double> _geolocation { get; set; }
        public int _media_count { get; set; }
        public int _total_media { get; set; }
        [JsonProperty("formhub/uuid")]
        public string FormhubUuid { get; set; }
        [JsonProperty("Qn/qn16_times")]
        public object QnQn16Times { get; set; }
        public string _submitted_by { get; set; }
        [JsonProperty("Qn/qn16_seasons")]
        public int QnQn16Seasons { get; set; }
        [JsonProperty("meta/instanceID")]
        public string MetaInstanceID { get; set; }
        [JsonProperty("Qn/sectionc/qn21")]
        public double QnSectioncQn21 { get; set; }
        [JsonProperty("Qn/sectionc/qn22")]
        public string QnSectioncQn22 { get; set; }
        [JsonProperty("Qn/sectionc/qn23")]
        public string QnSectioncQn23 { get; set; }
        [JsonProperty("Qn/sectionc/qn24")]
        public int QnSectioncQn24 { get; set; }
        [JsonProperty("Qn/sectionc/qn25")]
        public string QnSectioncQn25 { get; set; }
        [JsonProperty("Qn/sectionc/qn27")]
        public object QnSectioncQn27 { get; set; }
        [JsonProperty("Qn/sectionc/qn28")]
        public string QnSectioncQn28 { get; set; }
        [JsonProperty("Qn/sectionc/qn29")]
        public string QnSectioncQn29 { get; set; }
        [JsonProperty("Qn/sectiond/cap2")]
        public string QnSectiondCap2 { get; set; }
        public DateTime _submission_time { get; set; }
        public string _xform_id_string { get; set; }
        [JsonProperty("location/groupid")]
        public string LocationGroupid { get; set; }
        [JsonProperty("Qn/sectionc/qn210")]
        public int QnSectioncQn210 { get; set; }
        [JsonProperty("Qn/sectionc/qn211")]
        public string QnSectioncQn211 { get; set; }
        [JsonProperty("Qn/sectionc/qn212")]
        public object QnSectioncQn212 { get; set; }
        [JsonProperty("Qn/sectionc/qn216")]
        public int QnSectioncQn216 { get; set; }
        [JsonProperty("Qn/sectionc/qn221")]
        public object QnSectioncQn221 { get; set; }
        [JsonProperty("Qn/sectionc/qn251")]
        public string QnSectioncQn251 { get; set; }
        [JsonProperty("Qn/sectiond/cap14")]
        public string QnSectiondCap14 { get; set; }
        [JsonProperty("Qn/sectiond/cap17")]
        public string QnSectiondCap17 { get; set; }
        [JsonProperty("Qn/sectione/necpa")]
        public string QnSectioneNecpa { get; set; }
        [JsonProperty("Qn/sectiond/shocks")]
        public string QnSectiondShocks { get; set; }
        [JsonProperty("Qn/sectione/necpa1")]
        public string QnSectioneNecpa1 { get; set; }
        public string _bamboo_dataset_id { get; set; }
        [JsonProperty("Qn/sectiond/shocks2")]
        public string QnSectiondShocks2 { get; set; }
        public bool _media_all_received { get; set; }
        [JsonProperty("Qn/sectiond/shocks14")]
        public string QnSectiondShocks14 { get; set; }
        [JsonProperty("Qn/sectiond/shocks17")]
        public string QnSectiondShocks17 { get; set; }
        [JsonProperty("Qn/sectiond/cap4")]
        public string QnSectiondCap4 { get; set; }
        [JsonProperty("Qn/sectiond/cap9")]
        public string QnSectiondCap9 { get; set; }
        [JsonProperty("Qn/sectione/necpa3")]
        public string QnSectioneNecpa3 { get; set; }
        [JsonProperty("Qn/sectione/necpa4")]
        public string QnSectioneNecpa4 { get; set; }
        [JsonProperty("Qn/sectiond/shocks4")]
        public string QnSectiondShocks4 { get; set; }
        [JsonProperty("Qn/sectiond/shocks9")]
        public string QnSectiondShocks9 { get; set; }
        [JsonProperty("Qn/sectionc/other_qn23")]
        public string QnSectioncOtherQn23 { get; set; }
        [JsonProperty("Qn/sectionc/qn252")]
        public string QnSectioncQn252 { get; set; }
        [JsonProperty("Qn/sectione/necpa6")]
        public string QnSectioneNecpa6 { get; set; }
        [JsonProperty("Qn/sectione/necpa7")]
        public string QnSectioneNecpa7 { get; set; }
        [JsonProperty("Qn/sectionc/other_situation")]
        public string QnSectioncOtherSituation { get; set; }
        [JsonProperty("Qn/sectionc/qn213")]
        public string QnSectioncQn213 { get; set; }
        [JsonProperty("Qn/sectionc/qn254")]
        public string QnSectioncQn254 { get; set; }
        [JsonProperty("Qn/sectionc/qn256")]
        public string QnSectioncQn256 { get; set; }
        [JsonProperty("Qn/sectiond/cap18")]
        public string QnSectiondCap18 { get; set; }
        [JsonProperty("Qn/sectionc/qn2131")]
        public string QnSectioncQn2131 { get; set; }
        [JsonProperty("Qn/sectiond/shocks18")]
        public string QnSectiondShocks18 { get; set; }
        [JsonProperty("Qn/sectiond/cap6")]
        public string QnSectiondCap6 { get; set; }
        [JsonProperty("Qn/sectione/necpa2")]
        public string QnSectioneNecpa2 { get; set; }
        [JsonProperty("Qn/sectiond/shocks6")]
        public string QnSectiondShocks6 { get; set; }
        [JsonProperty("Qn/sectiond/cap1")]
        public string QnSectiondCap1 { get; set; }
        [JsonProperty("Qn/sectiond/shocks1")]
        public string QnSectiondShocks1 { get; set; }
        [JsonProperty("Qn/sectiond/cap13")]
        public string QnSectiondCap13 { get; set; }
        [JsonProperty("Qn/sectione/necpa8")]
        public string QnSectioneNecpa8 { get; set; }
        [JsonProperty("Qn/sectione/necpa9")]
        public string QnSectioneNecpa9 { get; set; }
        [JsonProperty("Qn/sectione/necpa10")]
        public string QnSectioneNecpa10 { get; set; }
        [JsonProperty("Qn/sectione/necpa13")]
        public string QnSectioneNecpa13 { get; set; }
        [JsonProperty("Qn/sectione/necpa15")]
        public string QnSectioneNecpa15 { get; set; }
        [JsonProperty("Qn/sectiond/shocks13")]
        public string QnSectiondShocks13 { get; set; }
        [JsonProperty("Qn/sectiond/cap10")]
        public string QnSectiondCap10 { get; set; }
        [JsonProperty("Qn/sectiond/shocks10")]
        public string QnSectiondShocks10 { get; set; }
        [JsonProperty("Qn/sectionc/qn255")]
        public string QnSectioncQn255 { get; set; }
        [JsonProperty("Qn/sectionc/qn258")]
        public string QnSectioncQn258 { get; set; }
        [JsonProperty("Qn/sectionc/qn253")]
        public string QnSectioncQn253 { get; set; }
        [JsonProperty("Qn/sectionc/qn231")]
        public string QnSectioncQn231 { get; set; }
        [JsonProperty("Qn/sectiond/cap15")]
        public string QnSectiondCap15 { get; set; }
        [JsonProperty("Qn/sectiond/shocks15")]
        public string QnSectiondShocks15 { get; set; }
        [JsonProperty("Qn/sectione/necpa16")]
        public string QnSectioneNecpa16 { get; set; }
        [JsonProperty("Qn/sectiond/shocks19")]
        public string QnSectiondShocks19 { get; set; }
        [JsonProperty("Qn/sectiond/cap8")]
        public string QnSectiondCap8 { get; set; }
        [JsonProperty("Qn/sectiond/cap11")]
        public string QnSectiondCap11 { get; set; }
        [JsonProperty("Qn/sectiond/shocks8")]
        public string QnSectiondShocks8 { get; set; }
        [JsonProperty("Qn/sectiond/shocks11")]
        public string QnSectiondShocks11 { get; set; }
        [JsonProperty("Qn/sectione/necpa20")]
        public string QnSectioneNecpa20 { get; set; }
        [JsonProperty("Qn/sectione/other_necpa")]
        public string QnSectioneOtherNecpa { get; set; }
        [JsonProperty("Qn/sectiond/cap5")]
        public string QnSectiondCap5 { get; set; }
        [JsonProperty("Qn/sectiond/shocks5")]
        public string QnSectiondShocks5 { get; set; }
        [JsonProperty("Qn/sectionc/qn259")]
        public string QnSectioncQn259 { get; set; }
    }

    public class ukuRegisterData
    {
        public int _id { get; set; }
        public DateTime end { get; set; }
        public string gps { get; set; }
        public string loc { get; set; }
        public string ack2 { get; set; }
        public string term { get; set; }
        public List<object> _tags { get; set; }
        public string _uuid { get; set; }
        public DateTime start { get; set; }
        public List<object> _notes { get; set; }
        public string patron { get; set; }
        public string school { get; set; }
        public bool _edited { get; set; }
        public string _status { get; set; }
        public string _version { get; set; }
        public string comments { get; set; }
        public string deviceid { get; set; }
        public double _duration { get; set; }
        public int _xform_id { get; set; }
        public string fieldteam { get; set; }
        //public List<Attendance> attendance { get; set; }
        public string loc_parish { get; set; }
        public string loc_region { get; set; }
        public List<object> _attachments { get; set; }
        public List<double> _geolocation { get; set; }
        public int _media_count { get; set; }
        public int _total_media { get; set; }
        [JsonProperty("formhub/uuid")]
        public string FormhubUuid { get; set; }
        public string loc_district { get; set; }
        public string _submitted_by { get; set; }
        public string activity_date { get; set; }
        public string loc_subcounty { get; set; }
        [JsonProperty("meta/instanceID")]
        public string MetaInstanceID { get; set; }
        public DateTime _submission_time { get; set; }
        public string _xform_id_string { get; set; }
        public string _bamboo_dataset_id { get; set; }
        public bool _media_all_received { get; set; }
    }

    public class Update_Livelihood_groupData
    {
        public string fo { get; set; }
        public int _id { get; set; }
        public DateTime end { get; set; }
        public string ack2 { get; set; }
        public List<object> _tags { get; set; }
        public string _uuid { get; set; }
        public string fname { get; set; }
        public string image { get; set; }
        public object maleA { get; set; }
        public object maleY { get; set; }
        public DateTime start { get; set; }
        public List<object> _notes { get; set; }
        public string saving { get; set; }
        public bool _edited { get; set; }
        public string _status { get; set; }
        public string contact { get; set; }
        public object femaleA { get; set; }
        public object femaleY { get; set; }
        public string surname { get; set; }
        public string village { get; set; }
        public string _version { get; set; }
        public string deviceid { get; set; }
        public string district { get; set; }
        public double _duration { get; set; }
        public int _xform_id { get; set; }
        public string subcounty { get; set; }
        //public List<Attachment> _attachments { get; set; }
        public List<object> _geolocation { get; set; }
        public int _media_count { get; set; }
        public int _total_media { get; set; }
        [JsonProperty("formhub/uuid")]
        public string FormhubUuid { get; set; }
        public string _submitted_by { get; set; }
        [JsonProperty("meta/instanceID")]
        public string MetaInstanceID { get; set; }
        public DateTime _submission_time { get; set; }
        public string _xform_id_string { get; set; }
        [JsonProperty("location/groupid")]
        public string LocationGroupid { get; set; }
        public string _bamboo_dataset_id { get; set; }
        [JsonProperty("location/groupname")]
        public string LocationGroupname { get; set; }
        public bool _media_all_received { get; set; }
        public string contact1 { get; set; }
        public string contact2 { get; set; }
        public string comments { get; set; }
    }

    public class Update_MIYCAN_groupData
    {
        public string fo { get; set; }
        public int _id { get; set; }
        public DateTime end { get; set; }
        public object l19 { get; set; }
        public object p19 { get; set; }
        public string ack2 { get; set; }
        public object lA19 { get; set; }
        public object pA19 { get; set; }
        public List<object> _tags { get; set; }
        public string _uuid { get; set; }
        public string fname { get; set; }
        public string image { get; set; }
        public DateTime start { get; set; }
        public List<object> _notes { get; set; }
        public string saving { get; set; }
        public bool _edited { get; set; }
        public string _status { get; set; }
        public string contact { get; set; }
        public string surname { get; set; }
        public string village { get; set; }
        public string _version { get; set; }
        public string deviceid { get; set; }
        public string district { get; set; }
        public object oth_o19f { get; set; }
        public object oth_o19m { get; set; }
        public double _duration { get; set; }
        public int _xform_id { get; set; }
        public object oth_oA19f { get; set; }
        public object oth_oA19m { get; set; }
        public string subcounty { get; set; }
        //public List<Attachment> _attachments { get; set; }
        public List<object> _attachments { get; set; }
        public List<object> _geolocation { get; set; }
        public int _media_count { get; set; }
        public int _total_media { get; set; }
        public string formhub_uuid { get; set; }
        public string _submitted_by { get; set; }
        public string meta_instanceID { get; set; }
        public DateTime _submission_time { get; set; }
        public string _xform_id_string { get; set; }
        public string location_groupid { get; set; }
        public string _bamboo_dataset_id { get; set; }
        public string location_groupname { get; set; }
        public bool _media_all_received { get; set; }
        public string contact1 { get; set; }
        public string comments { get; set; }
        public string contact2 { get; set; }
    }
}