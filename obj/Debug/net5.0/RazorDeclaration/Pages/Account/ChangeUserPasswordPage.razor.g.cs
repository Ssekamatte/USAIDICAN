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
#line 2 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\Account\ChangeUserPasswordPage.razor"
using Microsoft.EntityFrameworkCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\Account\ChangeUserPasswordPage.razor"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\Account\ChangeUserPasswordPage.razor"
using Microsoft.AspNetCore.Identity.UI.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\Account\ChangeUserPasswordPage.razor"
using USAIDICANBLAZOR.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\Account\ChangeUserPasswordPage.razor"
using Microsoft.Extensions.Logging;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\Account\ChangeUserPasswordPage.razor"
using USAIDICANBLAZOR.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\Account\ChangeUserPasswordPage.razor"
using System.IO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\Account\ChangeUserPasswordPage.razor"
using System.Collections;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Components.RouteAttribute("/Account/ChangeUserPasswordPage")]
    public partial class ChangeUserPasswordPage : global::Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 88 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\Account\ChangeUserPasswordPage.razor"
       
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
    private SfGrid<AspNetUsers> UserGrid;
    private ResetUserPasswordViewModel InputModel = new ResetUserPasswordViewModel();
    private bool BatchVisibility { get; set; } = false;
    private async void OnViewRecord()
    {
        try
        {
            var m = UserGrid.SelectedRecords;
            if (m.Count == 0)
            {
                BatchVisibility = false;
                await ToastObj.Show(new ToastModel { Title = "Information!", Content = "Please select the user whose password you would like to reset.", CssClass = "e-toast-info", Icon = "e-info toast-icons" });
            }
            else if (m.Count > 1)
            {
                BatchVisibility = false;
                await ToastObj.Show(new ToastModel { Title = "Information!", Content = "Please select only one user.", CssClass = "e-toast-info", Icon = "e-info toast-icons" });
            }
            else
            {
                InputModel = new ResetUserPasswordViewModel();
                InputModel.UserId = m[0].Id;
                InputModel.Username = m[0].UserName;
                BatchVisibility = true;
            }
        }
        catch (Exception ex)
        {
            await ToastObj.Show(new ToastModel { Title = "Error!", Content = ex.ToString(), CssClass = "e-toast-danger", Icon = "e-error toast-icons" });
        }
    }
    private async void onComfirmResetBtnclick()
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
                    BatchVisibility = false;
                    await ToastObj.Show(new ToastModel { Title = "Success!", Content = "Password for " + UserGrid.SelectedRecords[0].NameOfUserAccountHolder + " was successfully Changed", CssClass = "e-toast-success", Icon = "e-success toast-icons" });
                }
                else
                {
                    string error = string.Join(",", _result.Errors.Select(o => new { o.Description }).ToList());
                    await ToastObj.Show(new ToastModel { Title = "Error!", Content = error, CssClass = "e-toast-danger", Icon = "e-error toast-icons" });
                }
            }
            else
            {
                string error = string.Join(",", result.Errors.Select(o => new { o.Description }).ToList());
                await ToastObj.Show(new ToastModel { Title = "Error!", Content = error, CssClass = "e-toast-danger", Icon = "e-error toast-icons" });
            }

        }
        catch (Exception ex)
        {
            await ToastObj.Show(new ToastModel { Title = "Error!", Content = ex.ToString(), CssClass = "e-toast-danger", Icon = "e-error toast-icons" });
        }
        //finally
        //{
        //    BatchVisibility = false;
        //    StateHasChanged();
        //}
    }
    protected override async Task OnInitializedAsync()
    {
        try
        {
            if (!userManagement.IsSignedIn())
            {
                Navigation.NavigateTo("Account/LoginPage", true);
            }
        }
        catch (Exception ex)
        {
            await ToastObj.Show(new ToastModel { Title = "Error!", Content = ex.ToString(), CssClass = "e-toast-danger", Icon = "e-error toast-icons" });
        }
    }
    public class AspNetUsersAdapter : DataAdaptor
    {
        public IToastService toastService;
        public AspNetUsersAdapter(IToastService ts)
        {
            toastService = ts;
        }
        public override async Task<Object> ReadAsync(DataManagerRequest dataManagerRequest, string key = null)
        {
            var data = new List<AspNetUsers>();
            try
            {
                using (var dbContext = new USAID_ICANContext())
                {
                    data = await dbContext.AspNetUsers.OrderBy(o => o.NameOfUserAccountHolder).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.ToString());
            }

            IEnumerable GridData = data;
            int _count = data.Count;
            if (dataManagerRequest.Search != null && dataManagerRequest.Search.Count > 0)
            {
                // Searching
                GridData = DataOperations.PerformSearching(GridData, dataManagerRequest.Search);
            }
            if (dataManagerRequest.Where != null && dataManagerRequest.Where.Count > 0)
            {
                // Filtering
                GridData = DataOperations.PerformFiltering(GridData, dataManagerRequest.Where, dataManagerRequest.Where[0].Operator);
            }
            if (dataManagerRequest.Sorted?.Count > 0) // perform Sorting
            {
                GridData = DataOperations.PerformSorting(GridData, dataManagerRequest.Sorted);
            }
            if (dataManagerRequest.Skip != 0)
            {
                GridData = DataOperations.PerformSkip(GridData, dataManagerRequest.Skip); //Paging
            }
            if (dataManagerRequest.Take != 0)
            {
                GridData = DataOperations.PerformTake(GridData, dataManagerRequest.Take);
            }
            IDictionary<string, object> aggregates = new Dictionary<string, object>();
            if (dataManagerRequest.Aggregates != null) // Aggregation
            {
                aggregates = DataUtil.PerformAggregation(GridData, dataManagerRequest.Aggregates);
            }
            if (dataManagerRequest.Group != null && dataManagerRequest.Group.Any()) //Grouping
            {
                foreach (var group in dataManagerRequest.Group)
                {
                    GridData = DataUtil.Group<AspNetUsers>(GridData, group, dataManagerRequest.Aggregates, 0, dataManagerRequest.GroupByFormatter);
                }
            }
            return dataManagerRequest.RequiresCounts ? new DataResult() { Result = GridData, Count = _count, Aggregates = aggregates } : (object)GridData;
        }
        // Performs BatchUpdate operation
        public override object BatchUpdate(DataManager dm, object Changed, object Added, object Deleted, string KeyField, string Key, int? dropIndex)
        {
            object value = null;

            return value;
        }

    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private UserManagement userManagement { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager Navigation { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private UserManager<IdentityUser> _userManager { get; set; }
    }
}
#pragma warning restore 1591