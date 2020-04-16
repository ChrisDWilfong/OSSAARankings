<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucMenuDDNew.ascx.vb" Inherits="OSSAARankings.ucMenuDDNew" %>
    <style type="text/css">
        .titleHeader
        {
            font-family: Century Gothic;
            font-size: 12px;
            color: Black;
            font-weight: bold;
        }
        .titleHeaderBlue
        {
            font-family: Century Gothic;
            font-size: 12px;
            color: Red;
            font-weight: bold;
            font-style: italic;
        }        
        .content
        {
            font-family: Century Gothic;
            font-size: 11px;
            color: Navy;
        }
        .contentSmall 
        {
            font-family: Century Gothic;
            font-size: 11px;
            color: black;
        }
    </style>

<asp:Table runat="server" ID="tblMenu" Width="600px">
        <asp:TableRow VerticalAlign="Top">
            <asp:TableCell Width="300px">
                <asp:Label ID="Label3" runat="server" Text="OSSAA Intermediate Appeals Panel Minutes :" CssClass="content" Font-Bold="true"></asp:Label><br />
                <%= Session("membersLinksBoardPanel")%>
                <br />
                <asp:Label ID="Label2" runat="server" Text="OSSAA Board Minutes :" CssClass="content" Font-Bold="true"></asp:Label><br />
                <%= Session("membersLinksBoard")%>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="Label1" runat="server" Text="&nbsp;Financial Reports :" CssClass="content" Font-Bold="true"></asp:Label><br />
                <%= Session("membersLinksFinancials")%>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow><asp:TableCell ColumnSpan="3"><hr /></asp:TableCell></asp:TableRow>
        <asp:TableRow VerticalAlign="Top">
            <asp:TableCell Width="450px" ColumnSpan="2">
                <asp:Table runat="server" ID="tblContacts">
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="2"><asp:Label ID="Label4" runat="server" Text="Emergency Numbers (after office hours)" CssClass="contentSmall" Font-Bold="true" Font-Underline="true"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:Label ID="Label6" runat="server" Text="e-mail Address" Font-Bold="true" Font-Underline="true" CssClass="contentSmall"></asp:Label></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow BackColor="LightGray">
                        <asp:TableCell><asp:Label ID="Label13" runat="server" Text="David Jackson" CssClass="contentSmall"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:Label ID="Label14" runat="server" Text="405.330.8195" CssClass="contentSmall"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:Label ID="Label15" runat="server" Text="djackson@ossaa.com" CssClass="contentSmall"></asp:Label></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell><asp:Label ID="Label10" runat="server" Text="Mike Plunkett" CssClass="contentSmall"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:Label ID="Label11" runat="server" Text="405.630.4141" CssClass="contentSmall"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:Label ID="Label12" runat="server" Text="mplunkett@ossaa.com" CssClass="contentSmall"></asp:Label></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow BackColor="LightGray">
                        <asp:TableCell><asp:Label ID="Label16" runat="server" Text="Amy Cassell" CssClass="contentSmall"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:Label ID="Label17" runat="server" Text="405.359.1073" CssClass="contentSmall"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:Label ID="Label18" runat="server" Text="acassell@ossaa.com" CssClass="contentSmall"></asp:Label></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell><asp:Label ID="Label22" runat="server" Text="Mike Whaley" CssClass="contentSmall"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:Label ID="Label23" runat="server" Text="405.818.3541" CssClass="contentSmall"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:Label ID="Label24" runat="server" Text="mwhaley@ossaa.com" CssClass="contentSmall"></asp:Label></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow BackColor="LightGray">
                        <asp:TableCell><asp:Label ID="Label25" runat="server" Text="David Glover" CssClass="contentSmall"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:Label ID="Label26" runat="server" Text="405.213.4636" CssClass="contentSmall"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:Label ID="Label27" runat="server" Text="dglover@ossaa.com" CssClass="contentSmall"></asp:Label></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell><asp:Label ID="Label19" runat="server" Text="Todd Goolsby" CssClass="contentSmall"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:Label ID="Label20" runat="server" Text="405.627.6956" CssClass="contentSmall"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:Label ID="Label21" runat="server" Text="tgoolsby@ossaa.com" CssClass="contentSmall"></asp:Label></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow BackColor="LightGray">
                        <asp:TableCell><asp:Label ID="Label5" runat="server" Text="Grant Gower" CssClass="contentSmall"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:Label ID="Label7" runat="server" Text="405.642.4521" CssClass="contentSmall"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:Label ID="Label8" runat="server" Text="ggower@ossaa.com" CssClass="contentSmall"></asp:Label></asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </asp:TableCell>  
        </asp:TableRow>
</asp:Table>



