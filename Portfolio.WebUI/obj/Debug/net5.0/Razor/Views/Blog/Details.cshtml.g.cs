#pragma checksum "C:\Users\Lenovo\Desktop\TestPortfolio\Portfolio\Portfolio.WebUI\Views\Blog\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c0964cf6bba807991e662443de41091d9f26d519"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Blog_Details), @"mvc.1.0.view", @"/Views/Blog/Details.cshtml")]
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
#line 2 "C:\Users\Lenovo\Desktop\TestPortfolio\Portfolio\Portfolio.WebUI\Views\_ViewImports.cshtml"
using Portfolio.WebUI.Models.Entity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Lenovo\Desktop\TestPortfolio\Portfolio\Portfolio.WebUI\Views\_ViewImports.cshtml"
using Portfolio.WebUI.Controllers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Lenovo\Desktop\TestPortfolio\Portfolio\Portfolio.WebUI\Views\_ViewImports.cshtml"
using Portfolio.WebUI.Models.ViewModel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c0964cf6bba807991e662443de41091d9f26d519", @"/Views/Blog/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"03d9da9de8f2dcb1fa76cdd8b46428e1d81f3aa2", @"/Views/_ViewImports.cshtml")]
    public class Views_Blog_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BlogPosts>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/uploads/images/img-1.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/uploads/images/avatar-1.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/uploads/images/avatar-2.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Lenovo\Desktop\TestPortfolio\Portfolio\Portfolio.WebUI\Views\Blog\Details.cshtml"
  
    ViewData["Title"] = "Blog Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n    <div class=\"inside-sec blog\">\r\n        <!-- BIO AND SKILLS -->\r\n        <h5 class=\"tittle\">");
#nullable restore
#line 12 "C:\Users\Lenovo\Desktop\TestPortfolio\Portfolio\Portfolio.WebUI\Views\Blog\Details.cshtml"
                      Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n\r\n        <!-- Blog -->\r\n        <article class=\"blog-post width-100 padding-25\">\r\n            <div class=\"post-img\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "c0964cf6bba807991e662443de41091d9f26d5195822", async() => {
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
            WriteLiteral("\r\n                <span class=\"date-in\">");
#nullable restore
#line 18 "C:\Users\Lenovo\Desktop\TestPortfolio\Portfolio\Portfolio.WebUI\Views\Blog\Details.cshtml"
                                 Write(Model.PublishDate);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
            </div>

            <!-- BLOG DETAIL -->
            <h4 class=""font-normal"">Faster Response</h4>
            <span class=""post-bt"">by <span class=""text-color-primary"">Admin</span></span>
            <ul class=""post-info"">
                <li> <i class=""fa fa-comments-o""></i>97 </li>
                <li> <i class=""fa fa-eye""></i>565 </li>
                <li> <i class=""fa fa-bookmark-o""></i>Photography </li>
                <li>  </li>
            </ul>
            <p>
               
 ");
#nullable restore
#line 32 "C:\Users\Lenovo\Desktop\TestPortfolio\Portfolio\Portfolio.WebUI\Views\Blog\Details.cshtml"
Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </p>
            
            
            <div class=""auther-name text-center margin-top-50"">
                <h6 class=""font-12px margin-top-20 margin-bottom-10"">WHITE SHADOW WALKER</h6>
                <span class=""font-16px font-crimson font-italic"">Writer/Personal blog</span>
            </div>



            <div class=""next-prev"">
                <div class=""row"">
                    <div class=""col-md-6 text-left""><a href=""#."" class=""font-16px font-crimson text-uppercase""><i class=""fa fa-long-arrow-left margin-right-15""></i> PREVIOUS Article</a></div>
                    <div class=""col-md-6 text-right""><a href=""#."" class=""font-16px font-crimson text-uppercase"">Next Article<i class=""fa fa-long-arrow-right margin-left-15""></i></a></div>
                </div>
            </div>


            <div class=""comments"">

                <!-- Main Heading -->
                <div class=""heading-side-bar margin-bottom-50 margin-top-100"">
                    <h4>Comment (37)<");
            WriteLiteral(@"/h4>
                </div>
                <ul>

                    <!-- Comments -->
                    <li class=""margin-bottom-30"">
                        <div class=""media"">
                            <div class=""media-left"">
                                <div class=""avatar"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "c0964cf6bba807991e662443de41091d9f26d5199397", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</div>
                            </div>
                            <div class=""media-body"">
                                <div class=""a-com"">
                                    <span class=""a-name text-color-primary"">JAMMIE LANDING </span><span class=""date"">24.03.2015 at 10:21</span>
                                    <p class=""margin-top-20"">
                                        “Quando feugait duo ei, te erant corpora interpretaris eos. Illud accommodare vituperatoribus an mea. Erat mazim animal
                                        at nam, eam te doctus evertitur, sed decore ornatus”
                                    </p>
                                    <a href=""#."" class=""text-right""> REPLAY <i class=""fa fa-reply""></i></a>
                                </div>
                            </div>
                        </div>
                    </li>

                    <!-- Comments Replay -->
                    <li class=""com-reply"">
                        <div cla");
            WriteLiteral("ss=\"media\">\r\n                            <div class=\"media-left\">\r\n                                <div class=\"avatar\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "c0964cf6bba807991e662443de41091d9f26d51911710", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</div>
                            </div>
                            <div class=""media-body"">
                                <div class=""a-com"">
                                    <span class=""a-name "">JAMMIE LANDING </span><span class=""date"">24.03.2015 at 10:21</span>
                                    <p class=""margin-top-20"">
                                        “Quando feugait duo ei, te erant corpora interpretaris eos. Illud accommodare vituperatoribus an mea. Erat mazim animal
                                        at nam, eam te doctus evertitur, sed decore ornatus”
                                    </p>
                                    <a href=""#."" class=""text-right""> REPLAY <i class=""fa fa-reply""></i></a>
                                </div>
                            </div>
                        </div>
                    </li>
                    <li class=""text-center more-comments""><a href=""#."">MORE COMMENT <i class=""fa fa-angle-down""></i></a></li>
               ");
            WriteLiteral(@" </ul>

                <!-- Comments Form -->
                <div class=""comment-form"">
                    <!-- Main Heading -->
                    <div class=""heading-side-bar margin-bottom-50 margin-top-80"">
                        <h4>Post to Reply</h4>
                    </div>
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c0964cf6bba807991e662443de41091d9f26d51914220", async() => {
                WriteLiteral("\r\n                        <ul class=\"row\">\r\n                            <li class=\"col-sm-4\">\r\n                                <label>\r\n                                    *NAME\r\n                                    <input class=\"form-control\" type=\"text\"");
                BeginWriteAttribute("placeholder", " placeholder=\"", 5129, "\"", 5143, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                                </label>
                            </li>
                            <li class=""col-sm-4"">
                                <label>
                                    *EMAIL ADDRESS
                                    <input class=""form-control"" type=""text""");
                BeginWriteAttribute("placeholder", " placeholder=\"", 5443, "\"", 5457, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                                </label>
                            </li>
                            <li class=""col-sm-4"">
                                <label>
                                    WEBSITE
                                    <input class=""form-control"" type=""text""");
                BeginWriteAttribute("placeholder", " placeholder=\"", 5750, "\"", 5764, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                                </label>
                            </li>
                            <li class=""col-sm-12"">
                                <label>
                                    SUBJECT
                                    <input class=""form-control"" type=""text""");
                BeginWriteAttribute("placeholder", " placeholder=\"", 6058, "\"", 6072, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                                </label>
                            </li>
                            <li class=""col-sm-12"">
                                <textarea placeholder=""YOUR MESSAGE""></textarea>
                            </li>
                            <li class=""col-sm-12"">
                                <button type=""submit"" class=""btn btn-dark"">POST COMMENT </button>
                            </li>
                        </ul>
                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n\r\n\r\n        </article>\r\n    </div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BlogPosts> Html { get; private set; }
    }
}
#pragma warning restore 1591
