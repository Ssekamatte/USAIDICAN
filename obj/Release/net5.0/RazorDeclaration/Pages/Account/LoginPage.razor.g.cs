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
#line 2 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\Account\LoginPage.razor"
using USAIDICANBLAZOR.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\Account\LoginPage.razor"
using Microsoft.EntityFrameworkCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\Account\LoginPage.razor"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\Account\LoginPage.razor"
using Microsoft.AspNetCore.Identity.UI.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\Account\LoginPage.razor"
using USAIDICANBLAZOR.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\Account\LoginPage.razor"
using Microsoft.Extensions.Logging;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class LoginPage : global::Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 338 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\Account\LoginPage.razor"
       
    string Errormsg { get; set; }
    private LoginViewModel InputModel = new LoginViewModel();

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await JS.InvokeAsync<object>("initializeCarousel");
        }
        await base.OnAfterRenderAsync(firstRender);
        // return await base.OnAfterRenderAsync(firstRender);
    }

    protected override async Task OnInitializedAsync()
    {
        try
        {
            Errormsg = string.Empty;
            if (userManagement.IsSignedIn())
            {
                string currentUrl = NavManager.Uri + "api/LoginAPI";
                var text = await JS.InvokeAsync<string>("Logout",currentUrl);
            }
            InputModel.Isbusy = false;
        }
        catch (Exception ex)
        {
            _logger.LogInformation("Login Error:-" + ex.ToString());
            Errormsg = ex.Message;
        }
    }
    private async Task LoginUser()
    {
        try
        {
            InputModel.Isbusy = true;
            Errormsg = string.Empty;
            string email = string.Empty;
            using (var dbContext = new USAID_ICANContext())
            {
                var exist = dbContext.AspNetUsers.FirstOrDefault(o => o.Email == InputModel.Email || o.UserName == InputModel.Email);
                if (exist != null)
                {
                    if (exist.LockoutEnabled)
                    {
                        Errormsg = "This account has been locked out, Please contact your administrator for re-activation.";
                        InputModel.Isbusy = false;
                    }
                    else
                    {
                        email = exist.UserName;
                        InputModel.Email = exist.UserName;
                        string currentUrl = NavManager.Uri + "api/LoginAPI";
                        var result = await JS.InvokeAsync<Microsoft.AspNetCore.Identity.SignInResult>("Login", InputModel.Email, InputModel.Password, InputModel.RememberMe, currentUrl);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogInformation("Login Error:-" + ex.ToString());
            Errormsg = ex.Message;
        }
        StateHasChanged();
    }
    private void signUpclick()
    {
        NavManager.NavigateTo("ExternalRegistrationPage", true);
    }
    private void ForgotPasswordclick()
    {
        NavManager.NavigateTo("ForgotPasswordPage", true);
    }

    public string TxtType = "password";

    public void ShowPassword()
    {
        if (this.TxtType == "password")
        {
            this.TxtType = "text";
        }
        else
        {
            this.TxtType = "password";
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private UserManagement userManagement { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ILogger<LoginPage> _logger { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private UserManager<IdentityUser> _userManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private SignInManager<IdentityUser> _signInManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JS { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavManager { get; set; }
    }
}
#pragma warning restore 1591
