#pragma checksum "C:\Users\puto-\Desktop\FridaSchoolName\Views\Subject\Subjects.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "68681a1adca39b70c3bb1b3137927dd6e2795a19"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Subject_Subjects), @"mvc.1.0.view", @"/Views/Subject/Subjects.cshtml")]
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
#line 1 "C:\Users\puto-\Desktop\FridaSchoolName\Views\_ViewImports.cshtml"
using FridaSchoolWeb;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\puto-\Desktop\FridaSchoolName\Views\_ViewImports.cshtml"
using FridaSchoolWeb.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"68681a1adca39b70c3bb1b3137927dd6e2795a19", @"/Views/Subject/Subjects.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cb0c48b48b144c6cc13f62f1bcd3497516f68842", @"/Views/_ViewImports.cshtml")]
    public class Views_Subject_Subjects : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IQueryable<Subject>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_LayoutAccount", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditSubject", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\puto-\Desktop\FridaSchoolName\Views\Subject\Subjects.cshtml"
  
    ViewData["Title"] = "Subjects";
    Layout ="_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "68681a1adca39b70c3bb1b3137927dd6e2795a194769", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    <div class=\"view\">\r\n");
#nullable restore
#line 9 "C:\Users\puto-\Desktop\FridaSchoolName\Views\Subject\Subjects.cshtml"
          
        if(HttpContextAccessor.HttpContext.User.IsInRole("Cordinator")){

#line default
#line hidden
#nullable disable
            WriteLiteral(@"             <ul class=""nav nav-tabs"" id=""myTab"" role=""tablist"">
                <li class=""nav-item"">
                    <a class=""nav-link"" id=""home-tab"" href=""/Subject/MySubjects"">My subjects</a>
                </li>
                <li class=""nav-item"">
                    <a class=""nav-link active"" id=""profile-tab"" href=""/Subject/Subjects"">All subjects</a>
                </li>
            </ul>
");
#nullable restore
#line 19 "C:\Users\puto-\Desktop\FridaSchoolName\Views\Subject\Subjects.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <br>\r\n");
            WriteLiteral(@"    <div class=""container"">
        <table class=""table"">
            <thead>
            <a href=""#myModalCreate"" data-toggle=""modal"" class=""btn btn-primary btn-xs pull-right""><b>+</b> Add new groups</a>
            </thead>
            <tbody>
                <tr>
                    <th>ID</th>
                    <th>Key</th>
                    <th>Name</th>
                    <th>Theory Hours</th>
                    <th>PracticeHours</th>
                    <th>Action</th>
                </tr>
");
#nullable restore
#line 36 "C:\Users\puto-\Desktop\FridaSchoolName\Views\Subject\Subjects.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 39 "C:\Users\puto-\Desktop\FridaSchoolName\Views\Subject\Subjects.cshtml"
                       Write(item.ID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 40 "C:\Users\puto-\Desktop\FridaSchoolName\Views\Subject\Subjects.cshtml"
                       Write(item.Key);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 41 "C:\Users\puto-\Desktop\FridaSchoolName\Views\Subject\Subjects.cshtml"
                       Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 42 "C:\Users\puto-\Desktop\FridaSchoolName\Views\Subject\Subjects.cshtml"
                       Write(item.TheoryHours);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 43 "C:\Users\puto-\Desktop\FridaSchoolName\Views\Subject\Subjects.cshtml"
                       Write(item.PracticeHours);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td >\r\n                            <a class=\'btn btn-info btn-xs\'");
            BeginWriteAttribute("href", " href=\"", 1713, "\"", 1744, 2);
            WriteAttributeValue("", 1720, "/Subject/Delete/", 1720, 16, true);
#nullable restore
#line 45 "C:\Users\puto-\Desktop\FridaSchoolName\Views\Subject\Subjects.cshtml"
WriteAttributeValue("", 1736, item.ID, 1736, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                            <svg width=""1em"" height=""1em"" viewBox=""0 0 16 16"" class=""bi bi-trash"" fill=""currentColor"" xmlns=""http://www.w3.org/2000/svg"">
                            <path d=""M5.5 5.5A.5.5 0 0 1 6 6v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm2.5 0a.5.5 0 0 1 .5.5v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm3 .5a.5.5 0 0 0-1 0v6a.5.5 0 0 0 1 0V6z""/>
                            <path fill-rule=""evenodd"" d=""M14.5 3a1 1 0 0 1-1 1H13v9a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V4h-.5a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1H6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1h3.5a1 1 0 0 1 1 1v1zM4.118 4L4 4.059V13a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1V4.059L11.882 4H4.118zM2.5 3V2h11v1h-11z""/>
                            </svg></a><a href=""#myModal"" data-toggle=""modal"" class=""btn btn-danger btn-xs"">
                            <svg width=""1em"" height=""1em"" viewBox=""0 0 16 16"" class=""bi bi-pencil"" fill=""currentColor"" xmlns=""http://www.w3.org/2000/svg"">
                            <path fill-rule=""evenodd"" d=""M12.146.146a.5.5 0 0 1 .708 0l3 3a.5.5 0 0 1 0 ");
            WriteLiteral(@".708l-10 10a.5.5 0 0 1-.168.11l-5 2a.5.5 0 0 1-.65-.65l2-5a.5.5 0 0 1 .11-.168l10-10zM11.207 2.5L13.5 4.793 14.793 3.5 12.5 1.207 11.207 2.5zm1.586 3L10.5 3.207 4 9.707V10h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.293l6.5-6.5zm-9.761 5.175l-.106.106-1.528 3.821 3.821-1.528.106-.106A.5.5 0 0 1 5 12.5V12h-.5a.5.5 0 0 1-.5-.5V11h-.5a.5.5 0 0 1-.468-.325z""/>
                            </svg></a>
                        </td>
                    </tr>
                    <div class=""modal fade"" id=""myModal"" tabindex=""-1"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
                        <div class=""modal-dialog"">
                            <div class=""modal-content"">
                                <div class=""modal-header"">
                                    <h5 class=""modal-title"" id=""emyModalLabel"">Edit Subject</h5>
                                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                                    <span aria-hidden=""t");
            WriteLiteral("rue\">&times;</span>\r\n                                    </button>\r\n                                </div>\r\n                                <div class=\"modal-body\">\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "68681a1adca39b70c3bb1b3137927dd6e2795a1911890", async() => {
                WriteLiteral(@"
                                        <div class=""form-group"">
                                            <label for=""name"" class=""col-form-label"">Name:</label>
                                            <input type=""text"" class=""form-control"" name=""name""");
                BeginWriteAttribute("value", " value=\"", 4303, "\"", 4321, 1);
#nullable restore
#line 68 "C:\Users\puto-\Desktop\FridaSchoolName\Views\Subject\Subjects.cshtml"
WriteAttributeValue("", 4311, item.Name, 4311, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" required>
                                        </div>
                                        <div class=""form-group"">
                                            <label for=""name"" class=""col-form-label"">Theory Hours:</label>
                                            <input type=""number"" class=""form-control"" name=""theoryH""");
                BeginWriteAttribute("value", " value=\"", 4656, "\"", 4681, 1);
#nullable restore
#line 72 "C:\Users\puto-\Desktop\FridaSchoolName\Views\Subject\Subjects.cshtml"
WriteAttributeValue("", 4664, item.TheoryHours, 4664, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" required>
                                        </div>
                                        <div class=""form-group"">
                                            <label for=""name"" class=""col-form-label"">Practice Hours:</label>
                                            <input type=""number"" class=""form-control"" name=""practiceH""");
                BeginWriteAttribute("value", " value=\"", 5020, "\"", 5047, 1);
#nullable restore
#line 76 "C:\Users\puto-\Desktop\FridaSchoolName\Views\Subject\Subjects.cshtml"
WriteAttributeValue("", 5028, item.PracticeHours, 5028, 19, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" required>\r\n                                        </div>\r\n                                        <br><br>\r\n                                        <input type=\"hidden\" name=\"id\" id=\"planid\"");
                BeginWriteAttribute("value", "  value=\"", 5240, "\"", 5257, 1);
#nullable restore
#line 79 "C:\Users\puto-\Desktop\FridaSchoolName\Views\Subject\Subjects.cshtml"
WriteAttributeValue("", 5249, item.ID, 5249, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@"/>
                                        <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
                                        <button type=""submit"" class=""btn btn-primary"" >Save</button>
                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 87 "C:\Users\puto-\Desktop\FridaSchoolName\Views\Subject\Subjects.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </tbody>
        </table>
        </div>
        <div class=""modal fade"" id=""myModalCreate"" tabindex=""-1"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
            <div class=""modal-dialog"">
                <div class=""modal-content"">
                    <div class=""modal-header"">
                        <h5 class=""modal-title"" id=""emyModalLabel"">Edit Group</h5>
                        <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                        </button>
                </div>
                <div class=""modal-body"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "68681a1adca39b70c3bb1b3137927dd6e2795a1917504", async() => {
                WriteLiteral(@"
                        <div class=""form-group"">
                            <label for=""name"" class=""col-form-label"">Name:</label>
                            <input type=""text"" class=""form-control"" name=""name"" required>
                        </div>
                       <div class=""form-group"">
                            <label for=""name"" class=""col-form-label"">Theory Hours:</label>
                            <input type=""number"" class=""form-control"" name=""theoryH"" required>
                        </div>
                        <div class=""form-group"">
                            <label for=""name"" class=""col-form-label"">Practice Hours:</label>
                            <input type=""number"" class=""form-control"" name=""practiceH"" required>
                        </div>
                        <br><br>
                        <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
                        <button type=""submit"" class=""btn btn-primary"">Create</b");
                WriteLiteral("utton>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    </div>\r\n    \r\n\r\n    \r\n\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Microsoft.AspNetCore.Http.IHttpContextAccessor HttpContextAccessor { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IQueryable<Subject>> Html { get; private set; }
    }
}
#pragma warning restore 1591