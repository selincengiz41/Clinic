#pragma checksum "C:\Users\LENOVO\Desktop\Clinic\Clinic\Views\Visitors\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "30e1275e5e6f3a2b6f66ef917c410747fcfbad88"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Visitors_Edit), @"mvc.1.0.view", @"/Views/Visitors/Edit.cshtml")]
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
#line 1 "C:\Users\LENOVO\Desktop\Clinic\Clinic\Views\_ViewImports.cshtml"
using Clinic;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\LENOVO\Desktop\Clinic\Clinic\Views\_ViewImports.cshtml"
using Clinic.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\LENOVO\Desktop\Clinic\Clinic\Views\Visitors\Edit.cshtml"
using System.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"30e1275e5e6f3a2b6f66ef917c410747fcfbad88", @"/Views/Visitors/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"967d7115af2116ec51148838caed4c3d0a52ac70", @"/Views/_ViewImports.cshtml")]
    public class Views_Visitors_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DataSet>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 4 "C:\Users\LENOVO\Desktop\Clinic\Clinic\Views\Visitors\Edit.cshtml"
 using (Html.BeginForm())
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""outer-box"">
    <div class=""login-box"">

        <table cellpadding=""0"" cellspacing=""0"">
            <tr>
                <th>Ziyaretci Kodu</th>
                <th>Ziyaretci Adi</th>
                <th>Ziyaretci Kimlik No</th>
                <th>Ziyaretci Adres</th>
                <th>Hasta Adi</th>
                <th>Yakınlık</th>
                <th>Ziyaret Tarih</th>
            

            </tr>
");
#nullable restore
#line 21 "C:\Users\LENOVO\Desktop\Clinic\Clinic\Views\Visitors\Edit.cshtml"
             foreach (DataRow row in Model.Tables[0].Rows)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <tr>\n        <td>");
#nullable restore
#line 24 "C:\Users\LENOVO\Desktop\Clinic\Clinic\Views\Visitors\Edit.cshtml"
       Write(row["ziyaretciID"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\n        <td>");
#nullable restore
#line 25 "C:\Users\LENOVO\Desktop\Clinic\Clinic\Views\Visitors\Edit.cshtml"
       Write(row["ziyaretciAdi"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\n        <td>");
#nullable restore
#line 26 "C:\Users\LENOVO\Desktop\Clinic\Clinic\Views\Visitors\Edit.cshtml"
       Write(row["ziyaretciTCNO"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\n        <td>");
#nullable restore
#line 27 "C:\Users\LENOVO\Desktop\Clinic\Clinic\Views\Visitors\Edit.cshtml"
       Write(row["ziyaretciAdres"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\n        <td>");
#nullable restore
#line 28 "C:\Users\LENOVO\Desktop\Clinic\Clinic\Views\Visitors\Edit.cshtml"
       Write(row["hastaAdi"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\n        <td>");
#nullable restore
#line 29 "C:\Users\LENOVO\Desktop\Clinic\Clinic\Views\Visitors\Edit.cshtml"
       Write(row["yakınlık"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\n        <td>");
#nullable restore
#line 30 "C:\Users\LENOVO\Desktop\Clinic\Clinic\Views\Visitors\Edit.cshtml"
       Write(row["ziyaretTarih"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\n \n\n    </tr>");
#nullable restore
#line 33 "C:\Users\LENOVO\Desktop\Clinic\Clinic\Views\Visitors\Edit.cshtml"
         }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </table>\n\n        <input type=\"text\" name=\"ziyaretcikodu\" class=\"form-control\" placeholder=\"Ziyaretçi Kodu\" />\n\n        <button id=\"btn-login\">Sec</button>\n\n\n    </div>\n\n</div>");
#nullable restore
#line 43 "C:\Users\LENOVO\Desktop\Clinic\Clinic\Views\Visitors\Edit.cshtml"
      }

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DataSet> Html { get; private set; }
    }
}
#pragma warning restore 1591
