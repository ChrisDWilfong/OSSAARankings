Public Class ucPersonalInfoCoaches
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Request.QueryString("sel") = "CoachEdit" Or Request.QueryString("sel") = "CoachAdd" Then
            If Not IsPostBack Then
                If Request.QueryString("sel") = "CoachEdit" Then
                    If Session("madgCoachID") > 0 Then
                        LoadData(Session("madgCoachID"))
                    End If
                ElseIf Request.QueryString("sel") = "CoachAdd" Then
                    Session("madgCoachID") = 0
                    ClearFields()
                End If
            End If
        End If

    End Sub

    Private Sub cmdSave_Click(sender As Object, e As System.EventArgs) Handles cmdSave.Click

        SaveChanges(Session("madgCoachID"))

    End Sub

    Public Sub SendEmail()
        ' Send email to coach...
        Dim strContent As String
        Dim strSubject As String
        strSubject = "OSSAARankings.com Login Information (from your A/D)"
        strContent = "Your OSSAARankings.com login account has been setup by your Athletic Director." & vbCrLf & vbCrLf
        strContent = strContent & "Below is your login information :" & vbCrLf
        strContent = strContent & "Username : " & SqlHelper.StripString(txtEmailMain.Text) & vbCrLf
        If txtPassword.Text = "" Then
            strContent = strContent & "Password : password" & vbCrLf & vbCrLf
        Else
            strContent = strContent & "Password : " & txtPassword.Text & vbCrLf & vbCrLf
        End If
        strContent = strContent & "If your Password is 'password', you will be required to change it the first time you login to the site." & vbCrLf
        strContent = strContent & "Go to <a href='http://www.ossaarankings.com'>www.OSSAARankings.com</a> and once you get logged in, click 'Coaches' and 'Coaches Login'" & vbCrLf & vbCrLf
        strContent = strContent & "If you have an questions/problems logging in, contact us at : cwilfong@ossaa.com" & vbCrLf

        ' CDW changed 3/5/2019...
        '''''clsEmail.SendEmail(Me, strContent, SqlHelper.StripString(txtEmailMain.Text), "cwilfong@ossaa.com", strSubject)
        clsEmail.SendEmailNew(SqlHelper.StripString(txtEmailMain.Text), "", strSubject, strContent, False, "OSSAA Response Email")

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
        Dim strPassword As String = txtPassword.Text

        If strVerify = "OK" Then
            If strPassword = "" Then strPassword = "password"
            If Session("madgCoachID") = 0 Then
                strSQL = "INSERT INTO tblMembers (username, intYear, Role, schoolID, Title, FirstName, LastName, emailMain, emailAlt, phoneMain, phoneAlt, password) VALUES ("
                strSQL = strSQL & "'" & txtEmailMain.Text & "', "
                strSQL = strSQL & clsFunctions.GetCurrentYear & ", "
                strSQL = strSQL & "'Coach', "
                strSQL = strSQL & Session("madgSchoolID") & ", "
                strSQL = strSQL & "'Head Coach', "
                strSQL = strSQL & "'" & SqlHelper.StripString(txtFirstName.Text) & "', "
                strSQL = strSQL & "'" & SqlHelper.StripString(txtLastName.Text) & "', "
                strSQL = strSQL & "'" & SqlHelper.StripString(txtEmailMain.Text) & "', "
                strSQL = strSQL & "'" & SqlHelper.StripString(txtEmailAlt.Text) & "', "
                strSQL = strSQL & "'" & SqlHelper.StripString(txtPhoneMain.Text) & "', "
                strSQL = strSQL & "'" & SqlHelper.StripString(txtPhoneAlt.Text) & "', "
                strSQL = strSQL & "'" & SqlHelper.StripString(strPassword) & "')"
                SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, strSQL)
                SendEmail()
                Me.lblMessage.Text = "Changes have been saved."
            Else    ' This is an edit... 
                strSQL = "UPDATE tblMembers SET "
                strSQL = strSQL & "Username = '" & SqlHelper.StripString(Me.txtEmailMain.Text) & "', "
                strSQL = strSQL & "FirstName = '" & SqlHelper.StripString(Me.txtFirstName.Text) & "', "
                strSQL = strSQL & "LastName = '" & SqlHelper.StripString(Me.txtLastName.Text) & "', "
                strSQL = strSQL & "emailMain = '" & SqlHelper.StripString(Me.txtEmailMain.Text) & "', "
                strSQL = strSQL & "emailAlt = '" & SqlHelper.StripString(Me.txtEmailAlt.Text) & "', "
                strSQL = strSQL & "phoneMain = '" & SqlHelper.StripString(Me.txtPhoneMain.Text) & "', "
                strSQL = strSQL & "phoneAlt = '" & SqlHelper.StripString(Me.txtPhoneAlt.Text) & "', "
                strSQL = strSQL & "password = '" & SqlHelper.StripString(Me.txtPassword.Text) & "'"
                strSQL = strSQL & "WHERE memberID = " & memberID
                SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, strSQL)
                SendEmail()
                Me.lblMessage.Text = "Changes have been saved."
            End If
            ClearFields()
            Me.Visible = False
            Response.Redirect("adHome.aspx?sel=CoachesList")
        Else
            Me.lblMessage.Text = strVerify
        End If



    End Sub

    Public Sub ClearFields()
        Me.txtFirstName.Text = ""
        Me.txtLastName.Text = ""
        Me.txtEmailAlt.Text = ""
        Me.txtEmailMain.Text = ""
        Me.txtPhoneMain.Text = ""
        Me.txtPhoneAlt.Text = ""
        Me.txtPassword.Text = "password"
    End Sub

    Public Function VerifyData() As String
        Dim strResult As String = "OK"

        If Me.txtFirstName.Text = "" Then
            strResult = "You must enter your First Name."
        ElseIf Me.txtLastName.Text = "" Then
            strResult = "You must enter your Last Name."
        ElseIf Me.txtEmailMain.Text = "" Then
            strResult = "You must enter your Email (Main)."
        ElseIf clsMembers.IsDuplicateEmail(Session("madgCoachID"), Me.txtEmailMain.Text) Then
            strResult = "Duplicate email.  Save cancelled."
        Else
            strResult = "OK"
        End If

        Return strResult
    End Function

    Private Sub Page_PreRender(sender As Object, e As System.EventArgs) Handles Me.PreRender
        LoadData(Session("madgCoachID"))
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As System.EventArgs) Handles cmdCancel.Click
        Response.Redirect("adHome.aspx?sel=CoachesList")
    End Sub

    Private Sub cmdDelete_Click(sender As Object, e As System.EventArgs) Handles cmdDelete.Click
        ' 8/7/2013 added...
        ' 6/5/2014 automatically remove a coach from a sport they coach when deleted...
        Dim strSQL As String
        Dim intTeamID As Long = 0

        strSQL = "SELECT teamID FROM tblTeams WHERE memberID = " & Session("madgCoachID")
        intTeamID = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, strSQL)
        If intTeamID = 0 Then
        Else
            strSQL = "UPDATE tblTeams SET memberID = 0 WHERE memberID = " & Session("madgCoachID")
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
        End If
        strSQL = "UPDATE tblMembers SET intActive = 0 WHERE memberID = " & Session("madgCoachID")
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
        ClearFields()
        Me.Visible = False
        Response.Redirect("adHome.aspx?sel=CoachesList")

        'Else
        '    lblMessage.Text = "This coach is assigned to a Sport. You must unassign them before deleting."
        'End If
    End Sub
End Class