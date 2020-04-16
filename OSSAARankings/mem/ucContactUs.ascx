<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucContactUs.ascx.vb" Inherits="OSSAARankings.ucContactUs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<link href="mem.css" rel="stylesheet" type="text/css" />
<ajax:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" TargetControlID="PanelContactUs" Radius="5" BorderColor="gray"></ajax:RoundedCornersExtender>
<ajax:RoundedCornersExtender ID="RoundedCornersExtender2" runat="server" TargetControlID="lblHeaderMain" Radius="3" BorderColor="gray"></ajax:RoundedCornersExtender>    
<div><hr /></div>
<asp:Panel ID="PanelContactUs" runat="server" CssClass="panelSmall">
    <asp:Label ID="lblHeaderMain" runat="server" CssClass="headerSmall" Text="Contact " Width="100%" Height="24px"></asp:Label><br />
    <asp:Label ID="lblContent" runat="server" Text="" Font-Bold="true" CssClass="contentLine"></asp:Label><br />
</asp:Panel>