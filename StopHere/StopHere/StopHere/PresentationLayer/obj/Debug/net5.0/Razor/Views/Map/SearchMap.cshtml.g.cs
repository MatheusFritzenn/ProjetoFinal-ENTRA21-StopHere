#pragma checksum "C:\Users\Fabia\Downloads\StopHereDiaDaFormatura\StopHereDiaDaFormatura\PresentationLayer\Views\Map\SearchMap.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "857f3f8c88c2a1760dd9324654bb07616e5d4d91"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Map_SearchMap), @"mvc.1.0.view", @"/Views/Map/SearchMap.cshtml")]
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
#line 1 "C:\Users\Fabia\Downloads\StopHereDiaDaFormatura\StopHereDiaDaFormatura\PresentationLayer\Views\_ViewImports.cshtml"
using PresentationLayer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Fabia\Downloads\StopHereDiaDaFormatura\StopHereDiaDaFormatura\PresentationLayer\Views\_ViewImports.cshtml"
using PresentationLayer.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"857f3f8c88c2a1760dd9324654bb07616e5d4d91", @"/Views/Map/SearchMap.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"30be6e8d357e7570361a44c6f59cbfc77c09d358", @"/Views/_ViewImports.cshtml")]
    public class Views_Map_SearchMap : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css1/mapstyle.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Fabia\Downloads\StopHereDiaDaFormatura\StopHereDiaDaFormatura\PresentationLayer\Views\Map\SearchMap.cshtml"
  
    ViewData["Title"] = "SearchMap";

#line default
#line hidden
#nullable disable
            WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "857f3f8c88c2a1760dd9324654bb07616e5d4d914505", async() => {
                WriteLiteral("\r\n    <title>Simple Map</title>\r\n    <script src=\"https://polyfill.io/v3/polyfill.min.js?features=default\"></script>\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "857f3f8c88c2a1760dd9324654bb07616e5d4d914889", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "857f3f8c88c2a1760dd9324654bb07616e5d4d916771", async() => {
                WriteLiteral(@"
    <div id=""map""></div>

    <!-- Async script executes immediately and must be after any DOM elements used in callback. -->
    <script src=""https://maps.googleapis.com/maps/api/js?key=AIzaSyAGLXT11vHyrybLHkzJSJiR39-2PO_DII4&callback=initMap&libraries=&v=weekly""
            async></script>
    <script>
        function initMap() {

            const Location = { lat: ");
#nullable restore
#line 21 "C:\Users\Fabia\Downloads\StopHereDiaDaFormatura\StopHereDiaDaFormatura\PresentationLayer\Views\Map\SearchMap.cshtml"
                               Write(ViewBag.Latitude);

#line default
#line hidden
#nullable disable
                WriteLiteral(", lng: ");
#nullable restore
#line 21 "C:\Users\Fabia\Downloads\StopHereDiaDaFormatura\StopHereDiaDaFormatura\PresentationLayer\Views\Map\SearchMap.cshtml"
                                                       Write(ViewBag.Longitude);

#line default
#line hidden
#nullable disable
                WriteLiteral(@" };
            const map = new google.maps.Map(document.getElementById(""map""), {
                zoom: 15,
                center: Location,
            });

            const SHicon = ""https://i.imgur.com/rUt1lHG.png"";

            const SHmarker = new google.maps.Marker({
                position: Location,
                map,
                title: ""Your location"",
            });

            var estacionamentosJson = ");
#nullable restore
#line 35 "C:\Users\Fabia\Downloads\StopHereDiaDaFormatura\StopHereDiaDaFormatura\PresentationLayer\Views\Map\SearchMap.cshtml"
                                 Write(Html.Raw(Json.Serialize(ViewBag.Parkings)));

#line default
#line hidden
#nullable disable
                WriteLiteral(@";
            var estacionamentos = JSON.parse(estacionamentosJson);

            for (var i = 0; i < estacionamentos.length; i++) {

                const infowindow =new google.maps.InfoWindow({
                    content: `<div>
                            <h1><b>Informações Principais</b></h1>
                          </div>
                          <div>
                            <p>Abertura: ${estacionamentos[i].Abre}</p>
                            <p>Fechamento: ${estacionamentos[i].Fecha} </p>
                            <p>Coberta: ${estacionamentos[i].IsCoberta == true ? ""Sim"" : ""Não""}</p >
                            <p>Vigilância: ${estacionamentos[i].IsVigiada == true ? ""Sim"" : ""Não""}</p >
                            <p>Necessário deixar chave:  ${estacionamentos[i].DeixarChave == true ? ""Sim"" : ""Não""} </p>
                            <p>Valor:  ${estacionamentos[i].Valor}</p>
                          </div>
                          <a href='/Location/Add/${estacionamento");
                WriteLiteral(@"s[i].ID}' style=""color:red"">Entrar em contato</a>`,
                });

                var locationTemp = { lat: parseFloat(estacionamentos[i].Latitude), lng: parseFloat(estacionamentos[i].Longitude) };

                const marker = new google.maps.Marker({
                    position: locationTemp,
                    map,
                    icon: SHicon
                });

                marker.addListener(""click"", () => {
                    infowindow.open({
                        anchor: marker,
                        map,
                        shouldFocus: false,
                    });
                });
            }
        }
    </script>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 76 "C:\Users\Fabia\Downloads\StopHereDiaDaFormatura\StopHereDiaDaFormatura\PresentationLayer\Views\Map\SearchMap.cshtml"
       await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            }
            );
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
