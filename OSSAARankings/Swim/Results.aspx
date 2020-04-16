<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Results.aspx.vb" Inherits="OSSAARankings.Results" %>

<%@ Register Src="~/mem/ucSwimResults.ascx" TagPrefix="uc1" TagName="ucSwimResults" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>OSSAA Swim Meet Results</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no" />
    <link href="~/mem/mem.css" rel="stylesheet" type="text/css" />
    <link href="~/mem/popup.css" rel="stylesheet" type="text/css" />
    <link href="~/mem/entryform.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <uc1:ucSwimResults runat="server" ID="ucSwimResults" />
    </div>
    </form>
</body>
</html>
