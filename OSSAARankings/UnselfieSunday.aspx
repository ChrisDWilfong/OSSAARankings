<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="UnselfieSunday.aspx.vb" Inherits="OSSAARankings.UnselfieSunday" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>UnselifeSunday.com</title>
    <style type="text/css">
        .styleHeader
        {
            font-family:Segoe UI, Helvetica, Helvetica Neue, Lucida Grande, Arial, Verdana, sans-serif;
            font-size:xx-large;
            font-weight:bold;
            color: White;
        }
        .style1
        {
            font-family:Segoe UI, Helvetica, Helvetica Neue, Lucida Grande, Arial, Verdana, sans-serif;
            font-size:large;
            color: Yellow;
        }
        .style2
        {
            font-family:Segoe UI, Helvetica, Helvetica Neue, Lucida Grande, Arial, Verdana, sans-serif;
            font-size:large;
            color: Blue;
        }                
    </style>
</head>
<body style="background-color:Maroon;">
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label2" runat="server" Text="UnselfieSunday.com" CssClass="styleHeader"></asp:Label><br />
        <asp:Label ID="Label1" runat="server" Text="Coming Soon..." CssClass="style1"></asp:Label><br />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="mailto:madison@unselfieSunday.com" CssClass="style2">Email us at Madison@unselfieSunday.com</asp:HyperLink>
    </div>
    </form>
</body>
</html>
