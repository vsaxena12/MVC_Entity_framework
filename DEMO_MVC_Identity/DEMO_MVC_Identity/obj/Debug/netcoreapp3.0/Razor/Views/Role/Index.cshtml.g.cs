#pragma checksum "F:\MVC_Entity_framework\DEMO_MVC_Identity\DEMO_MVC_Identity\Views\Role\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "742f437b641d88b32db0f9034eb02c29051a89a7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Role_Index), @"mvc.1.0.view", @"/Views/Role/Index.cshtml")]
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
#line 1 "F:\MVC_Entity_framework\DEMO_MVC_Identity\DEMO_MVC_Identity\Views\_ViewImports.cshtml"
using DEMO_MVC_Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\MVC_Entity_framework\DEMO_MVC_Identity\DEMO_MVC_Identity\Views\_ViewImports.cshtml"
using DEMO_MVC_Identity.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"742f437b641d88b32db0f9034eb02c29051a89a7", @"/Views/Role/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3c0cf30a4ed01c95cacdf55fe1f69bc9182b6f3c", @"/Views/_ViewImports.cshtml")]
    public class Views_Role_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "F:\MVC_Entity_framework\DEMO_MVC_Identity\DEMO_MVC_Identity\Views\Role\Index.cshtml"
  
    ViewBag.Title = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Available Roles For Application</h2>\r\n\r\n");
#nullable restore
#line 8 "F:\MVC_Entity_framework\DEMO_MVC_Identity\DEMO_MVC_Identity\Views\Role\Index.cshtml"
Write(Html.ActionLink("Create Role", "Create", "Role"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<style type=\"text/css\">\r\n    #tbrole, .c {\r\n        border: double;\r\n    }\r\n</style>\r\n\r\n<table id=\"tbrole\">\r\n    <tr>\r\n        <td class=\"c\">\r\n            Role Name\r\n        </td>\r\n    </tr>\r\n");
#nullable restore
#line 22 "F:\MVC_Entity_framework\DEMO_MVC_Identity\DEMO_MVC_Identity\Views\Role\Index.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td class=\"c\">\r\n                ");
#nullable restore
#line 26 "F:\MVC_Entity_framework\DEMO_MVC_Identity\DEMO_MVC_Identity\Views\Role\Index.cshtml"
           Write(item.Role);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 29 "F:\MVC_Entity_framework\DEMO_MVC_Identity\DEMO_MVC_Identity\Views\Role\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\r\n\r\n\r\n\r\n");
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
