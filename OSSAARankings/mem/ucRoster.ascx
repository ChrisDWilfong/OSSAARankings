<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucRoster.ascx.vb" Inherits="OSSAARankings.ucRoster" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register src="ucRosterList.ascx" tagname="ucRosterList" tagprefix="uc1" %>
<%@ Register src="ucRosterAdd.ascx" tagname="ucRosterAdd" tagprefix="uc2" %>
<httpRuntime maxRequestLength="8192" /> 
<link rel="stylesheet" type="text/css" href="mem.css">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <Triggers>
        <asp:PostBackTrigger ControlID="cmdUpload" />
        <asp:PostBackTrigger ControlID="cmdRemove" />
    </Triggers>
    <ContentTemplate>
        <ajax:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" TargetControlID="PanelRosterAdd" Radius="5" BorderColor="gray"></ajax:RoundedCornersExtender>
        <ajax:RoundedCornersExtender ID="RoundedCornersExtender3" runat="server" TargetControlID="PanelRosterList" Radius="5" BorderColor="gray"></ajax:RoundedCornersExtender>
        <asp:Panel ID="PanelRosterAdd" runat="server" Visible="false" CssClass="panelSmall">
            <uc2:ucRosterAdd ID="ucRosterAdd1" runat="server"/>
        </asp:Panel>
        <asp:Label runat="server" ID="space1"><hr /></asp:Label>
        <asp:Panel ID="PanelRosterList" runat="server" CssClass="panelSmall">
            <asp:Image ID="imgTeamPicture" runat="server" Width="300px" BorderWidth="2" />
            <hr />
            <asp:Button ID="cmdAdd" runat="server" Text="Add New Player" CssClass="button" />
            <uc1:ucRosterList ID="ucRosterList1" runat="server" />
            <hr />
            <asp:Label ID="lblUpload" runat="server" Text="Upload Team Picture:" CssClass="labelDistrict"></asp:Label>
            <asp:FileUpload ID="FileUpload1" runat="server" EnableViewState="true" /><br />
            <asp:Button ID="cmdUpload" runat="server" Text="Upload Picture" CssClass="buttonSave" />&nbsp;
            <asp:Button ID="cmdRemove" runat="server" Text="Remove Picture" CssClass="buttonDelete" />
            <asp:Label ID="lblStatus" runat="server" Text="" CssClass="labelMessage"></asp:Label>
        </asp:Panel>
    </ContentTemplate>

</asp:UpdatePanel>

