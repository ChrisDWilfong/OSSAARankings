<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PortalPoll_Jerseys.aspx.vb" Inherits="OSSAARankings.PortalPoll_Jerseys" %>

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
                    <asp:Label runat="server" ID="lblStepPortal" Text="OSSAA Officials VOTE - December 2019" CssClass="labelStep" >
                    </asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowVote01">
                <asp:TableCell>
                    <asp:Label runat="server" ID="lblVote01" text="<strong>Before I came into the position of Director of Officials, Todd Dilbeck had started the process of looking at different shirts.<br>For this season, it was not feasible to make that happen, but moving forward, we are going to be able to go that direction.</strong>"></asp:Label>
                    <br /><br />
                    <asp:Label runat="server" ID="Label1" text="<strong>Here are some pictures of a couple of options for Basketball Officials Shirts for next season-(2020-2021 Season).<br>These would not be the playoff shirts for this season- (2019-2020) as we will be in our conventional striped shirts for the playoffs this year.</strong>"></asp:Label>
                    <br /><br />
                    <asp:Label runat="server" ID="Label2" text="<strong>We are conducting a poll to determine your preference between these two shirts.<br>Please vote for one, and we will tabulate the responses and gauge everyone’s input.</strong>"></asp:Label>
                    <br /><br />
                    <asp:Label runat="server" ID="Label3" text="<strong>Thank you and have a great rest of the season!</strong>"></asp:Label>
                    <br /><br />
                    <hr />
                    <asp:Table runat="server">
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Image runat="server" ID="imgWithStripes" ImageUrl="~/images/OfficialsShirtWStripe.JPG" Width="350" Borderwidth="2" />
                            </asp:TableCell>
                            <asp:TableCell>&nbsp;&nbsp;&nbsp;&nbsp;</asp:TableCell>
                            <asp:TableCell>
                                <asp:Image runat="server" ID="imgWithoutStripes" ImageUrl="~/images/OfficialsShirtWOStripe.JPG" Width="350" BorderWidth="2" />
                            </asp:TableCell>
                        </asp:TableRow>
                          
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label runat="server" ID="lblW" Text="Officials shirt WITH stripes" Style="text-align:center;" Font-Bold="true" ForeColor="Navy"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell>&nbsp;&nbsp;&nbsp;&nbsp;</asp:TableCell>
                            <asp:TableCell>
                                <asp:Label runat="server" ID="lblWO" Text="Officials shirt WITHOUT stripes" Style="text-align:center;" Font-Bold="true" ForeColor="Navy"></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <hr />
                    <asp:Label runat="server" Text="MAKE SELECTION BELOW and then CLICK SUBMIT VOTE" Font-Bold="true" ForeColor="Red"></asp:Label>
                    <asp:CheckBoxList runat="server" ID="cbVote01" >
                        <asp:ListItem Value="WITH" Text="Officials shirt WITH stripes" onclick="UncheckOthers(this);"></asp:ListItem>
                        <asp:ListItem Value="WITHOUT" Text="Officials shirt WITHOUT stripes" onclick="UncheckOthers(this);"></asp:ListItem>
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
