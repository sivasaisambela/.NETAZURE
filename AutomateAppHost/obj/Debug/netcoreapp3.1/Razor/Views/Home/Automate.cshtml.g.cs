#pragma checksum "C:\Users\sivasaisambela\source\repos\.NET CORE WEB API\AutomateAppHost\AutomateAppHost\Views\Home\Automate.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4dbfe7bd62fb53ba69c3afbf044cd277f8f0454e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Automate), @"mvc.1.0.view", @"/Views/Home/Automate.cshtml")]
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
#line 1 "C:\Users\sivasaisambela\source\repos\.NET CORE WEB API\AutomateAppHost\AutomateAppHost\Views\_ViewImports.cshtml"
using AutomateAppHost;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\sivasaisambela\source\repos\.NET CORE WEB API\AutomateAppHost\AutomateAppHost\Views\_ViewImports.cshtml"
using AutomateAppHost.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4dbfe7bd62fb53ba69c3afbf044cd277f8f0454e", @"/Views/Home/Automate.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"95e70a269a5339fa4d54a7505510e1228ccc4f16", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Automate : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/site.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AutoMigrate", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "C:\Users\sivasaisambela\source\repos\.NET CORE WEB API\AutomateAppHost\AutomateAppHost\Views\Home\Automate.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4dbfe7bd62fb53ba69c3afbf044cd277f8f0454e5309", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<script src=""https://code.jquery.com/jquery-3.6.0.min.js"" integrity=""sha256-/xUj+3OJU5yExlq6GSYGSHk7tPXikynS7ogEvDej/m4="" crossorigin=""anonymous""></script>
<script type=""text/javascript"">

    $(document).ready(function () {

        //Uncheck the CheckBox initially

      //  $('#chkCICDPipeline').removeAttr('checked');

        // Initially, Hide the SSN textbox when Web Form is loaded

        $('#divPIPELINE').hide();
        $('#divAzureApp').hide();
        
        $('#rdAzureAppServiceChecked').change(function () {

            if (this.checked) {

                $('#divAzureApp').show();
                $('#divPIPELINE').hide();
            }

            else {

                $('#divPIPELINE').hide();

            }

        });

        $('#rdAzureCICDChecked').change(function () {

            if (this.checked) {

                $('#divPIPELINE').show();
                $('#divAzureApp').hide();
            }

            else {

                $('#di");
            WriteLiteral("vAzureApp\').hide();\r\n\r\n            }\r\n\r\n        });\r\n\r\n    });\r\n\r\n</script>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4dbfe7bd62fb53ba69c3afbf044cd277f8f0454e7504", async() => {
                WriteLiteral(@"
    <div class=""col-sm-12"">
        <section class=""panel"">

            <p>Welcome to AzureMigration</p>
            <div class=""panel-body"">
                <fieldset>
                    <legend>Select one automate approach:</legend>

                    <div class=""form-group"">
                        <input type=""radio"" id=""rdAzureAppServiceChecked"" name=""drone"" value=""Azure Resrouce Creation & App Service Deploy"" />
                         <label for=""rdAzureAppServiceChecked"">Azure Resrouce Creation & App Service Deploy</label>
                    </div>

                    <div class=""form-group"">
                        <input type=""radio"" id=""rdAzureCICDChecked"" name=""drone"" value=""Azure Devops CICD Pipeline Build and Deploy"">
                        <label for=""Azure Devops CICD Pipeline Build and Deploy"">Azure Devops CICD Pipeline Build and Deploy</label>
                    </div>

                    
                </fieldset>

                <div id=""divAzureApp"" cla");
                WriteLiteral(@"ss=""form-group"">
                    <div id=""div_add_line1_error"" class=""form-group"">
                        <label class=""col-sm-4 control-label"">Repository Url:</label>
                        <div class=""col-sm-8"">
                            <input type=""text""");
                BeginWriteAttribute("value", " value=\"", 2573, "\"", 2581, 0);
                EndWriteAttribute();
                WriteLiteral(@" name=""txtRepo"" class=""form-control"">
                            <span class=""help-block with-errors errorLabel displayLabel"" id=""add_line1_error"">
                                &nbsp;
                            </span>
                        </div>
                    </div>
                    <div id=""div_add_line2_error"" class=""form-group"">
                        <label class=""col-sm-4 control-label"">Repository Token:</label>
                        <div class=""col-sm-8"">
                            <input type=""text""");
                BeginWriteAttribute("value", " value=\"", 3124, "\"", 3132, 0);
                EndWriteAttribute();
                WriteLiteral(@" name=""txtRepoToken"" class=""form-control"">
                            <span class=""help-block with-errors errorLabel displayLabel"" id=""add_line2_error"">
                                &nbsp;
                            </span>
                        </div>
                    </div>
                    <div id=""div_add_line3_error"" class=""form-group"">
                        <label class=""col-sm-4 control-label"">Application Name:</label>
                        <div class=""col-sm-8"">
                            <input type=""text""");
                BeginWriteAttribute("value", " value=\"", 3680, "\"", 3688, 0);
                EndWriteAttribute();
                WriteLiteral(@" name=""txtAppName"" class=""form-control"">
                            <span class=""help-block with-errors errorLabel displayLabel"" id=""add_line3_error"">
                                &nbsp;
                            </span>
                        </div>
                    </div>
                    <div id=""div_add_line4_error"" class=""form-group"">
                        <label class=""col-sm-4 control-label"">Resource Group Name:</label>
                        <div class=""col-sm-8"">
                            <input type=""text""");
                BeginWriteAttribute("value", " value=\"", 4237, "\"", 4245, 0);
                EndWriteAttribute();
                WriteLiteral(@" name=""txtRGName"" class=""form-control"">
                            <span class=""help-block with-errors errorLabel displayLabel"" id=""add_line4_error"">
                                &nbsp;
                            </span>
                        </div>
                    </div>
                    <div id=""div_add_line5_error"" class=""form-group"">
                        <label class=""col-sm-4 control-label"">Source Branch for Continuous Deployment:</label>
                        <div class=""col-sm-8"">
                            <input type=""text""");
                BeginWriteAttribute("value", " value=\"", 4813, "\"", 4821, 0);
                EndWriteAttribute();
                WriteLiteral(@" name=""txtSourceName"" class=""form-control"">
                            <span class=""help-block with-errors errorLabel displayLabel"" id=""add_line5_error"">
                                &nbsp;
                            </span>
                        </div>
                    </div>

                </div>
");
                WriteLiteral(@"
            <div id=""divPIPELINE"" class=""form-group"">




                <div id=""div_add_line6_error"" class=""form-group"">
                    <div id=""div_add_line1_error"" class=""form-group"">
                        <label class=""col-sm-4 control-label"">Repository Url:</label>
                        <div class=""col-sm-8"">
                            <input type=""text""");
                BeginWriteAttribute("value", " value=\"", 5937, "\"", 5945, 0);
                EndWriteAttribute();
                WriteLiteral(@" name=""txtRepo"" class=""form-control"">
                            <span class=""help-block with-errors errorLabel displayLabel"" id=""add_line1_error"">
                                &nbsp;
                            </span>
                        </div>
                    </div>
                    <div id=""div_add_line2_error"" class=""form-group"">
                        <label class=""col-sm-4 control-label"">Repository Token:</label>
                        <div class=""col-sm-8"">
                            <input type=""text""");
                BeginWriteAttribute("value", " value=\"", 6488, "\"", 6496, 0);
                EndWriteAttribute();
                WriteLiteral(@" name=""txtRepoToken"" class=""form-control"">
                            <span class=""help-block with-errors errorLabel displayLabel"" id=""add_line2_error"">
                                &nbsp;
                            </span>
                        </div>
                    </div>
                    <label class=""col-sm-4 control-label"">Azure Devops Organisation:</label>
                    <div class=""col-sm-8"">
                        <input type=""text""");
                BeginWriteAttribute("value", " value=\"", 6970, "\"", 6978, 0);
                EndWriteAttribute();
                WriteLiteral(@" name=""txtOrgName"" class=""form-control"">
                        <span class=""help-block with-errors errorLabel displayLabel"" id=""add_line6_error"">
                            &nbsp;
                        </span>
                    </div>
                </div>
                <div id=""div_add_line7_error"" class=""form-group"">
                    <label class=""col-sm-4 control-label"">Azure Project Personal Access Token:</label>
                    <div class=""col-sm-8"">
                        <input type=""text""");
                BeginWriteAttribute("value", " value=\"", 7507, "\"", 7515, 0);
                EndWriteAttribute();
                WriteLiteral(@" name=""txtPAT"" class=""form-control"">
                        <span class=""help-block with-errors errorLabel displayLabel"" id=""add_line7_error"">
                            &nbsp;
                        </span>
                    </div>
                </div>
                <div id=""div_add_line7_error"" class=""form-group"">
                    <label class=""col-sm-4 control-label"">Azure Repository:</label>
                    <div class=""col-sm-8"">
                        <input type=""text""");
                BeginWriteAttribute("value", " value=\"", 8021, "\"", 8029, 0);
                EndWriteAttribute();
                WriteLiteral(@" name=""txtAzRepo"" class=""form-control"">
                        <span class=""help-block with-errors errorLabel displayLabel"" id=""add_line7_error"">
                            &nbsp;
                        </span>
                    </div>
                </div>
                <div id=""div_add_line7_error"" class=""form-group"">
                    <label class=""col-sm-4 control-label"">Azure Devops Project:</label>
                    <div class=""col-sm-8"">
                        <input type=""text""");
                BeginWriteAttribute("value", " value=\"", 8542, "\"", 8550, 0);
                EndWriteAttribute();
                WriteLiteral(@" name=""txtAzProject"" class=""form-control"">
                        <span class=""help-block with-errors errorLabel displayLabel"" id=""add_line7_error"">
                            &nbsp;
                        </span>
                    </div>
                </div>
                <div id=""div_add_line7_error"" class=""form-group"">
                    <label class=""col-sm-4 control-label"">Project Id:</label>
                    <div class=""col-sm-8"">
                        <input type=""text""");
                BeginWriteAttribute("value", " value=\"", 9056, "\"", 9064, 0);
                EndWriteAttribute();
                WriteLiteral(@" name=""txtAzProjectId"" class=""form-control"">
                        <span class=""help-block with-errors errorLabel displayLabel"" id=""add_line7_error"">
                            &nbsp;
                        </span>
                    </div>
                </div>

            </div>

            </div>
        </section>
    </div>

    <div class=""form-group"">
        <div class=""col-md-10"">
            <input type=""submit"" value=""submit"" />
        </div>

    </div>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
