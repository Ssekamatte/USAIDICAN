using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using USAIDICANBLAZOR.Models;
using System.Linq;
using System.Threading.Tasks;

namespace USAIDICANBLAZOR.Data
{
    public class UserManagement
    {
        private IHttpContextAccessor _httpContextAccessor;
        private USAID_ICANContext _contex;
        private SignInManager<IdentityUser> SignInManager;
        private UserManager<IdentityUser> UserManager;
        public UserManagement(IHttpContextAccessor httpContextAccessor, USAID_ICANContext context,
            SignInManager<IdentityUser> _SignInManager, UserManager<IdentityUser> _UserManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _contex = context;
            SignInManager = _SignInManager;
            UserManager = _UserManager;
        }
        public string GetStaffName()
        {
            string name = string.Empty;
            var person = _contex.AspNetUsers.FirstOrDefault(o => o.UserName == _httpContextAccessor.HttpContext.User.Identity.Name);
            if (person != null)
            {
                name = person.NameOfUserAccountHolder;
            }
            return name;
        }

        public string GetRoleName()
        {
            string rolename = string.Empty;
            var person = _contex.View2022UserManagement.FirstOrDefault(o => o.UserName == _httpContextAccessor.HttpContext.User.Identity.Name);
            if (person != null)
            {
                rolename = person.NormalizedRoleName;
            }
            return rolename;
        }

        public string GetRegionName()
        {
            string regionname = string.Empty;
            var person = _contex.View2022UserManagement.FirstOrDefault(o => o.UserName == _httpContextAccessor.HttpContext.User.Identity.Name);
            if (person != null)
            {
                regionname = person.LocRegion;
            }
            return regionname;
        }

        public int? GetRegionId()
        {
            int? RegionId = null;
            var person = _contex.View2022UserManagement.FirstOrDefault(o => o.UserName == _httpContextAccessor.HttpContext.User.Identity.Name);
            if (person != null)
            {
                RegionId = person.RegionId;
            }
            return RegionId;
        }

        //public int? GetUserDivision()
        //{
        //    int? divisionId = null;
        //    var person = _contex.View2022UserManagement.FirstOrDefault(o => o.UserName == _httpContextAccessor.HttpContext.User.Identity.Name);
        //    if (person != null)
        //    {
        //        divisionId = person.DivisionId;
        //    }
        //    return divisionId;
        //}

        //public int? GetUserDivisionUnit()
        //{
        //    int? result = null;
        //    var person = _contex.View2022UserManagement.FirstOrDefault(o => o.UserName == _httpContextAccessor.HttpContext.User.Identity.Name);
        //    if (person != null)
        //    {
        //        result = person.DivisionUnitId;
        //    }
        //    return result;
        //}


        //public int? GetUserResponsibilityLevel()
        //{
        //    int? result = null;
        //    var person = _contex.View2022UserManagement.FirstOrDefault(o => o.UserName == _httpContextAccessor.HttpContext.User.Identity.Name);
        //    if (person != null)
        //    {
        //        result = person.ResponsibilityLevelId;
        //    }
        //    return result;
        //}

        public string GetStaffEmail()
        {
            string name = string.Empty;
            var person = _contex.AspNetUsers.FirstOrDefault(o => o.UserName == _httpContextAccessor.HttpContext.User.Identity.Name);
            if (person != null)
            {
                name = person.Email;
            }
            return name;
        }
        public string GetUserName()
        {
            //string name = string.Empty;
            //var person = _contex.AspNetUsers.FirstOrDefault(o => o.UserName == _httpContextAccessor.HttpContext.User.Identity.Name);
            //if (person != null)
            //{
            //    name = person.UserName;
            //}
            //return name;
            return _httpContextAccessor.HttpContext.User.Identity.Name;
        }
        public string GetStaffNumber()
        {
            string name = string.Empty;
            var person = _contex.AspNetUsers.FirstOrDefault(o => o.UserName == _httpContextAccessor.HttpContext.User.Identity.Name);
            if (person != null)
            {
                name = person.PhoneNumber;
            }
            return name;
        }
        //public double? GetOperatorId()
        //{
        //    double? OperatorId = null;
        //    var person = _contex.AspNetUsers.FirstOrDefault(o => o.UserName == _httpContextAccessor.HttpContext.User.Identity.Name);
        //    if (person != null)
        //    {
        //        OperatorId = person.OperatorId;
        //    }
        //    return OperatorId;
        //}
        public bool IsSignedIn()
        {
            return SignInManager.IsSignedIn(_httpContextAccessor.HttpContext.User);
        }
        public async Task<bool> IsInRole(string UserRole)
        {
            var user = await UserManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            //var a =await UserManager.IsInRoleAsync(user, UserRole);
            return await UserManager.IsInRoleAsync(user, UserRole);
        }
    }
}
