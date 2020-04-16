<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PortalPoll03.aspx.vb" Inherits="OSSAARankings.PortalPoll03" %>

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
                    <asp:Label runat="server" ID="lblStepPortal" Text="OSSAA Officials VOTE - May 2019" CssClass="labelStep" >
                    </asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowHeader">
                <asp:TableCell>
                    <asp:Label runat="server" ID="Label1" text="<strong>WhAT IS THE HEADING</strong><br><br>What do you want to say here...<br><br>"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowVote01">
                <asp:TableCell>
                    <asp:Label runat="server" ID="lblVote01" text="<strong>QUESTION 1<br>Did you put in for the 2018-19 playoffs?</strong>"></asp:Label>
                    <asp:CheckBoxList runat="server" ID="cbVote01">
                        <asp:ListItem Value="Y" Text="YES" onclick="UncheckOthers(this);"></asp:ListItem>
                        <asp:ListItem Value="N" Text="NO" onclick="UncheckOthers(this);"></asp:ListItem>
                    </asp:CheckBoxList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell><br /></asp:TableCell></asp:TableRow>
            <asp:TableRow ID="rowVote02">
                <asp:TableCell>
                    <asp:Label runat="server" ID="lblVote2" text="<strong>If NO to QUESTION 1, why?</strong>"></asp:Label>
                    <asp:CheckBoxList runat="server" ID="cbVote02">
                        <asp:ListItem Value="Work" Text="Work" onclick="UncheckOthers(this);"></asp:ListItem>
                        <asp:ListItem Value="No3" Text="No 3 Person Crews" onclick="UncheckOthers(this);"></asp:ListItem>
                        <asp:ListItem Value="NoAfternoon" Text="Not interested in working the afternoon games" onclick="UncheckOthers(this);"></asp:ListItem>
                        <asp:ListItem Value="Other" Text="Other reasons" onclick="UncheckOthers(this);"></asp:ListItem>
                    </asp:CheckBoxList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell><hr /></asp:TableCell></asp:TableRow>
            <asp:TableRow ID="rowVote03">
                <asp:TableCell>
                    <asp:Label runat="server" ID="lblVote3" text="<strong>QUESTION 2<br>If we use 3 person crews in 2020 will you make yourself available for the playoffs?</strong>"></asp:Label>
                    <asp:CheckBoxList runat="server" ID="cbVote03">
                        <asp:ListItem Value="Y" Text="YES" onclick="UncheckOthers(this);"></asp:ListItem>
                        <asp:ListItem Value="N" Text="NO" onclick="UncheckOthers(this);"></asp:ListItem>
                    </asp:CheckBoxList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell><hr /></asp:TableCell></asp:TableRow>
            <asp:TableRow ID="rowVote04">
                <asp:TableCell>
                    <asp:Label runat="server" ID="lblVote4" text="<strong>QUESTION 3<br>If we use 2 person crews in 2020 will you make yourself available for the playoffs?</strong>"></asp:Label>
                    <asp:CheckBoxList runat="server" ID="cbVote04">
                        <asp:ListItem Value="Y" Text="YES" onclick="UncheckOthers(this);"></asp:ListItem>
                        <asp:ListItem Value="N" Text="NO" onclick="UncheckOthers(this);"></asp:ListItem>
                    </asp:CheckBoxList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell><hr /></asp:TableCell></asp:TableRow>
            <asp:TableRow ID="rowVote05">
                <asp:TableCell>
                    <asp:Label runat="server" ID="lblVote5" text="<strong>QUESTION 4<br>If we work 3 person crews in 2020 would you be available for afternoon sessions?</strong>"></asp:Label>
                    <asp:CheckBoxList runat="server" ID="cbVote05">
                        <asp:ListItem Value="Y" Text="YES" onclick="UncheckOthers(this);"></asp:ListItem>
                        <asp:ListItem Value="N" Text="NO" onclick="UncheckOthers(this);"></asp:ListItem>
                    </asp:CheckBoxList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell><hr /></asp:TableCell></asp:TableRow>
            <asp:TableRow ID="rowVote06">
                <asp:TableCell>
                    <asp:Label runat="server" ID="lblVote6" text="<strong>QUESTION 5<br>If we work 2 person crews in 2020 would you be available for afternoon sessions?</strong>"></asp:Label>
                    <asp:CheckBoxList runat="server" ID="cbVote06">
                        <asp:ListItem Value="Y" Text="YES" onclick="UncheckOthers(this);"></asp:ListItem>
                        <asp:ListItem Value="N" Text="NO" onclick="UncheckOthers(this);"></asp:ListItem>
                    </asp:CheckBoxList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell><hr /></asp:TableCell></asp:TableRow>
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
                    <asp:Button runat="server" ID="cmdReturn" Text="Return to Portal Home (canceling Changes)" CssClass="button" Width="400px" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
    </form>
</body>
</html>
