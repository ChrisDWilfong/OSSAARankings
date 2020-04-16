<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FBAssignors.aspx.vb" Inherits="OSSAARankings.FBAssignors" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>OSSAA Officials Assignors</title>
    <link href="Officials.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Table ID="tblMain" runat="server" Width="800px">
            <asp:TableRow>
                <asp:TableCell Width="110px">&nbsp;</asp:TableCell>
                <asp:TableCell>&nbsp;</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="Label4" runat="server" Text="OSSAA 2014-15 Officials Assignors Registration" CssClass="panelHeader" ForeColor="Maroon" Font-Bold="true"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="lblHeader1" runat="server" CssClass="panelHeader" Height="22px" Font-Bold="true" Text="Your Personal Information" Width="100%" BackColor="Navy" ForeColor="Yellow" style="text-align:center; vertical-align:middle;"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblEmail" runat="server" Text="Your Email :" CssClass="labelSmall"></asp:Label><asp:Label runat="server" ID="Label6" CssClass="label" ForeColor="Red" >*</asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="textbox"></asp:TextBox>&nbsp;<asp:Button ID="cmdGo" runat="server" Text="Go..." CssClass="button" Width="100px" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="row001" Visible="false">
                <asp:TableCell>
                    <asp:Label ID="lblName" runat="server" Text="Your Name :" CssClass="labelSmall"></asp:Label><asp:Label runat="server" ID="red1" CssClass="label" ForeColor="Red">*</asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtName" runat="server" CssClass="textbox"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="row002" Visible="false">
                <asp:TableCell>
                    <asp:Label ID="lblOSSAAID" runat="server" Text="Your OSSAAID# :" CssClass="labelSmall"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtOSSAAID" runat="server" CssClass="textbox" Width="80px"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="row003" Visible="false">
                <asp:TableCell>
                    <asp:Label ID="lblAddress" runat="server" Text="Address :" CssClass="labelSmall"></asp:Label><asp:Label runat="server" ID="Label2" CssClass="label" ForeColor="Red">*</asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="textbox"></asp:TextBox>
                </asp:TableCell>               
            </asp:TableRow>
            <asp:TableRow ID="row004" Visible="false">
                <asp:TableCell>
                    <asp:Label ID="lblCityStZip" runat="server" Text="City/St/Zip :" CssClass="labelSmall"></asp:Label><asp:Label runat="server" ID="Label3" CssClass="label" ForeColor="Red">*</asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtCity" runat="server" CssClass="textbox" Width="120px"></asp:TextBox>&nbsp;
                    <asp:TextBox ID="txtState" runat="server" CssClass="textbox" Width="20px"></asp:TextBox>&nbsp;
                    <asp:TextBox ID="txtZip" runat="server" CssClass="textbox" Width="50px"></asp:TextBox>&nbsp;
                    <asp:Button ID="cmdSave" runat="server" Text="Save Personal Information" CssClass="buttonSave" />&nbsp;
                    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="textbox" ForeColor="Red"></asp:Label>
                </asp:TableCell>               
            </asp:TableRow>
            <asp:TableRow ID="rowAssignorInfoHeader" Visible="false">
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="lblHeader2" runat="server" CssClass="panelHeader" Height="22px" Font-Bold="true" Text="Your Assignor Information" Width="100%" BackColor="Navy" ForeColor="Yellow" style="text-align:center; vertical-align:middle;"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowAssignorInfo" Visible="false">
                <asp:TableCell ColumnSpan="2">
                    <asp:Table runat="server" ID="tblAssignor" Width="100%">
                        <asp:TableRow>
                            <asp:TableCell ID="colA001" VerticalAlign="Top" Width="200px">
                                <asp:Label ID="lblSubHeader001" runat="server" CssClass="panelHeader" Height="36px" Font-Bold="true" Text="Select Sport(s)<br><i>Click all that apply</i>" BackColor="Maroon" ForeColor="Yellow" style="text-align:center; vertical-align:middle;" width="200px" Font-size="Small"></asp:Label><br /><hr />
                                <asp:CheckBox ID="cbBaseball" runat="server" AutoPostBack="true"/><asp:Label ID="lblBaseball" runat="server" Text="Baseball" CssClass="textboxTrans" Width="80px"></asp:Label><asp:Button ID="cmdBaseball" runat="server" Text="View Details >>" CssClass="button" Font-Size="XX-Small" Width="100px" Height="20px" /><br />
                                <asp:Label ID="lblBaseballDetail" runat="server" CssClass="labelSmall" Text=""></asp:Label><hr />
                                <asp:CheckBox ID="cbBasketball" runat="server" AutoPostBack="true" /><asp:Label ID="lblBasketball" runat="server" Text="Basketball" CssClass="textboxTrans" Width="80px"></asp:Label><asp:Button ID="cmdBasketball" runat="server" Text="View Details >>" CssClass="button" Font-Size="XX-Small" Width="100px" Height="20px"/><br />
                                <asp:Label ID="lblBasketballDetail" runat="server" CssClass="labelSmall" Text=""></asp:Label><hr />
                                <asp:CheckBox ID="cbFootball" runat="server" AutoPostBack="true" /><asp:Label ID="lblFootball" runat="server" Text="Football" CssClass="textboxTrans" Width="80px"></asp:Label><asp:Button ID="cmdFootball" runat="server" Text="View Details >>" CssClass="button" Font-Size="XX-Small" Width="100px" Height="20px"/><br />
                                <asp:Label ID="lblFootballDetail" runat="server" CssClass="labelSmall" Text=""></asp:Label><hr />
                                <asp:CheckBox ID="cbSoftballFP" runat="server" AutoPostBack="true" /><asp:Label ID="lblSoftballFP" runat="server" Text="Fast-Pitch" CssClass="textboxTrans" Width="80px"></asp:Label><asp:Button ID="cmdSoftballFP" runat="server" Text="View Details >>" CssClass="button" Font-Size="XX-Small" Width="100px" Height="20px"/><br />
                                <asp:Label ID="lblSoftballFPDetail" runat="server" CssClass="labelSmall" Text=""></asp:Label><hr />
                                <asp:CheckBox ID="cbSoftballSP" runat="server" AutoPostBack="true" /><asp:Label ID="lblSoftballSP" runat="server" Text="Slow-Pitch" CssClass="textboxTrans" Width="80px"></asp:Label><asp:Button ID="cmdSoftballSP" runat="server" Text="View Details >>" CssClass="button" Font-Size="XX-Small" Width="100px" Height="20px"/><br />
                                <asp:Label ID="lblSoftballSPDetail" runat="server" CssClass="labelSmall" Text=""></asp:Label><hr />
                                <asp:CheckBox ID="cbSoccer" runat="server" AutoPostBack="true" /><asp:Label ID="lblSoccer" runat="server" Text="Soccer" CssClass="textboxTrans" Width="80px"></asp:Label><asp:Button ID="cmdSoccer" runat="server" Text="View Details >>" CssClass="button" Font-Size="XX-Small" Width="100px" Height="20px"/><br />
                                <asp:Label ID="lblSoccerDetail" runat="server" CssClass="labelSmall" Text=""></asp:Label><hr />
                                <asp:CheckBox ID="cbWrestling" runat="server" AutoPostBack="true" /><asp:Label ID="lblWrestling" runat="server" Text="Wrestling" CssClass="textboxTrans" Width="80px"></asp:Label><asp:Button ID="cmdWrestling" runat="server" Text="View Details >>" CssClass="button" Font-Size="XX-Small" Width="100px" Height="20px"/><br />
                                <asp:Label ID="lblWrestlingDetail" runat="server" CssClass="labelSmall" Text=""></asp:Label><hr />
                                <asp:CheckBox ID="cbVolleyball" runat="server" AutoPostBack="true" /><asp:Label ID="lblVolleyball" runat="server" Text="Volleyball" CssClass="textboxTrans" Width="80px"></asp:Label><asp:Button ID="cmdVolleyball" runat="server" Text="View Details >>" CssClass="button" Font-Size="XX-Small" Width="100px" Height="20px"/><br />
                                <asp:Label ID="lblVolleyballDetail" runat="server" CssClass="labelSmall" Text=""></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell ID="colA002" VerticalAlign="Top" Width="580px" Visible="false">
                                <asp:Label ID="lblSubHeader002" runat="server" CssClass="panelHeader" Height="36px" Font-Bold="true" Text="Select Area(s) You Assign"  BackColor="Maroon" ForeColor="Yellow" style="text-align:center; vertical-align:middle;" width="420px" Font-size="Small"></asp:Label>&nbsp;<asp:Button ID="cmdSaveDetail" runat="server" Text="Save Details" CssClass="buttonSave" />&nbsp;<br /><hr />
                                <asp:CheckBox ID="cbSiteMetroOKC" runat="server"/><asp:Label ID="lblSiteMetroOKC" runat="server" Text="Metro-OKC" CssClass="textboxTrans" Width="120px"></asp:Label>
                                <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatDirection="Horizontal" CssClass="textbox" ViewStateMode="Enabled">
                                    <asp:ListItem>Elem&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem>MS&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem>JRH&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem>Sub-Var&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem>Varsity&nbsp;&nbsp;</asp:ListItem>
                                </asp:CheckBoxList>
                                <hr />
                                <asp:CheckBox ID="cbSiteMetroTulsa" runat="server"/><asp:Label ID="lblSiteMetroTulsa" runat="server" Text="Metro-Tulsa" CssClass="textboxTrans" Width="125px"></asp:Label>
                                 <asp:CheckBoxList ID="CheckBoxList2" runat="server" RepeatDirection="Horizontal" CssClass="textbox" ViewStateMode="Enabled">
                                    <asp:ListItem>Elem&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem>MS&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem>JRH&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem>Sub-Var&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem>Varsity&nbsp;&nbsp;</asp:ListItem>
                                </asp:CheckBoxList>                               
                                <hr />
                                <asp:CheckBox ID="cbSiteLawton" runat="server" /><asp:Label ID="lblSiteLawton" runat="server" Text="Lawton Area" CssClass="textboxTrans" Width="125px"></asp:Label>
                                <asp:CheckBoxList ID="CheckBoxList3" runat="server" RepeatDirection="Horizontal" CssClass="textbox" ViewStateMode="Enabled">
                                    <asp:ListItem>Elem&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem>MS&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem>JRH&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem>Sub-Var&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem>Varsity&nbsp;&nbsp;</asp:ListItem>
                                </asp:CheckBoxList>   
                                                             
                                <hr />
                                <asp:CheckBox ID="cbSitePanhandle" runat="server" /><asp:Label ID="lblSitePanhandle" runat="server" Text="Panhandle" CssClass="textboxTrans" Width="125px"></asp:Label>
                                <asp:CheckBoxList ID="CheckBoxList4" runat="server" RepeatDirection="Horizontal" CssClass="textbox" ViewStateMode="Enabled">
                                    <asp:ListItem>Elem&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem>MS&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem>JRH&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem>Sub-Var&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem>Varsity&nbsp;&nbsp;</asp:ListItem>
                                </asp:CheckBoxList>                                
                                <hr />
                                <asp:CheckBox ID="cbSiteStillwater" runat="server" /><asp:Label ID="lblSiteStillwater" runat="server" Text="Stillwater Area" CssClass="textboxTrans" Width="125px"></asp:Label>
                                <asp:CheckBoxList ID="CheckBoxList5" runat="server" RepeatDirection="Horizontal" CssClass="textbox">
                                    <asp:ListItem>Elem&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem>MS&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem>JRH&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem>Sub-Var&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem>Varsity&nbsp;&nbsp;</asp:ListItem>
                                </asp:CheckBoxList>                                
                                <hr />
                                <asp:CheckBox ID="cbSiteNW" runat="server" /><asp:Label ID="lblSiteNW" runat="server" Text="Northwest OK" CssClass="textboxTrans" Width="125px"></asp:Label>
                                <asp:CheckBoxList ID="CheckBoxList6" runat="server" RepeatDirection="Horizontal" CssClass="textbox">
                                    <asp:ListItem>Elem&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem>MS&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem>JRH&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem>Sub-Var&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem>Varsity&nbsp;&nbsp;</asp:ListItem>
                                </asp:CheckBoxList>                                
                                <hr />
                                <asp:CheckBox ID="cbSiteSW" runat="server" /><asp:Label ID="lblSiteSW" runat="server" Text="Southwest OK" CssClass="textboxTrans" Width="125px"></asp:Label>
                                <asp:CheckBoxList ID="CheckBoxList7" runat="server" RepeatDirection="Horizontal" CssClass="textbox">
                                    <asp:ListItem>Elem&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem>MS&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem>JRH&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem>Sub-Var&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem>Varsity&nbsp;&nbsp;</asp:ListItem>
                                </asp:CheckBoxList>                                
                                <hr />
                                <asp:CheckBox ID="cbSiteNE" runat="server" /><asp:Label ID="lblSiteNE" runat="server" Text="Northeast OK" CssClass="textboxTrans" Width="125px"></asp:Label>
                                <asp:CheckBoxList ID="CheckBoxList8" runat="server" RepeatDirection="Horizontal" CssClass="textbox">
                                    <asp:ListItem>Elem&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem>MS&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem>JRH&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem>Sub-Var&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem>Varsity&nbsp;&nbsp;</asp:ListItem>
                                </asp:CheckBoxList>                                
                                <hr />
                                <asp:CheckBox ID="cbSiteSE" runat="server" /><asp:Label ID="lblSiteSE" runat="server" Text="Southeast OK" CssClass="textboxTrans" Width="125px"></asp:Label>
                                <asp:CheckBoxList ID="CheckBoxList9" runat="server" RepeatDirection="Horizontal" CssClass="textbox">
                                    <asp:ListItem>Elem&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem>MS&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem>JRH&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem>Sub-Var&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem>Varsity&nbsp;&nbsp;</asp:ListItem>
                                </asp:CheckBoxList>                                
                                <hr />
                                <asp:CheckBox ID="cbSiteSCentral" runat="server" /><asp:Label ID="lblSiteSCentral" runat="server" Text="South Central OK" CssClass="textboxTrans" Width="125px"></asp:Label>
                                <asp:CheckBoxList ID="CheckBoxList10" runat="server" RepeatDirection="Horizontal" CssClass="textbox">
                                    <asp:ListItem>Elem&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem>MS&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem>JRH&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem>Sub-Var&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem>Varsity&nbsp;&nbsp;</asp:ListItem>
                                </asp:CheckBoxList>                                
                                <hr />
                                <asp:CheckBox ID="cbSiteEastern" runat="server" /><asp:Label ID="lblSiteEastern" runat="server" Text="Eastern OK" CssClass="textboxTrans" Width="125px"></asp:Label>
                                <asp:CheckBoxList ID="CheckBoxList11" runat="server" RepeatDirection="Horizontal" CssClass="textbox">
                                    <asp:ListItem>Elem&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem>MS&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem>JRH&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem>Sub-Var&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem>Varsity&nbsp;&nbsp;</asp:ListItem>
                                </asp:CheckBoxList>                                  
                                <br />
                           </asp:TableCell>
                       
                        </asp:TableRow>
                    </asp:Table>
                </asp:TableCell>
            </asp:TableRow>

        </asp:Table>
    </div>
    </form>
</body>
</html>
