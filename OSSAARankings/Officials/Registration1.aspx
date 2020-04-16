<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Registration1.aspx.vb" Inherits="OSSAARankings.Registration1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>OSSAA Officials Registration : Step 1</title>
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
                    <asp:Label runat="server" ID="lblStep" Text="OSSAA Registration : STEP 1" CssClass="labelStep" ></asp:Label><br />
                    <asp:Button runat="server" ID="cmdGoBack" Text="Go back to Portal Home" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowRegistrationThis">
                <asp:TableCell CssClass="cellRadius">
                    <asp:Label runat="server" CssClass="labelPortal" Text="&nbsp;REGISTRATION THIS SEASON (since June 3, 2019)" Width="100%"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowRegistrationThisOK" Visible="false">               
                <asp:TableCell>
                    <asp:CheckBoxList runat="server" ID="cbRegisteredThisSeasonOK" AutoPostBack="true" CssClass="label" Font-Bold="true" Font-Size="Large">
                        <asp:ListItem Text="YES, I have registered this season." Value="Y" onclick="UncheckOthers(this);"></asp:ListItem>
                        <asp:ListItem Text="NO, I have NOT registered this season." Value="N" onclick="UncheckOthers(this);"></asp:ListItem>
                    </asp:CheckBoxList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowRegistrationThisOOS" Visible="false">               
                <asp:TableCell>
                    <br />
                    <asp:HyperLink runat="server" ID="hlReciprocal" Font-Bold="true" NavigateUrl="http://www.ossaa.net/docs/2017-18/OSSAAReciprocalAgreement2018.pdf" Text="Reciprocal Agreement" Target="_blank"></asp:HyperLink><br />
                    <asp:CheckBoxList runat="server" ID="cbRegisteredThisSeasonOOS" AutoPostBack="true" CssClass="label" Font-Bold="true" Font-Size="Large">
                        <asp:ListItem Text="YES, I have registered this season." Value="OOS" onclick="UncheckOthers(this);"></asp:ListItem>
                        <asp:ListItem Text="YES, I have registered this season." Value="Y" onclick="UncheckOthers(this);"></asp:ListItem>
                        <asp:ListItem Text="NO, I have NOT registered this season, but I want to register in Oklahoma now." Value="N" onclick="UncheckOthers(this);"></asp:ListItem>
                    </asp:CheckBoxList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowRegistrationEver" Visible="false">
                <asp:TableCell CssClass="cellRadius">
                    <asp:Label runat="server" CssClass="labelPortal" Text="&nbsp;REGISTRATION IN ARBITER" Font-Bold="true" Width="100%"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowRegistrationEver1" Visible="false">
                <asp:TableCell>
                    <asp:CheckBoxList runat="server" ID="cbRegisteredEver" AutoPostBack="true" CssClass="label" Font-Bold="true" Font-Size="Large">
                        <asp:ListItem Text="YES, I have registered with ARBITER before" Value="Y" onclick="UncheckOthers(this);"></asp:ListItem>
                        <asp:ListItem Text="NO, I have NOT registered with ARBITER before" Value="N" onclick="UncheckOthers(this);"></asp:ListItem>
                    </asp:CheckBoxList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>&nbsp;</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowSports1" Visible="false">
                <asp:TableCell CssClass="cellRadius">
                    <asp:Label runat="server" ID="lblSportHeader" Text="&nbsp;REGISTER FOR AN ADDITIONAL SPORT" Font-Bold="true" CssClass="labelPortal" Width="100%"></asp:Label><br />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowSports2" Visible="false">
                <asp:TableCell>
                    <asp:Table runat="server" ID="tblSports" Style="padding-top:20px;">
                        <asp:TableRow>
                            <asp:TableCell Width="150px" HorizontalAlign="center">
                                <asp:Image runat="server" ID="imgBaseball" ImageUrl="~/Officials/images/baseball.png" Width="80px"  />
                            </asp:TableCell> 
                            <asp:TableCell Width="150px" HorizontalAlign="center">
                                <asp:Image runat="server" ID="imgBasketball" ImageUrl="~/Officials/images/basketball.png" Width="80px"  />
                            </asp:TableCell> 
                            <asp:TableCell Width="150px" HorizontalAlign="center">
                                <asp:Image runat="server" ID="imgFootball" ImageUrl="~/Officials/images/football.png" Width="80px"  />
                            </asp:TableCell> 
                            <asp:TableCell Width="150px" HorizontalAlign="center">
                                <asp:Image runat="server" ID="imgSoccer" ImageUrl="~/Officials/images/soccer.png" Width="80px"  />
                            </asp:TableCell> 
                            <asp:TableCell Width="150px" HorizontalAlign="center">
                                <asp:Image runat="server" ID="imgTrack" ImageUrl="~/Officials/images/track.png" Width="80px"  />
                            </asp:TableCell> 
                            <asp:TableCell>&nbsp;</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Button runat="server" ID="cmdBaseball" Text="Register Baseball" CssClass="button" Width="100%" Height="30px" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Button runat="server" ID="cmdBasketball" Text="Register Basketball" CssClass="button" Width="100%" Height="30px" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Button runat="server" ID="cmdFootball" Text="Register Football" CssClass="button" Width="100%" Height="30px" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Button runat="server" ID="cmdSoccer" Text="Register Soccer" CssClass="button" Width="100%" Height="30px" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Button runat="server" ID="cmdTrack" Text="Register Track" CssClass="button" Width="100%" Height="30px" />
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell Width="150px" HorizontalAlign="center">
                                <asp:Image runat="server" ID="imgFastPitch" ImageUrl="~/Officials/images/softball.png" Width="80px"  />
                            </asp:TableCell> 
                            <asp:TableCell Width="150px" HorizontalAlign="center">
                                <asp:Image runat="server" ID="imgSlowPitch" ImageUrl="~/Officials/images/softball.png" Width="80px"  />
                            </asp:TableCell> 
                            <asp:TableCell Width="150px" HorizontalAlign="center">
                                <asp:Image runat="server" ID="imgVolleyball" ImageUrl="~/Officials/images/volleyball.png" Width="80px"  />
                            </asp:TableCell> 
                            <asp:TableCell Width="150px" HorizontalAlign="center">
                                <asp:Image runat="server" ID="imgWrestling" ImageUrl="~/Officials/images/wrestling.png" Width="80px"  />
                            </asp:TableCell> 
                            <asp:TableCell>&nbsp;</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Button runat="server" ID="cmdFastPitch" Text="Register Fast Pitch" CssClass="button" Width="100%" Height="30px" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Button runat="server" ID="cmdSlowPitch" Text="Register Slow PItch" CssClass="button" Width="100%" Height="30px" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Button runat="server" ID="cmdVolleyball" Text="Register Volleyball" CssClass="button" Width="100%" Height="30px" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Button runat="server" ID="cmdWrestling" Text="Register Wrestling" CssClass="button" Width="100%" Height="30px" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Button runat="server" ID="cmdHome" Text="GO HOME" CssClass="button" Width="200px" Height="30px" />
                            </asp:TableCell>
                        </asp:TableRow>
         
                    </asp:Table>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>&nbsp;</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Hyperlink runat="server" ID="hlPopupBlicker" CssClass="labelMessage" Font-Bold="true" Font-Size="Large" Text="If you have a popup blocker ON, you may not be able to proceed from this point forward. CLICK HERE to turn off your popup blocker." NavigateUrl="https://www.techsupportall.com/block-pop-ups-chrome-firefox-internet-explorer-edge-browser/"></asp:Hyperlink>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowMessage">
                <asp:TableCell>
                    <asp:Label runat="server" ID="lblMessage" CssClass="labelMessage" Font-Bold="true" Font-Size="X-Large"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowButtons" HorizontalAlign="left">
                <asp:TableCell>
                    <asp:Button runat="server" ID="cmdRegister" Text="I COMPLETED MY REGISTRATION" CssClass="button" Width="400px" Visible="false" />&nbsp;&nbsp;
                    <asp:Button runat="server" ID="cmdRegister1" Text="I WILL COMPLETE THIS REGISTRATION LATER" CssClass="button" Width="475px" Visible="false" />
                    <asp:Button runat="server" ID="cmdGoHome" Text="CLICK HERE TO RETURN TO PORTAL HOME" CssClass="button" Width="450px" Visible="false" />
                </asp:TableCell>
            </asp:TableRow>  
        </asp:Table>
    </div>
    </form>
</body>
</html>
