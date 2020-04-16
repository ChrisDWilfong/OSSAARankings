<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Portal.aspx.vb" Inherits="OSSAARankings.Portal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>OSSAA Officials Portal</title>
    <link href="Officials.css" rel="stylesheet" type="text/css" />
    <link href='http://fonts.googleapis.com/css?family=Oswald' rel='stylesheet' type='text/css' />
    <script type = "text/javascript">
            function UncheckOthers(objchkbox) {
                //Get the parent control of checkbox which is the checkbox list
                var objchkList = objchkbox.parentNode.parentNode.parentNode;
                //Get the checkbox controls in checkboxlist
                var chkboxControls = objchkList.getElementsByTagName("input");
                //Loop through each check box controls
                for (var i = 0; i < chkboxControls.length; i++) {
                    //Check the current checkbox is not the one user selected
                    if (chkboxControls[i] != objchkbox && objchkbox.checked) {
                        //Uncheck all other checkboxes
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
                    <asp:Label runat="server" ID="lblStepPortal" Text="OSSAA Officials Portal" CssClass="labelStep" >
                    </asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" ID="lblTitle" CssClass="label" Font-Bold="true" Font-Size="X-Large" Text="ENTER YOUR PERSONAL INFORMATION"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowPersonalInfoFN">
                <asp:TableCell>
                    <asp:Label runat="server" ID="lblFirstName" Text="First Name :" CssClass="label" Height="24px"></asp:Label><br />
                    <asp:TextBox runat="server" ID="txtFirstName" CssClass="textbox" width="150px"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowPersonalInfoLN">
                <asp:TableCell>
                    <asp:Label runat="server" ID="lblLastName" Text="Last Name :" CssClass="label" Height="24px"></asp:Label><br />
                    <asp:TextBox runat="server" ID="txtLastName" CssClass="textbox" width="150px"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowPersonalInfoE">
                <asp:TableCell>
                    <asp:Label runat="server" ID="lblEmail" Text="Registered Email :" CssClass="label" Height="24px"></asp:Label><br />
                    <asp:TextBox runat="server" ID="txtEmail" CssClass="textbox" width="250px"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowPersonalInfoS">
                <asp:TableCell>
                    <asp:Label runat="server" ID="Label1" Text="State you live in :" CssClass="label" Height="24px"></asp:Label><br />
                    <asp:DropDownList runat="server" Width="100px" CssClass="textbox" ID="cboState" AutoPostBack="true">
                        <asp:ListItem Text="Select..." Value="" Selected="true"></asp:ListItem>
                        <asp:ListItem Text="OK" Value="OK"></asp:ListItem>
                        <asp:ListItem Text="AR" Value="AR"></asp:ListItem>
                        <asp:ListItem Text="CO" Value="CO"></asp:ListItem>
                        <asp:ListItem Text="KS" Value="KS"></asp:ListItem>
                        <asp:ListItem Text="MO" Value="MO"></asp:ListItem>
                        <asp:ListItem Text="TX" Value="TX"></asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowPersonalInfoZip">
                <asp:TableCell>
                    <asp:Label runat="server" ID="lblZipCode" Text="Zip Code :" CssClass="label" Height="24px"></asp:Label><br />
                    <asp:TextBox runat="server" ID="txtZipCode" CssClass="textbox" width="100px"></asp:TextBox>&nbsp;&nbsp;
                    <asp:Label runat="server" ID="lblZipCodeZone" CssClass="label" ></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowPersonalInfoO">
                <asp:TableCell>
                    <asp:Label runat="server" ID="lblOSSAAID" Text="OSSAA ID (leave blank if you do not have one) :" CssClass="label" Height="24px"></asp:Label><br />
                    <asp:TextBox runat="server" ID="txtOSSAAID" CssClass="textbox" width="80px"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>&nbsp;</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:CheckBox runat="server" ID="cbVerify" Text="&nbsp;OSSAA Registration as an official is on a school year not a calendar year.  You will be registering for the 2019-20 school year. I agree to read and fully adhere to all OSSAA policies listed in the OSSAA Officials Registration." CssClass="label" AutoPostBack="true" Font-Italic="true" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowMessage">
                <asp:TableCell>
                    <asp:Label runat="server" ID="lblMessage" CssClass="labelMessage" Font-Size="Large" Font-Bold="true"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>&nbsp;</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowButtons">
                <asp:TableCell>
                    <asp:Button runat="server" ID="cmdRegister" Text="REGISTER" CssClass="button" />&nbsp;&nbsp;
                    <asp:Button runat="server" ID="cmdOfficialsInfo" Text="OFFICIALS INFO" CssClass="button" />&nbsp;&nbsp;
                    <asp:Button runat="server" ID="cmdArbiterHome" Text="ARBITER HOME PAGE" CssClass="button" />&nbsp;&nbsp;
                    <asp:Button runat="server" ID="cmdVote" Text="VOTE" CssClass="button" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow Visible="false">
                <asp:TableCell>
                <h2>Additional REGISTRATIONS</h2>
                <asp:HyperLink runat="server" ID="HyperLink1" NavigateUrl="http://ossaa.arbitersports.com/front/106940/Registration/2019-OU-Basketball-Camp-Deposit" Text="2019 OU Basketball Camp Registration : DEPOSIT"></asp:HyperLink><br />
                <asp:HyperLink runat="server" ID="HyperLink2" NavigateUrl="http://ossaa.arbitersports.com/front/106940/Registration/2019-OU-Basketball-Camp-Full-Payment" Text="2019 OU Basketball Camp Registration : FULL PAYMENT"></asp:HyperLink><br />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                <h2>Additional Resources</h2>
                <asp:HyperLink runat="server" ID="hl1" NavigateUrl="https://nfhslearn.com/courses/61151/concussion-in-sports" Text="CONCUSSION Video"></asp:HyperLink><br />
                <asp:HyperLink runat="server" ID="hl2" NavigateUrl="https://nfhslearn.com/courses/61140/heat-illness-prevention" Text="HEAT ILLNESS PREVENTION video"></asp:HyperLink><br />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
    </form>
</body>
</html>
