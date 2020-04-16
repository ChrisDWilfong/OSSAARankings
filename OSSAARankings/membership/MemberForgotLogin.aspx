<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="SiteLogin.Master" CodeBehind="MemberForgotLogin.aspx.vb" Inherits="OSSAARankings.MemberForgotLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table id="tableDetail" style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="lblStep" runat="server" Text="" Font-Bold="True" ForeColor="Red" Font-Size="Large"
                    CssClass="objectTitle"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblTitle" runat="server" Text="" Font-Bold="True" 
                    CssClass="objectTitle"></asp:Label>
            </td>
        </tr>
    </table>
    <table id="tableContent" style="width: 100%;">
            <tr align="center" style="height: 40px">
                <td colspan="2">
                    <b>
                    <asp:Label ID="Label1" runat="server" ForeColor="Black" 
                        Text="Forgot Password Recovery (Existing Member)" Font-Bold="True" 
                        CssClass="label14"></asp:Label>
                    <br />
                    <asp:Label ID="Label3" runat="server" Text="(If you currently have a login into the OSSAA Membership Site and have forgotten it. If your email exists in our system, it will be emailed to you.)" Font-Bold="False" Font-Names="Verdana" Font-Size="8pt"></asp:Label></b>
                </td>
            </tr>
            <tr align="center" style="height: 35px">
                <td align="right">
                    <asp:Label ID="lblSelectPosition" runat="server" Text="Select your Position :" 
                        CssClass="label"></asp:Label>
                </td>
                <td align="left">
                    &nbsp;<asp:DropDownList ID="cboPositions" runat="server" 
                        CssClass="dropDownList">
                        <asp:ListItem>Select...</asp:ListItem>
                        <asp:ListItem>Superintendent</asp:ListItem>
                        <asp:ListItem>High School Principal</asp:ListItem>
                        <asp:ListItem>Athletic Director</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr align="center" style="height: 25px">
                <td align="right">
                    <asp:Label ID="lblSelectSport0" runat="server" Text="Your Name :" 
                        CssClass="label"></asp:Label>
                </td>
                <td align="left">
                    &nbsp;<asp:TextBox ID="txtName" runat="server" Width="300px" CssClass="content"></asp:TextBox>
                </td>
            </tr>
            <tr align="center" style="height: 25px">
                <td align="right">
                    <asp:Label ID="lblSelectSport1" runat="server" Text="Your School :" 
                        CssClass="label"></asp:Label>
                </td>
                <td align="left">
                    &nbsp;<asp:DropDownList ID="cboSchools" runat="server" CssClass="dropDownList"></asp:DropDownList></td>
            </tr>
            <tr align="center" style="height: 25px">
                <td align="right">
                    <asp:Label ID="Label2" runat="server" Text="Enter your email address : " 
                        CssClass="label"></asp:Label>
                </td>
                <td align="left">
                    &nbsp;<asp:TextBox ID="txtEmail" runat="server" Width="400px" 
                        CssClass="content"></asp:TextBox>
                </td>
            </tr>
            <tr align="center" style="height: 25px">
                <td colspan="2">
                    <asp:Button ID="cmdSubmit" runat="server" Text="Submit Request" 
                        CssClass="button" />
                </td>
            </tr>
            <tr align="center" style="height: 25px">
                <td colspan="2">
                    <asp:Label ID="lblMessage" runat="server" Font-Names="Verdana" Font-Size="10pt" 
                        ForeColor="Red"></asp:Label>
                </td>
            </tr>
                        <tr align="center" style="height: 40px">
                <td colspan="2">
                    <b>
                    <asp:Label ID="Label4" runat="server" ForeColor="Black" 
                        Text="Request A Login for Your School (New Member Request)" 
                        Font-Bold="True" CssClass="label14"></asp:Label>
                    <br />
                    <asp:Label ID="Label5" runat="server" Text="(if you are a Superintendent, High School Principal or Athletic Director and have not received login information to the OSSAA Membership Site)" Font-Bold="False" Font-Names="Verdana" Font-Size="8pt"></asp:Label></b>
                    <br />
                    <asp:Label ID="Label11" runat="server" Text="(IF YOU ARE A <strong>MIDDLE SCHOOL OR JR HIGH PRINCIPAL/SITE A/D OF A 6A/5A HIGH SCHOOL</strong>, PLEASE EMAIL cwilfong@ossaa.com WITH YOUR REQUEST)" Font-Bold="False" Font-Names="Verdana" Font-Size="8pt"></asp:Label></b>
                </td>
            </tr>
                        <tr align="center" style="height: 25px">
                <td align="right">
                    <asp:Label ID="Label6" runat="server" Text="Select your Position : " 
                        CssClass="label"></asp:Label>
                </td>
                <td align="left">
                    &nbsp;<asp:DropDownList ID="cboPositions1" runat="server" 
                        CssClass="dropDownList">
                        <asp:ListItem>Select...</asp:ListItem>
                        <asp:ListItem>Superintendent</asp:ListItem>
                        <asp:ListItem>High School Principal</asp:ListItem>
                        <asp:ListItem>Athletic Director</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr align="center" style="height: 25px">
                <td align="right">
                    <asp:Label ID="Label7" runat="server" Text="Your Name :" CssClass="label"></asp:Label>
                </td>
                <td align="left">
                    &nbsp;<asp:TextBox ID="txtName1" runat="server" Width="300px" 
                        CssClass="content"></asp:TextBox>
                </td>
            </tr>
            <tr align="center" style="height: 25px">
                <td align="right">
                    <asp:Label ID="Label8" runat="server" Text="Your School :" 
                        CssClass="label"></asp:Label>
                </td>
                <td align="left">
                    &nbsp;<asp:DropDownList ID="cboSchools1" runat="server" CssClass="dropDownList"></asp:DropDownList></td>
            </tr>
            <tr align="center" style="height: 25px">
                <td align="right">
                    <asp:Label ID="Label10" runat="server" Text="Enter your phone # : " 
                        CssClass="label"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPhone" runat="server" Width="300px" 
                        CssClass="content"></asp:TextBox>
                </td>
            </tr>
            <tr align="center" style="height: 25px">
                <td align="right">
                    <asp:Label ID="Label9" runat="server" Text="Enter your email address : " 
                        CssClass="label"></asp:Label>
                </td>
                <td align="left">
                    &nbsp;<asp:TextBox ID="txtEmail1" runat="server" Width="400px" 
                        CssClass="content"></asp:TextBox>
                </td>
            </tr>
            <tr align="center" style="height: 25px">
                <td colspan="2">
                    <asp:Button ID="cmdSubmit1" runat="server" Text="Submit Request" 
                        CssClass="button" />
                </td>
            </tr>
            </table>
    <table id="tableFooter" style="width: 100%;">
        <tr><td>
            &nbsp;</td></tr>
        <tr><td>
            <asp:Button ID="cmdReturnToLogin" runat="server" CssClass="button" 
                Text="Return to Login Page" CausesValidation="False" />
                </td></tr>
        <tr>
        <td>
            <asp:Label ID="lblCopyright" runat="server" Font-Size="X-Small" Text="Copyright © 2014 OSSAA. All rights reserved.  "></asp:Label><a href="http://www.ossaa.com" target="_blank"><span style="font-family: Century Gothic; Font-Size:X-Small;">OSSAA Home Page</span></a>
        </td>
        </tr>
    </table>
</asp:Content>
