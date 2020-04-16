<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucRankingsOthers.ascx.vb" Inherits="OSSAARankings.ucRankingsOthers" %>
<%@ Register src="ucRankingsOthersDetails.ascx" tagname="ucRankingsOthersDetails" tagprefix="uc1" %>
<link href="mem.css" rel="stylesheet" type="text/css" />
<asp:UpdateProgress ID="updProgress100" AssociatedUpdatePanelID="UpdatePanelRankingsOthers" runat="server" ViewStateMode="Enabled">
    <ProgressTemplate>  
        <img alt="Loading..." src="../images/loading.gif"/><span style="font-family: Arial; font-size:12px; font-style:italic;">&nbsp;&nbsp;Loading...</span>
    </ProgressTemplate>
</asp:UpdateProgress>
<asp:UpdatePanel ID="UpdatePanelRankingsOthers" runat="server" UpdateMode="Conditional">
    <Triggers>
        <asp:PostBackTrigger ControlID="cmdGo" />
    </Triggers>
    <ContentTemplate>
    <asp:Panel ID="PanelRankingsOthers" runat="server">
        <asp:Table runat="server" ID="tblRO1">
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:TableCell><asp:Label ID="lblMessage" runat="server" Text="" CssClass="labelMessage"></asp:Label></asp:TableCell>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="lblSelectWeek" runat="server" Text="Select Week :&nbsp;&nbsp;" CssClass="rankingsLabel"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:DropDownList runat="server" ID="cboSelectWeek" CssClass="rankingsDropdown" DataValueField="intWeekNo" DataTextField="strDisplay" BackColor="LightGreen"></asp:DropDownList></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="lblSelectSchool" runat="server" Text="Select School :&nbsp;&nbsp;" CssClass="rankingsLabel"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:DropDownList runat="server" ID="cboSelectSchool" CssClass="rankingsDropdown" DataValueField="teamID" DataTextField="school" BackColor="LightGreen"></asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>&nbsp;</asp:TableCell>
            <asp:TableCell><asp:Button runat="server" Text="Load Rankings" cssclass="buttonSave" id="cmdGo" ></asp:Button></asp:TableCell>
        </asp:TableRow>
        </asp:Table>
        <asp:Label ID="lblHeader" runat="server" Text="Other Coaches Rankings" Font-Bold="true" CssClass="memHeader"></asp:Label><br />
        <uc1:ucRankingsOthersDetails ID="ucRankingsOthersDetails1" runat="server" />
    </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
