#pragma checksum "C:\Users\Fabia\Downloads\StopHereDiaDaFormatura\StopHereDiaDaFormatura\PresentationLayer\Views\Vehicle\ShowAll.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "da71bd0737f97a4beff7048f161035d5aaac2244"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Vehicle_ShowAll), @"mvc.1.0.view", @"/Views/Vehicle/ShowAll.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"da71bd0737f97a4beff7048f161035d5aaac2244", @"/Views/Vehicle/ShowAll.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"30be6e8d357e7570361a44c6f59cbfc77c09d358", @"/Views/_ViewImports.cshtml")]
    public class Views_Vehicle_ShowAll : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<PresentationLayer.Models.Vehicle.VehicleShowAllViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Fabia\Downloads\StopHereDiaDaFormatura\StopHereDiaDaFormatura\PresentationLayer\Views\Vehicle\ShowAll.cshtml"
  
    ViewData["Title"] = "ShowAll";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<script defer type=""text/javascript"">
    function editData(id) {
        window.location.href = '/Vehicle/Edit/' + id;
    }


    function deleteData(id) {
        window.location.href = '/Vehicle/Disable/' + id;
    }

</script>
<!--link de acesso para cadastrar novo veiculo-->
<a class=""flex items-center justify-between p-4 mb-8 text-sm font-semibold text-purple-100 bg-purple-600 rounded-lg shadow-md focus:outline-none focus:shadow-outline-purple""
   href=""/Vehicle/Create/"">
    <div class=""flex items-center"">
        <span><font style=""vertical-align: inherit;""><font style=""vertical-align: inherit;"">Cadastrar novo ve??culo :</font></font></span>
    </div>
    <span><font style=""vertical-align: inherit;""><font style=""vertical-align: inherit;"">Clique aqui ???</font></font></span>
</a>
<!--inicio da tabela-->
<!--Cabe??alho-->
<table class=""w-full whitespace-no-wrap"">
    <thead>
        <tr>
            <th>
                ");
#nullable restore
#line 31 "C:\Users\Fabia\Downloads\StopHereDiaDaFormatura\StopHereDiaDaFormatura\PresentationLayer\Views\Vehicle\ShowAll.cshtml"
           Write(Html.DisplayNameFor(model => model.ID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th class=\"px-4 py-3\">\r\n                ");
#nullable restore
#line 34 "C:\Users\Fabia\Downloads\StopHereDiaDaFormatura\StopHereDiaDaFormatura\PresentationLayer\Views\Vehicle\ShowAll.cshtml"
           Write(Html.DisplayNameFor(model => model.Modelo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th class=\"px-4 py-3\">\r\n                ");
#nullable restore
#line 37 "C:\Users\Fabia\Downloads\StopHereDiaDaFormatura\StopHereDiaDaFormatura\PresentationLayer\Views\Vehicle\ShowAll.cshtml"
           Write(Html.DisplayNameFor(model => model.Marca));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th class=\"px-4 py-3\">\r\n                ");
#nullable restore
#line 40 "C:\Users\Fabia\Downloads\StopHereDiaDaFormatura\StopHereDiaDaFormatura\PresentationLayer\Views\Vehicle\ShowAll.cshtml"
           Write(Html.DisplayNameFor(model => model.Cor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th class=\"px-4 py-3\">\r\n                ");
#nullable restore
#line 43 "C:\Users\Fabia\Downloads\StopHereDiaDaFormatura\StopHereDiaDaFormatura\PresentationLayer\Views\Vehicle\ShowAll.cshtml"
           Write(Html.DisplayNameFor(model => model.Placa));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th class=\"px-4 py-3\">\r\n                ");
#nullable restore
#line 46 "C:\Users\Fabia\Downloads\StopHereDiaDaFormatura\StopHereDiaDaFormatura\PresentationLayer\Views\Vehicle\ShowAll.cshtml"
           Write(Html.DisplayNameFor(model => model.TamanhoVeiculo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th class=\"px-4 py-3\">\r\n                ");
#nullable restore
#line 49 "C:\Users\Fabia\Downloads\StopHereDiaDaFormatura\StopHereDiaDaFormatura\PresentationLayer\Views\Vehicle\ShowAll.cshtml"
           Write(Html.DisplayNameFor(model => model.TipoVeiculo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th class=\"px-4 py-3\"><font style=\"vertical-align: inherit;\"><font style=\"vertical-align: inherit;\">A????es</font></font></th>\r\n        </tr>\r\n    </thead>\r\n    <!--Inicio do conteudo da tabela-->\r\n    <tbody>\r\n");
#nullable restore
#line 56 "C:\Users\Fabia\Downloads\StopHereDiaDaFormatura\StopHereDiaDaFormatura\PresentationLayer\Views\Vehicle\ShowAll.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td class=\"px-4 py-3\">\r\n                    ");
#nullable restore
#line 60 "C:\Users\Fabia\Downloads\StopHereDiaDaFormatura\StopHereDiaDaFormatura\PresentationLayer\Views\Vehicle\ShowAll.cshtml"
               Write(Html.DisplayFor(modelItem => item.ID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td class=\"px-4 py-3\">\r\n                    ");
#nullable restore
#line 63 "C:\Users\Fabia\Downloads\StopHereDiaDaFormatura\StopHereDiaDaFormatura\PresentationLayer\Views\Vehicle\ShowAll.cshtml"
               Write(Html.DisplayFor(modelItem => item.Modelo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td class=\"px-4 py-3\">\r\n                    ");
#nullable restore
#line 66 "C:\Users\Fabia\Downloads\StopHereDiaDaFormatura\StopHereDiaDaFormatura\PresentationLayer\Views\Vehicle\ShowAll.cshtml"
               Write(Html.DisplayFor(modelItem => item.Marca));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td class=\"px-4 py-3\">\r\n                    ");
#nullable restore
#line 69 "C:\Users\Fabia\Downloads\StopHereDiaDaFormatura\StopHereDiaDaFormatura\PresentationLayer\Views\Vehicle\ShowAll.cshtml"
               Write(Html.DisplayFor(modelItem => item.Cor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td class=\"px-4 py-3\">\r\n                    ");
#nullable restore
#line 72 "C:\Users\Fabia\Downloads\StopHereDiaDaFormatura\StopHereDiaDaFormatura\PresentationLayer\Views\Vehicle\ShowAll.cshtml"
               Write(Html.DisplayFor(modelItem => item.Placa));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td class=\"px-4 py-3\">\r\n                    ");
#nullable restore
#line 75 "C:\Users\Fabia\Downloads\StopHereDiaDaFormatura\StopHereDiaDaFormatura\PresentationLayer\Views\Vehicle\ShowAll.cshtml"
               Write(Html.DisplayFor(modelItem => item.TamanhoVeiculo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td class=\"px-4 py-3\">\r\n                    ");
#nullable restore
#line 78 "C:\Users\Fabia\Downloads\StopHereDiaDaFormatura\StopHereDiaDaFormatura\PresentationLayer\Views\Vehicle\ShowAll.cshtml"
               Write(Html.DisplayFor(modelItem => item.TipoVeiculo));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </td>
                <!--Botoes para editar ou deletar com icones (lapis ou lata de lixo)-->
                <td class=""px-4 py-3"">
                    <div class=""flex items-center space-x-4 text-sm"">
                        <button");
            BeginWriteAttribute("onclick", " onclick=\"", 3262, "\"", 3290, 3);
            WriteAttributeValue("", 3272, "editData(", 3272, 9, true);
#nullable restore
#line 83 "C:\Users\Fabia\Downloads\StopHereDiaDaFormatura\StopHereDiaDaFormatura\PresentationLayer\Views\Vehicle\ShowAll.cshtml"
WriteAttributeValue("", 3281, item.ID, 3281, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3289, ")", 3289, 1, true);
            EndWriteAttribute();
            WriteLiteral(@" class=""flex items-center justify-between px-2 py-2 text-sm font-medium leading-5 text-purple-600 rounded-lg dark:text-gray-400 focus:outline-none focus:shadow-outline-gray"" aria-label=""Editar"">
                            <svg class=""w-5 h-5"" aria-hidden=""true"" fill=""currentColor"" viewBox=""0 0 20 20"">
                                <path d=""M13.586 3.586a2 2 0 112.828 2.828l-.793.793-2.828-2.828.793-.793zM11.379 5.793L3 14.172V17h2.828l8.38-8.379-2.83-2.828z""></path>
                            </svg>
                        </button>
                        <button");
            BeginWriteAttribute("onclick", " onclick=\"", 3870, "\"", 3900, 3);
            WriteAttributeValue("", 3880, "deleteData(", 3880, 11, true);
#nullable restore
#line 88 "C:\Users\Fabia\Downloads\StopHereDiaDaFormatura\StopHereDiaDaFormatura\PresentationLayer\Views\Vehicle\ShowAll.cshtml"
WriteAttributeValue("", 3891, item.ID, 3891, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3899, ")", 3899, 1, true);
            EndWriteAttribute();
            WriteLiteral(@" class=""flex items-center justify-between px-2 py-2 text-sm font-medium leading-5 text-purple-600 rounded-lg dark:text-gray-400 focus:outline-none focus:shadow-outline-gray"" aria-label=""Excluir"">
                            <svg class=""w-5 h-5"" aria-hidden=""true"" fill=""currentColor"" viewBox=""0 0 20 20"">
                                <path fill-rule=""evenodd"" d=""M9 2a1 1 0 00-.894.553L7.382 4H4a1 1 0 000 2v10a2 2 0 002 2h8a2 2 0 002-2V6a1 1 0 100-2h-3.382l-.724-1.447A1 1 0 0011 2H9zM7 8a1 1 0 012 0v6a1 1 0 11-2 0V8zm5-1a1 1 0 00-1 1v6a1 1 0 102 0V8a1 1 0 00-1-1z"" clip-rule=""evenodd""></path>
                            </svg>
                        </button>
                    </div>
                </td>
                <!--Linhas criadas pelo Razor-->
");
            WriteLiteral("            </tr>\r\n");
#nullable restore
#line 102 "C:\Users\Fabia\Downloads\StopHereDiaDaFormatura\StopHereDiaDaFormatura\PresentationLayer\Views\Vehicle\ShowAll.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<PresentationLayer.Models.Vehicle.VehicleShowAllViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
