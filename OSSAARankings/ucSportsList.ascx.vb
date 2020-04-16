Partial Class ucSportsList
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Dim ds As DataSet
            Dim x As Integer
            Dim strSQL As String = ""

            Select Case Session("listtype")
                Case "rankings"
                    strSQL = "SELECT DISTINCT GenderSport1, GenderSport, Sport, Gender FROM tblSports WHERE intRankings > 0 ORDER BY GenderSport1"
                Case "schedules"
                    strSQL = "SELECT DISTINCT GenderSport1, GenderSport, Sport, Gender FROM tblSports WHERE intSchedules > 0 ORDER BY GenderSport1"
                Case "districts"
                    strSQL = "SELECT DISTINCT GenderSport1, GenderSport, Sport, Gender FROM tblSports WHERE intDistrictStandings > 0 ORDER BY GenderSport1"
                Case Else

            End Select

            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)
            If ds Is Nothing Then
            ElseIf ds.Tables.Count = 0 Then
            ElseIf ds.Tables(0).Rows.Count = 0 Then
            Else
                For x = 0 To ds.Tables(0).Rows.Count - 1
                    Dim objGroupBar As New Infragistics.Web.UI.NavigationControls.ExplorerBarGroup
                    objGroupBar.Value = ds.Tables(0).Rows(x).Item("GenderSport")
                    objGroupBar.Text = ds.Tables(0).Rows(x).Item("GenderSport1")
                    objGroupBar.NavigateUrl = "?sel=rankings&sp=" & ds.Tables(0).Rows(x).Item("Sport") & "&g=" & ds.Tables(0).Rows(x).Item("Gender")
                    Me.ExplorerBarSportsList.Groups.Add(objGroupBar)
                Next x
            End If

        End If
    End Sub

End Class