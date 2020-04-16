Public Class MemberForgotLogin
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim ds As DataSet
            Dim strSQL As String

            ' SCHOOLS...
            strSQL = "SELECT Id, SchoolName FROM [tblSchool] ORDER BY [SchoolName]"
            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

            Me.cboSchools.DataTextField = "SchoolName"
            Me.cboSchools.DataValueField = "Id"
            Me.cboSchools.DataSource = ds
            Me.cboSchools.DataBind()
            Me.cboSchools.Items.Insert(0, "Select School...")

            Me.cboSchools1.DataTextField = "SchoolName"
            Me.cboSchools1.DataValueField = "Id"
            Me.cboSchools1.DataSource = ds
            Me.cboSchools1.DataBind()
            Me.cboSchools1.Items.Insert(0, "Select School...")
        End If

        If Not IsPostBack Then
            Me.lblCopyright.Text = clsMembership.GetCopyright
        End If

    End Sub

    Protected Sub cmdReturnToLogin_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdReturnToLogin.Click
        Response.Redirect("MemberLogin.aspx")
    End Sub

    Protected Sub cmdSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSubmit.Click
        Dim strValidate As String

        strValidate = ValidateExisting

        If strValidate = "OK" Then
            strValidate = ""
            strValidate = clsEmail.GetForgotLoginEmailContent(SqlHelper.StripString(txtEmail.Text), cboSchools.SelectedValue, 0, Me.cboPositions.SelectedValue, SqlHelper.StripString(txtName.Text), cboSchools.SelectedItem.Text, False)
            If strValidate.Contains("FAILED") Then
                SqlHelper.LogUser(SqlHelper.StripString(txtEmail.Text), Me.cboPositions.SelectedValue, 0, "FORGOT-LOGIN-FAILED", cboSchools.SelectedItem.ToString)
                lblMessage.Text = "Your email was NOT sent.  Your information is not located in our database."
            Else
                SqlHelper.LogUser(SqlHelper.StripString(txtEmail.Text), Me.cboPositions.SelectedValue, 0, "FORGOT-LOGIN", cboSchools.SelectedItem.ToString)
                ' CDW changed 3/5/2019...
                '''''clsEmail.SendEmail(Me, strValidate, txtEmail.Text, "postmaster@ossaa.com", "Login Information Request from OSSAA Membership Site")
                clsEmail.SendEmailNew(clsFunctions.StringValidate(txtEmail.Text), "", "Login Information Request from OSSAA Membership Site", strValidate, False, "OSSAA Membership Email")
                lblMessage.Text = "Your password will be sent to you via your email address."
                ' CDW changed 3/5/2019...
                '''''clsEmail.SendEmail(Me, strValidate, "postmaster@ossaa.com", "postmaster@ossaa.com", "Login Information Request from OSSAA Membership Site : " & txtEmail.Text)
                clsEmail.SendEmailNew("cwilfong@ossaa.com", "", "Login Information Request from OSSAA Membership Site : " & txtEmail.Text, strValidate, False, "OSSAA Membership Email")
            End If
        Else
            lblMessage.Text = strValidate
        End If
    End Sub

    Shared Sub SmtpClient_OnCompleted(ByVal sender As Object, ByVal e As ComponentModel.AsyncCompletedEventArgs)

    End Sub

    Protected Sub cmdSubmit1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSubmit1.Click
        Dim strResults As String
        Dim strValidate As String

        strValidate = ValidateExisting1()

        If strValidate = "OK" Then
            SqlHelper.LogUser(SqlHelper.StripString(txtEmail1.Text), Me.cboPositions1.SelectedValue, 0, "NEWRESQUEST", cboSchools1.SelectedItem.Text)
            strResults = "A new login has been requested by..." & vbCrLf & vbCrLf
            strResults = strResults & "Name : " & SqlHelper.StripString(txtName1.Text) & vbCrLf
            strResults = strResults & "School : " & cboSchools1.SelectedItem.Text & vbCrLf
            strResults = strResults & "Position : " & cboPositions1.SelectedItem.Text & vbCrLf
            strResults = strResults & "Phone : " & txtPhone.Text & vbCrLf
            strResults = strResults & "Email : " & SqlHelper.StripString(txtEmail1.Text) & vbCrLf & vbCrLf
            ' CDW changed 3/5/2019...
            '''''clsEmail.SendEmail(Me, strResults, "cwilfong@ossaa.com", "postmaster@ossaa.com", "New Membership Request for the OSSAA Membership Site")
            clsEmail.SendEmailNew("cwilfong@ossaa.com", "", "New Membership Request for the OSSAA Membership Site", strResults, False, "OSSAA Membership Email")
            lblMessage.Text = "Thank You.  Your login request has been sent to the OSSAA"
        Else
            lblMessage.Text = strValidate
        End If
    End Sub

    Public Function ValidateExisting() As String
        Dim strReturn As String

        If txtName.Text = "" Then
            strReturn = "You must enter your name."
        ElseIf cboPositions.SelectedIndex = 0 Then
            strReturn = "You must select a position."
        ElseIf cboSchools.SelectedIndex = 0 Then
            strReturn = "You must select a school."
        ElseIf txtEmail.Text = "" Then
            strReturn = "You must enter your email address."
        Else
            strReturn = "OK"
        End If

        Return strReturn
    End Function

    Public Function ValidateExisting1() As String
        Dim strReturn As String

        If txtName1.Text = "" Then
            strReturn = "You must enter your name."
        ElseIf cboPositions1.SelectedIndex = 0 Then
            strReturn = "You must select a position."
        ElseIf cboSchools1.SelectedIndex = 0 Then
            strReturn = "You must select a school."
        ElseIf txtEmail1.Text = "" Then
            strReturn = "You must enter your email address."
        ElseIf txtPhone.Text = "" Then
            strReturn = "You must enter your phone number."
        Else
            strReturn = "OK"
        End If

        Return strReturn
    End Function

    Private Sub cboPositions_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPositions.DataBound
        cboPositions.Items.Insert(0, "Select...")
    End Sub
End Class