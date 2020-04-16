<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucMenu.ascx.vb" Inherits="OSSAARankings.ucMenu" %>
<%@ Register Assembly="Infragistics4.Web.v10.2, Version=10.2.20102.1011, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.NavigationControls" TagPrefix="ig" %>

<asp:Table runat="server" ID="tblMenu">
        <asp:TableRow VerticalAlign="Top">
            <asp:TableCell>
                <ig:WebExplorerBar ID="WebExplorerBar1" runat="server" Width="250px" StyleSetName="RedPlanet">
                    <Groups>
                        <ig:ExplorerBarGroup GroupContentsHeight="" Text="OSSAA Board Minutes">
                            <asp:ListItem>Select...</asp:ListItem>
                        </ig:ExplorerBarGroup>
                    </Groups>
                </ig:WebExplorerBar>
            </asp:TableCell>
            <asp:TableCell>
                <ig:WebExplorerBar ID="WebExplorerBar2" runat="server" Width="250px" StyleSetName="RedPlanet">
                    <Groups>
                        <ig:ExplorerBarGroup GroupContentsHeight="" Text="Financial Reports">
                          <asp:ListItem Value="http://www.keepandshare.com/doc/6538881/2013baseball-pdf-150k?da=y">2013 Spring Baseball</asp:ListItem>
                          <asp:ListItem Value="http://www.keepandshare.com/doc/6538882/2013soccer-pdf-167k?da=y">2013 Soccer</asp:ListItem>                        </ig:ExplorerBarGroup>
                    </Groups>
                </ig:WebExplorerBar>
            </asp:TableCell>
        </asp:TableRow>
</asp:Table>

