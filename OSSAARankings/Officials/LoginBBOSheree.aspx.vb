Public Class LoginBBOSheree
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("login") = "ossaastaff" Then
            Session("user") = Request.QueryString("login")
        End If
        'Me.lblMessage.Text = "This site is now closed."
    End Sub

    Protected Sub cmdLogin_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLogin.Click
        Dim strInvalidCodeMessage As String

        'Me.lblMessage.Text = "This site is now closed."
        'Exit Sub

        strInvalidCodeMessage = "Invalid code.  You are not identified as qualifying to enter Playoff Availability in our system (OSSAA enrolled official, passed Part 1 AND Part II).  Please email Sheree Riddell (sriddell@ossaa.com) or call 405.840.1116"
        Session("override") = False

        If txtUsername.Text = "ossaastaff" Then
            Session("user") = txtUsername.Text
        Else
            Dim strUserName As String
            strUserName = Me.txtUsername.Text

            If InStr(strUserName, "sheree") > 0 Then
                Session("override") = True
                strUserName = strUserName.Replace("sheree", "")
            Else
                Session("override") = False
            End If

            ' Let's look up the code and see if it is valid...
            Dim intID As Integer = 0
            Dim strSQL As String
            If InStr(Me.txtUsername.Text, "@") > 0 Then
                strSQL = "SELECT TOP 1 id FROM prodOfficials WHERE strEmail = '" & Me.txtUsername.Text & "'"
            Else
                strSQL = "SELECT TOP 1 id FROM prodOfficials WHERE intOSSAAID = '" & Me.txtUsername.Text & "'"
            End If
            intID = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            If intID > 0 Then
                Dim ds As DataSet
                strSQL = "SELECT * FROM prodOfficials WHERE Id = " & intID
                ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
                If ds Is Nothing Then
                    lblMessage.Text = strInvalidCodeMessage
                ElseIf ds.Tables.Count = 0 Then
                    lblMessage.Text = strInvalidCodeMessage
                ElseIf ds.Tables(0).Rows.Count = 0 Then
                    lblMessage.Text = strInvalidCodeMessage
                Else
                    ' Found it, move on...
                    With ds.Tables(0).Rows(0)
                        Session("OSSAAID") = .Item("intOSSAAID")
                        Session("Id") = intID
                        Session("OfficialName") = .Item("strFirstName") & " " & .Item("strLastName")
                        Session("user") = strUserName
                    End With
                    'Response.Redirect("PlayoffAvailabilityBK.aspx")
                    Response.Redirect("PlayoffAvailabilityEmBK.aspx")
                End If
            Else
                lblMessage.Text = strInvalidCodeMessage
            End If

        End If
    End Sub
End Class