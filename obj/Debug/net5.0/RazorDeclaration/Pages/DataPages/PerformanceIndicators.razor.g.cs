// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace USAIDICANBLAZOR.Pages.DataPages
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
#line 2 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\DataPages\PerformanceIndicators.razor"
using USAIDICANBLAZOR.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\DataPages\PerformanceIndicators.razor"
using USAIDICANBLAZOR.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\DataPages\PerformanceIndicators.razor"
using System.Collections;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\DataPages\PerformanceIndicators.razor"
using Microsoft.EntityFrameworkCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\DataPages\PerformanceIndicators.razor"
using Syncfusion.Blazor.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\DataPages\PerformanceIndicators.razor"
using System.IO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\DataPages\PerformanceIndicators.razor"
using Microsoft.AspNetCore.Hosting;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Components.RouteAttribute("/PerformanceIndicatorsPage")]
    public partial class PerformanceIndicators : global::Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 94 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\DataPages\PerformanceIndicators.razor"
       

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

    SfGrid<View2022OnaTargetsUpdated> PerformanceGrid;
    private SearchPanel InputModel = new();
    List<View2022ARegions> RegionData { get; set; }
    List<ViewADistricts> DistrictsData { get; set; }
    bool isEnabled { get; set; } = false;
    private List<AYear> YearData { get; set; }
    private List<OnaAFinancialYears> FinancialYearData { get; set; }
    private List<OnaAQuarter> QuarterData { get; set; }
    string UserRole { get; set; }

    public Query MainQuery = new Query();

    //public IEditorSettings PriceEditParams = new NumericEditCellParams
    //{
    //    Params = new NumericTextBoxModel<object>() { Min = 0, ShowSpinButton = false, Decimals = 3, Format = "n3", ValidateDecimalOnType = true }
    //};

    protected override async Task OnInitializedAsync()
    {
        try
        {
            await base.OnInitializedAsync();
            using (var db = new USAID_ICANContext())
            {
                string Region = string.Empty;
                Region = userManagement.GetRegionName();
                var user = db.View2022UserManagement.FirstOrDefault(o => o.UserName == userManagement.GetUserName());
                if (user != null)
                {
                    UserRole = user.RoleName;
                    if (!string.IsNullOrEmpty(Region))
                    {
                        RegionData = db.View2022ARegions.AsNoTracking().Where(o => o.Region.ToLower() == Region.ToLower()).ToList();
                        DistrictsData = db.ViewADistricts.AsNoTracking().ToList();
                        YearData = db.AYear.OrderBy(o => o.YearName).ToList();
                        FinancialYearData = db.OnaAFinancialYears.OrderBy(o => o.FinancialYearId).ToList();
                        QuarterData = db.OnaAQuarter.OrderBy(o => o.QuarterId).ToList();
                        InputModel = new();
                    }
                    else
                    {
                       RegionData = db.View2022ARegions.AsNoTracking().ToList();
                        DistrictsData = db.ViewADistricts.AsNoTracking().ToList();
                        YearData = db.AYear.OrderBy(o => o.YearName).ToList();
                        FinancialYearData = db.OnaAFinancialYears.OrderBy(o => o.FinancialYearId).ToList();
                        QuarterData = db.OnaAQuarter.OrderBy(o => o.QuarterId).ToList();
                        InputModel = new(); 
                    }
                }

                
            }

        }
        catch (Exception ex)
        {
            await ToastObj.Show(new ToastModel { Title = "Error!", Content = ex.Message.ToString(), CssClass = "e-toast-danger", Icon = "e-error toast-icons" });
        }
    }

    public void OnRegionChange(Syncfusion.Blazor.DropDowns.MultiSelectChangeEventArgs<int?[]> args)
    {
        if (args.Value != null)
        {
            using (var db = new USAID_ICANContext())
            {
                DistrictsData = db.ViewADistricts.Where(o => args.Value.Any(a => a == o.RegionId) == true).AsNoTracking().ToList();
                isEnabled = true;
            }
        }
    }

    private void SearchRecords()
    {
        try
        {
            MainQuery = new Query();
            if (InputModel.RegionId != null)
            {
                MainQuery.AddParams("RegionId", string.Join(",", InputModel.RegionId));
            }
            if (InputModel.DistrictId != null)
            {
                MainQuery.AddParams("DistrictId", string.Join(",", InputModel.DistrictId));
            }
            if (InputModel.Year != null)
            {
                MainQuery.AddParams("Year", string.Join(",", InputModel.Year));
            }
        }
        catch (Exception ex)
        {
            ToastObj.Show(new ToastModel { Title = "Error!", Content = ex.Message.ToString(), CssClass = "e-toast-danger", Icon = "e-error toast-icons" });
        }
    }

    private void ClearSearchBtnClick()
    {
        InputModel = new();
        MainQuery = new Query();
        using (var db = new USAID_ICANContext())
        {
            MainQuery = new Query();
        }
    }

    #region PerformanceIndicators

    public void OnCellSaved(CellSaveArgs<View2022OnaTargetsUpdated> Args)
    {
        this.PerformanceGrid.EndEdit();
    }

    public void TemplateActionComplete(ActionEventArgs<View2022OnaTargetsUpdated> args)
    {
        if (args.RequestType == Syncfusion.Blazor.Grids.Action.BatchSave)
        {
            PerformanceGrid.Refresh();
        }
        else
        {

        }
    }

    //Enable cell edit on single click
    public async Task CellSelectHandler(CellSelectEventArgs<View2022OnaTargetsUpdated> args)
    {
        //get selected cell index
        var CellIndexes = await PerformanceGrid.GetSelectedRowCellIndexes();

        //get the row and cell index
        var CurrentEditRowIndex = CellIndexes[0].Item1;
        var CurrentEditCellIndex = (int)CellIndexes[0].Item2;

        //get the available fields
        var fields = await PerformanceGrid.GetColumnFieldNames();
        // edit the selected cell using the cell index and column name
        await PerformanceGrid.EditCell(CurrentEditRowIndex, fields[CurrentEditCellIndex]);
    }

    public class PerformanceIndicatorsAdapter : DataAdaptor
    {
        public IToastService toastService;
        private UserManagement _userManagement;
        public PerformanceIndicatorsAdapter(IToastService ts,UserManagement userManagement)
        {
            toastService = ts;
            _userManagement = userManagement;
        }

        public override async Task<Object> ReadAsync(DataManagerRequest dataManagerRequest, string key = null)
        {
            var data = new List<View2022OnaTargetsUpdated>();
            try
            {
                List<int> RegionId = new List<int>();
                List<int> DistrictId = new List<int>();
                List<int> Year = new List<int>();
                int? RegionDataId = null;
                if (_userManagement.GetRegionId()!=null)
                {
                    RegionDataId = _userManagement.GetRegionId();
                }

                if (dataManagerRequest.Params != null && dataManagerRequest.Params.Count > 0)
                {
                    var val = dataManagerRequest.Params;
                    if (val.FirstOrDefault(o => o.Key == "RegionId").Value != null)
                    {
                        var a = val.FirstOrDefault(o => o.Key == "RegionId").Value.ToString().Split(",");
                        foreach (var y in a) {
                            RegionId.Add(Convert.ToInt32(y));
                        }
                    }

                    if (val.FirstOrDefault(o => o.Key == "DistrictId").Value != null)
                    {
                        var a = val.FirstOrDefault(o => o.Key == "DistrictId").Value.ToString().Split(",");
                        foreach (var y in a)
                        {
                            DistrictId.Add(Convert.ToInt32(y));
                        }
                    }

                    if (val.FirstOrDefault(o => o.Key == "Year").Value != null)
                    {
                        var a = val.FirstOrDefault(o => o.Key == "Year").Value.ToString().Split(",");
                        foreach (var y in a)
                        {
                            Year.Add(Convert.ToInt32(y));
                        }
                    }
                }
                using (var dbContext = new USAID_ICANContext())
                {
                    if (_userManagement.GetRoleName().Contains("ADMINISTRATOR") || _userManagement.GetRoleName().Contains("SUPER ADMINISTRATOR"))
                    {
                        data = dbContext.View2022OnaTargetsUpdated.OrderBy(o => o.IndicatorDescription).OrderByDescending(o => o.TargetId).ToList().Where(o => (RegionId.Count() == 0 || RegionId.Any(a => a == o.RegionId) && (DistrictId.Count() == 0 || DistrictId.Any(a => a == o.DistrictId)) && (Year.Count() == 0 || Year.Any(a => a == Convert.ToInt32(o.Year))))).ToList();
                    }
                    else
                    {
                        data = dbContext.View2022OnaTargetsUpdated.OrderBy(o => o.IndicatorDescription).OrderByDescending(o => o.TargetId).ToList().Where(o => (o.RegionId== RegionDataId) && (DistrictId.Count() == 0 || DistrictId.Any(a => a == o.DistrictId)) && (Year.Count() == 0 || Year.Any(a => a == Convert.ToInt32(o.Year)))).ToList();
                    }   
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
                        GridData = DataUtil.Group<View2022OnaTargetsUpdated>(GridData, group, dataManagerRequest.Aggregates, 0, dataManagerRequest.GroupByFormatter);
                    }
                }
                return dataManagerRequest.RequiresCounts ? new DataResult() { Result = GridData, Count = _count, Aggregates = aggregates } : (object)GridData;
            }

            // Performs BatchUpdate operation
            public override object BatchUpdate(DataManager dm, object Changed, object Added, object Deleted, string KeyField, string Key, int? dropIndex)
            {
                object value = null;
                try
                {
                    if (Added != null)
                    {
                        var val = (List<View2022OnaTargetsUpdated>)Added;
                        if (val.Count > 0)
                        {
                            Changed = Added;
                            value = Added;
                        }
                    }
                    if (Changed != null)
                    {
                        value = Changed;

                        using (var dbContext = new USAID_ICANContext())
                        {
                            var val = (List<View2022OnaTargetsUpdated>)Changed;
                            foreach (var n in val)
                            {
                                var exists = dbContext.OnaTargets.FirstOrDefault(o => o.TargetId == n.TargetId);
                                if (exists != null)
                                {
                                    exists.Actual = n.Actual;
                                    exists.FinancialYearId = n.FinancialYearId;
                                    exists.QuarterId = n.QuarterId;
                                    exists.Quarter1 = n.Quarter1;
                                    exists.Quarter2 = n.Quarter1;
                                    exists.Quarter3 = n.Quarter1;
                                    exists.Quarter4 = n.Quarter1;

                                    dbContext.Entry(exists).CurrentValues.SetValues(n);
                                    dbContext.Entry(exists).State = EntityState.Modified;
                                }
                                else
                                {
                                    int id = 1;
                                    var data = dbContext.View2022OnaTargetsUpdated.OrderBy(o => o.TargetId).ToList().LastOrDefault();
                                    if (data != null)
                                    {
                                        id = (data.TargetId + 1);
                                    }
                                    n.TargetId = id;
                                    dbContext.View2022OnaTargetsUpdated.Add(n);
                                }
                                dbContext.SaveChanges();
                                string result = "Record Updated Successfully";
                                toastService.ShowInfo(result);
                            }
                        }
                    }
                    //if (Deleted != null)
                    //{
                    //    foreach (var rec in (IEnumerable<OnaTargets>)Deleted)
                    //    {
                    //        //Orders.Remove(onata.Where(or => or.OrderID == rec.OrderID).FirstOrDefault());
                    //    }

                    //}
                }
                catch (Exception ex)
                {
                    toastService.ShowError(ex.ToString());
                }

                return value;
            }
        }
        #endregion PerformanceIndicators
    

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IWebHostEnvironment hostingEnv { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private UserManagement userManagement { get; set; }
    }
}
#pragma warning restore 1591