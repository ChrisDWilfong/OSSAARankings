<%@ Control Language="vb" AutoEventWireup="true" Inherits="OSSAARankings.ucViewSchedule" Codebehind="ucViewSchedule.ascx.vb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<link href="Rankings.css" rel="stylesheet" type="text/css" />
<asp:Table runat="server" Width="525px" >
    <asp:TableRow ID="rowHeader">
            <asp:TableCell HorizontalAlign="Right" VerticalAlign="Top" width="58%" ColumnSpan="3">
            <asp:Table runat="server" ID="tblEllen">
                <asp:TableRow VerticalAlign="Top">
                    <asp:TableCell HorizontalAlign="left" height="36">
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" CssClass="labelBig" Text="Select Class : "></asp:Label><br />
                        <asp:DropDownList ID="cboClass" runat="server" AutoPostBack="true" DataTextField="class" DataValueField="class" DataSourceID="SqlDataSource1" CssClass="dropdownBig" EnableViewState="true">
                            <asp:ListItem Value="ALL">ALL</asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="lblToday" runat="server" CssClass="labelBig" Font-Bold="true" Text="Select Date : "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Button ID="cmdPrev" runat="server" Text="<< Prev" Font-Size="7pt" ForeColor="Navy" />&nbsp;
                    </asp:TableCell>
                    <asp:TableCell>
                        <telerik:RadDatePicker ID="RadDatePicker1" runat="server" MinDate="8/1/2019" MaxDate="5/30/2020" AutoPostBack="true" BackColor="White" Width="100px"></telerik:RadDatePicker>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Button ID="cmdNext" runat="server" Text="Next >>" Font-Size="7pt"  ForeColor="Navy" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="center" ColumnSpan="3">
            <asp:Label ID="lblSport" runat="server" Text="Sport" Font-Names="Segoe UI, Verdana, Helvetica, sans-serif" Font-Size="18pt" ForeColor="Maroon" Font-Bold="true"></asp:Label>
        </asp:TableCell>
   </asp:TableRow>
   <asp:TableRow>
    <asp:TableCell HorizontalAlign="center" ColumnSpan="3">
        <asp:HyperLink ID="hlPrint" runat="server" Font-Names="Verdana" Font-Size="8pt" NavigateUrl="PrintSchedule.aspx?sel=vs" Target="_blank">Print Version</asp:HyperLink>
    </asp:TableCell>
   </asp:TableRow>
   <asp:TableRow>
    <asp:TableCell ColumnSpan="3">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="500px" 
                Font-Names="Segoe UI, Verdana, Helvetica, sans-serif" Font-Size="9pt" Visible="true" HorizontalAlign="Left" EmptyDataText="No Scheduled Games" >
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <Columns>
                <asp:HyperLinkField DataTextField="Game" Text="Game" HeaderText="Scores by www.OSSAARankings.com" ItemStyle-HorizontalAlign="Left" />
            </Columns>
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
    </asp:TableCell>
</asp:TableRow>
</asp:Table>
<asp:Panel ID="PanelPopup" runat="server">
</asp:Panel>

<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:OSSAARANKINGSConnectionString %>" 
    SelectCommand="SELECT DISTINCT [Class], [Sort] FROM [tblSports] WHERE ([SportGenderKey] = @Sport) AND ([Class] <> 'I') AND ([Class] <> 'U') AND ([Class] <> 'AAU6') AND ([Class] <> '8G') AND ([Class] <> '-') UNION SELECT DISTINCT [ClassTop] AS [Class], [Sort] FROM [tblSports] WHERE ([SportGenderKey] = @Sport) AND ([Class] <> 'I') AND ([Class] <> 'U') AND ([Class] <> 'AAU6') AND ([Class] <> '8G') AND ([Class] <> '-') ORDER BY [Sort]">
    <SelectParameters>
        <asp:SessionParameter DefaultValue="" Name="Sport" SessionField="gSportGenderKey" Type="String" />
    </SelectParameters>
</asp:SqlDataSource>



