#pragma checksum "C:\Users\Ismael\Desktop\Biblioteca\Views\Usuario\Listar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7813d83d759781edfe108238b6cd56053ad4ba1d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Usuario_Listar), @"mvc.1.0.view", @"/Views/Usuario/Listar.cshtml")]
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
#line 1 "C:\Users\Ismael\Desktop\Biblioteca\Views\_ViewImports.cshtml"
using Biblioteca;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Ismael\Desktop\Biblioteca\Views\_ViewImports.cshtml"
using Biblioteca.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7813d83d759781edfe108238b6cd56053ad4ba1d", @"/Views/Usuario/Listar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ea07f0214da259abc315dec5bc842518e8ae187", @"/Views/_ViewImports.cshtml")]
    public class Views_Usuario_Listar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Usuario>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
    <h1>LISTA USUARIOS CADASTRADOS:</h1>

    <table class=""table"">

        <thead> 
            <tr> 
                <th>Nome</th>
                <th>Usuarios</th>
                <th>Senha</th>
                <th>Manutenção</th>

            </tr>

        </thead>


");
#nullable restore
#line 19 "C:\Users\Ismael\Desktop\Biblioteca\Views\Usuario\Listar.cshtml"
         foreach (Usuario a in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("           <tr> \r\n                \r\n                <td>");
#nullable restore
#line 23 "C:\Users\Ismael\Desktop\Biblioteca\Views\Usuario\Listar.cshtml"
               Write(a.nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 24 "C:\Users\Ismael\Desktop\Biblioteca\Views\Usuario\Listar.cshtml"
               Write(a.user);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 25 "C:\Users\Ismael\Desktop\Biblioteca\Views\Usuario\Listar.cshtml"
               Write(a.senha);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                \r\n                <td>\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 565, "\"", 603, 2);
            WriteAttributeValue("", 572, "/Usuario/Editar?Id=", 572, 19, true);
#nullable restore
#line 28 "C:\Users\Ismael\Desktop\Biblioteca\Views\Usuario\Listar.cshtml"
WriteAttributeValue("", 591, a.idUsuario, 591, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Editar</a>/\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 640, "\"", 679, 2);
            WriteAttributeValue("", 647, "/Usuario/Deletar?Id=", 647, 20, true);
#nullable restore
#line 29 "C:\Users\Ismael\Desktop\Biblioteca\Views\Usuario\Listar.cshtml"
WriteAttributeValue("", 667, a.idUsuario, 667, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Excluir</a>/\r\n                    \r\n\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 34 "C:\Users\Ismael\Desktop\Biblioteca\Views\Usuario\Listar.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    </table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Usuario>> Html { get; private set; }
    }
}
#pragma warning restore 1591
