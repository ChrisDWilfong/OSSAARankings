<%@ Control Language="vb" AutoEventWireup="false" Inherits="OSSAARankings.ucViewScheduleFBWeek2" Codebehind="ucViewScheduleFBWeek2.ascx.vb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<link href="Rankings.css" rel="stylesheet" type="text/css" />
<asp:Table runat="server" style="width:525px">
    <asp:TableRow ID="rowHeader">
        <asp:TableCell  HorizontalAlign="Center" height="36" ColumnSpan="3">
            <asp:Label ID="Label1" runat="server" Font-Bold="True" CssClass="labelBig" Text="Select Class : "></asp:Label>
            <asp:DropDownList ID="cboClass" runat="server" AutoPostBack="true" DataTextField="class" DataValueField="class" DataSourceID="SqlDataSource1" CssClass="dropdownBig" EnableViewState="true">
                <asp:ListItem Value="ALL">ALL</asp:ListItem>
            </asp:DropDownList>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="center" ColumnSpan="3">
            <asp:Label ID="lblSport" runat="server" Text="Sport" Font-Names="Segoe UI, Verdana, Helvetica, sans-serif" Font-Size="18pt" ForeColor="Maroon" Font-Bold="true"></asp:Label>
        </asp:TableCell>
   </asp:TableRow>
   <asp:TableRow>
   <asp:TableCell ColumnSpan="3">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="500px" 
                Font-Names="Segoe UI, Verdana, Helvetica, sans-serif" Font-Size="9pt" Visible="true" HorizontalAlign="Left" EmptyDataText="No Scheduled Games">
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <Columns>
                <asp:HyperLinkField DataTextField="Game" Text="Game" HeaderText="Game" ItemStyle-HorizontalAlign="Left" />
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
    SelectCommand="SELECT DISTINCT [Class], [Sort] FROM [tblSports] WHERE ([SportGenderKey] = 'Football') AND ([Class] <> '-') AND ([Class] <> 'I') ORDER BY [Sort]">
</asp:SqlDataSource>



