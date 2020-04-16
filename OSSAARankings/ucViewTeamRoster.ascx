<%@ Control Language="VB" AutoEventWireup="false" Inherits="OSSAARankings.ucViewTeamRoster" Codebehind="ucViewTeamRoster.ascx.vb" %>
<div><asp:Image ID="imgTeamPicture" runat="server" Width="400px" BorderWidth="2" /></div>
<div><asp:HyperLink ID="hlPrint" runat="server" Font-Names="Verdana" Font-Size="8pt" NavigateUrl="/PrintRoster.aspx" Target="_blank">Print Version</asp:HyperLink></div>
<br />
<asp:GridView ID="GridView1" runat="server" CellPadding="4" Height="209px" Width="450px" 
    Font-Names="Segoe UI,Verdana,Helvetica,sans-serif" Font-Size="9pt" AutoGenerateColumns="False" 
    ShowFooter="True" BackColor="White" BorderColor="#CC9966" 
    BorderStyle="None" BorderWidth="1px" AllowSorting="True" PageSize="250" 
    DataSourceID="SqlDataSource1">
    <FooterStyle BackColor="#FFFFCC" Height="24px" ForeColor="#330099" />
    <RowStyle BackColor="White" Height="22px" ForeColor="#330099" />
    <Columns>
        <asp:BoundField DataField="DisplayName" HeaderText="Player" ItemStyle-HorizontalAlign="Left" SortExpression="DisplayName" >
            <ItemStyle HorizontalAlign="Left"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="GradeSort" HeaderText="Grade" ItemStyle-HorizontalAlign="Left" SortExpression="GradeSort" >
            <ItemStyle HorizontalAlign="Center"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="Height" HeaderText="Height" ItemStyle-HorizontalAlign="Left" >
            <ItemStyle HorizontalAlign="Center"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="Pos" HeaderText="Position" SortExpression="Pos">
            <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="Jersey" HeaderText="#" ItemStyle-HorizontalAlign="Right" SortExpression="JerseySort" HeaderStyle-HorizontalAlign="Center" >
            <ItemStyle HorizontalAlign="Right"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="rosterID" HeaderText="rosterID" Visible="False" ItemStyle-HorizontalAlign="Left" >
            <ItemStyle HorizontalAlign="Left"></ItemStyle>
        </asp:BoundField>
    </Columns>
    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" 
        Height="24px" HorizontalAlign="Left" />
    <SortedAscendingCellStyle BackColor="#FEFCEB" />
    <SortedAscendingHeaderStyle BackColor="#AF0101" />
    <SortedDescendingCellStyle BackColor="#F6F0C0" />
    <SortedDescendingHeaderStyle BackColor="#7E0000" />
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:OSSAARANKINGSConnectionString %>" 
    SelectCommand="SELECT [Jersey], [LastName] AS Last, [FirstName] AS First, [LastName] + ', ' + [FirstName] AS DisplayName, [Pos], [Height], [Weight], [Grade], [rosterID], [ysnStarter] AS Starter, [ysnPitcher] AS Pitcher, CAST(intJersey AS INT) AS JerseySort, CAST(Grade AS INT) AS GradeSort, Jersey FROM [tblRosters] WHERE ([teamID] = @gTeamID) AND ysnActive <> 0 ORDER BY intJersey">
    <SelectParameters>
        <asp:SessionParameter DefaultValue="0" Name="gTeamID" SessionField="gTeamID" />
    </SelectParameters>
</asp:SqlDataSource>

