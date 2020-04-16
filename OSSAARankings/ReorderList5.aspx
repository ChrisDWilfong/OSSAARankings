<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<script runat="server">

</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Control Toolkit</title>
  <style type="text/css">
    .DragHandleClass {
      width: 12px;
	    height: 12px;
	    background-color: red;
	    cursor:move;
	  }
  </style>
</head>
<body>
  <form id="form1" runat="server">
    <asp:ScriptManager ID="asm" runat="server" />
    <asp:SqlDataSource ID="sds" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OKRANKINGSConnectionString %>" OldValuesParameterFormatString="original_{0}"
        SelectCommand="SELECT [schoolID], [School] FROM [tblSchools] ORDER BY [School]">
    </asp:SqlDataSource>
    <div>
      <ajaxToolkit:ReorderList ID="rl1" runat="server" SortOrderField="School" AllowReorder="true"
        DataSourceID="sds" DataKeyField="schoolId">
        <DragHandleTemplate>
          <div class="DragHandleClass">
          </div>
        </DragHandleTemplate>
        <ItemTemplate>
            <asp:Label ID="ItemLabel" runat="server" Text='<%#Eval("school") %>' />
        </ItemTemplate>
      </ajaxToolkit:ReorderList>
    </div>
  </form>
</body>
</html>
