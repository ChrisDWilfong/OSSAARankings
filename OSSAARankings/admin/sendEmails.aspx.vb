Public Class sendEmails
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub cmdSendEmails_Click(sender As Object, e As System.EventArgs) Handles cmdSendEmails.Click
        Dim strSQL As String
        strSQL = "SELECT * FROM emails WHERE intSend <> 0"
        Dim ds As DataSet
        Dim x As Integer = 0
        Dim intCount As Integer = 0

        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

        If ds Is Nothing Then
            lblMessage.Text = "Non selected."
        ElseIf ds.Tables.Count = 0 Then
            lblMessage.Text = "Non selected."
        ElseIf ds.Tables(0).Rows.Count = 0 Then
            lblMessage.Text = "Non selected."
        Else
            For x = 0 To ds.Tables(0).Rows.Count - 1
                clsEmail.SendEmail(sender, ds.Tables(0).Rows(x).Item("strContent"), ds.Tables(0).Rows(x).Item("strEmailTo"), "", ds.Tables(0).Rows(x).Item("strSubject"), True)
                strSQL = "UPDATE emails SET dtmStamp = '" & Now & "' WHERE Id = " & ds.Tables(0).Rows(x).Item("Id")
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            Next
            lblMessage.Text = "Process complete (" & (x + 1) & " emails sent)"
        End If
    End Sub
End Class