<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Landing.aspx.vb" Inherits="OSSAARankings.Landing" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>OSSAARankings.com</title>
    <link href='http://fonts.googleapis.com/css?family=Oswald' rel='stylesheet' type='text/css' />
    <link href='http://fonts.googleapis.com/css?family=Luckiest+Guy' rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Michroma:400,700,300' rel='stylesheet' type='text/css'>
    <link href="http://fonts.googleapis.com/css?family=Lato:100,300,400,700" rel='stylesheet' type='text/css' />
    <meta charset="utf-8">
    <link rel="icon" href="images/favicon.ico" type="image/x-icon">
    <link rel="stylesheet" href="../css/m/grid.css">
    <link rel="stylesheet" href="../css/m/contact-form.css"/>
    <link rel="stylesheet" href="../css/m/style.css">

    <script src="js/jquery.js"></script>
    <script src="js/jquery-migrate-1.2.1.js"></script>
    <script src="js/device.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox runat="server" ReadOnly="true" Text="" ID="lblHeader" Font-Names="Lato" Font-Bold="true" Font-Size="24px" ForeColor="Yellow" BackColor="Black" BorderStyle="None" Width="90%" style="padding-left:20px;" ></asp:TextBox>
        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="mLinkButton" BackColor="Red" ForeColor="Yellow" Font-Bold="true" PostBackUrl="~/Default.aspx" ToolTip="OSSAARankings.com"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton2" runat="server" CssClass="mLinkButton" BackColor="Gray" ForeColor="Yellow" Font-Bold="true" PostBackUrl="http://www.ossaarankings.com/mem/Login.aspx" Text="Coaches Login"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton3" runat="server" CssClass="mLinkButton" BackColor="Gray" ForeColor="Yellow" Font-Bold="true" PostBackUrl="http://www.ossaarankings.com/memad/adLogin.aspx" Text="Athletic Director Login"></asp:LinkButton>
    </div>
    </form>
</body>
</html>
