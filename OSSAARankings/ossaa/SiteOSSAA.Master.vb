Partial Class SiteOSSAA
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Load the Classifications Menu item...
        Dim strSQL As String
        Dim ds As DataSet
        Dim x As Integer = 0

        If Not IsPostBack Then

            strSQL = "SELECT * FROM tblDashboardLinks WHERE strSite = 'OSSAA.COM' AND strType = 'Classifications' ORDER BY intSort DESC"
            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

            If ds Is Nothing Then
            ElseIf ds.Tables.Count = 0 Then
            ElseIf ds.Tables(0).Rows.Count = 0 Then
            Else
                For x = 0 To ds.Tables(0).Rows.Count - 1
                    Dim objMenuItem As New System.Web.UI.WebControls.MenuItem
                    Select Case ds.Tables(0).Rows(x).Item("strLineType")
                        Case "Link"
                            objMenuItem.Text = ds.Tables(0).Rows(x).Item("strDescription")
                            objMenuItem.NavigateUrl = ds.Tables(0).Rows(x).Item("strLink")
                            objMenuItem.Target = "_blank"
                            NavigationMenu.FindItem("Classification").ChildItems.Add(objMenuItem)
                        Case "TextBold"
                            objMenuItem.Text = "<strong><span style='color:white;'>" & ds.Tables(0).Rows(x).Item("strDescription") & "</span></strong>"
                            NavigationMenu.FindItem("Classification").ChildItems.Add(objMenuItem)
                        Case Else
                    End Select
                Next
            End If

            strSQL = "SELECT * FROM tblDashboardLinks WHERE strSite = 'OSSAA.COM' AND strType = 'OSSAAInfo' ORDER BY intSort DESC"
            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

            If ds Is Nothing Then
            ElseIf ds.Tables.Count = 0 Then
            ElseIf ds.Tables(0).Rows.Count = 0 Then
            Else
                For x = 0 To ds.Tables(0).Rows.Count - 1
                    Dim objMenuItem As New System.Web.UI.WebControls.MenuItem
                    Select Case ds.Tables(0).Rows(x).Item("strLineType")
                        Case "Link"
                            objMenuItem.Text = ds.Tables(0).Rows(x).Item("strDescription")
                            objMenuItem.NavigateUrl = ds.Tables(0).Rows(x).Item("strLink")
                            objMenuItem.Target = "_blank"
                            NavigationMenu.FindItem("OSSAA Info").ChildItems.Add(objMenuItem)
                        Case "TextBold"
                            objMenuItem.Text = "<strong><span style='color:white;'>" & ds.Tables(0).Rows(x).Item("strDescription") & "</span></strong>"
                            NavigationMenu.FindItem("OSSAA Info").ChildItems.Add(objMenuItem)
                        Case Else
                    End Select
                Next
            End If


        End If

    End Sub

End Class