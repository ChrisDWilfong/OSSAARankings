<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucFBScratchList.ascx.vb" Inherits="OSSAARankings.ucFBScratchList" %>
<table id="scratchList" width="400px">
    <tr>
        <td align="left" width="50%"><asp:Button ID="cmdSave" runat="server" Text="Save Changes" CssClass="button" BackColor="Green" ForeColor="Yellow" Font-Bold="true" Font-Size="12pt" /></td>
        <td align="right" width="50%"><asp:Button ID="cmdBack" runat="server" Text="Go Back" CssClass="button" /></td>
    </tr>
    <tr><td colspan="2" style="background-color:Yellow;"><asp:Label ID="lblMessage" CssClass="label" runat="server" Text="" style="color:Red; font-weight:bold; font-size:14pt;"></asp:Label></td></tr>
    <tr><td colspan="2"><hr /></td></tr>
    <tr style="background-color:Black;"><td colspan="4"><asp:Label ID="lblHeader" Width="100%" CssClass="shadedheader" runat="server" style="text-align:center;" Text="2014 PLAYOFF SCRATCH LIST"></asp:Label></td></tr>
    <tr style="background-color:Maroon;"><td colspan="2"><asp:Label ID="Label7" Width="100%" CssClass="text" runat="server" style="text-align:center; color:White; font-family: Verdana; font-size:8pt;" Text="Enter the OSSAA ID# to Identify the Crew.<br>Blank out the OSSAA ID# to remove from the scratchlist."></asp:Label></td></tr>
    <tr style="background-color:Gray;">
        <td width="30%" align="center"><asp:Label ID="Label1" runat="server" Text="ID" CssClass="shadedheader"></asp:Label></td>
        <td width="70%" align="center"><asp:Label ID="Label2" runat="server" Text="OFFICIAL" CssClass="shadedheader"></asp:Label></td>
    </tr>
    <tr style="background-color:Silver;">
        <td width="30%" valign="top"><asp:Label ID="lblNo1" runat="server" Text="1." CssClass="label"></asp:Label>&nbsp;
        <asp:TextBox ID="txtOSSAAID1" runat="server" CssClass="textbox" AutoPostBack="True"></asp:TextBox></td>
        <td width="70%" valign="top">&nbsp;<i><asp:Label ID="lblOfficialName1" runat="server" Text="" CssClass="label"></asp:Label></i></td>
    </tr>
    <tr>
        <td width="30%" valign="top"><asp:Label ID="lblNo2" runat="server" Text="2." CssClass="label"></asp:Label>&nbsp;
        <asp:TextBox ID="txtOSSAAID2" runat="server" CssClass="textbox" AutoPostBack="True"></asp:TextBox></td>
        <td width="70%" valign="top">&nbsp;<i><asp:Label ID="lblOfficialName2" runat="server" Text="" CssClass="label"></asp:Label></i></td>
    </tr>
    <tr style="background-color:Silver;">
        <td width="30%" valign="top"><asp:Label ID="lblNo3" runat="server" Text="3." CssClass="label"></asp:Label>&nbsp;
        <asp:TextBox ID="txtOSSAAID3" runat="server" CssClass="textbox" AutoPostBack="True"></asp:TextBox></td>
        <td width="70%" valign="top">&nbsp;<i><asp:Label ID="lblOfficialName3" runat="server" Text="" CssClass="label"></asp:Label></i></td>
    </tr>
    <tr>
        <td width="30%" valign="top"><asp:Label ID="lblNo4" runat="server" Text="4." CssClass="label"></asp:Label>&nbsp;
        <asp:TextBox ID="txtOSSAAID4" runat="server" CssClass="textbox" AutoPostBack="True"></asp:TextBox></td>
        <td width="70%" valign="top">&nbsp;<i><asp:Label ID="lblOfficialName4" runat="server" Text="" CssClass="label"></asp:Label></i></td>
    </tr>
    <tr style="background-color:Silver;">
        <td width="30%" valign="top"><asp:Label ID="lblNo5" runat="server" Text="5." CssClass="label"></asp:Label>&nbsp;
        <asp:TextBox ID="txtOSSAAID5" runat="server" CssClass="textbox" AutoPostBack="True"></asp:TextBox></td>
        <td width="70%" valign="top">&nbsp;<i><asp:Label ID="lblOfficialName5" runat="server" Text="" CssClass="label"></asp:Label></i></td>
    </tr>

</table>
