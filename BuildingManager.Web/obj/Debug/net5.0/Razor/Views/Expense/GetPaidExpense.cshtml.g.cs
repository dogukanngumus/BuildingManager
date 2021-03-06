#pragma checksum "/Users/apple/FinalProject/BuildingManager/BuildingManager.Web/Views/Expense/GetPaidExpense.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4320e3aa503820a0abddf47c462ed0b56dffd31d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Expense_GetPaidExpense), @"mvc.1.0.view", @"/Views/Expense/GetPaidExpense.cshtml")]
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
#line 1 "/Users/apple/FinalProject/BuildingManager/BuildingManager.Web/Views/_ViewImports.cshtml"
using BuildingManager.Business.PaymentApiModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/apple/FinalProject/BuildingManager/BuildingManager.Web/Views/_ViewImports.cshtml"
using BuildingManager.Business.Dtos;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4320e3aa503820a0abddf47c462ed0b56dffd31d", @"/Views/Expense/GetPaidExpense.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7124492bb4d58be92f6cce47f091b08f2cf518d5", @"/Views/_ViewImports.cshtml")]
    public class Views_Expense_GetPaidExpense : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ExpenseDto>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""container mb-5 mt-5"">
    <h3>Tahsilat Listesi</h3>
</div>

<table id=""datatable"" style=""width:100%"" class=""table table-hover table-striped"">
    <thead class=""thead-info"">
    <tr>
        <th scope=""col"">Id</th>
        <th scope=""col"">Ödendimi</th>
        <th scope=""col"">Fiyat</th>
        <th scope=""col"">Tarih</th>
        <th scope=""col"">Kullanıcı Adı</th>
        <th scope=""col"">Daire Numarası</th>
        <th scope=""col"">Gider Tipi</th>
    </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 20 "/Users/apple/FinalProject/BuildingManager/BuildingManager.Web/Views/Expense/GetPaidExpense.cshtml"
     foreach (var expense in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\n            <td>");
#nullable restore
#line 23 "/Users/apple/FinalProject/BuildingManager/BuildingManager.Web/Views/Expense/GetPaidExpense.cshtml"
           Write(expense.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td>");
#nullable restore
#line 24 "/Users/apple/FinalProject/BuildingManager/BuildingManager.Web/Views/Expense/GetPaidExpense.cshtml"
                 if (expense.IsPaid ==true)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span class=\"badge badge-pill badge-success\"><i class=\"fa fa-check-circle\"></i></span>\n");
#nullable restore
#line 27 "/Users/apple/FinalProject/BuildingManager/BuildingManager.Web/Views/Expense/GetPaidExpense.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span class=\"badge badge-pill badge-danger\"><i class=\"fa fa-ban\"></i></span>\n");
#nullable restore
#line 31 "/Users/apple/FinalProject/BuildingManager/BuildingManager.Web/Views/Expense/GetPaidExpense.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td>");
#nullable restore
#line 32 "/Users/apple/FinalProject/BuildingManager/BuildingManager.Web/Views/Expense/GetPaidExpense.cshtml"
           Write(expense.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td>");
#nullable restore
#line 33 "/Users/apple/FinalProject/BuildingManager/BuildingManager.Web/Views/Expense/GetPaidExpense.cshtml"
           Write(expense.InvoiceDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td>");
#nullable restore
#line 34 "/Users/apple/FinalProject/BuildingManager/BuildingManager.Web/Views/Expense/GetPaidExpense.cshtml"
           Write(expense.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td>");
#nullable restore
#line 35 "/Users/apple/FinalProject/BuildingManager/BuildingManager.Web/Views/Expense/GetPaidExpense.cshtml"
           Write(expense.FlatNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td>");
#nullable restore
#line 36 "/Users/apple/FinalProject/BuildingManager/BuildingManager.Web/Views/Expense/GetPaidExpense.cshtml"
           Write(expense.ExpenseTypeName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n        </tr>\n");
#nullable restore
#line 38 "/Users/apple/FinalProject/BuildingManager/BuildingManager.Web/Views/Expense/GetPaidExpense.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ExpenseDto>> Html { get; private set; }
    }
}
#pragma warning restore 1591
