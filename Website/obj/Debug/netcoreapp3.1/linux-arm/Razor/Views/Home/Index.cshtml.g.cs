#pragma checksum "C:\Users\tbarr\Desktop\Barron Racing\Site\Website\Website\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "925288a9f63eeedc45c4ef53c9718fb7d1c796df"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"925288a9f63eeedc45c4ef53c9718fb7d1c796df", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"971d47fbe439df3910fb180c393f0b2f21208c79", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IndexViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Standings", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "RaceResults", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Images/loader.gif"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width: 50%;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/index.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\tbarr\Desktop\Barron Racing\Site\Website\Website\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Season Standings";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""container bg-dark text-light"" style=""margin-bottom: 2em;"">
    <div class=""row"">
        <div class=""col-md-7 col-sm-6"">
            <div class=""row"">
                <div class=""col-md-12 col-sm-12 text-center"" style=""min-height: 450px; background-color: #f8f9fa; background-image: url(Images/topstory.png); background-position: center center; background-size: cover; padding: 5em; border: 4px solid #343a40;"">
                    <!--<img src=""./Images/Icons/");
#nullable restore
#line 11 "C:\Users\tbarr\Desktop\Barron Racing\Site\Website\Website\Views\Home\Index.cshtml"
                                            Write(Model.CurrentYear);

#line default
#line hidden
#nullable disable
            WriteLiteral("/");
#nullable restore
#line 11 "C:\Users\tbarr\Desktop\Barron Racing\Site\Website\Website\Views\Home\Index.cshtml"
                                                                Write(Model.HeadlineDriver.Number + ".png");

#line default
#line hidden
#nullable disable
            WriteLiteral("\" style=\"width: 60%;\" />-->\r\n                    <div class=\"text-center\" style=\"position: absolute; bottom: 0; left: 0; width: 100%; background-color: #fef000; color: #343a40;\">\r\n                        <b>");
#nullable restore
#line 13 "C:\Users\tbarr\Desktop\Barron Racing\Site\Website\Website\Views\Home\Index.cshtml"
                      Write(Model.MainHeadline);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</b>
                    </div>
                </div>
            </div>
            <div class=""row"">
                <div class=""col-md-12 col-sm-12"">
                    <h3><span style=""width: 100%; text-align: center;"">Headlines</span></h3>
                    <ul id=""headline-list"" style=""list-style-type: none; margin: 0; padding: 0;""></ul>
                </div>
            </div>
        </div>
        <div class=""col-md-5 col-sm-6 bg-light"">
            <div class=""card"">
                <div class=""card-header text-dark""><span id=""cur_year"">");
#nullable restore
#line 26 "C:\Users\tbarr\Desktop\Barron Racing\Site\Website\Website\Views\Home\Index.cshtml"
                                                                  Write(Model.CurrentYear);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span> Season Top 10</div>
                <div class=""card-body"">
                    <table class=""table table-responsive"" id=""top10-list"">
                        <thead>
                            <tr>
                                <th>Position</th>
                                <th>Driver</th>
                                <th>Points</th>
                                <th>Behind</th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 38 "C:\Users\tbarr\Desktop\Barron Racing\Site\Website\Website\Views\Home\Index.cshtml"
                              
                                int position = 1;
                                int top = Model.Top10.First().Points;
                                foreach (var d in Model.Top10)
                                {


#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <td>");
#nullable restore
#line 45 "C:\Users\tbarr\Desktop\Barron Racing\Site\Website\Website\Views\Home\Index.cshtml"
                                       Write(position);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 46 "C:\Users\tbarr\Desktop\Barron Racing\Site\Website\Website\Views\Home\Index.cshtml"
                                       Write(d.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 47 "C:\Users\tbarr\Desktop\Barron Racing\Site\Website\Website\Views\Home\Index.cshtml"
                                       Write(d.Points);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 48 "C:\Users\tbarr\Desktop\Barron Racing\Site\Website\Website\Views\Home\Index.cshtml"
                                        Write(d.Points - top);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                                    </tr>\r\n");
#nullable restore
#line 50 "C:\Users\tbarr\Desktop\Barron Racing\Site\Website\Website\Views\Home\Index.cshtml"
                                    position++;
                                }
                            

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n                </div>\r\n                <div class=\"card-footer\" style=\"text-align: right;\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "925288a9f63eeedc45c4ef53c9718fb7d1c796df11274", async() => {
                WriteLiteral("Full Standings >>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                </div>
            </div>
        </div>
    </div>
    <div class=""row"">
        <div class=""col-md-7 col-sm-12 bg-light text-dark"" style=""padding-top: 2em;"">
            <h4>Upcoming Schedule</h4>
            <table class=""table table-responsive"" id=""upcoming-schedule"">
                <tr>
                    <th>Race Number</th>
                    <th>Race Name</th>
                    <th>Location</th>
                </tr>
            </table>
            <div style=""text-align: right;"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "925288a9f63eeedc45c4ef53c9718fb7d1c796df13405", async() => {
                WriteLiteral("Full Schedule >>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-year", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 73 "C:\Users\tbarr\Desktop\Barron Racing\Site\Website\Website\Views\Home\Index.cshtml"
                                                                                  WriteLiteral(Model.CurrentYear);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["year"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-year", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["year"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </div>
        </div>
        <div class=""col-md-5 col-sm-12 bg-light text-dark"" style=""padding-top: 2em;"">
            <h4>Upcoming Track Stats</h4>
            
            <div class=""card"">
                <div class=""card-header bg-light"">
                    <div class=""text-center"">
                        <img id=""track_img""");
            BeginWriteAttribute("src", " src=\"", 3926, "\"", 3932, 0);
            EndWriteAttribute();
            WriteLiteral(" style=\"width: 50%;\" />\r\n                    </div>\r\n                </div>\r\n                <div class=\"card-body\">\r\n                    <div id=\"track_stats_loader\" class=\"col-md-12 text-center\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "925288a9f63eeedc45c4ef53c9718fb7d1c796df16778", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    </div>
                    <div id=""track_stats_info"">
                        <table class=""table"" style=""width: 100%;"">
                            <thead>
                                <tr>
                                    <th style=""border: 0px;"">Length</th>
                                    <td><span id=""track_length"">length</span></td>
                                </tr>
                                <tr>
                                    <th style=""border: 0px;"">Type</th>
                                    <td><span id=""track_type"">type</span></td>
                                </tr>
                                <tr>
                                    <th style=""border: 0px;"">Laps</th>
                                    <td><span id=""race_laps"">laps</span></td>
                                </tr>
                                <tr>
                                    <th style=""border: 0px;"">Previous Winner</th>
                           ");
            WriteLiteral(@"         <td><span id=""prev_winner"">winner</span></td>
                                </tr>
                                <tr>
                                    <th style=""border: 0px;"">Most Wins</th>
                                    <td><span id=""track_wins"">wins</span></td>
                                </tr>
                                <tr>
                                    <th style=""border: 0px;"">Laps Led</th>
                                    <td><span id=""track_laps"">led</span></td>
                                </tr>
                            </thead>
                        </table>
                    </div>
                </div>                
            </div>
        </div>
    </div>
</div>
");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "925288a9f63eeedc45c4ef53c9718fb7d1c796df19732", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
