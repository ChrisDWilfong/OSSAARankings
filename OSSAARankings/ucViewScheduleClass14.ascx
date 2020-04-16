<%@ Control Language="vb" AutoEventWireup="false" Inherits="OSSAARankings.ucViewScheduleClass14" Codebehind="ucViewScheduleClass14.ascx.vb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register src="ucScheduleListSmallPublic.ascx" tagname="ucScheduleListSmall" tagprefix="uc3" %>
<link href="./mem/mem.css" rel="stylesheet" type="text/css" />
<link href="Rankings.css" rel="stylesheet" type="text/css" />
<asp:Table runat="server" style="width:650px">
    <asp:TableRow>
        <asp:TableCell horizontalalign="Center" ColumnSpan="4">
            <asp:Panel ID="PanelScheduleTeam" runat="server" Visible="false" CssClass="panelSmallPublic">
                <asp:Button ID="cmdClose" runat="server" Text="Close This Schedule" CssClass="button" />
                <uc3:ucScheduleListSmall ID="ucScheduleListSmall1" runat="server" />
            </asp:Panel>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow ID="rowHeader">
        <asp:TableCell horizontalalign="Center" height="36" ColumnSpan="4">
            <asp:Label ID="Label1" runat="server" Font-Bold="True" CssClass="labelBig" Text="Select Class : "></asp:Label>
            <asp:DropDownList ID="cboClass" runat="server" AutoPostBack="true" DataTextField="class" DataValueField="class" DataSourceID="SqlDataSource1" CssClass="dropdownBig" EnableViewState="true">
                <asp:ListItem Value="Select...">Select...</asp:ListItem>
            </asp:DropDownList>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell horizontalalign="Center" ColumnSpan="4">
            <asp:Label ID="lblSport" runat="server" Text="Sport" Font-Names="Segoe UI, Verdana, Helvetica, sans-serif" Font-Size="16pt" ForeColor="Maroon" Font-Bold="true"></asp:Label>
        </asp:TableCell>
   </asp:TableRow>
   <asp:TableRow>
    <asp:TableCell horizontalalign="Center" ColumnSpan="4">
        <asp:HyperLink ID="hlPrint" runat="server" Font-Names="Verdana" Font-Size="8pt" NavigateUrl="PrintClasses.aspx?sel=vc" Target="_blank">Print Version</asp:HyperLink>
    </asp:TableCell>
   </asp:TableRow>
   <asp:TableRow>
        <asp:TableCell VerticalAlign="Top" Width="25%">
            <asp:GridView ID="GridView0" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="95%"
                Font-Names="Segoe UI, Verdana, Helvetica, sans-serif" Font-Size="8pt" Visible="true" HorizontalAlign="Left" EmptyDataText="No Scheduled Games">
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <Columns>
                        <asp:HyperLinkField DataTextField="strTeam" Text="" HeaderText="" ItemStyle-HorizontalAlign="Left" />
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
        <asp:TableCell VerticalAlign="Top" Width="25%">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None"  Width="95%"
                Font-Names="Segoe UI, Verdana, Helvetica, sans-serif" Font-Size="8pt" Visible="true" HorizontalAlign="Left" EmptyDataText="No Scheduled Games">
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <Columns>
                        <asp:HyperLinkField DataTextField="strTeam" Text="" HeaderText="" ItemStyle-HorizontalAlign="Left" />
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
        <asp:TableCell VerticalAlign="Top" Width="25%">
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None"  Width="95%" 
                Font-Names="Segoe UI, Verdana, Helvetica, sans-serif" Font-Size="8pt" Visible="true" HorizontalAlign="Left" EmptyDataText="No Scheduled Games">
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <Columns>
                        <asp:HyperLinkField DataTextField="strTeam" Text="" HeaderText="" ItemStyle-HorizontalAlign="Left" />
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
        <asp:TableCell VerticalAlign="Top" Width="25%">
            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None"  Width="95%"
                Font-Names="Segoe UI, Verdana, Helvetica, sans-serif" Font-Size="8pt" Visible="true" HorizontalAlign="Left" EmptyDataText="No Scheduled Games">
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <Columns>
                        <asp:HyperLinkField DataTextField="strTeam" Text="" HeaderText="" ItemStyle-HorizontalAlign="Left" />
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

<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:OSSAARANKINGSConnectionString %>" 
    SelectCommand="SELECT DISTINCT [Class], [Sort], [sportID] FROM [tblSports] WHERE ([SportGenderKey] = @Sport) AND ([Class] <> 'I') AND ([Class] <> 'U') AND ([Class] <> 'AAU6') AND ([Class] <> '8G') AND ([Class] <> '-') ORDER BY [Sort]">
    <SelectParameters>
        <asp:SessionParameter DefaultValue="" Name="Sport" SessionField="gSportGenderKey" Type="String" />
    </SelectParameters>
</asp:SqlDataSource>



