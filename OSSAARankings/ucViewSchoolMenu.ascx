<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucViewSchoolMenu.ascx.vb" Inherits="OSSAARankings.ucViewSchoolMenu" %>
<%@ Register Assembly="Infragistics4.Web.v10.2, Version=10.2.20102.1011, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.NavigationControls" TagPrefix="ig" %>
    <asp:Table ID="Table1" runat="server" >
        <asp:TableRow VerticalAlign="Top" HorizontalAlign="Center">
            <asp:TableCell>
                <ig:WebExplorerBar ID="WebExplorerBarSchedules" runat="server" Width="250px" StyleSetName="Office2007Silver"></ig:WebExplorerBar>
            </asp:TableCell>
            <asp:TableCell>
                <ig:WebExplorerBar ID="WebExplorerBarRosters" runat="server" Width="250px" StyleSetName="Office2007Silver"></ig:WebExplorerBar>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    
