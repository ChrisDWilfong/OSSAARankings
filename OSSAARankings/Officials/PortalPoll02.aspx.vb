Public Class PortalPoll02
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("userEMAIL") Is Nothing Then
            Response.Redirect("Portal.aspx")
        ElseIf Session("userEMAIL") = "" Then
            Response.Redirect("Portal.aspx")
        End If

        'If Session("CanVote") = "No" Then
        '    cmdSave.Enabled = False
        '    lblMessage.Text = "You must be registered as an OSSAA Official via ArbiterSports AND have an assigned OSSAA ID# in order to submit a vote.<br>If you are having problems, please call Sheree at 405.840.1116."
        'Else
        '    cmdSave.Enabled = True
        '    cmdReturn.Enabled = True
        'End If

    End Sub

    Private Sub cmdReturn_Click(sender As Object, e As EventArgs) Handles cmdReturn.Click
        Response.Redirect("Portal.aspx")
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Dim strSQL As String = ""
        Dim strName As String = ""

        If cbVote01.SelectedValue = "" Then
            lblMessage.Text = "You must complete the VOTING form."
        ElseIf cbVote02.SelectedValue = "" Then
            lblMessage.Text = "You must complete the VOTING form."
        Else
            strSQL = "UPDATE prodOfficials SET intZone = " & Session("ZipCodeZone") & ", strVote0201 = '" & cbVote01.SelectedValue & "', strVote0202 = '" & cbVote02.SelectedValue & "', dtmStampVote = '" & Now & "' WHERE strEmail = '" & Session("userEMAIL") & "'"
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            Response.Redirect("Portal.aspx")
        End If

    End Sub
End Class