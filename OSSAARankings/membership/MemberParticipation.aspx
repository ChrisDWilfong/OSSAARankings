<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="SiteMembership.Master" CodeBehind="MemberParticipation.aspx.vb" Inherits="OSSAARankings.MemberParticipation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<link href="styles/SiteMembership.css" rel="stylesheet" type="text/css" />
<asp:Table ID="tblPart" runat="server" Width="900px">
    <asp:TableRow>
        <asp:TableCell ColumnSpan="3">
            <asp:Label runat="server" Text="2019-2020 OSSAA Participation Numbers" CssClass="headerHeader" Font-Size="Large" Font-Bold="true"></asp:Label>&nbsp;&nbsp;
            <asp:Label ID="lblMessageSubmit" runat="server" Text="" CssClass="headerHeader" ForeColor="Red"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell ColumnSpan="3"><hr /></asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell ColumnSpan="3">
            <asp:Label runat="server" Text="" ID="lblInfo" CssClass="label10"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell ColumnSpan="3"><hr /></asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell ColumnSpan="3"><asp:Label ID="lblMessage" runat="server" Text="" CssClass="labelMessage" ForeColor="Red" Font-Bold="true"></asp:Label></asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell ColumnSpan="2"><asp:Label runat="server" Text="ATHLETIC ACTIVITIES" CssClass="partLabel" ID="Label30" Width="150px" Font-Bold="true"></asp:Label>
        <asp:Button ID="cmdSave" runat="server" Text="Save Changes" CssClass="buttonSave" ForeColor="Black" />&nbsp;
        <asp:Button ID="cmdSubmit" runat="server" Text="Submit to OSSAA" CssClass="buttonSave" BackColor="Green" ForeColor="Yellow" />
        </asp:TableCell>
        <asp:TableCell><asp:Label runat="server" Text="NON-ATHLETIC ACTIVITIES" CssClass="partLabel" ID="Label29" Width="220px" Font-Bold="true"></asp:Label></asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell><asp:Label runat="server" Text="Boys" CssClass="partHeading" ID="Label21" Width="30px"></asp:Label>&nbsp;<asp:Label runat="server" Text="Girls" CssClass="partHeading" ID="Label2" Width="30px"></asp:Label></asp:TableCell>
        <asp:TableCell><asp:Label runat="server" Text="Boys" CssClass="partHeading" ID="Label5" Width="30px"></asp:Label>&nbsp;<asp:Label runat="server" Text="Girls" CssClass="partHeading" ID="Label6" Width="30px"></asp:Label></asp:TableCell>
        <asp:TableCell><asp:Label runat="server" Text="Students" CssClass="partHeading" ID="Label7" Width="30px"></asp:Label></asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell><asp:TextBox ID="TextBox1" runat="server" CssClass="partValueB" BackColor="LightBlue" style="text-align:right;" Width="25px" TabIndex="1"></asp:TextBox>&nbsp;<asp:TextBox ID="TextBox2" runat="server" CssClass="partValueG" BackColor="Pink" style="text-align:right;" Width="25px" TabIndex="2"></asp:TextBox><asp:Label runat="server" Text="Baseball" CssClass="partLabel" ID="Label1" Width="130px"></asp:Label></asp:TableCell>
        <asp:TableCell><asp:TextBox ID="TextBox3" runat="server" CssClass="partValueB" BackColor="LightBlue" style="text-align:right;" Width="25px" TabIndex="15"></asp:TextBox>&nbsp;<asp:TextBox ID="TextBox4" runat="server" CssClass="partValueG" BackColor="Pink" style="text-align:right;" Width="25px" TabIndex="16"></asp:TextBox><asp:Label runat="server" Text="Soccer" CssClass="partLabel" ID="Label3" Width="130px"></asp:Label></asp:TableCell>
        <asp:TableCell><asp:TextBox ID="TextBox5" runat="server" CssClass="partValue" style="text-align:right;" Width="25px" TabIndex="28"></asp:TextBox><asp:Label runat="server" Text="Band" CssClass="partLabel" ID="Label4" Width="130px"></asp:Label></asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell><asp:TextBox ID="TextBox6" runat="server" CssClass="partValueB" BackColor="LightBlue" style="text-align:right;" Width="25px" TabIndex="3"></asp:TextBox>&nbsp;<asp:TextBox ID="TextBox7" runat="server" CssClass="partValueG" BackColor="Pink" style="text-align:right;" Width="25px" TabIndex="4"></asp:TextBox><asp:Label runat="server" Text="Basketball" CssClass="partLabel" ID="Label8" Width="130px"></asp:Label></asp:TableCell>
        <asp:TableCell><asp:TextBox ID="TextBox8" runat="server" CssClass="partValueB" style="text-align:right;" BackColor="Transparent" BorderColor="Transparent" Enabled="false" Width="25px"></asp:TextBox>&nbsp;<asp:TextBox ID="TextBox9" runat="server" CssClass="partValueG" BackColor="Pink" style="text-align:right;" Width="25px" TabIndex="17"></asp:TextBox><asp:Label runat="server" Text="Softball (Fast Pitch)" CssClass="partLabel" ID="Label9" Width="130px"></asp:Label></asp:TableCell>
        <asp:TableCell><asp:TextBox ID="TextBox10" runat="server" CssClass="partValue" style="text-align:right;" Width="25px" TabIndex="29"></asp:TextBox><asp:Label runat="server" Text="Orchestra" CssClass="partLabel" ID="Label10" Width="130px"></asp:Label></asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell><asp:TextBox ID="TextBox11" runat="server" CssClass="partValueB" BackColor="LightBlue" style="text-align:right;" Width="25px" TabIndex="5"></asp:TextBox>&nbsp;<asp:TextBox ID="TextBox12" runat="server" CssClass="partValueG" BackColor="Pink" style="text-align:right;" Width="25px" TabIndex="6"></asp:TextBox><asp:Label runat="server" Text="Cheerleading" CssClass="partLabel" ID="Label11" Width="130px"></asp:Label></asp:TableCell>
        <asp:TableCell><asp:TextBox ID="TextBox13" runat="server" CssClass="partValueB" style="text-align:right;" BackColor="Transparent" BorderColor="Transparent" Enabled="false" Width="25px"></asp:TextBox>&nbsp;<asp:TextBox ID="TextBox14" runat="server" CssClass="partValueG" BackColor="Pink" style="text-align:right;" Width="25px" TabIndex="18"></asp:TextBox><asp:Label runat="server" Text="Softball (Slow Pitch)" CssClass="partLabel" ID="Label12" Width="130px"></asp:Label></asp:TableCell>
        <asp:TableCell><asp:TextBox ID="TextBox15" runat="server" CssClass="partValue" style="text-align:right;" Width="25px" TabIndex="30"></asp:TextBox><asp:Label runat="server" Text="Vocal Music" CssClass="partLabel" ID="Label13" Width="130px"></asp:Label></asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell><asp:TextBox ID="TextBox16" runat="server" CssClass="partValueB" BackColor="LightBlue" style="text-align:right;" Width="25px" TabIndex="7"></asp:TextBox>&nbsp;<asp:TextBox ID="TextBox17" runat="server" CssClass="partValueG" BackColor="Pink" style="text-align:right;" Width="25px" TabIndex="8"></asp:TextBox><asp:Label runat="server" Text="Cross Country" CssClass="partLabel" ID="Label14" Width="130px"></asp:Label></asp:TableCell>
        <asp:TableCell><asp:TextBox ID="TextBox18" runat="server" CssClass="partValueB" BackColor="LightBlue" style="text-align:right;" Width="25px" TabIndex="19"></asp:TextBox>&nbsp;<asp:TextBox ID="TextBox19" runat="server" CssClass="partValueG" BackColor="Pink" style="text-align:right;" Width="25px" TabIndex="20"></asp:TextBox><asp:Label runat="server" Text="Swimming" CssClass="partLabel" ID="Label15" Width="130px"></asp:Label></asp:TableCell>
        <asp:TableCell><asp:TextBox ID="TextBox20" runat="server" CssClass="partValue" style="text-align:right;" Width="25px" TabIndex="31"></asp:TextBox><asp:Label runat="server" Text="One-Act Plays" CssClass="partLabel" ID="Label16" Width="130px"></asp:Label></asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell><asp:TextBox ID="TextBox21" runat="server" CssClass="partValueB" BackColor="LightBlue" style="text-align:right;" Width="25px" TabIndex="9"></asp:TextBox>&nbsp;<asp:TextBox ID="TextBox22" runat="server" CssClass="partValueG" BackColor="Pink" style="text-align:right;" Width="25px" TabIndex="10"></asp:TextBox><asp:Label runat="server" Text="Football (11 man)" CssClass="partLabel" ID="Label17" Width="130px"></asp:Label></asp:TableCell>
        <asp:TableCell><asp:TextBox ID="TextBox23" runat="server" CssClass="partValueB" BackColor="LightBlue" style="text-align:right;" Width="25px" TabIndex="21"></asp:TextBox>&nbsp;<asp:TextBox ID="TextBox24" runat="server" CssClass="partValueG" BackColor="Pink" style="text-align:right;" Width="25px" TabIndex="22"></asp:TextBox><asp:Label runat="server" Text="Tennis" CssClass="partLabel" ID="Label18" Width="130px"></asp:Label></asp:TableCell>
        <asp:TableCell><asp:TextBox ID="TextBox25" runat="server" CssClass="partValue" style="text-align:right;" Width="25px" TabIndex="32"></asp:TextBox><asp:Label runat="server" Text="Speech/Debate" CssClass="partLabel" ID="Label19" Width="130px"></asp:Label></asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell><asp:TextBox ID="TextBox26" runat="server" CssClass="partValueB" BackColor="LightBlue" style="text-align:right;" Width="25px" TabIndex="11"></asp:TextBox>&nbsp;<asp:TextBox ID="TextBox27" runat="server" CssClass="partValueG" BackColor="Pink" style="text-align:right;" Width="25px" TabIndex="12"></asp:TextBox><asp:Label runat="server" Text="Football (8 man)" CssClass="partLabel" ID="Label20" Width="130px"></asp:Label></asp:TableCell>
        <asp:TableCell><asp:TextBox ID="TextBox28" runat="server" CssClass="partValueB" BackColor="LightBlue" style="text-align:right;" Width="25px" TabIndex="23"></asp:TextBox>&nbsp;<asp:TextBox ID="TextBox29" runat="server" CssClass="partValueG" BackColor="Pink" style="text-align:right;" Width="25px" TabIndex="24"></asp:TextBox><asp:Label runat="server" Text="Track" CssClass="partLabel" ID="Label22" Width="130px"></asp:Label></asp:TableCell>
        <asp:TableCell><asp:TextBox ID="TextBox36" runat="server" CssClass="partValue" style="text-align:right;" Width="25px" TabIndex="33"></asp:TextBox><asp:Label runat="server" Text="Academic Bowl" CssClass="partLabel" ID="Label27" Width="130px"></asp:Label></asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell><asp:TextBox ID="TextBox30" runat="server" CssClass="partValueB" BackColor="LightBlue" style="text-align:right;" Width="25px" TabIndex="13"></asp:TextBox>&nbsp;<asp:TextBox ID="TextBox31" runat="server" CssClass="partValueG" BackColor="Pink" style="text-align:right;" Width="25px" TabIndex="14"></asp:TextBox><asp:Label runat="server" Text="Golf" CssClass="partLabel" ID="Label23" Width="130px"></asp:Label></asp:TableCell>
        <asp:TableCell><asp:TextBox ID="TextBox32" runat="server" CssClass="partValue" style="text-align:right;" BackColor="Transparent" BorderColor="Transparent" Enabled="false" Width="25px"></asp:TextBox>&nbsp;<asp:TextBox ID="TextBox33" runat="server" CssClass="partValueG" BackColor="Pink" style="text-align:right;" Width="25px" TabIndex="25"></asp:TextBox><asp:Label runat="server" Text="Volleyball" CssClass="partLabel" ID="Label24" Width="130px"></asp:Label></asp:TableCell>
        <asp:TableCell>&nbsp;</asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>&nbsp;</asp:TableCell>
        <asp:TableCell><asp:TextBox ID="TextBox34" runat="server" CssClass="partValueB" BackColor="LightBlue" style="text-align:right;" Width="25px" TabIndex="26"></asp:TextBox>&nbsp;<asp:TextBox ID="TextBox35" runat="server" CssClass="partValueG" BackColor="Pink" Width="25px" TabIndex="27" style="text-align:right;"></asp:TextBox><asp:Label runat="server" Text="Wrestling" CssClass="partLabel" ID="Label26" Width="130px"></asp:Label></asp:TableCell>
        <asp:TableCell>&nbsp;</asp:TableCell>
    </asp:TableRow>

</asp:Table>
    <asp:Table id="tableFooter" style="width: 100%;" runat="server">
        <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell><asp:Label ID="Label25" runat="server" Font-Size="X-Small" Text="Copyright © 2018 OSSAA. All rights reserved.  "></asp:Label><a href="http://www.ossaa.com" target="_blank"><span style="font-family: Century Gothic; Font-Size:X-Small;">OSSAA Home Page</span></a></asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
    </asp:Table>
</asp:Content>
