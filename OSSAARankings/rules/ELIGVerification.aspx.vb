Public Class ELIGVerification
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Request.QueryString("sp") = "Elig2016" Then
        ElseIf Request.QueryString("sp") = "Elig2017" Then
        ElseIf Request.QueryString("sp") = "Elig2018" Then
        ElseIf Request.QueryString("sp") = "Elig2019" Then
        Else
            Response.Redirect("InvalidPage.aspx")
        End If

    End Sub

    Public Function VerifyData() As String
        Dim strReturn As String = "OK"

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
            strSQL = "INSERT INTO tblRulesResults (strType, strFirstName, strLastName, strSchool, strSport, strEmail, strKey) VALUES ("
            strSQL = strSQL & "'ELIG', '" & ParseString(txtFirstName.Text) & "', '" & ParseString(txtLastName.Text) & "', '" & cboSchool.SelectedValue & "', '" & cboPosition.SelectedValue & "', '" & ParseString(txtEmail.Text) & "', 'Eligibility')"
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAAOnline, System.Data.CommandType.Text, strSQL)

            strSQL = "SELECT Id FROM tblRulesResults WHERE strType = 'ELIG' AND strEmail = '" & ParseString(txtEmail.Text) & "'"
            Session("key") = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAAOnline, System.Data.CommandType.Text, strSQL)
            ProcessEmail()
        End If

        Return strReturn

    End Function

    Protected Sub cmdSubmitToOSSAA_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSubmitToOSSAA.Click

        If SaveData() = "OK" Then
            lblMessage.Text = "Your submission is complete.<br>Please click NEXT below to continue..."
            Response.Redirect("CompleteElig.aspx")
        Else
            lblMessage.Text = "Please make the appropriate selections above."
        End If

    End Sub

    Public Sub ProcessEmail()
        Dim strContent As String = ""
        Dim strSubject As String = ""
        Dim strEmailTo1 As String = ""
        Dim strEmailTo2 As String = ""
        Dim strEmailFrom As String = "postmaster@ossaa.com"
        Dim strSportString As String = ""

        'strEmailTo1 = "cwilfong@ossaa.com"
        strEmailTo1 = "acassell@ossaa.com"

        strSubject = "ELIGIBILITY On-Line Meeting Completion (" & cboSchool.SelectedValue.ToString & ")"
        strContent = "ELIGIBILITY On-Line Meeting Completed by " & Me.txtFirstName.Text & " " & Me.txtLastName.Text & "(" & cboPosition.SelectedValue.ToString & ") (" & Me.txtEmail.Text & ")<br>KEY = " & Session("key")

        ' Email to Associate...
        If strEmailTo1 = "" Then
        Else
            ' CDW changed 3/5/3019...
            '''''clsEmail.SendEmail(Me, strContent, strEmailTo1, strEmailFrom, strSubject)
            clsEmail.SendEmailNew(strEmailTo1, "", strSubject, strContent, False, "")
        End If
        If strEmailTo2 = "" Then
        Else
            '''''clsEmail.SendEmail(Me, strContent, strEmailTo2, strEmailFrom, strSubject)
            clsEmail.SendEmailNew(strEmailTo2, "", strSubject, strContent, False, "")
        End If

        ' Send Confirmation Email...
        strContent = "Thank you for taking the OSSAA ELIGIBILITY On-Line Meeting Meeting.  Your confirmation has been received.<br>KEY = " & Session("key")
        strSubject = "OSSAA ELIGIBILITY On-Line Meeting Confirmation"
        ' CDW changed 3/5/3019...
        '''''clsEmail.SendEmail(Me, strContent, txtEmail.Text, strEmailFrom, strSubject)
        '''''clsEmail.SendEmail(Me, strContent, strEmailFrom, strEmailFrom, strSubject & " : " & Me.txtEmail.Text)
        clsEmail.SendEmailNew(clsFunctions.StringValidate(txtEmail.Text), "", strSubject, strContent, False, "")
        clsEmail.SendEmailNew("cwilfong@ossaa.com", "", (strSubject & " : " & Me.txtEmail.Text), strContent, False, "")
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