#pragma checksum "C:\Users\User\Documents\GitHub\ZIwG_Projekt_Zapisy\Project_ZIwG.Web\Views\Home\Secured.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0794ffbfddaec3d33776833159f0c61961d1e57d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Secured), @"mvc.1.0.view", @"/Views/Home/Secured.cshtml")]
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
#line 1 "C:\Users\User\Documents\GitHub\ZIwG_Projekt_Zapisy\Project_ZIwG.Web\Views\_ViewImports.cshtml"
using Project_ZIwG.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\Documents\GitHub\ZIwG_Projekt_Zapisy\Project_ZIwG.Web\Views\_ViewImports.cshtml"
using Project_ZIwG.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0794ffbfddaec3d33776833159f0c61961d1e57d", @"/Views/Home/Secured.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a7a2d477b40d06f6ca3ce341d3ea151833d1e193", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Secured : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h1>Top secret</h1>\r\n<h2>Welcome ");
#nullable restore
#line 7 "C:\Users\User\Documents\GitHub\ZIwG_Projekt_Zapisy\Project_ZIwG.Web\Views\Home\Secured.cshtml"
       Write(User.Identity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n<ul>\r\n");
#nullable restore
#line 9 "C:\Users\User\Documents\GitHub\ZIwG_Projekt_Zapisy\Project_ZIwG.Web\Views\Home\Secured.cshtml"
     foreach(var c in User.Claims)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li>");
#nullable restore
#line 11 "C:\Users\User\Documents\GitHub\ZIwG_Projekt_Zapisy\Project_ZIwG.Web\Views\Home\Secured.cshtml"
       Write(c.Type);

#line default
#line hidden
#nullable disable
            WriteLiteral(": ");
#nullable restore
#line 11 "C:\Users\User\Documents\GitHub\ZIwG_Projekt_Zapisy\Project_ZIwG.Web\Views\Home\Secured.cshtml"
                Write(c.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 12 "C:\Users\User\Documents\GitHub\ZIwG_Projekt_Zapisy\Project_ZIwG.Web\Views\Home\Secured.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</ul>");
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
