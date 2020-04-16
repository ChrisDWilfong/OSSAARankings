<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="SiteOSSAAAdmin.Master" CodeBehind="MemberInfoOSSAA.aspx.vb" Inherits="OSSAARankings.MemberInfoOSSAA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table id="tableDetail" style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="lblStep" runat="server" Text="" Font-Bold="True" ForeColor="Red" Font-Size="Large"
                    CssClass="objectTitle"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblTitle" runat="server" Text="" Font-Bold="True" 
                    CssClass="objectTitle"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
   <table id="tableContent" style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="lblSupName" runat="server" Text="First/Last Name : " 
                    CssClass="label"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="cboMrMsSup" runat="server" CssClass="content">
                    <asp:ListItem>Select...</asp:ListItem>
                    <asp:ListItem>Mr</asp:ListItem>
                    <asp:ListItem>Ms</asp:ListItem>
                    <asp:ListItem>Dr</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtFirstNameSup" runat="server" CssClass="content" 
                    Width="181px"></asp:TextBox>
                <asp:TextBox ID="txtLastNameSup" runat="server" CssClass="content" 
                    Width="168px"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToValidate="cboMrMsSup" ErrorMessage="Mr/Ms Required" 
                    Font-Names="Century Gothic" Font-Size="8pt" ForeColor="Red" Operator="NotEqual" 
                    ValueToCompare="Select..."></asp:CompareValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtFirstNameSup" ErrorMessage="Required" 
                    Font-Names="Century Gothic" Font-Size="8pt" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="txtLastNameSup" ErrorMessage="Required" 
                    Font-Names="Century Gothic" Font-Size="8pt" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:Label ID="lblMrMs" runat="server" ForeColor="White" Text="Select..."></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblMailingAddress" runat="server" 
                    Text="Mailing Address : " CssClass="label"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtMailingAddressSup" runat="server" CssClass="content" 
                    Width="260px"></asp:TextBox>
                <asp:TextBox ID="txtMailingCitySup" runat="server" CssClass="content" 
                    Width="168px"></asp:TextBox>
                <asp:TextBox ID="txtMailingStateSup" runat="server" CssClass="content" 
                    Width="45px" ReadOnly="True" Enabled="False"></asp:TextBox>
                <asp:TextBox ID="txtMailingZipSup" runat="server" CssClass="content" 
                    Width="85px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ControlToValidate="txtMailingAddressSup" ErrorMessage="Required" 
                    Font-Names="Century Gothic" Font-Size="8pt" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                    ControlToValidate="txtMailingCitySup" ErrorMessage="Required" 
                    Font-Names="Century Gothic" Font-Size="8pt" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                    ControlToValidate="txtMailingZipSup" ErrorMessage="Required" 
                    Font-Names="Century Gothic" Font-Size="8pt" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" 
                    Text="Physical Address : " CssClass="label"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPhysicalAddress" runat="server" CssClass="content" 
                    Width="260px"></asp:TextBox>
                <asp:TextBox ID="txtPhysicalCity" runat="server" CssClass="content" 
                    Width="168px"></asp:TextBox>
                <asp:TextBox ID="txtPhysicalState" runat="server" CssClass="content" 
                    Width="45px" ReadOnly="True" Enabled="False"></asp:TextBox>
                <asp:TextBox ID="txtPhysicalZip" runat="server" CssClass="content" 
                    Width="85px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtPhysicalAddress" ErrorMessage="Required" 
                    Font-Names="Century Gothic" Font-Size="8pt" ForeColor="Red"></asp:RequiredFieldValidator>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                    ControlToValidate="txtPhysicalCity" ErrorMessage="Required" 
                    Font-Names="Century Gothic" Font-Size="8pt" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                    ControlToValidate="txtPhysicalZip" ErrorMessage="Required" 
                    Font-Names="Century Gothic" Font-Size="8pt" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblSupEmail" runat="server" Text="Email : " CssClass="label"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtSchoolEmailSup" runat="server" CssClass="content" 
                    Width="427px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                    ControlToValidate="txtSchoolEmailSup" ErrorMessage="Email is Required" 
                    Font-Names="Century Gothic" Font-Size="8pt" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                    ControlToValidate="txtSchoolEmailSup" ErrorMessage="Invalid Email Address Typed" 
                    Font-Names="Century Gothic" Font-Size="8pt" ForeColor="Red" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td><asp:Label ID="lblMessage100" runat="server" Text="Changing your email address will also change your Username during login." CssClass="label" style="color:Navy; font-weight:bold; font-style:italic; "></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblSupSchoolPhone" runat="server" Text="School Phone #/Ext : " 
                    CssClass="label"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtSchoolPhoneSup" runat="server" CssClass="content" 
                    Width="234px"></asp:TextBox>&nbsp;
                <asp:TextBox ID="txtSchoolPhoneSupExt" runat="server" CssClass="content" 
                    Width="85px"></asp:TextBox>
            
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="txtSchoolPhoneSup" ErrorMessage="Invalid phone number typed" 
                    Font-Names="Century Gothic" Font-Size="8pt" ForeColor="Red" 
                    ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtSchoolPhoneSup" ErrorMessage="School Phone Required" 
                    Font-Names="Century Gothic" Font-Size="8pt" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblSupFax" runat="server" Text="School Fax # : " 
                    CssClass="label"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtSchoolFaxSup" runat="server" CssClass="content" 
                    Width="234px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtSchoolFaxSup" ErrorMessage="Fax Required" 
                    Font-Names="Century Gothic" Font-Size="8pt" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="txtSchoolFaxSup" ErrorMessage="Invalid phone number typed" 
                    Font-Names="Century Gothic" Font-Size="8pt" ForeColor="Red" 
                    ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblSupCell" runat="server" Text="Cell # : " 
                    CssClass="label"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCellSup" runat="server" CssClass="content" 
                    Width="234px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                    ControlToValidate="txtCellSup" ErrorMessage="Invalid phone number typed" 
                    Font-Names="Century Gothic" Font-Size="8pt" ForeColor="Red" 
                    ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr><td>
            <asp:Label ID="lblMessage" runat="server" Font-Names="Century Gothic" 
                ForeColor="Red"></asp:Label>
            </td><td>
            <asp:Button ID="cmdSaveChanges" runat="server" CssClass="button" 
                Text="Save Changes" />&nbsp;
                <asp:Button ID="cmdCancelChanges" runat="server" CssClass="button" 
                Text="Cancel Changes" CausesValidation="False" Width="130px" />
            </td></tr>
    </table>
    <table id="tableFooter" style="width: 100%;">
        <tr><td align="center">&nbsp;</td></tr>
        <tr><td align="right">
            <asp:Button ID="cmdChangeUsername" runat="server" CssClass="button" 
                Text="Change Your Password" CausesValidation="False" />
                </td></tr>
        <tr>
        <td>
            <asp:Label ID="lblCopyright" runat="server" Font-Size="X-Small" Text="Copyright © 2014 OSSAA. All rights reserved.  "></asp:Label><a href="http://www.ossaa.com" target="_blank"><span style="font-family: Century Gothic; Font-Size:X-Small;">OSSAA Home Page</span></a>
        </td>
        </tr>
        <tr>
        <td>
            &nbsp;</td>
        </tr>
    </table>


</asp:Content>
