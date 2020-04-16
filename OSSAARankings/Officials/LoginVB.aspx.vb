Public Class LoginVB
    Inherits System.Web.UI.Page
    Public objDashboard As clsDashboard

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'If (Now >= ConfigurationManager.AppSettings("VBOfficialsAvailabilityDateStart") And Now <= ConfigurationManager.AppSettings("VBOfficialsAvailabilityDateEnd")) Then
        '    cmdLogin.Enabled = True
        'ElseIf Now >= ConfigurationManager.AppSettings("VBOfficialsAvailabilityDateEnd") Then
        '    'cmdLogin.Enabled = False
        '    lblMessage.Text = "Site is now closed."
        'Else
        '    cmdLogin.Enabled = False
        '    Me.lblMessage.Text = "Login will be available from " & ConfigurationManager.AppSettings("VBOfficialsAvailabilityDateStartShow")
        'End If

        objDashboard = New clsDashboard("PLAYOFFAVAIL", "Volleyball", clsFunctions.GetCurrentYear)

        If objDashboard.gLoginPage Is Nothing Then
            lblMessage.Text = "This site is currently closed.  It will be open from " & Format(objDashboard.gStartDate, "Long Date") & " through " & Format(objDashboard.gEndDate, "Long Date")
        ElseIf Now >= objDashboard.gStartDate And Now <= objDashboard.gEndDate Then
        Else
            lblMessage.Text = "This site is currently closed.  It will be open from " & Format(objDashboard.gStartDate, "Long Date") & " through " & Format(objDashboard.gEndDate, "Long Date")
        End If

        lblHeader.Text = objDashboard.gLoginHeader

    End Sub

    Protected Sub cmdLogin_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLogin.Click
        Dim strInvalidCodeMessage As String = ""
        Dim strUserName As String = ""

        strInvalidCodeMessage = "Invalid email.  You are not identified as qualifying to enter Playoff Availability in our system (OSSAA enrolled official and passed Part 1 Test).  Please email Sheree Riddell (sriddell@ossaa.com) or call 405.840.1116"
        Session("override") = False


        If InStr(txtUsername.Text, "sheree") > 0 Then           ' Backdoor...

        Else
            If Now >= objDashboard.gStartDate And Now <= objDashboard.gEndDate Then
            Else
                Me.lblMessage.Text = "This site is currently closed.  It will be open from " & Format(objDashboard.gStartDate, "Long Date") & " through " & Format(objDashboard.gEndDate, "Long Date")
                Exit Sub
            End If
        End If

        If txtUsername.Text = "ossaastaff" Then
            Session("user") = txtUsername.Text
        Else
            strUserName = Me.txtUsername.Text

            If InStr(strUserName, "sheree") > 0 Then
                Session("override") = True
                strUserName = strUserName.Replace("sheree", "")
            Else
                Session("override") = False
            End If

            ' Let's look up the code and see if it is valid...
            Dim intID As Integer = 0
            Dim strSQL As String = "SELECT TOP 1 id FROM " & objDashboard.gViewEligible & " WHERE strEmail = '" & strUserName & "'"
            intID = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            If intID > 0 Then
                Dim ds As DataSet
                strSQL = "SELECT * FROM prodOfficials WHERE Id = " & intID
                ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
                If ds Is Nothing Then
                    lblMessage.Text = strInvalidCodeMessage
                ElseIf ds.Tables.Count = 0 Then
                    lblMessage.Text = strInvalidCodeMessage
                ElseIf ds.Tables(0).Rows.Count = 0 Then
                    lblMessage.Text = strInvalidCodeMessage
                Else
                    ' Found it, move on...
                    With ds.Tables(0).Rows(0)
                        Session("OSSAAID") = .Item("intOSSAAID")
                        Session("Id") = intID
                        Session("OfficialName") = .Item("strFirstName") & " " & .Item("strLastName")
                        Session("user") = strUserName
                        Session("useremail") = strUserName
                    End With
                    Response.Redirect(objDashboard.gHomePage)
                End If
            Else
                lblMessage.Text = strInvalidCodeMessage
            End If

        End If
    End Sub
End Class