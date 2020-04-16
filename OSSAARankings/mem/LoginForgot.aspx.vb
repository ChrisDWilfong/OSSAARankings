Public Class LoginForgot
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            ' Load schools list...
            cboSchools.DataSource = clsSchools.GetSchoolsDS
            cboSchools.DataBind()
            Dim objItem As New System.Web.UI.WebControls.ListItem
            objItem.Value = 0
            objItem.Text = "Select..."
            cboSchools.Items.Insert(0, objItem)
        End If

        If Request.UserAgent.Contains("android") Or Request.UserAgent.Contains("iphone") Or Request.UserAgent.Contains("blackberry") Or Request.UserAgent.Contains("mobile") Or Request.UserAgent.Contains("palm") Then
        Else
        End If

    End Sub

    Private Sub cmdSubmit_Click(sender As Object, e As System.EventArgs) Handles cmdSubmit.Click
        Dim strValidate As String

        strValidate = ValidateExisting

        If strValidate = "OK" Then
            strValidate = ""
            strValidate = clsEmail.GetForgotLoginEmailContent(SqlHelper.StripString(txtEmail.Text), cboSchools.SelectedValue, cboPositions.SelectedValue, "", SqlHelper.StripString(txtName.Text), cboSchools.SelectedItem.Text, True)
            If strValidate.Contains("FAILED") Then
                clsLog.LogUser(SqlHelper.StripString(txtEmail.Text), cboPositions.SelectedValue, 0, "FORGOT-LOGIN-FAILED", cboSchools.SelectedItem.ToString, Request.UserAgent)
                lblMessage.Text = "Your email was NOT sent.  Either the information you entered is incorrect OR your Athletic Director has NOT entered your information as a coach."
            Else
                clsLog.LogUser(SqlHelper.StripString(txtEmail.Text), cboPositions.SelectedValue, 0, "FORGOT-LOGIN", cboSchools.SelectedItem.ToString, Request.UserAgent)
                ' CDW changed 3/6/2019...
                '''''clsEmail.SendEmail(Me, strValidate, txtEmail.Text, "cwilfong@ossaa.com", "Login Information Request from OSSAARankings.com Site")
                clsEmail.SendEmailNew(clsFunctions.StringValidate(txtEmail.Text), "", "Login Information Request from OSSAARankings.com Site", strValidate, False, "OSSAA Membership Email")
                lblMessage.Text = "Your password will be sent to you via your email address. <a href='Login.aspx'>Click here to go to Login page</a>"
            End If
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

    Private Sub cboSchools_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboSchools.SelectedIndexChanged
        ' Re-Load the Positions...
        cboPositions.DataSource = clsSports.GetSportsForSchoolDS(cboSchools.SelectedValue, clsFunctions.GetCurrentYear)
        cboPositions.DataBind()
        Dim objItem As New System.Web.UI.WebControls.ListItem
        Dim objItem1 As New System.Web.UI.WebControls.ListItem
        objItem.Value = 0
        objItem.Text = "Select..."
        objItem1.Value = 99999
        objItem1.Text = "Athletic Director"
        cboPositions.Items.Insert(0, objItem1)
        cboPositions.Items.Insert(0, objItem)
    End Sub
End Class