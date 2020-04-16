<%@ Control Language="VB" AutoEventWireup="false" Inherits="OSSAARankings.ucViewRankingAll5" Codebehind="ucViewRankingAll5.ascx.vb" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajax" %>
<link href="Rankings.css" rel="stylesheet" type="text/css" />
<div>
    <asp:Table runat="server" width="500">
        <asp:TableRow>
            <asp:TableCell  HorizontalAlign="center" VerticalAlign="top">
                <asp:Label ID="lblSport" runat="server" CssClass="headerStyle"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="center" VerticalAlign="top">
                <asp:Label ID="lblSportSubHeader" runat="server" CssClass="headerStyle" ForeColor="Black" Visible="false" Text="No Rankings Available"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>    
            <asp:TableCell HorizontalAlign="center" VerticalAlign="top">
                <asp:Label ID="Label1" runat="server" Text="" CssClass="headerStyleGrid"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:HyperLink ID="hlPrint" runat="server" Font-Names="Verdana" Font-Size="8pt" NavigateUrl="PrintRankings.aspx?sel=tr" Target="_blank">Print Version</asp:HyperLink><br />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="center" VerticalAlign="top">
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
                        <asp:TemplateField ItemStyle-Width="40" ItemStyle-HorizontalAlign="Right" HeaderText="School">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Eval("School") %>' Width="200px" ID="lblSchool1" style="text-align:left; text-decoration:underline;" ></asp:Label>
                                <ajax:popupcontrolextender id="PopupControlExtender1" runat="server" popupcontrolid="Panel1"
                                    targetcontrolid="lblSchool1" dynamiccontextkey='<%# Eval("teamID") %>' dynamiccontrolid="Panel1"
                                    dynamicservicemethod="GetDynamicContent" position="Bottom">
                                </ajax:popupcontrolextender>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="TotalPoints" HeaderText="Points" />
                    </Columns>
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="center" VerticalAlign="top">&nbsp;</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>    
            <asp:TableCell HorizontalAlign="center" VerticalAlign="top">
                <asp:Label ID="Label2" runat="server" Text="" CssClass="headerStyleGrid"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="center" VerticalAlign="top">
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
                        <asp:TemplateField ItemStyle-Width="40" ItemStyle-HorizontalAlign="Right" HeaderText="School">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Eval("School") %>' Width="200px" ID="lblSchool1" style="text-align:left; text-decoration:underline;" ></asp:Label>
                                <ajax:popupcontrolextender id="PopupControlExtender1" runat="server" popupcontrolid="Panel1"
                                    targetcontrolid="lblSchool1" dynamiccontextkey='<%# Eval("teamID") %>' dynamiccontrolid="Panel1"
                                    dynamicservicemethod="GetDynamicContent" position="Bottom">
                                </ajax:popupcontrolextender>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="TotalPoints" HeaderText="Points" />
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
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="center" VerticalAlign="top">&nbsp;</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>    
            <asp:TableCell HorizontalAlign="center" VerticalAlign="top">
                <asp:Label ID="Label3" runat="server" Text="" CssClass="headerStyleGrid"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="center" VerticalAlign="top">
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
                        <asp:TemplateField ItemStyle-Width="40" ItemStyle-HorizontalAlign="Right" HeaderText="School">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Eval("School") %>' Width="200px" ID="lblSchool1" style="text-align:left; text-decoration:underline;" ></asp:Label>
                                <ajax:popupcontrolextender id="PopupControlExtender1" runat="server" popupcontrolid="Panel1"
                                    targetcontrolid="lblSchool1" dynamiccontextkey='<%# Eval("teamID") %>' dynamiccontrolid="Panel1"
                                    dynamicservicemethod="GetDynamicContent" position="Bottom">
                                </ajax:popupcontrolextender>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="TotalPoints" HeaderText="Points" />
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
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="center" VerticalAlign="top">&nbsp;</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>    
            <asp:TableCell HorizontalAlign="center" VerticalAlign="top">
                <asp:Label ID="Label4" runat="server" Text="" CssClass="headerStyleGrid"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="center" VerticalAlign="top">
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
                        <asp:TemplateField ItemStyle-Width="40" ItemStyle-HorizontalAlign="Right" HeaderText="School">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Eval("School") %>' Width="200px" ID="lblSchool1" style="text-align:left; text-decoration:underline;" ></asp:Label>
                                <ajax:popupcontrolextender id="PopupControlExtender1" runat="server" popupcontrolid="Panel1"
                                    targetcontrolid="lblSchool1" dynamiccontextkey='<%# Eval("teamID") %>' dynamiccontrolid="Panel1"
                                    dynamicservicemethod="GetDynamicContent" position="Bottom">
                                </ajax:popupcontrolextender>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="TotalPoints" HeaderText="Points" />
                    </Columns>
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="center" VerticalAlign="top">&nbsp;</asp:TableCell>
        </asp:TableRow>
 </asp:Table>
</div>
<div>
<asp:Panel ID="Panel1" runat="server">
</asp:Panel>
</div>

