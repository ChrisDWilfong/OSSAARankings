<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="sendEmails.aspx.vb" Inherits="OSSAARankings.sendEmails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:button ID="cmdSendEmails" runat="server" text="Send Emails" /> <br />
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>   
    </div>
    </form>
</body>
</html>
