<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="stats.aspx.vb" Inherits="OSSAARankings.stats" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>OSSAARankings.com - Stats</title>
<style>
    .label 
    {
        font-family:Verdana;
        font-size: 10pt;
        font-weight:bold;
    }
    .label8 
    {
        font-family:Verdana;
        font-size: 8pt;
    }    
    .header 
    {
        font-family:Arial;
        font-size: 12pt;
        font-weight:bold;
        color:Maroon;
    }        
</style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Table runat="server">
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblHeader" runat="server" Text="OSSAARankings.com Stats" CssClass="header"></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblDate" runat="server" Text="" CssClass="label8"></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><img src="../images/ig_menutri.gif" /><asp:Label ID="lblMemberLoginsAD" runat="server" Text="" CssClass="label"></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><img src="../images/ig_menutri.gif" /><asp:Label ID="lblMemberLoginsCoaches" runat="server" Text="" CssClass="label"></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><img src="../images/ig_menutri.gif" /><asp:Label ID="lblCoachesNo" runat="server" Text="" CssClass="label"></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><img src="../images/ig_menutri.gif" /><asp:Label ID="lblSchoolSubmittedCoaches" runat="server" Text="" CssClass="label"></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><img src="../images/ig_menutri.gif" /><asp:Label ID="lblCoachesAssignedToTeams" runat="server" Text="" CssClass="label"></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><img src="../images/ig_menutri.gif" /><asp:Label ID="lblRosters" runat="server" Text="" CssClass="label"></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><hr /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><img src="../images/ig_menutri.gif" /><asp:Label ID="lblSchedulesFootball" runat="server" Text="" CssClass="label"></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><img src="../images/ig_menutri.gif" /><asp:Label ID="lblSchedulesVolleyball" runat="server" Text="" CssClass="label"></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><img src="../images/ig_menutri.gif" /><asp:Label ID="lblSchedulesFPSoftball" runat="server" Text="" CssClass="label"></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><hr /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><img src="../images/ig_menutri.gif" /><asp:Label ID="lblSchedulesBasketballBoys" runat="server" Text="" CssClass="label"></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><img src="../images/ig_menutri.gif" /><asp:Label ID="lblSchedulesBasketballGirls" runat="server" Text="" CssClass="label"></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><img src="../images/ig_menutri.gif" /><asp:Label ID="lblSchedulesWrestling" runat="server" Text="" CssClass="label"></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><hr /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><img src="../images/ig_menutri.gif" /><asp:Label ID="lblSchedulesTotal" runat="server" Text="" CssClass="label"></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><img src="../images/ig_menutri.gif" /><asp:Label ID="lblErrors" runat="server" Text="" CssClass="label"></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell><hr /></asp:TableCell></asp:TableRow>
            <asp:TableRow BackColor="Gray">
                <asp:TableCell>
                    <asp:Label ID="Label1" runat="server" Text="Number of Coaches Submitted" Font-Names="Verdana"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="Black" 
            GridLines="Vertical" AllowSorting="True" >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="SchoolName" HeaderText="School" SortExpression="SchoolName">
                    <HeaderStyle Font-Names="Verdana" Font-Size="8pt" />
                    <ItemStyle Font-Names="Verdana" Font-Size="8pt" HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="CoachCount" HeaderText="# Coaches" ReadOnly="True" SortExpression="CoachCount">
                    <HeaderStyle Font-Names="Verdana" Font-Size="8pt" />
                    <ItemStyle Font-Names="Verdana" Font-Size="8pt" HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="schFootball" HeaderText="FB" ReadOnly="True" SortExpression="schFootball">
                    <HeaderStyle Font-Names="Verdana" Font-Size="8pt" />
                    <ItemStyle Font-Names="Verdana" Font-Size="8pt" HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="schBaseballFall" HeaderText="FBA" ReadOnly="True" SortExpression="schBaseballFall">
                    <HeaderStyle Font-Names="Verdana" Font-Size="8pt" />
                    <ItemStyle Font-Names="Verdana" Font-Size="8pt" HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="schFPSoftball" HeaderText="FP" ReadOnly="True" SortExpression="schFPSoftball">
                    <HeaderStyle Font-Names="Verdana" Font-Size="8pt" />
                    <ItemStyle Font-Names="Verdana" Font-Size="8pt" HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="schCrossCountryBoys" HeaderText="XCB" ReadOnly="True" SortExpression="schCrossCountryBoys">
                    <HeaderStyle Font-Names="Verdana" Font-Size="8pt" />
                    <ItemStyle Font-Names="Verdana" Font-Size="8pt" HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="schCrossCountryGirls" HeaderText="XCG" ReadOnly="True" SortExpression="schCrossCountryGirls">
                    <HeaderStyle Font-Names="Verdana" Font-Size="8pt" />
                    <ItemStyle Font-Names="Verdana" Font-Size="8pt" HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="schCheerleading" HeaderText="CH" ReadOnly="True" SortExpression="schCheerleading">
                    <HeaderStyle Font-Names="Verdana" Font-Size="8pt" />
                    <ItemStyle Font-Names="Verdana" Font-Size="8pt" HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="schVolleyball" HeaderText="VB" ReadOnly="True" SortExpression="schVolleyball">
                    <HeaderStyle Font-Names="Verdana" Font-Size="8pt" />
                    <ItemStyle Font-Names="Verdana" Font-Size="8pt" HorizontalAlign="Right" />
                </asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
    </form>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OSSAARANKINGSConnectionString %>" SelectCommand="SELECT * FROM viewStats"></asp:SqlDataSource>
</body>
</html>
