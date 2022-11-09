using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace USAIDICANBLAZOR.Models
{
    public interface IServiceApi
    {
        Task SaveChilliData();
        Task SaveCRCData();
        Task SaveLgroupsData();
        Task SaveMCareGroupsData();
        Task SaveSampleGroupsData();
        Task SaveAGYW2020Data();
        Task SaveBSPSurveyfinalData();
        Task SaveCGAssessmentData();
        Task SavemcgData();
        Task Savevetrac2Data();
        Task SavecrcweeklysummData();
        Task SavemiycanmonSumData();
        Task SavecommgrpsumData();
        Task SaveukuregData();
        Task SavebspsurrevData();
        Task SaveUpdlivgroupData();
        Task SavemiycangroupData();
        Task SaveEreProfilingData();
        Task SaverefNoteData();
        Task SaveRMS1Data();
        Task SavecellprofilingData();
        Task SaveInstnMappgData();
        Task SavePostTestData();
        Task SaveIBS2020Data();
        Task SavevhtregData();
        Task SavecommteamregData();
        Task SaveDisMonSumm();
        Task SavemiycanmonVer5SumData();

        Task SaveTargetsData();
    }
}

