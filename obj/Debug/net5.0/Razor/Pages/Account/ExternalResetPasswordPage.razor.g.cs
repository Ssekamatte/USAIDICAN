#pragma checksum "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\Account\ExternalResetPasswordPage.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4b01f6481507a79d8fdcfd242bc968a4cb845fc5"
// <auto-generated/>
#pragma warning disable 1591
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
            __builder.AddMarkupContent(0, @"<style>
    body {
        margin: 0px;
        padding: 0px;
        background: url(../image/bg.png);
        background-attachment: fixed;
        background-repeat: no-repeat;
        background-size: cover;
        background-position-y: -68px;
        height: 100%;
        background-color: #000 !important;
        /*font-family: 'Roboto', 'Roboto Condensed' !important;*/
        width: 100%;
        overflow-x: hidden !important;
    }

    .center-screen {
        display: flex;
        flex-direction: column;
        justify-content: center;
        align-items: center;
        text-align: center;
        min-height: 100vh;
        /*width:40%;*/
    }

    h3 {
        color: #FFBF00;
        font-family: Cambria;
    }

    p {
        word-wrap: break-word;
    }
</style>
");
            __builder.OpenElement(1, "div");
            __builder.AddAttribute(2, "class", "center-screen");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "style", "width:35%;");
            __builder.AddMarkupContent(5, "<h3>Reset Password</h3>\r\n        ");
            __builder.AddMarkupContent(6, "<p>Please input the new Password you would like to use to access your account</p>\r\n        ");
            __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.EditForm>(7);
            __builder.AddAttribute(8, "Model", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::System.Object>(
#nullable restore
#line 49 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\Account\ExternalResetPasswordPage.razor"
                          InputModel

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(9, "class", "signin-form");
            __builder.AddAttribute(10, "OnValidSubmit", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::Microsoft.AspNetCore.Components.EventCallback<global::Microsoft.AspNetCore.Components.Forms.EditContext>>(global::Microsoft.AspNetCore.Components.EventCallback.Factory.Create<global::Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 49 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\Account\ExternalResetPasswordPage.razor"
                                                                          ResetPassword

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(11, "ChildContent", (global::Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.OpenElement(12, "div");
                __builder2.AddAttribute(13, "class", "form-group mb-3");
                __builder2.AddMarkupContent(14, "<label class=\"label\" for=\"Password\" style=\"color:#96CFF0;float:left;\">Password</label>\r\n                ");
                __builder2.OpenElement(15, "input");
                __builder2.AddAttribute(16, "type", "password");
                __builder2.AddAttribute(17, "class", "form-control");
                __builder2.AddAttribute(18, "placeholder", "Password");
                __builder2.AddAttribute(19, "required");
                __builder2.AddAttribute(20, "value", global::Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 52 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\Account\ExternalResetPasswordPage.razor"
                                                     InputModel.Password

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(21, "onchange", global::Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => InputModel.Password = __value, InputModel.Password));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(22, "\r\n            ");
                __builder2.OpenElement(23, "div");
                __builder2.AddAttribute(24, "class", "form-group mb-3");
                __builder2.AddMarkupContent(25, "<label class=\"label\" for=\"ConfirmPassword\" style=\"color:#96CFF0;float:left;\">Confirm Password</label>\r\n                ");
                __builder2.OpenElement(26, "input");
                __builder2.AddAttribute(27, "type", "password");
                __builder2.AddAttribute(28, "class", "form-control");
                __builder2.AddAttribute(29, "placeholder", "Confirm Password");
                __builder2.AddAttribute(30, "required");
                __builder2.AddAttribute(31, "value", global::Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 56 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\Account\ExternalResetPasswordPage.razor"
                                                     InputModel.ConfirmPassword

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(32, "onchange", global::Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => InputModel.ConfirmPassword = __value, InputModel.ConfirmPassword));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(33, "\r\n            ");
                __builder2.AddMarkupContent(34, "<div class=\"form-group\"><button type=\"submit\" class=\"form-control btn btn-primary rounded submit px-3\">Reset Password</button></div>\r\n            ");
                __builder2.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(35);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(36, "\r\n            ");
                __builder2.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationSummary>(37);
                __builder2.CloseComponent();
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(38, "\r\n        ");
            __builder.OpenElement(39, "p");
            __builder.AddAttribute(40, "class", "text-center");
            __builder.AddContent(41, "Do you want to return to the login page? ");
            __builder.OpenElement(42, "a");
            __builder.AddAttribute(43, "data-toggle", "tab");
            __builder.AddAttribute(44, "href", "#");
            __builder.AddAttribute(45, "onclick", global::Microsoft.AspNetCore.Components.EventCallback.Factory.Create<global::Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 64 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\Account\ExternalResetPasswordPage.razor"
                                                                                                                 BackToLoginClick

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(46, "Click here");
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 65 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\Account\ExternalResetPasswordPage.razor"
         if (!string.IsNullOrEmpty(Returnmessage))
        {
            if (Returnmessage.ToLower().Contains("success"))
            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(47, "p");
            __builder.AddAttribute(48, "class", "badge badge-success");
            __builder.AddAttribute(49, "style", "width:100%; padding:15px; font-family:Cambria;font-size:large;");
#nullable restore
#line 69 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\Account\ExternalResetPasswordPage.razor"
__builder.AddContent(50, Returnmessage);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
#nullable restore
#line 70 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\Account\ExternalResetPasswordPage.razor"
            }
            else
            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(51, "p");
            __builder.AddAttribute(52, "class", "badge badge-danger");
            __builder.AddAttribute(53, "style", "width:100%; padding:15px; font-family:Cambria;font-size:large;");
#nullable restore
#line 73 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\Account\ExternalResetPasswordPage.razor"
__builder.AddContent(54, Returnmessage);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
#nullable restore
#line 74 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\Account\ExternalResetPasswordPage.razor"
            }
        }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
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
