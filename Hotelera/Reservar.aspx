<%@ Page Title="Reservar"Language="C#" AutoEventWireup="true" CodeBehind="Reservar.aspx.cs" Inherits="Hotelera.Reservar" MasterPageFile="~/master.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="centerpage" runat="server">

<%--<asp:Table ID="Table2" runat="server" Height="280px" Width="437px">
    <asp:TableRow>
        <asp:TableHeaderCell>Fecha Ingreso</asp:TableHeaderCell>
        <asp:TableHeaderCell>Fecha Salida</asp:TableHeaderCell>
    </asp:TableRow>
     <asp:TableRow>
        <asp:TableHeaderCell><asp:Calendar ID="cdFechaIngreso" runat="server" Height="5px" Width="10px" OnSelectionChanged="cambioFecIni"></asp:Calendar></asp:TableHeaderCell>
        <asp:TableHeaderCell><asp:Calendar ID="cdFechaSalida" runat="server" Height="5px" Width="10px" OnSelectionChanged="cambioFecSal"></asp:Calendar></asp:TableHeaderCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableHeaderCell>Habitaciones Disp: <asp:DropDownList ID="lstHabitaciones" runat="server" Width ="70px" OnSelectedIndexChanged="lstHabitaciones_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></asp:TableHeaderCell>
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


</asp:Table>--%>
    <table style="height:280px;width:437px">
        <tr>
            <td>
                <span>Fecha Ingreso</span>
            </td>
            <td>
                <span>Fecha Salida</span>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Calendar ID="cdFechaIngreso" runat="server" Height="180px" Width="200px" OnSelectionChanged="cambioFecIni" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" >
                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                    <NextPrevStyle VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#808080" />
                    <SelectedDayStyle BackColor="#CCCCCC" Font-Bold="True" ForeColor="White" />
                    <SelectorStyle BackColor="#CCCCCC" />
                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                    <TodayDayStyle ForeColor="Black" />
                    <WeekendDayStyle BackColor="#FFFFCC" />
                </asp:Calendar>
            </td>
            <td>
                <asp:Calendar ID="cdFechaSalida" runat="server" Height="180px" Width="200px" OnSelectionChanged="cambioFecSal" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" >
                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                    <NextPrevStyle VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#808080" />
                    <SelectedDayStyle BackColor="#CCCCCC" Font-Bold="True" ForeColor="White" />
                    <SelectorStyle BackColor="#CCCCCC" />
                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                    <TodayDayStyle ForeColor="Black" />
                    <WeekendDayStyle BackColor="#FFFFCC" />
                </asp:Calendar>
            </td>
        </tr>
        <tr>
            <td>
                <span>Habitaciones Disp: </span><asp:DropDownList ID="lstHabitaciones" runat="server" Width ="70px" OnSelectedIndexChanged="lstHabitaciones_SelectedIndexChanged" AutoPostBack="True" />
            </td>
            <td>
                <span>Costo: </span><asp:TextBox ID="txtCosto" runat="server" Enabled="false" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="erro" runat="server" Visible="false" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnReservar" runat="server" Text="Reservar" OnClick="clickReservar" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="menubar" runat="server">
</asp:Content>