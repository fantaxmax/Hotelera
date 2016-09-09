<%@ Page Title="Reservar"Language="C#" AutoEventWireup="true" CodeBehind="Reservar.aspx.cs" Inherits="Hotelera.Reservar" MasterPageFile="~/master.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="centerpage" runat="server">

<asp:Table ID="Table2" runat="server" Height="280px" Width="437px">
    <asp:TableRow>
        <asp:TableHeaderCell>Fecha Ingreso</asp:TableHeaderCell>
        <asp:TableHeaderCell>Fecha Salida</asp:TableHeaderCell>
    </asp:TableRow>
     <asp:TableRow>
        <asp:TableHeaderCell><asp:Calendar ID="cdFechaIngreso" runat="server" Height="5px" Width="10px" OnSelectionChanged="cambioFecIni"></asp:Calendar></asp:TableHeaderCell>
        <asp:TableHeaderCell><asp:Calendar ID="cdFechaSalida" runat="server" Height="5px" Width="10px" OnSelectionChanged="cambioFecSal"></asp:Calendar></asp:TableHeaderCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableHeaderCell>Habitaciones Disp: <asp:DropDownList ID="lstHabitaciones" runat="server" Width ="70px"></asp:DropDownList></asp:TableHeaderCell>
        <asp:TableHeaderCell>Costo: <asp:TextBox ID="txtCosto" runat="server" Enabled="false"></asp:TextBox></asp:TableHeaderCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableHeaderCell>
            <asp:TextBox ID="txtError" runat="server" Width ="100px" Visible="false"></asp:TextBox>
        </asp:TableHeaderCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableHeaderCell>
            <asp:Button ID="btnReservar" runat="server" Text="Reservar" OnClick="clickReservar" />
        </asp:TableHeaderCell>
    </asp:TableRow>


</asp:Table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="menubar" runat="server">
</asp:Content>