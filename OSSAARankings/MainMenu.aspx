<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MainMenu.aspx.vb" Inherits="OSSAARankings.MainMenu" %>

<%@ Register Assembly="Infragistics4.Web.v10.2, Version=10.2.20102.1011, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.NavigationControls" TagPrefix="ig" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>OSSAARankings.com Main Menu</title>
    <meta name="viewport" content="width=320, maximum-scale=1.0" />
    <meta name="viewport" content="initial-scale=1, user-scalable=no" />
    <style>
        .headerFont 
        {
            font-family: Arial;
            font-size: 14pt;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
    <ig:WebExplorerBar ID="WebExplorerBar1" runat="server" GroupContentsHeight="" StyleSetName="RedPlanet">
        <Groups>
            <ig:ExplorerBarGroup GroupContentsHeight="" Text="Rankings">
            </ig:ExplorerBarGroup>
            <ig:ExplorerBarGroup GroupContentsHeight="" Text="Schedules">
            </ig:ExplorerBarGroup>
            <ig:ExplorerBarGroup GroupContentsHeight="" Text="District Standings">
            </ig:ExplorerBarGroup>
            <ig:ExplorerBarGroup GroupContentsHeight="" Text="Schools">
            </ig:ExplorerBarGroup>
        </Groups>
    </ig:WebExplorerBar>
    </div>
    </form>
</body>
</html>
