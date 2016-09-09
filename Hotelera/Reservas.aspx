<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Reservas.aspx.cs" Inherits="Hotelera.Reservas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="centerpage" runat="server">
    <div>

        <!--

            Diseño tabla de reservas - tabla se genera dinamicamente

            -----------------------------------------------------
            | Desde     |  Hasta    |  Habitación   |  Costo    |
            |-----------|-----------|---------------|-----------|
            | 02/02/2015| 05/02/2015| 203 - Single  | $54.000   |
            |-----------|-----------|---------------|-----------|
            |           |           |               |           |
            |-----------|-----------|---------------|-----------|
            |           |           |               |           |
            |-----------|-----------|---------------|-----------|
            |           |           |               |           |
            -----------------------------------------------------

            -->
        <table>
            <tr>
                <td>
                    <asp:Label ID="mensaje" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <span>Reservas Activas</span>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Table ID="tablaAct" runat="server" /><!--aqui vamos a cargar una lista de las reservas que esten activas, por debajo en el codigo -Ismael -->
                </td>
            </tr>
            <tr>
                <td><br /><br /></td>
            </tr>
            <tr>
                <td>
                    <span>Reservas Anteriores</span>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Table ID="tablaAnt" runat="server" /><!-- mismo que arriba, pero aqui van las que ya pasaron -Ismael -->
                </td>
            </tr>
        </table>
        
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="menubar" runat="server">
</asp:Content>
