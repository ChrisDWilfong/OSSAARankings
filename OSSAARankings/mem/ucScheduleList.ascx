<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucScheduleList.ascx.vb" Inherits="OSSAARankings.ucScheduleList" %>
<link href="mem.css" rel="stylesheet" type="text/css" />
<div>
<asp:GridView ID="GridView1" runat="server" CellPadding="4" Width="100%" 
    Font-Names="Segoe UI, Verdana, Helvetica, sans-serif" Font-Size="9pt" AutoGenerateColumns="False" 
    ShowFooter="True" BackColor="White" BorderColor="#CC9966" 
    BorderStyle="None" BorderWidth="1px">
    <FooterStyle BackColor="#FFFFCC" Height="24px" ForeColor="#330099" />
    <RowStyle BackColor="White" Height="22px" ForeColor="#330099" />
    <Columns>
        <asp:BoundField DataField="Date" HeaderText="Date">
            <ItemStyle Width="30%" />
            <HeaderStyle HorizontalAlign="Left" />
        </asp:BoundField>
        <asp:BoundField DataField="Opposing Team" HeaderText="Opposing Team" Visible="False" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" >
        </asp:BoundField>
        <asp:BoundField DataField="scheduleID" HeaderText="GameID" Visible="False" ItemStyle-HorizontalAlign="Left" >
            <ItemStyle HorizontalAlign="Left"></ItemStyle>
        </asp:BoundField>
        <asp:HyperLinkField DataNavigateUrlFields="oTeamID" DataNavigateUrlFormatString="?sel=ScheduleTeam&t={0}" DataTextField="Opposing Team" HeaderText="Opposing Team"  ItemStyle-HorizontalAlign="Left" >
            <ItemStyle HorizontalAlign="Left"></ItemStyle>
            <HeaderStyle HorizontalAlign="Left" />
        </asp:HyperLinkField>
        <asp:HyperLinkField DataNavigateUrlFields="Results" DataNavigateUrlFormatString="?sel=ScheduleEdit&g={0}" DataTextField="Results" HeaderText="Results"  ItemStyle-HorizontalAlign="Left" >
            <ItemStyle HorizontalAlign="Left"></ItemStyle>
            <HeaderStyle HorizontalAlign="Left" />
        </asp:HyperLinkField>
        <asp:BoundField DataField="strResults" HeaderText="Match Details" Visible="False" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" ItemStyle-Font-Size="8pt" >
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
<asp:Label ID="lblPlayoffs" runat="server" Text="" Font-Names="Segoe UI, Verdana, Helvetica, sans-serif" Font-Size="10pt" ForeColor="Navy" Font-Bold="true"></asp:Label><br />
<asp:Label ID="lblFooter" runat="server" Text="<strong>TO CHANGE OR DELETE A GAME</strong>, click the appropriate game under Results." Font-Names="Segoe UI, Verdana, Helvetica, sans-serif" Font-Size="10pt" ForeColor="Maroon"></asp:Label>
</div>
