Public Class RulesVerificationNew
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim strResultsIn As String = ""

        If Not IsPostBack Then
            ' Post the results passed in...
            strResultsIn = Request.QueryString("sp")
            If strResultsIn = "" Then strResultsIn = "Soccer"
            If strResultsIn = "" Then
                Response.Redirect("InvalidPage.aspx")
            Else

            End If
            Session("sportIn") = strResultsIn
            Me.lblHeader.Text = "Rules Confirmation Page for " & strResultsIn
        End If

    End Sub

    Public Function VerifyData() As String
        Dim strReturn As String = "OK"

        If txtOfficialID.Visible = True Then
            If txtOfficialID.Text = "" Then
                strReturn = "OSSAA ID# is required."
            End If
        End If

        If cboSchool.Visible = True Then
            If cboSchool.SelectedIndex <= 0 Then
                strReturn = "Please select as school."
            End If
        End If

        Return strReturn
    End Function

    Public Function SaveData() As String
        Dim strSQL As String = ""
        Dim strReturn As String = "OK"

        strReturn = VerifyData()

        If strReturn <> "OK" Then
            lblMessage.Text = strReturn
        Else
            Select Case rbType.SelectedValue
                Case "Coach"
                    strSQL = "INSERT INTO tblRulesResults (strType, strFirstName, strLastName, strSchool, strSport, strEmail, strKey) VALUES ("
                    strSQL = strSQL & "'Coach', '" & ParseString(txtFirstName.Text) & "', '" & ParseString(txtLastName.Text) & "', '" & cboSchool.SelectedValue & "', '" & cboSport.SelectedValue & "', '" & ParseString(txtEmail.Text) & "', '" & Session("sportIn") & "')"
                    SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAAOnline, System.Data.CommandType.Text, strSQL)
                    ProcessEmail(Me.cboSport.SelectedValue, "Coach")
                Case "Admin"
                    strSQL = "INSERT INTO tblRulesResults (strType, strFirstName, strLastName, strSchool, strSport, strEmail, strKey) VALUES ("
                    strSQL = strSQL & "'Admin', '" & ParseString(txtFirstName.Text) & "', '" & ParseString(txtLastName.Text) & "', '" & cboSchool.SelectedValue & "', '" & cboSport.SelectedValue & "', '" & ParseString(txtEmail.Text) & "', '" & Session("sportIn") & "')"
                    SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAAOnline, System.Data.CommandType.Text, strSQL)
                    ProcessEmail(Me.cboSport.SelectedValue, "Admin")
                Case "Judge"
                    strSQL = "INSERT INTO tblRulesResults (strType, strFirstName, strLastName, strSport, strEmail, strKey) VALUES ("
                    strSQL = strSQL & "'Judge', '" & ParseString(txtFirstName.Text) & "', '" & ParseString(txtLastName.Text) & "', '" & cboSport.SelectedValue & "', '" & ParseString(txtEmail.Text) & "', '" & Session("sportIn") & "')"
                    SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAAOnline, System.Data.CommandType.Text, strSQL)
                    ProcessEmail(Me.cboSport.SelectedValue, "Judge")
                Case "Official"
                    strSQL = "INSERT INTO tblRulesResults (strType, strFirstName, strLastName, strOSSAAIdNo, strSport, strEmail, strKey) VALUES ("
                    strSQL = strSQL & "'Official', '" & ParseString(txtFirstName.Text) & "', '" & ParseString(txtLastName.Text) & "', '" & ParseString(Me.txtOfficialID.Text) & "', '" & cboSport.SelectedValue & "', '" & ParseString(txtEmail.Text) & "', '" & Session("sportIn") & "')"
                    SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAAOnline, System.Data.CommandType.Text, strSQL)
                    ProcessEmail(Me.cboSport.SelectedValue, "Official")
                Case Else
                    strReturn = "FAILED"
            End Select
            lblMessage.Text = strSQL
        End If

        Return strReturn

    End Function

    Protected Sub cmdSubmitToOSSAA_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSubmitToOSSAA.Click

        If SaveData() = "OK" Then
            lblMessage.Text = "Your submission of the quiz is complete.<br>Please click NEXT below to continue..."
            Response.Redirect("CompleteNew.aspx")
        Else
            lblMessage.Text = "Please make the appropriate selections above."
        End If

    End Sub

    Protected Sub PostResults(ByVal strSport As String)

        Dim strKey As String = Now
        Dim strSQL As String
        strSQL = "INSERT INTO tblRulesResults (strPassedValueIn, strKey) VALUES ('" & strSport & "', '" & strKey & "')"
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAAOnline, System.Data.CommandType.Text, strSQL)

        strSQL = "SELECT Id FROM tblRulesResults WHERE strPassedValueIn = '" & strSport & "' AND strKey = '" & strKey & "'"
        Session("key") = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAAOnline, System.Data.CommandType.Text, strSQL)

    End Sub

    Public Sub ProcessEmail(ByVal strSport As String, ByVal strBy As String)
        Dim strContent As String = ""
        Dim strSubject As String = ""
        Dim strEmailTo1 As String = ""
        Dim strEmailTo2 As String = ""
        Dim strEmailFrom As String = "postmaster@ossaa.com"
        Dim strSportString As String = ""

        ' Email To...
        If strBy = "Coach" Or strBy = "Admin" Then
            Select Case strSport
                Case "VB", "Volleyball"
                    'strEmailTo1 = "mliebel@ossaa.com"
                    'strEmailTo1 = "tgoolsby@ossaa.com"
                    strEmailTo1 = "mjennings@ossaa.com"
                Case "AC", "Academic Bowl", "AcademicBowl"
                    strEmailTo1 = "bjohnson@ossaa.com"
                Case "FB", "Football"
                    strEmailTo1 = "mwoods@ossaa.com"
                Case "BB", "Baseball", "BBS", "Baseball (Spring)", "BS"
                    strEmailTo1 = "sriddell@ossaa.com"
                Case "CC", "Cross Country", "Cross Country (Both)", "Cross Country (Boys)", "Cross Country (Girls)"
                    'strEmailTo1 = "retheridge@ossaa.com"
                    strEmailTo1 = "mwoods@ossaa.com"
                Case "CH", "Cheer", "Cheerleading", "CHJ", "Cheerleading (Judge)"
                    strEmailTo1 = "bjohnson@ossaa.com"
                Case "SC", "Soccer", "Soccer (Boys Only)", "Soccer (Girls Only)", "Soccer (Both)"
                    'strEmailTo1 = "sriddell@ossaa.com"
                    'strEmailTo1 = "mliebel@ossaa.com"       ' 2/1/2016...
                    'strEmailTo1 = "tgoolsby@ossaa.com"
                    strEmailTo1 = "mjennings@ossaa.com"
                Case "SB", "Softball", "FP", "Softball (Fast Pitch)", "SBFP", "Fastpitch", "FastPitch"
                    strEmailTo1 = "bjohnson@ossaa.com"
                Case "SP", "Softball (Slow Pitch)", "SBSP", "Slowpitch"
                    'strEmailTo1 = "bjohnson@ossaa.com"
                    'strEmailTo1 = "acassell@ossaa.com"      ' 2/1/2016...
                    'strEmailTo1 = "mliebel@ossaa.com"       ' 2/23/2016...
                    'strEmailTo1 = "tgoolsby@ossaa.com"
                    strEmailTo1 = "mjennings@ossaa.com"
                Case "SW", "Swimming", "Swimming (Both)", "Swimming (Boys)", "Swimming (Girls)"
                    strEmailTo1 = "bjohnson@ossaa.com"
                Case "BK", "Basketball", "Basketball (Boys)", "Basketball (Girls)", "Basketball (Both)"
                    strEmailTo1 = "mwoods@ossaa.com"
                Case "WR", "Wrestling"
                    'strEmailTo1 = "mliebel@ossaa.com"
                    'strEmailTo1 = "tgoolsby@ossaa.com"
                    strEmailTo1 = "mjennings@ossaa.com"
                Case "GF", "Golf", "Golf (Both)", "Golf (Boys)", "Golf (Girls)"
                    strEmailTo1 = "bjohnson@ossaa.com"
                Case "TK", "TR", "Track", "Track (Both)", "Track (Girls Only)", "Track (Boys Only)"
                    strEmailTo1 = "mwoods@ossaa.com"
                Case "TN", "Tennis", "Tennis (Both)", "Tennis (Boys)", "Tennis (Girls)"
                    strEmailTo1 = "mwoods@ossaa.com"
                Case "Eligibility", "ELIGIBILITY"
                    strEmailTo1 = "acassell@ossaa.com"
                Case Else
                    strEmailTo1 = "cwilfong@ossaa.com"
            End Select
        ElseIf strBy = "Official" Then
            Select Case strSport
                Case "VB", "Volleyball"
                    strEmailTo1 = "sriddell@ossaa.com"
                Case "AC", "AcademicBowl", "Academic Bowl"
                    strEmailTo1 = "bjohnson@ossaa.com"
                Case "FB", "Football"
                    strEmailTo1 = "sriddell@ossaa.com"
                Case "BB", "Baseball", "BBS", "Baseball (Spring)", "BS"
                    strEmailTo1 = "sriddell@ossaa.com"
                Case "BK", "Basketball", "Basketball (Boys)", "Basketball (Girls)", "Basketball (Both)"
                    strEmailTo1 = "sriddell@ossaa.com"
                Case "CC", "Cross Country", "Cross Country (Both)", "Cross Country (Boys)", "Cross Country (Girls)"
                    strEmailTo1 = "mwoods@ossaa.com"
                Case "CH", "Cheer", "Cheerleading", "CHJ", "Cheerleading (Judge)"
                    strEmailTo1 = "sriddell@ossaa.com"
                Case "SB", "Softball"
                    strEmailTo1 = "sriddell@ossaa.com"
                Case "SW", "Swimming", "Swimming (Both)", "Swimming (Boys)", "Swimming (Girls)"
                    strEmailTo1 = "sriddell@ossaa.com"
                Case "SBSP", "Softball (Slow Pitch)", "SP", "Slowpitch"
                    strEmailTo1 = "sriddell@ossaa.com"
                Case "SBFP", "Softball (Fast Pitch)", "FP", "Fastpitch", "FastPitch"
                    strEmailTo1 = "sriddell@ossaa.com"
                Case "SC", "Soccer", "Soccer (Boys Only)", "Soccer (Girls Only)", "Soccer (Both)"
                    strEmailTo1 = "sriddell@ossaa.com"
                Case "WR", "Wrestling"
                    strEmailTo1 = "sriddell@ossaa.com"
                Case "SW", "Swimming", "Swimming (Both)", "Swimming (Boys)", "Swimming (Girls)"
                    strEmailTo1 = "sriddell@ossaa.com"
                Case "GF", "Golf", "Golf (Both)", "Golf (Boys)", "Golf (Girls)"
                    strEmailTo1 = "sriddell@ossaa.com"
                Case "TK", "TR", "Track", "Track (Both)", "Track (Girls Only)", "Track (Boys Only)"
                    strEmailTo1 = "sriddell@ossaa.com"
                Case "TN", "Tennis", "Tennis (Both)", "Tennis (Boys)", "Tennis (Girls)"
                    strEmailTo1 = "sriddell@ossaa.com"
                Case "Eligibility", "ELIGIBILITY"
                    strEmailTo1 = "acassell@ossaa.com"
                Case Else
                    strEmailTo1 = "cwilfong@ossaa.com"
            End Select
        ElseIf strBy = "Judge" Then
            Select Case strSport
                Case "AC", "Academic Bowl"
                    strEmailTo1 = "bjohnson@ossaa.com"
                Case "TK", "TR", "Track", "Track (Both)", "Track (Girls Only)", "Track (Boys Only)"
                    strEmailTo1 = "mwoods@ossaa.com"
                Case "CH", "Cheerleading", "Cheerleading (Judge)"
                    strEmailTo1 = "acassell@ossaa.com"
                Case "AC", "AcademicBowl", "Academic Bowl"
                    strEmailTo1 = "bjohnson@ossaa.com"
                Case "Eligibility", "ELIGIBILITY"
                    strEmailTo1 = "acassell@ossaa.com"
                Case Else
                    strEmailTo1 = "cwilfong@ossaa.com"
            End Select
        Else
            strEmailTo1 = "cwilfong@ossaa.com"
        End If

        strSportString = ReturnSportString(strSport)

        ' Subject...
        If strBy = "Coach" Then
            strSubject = "COACH " & strSport & " (" & Me.cboSchool.SelectedValue.ToString & ") On-Line Rules Completion (" & strSport & ")"
            strContent = "On-Line Rules Completed by " & Me.txtFirstName.Text & " " & Me.txtLastName.Text & " from " & Me.cboSchool.SelectedValue.ToString & " (" & Me.txtEmail.Text & ")<br>" & Session("key")
        ElseIf strBy = "Admin" Then
            strSubject = "ADMIN " & strSport & " (" & Me.cboSchool.SelectedValue.ToString & ") On-Line Rules Completion (" & strSport & ")"
            strContent = "On-Line Rules Completed by " & Me.txtFirstName.Text & " " & Me.txtLastName.Text & " from " & Me.cboSchool.SelectedValue.ToString & " (" & Me.txtEmail.Text & ")<br>" & Session("key")
        ElseIf strBy = "Judge" Then
            strSubject = "JUDGE " & strSport & " On-Line Rules Completion (" & strSport & ")"
            strContent = "On-Line Rules Completed by " & Me.txtFirstName.Text & " " & Me.txtLastName.Text & " (" & Me.txtEmail.Text & ")<br>" & Session("key")
        ElseIf strBy = "Official" Then
            strSubject = "OFFICIAL " & strSport & " On-Line Rules Completion (#" & Me.txtOfficialID.Text & ") (" & strSport & ")"
            strContent = "On-Line Rules Completed by " & Me.txtFirstName.Text & " " & Me.txtLastName.Text & " for " & strSportString & " (" & Me.txtEmail.Text & ")<br>" & Session("key")
        Else
            strSubject = "UNKNOWN " & strSport & " On-Line Rules Completion (" & strSport & ")"
            strContent = "UNKNOWN INFORMATION " & Session("key")
        End If

        ' Email to Associate...
        If strEmailTo1 = "" Then
        Else
            '''''clsEmail.SendEmail(Me, strContent, strEmailTo1, strEmailFrom, strSubject)
            clsEmail.SendEmailNew(strEmailTo1, "", strSubject, strContent, False, "")
        End If
        If strEmailTo2 = "" Then
        Else
            '''''clsEmail.SendEmail(Me, strContent, strEmailTo2, strEmailFrom, strSubject)
            clsEmail.SendEmailNew(strEmailTo2, "", strSubject, strContent, False, "")
        End If

        ' Send Confirmation Email...
        'strContent = "Thank you for taking the OSSAA On-Line State Rules Meeting (for " & strSportString & ").  Your confirmation has been received. <br><br>Here is your confirmation number :" & Session("key")
        strContent = "Thank you for taking the OSSAA On-Line State Rules Meeting (for " & strSportString & ").  Your confirmation has been received."
        strSubject = "OSSAA On-Line State Rules Meeting Confirmation"
        ' CDW changed 3/5/2019...
        '''''clsEmail.SendEmail(Me, strContent, Me.txtEmail.Text, strEmailFrom, strSubject)
        '''''clsEmail.SendEmail(Me, strContent, strEmailFrom, strEmailFrom, strSubject & " : " & Me.txtEmail.Text)
        clsEmail.SendEmailNew(clsFunctions.StringValidate(txtEmail.Text), "", strSubject, strContent, False, "")
        ' CDW removed 3/26/2019...
        'clsEmail.SendEmailNew("cwilfong@ossaa.com", "", (strSubject & " : " & Me.txtEmail.Text), strContent, False, "")

    End Sub


    Public Function ReturnSportString(ByVal strAbb As String) As String
        Dim strSport As String = ""

        Select Case strAbb
            Case "VB", "Volleyball"
                strSport = "Volleyball"
            Case "AC", "AcademicBowl", "Academic Bowl"
                strSport = "Academic Bowl"
            Case "FB", "Football"
                strSport = "Football"
            Case "BB", "BBS", "Baseball", "BS"
                strSport = "Baseball"
            Case "CC", "Cross Country"
                strSport = "Cross Country"
            Case "CH", "Cheerleading"
                strSport = "Cheerleading"
            Case "CHJ", "Cheerleading (Judge)"
                strSport = "Cheerleading (Judge)"
            Case "SB", "Softball"
                strSport = "Softball"
            Case "SBSP", "SP", "Slow Pitch", "SlowPitch", "Slowpitch"
                strSport = "Slow Pitch"
            Case "FP", "SBFP", "Fast Pitch", "FastPitch", "Fastpitch"
                strSport = "Fast Pitch"
            Case "BK", "Basketball"
                strSport = "Basketball"
            Case "WR", "Wrestling"
                strSport = "Wrestling"
            Case "SW", "Swimming"
                strSport = "Swimming"
            Case "GF", "Golf"
                strSport = "Golf"
            Case "TK", "Track"
                strSport = "Track"
            Case "TN", "Tennis"
                strSport = "Tennis"
            Case "SC", "Soccer"
                strSport = "Soccer"
            Case "Eligibility"
                strSport = "Eligibility"
            Case Else
                strSport = strAbb
        End Select

        Return strSport

    End Function

    Protected Sub rbType_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles rbType.SelectedIndexChanged
        If rbType.SelectedValue = "Coach" Or rbType.SelectedValue = "Admin" Then
            Me.lblSchool.Text = "School : "
            Me.lblSchool.Visible = True
            Me.cboSchool.Visible = True
            Me.txtOfficialID.Visible = False
        ElseIf rbType.SelectedValue = "Judge" Then
            Me.lblSchool.Visible = False
            Me.cboSchool.Visible = False
            Me.txtOfficialID.Visible = False
        Else
            Me.lblSchool.Text = "Official ID #:"
            Me.lblSchool.Visible = True
            Me.cboSchool.Visible = False
            Me.txtOfficialID.Visible = True
        End If
    End Sub

    Public Function ParseString(ByVal strIn As Object) As String
        Dim strTemp As String = ""

        Try
            strTemp = strIn
            strTemp = strTemp.Replace("'", "")
            strTemp = strTemp.Replace("""", "")
            strTemp = strTemp.Replace("DELETE", "")
            strTemp = strTemp.Replace("SELECT ", "")
            strTemp = strTemp.Replace("INSERT INTO ", "")
        Catch

        End Try

        Return strTemp
    End Function
End Class