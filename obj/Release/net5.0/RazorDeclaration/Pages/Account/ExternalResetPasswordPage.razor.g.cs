// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace USAIDICANBLAZOR.Pages.Account
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\_Imports.razor"
using USAIDICANBLAZOR.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\_Imports.razor"
using Blazored.Toast;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\_Imports.razor"
using Blazored.Toast.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\_Imports.razor"
using BlazorStrap;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\_Imports.razor"
using Syncfusion.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\_Imports.razor"
using Syncfusion.Blazor.Calendars;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\_Imports.razor"
using Syncfusion.Blazor.DropDowns;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\_Imports.razor"
using Syncfusion.Blazor.Grids;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\_Imports.razor"
using Syncfusion.Blazor.Inputs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\_Imports.razor"
using Syncfusion.Blazor.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\_Imports.razor"
using Syncfusion.Blazor.Navigations;

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\_Imports.razor"
using Syncfusion.Blazor.Buttons;

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\_Imports.razor"
using Syncfusion.Blazor.Notifications;

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\_Imports.razor"
using Syncfusion.Blazor.Popups;

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\_Imports.razor"
using Syncfusion.Blazor.Spinner;

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\_Imports.razor"
using Syncfusion.Blazor.Lists;

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\_Imports.razor"
using Syncfusion.Blazor.Layouts;

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\_Imports.razor"
using Syncfusion.Blazor.Maps;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\Account\ExternalResetPasswordPage.razor"
using USAIDICANBLAZOR.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\Account\ExternalResetPasswordPage.razor"
using USAIDICANBLAZOR.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\Account\ExternalResetPasswordPage.razor"
using Microsoft.EntityFrameworkCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\Account\ExternalResetPasswordPage.razor"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\Account\ExternalResetPasswordPage.razor"
using Microsoft.AspNetCore.Identity.UI.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Components.RouteAttribute("/ExternalResetPasswordPage")]
    [global::Microsoft.AspNetCore.Components.RouteAttribute("/ExternalResetPasswordPage/{Id}")]
    public partial class ExternalResetPasswordPage : global::Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 78 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\Account\ExternalResetPasswordPage.razor"
       
    [Parameter]
    public string Id { get; set; }
    private string decriptedSring { get; set; }
    string Returnmessage { get; set; }

    private ResetUserPasswordViewModel InputModel = new ResetUserPasswordViewModel();

    protected override Task OnAfterRenderAsync(bool firstRender)
    {
        if (!string.IsNullOrEmpty(Id))
        {
            byte[] b = Convert.FromBase64String(Id);
            decriptedSring = System.Text.ASCIIEncoding.ASCII.GetString(b);
        }
        return base.OnAfterRenderAsync(firstRender);
    }
    protected override void OnInitialized()
    {
        if (!string.IsNullOrEmpty(Id))
        {
            byte[] b = Convert.FromBase64String(Id);
            decriptedSring = System.Text.ASCIIEncoding.ASCII.GetString(b);
            using (var db = new USAID_ICANContext())
            {
                var exists = db.AspNetUsers.FirstOrDefault(o => o.Id == decriptedSring);
                if (exists != null)
                {
                    InputModel.UserId = decriptedSring;
                    InputModel.Username = exists.UserName;
                }
            }
        }
        base.OnInitialized();
    }
    private async Task ResetPassword()
    {
        try
        {
            var user = await _userManager.FindByNameAsync(InputModel.Username);
            var result = await _userManager.RemovePasswordAsync(user);
            if (result.Succeeded)
            {
                var _result = await _userManager.AddPasswordAsync(user, InputModel.Password);
                if (_result.Succeeded)
                {
                    Returnmessage = "Success: the password to your account was successfully reset";
                }
                else
                {
                    string error = string.Join(",", result.Errors.ToList());
                    Returnmessage = "Error: " + error;
                }
            }
            else
            {
                string error = string.Join(",", result.Errors.ToList());
                Returnmessage = "Error: "+ error;
            }

        }
        catch (Exception ex)
        {
            Returnmessage = "Error: something went wrong when processing your request, please try again later or contact the administrator.";
        }
        StateHasChanged();
    }
    private void BackToLoginClick()
    {
        NavManager.NavigateTo("/", true);
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private UserManager<IdentityUser> _userManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavManager { get; set; }
    }
}
#pragma warning restore 1591
