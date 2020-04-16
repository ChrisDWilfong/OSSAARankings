<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EWRankings.aspx.vb" Inherits="OSSAARankings.EWRankings" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <asp:Label ID="lblHeaderMain" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="14pt" Text="E/W RANKINGS 2016" ForeColor="Black"></asp:Label><br />
    </div>
    <div>
        <br /><asp:Label ID="lblHeader1" runat="server"  Font-Bold="true" Font-Names="Arial" Font-Size="11pt" Text="CLASS 6A BOYS WEST" ForeColor="Maroon"></asp:Label><br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" DataKeyNames="wID,ID" DataSourceID="SQLDataSourceEW6ABW" 
            ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Rank" HeaderText="Rank" SortExpression="Rank" ItemStyle-HorizontalAlign="Right" />
                <asp:BoundField DataField="School" HeaderText="School" SortExpression="School" ItemStyle-Width="175px">
                </asp:BoundField>
                <asp:BoundField DataField="Points" HeaderText="Points" 
                    SortExpression="Points" ItemStyle-HorizontalAlign="Right" />
                <asp:BoundField DataField="NumOne" HeaderText="# One" 
                    SortExpression="NumOne" ItemStyle-HorizontalAlign="Right" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" Font-Size="9pt" Font-Names="Arial"/>
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" Font-Size="8pt" Font-Names="Arial" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
    </div>
    <div>
        <br /><asp:Label ID="Label1" runat="server"  Font-Bold="true" Font-Names="Arial" Font-Size="11pt" Text="CLASS 6A BOYS EAST" ForeColor="Maroon"></asp:Label><br />
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" DataKeyNames="wID,ID" DataSourceID="SQLDataSourceEW6ABE" 
            ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Rank" HeaderText="Rank" SortExpression="Rank" ItemStyle-HorizontalAlign="Right" />
                <asp:BoundField DataField="School" HeaderText="School" SortExpression="School" ItemStyle-Width="175px">
                </asp:BoundField>
                <asp:BoundField DataField="Points" HeaderText="Points" 
                    SortExpression="Points" ItemStyle-HorizontalAlign="Right" />
                <asp:BoundField DataField="NumOne" HeaderText="# One" 
                    SortExpression="NumOne" ItemStyle-HorizontalAlign="Right" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" Font-Size="9pt" Font-Names="Arial"/>
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" Font-Size="8pt" Font-Names="Arial" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
    </div>
    <div>
        <br /><asp:Label ID="Label2" runat="server"  Font-Bold="true" Font-Names="Arial" Font-Size="11pt" Text="CLASS 5A BOYS WEST" ForeColor="Maroon"></asp:Label><br />
        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" DataKeyNames="wID,ID" DataSourceID="SQLDataSourceEW5ABW" 
            ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Rank" HeaderText="Rank" SortExpression="Rank" ItemStyle-HorizontalAlign="Right" />
                <asp:BoundField DataField="School" HeaderText="School" SortExpression="School" ItemStyle-Width="175px">
                </asp:BoundField>
                <asp:BoundField DataField="Points" HeaderText="Points" 
                    SortExpression="Points" ItemStyle-HorizontalAlign="Right" />
                <asp:BoundField DataField="NumOne" HeaderText="# One" 
                    SortExpression="NumOne" ItemStyle-HorizontalAlign="Right" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" Font-Size="9pt" Font-Names="Arial"/>
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" Font-Size="8pt" Font-Names="Arial" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
    </div>
    <div>
        <br /><asp:Label ID="Label3" runat="server"  Font-Bold="true" Font-Names="Arial" Font-Size="11pt" Text="CLASS 5A BOYS EAST" ForeColor="Maroon"></asp:Label><br />
        <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" DataKeyNames="wID,ID" DataSourceID="SQLDataSourceEW5ABE" 
            ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Rank" HeaderText="Rank" SortExpression="Rank" ItemStyle-HorizontalAlign="Right" />
                <asp:BoundField DataField="School" HeaderText="School" SortExpression="School" ItemStyle-Width="175px">
                </asp:BoundField>
                <asp:BoundField DataField="Points" HeaderText="Points" 
                    SortExpression="Points" ItemStyle-HorizontalAlign="Right" />
                <asp:BoundField DataField="NumOne" HeaderText="# One" 
                    SortExpression="NumOne" ItemStyle-HorizontalAlign="Right" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" Font-Size="9pt" Font-Names="Arial"/>
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" Font-Size="8pt" Font-Names="Arial" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
    </div>
    <div>
        <br /><asp:Label ID="Label4" runat="server"  Font-Bold="true" Font-Names="Arial" Font-Size="11pt" Text="CLASS 6A GIRLS WEST" ForeColor="Maroon"></asp:Label><br />
        <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" DataKeyNames="wID,ID" DataSourceID="SQLDataSourceEW6AGW" 
            ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Rank" HeaderText="Rank" SortExpression="Rank" ItemStyle-HorizontalAlign="Right" />
                <asp:BoundField DataField="School" HeaderText="School" SortExpression="School" ItemStyle-Width="175px">
                </asp:BoundField>
                <asp:BoundField DataField="Points" HeaderText="Points" 
                    SortExpression="Points" ItemStyle-HorizontalAlign="Right" />
                <asp:BoundField DataField="NumOne" HeaderText="# One" 
                    SortExpression="NumOne" ItemStyle-HorizontalAlign="Right" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" Font-Size="9pt" Font-Names="Arial"/>
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" Font-Size="8pt" Font-Names="Arial" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
    </div>
    <div>
        <br /><asp:Label ID="Label5" runat="server"  Font-Bold="true" Font-Names="Arial" Font-Size="11pt" Text="CLASS 6A GIRLS EAST" ForeColor="Maroon"></asp:Label><br />
        <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" DataKeyNames="wID,ID" DataSourceID="SQLDataSourceEW6AGE" 
            ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Rank" HeaderText="Rank" SortExpression="Rank" ItemStyle-HorizontalAlign="Right" />
                <asp:BoundField DataField="School" HeaderText="School" SortExpression="School" ItemStyle-Width="175px">
                </asp:BoundField>
                <asp:BoundField DataField="Points" HeaderText="Points" 
                    SortExpression="Points" ItemStyle-HorizontalAlign="Right" />
                <asp:BoundField DataField="NumOne" HeaderText="# One" 
                    SortExpression="NumOne" ItemStyle-HorizontalAlign="Right" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" Font-Size="9pt" Font-Names="Arial"/>
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" Font-Size="8pt" Font-Names="Arial" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
    </div>
    <div>
        <br /><asp:Label ID="Label6" runat="server"  Font-Bold="true" Font-Names="Arial" Font-Size="11pt" Text="CLASS 5A GIRLS WEST" ForeColor="Maroon"></asp:Label><br />
        <asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" DataKeyNames="wID,ID" DataSourceID="SQLDataSourceEW5AGW" 
            ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Rank" HeaderText="Rank" SortExpression="Rank" ItemStyle-HorizontalAlign="Right" />
                <asp:BoundField DataField="School" HeaderText="School" SortExpression="School" ItemStyle-Width="175px">
                </asp:BoundField>
                <asp:BoundField DataField="Points" HeaderText="Points" 
                    SortExpression="Points" ItemStyle-HorizontalAlign="Right" />
                <asp:BoundField DataField="NumOne" HeaderText="# One" 
                    SortExpression="NumOne" ItemStyle-HorizontalAlign="Right" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" Font-Size="9pt" Font-Names="Arial"/>
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" Font-Size="8pt" Font-Names="Arial" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
    </div>
    <div>
        <br /><asp:Label ID="Label7" runat="server"  Font-Bold="true" Font-Names="Arial" Font-Size="11pt" Text="CLASS 5A GIRLS EAST" ForeColor="Maroon"></asp:Label><br />
        <asp:GridView ID="GridView8" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" DataKeyNames="wID,ID" DataSourceID="SQLDataSourceEW5AGE" 
            ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Rank" HeaderText="Rank" SortExpression="Rank" ItemStyle-HorizontalAlign="Right" />
                <asp:BoundField DataField="School" HeaderText="School" SortExpression="School" ItemStyle-Width="175px">
                </asp:BoundField>
                <asp:BoundField DataField="Points" HeaderText="Points" 
                    SortExpression="Points" ItemStyle-HorizontalAlign="Right" />
                <asp:BoundField DataField="NumOne" HeaderText="# One" 
                    SortExpression="NumOne" ItemStyle-HorizontalAlign="Right" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" Font-Size="9pt" Font-Names="Arial"/>
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" Font-Size="8pt" Font-Names="Arial" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
<asp:SQLDataSource ID="SQLDataSourceEW6ABE" runat="server" 
    ConnectionString="<%$ ConnectionStrings:OSSAARANKINGSConnectionString %>"   
    SelectCommand="SELECT DISTINCT * FROM [viewEWRankings] WHERE (([EW] = @EW) AND ([sportID] = @sportID) AND ([intYear] = @intYear) AND ([WeekNo] = @WeekNo)) ORDER BY [Rank]">
    <SelectParameters>
        <asp:Parameter DefaultValue="2" Name="EW" Type="Int16" />
        <asp:Parameter DefaultValue="BasketballBoys6A" Name="sportID" Type="String" />
        <asp:SessionParameter DefaultValue="16" Name="intYear" SessionField="EWy" 
            Type="Int16" />
        <asp:SessionParameter DefaultValue="" Name="WeekNo" SessionField="EWw" 
            Type="String" />
    </SelectParameters>
</asp:SQLDataSource>
<asp:SQLDataSource ID="SQLDataSourceEW6ABW" runat="server" 
    ConnectionString="<%$ ConnectionStrings:OSSAARANKINGSConnectionString %>"   
    SelectCommand="SELECT DISTINCT * FROM [viewEWRankings] WHERE (([EW] = @EW) AND ([sportID] = @sportID) AND ([intYear] = @intYear) AND ([WeekNo] = @WeekNo)) ORDER BY [Rank]">
    <SelectParameters>
        <asp:Parameter DefaultValue="3" Name="EW" Type="Int16" />
        <asp:Parameter DefaultValue="BasketballBoys6A" Name="sportID" Type="String" />
        <asp:SessionParameter DefaultValue="16" Name="intYear" SessionField="EWy" 
            Type="Int16" />
        <asp:SessionParameter DefaultValue="" Name="WeekNo" SessionField="EWw" 
            Type="String" />
    </SelectParameters>
</asp:SQLDataSource>
<asp:SQLDataSource ID="SQLDataSourceEW5ABE" runat="server" 
    ConnectionString="<%$ ConnectionStrings:OSSAARANKINGSConnectionString %>"   
    SelectCommand="SELECT DISTINCT * FROM [viewEWRankings] WHERE (([EW] = @EW) AND ([sportID] = @sportID) AND ([intYear] = @intYear) AND ([WeekNo] = @WeekNo)) ORDER BY [Rank]">
    <SelectParameters>
        <asp:Parameter DefaultValue="2" Name="EW" Type="Int16" />
        <asp:Parameter DefaultValue="BasketballBoys5A" Name="sportID" Type="String" />
        <asp:SessionParameter DefaultValue="16" Name="intYear" SessionField="EWy" 
            Type="Int16" />
        <asp:SessionParameter DefaultValue="" Name="WeekNo" SessionField="EWw" 
            Type="String" />
    </SelectParameters>
</asp:SQLDataSource>
<asp:SQLDataSource ID="SQLDataSourceEW5ABW" runat="server" 
    ConnectionString="<%$ ConnectionStrings:OSSAARANKINGSConnectionString %>"   
    SelectCommand="SELECT DISTINCT * FROM [viewEWRankings] WHERE (([EW] = @EW) AND ([sportID] = @sportID) AND ([intYear] = @intYear) AND ([WeekNo] = @WeekNo)) ORDER BY [Rank]">
    <SelectParameters>
        <asp:Parameter DefaultValue="3" Name="EW" Type="Int16" />
        <asp:Parameter DefaultValue="BasketballBoys5A" Name="sportID" Type="String" />
        <asp:SessionParameter DefaultValue="16" Name="intYear" SessionField="EWy" 
            Type="Int16" />
        <asp:SessionParameter DefaultValue="" Name="WeekNo" SessionField="EWw" 
            Type="String" />
    </SelectParameters>
</asp:SQLDataSource>
<asp:SQLDataSource ID="SQLDataSourceEW6AGE" runat="server" 
    ConnectionString="<%$ ConnectionStrings:OSSAARANKINGSConnectionString %>"   
    SelectCommand="SELECT DISTINCT * FROM [viewEWRankings] WHERE (([EW] = @EW) AND ([sportID] = @sportID) AND ([intYear] = @intYear) AND ([WeekNo] = @WeekNo)) ORDER BY [Rank]">
    <SelectParameters>
        <asp:Parameter DefaultValue="2" Name="EW" Type="Int16" />
        <asp:Parameter DefaultValue="BasketballGirls6A" Name="sportID" Type="String" />
        <asp:SessionParameter DefaultValue="16" Name="intYear" SessionField="EWy" 
            Type="Int16" />
        <asp:SessionParameter DefaultValue="" Name="WeekNo" SessionField="EWw" 
            Type="String" />
    </SelectParameters>
</asp:SQLDataSource>
<asp:SQLDataSource ID="SQLDataSourceEW6AGW" runat="server" 
    ConnectionString="<%$ ConnectionStrings:OSSAARANKINGSConnectionString %>"   
    SelectCommand="SELECT DISTINCT * FROM [viewEWRankings] WHERE (([EW] = @EW) AND ([sportID] = @sportID) AND ([intYear] = @intYear) AND ([WeekNo] = @WeekNo)) ORDER BY [Rank]">
    <SelectParameters>
        <asp:Parameter DefaultValue="3" Name="EW" Type="Int16" />
        <asp:Parameter DefaultValue="BasketballGirls6A" Name="sportID" Type="String" />
        <asp:SessionParameter DefaultValue="16" Name="intYear" SessionField="EWy" 
            Type="Int16" />
        <asp:SessionParameter DefaultValue="" Name="WeekNo" SessionField="EWw" 
            Type="String" />
    </SelectParameters>
</asp:SQLDataSource>
<asp:SQLDataSource ID="SQLDataSourceEW5AGE" runat="server" 
    ConnectionString="<%$ ConnectionStrings:OSSAARANKINGSConnectionString %>"   
    SelectCommand="SELECT DISTINCT * FROM [viewEWRankings] WHERE (([EW] = @EW) AND ([sportID] = @sportID) AND ([intYear] = @intYear) AND ([WeekNo] = @WeekNo)) ORDER BY [Rank]">
    <SelectParameters>
        <asp:Parameter DefaultValue="2" Name="EW" Type="Int16" />
        <asp:Parameter DefaultValue="BasketballGirls5A" Name="sportID" Type="String" />
        <asp:SessionParameter DefaultValue="16" Name="intYear" SessionField="EWy" 
            Type="Int16" />
        <asp:SessionParameter DefaultValue="" Name="WeekNo" SessionField="EWw" 
            Type="String" />
    </SelectParameters>
</asp:SQLDataSource>
<asp:SQLDataSource ID="SQLDataSourceEW5AGW" runat="server" 
    ConnectionString="<%$ ConnectionStrings:OSSAARANKINGSConnectionString %>"   
    SelectCommand="SELECT DISTINCT * FROM [viewEWRankings] WHERE (([EW] = @EW) AND ([sportID] = @sportID) AND ([intYear] = @intYear) AND ([WeekNo] = @WeekNo)) ORDER BY [Rank]">
    <SelectParameters>
        <asp:Parameter DefaultValue="3" Name="EW" Type="Int16" />
        <asp:Parameter DefaultValue="BasketballGirls5A" Name="sportID" Type="String" />
        <asp:SessionParameter DefaultValue="16" Name="intYear" SessionField="EWy" 
            Type="Int16" />
        <asp:SessionParameter DefaultValue="" Name="WeekNo" SessionField="EWw" 
            Type="String" />
    </SelectParameters>
</asp:SQLDataSource>

