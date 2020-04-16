<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucTestContent.ascx.vb" Inherits="OSSAARankings.ucTestContent" %>
<asp:UpdatePanel ID="UpdatePanelContent" runat="server">
    <ContentTemplate>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
        <asp:Button ID="cmdRefresh" runat="server" Text="Refresh Me Again (ucTestContent.ascx)" /><br />
        <asp:Label id="Label2" runat="server" Text="Label2 (ucTestContent.ascx)" style="font-family:Arial; font-size:30px; font-weight:bold;"></asp:Label>
    </ContentTemplate>
</asp:UpdatePanel>
