Public Class MemberLogin
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Request.QueryString("logout") = "1" Then
            Session("user") = ""
            Session("key") = ""
            Session("idSchool") = ""
            Session("usertype") = "NONE"
            Session("multi") = 0
            Me.Login1.Visible = True
        End If

        ' Remember Me?
        If Not IsPostBack Then
            If Request.Browser.Cookies Then
                If Request.Cookies("OSSAAMLOGIN") IsNot Nothing Then
                    Me.Login1.UserName = Request.Cookies("OSSAAMLOGIN")("UNAME").ToString()
                End If
            End If
        End If

        If Not IsPostBack Then
            Me.lblCopyright.Text = clsMembership.GetCopyright
        End If

    End Sub

    Protected Sub Login1_Authenticate(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.AuthenticateEventArgs) Handles Login1.Authenticate
        Dim strUserName As String = ""
        Dim strUsernameIn As String
        Dim strPasswordIn As String
        Dim intConfirmed As Integer

        strUsernameIn = Me.Login1.UserName
        strUsernameIn = SqlHelper.StripString(strUsernameIn)
        strPasswordIn = Me.Login1.Password
        strPasswordIn = SqlHelper.StripString(strPasswordIn)

        strUserName = AuthenticateUser(Me.Login1.UserName, Me.Login1.Password)

        WriteCookie(strUsernameIn, strPasswordIn)

        If strUserName = "" Then
            e.Authenticated = False
        Else
            Session("user") = strUserName
            If Session("usertype") = "SUPER" Then
                SqlHelper.LogUser(Session("user"), Session("usertype"), Session("key"), "SCHOOL-LOGIN", Session("school"))

                intConfirmed = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, "SELECT intConfirmedSuper FROM tblSchool WHERE Id = " & Session("key"))
                If intConfirmed = 0 Then
                    Session("confirmed") = 0
                    EmailLogin("MemberInfoSup.aspx")
                    Response.Redirect("MemberInfoSup.aspx")
                Else
                    Session("confirmed") = 1
                    EmailLogin("MemberHome.aspx")
                    Response.Redirect("MemberHome.aspx")
                End If

                e.Authenticated = True
            ElseIf Session("usertype") = "PRINCIPAL" Then
                SqlHelper.LogUser(Session("user"), Session("usertype"), Session("key"), "SCHOOL-LOGIN", Session("school"))
                intConfirmed = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, "SELECT intConfirmedPrincipal FROM tblSchool WHERE Id = " & Session("key"))
                If intConfirmed = 0 Then
                    Session("confirmed") = 0
                    EmailLogin("MemberInfoPrin.aspx")
                    Response.Redirect("MemberInfoPrin.aspx")
                Else
                    Session("confirmed") = 1
                    EmailLogin("MemberHome.aspx")
                    Response.Redirect("MemberHome.aspx")
                End If
                e.Authenticated = True

            ElseIf Session("usertype") = "AD" Then
                SqlHelper.LogUser(Session("user"), Session("usertype"), Session("key"), "SCHOOL-LOGIN", Session("school"))
                intConfirmed = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, "SELECT intConfirmedAD FROM tblSchool WHERE Id = " & Session("key"))
                If intConfirmed = 0 Then
                    Session("confirmed") = 0
                    EmailLogin("MemberInfoAD.aspx")
                    Response.Redirect("MemberInfoAD.aspx")
                Else
                    Session("confirmed") = 1
                    EmailLogin("MemberHome.aspx")
                    Response.Redirect("MemberHome.aspx")
                End If
                e.Authenticated = True

            ElseIf Session("usertype") = "OSSAA" Or Session("usertype") = "OSSAAADMIN" Then
                SqlHelper.LogUser(Session("user"), Session("usertype"), Session("key"), "OSSAA-LOGIN", Session("school"))
                EmailLogin("MemberHome.aspx")
                Response.Redirect("MemberHome.aspx")
                e.Authenticated = True
                Else
                    SqlHelper.LogUser((Me.Login1.UserName & "-" & Me.Login1.Password), "NONE", 0, "LOGIN-FAILED", Session("school"))
                    e.Authenticated = False
                End If
        End If

    End Sub

    Public Sub EmailLogin(strToSite As String)
        ' 10/29/2018 removed...
        'clsEmail.SendEmail(Me, "Login by : " & Session("user") & " : " & Session("school") & " : " & Session("usertype") & " on " & Now & " to " & strToSite, "membershiplogin@ossaa.com", "", "Membership Login by : " & Session("user") & " : " & Session("school") & " : " & Session("usertype") & " on " & Now, False)
    End Sub

    Public Function AuthenticateUser(ByVal strUsernameIn As String, ByVal strPasswordIn As String) As String
        Dim strReturn As String = ""
        Dim intKey As Integer = 0
        Dim intSchoolId As Integer = 0
        Dim strPassword As String = ""
        Dim intMulti As Integer = 0

        ' Search Superintendents...
        intKey = FindUserKeyNo(strUsernameIn, strPasswordIn)
        intSchoolId = clsMembership.FindSchoolId(intKey)

        If intKey > 0 Then
            Session("votingdelegate") = clsMembership.GetVotingDelegateInfo(intSchoolId)

            intMulti = FindMulti(intKey)
            Select Case Session("usertypetemp")
                Case "SUPER"
                    If FindPassword(intKey, strPasswordIn, 1) <> "" Then
                        Session("usertype") = "SUPER"
                        Session("user") = strUsernameIn
                        Session("password") = strPasswordIn
                        Session("key") = intKey
                        Session("multi") = intMulti
                        Session("idSchool") = intSchoolId
                    Else
                        Session("usertype") = "NONE"
                        Session("user") = ""
                        Session("password") = ""
                        Session("key") = 0
                        Session("multi") = 0
                        Session("idSchool") = 0
                    End If
                Case "PRINCIPAL"
                    If FindPassword(intKey, strPasswordIn, 2) <> "" Then
                        Session("usertype") = "PRINCIPAL"
                        Session("user") = strUsernameIn
                        Session("password") = strPasswordIn
                        Session("key") = intKey
                        Session("multi") = 0
                        Session("idSchool") = intSchoolId
                    Else
                        Session("usertype") = "NONE"
                        Session("user") = ""
                        Session("password") = ""
                        Session("key") = 0
                        Session("multi") = 0
                        Session("idSchool") = 0
                    End If
                Case "AD"
                    If FindPassword(intKey, strPasswordIn, 3) <> "" Then
                        Session("usertype") = "AD"
                        Session("user") = strUsernameIn
                        Session("password") = strPasswordIn
                        Session("key") = intKey
                        Session("multi") = 0
                        Session("idSchool") = intSchoolId
                    Else
                        Session("usertype") = "NONE"
                        Session("user") = ""
                        Session("password") = ""
                        Session("key") = 0
                        Session("multi") = 0
                        Session("idSchool") = 0
                    End If
                Case "OSSAA"
                    If FindPassword(intKey, strPasswordIn, 0) <> "" Then
                        Session("usertype") = "OSSAA"
                        Session("user") = strUsernameIn
                        Session("password") = strPasswordIn
                        Session("key") = intKey
                        Session("multi") = 0
                        Session("idSchool") = intSchoolId
                    Else
                        Session("usertype") = "NONE"
                        Session("user") = ""
                        Session("password") = ""
                        Session("key") = 0
                        Session("multi") = 0
                        Session("idSchool") = 0
                    End If
                Case "OSSAAADMIN"
                    If FindPassword(intKey, strPasswordIn, 0) <> "" Then
                        Session("usertype") = "OSSAAADMIN"
                        Session("user") = strUsernameIn
                        Session("password") = strPasswordIn
                        Session("key") = intKey
                        Session("multi") = 0
                        Session("idSchool") = intSchoolId
                    Else
                        Session("usertype") = "NONE"
                        Session("user") = ""
                        Session("password") = ""
                        Session("key") = 0
                        Session("multi") = 0
                        Session("idSchool") = 0
                    End If
                Case Else
                    Session("usertype") = "NONE"
                    Session("user") = ""
                    Session("password") = ""
                    Session("key") = 0
                    Session("multi") = 0
                    Session("idSchool") = 0
            End Select

        End If

        If intKey > 0 Then
            strReturn = strUsernameIn
        Else
            strReturn = ""
        End If

        Return strReturn

    End Function

    Public Function FindMulti(ByVal intKey As Integer) As Integer
        ' Added 11/2/2010...

        Dim strSQL As String
        Dim intMulti As Integer = 0
        strSQL = "SELECT intMulti FROM tblSchool WHERE Id = " & intKey

        Try
            intMulti = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, System.Data.CommandType.Text, strSQL)
            If intMulti = 99999 Then
            Else
                intMulti = 0
            End If
        Catch
            intMulti = 0
        End Try

        Return intMulti
    End Function


    Public Function FindUserKeyNo(ByVal strUserNameIn As String, ByVal strPasswordIn As String) As Integer
        Dim intKey As Integer = 0
        Dim strSQL As String = ""

        Session("usertypetemp") = ""

        strSQL = "SELECT Id FROM tblSchool WHERE Username = '" & strUserNameIn & "' And Password = '" & strPasswordIn & "'"
        Try
            intKey = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, System.Data.CommandType.Text, strSQL)
            'Session("usertypetemp") = "OSSAA"
            strSQL = "SELECT OrganizationType FROM tblSchool WHERE Username = '" & strUserNameIn & "' And Password = '" & strPasswordIn & "'"
            Dim strResult As String
            strResult = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, System.Data.CommandType.Text, strSQL)
            Session("usertypetemp") = strResult
            Session("school") = clsMembership.GetSchoolNameFromKey(intKey)
        Catch
            intKey = 0
        End Try

        If intKey > 0 Then
            ' Move on, we are done...
        Else

            strSQL = "SELECT Id FROM tblSchool WHERE AdminSuperEmail = '" & strUserNameIn & "' And Password1 = '" & strPasswordIn & "'"
            Try
                intKey = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, System.Data.CommandType.Text, strSQL)
                Session("usertypetemp") = "SUPER"
                Session("school") = clsMembership.GetSchoolNameFromKey(intKey)
            Catch
                intKey = 0
            End Try

            If intKey > 0 Then
                ' Move on, we are done...
            Else
                strSQL = "SELECT Id FROM tblSchool WHERE AdminPrincipalEmail = '" & strUserNameIn & "' And Password2 = '" & strPasswordIn & "'"
                Try
                    intKey = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, System.Data.CommandType.Text, strSQL)
                    Session("usertypetemp") = "PRINCIPAL"
                    Session("school") = clsMembership.GetSchoolNameFromKey(intKey)
                Catch
                    intKey = 0
                End Try
                If intKey > 0 Then
                    ' Move on, we are done...
                Else
                    strSQL = "SELECT Id FROM tblSchool WHERE AdminADEmail = '" & strUserNameIn & "' And Password3 = '" & strPasswordIn & "'"
                    Try
                        intKey = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, System.Data.CommandType.Text, strSQL)
                        Session("usertypetemp") = "AD"
                        Session("school") = clsMembership.GetSchoolNameFromKey(intKey)
                    Catch
                        intKey = 0
                    End Try
                End If
            End If
        End If

        Return intKey

    End Function

    Public Function FindPassword(ByVal intKeyIn As Integer, ByVal strPasswordIn As String, ByVal intSearchNo As Integer) As String
        Dim strPassword As String = ""
        Dim strSQL As String

        Select Case intSearchNo
            Case 1
                strSQL = "SELECT Password1 FROM tblSchool WHERE Id = " & intKeyIn
            Case 2
                strSQL = "SELECT Password2 FROM tblSchool WHERE Id = " & intKeyIn
            Case 3
                strSQL = "SELECT Password3 FROM tblSchool WHERE Id = " & intKeyIn
            Case 0
                strSQL = "SELECT Password FROM tblSchool WHERE Id = " & intKeyIn
            Case Else
                strSQL = ""
        End Select

        If strSQL = "" Then
            strPassword = ""
        Else
            Try
                strPassword = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, System.Data.CommandType.Text, strSQL)
                If strPassword.ToUpper = strPasswordIn.ToUpper Then
                    ' Verified, do nothing but return the password...
                Else
                    strPassword = ""
                End If
            Catch
                strPassword = ""
            End Try
        End If

        Return strPassword

    End Function

    Protected Sub cmdForgotLogin_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdForgotLogin.Click
        Response.Redirect("MemberForgotLogin.aspx")
    End Sub

    Public Sub WriteCookie(ByVal strUsernameIn As String, ByVal strPasswordIn As String)
        If (Request.Browser.Cookies) Then
            If (Request.Cookies("OSSAAMLOGIN") Is Nothing) Then
                Response.Cookies("OSSAAMLOGIN").Expires = DateTime.Now.AddDays(30)
                Response.Cookies("OSSAAMLOGIN").Item("UNAME") = strUsernameIn
                Response.Cookies("OSSAAMLOGIN").Item("UPASS") = strPasswordIn
            Else
                Response.Cookies("OSSAAMLOGIN").Item("UNAME") = strUsernameIn
                Response.Cookies("OSSAAMLOGIN").Item("UPASS") = strPasswordIn
            End If
        End If
    End Sub
End Class