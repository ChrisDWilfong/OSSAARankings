<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="BKSchedule.aspx.vb" Inherits="OSSAARankings.BKSchedule" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register assembly="Infragistics4.WebUI.WebDateChooser.v10.2, Version=10.2.20102.1011, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.WebUI.WebSchedule" tagprefix="igsch" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>OSSAA Basketball Officials Schedule</title>
    <style>
        .header
        {
            font-family:Arial;
            font-size:10pt;
            font-weight:bold;
            color:Maroon;
        }        
        .label
        {
            font-family:Verdana;
            font-size:9pt;
            font-weight:bold;
        }
        .text 
        {
            font-family:Verdana;
            font-size:8pt;
            background-color: LightYellow;
        } 
        .label8
        {
            font-family:Verdana;
            font-size:8pt;
            background-color: White;
        }         
        .button
        {
            font-family:Verdana;
            font-size:8pt;
        }   
    </style>
</head>
<body>
    <form id="form1" runat="server">
 <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
 <asp:Panel ID="MainPanel" ScrollBars="None" Wrap="true" runat="server" Height="100%" Width="100%" style="vertical-align:top;">
    <asp:UpdateProgress ID="updProgress" AssociatedUpdatePanelID="UpdatePanel" runat="server">
        <ProgressTemplate>
            <div style="position:absolute; top:150px;left:150px;">
                <img alt="progress" src="../images/ajax-loader1.gif" width="80px" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
<asp:UpdatePanel ID="UpdatePanel" runat="server">
<ContentTemplate>
        <asp:Table ID="tblFBAvail" runat="server" Width="600px">
            <asp:TableRow>
                <asp:TableCell Width="30%">&nbsp;</asp:TableCell>
                <asp:TableCell Width="70%">&nbsp;</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                <img src="../images/HeaderBasketball.png" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="Label4" runat="server" Text="OSSAA Basketball Officials Schedule" Font-Size="12pt" CssClass="header"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="lblEmail" runat="server" Text="Your Email :" CssClass="label8" Width="125px"></asp:Label><asp:Label runat="server" ID="Label6" CssClass="label" ForeColor="Red">*</asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="text" Width="200px"></asp:TextBox><asp:Button ID="cmdGo" runat="server" Text="Go" CssClass="button" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="row001">
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="lblName" runat="server" Text="Your Name :" CssClass="label8" Width="125px"></asp:Label><asp:Label runat="server" ID="red1" CssClass="label" ForeColor="Red">*</asp:Label>
                    <asp:TextBox ID="txtName" runat="server" CssClass="text"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="row002">
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="lblOSSAAID" runat="server" Text="Your OSSAAID# :" CssClass="label8" Width="125px"></asp:Label><asp:Label runat="server" ID="Label7" CssClass="label" ForeColor="Red">*</asp:Label>
                    <asp:TextBox ID="txtOSSAAID" runat="server" CssClass="text"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowSave">
                <asp:TableCell ColumnSpan="2">
                    <asp:Button ID="cmdSave" runat="server" Text="Save Changes" font-family="verdana" Font-Size="10pt" BackColor="Green" ForeColor="White"  />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="text" ForeColor="Red"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2"><hr /></asp:TableCell></asp:TableRow>
            </asp:Table>
            <asp:Table ID="tblDe" Width="600px" runat="server">
            <asp:TableRow ID="rowHelp"><asp:TableCell ColumnSpan="4"><asp:Label ID="Label5" runat="server" Font-Size="12pt" Text="To CLEAR an existing game, SELECT 'No site selected...' for that game.<br><strong>ONLY ENTER GAMES SCHEDULED AFTER JAN 1.</strong>" Font-Bold="false" ForeColor="Maroon" CssClass="label"></asp:Label></asp:TableCell></asp:TableRow>
            <asp:TableRow ID="rowHeader">
                <asp:TableCell><asp:Label ID="Label1" runat="server" Text="Game Date" CssClass="label"></asp:Label></asp:TableCell>
                <asp:TableCell><asp:Label ID="Label9" runat="server" Text="Game Time" cssclass="label"></asp:Label></asp:TableCell>
                <asp:TableCell><asp:Label ID="Label2" runat="server" Text="Game Location" cssclass="label"></asp:Label></asp:TableCell>
                <asp:TableCell><asp:Label ID="Label3" runat="server" Text="Game Type" cssclass="label"></asp:Label></asp:TableCell>
            </asp:TableRow> 
            <asp:TableRow ID="row1">
                <asp:TableCell><igsch:WebDateChooser ID="WebDateChooser1" runat="server" StyleSetName="Office2007Silver" AutoPostBack-ValueChanged="false" MinDate="2019-11-15" MaxDate="2020-03-01"></igsch:WebDateChooser></asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cboGameTime1" runat="server" >
                        <asp:ListItem Value="Select...">Select...</asp:ListItem>
                        <asp:ListItem Value="Afternoon">Afternoon</asp:ListItem>
                        <asp:ListItem Value="Evening">Evening</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>                
                <asp:TableCell><asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="SchoolDisplay" DataValueField="schoolID"></asp:DropDownList></asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cboGameType1" runat="server" >
                        <asp:ListItem Value="Select...">Select...</asp:ListItem>
                        <asp:ListItem Value="Regular Season">Regular Season</asp:ListItem>
                        <asp:ListItem Value="Tournament">Tournament</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow> 
            <asp:TableRow ID="row2">
                <asp:TableCell><igsch:WebDateChooser ID="WebDateChooser2" runat="server" StyleSetName="Office2007Silver" AutoPostBack-ValueChanged="false" MinDate="2019-11-15" MaxDate="2020-03-15"></igsch:WebDateChooser></asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cboGameTime2" runat="server" >
                        <asp:ListItem Value="Select...">Select...</asp:ListItem>
                        <asp:ListItem Value="Afternoon">Afternoon</asp:ListItem>
                        <asp:ListItem Value="Evening">Evening</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>  
                <asp:TableCell><asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource1" DataTextField="SchoolDisplay" DataValueField="schoolID"></asp:DropDownList></asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cboGameType2" runat="server" >
                        <asp:ListItem Value="Select...">Select...</asp:ListItem>
                        <asp:ListItem Value="Regular Season">Regular Season</asp:ListItem>
                        <asp:ListItem Value="Tournament">Tournament</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>            
            </asp:TableRow>    
            <asp:TableRow ID="row3">
                <asp:TableCell><igsch:WebDateChooser ID="WebDateChooser3" runat="server" StyleSetName="Office2007Silver" AutoPostBack-ValueChanged="false" MinDate="2019-11-15" MaxDate="2020-03-15"></igsch:WebDateChooser></asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cboGameTime3" runat="server" >
                        <asp:ListItem Value="Select...">Select...</asp:ListItem>
                        <asp:ListItem Value="Afternoon">Afternoon</asp:ListItem>
                        <asp:ListItem Value="Evening">Evening</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>  
                <asp:TableCell><asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="SqlDataSource1" DataTextField="SchoolDisplay" DataValueField="schoolID"></asp:DropDownList></asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cboGameType3" runat="server" >
                        <asp:ListItem Value="Select...">Select...</asp:ListItem>
                        <asp:ListItem Value="Regular Season">Regular Season</asp:ListItem>
                        <asp:ListItem Value="Tournament">Tournament</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>            
            </asp:TableRow>  
            <asp:TableRow ID="row4">
                <asp:TableCell><igsch:WebDateChooser ID="WebDateChooser4" runat="server" StyleSetName="Office2007Silver" AutoPostBack-ValueChanged="false" MinDate="2019-11-15" MaxDate="2020-03-15"></igsch:WebDateChooser></asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cboGameTime4" runat="server" >
                        <asp:ListItem Value="Select...">Select...</asp:ListItem>
                        <asp:ListItem Value="Afternoon">Afternoon</asp:ListItem>
                        <asp:ListItem Value="Evening">Evening</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>                  
                <asp:TableCell><asp:DropDownList ID="DropDownList4" runat="server" DataSourceID="SqlDataSource1" DataTextField="SchoolDisplay" DataValueField="schoolID"></asp:DropDownList></asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cboGameType4" runat="server" >
                        <asp:ListItem Value="Select...">Select...</asp:ListItem>
                        <asp:ListItem Value="Regular Season">Regular Season</asp:ListItem>
                        <asp:ListItem Value="Tournament">Tournament</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>            
            </asp:TableRow>  
            <asp:TableRow ID="row5">
                <asp:TableCell><igsch:WebDateChooser ID="WebDateChooser5" runat="server" StyleSetName="Office2007Silver" AutoPostBack-ValueChanged="false" MinDate="2019-11-15" MaxDate="2020-03-15"></igsch:WebDateChooser></asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cboGameTime5" runat="server" >
                        <asp:ListItem Value="Select...">Select...</asp:ListItem>
                        <asp:ListItem Value="Afternoon">Afternoon</asp:ListItem>
                        <asp:ListItem Value="Evening">Evening</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>                
                <asp:TableCell><asp:DropDownList ID="DropDownList5" runat="server" DataSourceID="SqlDataSource1" DataTextField="SchoolDisplay" DataValueField="schoolID"></asp:DropDownList></asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cboGameType5" runat="server" >
                        <asp:ListItem Value="Select...">Select...</asp:ListItem>
                        <asp:ListItem Value="Regular Season">Regular Season</asp:ListItem>
                        <asp:ListItem Value="Tournament">Tournament</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>            
            </asp:TableRow>  
            <asp:TableRow ID="row6">
                <asp:TableCell><igsch:WebDateChooser ID="WebDateChooser6" runat="server" StyleSetName="Office2007Silver" AutoPostBack-ValueChanged="false" MinDate="2019-11-15" MaxDate="2020-03-15"></igsch:WebDateChooser></asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cboGameTime6" runat="server" >
                        <asp:ListItem Value="Select...">Select...</asp:ListItem>
                        <asp:ListItem Value="Afternoon">Afternoon</asp:ListItem>
                        <asp:ListItem Value="Evening">Evening</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>                     
                <asp:TableCell><asp:DropDownList ID="DropDownList6" runat="server" DataSourceID="SqlDataSource1" DataTextField="SchoolDisplay" DataValueField="schoolID"></asp:DropDownList></asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cboGameType6" runat="server" >
                        <asp:ListItem Value="Select...">Select...</asp:ListItem>
                        <asp:ListItem Value="Regular Season">Regular Season</asp:ListItem>
                        <asp:ListItem Value="Tournament">Tournament</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>            
            </asp:TableRow>  
            <asp:TableRow ID="row7">
                <asp:TableCell><igsch:WebDateChooser ID="WebDateChooser7" runat="server" StyleSetName="Office2007Silver" AutoPostBack-ValueChanged="false" MinDate="2019-11-15" MaxDate="2020-03-15"></igsch:WebDateChooser></asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cboGameTime7" runat="server" >
                        <asp:ListItem Value="Select...">Select...</asp:ListItem>
                        <asp:ListItem Value="Afternoon">Afternoon</asp:ListItem>
                        <asp:ListItem Value="Evening">Evening</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>                 
                <asp:TableCell><asp:DropDownList ID="DropDownList7" runat="server" DataSourceID="SqlDataSource1" DataTextField="SchoolDisplay" DataValueField="schoolID"></asp:DropDownList></asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cboGameType7" runat="server" >
                        <asp:ListItem Value="Select...">Select...</asp:ListItem>
                        <asp:ListItem Value="Regular Season">Regular Season</asp:ListItem>
                        <asp:ListItem Value="Tournament">Tournament</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>            
            </asp:TableRow>  
            <asp:TableRow ID="row8">
                <asp:TableCell><igsch:WebDateChooser ID="WebDateChooser8" runat="server" StyleSetName="Office2007Silver" AutoPostBack-ValueChanged="false" MinDate="2019-11-15" MaxDate="2020-03-15"></igsch:WebDateChooser></asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cboGameTime8" runat="server" >
                        <asp:ListItem Value="Select...">Select...</asp:ListItem>
                        <asp:ListItem Value="Afternoon">Afternoon</asp:ListItem>
                        <asp:ListItem Value="Evening">Evening</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>                 
                <asp:TableCell><asp:DropDownList ID="DropDownList8" runat="server" DataSourceID="SqlDataSource1" DataTextField="SchoolDisplay" DataValueField="schoolID"></asp:DropDownList></asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cboGameType8" runat="server" >
                        <asp:ListItem Value="Select...">Select...</asp:ListItem>
                        <asp:ListItem Value="Regular Season">Regular Season</asp:ListItem>
                        <asp:ListItem Value="Tournament">Tournament</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>            
            </asp:TableRow>  
            <asp:TableRow ID="row9">
                <asp:TableCell><igsch:WebDateChooser ID="WebDateChooser9" runat="server" StyleSetName="Office2007Silver" AutoPostBack-ValueChanged="false" MinDate="2019-11-15" MaxDate="2020-03-15"></igsch:WebDateChooser></asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cboGameTime9" runat="server" >
                        <asp:ListItem Value="Select...">Select...</asp:ListItem>
                        <asp:ListItem Value="Afternoon">Afternoon</asp:ListItem>
                        <asp:ListItem Value="Evening">Evening</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>                 
                <asp:TableCell><asp:DropDownList ID="DropDownList9" runat="server" DataSourceID="SqlDataSource1" DataTextField="SchoolDisplay" DataValueField="schoolID"></asp:DropDownList></asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cboGameType9" runat="server" >
                        <asp:ListItem Value="Select...">Select...</asp:ListItem>
                        <asp:ListItem Value="Regular Season">Regular Season</asp:ListItem>
                        <asp:ListItem Value="Tournament">Tournament</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>            
            </asp:TableRow>  
            <asp:TableRow ID="row10">
                <asp:TableCell><igsch:WebDateChooser ID="WebDateChooser10" runat="server" StyleSetName="Office2007Silver" AutoPostBack-ValueChanged="false" MinDate="2019-11-15" MaxDate="2020-03-15"></igsch:WebDateChooser></asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cboGameTime10" runat="server" >
                        <asp:ListItem Value="Select...">Select...</asp:ListItem>
                        <asp:ListItem Value="Afternoon">Afternoon</asp:ListItem>
                        <asp:ListItem Value="Evening">Evening</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>                 
                <asp:TableCell><asp:DropDownList ID="DropDownList10" runat="server" DataSourceID="SqlDataSource1" DataTextField="SchoolDisplay" DataValueField="schoolID"></asp:DropDownList></asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cboGameType10" runat="server" >
                        <asp:ListItem Value="Select...">Select...</asp:ListItem>
                        <asp:ListItem Value="Regular Season">Regular Season</asp:ListItem>
                        <asp:ListItem Value="Tournament">Tournament</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>            
            </asp:TableRow>  
            <asp:TableRow ID="row11">
                <asp:TableCell><igsch:WebDateChooser ID="WebDateChooser11" runat="server" StyleSetName="Office2007Silver" AutoPostBack-ValueChanged="false" MinDate="2019-11-15" MaxDate="2020-03-15"></igsch:WebDateChooser></asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cboGameTime11" runat="server" >
                        <asp:ListItem Value="Select...">Select...</asp:ListItem>
                        <asp:ListItem Value="Afternoon">Afternoon</asp:ListItem>
                        <asp:ListItem Value="Evening">Evening</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>                 
                <asp:TableCell><asp:DropDownList ID="DropDownList11" runat="server" DataSourceID="SqlDataSource1" DataTextField="SchoolDisplay" DataValueField="schoolID"></asp:DropDownList></asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cboGameType11" runat="server" >
                        <asp:ListItem Value="Select...">Select...</asp:ListItem>
                        <asp:ListItem Value="Regular Season">Regular Season</asp:ListItem>
                        <asp:ListItem Value="Tournament">Tournament</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>            
            </asp:TableRow>  
            <asp:TableRow ID="row12">
                <asp:TableCell><igsch:WebDateChooser ID="WebDateChooser12" runat="server" StyleSetName="Office2007Silver" AutoPostBack-ValueChanged="false" MinDate="2019-11-15" MaxDate="2020-03-15"></igsch:WebDateChooser></asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cboGameTime12" runat="server" >
                        <asp:ListItem Value="Select...">Select...</asp:ListItem>
                        <asp:ListItem Value="Afternoon">Afternoon</asp:ListItem>
                        <asp:ListItem Value="Evening">Evening</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>                 
                <asp:TableCell><asp:DropDownList ID="DropDownList12" runat="server" DataSourceID="SqlDataSource1" DataTextField="SchoolDisplay" DataValueField="schoolID"></asp:DropDownList></asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cboGameType12" runat="server" >
                        <asp:ListItem Value="Select...">Select...</asp:ListItem>
                        <asp:ListItem Value="Regular Season">Regular Season</asp:ListItem>
                        <asp:ListItem Value="Tournament">Tournament</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>            
            </asp:TableRow>  
            <asp:TableRow ID="row13">
                <asp:TableCell><igsch:WebDateChooser ID="WebDateChooser13" runat="server" StyleSetName="Office2007Silver" AutoPostBack-ValueChanged="false" MinDate="2019-11-15" MaxDate="2020-03-15"></igsch:WebDateChooser></asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cboGameTime13" runat="server" >
                        <asp:ListItem Value="Select...">Select...</asp:ListItem>
                        <asp:ListItem Value="Afternoon">Afternoon</asp:ListItem>
                        <asp:ListItem Value="Evening">Evening</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>                 
                <asp:TableCell><asp:DropDownList ID="DropDownList13" runat="server" DataSourceID="SqlDataSource1" DataTextField="SchoolDisplay" DataValueField="schoolID"></asp:DropDownList></asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cboGameType13" runat="server" >
                        <asp:ListItem Value="Select...">Select...</asp:ListItem>
                        <asp:ListItem Value="Regular Season">Regular Season</asp:ListItem>
                        <asp:ListItem Value="Tournament">Tournament</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>            
            </asp:TableRow>  
            <asp:TableRow ID="row14">
                <asp:TableCell><igsch:WebDateChooser ID="WebDateChooser14" runat="server" StyleSetName="Office2007Silver" AutoPostBack-ValueChanged="false" MinDate="2019-11-15" MaxDate="2020-03-15"></igsch:WebDateChooser></asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cboGameTime14" runat="server" >
                        <asp:ListItem Value="Select...">Select...</asp:ListItem>
                        <asp:ListItem Value="Afternoon">Afternoon</asp:ListItem>
                        <asp:ListItem Value="Evening">Evening</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>                
                <asp:TableCell><asp:DropDownList ID="DropDownList14" runat="server" DataSourceID="SqlDataSource1" DataTextField="SchoolDisplay" DataValueField="schoolID"></asp:DropDownList></asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cboGameType14" runat="server" >
                        <asp:ListItem Value="Select...">Select...</asp:ListItem>
                        <asp:ListItem Value="Regular Season">Regular Season</asp:ListItem>
                        <asp:ListItem Value="Tournament">Tournament</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>            
            </asp:TableRow>  
            <asp:TableRow ID="row15">
                <asp:TableCell><igsch:WebDateChooser ID="WebDateChooser15" runat="server" StyleSetName="Office2007Silver" AutoPostBack-ValueChanged="false" MinDate="2019-11-15" MaxDate="2020-03-15"></igsch:WebDateChooser></asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cboGameTime15" runat="server" >
                        <asp:ListItem Value="Select...">Select...</asp:ListItem>
                        <asp:ListItem Value="Afternoon">Afternoon</asp:ListItem>
                        <asp:ListItem Value="Evening">Evening</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>                
                <asp:TableCell><asp:DropDownList ID="DropDownList15" runat="server" DataSourceID="SqlDataSource1" DataTextField="SchoolDisplay" DataValueField="schoolID"></asp:DropDownList></asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cboGameType15" runat="server" >
                        <asp:ListItem Value="Select...">Select...</asp:ListItem>
                        <asp:ListItem Value="Regular Season">Regular Season</asp:ListItem>
                        <asp:ListItem Value="Tournament">Tournament</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>            
            </asp:TableRow>   
            <asp:TableRow ID="row16">
                <asp:TableCell><igsch:WebDateChooser ID="WebDateChooser16" runat="server" StyleSetName="Office2007Silver" AutoPostBack-ValueChanged="false" MinDate="2019-11-15" MaxDate="2020-03-15"></igsch:WebDateChooser></asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cboGameTime16" runat="server" >
                        <asp:ListItem Value="Select...">Select...</asp:ListItem>
                        <asp:ListItem Value="Afternoon">Afternoon</asp:ListItem>
                        <asp:ListItem Value="Evening">Evening</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>                
                <asp:TableCell><asp:DropDownList ID="DropDownList16" runat="server" DataSourceID="SqlDataSource1" DataTextField="SchoolDisplay" DataValueField="schoolID"></asp:DropDownList></asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cboGameType16" runat="server" >
                        <asp:ListItem Value="Select...">Select...</asp:ListItem>
                        <asp:ListItem Value="Regular Season">Regular Season</asp:ListItem>
                        <asp:ListItem Value="Tournament">Tournament</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>            
            </asp:TableRow>  
            <asp:TableRow ID="row17">
                <asp:TableCell><igsch:WebDateChooser ID="WebDateChooser17" runat="server" StyleSetName="Office2007Silver" AutoPostBack-ValueChanged="false" MinDate="2019-11-15" MaxDate="2020-03-15"></igsch:WebDateChooser></asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cboGameTime17" runat="server" >
                        <asp:ListItem Value="Select...">Select...</asp:ListItem>
                        <asp:ListItem Value="Afternoon">Afternoon</asp:ListItem>
                        <asp:ListItem Value="Evening">Evening</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>                
                <asp:TableCell><asp:DropDownList ID="DropDownList17" runat="server" DataSourceID="SqlDataSource1" DataTextField="SchoolDisplay" DataValueField="schoolID"></asp:DropDownList></asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cboGameType17" runat="server" >
                        <asp:ListItem Value="Select...">Select...</asp:ListItem>
                        <asp:ListItem Value="Regular Season">Regular Season</asp:ListItem>
                        <asp:ListItem Value="Tournament">Tournament</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>            
            </asp:TableRow>  
            <asp:TableRow ID="row18">
                <asp:TableCell><igsch:WebDateChooser ID="WebDateChooser18" runat="server" StyleSetName="Office2007Silver" AutoPostBack-ValueChanged="false" MinDate="2019-11-15" MaxDate="2020-03-15"></igsch:WebDateChooser></asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cboGameTime18" runat="server" >
                        <asp:ListItem Value="Select...">Select...</asp:ListItem>
                        <asp:ListItem Value="Afternoon">Afternoon</asp:ListItem>
                        <asp:ListItem Value="Evening">Evening</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>                
                <asp:TableCell><asp:DropDownList ID="DropDownList18" runat="server" DataSourceID="SqlDataSource1" DataTextField="SchoolDisplay" DataValueField="schoolID"></asp:DropDownList></asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cboGameType18" runat="server" >
                        <asp:ListItem Value="Select...">Select...</asp:ListItem>
                        <asp:ListItem Value="Regular Season">Regular Season</asp:ListItem>
                        <asp:ListItem Value="Tournament">Tournament</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>            
            </asp:TableRow>  
            <asp:TableRow ID="row19">
                <asp:TableCell><igsch:WebDateChooser ID="WebDateChooser19" runat="server" StyleSetName="Office2007Silver" AutoPostBack-ValueChanged="false" MinDate="2019-11-15" MaxDate="2020-03-15"></igsch:WebDateChooser></asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cboGameTime19" runat="server" >
                        <asp:ListItem Value="Select...">Select...</asp:ListItem>
                        <asp:ListItem Value="Afternoon">Afternoon</asp:ListItem>
                        <asp:ListItem Value="Evening">Evening</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>                
                <asp:TableCell><asp:DropDownList ID="DropDownList19" runat="server" DataSourceID="SqlDataSource1" DataTextField="SchoolDisplay" DataValueField="schoolID"></asp:DropDownList></asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cboGameType19" runat="server" >
                        <asp:ListItem Value="Select...">Select...</asp:ListItem>
                        <asp:ListItem Value="Regular Season">Regular Season</asp:ListItem>
                        <asp:ListItem Value="Tournament">Tournament</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>            
            </asp:TableRow>  
            <asp:TableRow ID="row20">
                <asp:TableCell><igsch:WebDateChooser ID="WebDateChooser20" runat="server" StyleSetName="Office2007Silver" AutoPostBack-ValueChanged="false" MinDate="2019-11-15" MaxDate="2020-03-15"></igsch:WebDateChooser></asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cboGameTime20" runat="server" >
                        <asp:ListItem Value="Select...">Select...</asp:ListItem>
                        <asp:ListItem Value="Afternoon">Afternoon</asp:ListItem>
                        <asp:ListItem Value="Evening">Evening</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>                
                <asp:TableCell><asp:DropDownList ID="DropDownList20" runat="server" DataSourceID="SqlDataSource1" DataTextField="SchoolDisplay" DataValueField="schoolID"></asp:DropDownList></asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cboGameType20" runat="server" >
                        <asp:ListItem Value="Select...">Select...</asp:ListItem>
                        <asp:ListItem Value="Regular Season">Regular Season</asp:ListItem>
                        <asp:ListItem Value="Tournament">Tournament</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>            
            </asp:TableRow>  
        </asp:Table>
    </ContentTemplate>
    <Triggers>

    </Triggers>
    </asp:UpdatePanel>
    </asp:Panel>
    </form>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OSSAARANKINGSConnectionString %>" 
        SelectCommand="SELECT DISTINCT SchoolName AS SchoolDisplay, schoolID FROM ossaauser.viewTeamsBasketball ORDER BY SchoolName"></asp:SqlDataSource>

</body>
</html>
