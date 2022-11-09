using USAIDICANBLAZOR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace USAIDICANBLAZOR.EmailScheduler
{
    public class EmailModel
    {
        private string SenderEmail { get; set; }
        private string SenderEmailTo { get; set; }
        private string SenderEmailToCopy { get; set; }
        private string SenderHost { get; set; }
        private string SenderPassword { get; set; }
        private int SenderPort { get; set; }
        private bool EnableSSL { get; set; }

        private USAID_ICANContext _context;
        public EmailModel(USAID_ICANContext context)
        {
            this._context = context;
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            SenderEmail = configuration.GetSection("EmailCredentials")["SenderEmail"];
            SenderEmailTo = configuration.GetSection("EmailCredentials")["SenderEmailTo"];
            SenderEmailToCopy = configuration.GetSection("EmailCredentials")["SenderEmailToCopy"];
            SenderHost = configuration.GetSection("EmailCredentials")["SenderHost"];
            SenderPassword = configuration.GetSection("EmailCredentials")["SenderPassword"];
            SenderPort = Convert.ToInt32(configuration.GetSection("EmailCredentials")["SenderPort"]);
            EnableSSL = Convert.ToBoolean(configuration.GetSection("EmailCredentials")["EnableSsl"]);
        }

        public void OnaIbs2020Email()
        {
            try
            {
                using (var message = new MailMessage(SenderEmail, SenderEmailTo))
                {
                    string m = "Dear User, <br/>" + "The above table has successfully been updated " + " " + "on this day" + " " + DateTime.Now.ToLongDateString() + " at " + DateTime.Now.ToShortTimeString();
                    message.Subject = "OnaIbs2020 Table Update" + " " + "on" + " " + DateTime.Now.ToLongDateString();
                    m += "</table> <br/> Kind Regards, <br/> Abt Associates <br/> " + DateTime.Now + "<br/><p style='color:red;'></p>";
                    message.Body = m;
                    message.IsBodyHtml = true;
                    if (!string.IsNullOrEmpty(SenderEmailToCopy))
                    {
                        message.CC.Add(SenderEmailToCopy);
                    }

                    using (SmtpClient client = new SmtpClient
                    {
                        EnableSsl = EnableSSL,
                        Host = SenderHost,
                        Port = SenderPort,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new NetworkCredential(SenderEmail, SenderPassword)
                    })
                    {
                        client.Send(message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void OnaPosttestAgywEmail()
        {
            try
            {
                using (var message = new MailMessage(SenderEmail, SenderEmailTo))
                {
                    string m = "Dear User, <br/>" + "The above table has successfully been updated " + " " + "on this day" + " " + DateTime.Now.ToLongDateString() + " at " + DateTime.Now.ToShortTimeString();
                    message.Subject = "OnaPosttestAgyw Table Update" + " " + "on" + " " + DateTime.Now.ToLongDateString();
                    m += "</table> <br/> Kind Regards, <br/> Abt Associates <br/> " + DateTime.Now + "<br/><p style='color:red;'></p>";
                    message.Body = m;
                    message.IsBodyHtml = true;
                    if (!string.IsNullOrEmpty(SenderEmailToCopy))
                    {
                        message.CC.Add(SenderEmailToCopy);
                    }
                    using (SmtpClient client = new SmtpClient
                    {
                        EnableSsl = EnableSSL,
                        Host = SenderHost,
                        Port = SenderPort,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new NetworkCredential(SenderEmail, SenderPassword)
                    })
                    {
                        client.Send(message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Ona1ChilligrpsEmail()
        {
            try
            {
                using (var message = new MailMessage(SenderEmail, SenderEmailTo))
                {
                    string m = "Dear User, <br/>" + "The above table has successfully been updated " + " " + "on this day" + " " + DateTime.Now.ToLongDateString() + " at " + DateTime.Now.ToShortTimeString();
                    message.Subject = "Ona1Chilligrps Table Update" + " " + "on" + " " + DateTime.Now.ToLongDateString();
                    m += "</table> <br/> Kind Regards, <br/> Abt Associates <br/> " + DateTime.Now + "<br/><p style='color:red;'></p>";
                    message.Body = m;
                    message.IsBodyHtml = true;
                    if (!string.IsNullOrEmpty(SenderEmailToCopy))
                    {
                        message.CC.Add(SenderEmailToCopy);
                    }
                    using (SmtpClient client = new SmtpClient
                    {
                        EnableSsl = EnableSSL,
                        Host = SenderHost,
                        Port = SenderPort,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new NetworkCredential(SenderEmail, SenderPassword)
                    })
                    {
                        client.Send(message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Ona1CRCEmail()
        {
            try
            {
                using (var message = new MailMessage(SenderEmail, SenderEmailTo))
                {
                    string m = "Dear User, <br/>" + "The above table has successfully been updated " + " " + "on this day" + " " + DateTime.Now.ToLongDateString() + " at " + DateTime.Now.ToShortTimeString();
                    message.Subject = "Ona1CRC Table Update" + " " + "on" + " " + DateTime.Now.ToLongDateString();
                    m += "</table> <br/> Kind Regards, <br/> Abt Associates <br/> " + DateTime.Now + "<br/><p style='color:red;'></p>";
                    message.Body = m;
                    message.IsBodyHtml = true;
                    if (!string.IsNullOrEmpty(SenderEmailToCopy))
                    {
                        message.CC.Add(SenderEmailToCopy);
                    }
                    using (SmtpClient client = new SmtpClient
                    {
                        EnableSsl = EnableSSL,
                        Host = SenderHost,
                        Port = SenderPort,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new NetworkCredential(SenderEmail, SenderPassword)
                    })
                    {
                        client.Send(message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Ona1LgroupsEmail()
        {
            try
            {
                using (var message = new MailMessage(SenderEmail, SenderEmailTo))
                
                {
                    string m = "Dear User, <br/>" + "The above table has successfully been updated " + " " + "on this day" + " " + DateTime.Now.ToLongDateString() + " at " + DateTime.Now.ToShortTimeString();
                    message.Subject = "Ona1Lgroups Table Update" + " " + "on" + " " + DateTime.Now.ToLongDateString();
                    m += "</table> <br/> Kind Regards, <br/> Abt Associates <br/> " + DateTime.Now + "<br/><p style='color:red;'></p>";
                    message.Body = m;
                    message.IsBodyHtml = true;
                    if (!string.IsNullOrEmpty(SenderEmailToCopy))
                    {
                        message.CC.Add(SenderEmailToCopy);
                    }
                    using (SmtpClient client = new SmtpClient
                    {
                        EnableSsl = EnableSSL,
                        Host = SenderHost,
                        Port = SenderPort,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new NetworkCredential(SenderEmail, SenderPassword)
                    })
                    {
                        client.Send(message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Ona1McareGroupsEmail()
        {
            try
            {
                using (var message = new MailMessage(SenderEmail, SenderEmailTo))
                {
                    string m = "Dear User, <br/>" + "The above table has successfully been updated " + " " + "on this day" + " " + DateTime.Now.ToLongDateString() + " at " + DateTime.Now.ToShortTimeString();
                    message.Subject = "Ona1McareGroups Table Update" + " " + "on" + " " + DateTime.Now.ToLongDateString();
                    m += "</table> <br/> Kind Regards, <br/> Abt Associates <br/> " + DateTime.Now + "<br/><p style='color:red;'></p>";
                    message.Body = m;
                    message.IsBodyHtml = true;
                    if (!string.IsNullOrEmpty(SenderEmailToCopy))
                    {
                        message.CC.Add(SenderEmailToCopy);
                    }
                    using (SmtpClient client = new SmtpClient
                    {
                        EnableSsl = EnableSSL,
                        Host = SenderHost,
                        Port = SenderPort,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new NetworkCredential(SenderEmail, SenderPassword)
                    })
                    {
                        client.Send(message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
 
        public void Ona1samplegrpsEmail()
        {
            try
            {
                using (var message = new MailMessage(SenderEmail, SenderEmailTo))
                {
                    string m = "Dear User, <br/>" + "The above table has successfully been updated " + " " + "on this day" + " " + DateTime.Now.ToLongDateString() + " at " + DateTime.Now.ToShortTimeString();
                    message.Subject = "Ona1samplegrps Table Update" + " " + "on" + " " + DateTime.Now.ToLongDateString();
                    m += "</table> <br/> Kind Regards, <br/> Abt Associates <br/> " + DateTime.Now + "<br/><p style='color:red;'></p>";
                    message.Body = m;
                    message.IsBodyHtml = true;
                    if (!string.IsNullOrEmpty(SenderEmailToCopy))
                    {
                        message.CC.Add(SenderEmailToCopy);
                    }
                    using (SmtpClient client = new SmtpClient
                    {
                        EnableSsl = EnableSSL,
                        Host = SenderHost,
                        Port = SenderPort,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new NetworkCredential(SenderEmail, SenderPassword)
                    })
                    {
                        client.Send(message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
 
        public void OnaAgyw2020Email()
        {
            try
            {
                using (var message = new MailMessage(SenderEmail, SenderEmailTo))
                {
                    string m = "Dear User, <br/>" + "The above table has successfully been updated " + " " + "on this day" + " " + DateTime.Now.ToLongDateString() + " at " + DateTime.Now.ToShortTimeString();
                    message.Subject = "OnaAgyw2020 Table Update" + " " + "on" + " " + DateTime.Now.ToLongDateString();
                    m += "</table> <br/> Kind Regards, <br/> Abt Associates <br/> " + DateTime.Now + "<br/><p style='color:red;'></p>";
                    message.Body = m;
                    message.IsBodyHtml = true;
                    if (!string.IsNullOrEmpty(SenderEmailToCopy))
                    {
                        message.CC.Add(SenderEmailToCopy);
                    }
                    using (SmtpClient client = new SmtpClient
                    {
                        EnableSsl = EnableSSL,
                        Host = SenderHost,
                        Port = SenderPort,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new NetworkCredential(SenderEmail, SenderPassword)
                    })
                    {
                        client.Send(message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void OnaBspSurveyFinalEmail()
        {
            try
            {
                using (var message = new MailMessage(SenderEmail, SenderEmailTo))
                {
                    string m = "Dear User, <br/>" + "The above table has successfully been updated " + " " + "on this day" + " " + DateTime.Now.ToLongDateString() + " at " + DateTime.Now.ToShortTimeString();
                    message.Subject = "OnaBspSurveyFinal Table Update" + " " + "on" + " " + DateTime.Now.ToLongDateString();
                    m += "</table> <br/> Kind Regards, <br/> Abt Associates <br/> " + DateTime.Now + "<br/><p style='color:red;'></p>";
                    message.Body = m;
                    message.IsBodyHtml = true;
                    if (!string.IsNullOrEmpty(SenderEmailToCopy))
                    {
                        message.CC.Add(SenderEmailToCopy);
                    }
                    using (SmtpClient client = new SmtpClient
                    {
                        EnableSsl = EnableSSL,
                        Host = SenderHost,
                        Port = SenderPort,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new NetworkCredential(SenderEmail, SenderPassword)
                    })
                    {
                        client.Send(message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void OnaBspSurveyRevisedEmail()
        {
            try
            {
                using (var message = new MailMessage(SenderEmail, SenderEmailTo))
                {
                    string m = "Dear User, <br/>" + "The above table has successfully been updated " + " " + "on this day" + " " + DateTime.Now.ToLongDateString() + " at " + DateTime.Now.ToShortTimeString();
                    message.Subject = "OnaBspSurveyRevised Table Update" + " " + "on" + " " + DateTime.Now.ToLongDateString();
                    m += "</table> <br/> Kind Regards, <br/> Abt Associates <br/> " + DateTime.Now + "<br/><p style='color:red;'></p>";
                    message.Body = m;
                    message.IsBodyHtml = true;
                    if (!string.IsNullOrEmpty(SenderEmailToCopy))
                    {
                        message.CC.Add(SenderEmailToCopy);
                    }
                    using (SmtpClient client = new SmtpClient
                    {
                        EnableSsl = EnableSSL,
                        Host = SenderHost,
                        Port = SenderPort,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new NetworkCredential(SenderEmail, SenderPassword)
                    })
                    {
                        client.Send(message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void OnaCellProfilingEmail()
        {
            try
            {
                using (var message = new MailMessage(SenderEmail, SenderEmailTo))
                {
                    string m = "Dear User, <br/>" + "The above table has successfully been updated " + " " + "on this day" + " " + DateTime.Now.ToLongDateString() + " at " + DateTime.Now.ToShortTimeString();
                    message.Subject = "OnaCellProfiling Table Update" + " " + "on" + " " + DateTime.Now.ToLongDateString();
                    m += "</table> <br/> Kind Regards, <br/> Abt Associates <br/> " + DateTime.Now + "<br/><p style='color:red;'></p>";
                    message.Body = m;
                    message.IsBodyHtml = true;
                    if (!string.IsNullOrEmpty(SenderEmailToCopy))
                    {
                        message.CC.Add(SenderEmailToCopy);
                    }
                    using (SmtpClient client = new SmtpClient
                    {
                        EnableSsl = EnableSSL,
                        Host = SenderHost,
                        Port = SenderPort,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new NetworkCredential(SenderEmail, SenderPassword)
                    })
                    {
                        client.Send(message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
 
        public void OnaCgAssessmentEmail()
        {
            try
            {
                using (var message = new MailMessage(SenderEmail, SenderEmailTo))
                {
                    string m = "Dear User, <br/>" + "The above table has successfully been updated " + " " + "on this day" + " " + DateTime.Now.ToLongDateString() + " at " + DateTime.Now.ToShortTimeString();
                    message.Subject = "OnaCgAssessment Table Update" + " " + "on" + " " + DateTime.Now.ToLongDateString();
                    m += "</table> <br/> Kind Regards, <br/> Abt Associates <br/> " + DateTime.Now + "<br/><p style='color:red;'></p>";
                    message.Body = m;
                    message.IsBodyHtml = true;
                    if (!string.IsNullOrEmpty(SenderEmailToCopy))
                    {
                        message.CC.Add(SenderEmailToCopy);
                    }
                    using (SmtpClient client = new SmtpClient
                    {
                        EnableSsl = EnableSSL,
                        Host = SenderHost,
                        Port = SenderPort,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new NetworkCredential(SenderEmail, SenderPassword)
                    })
                    {
                        client.Send(message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void OnaCommunitygroupSummary2021Email()
        {
            try
            {
                using (var message = new MailMessage(SenderEmail, SenderEmailTo))
                {
                    string m = "Dear User, <br/>" + "The above table has successfully been updated " + " " + "on this day" + " " + DateTime.Now.ToLongDateString() + " at " + DateTime.Now.ToShortTimeString();
                    message.Subject = "OnaCommunitygroupSummary2021 Table Update" + " " + "on" + " " + DateTime.Now.ToLongDateString();
                    m += "</table> <br/> Kind Regards, <br/> Abt Associates <br/> " + DateTime.Now + "<br/><p style='color:red;'></p>";
                    message.Body = m;
                    message.IsBodyHtml = true;
                    if (!string.IsNullOrEmpty(SenderEmailToCopy))
                    {
                        message.CC.Add(SenderEmailToCopy);
                    }
                    using (SmtpClient client = new SmtpClient
                    {
                        EnableSsl = EnableSSL,
                        Host = SenderHost,
                        Port = SenderPort,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new NetworkCredential(SenderEmail, SenderPassword)
                    })
                    {
                        client.Send(message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void OnaCrcWeeklySummaryVer4Email()
        {
            try
            {
                using (var message = new MailMessage(SenderEmail, SenderEmailTo))
                {
                    string m = "Dear User, <br/>" + "The above table has successfully been updated " + " " + "on this day" + " " + DateTime.Now.ToLongDateString() + " at " + DateTime.Now.ToShortTimeString();
                    message.Subject = "OnaCrcWeeklySummaryVer4 Table Update" + " " + "on" + " " + DateTime.Now.ToLongDateString();
                    m += "</table> <br/> Kind Regards, <br/> Abt Associates <br/> " + DateTime.Now + "<br/><p style='color:red;'></p>";
                    message.Body = m;
                    message.IsBodyHtml = true;
                    if (!string.IsNullOrEmpty(SenderEmailToCopy))
                    {
                        message.CC.Add(SenderEmailToCopy);
                    }
                    using (SmtpClient client = new SmtpClient
                    {
                        EnableSsl = EnableSSL,
                        Host = SenderHost,
                        Port = SenderPort,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new NetworkCredential(SenderEmail, SenderPassword)
                    })
                    {
                        client.Send(message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void OnaEreProfilingEmail()
        {
            try
            {
                using (var message = new MailMessage(SenderEmail, SenderEmailTo))
                {
                    string m = "Dear User, <br/>" + "The above table has successfully been updated " + " " + "on this day" + " " + DateTime.Now.ToLongDateString() + " at " + DateTime.Now.ToShortTimeString();
                    message.Subject = "OnaEreProfiling Table Update" + " " + "on" + " " + DateTime.Now.ToLongDateString();
                    m += "</table> <br/> Kind Regards, <br/> Abt Associates <br/> " + DateTime.Now + "<br/><p style='color:red;'></p>";
                    message.Body = m;
                    message.IsBodyHtml = true;
                    if (!string.IsNullOrEmpty(SenderEmailToCopy))
                    {
                        message.CC.Add(SenderEmailToCopy);
                    }
                    using (SmtpClient client = new SmtpClient
                    {
                        EnableSsl = EnableSSL,
                        Host = SenderHost,
                        Port = SenderPort,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new NetworkCredential(SenderEmail, SenderPassword)
                    })
                    {
                        client.Send(message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void OnaEventTracker2Email()
        {
            try
            {
                using (var message = new MailMessage(SenderEmail, SenderEmailTo))
                {
                    string m = "Dear User, <br/>" + "The above table has successfully been updated " + " " + "on this day" + " " + DateTime.Now.ToLongDateString() + " at " + DateTime.Now.ToShortTimeString();
                    message.Subject = "OnaEventTracker2 Table Update" + " " + "on" + " " + DateTime.Now.ToLongDateString();
                    m += "</table> <br/> Kind Regards, <br/> Abt Associates <br/> " + DateTime.Now + "<br/><p style='color:red;'></p>";
                    message.Body = m;
                    message.IsBodyHtml = true;
                    if (!string.IsNullOrEmpty(SenderEmailToCopy))
                    {
                        message.CC.Add(SenderEmailToCopy);
                    }
                    using (SmtpClient client = new SmtpClient
                    {
                        EnableSsl = EnableSSL,
                        Host = SenderHost,
                        Port = SenderPort,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new NetworkCredential(SenderEmail, SenderPassword)
                    })
                    {
                        client.Send(message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void OnaInstitutionMappingEmail()
        {
            try
            {
                using (var message = new MailMessage(SenderEmail, SenderEmailTo))
                {
                    string m = "Dear User, <br/>" + "The above table has successfully been updated " + " " + "on this day" + " " + DateTime.Now.ToLongDateString() + " at " + DateTime.Now.ToShortTimeString();
                    message.Subject = "OnaInstitutionMapping Table Update" + " " + "on" + " " + DateTime.Now.ToLongDateString();
                    m += "</table> <br/> Kind Regards, <br/> Abt Associates <br/> " + DateTime.Now + "<br/><p style='color:red;'></p>";
                    message.Body = m;
                    message.IsBodyHtml = true;
                    if (!string.IsNullOrEmpty(SenderEmailToCopy))
                    {
                        message.CC.Add(SenderEmailToCopy);
                    }
                    using (SmtpClient client = new SmtpClient
                    {
                        EnableSsl = EnableSSL,
                        Host = SenderHost,
                        Port = SenderPort,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new NetworkCredential(SenderEmail, SenderPassword)
                    })
                    {
                        client.Send(message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void OnavhtRegisterEmail()
        {
            try
            {
                using (var message = new MailMessage(SenderEmail, SenderEmailTo))
                {
                    string m = "Dear User, <br/>" + "The above table has successfully been updated " + " " + "on this day" + " " + DateTime.Now.ToLongDateString() + " at " + DateTime.Now.ToShortTimeString();
                    message.Subject = "OnavhtRegister Table Update" + " " + "on" + " " + DateTime.Now.ToLongDateString();
                    m += "</table> <br/> Kind Regards, <br/> Abt Associates <br/> " + DateTime.Now + "<br/><p style='color:red;'></p>";
                    message.Body = m;
                    message.IsBodyHtml = true;
                    if (!string.IsNullOrEmpty(SenderEmailToCopy))
                    {
                        message.CC.Add(SenderEmailToCopy);
                    }
                    using (SmtpClient client = new SmtpClient
                    {
                        EnableSsl = EnableSSL,
                        Host = SenderHost,
                        Port = SenderPort,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new NetworkCredential(SenderEmail, SenderPassword)
                    })
                    {
                        client.Send(message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void OnamcgEmail()
        {
            try
            {
                using (var message = new MailMessage(SenderEmail, SenderEmailTo))
                {
                    string m = "Dear User, <br/>" + "The above table has successfully been updated " + " " + "on this day" + " " + DateTime.Now.ToLongDateString() + " at " + DateTime.Now.ToShortTimeString();
                    message.Subject = "Onamcg Table Update" + " " + "on" + " " + DateTime.Now.ToLongDateString();
                    m += "</table> <br/> Kind Regards, <br/> Abt Associates <br/> " + DateTime.Now + "<br/><p style='color:red;'></p>";
                    message.Body = m;
                    if (!string.IsNullOrEmpty(SenderEmailToCopy))
                    {
                        message.CC.Add(SenderEmailToCopy);
                    }
                    using (SmtpClient client = new SmtpClient
                    {
                        EnableSsl = EnableSSL,
                        Host = SenderHost,
                        Port = SenderPort,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new NetworkCredential(SenderEmail, SenderPassword)
                    })
                    {
                        client.Send(message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void OnaMiycanMonthlySummaryVer4Email()
        {
            try
            {
                using (var message = new MailMessage(SenderEmail, SenderEmailTo))
                {
                    string m = "Dear User, <br/>" + "The above table has successfully been updated " + " " + "on this day" + " " + DateTime.Now.ToLongDateString() + " at " + DateTime.Now.ToShortTimeString();
                    message.Subject = "OnaMiycanMonthlySummaryVer4 Table Update" + " " + "on" + " " + DateTime.Now.ToLongDateString();
                    m += "</table> <br/> Kind Regards, <br/> Abt Associates <br/> " + DateTime.Now + "<br/><p style='color:red;'></p>";
                    message.Body = m;
                    message.IsBodyHtml = true;
                    if (!string.IsNullOrEmpty(SenderEmailToCopy))
                    {
                        message.CC.Add(SenderEmailToCopy);
                    }
                    using (SmtpClient client = new SmtpClient
                    {
                        EnableSsl = EnableSSL,
                        Host = SenderHost,
                        Port = SenderPort,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new NetworkCredential(SenderEmail, SenderPassword)
                    })
                    {
                        client.Send(message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void OnarefNoteEmail()
        {
            try
            {
                using (var message = new MailMessage(SenderEmail, SenderEmailTo))
                {
                    string m = "Dear User, <br/>" + "The above table has successfully been updated " + " " + "on this day" + " " + DateTime.Now.ToLongDateString() + " at " + DateTime.Now.ToShortTimeString();
                    message.Subject = "OnarefNote Table Update" + " " + "on" + " " + DateTime.Now.ToLongDateString();
                    m += "</table> <br/> Kind Regards, <br/> Abt Associates <br/> " + DateTime.Now + "<br/><p style='color:red;'></p>";
                    message.Body = m;
                    message.IsBodyHtml = true;
                    if (!string.IsNullOrEmpty(SenderEmailToCopy))
                    {
                        message.CC.Add(SenderEmailToCopy);
                    }
                    using (SmtpClient client = new SmtpClient
                    {
                        EnableSsl = EnableSSL,
                        Host = SenderHost,
                        Port = SenderPort,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new NetworkCredential(SenderEmail, SenderPassword)
                    })
                    {
                        client.Send(message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void OnaRms1Email()
        {
            try
            {
                using (var message = new MailMessage(SenderEmail, SenderEmailTo))
                {
                    string m = "Dear User, <br/>" + "The above table has successfully been updated " + " " + "on this day" + " " + DateTime.Now.ToLongDateString() + " at " + DateTime.Now.ToShortTimeString();
                    message.Subject = "OnaRms1 Table Update" + " " + "on" + " " + DateTime.Now.ToLongDateString();
                    m += "</table> <br/> Kind Regards, <br/> Abt Associates <br/> " + DateTime.Now + "<br/><p style='color:red;'></p>";
                    message.Body = m;
                    message.IsBodyHtml = true;
                    if (!string.IsNullOrEmpty(SenderEmailToCopy))
                    {
                        message.CC.Add(SenderEmailToCopy);
                    }
                    using (SmtpClient client = new SmtpClient
                    {
                        EnableSsl = EnableSSL,
                        Host = SenderHost,
                        Port = SenderPort,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new NetworkCredential(SenderEmail, SenderPassword)
                    })
                    {
                        client.Send(message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void OnaukuRegisterEmail()
        {
            try
            {
                using (var message = new MailMessage(SenderEmail, SenderEmailTo))
                {
                    string m = "Dear User, <br/>" + "The above table has successfully been updated " + " " + "on this day" + " " + DateTime.Now.ToLongDateString() + " at " + DateTime.Now.ToShortTimeString();
                    message.Subject = "OnaukuRegister Table Update" + " " + "on" + " " + DateTime.Now.ToLongDateString();
                    m += "</table> <br/> Kind Regards, <br/> Abt Associates <br/> " + DateTime.Now + "<br/><p style='color:red;'></p>";
                    message.Body = m;
                    message.IsBodyHtml = true;
                    if (!string.IsNullOrEmpty(SenderEmailToCopy))
                    {
                        message.CC.Add(SenderEmailToCopy);
                    }
                    using (SmtpClient client = new SmtpClient
                    {
                        EnableSsl = EnableSSL,
                        Host = SenderHost,
                        Port = SenderPort,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new NetworkCredential(SenderEmail, SenderPassword)
                    })
                    {
                        client.Send(message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
 
        public void OnaUpdateLivelihoodGroupDataEmail()
        {
            try
            {
                using (var message = new MailMessage(SenderEmail, SenderEmailTo))
                {
                    string m = "Dear User, <br/>" + "The above table has successfully been updated " + " " + "on this day" + " " + DateTime.Now.ToLongDateString() + " at " + DateTime.Now.ToShortTimeString();
                    message.Subject = "OnaUpdateLivelihoodGroupData Table Update" + " " + "on" + " " + DateTime.Now.ToLongDateString();
                    m += "</table> <br/> Kind Regards, <br/> Abt Associates <br/> " + DateTime.Now + "<br/><p style='color:red;'></p>";
                    message.Body = m;
                    message.IsBodyHtml = true;
                    if (!string.IsNullOrEmpty(SenderEmailToCopy))
                    {
                        message.CC.Add(SenderEmailToCopy);
                    }
                    using (SmtpClient client = new SmtpClient
                    {
                        EnableSsl = EnableSSL,
                        Host = SenderHost,
                        Port = SenderPort,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new NetworkCredential(SenderEmail, SenderPassword)
                    })
                    {
                        client.Send(message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void OnaUpdateMiycanGroupDataEmail()
        {
            try
            {
                using (var message = new MailMessage(SenderEmail, SenderEmailTo))
                {
                    string m = "Dear User, <br/>" + "The above table has successfully been updated " + " " + "on this day" + " " + DateTime.Now.ToLongDateString() + " at " + DateTime.Now.ToShortTimeString();
                    message.Subject = "OnaUpdateMiycanGroupData Table Update" + " " + "on" + " " + DateTime.Now.ToLongDateString();
                    m += "</table> <br/> Kind Regards, <br/> Abt Associates <br/> " + DateTime.Now + "<br/><p style='color:red;'></p>";
                    message.Body = m;
                    message.IsBodyHtml = true;
                    if (!string.IsNullOrEmpty(SenderEmailToCopy))
                    {
                        message.CC.Add(SenderEmailToCopy);
                    }
                    using (SmtpClient client = new SmtpClient
                    {
                        EnableSsl = EnableSSL,
                        Host = SenderHost,
                        Port = SenderPort,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new NetworkCredential(SenderEmail, SenderPassword)
                    })
                    {
                        client.Send(message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void OnaCommunityTeamRegisterEmail()
        {
            try
            {
                using (var message = new MailMessage(SenderEmail, SenderEmailTo))
                {
                    string m = "Dear User, <br/>" + "The above table has successfully been updated " + " " + "on this day" + " " + DateTime.Now.ToLongDateString() + " at " + DateTime.Now.ToShortTimeString();
                    message.Subject = "OnaCommunityTeamRegister Table Update" + " " + "on" + " " + DateTime.Now.ToLongDateString();
                    m += "</table> <br/> Kind Regards, <br/> Abt Associates <br/> " + DateTime.Now + "<br/><p style='color:red;'></p>";
                    message.Body = m;
                    message.IsBodyHtml = true;
                    if (!string.IsNullOrEmpty(SenderEmailToCopy))
                    {
                        message.CC.Add(SenderEmailToCopy);
                    }
                    using (SmtpClient client = new SmtpClient
                    {
                        EnableSsl = EnableSSL,
                        Host = SenderHost,
                        Port = SenderPort,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new NetworkCredential(SenderEmail, SenderPassword)
                    })
                    {
                        client.Send(message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void OnaDistrictMonthlySummaryEmail()
        {
            try
            {
                using (var message = new MailMessage(SenderEmail, SenderEmailTo))
                {
                    string m = "Dear User, <br/>" + "The above table has successfully been updated " + " " + "on this day" + " " + DateTime.Now.ToLongDateString() + " at " + DateTime.Now.ToShortTimeString();
                    message.Subject = "OnaDistrictMonthlySummary Table Update" + " " + "on" + " " + DateTime.Now.ToLongDateString();
                    m += "</table> <br/> Kind Regards, <br/> Abt Associates <br/> " + DateTime.Now + "<br/><p style='color:red;'></p>";
                    message.Body = m;
                    message.IsBodyHtml = true;
                    if (!string.IsNullOrEmpty(SenderEmailToCopy))
                    {
                        message.CC.Add(SenderEmailToCopy);
                    }
                    using (SmtpClient client = new SmtpClient
                    {
                        EnableSsl = EnableSSL,
                        Host = SenderHost,
                        Port = SenderPort,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new NetworkCredential(SenderEmail, SenderPassword)
                    })
                    {
                        client.Send(message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void OnaMiycanMonthlySummaryVer5Email()
        {
            try
            {
                using (var message = new MailMessage(SenderEmail, SenderEmailTo))
                {
                    string m = "Dear User, <br/>" + "The above table has successfully been updated " + " " + "on this day" + " " + DateTime.Now.ToLongDateString() + " at " + DateTime.Now.ToShortTimeString();
                    message.Subject = "OnaMiycanMonthlySummaryVer5 Table Update" + " " + "on" + " " + DateTime.Now.ToLongDateString();
                    m += "</table> <br/> Kind Regards, <br/> Abt Associates <br/> " + DateTime.Now + "<br/><p style='color:red;'></p>";
                    message.Body = m;
                    message.IsBodyHtml = true;
                    if (!string.IsNullOrEmpty(SenderEmailToCopy))
                    {
                        message.CC.Add(SenderEmailToCopy);
                    }
                    using (SmtpClient client = new SmtpClient
                    {
                        EnableSsl = EnableSSL,
                        Host = SenderHost,
                        Port = SenderPort,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new NetworkCredential(SenderEmail, SenderPassword)
                    })
                    {
                        client.Send(message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void OnaTargetsEmail()
        {
            try
            {
                using (var message = new MailMessage(SenderEmail, SenderEmailTo))
                {
                    string m = "Dear User, <br/>" + "The above table has successfully been updated " + " " + "on this day" + " " + DateTime.Now.ToLongDateString() + " at " + DateTime.Now.ToShortTimeString();
                    message.Subject = "OnaTargets Table Update" + " " + "on" + " " + DateTime.Now.ToLongDateString();
                    m += "</table> <br/> Kind Regards, <br/> Abt Associates <br/> " + DateTime.Now + "<br/><p style='color:red;'></p>";
                    message.Body = m;
                    message.IsBodyHtml = true;
                    if (!string.IsNullOrEmpty(SenderEmailToCopy))
                    {
                        message.CC.Add(SenderEmailToCopy);
                    }
                    using (SmtpClient client = new SmtpClient
                    {
                        EnableSsl = EnableSSL,
                        Host = SenderHost,
                        Port = SenderPort,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new NetworkCredential(SenderEmail, SenderPassword)
                    })
                    {
                        client.Send(message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ForgotPasswordEmail(string username, string emailAddress, string _message)
        {
            try
            {
                using (var message = new MailMessage(SenderEmail, emailAddress))
                {
                    message.Subject = "Dashboard System Password Reset";
                    message.Body = "Dear " + username + ",<br/><br/>" +
                            "<p> You recently requested a password reset with us.</p>" +
                            "<br/> <p>Please click <a href='" + _message + "'>here</a> to be directed to a page to reset your password. Thanks!</p>" +
                            "<br/> <br/> Regards,<br/><br/> System Notification, <br/> Integrated Community Agriculture and Nutrition Activity (USAID - ICAN).<br/><br/>" + DateTime.Now;
                    message.IsBodyHtml = true;
                    
                    using (SmtpClient client = new SmtpClient
                    {
                        EnableSsl = EnableSSL,
                        Host = SenderHost,
                        Port = SenderPort,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new NetworkCredential(SenderEmail, SenderPassword)
                    })
                    {
                        client.Send(message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
