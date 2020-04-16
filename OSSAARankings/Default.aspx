<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="OSSAARankings._Default" ClientTarget="uplevel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<!-- Google Tag Manager -->
<script>(function(w,d,s,l,i){w[l]=w[l]||[];w[l].push({'gtm.start':
new Date().getTime(),event:'gtm.js'});var f=d.getElementsByTagName(s)[0],
j=d.createElement(s),dl=l!='dataLayer'?'&l='+l:'';j.async=true;j.src=
'https://www.googletagmanager.com/gtm.js?id='+i+dl;f.parentNode.insertBefore(j,f);
})(window,document,'script','dataLayer','GTM-5SVGP75');</script>
<!-- End Google Tag Manager -->
    <title>OSSAARankings.com 2019-20</title>
<style type="text/css">
     .accordionContent {
        background-color: #e6e8ea;
        border-color: -moz-use-text-color#2F4F4F #2F4F4F;
        border-right: 1px solid #2F4F4F;
        border-style: none solid solid;
        border-width: medium 1px 1px;
        padding: 10px 5px 5px 5px;
        width: 95%;
     }
     .accordionHeaderSelected {
        background-color: #000000;
        border: 1px solid #2F4F4F;
        color: white;
        cursor: pointer;
        font-family: Segoe UI, Verdana, Helvetica, sans-serif;
        font-size: 18px;
        font-weight: bold;
        margin-top: 5px;
        padding: 5px;
        width: 95%;
    }
    .accordionHeader {
        background-color: #811212;
        border: 1px solid #2F4F4F;
        color: white;
        cursor: pointer;
        font-family: Segoe UI, Verdana, Helvetica, sans-serif;
        font-size: 18px;
        font-weight: bold;
        margin-top: 5px;
        padding: 5px;
        width: 95%;
    }
    .href
    {
        color: White;  
        font-weight: bold;
        text-decoration: none;
     }
 </style>
<link href="Rankings.css" rel="stylesheet" type="text/css" />
</head>
<body style="background-color:#e6e8ea;">
<!-- Google Tag Manager (noscript) -->
<noscript><iframe src="https://www.googletagmanager.com/ns.html?id=GTM-P6NSRTN"
height="0" width="0" style="display:none;visibility:hidden"></iframe></noscript>
<!-- End Google Tag Manager (noscript) -->
 <form id="form1" runat="server">
 <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
 <asp:Panel ID="MainPanel" ScrollBars="None" Wrap="true" runat="server" Height="100%" Width="100%" style="vertical-align:top;">
    <asp:UpdateProgress ID="updProgress" AssociatedUpdatePanelID="UpdatePanel" runat="server">
        <ProgressTemplate>
            <div style="position:absolute; top:180px;left:300px;">
                <img alt="progress" src="images/ajax-loader1.gif" width="80px" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
<asp:UpdatePanel ID="UpdatePanel" runat="server">
    <ContentTemplate>
 <ajax:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" TargetControlID="Column1" Radius="5" BorderColor="gray"></ajax:RoundedCornersExtender>
 <ajax:RoundedCornersExtender ID="RoundedCornersExtender2" runat="server" TargetControlID="Column2" Radius="5" BorderColor="gray"></ajax:RoundedCornersExtender>
 <ajax:RoundedCornersExtender ID="RoundedCornersExtender3" runat="server" TargetControlID="Column0" Radius="5" BorderColor="gray"></ajax:RoundedCornersExtender>
    <div>
        <asp:Table ID="Table1" runat="server" Width="960" HorizontalAlign="left" Height="700" BackColor="#e6e8ea">
            <asp:TableRow BackColor="#7d0200">
                <asp:TableCell ColumnSpan="2" Width="100%" BorderStyle="Solid" BorderWidth="2" ID="Column0" VerticalAlign="Top" style="padding-left:10px;">
                    <asp:Table runat="server">
                        <asp:TableRow>
                            <asp:TableCell Width="50%">
                                <asp:Image runat="server" ImageUrl="~/images/logoWebsiteWhite.png" Width="90%" />
                            </asp:TableCell>
                            <asp:TableCell Width="50%" HorizontalAlign="center">
                                <telerik:RadRotator ID="RadRotator1" runat="server" RenderMode="Lightweight" Width="451" Height="55" ScrollDuration="2000" 
                                        ScrollDirection="Left" FrameDuration="2000" ItemHeight="55" ItemWidth="451" BorderStyle="None" BorderWidth="0" EnableRandomOrder="true"  >
                                        <Items>
											<telerik:RadRotatorItem>
												<ItemTemplate>
													<asp:HyperLink ID="hlAd01" runat="server" ImageUrl="None" Target="_blank" NavigateUrl="http://www.ossaarankings.com" BorderStyle="None"></asp:HyperLink>
												</ItemTemplate>
											</telerik:RadRotatorItem>
											<telerik:RadRotatorItem>
												<ItemTemplate>
													<asp:HyperLink ID="hlAd02" runat="server" ImageUrl="None" Target="_blank" NavigateUrl="http://www.ossaarankings.com" BorderStyle="None"></asp:HyperLink>
												</ItemTemplate>
											</telerik:RadRotatorItem>
                                        </Items>
                                    </telerik:RadRotator>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell Width="270" BorderStyle="Solid" BorderWidth="2" ID="Column1" VerticalAlign="top">
                    <ajax:Accordion ID="LeftAccordion" runat="server" SelectedIndex="0" HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected" ContentCssClass="accordionContent" FadeTransitions="true" SuppressHeaderPostbacks="true" TransitionDuration="250" FramesPerSecond="40" RequireOpenedPane="false" AutoSize="None" >
                        <panes>
                        <ajax:AccordionPane ID="Rankings" runat="server">
                            <Header><a href="#" class="href" style="color:Yellow;">Rankings</a></Header>
                            <Content>
                                <asp:PlaceHolder runat="server" ID="PlaceHolderRankings"></asp:PlaceHolder>
                            </Content>
                        </ajax:AccordionPane>
                       <ajax:AccordionPane ID="SchedulesPlayoffs" runat="server" Visible="false">
                            <Header><a href="#" class="href" style="color:Yellow;">PLAYOFFS SCOREBOARD</a></Header>
                            <Content>
                                <asp:PlaceHolder runat="server" ID="PlaceHolderSchedulesPlayoffs"></asp:PlaceHolder>
                            </Content>
                        </ajax:AccordionPane>
                         <ajax:AccordionPane ID="SchedulesClass" runat="server">
                            <Header><a href="#" class="href" style="color:Yellow;">Schedules : By Class</a></Header>
                            <Content>
                                <asp:PlaceHolder runat="server" ID="PlaceHolderSchedulesClass"></asp:PlaceHolder>
                            </Content>
                        </ajax:AccordionPane>
                        <ajax:AccordionPane ID="Schedules" runat="server">
                            <Header><a href="#" class="href" style="color:Yellow;">Schedules : By Date</a></Header>
                            <Content>
                                <asp:PlaceHolder runat="server" ID="PlaceHolderSchedules"></asp:PlaceHolder>
                            </Content>
                        </ajax:AccordionPane>
                        <ajax:AccordionPane ID="DistrictStandings" runat="server">
                            <Header><a href="#" class="href" style="color:Yellow;">District Standings</a></Header>
                            <Content>
                                <asp:PlaceHolder runat="server" ID="PlaceHolderDistrictStandings"></asp:PlaceHolder>
                            </Content>
                        </ajax:AccordionPane>
                        <ajax:AccordionPane ID="Schools" runat="server">
                            <Header><a href="#" class="href" style="color:Yellow;">Schools</a></Header>
                            <Content>
                                <asp:PlaceHolder runat="server" ID="PlaceHolderSchools"></asp:PlaceHolder>
                            </Content>
                        </ajax:AccordionPane>
                        <ajax:AccordionPane ID="CoachLogin" runat="server" ForeColor="Yellow" Enabled="true" Visible="true">
                            <Header><a href="#" class="href" style="color:Yellow;">Coaches</a></Header>
                            <Content>
                                <asp:HyperLink ID="hlLogin" runat="server" NavigateUrl="../mem/Login.aspx" CssClass="labelBig" Font-Bold="true"><img src="../images/ig_menutri.gif" border="0" /><img src="../images/blank.gif" border="0" />Coaches Login</asp:HyperLink>
                            </Content>
                        </ajax:AccordionPane>           
                        <ajax:AccordionPane ID="AD" runat="server" ForeColor="Yellow" Enabled="true" Visible="true">
                            <Header><a href="#" class="href" style="color:Yellow;">Athletic Directors</a></Header>
                            <Content>
                                <asp:HyperLink ID="hlLoginAD" runat="server" NavigateUrl="../memad/adLogin.aspx" CssClass="labelBig" Font-Bold="true"><img src="../images/ig_menutri.gif" border="0" /><img src="../images/blank.gif" border="0" />Athletic Directors Login</asp:HyperLink>
                            </Content>
                        </ajax:AccordionPane> 
                         <ajax:AccordionPane ID="SchedulesClass14" runat="server" BackColor="Green" Visible="false">
                            <Header><a href="#" class="href" style="color:White;">2013-14 Schedules</a></Header>
                            <Content>
                                <asp:PlaceHolder runat="server" ID="PlaceHolderSchedulesClass14"></asp:PlaceHolder>
                            </Content>
                        </ajax:AccordionPane>    
                         <ajax:AccordionPane ID="SchedulesClass15" runat="server" BackColor="Green" Visible="false">
                            <Header><a href="#" class="href" style="color:White;">2014-15 Schedules</a></Header>
                            <Content>
                                <asp:PlaceHolder runat="server" ID="PlaceHolderSchedulesClass15"></asp:PlaceHolder>
                            </Content>
                        </ajax:AccordionPane>  
                         <ajax:AccordionPane ID="SchedulesClass16" runat="server" BackColor="Green" Visible="true">
                            <Header><a href="#" class="href" style="color:White;">2015-16 Schedules</a></Header>
                            <Content>
                                <asp:PlaceHolder runat="server" ID="PlaceHolderSchedulesClass16"></asp:PlaceHolder>
                            </Content>
                        </ajax:AccordionPane>       
                         <ajax:AccordionPane ID="SchedulesClass17" runat="server" BackColor="Green" Visible="true">
                            <Header><a href="#" class="href" style="color:White;">2016-17 Schedules</a></Header>
                            <Content>
                                <asp:PlaceHolder runat="server" ID="PlaceHolderSchedulesClass17"></asp:PlaceHolder>
                            </Content>
                        </ajax:AccordionPane>        

                         <ajax:AccordionPane ID="SchedulesClass18" runat="server" BackColor="Green" Visible="true">
                            <Header><a href="#" class="href" style="color:White;">2017-18 Schedules</a></Header>
                            <Content>
                                <asp:PlaceHolder runat="server" ID="PlaceHolderSchedulesClass18"></asp:PlaceHolder>
                            </Content>
                        </ajax:AccordionPane>  
                         <ajax:AccordionPane ID="SchedulesClass19" runat="server" BackColor="Green" Visible="true">
                            <Header><a href="#" class="href" style="color:White;">2018-19 Schedules</a></Header>
                            <Content>
                                <asp:PlaceHolder runat="server" ID="PlaceHolderSchedulesClass19"></asp:PlaceHolder>
                            </Content>
                        </ajax:AccordionPane>  
                        </panes>
                    </ajax:Accordion>
                    <hr />
                    <asp:Image runat="server" ImageUrl="~/images/sponsors/WilsonBallWeb.png" Visible="false" />
                </asp:TableCell>
                <asp:TableCell Width="690" BorderStyle="Solid" BorderWidth="2" ID="Column2" VerticalAlign="top" HorizontalAlign="Center" >
                    <asp:PlaceHolder runat="server" ID="PlaceHolderRightPane"></asp:PlaceHolder>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
    </ContentTemplate>
    <Triggers>

    </Triggers>
</asp:UpdatePanel>
</asp:Panel>
    </form>
</body>
</html>
