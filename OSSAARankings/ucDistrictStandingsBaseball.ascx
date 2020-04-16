<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucDistrictStandingsBaseball.ascx.vb" Inherits="OSSAARankings.ucDistrictStandingsBaseball" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>    
<asp:Table runat="server" height="100%">
    <asp:TableRow><asp:TableCell>
        <asp:Label ID="lblHeader" runat="server" Text="<b>OSSAA Baseball 6A-2A District Standings</b>" style="font-family:Century Gothic; font-size: 16px;"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
    <asp:TableCell>
        <asp:DropDownList ID="cboClass1" runat="server" style="font-family:Arial; font-size:14px;" AutoPostBack="True" Font-Bold="true" ForeColor="Maroon">
            <asp:ListItem Value="Z">Select Class...</asp:ListItem>
            <asp:ListItem>6A</asp:ListItem>
            <asp:ListItem>5A</asp:ListItem>
            <asp:ListItem>4A</asp:ListItem>
			<asp:ListItem>3A</asp:ListItem>
			<asp:ListItem>2A</asp:ListItem>
        </asp:DropDownList>
    </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow  VerticalAlign="Top" ID="grid1" Visible="false">
        <asp:TableCell VerticalAlign="Top">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                CellPadding="3" DataSourceID="SqlDataSource1" Width="422px" 
                Font-Names="Century Gothic" Font-Size="11px" CaptionAlign="Left" EmptyDataText="No District Standings Available">
            <Columns>
                <asp:TemplateField ItemStyle-Width="40" ItemStyle-HorizontalAlign="Left" HeaderText="Click team below for schedule...">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("SchoolName") %>' Width="200px" ID="lblSchool1" style="text-align:left; text-decoration:underline;" ></asp:Label>
                        <ajax:popupcontrolextender id="PopupControlExtender1" runat="server" popupcontrolid="Panel1"
                            targetcontrolid="lblSchool1" dynamiccontextkey='<%# Eval("teamID") %>' dynamiccontrolid="Panel1"
                            dynamicservicemethod="GetDynamicContent" position="Bottom">
                        </ajax:popupcontrolextender>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="WL" SortExpression="WL" HeaderText="W/L" ItemStyle-HorizontalAlign="Center">
                <ControlStyle Width="40px" />
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle Width="40px" />
                </asp:BoundField>
                <asp:BoundField DataField="DistrictWL" SortExpression="DistrictWL" HeaderText="Dist W/L" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="LightGray">
                <ControlStyle Width="40px" />
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle Width="40px" />
                </asp:BoundField>
                <asp:CommandField SelectText="Scores" ShowSelectButton="True" ItemStyle-Width="40px" Visible="false" />
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
    <asp:TableRow ID="grid2" Visible="false">
        <asp:TableCell>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                CellPadding="3" DataSourceID="SqlDataSource2" Width="422px" 
                Font-Names="Century Gothic" Font-Size="11px" CaptionAlign="Left">
            <Columns>
                <asp:TemplateField ItemStyle-Width="40" ItemStyle-HorizontalAlign="Left" HeaderText="Click team below for schedule...">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("SchoolName") %>' Width="200px" ID="lblSchool1" style="text-align:left; text-decoration:underline;" ></asp:Label>
                        <ajax:popupcontrolextender id="PopupControlExtender1" runat="server" popupcontrolid="Panel1"
                            targetcontrolid="lblSchool1" dynamiccontextkey='<%# Eval("teamID") %>' dynamiccontrolid="Panel1"
                            dynamicservicemethod="GetDynamicContent" position="Bottom">
                        </ajax:popupcontrolextender>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="WL" SortExpression="WL" HeaderText="W/L" ItemStyle-HorizontalAlign="Center">
                <ControlStyle Width="40px" />
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle Width="40px" />
                </asp:BoundField>
                <asp:BoundField DataField="DistrictWL" SortExpression="DistrictWL" HeaderText="Dist W/L" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="LightGray">
                <ControlStyle Width="40px" />
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle Width="40px" />
                </asp:BoundField>
                <asp:CommandField SelectText="Scores" ShowSelectButton="True" Visible="false" />
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
    <asp:TableRow ID="grid3" Visible="false">
        <asp:TableCell>
        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                CellPadding="3" DataSourceID="SqlDataSource3" Width="422px" 
                Font-Names="Century Gothic" Font-Size="11px" CaptionAlign="Left">
            <Columns>
                <asp:TemplateField ItemStyle-Width="40" ItemStyle-HorizontalAlign="Left" HeaderText="Click team below for schedule...">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("SchoolName") %>' Width="200px" ID="lblSchool1" style="text-align:left; text-decoration:underline;" ></asp:Label>
                        <ajax:popupcontrolextender id="PopupControlExtender1" runat="server" popupcontrolid="Panel1"
                            targetcontrolid="lblSchool1" dynamiccontextkey='<%# Eval("teamID") %>' dynamiccontrolid="Panel1"
                            dynamicservicemethod="GetDynamicContent" position="Bottom">
                        </ajax:popupcontrolextender>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="WL" SortExpression="WL" HeaderText="W/L" ItemStyle-HorizontalAlign="Center">
                <ControlStyle Width="40px" />
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle Width="40px" />
                </asp:BoundField>
                <asp:BoundField DataField="DistrictWL" SortExpression="DistrictWL" HeaderText="Dist W/L" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="LightGray">
                <ControlStyle Width="40px" />
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle Width="40px" />
                </asp:BoundField>
                <asp:CommandField SelectText="Scores" ShowSelectButton="True" Visible="false" />
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
    <asp:TableRow ID="grid4" Visible="false">
        <asp:TableCell>
        <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" 
                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                CellPadding="3" DataSourceID="SqlDataSource4" Width="422px" 
                Font-Names="Century Gothic" Font-Size="11px" CaptionAlign="Left">
            <Columns>
                <asp:TemplateField ItemStyle-Width="40" ItemStyle-HorizontalAlign="Left" HeaderText="Click team below for schedule...">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("SchoolName") %>' Width="200px" ID="lblSchool1" style="text-align:left; text-decoration:underline;" ></asp:Label>
                        <ajax:popupcontrolextender id="PopupControlExtender1" runat="server" popupcontrolid="Panel1"
                            targetcontrolid="lblSchool1" dynamiccontextkey='<%# Eval("teamID") %>' dynamiccontrolid="Panel1"
                            dynamicservicemethod="GetDynamicContent" position="Bottom">
                        </ajax:popupcontrolextender>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="WL" SortExpression="WL" HeaderText="W/L" ItemStyle-HorizontalAlign="Center">
                <ControlStyle Width="40px" />
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle Width="40px" />
                </asp:BoundField>
                <asp:BoundField DataField="DistrictWL" SortExpression="DistrictWL" HeaderText="Dist W/L" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="LightGray">
                <ControlStyle Width="40px" />
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle Width="40px" />
                </asp:BoundField>
                <asp:CommandField SelectText="Scores" ShowSelectButton="True" Visible="false" />
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
    <asp:TableRow ID="grid5" Visible="false">
        <asp:TableCell VerticalAlign="Top">
        <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" 
                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                CellPadding="3" DataSourceID="SqlDataSource5" Width="422px" 
                Font-Names="Century Gothic" Font-Size="11px" CaptionAlign="Left" EmptyDataText="No District Standings Available">
            <Columns>
                <asp:TemplateField ItemStyle-Width="40" ItemStyle-HorizontalAlign="Left" HeaderText="Click team below for schedule...">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("SchoolName") %>' Width="200px" ID="lblSchool1" style="text-align:left; text-decoration:underline;" ></asp:Label>
                        <ajax:popupcontrolextender id="PopupControlExtender1" runat="server" popupcontrolid="Panel1"
                            targetcontrolid="lblSchool1" dynamiccontextkey='<%# Eval("teamID") %>' dynamiccontrolid="Panel1"
                            dynamicservicemethod="GetDynamicContent" position="Bottom">
                        </ajax:popupcontrolextender>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="WL" SortExpression="WL" HeaderText="W/L" ItemStyle-HorizontalAlign="Center">
                <ControlStyle Width="40px" />
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle Width="40px" />
                </asp:BoundField>
                <asp:BoundField DataField="DistrictWL" SortExpression="DistrictWL" HeaderText="Dist W/L" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="LightGray">
                <ControlStyle Width="40px" />
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle Width="40px" />
                </asp:BoundField>
                <asp:CommandField SelectText="Scores" ShowSelectButton="True" ItemStyle-Width="40px" Visible="false" />
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
    <asp:TableRow ID="grid6" Visible="false">
        <asp:TableCell VerticalAlign="Top">
        <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" 
                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                CellPadding="3" DataSourceID="SqlDataSource6" Width="422px" 
                Font-Names="Century Gothic" Font-Size="11px" CaptionAlign="Left" EmptyDataText="No District Standings Available">
            <Columns>
                <asp:TemplateField ItemStyle-Width="40" ItemStyle-HorizontalAlign="Left" HeaderText="Click team below for schedule...">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("SchoolName") %>' Width="200px" ID="lblSchool1" style="text-align:left; text-decoration:underline;" ></asp:Label>
                        <ajax:popupcontrolextender id="PopupControlExtender1" runat="server" popupcontrolid="Panel1"
                            targetcontrolid="lblSchool1" dynamiccontextkey='<%# Eval("teamID") %>' dynamiccontrolid="Panel1"
                            dynamicservicemethod="GetDynamicContent" position="Bottom">
                        </ajax:popupcontrolextender>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="WL" SortExpression="WL" HeaderText="W/L" ItemStyle-HorizontalAlign="Center">
                <ControlStyle Width="40px" />
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle Width="40px" />
                </asp:BoundField>
                <asp:BoundField DataField="DistrictWL" SortExpression="DistrictWL" HeaderText="Dist W/L" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="LightGray">
                <ControlStyle Width="40px" />
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle Width="40px" />
                </asp:BoundField>
                <asp:CommandField SelectText="Scores" ShowSelectButton="True" ItemStyle-Width="40px" Visible="false" />
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
    <asp:TableRow ID="grid7" Visible="false">
        <asp:TableCell VerticalAlign="Top">
        <asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="False" 
                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                CellPadding="3" DataSourceID="SqlDataSource7" Width="422px" 
                Font-Names="Century Gothic" Font-Size="11px" CaptionAlign="Left" EmptyDataText="No District Standings Available">
            <Columns>
                <asp:TemplateField ItemStyle-Width="40" ItemStyle-HorizontalAlign="Left" HeaderText="Click team below for schedule...">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("SchoolName") %>' Width="200px" ID="lblSchool1" style="text-align:left; text-decoration:underline;" ></asp:Label>
                        <ajax:popupcontrolextender id="PopupControlExtender1" runat="server" popupcontrolid="Panel1"
                            targetcontrolid="lblSchool1" dynamiccontextkey='<%# Eval("teamID") %>' dynamiccontrolid="Panel1"
                            dynamicservicemethod="GetDynamicContent" position="Bottom">
                        </ajax:popupcontrolextender>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="WL" SortExpression="WL" HeaderText="W/L" ItemStyle-HorizontalAlign="Center">
                <ControlStyle Width="40px" />
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle Width="40px" />
                </asp:BoundField>
                <asp:BoundField DataField="DistrictWL" SortExpression="DistrictWL" HeaderText="Dist W/L" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="LightGray">
                <ControlStyle Width="40px" />
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle Width="40px" />
                </asp:BoundField>
                <asp:CommandField SelectText="Scores" ShowSelectButton="True" ItemStyle-Width="40px" Visible="false" />
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
    <asp:TableRow ID="grid8" Visible="false">
        <asp:TableCell VerticalAlign="Top">
        <asp:GridView ID="GridView8" runat="server" AutoGenerateColumns="False" 
                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                CellPadding="3" DataSourceID="SqlDataSource8" Width="422px" 
                Font-Names="Century Gothic" Font-Size="11px" CaptionAlign="Left" EmptyDataText="No District Standings Available">
            <Columns>
                <asp:TemplateField ItemStyle-Width="40" ItemStyle-HorizontalAlign="Left" HeaderText="Click team below for schedule...">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("SchoolName") %>' Width="200px" ID="lblSchool1" style="text-align:left; text-decoration:underline;" ></asp:Label>
                        <ajax:popupcontrolextender id="PopupControlExtender1" runat="server" popupcontrolid="Panel1"
                            targetcontrolid="lblSchool1" dynamiccontextkey='<%# Eval("teamID") %>' dynamiccontrolid="Panel1"
                            dynamicservicemethod="GetDynamicContent" position="Bottom">
                        </ajax:popupcontrolextender>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="WL" SortExpression="WL" HeaderText="W/L" ItemStyle-HorizontalAlign="Center">
                <ControlStyle Width="40px" />
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle Width="40px" />
                </asp:BoundField>
                <asp:BoundField DataField="DistrictWL" SortExpression="DistrictWL" HeaderText="Dist W/L" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="LightGray">
                <ControlStyle Width="40px" />
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle Width="40px" />
                </asp:BoundField>
                <asp:CommandField SelectText="Scores" ShowSelectButton="True" ItemStyle-Width="40px" Visible="false" />
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

</asp:Table>
<asp:Panel ID="Panel1" runat="server">
</asp:Panel>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OSSAARANKINGSConnectionString %>" 
        SelectCommand="SELECT * FROM [ossaauser].[viewDistrictStandingsBaseball] WHERE ([Class] = @BaseballClass) AND District = 1 ORDER BY [Class], District, DistrictWins DESC, DistrictLosses, HeadToHead DESC, DistrictPoints DESC, Wins DESC, SchoolName">
    <SelectParameters>
        <asp:ControlParameter ControlID="cboClass1" Name="BaseballClass" 
            PropertyName="SelectedValue" Type="String" />
    </SelectParameters>
    </asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OSSAARANKINGSConnectionString %>" 
        SelectCommand="SELECT * FROM [ossaauser].[viewDistrictStandingsBaseball] WHERE ([Class] = @BaseballClass) AND District = 2 ORDER BY [Class], District, DistrictWins DESC, DistrictLosses, HeadToHead DESC, DistrictPoints DESC, Wins DESC, SchoolName">
    <SelectParameters>
        <asp:ControlParameter ControlID="cboClass1" Name="BaseballClass" 
            PropertyName="SelectedValue" Type="String" />
    </SelectParameters>
    </asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource3" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OSSAARANKINGSConnectionString %>" 
        SelectCommand="SELECT * FROM [ossaauser].[viewDistrictStandingsBaseball] WHERE ([Class] = @BaseballClass) AND District = 3 ORDER BY [Class], District, DistrictWins DESC, DistrictLosses, HeadToHead DESC, DistrictPoints DESC, Wins DESC, SchoolName">
    <SelectParameters>
        <asp:ControlParameter ControlID="cboClass1" Name="BaseballClass" 
            PropertyName="SelectedValue" Type="String" />
    </SelectParameters>
    </asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource4" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OSSAARANKINGSConnectionString %>" 
        SelectCommand="SELECT * FROM [ossaauser].[viewDistrictStandingsBaseball] WHERE ([Class] = @BaseballClass) AND District = 4 ORDER BY [Class], District, DistrictWins DESC, DistrictLosses, HeadToHead DESC, DistrictPoints DESC, Wins DESC, SchoolName">
    <SelectParameters>
        <asp:ControlParameter ControlID="cboClass1" Name="BaseballClass" 
            PropertyName="SelectedValue" Type="String" />
    </SelectParameters>
    </asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource5" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OSSAARANKINGSConnectionString %>" 
        SelectCommand="SELECT * FROM [ossaauser].[viewDistrictStandingsBaseball] WHERE ([Class] = @BaseballClass) AND District = 5 ORDER BY [Class], District, DistrictWins DESC, DistrictLosses, HeadToHead DESC, DistrictPoints DESC, Wins DESC, SchoolName">
    <SelectParameters>
        <asp:ControlParameter ControlID="cboClass1" Name="BaseballClass" 
            PropertyName="SelectedValue" Type="String" />
    </SelectParameters>
    </asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource6" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OSSAARANKINGSConnectionString %>" 
        SelectCommand="SELECT * FROM [ossaauser].[viewDistrictStandingsBaseball] WHERE ([Class] = @BaseballClass) AND District = 6 ORDER BY [Class], District, DistrictWins DESC, DistrictLosses, HeadToHead DESC, DistrictPoints DESC, Wins DESC, SchoolName">
    <SelectParameters>
        <asp:ControlParameter ControlID="cboClass1" Name="BaseballClass" 
            PropertyName="SelectedValue" Type="String" />
    </SelectParameters>
    </asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource7" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OSSAARANKINGSConnectionString %>" 
        SelectCommand="SELECT * FROM [ossaauser].[viewDistrictStandingsBaseball] WHERE ([Class] = @BaseballClass) AND District = 7 ORDER BY [Class], District, DistrictWins DESC, DistrictLosses, HeadToHead DESC, DistrictPoints DESC, Wins DESC, SchoolName">
    <SelectParameters>
        <asp:ControlParameter ControlID="cboClass1" Name="BaseballClass" 
            PropertyName="SelectedValue" Type="String" />
    </SelectParameters>
    </asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource8" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OSSAARANKINGSConnectionString %>" 
        SelectCommand="SELECT * FROM [ossaauser].[viewDistrictStandingsBaseball] WHERE ([Class] = @BaseballClass) AND District = 8 ORDER BY [Class], District, DistrictWins DESC, DistrictLosses, HeadToHead DESC, DistrictPoints DESC, Wins DESC, SchoolName">
    <SelectParameters>
        <asp:ControlParameter ControlID="cboClass1" Name="BaseballClass" 
            PropertyName="SelectedValue" Type="String" />
    </SelectParameters>
    </asp:SqlDataSource>
