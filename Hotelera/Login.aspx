<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Hotelera.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="centerpage" runat="server">
    <div>
        <table>
            <tr>
                <td colspan="2">
                    <span style="text-align:left">Inicio de Sesión o Registrate si no tienes cuenta</span>
                </td>
            </tr>
            <tr>
                <td>
                    <span style="text-align:left">Rut</span><span style="text-align:right">:</span>
                </td>
                <td>
                    <asp:TextBox ID="txtrut" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <span style="text-align:left">Clave</span><span style="text-align:right">:</span>
                </td>
                <td>
                    <asp:TextBox ID="txtpwd" runat="server" TextMode="Password" />
               </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnRegistro" Text="Registrarse" runat="server" OnClick="btnRegistro_Click" />
                </td>
                <td>
                    <asp:Button ID="btnInicioSesion" Text="Iniciar Sesión" runat="server" OnClick="btnInicioSesion_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="menubar" runat="server">
</asp:Content>
