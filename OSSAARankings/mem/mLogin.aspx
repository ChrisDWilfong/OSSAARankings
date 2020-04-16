<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="mLogin.aspx.vb" Inherits="OSSAARankings.mLogin" ClientTarget="uplevel"  %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<link href="../mem/mem.css" rel="stylesheet" type="text/css" />
<head runat="server">
    <title>OSSAARankings.com Coaches Login Page</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" >
    <link href="../css/mbase.css" rel="stylesheet" type="text/css" />
    <link href="../css/mlayout.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<asp:Panel ID="PanelLogin" runat="server" >
<asp:UpdatePanel ID="UpdatePanelHome" runat="server" UpdateMode="Conditional">
 <ContentTemplate>
  <div class="row">
    <div class="services-wrapper">
        <div class="col first">
            <h3 style="color:Yellow;">OSSAARANKINGS.COM</h3>
            <asp:Label ID="lblHeading" runat="server" Text="Coaches Login" CssClass="memHeader"></asp:Label>
        </div>
        <div class="col first">
            <h2><i class="icon-none"></i>&nbsp;Username</h2>
            <asp:TextBox ID="txtUserName" runat="server" Width="100%" ></asp:TextBox>
        </div>
        <div class="col first">                        
            <h2><i class="icon-none"></i>&nbsp;Password</h2>
            <asp:TextBox ID="txtPassword" runat="server"  TextMode="Password" Width="100%"></asp:TextBox>
        </div>
        <div class="col first">
            <asp:Button ID="cmdLogin" runat="server" Text="Login" Width="100%" />
        </div>
        <div class="col first">
            <asp:Button ID="cmdForgot" runat="server" Text="Forgot Password" Width="100%"  />
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Font-Size="Medium"></asp:Label>
        </div>
        <div class="col first">
            <asp:Label ID="Label1" runat="server" Text="<strong>YOUR LOGIN INFORMATION IS SETUP BY YOUR ATHLETIC DIRECTOR</strong><br>If you do not have your login information, please contact your Athletic Director."></asp:Label>
        </div>  
        </div>
        </div>  
            </ContentTemplate>
        </asp:UpdatePanel>
        </asp:Panel>
    </form>
</body>
</html>
