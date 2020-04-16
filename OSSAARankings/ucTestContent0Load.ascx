<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucTestContent0Load.ascx.vb" Inherits="OSSAARankings.ucTestContent0Load" %>
<asp:UpdatePanel ID="UpdatePanelContentLoad" runat="server">
    <ContentTemplate>
        <asp:Panel ID="Panel0" runat="server">
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
            <asp:Button ID="cmdRefresh" runat="server" Text="Refresh Me Again (ucTestContent0.ascx)" /><br />
            <asp:Label id="Label2" runat="server" Text="Label2 (ucTestContent0.ascx)" style="font-family:Arial; font-size:30px; font-weight:bold;"></asp:Label>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>