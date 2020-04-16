Public Class LoginWH
    Inherits System.Web.UI.Page

    Public objDashboard As clsDashboard

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'If Request.QueryString("login") = "ossaastaff" Then
        '    Session("login") = "ossaastaff"
        '    Session("override") = True
        '    Session("user") = Request.QueryString("login")
        '    Response.Redirect("WHReportEntry.aspx")
        'End If

        objDashboard = New clsDashboard("PLAYOFFAVAIL", "Football", clsFunctions.GetCurrentYear)
        lblHeader.Text = objDashboard.gLoginHeader

    End Sub

    Protected Sub cmdLogin_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLogin.Click
        Dim strInvalidCodeMessage As String

        strInvalidCodeMessage = "Invalid code.  You are not identified as a White Hat Official with a valid test score in our system.  Please email Sheree Riddell (sriddell@ossaa.com) or call 405.840.1116"
        Session("override") = False

        If txtUsername.Text = "ossaastaff" Then
            Session("user") = txtUsername.Text
            Session("override") = True
            Response.Redirect("WHReportAdmin.aspx")
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
            Dim strSQL As String = "SELECT TOP 1 id FROM prodOfficials WHERE strEmail = '" & strUserName & "' AND intTestFootball >= 74 AND (ysnWhiteHat = -1 And (intOSSAAID > 0))"
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
                        Session("OfficialName") = .Item("strFirstName") & " " & .Item("strLastName") & " (" & .Item("strClassFootball") & "-" & .Item("dblRatingFootball") & ")"
                        Session("user") = strUserName
                    End With

                    ' Log it 9/17/2012 added...
                    strSQL = "INSERT INTO ossaauser.tblOfficialsReportsFootballLog (intWhiteHatOSSAAID, strWhiteHatName, strWhiteHatEmail) VALUES (" & Session("OSSAAID") & ", '" & Session("OfficialName") & "', '" & Session("user") & "')"
                    SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

                    'Response.Redirect(objDashboard.gHomePage)
                    'Response.Redirect("WHReportEntry.aspx")
                    Response.Redirect("WHMainMenu.aspx")
                End If
            Else
                lblMessage.Text = strInvalidCodeMessage
            End If

        End If
    End Sub
End Class