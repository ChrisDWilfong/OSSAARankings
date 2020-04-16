<%@ Control Language="vb" AutoEventWireup="false" Inherits="OSSAARankings.ucViewScheduleFPRegionals" Codebehind="ucViewScheduleFPRegionals.ascx.vb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<link href="./mem/mem.css" rel="stylesheet" type="text/css" />
<link href="Rankings.css" rel="stylesheet" type="text/css" />
<asp:Table runat="server" style="width:550px" ID="tblFP101">
    <asp:TableRow ID="rowHeader">
        <asp:TableCell horizontalalign="Center" height="36" ColumnSpan="4">
            <asp:Label ID="Label1" runat="server" Font-Bold="True" CssClass="labelBig" Text="Select Class : "></asp:Label>
            <asp:DropDownList ID="cboClass" runat="server" AutoPostBack="true" DataTextField="class" DataValueField="class" DataSourceID="SqlDataSource1" CssClass="dropdownBig" EnableViewState="true">
                <asp:ListItem Value="Select...">Select...</asp:ListItem>
            </asp:DropDownList>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell horizontalalign="Center" ColumnSpan="4">
            <asp:Label ID="lblSport" runat="server" Text="Sport" Font-Names="Segoe UI, Verdana, Helvetica, sans-serif" Font-Size="16pt" ForeColor="Maroon" Font-Bold="true"></asp:Label>
        </asp:TableCell>
   </asp:TableRow>
   <asp:TableRow HorizontalAlign="Left">
        <asp:TableCell VerticalAlign="Top" >
            <%= Session("content")%>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow><asp:TableCell>
        <asp:Image ID="Image1" runat="server" src="images/sponsors/regionalSponsor.gif" /><asp:Image ID="Image2" runat="server" src="images/sponsors/fallSponsor.gif" /><asp:Image ID="Image3" runat="server" src="images/sponsors/playoffSponsor.gif" /><asp:Image ID="Image4" runat="server" src="images/sponsors/scoreboardSponsor.gif" />
    </asp:TableCell></asp:TableRow>
</asp:Table>

<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:OSSAARANKINGSConnectionString %>" 
    SelectCommand="SELECT DISTINCT [Class], [Sort], [sportID] FROM [tblSports] WHERE ([SportGenderKey] = @Sport) AND ([Class] <> '-') AND ([intPlayoffsScheduleShowRegionals] > 0) ORDER BY [Sort]">
    <SelectParameters>
        <asp:SessionParameter DefaultValue="" Name="Sport" SessionField="gSportGenderKey" Type="String" />
    </SelectParameters>
</asp:SqlDataSource>



