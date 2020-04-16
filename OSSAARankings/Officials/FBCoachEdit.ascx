<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="FBCoachEdit.ascx.vb" Inherits="OSSAARankings.FBCoachEdit" %>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<table id="editOfficial" width="989px">
    <tr>
        <td colspan="2">
            <asp:Button ID="cmdAddNew" runat="server" Text="Add New" CssClass="button" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="cmdEditWeek" runat="server" Text="Edit Week" CssClass="button" />&nbsp;&nbsp;
        <asp:DropDownList CssClass="dropdown" ID="cboWeek" runat="server" 
                DataSourceID="SqlDataSource5" DataTextField="Teams" 
                DataValueField="Id"></asp:DropDownList>
        </td>
        <td align="right">
            &nbsp;
        </td>
        <td align="right"><asp:Button ID="cmdSave" runat="server" Text="Save Changes" CssClass="button" BackColor="Green" ForeColor="White" Font-Bold="true" Font-Size="16px" Font-Names="Arial"/></td>
    </tr>
    <tr><td colspan="4" style="background-color:Yellow;"><asp:Label ID="lblMessage" CssClass="label" runat="server" Text="" style="color:Red; font-weight:bold; font-size:14pt;"></asp:Label></td></tr>
    <tr><td colspan="4"><hr /></td></tr>
    <tr style="background-color:Black;"><td colspan="4"><asp:Label ID="lblHeader" Width="100%" CssClass="shadedheader" runat="server" style="text-align:center;" Text="2014 RATE GAME CREW PERFORMANCE"></asp:Label></td></tr>
    <tr>
        <td colspan="2">
        <asp:Label ID="Label5" runat="server" Text="Week # : " CssClass="label"></asp:Label>&nbsp;
        <asp:DropDownList ID="cboWeekNew" runat="server" CssClass="dropdown" DataSourceID="SqlDataSource7" DataTextField="strDescription" DataValueField="intKey" Width="100px">
        </asp:DropDownList>
        <asp:TextBox ID="txtWeek" runat="server" Width="40px" Visible="false" Enabled="false" CssClass="textbox"></asp:TextBox>
        <asp:TextBox ID="txtKey" runat="server" Width="40px" Visible="false" Enabled="false" CssClass="textbox"></asp:TextBox>
        </td>
        <td colspan="2">
            <asp:Label ID="Label6" runat="server" Text="Home or Away? " CssClass="label"></asp:Label>&nbsp;
            <asp:DropDownList ID="cboHomeAway" runat="server" CssClass="dropdown">
                <asp:ListItem Selected="True" Value="N">Select...</asp:ListItem>
                <asp:ListItem Value="H">Home</asp:ListItem>
                <asp:ListItem Value="A">Away</asp:ListItem>
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
        <asp:TextBox ID="txtOSSAAID1" runat="server" CssClass="textbox" AutoPostBack="True" Width="150px"></asp:TextBox></td>
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
        <asp:TextBox ID="txtComments1" runat="server" TextMode="MultiLine" Rows="4" Width="100%" CssClass="textbox" Height="60px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td width="15%" valign="top"><asp:Label ID="lblNo2" runat="server" Text="2." CssClass="label"></asp:Label>&nbsp;
        <asp:TextBox ID="txtOSSAAID2" runat="server" CssClass="textbox" AutoPostBack="True" Width="150px"></asp:TextBox></td>
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
        <asp:TextBox ID="txtComments2" runat="server" TextMode="MultiLine" Rows="4" Width="100%" CssClass="textbox" Height="60px"></asp:TextBox>
        </td>
    </tr>
    <tr style="background-color:Silver;">
        <td width="15%" valign="top"><asp:Label ID="lblNo3" runat="server" Text="3." CssClass="label"></asp:Label>&nbsp;
        <asp:TextBox ID="txtOSSAAID3" runat="server" CssClass="textbox" AutoPostBack="True" Width="150px"></asp:TextBox></td>
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
        <asp:TextBox ID="txtComments3" runat="server" TextMode="MultiLine" Rows="4" Width="100%" CssClass="textbox" Height="60px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td width="15%" valign="top"><asp:Label ID="lblNo4" runat="server" Text="4." CssClass="label"></asp:Label>&nbsp;
        <asp:TextBox ID="txtOSSAAID4" runat="server" CssClass="textbox" AutoPostBack="True" Width="150px"></asp:TextBox></td>
        <td width="20%" valign="top">&nbsp;<i><asp:Label ID="lblOfficialName4" runat="server" Text="" CssClass="label"></asp:Label></i></td>
        <td width="20%" valign="top"><asp:RadioButtonList ID="rb4" runat="server" RepeatDirection="Horizontal" CssClass="label">
            <asp:ListItem Value="1">S</asp:ListItem>
            <asp:ListItem Value="2">G</asp:ListItem>
            <asp:ListItem Value="3">F</asp:ListItem>
            <asp:ListItem Value="4">U</asp:ListItem>
            <asp:ListItem Value="5">P</asp:ListItem>
        </asp:RadioButtonList>
        </td>
        <td width="40%" valign="top">
        <asp:TextBox ID="txtComments4" runat="server" TextMode="MultiLine" Rows="4" Width="100%" CssClass="textbox" Height="60px"></asp:TextBox>
        </td>
    </tr>
    <tr style="background-color:Silver;">
        <td width="15%" valign="top"><asp:Label ID="lblNo5" runat="server" Text="5." CssClass="label"></asp:Label>&nbsp;
        <asp:TextBox ID="txtOSSAAID5" runat="server" CssClass="textbox" AutoPostBack="True" Width="150px"></asp:TextBox></td>
        <td width="20%" valign="top">&nbsp;<i><asp:Label ID="lblOfficialName5" runat="server" Text="" CssClass="label"></asp:Label></i></td>
        <td width="20%" valign="top"><asp:RadioButtonList ID="rb5" runat="server" RepeatDirection="Horizontal" CssClass="label">
            <asp:ListItem Value="1">S</asp:ListItem>
            <asp:ListItem Value="2">G</asp:ListItem>
            <asp:ListItem Value="3">F</asp:ListItem>
            <asp:ListItem Value="4">U</asp:ListItem>
            <asp:ListItem Value="5">P</asp:ListItem>
        </asp:RadioButtonList>
        </td>
        <td width="40%" valign="top">
        <asp:TextBox ID="txtComments5" runat="server" TextMode="MultiLine" Rows="4" Width="100%" CssClass="textbox" Height="60px"></asp:TextBox>
        </td>
    </tr>

</table>
    <asp:SqlDataSource ID="SqlDataSource5" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OSSAAConnectionString %>" 
    SelectCommand="SELECT DISTINCT 
               dbo.tblOfficialsRatingByCoachesFB.Id, dbo.tblOfficialsRatingByCoachesFB.intWeekKey, dbo.tblOfficialsWeeksFootball.strDescriptionCoach AS Teams, 
               dbo.tblOfficialsRatingByCoachesFB.intCoachID
FROM  dbo.tblOfficialsRatingByCoachesFB LEFT OUTER JOIN
               dbo.tblOfficialsWeeksFootball ON dbo.tblOfficialsRatingByCoachesFB.intWeekKey = dbo.tblOfficialsWeeksFootball.intKey
WHERE (dbo.tblOfficialsRatingByCoachesFB.intSchoolID = @intSchoolID AND dbo.tblOfficialsRatingByCoachesFB.intYear = @intYear )
ORDER BY dbo.tblOfficialsRatingByCoachesFB.intWeekKey" >
        <SelectParameters>
            <asp:SessionParameter Name="intSchoolID" SessionField="intSchoolID" />
            <asp:SessionParameter Name="intYear" SessionField="gYear" />
        </SelectParameters>
</asp:SqlDataSource>

<asp:SqlDataSource ID="SqlDataSource7" runat="server" 
    ConnectionString="<%$ ConnectionStrings:OSSAAConnectionString %>" 
    SelectCommand="SELECT [intKey], [strDescriptionCoach] As [strDescription] FROM [tblOfficialsWeeksFootball] WHERE ([tblOfficialsWeeksFootball].intKey <= 11 OR [tblOfficialsWeeksFootball].intKey > 22)">
    <SelectParameters>
        <asp:SessionParameter Name="CoachID" SessionField="CoachID" Type="Int32" />
    </SelectParameters>
</asp:SqlDataSource>