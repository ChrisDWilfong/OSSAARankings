<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Assignors.aspx.vb" Inherits="OSSAARankings.Assignors" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>OSSAA Assignors</title>
    <link href="Assignors.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <telerik:RadSkinManager ID="RadSkinManager1" runat="server" />
    <div class="innerPanel in" style="padding-left:20px; padding-top:20px;">
        <asp:Label ID="lblHeader1" runat="server" Text="OSSAA OFFICIALS ASSIGNING INFORMATION PAGE" ForeColor="Maroon" Font-Size="Large" Font-Bold="true"></asp:Label>  
    </div>
    <div class="innerPanel in" style="padding-left:20px; padding-top:20px;">
        <asp:Table runat="server" ID="tblPersonalInfo">
            <asp:TableRow>
                <asp:TableCell Width="300px">
                    <asp:Label ID="lblFirstName" runat="server" Text="First Name : " Width="100px"></asp:Label>
                    <asp:TextBox ID="txtFirstName" runat="server" Width="120px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblAddress" runat="server" Text="Address : " Width="100px"></asp:Label>
                    <asp:TextBox ID="txtAddress" runat="server" Width="150px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>&nbsp;</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblLastName" runat="server" Text="Last Name : " Width="100px"></asp:Label>
                    <asp:TextBox ID="txtLastName" runat="server" Width="120px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblCityStateZip" runat="server" Text="City/ST/Zip : " Width="100px"></asp:Label>
                    <asp:TextBox ID="txtCity" runat="server" Width="120px"></asp:TextBox>&nbsp;
                    <asp:DropDownList runat="server">
                        <asp:ListItem Value="" Text="Select..."></asp:ListItem>
                        <asp:ListItem Value="OK" Text="OK"></asp:ListItem>
                        <asp:ListItem Value="AR" Text="AR"></asp:ListItem>
                        <asp:ListItem Value="KS" Text="KS"></asp:ListItem>
                        <asp:ListItem Value="TX" Text="TX"></asp:ListItem>
                    </asp:DropDownList>&nbsp;
                    <asp:TextBox ID="txtZip" runat="server" Width="80px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>&nbsp;</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblEmail" runat="server" Text="Email : " Width="100px"></asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server" Width="180px"></asp:TextBox>                
                </asp:TableCell>
                <asp:TableCell ColumnSpan="2">
                     <asp:Label ID="lblPhone" runat="server" Text="Phone : " Width="100px"></asp:Label>
                    <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>                   
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblOSSAAID" runat="server" Text="OSSAA ID# : " Width="100px"></asp:Label>
                    <asp:TextBox ID="txtOSSAAID" runat="server" Width="100px" MaxLength="5"></asp:TextBox>                
                </asp:TableCell>
                <asp:TableCell>&nbsp;</asp:TableCell> 
                <asp:TableCell HorizontalAlign="Right">
                    <telerik:RadButton ID="RadButtonSave" runat="server" Text="SAVE CHANGES" Skin="Silk" BackColor="Olive" Font-Bold="true">
                    </telerik:RadButton>
                </asp:TableCell>           
            </asp:TableRow>
        </asp:Table>
    </div>
    <div class="innerPanel in" style="padding-left:20px; padding-top:20px;">
        <asp:Label ID="lblHeader2" runat="server" Text="SELECT THE SPORTS YOU WILL BE ASSIGNING BELOW AND THE APPROPRIATE INFORMATION FOR EACH SPORT" ForeColor="Maroon" Font-Bold="true"></asp:Label>  
    </div>
    <div class="demo-container no-bg">
        <telerik:RadTabStrip ID="RadTabStrip1" runat="server" ResolvedRenderMode="Classic" Skin="Silk" MultiPageID="RadMultiPage1">
            <Tabs>
                <telerik:RadTab runat="server" Text="Football" PageViewID="RadPageViewFB">
                </telerik:RadTab>
                <telerik:RadTab runat="server" Text="Basketball" PageViewID="RadPageViewBK">
                </telerik:RadTab>
                <telerik:RadTab runat="server" Text="Baseball">
                </telerik:RadTab>
                <telerik:RadTab runat="server" Text="Fast-Pitch">
                </telerik:RadTab>
                <telerik:RadTab runat="server" Text="Slow-Pitch">
                </telerik:RadTab>
                <telerik:RadTab runat="server" Text="Wrestling">
                </telerik:RadTab>
                <telerik:RadTab runat="server" Text="Soccer">
                </telerik:RadTab>
                <telerik:RadTab runat="server" Text="Volleyball">
                </telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0" CssClass="outerMultiPage">

            <telerik:RadPageView runat="server" ID="RadPageViewFB">
                <div class="innerPanel in">
                <asp:Table runat="server" ID="Table1" Width="98%">
                    <asp:TableRow VerticalAlign="Top">
                        <asp:TableCell Width="50%">
                            <asp:Label ID="Label1" runat="server" Font-Bold="true" Text="Football Officiating LEVEL<br>(check all that apply)"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell Width="50%">
                            <asp:Label ID="Label2" runat="server" Font-Bold="true" Text="Football Officiating AREAS<br>(check all that apply)"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow VerticalAlign="Top">
                        <asp:TableCell>
                            <asp:CheckBoxList ID="CheckBoxListLevelsFB" runat="server" style="padding-left:10px;"  DataSourceID="SqlDataSource1" DataTextField="strLevel" DataValueField="idLevel">
                            </asp:CheckBoxList>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:CheckBoxList ID="CheckBoxListAreasFB" runat="server" style="padding-left:10px;"  DataSourceID="SqlDataSource2" DataTextField="strArea" DataValueField="idArea">
                            </asp:CheckBoxList>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>           
                </div>     
            </telerik:RadPageView>


            <telerik:RadPageView runat="server" ID="RadPageViewBK">
                <div class="innerPanel in">
                <asp:Table runat="server" ID="tblBasketball" Width="98%">
                    <asp:TableRow VerticalAlign="Top">
                        <asp:TableCell Width="50%">
                            <asp:Label ID="lblBasketballLevel" runat="server" Font-Bold="true" Text="Basketball Officiating LEVEL<br>(check all that apply)"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell Width="50%">
                            <asp:Label ID="lblBasketballArea" runat="server" Font-Bold="true" Text="Basketball Officiating AREAS<br>(check all that apply)"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow VerticalAlign="Top">
                        <asp:TableCell>
                            <asp:CheckBoxList ID="CheckBoxListLevelsBK" runat="server" style="padding-left:10px;"  DataSourceID="SqlDataSource1" DataTextField="strLevel" DataValueField="idLevel">
                            </asp:CheckBoxList>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:CheckBoxList ID="CheckBoxListAreasBK" runat="server" style="padding-left:10px;"  DataSourceID="SqlDataSource2" DataTextField="strArea" DataValueField="idArea">
                            </asp:CheckBoxList>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>           
                </div>     
            </telerik:RadPageView>

            <telerik:RadPageView runat="server" ID="RadPageViewBA">
                <div class="innerPanel in">
                <asp:Table runat="server" ID="Table2" Width="98%">
                    <asp:TableRow VerticalAlign="Top">
                        <asp:TableCell Width="50%">
                            <asp:Label ID="Label3" runat="server" Font-Bold="true" Text="Baseball Officiating LEVEL<br>(check all that apply)"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell Width="50%">
                            <asp:Label ID="Label4" runat="server" Font-Bold="true" Text="Baseball Officiating AREAS<br>(check all that apply)"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow VerticalAlign="Top">
                        <asp:TableCell>
                            <asp:CheckBoxList ID="CheckBoxListLevelsBA" runat="server" style="padding-left:10px;"  DataSourceID="SqlDataSource1" DataTextField="strLevel" DataValueField="idLevel">
                            </asp:CheckBoxList>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:CheckBoxList ID="CheckBoxListAreasBA" runat="server" style="padding-left:10px;"  DataSourceID="SqlDataSource2" DataTextField="strArea" DataValueField="idArea">
                            </asp:CheckBoxList>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>           
                </div>     
            </telerik:RadPageView>

            <telerik:RadPageView runat="server" ID="RadPageViewFP">
                <div class="innerPanel in">
                <asp:Table runat="server" ID="Table3" Width="98%">
                    <asp:TableRow VerticalAlign="Top">
                        <asp:TableCell Width="50%">
                            <asp:Label ID="Label5" runat="server" Font-Bold="true" Text="Fast-Pitch Officiating LEVEL<br>(check all that apply)"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell Width="50%">
                            <asp:Label ID="Label6" runat="server" Font-Bold="true" Text="Fast-Pitch Officiating AREAS<br>(check all that apply)"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow VerticalAlign="Top">
                        <asp:TableCell>
                            <asp:CheckBoxList ID="CheckBoxListLevelsFP" runat="server" style="padding-left:10px;"  DataSourceID="SqlDataSource1" DataTextField="strLevel" DataValueField="idLevel">
                            </asp:CheckBoxList>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:CheckBoxList ID="CheckBoxListAreasFP" runat="server" style="padding-left:10px;"  DataSourceID="SqlDataSource2" DataTextField="strArea" DataValueField="idArea">
                            </asp:CheckBoxList>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>           
                </div>     
            </telerik:RadPageView>

            <telerik:RadPageView runat="server" ID="RadPageViewSP">
                <div class="innerPanel in">
                <asp:Table runat="server" ID="Table4" Width="98%">
                    <asp:TableRow VerticalAlign="Top">
                        <asp:TableCell Width="50%">
                            <asp:Label ID="Label7" runat="server" Font-Bold="true" Text="Slow-Pitch Officiating LEVEL<br>(check all that apply)"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell Width="50%">
                            <asp:Label ID="Label8" runat="server" Font-Bold="true" Text="Slow-Pitch Officiating AREAS<br>(check all that apply)"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow VerticalAlign="Top">
                        <asp:TableCell>
                            <asp:CheckBoxList ID="CheckBoxListLevelsSP" runat="server" style="padding-left:10px;"  DataSourceID="SqlDataSource1" DataTextField="strLevel" DataValueField="idLevel">
                            </asp:CheckBoxList>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:CheckBoxList ID="CheckBoxListAreasSP" runat="server" style="padding-left:10px;"  DataSourceID="SqlDataSource2" DataTextField="strArea" DataValueField="idArea">
                            </asp:CheckBoxList>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>           
                </div>     
            </telerik:RadPageView>

            <telerik:RadPageView runat="server" ID="RadPageViewWR">
                <div class="innerPanel in">
                <asp:Table runat="server" ID="Table5" Width="98%">
                    <asp:TableRow VerticalAlign="Top">
                        <asp:TableCell Width="50%">
                            <asp:Label ID="Label9" runat="server" Font-Bold="true" Text="Wrestling Officiating LEVEL<br>(check all that apply)"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell Width="50%">
                            <asp:Label ID="Label10" runat="server" Font-Bold="true" Text="Wrestling Officiating AREAS<br>(check all that apply)"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow VerticalAlign="Top">
                        <asp:TableCell>
                            <asp:CheckBoxList ID="CheckBoxListLevelsWR" runat="server" style="padding-left:10px;"  DataSourceID="SqlDataSource1" DataTextField="strLevel" DataValueField="idLevel">
                            </asp:CheckBoxList>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:CheckBoxList ID="CheckBoxListAreasWR" runat="server" style="padding-left:10px;"  DataSourceID="SqlDataSource2" DataTextField="strArea" DataValueField="idArea">
                            </asp:CheckBoxList>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>           
                </div>     
            </telerik:RadPageView>

            <telerik:RadPageView runat="server" ID="RadPageViewSC">
                <div class="innerPanel in">
                <asp:Table runat="server" ID="Table6" Width="98%">
                    <asp:TableRow VerticalAlign="Top">
                        <asp:TableCell Width="50%">
                            <asp:Label ID="Label11" runat="server" Font-Bold="true" Text="Soccer Officiating LEVEL<br>(check all that apply)"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell Width="50%">
                            <asp:Label ID="Label12" runat="server" Font-Bold="true" Text="Soccer Officiating AREAS<br>(check all that apply)"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow VerticalAlign="Top">
                        <asp:TableCell>
                            <asp:CheckBoxList ID="CheckBoxListLevelsSC" runat="server" style="padding-left:10px;"  DataSourceID="SqlDataSource1" DataTextField="strLevel" DataValueField="idLevel">
                            </asp:CheckBoxList>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:CheckBoxList ID="CheckBoxListAreasSC" runat="server" style="padding-left:10px;"  DataSourceID="SqlDataSource2" DataTextField="strArea" DataValueField="idArea">
                            </asp:CheckBoxList>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>           
                </div>     
            </telerik:RadPageView>

            <telerik:RadPageView runat="server" ID="RadPageViewVB">
                <div class="innerPanel in">
                <asp:Table runat="server" ID="Table7" Width="98%">
                    <asp:TableRow VerticalAlign="Top">
                        <asp:TableCell Width="50%">
                            <asp:Label ID="Label13" runat="server" Font-Bold="true" Text="Volleyball Officiating LEVEL<br>(check all that apply)"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell Width="50%">
                            <asp:Label ID="Label14" runat="server" Font-Bold="true" Text="Volleyball Officiating AREAS<br>(check all that apply)"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow VerticalAlign="Top">
                        <asp:TableCell>
                            <asp:CheckBoxList ID="CheckBoxListLevelsVB" runat="server" style="padding-left:10px;"  DataSourceID="SqlDataSource1" DataTextField="strLevel" DataValueField="idLevel">
                            </asp:CheckBoxList>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:CheckBoxList ID="CheckBoxListAreasVB" runat="server" style="padding-left:10px;"  DataSourceID="SqlDataSource2" DataTextField="strArea" DataValueField="idArea">
                            </asp:CheckBoxList>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>           
                </div>     
            </telerik:RadPageView>

        </telerik:RadMultiPage>
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OSSAAConnectionString %>" 
        SelectCommand="SELECT [idLevel], [strLevel] FROM [tblAssignorsLevels] ORDER BY idLevel">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OSSAAConnectionString %>" 
        SelectCommand="SELECT [idArea], [strArea] FROM [tblAssignorsAreas] ORDER BY idArea">
    </asp:SqlDataSource>
    </form>
</body>
</html>
