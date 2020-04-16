<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="LoginChange.aspx.vb" Inherits="OSSAARankings.LoginChange" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<link href="../mem/mem.css" rel="stylesheet" type="text/css" />
<head runat="server">
    <title>Rankings Coaches Login Page</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="panelHome">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:Panel ID="PanelLogin" runat="server" CssClass="panelHome">
        <asp:UpdatePanel ID="UpdatePanelHome" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                    <asp:Table ID="TableHome" runat="server" Width="100%">
                        <asp:TableRow BackColor="DarkMagenta" VerticalAlign="Middle" Height="32"><asp:TableCell><asp:Label ID="lblHeader" runat="server" Text="&nbsp;OSSAARankings.com - Change Coaches Password" CssClass="memHeader" ForeColor="White" BackColor="DarkMagenta" ></asp:Label></asp:TableCell></asp:TableRow>
                        <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
                        <asp:TableRow><asp:TableCell><asp:Label ID="lblHeading" runat="server" Text="Enter Your New Password" CssClass="memHeader"></asp:Label></asp:TableCell></asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label ID="lblUserName" runat="server" CssClass="perInfoLabel" Enabled="false">Username :</asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:TextBox ID="txtUserName" runat="server" CssClass="perInfoText2"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label ID="lblPassword" runat="server" CssClass="perInfoLabel">Password :<span style="color:Red;"> *</span></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="perInfoText2" TextMode="Password"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                            <asp:Button ID="cmdLogin" runat="server" Text="&nbsp;&nbsp;Change Password&nbsp;&nbsp;" CssClass="buttonSave" />&nbsp;&nbsp;
                            <asp:Label ID="lblMessage" runat="server" CssClass="labelMessage"></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
            </ContentTemplate>
        </asp:UpdatePanel>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
