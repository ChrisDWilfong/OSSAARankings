<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SchoolSportsPage.aspx.vb" Inherits="OSSAARankings.SchoolSportsPage" %>

<%@ Register Assembly="Infragistics4.Web.v10.2, Version=10.2.20102.1011, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.NavigationControls" TagPrefix="ig" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Table runat="server" >
        <asp:TableRow>
            <asp:TableCell><ig:WebExplorerBar ID="WebExplorerBarSchedules" runat="server" Width="250px" StyleSetName="Office2007Black"></ig:WebExplorerBar></asp:TableCell>
            <asp:TableCell><ig:WebExplorerBar ID="WebExplorerBarRosters" runat="server" Width="250px" StyleSetName="Office2007Black"></ig:WebExplorerBar></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <div>
    <asp:PlaceHolder runat="server" ID="PlaceHolderRightPane"></asp:PlaceHolder>
    <div>
        <asp:Label ID="lblFooter" Font-Names="Verdana" Font-Size="X-Small" runat="server" Text="OSSAARankings.com"></asp:Label>
    </div>     
    </div>
    </form>
</body>
</html>
