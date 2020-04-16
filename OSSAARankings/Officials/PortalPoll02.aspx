<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PortalPoll02.aspx.vb" Inherits="OSSAARankings.PortalPoll02" %>

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
                    <asp:Label runat="server" ID="lblStepPortal" Text="OSSAA Officials VOTE - August 2018" CssClass="labelStep" >
                    </asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowHeader">
                <asp:TableCell>
                    <asp:Label runat="server" ID="Label1" text="<strong>PRESENTING CERTIFICATES</strong><br><br>This year at the OOA meeting at Southmoore, July 21 we changed things up a bit and rather than call everyone to the stage to present their certificate we posted the names on the screen in front and asked all that were associated with that event to stand for a round of applause.  We did that for each of the events: Years of Service (20, 25, 30, 35, 40, 45), State Championship officials and  All State Officials.  We acknowledged everyone, we just did not hand out certificates at that moment.  Certificates were available before and after the meeting.<br><br>"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowVote01">
                <asp:TableCell>
                    <asp:Label runat="server" ID="lblVote01" text="<strong>How do you feel about the new certificate presentation procedure?</strong>"></asp:Label>
                    <asp:CheckBoxList runat="server" ID="cbVote01">
                        <asp:ListItem Value="Y" Text="I like the new procedure" onclick="UncheckOthers(this);"></asp:ListItem>
                        <asp:ListItem Value="N" Text="I DO NOT like the new procedure" onclick="UncheckOthers(this);"></asp:ListItem>
                    </asp:CheckBoxList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell><hr /></asp:TableCell></asp:TableRow>
            <asp:TableRow ID="rowVote02">
                <asp:TableCell>
                    <asp:Label runat="server" ID="lblVote2" text="<strong>Do you prefer to have your certificate presented to you on stage?</strong>"></asp:Label>
                    <asp:CheckBoxList runat="server" ID="cbVote02">
                        <asp:ListItem Value="Y" Text="YES" onclick="UncheckOthers(this);"></asp:ListItem>
                        <asp:ListItem Value="N" Text="NO" onclick="UncheckOthers(this);"></asp:ListItem>
                    </asp:CheckBoxList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell><br /></asp:TableCell></asp:TableRow>
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
