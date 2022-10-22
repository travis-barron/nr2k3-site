#pragma checksum "C:\Users\tbarr\Desktop\Barron Racing\Site\Website\Website\Views\Home\Standings.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bc5f13b09ece2bc130ca746747b010d03fabe97b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Standings), @"mvc.1.0.view", @"/Views/Home/Standings.cshtml")]
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
#nullable restore
#line 1 "C:\Users\tbarr\Desktop\Barron Racing\Site\Website\Website\Views\_ViewImports.cshtml"
using Website;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\tbarr\Desktop\Barron Racing\Site\Website\Website\Views\_ViewImports.cshtml"
using Website.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bc5f13b09ece2bc130ca746747b010d03fabe97b", @"/Views/Home/Standings.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"971d47fbe439df3910fb180c393f0b2f21208c79", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Standings : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<string[]>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/standings.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\tbarr\Desktop\Barron Racing\Site\Website\Website\Views\Home\Standings.cshtml"
  
    ViewData["Title"] = "Season Standings";

#line default
#line hidden
#nullable disable
            WriteLiteral("<input type=\"hidden\" id=\"activeYear\"");
            BeginWriteAttribute("value", " value=\"", 112, "\"", 143, 1);
#nullable restore
#line 5 "C:\Users\tbarr\Desktop\Barron Racing\Site\Website\Website\Views\Home\Standings.cshtml"
WriteAttributeValue("", 120, ViewData["ActiveYear"], 120, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n<input type=\"hidden\" id=\"activeWeek\"");
            BeginWriteAttribute("value", " value=\"", 185, "\"", 216, 1);
#nullable restore
#line 6 "C:\Users\tbarr\Desktop\Barron Racing\Site\Website\Website\Views\Home\Standings.cshtml"
WriteAttributeValue("", 193, ViewData["ActiveWeek"], 193, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n<input type=\"hidden\" id=\"playoffsSystem\"");
            BeginWriteAttribute("value", " value=\"", 262, "\"", 297, 1);
#nullable restore
#line 7 "C:\Users\tbarr\Desktop\Barron Racing\Site\Website\Website\Views\Home\Standings.cshtml"
WriteAttributeValue("", 270, ViewData["PlayoffsSystem"], 270, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("  />\r\n<div class=\"container-fluid\">\r\n    <div class=\"row\">\r\n        <div class=\"col-md-4 offset-md-4 form-group\">\r\n            <label for=\"year_select\">Year</label>\r\n            <select id=\"year_select\" class=\"form-control\">\r\n");
#nullable restore
#line 13 "C:\Users\tbarr\Desktop\Barron Racing\Site\Website\Website\Views\Home\Standings.cshtml"
                 foreach (string year in Model[0])
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bc5f13b09ece2bc130ca746747b010d03fabe97b5984", async() => {
#nullable restore
#line 15 "C:\Users\tbarr\Desktop\Barron Racing\Site\Website\Website\Views\Home\Standings.cshtml"
                                                                Write(year.Substring(year.Length - 4));

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 15 "C:\Users\tbarr\Desktop\Barron Racing\Site\Website\Website\Views\Home\Standings.cshtml"
                       WriteLiteral(year.Substring(year.Length - 4));

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 16 "C:\Users\tbarr\Desktop\Barron Racing\Site\Website\Website\Views\Home\Standings.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </select>\r\n        </div>\r\n\r\n        <div class=\"col-md-4 form-group\">\r\n            <label for=\"week_select\">Week</label>\r\n            <select id=\"week_select\" class=\"form-control\">\r\n");
#nullable restore
#line 23 "C:\Users\tbarr\Desktop\Barron Racing\Site\Website\Website\Views\Home\Standings.cshtml"
                 foreach (string week in Model[1])
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bc5f13b09ece2bc130ca746747b010d03fabe97b8574", async() => {
#nullable restore
#line 25 "C:\Users\tbarr\Desktop\Barron Racing\Site\Website\Website\Views\Home\Standings.cshtml"
                                     Write(week);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 25 "C:\Users\tbarr\Desktop\Barron Racing\Site\Website\Website\Views\Home\Standings.cshtml"
                       WriteLiteral(week);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 26 "C:\Users\tbarr\Desktop\Barron Racing\Site\Website\Website\Views\Home\Standings.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </select>
        </div>
    </div>

    <div class=""text-center col-md-12"">
        <h1 class=""display-4""><span id=""cur_year""></span> <span id=""cup_desc"">PRL Cup</span> Standings</h1>
        <div id=""standings_guide"" style=""display: none; width: 100%;""><div class=""box prl-yellow""></div> - In the <span id=""standings_type_text"">playoffs</span></div>
        <table class=""table table-bordered table-responsive"" id=""season_standings"">
            <thead>
                <tr>
                    <th>Position</th>
                    <th>Driver</th>
                    <th>Number</th>
                    <th>Points</th>
                    <th>Behind</th>
                    <th>Starts</th>
                    <th>Wins</th>
                    <th>Top 5s</th>
                    <th>Top 10s</th>
                    <th>DNFs</th>
                    <th>Laps Led</th>
                    <th>Laps</th>
                    <th>Avg Fin</th>
                </tr>
            </thead>
            WriteLiteral(@"
            <tbody>
            </tbody>
        </table>
    </div>
</div>

<div class=""modal fade"" id=""seasonModal"" tabindex=""-3"" style=""z-index: 1043;"" aria-labelledby=""seasonModal"" aria-hidden=""true"">
    <div class=""modal-dialog modal-lg"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""seasonModalTitle"">Season Stats</h5>
            </div>
            <div class=""modal-body"">
                <div id=""season-stats"">
                    <div class=""row"">
                        <div class=""col-md-2""></div>
                        <div class=""col-md-3"">
                            <b>Season: </b> <span class=""float-right"" id=""seasonModalYear""></span><br />
                            <b>Races: </b> <span class=""float-right"" id=""seasonModalRaces""></span><br />
                            <b>Wins: </b> <span class=""float-right"" id=""seasonModalWins""></span><br />
                            <b>DNFs: </b> <span class=""f");
            WriteLiteral(@"loat-right"" id=""seasonModalDNFs""></span><br />
                        </div>
                        <div class=""col-md-2""></div>
                        <div class=""col-md-3"">
                            <b>Rank: </b> <span class=""float-right"" id=""seasonModalRank""></span><br />
                            <b>Laps: </b> <span class=""float-right"" id=""seasonModalLaps""></span><br />
                            <b>Led: </b> <span class=""float-right"" id=""seasonModalLed""></span><br />
                            <b>Average Finish: </b> <span class=""float-right"" id=""seasonModalAvg""></span><br />
                        </div>
                        <div class=""col-md-2""></div>
                    </div>
                </div>
                <hr />
                <table id=""driverSeasonTable"" class=""table table-bordered table-responsive-lg"">
                    <thead>
                        <tr>
                            <th></th>
                            <th>Race</th>
                   ");
            WriteLiteral(@"         <th>Track</th>
                            <th>Start</th>
                            <th>Finish</th>
                            <th>Laps</th>
                            <th>Laps Led</th>
                            <th>Status</th>
                        </tr>
                    </thead>
                    <tbody>
                    </tbody>
                </table>
            </div>
            <div class=""modal-footer"">
                <a id=""fullDriverStatsLink"" target=""_blank"" class=""btn btn-primary"">Full Stats</a>
                <button onclick=""$('#seasonModal').modal('hide');"" type=""button"" class=""btn btn-secondary"" data-bs-dismiss=""modal"">Close</button>
            </div>
        </div>
    </div>
</div>

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bc5f13b09ece2bc130ca746747b010d03fabe97b14618", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("defer", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<script>

    function ShowSeasonModal(driverId, year, rank, parentRow) {
        $('#seasonModal').modal('show');
        seasonModalOpen = 1;

        $('#seasonModalTitle').text(parentRow[0].children[1].innerText + "" Season Stats"");
        $('#seasonModalYear').text(year);
        $('#seasonModalRaces').text(parentRow[0].children[5].innerText);
        $('#seasonModalWins').text(parentRow[0].children[6].innerText);
        $('#seasonModalDNFs').text(parentRow[0].children[9].innerText);
        $('#seasonModalRank').text(parentRow[0].children[0].innerText);
        $('#seasonModalLaps').text(parentRow[0].children[11].innerText);
        $('#seasonModalLed').text(parentRow[0].children[10].innerText);
        $('#seasonModalAvg').text(parentRow[0].children[12].innerText);
        $('#fullDriverStatsLink').prop('href', './Driver?driver=' + parentRow[0].children[1].innerText);

        $.ajax({
            'url': './GetDriverSeasonStats?driverId=' + driverId + '&seasonId=' + year + '&year='");
            WriteLiteral(@" + year,
            'success': function (data) {
                $('#fullSeasonLink').attr(""href"", ""./RaceResults?year="" + parentRow[0].children[0].innerText);
                var seasonTable = $(""#driverSeasonTable"").DataTable();
                seasonTable.destroy();
                var tbody = $('#driverSeasonTable tbody');
                tbody.empty();
                for (var i = 0; i < data.length; i++) {
                    let row = $('<tr></tr>');
                    row.append($('<td class=""text-right"">' + data[i].raceNum + '</td>'));
                    row.append($('<td class=""text-right"">' + data[i].raceName + '</td>'));
                    row.append($('<td class=""text-right"">' + data[i].track + '</td>'));
                    row.append($('<td class=""text-right"">' + data[i].start + '</td>'));
                    row.append($('<td class=""text-right"">' + data[i].finish + '</td>'));
                    row.append($('<td class=""text-right"">' + data[i].laps + '</td>'));
             ");
            WriteLiteral(@"       row.append($('<td class=""text-right"">' + data[i].led + '</td>'));
                    row.append($('<td class=""text-right"">' + data[i].status + '</td>'));
                    tbody.append(row);
                }
                $('#driverSeasonTable').dataTable({
                    'paging': false
                });
            }
        });
    }
</script>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<string[]>> Html { get; private set; }
    }
}
#pragma warning restore 1591