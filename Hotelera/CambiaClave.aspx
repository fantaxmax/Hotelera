<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="CambiaClave.aspx.cs" Inherits="Hotelera.CambiaClave" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="menubar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="centerpage" runat="server">
    <div>
        <table>
            <tr>
                <td colspan="3">
                    <span>Actualiza tu clave</span>
                </td>
            </tr>
            <tr>
                <td>
                    <span>Nueva Clave</span>
                </td>
                <td style="width:20px"><span>:</span></td>
                <td>
                    <asp:TextBox ID="txtclave" runat="server" TextMode="Password" />
                </td>
            </tr>
            <tr>
                <td>
                    <span>Confirma Clave</span>
                </td>
                <td style="width:20px"><span>:</span></td>
                <td>
                    <asp:TextBox ID="txtconfclave" runat="server" TextMode="Password" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Button ID="btncambia" runat="server" Text="Actualizar" OnClick="btncambia_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
