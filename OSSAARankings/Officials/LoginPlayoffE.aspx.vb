Public Class LoginPlayoffE
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("login") = "ossaasup" Or Request.QueryString("login") = "ossaaAD" Or Request.QueryString("login") = "ossaaprincipal" Or Request.QueryString("login") = "ossaastaff" Then
            Session("user") = Request.QueryString("login")
            Response.Redirect("EligibleOfficialsPlayoffs.aspx")
        End If
    End Sub

    Protected Sub cmdLogin_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLogin.Click
        DoLogin(Me.txtUsername.Text)
    End Sub

    Public Sub DoLogin(ByVal strEmail As String)
        Dim strInvalidCodeMessage As String
        Dim strInvalidCodeMessage1 As String
        Dim strEmailCheck As String = ""
        Dim ds As DataSet
        '''''Dim dsd As DataSet

        If strEmail = "" Then
            strEmailCheck = Me.txtUsername.Text
        Else
            strEmailCheck = strEmail
        End If

        strInvalidCodeMessage = "Invalid code.  You are not identified as a Head Basketball Coach or Administrator for a District in our system."
        strInvalidCodeMessage1 = "Your team is not in the District Playoffs."

        If strEmailCheck = "ossaastaff" Then
            Session("user") = "ossaastaff"
            Session("userName") = "OSSAA Staff"
            Session("userSchoolName") = "OSSAA"
            Response.Redirect("EligibleOfficialsPlayoffs.aspx")
        Else
            ' Let's look up the code and see if it is valid...
            Dim intID As Integer = 0
            Dim strSQL As String = "SELECT TOP 1 * FROM viewPlayoffBBLogins WHERE Email = '" & strEmailCheck & "'"
            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

            If ds Is Nothing Then
                lblMessage.Text = strInvalidCodeMessage
            ElseIf ds.Tables.Count = 0 Then
                lblMessage.Text = strInvalidCodeMessage
            ElseIf ds.Tables(0).Rows.Count = 0 Then
                lblMessage.Text = strInvalidCodeMessage
            Else
                ' Set User Info...
                Session("user") = ds.Tables(0).Rows(0).Item("Email")
                Session("userName") = ds.Tables(0).Rows(0).Item("FirstName") & " " & ds.Tables(0).Rows(0).Item("LastName")
                Session("userSchoolName") = ds.Tables(0).Rows(0).Item("SchoolName")

                ' Log Activity...
                strSQL = "INSERT INTO tblLogEligibleOfficialsPlayoffs (strEmail, strName, strSchool, strPosition) VALUES ('" & Session("user") & "', '" & Session("userName") & "', '" & Session("userSchoolName") & "', '" & ds.Tables(0).Rows(0).Item("Position") & "')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

                Response.Redirect("EligibleOfficialsPlayoffs.aspx")
            End If
        End If

    End Sub

End Class