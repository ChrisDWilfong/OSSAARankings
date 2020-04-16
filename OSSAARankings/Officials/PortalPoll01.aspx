<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PortalPoll01.aspx.vb" Inherits="OSSAARankings.PortalPoll01" %>

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
                    <asp:Label runat="server" ID="lblStepPortal" Text="OSSAA Officials VOTE - June 2018" CssClass="labelStep" >
                    </asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowVote01">
                <asp:TableCell>
                    <asp:Label runat="server" ID="lblVote01" text="OOA Constitutional Amendment:<br>The Policy in the OOA Constitution now reads : <strong>'Basketball officials may not officiate a state tournament for more than three (3) consecutive years in Class B, A, 2A, 3A and 4A.'</strong><br><br><strong>The proposed change is to eliminate this statement.</strong>"></asp:Label>
                    <asp:CheckBoxList runat="server" ID="cbVote01">
                        <asp:ListItem Value="Y" Text="I vote to ELMINIATE this statement." onclick="UncheckOthers(this);"></asp:ListItem>
                        <asp:ListItem Value="N" Text="I vote to KEEP this statement." onclick="UncheckOthers(this);"></asp:ListItem>
                    </asp:CheckBoxList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell><hr /></asp:TableCell></asp:TableRow>
            <asp:TableRow><asp:TableCell><br /></asp:TableCell></asp:TableRow>
            <asp:TableRow ID="rowRegion1" Visible="false">
                <asp:TableCell>
                   <asp:Label runat="server" ID="lblRegion1" Text="<strong>CHOOSE ONE CANDIDATE FROM THE FOLLOWING TO SERVE A 2 YEAR TERM ON THE OKLAHOMA OFFICIALS ASSOCIATION (OOA) EXECUTIVE BOARD.<br><br>REGION 1</strong>"></asp:Label>
                    <asp:CheckBoxList runat="server" ID="cbListRegion1">
                        <asp:ListItem Value="Buck King" Text="Buck King" onclick="UncheckOthers(this);"></asp:ListItem>
                        <asp:ListItem Value="Doug Jech" Text="Doug Jech" onclick="UncheckOthers(this);"></asp:ListItem>
                        <asp:ListItem Value="Jason Frantz" Text="Jason Frantz" onclick="UncheckOthers(this);"></asp:ListItem>
                        <asp:ListItem Value="Kyal Johnston" Text="Kyal Johnston" onclick="UncheckOthers(this);"></asp:ListItem>
                        <asp:ListItem Value="Mark Martin" Text="Mark Martin" onclick="UncheckOthers(this);"></asp:ListItem>
                        <asp:ListItem Value="Marsha Cusack" Text="Marsha Cusack" onclick="UncheckOthers(this);"></asp:ListItem>
                        <asp:ListItem Value="Rusty Boring" Text="Rusty Boring" onclick="UncheckOthers(this);"></asp:ListItem>
                    </asp:CheckBoxList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowRegion3" Visible="false">
                <asp:TableCell>
                   <asp:Label runat="server" ID="lblRegion3" Text="<strong>CHOOSE ONE CANDIDATE FROM THE FOLLOWING TO SERVE A 2 YEAR TERM ON THE OKLAHOMA OFFICIALS ASSOCIATION (OOA) EXECUTIVE BOARD.<br><br>REGION 3</strong>"></asp:Label>
                    <asp:CheckBoxList runat="server" ID="cbListRegion3">
                        <asp:ListItem Value="Brad Murray" Text="Brad Murray" onclick="UncheckOthers(this);"></asp:ListItem>
                        <asp:ListItem Value="David Sherwood" Text="David Sherwood" onclick="UncheckOthers(this);"></asp:ListItem>
                        <asp:ListItem Value="Doug Merrie" Text="Doug Merrie" onclick="UncheckOthers(this);"></asp:ListItem>
                        <asp:ListItem Value="Fred Poteete" Text="Fred Poteete" onclick="UncheckOthers(this);"></asp:ListItem>
                        <asp:ListItem Value="Leslie Hannah" Text="Leslie Hannah" onclick="UncheckOthers(this);"></asp:ListItem>
                        <asp:ListItem Value="Randy Swift" Text="Randy Swift" onclick="UncheckOthers(this);"></asp:ListItem>
                        <asp:ListItem Value="Robert Stokes" Text="Robert Stokes" onclick="UncheckOthers(this);"></asp:ListItem>
                        <asp:ListItem Value="Terry Tyree Jr." Text="Terry Tyree Jr." onclick="UncheckOthers(this);"></asp:ListItem>
                    </asp:CheckBoxList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowRegion4" Visible="false">
                <asp:TableCell>
                   <asp:Label runat="server" ID="lblRegion4" Text="<strong>CHOOSE ONE CANDIDATE FROM THE FOLLOWING TO SERVE A 2 YEAR TERM ON THE OKLAHOMA OFFICIALS ASSOCIATION (OOA) EXECUTIVE BOARD.<br><br>REGION 4</strong>"></asp:Label>
                    <asp:CheckBoxList runat="server" ID="cbListRegion4">
                        <asp:ListItem Value="Jacqueline White" Text="Jacqueline White" onclick="UncheckOthers(this);"></asp:ListItem>
                        <asp:ListItem Value="James Hooko" Text="James Hooko" onclick="UncheckOthers(this);"></asp:ListItem>
                        <asp:ListItem Value="Jay Craft" Text="Jay Craft" onclick="UncheckOthers(this);"></asp:ListItem>
                        <asp:ListItem Value="Marty Haskins" Text="Marty Haskins" onclick="UncheckOthers(this);"></asp:ListItem>
                    </asp:CheckBoxList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowRegion7" Visible="false">
                <asp:TableCell>
                   <asp:Label runat="server" ID="lblRegion7" Text="<strong>CHOOSE ONE CANDIDATE FROM THE FOLLOWING TO SERVE A 2 YEAR TERM ON THE OKLAHOMA OFFICIALS ASSOCIATION (OOA) EXECUTIVE BOARD.<br><br>REGION 7</strong>"></asp:Label>
                    <asp:CheckBoxList runat="server" ID="cbListRegion7">
                        <asp:ListItem Value="Eric Dugger" Text="Eric Dugger" onclick="UncheckOthers(this);"></asp:ListItem>
                        <asp:ListItem Value="Randy Jeffers" Text="Randy Jeffers" onclick="UncheckOthers(this);"></asp:ListItem>
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
