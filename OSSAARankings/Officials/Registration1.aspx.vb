Public Class Registration1
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

		If Session("userEMAIL") Is Nothing Then
			Response.Redirect("Portal.aspx")
		ElseIf Session("userEMAIL") = "" Then
			Response.Redirect("Portal.aspx")
		End If

		If Session("regStatus") = "RETURNING" Or Session("regStatus") = "START-RETURNING" Or Session("regStatus") = "COMPLETE-RETURNING" Then
			Session("doRegistration") = "RETURNING-MEMBER"
			ShowRegistrationThisOK(False)
			ShowRegistrationThisOOS(False)
			ShowSports(True)
			clsOfficials.LogRegistration("Registration", "Registration1 Load1", Session("doRegSport"), Request.UserHostAddress, Request.UserAgent, Session("userOSSAAID"), Session("userEMAIL"), Session("userRES"), Session("userZIPCODE"), Session("doRegistration"), Session("regStatus"))
		ElseIf Session("regStatus") = "NEW" Or Session("regStatus") = "START-NEW" Or Session("regStatus") = "COMPLETE-NEW" Then
			Session("doRegistration") = "NEW-MEMBER"
			ShowRegistrationThisOK(False)
			ShowRegistrationThisOOS(False)
			ShowSports(True)
			clsOfficials.LogRegistration("Registration", "Registration1 Load2", Session("doRegSport"), Request.UserHostAddress, Request.UserAgent, Session("userOSSAAID"), Session("userEMAIL"), Session("userRES"), Session("userZIPCODE"), Session("doRegistration"), Session("regStatus"))
		ElseIf Session("regStatus") = "OOS" Or Session("regStatus") = "START-OOS" Or Session("regStatus") = "COMPLETE-OOS" Then
			Session("doRegistration") = "OUT-OF-STATE"
			ShowRegistrationThisOK(False)
			ShowRegistrationThisOOS(False)
			ShowSports(True)
			clsOfficials.LogRegistration("Registration", "Registration1 Load3", Session("doRegSport"), Request.UserHostAddress, Request.UserAgent, Session("userOSSAAID"), Session("userEMAIL"), Session("userRES"), Session("userZIPCODE"), Session("doRegistration"), Session("regStatus"))
		ElseIf Session("userRES") = "OK" Then
			ShowRegistrationThisOK(True)
			ShowRegistrationThisOOS(False)
			clsOfficials.LogRegistration("Registration", "Registration1 Load4", Session("doRegSport"), Request.UserHostAddress, Request.UserAgent, Session("userOSSAAID"), Session("userEMAIL"), Session("userRES"), Session("userZIPCODE"), Session("doRegistration"), Session("regStatus"))
		Else
			ShowRegistrationThisOK(False)
			ShowRegistrationThisOOS(True)
			cbRegisteredThisSeasonOOS.Items(0).Text = "YES, I have registered this season (in " & Session("userRES") & ")"
			cbRegisteredThisSeasonOOS.Items(1).Text = "YES, I have registered this season (in OKLAHOMA)"
			cbRegisteredThisSeasonOOS.Items(2).Text = "NO, I have NOT registered this season"
			clsOfficials.LogRegistration("Registration", "Registration1 Load5", Session("doRegSport"), Request.UserHostAddress, Request.UserAgent, Session("userOSSAAID"), Session("userEMAIL"), Session("userRES"), Session("userZIPCODE"), Session("doRegistration"), Session("regStatus"))
		End If

	End Sub

	Public Sub ShowRegistrationThisOK(ysnShow As Boolean)
		rowRegistrationThis.Visible = ysnShow
		rowRegistrationThisOK.Visible = ysnShow
	End Sub

	Public Sub ShowRegistrationThisOOS(ysnShow As Boolean)
		rowRegistrationThisOOS.Visible = ysnShow
	End Sub

	Public Sub ShowRegistrationEver(ysnShow As Boolean)
		rowRegistrationEver.Visible = ysnShow
		rowRegistrationEver1.Visible = ysnShow
	End Sub

	Public Sub ShowSports(ysnShow As Boolean)
		rowSports1.Visible = ysnShow
		rowSports2.Visible = ysnShow
	End Sub

	Public Sub WhereToGo(strREG As String, strRES As String, strSport As String)
		Session("doRegSport") = strSport
		clsOfficials.LogRegistration("Registration", "SelectSport", Session("doRegSport"), Request.UserHostAddress, Request.UserAgent, Session("userOSSAAID"), Session("userEMAIL"), Session("userRES"), Session("userZIPCODE"), Session("doRegistration"), Session("regStatus"))
		cmdRegister.Text = "I COMPLETED MY REGISTRATION for " & clsRegistration.GetSportFromAbb(Session("doRegSport"))
		cmdRegister1.Text = "I WILL COMPLETE THIS REGISTRATION for " & clsRegistration.GetSportFromAbb(Session("doRegSport")) & " LATER"
		cmdRegister.Visible = True
		cmdRegister1.Visible = True
		Response.Write("<script>")
		Response.Write("window.open('" & clsOfficials.GetRegistrationURL(Session("doRegistration"), Session("doRegSport")) & "','_blank')")
		Response.Write("</script>")
		'Response.Redirect(clsRegistration.GetRegistrationURL(Session("doRegistration"), Session("doRegSport")))
		'Response.Redirect("RegistrationA.aspx")     ' Replaced 1/14/2019...
	End Sub

	Private Sub cmdBaseball_Click(sender As Object, e As EventArgs) Handles cmdBaseball.Click
		WhereToGo(Session("userREG"), Session("userRES"), "BA")
	End Sub

	Private Sub cmdBasketball_Click(sender As Object, e As EventArgs) Handles cmdBasketball.Click
		WhereToGo(Session("userREG"), Session("userRES"), "BK")
	End Sub

	Private Sub cmdFootball_Click(sender As Object, e As EventArgs) Handles cmdFootball.Click
		WhereToGo(Session("userREG"), Session("userRES"), "FB")
	End Sub

	Private Sub cmdSoccer_Click(sender As Object, e As EventArgs) Handles cmdSoccer.Click
		WhereToGo(Session("userREG"), Session("userRES"), "SC")
	End Sub

	Private Sub cmdTrack_Click(sender As Object, e As EventArgs) Handles cmdTrack.Click
		WhereToGo(Session("userREG"), Session("userRES"), "TK")
	End Sub

	Private Sub cmdFastPitch_Click(sender As Object, e As EventArgs) Handles cmdFastPitch.Click
		WhereToGo(Session("userREG"), Session("userRES"), "FP")
	End Sub

	Private Sub cmdSlowPitch_Click(sender As Object, e As EventArgs) Handles cmdSlowPitch.Click
		WhereToGo(Session("userREG"), Session("userRES"), "SP")
	End Sub

	Private Sub cmdVolleyball_Click(sender As Object, e As EventArgs) Handles cmdVolleyball.Click
		WhereToGo(Session("userREG"), Session("userRES"), "VB")
	End Sub

	Private Sub cmdWrestling_Click(sender As Object, e As EventArgs) Handles cmdWrestling.Click
		WhereToGo(Session("userREG"), Session("userRES"), "WR")
	End Sub

	Private Sub cmdHome_Click(sender As Object, e As EventArgs) Handles cmdHome.Click
		Session("doRegSport") = "NONE"
		Session("userREG") = "NONE"
		Session("userRES") = "NONE"
		Session("doRegistration") = "UNKNOWN"
		Response.Redirect("Portal.aspx")
	End Sub

	Private Sub cbRegisteredThisSeasonOK_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbRegisteredThisSeasonOK.SelectedIndexChanged

		lblMessage.Text = ""

		If cbRegisteredThisSeasonOK.SelectedValue = "Y" Then
			Session("userREG") = "YES"
			If Session("regStatus") = "" Or Session("regStatus") = "START" Then
				clsOfficials.SetRegistrationStatus(Session("userOSSAAID"), Session("userEMAIL"), "START-RETURNING")
			End If
			Session("regStatus") = "START-RETURNING"
			Session("doRegistration") = "RETURNING-MEMBER"
			ShowRegistrationEver(False)
			ShowSports(True)
			lblSportHeader.Text = "&nbsp;REGISTER FOR AN ADDITIONAL SPORT"
			clsOfficials.LogRegistration("Registration", "RegisteredThisSeasonOK = Y", Session("doRegSport"), Request.UserHostAddress, Request.UserAgent, Session("userOSSAAID"), Session("userEMAIL"), Session("userRES"), Session("userZIPCODE"), Session("doRegistration"), Session("regStatus"))
		Else
			Session("userREG") = "NO"
			Session("doRegistration") = "UNKNOWN"
			ShowRegistrationEver(True)
			ShowSports(False)
			clsOfficials.LogRegistration("Registration", "RegisteredThisSeasonOK <> Y", Session("doRegSport"), Request.UserHostAddress, Request.UserAgent, Session("userOSSAAID"), Session("userEMAIL"), Session("userRES"), Session("userZIPCODE"), Session("doRegistration"), Session("regStatus"))
		End If

	End Sub

	Private Sub cbRegisteredThisSeasonOOS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbRegisteredThisSeasonOOS.SelectedIndexChanged
		' Y : an OOS Residence who has already registered in Oklahoma...
		' OOS : an OOS Residence who has already registered in his/her state...
		' N : and OOS Residence who has not registered and wants to in Oklahoma...

		lblMessage.Text = ""

		If cbRegisteredThisSeasonOOS.SelectedValue = "OOS" Then
			Session("userREG") = "OOS"
			If Session("regStatus") = "" Or Session("regStatus") = "START" Then
				clsOfficials.SetRegistrationStatus(Session("userOSSAAID"), Session("userEMAIL"), "START-OOS")
			End If
			Session("doRegistration") = "OUT-OF-STATE"
			ShowRegistrationEver(False)
			ShowSports(True)
			lblSportHeader.Text = "&nbsp;REGISTER FOR AN ADDITIONAL SPORT"
			clsOfficials.LogRegistration("Registration", "RegisteredThisSeasonOOS = OOS", Session("doRegSport"), Request.UserHostAddress, Request.UserAgent, Session("userOSSAAID"), Session("userEMAIL"), Session("userRES"), Session("userZIPCODE"), Session("doRegistration"), Session("regStatus"))
		ElseIf cbRegisteredThisSeasonOOS.SelectedValue = "Y" Then
			Session("userREG") = "YES"
			If Session("regStatus") = "" Or Session("regStatus") = "START" Then
				clsOfficials.SetRegistrationStatus(Session("userOSSAAID"), Session("userEMAIL"), "START-RETURNING")
			End If
			Session("regStatus") = "START-RETURNING"
			Session("doRegistration") = "RETURNING-MEMBER"
			ShowRegistrationEver(False)
			ShowSports(True)
			lblSportHeader.Text = "&nbsp;REGISTER FOR AN ADDITIONAL SPORT"
			clsOfficials.LogRegistration("Registration", "RegisteredThisSeasonOOS = Y", Session("doRegSport"), Request.UserHostAddress, Request.UserAgent, Session("userOSSAAID"), Session("userEMAIL"), Session("userRES"), Session("userZIPCODE"), Session("doRegistration"), Session("regStatus"))
		ElseIf cbRegisteredThisSeasonOOS.SelectedValue = "N" Then
			Session("userREG") = "NO"
			Session("doRegistration") = "UNKNOWN"
			ShowRegistrationEver(True)
			ShowSports(False)
			lblSportHeader.Text = "&nbsp;REGISTER IN OKLAHOMA"
			clsOfficials.LogRegistration("Registration", "RegisteredThisSeasonOOS = N", Session("doRegSport"), Request.UserHostAddress, Request.UserAgent, Session("userOSSAAID"), Session("userEMAIL"), Session("userRES"), Session("userZIPCODE"), Session("doRegistration"), Session("regStatus"))
		End If

	End Sub

	Private Sub cbRegisteredEver_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbRegisteredEver.SelectedIndexChanged

		lblMessage.Text = ""

		If cbRegisteredEver.SelectedValue = "Y" Then
			If Session("regStatus") = "" Or Session("regStatus") = "START" Or Session("regStatus") = "START-RETURNING" Then
				clsOfficials.SetRegistrationStatus(Session("userOSSAAID"), Session("userEMAIL"), "START-RETURNING")
			End If
			Session("regStatus") = "START-RETURNING"
			Session("doRegistration") = "RETURNING-MEMBER"
			ShowSports(True)
			clsOfficials.LogRegistration("Registration", "RegisteredEver = Y", Session("doRegSport"), Request.UserHostAddress, Request.UserAgent, Session("userOSSAAID"), Session("userEMAIL"), Session("userRES"), Session("userZIPCODE"), Session("doRegistration"), Session("regStatus"))
		ElseIf cbRegisteredEver.SelectedValue = "N" Then
			If Session("ds") Is Nothing Then
				If Session("regStatus") = "" Or Session("regStatus") = "START" Or Session("regStatus") = "START-NEW" Then
					clsOfficials.SetRegistrationStatus(Session("userOSSAAID"), Session("userEMAIL"), "START-NEW")
				End If
				Session("regStatus") = "START-NEW"
				Session("doRegistration") = "NEW-MEMBER"
				Session("userREG") = "NEW"
				ShowSports(True)
				lblSportHeader.Text = "&nbsp;REGISTER FOR SPORT"
				lblMessage.Text = ""
				clsOfficials.LogRegistration("Registration", "RegisteredEver = N;ds = Nothing", Session("doRegSport"), Request.UserHostAddress, Request.UserAgent, Session("userOSSAAID"), Session("userEMAIL"), Session("userRES"), Session("userZIPCODE"), Session("doRegistration"), Session("regStatus"))
			Else
				clsOfficials.LogRegistration("Registration", "RegisteredEver = N;ds <> Nothing", Session("doRegSport"), Request.UserHostAddress, Request.UserAgent, Session("userOSSAAID"), Session("userEMAIL"), Session("userRES"), Session("userZIPCODE"), Session("doRegistration"), Session("regStatus"))
				lblMessage.Text = "Your information has been found in our database that you HAVE registered in the past.  You cannot register as a new user, please contact Sheree @ 405.840.1116 for any questions."
			End If
		End If

	End Sub

	Private Sub cmdGoBack_Click(sender As Object, e As EventArgs) Handles cmdGoBack.Click
		Response.Redirect("Portal.aspx")
	End Sub

	Private Sub cmdRegister1_Click(sender As Object, e As EventArgs) Handles cmdRegister1.Click
		clsOfficials.LogRegistration("Registration", "Later", Session("doRegSport"), Request.UserHostAddress, Request.UserAgent, Session("userOSSAAID"), Session("userEMAIL"), Session("userRES"), Session("userZIPCODE"), Session("doRegistration"), Session("regStatus"))
		Response.Redirect("Portal.aspx")
	End Sub

	Private Sub cmdRegister_Click(sender As Object, e As EventArgs) Handles cmdRegister.Click
		clsOfficials.LogRegistration("Registration", "Complete", Session("doRegSport"), Request.UserHostAddress, Request.UserAgent, Session("userOSSAAID"), Session("userEMAIL"), Session("userRES"), Session("userZIPCODE"), Session("doRegistration"), Session("regStatus"))
		Response.Redirect("Portal.aspx")
	End Sub
End Class