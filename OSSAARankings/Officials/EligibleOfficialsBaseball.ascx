<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="EligibleOfficialsBaseball.ascx.vb" Inherits="OSSAARankings.EligibleOfficialsBaseball" %>
<%@ Register Assembly="Infragistics4.WebUI.UltraWebGrid.v10.2, Version=10.2.20102.1011, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebGrid" TagPrefix="igtbl" %>
<style type="text/css">
    .style1
    {
        width: 256px;
    }
</style>
<asp:UpdateProgress ID="updProgress" AssociatedUpdatePanelID="UpdatePanel2" runat="server">
    <ProgressTemplate   >            
        <div ><img alt="progress" src="../images/gears.gif"/><span style="font-family: Verdana; font-size:10px;">Processing...</span></div>
    </ProgressTemplate>
</asp:UpdateProgress>
<asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
<ContentTemplate>
<table style="height: 3000px; width: 258px">
<tr>
<td class="style1" valign="top">
<igtbl:UltraWebGrid ID="UltraWebGrid1" runat="server" 
                    Width="250px" Browser="Xml" DataSourceID="SqlDataSource1" 
        Height="100%" >
<DisplayLayout Name="UltraWebGrid1" RowHeightDefault="20px" 
                        Version="4.00" AllowColSizingDefault="Free"
                        CellClickActionDefault="RowSelect" CellPaddingDefault="1" 
                        HeaderClickActionDefault="SortMulti" LoadOnDemand="Xml" 
                        RowSelectorsDefault="No" SelectTypeRowDefault="Single" Pager-AllowPaging="true" Pager-PageSize="150" Pager-MinimumPagesForDisplay="1500" Pager-PagerAppearance="Both"
                        StationaryMargins="Header" TableLayout="Fixed">
    <FrameStyle Width="250px" BorderColor="#999999" BorderStyle="Solid" 
        BorderWidth="3px" Cursor="Default" Font-Names="Verdana" Font-Size="8pt" 
        Height="100%">
    </FrameStyle>
    <RowAlternateStyleDefault BackColor="Gainsboro">
        <BorderDetails ColorLeft="Gainsboro" ColorTop="Gainsboro" />
<BorderDetails ColorLeft="Gainsboro" ColorTop="Gainsboro"></BorderDetails>
    </RowAlternateStyleDefault>

<Pager PageSize="150" AllowPaging="True" PagerAppearance="Both" MinimumPagesForDisplay="1500"></Pager>

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
        <igtbl:UltraGridColumn BaseColumnName="Id" DataType="System.Int32" Hidden="True" IsBound="True" Key="Id">
            <Header Caption="Id">
            </Header>
        </igtbl:UltraGridColumn>
        <igtbl:UltraGridColumn BaseColumnName="intOSSAAID" DataType="System.Int32" 
            IsBound="True" Key="intOSSAAID" Width="75px">
            <Header Caption="OSSAAID#" Title="OSSAAID">
                <RowLayoutColumnInfo OriginX="1" />
<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
            </Header>
            <Footer>
                <RowLayoutColumnInfo OriginX="1" />
<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
            </Footer>
        </igtbl:UltraGridColumn>
        <igtbl:UltraGridColumn BaseColumnName="FullName" IsBound="True" 
            Key="FullName" Width="150px">
            <Header Caption="Name">
                <RowLayoutColumnInfo OriginX="2" />
<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
            </Header>
            <Footer>
                <RowLayoutColumnInfo OriginX="2" />
<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
            </Footer>
        </igtbl:UltraGridColumn>
    </Columns>
<AddNewRow Visible="NotSet" View="NotSet"></AddNewRow>
</igtbl:UltraGridBand>
</Bands>
</igtbl:UltraWebGrid>
</td></tr></table>
</ContentTemplate>
</asp:UpdatePanel>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OSSAAConnectionString %>" 
        SelectCommand="SELECT [Id], [intOSSAAID], [strLastName], [strFirstName], [strLastName] + ', ' + [strFirstName] AS [FullName], [strCity], [ysnCurrentBaseball] FROM [prodOfficials] WHERE (([ysnCurrentBaseball] = -1) And (intTestBaseball >= dbo.GetOfficialsPassingScore()) And (intOSSAAID > 0)) ORDER BY strLastName">
        <SelectParameters>
            <asp:Parameter DefaultValue="100" Name="ysnPrintedBaseball" Type="Int16" />
        </SelectParameters>
</asp:SqlDataSource>


