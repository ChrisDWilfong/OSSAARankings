Public Class LoginFBR2011
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

    Protected Sub cmdLogin_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLogin.Click
        Dim strInvalidCodeMessage As String

        strInvalidCodeMessage = "Invalid code.  You are not identified Head Football Coach in our system.  Your Athletic Director must enter your contact information in the OSSAA Membership Website."

        ' Let's look up the code and see if it is valid...
        Dim intID As Integer = 0
        Dim strSQL As String = "SELECT TOP 1 id FROM tblCoaches WHERE Email = '" & Me.txtUsername.Text & "' And Position = 'HS Head Coach (Football)'"
        intID = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
        If intID > 0 Then
            Dim ds As DataSet
            strSQL = "SELECT * FROM tblCoaches WHERE Id = " & intID
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
                    Session("CoachId") = intID
                    Session("intSchoolID") = .Item("schoolID")
                    Session("CoachName") = .Item("FirstName") & " " & .Item("LastName")
                    Session("SchoolName") = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, "SELECT SchoolName FROM tblSchool WHERE Id = " & Session("intSchoolID"))
                    Session("SchoolID") = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, "SELECT SchoolID FROM tblSchool WHERE Id = " & Session("intSchoolID"))
                    Session("user") = Me.txtUsername.Text
                End With
                Response.Redirect("FBMainMenu.aspx")
            End If
        Else
            lblMessage.Text = strInvalidCodeMessage
        End If

    End Sub
End Class