<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucTeamUpdate.ascx.vb" Inherits="OSSAARankings.ucTeamUpdate" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<link href="mem.css" rel="stylesheet" type="text/css" />
<ajax:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" TargetControlID="PanelTeamUpdate" Radius="5" BorderColor="gray"></ajax:RoundedCornersExtender>
<div><hr /></div>
<asp:Panel ID="PanelTeamUpdate" runat="server" CssClass="panelSmall">
<asp:UpdatePanel ID="UpdatePanelTeamUpdate" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <ajax:RoundedCornersExtender ID="RoundedCornersExtender2" runat="server" TargetControlID="lblHeader" Radius="3" BorderColor="gray"></ajax:RoundedCornersExtender>
        <asp:Table runat="server" ID="lblTeamUpdate" Width="100%">
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="lblHeader" runat="server" CssClass="headerSmall" Height="24px" Text="My Team Update" Width="100%"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
            <asp:Button ID="cmdSave" runat="server" Text="SAVE CHANGES" CssClass="buttonSave" />&nbsp;&nbsp;<asp:Button ID="cmdClear" runat="server" Text="Clear Update" CssClass="buttonSave" BackColor="Red" /><br />
            <asp:Label ID="lblMessage" runat="server" CssClass="labelMessage"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell >
                <asp:Label ID="lblMyTeamUpdate" runat="server" CssClass="perInfoLabel" >MY TEAM UPDATE : Will appear in the OTHER Team Updates (above) and on the Rankings Detail information for each team.  THIS IS OPTIONAL.<span style="color:Red;"> *</span></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell >
                <asp:TextBox ID="txtMyTeamUpdate" runat="server" CssClass="perInfoText" ViewStateMode="Enabled" TextMode="MultiLine" Rows="15" Width="97%"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        </asp:Table>
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Panel>


