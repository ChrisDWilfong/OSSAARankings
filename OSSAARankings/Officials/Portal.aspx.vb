Public Class Portal
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            If Not Request.Cookies("OfficialsSettings") Is Nothing Then
                Dim myCookie As HttpCookie = Request.Cookies("OfficialsSettings")
                txtFirstName.Text = myCookie.Values("FirstName")
                Session("userFIRSTNAME") = txtFirstName.Text
                txtLastName.Text = myCookie.Values("LastName")
                Session("userLASTNAME") = txtLastName.Text
                txtEmail.Text = myCookie.Values("Email")
                Session("userEMAIL") = txtEmail.Text
                txtOSSAAID.Text = myCookie.Values("OSSAAID")
                Session("userOSSAAID") = txtOSSAAID.Text
                Try
                    txtZipCode.Text = clsOfficials.GetZipCode(txtEmail.Text, 0, CType(myCookie.Values("ZipCode"), String))
                Catch
                    txtZipCode.Text = ""
                End Try
                Session("ZipCodeZone") = clsOfficials.GetZipCodeZone(txtZipCode.Text)
                lblZipCodeZone.Text = Session("ZipCodeZone")

                cboState.SelectedValue = myCookie.Values("State")
                Session("userRES") = myCookie.Values("State")

                ' Let's verify...
                Dim ds As DataSet
                Dim strSQL As String
                strSQL = "SELECT TOP 1 * FROM prodOfficials WHERE strEmail = '" & Session("userEMAIL") & "'"
                ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

                If ds Is Nothing Then
                    Session("CanVote") = "No"
                ElseIf ds.Tables.Count = 0 Then
                    Session("CanVote") = "No"
                ElseIf ds.Tables(0).Rows.Count = 0 Then
                    Session("CanVote") = "No"
                Else
                    If ds.Tables(0).Rows(0).Item("intZone") IsNot System.DBNull.Value Then
                        Session("CanVote") = "Done"
                    ElseIf ds.Tables(0).Rows(0).item("intOSSAAID") <= 0 Then
                        Session("CanVote") = "No"
                    Else
                        Session("CanVote") = "Yes"
                    End If
                End If

                'If Session("CanVote") = "Done" Then
                '    cmdVote.Text = "Voting complete"
                '    cmdVote.Enabled = False
                'End If

                'cboState.Enabled = False
                clsOfficials.LogRegistration("Home", "Load Cookies", Session("doRegSport"), Request.UserHostAddress, Request.UserAgent, Session("userOSSAAID"), Session("userEMAIL"), Session("userRES"), Session("userZIPCODE"), Session("doRegistration"), Session("regStatus"))
            End If
        End If

        ' Make sure they UNDERSTAND...
        If cbVerify.Checked Then
            cmdOfficialsInfo.Enabled = True
            cmdRegister.Enabled = True
        Else
            cmdOfficialsInfo.Enabled = False
            cmdRegister.Enabled = False
        End If

    End Sub

    Private Sub cmdOfficialsInfo_Click(sender As Object, e As EventArgs) Handles cmdOfficialsInfo.Click
        Dim strReturn As String = "OK"

        strReturn = VerifyInfo(True)

        If strReturn = "OK" Then
            ' Register Cookie...
            Dim myCookie As HttpCookie = New HttpCookie("OfficialsSettings")
            myCookie.Values("FirstName") = Session("userFIRSTNAME")
            myCookie.Values("LastName") = Session("userLASTNAME")
            myCookie.Values("Email") = Session("userEMAIL")
            myCookie.Values("OSSAAID") = Session("userOSSAAID")
            myCookie.Values("ZipCode") = clsOfficials.GetZipCode(myCookie.Values("Email"), 0, Session("userZIPCODE"))
            myCookie.Values("State") = cboState.SelectedValue
            myCookie.Expires = DateTime.Now.AddDays(300)
            Response.Cookies.Add(myCookie)
            Session("userRES") = cboState.SelectedValue
            Session("userREG") = ""
            clsOfficials.LogRegistration("Info", "to PortalInfo.aspx", Session("doRegSport"), Request.UserHostAddress, Request.UserAgent, Session("userOSSAAID"), Session("userEMAIL"), Session("userRES"), Session("userZIPCODE"), Session("doRegistration"), Session("regStatus"))
            ' Go to page...
            Response.Redirect("PortalInfo.aspx")
        Else
            lblMessage.Text = strReturn
        End If
    End Sub

    Private Sub cmdRegister_Click(sender As Object, e As EventArgs) Handles cmdRegister.Click
        Dim strReturn As String = "OK"

        strReturn = VerifyInfo(False)

        If strReturn = "OK" Then
            ' Register Cookie...
            Dim myCookie As HttpCookie = New HttpCookie("OfficialsSettings")
            myCookie("FirstName") = Session("userFIRSTNAME")
            myCookie("LastName") = Session("userLASTNAME")
            myCookie("Email") = Session("userEMAIL")
            myCookie("OSSAAID") = Session("userOSSAAID")
            myCookie("ZipCode") = Session("userZIPCODE")
            myCookie("State") = cboState.SelectedValue
            myCookie.Expires = DateTime.Now.AddDays(300)
            Response.Cookies.Add(myCookie)
            Session("userRES") = cboState.SelectedValue
            Session("userREG") = ""
            ' Go to page...
            clsOfficials.LogRegistration("Registration", "to Registration1.aspx", Session("doRegSport"), Request.UserHostAddress, Request.UserAgent, Session("userOSSAAID"), Session("userEMAIL"), Session("userRES"), Session("userZIPCODE"), Session("doRegistration"), Session("regStatus"))
            Response.Redirect("Registration1.aspx")
        Else
            lblMessage.Text = strReturn
        End If

    End Sub

    Private Sub cboState_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboState.SelectedIndexChanged
        Session("userRES") = cboState.SelectedValue
    End Sub

    Private Sub cmdArbiterHome_Click(sender As Object, e As EventArgs) Handles cmdArbiterHome.Click
        clsOfficials.LogRegistration("Arbiter", "Home", Session("doRegSport"), Request.UserHostAddress, Request.UserAgent, Session("userOSSAAID"), Session("userEMAIL"), Session("userRES"), Session("userZIPCODE"), Session("doRegistration"), Session("regStatus"))
        Response.Redirect("https://ossaa.arbitersports.com/front/106940/Site")
    End Sub

    Private Sub cmdVote_Click(sender As Object, e As EventArgs) Handles cmdVote.Click

        Dim strReturn As String = "OK"

        ' Shut down the voting...
        If Now > "2019-12-18 16:00" And Now < "2020-01-15 16:00" Then
        Else
            lblMessage.Text = "Voting is closed."
            Exit Sub
        End If

        strReturn = VerifyInfo(True)

        If strReturn = "OK" Then
            Session("userREG") = ""
            Session("userFIRSTNAME") = txtFirstName.Text
            Session("userLASTNAME") = txtLastName.Text
            Session("userEMAIL") = clsFunctions.StringValidate(Me.txtEmail.Text)
            Session("userSTATE") = cboState.SelectedValue
            If txtOSSAAID.Text = "" Or txtOSSAAID Is Nothing Then
                Session("userOSSAAID") = 0
            Else
                Session("userOSSAAID") = txtOSSAAID.Text
            End If
            Session("ZipCodeZone") = clsOfficials.GetZipCodeZone(txtZipCode.Text)
            lblZipCodeZone.Text = Session("ZipCodeZone")

            clsOfficials.LogRegistration("Arbiter", "VOTEJerseys", Session("doRegSport"), Request.UserHostAddress, Request.UserAgent, Session("userOSSAAID"), Session("userEMAIL"), Session("userRES"), Session("userZIPCODE"), Session("doRegistration"), Session("regStatus"))
            Response.Redirect("PortalPoll_Jerseys.aspx")
        Else
            lblMessage.Text = strReturn
        End If
    End Sub

    Public Function VerifyInfo(verifyWithOSSAAID As Boolean) As String
        Dim strReturn As String = "OK"

        If txtFirstName.Text = "" Then
            strReturn = "Enter a FIRST Name."
            clsOfficials.LogRegistration("Registration", strReturn, Session("doRegSport"), Request.UserHostAddress, Request.UserAgent, Session("userOSSAAID"), Session("userEMAIL"), Session("userRES"), Session("userZIPCODE"), Session("doRegistration"), Session("regStatus"))
        ElseIf txtLastName.Text = "" Then
            strReturn = "Enter a LAST Name."
            clsOfficials.LogRegistration("Registration", strReturn, Session("doRegSport"), Request.UserHostAddress, Request.UserAgent, Session("userOSSAAID"), Session("userEMAIL"), Session("userRES"), Session("userZIPCODE"), Session("doRegistration"), Session("regStatus"))
        ElseIf txtEmail.Text = "" Then
            strReturn = "Enter an EMAIL ADDRESS."
            clsOfficials.LogRegistration("Registration", strReturn, Session("doRegSport"), Request.UserHostAddress, Request.UserAgent, Session("userOSSAAID"), Session("userEMAIL"), Session("userRES"), Session("userZIPCODE"), Session("doRegistration"), Session("regStatus"))
        ElseIf txtZipCode.Text = "" Then
            strReturn = "Enter a ZIP CODE."
            clsOfficials.LogRegistration("Registration", strReturn, Session("doRegSport"), Request.UserHostAddress, Request.UserAgent, Session("userOSSAAID"), Session("userEMAIL"), Session("userRES"), Session("userZIPCODE"), Session("doRegistration"), Session("regStatus"))
        ElseIf cboState.SelectedValue = "Select..." Or cboState.SelectedValue = "" Then
            strReturn = "Select a RESIDENCE STATE."
            clsOfficials.LogRegistration("Registration", strReturn, Session("doRegSport"), Request.UserHostAddress, Request.UserAgent, Session("userOSSAAID"), Session("userEMAIL"), Session("userRES"), Session("userZIPCODE"), Session("doRegistration"), Session("regStatus"))
        ElseIf txtOSSAAID.Text.Contains("-") Or txtOSSAAID.Text = "" Or txtOSSAAID Is Nothing Then
            strReturn = "This is an invalid OSSAA ID#.  Enter 0 if you do not have one yet."
            clsOfficials.LogRegistration("Registration", strReturn, Session("doRegSport"), Request.UserHostAddress, Request.UserAgent, Session("userOSSAAID"), Session("userEMAIL"), Session("userRES"), Session("userZIPCODE"), Session("doRegistration"), Session("regStatus"))
        Else

            Session("userREG") = ""
            Session("userFIRSTNAME") = txtFirstName.Text
            Session("userLASTNAME") = txtLastName.Text
            Session("userEMAIL") = clsFunctions.StringValidate(Me.txtEmail.Text)
            Session("userSTATE") = cboState.SelectedValue
            If txtOSSAAID.Text = "" Or txtOSSAAID Is Nothing Then
                Session("userOSSAAID") = 0
                txtOSSAAID.Text = "0"
            Else
                Session("userOSSAAID") = txtOSSAAID.Text
            End If

            ' Let's verify...
            Dim ds As DataSet
            Dim strSQL As String
            strSQL = "SELECT * FROM prodOfficials WHERE strEmail = '" & Session("userEMAIL") & "' AND intOSSAAID > 0"
            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

            If ds Is Nothing Then
                Session("ds") = Nothing
                If Session("regStatus") = "" Then
                    Session("regStatus") = clsOfficials.GetRegistrationStatus(Session("userOSSAAID"), Session("userEMAIL"), True)
                End If
                clsOfficials.LogRegistration("Registration", "VerifyInfo(31)", Session("doRegSport"), Request.UserHostAddress, Request.UserAgent, Session("userOSSAAID"), Session("userEMAIL"), Session("userRES"), Session("userZIPCODE"), Session("doRegistration"), Session("regStatus"))

            ElseIf ds.Tables.Count = 0 Then
                Session("ds") = Nothing
                If Session("regStatus") = "" Then
                    Session("regStatus") = clsOfficials.GetRegistrationStatus(Session("userOSSAAID"), Session("userEMAIL"), True)
                End If
                clsOfficials.LogRegistration("Registration", "VerifyInfo(32)", Session("doRegSport"), Request.UserHostAddress, Request.UserAgent, Session("userOSSAAID"), Session("userEMAIL"), Session("userRES"), Session("userZIPCODE"), Session("doRegistration"), Session("regStatus"))

            ElseIf ds.Tables(0).Rows.Count = 0 Then
                Session("ds") = Nothing
                If Session("regStatus") = "" Then
                    Session("regStatus") = clsOfficials.GetRegistrationStatus(Session("userOSSAAID"), Session("userEMAIL"), True)
                End If
                clsOfficials.LogRegistration("Registration", "VerifyInfo(33)", Session("doRegSport"), Request.UserHostAddress, Request.UserAgent, Session("userOSSAAID"), Session("userEMAIL"), Session("userRES"), Session("userZIPCODE"), Session("doRegistration"), Session("regStatus"))

            Else
                ' Only CAPTURE the dataset if we are supposed to VerifyWithOSSAAID (View Officials Info) AND there is an OSSAAID match OR NOT VerifyWithOSSAAID...
                If (verifyWithOSSAAID And (Session("userOSSAAID") = ds.Tables(0).Rows(0).Item("intOSSAAID"))) Or verifyWithOSSAAID = False Then
                    Session("ds") = ds

                    ' Get the OSSAAID from the Email???
                    Dim intOSSAAID As Long = 0
                    Try
                        intOSSAAID = ds.Tables(0).Rows(0).Item("intOSSAAID")
                    Catch
                        intOSSAAID = 0
                    End Try
                    If intOSSAAID > 0 Then
                        Session("userOSSAAID") = intOSSAAID
                        Dim myCookie As HttpCookie = New HttpCookie("OfficialsSettings")
                        myCookie("OSSAAID") = Session("userOSSAAID")
                    End If

                    Session("regStatus") = clsOfficials.GetRegistrationStatus(Session("userOSSAAID"), Session("userEMAIL"))
                    If Session("regStatus") = "" Then
                        clsOfficials.SetRegistrationStatus(Session("userOSSAAID"), Session("userEMAIL"), "START")
                        Session("regStatus") = "START"
                    End If
                    clsOfficials.LogRegistration("Registration", "VerifyInfo(0)", Session("doRegSport"), Request.UserHostAddress, Request.UserAgent, Session("userOSSAAID"), Session("userEMAIL"), Session("userRES"), Session("userZIPCODE"), Session("doRegistration"), Session("regStatus"))
                Else
                    clsOfficials.LogRegistration("Registration", "VerifyInfo(1)", Session("doRegSport"), Request.UserHostAddress, Request.UserAgent, Session("userOSSAAID"), Session("userEMAIL"), Session("userRES"), Session("userZIPCODE"), Session("doRegistration"), Session("regStatus"))
                End If
            End If

        End If

        Return strReturn

    End Function

End Class