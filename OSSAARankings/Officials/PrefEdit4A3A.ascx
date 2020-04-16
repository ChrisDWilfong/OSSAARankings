<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="PrefEdit4A3A.ascx.vb" Inherits="OSSAARankings.PrefEdit4A3A" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register assembly="Infragistics4.Web.v10.2, Version=10.2.20102.1011, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.Web.UI.EditorControls" tagprefix="ig" %>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdateProgress ID="updProgress" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
    <ProgressTemplate>            
        <img alt="progress" src="../images/ajax-loader.gif"/><span style="font-family: Verdana; font-size:10px;">Processing...</span></ProgressTemplate>
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
    <tr><td colspan="4"><u><asp:Label ID="lblDueDate" runat="server" Font-Bold="true" ForeColor="Maroon" style="font-size:16px;" Text="" CssClass="label"></asp:Label></u></td></tr>
    <tr><td colspan="4"><hr /></td></tr>
    <tr style="background-image:url('../images/black_bg.gif'); height:32px;"><td colspan="4"><asp:Label ID="lblHeader" Width="100%" CssClass="shadedheader" ForeColor="White" Font-Bold="true" runat="server" style="text-align:center;" Text="2017 DISTRICT PREFERENTIAL OFFICIALS LIST (STEP 1)"></asp:Label></td></tr>
    <tr style="background-color:Navy; height:26px;"><td colspan="4"><asp:Label ID="lblDistrictInfo" Width="100%" CssClass="shadedheader" runat="server" style="text-align:center;" Text="" BackColor="Navy" ForeColor="Yellow"></asp:Label></td></tr>
    <tr height="40px">
        <td align="right">
            <asp:Label ID="lblSiteManagerEmail" runat="server" Text="Site Manager E-Mail Address: <span style='color:Red'>*</span>" CssClass="label"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtSiteManagerEmail" runat="server" CssClass="textbox" Width="95%"></asp:TextBox>
        </td>
        <td align="right">
            <asp:Label ID="lblSiteManagerPhone" runat="server" Text="Phone: <span style='color:Red'>*</span>" CssClass="label"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtSiteManagerPhone" runat="server" CssClass="textbox" Width="95%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="4">
            <asp:Label ID="lblMiles" runat="server" Text="" CssClass="label"></asp:Label>
        </td>
    </tr>
    <tr style="background-color:Maroon;" height="30px"><td colspan="4"><asp:Label ID="Label7" Width="100%" CssClass="text" runat="server" style="text-align:center; color:White; font-weight:bold; font-family: Verdana; font-size:10pt;" Text="Select your Top 15 officials in order of preference, below"></asp:Label></td></tr>
    <tr style="background-color:Gray;">
        <td width="20%" align="center"><asp:Label ID="Label1" runat="server" Text="OSSAA ID#" CssClass="shadedheader"></asp:Label></td>
        <td width="30%" align="center"><asp:Label ID="Label2" runat="server" Text="OFFICIAL" CssClass="shadedheader"></asp:Label></td>
        <td width="30%" align="center"><asp:Label ID="Label4" runat="server" Text="CITY" CssClass="shadedheader"></asp:Label></td>
        <td width="10%" align="center"><asp:Label ID="Label3" runat="server" Text="MILES" CssClass="shadedheader"></asp:Label></td>
    </tr>
    <tr style="background-color:Silver;">
        <td width="20%" valign="top"><asp:Label ID="lblNo1" runat="server" Text="&nbsp;1.<span style='color:Red'>*</span>" CssClass="label"></asp:Label>&nbsp;
        <asp:TextBox ID="txtOSSAAID1" runat="server" CssClass="textbox" AutoPostBack="True" Width="60%"></asp:TextBox></td>
        <td width="30%" valign="top"><i><asp:Label ID="lblOfficialName1" runat="server" Text="" CssClass="label"></asp:Label></i></td>
        <td width="30%" valign="top"><i><asp:Label ID="lblOfficialCity1" runat="server" CssClass="label" Text=""></asp:Label><asp:Label ID="lblOfficialZip1" runat="server" CssClass="label" Text="" Visible="false"></asp:Label></i></td>
        <td width="10%" valign="top" align="center"><i><asp:Label ID="lblOfficialMiles1" runat="server" Text="" CssClass="label" style="text-align:center;"></asp:Label></i></td>
    </tr>
    <tr style="background-color:White;">
        <td width="20%" valign="top"><asp:Label ID="lblNo2" runat="server" Text="&nbsp;2.<span style='color:Red'>*</span>" CssClass="label"></asp:Label>&nbsp;
        <asp:TextBox ID="txtOSSAAID2" runat="server" CssClass="textbox" AutoPostBack="True" Width="60%"></asp:TextBox></td>
        <td width="30%" valign="top"><i><asp:Label ID="lblOfficialName2" runat="server" Text="" CssClass="label"></asp:Label></i></td>
        <td width="30%" valign="top"><i><asp:Label ID="lblOfficialCity2" runat="server" CssClass="label" Text=""></asp:Label><asp:Label ID="lblOfficialZip2" runat="server" CssClass="label" Text="" Visible="false"></asp:Label></i></td>
        <td width="10%" valign="top" align="center"><i><asp:Label ID="lblOfficialMiles2" runat="server" Text="" CssClass="label" style="text-align:center;"></asp:Label></i></td>
    </tr>
        <tr style="background-color:Silver;">
        <td width="20%" valign="top"><asp:Label ID="lblNo3" runat="server" Text="&nbsp;3.<span style='color:Red'>*</span>" CssClass="label"></asp:Label>&nbsp;
        <asp:TextBox ID="txtOSSAAID3" runat="server" CssClass="textbox" AutoPostBack="True" Width="60%"></asp:TextBox></td>
        <td width="30%" valign="top"><i><asp:Label ID="lblOfficialName3" runat="server" Text="" CssClass="label"></asp:Label></i></td>
        <td width="30%" valign="top"><i><asp:Label ID="lblOfficialCity3" runat="server" CssClass="label" Text=""></asp:Label><asp:Label ID="lblOfficialZip3" runat="server" CssClass="label" Text="" Visible="false"></asp:Label></i></td>
        <td width="10%" valign="top" align="center"><i><asp:Label ID="lblOfficialMiles3" runat="server" Text="" CssClass="label" style="text-align:center;"></asp:Label></i></td>
    </tr>
    <tr style="background-color:White;">
        <td width="20%" valign="top"><asp:Label ID="lblNo4" runat="server" Text="&nbsp;4.<span style='color:Red'>*</span>" CssClass="label"></asp:Label>&nbsp;
        <asp:TextBox ID="txtOSSAAID4" runat="server" CssClass="textbox" AutoPostBack="True" Width="60%"></asp:TextBox></td>
        <td width="30%" valign="top"><i><asp:Label ID="lblOfficialName4" runat="server" Text="" CssClass="label"></asp:Label></i></td>
        <td width="30%" valign="top"><i><asp:Label ID="lblOfficialCity4" runat="server" CssClass="label" Text=""></asp:Label><asp:Label ID="lblOfficialZip4" runat="server" CssClass="label" Text="" Visible="false"></asp:Label></i></td>
        <td width="10%" valign="top" align="center"><i><asp:Label ID="lblOfficialMiles4" runat="server" Text="" CssClass="label" style="text-align:center;"></asp:Label></i></td>
    </tr>
    <tr style="background-color:Silver;">
        <td width="20%" valign="top"><asp:Label ID="lblNo5" runat="server" Text="&nbsp;5.<span style='color:Red'>*</span>" CssClass="label"></asp:Label>&nbsp;
        <asp:TextBox ID="txtOSSAAID5" runat="server" CssClass="textbox" AutoPostBack="True" Width="60%"></asp:TextBox></td>
        <td width="30%" valign="top"><i><asp:Label ID="lblOfficialName5" runat="server" Text="" CssClass="label"></asp:Label></i></td>
        <td width="30%" valign="top"><i><asp:Label ID="lblOfficialCity5" runat="server" CssClass="label" Text=""></asp:Label><asp:Label ID="lblOfficialZip5" runat="server" CssClass="label" Text="" Visible="false"></asp:Label></i></td>
        <td width="10%" valign="top" align="center"><i><asp:Label ID="lblOfficialMiles5" runat="server" Text="" CssClass="label" style="text-align:center;"></asp:Label></i></td>
    </tr>
    <tr style="background-color:White;">
        <td width="20%" valign="top"><asp:Label ID="lblNo6" runat="server" Text="&nbsp;6.<span style='color:Red'>*</span>" CssClass="label"></asp:Label>&nbsp;
        <asp:TextBox ID="txtOSSAAID6" runat="server" CssClass="textbox" AutoPostBack="True" Width="60%"></asp:TextBox></td>
        <td width="30%" valign="top"><i><asp:Label ID="lblOfficialName6" runat="server" Text="" CssClass="label"></asp:Label></i></td>
        <td width="30%" valign="top"><i><asp:Label ID="lblOfficialCity6" runat="server" CssClass="label" Text=""></asp:Label><asp:Label ID="lblOfficialZip6" runat="server" CssClass="label" Text="" Visible="false"></asp:Label></i></td>
        <td width="10%" valign="top" align="center"><i><asp:Label ID="lblOfficialMiles6" runat="server" Text="" CssClass="label" style="text-align:center;"></asp:Label></i></td>
    </tr>
    <tr style="background-color:Silver;">
        <td width="20%" valign="top"><asp:Label ID="lblNo7" runat="server" Text="&nbsp;7.<span style='color:Red'>*</span>" CssClass="label"></asp:Label>&nbsp;
        <asp:TextBox ID="txtOSSAAID7" runat="server" CssClass="textbox" AutoPostBack="True" Width="60%"></asp:TextBox></td>
        <td width="30%" valign="top"><i><asp:Label ID="lblOfficialName7" runat="server" Text="" CssClass="label"></asp:Label></i></td>
        <td width="30%" valign="top"><i><asp:Label ID="lblOfficialCity7" runat="server" CssClass="label" Text=""></asp:Label><asp:Label ID="lblOfficialZip7" runat="server" CssClass="label" Text="" Visible="false"></asp:Label></i></td>
        <td width="10%" valign="top" align="center"><i><asp:Label ID="lblOfficialMiles7" runat="server" Text="" CssClass="label" style="text-align:center;"></asp:Label></i></td>
    </tr>
    <tr style="background-color:White;">
        <td width="20%" valign="top"><asp:Label ID="lblNo8" runat="server" Text="&nbsp;8.<span style='color:Red'>*</span>" CssClass="label"></asp:Label>&nbsp;
        <asp:TextBox ID="txtOSSAAID8" runat="server" CssClass="textbox" AutoPostBack="True" Width="60%"></asp:TextBox></td>
        <td width="30%" valign="top"><i><asp:Label ID="lblOfficialName8" runat="server" Text="" CssClass="label"></asp:Label></i></td>
        <td width="30%" valign="top"><i><asp:Label ID="lblOfficialCity8" runat="server" CssClass="label" Text=""></asp:Label><asp:Label ID="lblOfficialZip8" runat="server" CssClass="label" Text="" Visible="false"></asp:Label></i></td>
        <td width="10%" valign="top" align="center"><i><asp:Label ID="lblOfficialMiles8" runat="server" Text="" CssClass="label" style="text-align:center;"></asp:Label></i></td>
    </tr>
    <tr style="background-color:Silver;">
        <td width="20%" valign="top"><asp:Label ID="lblNo9" runat="server" Text="&nbsp;9.<span style='color:Red'>*</span>" CssClass="label"></asp:Label>&nbsp;
        <asp:TextBox ID="txtOSSAAID9" runat="server" CssClass="textbox" AutoPostBack="True" Width="60%"></asp:TextBox></td>
        <td width="30%" valign="top"><i><asp:Label ID="lblOfficialName9" runat="server" Text="" CssClass="label"></asp:Label></i></td>
        <td width="30%" valign="top"><i><asp:Label ID="lblOfficialCity9" runat="server" CssClass="label" Text=""></asp:Label><asp:Label ID="lblOfficialZip9" runat="server" CssClass="label" Text="" Visible="false"></asp:Label></i></td>
        <td width="10%" valign="top" align="center"><i><asp:Label ID="lblOfficialMiles9" runat="server" Text="" CssClass="label" style="text-align:center;"></asp:Label></i></td>
    </tr>
    <tr style="background-color:White;">
        <td width="20%" valign="top"><asp:Label ID="lblNo10" runat="server" Text="10.<span style='color:Red'>*</span>" CssClass="label"></asp:Label>&nbsp;
        <asp:TextBox ID="txtOSSAAID10" runat="server" CssClass="textbox" AutoPostBack="True" Width="60%"></asp:TextBox></td>
        <td width="30%" valign="top"><i><asp:Label ID="lblOfficialName10" runat="server" Text="" CssClass="label"></asp:Label></i></td>
        <td width="30%" valign="top"><i><asp:Label ID="lblOfficialCity10" runat="server" CssClass="label" Text=""></asp:Label><asp:Label ID="lblOfficialZip10" runat="server" CssClass="label" Text="" Visible="false"></asp:Label></i></td>
        <td width="10%" valign="top" align="center"><i><asp:Label ID="lblOfficialMiles10" runat="server" Text="" CssClass="label" style="text-align:center;"></asp:Label></i></td>
    </tr>
    <tr style="background-color:Silver;">
        <td width="20%" valign="top"><asp:Label ID="lblNo11" runat="server" Text="11.<span style='color:Red'>*</span>" CssClass="label"></asp:Label>&nbsp;
        <asp:TextBox ID="txtOSSAAID11" runat="server" CssClass="textbox" AutoPostBack="True" Width="60%"></asp:TextBox></td>
        <td width="30%" valign="top"><i><asp:Label ID="lblOfficialName11" runat="server" Text="" CssClass="label"></asp:Label></i></td>
        <td width="30%" valign="top"><i><asp:Label ID="lblOfficialCity11" runat="server" CssClass="label" Text=""></asp:Label><asp:Label ID="lblOfficialZip11" runat="server" CssClass="label" Text="" Visible="false"></asp:Label></i></td>
        <td width="10%" valign="top" align="center"><i><asp:Label ID="lblOfficialMiles11" runat="server" Text="" CssClass="label" style="text-align:center;"></asp:Label></i></td>
    </tr>
    <tr style="background-color:White;">
        <td width="20%" valign="top"><asp:Label ID="lblNo12" runat="server" Text="12.<span style='color:Red'>*</span>" CssClass="label"></asp:Label>&nbsp;
        <asp:TextBox ID="txtOSSAAID12" runat="server" CssClass="textbox" AutoPostBack="True" Width="60%"></asp:TextBox></td>
        <td width="30%" valign="top"><i><asp:Label ID="lblOfficialName12" runat="server" Text="" CssClass="label"></asp:Label></i></td>
        <td width="30%" valign="top"><i><asp:Label ID="lblOfficialCity12" runat="server" CssClass="label" Text=""></asp:Label><asp:Label ID="lblOfficialZip12" runat="server" CssClass="label" Text="" Visible="false"></asp:Label></i></td>
        <td width="10%" valign="top" align="center"><i><asp:Label ID="lblOfficialMiles12" runat="server" Text="" CssClass="label" style="text-align:center;"></asp:Label></i></td>
    </tr>
    <tr style="background-color:Silver;">
        <td width="20%" valign="top"><asp:Label ID="lblNo13" runat="server" Text="13.<span style='color:Red'>*</span>" CssClass="label"></asp:Label>&nbsp;
        <asp:TextBox ID="txtOSSAAID13" runat="server" CssClass="textbox" AutoPostBack="True" Width="60%"></asp:TextBox></td>
        <td width="30%" valign="top"><i><asp:Label ID="lblOfficialName13" runat="server" Text="" CssClass="label"></asp:Label></i></td>
        <td width="30%" valign="top"><i><asp:Label ID="lblOfficialCity13" runat="server" CssClass="label" Text=""></asp:Label><asp:Label ID="lblOfficialZip13" runat="server" CssClass="label" Text="" Visible="false"></asp:Label></i></td>
        <td width="10%" valign="top" align="center"><i><asp:Label ID="lblOfficialMiles13" runat="server" Text="" CssClass="label" style="text-align:center;"></asp:Label></i></td>
    </tr>
    <tr style="background-color:White;">
        <td width="20%" valign="top"><asp:Label ID="lblNo14" runat="server" Text="14.<span style='color:Red'>*</span>" CssClass="label"></asp:Label>&nbsp;
        <asp:TextBox ID="txtOSSAAID14" runat="server" CssClass="textbox" AutoPostBack="True" Width="60%"></asp:TextBox></td>
        <td width="30%" valign="top"><i><asp:Label ID="lblOfficialName14" runat="server" Text="" CssClass="label"></asp:Label></i></td>
        <td width="30%" valign="top"><i><asp:Label ID="lblOfficialCity14" runat="server" CssClass="label" Text=""></asp:Label><asp:Label ID="lblOfficialZip14" runat="server" CssClass="label" Text="" Visible="false"></asp:Label></i></td>
        <td width="10%" valign="top" align="center"><i><asp:Label ID="lblOfficialMiles14" runat="server" Text="" CssClass="label" style="text-align:center;"></asp:Label></i></td>
    </tr>
    <tr style="background-color:Silver;">
        <td width="20%" valign="top"><asp:Label ID="lblNo15" runat="server" Text="15.<span style='color:Red'>*</span>" CssClass="label"></asp:Label>&nbsp;
        <asp:TextBox ID="txtOSSAAID15" runat="server" CssClass="textbox" AutoPostBack="True" Width="60%"></asp:TextBox></td>
        <td width="30%" valign="top"><i><asp:Label ID="lblOfficialName15" runat="server" Text="" CssClass="label"></asp:Label></i></td>
        <td width="30%" valign="top"><i><asp:Label ID="lblOfficialCity15" runat="server" CssClass="label" Text=""></asp:Label><asp:Label ID="lblOfficialZip15" runat="server" CssClass="label" Text="" Visible="false"></asp:Label></i></td>
        <td width="10%" valign="top" align="center"><i><asp:Label ID="lblOfficialMiles15" runat="server" Text="" CssClass="label" style="text-align:center;"></asp:Label></i></td>
    </tr>
</table>

<table id="editSignature" width="750px">
    <tr style="background-image:url('../images/black_bg.gif'); height:32px;"><td colspan="4"><asp:Label ID="Label12" Width="100%" CssClass="shadedheader" ForeColor="White" Font-Bold="true" runat="server" style="text-align:center;" Text="PARTICIPATING DISTRICT SCHOOLS REPRESENTATIVES (STEP 2)"></asp:Label></td></tr>
    <tr style="background-color:Maroon;"><td colspan="4"><asp:Label ID="Label5" Width="100%" CssClass="text" runat="server" style="text-align:center; color:White; font-weight:bold; font-family: Verdana; font-size:10pt;" Text="Please list a representative from each school that was involved in the selection process.<br>List <u>WILL NOT</u> be accepted without:<br>&nbsp;&nbsp;1) Fifteen officials<br>&nbsp;&nbsp;2) Names of representatives from each school."></asp:Label></td></tr>
    <tr style="background-color:Black;">
        <td width="20%" valign="top">&nbsp;&nbsp;</td>
        <td width="35%" valign="top" align="center"><asp:Label ID="chris" runat="server" Text="Signature" CssClass="label" ForeColor="White" Font-Bold="true"></asp:Label></td>
        <td width="10%" valign="top">&nbsp;&nbsp;</td>
        <td width="35%" valign="top" align="center"><asp:Label ID="ellen" runat="server" Text="School" CssClass="label" ForeColor="White" Font-Bold="true"></asp:Label></td>
    </tr>
    <tr style="background-color:Silver;">
        <td width="20%" valign="top"><asp:Label ID="lbl100" runat="server" 
                Text="Site Manager: <span style='color:Red'>*</span>" CssClass="label"></asp:Label></td>
        <td width="35%" valign="top"><asp:TextBox ID="txtSignature11" runat="server" CssClass="textbox" Width="95%"></asp:TextBox></td>
        <td width="10%" valign="top">&nbsp;&nbsp;</td>
        <td width="35%" valign="top"><asp:TextBox ID="txtSignature12" runat="server" CssClass="textbox" Width="95%"></asp:TextBox></td>
    </tr>
    <tr style="background-color:White;">
        <td width="20%" valign="top"><asp:Label ID="Label6" runat="server" Text="Representative: <span style='color:Red'>*</span>" CssClass="label"></asp:Label></td>
        <td width="35%" valign="top"><asp:TextBox ID="txtSignature21" runat="server" CssClass="textbox" Width="95%"></asp:TextBox></td>
        <td width="10%" valign="top">&nbsp;&nbsp;</td>
        <td width="35%" valign="top"><asp:TextBox ID="txtSignature22" runat="server" CssClass="textbox" Width="95%"></asp:TextBox></td>
    </tr>
    <tr style="background-color:Silver;">
        <td width="20%" valign="top"><asp:Label ID="Label8" runat="server" Text="Representative: <span style='color:Red'>*</span>" CssClass="label"></asp:Label></td>
        <td width="35%" valign="top"><asp:TextBox ID="txtSignature31" runat="server" CssClass="textbox" Width="95%"></asp:TextBox></td>
        <td width="10%" valign="top">&nbsp;&nbsp;</td>
        <td width="35%" valign="top"><asp:TextBox ID="txtSignature32" runat="server" CssClass="textbox" Width="95%"></asp:TextBox></td>
    </tr>
    <tr style="background-color:White;">
        <td width="20%" valign="top"><asp:Label ID="Label9" runat="server" Text="Representative: <span style='color:Red'>*</span>" CssClass="label"></asp:Label></td>
        <td width="35%" valign="top"><asp:TextBox ID="txtSignature41" runat="server" CssClass="textbox" Width="95%"></asp:TextBox></td>
        <td width="10%" valign="top">&nbsp;&nbsp;</td>
        <td width="35%" valign="top"><asp:TextBox ID="txtSignature42" runat="server" CssClass="textbox" Width="95%"></asp:TextBox></td>
    </tr>
    <tr style="background-color:Silver;">
        <td width="20%" valign="top"><asp:Label ID="Label10" runat="server" Text="Representative: " CssClass="label"></asp:Label></td>
        <td width="35%" valign="top"><asp:TextBox ID="txtSignature51" runat="server" CssClass="textbox" Width="95%"></asp:TextBox></td>
        <td width="10%" valign="top">&nbsp;&nbsp;</td>
        <td width="35%" valign="top"><asp:TextBox ID="txtSignature52" runat="server" CssClass="textbox" Width="95%"></asp:TextBox></td>
    </tr>
    <tr style="background-color:White;">
        <td width="20%" valign="top"><asp:Label ID="Label11" runat="server" Text="Representative: " CssClass="label"></asp:Label></td>
        <td width="35%" valign="top"><asp:TextBox ID="txtSignature61" runat="server" CssClass="textbox" Width="95%"></asp:TextBox></td>
        <td width="10%" valign="top">&nbsp;&nbsp;</td>
        <td width="35%" valign="top"><asp:TextBox ID="txtSignature62" runat="server" CssClass="textbox" Width="95%"></asp:TextBox></td>
    </tr>
    <tr style="background-image:url('../images/black_bg.gif'); height:32px;"><td colspan="4"><asp:Label ID="Label16" Width="100%" CssClass="shadedheader" ForeColor="White" Font-Bold="true" runat="server" style="text-align:center;" Text="SAVE CHANGES (STEP 3)"></asp:Label></td></tr>
    <tr><td colspan="4" style="background-color:Yellow;"><asp:Label ID="Label23" CssClass="label" runat="server" Text="" style="color:Red; font-weight:bold; font-size:14pt;">NOW, GO BACK TO THE TOP OF THIS PAGE AND CLICK 'SAVE CHANGES' TO SAVE YOUR INFORMATION...(PLEASE NOTE, THERE WILL BE NO NEED TO FAX DOCUMENTS TO OUR OFFICES)...</asp:Label></td></tr>
</table>
</ContentTemplate>
</asp:UpdatePanel>

