<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DashboardMembershipDetails.ascx.vb" Inherits="OSSAARankings.DashboardMembershipDetails" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Table runat="server" ID="tblMemDets" style="padding-left:10px;">
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left">
                <asp:Label ID="Label2" runat="server" Text="Type : "  ></asp:Label>
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Left" ColumnSpan="3">
                <asp:DropDownList runat="server" ID="strLineType" Text='<%# DataBinder.Eval(Container, "DataItem.strLineType")%>'>
                    <asp:ListItem Text="Link" Value="Link"></asp:ListItem>
                    <asp:ListItem Text="Link (Bold)" Value="LinkBold"></asp:ListItem>
                    <asp:ListItem Text="Link (w/Image)" Value="LinkImage"></asp:ListItem>
                    <asp:ListItem Text="Red Heading" Value="RedHeading"></asp:ListItem>
                    <asp:ListItem Text="Text" Value="Text"></asp:ListItem>
                    <asp:ListItem Text="Text (Bold)" Value="TextBold"></asp:ListItem>
                    <asp:ListItem Text="Select..." Value=""></asp:ListItem>
                </asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="left">
            <asp:TableCell >
                <asp:TextBox ID="id" runat="server" Visible="false" CssClass="textbox" Font-Names="Verdana" Width="60px" Text='<%# DataBinder.Eval(Container, "DataItem.id")%>'  CausesValidation="false" ForeColor="Blue"></asp:TextBox>
            </asp:TableCell >
                <asp:Label ID="lblDescription" runat="server" Text="Description: "  ></asp:Label>
            </asp:TableCell >
            <asp:TableCell >
                <asp:TextBox ID="strDescription" runat="server" CssClass="textbox" Font-Names="Verdana" Width="600px" TextMode="MultiLine" Rows="20" Text='<%# DataBinder.Eval(Container, "DataItem.strDescription")%>'  CausesValidation="false" ForeColor="Blue"></asp:TextBox>
            </asp:TableCell >
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="left">
                <asp:Label ID="Label1" runat="server" Text="Upload: "  ></asp:Label>
            </asp:TableCell > 
            <asp:TableCell>  
                <Telerik:RadAsyncUpload id="RadAsyncUpload1"  runat="server" ForeColor="yellow"> </Telerik:RadAsyncUpload>
                <asp:Button id="UploadButton" AutoPostBack="true" Text="Upload Document" runat="server" OnClick="UploadDocument_Click" ForeColor="Black">
                </asp:Button>   
                <asp:Label id="UploadStatusLabel"  forecolor="Red" runat="server">
                </asp:Label>                              
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow><asp:TableCell ColumnSpan="2">
            <asp:Label ID="lblOR" runat="server" Text="OR" ForeColor="Yellow" Font-Bold="true"></asp:Label>
        </asp:TableCell></asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="left">
                <asp:Label ID="lblLinkAdd" runat="server" Text="Link : "  ></asp:Label>
            </asp:TableCell >
            <asp:TableCell >
                <asp:TextBox ID="strLink" runat="server" CssClass="textbox" Width="600px" Font-Names="Verdana" Text='<%# DataBinder.Eval(Container, "DataItem.strLink")%>'  CausesValidation="false" ForeColor="Blue"></asp:TextBox>
            </asp:TableCell >
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="left">
                <asp:Label ID="lblSort" runat="server" Text="Sort : "  ></asp:Label>
            </asp:TableCell >
            <asp:TableCell >
                <asp:TextBox ID="intSort" runat="server" CssClass="textbox" Width="50px" Font-Names="Verdana" Text='<%# DataBinder.Eval(Container, "DataItem.intSort")%>'  CausesValidation="false" ForeColor="Blue"></asp:TextBox>
            </asp:TableCell >
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="left">
                <asp:Label ID="lblYear" runat="server" Text="Year : "  ></asp:Label>
            </asp:TableCell >
            <asp:TableCell >
                <asp:TextBox ID="intYear" runat="server" CssClass="textbox" Width="50px" Font-Names="Verdana" Text='<%# DataBinder.Eval(Container, "DataItem.intYear")%>'  CausesValidation="false" ForeColor="Blue"></asp:TextBox>
            </asp:TableCell >
        </asp:TableRow>
        <asp:TableRow>
         <asp:TableCell>&nbsp;</asp:TableCell>
            <asp:TableCell  HorizontalAlign="left"> 
               <asp:Button ID="cmdSubmit" runat="server" Text="Save Changes" CommandName="Update" CausesValidation="false" ForeColor="Black" />&nbsp;&nbsp;
               <asp:Button ID="btnCancel" Text="Cancel" runat="server" CausesValidation="False" CommandName="Cancel" ForeColor="Black"></asp:Button>&nbsp;&nbsp;
        </asp:TableCell >
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:Label runat="server" ID="lblMessage" ForeColor="Red"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
</asp:Table>