Public Class FBMainMenu
    Inherits System.Web.UI.Page

    Public intNumberOfWeeks As Integer = 6
    Public objDashboard As clsDashboard
    Public objDashboardScratch As clsDashboard
    Public objDashboardRating As clsDashboard

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        objDashboard = New clsDashboard("COACHES", "Football", clsFunctions.GetCurrentYear)
        objDashboardRating = New clsDashboard("COACHESRATING", "Football", clsFunctions.GetCurrentYear)
        objDashboardScratch = New clsDashboard("COACHESSCRATCH", "Football", clsFunctions.GetCurrentYear)

        lblNote.Text = "You have to have rated the first 6 weeks of the season.  This will be available " & objDashboardScratch.gStartDate.ToLongDateString & " @ " & objDashboardScratch.gStartTime
    End Sub

    Private Sub ImageButton1_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click

        Dim strReturn As String = "OK"

        If strReturn = "OK" Then
            If Session("override") = True Then
                Response.Redirect(objDashboardRating.gHomePage)
            Else
                If Now >= objDashboardRating.gStartDate And Now <= objDashboardRating.gEndDate Then
                    Response.Redirect(objDashboardRating.gHomePage)
                ElseIf Now < objDashboardRating.gReadyDate Then
                    Me.lblMessage.Text = "Coaches Ratings will be available " & objDashboardRating.gStartDate.ToLongDateString & " @ " & objDashboardRating.gStartTime
                Else
                    Me.lblMessage.Text = "This option is now closed."
                End If
            End If
        Else
            ' NOTHING...
        End If

    End Sub

    Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click
        ' SCRATCH LIST...

        Dim strReturn As String = ValidToScratch()

        If strReturn = "OK" Then
            If Session("override") = True Then
                Response.Redirect(objDashboardScratch.gHomePage)
            Else
                If Now >= objDashboardScratch.gStartDate And Now <= objDashboardScratch.gEndDate Then
                    Response.Redirect(objDashboardScratch.gHomePage)
                ElseIf Now < objDashboardScratch.gReadyDate Then
                    Me.lblMessage.Text = "Coaches Scratch List will be available " & objDashboardScratch.gStartDate.ToLongDateString & " @ " & objDashboardScratch.gStartTime
                Else
                    Me.lblMessage.Text = "This option is now closed."
                End If
            End If
        Else
            Me.lblMessage.Text = "You must have submitted ratings at least " & intNumberOfWeeks & " weeks this season to submit a scratch list."
        End If

    End Sub

    Public Function ValidToScratch() As String
        Dim strResult As String = "OK"
        Dim intCount As Integer = 0
        Dim intCountWeeks As Integer = 0

        Dim strSQL As String = "SELECT COUNT(Id) FROM tblOfficialsRatingByCoachesFB WHERE intSchoolID = " & Session("intSchoolID")
        Try
            intCountWeeks = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            strSQL = "SELECT intOverride FROM ossaauser.viewTeamsFootball WHERE TeamID = " & Session("TeamID")
            intCount = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, strSQL)

            If intCountWeeks >= (intNumberOfWeeks - intCount) Then
                strResult = "OK"
            Else
                strResult = "FAILED"
            End If
        Catch ex As Exception
            strResult = "FAILED"
        End Try

        Return strResult

    End Function


End Class