Public Class LoginWRPref
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Now >= ConfigurationManager.AppSettings("WrestlingPrefsDateStart") And Now <= ConfigurationManager.AppSettings("WrestlingPrefsDateEnd") Then
            Session("canLoginWR") = True
        End If

        If Not IsPostBack Then
            If Now >= ConfigurationManager.AppSettings("WrestlingPrefsDateStart") And Now <= ConfigurationManager.AppSettings("WrestlingPrefsDateEnd") Then
                DoLogin2()
            Else
                lblMessage.Text = "Closed."
            End If
        End If

    End Sub

    Public Sub DoLogin2()
        Dim strInvalidCodeMessage As String
        Dim strInvalidCodeMessage1 As String
        Dim ds As DataSet
        Dim dsd As DataSet
        Dim strSQL As String

        Dim intMemberID As Long = 0
        Dim strEmail As String = ""
        Dim strSport As String = ""
        Dim strLoginCode As String = ""

        If Request.QueryString("l") = "ossaacoach" Or Request.QueryString("l") = "ossaastaff" Then
            ' Continue...
            Try
                strLoginCode = Request.QueryString("l")
                intMemberID = Request.QueryString("sid")           ' For coaches : MemberID, for A/D : tblSchool.ID...
                strEmail = Request.QueryString("id")
                Session("userEmail") = strEmail
                'Session("userName") = clsMembers.GetUserName(strEmail, "Wrestling")
                Session("userMemberID") = intMemberID
                strSport = Request.QueryString("g")
                intMemberID -= 1234

            Catch ex As Exception
                intMemberID = -1
                strEmail = ""
            End Try

            Session("prefMemberID") = intMemberID
            Session("prefEmail") = strEmail
            Session("prefSport") = strSport
            Session("prefGender") = ""

        ElseIf Request.QueryString("l") = "ossaaad" Then
            Try
                strLoginCode = Request.QueryString("l")
                intMemberID = Request.QueryString("sid")           ' For coaches : MemberID, for A/D : tblSchool.ID...
                strEmail = Request.QueryString("id")
                Session("userEmail") = strEmail
                'Session("userName") = clsMembers.GetUserName(strEmail, "Wrestling")
                Session("userMemberID") = intMemberID
                strSport = ""
                intMemberID -= 1234

            Catch ex As Exception
                intMemberID = -1
                strEmail = ""
            End Try
        Else
            lblMessage.Text = "This site is currently unavailable.  Please check back soon..."
            Exit Sub
        End If

        strInvalidCodeMessage = "Invalid code."
        strInvalidCodeMessage1 = "Your team is not in the Playoffs."

        If strEmail = "" Then
            Me.lblMessage.Text = "Invalid access (2)."
        ElseIf InStr(strEmail, "@") <= 0 Or InStr(strEmail, ".") <= 0 Then
            lblMessage.Text = "Invalid access (3)."
        Else

            ' GET USER INFORMATION ...
            If strLoginCode = "ossaaad" Then
                strSQL = "SELECT * FROM tblSchool WHERE AdminADEmail = '" & strEmail & "'"
                ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)
            Else
                strSQL = "SELECT * FROM allCoachesDetail WHERE memberID = " & intMemberID & " AND sportID Like '" & strSport & "%' AND intYear = " & clsFunctions.GetCurrentYear
                ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)
            End If


            If ds Is Nothing Then
            ElseIf ds.Tables.Count = 0 Then
            ElseIf ds.Tables(0).Rows.Count = 0 Then
            Else

                If strLoginCode = "ossaaad" Then
                    With ds.Tables(0).Rows(0)
                        Session("prefSchoolID") = .Item("schoolID")
                        Session("prefCoachName") = .Item("AdminADFirst") & " " & .Item("AdminADLast")
                        Session("prefSchoolName") = .Item("SchoolName")
                        Session("prefUser") = strEmail
                        Session("prefClass") = clsFunctions.GetClassFromADForBasketball(Session("prefSchoolID"))
                    End With
                Else
                    With ds.Tables(0).Rows(0)
                        Session("prefSchoolID") = .Item("schoolID")
                        Session("prefCoachName") = .Item("FirstName") & " " & .Item("LastName")
                        Session("prefSchoolName") = .Item("SchoolName")
                        Session("prefUser") = strEmail
                        Session("prefClass") = .Item("Class")
                    End With
                End If

                'strSQL = "SELECT * FROM allCoachesDetail WHERE SchoolID = " & Session("prefSchoolID")
                strSQL = "SELECT * FROM allCoachesDetail WHERE emailMain = '" & strEmail & "' AND intYear = " & clsFunctions.GetCurrentYear & " AND sportID Like 'Wrestling%'"
            End If

            dsd = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

            If dsd Is Nothing Then
                lblMessage.Text = strInvalidCodeMessage1
            ElseIf dsd.Tables.Count = 0 Then
                lblMessage.Text = strInvalidCodeMessage1
            ElseIf dsd.Tables(0).Rows.Count = 0 Then
                lblMessage.Text = strInvalidCodeMessage1
            Else

                Dim strMessageEmail As String = "OK"
                'strMessageEmail = VerifyEmailToSchool(Session("prefSchoolID"), strEmail)

                If strMessageEmail = "OK" Then
                    Session("userEmail") = dsd.Tables(0).Rows(0).Item("emailMain")

                    ' Set User Info...
                    Session("userName") = dsd.Tables(0).Rows(0).Item("FirstName") & " " & dsd.Tables(0).Rows(0).Item("LastName")
                    Session("userSchoolID") = dsd.Tables(0).Rows(0).Item("schoolID")
                    Session("userSchoolName") = dsd.Tables(0).Rows(0).Item("schoolName")

                    If strLoginCode = "ossaacoach" Then
                        Session("userPosition") = "Head Coach"
                    Else
                        Session("userPosition") = "Administrator"
                    End If
                    Response.Redirect("PrefEntryWR.aspx?l=" & Request.QueryString("l"))

                Else
                    lblMessage.Text = strMessageEmail
                    Me.txtUsername.Visible = False
                    Me.cboGender.Visible = False
                    Me.cboSchools.Visible = False
                    Me.lblGender.Visible = False
                    Me.lblEmail.Visible = False
                    Me.lblSchool.Visible = False
                    cmdLogin.Visible = False
                    lblLoginType.Visible = False
                End If
            End If
        End If

    End Sub

    Public Function VerifyEmailToSchool(schoolID As Long, strEmail As String) As String
        ' Added 2/17/2014...
        Dim strReturn As String = ""
        Dim strSQL As String = ""
        Dim intTeamID As Long = 0

        strSQL = "SELECT teamID FROM allCoachesDetail WHERE schoolID = " & schoolID & " AND EmailMain = '" & strEmail & "' AND sportID Like 'Wrestling%'"
        Try
            intTeamID = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, strSQL)
        Catch
            intTeamID = 0
        End Try

        If intTeamID > 0 Then
            strReturn = "OK"
        Else
            strSQL = "SELECT schoolID FROM tblSchool WHERE schoolID = " & schoolID & " AND (AdminSuperEmail = '" & strEmail & "' OR AdminPrincipalEmail = '" & strEmail & "' OR AdminADEmail = '" & strEmail & "')"
            Try
                intTeamID = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, strSQL)
            Catch
                intTeamID = 0
            End Try
            If intTeamID > 0 Then
                strReturn = "OK"
            Else
                strReturn = "Invalid email address for selected school."
            End If
        End If

        Return strReturn
    End Function

End Class