<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ELIGVerification.aspx.vb" Inherits="OSSAARankings.ELIGVerification" ClientTarget="uplevel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>OSSAA Eligibility Meeting Verification</title>
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .textBox 
        {
            font-family:Verdana;
            font-size:9pt;
        }
        .validBox 
        {
            font-family:Arial;
            font-size:8pt;
        }        
        .labelBox 
        {
            font-family:Verdana;
            font-size:9pt;
            font-weight:bold;
        }
        .headerBox 
        {
            font-family:Verdana;
            font-size:9pt;
            font-weight:bold;
        }        
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <asp:Table runat="server" Width="650px">
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2" >
                    <asp:Label ID="lblHeader" runat="server" CssClass="headerBox" ForeColor="#000099" Text="Eligibility Meeting Confirmation Page"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell >
                    <asp:Label ID="lblName" runat="server" Text="First/Last :" Width="150px" CssClass="labelBox"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtFirstName" runat="server" Width="100px" CssClass="textBox"></asp:TextBox>&nbsp;
                    <asp:TextBox ID="txtLastName" runat="server" Width="100px" CssClass="textBox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtFirstName" ErrorMessage="RequiredFieldValidator" 
                        ForeColor="Red" CssClass="validBox">First is required</asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txtLastName" ErrorMessage="RequiredFieldValidator" 
                        ForeColor="Red" CssClass="validBox">Last is required</asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell >
                    <asp:Label ID="lblEmail" runat="server" Text="YOUR Email : " Width="150px" CssClass="labelBox"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtEmail" runat="server" Width="260px" CssClass="textBox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="txtEmail" ErrorMessage="RequiredFieldValidator" 
                        ForeColor="Red" CssClass="validBox">Your email is required</asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblSport" runat="server" Text="Position : " Width="150px" CssClass="labelBox"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cboPosition" runat="server" Font-Names="Verdana" Width="300px" CssClass="textBox">
                        <asp:ListItem Value="Select..." Text="Select..."></asp:ListItem>
                        <asp:ListItem Value="Superintendent" Text="Superintendent"></asp:ListItem>
                        <asp:ListItem Value="High School Principal" Text="High School Principal"></asp:ListItem>
                        <asp:ListItem Value="Athletic Director" Text="Athletic Director"></asp:ListItem>
                        <asp:ListItem Value="Other" Text="Other"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToCompare="txtSelect" ControlToValidate="cboPosition" 
                        ErrorMessage="CompareValidator" ForeColor="Red" Operator="NotEqual" 
                        ValueToCompare="Select..." CssClass="validBox">You must select a POSITION...</asp:CompareValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblSchool" runat="server" Text="School : " Width="150px" CssClass="labelBox"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cboSchool" runat="server" DataSourceID="SqlDataSource3" 
                        DataTextField="strSchool" DataValueField="strSchool" Font-Names="Verdana" 
                        Width="300px" CssClass="textBox">
                    </asp:DropDownList>
                    <asp:TextBox ID="txtOfficialID" runat="server" Visible="False" CssClass="textBox"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>&nbsp;</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtSelect" runat="server" Height="16px" Width="1px" 
                        BackColor="Transparent" BorderColor="Transparent" BorderStyle="Solid">Select...</asp:TextBox>
                    <asp:TextBox ID="txtSelect0" runat="server" Height="16px" Width="1px" 
                        BackColor="Transparent" BorderColor="Transparent" BorderStyle="Solid"> Select...</asp:TextBox>
                    <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Maroon" 
                        Text="Please complete the info above and click the 'Submit to OSSAA' button below. "></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>&nbsp;</asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="cmdSubmitToOSSAA" runat="server" Font-Names="Verdana" Text="Submit to OSSAA" CssClass="textBox" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OSSAAOnlineConnectionString %>" 
        SelectCommand="SELECT [Id], [strType], [strLastName], [strFirstName], [strSchool], [strSport], [strEmail], [strOSSAAIdNo] FROM [tblRulesResults]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OSSAAOnlineConnectionString %>" 
        SelectCommand="SELECT [strSport] FROM [tblSports] ORDER BY [intSort], [strSport]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OSSAAOnlineConnectionString %>" 
        SelectCommand="SELECT strSchool FROM [tblSchools] ORDER BY strSchool">
    </asp:SqlDataSource>
    </form>
</body>
</html>
