#pragma checksum "C:\Users\v-pc\source\repos\FirstMvcApp\FirstMvcApp\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cef92f62707b0e25df888b71363d3684d7b0f9c5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(FirstMvcApp.Pages.Home.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(FirstMvcApp.Pages.Home.Views_Home_Index))]
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
#line 1 "C:\Users\v-pc\source\repos\FirstMvcApp\FirstMvcApp\Views\Home\Index.cshtml"
using FirstMvcApp.Models;

#line default
#line hidden
#line 3 "C:\Users\v-pc\source\repos\FirstMvcApp\FirstMvcApp\Views\Home\Index.cshtml"
using Microsoft.Extensions.Localization;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cef92f62707b0e25df888b71363d3684d7b0f9c5", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"460760e1e5699e3bea8ef77fc42d12584a0e81c6", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FirstMvcApp.Models.Person>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(103, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(151, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 7 "C:\Users\v-pc\source\repos\FirstMvcApp\FirstMvcApp\Views\Home\Index.cshtml"
  
    ViewBag.Title = "Home Page";

#line default
#line hidden
            BeginContext(194, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 11 "C:\Users\v-pc\source\repos\FirstMvcApp\FirstMvcApp\Views\Home\Index.cshtml"
 if (TempData["FirstName"] != null)
{

#line default
#line hidden
            BeginContext(236, 35, true);
            WriteLiteral("    <p class=\"alert alert-success\">");
            EndContext();
            BeginContext(272, 29, false);
#line 13 "C:\Users\v-pc\source\repos\FirstMvcApp\FirstMvcApp\Views\Home\Index.cshtml"
                              Write(localizer["SuccessfulInsert"]);

#line default
#line hidden
            EndContext();
            BeginContext(301, 2, true);
            WriteLiteral(": ");
            EndContext();
            BeginContext(304, 21, false);
#line 13 "C:\Users\v-pc\source\repos\FirstMvcApp\FirstMvcApp\Views\Home\Index.cshtml"
                                                              Write(TempData["FirstName"]);

#line default
#line hidden
            EndContext();
            BeginContext(325, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
#line 14 "C:\Users\v-pc\source\repos\FirstMvcApp\FirstMvcApp\Views\Home\Index.cshtml"
}

#line default
#line hidden
            BeginContext(334, 136, true);
            WriteLiteral("\r\n<div class=\"panel panel-primary\">\r\n    <div class=\"panel-heading\">\r\n        Add attendant:\r\n    </div>\r\n    <div class=\"panel-body\">\r\n");
            EndContext();
#line 21 "C:\Users\v-pc\source\repos\FirstMvcApp\FirstMvcApp\Views\Home\Index.cshtml"
         using (Html.BeginForm("Index", "Home", FormMethod.Post, new { @class = "form" }))
        {

#line default
#line hidden
            BeginContext(573, 54, true);
            WriteLiteral("            <div class=\"form-group\">\r\n                ");
            EndContext();
            BeginContext(628, 31, false);
#line 24 "C:\Users\v-pc\source\repos\FirstMvcApp\FirstMvcApp\Views\Home\Index.cshtml"
           Write(Html.LabelFor(m => m.FirstName));

#line default
#line hidden
            EndContext();
            BeginContext(659, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(678, 100, false);
#line 25 "C:\Users\v-pc\source\repos\FirstMvcApp\FirstMvcApp\Views\Home\Index.cshtml"
           Write(Html.TextBoxFor(m => m.FirstName, null, new { @class = "form-control", placeholder = "First Name" }));

#line default
#line hidden
            EndContext();
            BeginContext(778, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(797, 81, false);
#line 26 "C:\Users\v-pc\source\repos\FirstMvcApp\FirstMvcApp\Views\Home\Index.cshtml"
           Write(Html.ValidationMessageFor(m => m.FirstName, null, new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(878, 22, true);
            WriteLiteral("\r\n            </div>\r\n");
            EndContext();
            BeginContext(902, 54, true);
            WriteLiteral("            <div class=\"form-group\">\r\n                ");
            EndContext();
            BeginContext(957, 30, false);
#line 30 "C:\Users\v-pc\source\repos\FirstMvcApp\FirstMvcApp\Views\Home\Index.cshtml"
           Write(Html.LabelFor(m => m.LastName));

#line default
#line hidden
            EndContext();
            BeginContext(987, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(1006, 98, false);
#line 31 "C:\Users\v-pc\source\repos\FirstMvcApp\FirstMvcApp\Views\Home\Index.cshtml"
           Write(Html.TextBoxFor(m => m.LastName, null, new { @class = "form-control", placeholder = "Last Name" }));

#line default
#line hidden
            EndContext();
            BeginContext(1104, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(1123, 80, false);
#line 32 "C:\Users\v-pc\source\repos\FirstMvcApp\FirstMvcApp\Views\Home\Index.cshtml"
           Write(Html.ValidationMessageFor(m => m.LastName, null, new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(1203, 22, true);
            WriteLiteral("\r\n            </div>\r\n");
            EndContext();
            BeginContext(1227, 54, true);
            WriteLiteral("            <div class=\"form-group\">\r\n                ");
            EndContext();
            BeginContext(1282, 33, false);
#line 36 "C:\Users\v-pc\source\repos\FirstMvcApp\FirstMvcApp\Views\Home\Index.cshtml"
           Write(Html.LabelFor(m => m.DateOfBirth));

#line default
#line hidden
            EndContext();
            BeginContext(1315, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(1334, 105, false);
#line 37 "C:\Users\v-pc\source\repos\FirstMvcApp\FirstMvcApp\Views\Home\Index.cshtml"
           Write(Html.TextBoxFor(m => m.DateOfBirth, null, new { @class = "form-control", placeholder = "Date of Birth" }));

#line default
#line hidden
            EndContext();
            BeginContext(1439, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(1458, 83, false);
#line 38 "C:\Users\v-pc\source\repos\FirstMvcApp\FirstMvcApp\Views\Home\Index.cshtml"
           Write(Html.ValidationMessageFor(m => m.DateOfBirth, null, new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(1541, 22, true);
            WriteLiteral("\r\n            </div>\r\n");
            EndContext();
            BeginContext(1565, 72, true);
            WriteLiteral("            <button class=\"btn btn-default\" type=\"submit\">Add</button>\r\n");
            EndContext();
#line 42 "C:\Users\v-pc\source\repos\FirstMvcApp\FirstMvcApp\Views\Home\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(1648, 32, true);
            WriteLiteral("    </div>\r\n</div>\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
            EndContext();
            BeginContext(1681, 27, false);
#line 51 "C:\Users\v-pc\source\repos\FirstMvcApp\FirstMvcApp\Views\Home\Index.cshtml"
Write(Html.Partial("_PersonList"));

#line default
#line hidden
            EndContext();
            BeginContext(1708, 6, true);
            WriteLiteral("\r\n\r\n\r\n");
            EndContext();
            DefineSection("SideBar", async() => {
                BeginContext(1732, 397, true);
                WriteLiteral(@"
    <div class=""panel panel-default"">
        <div class=""panel-heading"">
            This is page specific sidebar
        </div>
        <div class=""panel-body"">
            <ul>
                <li><a href=""#"">Link one</a></li>
                <li><a href=""#"">Link two</a></li>
                <li><a href=""#"">Link three</a></li>
            </ul>
        </div>
    </div>
    
");
                EndContext();
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IStringLocalizer<Resource> localizer { get; private set; }
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
