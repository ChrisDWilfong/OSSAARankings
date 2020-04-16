<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FootballSchedules.aspx.vb" Inherits="OSSAARankings.FootballSchedules" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AllowSorting="True" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" 
        BorderWidth="1px" CellPadding="4" DataSourceID="SqlDataSource1" 
        ForeColor="Black" GridLines="Vertical">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="TeamID" />
            <asp:BoundField DataField="School" HeaderText="School" />
            <asp:BoundField DataField="avgGolfScore" HeaderText="Score" />
            <asp:BoundField DataField="strClass" HeaderText="Class" />
        </Columns>
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#F7F7DE" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FBFBF2" />
        <SortedAscendingHeaderStyle BackColor="#848384" />
        <SortedDescendingCellStyle BackColor="#EAEAD3" />
        <SortedDescendingHeaderStyle BackColor="#575357" />
    </asp:GridView>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>   
    <div>
   
    </div>
    </form>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OSSAARANKINGSConnectionString %>" 
        SelectCommand="SELECT [SchoolName], [SchFootball], [DistSchFootball], [sportID], [teamID] FROM [viewStatsFootballSchedules] ORDER BY [SchFootball] DESC, [SchoolName]"></asp:SqlDataSource>
</body>
</html>
