<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucCoachList.ascx.vb" Inherits="OSSAARankings.ucCoachList" %>
<link href="../mem/mem.css" rel="stylesheet" type="text/css" />
<div>
<asp:GridView ID="GridView1" runat="server" CellPadding="4" Width="100%" 
    Font-Names="Segoe UI, Verdana, Helvetica, sans-serif" Font-Size="9pt" AutoGenerateColumns="False" 
    ShowFooter="True" BackColor="White" BorderColor="#CC9966" 
    BorderStyle="None" BorderWidth="1px" EmptyDataText="No Coaches have been added.">
    <FooterStyle BackColor="#FFFFCC" Height="24px" ForeColor="#330099" />
    <RowStyle BackColor="White" Height="22px" ForeColor="#330099" />
    <Columns>
        <asp:HyperLinkField DataNavigateUrlFields="MemberID" DataNavigateUrlFormatString="?sel=CoachEdit&c={0}" DataTextField="FullName" HeaderText="Coach"  ItemStyle-HorizontalAlign="Left" >
            <ItemStyle HorizontalAlign="Left" Width="40%"></ItemStyle>
        </asp:HyperLinkField>
        <asp:BoundField DataField="EmailMain" HeaderText="Email Address" Visible="true" ItemStyle-HorizontalAlign="Left" >
            <ItemStyle HorizontalAlign="Left"></ItemStyle>
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
</div>
