Public Class PortalPoll01
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("userEMAIL") Is Nothing Then
            Response.Redirect("Portal.aspx")
        ElseIf Session("userEMAIL") = "" Then
            Response.Redirect("Portal.aspx")
        End If

        If Session("CanVote") = "No" Then
            rowVote01.Visible = False
            rowRegion1.Visible = False
            rowRegion3.Visible = False
            rowRegion4.Visible = False
            rowRegion7.Visible = False
            cmdSave.Enabled = False
            lblMessage.Text = "You must be registered as an OSSAA Official via ArbiterSports AND have an assigned OSSAA ID# in order to submit a vote.<br>If you are having problems, please call Sheree at 405.840.1116."
        Else
            cmdSave.Enabled = True
            cmdReturn.Enabled = True
            Select Case Session("ZipCodeZone")
                Case 1
                    rowRegion1.Visible = True
                Case 3
                    rowRegion3.Visible = True
                Case 4
                    rowRegion4.Visible = True
                Case 7
                    rowRegion7.Visible = True
                Case Else
                    rowRegion1.Visible = False
                    rowRegion3.Visible = False
                    rowRegion4.Visible = False
                    rowRegion7.Visible = False
            End Select
        End If

    End Sub

    Private Sub cmdReturn_Click(sender As Object, e As EventArgs) Handles cmdReturn.Click
        Response.Redirect("Portal.aspx")
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Dim strSQL As String = ""
        Dim strName As String = ""

        If cbVote01.SelectedValue = "" Then
            lblMessage.Text = "You must complete the VOTING form."
        ElseIf Session("ZipCodeZone") = 1 And cbListRegion1.SelectedValue = "" Then
            lblMessage.Text = "You must complete the VOTING form."
        ElseIf Session("ZipCodeZone") = 3 And cbListRegion3.SelectedValue = "" Then
            lblMessage.Text = "You must complete the VOTING form."
        ElseIf Session("ZipCodeZone") = 4 And cbListRegion4.SelectedValue = "" Then
            lblMessage.Text = "You must complete the VOTING form."
        ElseIf Session("ZipCodeZone") = 7 And cbListRegion7.SelectedValue = "" Then
            lblMessage.Text = "You must complete the VOTING form."
        Else
            ' Submit the vote...
            Select Case Session("ZipCodeZone")
                Case 1
                    strName = cbListRegion1.SelectedValue
                Case 3
                    strName = cbListRegion3.SelectedValue
                Case 4
                    strName = cbListRegion4.SelectedValue
                Case 7
                    strName = cbListRegion7.SelectedValue
                Case Else
                    strName = ""
            End Select
            strSQL = "UPDATE prodOfficials SET intZone = " & Session("ZipCodeZone") & ", strVote0101 = '" & cbVote01.SelectedValue & "', strVote0102 = '" & strName & "', dtmStampVote = '" & Now & "' WHERE strEmail = '" & Session("userEMAIL") & "'"
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            Response.Redirect("Portal.aspx")
        End If

    End Sub
End Class