Public Class ucPersonalInfo
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            If Session("memgMemberID") Is Nothing Then
            Else
                LoadData(Session("memgMemberID"))
            End If
        End If

    End Sub

    Private Sub cmdSave_Click(sender As Object, e As System.EventArgs) Handles cmdSave.Click
        If Me.txtPassword.Text.ToUpper = "PASSWORD" Then
            lblMessage.Text = "Your password can not be 'password'.  Please change it."
        Else
            SaveChanges(Session("memgMemberID"))
        End If
    End Sub

    Public Sub LoadData(memberID As Long)

        Dim objMember As New clsMember(memberID, False)
        txtFirstName.Text = objMember.gFirstName
        txtLastName.Text = objMember.gLastName
        txtEmailMain.Text = objMember.gEmailMain
        txtEmailAlt.Text = objMember.gEmailAlt
        txtPhoneMain.Text = objMember.gPhoneMain
        txtPhoneAlt.Text = objMember.gPhoneAlt
        txtPassword.Text = objMember.gPassword
    End Sub

    Public Sub SaveChanges(memberID As Long)

        Dim strVerify As String = VerifyData()
        Dim strSQL As String

        If strVerify = "OK" Then
            strSQL = "UPDATE tblMembers SET "
            strSQL = strSQL & "FirstName = '" & Me.txtFirstName.Text & "', "
            strSQL = strSQL & "LastName = '" & Me.txtLastName.Text & "', "
            strSQL = strSQL & "Username = '" & Me.txtEmailMain.Text & "', "
            strSQL = strSQL & "emailMain = '" & Me.txtEmailMain.Text & "', "
            strSQL = strSQL & "emailAlt = '" & Me.txtEmailAlt.Text & "', "
            strSQL = strSQL & "phoneMain = '" & Me.txtPhoneMain.Text & "', "
            strSQL = strSQL & "phoneAlt = '" & Me.txtPhoneAlt.Text & "', "
            strSQL = strSQL & "password = '" & Me.txtPassword.Text & "'"
            strSQL = strSQL & "WHERE memberID = " & memberID
            Session("memgPassword") = Me.txtPassword.Text.ToUpper
            SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, strSQL)
            Me.lblMessage.Text = "Changes have been saved."
        Else
            Me.lblMessage.Text = strVerify
        End If

    End Sub

    Public Function VerifyData() As String
        Dim strResult As String = "OK"

        If Me.txtFirstName.Text = "" Then
            strResult = "You must enter your First Name."
        ElseIf Me.txtLastName.Text = "" Then
            strResult = "You must enter your Last Name."
        ElseIf Me.txtEmailMain.Text = "" Then
            strResult = "You must enter your Email (Main)."
        ElseIf Me.txtPhoneMain.Text = "" Then
            strResult = "You must enter your Phone (Cell)."
        ElseIf Me.txtPassword.Text = "" Then
            strResult = "You must enter your Password."
        ElseIf clsMembers.IsDuplicateEmail(Session("memgMemberID"), Me.txtEmailMain.Text) Then
            strResult = "Duplicate email.  Save cancelled."
        Else
            strResult = "OK"
        End If

        Return strResult
    End Function

    Private Sub Page_PreRender(sender As Object, e As System.EventArgs) Handles Me.PreRender
        LoadData(Session("memgMemberID"))
    End Sub

    Private Sub cmdChangePassword_Click(sender As Object, e As System.EventArgs) Handles cmdChangePassword.Click
        Session("memgSchool") = ""
        Response.Redirect("LoginChange.aspx")
    End Sub
End Class