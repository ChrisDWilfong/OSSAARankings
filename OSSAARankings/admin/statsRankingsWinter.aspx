<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="statsRankingsWinter.aspx.vb" Inherits="OSSAARankings.statsRankingsWinter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div><asp:Label ID="Label1" runat="server" Text="Rankings " Font-Names="Verdana" Font-Size="12pt" Font-Bold="true"></asp:Label></div>
    <div><asp:Label ID="lblBK6ABoys" runat="server" Text="Basketball Boys (6A) : " Font-Names="Verdana" Font-Size="8pt"></asp:Label></div>
    <div><asp:Label ID="lblBK5ABoys" runat="server" Text="Basketball Boys (5A) : " Font-Names="Verdana" Font-Size="8pt"></asp:Label></div>
    <div><asp:Label ID="lblBK4ABoys" runat="server" Text="Basketball Boys (4A) : " Font-Names="Verdana" Font-Size="8pt"></asp:Label></div>
    <div><asp:Label ID="lblBK3ABoys" runat="server" Text="Basketball Boys (3A) : " Font-Names="Verdana" Font-Size="8pt"></asp:Label></div>
    <div><asp:Label ID="lblBK2ABoys" runat="server" Text="Basketball Boys (2A) : " Font-Names="Verdana" Font-Size="8pt"></asp:Label></div>
    <div><asp:Label ID="lblBKABoys" runat="server" Text="Basketball Boys (A) : " Font-Names="Verdana" Font-Size="8pt"></asp:Label></div>
    <div><asp:Label ID="lblBKBBoys" runat="server" Text="Basketball Boys (B) : " Font-Names="Verdana" Font-Size="8pt"></asp:Label></div>
    <div><asp:Label ID="lblBK6AGirls" runat="server" Text="Basketball Girls (6A) : " Font-Names="Verdana" Font-Size="8pt"></asp:Label></div>
    <div><asp:Label ID="lblBK5AGirls" runat="server" Text="Basketball Girls (5A) : " Font-Names="Verdana" Font-Size="8pt"></asp:Label></div>
    <div><asp:Label ID="lblBK4AGirls" runat="server" Text="Basketball Girls (4A) : " Font-Names="Verdana" Font-Size="8pt"></asp:Label></div>
    <div><asp:Label ID="lblBK3AGirls" runat="server" Text="Basketball Girls (3A) : " Font-Names="Verdana" Font-Size="8pt"></asp:Label></div>
    <div><asp:Label ID="lblBK2AGirls" runat="server" Text="Basketball Girls (2A) : " Font-Names="Verdana" Font-Size="8pt"></asp:Label></div>
    <div><asp:Label ID="lblBKAGirls" runat="server" Text="Basketball Girls (A) : " Font-Names="Verdana" Font-Size="8pt"></asp:Label></div>
    <div><asp:Label ID="lblBKBGirls" runat="server" Text="Basketball Girls (B) : " Font-Names="Verdana" Font-Size="8pt"></asp:Label></div>
    <div><asp:Label ID="lblBKTotal" runat="server" Text="Basketball (TOTAL) : " Font-Names="Verdana" Font-Size="8pt" Font-Bold="true"></asp:Label></div>
    <div><hr /></div>
    <div><asp:Label ID="lblSW6ABoys" runat="server" Text="Swimming Boys (6A) : " Font-Names="Verdana" Font-Size="8pt"></asp:Label></div>
    <div><asp:Label ID="lblSW5ABoys" runat="server" Text="Swimming Boys (5A) : " Font-Names="Verdana" Font-Size="8pt"></asp:Label></div>
    <div><asp:Label ID="lblSW6AGirls" runat="server" Text="Swimming Girls (6A) : " Font-Names="Verdana" Font-Size="8pt"></asp:Label></div>
    <div><asp:Label ID="lblSW5AGirls" runat="server" Text="Swimming Girls (5A) : " Font-Names="Verdana" Font-Size="8pt"></asp:Label></div>
    <div><asp:Label ID="lblSWTotal" runat="server" Text="Swimming (TOTAL) : " Font-Names="Verdana" Font-Size="8pt" Font-Bold="true"></asp:Label></div>
    <div><hr /></div>
    <div><asp:Label ID="lblWR6A" runat="server" Text="Wrestling (6A) : " Font-Names="Verdana" Font-Size="8pt"></asp:Label></div>
    <div><asp:Label ID="lblWR5A" runat="server" Text="Wrestling (5A) : " Font-Names="Verdana" Font-Size="8pt"></asp:Label></div>
    <div><asp:Label ID="lblWR4A" runat="server" Text="Wrestling (4A) : " Font-Names="Verdana" Font-Size="8pt"></asp:Label></div>
    <div><asp:Label ID="lblWR3A" runat="server" Text="Wrestling (3A) : " Font-Names="Verdana" Font-Size="8pt"></asp:Label></div>
    <div><asp:Label ID="lblWRTotal" runat="server" Text="Wrestling (TOTAL) : " Font-Names="Verdana" Font-Size="8pt"></asp:Label></div>

    <div><asp:Label ID="lblWRD6A" runat="server" Text="Wrestling (Dual) (6A) : " Font-Names="Verdana" Font-Size="8pt"></asp:Label></div>
    <div><asp:Label ID="lblWRD5A" runat="server" Text="Wrestling (Dual) (5A) : " Font-Names="Verdana" Font-Size="8pt"></asp:Label></div>
    <div><asp:Label ID="lblWRD4A" runat="server" Text="Wrestling (Dual) (4A) : " Font-Names="Verdana" Font-Size="8pt"></asp:Label></div>
    <div><asp:Label ID="lblWRD3A" runat="server" Text="Wrestling (Dual) (3A) : " Font-Names="Verdana" Font-Size="8pt"></asp:Label></div>
    <div><asp:Label ID="lblWRDTotal" runat="server" Text="Wrestling (Dual) (TOTAL) : " Font-Names="Verdana" Font-Size="8pt"></asp:Label></div>

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
