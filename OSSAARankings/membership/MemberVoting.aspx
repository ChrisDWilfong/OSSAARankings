<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="SiteMembership.Master" CodeBehind="MemberVoting.aspx.vb" Inherits="OSSAARankings.MemberVoting" %>
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
    </table>
   <table id="tableContent" style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="lblMulti" runat="server" Text="Select School : " CssClass="label"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="cboMulti" runat="server" CssClass="content" 
                    AutoPostBack="True" BackColor="#FFFF99" Width="300px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblPosition" runat="server" Text="Position : " CssClass="label"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="content" 
                    AutoPostBack="True">
                    <asp:ListItem>Select...</asp:ListItem>
                    <asp:ListItem>Superintendent</asp:ListItem>
                    <asp:ListItem>High School Principal</asp:ListItem>
                    <asp:ListItem>Athletic Director</asp:ListItem>
                    <asp:ListItem>Assistant Superintendent</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="Label2" runat="server" Text="&nbsp;or other&nbsp;" CssClass="label"></asp:Label>
                <asp:TextBox ID="txtOther" runat="server" CssClass="content" 
                    Width="181px"></asp:TextBox>            
                <asp:Label ID="lblPositionRequired" runat="server" Font-Names="Century Gothic" 
                    Font-Size="8pt" ForeColor="Red" Text="Position is Required" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr><td>&nbsp;</td></tr>
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
                    Width="168px" Enabled="False"></asp:TextBox>
                <asp:TextBox ID="txtMailingStateSup" runat="server" CssClass="content" 
                    Width="45px" ReadOnly="True" Enabled="False"></asp:TextBox>
                <asp:TextBox ID="txtMailingZipSup" runat="server" CssClass="content" 
                    Width="85px" Enabled="False"></asp:TextBox>
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
                    Width="168px" Enabled="False"></asp:TextBox>
                <asp:TextBox ID="txtPhysicalState" runat="server" CssClass="content" 
                    Width="45px" ReadOnly="True" Enabled="False"></asp:TextBox>
                <asp:TextBox ID="txtPhysicalZip" runat="server" CssClass="content" 
                    Width="85px" Enabled="False"></asp:TextBox>
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
                Text="Cancel Changes" CausesValidation="False" Width="130px" />
            </td></tr>
    </table>

    <table id="tableFooter" style="width: 100%;">
        <tr>
        <td>
            <asp:Label ID="lblCopyright" runat="server" Font-Size="X-Small" Text="Copyright © 2014 OSSAA. All rights reserved.  "></asp:Label><a href="http://www.ossaa.com" target="_blank"><span style="font-family: Century Gothic; Font-Size:X-Small;">OSSAA Home Page</span></a>
        </td>
        </tr>
    </table>
</asp:Content>
