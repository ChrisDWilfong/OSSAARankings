<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FBCrewTest.aspx.vb" Inherits="OSSAARankings.FBCrewTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register assembly="Infragistics4.WebUI.WebDateChooser.v10.2, Version=10.2.20102.1011, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.WebUI.WebSchedule" tagprefix="igsch" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>OSSAA Football Crew Test Information</title>
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
        <asp:Table ID="tblFBAvail" runat="server" Width="370px">

            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="Label4" runat="server" Text="OSSAA 2019 Football Crew Test Information" CssClass="header"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top" Width="150px">
                    <asp:Label ID="lblEmail" runat="server" Text="Your Email :" CssClass="label8"></asp:Label><asp:Label runat="server" ID="Label6" CssClass="label" ForeColor="Red">*</asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="text" Width="100%"></asp:TextBox><asp:Button ID="cmdGo" runat="server" Text="Go" CssClass="button" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="row001">
                <asp:TableCell Width="150px">
                    <asp:Label ID="lblName" runat="server" Text="Your Name :" CssClass="label8"></asp:Label><asp:Label runat="server" ID="red1" CssClass="label" ForeColor="Red">*</asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtName" runat="server" CssClass="text"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="row002">
                <asp:TableCell Width="150px">
                    <asp:Label ID="lblOSSAAID" runat="server" Text="Your OSSAAID# :" CssClass="label8"></asp:Label><asp:Label runat="server" ID="Label7" CssClass="label" ForeColor="Red">*</asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtOSSAAID" runat="server" CssClass="text"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow ID="row003">
                <asp:TableCell Width="150px">
                    <asp:Label ID="lblAreaCoord" runat="server" Text="Your Area Coord :" CssClass="label8"></asp:Label><asp:Label runat="server" ID="Label8" CssClass="label" ForeColor="Red">*</asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtAreaCoord" runat="server" CssClass="text"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow ID="row004">
                <asp:TableCell Width="150px">
                    <asp:Label ID="lblLocation" runat="server" Text="Test Date/Loc :" CssClass="label8" Width="200px"></asp:Label><asp:Label runat="server" ID="Label2" CssClass="label" ForeColor="Red">*</asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList runat="server" ID="cboLocation" CssClass="text" DataSourceID="SqlDataSource2" DataValueField="intCrewTestLocation" DataTextField="strCrewTestLocation">
                    </asp:DropDownList>
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

    </form>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OSSAAConnectionString %>" 
        SelectCommand="SELECT DISTINCT SchoolName AS SchoolDisplay, schoolID FROM tblSchool WHERE OrganizationType = 'SCHOOL' ORDER BY SchoolName"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OSSAAConnectionString %>" 
        SelectCommand="SELECT * FROM tblCrewTestLocations ORDER BY intCrewTestLocation"></asp:SqlDataSource>

</body>
</html>
