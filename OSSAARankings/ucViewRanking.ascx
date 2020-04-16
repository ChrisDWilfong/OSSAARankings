<%@ Control Language="VB" AutoEventWireup="false" Inherits="OSSAARankings.ucViewRanking" Codebehind="ucViewRanking.ascx.vb" %>
<p>
&nbsp;
    <table width="500">
        <tr>
            <td align="center" valign="top">
                <asp:Label ID="lblSport" runat="server" Font-Bold="True" 
                    Font-Names="Century Gothic" Font-Size="14pt" ForeColor="Navy"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" valign="top">
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    CaptionAlign="Left" CellPadding="4" EmptyDataText="No Data Found" 
    Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" GridLines="None" 
    UseAccessibleHeader="False" Width="400px">
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    <Columns>
        <asp:BoundField DataField="Rank" HeaderText="Rank">
            <ItemStyle Width="20px" />
        </asp:BoundField>
        <asp:BoundField DataField="School" HeaderText="School" />
        <asp:BoundField DataField="WL" HeaderText="WL" />
        <asp:BoundField DataField="Points" HeaderText="Points" />
    </Columns>
    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#999999" />
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
</asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="center" valign="top">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" valign="top">
<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
    CaptionAlign="Left" CellPadding="4" EmptyDataText="No Data Found" 
    Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" GridLines="None" 
    Width="400px">
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    <Columns>
        <asp:BoundField DataField="Rank" HeaderText="Rank">
            <ItemStyle Width="20px" />
        </asp:BoundField>
        <asp:BoundField DataField="School" HeaderText="School" />
        <asp:BoundField DataField="WL" HeaderText="WL" />
        <asp:BoundField DataField="Points" HeaderText="Points" />
    </Columns>
    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#999999" />
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
</asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="center" valign="top">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" valign="top">
<asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
    CaptionAlign="Left" CellPadding="4" EmptyDataText="No Data Found" 
    Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" GridLines="None" 
    Width="400px">
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    <Columns>
        <asp:BoundField DataField="Rank" HeaderText="Rank">
            <ItemStyle Width="20px" />
        </asp:BoundField>
        <asp:BoundField DataField="School" HeaderText="School" />
        <asp:BoundField DataField="WL" HeaderText="WL" />
        <asp:BoundField DataField="Points" HeaderText="Points" />
    </Columns>
    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#999999" />
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
</asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="center" valign="top">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" valign="top">
<asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" 
    CaptionAlign="Left" CellPadding="4" EmptyDataText="No Data Found" 
    Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" GridLines="None" 
    Width="400px">
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    <Columns>
        <asp:BoundField DataField="Rank" HeaderText="Rank">
            <ItemStyle Width="20px" />
        </asp:BoundField>
        <asp:BoundField DataField="School" HeaderText="School" />
        <asp:BoundField DataField="WL" HeaderText="WL" />
        <asp:BoundField DataField="Points" HeaderText="Points" />
    </Columns>
    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#999999" />
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
</asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="center" valign="top">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" valign="top">
<asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" 
    CaptionAlign="Left" CellPadding="4" EmptyDataText="No Data Found" 
    Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" GridLines="None" 
    Width="400px">
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    <Columns>
        <asp:BoundField DataField="Rank" HeaderText="Rank">
            <ItemStyle Width="20px" />
        </asp:BoundField>
        <asp:BoundField DataField="School" HeaderText="School" />
        <asp:BoundField DataField="WL" HeaderText="WL" />
        <asp:BoundField DataField="Points" HeaderText="Points" />
    </Columns>
    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#999999" />
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
</asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="center" valign="top">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" valign="top">
<asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" 
    CaptionAlign="Left" CellPadding="4" EmptyDataText="No Data Found" 
    Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" GridLines="None" 
    Width="400px">
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    <Columns>
        <asp:BoundField DataField="Rank" HeaderText="Rank">
            <ItemStyle Width="20px" />
        </asp:BoundField>
        <asp:BoundField DataField="School" HeaderText="School" />
        <asp:BoundField DataField="WL" HeaderText="WL" />
        <asp:BoundField DataField="Points" HeaderText="Points" />
    </Columns>
    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#999999" />
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
</asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="center" valign="top">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" valign="top">
<asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="False" 
    CaptionAlign="Left" CellPadding="4" EmptyDataText="No Data Found" 
    Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" GridLines="None" 
    Width="400px">
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    <Columns>
        <asp:BoundField DataField="Rank" HeaderText="Rank">
            <ItemStyle Width="20px" />
        </asp:BoundField>
        <asp:BoundField DataField="School" HeaderText="School" />
        <asp:BoundField DataField="WL" HeaderText="WL" />
        <asp:BoundField DataField="Points" HeaderText="Points" />
    </Columns>
    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#999999" />
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
</asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="center" valign="top">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" valign="top">
<asp:GridView ID="GridView8" runat="server" AutoGenerateColumns="False" 
    CaptionAlign="Left" CellPadding="4" EmptyDataText="No Data Found" 
    Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" GridLines="None" 
    Width="400px">
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    <Columns>
        <asp:BoundField DataField="Rank" HeaderText="Rank">
            <ItemStyle Width="20px" />
        </asp:BoundField>
        <asp:BoundField DataField="School" HeaderText="School" />
        <asp:BoundField DataField="WL" HeaderText="WL" />
        <asp:BoundField DataField="Points" HeaderText="Points" />
    </Columns>
    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#999999" />
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
</asp:GridView>
            </td>
        </tr>
    </table>
</p>

