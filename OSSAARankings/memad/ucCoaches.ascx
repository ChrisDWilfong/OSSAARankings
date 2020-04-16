<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucCoaches.ascx.vb" Inherits="OSSAARankings.ucCoaches" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register src="ucCoachList.ascx" tagname="ucCoachList" tagprefix="uc1" %>
<%@ Register src="ucPersonalInfoCoaches.ascx" tagname="ucCoachAdd" tagprefix="uc2" %>
<link rel="stylesheet" type="text/css" href="../mem/mem.css">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <ajax:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" TargetControlID="PanelCoachAdd" Radius="5" BorderColor="gray"></ajax:RoundedCornersExtender>
    <ajax:RoundedCornersExtender ID="RoundedCornersExtender3" runat="server" TargetControlID="PanelCoachList" Radius="5" BorderColor="gray"></ajax:RoundedCornersExtender>
    <asp:Panel ID="PanelCoachAdd" runat="server" Visible="false" CssClass="panelSmall">
        <uc2:ucCoachAdd ID="ucCoachAdd1" runat="server"/>      
    </asp:Panel>
    <asp:Label runat="server" ID="space1"><hr /></asp:Label>
    <asp:Panel ID="PanelCoachList" runat="server" CssClass="panelSmall">
        <asp:Button ID="cmdAdd" runat="server" Text="Add New Coach" CssClass="button" />
        <uc1:ucCoachList ID="ucCoachList1" runat="server" />
    </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>

