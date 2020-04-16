<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Admin.aspx.vb" Inherits="OSSAARankings.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label runat="server" ID="lblMessage" ForeColor="Red" Font-Names="Arial"></asp:Label>
            <asp:DropDownList runat="server" ID="cboClasses">
                <asp:ListItem Value="NONE" Text="Select..."></asp:ListItem>
                <asp:ListItem Value="6A" Text="6A"></asp:ListItem>
                <asp:ListItem Value="5A" Text="5A"></asp:ListItem>
                <asp:ListItem Value="4A" Text="4A"></asp:ListItem>
                <asp:ListItem Value="3A" Text="3A"></asp:ListItem>
                <asp:ListItem Value="2A" Text="2A"></asp:ListItem>
                <asp:ListItem Value="A" Text="A"></asp:ListItem>
            </asp:DropDownList><br />
            <asp:Button runat="server" ID="cmdProcess" Text="Process Zip Codes" />
        </div>
    </form>
</body>
</html>
