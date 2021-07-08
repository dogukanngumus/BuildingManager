#pragma checksum "/Users/apple/FinalProject/BuildingManager/BuildingManager.Web/Views/Home/Outbox.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4d4aebf211264f0111dcbecfff207f3007ecdef2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Outbox), @"mvc.1.0.view", @"/Views/Home/Outbox.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d4aebf211264f0111dcbecfff207f3007ecdef2", @"/Views/Home/Outbox.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7124492bb4d58be92f6cce47f091b08f2cf518d5", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Outbox : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<MessageDto>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n<table id=\"datatable\" style=\"width:100%\" class=\"table table-hover table-striped\">\n    <thead>\n    <tr>\n        <th scope=\"col\">Id</th>\n        <th scope=\"col\">Message</th>\n        <th scope=\"col\">Sender UserName</th>\n    </tr>\n    </thead>\n    <tbody>\n");
#nullable restore
#line 12 "/Users/apple/FinalProject/BuildingManager/BuildingManager.Web/Views/Home/Outbox.cshtml"
     foreach (var message in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\n            <td>");
#nullable restore
#line 15 "/Users/apple/FinalProject/BuildingManager/BuildingManager.Web/Views/Home/Outbox.cshtml"
           Write(message.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td>");
#nullable restore
#line 16 "/Users/apple/FinalProject/BuildingManager/BuildingManager.Web/Views/Home/Outbox.cshtml"
           Write(Html.Raw(message.MessageContent));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td>");
#nullable restore
#line 17 "/Users/apple/FinalProject/BuildingManager/BuildingManager.Web/Views/Home/Outbox.cshtml"
           Write(message.SenderEmail);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n        </tr>\n");
#nullable restore
#line 19 "/Users/apple/FinalProject/BuildingManager/BuildingManager.Web/Views/Home/Outbox.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<MessageDto>> Html { get; private set; }
    }
}
#pragma warning restore 1591
