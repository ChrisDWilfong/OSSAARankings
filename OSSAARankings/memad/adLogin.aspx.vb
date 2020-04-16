Public Class adLogin
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.ClientTarget = "Uplevel"       ' Added 11/20/2013 to resolve IE 11 compatibility problem...
        ' Remember Me?
        If Not IsPostBack Then
            If Request.Browser.Cookies Then
                If Request.Cookies("OSSAARADLOGIN") IsNot Nothing Then
                    Try
                        txtUserName.Text = Request.Cookies("OSSAARADLOGIN").Value
                    Catch
                    End Try
                End If
            End If
        End If

    End Sub

    Private Sub cmdLogin_Click(sender As Object, e As System.EventArgs) Handles cmdLogin.Click
        Dim strUserName As String
        Dim strPassword As String
        Dim strSQL As String
        Dim ds As DataSet

        strUserName = clsFunctions.StringValidate(txtUserName.Text)
        strPassword = clsFunctions.StringValidate(txtPassword.Text)

        ' Allow both... HACK!!!
        If strUserName = "cwilfong@ossaa.com" Then

            If strPassword = "gohogs23" Then strPassword = "gohogs"

            ' JUST A LITTLE MAINTENANCE OR CLEANUP STUFF...
            ' Added 8/12/2014...
            strSQL = "UPDATE tblMembers SET Password = 'password' WHERE Password = ''"
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        End If

        strSQL = "SELECT * FROM tblSchool WHERE AdminADEmail = '" & strUserName & "' AND Password3 = '" & strPassword & "'"
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        If ds Is Nothing Then
            lblMessage.Text = "Invalid login information."
        ElseIf ds.Tables.Count = 0 Then
            lblMessage.Text = "Invalid login information."
        ElseIf ds.Tables(0).Rows.Count = 0 Then
            lblMessage.Text = "Invalid login information."
        Else
            With ds.Tables(0).Rows(0)
                Session("madgUsername") = strUserName
                Session("madgMemberID") = .Item("Id")
                Session("madgSchool") = .Item("schoolName")
                Session("madgSchoolID") = .Item("schoolID")

                Session("entryFormSchoolName") = .Item("schoolName")
                Session("entryFormSchoolID") = .Item("schoolID")
                'Session("entryFormMemberID") = .Item("Id")
                Session("entryFormMemberID") = 0

                Session("madgCoachName") = .Item("AdminADFirst") & " " & .Item("AdminADLast")
                Session("madgTitle") = "Athletic Director"
                Session("madgFirstName") = .Item("AdminADFirst")
                Session("madgLastName") = .Item("AdminADLast")
                Session("madgEmailMain") = .Item("AdminADEmail")
                Session("madgPhoneMain") = .Item("AdminADPhoneCell")
                Session("madgPhoneAlt") = .Item("AdminADPhoneSchool")
                Session("madgPassword") = .Item("Password3")
                Session("madgOrganizationType") = .Item("OrganizationType")
                If Session("madgOrganizationType") = "MULTI" Then
                    Dim dsOT As DataSet
                    If Session("maddsSchoolsMULTI") Is Nothing Then
                        strSQL = "SELECT DISTINCT SchoolName AS SchoolDisplay, schoolID FROM tblSchool WHERE intMulti = " & Session("madgMemberID") & " ORDER BY SchoolName"
                        dsOT = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)
                        Session("maddsSchoolsMULTI") = dsOT
                    End If
                ElseIf Session("madgOrganizationType") = "OSSAAADMIN" Then
                    Dim dsOM As DataSet
                    If Session("maddsSchoolsADMIN") Is Nothing Then
                        strSQL = "SELECT DISTINCT SchoolName AS SchoolDisplay, schoolID FROM tblSchool WHERE OrganizationType = 'SCHOOL' ORDER BY SchoolName"
                        dsOM = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)
                        Session("maddsSchoolsADMIN") = dsOM
                    End If
                End If
            End With

            WriteCookie(strUserName, strPassword)

            If Not IsPostBack Then
                If txtUserName.Text = "cwilfong@ossaa.com" Then
                    Session.Timeout = 240
                End If
            End If

            strSQL = "INSERT INTO tblMembersLogin (memberID, strType, strSchoolName) VALUES ('" & Session("madgMemberID") & "', 'AD', '" & Session("madgSchool") & "')"
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
            Response.Redirect("adHome.aspx")

            End If

    End Sub

    Public Sub WriteCookie(ByVal strUsernameIn As String, ByVal strPasswordIn As String)
        If (Request.Browser.Cookies) Then
            If (Request.Cookies("OSSAARADLOGIN") Is Nothing) Then
                Response.Cookies("OSSAARADLOGIN").Expires = DateTime.Now.AddDays(30)
                Response.Cookies("OSSAARADLOGIN").Value = strUsernameIn
            Else
                Response.Cookies("OSSAARADLOGIN").Expires = DateTime.Now.AddDays(14)
                Response.Cookies("OSSAARADLOGIN").Value = strUsernameIn
            End If
        End If
    End Sub

    Private Sub cmdForgot_Click(sender As Object, e As System.EventArgs) Handles cmdForgot.Click
        Response.Redirect("../mem/LoginForgot.aspx")
    End Sub
End Class