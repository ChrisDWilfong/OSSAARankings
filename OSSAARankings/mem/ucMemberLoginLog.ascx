<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucMemberLoginLog.ascx.vb" Inherits="OSSAARankings.ucMemberLoginLog" %>
    <div>
        <asp:GridView ID="GridView1" runat="server" BackColor="White" 
            BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="Sqldatasource1" >
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" Font-Names="Arial" Font-Size="12px" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SortedAscendingCellStyle BackColor="#EDF6F6" />
            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
            <SortedDescendingCellStyle BackColor="#D6DFDF" />
            <SortedDescendingHeaderStyle BackColor="#002876" />
        </asp:GridView>
    </div>
<asp:sqldatasource ID="Sqldatasource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:OSSAARANKINGSConnectionString %>" 
    SelectCommand="SELECT [dtmStamp] AS LoginDate, ID FROM [tblMembersLogin] WHERE ([memberID] = @memberID) AND dtmStamp > '2016-08-01' ORDER BY [dtmStamp] DESC">
    <SelectParameters>
        <asp:SessionParameter Name="memberID" SessionField="memgMemberID" 
            Type="Int32" />
    </SelectParameters>
</asp:sqldatasource>

