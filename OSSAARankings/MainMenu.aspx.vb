Public Class MainMenu
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Dim ds As DataSet
            Dim x As Integer
            Dim strSQL As String

            strSQL = "SELECT DISTINCT GenderSport1 FROM tblSports WHERE NumberOfRankingsShow > 0 ORDER BY GenderSport1"
            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)
            If ds Is Nothing Then
            ElseIf ds.Tables.Count = 0 Then
            ElseIf ds.Tables(0).Rows.Count = 0 Then
            Else
                For x = 0 To ds.Tables(0).Rows.Count - 1
                    Dim objItem As New Infragistics.Web.UI.NavigationControls.ExplorerBarItem
                    objItem.Text = ds.Tables(0).Rows(x).Item("GenderSport1")
                    WebExplorerBar1.Groups(0).Items.Add(objItem)
                    WebExplorerBar1.Groups(1).Items.Add(objItem)
                Next x
            End If

            strSQL = "SELECT DISTINCT GenderSport1 FROM tblSports WHERE intDistrictStandings > 0 ORDER BY GenderSport1"
            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)
            If ds Is Nothing Then
            ElseIf ds.Tables.Count = 0 Then
            ElseIf ds.Tables(0).Rows.Count = 0 Then
            Else
                For x = 0 To ds.Tables(0).Rows.Count - 1
                    Dim objItem As New Infragistics.Web.UI.NavigationControls.ExplorerBarItem
                    objItem.Text = ds.Tables(0).Rows(x).Item("GenderSport1")
                    WebExplorerBar1.Groups(2).Items.Add(objItem)
                Next x
            End If

        End If

    End Sub

End Class