<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="SiteEmpty.Master" CodeBehind="MemberChangeUsername1.aspx.vb" Inherits="OSSAARankings.MemberChangeUsername1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:ChangePassword ID="ChangePassword1" runat="server" BackColor="#F7F6F3" BorderColor="#E6E2D8"
        BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" Font-Names="Verdana"
        Font-Size="11pt" OnChangedPassword="ChangePassword1_ChangedPassword" Style="position: static"
        Width="413px">
        <CancelButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid"
            BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
        <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
        <PasswordHintStyle Font-Italic="True" ForeColor="#888888" />
        <ChangePasswordButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid"
            BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
        <ContinueButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid"
            BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
        <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
        <ChangePasswordTemplate>
            <table border="0" cellpadding="4" cellspacing="0" style="border-collapse: collapse">
                <tr>
                    <td >
                        <table  border="0" cellpadding="0" style="width: 413px">
                            <tr>
                                <td align="center" colspan="2" style=" color: white;
                                    background-color: #507cd1; font-weight: bold; height: 20px; text-align: center;">
                                    Change Your Password</td>
                            </tr>
                            <tr>
                                <td align="right">
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="CurrentPasswordLabel" runat="server" AssociatedControlID="CurrentPassword"
                                        Font-Bold="False">Password:</asp:Label></td>
                                <td>
                                    <asp:TextBox ID="CurrentPassword" runat="server" Font-Size="Small" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword"
                                        ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="NewPasswordLabel" runat="server" AssociatedControlID="NewPassword"
                                        Font-Bold="False">New Password:</asp:Label></td>
                                <td>
                                    <asp:TextBox ID="NewPassword" runat="server" Font-Size="Small" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword"
                                        ErrorMessage="New Password is required." ToolTip="New Password is required."
                                        ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="ConfirmNewPasswordLabel" runat="server" AssociatedControlID="ConfirmNewPassword"
                                        Font-Bold="False">Confirm New Password:</asp:Label></td>
                                <td>
                                    <asp:TextBox ID="ConfirmNewPassword" runat="server" Font-Size="Small" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword"
                                        ErrorMessage="Confirm New Password is required." ToolTip="Confirm New Password is required."
                                        ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword"
                                        ControlToValidate="ConfirmNewPassword" Display="Dynamic" ErrorMessage="The Confirm New Password must match the New Password entry."
                                        Font-Bold="False" ValidationGroup="ChangePassword1"></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="color: red; height: 18px;">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="color: red">
                                </td>
                            </tr>
                            <tr>
                                <td align="right" colspan="2" style="text-align: center">
                                    <asp:Button ID="ChangePasswordPushButton" runat="server" BackColor="#FFFBFF" BorderColor="#CCCCCC"
                                        BorderStyle="Solid" BorderWidth="1px" CommandName="ChangePassword" Font-Bold="True"
                                        Font-Names="Verdana" Font-Size="Small" ForeColor="#284775" Text="Change Password"
                                        ValidationGroup="ChangePassword1" />
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ChangePasswordTemplate>
        <TextBoxStyle Font-Size="0.8em" />
        <SuccessTemplate>
            <table border="0" cellpadding="4" cellspacing="0" style="border-collapse: collapse">
                <tr>
                    <td>
                        <table border="0" cellpadding="0" style="width: 413px">
                            <tr>
                                <td align="center" colspan="2" style="font-weight: bold; font-size: 0.9em; color: white;
                                    background-color: #5d7b9d">
                                    <span style="font-size: 1.2em">Change Password Complete</span></td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <strong>Your password has been changed!<br />
                                        <br />
                                        Please Check your Email.</strong></td>
                            </tr>
                            <tr>
                                <td align="right" colspan="2">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </SuccessTemplate>
    </asp:ChangePassword></asp:Content>
