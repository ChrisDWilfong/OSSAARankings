<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="statsRankingsFall.aspx.vb" Inherits="OSSAARankings.statsRankingsFall" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div><asp:Label ID="Label1" runat="server" Text="Rankings " Font-Names="Verdana" Font-Size="12pt" Font-Bold="true"></asp:Label></div>
    <div><asp:Label ID="lblFP6A" runat="server" Text="Fast Pitch (6A) : " Font-Names="Verdana" Font-Size="8pt"></asp:Label></div>
    <div><asp:Label ID="lblFP5A" runat="server" Text="Fast Pitch (5A) : " Font-Names="Verdana" Font-Size="8pt"></asp:Label></div>
    <div><asp:Label ID="lblFP4A" runat="server" Text="Fast Pitch (4A) : " Font-Names="Verdana" Font-Size="8pt"></asp:Label></div>
    <div><asp:Label ID="lblFP3A" runat="server" Text="Fast Pitch (3A) : " Font-Names="Verdana" Font-Size="8pt"></asp:Label></div>
    <div><asp:Label ID="lblFP2A" runat="server" Text="Fast Pitch (2A) : " Font-Names="Verdana" Font-Size="8pt"></asp:Label></div>
    <div><asp:Label ID="lblFPA" runat="server" Text="Fast Pitch (A) : " Font-Names="Verdana" Font-Size="8pt"></asp:Label></div>
    <div><asp:Label ID="lblFPB" runat="server" Text="Fast Pitch (B) : " Font-Names="Verdana" Font-Size="8pt"></asp:Label></div>
    <div><asp:Label ID="lblFPTotal" runat="server" Text="Fast Pitch (TOTAL) : " Font-Names="Verdana" Font-Size="8pt" Font-Bold="true"></asp:Label></div>
    <div><hr /></div>
    <div><asp:Label ID="lblVB6A" runat="server" Text="Volleyball (6A) : " Font-Names="Verdana" Font-Size="8pt"></asp:Label></div>
    <div><asp:Label ID="lblVB5A" runat="server" Text="Volleyball (5A) : " Font-Names="Verdana" Font-Size="8pt"></asp:Label></div>
    <div><asp:Label ID="lblVB4A" runat="server" Text="Volleyball (4A) : " Font-Names="Verdana" Font-Size="8pt"></asp:Label></div>
    <div><asp:Label ID="lblVB3A" runat="server" Text="Volleyball (3A) : " Font-Names="Verdana" Font-Size="8pt"></asp:Label></div>
    <div><asp:Label ID="lblVBTotal" runat="server" Text="Volleyball (TOTAL) : " Font-Names="Verdana" Font-Size="8pt" Font-Bold="true"></asp:Label></div>
    <div><hr /></div>
    <div><asp:Label ID="lblFBBA" runat="server" Text="Fall Baseball (A) : " Font-Names="Verdana" Font-Size="8pt"></asp:Label></div>
    <div><asp:Label ID="lblFBBB" runat="server" Text="Fall Baseball (B) : " Font-Names="Verdana" Font-Size="8pt"></asp:Label></div>
    <div><asp:Label ID="lblFBBTotal" runat="server" Text="Fall Baseball (TOTAL) : " Font-Names="Verdana" Font-Size="8pt" Font-Bold="true"></asp:Label></div>
    <div><hr /></div>
    <div><asp:Label ID="lblTotal" runat="server" Text="GRAND TOTAL : " Font-Names="Verdana" Font-Size="8pt" Font-Bold="true"></asp:Label></div>
    <div><hr /></div>
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" DataSourceID="SqlDataSource1" Font-Names="Verdana" Font-Size="8pt">
            <Columns>
                <asp:BoundField DataField="SchoolName" HeaderText="School" 
                    SortExpression="SchoolName" />
                <asp:BoundField DataField="sportID" HeaderText="Sport" 
                    SortExpression="sportID" />
            </Columns>
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#330099" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>
    
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OSSAARANKINGSConnectionString %>" 
        SelectCommand="SELECT [SchoolName], [sportID] FROM ossaauser.viewStatsSubmittedRankings ORDER BY [sportID], [SchoolName]">
    </asp:SqlDataSource>
    </form>
</body>
</html>
