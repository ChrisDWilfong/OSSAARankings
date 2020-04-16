<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucViewHomePage.ascx.vb" Inherits="OSSAARankings.ucViewHomePage" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Table ID="tblHP1" runat="server" width="100%" Height="100%" BackImageUrl="~/images/ossaalogoGray.png">
<asp:TableRow VerticalAlign="Top" >
    <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center">
        <asp:Label style="padding-left:20px; vertical-align:top; text-align:center;" Width="90%" ID="lblHeader" runat="server" Text="Welcome to the OSSAARankings.com Website" Font-Names="Segoe UI, Helvetica, Helvetica Neue, Lucida Grande, Arial, Verdana, sans-serif" Font-Size="16px" Font-Bold="true" Visible="true"></asp:Label>
        <telerik:RadRotator ID="RadRotator1" runat="server" RenderMode="Lightweight" Width="250" Height="250" ScrollDuration="2000" 
                ScrollDirection="Left" FrameDuration="2000" ItemHeight="251" ItemWidth="251" BorderStyle="None" BorderWidth="0" EnableRandomOrder="true" >
                <Items>
                    <telerik:RadRotatorItem>
                        <ItemTemplate>
                            <asp:HyperLink ID="hlAd01" runat="server" ImageUrl="None" Target="_blank" NavigateUrl="http://www.ossaarankings.com" BorderStyle="None"></asp:HyperLink>
                        </ItemTemplate>
                    </telerik:RadRotatorItem>
                    <telerik:RadRotatorItem>
                        <ItemTemplate>
                            <asp:HyperLink ID="hlAd02" runat="server" ImageUrl="None" Target="_blank" NavigateUrl="http://www.ossaarankings.com" BorderStyle="None"></asp:HyperLink>
                        </ItemTemplate>
                    </telerik:RadRotatorItem>
                    <telerik:RadRotatorItem>
                        <ItemTemplate>
                            <asp:HyperLink ID="hlAd03" runat="server" ImageUrl="None" Target="_blank" NavigateUrl="http://www.ossaarankings.com" BorderStyle="None"></asp:HyperLink>
                        </ItemTemplate>
                    </telerik:RadRotatorItem>
                    <telerik:RadRotatorItem>
                        <ItemTemplate>
                            <asp:HyperLink ID="hlAd04" runat="server" ImageUrl="None" Target="_blank" NavigateUrl="http://www.ossaarankings.com" BorderStyle="None"></asp:HyperLink>
                        </ItemTemplate>
                    </telerik:RadRotatorItem>
                </Items>
            </telerik:RadRotator>
    </asp:TableCell>
</asp:TableRow>
</asp:Table>
