<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="SiteMembership.Master" CodeBehind="MemberInfoJH2.aspx.vb" Inherits="OSSAARankings.MemberInfoJH2" %>
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
                <asp:Label ID="lblSchoolName" runat="server" Text="School Name : " 
                    CssClass="label"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtSchoolName" runat="server" CssClass="content" 
                    Width="427px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                    ControlToValidate="txtSchoolName" ErrorMessage="School Name Required" 
                    Font-Names="Century Gothic" Font-Size="8pt" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblSchoolName0" runat="server" Text="School Type/Grades : " 
                    CssClass="label"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="cboSchoolType" runat="server" CssClass="content">
                    <asp:ListItem>Select...</asp:ListItem>
                    <asp:ListItem>Junior High</asp:ListItem>
                    <asp:ListItem>Middle School</asp:ListItem>
                    <asp:ListItem>Intermediate</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="lblSchoolName1" runat="server" Text="&amp;nbsp;&amp;nbsp;&amp;nbsp;Grades : " 
                    CssClass="label"></asp:Label>
                <asp:DropDownList ID="cboGradeFrom" runat="server" CssClass="content">
                    <asp:ListItem>Select...</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="lblSchoolName2" runat="server" Text="&amp;nbsp;to&amp;nbsp;" 
                    CssClass="label"></asp:Label>
                <asp:DropDownList ID="cboGradeTo" runat="server" CssClass="content">
                    <asp:ListItem>Select...</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                </asp:DropDownList>
                <asp:CompareValidator ID="CompareValidator2" runat="server" 
                    ControlToValidate="cboSchoolType" ErrorMessage="School Type Required" 
                    Font-Names="Century Gothic" Font-Size="8pt" ForeColor="Red" Operator="NotEqual" 
                    ValueToCompare="Select..."></asp:CompareValidator>
                <asp:CompareValidator ID="CompareValidator3" runat="server" 
                    ControlToValidate="cboGradeFrom" ErrorMessage="Grade From Required" 
                    Font-Names="Century Gothic" Font-Size="8pt" ForeColor="Red" Operator="NotEqual" 
                    ValueToCompare="Select..."></asp:CompareValidator>
                <asp:CompareValidator ID="CompareValidator4" runat="server" 
                    ControlToValidate="cboGradeTo" ErrorMessage="Grade To Required" 
                    Font-Names="Century Gothic" Font-Size="8pt" ForeColor="Red" Operator="NotEqual" 
                    ValueToCompare="Select..."></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblSupName" runat="server" Text="Principal First/Last : " 
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
                <asp:Label ID="lblSupEmail" runat="server" Text="Email : " CssClass="label"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtSchoolEmailSup" runat="server" CssClass="content" 
                    Width="427px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                    ControlToValidate="txtSchoolEmailSup" ErrorMessage="Email is Required" 
                    Font-Names="Century Gothic" Font-Size="8pt" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                    ControlToValidate="txtSchoolEmailSup" ErrorMessage="Invalid Email" 
                    Font-Names="Century Gothic" Font-Size="8pt" ForeColor="Red" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
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
                Text="Cancel Changes" CausesValidation="False" Width="130px" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="cmdClearAndSave" runat="server" CssClass="button" 
                Text="Clear Junior High Principal Info" CausesValidation="False" 
                    Visible="False"/>
            </td></tr>
    </table>
    <table id="tableFooter" style="width: 100%;">
        <tr><td>&nbsp;</td></tr>
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
