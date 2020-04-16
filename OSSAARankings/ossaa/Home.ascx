<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Home.ascx.vb" Inherits="OSSAARankings.Home2" %>
    <asp:Table ID="Table1" runat="server" Width="100%">
        <asp:TableRow>
            <asp:TableCell ColumnSpan="3" HorizontalAlign="Center" VerticalAlign="Top">
                <iframe src="http://www.ossaarankings.com/images/WOWSlider/index.html" width="100%" height="410px" frameborder="0"></iframe>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="3">
                <a href="http://www.ossaarankings.com/membership/MemberLogin.aspx" target="_blank"><h2><span style="color:Blue;">CLICK HERE FOR OSSAA MEMBERSHIP LOGIN</span></h2></a>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow Width="98%">
            <asp:TableCell Width="33%" VerticalAlign="Top">
                <asp:PlaceHolder ID="PlaceHolder1a" runat="server"  >
                </asp:PlaceHolder>
            </asp:TableCell>
            <asp:TableCell Width="33%" VerticalAlign="Top">
                <asp:PlaceHolder ID="PlaceHolder2a" runat="server" >
                </asp:PlaceHolder>
            </asp:TableCell>
            <asp:TableCell Width="33%" VerticalAlign="Top">
                <asp:PlaceHolder ID="PlaceHolder3a" runat="server" >
                </asp:PlaceHolder>
            </asp:TableCell>
        </asp:TableRow>

    </asp:Table>