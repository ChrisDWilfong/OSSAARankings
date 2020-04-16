<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="Officials.Master" CodeBehind="FBMainMenu.aspx.vb" Inherits="OSSAARankings.FBMainMenu" ClientTarget="Uplevel" %>
<%@ Register src="FBCoachInfo.ascx" tagname="FBCoachInfo" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="FB" width="500px">
    <tr>
        <td align="left" valign="top" colspan="2">
            <uc1:FBCoachInfo ID="FBCoachInfo1" runat="server" />
        </td>
    </tr>
    <tr>
        <td width="50%">
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Officials/images/FB1.png"
                AlternateText="Rating of Officials" />
        </td>
        <td width="50%">
            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Officials/images/FB2.png" 
                AlternateText="Scratch List for Playoffs"  />

        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td align="left" class="style2"><asp:Label ID="lblNote" runat="server" Text="You have to have rated the first 6 weeks of the season.  This opens on Wednesday, October 23th @ 6am." style="color: Red; font-family: Verdana; font-size:9px;" ></asp:Label></td>
    </tr>
    <tr>
        <td align="left" valign="top" colspan="2">
            <asp:Label ID="lblMessage" runat="server" Text="" style="color: Red; font-family: Verdana; font-size:12px; font-weight:bold;"></asp:Label>
        </td>
        
    </tr>
</table>    
</asp:Content>
