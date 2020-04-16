<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RegistrationA.aspx.vb" Inherits="OSSAARankings.RegistrationA" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Officials Registration : Arbiter</title>
    <link href="Officials.css" rel="stylesheet" type="text/css" />
    <link href='http://fonts.googleapis.com/css?family=Oswald' rel='stylesheet' type='text/css' />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Table runat="server">
            <asp:TableRow ID="rowStep">
                <asp:TableCell>
                    <asp:Label runat="server" ID="lblStepPortal" Text="OSSAA Officials Registration : FINAL STEP" CssClass="labelStep" >
                    </asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowButtons" HorizontalAlign="left">
                <asp:TableCell>
                    <asp:Label runat="server" ID="lblMessage" Font-Names="Oswald" Font-Size="X-Large" Text="FIRST, complete the registration process below, THEN click the appropriate ORANGE button below."></asp:Label><br />
                    <asp:Button runat="server" ID="cmdRegister" Text="THIS REGISTRATION COMPLETE" CssClass="button" Width="325px" />&nbsp;&nbsp;
                    <asp:Button runat="server" ID="cmdRegister1" Text="I WILL COMPLETE THIS REGISTRATION LATER" CssClass="button" Width="450px" />
                    <asp:Button runat="server" ID="cmdGoHome" Text="CLICK HERE TO RETURN TO PORTAL HOME" CssClass="button" Width="450px" Visible="false" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowIFrame">
                <asp:TableCell>
                    <%= Session("iframeURL") %> 
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
    </form>
</body>
</html>
