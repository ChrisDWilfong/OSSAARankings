<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="OfficialWeekGrid.ascx.vb" Inherits="OSSAARankings.OfficialWeekGrid" %>
<%@ Register assembly="Infragistics4.WebUI.UltraWebGrid.v10.2, Version=10.2.20102.1011, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.WebUI.UltraWebGrid" tagprefix="igtbl" %>
<igtbl:UltraWebGrid ID="UltraWebGrid1" runat="server" 
                    Width="400px" Browser="Xml" DataSourceID="SqlDataSource1" 
    Height="264px">
<DisplayLayout Name="UltraWebGrid1" RowHeightDefault="20px" 
                        Version="4.00" AllowColSizingDefault="Free"
                        CellClickActionDefault="RowSelect" CellPaddingDefault="1" 
                        HeaderClickActionDefault="SortMulti" LoadOnDemand="Xml" 
                        RowSelectorsDefault="No" SelectTypeRowDefault="Single" Pager-AllowPaging="true" Pager-MinimumPagesForDisplay="3000"
                        StationaryMargins="Header" TableLayout="Fixed">
    <FrameStyle Width="400px" BorderColor="#999999" BorderStyle="Solid" 
        BorderWidth="1px" Cursor="Default" Font-Names="Verdana" Font-Size="8pt" 
        height="264px">
    </FrameStyle>
    <RowAlternateStyleDefault BackColor="Gainsboro">
        <BorderDetails ColorLeft="Gainsboro" ColorTop="Gainsboro" />
<BorderDetails ColorLeft="Gainsboro" ColorTop="Gainsboro"></BorderDetails>
    </RowAlternateStyleDefault>

<Pager AllowPaging="True" MinimumPagesForDisplay="3000"></Pager>

    <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
        <BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" 
            WidthTop="1px" />
<BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" WidthTop="1px"></BorderDetails>
    </FooterStyleDefault>
    <HeaderStyleDefault BackColor="DarkGray" BorderColor="Black" 
        BorderStyle="Solid" Font-Bold="True" ForeColor="White">
        <BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" 
            WidthTop="1px" />
<BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" WidthTop="1px"></BorderDetails>
    </HeaderStyleDefault>
    <RowSelectorStyleDefault BorderStyle="Solid">
    </RowSelectorStyleDefault>
    <RowStyleDefault BackColor="White" BorderColor="Gray" BorderStyle="Solid" 
        BorderWidth="1px" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black">
        <Padding Left="3px" />
        <BorderDetails ColorLeft="White" ColorTop="White" />
<Padding Left="3px"></Padding>

<BorderDetails ColorLeft="White" ColorTop="White"></BorderDetails>
    </RowStyleDefault>
    <SelectedRowStyleDefault BackColor="Silver" Font-Bold="True" ForeColor="Black">
    </SelectedRowStyleDefault>
    <AddNewBox>
        <BoxStyle BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
            <BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" 
                WidthTop="1px" />
<BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" WidthTop="1px"></BorderDetails>
        </BoxStyle>
    </AddNewBox>
<ActivationObject BorderColor="Black" BorderWidth="" BorderStyle="Dotted"></ActivationObject>
    <FilterOptionsDefault>
        <FilterDropDownStyle BackColor="White" BorderColor="Silver" BorderStyle="Solid" 
            BorderWidth="1px" CustomRules="overflow:auto;" 
            Font-Names="Verdana,Arial,Helvetica,sans-serif" Font-Size="11px" Width="200px">
            <Padding Left="2px" />
<Padding Left="2px"></Padding>
        </FilterDropDownStyle>
        <FilterHighlightRowStyle BackColor="#151C55" ForeColor="White">
        </FilterHighlightRowStyle>
        <FilterOperandDropDownStyle BackColor="White" BorderColor="Silver" 
            BorderStyle="Solid" BorderWidth="1px" CustomRules="overflow:auto;" 
            Font-Names="Verdana,Arial,Helvetica,sans-serif" Font-Size="11px">
            <Padding Left="2px" />
<Padding Left="2px"></Padding>
        </FilterOperandDropDownStyle>
    </FilterOptionsDefault>
</DisplayLayout>
<Bands>
<igtbl:UltraGridBand>
    <Columns>
        <igtbl:UltraGridColumn BaseColumnName="intWeek" DataType="System.Int16" 
            Key="intWeek" Width="50px">
            <header caption="Week">
            </header>
            <HeaderStyle HorizontalAlign="Center" />
            <CellStyle HorizontalAlign="Center">
            </CellStyle>
        </igtbl:UltraGridColumn>
        <igtbl:UltraGridColumn BaseColumnName="Teams" 
            IsBound="True" Key="Teams" Width="300px">
            <Header Caption="Home/Away Team">
                <RowLayoutColumnInfo OriginX="1" />
<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
            </Header>
            <Footer>
                <RowLayoutColumnInfo OriginX="1" />
<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
            </Footer>
        </igtbl:UltraGridColumn>
        <igtbl:UltraGridColumn BaseColumnName="Id" DataType="System.Int32" 
            Hidden="True" IsBound="True" Key="Id">
            <header caption="Id">
                <rowlayoutcolumninfo originx="2" />
<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
            </header>
            <footer>
                <rowlayoutcolumninfo originx="2" />
<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
            </footer>
        </igtbl:UltraGridColumn>

    </Columns>
<AddNewRow Visible="NotSet" View="NotSet"></AddNewRow>
</igtbl:UltraGridBand>
</Bands>
    </igtbl:UltraWebGrid>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OSSAAConnectionString %>" 
        
    SelectCommand="SELECT [intWeek], [strTeamHome] + '/' + [strTeamAway] As Teams, [Id], [intWhiteHatOSSAAID] FROM [tblOfficialsReportsFootball] WHERE [intWhiteHatOSSAAID] = @OSSAAID AND intYear = @year" >
        <SelectParameters>
            <asp:SessionParameter Name="OSSAAID" SessionField="OSSAAID" />
            <asp:SessionParameter Name="year" SessionField="gYear" />
        </SelectParameters>
</asp:SqlDataSource>
    
