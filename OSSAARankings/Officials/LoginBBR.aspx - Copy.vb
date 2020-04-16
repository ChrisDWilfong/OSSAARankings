Public Class LoginBBR
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim strEmail As String = ""
            Dim strID As String = ""
            strEmail = Request.QueryString("e")
            strID = Request.QueryString("id")
            If strEmail = "" Then
            Else
                If strID = "143" Then
                    Me.txtUsername.Text = strEmail
                    'DoLogin(strEmail)
                End If
            End If
        End If
    End Sub

    Public Sub DoLogin(ByVal strEmail As String)
        Dim strInvalidCodeMessage As String
        Dim strEmailCheck As String = ""

        If strEmail = "" Then
            strEmailCheck = Me.txtUsername.Text
        Else
            strEmailCheck = strEmail
        End If

        strInvalidCodeMessage = "Invalid code.  You are not identified Head Basketball Coach in our system.  Your Athletic Director must enter your contact information in the OSSAA Membership Website."

        ' Let's look up the code and see if it is valid...
        Dim intID As Integer = 0
        Dim intGirlsID As Integer = 0
        Dim intBoysID As Integer = 0

        'Dim strSQL As String = "SELECT TOP 1 id FROM prodOfficials WHERE strEmail = '" & Me.txtUsername.Text & "' And ([ysnCurrentFootball] = -1) And (intTestFootball >= 75) And (intOSSAAID > 0)"
        Dim strSQL As String = "SELECT TOP 1 id FROM tblCoaches WHERE Email = '" & strEmailCheck & "' And (Position = 'HS Head Coach (Girls Basketball)')"
        intGirlsID = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

        strSQL = "SELECT TOP 1 id FROM tblCoaches WHERE Email = '" & strEmailCheck & "' And (Position = 'HS Head Coach (Boys Basketball)')"
        intBoysID = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

        If intBoysID > 0 Or intGirlsID > 0 Then
            Dim ds As DataSet
            If intBoysID > 0 Then
                strSQL = "SELECT * FROM tblCoaches WHERE Id = " & intBoysID
                ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            ElseIf intGirlsID > 0 Then
                strSQL = "SELECT * FROM tblCoaches WHERE Id = " & intGirlsID
                ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            End If

            If ds Is Nothing Then
                lblMessage.Text = strInvalidCodeMessage
            ElseIf ds.Tables.Count = 0 Then
                lblMessage.Text = strInvalidCodeMessage
            ElseIf ds.Tables(0).Rows.Count = 0 Then
                lblMessage.Text = strInvalidCodeMessage
            Else
                ' Found it, move on...
                With ds.Tables(0).Rows(0)
                    If intBoysID > 0 Then
                        Session("CoachIdBoys") = intBoysID
                        Session("CoachId") = intBoysID
                    Else
                        Session("CoachIdBoys") = 0
                    End If
                    If intGirlsID > 0 Then
                        Session("CoachIdGirls") = intGirlsID
                        Session("CoachId") = intGirlsID
                    Else
                        Session("CoachIdGirls") = 0
                    End If

                    If intGirlsID > 0 And intBoysID > 0 Then
                        Session("CoachID") = intBoysID
                    End If

                    Session("intSchoolID") = .Item("schoolID")
                    Session("CoachName") = .Item("FirstName") & " " & .Item("LastName")
                    Session("SchoolName") = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, "SELECT SchoolName FROM tblSchool WHERE Id = " & Session("intSchoolID"))
                    Session("SchoolID") = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, "SELECT SchoolID FROM tblSchool WHERE Id = " & Session("intSchoolID"))
                    Session("user") = strEmailCheck
                End With
                Response.Redirect("BBMainMenu.aspx")
            End If
        Else
            lblMessage.Text = strInvalidCodeMessage
        End If

    End Sub

    Protected Sub cmdLogin_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLogin.Click
        DoLogin("")
    End Sub
End Class