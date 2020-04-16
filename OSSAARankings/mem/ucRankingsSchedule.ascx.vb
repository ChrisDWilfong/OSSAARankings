Public Class ucRankingsSchedule
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strSport As String = ""

        ' Put a Note at the top...
        Dim strNote As String = ""
        Try
            strSport = Session("memgSportID").ToString          ' Added 11/14/2014...
            If strSport.Contains("Wrestling") Then
                strSport = strSport.Replace("Wrestling", "WrestlingDual")
            End If
            strNote = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT strRankingNote FROM tblSports WHERE sportID = '" & Session("memgSportID") & "'")
        Catch
        End Try
        If strNote = "" Then
        Else
            Me.lblNote.Text = strNote
        End If

        GridView1.DataSource = clsRankings.GetRankingsSchedule(strSport, clsFunctions.GetCurrentYear, True)
        GridView1.DataBind()
    End Sub

End Class