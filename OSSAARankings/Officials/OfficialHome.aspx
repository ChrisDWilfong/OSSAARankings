<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Officials/Officials.Master" CodeBehind="OfficialHome.aspx.vb" Inherits="OSSAARankings.OfficialHome" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
    </telerik:RadStyleSheetManager>
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <br />
    <asp:Label CssClass="header" ID="lblOfficialInfo" runat="server" Text="" ForeColor="Maroon"></asp:Label><br />
    <hr />
    <asp:Label CssClass="header" ID="lblBasketball" runat="server" Text="BASKETBALL (2016-17 Season)" Font-Names="Segoe UI"></asp:Label>  
    <telerik:RadGrid ID="RadGridBK" runat="server" DataSourceID="SqlDataSourceBK" Width="60%">
        <GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>
        <MasterTableView DataSourceID="SqlDataSourceBK">
            <ItemStyle HorizontalAlign="Left" />
        </MasterTableView>
     </telerik:RadGrid>
    <hr /><br />
    <asp:Label CssClass="header" ID="lblFootball" runat="server" Text="FOOTBALL (2016-17 Season)" Font-Names="Segoe UI"></asp:Label> 
    <telerik:RadGrid ID="RadGridFB" runat="server" DataSourceID="SqlDataSourceFB" Width="60%">
        <GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>
        <MasterTableView DataSourceID="SqlDataSourceFB">
            <ItemStyle HorizontalAlign="Left" />
        </MasterTableView>
     </telerik:RadGrid>
    <hr /><br />
    <asp:Table runat="server">
        <asp:TableRow VerticalAlign="Top">
            <asp:TableCell Font-Names="Verdana" Font-Size="8px">
            Rating = Your rating<br />
            Class = Your classification&nbsp;&nbsp;&nbsp;<br />
            </asp:TableCell>
            <asp:TableCell Font-Names="Verdana" Font-Size="8px">
            Part1 = Test Part 1<br />
            Part2 = Test Part 2<br />
            State = State/Online meetings&nbsp;&nbsp;&nbsp;<br />
            Local = Local meetings<br />
            Years OS = Years of Service<br />
            </asp:TableCell>
            <asp:TableCell Font-Names="Verdana" Font-Size="8px">
            S1 = SUPERIOR Ratings<br />
            G2 = GOOD Ratings<br />
            F3 = FAIRL Ratings<br />
            U4 = UNSATISFACTORY Ratings<br />
            P5 = POOR Ratings<br />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:SqlDataSource ID="SqlDataSourceBK" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OSSAAConnectionString %>" 
        SelectCommand="SELECT * FROM qryProdOfficialsRatingsGridBK WHERE OSSAAID = @OSSAAID AND Year = @Year AND Sport = 'BK'">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="-99999" SessionField="OSSAAID" Name="OSSAAID" />
            <asp:SessionParameter DefaultValue="0" SessionField="Year" Name="Year" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceFB" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OSSAAConnectionString %>" 
        SelectCommand="SELECT * FROM qryProdOfficialsRatingsGridFB WHERE OSSAAID = @OSSAAID AND Year = @Year AND Sport = 'FB'">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="-99999" SessionField="OSSAAID" Name="OSSAAID" />
            <asp:SessionParameter DefaultValue="0" SessionField="Year" Name="Year" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
