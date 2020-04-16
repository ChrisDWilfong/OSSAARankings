<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucPersonalInfo.ascx.vb" Inherits="OSSAARankings.ucPersonalInfo" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<link href="mem.css" rel="stylesheet" type="text/css" />
<ajax:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" TargetControlID="PanelPersonalInfo" Radius="5" BorderColor="gray"></ajax:RoundedCornersExtender>
<div><hr /></div>
<asp:Panel ID="PanelPersonalInfo" runat="server" CssClass="panelSmall">
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <ajax:RoundedCornersExtender ID="RoundedCornersExtender2" runat="server" TargetControlID="lblHeader" Radius="3" BorderColor="gray"></ajax:RoundedCornersExtender>
        <asp:Table runat="server" ID="tblPersonalInfo" Width="100%">
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="lblHeader" runat="server" CssClass="headerSmall" Height="24px" Text="Personal Info" Width="100%"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
            <asp:Button ID="cmdSave" runat="server" Text="SAVE CHANGES" CssClass="buttonSave" />&nbsp;&nbsp;
            <asp:Label ID="lblMessage" runat="server" CssClass="labelMessage"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:Label ID="lblFirstName" runat="server" CssClass="perInfoLabel" Width="140px">FIRST<span style="color:Red;"> *</span></asp:Label>
                <asp:Label ID="lblLastName" runat="server" CssClass="perInfoLabel">LAST<span style="color:Red;"> *</span></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:TextBox ID="txtFirstName" runat="server" CssClass="perInfoText" ViewStateMode="Enabled"></asp:TextBox>
                <asp:TextBox ID="txtLastName" runat="server" CssClass="perInfoText" ViewStateMode="Enabled"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:Label ID="lblEmailMain" runat="server" CssClass="perInfoLabel">EMAIL (MAIN) <i>This is also your username.</i><span style="color:Red;"> *</span></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:TextBox ID="txtEmailMain" runat="server" CssClass="perInfoText2"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:Label ID="lblEmailAlt" runat="server" CssClass="perInfoLabel">EMAIL (ALT)</asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:TextBox ID="txtEmailAlt" runat="server" CssClass="perInfoText2"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:Label ID="lblPhoneMain" runat="server" CssClass="perInfoLabel" Width="140px">PHONE (CELL)<span style="color:Red;"> *</span></asp:Label>
                <asp:Label ID="lblPhoneAlt" runat="server" CssClass="perInfoLabel">PHONE (HOME)</asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:TextBox ID="txtPhoneMain" runat="server" CssClass="perInfoText"></asp:TextBox>
                <asp:TextBox ID="txtPhoneAlt" runat="server" CssClass="perInfoText"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:Label ID="lblPassword" runat="server" CssClass="perInfoLabel">PASSWORD<span style="color:Red;"> *</span></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:TextBox ID="txtPassword" runat="server" CssClass="perInfoText" Enabled="false"></asp:TextBox><asp:Button ID="cmdChangePassword" runat="server" Text="Click Here to Change Password" CssClass="button" Width="200px" />
            </asp:TableCell>
        </asp:TableRow>
        </asp:Table>
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Panel>


