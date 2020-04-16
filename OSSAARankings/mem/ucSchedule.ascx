<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucSchedule.ascx.vb" Inherits="OSSAARankings.ucSchedule" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register src="ucScheduleList.ascx" tagname="ucScheduleList" tagprefix="uc1" %>
<%@ Register src="ucScheduleAdd.ascx" tagname="ucScheduleAdd" tagprefix="uc2" %>
<%@ Register src="ucScheduleListSmall.ascx" tagname="ucScheduleListSmall" tagprefix="uc3" %>
<link rel="stylesheet" type="text/css" href="mem.css">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <ajax:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" TargetControlID="PanelScheduleAdd" Radius="5" BorderColor="gray"></ajax:RoundedCornersExtender>
    <ajax:RoundedCornersExtender ID="RoundedCornersExtender2" runat="server" TargetControlID="PanelScheduleTeam" Radius="5" BorderColor="gray"></ajax:RoundedCornersExtender>
    <ajax:RoundedCornersExtender ID="RoundedCornersExtender3" runat="server" TargetControlID="PanelScheduleList" Radius="5" BorderColor="gray"></ajax:RoundedCornersExtender>
    <asp:Panel ID="PanelScheduleAdd" runat="server" Visible="false" CssClass="panelSmall">
        <uc2:ucScheduleAdd ID="ucScheduleAdd1" runat="server"/>      
    </asp:Panel>
    <asp:Panel ID="PanelScheduleTeam" runat="server" Visible="false" CssClass="panelSmall">
        <asp:Button ID="cmdClose" runat="server" Text="Close This Schedule" CssClass="button" />
        <uc3:ucScheduleListSmall ID="ucScheduleListSmall1" runat="server" />
    </asp:Panel>
    <asp:Label runat="server" ID="space1"><hr /></asp:Label>
    <asp:Panel ID="PanelScheduleList" runat="server" CssClass="panelSmall">
        <asp:Button ID="cmdAdd" runat="server" Text="Add New Game" CssClass="button" />&nbsp;&nbsp;<asp:Label ID="lblDistrict" runat="server" CssClass="labelDistrict" ForeColor="Navy" Text="** (District Game)"></asp:Label>
        <asp:Label ID="lblMessageSpecial" runat="server" Text="" CssClass="labelMessage" Font-Bold="true"></asp:Label>
        <uc1:ucScheduleList ID="ucScheduleList1" runat="server" />
    </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>

