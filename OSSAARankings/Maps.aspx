<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Maps.aspx.vb" Inherits="OSSAARankings.Maps" ClientTarget="uplevel" %>

<%@ Register Assembly="Infragistics4.Web.v10.2, Version=10.2.20102.1011, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics4.Web.v10.2, Version=10.2.20102.1011, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>

<body>
    <form id="form1" runat="server" height="840">
    <div>
    <ig:WebDataGrid ID="WebDataGrid1" runat="server" Height="800px" Width="625px" 
            DataSourceID="SqlDataSource1" AutoGenerateColumns="False" 
            StyleSetName="RedPlanet">
        <Columns>
            <ig:TemplateDataField Key="SchoolField">
                <Header Text="Click School Below to View Map" />
                <ItemTemplate>
                    <asp:HyperLink NavigateUrl=<%# Eval("strLink") %> runat="server" Target="_blank"><span style="font-size:14px"><%# Eval("strTitle")%></span></asp:HyperLink>
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
    </form>
</body>
</html>
