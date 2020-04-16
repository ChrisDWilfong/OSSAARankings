<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucScheduleListSmallPublic.ascx.vb" Inherits="OSSAARankings.ucScheduleListSmallPublic" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<link href="./mem/mem.css" rel="stylesheet" type="text/css" />
<ajax:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" TargetControlID="lblTeamInfo" Radius="5" BorderColor="gray"></ajax:RoundedCornersExtender>
<div>
<asp:Table Width="100%" runat="server" ID="tblScheduleSmall">
<asp:TableRow HorizontalAlign="Center"><asp:TableCell>
    <asp:HyperLink ID="hlPrint" runat="server" Font-Names="Verdana" Font-Size="8pt" NavigateUrl=".\mem\PrintScheduleSmall.aspx?sel=ts&t=0" Target="_blank">Print Version</asp:HyperLink>
</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell VerticalAlign="Middle">
    <asp:Label ID="lblTeamInfo" runat="server" CssClass="headerSmall" Height="46px" Text="Team (Class)" Width="100%"></asp:Label>
</asp:TableCell></asp:TableRow>
<asp:TableRow>
<asp:TableCell>
<asp:GridView ID="GridView1" runat="server" CellPadding="4" Height="209px" Width="100%" 
    Font-Names="Segoe UI,Verdana,Helvetica,sans-serif" Font-Size="9pt" AutoGenerateColumns="False" 
    ShowFooter="True" BackColor="White" BorderColor="#CCCCCC" 
    BorderStyle="None" BorderWidth="1px" ForeColor="Black" GridLines="Horizontal">
    <FooterStyle BackColor="#CCCC99" Height="24px" ForeColor="Black" />
    <RowStyle Height="22px" />
    <Columns>
        <asp:BoundField DataField="Date" HeaderText="Date">
            <ItemStyle Width="60px" />
            <HeaderStyle HorizontalAlign="Left" />
        </asp:BoundField>
        <asp:BoundField DataField="Opposing Team" HeaderText="Opposing Team" Visible="False" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" >
        </asp:BoundField>
        <asp:BoundField DataField="WL" HeaderText="">
            <ItemStyle HorizontalAlign="Center" Width="15px" />
        </asp:BoundField>
        <asp:HyperLinkField DataNavigateUrlFields="oTeamID" DataNavigateUrlFormatString="?sel=ScheduleTeam&t={0}" DataTextField="Opposing Team" HeaderText="Opposing Team"  ItemStyle-HorizontalAlign="Left" >
            <ItemStyle HorizontalAlign="Left"></ItemStyle>
            <HeaderStyle HorizontalAlign="Left" />
        </asp:HyperLinkField>
    </Columns>
    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" 
        Height="24px" HorizontalAlign="Left" />
    <SortedAscendingCellStyle BackColor="#F7F7F7" />
    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
    <SortedDescendingCellStyle BackColor="#E5E5E5" />
    <SortedDescendingHeaderStyle BackColor="#242121" />
</asp:GridView>
<asp:Label ID="lblPlayoffs" runat="server" Text="" Font-Names="Segoe UI, Verdana, Helvetica, sans-serif" Font-Size="10pt" ForeColor="Maroon" Font-Bold="true"></asp:Label>
</asp:TableCell>
</asp:TableRow>
</asp:Table>
</div>
