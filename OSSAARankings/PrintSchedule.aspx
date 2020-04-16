<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PrintSchedule.aspx.vb" Inherits="OSSAARankings.PrintSchedule1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>OSSAARankings.com : Schedule</title>
    <link href="Rankings.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
    <asp:PlaceHolder runat="server" ID="PlaceHolderRightPane"></asp:PlaceHolder>
    <div>
        <asp:Label ID="lblFooter" Font-Names="Verdana" Font-Size="X-Small" runat="server" Text="OSSAARankings.com"></asp:Label>
    </div>    
    </div>
    </form>
</body>
</html>
