<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ossaa/SiteOSSAA.Master" CodeBehind="Maps.aspx.vb" Inherits="OSSAARankings.Maps1" %>
<%@ Register Assembly="Infragistics4.Web.v10.2, Version=10.2.20102.1011, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI" TagPrefix="ig" %>
<%@ Register Assembly="Infragistics4.Web.v10.2, Version=10.2.20102.1011, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <ig:WebDataGrid ID="WebDataGrid1" runat="server" Height="800px" Width="625px" 
            DataSourceID="SqlDataSource1" AutoGenerateColumns="False" 
            StyleSetName="RedPlanet">
        <Columns>
            <ig:TemplateDataField Key="SchoolField">
                <Header Text="Click School Below to View Map" />
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" NavigateUrl=<%# Eval("strLink") %> runat="server" Target="_blank"><span style="font-size:14px"><%# Eval("strTitle")%></span></asp:HyperLink>
                </ItemTemplate>
            </ig:TemplateDataField>
        </Columns>
    </ig:WebDataGrid>
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OSSAAConnectionString %>" 
        SelectCommand="SELECT [strTitle], [strLink] FROM [wilfong143].[tblMaps] WHERE ([ysnActive] = @ysnActive) ORDER BY [strTitle]">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="ysnActive" Type="Int16" />
        </SelectParameters>
    </asp:SqlDataSource>
    <ig:WebScriptManager ID="WebScriptManager1" runat="server">
    </ig:WebScriptManager>

</asp:Content>
