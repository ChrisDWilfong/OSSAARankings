<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EntryFormsLog.aspx.vb" Inherits="OSSAARankings.EntryFormsLog" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
    <div>
        <telerik:RadGrid ID="RadGrid1" runat="server" CellSpacing="-1" DataSourceID="SqlDataSource1" GridLines="Both" AllowSorting="true">
<GroupingSettings CollapseAllTooltip="Collapse all groups" ></GroupingSettings>
            <MasterTableView DataSourceID="SqlDataSource1">
            </MasterTableView>
        </telerik:RadGrid>    
    </div>
    </form>
        
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:OSSAAServerConnectionString %>" 
            SelectCommand="SELECT TOP 500 * FROM prodLogEntryForms ORDER BY Id DESC">
        </asp:SqlDataSource>
</body>
</html>
