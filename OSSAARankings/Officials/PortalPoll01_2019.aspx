<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PortalPoll01_2019.aspx.vb" Inherits="OSSAARankings.PortalPoll01_2019" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>OSSAA Officials Info</title>
    <link href="Officials.css" rel="stylesheet" type="text/css" />
    <link href='http://fonts.googleapis.com/css?family=Oswald' rel='stylesheet' type='text/css' />
    <script type = "text/javascript">
        function UncheckOthers(objchkbox) {
                var objchkList = objchkbox.parentNode.parentNode.parentNode;
                var chkboxControls = objchkList.getElementsByTagName("input");
                for (var i = 0; i < chkboxControls.length; i++) {
                    if (chkboxControls[i] != objchkbox && objchkbox.checked) {
                        chkboxControls[i].checked = false;
                    }
                }
            }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Table runat="server">
            <asp:TableRow ID="rowStep">
                <asp:TableCell>
                    <asp:Label runat="server" ID="lblStepPortal" Text="OSSAA Officials VOTE - July 2019" CssClass="labelStep" >
                    </asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowRegion2" Visible="false">
                <asp:TableCell>
                   <asp:Label runat="server" ID="lblRegion2" Text="<strong>CHOOSE ONE CANDIDATE FROM THE FOLLOWING TO SERVE A 2 YEAR TERM ON THE OKLAHOMA OFFICIALS ASSOCIATION (OOA) EXECUTIVE BOARD.<br><br>REGION 2</strong>"></asp:Label>
                    <asp:CheckBoxList runat="server" ID="cbListRegion2">
                        <asp:ListItem Value="Mark Burch" Text="Mark Burch" onclick="UncheckOthers(this);"></asp:ListItem>
                        <asp:ListItem Value="Danny Gaches" Text="Danny Gaches" onclick="UncheckOthers(this);"></asp:ListItem>
                        <asp:ListItem Value="Lonnie Brickman" Text="Lonnie Brickman" onclick="UncheckOthers(this);"></asp:ListItem>
                        <asp:ListItem Value="Angelo Guerrieri" Text="Angelo Guerrieri" onclick="UncheckOthers(this);"></asp:ListItem>
                        <asp:ListItem Value="Clint Cox" Text="Clint Cox" onclick="UncheckOthers(this);"></asp:ListItem>
                        <asp:ListItem Value="Charles Carroll" Text="Charles Carroll" onclick="UncheckOthers(this);"></asp:ListItem>
                        <asp:ListItem Value="David Willis" Text="David Willis" onclick="UncheckOthers(this);"></asp:ListItem>
                        <asp:ListItem Value="Eliot Smith" Text="Eliot Smith" onclick="UncheckOthers(this);"></asp:ListItem>
                    </asp:CheckBoxList>
                </asp:TableCell>
            </asp:TableRow>     
            <asp:TableRow ID="rowRegion5" Visible="false">
                <asp:TableCell>
                   <asp:Label runat="server" ID="lblRegion5" Text="<strong>CHOOSE ONE CANDIDATE FROM THE FOLLOWING TO SERVE A 2 YEAR TERM ON THE OKLAHOMA OFFICIALS ASSOCIATION (OOA) EXECUTIVE BOARD.<br><br>REGION 5</strong>"></asp:Label>
                    <asp:CheckBoxList runat="server" ID="cbListRegion5">
                        <asp:ListItem Value="Gerald Winnard" Text="Gerald Winnard" onclick="UncheckOthers(this);"></asp:ListItem>
                        <asp:ListItem Value="Alton Rawlins" Text="Alton Rawlins" onclick="UncheckOthers(this);"></asp:ListItem>
                        <asp:ListItem Value="Marcus Chapman" Text="Marcus Chapman" onclick="UncheckOthers(this);"></asp:ListItem>
                    </asp:CheckBoxList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowRegion6" Visible="false">
                <asp:TableCell>
                   <asp:Label runat="server" ID="lblRegion6" Text="<strong>CHOOSE ONE CANDIDATE FROM THE FOLLOWING TO SERVE A 2 YEAR TERM ON THE OKLAHOMA OFFICIALS ASSOCIATION (OOA) EXECUTIVE BOARD.<br><br>REGION 6</strong>"></asp:Label>
                    <asp:CheckBoxList runat="server" ID="cbListRegion6">
                        <asp:ListItem Value="Brison McSwain" Text="Brison McSwain" onclick="UncheckOthers(this);"></asp:ListItem>
                        <asp:ListItem Value="Jason Seikel" Text="Jason Seikel" onclick="UncheckOthers(this);"></asp:ListItem>
                        <asp:ListItem Value="Richard Littleton" Text="Richard Littleton" onclick="UncheckOthers(this);"></asp:ListItem>
                    </asp:CheckBoxList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowRegion8" Visible="false">
                <asp:TableCell>
                   <asp:Label runat="server" ID="lblRegion8" Text="<strong>CHOOSE ONE CANDIDATE FROM THE FOLLOWING TO SERVE A 2 YEAR TERM ON THE OKLAHOMA OFFICIALS ASSOCIATION (OOA) EXECUTIVE BOARD.<br><br>REGION 8</strong>"></asp:Label>
                    <asp:CheckBoxList runat="server" ID="cbListRegion8">
                        <asp:ListItem Value="Mike Stevenson" Text="Mike Stevenson" onclick="UncheckOthers(this);"></asp:ListItem>
                        <asp:ListItem Value="Scott Swyden" Text="Scott Swyden" onclick="UncheckOthers(this);"></asp:ListItem>
                        <asp:ListItem Value="Jake Weatherford" Text="Jake Weatherford" onclick="UncheckOthers(this);"></asp:ListItem>
                        <asp:ListItem Value="Craig Shive" Text="Craig Shive" onclick="UncheckOthers(this);"></asp:ListItem>
                    </asp:CheckBoxList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" ID="lblMessage" CssClass="labelMessage" Font-Bold="true" Font-Size="Larger"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowButtons">
                <asp:TableCell>
                    <asp:Button runat="server" ID="cmdSave" Text="Submit VOTE" CssClass="button" Width="150px" />&nbsp;&nbsp;
                    <asp:Button runat="server" ID="cmdReturn" Text="Return to Portal Home (canceling Changes)" CssClass="button" Width="350px" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
    </form>
</body>
</html>
