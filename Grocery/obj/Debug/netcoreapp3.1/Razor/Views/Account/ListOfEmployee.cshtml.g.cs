#pragma checksum "C:\Users\jeel.detroja\OneDrive - Contis Group Ltd\Desktop\Grocery\Grocery\Views\Account\ListOfEmployee.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a3a9a60ec298a1168f823f65dbb2c052a5753afb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_ListOfEmployee), @"mvc.1.0.view", @"/Views/Account/ListOfEmployee.cshtml")]
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
#line 1 "C:\Users\jeel.detroja\OneDrive - Contis Group Ltd\Desktop\Grocery\Grocery\Views\_ViewImports.cshtml"
using Grocery;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\jeel.detroja\OneDrive - Contis Group Ltd\Desktop\Grocery\Grocery\Views\_ViewImports.cshtml"
using Grocery.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\jeel.detroja\OneDrive - Contis Group Ltd\Desktop\Grocery\Grocery\Views\_ViewImports.cshtml"
using Grocery.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\jeel.detroja\OneDrive - Contis Group Ltd\Desktop\Grocery\Grocery\Views\_ViewImports.cshtml"
using Grocery.Enums;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a3a9a60ec298a1168f823f65dbb2c052a5753afb", @"/Views/Account/ListOfEmployee.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"018116dac76c8f4a0b00b10cc8f3dd5c7f1550bd", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Account_ListOfEmployee : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<User>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CreateEmployee", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Account", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteEmployee", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\jeel.detroja\OneDrive - Contis Group Ltd\Desktop\Grocery\Grocery\Views\Account\ListOfEmployee.cshtml"
  
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>List of all Employee</h1>\r\n<br/>\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a3a9a60ec298a1168f823f65dbb2c052a5753afb5538", async() => {
                WriteLiteral("Create New");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
</p>
<table class=""table"">
    <thead>
        <tr>
            <th>
                Id
            </th>
            <th>
                Name
            </th>
            <th>
                Email
            </th>
            <th>
                MobileNo
            </th>
            <th>
                Dob
            </th>
            <th>
                CreatedOn
            </th>
            <th>
                isActivated
            </th>
            <th>
                Delete
            </th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 41 "C:\Users\jeel.detroja\OneDrive - Contis Group Ltd\Desktop\Grocery\Grocery\Views\Account\ListOfEmployee.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 45 "C:\Users\jeel.detroja\OneDrive - Contis Group Ltd\Desktop\Grocery\Grocery\Views\Account\ListOfEmployee.cshtml"
           Write(Html.DisplayFor(modelItem => item.UserId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 48 "C:\Users\jeel.detroja\OneDrive - Contis Group Ltd\Desktop\Grocery\Grocery\Views\Account\ListOfEmployee.cshtml"
           Write(Html.DisplayFor(modelItem => item.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 51 "C:\Users\jeel.detroja\OneDrive - Contis Group Ltd\Desktop\Grocery\Grocery\Views\Account\ListOfEmployee.cshtml"
           Write(Html.DisplayFor(modelItem => item.UserEmail));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 54 "C:\Users\jeel.detroja\OneDrive - Contis Group Ltd\Desktop\Grocery\Grocery\Views\Account\ListOfEmployee.cshtml"
           Write(Html.DisplayFor(modelItem => item.UserMobileNo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 57 "C:\Users\jeel.detroja\OneDrive - Contis Group Ltd\Desktop\Grocery\Grocery\Views\Account\ListOfEmployee.cshtml"
           Write(Html.DisplayFor(modelItem => item.UserDob));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 60 "C:\Users\jeel.detroja\OneDrive - Contis Group Ltd\Desktop\Grocery\Grocery\Views\Account\ListOfEmployee.cshtml"
           Write(Html.DisplayFor(modelItem => item.CreatedOn));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 63 "C:\Users\jeel.detroja\OneDrive - Contis Group Ltd\Desktop\Grocery\Grocery\Views\Account\ListOfEmployee.cshtml"
           Write(Html.DisplayFor(modelItem => item.IsActivated));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a3a9a60ec298a1168f823f65dbb2c052a5753afb10331", async() => {
                WriteLiteral("Delete");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 66 "C:\Users\jeel.detroja\OneDrive - Contis Group Ltd\Desktop\Grocery\Grocery\Views\Account\ListOfEmployee.cshtml"
                                                                          WriteLiteral(item.UserId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "onclick", 11, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1672, "return", 1672, 6, true);
            AddHtmlAttributeValue(" ", 1678, "confirm(\'Are", 1679, 13, true);
            AddHtmlAttributeValue(" ", 1691, "you", 1692, 4, true);
            AddHtmlAttributeValue(" ", 1695, "sure", 1696, 5, true);
            AddHtmlAttributeValue(" ", 1700, "you", 1701, 4, true);
            AddHtmlAttributeValue(" ", 1704, "want", 1705, 5, true);
            AddHtmlAttributeValue(" ", 1709, "to", 1710, 3, true);
            AddHtmlAttributeValue(" ", 1712, "delete", 1713, 7, true);
#nullable restore
#line 66 "C:\Users\jeel.detroja\OneDrive - Contis Group Ltd\Desktop\Grocery\Grocery\Views\Account\ListOfEmployee.cshtml"
AddHtmlAttributeValue(" ", 1719, item.UserName, 1720, 14, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue(" ", 1734, "Employee", 1735, 9, true);
            AddHtmlAttributeValue(" ", 1743, "?\');", 1744, 5, true);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 69 "C:\Users\jeel.detroja\OneDrive - Contis Group Ltd\Desktop\Grocery\Grocery\Views\Account\ListOfEmployee.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<User>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591