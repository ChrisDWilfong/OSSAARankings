Public Class NewYearUtils
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub cmdCreateTeamsForAllSportsSchools_Click(sender As Object, e As EventArgs) Handles cmdCreateTeamsForAllSportsSchools.Click
        Dim strSQL As String
        Dim ds As DataSet
        Dim dss As DataSet
        Dim x As Integer
        Dim y As Integer
        strSQL = "SELECT * FROM tblSchool WHERE OrganizationType = 'SCHOOL' ORDER BY SchoolName"
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            For x = 0 To ds.Tables(0).Rows.Count - 1
                strSQL = "SELECT * FROM tblSports WHERE [Class] = '-' ORDER BY SportID"
                dss = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)
                If dss Is Nothing Then
                ElseIf dss.Tables.Count = 0 Then
                ElseIf dss.Tables(0).Rows.Count = 0 Then
                Else
                    For y = 0 To dss.Tables(0).Rows.Count - 1
                        strSQL = "INSERT INTO tblTeams (schoolID, sportID, sportIDOld, WL, W, L, District, intYear, memberID, HeadToHead, SchoolName) VALUES ("
                        strSQL = strSQL & ds.Tables(0).Rows(x).Item("schoolID") & ", '" & dss.Tables(0).Rows(y).Item("sportID") & "', 0, '0-0', 0, 0, 0, 16, 0, 0, '" & ds.Tables(0).Rows(x).Item("SchoolName") & "')"
                        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
                    Next
                End If
            Next x
        End If

    End Sub
End Class