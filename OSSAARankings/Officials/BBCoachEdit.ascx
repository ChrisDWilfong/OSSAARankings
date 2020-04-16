<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="BBCoachEdit.ascx.vb" Inherits="OSSAARankings.BBCoachEdit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdateProgress ID="updProgress" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
    <ProgressTemplate>            
        <img alt="progress" src="../images/ajax-loader.gif"/><span style="font-family: Verdana; font-size:10px;">Processing...</span>
    </ProgressTemplate>
</asp:UpdateProgress>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
<ContentTemplate>
<table id="editOfficial" width="989px">
    <tr>
        <td colspan="2">
            <asp:Button ID="cmdBack" runat="server" CssClass="button" Text="Go Back"  BackColor="ForestGreen" Font-Names="Arial" Font-Size="12pt" ForeColor="White" Font-Bold="true" />
        </td>
        <td align="right">
            &nbsp;</td>
        <td align="right"><asp:Button ID="cmdSave" runat="server" Text="Save Changes" CssClass="button" BackColor="ForestGreen" Font-Names="Arial" Font-Size="12pt" ForeColor="White" Font-Bold="true"/></td>
    </tr>
    <tr><td colspan="4" style="background-color:Yellow;"><asp:Label ID="lblMessage" CssClass="label" runat="server" Text="" style="color:Red; font-weight:bold; font-size:14pt;"></asp:Label></td></tr>
    <tr><td colspan="4"><hr /></td></tr>
    <tr style="background-color:Black;"><td colspan="4"><asp:Label ID="lblHeader" Width="100%" CssClass="shadedheader" runat="server" style="text-align:center;" Text="2014 RATE GAME CREW PERFORMANCE"></asp:Label></td></tr>
    <tr>
        <td>
        <asp:Label ID="Label5" runat="server" Text="Game # : " CssClass="label"></asp:Label>&nbsp;
        <asp:TextBox ID="txtGame" runat="server" Width="40px"
                Enabled="false" CssClass="textbox"></asp:TextBox>
        <asp:TextBox ID="txtKey" runat="server" Width="40px" Visible="false" Enabled="false" CssClass="textbox"></asp:TextBox>
        </td>
        <td>
            <asp:Label ID="Label9" runat="server" Text="Game Date : " CssClass="label"></asp:Label>
            <asp:TextBox ID="txtGameDate1" runat="server" Width="75px" CssClass="dropdown"></asp:TextBox>
            <asp:CalendarExtender ID="txtGameDate_CalendarExtender" runat="server" 
                Enabled="True" TargetControlID="txtGameDate1">
            </asp:CalendarExtender>
           
        </td>
        <td align="center" valign="middle">
            <asp:Label ID="Label6" runat="server" Text="Home or Away? " CssClass="label"></asp:Label>&nbsp;
            <asp:DropDownList ID="cboHomeAway" runat="server" CssClass="dropdown">
                <asp:ListItem Selected="True" Value="X">Select...</asp:ListItem>
                <asp:ListItem Value="H">Home</asp:ListItem>
                <asp:ListItem Value="A">Away</asp:ListItem>
                <asp:ListItem Value="N">Neutral</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td align="center" valign="middle">
            <asp:DropDownList ID="cboGender" runat="server" CssClass="dropdown" Visible="false">
                <asp:ListItem Selected="True" Value="X">Select...</asp:ListItem>
            </asp:DropDownList>
        </td>

    </tr>
    <tr style="background-color:Maroon;"><td colspan="4"><asp:Label ID="Label7" Width="100%" CssClass="text" runat="server" style="text-align:center; color:White; font-weight:bold; font-family: Verdana; font-size:10pt;" Text="EVALUATION RATINGS : S = Superior, G = Good, F = Fair, U = Unsatisfactory, P = Poor"></asp:Label></td></tr>
    <tr style="background-color:Gray;">
        <td width="20%" align="center"><asp:Label ID="Label1" runat="server" Text="ID" CssClass="shadedheader"></asp:Label></td>
        <td width="20%" align="center"><asp:Label ID="Label2" runat="server" Text="OFFICIAL" CssClass="shadedheader"></asp:Label></td>
        <td width="20%" align="center"><asp:Label ID="Label3" runat="server" Text="EVALUATION" CssClass="shadedheader"></asp:Label></td>
        <td width="40%" align="center"><asp:Label ID="Label4" runat="server" Text="COMMENTS" CssClass="shadedheader"></asp:Label></td>
    </tr>
    <tr style="background-color:Silver;">
        <td width="15%" valign="top"><asp:Label ID="lblNo1" runat="server" Text="1." CssClass="label"></asp:Label>&nbsp;
        <asp:TextBox ID="txtOSSAAID1" runat="server" CssClass="textbox" AutoPostBack="True"></asp:TextBox></td>
        <td width="20%" valign="top">&nbsp;<i><asp:Label ID="lblOfficialName1" runat="server" Text="" CssClass="label"></asp:Label></i></td>
        <td width="20%" valign="top"><asp:RadioButtonList ID="rb1" runat="server" RepeatDirection="Horizontal" CssClass="label">
            <asp:ListItem Value="1">S</asp:ListItem>
            <asp:ListItem Value="2">G</asp:ListItem>
            <asp:ListItem Value="3">F</asp:ListItem>
            <asp:ListItem Value="4">U</asp:ListItem>
            <asp:ListItem Value="5">P</asp:ListItem>
        </asp:RadioButtonList>
        </td>
        <td width="40%" valign="top">
        <asp:TextBox ID="txtComments1" runat="server" TextMode="MultiLine" Rows="4" Width="100%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td width="15%" valign="top"><asp:Label ID="lblNo2" runat="server" Text="2." CssClass="label"></asp:Label>&nbsp;
        <asp:TextBox ID="txtOSSAAID2" runat="server" CssClass="textbox" AutoPostBack="True"></asp:TextBox></td>
        <td width="20%" valign="top">&nbsp;<i><asp:Label ID="lblOfficialName2" runat="server" Text="" CssClass="label"></asp:Label></i></td>
        <td width="20%" valign="top"><asp:RadioButtonList ID="rb2" runat="server" RepeatDirection="Horizontal" CssClass="label">
            <asp:ListItem Value="1">S</asp:ListItem>
            <asp:ListItem Value="2">G</asp:ListItem>
            <asp:ListItem Value="3">F</asp:ListItem>
            <asp:ListItem Value="4">U</asp:ListItem>
            <asp:ListItem Value="5">P</asp:ListItem>
        </asp:RadioButtonList>
        </td>
        <td width="40%" valign="top">
        <asp:TextBox ID="txtComments2" runat="server" TextMode="MultiLine" Rows="4" Width="100%" CssClass="textbox"></asp:TextBox>
        </td>
    </tr>
    <tr style="background-color:Silver;">
        <td width="15%" valign="top"><asp:Label ID="lblNo3" runat="server" Text="3." CssClass="label"></asp:Label>&nbsp;
        <asp:TextBox ID="txtOSSAAID3" runat="server" CssClass="textbox" AutoPostBack="True"></asp:TextBox></td>
        <td width="20%" valign="top">&nbsp;<i><asp:Label ID="lblOfficialName3" runat="server" Text="" CssClass="label"></asp:Label></i></td>
        <td width="20%" valign="top"><asp:RadioButtonList ID="rb3" runat="server" RepeatDirection="Horizontal" CssClass="label">
            <asp:ListItem Value="1">S</asp:ListItem>
            <asp:ListItem Value="2">G</asp:ListItem>
            <asp:ListItem Value="3">F</asp:ListItem>
            <asp:ListItem Value="4">U</asp:ListItem>
            <asp:ListItem Value="5">P</asp:ListItem>
        </asp:RadioButtonList>
        </td>
        <td width="40%" valign="top">
        <asp:TextBox ID="txtComments3" runat="server" TextMode="MultiLine" Rows="4" Width="100%" CssClass="textbox"></asp:TextBox>
        </td>
    </tr>
    
</table>
</ContentTemplate>
</asp:UpdatePanel>

