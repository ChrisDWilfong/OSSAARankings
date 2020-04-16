<%@ Control Language="VB" AutoEventWireup="false" Inherits="OSSAARankings.ucRankingsPreviousDetails" Codebehind="ucRankingsPreviousDetails.ascx.vb" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<link href="Rankings.css" rel="stylesheet" type="text/css" />
<div>
    <table width="500">
        <tr>
            <td align="center" valign="top">
                <asp:Label ID="lblSport" runat="server" CssClass="headerStyle"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" valign="top">
                <asp:Label ID="lblSportSubHeader" runat="server" CssClass="headerStyle" ForeColor="Black" Visible="false" Text="No Rankings Available"></asp:Label>
            </td>
        </tr>
        <tr>    
            <td align="center" valign="top">
                <asp:Label ID="Label1" runat="server" Text="" CssClass="headerStyleGrid"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:HyperLink ID="hlPrint" runat="server" Font-Names="Verdana" Font-Size="8pt" NavigateUrl="PrintRankings.aspx?sel=tr" Target="_blank">Print Version</asp:HyperLink><br />
            </td>
        </tr>
        <tr>
            <td align="center" valign="top">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    CaptionAlign="Left" CellPadding="4" 
                    Font-Names="Verdana" Font-Size="8pt" 
                    UseAccessibleHeader="False" Width="400px"
                    EmptyDataText="No Rankings Available" ForeColor="#333333" GridLines="Both"
                    BorderColor="#CC9966" BorderStyle="None" BorderWidth="1pt">
                    <FooterStyle BackColor="#990000" ForeColor="White" Font-Bold="True" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Rank" HeaderText="Rank">
                            <ItemStyle Width="20px" HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="School" HeaderText="School (#1 Rankings)" >
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="WL" HeaderText="W-L" />
                        <asp:BoundField DataField="Points" HeaderText="Points" />
                    </Columns>
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="center" valign="top">&nbsp;</td>
        </tr>
        <tr>    
            <td align="center" valign="top">
                <asp:Label ID="Label2" runat="server" Text="" CssClass="headerStyleGrid"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" valign="top">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                    CaptionAlign="Left" CellPadding="4" EmptyDataText="No Data Found" 
                    Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" GridLines="Both"
                    BorderColor="#CC9966" BorderStyle="None" BorderWidth="1pt"
                    Width="400px">
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="Rank" HeaderText="Rank">
                            <ItemStyle Width="20px" HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="School" HeaderText="School (#1 Rankings)" >
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="WL" HeaderText="W-L" />
                        <asp:BoundField DataField="Points" HeaderText="Points" />
                    </Columns>
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="center" valign="top">&nbsp;</td>
        </tr>
        <tr>    
            <td align="center" valign="top">
                <asp:Label ID="Label3" runat="server" Text="" CssClass="headerStyleGrid"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" valign="top">
                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
                    CaptionAlign="Left" CellPadding="4" EmptyDataText="No Data Found" 
                    Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" GridLines="Both"
                    BorderColor="#CC9966" BorderStyle="None" BorderWidth="1pt" 
                    Width="400px">
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="Rank" HeaderText="Rank">
                            <ItemStyle Width="20px" HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="School" HeaderText="School (#1 Rankings)" >
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="WL" HeaderText="W-L" />
                        <asp:BoundField DataField="Points" HeaderText="Points" />
                    </Columns>
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="center" valign="top">&nbsp;</td>
        </tr>
        <tr>    
            <td align="center" valign="top">
                <asp:Label ID="Label4" runat="server" Text="" CssClass="headerStyleGrid"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" valign="top">
                <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" 
                    CaptionAlign="Left" CellPadding="4" EmptyDataText="No Data Found" 
                    Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" GridLines="Both"
                    BorderColor="#CC9966" BorderStyle="None" BorderWidth="1pt" 
                    Width="400px">
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Rank" HeaderText="Rank">
                            <ItemStyle Width="20px" HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="School" HeaderText="School (#1 Rankings)" >
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="WL" HeaderText="W-L" />
                        <asp:BoundField DataField="Points" HeaderText="Points" />
                    </Columns>
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="center" valign="top">&nbsp;</td>
        </tr>
        <tr>    
            <td align="center" valign="top">
                <asp:Label ID="Label5" runat="server" Text="" CssClass="headerStyleGrid"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" valign="top">
                <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" 
                    CaptionAlign="Left" CellPadding="4" EmptyDataText="No Data Found" 
                    Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" GridLines="Both"
                    BorderColor="#CC9966" BorderStyle="None" BorderWidth="1pt" 
                    Width="400px">
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="Rank" HeaderText="Rank">
                            <ItemStyle Width="20px" HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="School" HeaderText="School (#1 Rankings)" >
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="WL" HeaderText="W-L" />
                        <asp:BoundField DataField="Points" HeaderText="Points" />
                    </Columns>
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="center" valign="top">&nbsp;</td>
        </tr>
        <tr>    
            <td align="center" valign="top">
                <asp:Label ID="Label6" runat="server" Text="" CssClass="headerStyleGrid"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" valign="top">
                <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" 
                    CaptionAlign="Left" CellPadding="4" EmptyDataText="No Data Found" 
                    Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" GridLines="Both"
                    BorderColor="#CC9966" BorderStyle="None" BorderWidth="1pt" 
                    Width="400px">
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="Rank" HeaderText="Rank">
                            <ItemStyle Width="20px" HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="School" HeaderText="School (#1 Rankings)" >
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="WL" HeaderText="W-L" />
                        <asp:BoundField DataField="Points" HeaderText="Points" />
                    </Columns>
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="center" valign="top">&nbsp;</td>
        </tr>
        <tr>    
            <td align="center" valign="top">
                <asp:Label ID="Label7" runat="server" Text="" CssClass="headerStyleGrid"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" valign="top">
                <asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="False" 
                    CaptionAlign="Left" CellPadding="4" EmptyDataText="No Data Found" 
                    Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" GridLines="Both" 
                    BorderColor="#CC9966" BorderStyle="None" BorderWidth="1pt"
                    Width="400px">
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="Rank" HeaderText="Rank">
                            <ItemStyle Width="20px" HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="School" HeaderText="School (#1 Rankings)" >
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="WL" HeaderText="W-L" />
                        <asp:BoundField DataField="Points" HeaderText="Points" />
                    </Columns>
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="center" valign="top">&nbsp;</td>
        </tr>
        <tr>    
            <td align="center" valign="top">
                <asp:Label ID="Label8" runat="server" Text="" CssClass="headerStyleGrid"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" valign="top">
                <asp:GridView ID="GridView8" runat="server" AutoGenerateColumns="False" 
                    CaptionAlign="Left" CellPadding="4" EmptyDataText="No Data Found" 
                    Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" GridLines="Both"
                    BorderColor="#CC9966" BorderStyle="None" BorderWidth="1pt" 
                    Width="400px">
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="Rank" HeaderText="Rank">
                            <ItemStyle Width="20px" HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="School" HeaderText="School (#1 Rankings)" >
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="WL" HeaderText="W-L" />
                        <asp:BoundField DataField="Points" HeaderText="Points" />
                    </Columns>
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
            </td>
        </tr>
</table>
</div>

