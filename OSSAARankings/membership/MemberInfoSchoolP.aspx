<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="SiteP.Master" CodeBehind="MemberInfoSchoolP.aspx.vb" Inherits="OSSAARankings.MemberInfoSchoolP" %>
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
        <tr><td>&nbsp;</td></tr>
    </table>
    <table id="tableContent" style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="lblSchoolName" runat="server" Text="School Name/Mascot : " 
                    CssClass="label"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtSchoolName" runat="server" CssClass="content" Width="359px"></asp:TextBox>
                <asp:TextBox ID="txtSchoolMascot" runat="server" CssClass="content" 
                    Width="180px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtSchoolName" CssClass="validator" 
                    ErrorMessage="School required"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblMailingAddress" runat="server" 
                    Text="Mailing Address/City/Zip : " CssClass="label"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtMailingAddress" runat="server" CssClass="content" 
                    Width="210px" ValidationGroup="MailingInfo"></asp:TextBox>
                <asp:TextBox ID="txtMailingCity" runat="server" CssClass="content" 
                    Width="140px" ValidationGroup="MailingInfo"></asp:TextBox>
                <asp:TextBox ID="txtMailingState" runat="server" CssClass="content" 
                    Width="40px" ReadOnly="True" Enabled="False" ValidationGroup="MailingInfo"></asp:TextBox>
                <asp:TextBox ID="txtMailingZip" runat="server" CssClass="content" Width="85px" 
                    ValidationGroup="MailingInfo"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtMailingAddress" CssClass="validator" 
                    ErrorMessage="Required"></asp:RequiredFieldValidator>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="txtMailingCity" CssClass="validator" 
                    ErrorMessage="Required"></asp:RequiredFieldValidator>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ControlToValidate="txtMailingZip" CssClass="validator" 
                    ErrorMessage="Required"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblSchoolAddress" runat="server" 
                    Text="School Address/City/Zip : " CssClass="label"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtSchoolAddress" runat="server" CssClass="content" 
                    Width="210px"></asp:TextBox>
                <asp:TextBox ID="txtSchoolCity" runat="server" CssClass="content" Width="140px"></asp:TextBox>
                <asp:TextBox ID="txtSchoolState" runat="server" CssClass="content" Width="40px" 
                    ReadOnly="True" Enabled="False" EnableTheming="True"></asp:TextBox>
                <asp:TextBox ID="txtSchoolZip" runat="server" CssClass="content" Width="85px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                    ControlToValidate="txtSchoolAddress" CssClass="validator" 
                    ErrorMessage="Required"></asp:RequiredFieldValidator>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                    ControlToValidate="txtSchoolCity" CssClass="validator" 
                    ErrorMessage="Required"></asp:RequiredFieldValidator>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                    ControlToValidate="txtSchoolZip" CssClass="validator" 
                    ErrorMessage="Required"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblSchoolEmail" runat="server" Text="School Email : " CssClass="label"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtSchoolEmail" runat="server" CssClass="content" 
                    Width="427px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtSchoolEmail" CssClass="validator" 
                    ErrorMessage="Email is required"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                    ControlToValidate="txtSchoolEmail" ErrorMessage="Invalid Email" 
                    Font-Names="Century Gothic" Font-Size="8pt" ForeColor="Red" 
                    EnableTheming="True" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblSchoolWebSite" runat="server" Text="School Website : " CssClass="label"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtSchoolWebSite" runat="server" CssClass="content" Width="427px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtSchoolWebSite" CssClass="validator" 
                    ErrorMessage="Website is required"></asp:RequiredFieldValidator>
            </td>
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
