#pragma checksum "C:\Users\v-pc\source\repos\FirstMvcApp\FirstMvcApp\Views\Home\Attendant.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "62eb1e33a5ad7bf851dd76576d55dbb2968dc82a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(FirstMvcApp.Pages.Home.Views_Home_Attendant), @"mvc.1.0.view", @"/Views/Home/Attendant.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Attendant.cshtml", typeof(FirstMvcApp.Pages.Home.Views_Home_Attendant))]
namespace FirstMvcApp.Pages.Home
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\v-pc\source\repos\FirstMvcApp\FirstMvcApp\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "C:\Users\v-pc\source\repos\FirstMvcApp\FirstMvcApp\Views\_ViewImports.cshtml"
using FirstMvcApp.Areas.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"62eb1e33a5ad7bf851dd76576d55dbb2968dc82a", @"/Views/Home/Attendant.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"460760e1e5699e3bea8ef77fc42d12584a0e81c6", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Attendant : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FirstMvcApp.Models.Person>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\v-pc\source\repos\FirstMvcApp\FirstMvcApp\Views\Home\Attendant.cshtml"
  
    ViewBag.Title = "Attendant Details";

#line default
#line hidden
            BeginContext(83, 226, true);
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-md-2\">\r\n        <div class=\"thumbnail\">\r\n            <img src=\"\" />\r\n        </div>\r\n    </div>\r\n    <div class=\"col-md-6\" style=\"position:absolute;left:100;bottom:10px;\">\r\n        <h1>");
            EndContext();
            BeginContext(310, 15, false);
#line 13 "C:\Users\v-pc\source\repos\FirstMvcApp\FirstMvcApp\Views\Home\Attendant.cshtml"
       Write(Model.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(325, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(327, 14, false);
#line 13 "C:\Users\v-pc\source\repos\FirstMvcApp\FirstMvcApp\Views\Home\Attendant.cshtml"
                        Write(Model.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(341, 18, true);
            WriteLiteral("</h1>\r\n        <p>");
            EndContext();
            BeginContext(360, 17, false);
#line 14 "C:\Users\v-pc\source\repos\FirstMvcApp\FirstMvcApp\Views\Home\Attendant.cshtml"
      Write(Model.DateOfBirth);

#line default
#line hidden
            EndContext();
            BeginContext(377, 29, true);
            WriteLiteral("</p>\r\n    </div>\r\n</div>\r\n \r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FirstMvcApp.Models.Person> Html { get; private set; }
    }
}
#pragma warning restore 1591
