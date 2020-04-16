<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm1.aspx.vb" Inherits="OSSAARankings.WebForm1" %>

<%@ Register Assembly="Infragistics4.Web.v10.2, Version=10.2.20102.1011, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

</head>

<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
<ig:WebDatePicker ID="WebDatePicker1" runat="server" StyleSetName="RubberBlack">
</ig:WebDatePicker>    
    </div>
    </form>
</body>
</html>
