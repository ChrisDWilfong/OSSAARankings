<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucViewHomePageTest.ascx.vb" Inherits="OSSAARankings.ucViewHomePageTest" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Table ID="tblHP1" runat="server" width="100%" Height="100%" BackImageUrl="~/images/ossaalogoGray.png">
<asp:TableRow VerticalAlign="Top" >
    <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center">
        <asp:Label style="padding-left:20px; vertical-align:top; text-align:center;" Width="90%" ID="lblHeader" runat="server" Text="Welcome to the OSSAARankings.com Website" Font-Names="Segoe UI, Helvetica, Helvetica Neue, Lucida Grande, Arial, Verdana, sans-serif" Font-Size="16px" Font-Bold="true" Visible="true"></asp:Label>
        <telerik:RadRotator ID="RadRotator1" runat="server" RenderMode="Lightweight" Width="295" Height="120" ScrollDuration="2000" 
                ScrollDirection="Left" FrameDuration="2000" ItemHeight="120" ItemWidth="300" BorderStyle="None">
                <Items>
                    <telerik:RadRotatorItem>
                        <ItemTemplate>
                            <asp:HyperLink runat="server" ImageUrl="~/images/sponsors/Skordle300.png" Target="_blank" NavigateUrl="http://www.skordle.com/" BorderStyle="None"></asp:HyperLink>
                        </ItemTemplate>
                    </telerik:RadRotatorItem>
                    <telerik:RadRotatorItem>
                        <ItemTemplate>
                            <asp:HyperLink runat="server" ImageUrl="~/images/sponsors/OCOM300.png" Target="_blank" NavigateUrl="http://ocomhospital.com/ocom-imaging" BorderStyle="None"></asp:HyperLink>
                        </ItemTemplate>
                    </telerik:RadRotatorItem>
                    <telerik:RadRotatorItem>
                        <ItemTemplate>
                            <asp:HyperLink runat="server" ImageUrl="~/images/sponsors/Athelitecareokc300.png" Target="_blank" NavigateUrl="http://www.athelitecareokc.com" BorderStyle="None"></asp:HyperLink>
                        </ItemTemplate>
                    </telerik:RadRotatorItem>
                </Items>
            </telerik:RadRotator>
    </asp:TableCell>
</asp:TableRow>
</asp:Table>
