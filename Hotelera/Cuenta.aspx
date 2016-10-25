<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Cuenta.aspx.cs" Inherits="Hotelera.Cuenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="centerpage" runat="server">
    <div>
        
        <table> 
            <tr>
                <td colspan="3">
                    <h1>Mi Cuenta</h1>
                </td>
            </tr>
            <tr><td colspan="3"><asp:Label ID="mensaje" runat="server" Visible="false"/></td></tr>
            <tr>
                <td>
                    <span>Nombres</span>
                </td>
                <td style="width:20px"><span>:</span></td>
                <td>
                    <asp:TextBox ID="txtnombres" runat="server" style="width:330px"/>
                </td>
            </tr>
            <tr>
                <td>
                    <span>Apellidos</span>
                </td>
                <td style="width:20px"><span>:</span></td>
                <td>
                    <asp:TextBox ID="txtapellidos" runat="server" style="width:330px"/>
                </td>
            </tr>
            <tr>
                <td>
                    <span>Rut</span>
                </td>
                <td style="width:20px"><span>:</span></td>
                <td>
                    <asp:TextBox ID="txtrut" runat="server" style="width:330px" Enabled="False"/>
                </td>
            </tr>
            <tr>
                <td>
                    <span>Fecha Nac.</span>
                </td>
                <td style="width:20px"><span></span></td>
                <td>
                    <asp:Calendar ID="calNac" runat="server" >
                    </asp:Calendar>
                </td>
            </tr>
            <tr>
                <td>
                    <span>Clave</span>
                </td>
                <td style="width:20px"><span>:</span></td>
                <td>
                    <asp:Button ID="btnclave" Text="Cambiar" runat="server" OnClick="btnclave_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <div><!--la intencion es que este al centro -Ismael -->
                        <asp:Button ID="btnActualiza" Text="Actualizar" runat="server" OnClick="btnActualiza_Click" Enabled="False" Visible="False" />
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <span>Reservas</span>
                </td>
                <td style="width:20px"><span>:</span></td>
                <td>
                    <a href="Reservas.aspx">Ver Lista</a>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="menubar" runat="server">
</asp:Content>
