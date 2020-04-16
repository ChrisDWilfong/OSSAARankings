Public Class BBMainMenu
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub


    Protected Sub cmdEditGame_Click(sender As Object, e As EventArgs) Handles cmdEditGame.Click
        If cboGame.SelectedValue = "" Then
            lblMessage.Text = "You must select a game to Edit."
        Else
            Session("cboGame") = Me.cboGame.SelectedValue
            Session("AddEdit") = "EDIT"
            Response.Redirect("BBRatingEntry.aspx")
        End If
    End Sub

    Protected Sub cmdAddGame_Click(sender As Object, e As EventArgs) Handles cmdAddGame.Click

        Session("CrewRatingID") = 0
        Session("AddEdit") = "ADD"

        ' Get the next Game Number...
        Dim strSQL As String = ""
        Dim intCount As Integer
        intCount = 0
        If Session("CoachIDGirls") > 0 And Session("CoachIDBoys") > 0 Then
            strSQL = "SELECT COUNT(intCoachID) AS CoachCount FROM tblOfficialsRatingByCoachesBB WHERE intCoachID = " & Session("CoachID")
        ElseIf Session("CoachIDGirls") > 0 Then
            strSQL = "SELECT COUNT(intCoachID) AS CoachCount FROM tblOfficialsRatingByCoachesBB WHERE intCoachID = " & Session("CoachIDGirls")
        ElseIf Session("CoachIDBoys") > 0 Then
            strSQL = "SELECT COUNT(intCoachID) AS CoachCount FROM tblOfficialsRatingByCoachesBB WHERE intCoachID = " & Session("CoachIDBoys")
        End If
        'strSQL = "SELECT COUNT(intCoachID) AS CoachCount FROM tblOfficialsRatingByCoachesBB WHERE intCoachID = " & Session("CoachID")
        intCount = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
        intCount = intCount + 1
        Session("GameCount") = intCount
        Response.Redirect("BBRatingEntry.aspx")
    End Sub
End Class