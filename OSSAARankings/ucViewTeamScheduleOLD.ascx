<%@ Control Language="VB" AutoEventWireup="false" Inherits="OSSAARankings.ucViewTeamScheduleOLD" Codebehind="ucViewTeamScheduleOLD.ascx.vb" %>
<asp:GridView ID="GridView1" runat="server" CellPadding="4" Height="209px" Width="550px" 
    Font-Names="Verdana" Font-Size="8pt" AutoGenerateColumns="False" 
    ShowFooter="True" BackColor="White" BorderColor="#CC9966" 
    BorderStyle="None" BorderWidth="1px">
    <FooterStyle BackColor="#FFFFCC" Height="24px" 
        ForeColor="#330099" />
    <RowStyle BackColor="White" Height="22px" ForeColor="#330099" />
    <Columns>
        <asp:BoundField DataField="Date" HeaderText="Date">
            <ItemStyle Width="60px" />
        </asp:BoundField>
        <asp:BoundField DataField="Time" HeaderText="Time">
            <ItemStyle Width="60px" HorizontalAlign="right" />
        </asp:BoundField>
        <asp:BoundField DataField="Opposing Team" HeaderText="Opposing Team" 
            Visible="False" ItemStyle-HorizontalAlign="Left" >
<ItemStyle HorizontalAlign="Left"></ItemStyle>
        </asp:BoundField>
        <asp:HyperLinkField DataNavigateUrlFields="opposingTeamID" 
            DataNavigateUrlFormatString="?sel=teamschedule&t={0}" DataTextField="Opposing Team" 
            HeaderText="Opposing Team"  ItemStyle-HorizontalAlign="Left" >
<ItemStyle HorizontalAlign="Left"></ItemStyle>
        </asp:HyperLinkField>
        <asp:BoundField DataField="Location" HeaderText="Location">
            <ItemStyle Width="60px" HorizontalAlign="Left" />
        </asp:BoundField>
        <asp:BoundField DataField="Results" HeaderText="Results" ItemStyle-HorizontalAlign="Right">
            <ItemStyle Width="60px" />
        </asp:BoundField>
    </Columns>
    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" 
        Height="24px" HorizontalAlign="Left" />
    <SortedAscendingCellStyle BackColor="#FEFCEB" />
    <SortedAscendingHeaderStyle BackColor="#AF0101" />
    <SortedDescendingCellStyle BackColor="#F6F0C0" />
    <SortedDescendingHeaderStyle BackColor="#7E0000" />
</asp:GridView>
