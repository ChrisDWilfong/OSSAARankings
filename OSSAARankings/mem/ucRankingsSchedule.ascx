<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucRankingsSchedule.ascx.vb" Inherits="OSSAARankings.ucRankingsSchedule" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<link href="mem.css" rel="stylesheet" type="text/css" />
<ajax:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" TargetControlID="PanelRankingsSchedule" Radius="5" BorderColor="gray"></ajax:RoundedCornersExtender>
<ajax:RoundedCornersExtender ID="RoundedCornersExtender2" runat="server" TargetControlID="lblHeader" Radius="3" BorderColor="Maroon"></ajax:RoundedCornersExtender>
<ajax:RoundedCornersExtender ID="RoundedCornersExtender3" runat="server" TargetControlID="lblNote" Radius="3" BorderColor="Maroon"></ajax:RoundedCornersExtender>
<asp:Panel ID="PanelRankingsSchedule" runat="server" CssClass="panelSmall">
    <asp:Label ID="lblHeader" runat="server" CssClass="headerSmall" Height="24px" Text="Rankings Schedule" Width="100%"></asp:Label>
    <asp:Label ID="lblNote" runat="server" CssClass="headerNote" Height="18px" Text="" Width="100%"></asp:Label>
    <asp:GridView ID="GridView1" runat="server" BackColor="White" 
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
        ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" Width="575px">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:BoundField DataField="startDate" HeaderText="Start">
                <HeaderStyle Font-Names="Verdana" Font-Size="9pt" />
                <ItemStyle Font-Names="Verdana" Font-Size="8pt" />
            </asp:BoundField>
            <asp:BoundField DataField="EndDate" HeaderText="Close">
                <HeaderStyle Font-Names="Verdana" Font-Size="9pt" />
                <ItemStyle Font-Names="Verdana" Font-Size="8pt" />
            </asp:BoundField>
            <asp:BoundField DataField="WeekNo" HeaderText="Week">
                <HeaderStyle Font-Names="Verdana" Font-Size="9pt" />
                <ItemStyle Font-Names="Verdana" Font-Size="8pt" />
            </asp:BoundField>
            <asp:BoundField DataField="Notes" HeaderText="Notes">
                <HeaderStyle Font-Names="Verdana" Font-Size="9pt" />
                <ItemStyle Font-Names="Verdana" Font-Size="8pt" />
            </asp:BoundField>
            <asp:BoundField DataField="intWeekNo" Visible="False" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
    <br />
</asp:Panel>
