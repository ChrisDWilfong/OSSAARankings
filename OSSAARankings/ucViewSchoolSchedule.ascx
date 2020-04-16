<%@ Control Language="VB" AutoEventWireup="false" Inherits="OSSAARankings.ucViewSchoolSchedule" Codebehind="ucViewSchoolSchedule.ascx.vb" %>
<div><asp:HyperLink ID="hlPrint" runat="server" Font-Names="Verdana" Font-Size="8pt" NavigateUrl="/PrintSchedule.aspx?sel=abc&t=0" Target="_blank">Print Version</asp:HyperLink></div>
<br />
<asp:GridView ID="GridView1" runat="server" CellPadding="4" Height="209px" Width="550px" 
    Font-Names="Segoe UI, Verdana, Helvetica, sans-serif" Font-Size="9pt" AutoGenerateColumns="False" 
    ShowFooter="True" BackColor="White" BorderColor="#CC9966" 
    BorderStyle="None" BorderWidth="1px">
    <FooterStyle BackColor="#FFFFCC" Height="24px" ForeColor="#330099" />
    <RowStyle BackColor="White" Height="22px" ForeColor="#330099" />
    <Columns>
        <asp:BoundField DataField="Date" HeaderText="Date" HeaderStyle-HorizontalAlign="Center">
            <ItemStyle Width="125px" />
        </asp:BoundField>
        <asp:BoundField DataField="Opposing Team" HeaderText="Opposing Team" Visible="False" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" >
            </asp:BoundField>
            <asp:HyperLinkField DataNavigateUrlFields="oTeamID" DataNavigateUrlFormatString="?sel=teamschedule&t={0}" DataTextField="Opposing Team" HeaderText="Opposing Team"  ItemStyle-HorizontalAlign="Left" >
            <ItemStyle HorizontalAlign="Left"></ItemStyle>
        </asp:HyperLinkField>
        <asp:BoundField DataField="Results" HeaderText="Results" ItemStyle-HorizontalAlign="Right">
            <ItemStyle Width="60px" />
        </asp:BoundField>
    </Columns>
    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" Height="24px" HorizontalAlign="Left" />
    <SortedAscendingCellStyle BackColor="#FEFCEB" />
    <SortedAscendingHeaderStyle BackColor="#AF0101" />
    <SortedDescendingCellStyle BackColor="#F6F0C0" />
    <SortedDescendingHeaderStyle BackColor="#7E0000" />
</asp:GridView>
