#pragma checksum "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\SpreadSheet\SpreadSheetPage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1ec5f6dc9dc2d88055f3dc908d09022777356f88"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_SpreadSheet_SpreadSheetPage), @"mvc.1.0.razor-page", @"/Pages/SpreadSheet/SpreadSheetPage.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "/SpreadSheetPage")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1ec5f6dc9dc2d88055f3dc908d09022777356f88", @"/Pages/SpreadSheet/SpreadSheetPage.cshtml")]
    #nullable restore
    public class Pages_SpreadSheet_SpreadSheetPage : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/EJ2/material.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/EJ2/ej2.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", "spreadsheet", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("openUrl", "/api/SpreedSheetApi", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("created", "created", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Syncfusion.EJ2.Spreadsheet.Spreadsheet __Syncfusion_EJ2_Spreadsheet_Spreadsheet;
        private global::Syncfusion.EJ2.ScriptRenderer __Syncfusion_EJ2_ScriptRenderer;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<!-- Syncfusion Essential JS 2 Styles -->\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1ec5f6dc9dc2d88055f3dc908d09022777356f885045", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<!-- Syncfusion Essential JS 2 Scripts -->\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1ec5f6dc9dc2d88055f3dc908d09022777356f886209", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<style>\r\n    .e-ribbon {\r\n        background-color: #fafafa;\r\n        height: fit-content;\r\n    }\r\n</style>\r\n");
#nullable restore
#line 21 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\SpreadSheet\SpreadSheetPage.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("ejs-spreadsheet", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1ec5f6dc9dc2d88055f3dc908d09022777356f887640", async() => {
                WriteLiteral("\r\n\r\n");
            }
            );
            __Syncfusion_EJ2_Spreadsheet_Spreadsheet = CreateTagHelper<global::Syncfusion.EJ2.Spreadsheet.Spreadsheet>();
            __tagHelperExecutionContext.Add(__Syncfusion_EJ2_Spreadsheet_Spreadsheet);
            __Syncfusion_EJ2_Spreadsheet_Spreadsheet.Id = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Syncfusion_EJ2_Spreadsheet_Spreadsheet.OpenUrl = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
#nullable restore
#line 22 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\SpreadSheet\SpreadSheetPage.cshtml"
__Syncfusion_EJ2_Spreadsheet_Spreadsheet.ShowRibbon = false;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("showRibbon", __Syncfusion_EJ2_Spreadsheet_Spreadsheet.ShowRibbon, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 22 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\SpreadSheet\SpreadSheetPage.cshtml"
__Syncfusion_EJ2_Spreadsheet_Spreadsheet.ShowFormulaBar = false;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("showFormulaBar", __Syncfusion_EJ2_Spreadsheet_Spreadsheet.ShowFormulaBar, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 22 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\SpreadSheet\SpreadSheetPage.cshtml"
__Syncfusion_EJ2_Spreadsheet_Spreadsheet.AllowEditing = false;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("allowEditing", __Syncfusion_EJ2_Spreadsheet_Spreadsheet.AllowEditing, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 22 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\SpreadSheet\SpreadSheetPage.cshtml"
__Syncfusion_EJ2_Spreadsheet_Spreadsheet.AllowOpen = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("allowOpen", __Syncfusion_EJ2_Spreadsheet_Spreadsheet.AllowOpen, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Syncfusion_EJ2_Spreadsheet_Spreadsheet.Created = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<script>\r\n    let DefaultData =");
#nullable restore
#line 27 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\SpreadSheet\SpreadSheetPage.cshtml"
                Write(Html.Raw(Json.Serialize(ViewBag.DefaultData)));

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n    let filename =");
#nullable restore
#line 28 "D:\MVCProjects\BlazorProject\USAIDICAN\USAIDICANBLAZOR16June2022\USAIDICANBLAZOR\Pages\SpreadSheet\SpreadSheetPage.cshtml"
             Write(Html.Raw(Json.Serialize(ViewBag.filename)));

#line default
#line hidden
#nullable disable
            WriteLiteral(@";
    function created() {
        /*let url = window.location.protocol + ""//"" + window.location.hostname + "":"" + window.location.port + ""/DownloadReport/MTSPREPORT.xlsx"";*/
        let url = window.location.protocol + ""//"" + window.location.hostname + "":"" + window.location.port + ""/DownloadReport/"" + filename;
        /*alert(url);*/
        var spreadsheet = ej.base.getComponent(document.getElementById('spreadsheet'), 'spreadsheet');
        fetch(url) // fetch the remote url
            .then((response) => {
                response.blob().then((fileBlob) => { // convert the excel file to blob
                    var file = new File([fileBlob], ""Sample.xlsx""); //convert the blob into file
                    spreadsheet.open({ file: file }); // open the file into Spreadsheet
                })
            })
    }

</script>

<!-- Syncfusion Essential JS 2 ScriptManager -->
");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("ejs-scripts", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1ec5f6dc9dc2d88055f3dc908d09022777356f8812656", async() => {
            }
            );
            __Syncfusion_EJ2_ScriptRenderer = CreateTagHelper<global::Syncfusion.EJ2.ScriptRenderer>();
            __tagHelperExecutionContext.Add(__Syncfusion_EJ2_ScriptRenderer);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<USAIDICANBLAZOR.Pages.SpreadSheet.SpreadSheetPageModel> Html { get; private set; } = default!;
        #nullable disable
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<USAIDICANBLAZOR.Pages.SpreadSheet.SpreadSheetPageModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<USAIDICANBLAZOR.Pages.SpreadSheet.SpreadSheetPageModel>)PageContext?.ViewData;
        public USAIDICANBLAZOR.Pages.SpreadSheet.SpreadSheetPageModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
