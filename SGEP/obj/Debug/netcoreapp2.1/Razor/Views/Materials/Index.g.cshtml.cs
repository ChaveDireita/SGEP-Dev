#pragma checksum "C:\Users\danpg\OneDrive\Documentos\C# Projects\SGEP\SGEP\Views\Materials\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d7d1aab44a354bab2774c43d4889162758e55505"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Materials_Index), @"mvc.1.0.view", @"/Views/Materials/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Materials/Index.cshtml", typeof(AspNetCore.Views_Materials_Index))]
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
#line 1 "C:\Users\danpg\OneDrive\Documentos\C# Projects\SGEP\SGEP\Views\_ViewImports.cshtml"
using SGEP;

#line default
#line hidden
#line 2 "C:\Users\danpg\OneDrive\Documentos\C# Projects\SGEP\SGEP\Views\_ViewImports.cshtml"
using SGEP.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d7d1aab44a354bab2774c43d4889162758e55505", @"/Views/Materials/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"859f4487869393079a9c084a9eeb47f7da62b761", @"/Views/_ViewImports.cshtml")]
    public class Views_Materials_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SGEP.Models.Material>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-secondary float-right"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(41, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 3 "C:\Users\danpg\OneDrive\Documentos\C# Projects\SGEP\SGEP\Views\Materials\Index.cshtml"
  
    ViewData["Title"] = "Materiais";

#line default
#line hidden
            BeginContext(84, 157, true);
            WriteLiteral("\n    <h3 class=\"display-4 mt-5 mb-5 text-center\">Materiais</h3>\n\n<table class=\"table table-hover\">\n    <thead>\n        <tr>\n            <th>\n                ");
            EndContext();
            BeginContext(242, 38, false);
#line 13 "C:\Users\danpg\OneDrive\Documentos\C# Projects\SGEP\SGEP\Views\Materials\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
            EndContext();
            BeginContext(280, 52, true);
            WriteLiteral("\n            </th>\n            <th>\n                ");
            EndContext();
            BeginContext(333, 45, false);
#line 16 "C:\Users\danpg\OneDrive\Documentos\C# Projects\SGEP\SGEP\Views\Materials\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Descricao));

#line default
#line hidden
            EndContext();
            BeginContext(378, 52, true);
            WriteLiteral("\n            </th>\n            <th>\n                ");
            EndContext();
            BeginContext(431, 43, false);
#line 19 "C:\Users\danpg\OneDrive\Documentos\C# Projects\SGEP\SGEP\Views\Materials\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Unidade));

#line default
#line hidden
            EndContext();
            BeginContext(474, 52, true);
            WriteLiteral("\n            </th>\n            <th>\n                ");
            EndContext();
            BeginContext(527, 41, false);
#line 22 "C:\Users\danpg\OneDrive\Documentos\C# Projects\SGEP\SGEP\Views\Materials\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Preco));

#line default
#line hidden
            EndContext();
            BeginContext(568, 80, true);
            WriteLiteral("\n            </th>\n            <th></th>\n        </tr>\n    </thead>\n    <tbody>\n");
            EndContext();
#line 28 "C:\Users\danpg\OneDrive\Documentos\C# Projects\SGEP\SGEP\Views\Materials\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(679, 46, true);
            WriteLiteral("        <tr>\n            <td>\n                ");
            EndContext();
            BeginContext(726, 37, false);
#line 31 "C:\Users\danpg\OneDrive\Documentos\C# Projects\SGEP\SGEP\Views\Materials\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
            EndContext();
            BeginContext(763, 52, true);
            WriteLiteral("\n            </td>\n            <td>\n                ");
            EndContext();
            BeginContext(816, 44, false);
#line 34 "C:\Users\danpg\OneDrive\Documentos\C# Projects\SGEP\SGEP\Views\Materials\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Descricao));

#line default
#line hidden
            EndContext();
            BeginContext(860, 52, true);
            WriteLiteral("\n            </td>\n            <td>\n                ");
            EndContext();
            BeginContext(913, 42, false);
#line 37 "C:\Users\danpg\OneDrive\Documentos\C# Projects\SGEP\SGEP\Views\Materials\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Unidade));

#line default
#line hidden
            EndContext();
            BeginContext(955, 52, true);
            WriteLiteral("\n            </td>\n            <td>\n                ");
            EndContext();
            BeginContext(1008, 40, false);
#line 40 "C:\Users\danpg\OneDrive\Documentos\C# Projects\SGEP\SGEP\Views\Materials\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Preco));

#line default
#line hidden
            EndContext();
            BeginContext(1048, 52, true);
            WriteLiteral("\n            </td>\n            <td>\n                ");
            EndContext();
            BeginContext(1100, 107, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "38ce7907ee16419ebc43d2cd9a8cf863", async() => {
                BeginContext(1197, 6, true);
                WriteLiteral("Editar");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 43 "C:\Users\danpg\OneDrive\Documentos\C# Projects\SGEP\SGEP\Views\Materials\Index.cshtml"
                                                                                           WriteLiteral(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1207, 33, true);
            WriteLiteral("\n            </td>\n        </tr>\n");
            EndContext();
#line 46 "C:\Users\danpg\OneDrive\Documentos\C# Projects\SGEP\SGEP\Views\Materials\Index.cshtml"
}

#line default
#line hidden
            BeginContext(1242, 22, true);
            WriteLiteral("    </tbody>\n</table>\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SGEP.Models.Material>> Html { get; private set; }
    }
}
#pragma warning restore 1591
