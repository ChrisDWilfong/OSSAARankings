﻿Public Class PortalPoll_Jerseys
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("userEMAIL") Is Nothing Then
            Response.Redirect("Portal.aspx")
        ElseIf Session("userEMAIL") = "" Then
            Response.Redirect("Portal.aspx")
        End If

        'Session("userEMAIL") = "pgrimes@metalsusa.com"

        If Session("CanVote") = "No" Then
            rowVote01.Visible = False
            cmdSave.Enabled = False
            lblMessage.Text = "You must be registered as an OSSAA Official via ArbiterSports AND have an assigned OSSAA ID# in order to submit a vote.<br>If you are having problems, please call Sheree at 405.840.1116."
        Else
            cmdSave.Enabled = True
            cmdReturn.Enabled = True
        End If

        If Not IsPostBack Then
            ' Load the previous selection...
            Dim strSQL As String = "SELECT strVote01 FROM prodOfficials WHERE strEmail = '" & Session("userEMAIL") & "'"
            Dim strVote As String
            Try
                strVote = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
                cbVote01.SelectedValue = strVote
            Catch ex As Exception

            End Try
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
        Else
            ' Submit the vote...
            strSQL = "UPDATE prodOfficials SET intZone = " & Session("ZipCodeZone") & ", strVote01 = '" & cbVote01.SelectedValue & "', dtmStampVote = '" & Now & "' WHERE strEmail = '" & Session("userEMAIL") & "'"
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            Response.Redirect("Portal.aspx")
        End If

    End Sub
End Class