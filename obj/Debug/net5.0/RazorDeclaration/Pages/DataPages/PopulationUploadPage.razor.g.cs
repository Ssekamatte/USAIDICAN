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
#line 2 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\DataPages\PopulationUploadPage.razor"
using Syncfusion.Blazor.Inputs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\DataPages\PopulationUploadPage.razor"
using System.IO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\DataPages\PopulationUploadPage.razor"
using System.ComponentModel.DataAnnotations;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\DataPages\PopulationUploadPage.razor"
using Syncfusion.XlsIO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\DataPages\PopulationUploadPage.razor"
using USAIDICANBLAZOR.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\DataPages\PopulationUploadPage.razor"
using System.Collections;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\DataPages\PopulationUploadPage.razor"
using Microsoft.EntityFrameworkCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\DataPages\PopulationUploadPage.razor"
using USAIDICANBLAZOR.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Components.RouteAttribute("/PopulationUploadPage")]
    public partial class PopulationUploadPage : global::Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 117 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\DataPages\PopulationUploadPage.razor"
       
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

    SfUploader UploadObj;
    SfSpinner UploadingSpinner;
    SfGrid<View2022Icanpopulation> PopulationGrid;
    string MessageResponse { get; set; }
    public Query ChildQuery = new Query();
    private SearchPanel InputModel = new SearchPanel();
    private List<View2022ARegions> RegionData { get; set; }
    private List<ViewADistricts> DistrictData { get; set; }
    private List<ViewASubcounties> SubcountyData { get; set; }

    bool isEnabled { get; set; } = false;
    bool isSubcountyEnabled { get; set; } = false;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            await base.OnInitializedAsync();
            if (!userManagement.IsSignedIn())
            {
                Navigation.NavigateTo("/", true);
            }
            else
            {
                InputModel = new SearchPanel();
                using (var db = new SPToCoreContext())
                {
                    RegionData = db.View2022ARegions.ToList();
                    DistrictData = db.ViewADistricts.ToList();
                    SubcountyData = db.ViewASubcounties.ToList();
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
                DistrictData = db.ViewADistricts.Where(o => args.Value.Any(a => a == o.RegionId) == true).ToList();
                isEnabled = true;
            }
        }
    }

    public void OnDistrictChange(Syncfusion.Blazor.DropDowns.MultiSelectChangeEventArgs<int?[]> args)
    {
        if (args.Value != null)
        {
            using (var db = new USAID_ICANContext())
            {
                SubcountyData = db.ViewASubcounties.Where(o => args.Value.Any(a => a == o.DistrictId) == true).ToList();
                isSubcountyEnabled = true;
            }
        }
    }

    private void ClearSearchBtnClick()
    {
        InputModel = new SearchPanel();
    }

    private async void OnLoadRecords()
    {
        try
        {
            string _RegionId = null;
            if (InputModel.RegionId != null)
            {
                _RegionId = string.Join(",", InputModel.RegionId);
            }

            string _DistrictId = null;
            if (InputModel.DistrictId != null)
            {
                _DistrictId = string.Join(",", InputModel.DistrictId);
            }
            string _SubcountyId = null;
            if (InputModel.SubcountyId != null)
            {
                _SubcountyId = string.Join(",", InputModel.SubcountyId);
            }
            ChildQuery = new Query().AddParams("RegionId",_RegionId).AddParams("SubcountyId", _SubcountyId).AddParams("DistrictId", _DistrictId);
        }
        catch (Exception ex)
        {
            await ToastObj.Show(new ToastModel { Title = "Error!", Content = ex.ToString(), CssClass = "e-toast-danger", Icon = "e-error toast-icons" });
        }
    }

    public async Task OnChange(UploadChangeEventArgs args)
    {
        try
        {
            MessageResponse = null;
            await UploadingSpinner.ShowAsync();
            foreach (var file in args.Files)
            {
                using (ExcelEngine excelEngine = new ExcelEngine())
                {

                    //Instantiate the Excel application object
                    IApplication application = excelEngine.Excel;

                    file.Stream.Position = 0;
                    //Set the default application version
                    application.DefaultVersion = ExcelVersion.Xlsx;
                    IWorkbook workbook = excelEngine.Excel.Workbooks.Open(file.Stream);

                    //Get the first worksheet in the workbook into IWorksheet
                    IWorksheet worksheet = workbook.Worksheets[0];
                    if (worksheet.Range["A1"].Value.Contains("Region") && worksheet.Range["B1"].Value.Contains("District")
                        && worksheet.Range["C1"].Value.Contains("ICAN")
                        )
                    {
                        OnaIcanpopulation icanpop = new OnaIcanpopulation();
                        using (var db = new USAID_ICANContext())
                        {
                            var RegionData = db.ARegions.ToList();
                            var DistrictData = db.ADistricts.ToList();

                            for (int row = 2; row <= worksheet.UsedRange.LastRow; row++)
                            {
                                icanpop = new OnaIcanpopulation();
                                int DistrictId = 0;
                                int SubcountyId = 0;
                                if (worksheet.IsRowVisible(row))
                                {
                                    for (int column = 1; column <= worksheet.UsedRange.LastColumn; column++)
                                    {
                                        switch (column)
                                        {
                                            case 1:
                                                if (!string.IsNullOrEmpty(worksheet.Range[row, column].Value.Trim()) && (worksheet.Range[row, column].Value.Trim() != ""))
                                                {
                                                    string sn = worksheet.Range[row, column].Value.ToString().ToLower().Replace(" ", "");
                                                    var _region = RegionData.FirstOrDefault(o => o.LocRegion.ToLower().Replace(" ", "") == sn);
                                                    if (_region != null)
                                                    {
                                                        //icanpop.ImplementingPartnerId = _IP.ImplementingPartnerId;
                                                    }
                                                    else
                                                    {
                                                        ARegions reg = new ARegions();
                                                        reg.LocRegion = sn;
                                                        int id = 1;
                                                        var last = db.ARegions.OrderBy(o => o.Id).ToList().LastOrDefault();
                                                        if (last != null)
                                                        {
                                                            id = (last.Id + 1);
                                                        }
                                                        reg.Id = id;

                                                        db.ARegions.Add(reg);
                                                        db.SaveChanges();

                                                        RegionData = db.ARegions.ToList();
                                                        //save region id into popn table
                                                        //icanpop.region = reg.Id;
                                                    }

                                                }
                                                break;
                                            case 2:
                                                if (!string.IsNullOrEmpty(worksheet.Range[row, column].Value.Trim()) && (worksheet.Range[row, column].Value.Trim() != ""))
                                                {
                                                    string sn = worksheet.Range[row, column].Value.ToString().ToLower().Replace(" ", "");
                                                    var _district = DistrictData.FirstOrDefault(o => o.LocDistrict.ToLower().Replace(" ", "") == sn);

                                                    if (_district != null)
                                                    {
                                                        //icanpop.ImplementingPartnerId = _IP.ImplementingPartnerId;
                                                    }
                                                    else
                                                    {
                                                        ADistricts dis = new ADistricts();

                                                        dis.LocDistrict = sn;
                                                        int id = 1;
                                                        var last = db.ADistricts.OrderBy(o => o.Id).ToList().LastOrDefault();
                                                        if (last != null)
                                                        {
                                                            id = (last.Id + 1);
                                                        }
                                                        dis.Id = id;

                                                        db.ADistricts.Add(dis);
                                                        db.SaveChanges();

                                                        DistrictData = db.ADistricts.ToList();
                                                        //DistrictId into popn table
                                                        //icanpop.region = reg.Id;
                                                    }

                                                }
                                                break;
                                            case 3:
                                                if (!string.IsNullOrEmpty(worksheet.Range[row, column].Value.Trim()) && (worksheet.Range[row, column].Value.Trim() != ""))
                                                {
                                                    string subcounty = worksheet.Range[row, column].Value.Trim().Replace(" ", "");
                                                    icanpop.Icansubcounty = subcounty;
                                                }
                                                break;
                                            case 4:
                                                if (!string.IsNullOrEmpty(worksheet.Range[row, column].Value.Trim()) && (worksheet.Range[row, column].Value.Trim() != ""))
                                                {
                                                    string popn = worksheet.Range[row, column].Value.Trim().Replace("'", "");
                                                    icanpop.PopnTotalInIcanareas = Convert.ToDouble(popn);
                                                }
                                                break;
                                            case 5:
                                                if (!string.IsNullOrEmpty(worksheet.Range[row, column].Value.Trim()) && (worksheet.Range[row, column].Value.Trim() != ""))
                                                {
                                                    string popnfemale = worksheet.Range[row, column].Value.Trim().Replace("'", "");
                                                    icanpop.PopnFemale = Convert.ToDouble(popnfemale);
                                                }
                                                break;
                                            case 6:
                                                if (!string.IsNullOrEmpty(worksheet.Range[row, column].Value.Trim()) && (worksheet.Range[row, column].Value.Trim() != ""))
                                                {
                                                    string lessthan1YrNumber = worksheet.Range[row, column].Value.Trim().Replace("'", "");
                                                    icanpop.Popnlessthan1YrNumber = Convert.ToDouble(lessthan1YrNumber);
                                                }
                                                break;
                                            case 7:
                                                if (!string.IsNullOrEmpty(worksheet.Range[row, column].Value.Trim()) && (worksheet.Range[row, column].Value.Trim() != ""))
                                                {
                                                    string lessthan5Yrs = worksheet.Range[row, column].Value.Trim().Replace("'", "");
                                                    icanpop.Popnlessthan5Yrs = Convert.ToDouble(lessthan5Yrs);
                                                }
                                                break;
                                            case 8:
                                                if (!string.IsNullOrEmpty(worksheet.Range[row, column].Value.Trim()) && (worksheet.Range[row, column].Value.Trim() != ""))
                                                {
                                                    string lessthan2Yrs = worksheet.Range[row, column].Value.Trim().Replace("'", "");
                                                    icanpop.Popnlessthan2Yrs = Convert.ToDouble(lessthan2Yrs);
                                                }
                                                break;

                                            case 9:
                                                if (!string.IsNullOrEmpty(worksheet.Range[row, column].Value.Trim()) && (worksheet.Range[row, column].Value.Trim() != ""))
                                                {
                                                    string p1564yrs = worksheet.Range[row, column].Value.Trim().Replace("'", "");
                                                    icanpop.Popn1564yrs = Convert.ToDouble(p1564yrs);
                                                }
                                                break;
                                        }
                                    }

                                    OnaIcanpopulation _table = db.OnaIcanpopulation.FirstOrDefault(o => o.Icansubcounty == icanpop.Icansubcounty);
                                    //OnaIcanpopulation _table = db.OnaIcanpopulation.FirstOrDefault();

                                    if (_table == null)
                                    {
                                        int id = 1;
                                        var last = db.OnaIcanpopulation.OrderBy(o => o.Id).ToList().LastOrDefault();
                                        if (last != null)
                                        {
                                            id = (last.Id + 1);
                                        }
                                        icanpop.Id = id;
                                        try
                                        {
                                            icanpop.LastUploadDate = DateTime.Now;
                                            db.OnaIcanpopulation.Add(icanpop);
                                            db.SaveChanges();
                                        }
                                        catch (Exception ex)
                                        {
                                            throw ex;
                                        }
                                    }
                                    else
                                    {

                                        try
                                        {
                                            icanpop.Id = _table.Id;

                                            icanpop.LastUploadDate = DateTime.Now;
                                            db.Entry(_table).CurrentValues.SetValues(icanpop);
                                            db.Entry(_table).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                                            db.SaveChanges();
                                        }
                                        catch (Exception ex)
                                        {
                                            throw ex;
                                        }
                                    }
                                }

                            }
                        }
                    }

                    else
                    {
                        if (string.IsNullOrEmpty(MessageResponse))
                        {
                            MessageResponse = "Failure: You are uploading a wrong file.";
                        }
                    }
                    file.Stream.Close();
                }

            }
        }
        catch (Exception ex)
        {
            MessageResponse = "error: " + ex.Message.ToString();
        }
        finally
        {
            if (string.IsNullOrEmpty(MessageResponse))
            {
                MessageResponse = "Success: All the records were uploaded successfully. Please refresh the page to upload again";
            }
            await UploadingSpinner.HideAsync();
            await Task.CompletedTask;
            PopulationGrid.Refresh();
            StateHasChanged();
        }


    }
    public class PopulationAdapter : DataAdaptor
    {
        public IToastService toastService;
        public PopulationAdapter(IToastService ts)
        {
            toastService = ts;
        }

        public override async Task<Object> ReadAsync(DataManagerRequest dataManagerRequest, string key = null)
        {
            var data = new List<View2022Icanpopulation>();

            try
            {
                string RegionId = null;
                string DistrictId = null;
                string SubcountyId = null;

                if (dataManagerRequest.Params != null && dataManagerRequest.Params.Count > 0)
                {
                    var val = dataManagerRequest.Params;

                    if (val.FirstOrDefault(o => o.Key == "RegionId").Value != null)
                    {
                        RegionId = val.FirstOrDefault(o => o.Key == "RegionId").Value.ToString();
                    }

                    if (val.FirstOrDefault(o => o.Key == "DistrictId").Value != null)
                    {
                        DistrictId = val.FirstOrDefault(o => o.Key == "DistrictId").Value.ToString();
                    }
                    if (val.FirstOrDefault(o => o.Key == "SubcountyId").Value != null)
                    {
                        SubcountyId = val.FirstOrDefault(o => o.Key == "SubcountyId").Value.ToString();
                    }
                }

                using (var dbContext = new USAID_ICANContext())
                {
                    string[] _regionId = new string[] { };
                    if (!string.IsNullOrEmpty(RegionId))
                    {
                        _regionId = RegionId.Split(',');
                    }
                    string[] _district = new string[] { };
                    if (!string.IsNullOrEmpty(DistrictId))
                    {
                        _district = DistrictId.Split(',');
                    }
                    string[] _SubcountyId = new string[] { };
                    if (!string.IsNullOrEmpty(SubcountyId))
                    {
                        _SubcountyId = SubcountyId.Split(',');
                    }
                    data = await dbContext.View2022Icanpopulation.Where(o => (_regionId.Length == 0 || (o.RegionId != null && _regionId.Any(a => a == o.RegionId.ToString()) == true) && (_district.Length == 0 || (o.DistrictId != null && _district.Any(a => a == o.DistrictId.ToString()) == true)) && (_SubcountyId.Length == 0 || (o.SubcountyId != null && _SubcountyId.Any(a => a == o.SubcountyId.ToString()) == true)))).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message.ToString());
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
                    GridData = DataUtil.Group<View2022Icanpopulation>(GridData, group, dataManagerRequest.Aggregates, 0, dataManagerRequest.GroupByFormatter);
                }
            }
            return dataManagerRequest.RequiresCounts ? new DataResult() { Result = GridData, Count = _count, Aggregates = aggregates } : (object)GridData;
        }

    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager Navigation { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private UserManagement userManagement { get; set; }
    }
}
#pragma warning restore 1591
