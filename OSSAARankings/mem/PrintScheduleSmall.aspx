<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PrintScheduleSmall.aspx.vb" Inherits="OSSAARankings.PrintScheduleSmall" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>OSSAARankings.com : Schedule</title>
    <link href="mem.css" rel="stylesheet" type="text/css" />
    <meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Panel ID="PanelScheduleTeamSmall" runat="server" CssClass="panelSmall">
        <asp:PlaceHolder runat="server" ID="PlaceHolderRightPane"></asp:PlaceHolder>
        <asp:Label ID="lblFooter" Font-Names="Verdana" Font-Size="X-Small" runat="server" Text="OSSAARankings.com"></asp:Label>
    </asp:Panel>
    </form>
</body>
</html>
