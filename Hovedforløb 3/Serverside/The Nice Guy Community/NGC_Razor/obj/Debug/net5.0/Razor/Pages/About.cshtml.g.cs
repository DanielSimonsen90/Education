#pragma checksum "C:\Users\DanielSimonsen\source\repos\Techcollege\Education\Hovedforløb 3\Serverside\The Nice Guy Community\NGC_Razor\Pages\About.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f50676a51fd6c1978c5ae544a8d2ef6b4e5f040e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(NGC_Razor.Pages.Pages_About), @"mvc.1.0.razor-page", @"/Pages/About.cshtml")]
namespace NGC_Razor.Pages
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
#line 1 "C:\Users\DanielSimonsen\source\repos\Techcollege\Education\Hovedforløb 3\Serverside\The Nice Guy Community\NGC_Razor\Pages\_ViewImports.cshtml"
using NGC_Razor;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f50676a51fd6c1978c5ae544a8d2ef6b4e5f040e", @"/Pages/About.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"39b9916823a7a636bbbaa3f6a9a4e1f6ac45482f", @"/Pages/_ViewImports.cshtml")]
    public class Pages_About : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\DanielSimonsen\source\repos\Techcollege\Education\Hovedforløb 3\Serverside\The Nice Guy Community\NGC_Razor\Pages\About.cshtml"
  
    ViewData["Title"] = "Student Body Statistics";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Student Body Statistics</h2>\r\n\r\n<table>\r\n    <tr>\r\n        <th>Enrollment Date</th>\r\n        <th>Students</th>\r\n    </tr>\r\n\r\n");
#nullable restore
#line 15 "C:\Users\DanielSimonsen\source\repos\Techcollege\Education\Hovedforløb 3\Serverside\The Nice Guy Community\NGC_Razor\Pages\About.cshtml"
     foreach (var item in Model.Students)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 18 "C:\Users\DanielSimonsen\source\repos\Techcollege\Education\Hovedforløb 3\Serverside\The Nice Guy Community\NGC_Razor\Pages\About.cshtml"
           Write(Html.DisplayFor(modelItem => item.EnrollmentDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 19 "C:\Users\DanielSimonsen\source\repos\Techcollege\Education\Hovedforløb 3\Serverside\The Nice Guy Community\NGC_Razor\Pages\About.cshtml"
           Write(item.StudentCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n");
#nullable restore
#line 21 "C:\Users\DanielSimonsen\source\repos\Techcollege\Education\Hovedforløb 3\Serverside\The Nice Guy Community\NGC_Razor\Pages\About.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CortosoUniversity.Pages.AboutModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CortosoUniversity.Pages.AboutModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CortosoUniversity.Pages.AboutModel>)PageContext?.ViewData;
        public CortosoUniversity.Pages.AboutModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
