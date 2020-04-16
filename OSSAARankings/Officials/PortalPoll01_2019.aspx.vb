Public Class PortalPoll01_2019
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("userEMAIL") Is Nothing Then
            Response.Redirect("Portal.aspx")
        ElseIf Session("userEMAIL") = "" Then
            Response.Redirect("Portal.aspx")
        End If

        If Session("CanVote") = "No" Then
            rowRegion2.Visible = False
            rowRegion5.Visible = False
            rowRegion6.Visible = False
            rowRegion8.Visible = False
            cmdSave.Enabled = False
            lblMessage.Text = "You must have an assigned OSSAA ID# in order to submit a vote.<br>If you are having problems, please call Sheree at 405.840.1116."
        Else
            cmdSave.Enabled = True
            cmdReturn.Enabled = True
            'Lets load existing vote submitted... CDW added 7/7/2019...
            'Dim strSelectedName As String = ""
            'Dim strSQL As String = "SELECT strVote01 FROM prodOfficials WHERE strEmail = '" & Session("userEMAIL") & "'"
            'Try
            '    strSelectedName = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            'Catch ex As Exception
            '    strSelectedName = ""
            'End Try
            Select Case Session("ZipCodeZone")
                Case 2
                    rowRegion2.Visible = True
                    'If strSelectedName <> "" Then
                    '    cbListRegion2.SelectedValue = strSelectedName
                    'End If
                Case 5
                    rowRegion5.Visible = True
                    'If strSelectedName <> "" Then
                    '    cbListRegion5.SelectedValue = strSelectedName
                    'End If
                Case 6
                    rowRegion6.Visible = True
                    'If strSelectedName <> "" Then
                    '    cbListRegion6.SelectedValue = strSelectedName
                    'End If
                Case 8
                    rowRegion8.Visible = True
                    'If strSelectedName <> "" Then
                    '    cbListRegion8.SelectedValue = strSelectedName
                    'End If
                Case Else
                    rowRegion2.Visible = False
                    rowRegion5.Visible = False
                    rowRegion6.Visible = False
                    rowRegion8.Visible = False
            End Select


        End If

    End Sub

    Private Sub cmdReturn_Click(sender As Object, e As EventArgs) Handles cmdReturn.Click
        Response.Redirect("Portal.aspx")
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Dim strSQL As String = ""
        Dim strName As String = ""

        If Session("ZipCodeZone") = 2 And cbListRegion2.SelectedValue = "" Then
            lblMessage.Text = "You must complete the VOTING form."
        ElseIf Session("ZipCodeZone") = 5 And cbListRegion5.SelectedValue = "" Then
            lblMessage.Text = "You must complete the VOTING form."
        ElseIf Session("ZipCodeZone") = 6 And cbListRegion6.SelectedValue = "" Then
            lblMessage.Text = "You must complete the VOTING form."
        ElseIf Session("ZipCodeZone") = 8 And cbListRegion8.SelectedValue = "" Then
            lblMessage.Text = "You must complete the VOTING form."
        Else
            ' Submit the vote...
            Select Case Session("ZipCodeZone")
                Case 2
                    strName = cbListRegion2.SelectedValue
                Case 5
                    strName = cbListRegion5.SelectedValue
                Case 6
                    strName = cbListRegion6.SelectedValue
                Case 8
                    strName = cbListRegion8.SelectedValue
                Case Else
                    strName = ""
            End Select
            If strName = "" Then

            Else
                strSQL = "UPDATE prodOfficials SET intZone = " & Session("ZipCodeZone") & ", strVote01 = '" & strName & "', dtmStampVote = '" & Now & "' WHERE intOSSAAID > 0 AND strEmail = '" & Session("userEMAIL") & "'"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            End If
            Response.Redirect("Portal.aspx")
        End If

    End Sub
End Class