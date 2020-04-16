Public Class LoginBBPref
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim strPrefClass As String = clsOfficials.GetPrefClassBasketball

        If strPrefClass = "AB" Then
            If Now >= ConfigurationManager.AppSettings("BasketballPrefsDateStartAB") And Now <= ConfigurationManager.AppSettings("BasketballPrefsDateEndAB") Then
                Session("canLoginAB") = True
            Else
                Session("canLoginAB") = False
            End If
        Else
            Session("canLoginAB") = False
        End If

        If strPrefClass = "4A2A" Then
            If Now >= ConfigurationManager.AppSettings("BasketballPrefsDateStart4A2A") And Now <= ConfigurationManager.AppSettings("BasketballPrefsDateEnd4A2A") Then
                Session("canLogin4A2A") = True
            Else
                Session("canLogin4A2A") = False
            End If
        Else
            Session("canLogin4A2A") = False
        End If

        If strPrefClass = "6A5A" Then
            If Now >= ConfigurationManager.AppSettings("BasketballPrefsDateStart6A5A") And Now <= ConfigurationManager.AppSettings("BasketballPrefsDateEnd6A5A") Then
                Session("canLogin6A5A") = True
            Else
                Session("canLogin6A5A") = False
            End If
        Else
            Session("canLogin6A5A") = False
        End If

        If Not IsPostBack Then
            DoLogin2()
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
                strSport = Request.QueryString("g")
                intMemberID -= 1234

            Catch ex As Exception
                intMemberID = -1
                strEmail = ""
            End Try

            Session("prefMemberID") = intMemberID
            Session("prefEmail") = strEmail
            Session("prefSport") = strSport
            If strSport.Contains("Boys") Then
                Session("prefGender") = "Boys"
            ElseIf strSport.Contains("Girls") Then
                Session("prefGender") = "Girls"
            Else
                Session("prefGender") = ""
            End If
        ElseIf Request.QueryString("l") = "ossaaad" Then
            Try
                strLoginCode = Request.QueryString("l")
                intMemberID = Request.QueryString("sid")           ' For coaches : MemberID, for A/D : tblSchool.ID...
                strEmail = Request.QueryString("id")
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
                ds = SqlHelper.ExecuteDataset(SQLHelper.SQLConnection, CommandType.Text, strSQL)
            Else
                strSQL = "SELECT * FROM allCoachesDetail WHERE memberID = " & intMemberID & " AND sportID Like '" & strSport & "%' AND intYear = " & clsFunctions.GetCurrentYear
                ds = SqlHelper.ExecuteDataset(SQLHelper.SQLConnection, CommandType.Text, strSQL)
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

                ' Now lets get the district for this login and verify they are a playoff team..
                If clsOfficials.GetPrefClassBasketball = "6A5A" And (Session("prefClass") = "5A" Or Session("prefClass") = "6A") Then            ' TODO : FIX THIS FOR 6A/5A...
                    strSQL = "SELECT * FROM viewDistrictBBListOfTeams WHERE SchoolID = " & Session("prefSchoolID") & " AND strGender = '" & Session("prefGender") & "'"
                Else
                    strSQL = "SELECT * FROM viewDistrictBBListOfTeams WHERE SchoolID = " & Session("prefSchoolID")
                End If
            End If
            dsd = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

            If dsd Is Nothing Then
                lblMessage.Text = strInvalidCodeMessage1
            ElseIf dsd.Tables.Count = 0 Then
                lblMessage.Text = strInvalidCodeMessage1
            ElseIf dsd.Tables(0).Rows.Count = 0 Then
                lblMessage.Text = strInvalidCodeMessage1
            Else

                If ConfigurationManager.AppSettings("RedirectToPrefListAB") = "1" And (Session("prefClass") = "A" Or Session("prefClass") = "B") Then
                    Session("userEmail") = strEmail
                    Response.Redirect("BBPrefsALL.aspx")
                ElseIf ConfigurationManager.AppSettings("RedirectToPrefList4A2A") = "1" And (Session("prefClass") = "4A" Or Session("prefClass") = "3A" Or Session("prefClass") = "2A") Then
                    Session("userEmail") = strEmail
                    Response.Redirect("BBPrefsALL.aspx")
                ElseIf ConfigurationManager.AppSettings("RedirectToPrefList6A5A") = "1" And (Session("prefClass") = "6A" Or Session("prefClass") = "5A") Then
                    Session("userEmail") = strEmail
                    Response.Redirect("BBPrefsALL.aspx")
                Else
                    If ((Session("prefClass") = "A" Or Session("prefClass") = "B") And Session("canLoginAB")) _
                    Or ((Session("prefClass") = "4A" Or Session("prefClass") = "3A" Or Session("prefClass") = "2A") And Session("canLogin4A2A")) _
                    Or ((Session("prefClass") = "6A" Or Session("prefClass") = "5A") And Session("canLogin6A5A")) Then
                        'If 1 = 1 Then
                        Dim strMessageEmail As String = "OK"
                        strMessageEmail = VerifyEmailToSchool(Session("prefSchoolID"), strEmail)

                        If strMessageEmail = "OK" Then
                            Session("userEmail") = Me.txtUsername.Text
                            ' Set District Info...
                            Session("DistrictYear") = dsd.Tables(0).Rows(0).Item("intYear")
                            Session("DistrictGender") = Session("prefGender")
                            Session("DistrictClass") = dsd.Tables(0).Rows(0).Item("strClass")
                            Session("DistrictArea") = dsd.Tables(0).Rows(0).Item("strArea")
                            Session("DistrictDistrict") = dsd.Tables(0).Rows(0).Item("intDistrict")
                            Session("DistrictKey") = dsd.Tables(0).Rows(0).Item("intDistrictKey")
                            Session("DistrictSchool") = dsd.Tables(0).Rows(0).Item("strSchool")
                            Session("DistrictRow") = dsd.Tables(0).Rows(0).Item("RowNo")
                            Session("DistrictHostSchool") = dsd.Tables(0).Rows(0).Item("strDistrictHostSchool")
                            Session("DistrictHostZip") = dsd.Tables(0).Rows(0).Item("strDistrictZip")
                            Session("DistrictDistance") = dsd.Tables(0).Rows(0).Item("intDefaultMiles")
                            Session("DistrictHostSchoolID") = dsd.Tables(0).Rows(0).Item("intDistrictHostprodSchoolID")

                            ' Set User Info...
                            Session("userName") = Session("prefCoachName")
                            Session("userSchoolID") = Session("prefSchoolID")
                            Session("userSchoolName") = Session("prefSchoolName")
                            If strLoginCode = "ossaacoach" Then
                                Session("userPosition") = "Head Coach"
                            Else
                                Session("userPosition") = "Administrator"
                            End If

                            ' Log to tblLogDistrictPrefsBB...
                            strSQL = "INSERT INTO tblLogDistrictPrefsBB (intYear, strClass, strArea, strGender, intDistrict, intDistrictKey, strDistrictHostSchool, strEmail, strFullName, strSchool, intSchoolID, strPosition) VALUES ("
                            strSQL = strSQL & Session("DistrictYear") & ", "
                            strSQL = strSQL & "'" & Session("DistrictClass") & "', "
                            strSQL = strSQL & "'" & Session("DistrictArea") & "', "
                            strSQL = strSQL & "'" & Session("DistrictGender") & "', "
                            strSQL = strSQL & Session("DistrictDistrict") & ", "
                            strSQL = strSQL & Session("DistrictKey") & ", "
                            strSQL = strSQL & "'" & Session("DistrictHostSchool") & "', "
                            strSQL = strSQL & "'" & Session("userEmail") & "', "
                            strSQL = strSQL & "'" & Session("userName") & "', "
                            strSQL = strSQL & "'" & Session("userSchoolName") & "', "
                            strSQL = strSQL & "'" & Session("userSchoolID") & "', "
                            strSQL = strSQL & "'" & Session("userPosition") & "')"
                            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

                            If Session("prefClass") = "3A" Or Session("prefClass") = "4A" Then
                                Response.Redirect("PrefEntry4A3A.aspx")
                            ElseIf Session("prefClass") = "6A" Or Session("prefClass") = "5A" Then
                                Response.Redirect("PrefEntry6A5A.aspx")
                            Else
                                Response.Redirect("PrefEntry.aspx")
                            End If

                        Else
                            lblMessage.Text = strMessageEmail
                        End If
                    Else
                        lblMessage.Text = "Currently unavailable."
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
        End If

    End Sub

    Public Function VerifyEmailToSchool(schoolID As Long, strEmail As String) As String
        ' Added 2/17/2014...
        Dim strReturn As String = ""
        Dim strSQL As String = ""
        Dim intTeamID As Long = 0

        strSQL = "SELECT teamID FROM allCoachesDetail WHERE schoolID = " & schoolID & " AND EmailMain = '" & strEmail & "' AND sportID Like 'Basketball%'"
        Try
            intTeamID = SqlHelper.ExecuteScalar(SQLHelper.SQLConnection, CommandType.Text, strSQL)
        Catch
            intTeamID = 0
        End Try

        If intTeamID > 0 Then
            strReturn = "OK"
        Else
            strSQL = "SELECT schoolID FROM tblSchool WHERE schoolID = " & schoolID & " AND (AdminSuperEmail = '" & strEmail & "' OR AdminPrincipalEmail = '" & strEmail & "' OR AdminADEmail = '" & strEmail & "')"
            Try
                intTeamID = SqlHelper.ExecuteScalar(SQLHelper.SQLConnection, CommandType.Text, strSQL)
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