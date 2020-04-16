Public Class ucPersonalInfoAD
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            If Session("madgMemberID") Is Nothing Then

            Else
                LoadData()
            End If
        End If

    End Sub

    Private Sub cmdSave_Click(sender As Object, e As System.EventArgs) Handles cmdSave.Click
        SaveChanges(Session("madgMemberID"))
    End Sub

    Public Sub LoadData()
        On Error Resume Next

        txtFirstName.Text = Session("madgFirstName")
        txtLastName.Text = Session("madgLastName")
        txtEmailMain.Text = Session("madgEmailMain")
        txtPhoneMain.Text = Session("madgPhoneMain")
        txtPhoneAlt.Text = Session("madgPhoneAlt")
        txtPassword.Text = Session("madgPassword")

    End Sub

    Public Sub SaveChanges(memberID As Long)
        Dim strVerify As String = VerifyData()
        Dim strSQL As String

        If strVerify = "OK" Then
            strSQL = "UPDATE tblSchool SET "
            strSQL = strSQL & "AdminADFirst = '" & SqlHelper.StripString(Me.txtFirstName.Text) & "', "
            Session("madgFirstName") = SqlHelper.StripString(Me.txtFirstName.Text)
            strSQL = strSQL & "AdminADLast = '" & SqlHelper.StripString(Me.txtLastName.Text) & "', "
            Session("madgLastName") = SqlHelper.StripString(Me.txtLastName.Text)
            strSQL = strSQL & "AdminADEmail = '" & SqlHelper.StripString(Me.txtEmailMain.Text) & "', "
            Session("madgEmailMain") = SqlHelper.StripString(Me.txtEmailMain.Text)
            strSQL = strSQL & "AdminADPhoneCell = '" & SqlHelper.StripString(Me.txtPhoneMain.Text) & "', "
            Session("madgPhoneMain") = SqlHelper.StripString(Me.txtPhoneMain.Text)
            strSQL = strSQL & "AdminADPhoneSchool = '" & SqlHelper.StripString(Me.txtPhoneAlt.Text) & "', "
            Session("madgPhoneAlt") = SqlHelper.StripString(Me.txtPhoneAlt.Text)
            strSQL = strSQL & "Password3 = '" & SqlHelper.StripString(Me.txtPassword.Text) & "' "
            Session("madgPassword") = SqlHelper.StripString(Me.txtPassword.Text)
            strSQL = strSQL & "WHERE Id = " & Session("madgMemberID")
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
            Me.lblMessage.Text = "Changes saved."
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
        Else
            strResult = "OK"
        End If

        Return strResult
    End Function

    Private Sub Page_PreRender(sender As Object, e As System.EventArgs) Handles Me.PreRender
        LoadData()
    End Sub
End Class