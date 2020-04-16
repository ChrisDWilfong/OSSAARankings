Public Class ucSportsListSchedulesClass
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Dim intYear As Integer = clsFunctions.GetCurrentYear
            Dim ds As DataSet
            Dim x As Integer
            Dim strSQL As String

            strSQL = "SELECT DISTINCT GenderSport1, GenderSport, Sport, Gender, SportGenderKey FROM tblSports WHERE intSchedules > 0 ORDER BY GenderSport1"

            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)
            If ds Is Nothing Then
            ElseIf ds.Tables.Count = 0 Then
            ElseIf ds.Tables(0).Rows.Count = 0 Then
            Else
                For x = 0 To ds.Tables(0).Rows.Count - 1
                    Dim objGroupBar As New Infragistics.Web.UI.NavigationControls.ExplorerBarGroup
                    objGroupBar.Value = ds.Tables(0).Rows(x).Item("SportGenderKey")
                    objGroupBar.Text = ds.Tables(0).Rows(x).Item("GenderSport1")
                    objGroupBar.NavigateUrl = "?sel=schedulesClass&spGK=" & ds.Tables(0).Rows(x).Item("SportGenderKey") & "&y=" & intYear
                    ExplorerBarSportsListClass.Groups.Add(objGroupBar)
                Next x
            End If

        End If
    End Sub

End Class