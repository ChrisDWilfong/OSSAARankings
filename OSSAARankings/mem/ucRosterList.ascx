<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucRosterList.ascx.vb" Inherits="OSSAARankings.ucRosterList" %>
<link href="mem.css" rel="stylesheet" type="text/css" />
<div>
<asp:GridView ID="GridView1" runat="server" CellPadding="4" Width="300px" 
    Font-Names="Segoe UI,Verdana,Helvetica,sans-serif" Font-Size="9pt" AutoGenerateColumns="False" 
    ShowFooter="True" BackColor="White" BorderColor="#CC9966" 
    BorderStyle="None" BorderWidth="1px" AllowSorting="True">
    <FooterStyle BackColor="#FFFFCC" Height="24px" ForeColor="#330099" />
    <RowStyle BackColor="White" Height="22px" ForeColor="#330099" />
    <Columns>        
        <asp:HyperLinkField DataNavigateUrlFields="DisplayName" DataNavigateUrlFormatString="?sel=ScheduleEdit&r={0}" DataTextField="DisplayName" HeaderText="Player"  ItemStyle-HorizontalAlign="Left" SortExpression="DisplayName" >
            <ItemStyle HorizontalAlign="Left" Width="45%"></ItemStyle>
        </asp:HyperLinkField>
        <asp:BoundField DataField="GradeSort" HeaderText="Grade" ItemStyle-HorizontalAlign="Left" SortExpression="GradeSort" >
            <ItemStyle HorizontalAlign="Center"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="Height" HeaderText="Height" ItemStyle-HorizontalAlign="Left" >
            <ItemStyle HorizontalAlign="Center"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="Pos" HeaderText="Position" SortExpression="Pos">
            <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="Jersey" HeaderText="#" ItemStyle-HorizontalAlign="Left" SortExpression="JerseySort" >
            <ItemStyle HorizontalAlign="Left"></ItemStyle>
        </asp:BoundField>
        <asp:CheckBoxField DataField="ysnPitcher" HeaderText="Pitch?" ItemStyle-HorizontalAlign="Center" SortExpression="ysnPitcher"  ReadOnly="True" >
        </asp:CheckBoxField>
        <asp:BoundField DataField="rosterID" HeaderText="rosterID" Visible="False" ItemStyle-HorizontalAlign="Left" >
            <ItemStyle HorizontalAlign="Left"></ItemStyle>
        </asp:BoundField>
    </Columns>
    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" Height="24px" HorizontalAlign="Left" />
    <SortedAscendingCellStyle BackColor="#FEFCEB" />
    <SortedAscendingHeaderStyle BackColor="#AF0101" />
    <SortedDescendingCellStyle BackColor="#F6F0C0" />
    <SortedDescendingHeaderStyle BackColor="#7E0000" />
</asp:GridView>
</div>


