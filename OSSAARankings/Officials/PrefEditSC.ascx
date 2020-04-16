<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="PrefEditSC.ascx.vb" Inherits="OSSAARankings.PrefEditSC" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdateProgress ID="updProgress" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
    <ProgressTemplate>            
        <div style="position:absolute; top:400px;left:250px;">
            <img alt="Loading..." src="../images/ajax-loader1.gif" />
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
<ContentTemplate>
<table id="editOfficials" width="700px">
    <tr>
        <td colspan="2">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
        </td>
        <td align="right">
            <asp:Button ID="cmdBack" runat="server" Text="Go Back" CssClass="button" />
        </td>
        <td align="right"><asp:Button ID="cmdSave" runat="server" Text="Save Changes" CssClass="button" BackColor="Green" ForeColor="White" Font-Bold="true" Font-Size="Large" /></td>
    </tr>
    <tr><td colspan="4" style="background-color:Yellow;"><asp:Label ID="lblMessage" CssClass="label" runat="server" Text="" style="color:Red; font-weight:bold; font-size:12pt;"></asp:Label></td></tr>
    <tr><td colspan="4"><u><asp:Label id="lblPrefHeader" runat="server" Font-Bold="true" ForeColor="Maroon" style="font-size:16px;" Text="PREFERENTIAL LISTS RECEIVED AFTER 4pm..." CssClass="label"></asp:Label></u></td></tr>
    <tr><td colspan="4"><hr /></td></tr>
    <tr style="background-image:url('../images/black_bg.gif'); height:32px;"><td colspan="4"><asp:Label ID="lblHeader" Width="100%" CssClass="shadedheader" ForeColor="White" Font-Bold="true" runat="server" style="text-align:center;" Text="PREFERENTIAL OFFICIALS LIST (STEP 1)"></asp:Label></td></tr>
    <tr><td colspan="4">
            <asp:Label ID="lblMiles" runat="server" Text="" CssClass="label"></asp:Label>
        </td></tr>
    <tr style="background-color:Maroon;" height="30px"><td colspan="4"><asp:Label ID="Label7" Width="100%" CssClass="text" runat="server" style="text-align:center; color:White; font-weight:bold; font-family: Verdana; font-size:10pt;" Text="Select up to 10 officials in order of preference (TOP 6 are required)."></asp:Label></td></tr>
    <tr style="background-image:url('../images/black_bg.gif'); height:32px;"><td colspan="4"><asp:Label ID="Label13" Width="100%" CssClass="shadedheader" ForeColor="White" Font-Bold="true" runat="server" style="text-align:center;" Text="REGIONAL TOURNAMENT OFFICIALS"></asp:Label></td></tr>
    <tr style="background-color:black;">
        <td width="20%" align="center"><asp:Label ID="Label1" runat="server" Text="OSSAA ID#" CssClass="shadedheader" BackColor="black"></asp:Label></td>
        <td width="30%" align="center"><asp:Label ID="Label2" runat="server" Text="OFFICIAL" CssClass="shadedheader" BackColor="black"></asp:Label></td>
        <td width="30%" align="center"><asp:Label ID="Label4" runat="server" Text="CITY" CssClass="shadedheader" BackColor="black"></asp:Label></td>
        <td width="10%" align="center"><asp:Label ID="Label3" runat="server" Text="" CssClass="shadedheader" BackColor="black"></asp:Label></td>
    </tr>
    <tr style="background-color:Silver;">
        <td width="20%" valign="top" align="right"><asp:Label ID="lblNo1" runat="server" Text="&nbsp;1.<span style='color:Red'>*</span>" CssClass="label"></asp:Label>&nbsp;
        <asp:TextBox ID="txtOSSAAID1" runat="server" CssClass="textbox" AutoPostBack="True" Width="60%"></asp:TextBox></td>
        <td width="30%" valign="top"><i><asp:Label ID="lblOfficialName1" runat="server" Text="" CssClass="label"></asp:Label></i></td>
        <td width="30%" valign="top"><i><asp:Label ID="lblOfficialCity1" runat="server" CssClass="label" Text=""></asp:Label><asp:Label ID="lblOfficialZip1" runat="server" CssClass="label" Text="" Visible="false"></asp:Label></i></td>
    </tr>
    <tr style="background-color:White;">
        <td width="20%" valign="top" align="right"><asp:Label ID="lblNo2" runat="server" Text="&nbsp;2.<span style='color:Red'>*</span>" CssClass="label"></asp:Label>&nbsp;
        <asp:TextBox ID="txtOSSAAID2" runat="server" CssClass="textbox" AutoPostBack="True" Width="60%"></asp:TextBox></td>
        <td width="30%" valign="top"><i><asp:Label ID="lblOfficialName2" runat="server" Text="" CssClass="label"></asp:Label></i></td>
        <td width="30%" valign="top"><i><asp:Label ID="lblOfficialCity2" runat="server" CssClass="label" Text=""></asp:Label><asp:Label ID="lblOfficialZip2" runat="server" CssClass="label" Text="" Visible="false"></asp:Label></i></td>
    </tr>
        <tr style="background-color:Silver;">
        <td width="20%" valign="top" align="right"><asp:Label ID="lblNo3" runat="server" Text="&nbsp;3.<span style='color:Red'>*</span>" CssClass="label"></asp:Label>&nbsp;
        <asp:TextBox ID="txtOSSAAID3" runat="server" CssClass="textbox" AutoPostBack="True" Width="60%"></asp:TextBox></td>
        <td width="30%" valign="top"><i><asp:Label ID="lblOfficialName3" runat="server" Text="" CssClass="label"></asp:Label></i></td>
        <td width="30%" valign="top"><i><asp:Label ID="lblOfficialCity3" runat="server" CssClass="label" Text=""></asp:Label><asp:Label ID="lblOfficialZip3" runat="server" CssClass="label" Text="" Visible="false"></asp:Label></i></td>
    </tr>
    <tr style="background-color:White;">
        <td width="20%" valign="top" align="right"><asp:Label ID="lblNo4" runat="server" Text="&nbsp;4.&nbsp;&nbsp;" CssClass="label"></asp:Label>&nbsp;
        <asp:TextBox ID="txtOSSAAID4" runat="server" CssClass="textbox" AutoPostBack="True" Width="60%"></asp:TextBox></td>
        <td width="30%" valign="top"><i><asp:Label ID="lblOfficialName4" runat="server" Text="" CssClass="label"></asp:Label></i></td>
        <td width="30%" valign="top"><i><asp:Label ID="lblOfficialCity4" runat="server" CssClass="label" Text=""></asp:Label><asp:Label ID="lblOfficialZip4" runat="server" CssClass="label" Text="" Visible="false"></asp:Label></i></td>
    </tr>
    <tr style="background-color:Silver;">
        <td width="20%" valign="top" align="right"><asp:Label ID="lblNo5" runat="server" Text="&nbsp;5.&nbsp;&nbsp;" CssClass="label"></asp:Label>&nbsp;
        <asp:TextBox ID="txtOSSAAID5" runat="server" CssClass="textbox" AutoPostBack="True" Width="60%"></asp:TextBox></td>
        <td width="30%" valign="top"><i><asp:Label ID="lblOfficialName5" runat="server" Text="" CssClass="label"></asp:Label></i></td>
        <td width="30%" valign="top"><i><asp:Label ID="lblOfficialCity5" runat="server" CssClass="label" Text=""></asp:Label><asp:Label ID="lblOfficialZip5" runat="server" CssClass="label" Text="" Visible="false"></asp:Label></i></td>
    </tr>
    <tr style="background-color:White;">
        <td width="20%" valign="top" align="right"><asp:Label ID="lblNo6" runat="server" Text="&nbsp;6.&nbsp;&nbsp;" CssClass="label"></asp:Label>&nbsp;
        <asp:TextBox ID="txtOSSAAID6" runat="server" CssClass="textbox" AutoPostBack="True" Width="60%"></asp:TextBox></td>
        <td width="30%" valign="top"><i><asp:Label ID="lblOfficialName6" runat="server" Text="" CssClass="label"></asp:Label></i></td>
        <td width="30%" valign="top"><i><asp:Label ID="lblOfficialCity6" runat="server" CssClass="label" Text=""></asp:Label><asp:Label ID="lblOfficialZip6" runat="server" CssClass="label" Text="" Visible="false"></asp:Label></i></td>
    </tr>
    <tr style="background-color:Silver;">
        <td width="20%" valign="top" align="right"><asp:Label ID="lblNo7" runat="server" Text="&nbsp;7.&nbsp;&nbsp;" CssClass="label"></asp:Label>&nbsp;
        <asp:TextBox ID="txtOSSAAID7" runat="server" CssClass="textbox" AutoPostBack="True" Width="60%"></asp:TextBox></td>
        <td width="30%" valign="top"><i><asp:Label ID="lblOfficialName7" runat="server" Text="" CssClass="label"></asp:Label></i></td>
        <td width="30%" valign="top"><i><asp:Label ID="lblOfficialCity7" runat="server" CssClass="label" Text=""></asp:Label><asp:Label ID="lblOfficialZip7" runat="server" CssClass="label" Text="" Visible="false"></asp:Label></i></td>
    </tr>
    <tr style="background-color:White;">
        <td width="20%" valign="top" align="right"><asp:Label ID="lblNo8" runat="server" Text="&nbsp;8.&nbsp;&nbsp;" CssClass="label"></asp:Label>&nbsp;
        <asp:TextBox ID="txtOSSAAID8" runat="server" CssClass="textbox" AutoPostBack="True" Width="60%"></asp:TextBox></td>
        <td width="30%" valign="top"><i><asp:Label ID="lblOfficialName8" runat="server" Text="" CssClass="label"></asp:Label></i></td>
        <td width="30%" valign="top"><i><asp:Label ID="lblOfficialCity8" runat="server" CssClass="label" Text=""></asp:Label><asp:Label ID="lblOfficialZip8" runat="server" CssClass="label" Text="" Visible="false"></asp:Label></i></td>
    </tr>
    <tr style="background-color:Silver;">
        <td width="20%" valign="top" align="right"><asp:Label ID="lblNo9" runat="server" Text="&nbsp;9.&nbsp;&nbsp;" CssClass="label"></asp:Label>&nbsp;
        <asp:TextBox ID="txtOSSAAID9" runat="server" CssClass="textbox" AutoPostBack="True" Width="60%"></asp:TextBox></td>
        <td width="30%" valign="top"><i><asp:Label ID="lblOfficialName9" runat="server" Text="" CssClass="label"></asp:Label></i></td>
        <td width="30%" valign="top"><i><asp:Label ID="lblOfficialCity9" runat="server" CssClass="label" Text=""></asp:Label><asp:Label ID="lblOfficialZip9" runat="server" CssClass="label" Text="" Visible="false"></asp:Label></i></td>
    </tr>
    <tr style="background-color:White;">
        <td width="20%" valign="top" align="right"><asp:Label ID="lblNo10" runat="server" Text="10.&nbsp;&nbsp;" CssClass="label"></asp:Label>&nbsp;
        <asp:TextBox ID="txtOSSAAID10" runat="server" CssClass="textbox" AutoPostBack="True" Width="60%"></asp:TextBox></td>
        <td width="30%" valign="top"><i><asp:Label ID="lblOfficialName10" runat="server" Text="" CssClass="label"></asp:Label></i></td>
        <td width="30%" valign="top"><i><asp:Label ID="lblOfficialCity10" runat="server" CssClass="label" Text=""></asp:Label><asp:Label ID="lblOfficialZip10" runat="server" CssClass="label" Text="" Visible="false"></asp:Label></i></td>
    </tr>
    <tr><td colspan="4" style="background-color:Yellow;"><asp:Label ID="lblMessage1" CssClass="label" runat="server" Text="" style="color:Red; font-weight:bold; font-size:12pt;"></asp:Label></td></tr>
</table>

<table id="editScratch" width="750px">
    <tr style="background-image:url('../images/black_bg.gif'); height:32px;"><td colspan="3"><asp:Label ID="Label15" Width="100%" CssClass="shadedheader" ForeColor="White" Font-Bold="true" runat="server" style="text-align:center;" Text="SCRATCH FOR SEMI & FINALS (STEP 2)"></asp:Label></td></tr>
    <tr style="background-color:White;">
        <td width="20%" valign="top" align="right"><asp:Label ID="Label5" runat="server" Text="1.&nbsp;&nbsp;" CssClass="label"></asp:Label>&nbsp;
        <asp:TextBox ID="txtOSSAAID11" runat="server" CssClass="textbox" AutoPostBack="True" Width="60%"></asp:TextBox></td>
        <td width="30%" valign="top"><i><asp:Label ID="lblOfficialName11" runat="server" Text="" CssClass="label"></asp:Label></i></td>
        <td width="30%" valign="top"><i><asp:Label ID="lblOfficialCity11" runat="server" CssClass="label" Text=""></asp:Label><asp:Label ID="lblOfficialZip11" runat="server" CssClass="label" Text="" Visible="false"></asp:Label></i></td>
    </tr>
</table>

<table id="editSignature" width="750px">
    <tr style="background-image:url('../images/black_bg.gif'); height:32px;"><td colspan="3"><asp:Label ID="Label12" Width="100%" CssClass="shadedheader" ForeColor="White" Font-Bold="true" runat="server" style="text-align:center;" Text="SCHOOL INFORMATION (STEP 3)"></asp:Label></td></tr>
    <tr><td colspan="3" style="background-color:Yellow;"><asp:Label ID="lblMessage4" CssClass="label" runat="server" Text="" style="color:Red; font-weight:bold; font-size:12pt;"></asp:Label></td></tr>
    <tr style="background-color:Black;">
        <td width="20%" valign="top">&nbsp;&nbsp;</td>
        <td width="35%" valign="top" align="center"><asp:Label ID="chris" runat="server" Text="Signature" CssClass="label" ForeColor="White" Font-Bold="true"></asp:Label></td>
        <td width="10%" valign="top">&nbsp;&nbsp;</td>
    </tr>
    <tr style="background-color:Silver;">
        <td width="20%" valign="top"><asp:Label ID="lbl100" runat="server" 
                Text="SCHOOL : <span style='color:Red'>*</span>" CssClass="label"></asp:Label></td>
        <td width="35%" valign="top"><asp:TextBox ID="txtSchool" runat="server" CssClass="textbox" Width="95%"></asp:TextBox></td>
        <td width="10%" valign="top">&nbsp;&nbsp;</td>
    </tr>
    <tr style="background-color:White;">
        <td width="20%" valign="top"><asp:Label ID="Label6" runat="server" Text="CLASS : <span style='color:Red'>*</span>" CssClass="label"></asp:Label></td>
        <td width="35%" valign="top"><asp:TextBox ID="txtClass" runat="server" CssClass="textbox" Width="95%"></asp:TextBox></td>
        <td width="10%" valign="top">&nbsp;&nbsp;</td>
    </tr>
    <tr style="background-color:Silver;">
        <td width="20%" valign="top"><asp:Label ID="Label8" runat="server" Text="COACH NAME : <span style='color:Red'>*</span>" CssClass="label"></asp:Label></td>
        <td width="35%" valign="top"><asp:TextBox ID="txtSignature11" runat="server" CssClass="textbox" Width="95%"></asp:TextBox></td>
        <td width="10%" valign="top">&nbsp;&nbsp;</td>
    </tr>
    <tr style="background-color:White;">
        <td width="20%" valign="top"><asp:Label ID="Label9" runat="server" Text="PRINCIPAL NAME : <span style='color:Red'>*</span>" CssClass="label"></asp:Label></td>
        <td width="35%" valign="top"><asp:TextBox ID="txtSignature21" runat="server" CssClass="textbox" Width="95%"></asp:TextBox></td>
        <td width="10%" valign="top">&nbsp;&nbsp;</td>
    </tr>
    <tr style="background-image:url('../images/black_bg.gif'); height:32px;"><td colspan="3"><asp:Label ID="Label16" Width="100%" CssClass="shadedheader" ForeColor="White" Font-Bold="true" runat="server" style="text-align:center;" Text="SAVE CHANGES (STEP 4)"></asp:Label></td></tr>
    <tr><td colspan="3" style="background-color:Yellow;"><asp:Label ID="Label23" CssClass="label" runat="server" Text="" style="color:Red; font-weight:bold; font-size:14pt;">NOW, GO BACK TO THE TOP OF THIS PAGE AND CLICK 'SAVE CHANGES' TO SAVE YOUR INFORMATION...(PLEASE NOTE, THERE WILL BE NO NEED TO FAX DOCUMENTS TO OUR OFFICE)...</asp:Label></td></tr>
</table>
</ContentTemplate>
</asp:UpdatePanel>

