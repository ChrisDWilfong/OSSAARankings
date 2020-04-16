Imports System.Net.Mail

Public Class clsEmail

    Public Shared Function SendEmailNew(strEmailTo As String, strEmailFrom As String, strSubject As String, strContent As String, ysnLogToDb As Boolean, strFromHeader As String) As String
        Dim strReturn As String = "OK"
        Dim strSQL As String = ""
        Dim strDisplayName As String = ""

        If strEmailFrom = "" Then strEmailFrom = "ossaa@earthlink.net"

        If strDisplayName = "" Then
            strDisplayName = "OSSAA Confirmation Email"
        Else
        End If

        If ysnLogToDb Then
            strSQL = "INSERT INTO emails (strSubject, strContent, strEmailTo, strEmailFrom) VALUES ('" & strSubject.Replace("'", "") & "', '" & strContent.Replace("'", "") & "', '" & strEmailTo & "', '" & strEmailFrom & "')"
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            Exit Function
        Else
            'Exit Function
        End If

        Dim Smtp_Server As New SmtpClient
        Dim e_mail As New MailMessage()
        Smtp_Server.UseDefaultCredentials = False
        Smtp_Server.Credentials = New Net.NetworkCredential("ossaa@earthlink.net", "Ossaarocks23")
        Smtp_Server.Port = 587
        Smtp_Server.EnableSsl = True
        Smtp_Server.Host = "smtpauth.earthlink.net"

        e_mail = New MailMessage()
        e_mail.From = New MailAddress(strEmailFrom, strDisplayName)

        e_mail.To.Add(strEmailTo)
        e_mail.Subject = strSubject
        e_mail.IsBodyHtml = False
        e_mail.Body = strContent
        Smtp_Server.Send(e_mail)

        Return strReturn

    End Function

    Shared Function SendEmail(ByVal sender As Object, ByVal strContent As String, ByVal strEmailTo As String, ByVal strEmailFrom As String, ByVal strSubject As String, Optional ysnLogToDb As Boolean = True) As String
        Dim strTo As String
        Dim strResult As String = "OK"

        strTo = strEmailTo
        strEmailFrom = "cwilfong@ossaa.com"

        Dim strSQL As String
        ysnLogToDb = True

        If ysnLogToDb Then
            strSQL = "INSERT INTO emails (strSubject, strContent, strEmailTo, strEmailFrom) VALUES ('" & strSubject.Replace("'", "") & "', '" & strContent.Replace("'", "") & "', '" & strEmailTo & "', '" & strEmailFrom & "')"
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            Exit Function
        Else
            Exit Function
        End If

        Dim objEmail As New MailMessage(strEmailFrom, strEmailTo)
        objEmail.BodyEncoding = Encoding.Default
        objEmail.Subject = strSubject
        objEmail.IsBodyHtml = True
        objEmail.Body = strContent

        Dim objEmailSender As New SmtpClient
        Dim objAuth As New System.Net.NetworkCredential("cwilfong@ipa.net", "Ossaarocks!")

        objEmailSender.Host = "smtpauth.earthlink.net"
        '''''objEmailSender.Port = 465
        objEmailSender.Port = 587
        objEmailSender.EnableSsl = True

        objEmailSender.Credentials = objAuth
        objEmailSender.UseDefaultCredentials = False
        Dim userState As Object = objEmail

        AddHandler objEmailSender.SendCompleted, AddressOf sender.SmtpClient_OnCompleted
        Stop

        Try
            objEmailSender.Send(objEmail)
            strResult = "OK"
        Catch ex As Exception
            strResult = ex.Message.ToString
        End Try

        objEmail.Dispose()

        Return strResult
    End Function

    Shared Function GetForgotLoginEmailContent(ByVal strEmailIn As String, ByVal Id As Integer, ByVal intPosition As Long, strPosition As String, ByVal strNameIn As String, ByVal strSchoolName As String, IsOSSAARankings As Boolean) As String
        ' Get the A/D or coaches login...
        Dim strResults As String
        Dim strSQL As String
        Dim ds As DataSet
        'Dim objNewLine As String = "<br>"
        'Dim objNewLine As Integer = vbCrLf

        If strPosition = "Athletic Director" Then
            strSQL = "SELECT AdminSuperEmail, AdminPrincipalEmail, AdminADEmail, Password1, Password2, Password3 FROM tblSchool "
            strSQL = strSQL & "WHERE id = " & Id & " And AdminADEmail = '" & strEmailIn & "'"
            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
        ElseIf strPosition = "Superintendent" Then
            strSQL = "SELECT AdminSuperEmail, AdminPrincipalEmail, AdminADEmail, Password1, Password2, Password3 FROM tblSchool "
            strSQL = strSQL & "WHERE id = " & Id & " And AdminSuperEmail = '" & strEmailIn & "'"
            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
        ElseIf strPosition = "High School Principal" Then
            strSQL = "SELECT AdminSuperEmail, AdminPrincipalEmail, AdminADEmail, Password1, Password2, Password3 FROM tblSchool "
            strSQL = strSQL & "WHERE id = " & Id & " And AdminPrincipalEmail = '" & strEmailIn & "'"
            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
        ElseIf intPosition = 99999 Then
            strSQL = "SELECT AdminSuperEmail, AdminPrincipalEmail, AdminADEmail, Password1, Password2, Password3 FROM tblSchool "
            'strSQL = strSQL & "WHERE schoolID = " & intSchoolId & " And AdminADEmail = '" & strEmailIn & "'"
            strSQL = strSQL & "WHERE Id = " & Id & " And AdminADEmail = '" & strEmailIn & "'"           ' CDW changed 7/28/2016...
            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
        Else
            If intPosition = 0 Then
                'strSQL = "SELECT Username, Password FROM tblMembers WHERE SchoolID = " & intSchoolId & " AND Username = '" & strEmailIn & "' AND intActive <> 0"
                strSQL = "SELECT Username, Password FROM tblMembers WHERE SchoolID = " & Id & " AND Username = '" & strEmailIn & "' AND intActive <> 0"
            Else
                'strSQL = "SELECT Username, Password FROM tblMembers WHERE SchoolID = " & intSchoolId & " AND memberID = " & intPosition & " AND Username = '" & strEmailIn & "' AND intActive <> 0"
                strSQL = "SELECT Username, Password FROM tblMembers WHERE SchoolID = " & Id & " AND memberID = " & intPosition & " AND Username = '" & strEmailIn & "' AND intActive <> 0"
            End If
            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)
        End If

        If ds Is Nothing Then
            strResults = "FAILED (1)"
        ElseIf ds.Tables.Count = 0 Then
            strResults = "FAILED (2)"
        ElseIf ds.Tables(0).Rows.Count = 0 Then
            strResults = "FAILED (3)"
        Else
            strResults = "Hello " & strNameIn & "," & vbCrLf & vbCrLf
            strResults = strResults & "Below is your login information you requested for : " & strSchoolName & "." & vbCrLf & vbCrLf
            If strPosition = "Athletic Director" Then
                strResults = strResults & "Username : " & ds.Tables(0).Rows(0).Item("AdminADEmail") & vbCrLf
                strResults = strResults & "Password : " & ds.Tables(0).Rows(0).Item("Password3") & vbCrLf & vbCrLf
            ElseIf strPosition = "Superintendent" Then
                strResults = strResults & "Username : " & ds.Tables(0).Rows(0).Item("AdminSuperEmail") & vbCrLf
                strResults = strResults & "Password : " & ds.Tables(0).Rows(0).Item("Password1") & vbCrLf & vbCrLf
            ElseIf strPosition = "High School Principal" Then
                strResults = strResults & "Username : " & ds.Tables(0).Rows(0).Item("AdminPrincipalEmail") & vbCrLf
                strResults = strResults & "Password : " & ds.Tables(0).Rows(0).Item("Password2") & vbCrLf & vbCrLf
            Else
                strResults = strResults & "Username : " & ds.Tables(0).Rows(0).Item("UserName") & vbCrLf
                strResults = strResults & "Password : " & ds.Tables(0).Rows(0).Item("Password") & vbCrLf & vbCrLf
            End If
            '            If IsOSSAARankings Then
            '            strResults = strResults & "<a href='http://www.ossaarankings.com/mem/Login.aspx' target='_blank'>Click Here for OSSAARankings.com Website</a>" & vbCrLf & vbCrLf
            '            Else
            '            strResults = strResults & "<a href='http://www.ossaarankings.com/membership/MemberLogin.aspx' target='_blank'>Click Here for OSSAA Membership Website</a>" & vbCrLf & vbCrLf
            '        End If
            strResults = strResults & "If you are still having problems logging in, feel free to contact us at:" & vbCrLf & vbCrLf
            strResults = strResults & "cwilfong@ossaa.com" & vbCrLf
            strResults = strResults & "405.840.1116" & vbCrLf
        End If

        Return strResults

    End Function

End Class
