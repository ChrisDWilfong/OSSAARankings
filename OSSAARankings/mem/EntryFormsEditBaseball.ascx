<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="EntryFormsEditBaseball.ascx.vb" Inherits="OSSAARankings.EntryFormsEditBaseball" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<table>
    <tr>
        <td colspan="2"><strong>2017-18 BASEBALL ENTRY FORM</strong></td>
    </tr>
    <tr>
        <td style="width:75px;">
            <telerik:RadDropDownList ID="RadDropDownList1" runat="server" Width="60px">
                <Items>
                    <telerik:DropDownListItem Text="Select..." Value="-" />
                    <telerik:DropDownListItem Text="YES" Value="YES" />
                    <telerik:DropDownListItem Text="NO" Value="NO" />
                </Items>
            </telerik:RadDropDownList>
        </td>
        <td>
            <asp:Label ID="Label1" runat="server" Text="Is the lighting adequate for safe and fair play?"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="width:75px;">
            <telerik:RadDropDownList ID="RadDropDownList2" runat="server" Width="60px">
                <Items>
                    <telerik:DropDownListItem Text="Select..." Value="-" />
                    <telerik:DropDownListItem Text="YES" Value="YES" />
                    <telerik:DropDownListItem Text="NO" Value="NO" />
                </Items>
            </telerik:RadDropDownList>
        </td>
        <td>
            <asp:Label ID="Label2" runat="server" Text="Is the infield grass, dirt and outfield smooth and is it adequate for safe and fair play?"></asp:Label>
        </td>
    </tr>
    <tr>
        <td><asp:Button ID="cmdSave" runat="server" Text="Save Changes" /></td>
        <td><asp:Button ID="cmdCancel" Text="Cancel" runat="server" CausesValidation="False" CommandName="Cancel"></asp:Button></td>
    </tr>
</table>
