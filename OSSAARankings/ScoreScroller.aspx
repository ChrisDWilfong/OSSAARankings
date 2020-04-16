<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ScoreScroller.aspx.vb" Inherits="OSSAARankings.ScoreScroller" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>    
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/scroller.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/scroller.js" type="text/javascript"></script>
    <link href='http://fonts.googleapis.com/css?family=Oswald' rel='stylesheet' type='text/css' />
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
    <div class="demo-containers">
        <div class="demo-container">
            <asp:DropDownList runat="server" ID="DropDownClass" AutoPostBack="true" Font-Names="Oswald" ForeColor="Navy" Font-Bold="True" Font-Size="XX-Large">
                <asp:ListItem Text="6A Football" Value="Football6A"></asp:ListItem>
                <asp:ListItem Text="5A Football" Value="Football5A"></asp:ListItem>
                <asp:ListItem Text="4A Football" Value="Football4A"></asp:ListItem>
                <asp:ListItem Text="3A Football" Value="Football3A"></asp:ListItem>
                <asp:ListItem Text="2A Football" Value="Football2A"></asp:ListItem>
                <asp:ListItem Text=" A Football" Value="FootballA"></asp:ListItem>
                <asp:ListItem Text=" B Football" Value="FootballB"></asp:ListItem>
                <asp:ListItem Text=" C Football" Value="FootballC"></asp:ListItem>
            </asp:DropDownList>
            <telerik:RadRotator RenderMode="Lightweight" ID="RadRotator1" runat="server" Width="900px" Height="150"
                CssClass="horizontalRotator" ScrollDuration="500" FrameDuration="2000" ItemHeight="150"
                ItemWidth="150" EnableDragScrolling="true"  >
                <ItemTemplate>
                    <div class="itemBorder">
                    <asp:Table runat="server">
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="left" Width="125px">
                                <asp:Label CssClass="item" runat="server" ID="lblSchool" Text='<%# DataBinder.Eval(Container, "DataItem.School")%>'></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="right">
                                <asp:Label CssClass="itemScore" runat="server" ID="lblScore" Text='<%# DataBinder.Eval(Container, "DataItem.TotalScore")%>'></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="left" Width="125px">
                                <asp:Label CssClass="item" runat="server" ID="lbloSchool" Text='<%# DataBinder.Eval(Container, "DataItem.oSchool")%>'></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="right">
                                <asp:Label CssClass="itemScore" runat="server" ID="lbloScore" Text='<%# DataBinder.Eval(Container, "DataItem.oTotalScore")%>'></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    </div>
                </ItemTemplate>
            </telerik:RadRotator>
        </div>
    </div>
    <telerik:RadAjaxManager runat="server" ID="AjaxManager1">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="ConfigurationPanel1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadRotator1" LoadingPanelID="LoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="ConfigurationPanel1" LoadingPanelID="LoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>

    <telerik:RadAjaxLoadingPanel runat="server" ID="LoadingPanel1"></telerik:RadAjaxLoadingPanel>
    </form>
</body>
</html>
