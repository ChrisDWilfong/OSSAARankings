<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="NameSearch.aspx.vb" Inherits="OSSAARankings.NameSearch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

</head>
<body style="font-family:Arial; font-size: small;">
    <form id="form1" runat="server">
    <div style="height:40px;">
        <asp:Label ID="lblFirstName" runat="server" Text="First Name : " Width="120px"></asp:Label>
        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>&nbsp;&nbsp;<br />
        <asp:Label ID="lblLastName" runat="server" Text="Last Name : " Width="120px"></asp:Label>
        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox><br /><br />
    </div>
    <div style="height:40px;">
        <asp:Button ID="cmdSearch" runat="server" Text="Search Name" /><br /><br />
    </div>
    <div>
        <asp:Label ID="lblResults" runat="server" Text="NO RESULTS" ></asp:Label>
    </div>
    </form>
</body>
</html>
