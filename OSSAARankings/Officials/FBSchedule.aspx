<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FBSchedule.aspx.vb" Inherits="OSSAARankings.FBSchedule" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register assembly="Infragistics4.WebUI.WebDateChooser.v10.2, Version=10.2.20102.1011, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.WebUI.WebSchedule" tagprefix="igsch" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>OSSAA Football Officials Schedule</title>
    <style>
        .header
        {
            font-family:Arial;
            font-size:12pt;
            font-weight:bold;
            color:Maroon;
        }        
        .label
        {
            font-family:Verdana;
            font-size:9pt;
            font-weight:bold;
        }
        .text 
        {
            font-family:Verdana;
            font-size:8pt;
            background-color: LightYellow;
        } 
        .label8
        {
            font-family:Verdana;
            font-size:8pt;
            background-color: White;
        }         
        .button
        {
            font-family:Verdana;
            font-size:8pt;
        }   
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Table ID="tblFBAvail" runat="server" Width="330px">
            <asp:TableRow>
                <asp:TableCell Width="40%">&nbsp;</asp:TableCell>
                <asp:TableCell Width="60%">&nbsp;</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="Label4" runat="server" Text="OSSAA Football Officials Schedule" CssClass="header"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblEmail" runat="server" Text="Your Email :" CssClass="label8"></asp:Label><asp:Label runat="server" ID="Label6" CssClass="label" ForeColor="Red">*</asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="text" Width="250px"></asp:TextBox><asp:Button ID="cmdGo" runat="server" Text="Go" CssClass="button" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="row001">
                <asp:TableCell>
                    <asp:Label ID="lblName" runat="server" Text="Your Name :" CssClass="label8"></asp:Label><asp:Label runat="server" ID="red1" CssClass="label" ForeColor="Red">*</asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtName" runat="server" CssClass="text"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="row002">
                <asp:TableCell>
                    <asp:Label ID="lblOSSAAID" runat="server" Text="Your OSSAAID# :" CssClass="label8"></asp:Label><asp:Label runat="server" ID="Label7" CssClass="label" ForeColor="Red">*</asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtOSSAAID" runat="server" CssClass="text"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="row003">
                <asp:TableCell>
                    <asp:Label ID="lblAreYou" runat="server" Text="Are you a White Hat? " CssClass="label8"></asp:Label><asp:Label runat="server" ID="Label8" CssClass="label" ForeColor="Red">*</asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cboWH" runat="server" AutoPostBack="true">
                        <asp:ListItem>Select...</asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowWH1" Visible="false">
                <asp:TableCell>
                    <asp:Label ID="lblWH1" runat="server" Text="Your White Hat's OSSAAID# :" CssClass="label8"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtWH1" runat="server" CssClass="text"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowWH2">
                <asp:TableCell>
                    <asp:Label ID="Label3" runat="server" Text="Your White Hat's Name :" CssClass="label8"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtWH2" runat="server" CssClass="text"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowSave">
                <asp:TableCell ColumnSpan="2">
                    <asp:Button ID="cmdSave" runat="server" Text="Save Changes" font-family="verdana" Font-Size="10pt" BackColor="Green" ForeColor="White"  />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="text" ForeColor="Red"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2"><hr /></asp:TableCell></asp:TableRow>
            </asp:Table>

            <asp:Table ID="tblDe" Width="330px" runat="server">
            <asp:TableRow ID="rowHelp"><asp:TableCell ColumnSpan="2"><asp:Label ID="Label5" runat="server" Text="To CLEAR an existing game, SELECT 'No site selected...' for that game." Font-Bold="false" ForeColor="Maroon" CssClass="label"></asp:Label></asp:TableCell></asp:TableRow>
            <asp:TableRow ID="rowHeader">
                <asp:TableCell Width="30%"><asp:Label ID="Label1" runat="server" Text="Date of Game" CssClass="label"></asp:Label></asp:TableCell>
                <asp:TableCell Width="70%"><asp:Label ID="Label2" runat="server" Text="Game Location" cssclass="label"></asp:Label></asp:TableCell>
            </asp:TableRow> 
            <asp:TableRow ID="row1">
                <asp:TableCell><igsch:WebDateChooser ID="WebDateChooser1" runat="server" StyleSetName="Office2007Silver" AutoPostBack-ValueChanged="true" ></igsch:WebDateChooser></asp:TableCell>
                <asp:TableCell><asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="SchoolDisplay" DataValueField="schoolID"></asp:DropDownList></asp:TableCell>
            </asp:TableRow> 
            <asp:TableRow ID="row2">
                <asp:TableCell><igsch:WebDateChooser ID="WebDateChooser2" runat="server" StyleSetName="Office2007Silver" AutoPostBack-ValueChanged="true"></igsch:WebDateChooser></asp:TableCell>
                <asp:TableCell><asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource1" DataTextField="SchoolDisplay" DataValueField="schoolID"></asp:DropDownList></asp:TableCell>
            </asp:TableRow>    
            <asp:TableRow ID="row3">
                <asp:TableCell><igsch:WebDateChooser ID="WebDateChooser3" runat="server" StyleSetName="Office2007Silver" AutoPostBack-ValueChanged="true"></igsch:WebDateChooser></asp:TableCell>
                <asp:TableCell><asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="SqlDataSource1" DataTextField="SchoolDisplay" DataValueField="schoolID"></asp:DropDownList></asp:TableCell>
            </asp:TableRow>  
            <asp:TableRow ID="row4">
                <asp:TableCell><igsch:WebDateChooser ID="WebDateChooser4" runat="server" StyleSetName="Office2007Silver" AutoPostBack-ValueChanged="true"></igsch:WebDateChooser></asp:TableCell>
                <asp:TableCell><asp:DropDownList ID="DropDownList4" runat="server" DataSourceID="SqlDataSource1" DataTextField="SchoolDisplay" DataValueField="schoolID"></asp:DropDownList></asp:TableCell>
            </asp:TableRow>  
            <asp:TableRow ID="row5">
                <asp:TableCell><igsch:WebDateChooser ID="WebDateChooser5" runat="server" StyleSetName="Office2007Silver" AutoPostBack-ValueChanged="true"></igsch:WebDateChooser></asp:TableCell>
                <asp:TableCell><asp:DropDownList ID="DropDownList5" runat="server" DataSourceID="SqlDataSource1" DataTextField="SchoolDisplay" DataValueField="schoolID"></asp:DropDownList></asp:TableCell>
            </asp:TableRow>  
            <asp:TableRow ID="row6">
                <asp:TableCell><igsch:WebDateChooser ID="WebDateChooser6" runat="server" StyleSetName="Office2007Silver" AutoPostBack-ValueChanged="true"></igsch:WebDateChooser></asp:TableCell>
                <asp:TableCell><asp:DropDownList ID="DropDownList6" runat="server" DataSourceID="SqlDataSource1" DataTextField="SchoolDisplay" DataValueField="schoolID"></asp:DropDownList></asp:TableCell>
            </asp:TableRow>  
            <asp:TableRow ID="row7">
                <asp:TableCell><igsch:WebDateChooser ID="WebDateChooser7" runat="server" StyleSetName="Office2007Silver" AutoPostBack-ValueChanged="true"></igsch:WebDateChooser></asp:TableCell>
                <asp:TableCell><asp:DropDownList ID="DropDownList7" runat="server" DataSourceID="SqlDataSource1" DataTextField="SchoolDisplay" DataValueField="schoolID"></asp:DropDownList></asp:TableCell>
            </asp:TableRow>  
            <asp:TableRow ID="row8">
                <asp:TableCell><igsch:WebDateChooser ID="WebDateChooser8" runat="server" StyleSetName="Office2007Silver" AutoPostBack-ValueChanged="true"></igsch:WebDateChooser></asp:TableCell>
                <asp:TableCell><asp:DropDownList ID="DropDownList8" runat="server" DataSourceID="SqlDataSource1" DataTextField="SchoolDisplay" DataValueField="schoolID"></asp:DropDownList></asp:TableCell>
            </asp:TableRow>  
            <asp:TableRow ID="row9">
                <asp:TableCell><igsch:WebDateChooser ID="WebDateChooser9" runat="server" StyleSetName="Office2007Silver" AutoPostBack-ValueChanged="true"></igsch:WebDateChooser></asp:TableCell>
                <asp:TableCell><asp:DropDownList ID="DropDownList9" runat="server" DataSourceID="SqlDataSource1" DataTextField="SchoolDisplay" DataValueField="schoolID"></asp:DropDownList></asp:TableCell>
            </asp:TableRow>  
            <asp:TableRow ID="row10">
                <asp:TableCell><igsch:WebDateChooser ID="WebDateChooser10" runat="server" StyleSetName="Office2007Silver" AutoPostBack-ValueChanged="true"></igsch:WebDateChooser></asp:TableCell>
                <asp:TableCell><asp:DropDownList ID="DropDownList10" runat="server" DataSourceID="SqlDataSource1" DataTextField="SchoolDisplay" DataValueField="schoolID"></asp:DropDownList></asp:TableCell>
            </asp:TableRow>  
            <asp:TableRow ID="row11">
                <asp:TableCell><igsch:WebDateChooser ID="WebDateChooser11" runat="server" StyleSetName="Office2007Silver" AutoPostBack-ValueChanged="true"></igsch:WebDateChooser></asp:TableCell>
                <asp:TableCell><asp:DropDownList ID="DropDownList11" runat="server" DataSourceID="SqlDataSource1" DataTextField="SchoolDisplay" DataValueField="schoolID"></asp:DropDownList></asp:TableCell>
            </asp:TableRow>  
            <asp:TableRow ID="row12">
                <asp:TableCell><igsch:WebDateChooser ID="WebDateChooser12" runat="server" StyleSetName="Office2007Silver" AutoPostBack-ValueChanged="true"></igsch:WebDateChooser></asp:TableCell>
                <asp:TableCell><asp:DropDownList ID="DropDownList12" runat="server" DataSourceID="SqlDataSource1" DataTextField="SchoolDisplay" DataValueField="schoolID"></asp:DropDownList></asp:TableCell>
            </asp:TableRow>  
            <asp:TableRow ID="row13">
                <asp:TableCell><igsch:WebDateChooser ID="WebDateChooser13" runat="server" StyleSetName="Office2007Silver" AutoPostBack-ValueChanged="true"></igsch:WebDateChooser></asp:TableCell>
                <asp:TableCell><asp:DropDownList ID="DropDownList13" runat="server" DataSourceID="SqlDataSource1" DataTextField="SchoolDisplay" DataValueField="schoolID"></asp:DropDownList></asp:TableCell>
            </asp:TableRow>  
            <asp:TableRow ID="row14">
                <asp:TableCell><igsch:WebDateChooser ID="WebDateChooser14" runat="server" StyleSetName="Office2007Silver" AutoPostBack-ValueChanged="true"></igsch:WebDateChooser></asp:TableCell>
                <asp:TableCell><asp:DropDownList ID="DropDownList14" runat="server" DataSourceID="SqlDataSource1" DataTextField="SchoolDisplay" DataValueField="schoolID"></asp:DropDownList></asp:TableCell>
            </asp:TableRow>  
            <asp:TableRow ID="row15">
                <asp:TableCell><igsch:WebDateChooser ID="WebDateChooser15" runat="server" StyleSetName="Office2007Silver" AutoPostBack-ValueChanged="true"></igsch:WebDateChooser></asp:TableCell>
                <asp:TableCell><asp:DropDownList ID="DropDownList15" runat="server" DataSourceID="SqlDataSource1" DataTextField="SchoolDisplay" DataValueField="schoolID"></asp:DropDownList></asp:TableCell>
            </asp:TableRow>                                                                                                                                                                                            
        </asp:Table>
    </form>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OSSAAConnectionString %>" 
        SelectCommand="SELECT DISTINCT SchoolName AS SchoolDisplay, schoolID FROM tblSchool WHERE OrganizationType = 'SCHOOL' ORDER BY SchoolName"></asp:SqlDataSource>
</body>
</html>
