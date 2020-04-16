Public Class Utilities
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub cmdCopyClassForSport_Click(sender As Object, e As System.EventArgs) Handles cmdCopyClassForSport.Click
        Dim ds As DataSet
        Dim strSQL As String
        Dim strSportID As String = ""

        lblMessage.Text = ""

        strSQL = "SELECT * FROM allCoachesDetail WHERE (intYear = 17 AND sportID = 'Football') ORDER BY SchoolName"

        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            For x = 0 To ds.Tables(0).Rows.Count - 1
                strSportID = ""
                strSQL = "SELECT sportID FROM allCoachesDetail WHERE (intYear = 16 AND sportID Like 'Football%' AND schoolName = '" & ds.Tables(0).Rows(x).Item("schoolName") & "')"
                strSportID = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, strSQL)
                If strSportID = "" Or strSportID = "Football" Then
                Else
                    strSQL = "UPDATE allCoachesDetail SET sportID = '" & strSportID & "' WHERE (intYear = 17 AND sportID Like 'Football%' AND schoolName = '" & ds.Tables(0).Rows(x).Item("schoolName") & "')"
                    SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
                End If
            Next x
        End If
        lblMessage.Text = "Process complete."
    End Sub

    Private Sub cmdTestEmail_Click(sender As Object, e As System.EventArgs) Handles cmdTestEmail.Click
        'clsEmail.SendEmail(sender, "Test Content", "cwilfong@ipa.net", "", "Test Subject")
        clsEmail.SendEmailNew("cwilfong@ipa.net", "", "Test Subject", "Test Content", False, "OSSAA Test Email")
    End Sub
End Class