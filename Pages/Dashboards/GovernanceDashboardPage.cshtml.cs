using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using USAIDICANBLAZOR.Data;
using USAIDICANBLAZOR.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace USAIDICANBLAZOR.Pages.Dashboards
{
    public class GovernanceDashboardPageModel : PageModel
    {
        public IWebHostEnvironment _iweb;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly USAID_ICANContext _context;

        public GovernanceDashboardPageModel(USAID_ICANContext contex, IWebHostEnvironment hostenvironment, IHttpContextAccessor httpContextAccessor)
        {
            _context = contex;
            _iweb = hostenvironment;
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetRoleName()
        {
            var username = _httpContextAccessor.HttpContext.User.Identity.Name;

            string RoleName = null;
            var person = _context.View2022UserManagement.FirstOrDefault(o => o.UserName == _httpContextAccessor.HttpContext.User.Identity.Name);
            if (person != null)
            {
                RoleName = person.NormalizedRoleName;
            }
            return RoleName;
        }

        public double? GetRegionId()
        {
            var username = _httpContextAccessor.HttpContext.User.Identity.Name;

            double? RegionId = null;
            var person = _context.View2022UserManagement.FirstOrDefault(o => o.UserName == _httpContextAccessor.HttpContext.User.Identity.Name);
            if (person != null)
            {
                RegionId = person.RegionId;
            }
            return RegionId;
        }

        public string GetRegionName()
        {
            var username = _httpContextAccessor.HttpContext.User.Identity.Name;

            string RegionName = null;
            var person = _context.View2022UserManagement.FirstOrDefault(o => o.UserName == _httpContextAccessor.HttpContext.User.Identity.Name);
            if (person != null)
            {
                RegionName = person.LocRegion;
            }
            return RegionName;
        }

        public double? GetDistrictId()
        {
            var username = _httpContextAccessor.HttpContext.User.Identity.Name;

            double? DistrictId = null;
            var person = _context.View2022UserManagement.FirstOrDefault(o => o.UserName == _httpContextAccessor.HttpContext.User.Identity.Name);
            if (person != null)
            {
                DistrictId = person.DistrictId;
            }
            return DistrictId;
        }

        public string GetDistrictName()
        {
            var username = _httpContextAccessor.HttpContext.User.Identity.Name;

            string DistrictName = null;
            var person = _context.View2022UserManagement.FirstOrDefault(o => o.UserName == _httpContextAccessor.HttpContext.User.Identity.Name);
            if (person != null)
            {
                DistrictName = person.LocDistrict;
            }
            return DistrictName;
        }
        public int GetCurrentYear()
        {
            DateTime CurrentYear = DateTime.Now;
            int currentid = CurrentYear.Year;
            return currentid;
        }
        public void OnGet()
        {
            string webRootPath = _iweb.WebRootPath;

            string path = "";
            string name = "";
            double? regid = 0;
            double? distid = 0;
            string distname = "";
            string regname = "";

            path = Path.Combine(webRootPath, "GovernanceDashboard.sydx");
            name = GetRoleName();
            regid = GetRegionId();
            distid = GetDistrictId();
            regname = GetRegionName();
            distname = GetDistrictName();

            ViewData["GovernanceDashboard"] = path;
            ViewData["NameofRole"] = name;
            ViewData["RegionId"] = regid;
            ViewData["DistrictId"] = distid;
            ViewData["RegionName"] = regname;
            ViewData["DistrictName"] = distname;
            ViewData["CurrentYear"] = GetCurrentYear();

            string baseurl = $"{this.Request.Scheme}://{this.Request.Host.Host}";
            ViewData["baseurl"] = baseurl;
        }
    }
}
