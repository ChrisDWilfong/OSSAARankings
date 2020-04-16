<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="LoginForgot.aspx.vb" Inherits="OSSAARankings.LoginForgot" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<link href="../mem/mem.css" rel="stylesheet" type="text/css" />
<head runat="server">
    <title>OSSAARankings.com Coaches Login Page</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="panelHome">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:Panel ID="PanelLogin" runat="server" CssClass="panelHome">
        <asp:UpdatePanel ID="UpdatePanelHome" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
            <asp:Table id="tableContent" style="width: 100%;" runat="server">
                    <asp:TableRow BackColor="Maroon" VerticalAlign="Middle" Height="32"><asp:TableCell><asp:Label ID="Label4" runat="server" Text="&nbsp;OSSAARankings.com - Password Recovery" CssClass="memHeader" ForeColor="White" ></asp:Label></asp:TableCell></asp:TableRow>
                    <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
                    <asp:TableRow><asp:TableCell><asp:Label ID="Label5" runat="server" Text="Enter Login Information" CssClass="memHeader"></asp:Label></asp:TableCell></asp:TableRow>
                    <asp:TableRow><asp:TableCell><asp:Label ID="Label3" runat="server" Text="(If you currently have a login into the OSSAARankings.com Site and have forgotten it. If your email exists in our system, it will be emailed to you.)" Font-Bold="False" Font-Names="Verdana" Font-Size="8pt"></asp:Label></asp:TableCell></asp:TableRow>
                    <asp:TableRow HorizontalAlign="center" style="height: 25px">
                        <asp:TableCell HorizontalAlign="left">
                            <asp:Label ID="lblSelectSport1" runat="server" Text="Your School :" CssClass="perInfoLabel"></asp:Label><br />
                            <asp:DropDownList ID="cboSchools" runat="server" CssClass="dropDownList" DataValueField="SchoolID" DataTextField="SchoolName" AutoPostBack="true"></asp:DropDownList></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow HorizontalAlign="left">
                        <asp:TableCell HorizontalAlign="left">
                            <asp:Label ID="lblSelectPosition" runat="server" Text="Select your Coaching Position :" CssClass="perInfoLabel"></asp:Label><br />
                            <asp:DropDownList ID="cboPositions" runat="server" CssClass="dropDownList" DataTextField="SportDisplay" DataValueField="memberID" >
                                <asp:ListItem>Select...</asp:ListItem>
                            </asp:DropDownList>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow HorizontalAlign="center" style="height: 25px">
                        <asp:TableCell HorizontalAlign="left">
                            <asp:Label ID="lblSelectSport0" runat="server" Text="Your Name :" CssClass="perInfoLabel"></asp:Label><br />
                            <asp:TextBox ID="txtName" runat="server" Width="300px" CssClass="perInfoText2"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow HorizontalAlign="center" style="height: 25px">
                        <asp:TableCell HorizontalAlign="left">
                            <asp:Label ID="Label2" runat="server" Text="Enter your email address : " CssClass="perInfoLabel"></asp:Label><br />
                            <asp:TextBox ID="txtEmail" runat="server" Width="400px" CssClass="perInfoText2"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow HorizontalAlign="left">
                        <asp:TableCell ColumnSpan="2">
                            <asp:Button ID="cmdSubmit" runat="server" Text="Submit Request" CssClass="button" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow HorizontalAlign="left">
                        <asp:TableCell ColumnSpan="2">
                            <asp:Label ID="lblMessage" runat="server" Font-Names="Verdana" Font-Size="10pt" ForeColor="Red"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </ContentTemplate>
        </asp:UpdatePanel>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
