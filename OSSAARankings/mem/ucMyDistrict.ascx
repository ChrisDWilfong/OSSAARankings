<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucMyDistrict.ascx.vb" Inherits="OSSAARankings.ucMyDistrict" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<link href="mem.css" rel="stylesheet" type="text/css" />
<ajax:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" TargetControlID="PanelMyDistrict" Radius="5" BorderColor="gray"></ajax:RoundedCornersExtender>
<asp:Panel ID="PanelMyDistrict" runat="server" CssClass="panelSmall">
    <asp:PlaceHolder runat="server" ID="PlaceHolderDistricts"></asp:PlaceHolder>
</asp:Panel>
<div><img src="../images/sponsors/districtStandingsSponsor.gif" /></div>
