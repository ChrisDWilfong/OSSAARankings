<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucDistrictStandings1.ascx.vb" Inherits="OSSAARankings.ucDistrictStandings1" %>
    <asp:Table runat="server" ID="tblDS">
    <asp:TableRow>
        <asp:TableCell>
            <hr /><br />
            <asp:Label ID="lblHeader" runat="server" Text="" style="font-family:Arial; font-size: 16px;"></asp:Label><br />
            <asp:Label ID="lblHeader1" runat="server" Text="" style="font-family:Arial; font-size: 16px; color:Maroon; font-weight:bold;"></asp:Label><br />
            <asp:Label ID="lblDate" runat="server" Text="" style="font-family:Century Gothic; font-size: 10px;"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow valign="top">
        <asp:TableCell>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                CellPadding="3" Width="100%" Font-Names="Century Gothic" Font-Size="11px" CaptionAlign="Left">
            <Columns>
                <asp:BoundField DataField="SchoolName" SortExpression="SchoolName" HeaderText="School"  >
                    <ControlStyle Width="140px" />
                    <ItemStyle Width="140px" HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="WL" SortExpression="WL" HeaderText="W/L" ItemStyle-HorizontalAlign="Center">
                    <ControlStyle Width="35px" />
                    <HeaderStyle HorizontalAlign="Center" Width="35px" />
                    <ItemStyle Width="35px" />
                </asp:BoundField>
                <asp:BoundField DataField="DistrictWL" SortExpression="DistrictWL" HeaderText="D W/L" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="LightGray">
                    <ControlStyle Width="35px" />
                    <HeaderStyle HorizontalAlign="Center" Width="35px" />
                    <ItemStyle Width="35px" />
                </asp:BoundField>
                <asp:BoundField DataField="TotalPoints" SortExpression="TotalPoints" HeaderText="Pts" ItemStyle-HorizontalAlign="Center">
                    <ControlStyle Width="35px" />
                    <HeaderStyle HorizontalAlign="Center" Width="35px" />
                    <ItemStyle Width="35px" />
                </asp:BoundField>
                <asp:BoundField DataField="oTotalPoints" SortExpression="oTotalPoints" HeaderText="Opp" ItemStyle-HorizontalAlign="Center">
                    <ControlStyle Width="35px" />
                    <HeaderStyle HorizontalAlign="Center" Width="35px" />
                    <ItemStyle Width="35px" />
                </asp:BoundField>
                <asp:BoundField DataField="DistrictPoints" SortExpression="DistrictPoints" HeaderText="D Pts" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="LightGray">
                    <ControlStyle Width="35px" />
                    <HeaderStyle HorizontalAlign="Center" Width="35px" />
                    <ItemStyle Width="35px" />
                </asp:BoundField>
                <asp:CommandField SelectText="Scores" ShowSelectButton="True" ItemStyle-Width="1px" Visible="false" />
                <asp:BoundField DataField="SchoolID" ReadOnly="True">
                <ItemStyle Font-Size="1px" ForeColor="White" Width="1px" />
                </asp:BoundField>
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
</asp:Table>
</asp:ScriptManager>

