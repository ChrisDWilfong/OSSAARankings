<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="test.aspx.vb" Inherits="OSSAARankings.test" %>
<%@ Register src="ucTestContent.ascx" tagname="ucTestContent" tagprefix="uc1" %>
<%@ Register src="ucTestContent0Load.ascx" tagname="ucTestContent0" tagprefix="uc0" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test Page</title>
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
</head>
<body>
    <form id="form1" runat="server">

    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanelTest" runat="server">
            <ContentTemplate>
                <ajax:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" TargetControlID="LeftAccordion" Radius="5" BorderColor="gray"></ajax:RoundedCornersExtender>
                <div>
                <asp:Table ID="Table1" runat="server" Width="960" HorizontalAlign="left" Height="700" BackColor="#e6e8ea">
                    <asp:TableRow>
                        <asp:TableCell Width="270" BorderStyle="Solid" BorderWidth="2" ID="Column1" VerticalAlign="top">
                            <ajax:Accordion ID="LeftAccordion" runat="server" SelectedIndex="0" HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected" ContentCssClass="accordionContent" FadeTransitions="true" SuppressHeaderPostbacks="true" TransitionDuration="250" FramesPerSecond="40" RequireOpenedPane="false" AutoSize="None" >
                            <panes>
                                <ajax:AccordionPane ID="Rankings" runat="server">
                                <Header>
                                    <asp:Button ID="cmdEnterRankings" runat="server" Text="Enter Rankings" Width="100%" BorderStyle="None" BackColor="Transparent" Font-Bold="true" Font-Size="Large" ForeColor="White" Font-Names="Segoe UI, Helvetica, Helvetica Neue, Lucida Grande, Arial, Verdana, sans-serif;" style="text-align:left;" />
                                </Header>
                                    <Content>
                                        <asp:PlaceHolder runat="server" ID="PlaceHolderRankings"></asp:PlaceHolder>
                                        <uc0:ucTestContent0 ID="ucTestContent2" runat="server" />
                                    </Content>
                                </ajax:AccordionPane>
                                <ajax:AccordionPane ID="Schedules" runat="server">
                                    <Header>
                                        <asp:Button ID="cmdEnterSchedule" runat="server" Text="Enter Schedule/Scores" Width="100%" BorderStyle="None" BackColor="Transparent" Font-Bold="true" Font-Size="Large" ForeColor="White" Font-Names="Segoe UI, Helvetica, Helvetica Neue, Lucida Grande, Arial, Verdana, sans-serif;" style="text-align:left;" />
                                    </Header>
                                    <Content>
                                        <asp:PlaceHolder runat="server" ID="PlaceHolderSchedules"></asp:PlaceHolder>
                                        <asp:Button ID="cmdRefresh" runat="server" Text="Refresh Me (TEST.aspx)" /><br />
                                        <uc1:ucTestContent ID="ucTestContent1" runat="server" />
                                    </Content>
                                </ajax:AccordionPane>
                            </panes>
                            </ajax:Accordion>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
