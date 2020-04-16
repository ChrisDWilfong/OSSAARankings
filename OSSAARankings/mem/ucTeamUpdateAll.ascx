<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucTeamUpdateAll.ascx.vb" Inherits="OSSAARankings.ucTeamUpdateAll" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<link href="mem.css" rel="stylesheet" type="text/css" />
<ajax:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" TargetControlID="PanelMyTeamUpdate" Radius="5" BorderColor="gray"></ajax:RoundedCornersExtender>
<div><hr /></div>
<asp:Panel ID="PanelTeamUpdateAll" runat="server" CssClass="panelSmall">
<asp:UpdatePanel ID="UpdatePanelTeamUpdateAll" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <ajax:RoundedCornersExtender ID="RoundedCornersExtender2" runat="server" TargetControlID="lblHeader" Radius="3" BorderColor="gray"></ajax:RoundedCornersExtender>
        <asp:Table runat="server" ID="lblTeamUpdateAll" Width="100%">
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="lblHeader" runat="server" CssClass="headerSmall" Height="24px" Text="OTHER My Team Updates" Width="100%"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:Label ID="lblMessage" runat="server" CssClass="labelMessage"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="row1">
            <asp:TableCell>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="3" DataSourceID="SqlDataSource1" Width="422px" 
                        Font-Names="Century Gothic" Font-Size="11px" CaptionAlign="Left" EmptyDataText="No Team Updates Available">
                    <Columns>
                        <asp:TemplateField ItemStyle-Width="40" ItemStyle-HorizontalAlign="Left" HeaderText="Click team below for My Team Update...">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Eval("SchoolNameClassDate")%>' Width="100%" ID="lblSchool1" style="text-align:left; text-decoration:underline;" ></asp:Label>
                                <ajax:popupcontrolextender id="PopupControlExtender1" runat="server" popupcontrolid="PanelMyTeamUpdate"
                                    targetcontrolid="lblSchool1" dynamiccontextkey='<%# Eval("teamID") %>' dynamiccontrolid="PanelMyTeamUpdate"
                                    dynamicservicemethod="GetDynamicContentTeamUpdate" position="Bottom">
                                </ajax:popupcontrolextender>
                            </ItemTemplate>
                        </asp:TemplateField>
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
        <asp:TableRow>
            <asp:TableCell>&nbsp;</asp:TableCell>
        </asp:TableRow>
        </asp:Table>
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Panel>
<asp:Panel ID="PanelMyTeamUpdate" runat="server">
</asp:Panel>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OSSAARANKINGSConnectionString %>" 
        SelectCommand="SELECT TOP 20 * FROM viewTeamUpdateAllLastDetails WHERE SportID = @SportID ORDER BY Id DESC">
        <SelectParameters>
            <asp:SessionParameter Name="SportID" SessionField="memgSportID" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>


