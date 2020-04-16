<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="Officials.Master" CodeBehind="BBMainMenu.aspx.vb" Inherits="OSSAARankings.BBMainMenu" %>
<%@ Register src="BBCoachInfo.ascx" tagname="BBCoachInfo" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table id="FB" width="750px">
    <tr>
        <td align="left" valign="top" colspan="2">
            <uc1:BBCoachInfo ID="BBCoachInfo1" runat="server" />
        </td>
    </tr>
    <tr>
        <td colspan="2"><asp:Label ID="Label1" runat="server" Text="Varsity Basketball Rating of Officials 2019-2020" ForeColor="Maroon" Font-Names="Arial" Font-Size="14pt" Font-Bold="true"></asp:Label></td>
        
    </tr>
    <tr>
        
        <td width="50%">
            <asp:Button ID="cmdAddGame" runat="server" Text="Add New Game" BackColor="ForestGreen" Font-Names="Arial" Font-Size="12pt" ForeColor="White" Font-Bold="true" />
        </td>        
        <td width="50%">
            <asp:Button ID="cmdEditGame" runat="server" Text="Edit Game" BackColor="ForestGreen" Font-Names="Arial" Font-Size="12pt" ForeColor="White" Font-Bold="true" />&nbsp;&nbsp;
            <asp:DropDownList CssClass="dropdown" ID="cboGame" runat="server" DataSourceID="SqlDataSource5" DataTextField="Teams" DataValueField="Id"></asp:DropDownList>
        </td>
    </tr>
    <tr>
         <td align="left" class="style2"><asp:Label ID="lblNote" runat="server" Text="" style="color: Red; font-family: Verdana; font-size:9px;"></asp:Label></td>
    </tr>
    <tr>
        <td align="left" valign="top">
            <asp:Label ID="lblMessage" runat="server" Text="" style="color: Red; font-family: Verdana; font-size:12px; font-weight:bold;"></asp:Label>
        </td>
    </tr>
</table>    
    <asp:SqlDataSource ID="SqlDataSource5" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OSSAAConnectionString %>" 
        SelectCommand="SELECT [id], [intGameKey], 'Game #' + CONVERT(varchar, [intGameKey]) + ' (' + [strGameDate] + ')' As Teams, [intCoachID] FROM [tblOfficialsRatingByCoachesBB] WHERE [intCoachID] = @CoachID ORDER BY [intGameKey]" >
        <SelectParameters>
            <asp:SessionParameter Name="CoachID" SessionField="CoachID" />
        </SelectParameters>
</asp:SqlDataSource>
</asp:Content>
