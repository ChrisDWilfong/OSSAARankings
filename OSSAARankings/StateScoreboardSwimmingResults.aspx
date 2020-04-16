<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="StateScoreboardSwimmingResults.aspx.vb" Inherits="OSSAARankings.StateScoreboardSwimmingResults" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<head runat="server">
    <title>2017 OSSAA Swimming Championships</title>
</head>

<body bgcolor="#5c5040">
    <form id="frmSwimming" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <telerik:RadMenu ID="RadMenu1" runat="server" ShowToggleHandle="True" 
        Skin="Default" style="top: 0px; left: 0px; height: 173px; width: 636px">
        <Items>
            <telerik:RadMenuItem runat="server" Text="Class 6A">
            </telerik:RadMenuItem>
            <telerik:RadMenuItem runat="server" Text="Class 5A">
            </telerik:RadMenuItem>
        </Items>
    </telerik:RadMenu>
    </form>
</body>
</html>
