<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="SiteEmpty.Master" CodeBehind="MemberChangeUsername.aspx.vb" Inherits="OSSAARankings.MemberChangeUsername" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
                <table style="width:80%;">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" CssClass="headerHeader" 
                                Text="Change Your Username (must be a valid Email address)"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblUserName2" runat="server" Text="Current Username : " 
                                Width="150px" CssClass="label"></asp:Label>
                            <asp:TextBox ID="txtUserNameCurrent" runat="server" Width="250px" 
                                CssClass="textEntry"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblUserName" runat="server" Text="New Username : " Width="150px" 
                                CssClass="label"></asp:Label>
                            <asp:TextBox ID="txtUserName" runat="server" Width="250px" CssClass="textEntry"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                    ControlToValidate="txtUserName" ErrorMessage="Invalid Email" 
                    Font-Names="Century Gothic" Font-Size="8pt" ForeColor="Red" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblUserName1" runat="server" Text="Retype Username : " 
                                Width="150px" CssClass="label"></asp:Label>
                            <asp:TextBox ID="txtUserName1" runat="server" Width="250px" 
                                CssClass="textEntry"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
                    ControlToValidate="txtUserName1" ErrorMessage="Invalid Email" 
                    Font-Names="Century Gothic" Font-Size="8pt" ForeColor="Red" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="cmdSaveUsername" runat="server" Text="Save Username" CssClass="button" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" CssClass="headerHeader" 
                                Text="Change Your Password"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblUserName5" runat="server" Text="Current Password : " 
                                Width="150px" CssClass="label"></asp:Label>
                            <asp:TextBox ID="txtPasswordCurrent" runat="server" Width="250px" 
                                CssClass="textEntry"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblUserName3" runat="server" Text="New Password : " 
                                Width="150px" CssClass="label"></asp:Label>
                            <asp:TextBox ID="txtPassword" runat="server" Width="250px" CssClass="textEntry"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblUserName4" runat="server" Text="Retype Password : " 
                                Width="150px" CssClass="label"></asp:Label>
                            <asp:TextBox ID="txtPassword1" runat="server" Width="250px" 
                                CssClass="textEntry"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="cmdSavePassword" runat="server" Text="Save Password" 
                                CssClass="button" />
                        &nbsp;&nbsp;
                            <asp:Label ID="lblMessage" runat="server" Font-Names="Verdana" Font-Size="9pt" 
                                ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="cmdDone" runat="server" Text="DONE" CssClass="button" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
</asp:Content>
