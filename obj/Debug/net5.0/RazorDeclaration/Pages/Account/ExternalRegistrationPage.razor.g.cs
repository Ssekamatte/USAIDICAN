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
#line 2 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\Account\ExternalRegistrationPage.razor"
using USAIDICANBLAZOR.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\Account\ExternalRegistrationPage.razor"
using USAIDICANBLAZOR.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\Account\ExternalRegistrationPage.razor"
using Microsoft.EntityFrameworkCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\Account\ExternalRegistrationPage.razor"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\Account\ExternalRegistrationPage.razor"
using Microsoft.AspNetCore.Identity.UI.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\Account\ExternalRegistrationPage.razor"
using System.Net;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\Account\ExternalRegistrationPage.razor"
using System.Net.Mail;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Components.RouteAttribute("/ExternalRegistrationPage")]
    public partial class ExternalRegistrationPage : global::Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 78 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\Account\ExternalRegistrationPage.razor"
       
            #region Toasters
            public static string ToastContent { get; set; }
            SfToast ToastObj;
            SfToast DeleteToastObj;
            private string ToastPosition = "Right";
            private int AlarmTimeout { get; set; } = 120000;
            private List<ToastModel> Toast = new List<ToastModel>
{
        new ToastModel{ Title = "Warning!", Content=ToastContent, CssClass="e-toast-warning", Icon="e-warning toast-icons" },
        new ToastModel{ Title = "Success!", Content=ToastContent, CssClass="e-toast-success", Icon="e-success toast-icons" },
        new ToastModel{ Title = "Error!", Content=ToastContent, CssClass="e-toast-danger", Icon="e-error toast-icons" },
        new ToastModel{ Title = "Information!", Content=ToastContent, CssClass="e-toast-info", Icon="e-info toast-icons" }
    };
            #endregion Toasters
            private RegisterViewModel InputModel = new RegisterViewModel();

            protected override void OnInitialized()
            {
                InputModel.UserRole = "Administrator";
                base.OnInitialized();
            }
            private void BackToLoginClick()
            {
                NavManager.NavigateTo("/", true);
            }

            private async Task RegisterUser()
            {
                try
                {
                    var user = new ApplicationUser { UserName = InputModel.UserName, Email = InputModel.Email, PhoneNumber = InputModel.PhoneNumber, LockoutEnabled = false, AccountHolderName = InputModel.AccountHolderName };
                    var result = await _userManager.CreateAsync(user, InputModel.Password);
                    if (result.Succeeded)
                    {
                        var _result = await _userManager.AddToRoleAsync(user, InputModel.UserRole);

                        if (_result.Succeeded)
                        {
                            string url = NavManager.BaseUri;
                            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                            using (var dbContext = new USAID_ICANContext())
                            {
                                double id = 1;
                                var _last = dbContext.AspNetEmailConfirmationCode.ToList().LastOrDefault();
                                if(_last != null)
                                {
                                    id = (_last.ConfirmationId + 1);
                                }
                                var exist = dbContext.AspNetUsers.FirstOrDefault(o => o.Id == user.Id);
                                if (exist != null)
                                {
                                    //exist.StaffId = InputModel.StaffId;
                                    exist.NameOfUserAccountHolder = InputModel.AccountHolderName;
                                    //exist.EmailConfirmed = true;
                                    //exist.LockoutEnabled = false;
                                    exist.PhoneNumberConfirmed = true;
                                    dbContext.Entry(exist).State = EntityState.Modified;
                                    dbContext.SaveChanges();
                                }
                                AspNetEmailConfirmationCode x = new AspNetEmailConfirmationCode()
                                {
                                    UserName = InputModel.UserName,
                                    ConfirmationCode = code,
                                    CreationDate = DateTime.Now,
                                    ConfirmationId = id
                                };
                                dbContext.AspNetEmailConfirmationCode.Add(x);
                                dbContext.SaveChanges();
                            }

                            byte[] c = System.Text.ASCIIEncoding.ASCII.GetBytes(InputModel.UserName);
                            string username = Convert.ToBase64String(c);

                            string _message = url + "ConfirmEmailPage/"+ username;

                            using (var message = new MailMessage("donotreply@ibs.co.ug", InputModel.Email))
                            {
                                message.Subject = "PAU Email Confirmation";
                                message.Body = "Dear " + InputModel.AccountHolderName + ",<br/><br/>" +
                                        "<p> Email confirmation is required to access this system.</p>" +
                                        "<br/> <p>Please click <a href='" + _message + "'>here</a> to confirm your email. Thanks!</p>" +
                                        "<br/> <br/> Regards,<br/><br/> System notfication, <br/> Petrolium Authority of Uganda.<br/><br/>" + DateTime.Now;
                                message.IsBodyHtml = true;
                                using (SmtpClient client = new SmtpClient
                                {
                                    EnableSsl = false,
                                    //Host = "smtp.gmail.com",
                                    Host = "mail.ibs.co.ug",
                                    Port = 587,
                                    //Port = 25,
                                    DeliveryMethod = SmtpDeliveryMethod.Network,
                                    //UseDefaultCredentials = true,
                                    Credentials = new NetworkCredential("donotreply@ibs.co.ug", "**Root@85")
                                })
                        {
                                //client.EnableSsl = true;
                                client.Send(message);
                            }
                        }

                        await ToastObj.Show(new ToastModel { Title = "Success!", Content = InputModel.AccountHolderName + " has been successfully registered!", CssClass = "e-toast-success", Icon = "e-success toast-icons" });
                    }
                    else
                    {
                        string _error = string.Empty;
                        foreach (var error in _result.Errors)
                        {
                            // ModelState.AddModelError(string.Empty, error.Description);
                            _error += error.Description + ",";
                        }
                        await ToastObj.Show(new ToastModel { Title = "Error!", Content = _error, CssClass = "e-toast-danger", Icon = "e-error toast-icons" });
                    }

                }
            else
                {
                    string _error = string.Empty;
                    foreach (var error in result.Errors)
                    {
                        // ModelState.AddModelError(string.Empty, error.Description);
                        _error += error.Description + ",";
                    }
                    await ToastObj.Show(new ToastModel { Title = "Error!", Content = _error, CssClass = "e-toast-danger", Icon = "e-error toast-icons" });
                }
            }
        catch (Exception ex)
        {
            await ToastObj.Show(new ToastModel { Title = "Error!", Content = ex.ToString(), CssClass = "e-toast-danger", Icon = "e-error toast-icons" });
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private UserManager<IdentityUser> _userManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavManager { get; set; }
    }
}
#pragma warning restore 1591