<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="statsLockout.aspx.vb" Inherits="OSSAARankings.statsLockout" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
            CellPadding="3" DataSourceID="SqlDataSource1" GridLines="Vertical" Font-Names="Verdana" Font-Size="8pt">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:BoundField DataField="sportID" HeaderText="sportID" 
                    SortExpression="sportID" />
                <asp:BoundField DataField="memberID" HeaderText="memberID" 
                    SortExpression="memberID" />
                <asp:BoundField DataField="teamID" HeaderText="teamID" 
                    SortExpression="teamID" />
                <asp:BoundField DataField="weekID" HeaderText="weekID" 
                    SortExpression="weekID" />
                <asp:BoundField DataField="numWeeksVoted" HeaderText="numWeeksVoted" 
                    SortExpression="numWeeksVoted" />
                <asp:BoundField DataField="numLockoutValue" HeaderText="numLockoutValue" 
                    SortExpression="numLockoutValue" />
                <asp:BoundField DataField="SchoolName" HeaderText="SchoolName" 
                    SortExpression="SchoolName" />
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" 
                    SortExpression="FirstName" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" 
                    SortExpression="LastName" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:OSSAARANKINGSConnectionString %>" 
            SelectCommand="SELECT * FROM [viewStatsLockout]"></asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
