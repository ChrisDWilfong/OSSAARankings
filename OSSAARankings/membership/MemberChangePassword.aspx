<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="SiteEmpty.Master" CodeBehind="MemberChangePassword.aspx.vb" Inherits="OSSAARankings.MemberChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
                <table style="width:80%;">
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
                                CssClass="textEntry" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblUserName3" runat="server" Text="New Password : " 
                                Width="150px" CssClass="label"></asp:Label>
                            <asp:TextBox ID="txtPassword" runat="server" Width="250px" CssClass="textEntry" 
                                TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblUserName4" runat="server" Text="Retype Password : " 
                                Width="150px" CssClass="label"></asp:Label>
                            <asp:TextBox ID="txtPassword1" runat="server" Width="250px" 
                                CssClass="textEntry" TextMode="Password"></asp:TextBox>
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
