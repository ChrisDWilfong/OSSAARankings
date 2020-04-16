Public Class WHMainMenu
    Inherits System.Web.UI.Page

    Public objDashboard As clsDashboard

    Private Sub WHMainMenu_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Session("user") = "" Then
            Response.Redirect("LoginWH.aspx")
        End If

    End Sub

    Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click
        Dim strReturn As String = "FAILED"

        objDashboard = New clsDashboard("PLAYOFFAVAILSUB", "Football", clsFunctions.GetCurrentYear)

        strReturn = ValidWhiteHatPlayoffs()

        If strReturn = "OK" Then
            If Session("override") = True Then
                Response.Redirect(objDashboard.gHomePage)
            Else
                If Now >= objDashboard.gStartDate And Now <= objDashboard.gEndDate Then
                    Response.Redirect(objDashboard.gHomePage)
                ElseIf Now < objDashboard.gReadyDate Then
                    Me.lblMessage.Text = "Playoff Availability will be available " & objDashboard.gReadyDate.ToLongDateString & " @ " & objDashboard.gReadyTime
                Else
                    Me.lblMessage.Text = "This option is now closed."
                End If
            End If
        Else
            lblMessage.Text = strReturn
            'Me.lblMessage.Text = "You are not a valid White Hat OR you DO NOT have a Crew Test submitted OR we do NOT have record of your HEAT certificate."
        End If

    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Dim strReturn As String = "FAILED"

        objDashboard = New clsDashboard("PLAYOFFREPORT", "Football", clsFunctions.GetCurrentYear)

        strReturn = ValidWhiteHat()

        If strReturn = "OK" Then
            If Session("override") = True Then
                Response.Redirect(objDashboard.gHomePage)
            Else
                If Now >= objDashboard.gStartDate And Now <= objDashboard.gEndDate Then
                    Response.Redirect(objDashboard.gHomePage)
                ElseIf Now < objDashboard.gReadyDate Then
                    Me.lblMessage.Text = "Game Report entry will be available " & objDashboard.gReadyDate.ToLongDateString & " @ " & objDashboard.gReadyTime
                Else
                    Me.lblMessage.Text = "This option is now closed."
                End If
            End If
        Else
            Me.lblMessage.Text = "You are not a valid White Hat OR you DO NOT have a Crew Test submitted OR we do NOT have record of your HEAT certificate."
        End If

    End Sub

    Public Function ValidWhiteHat() As String
        Dim intWH As Integer
        Dim strReturn As String = "OK"
        Dim strSQL As String = "SELECT ysnWhiteHat FROM prodOfficials WHERE intOSSAAID = " & Session("OSSAAID")

        Try
            intWH = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
        Catch ex As Exception
            intWH = 0
        End Try

        If intWH <> 0 Then
            strReturn = "OK"
        Else
            strReturn = "FAILED"
        End If

        Return strReturn

    End Function

    Public Function ValidWhiteHatPlayoffs() As String
        Dim strResult As String = "OK"
        Dim intHeat As Integer = 0
        Dim intConcussion As Integer = 0
        Dim strSQL As String = "SELECT intCrewTest FROM prodOfficials WHERE intOSSAAID = " & Session("OSSAAID")

        Try
            Session("CrewTest") = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            If Session("CrewTest") > 0 Then
                strResult = "OK"
            Else
                strResult = "FAILED (No CREW TEST)"
            End If
        Catch ex As Exception
            Session("CrewTest") = 0
            strResult = "FAILED (No CREW TEST)"
        End Try

        If strResult = "OK" Then
            strSQL = "SELECT ysnHeat FROM prodOfficials WHERE intOSSAAID = " & Session("OSSAAID")
            intHeat = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            If intHeat = 0 Then
                strResult = "FAILED (No HEAT Cert)"
            Else
                strResult = "OK"
            End If
        End If

        If strResult = "OK" Then
            strSQL = "SELECT ysnConcussion FROM prodOfficials WHERE intOSSAAID = " & Session("OSSAAID")
            intConcussion = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            If intConcussion = 0 Then
                strResult = "FAILED (No CONCUSSION Cert)"
            Else
                strResult = "OK"
            End If
        End If

        Return strResult

    End Function

End Class