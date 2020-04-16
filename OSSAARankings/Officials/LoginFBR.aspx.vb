Public Class LoginFBR
    Inherits System.Web.UI.Page
    Public objDashboardScratch As clsDashboard

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim strEmail As String = ""
        Dim intSchoolID As Long = 0
        strEmail = Request.QueryString("id")
        Try
            intSchoolID = Request.QueryString("sid")
            If intSchoolID = 8401116 Then
            Else
                intSchoolID -= 1234
            End If
        Catch
            intSchoolID = 0
        End Try

        If (strEmail = "" And intSchoolID = 0) Then
            ' Do nothing...
            cboSchools.Enabled = False
            txtUsername.Enabled = False
        ElseIf intSchoolID = 8401116 Then
            cboSchools.Enabled = True
            txtUsername.Enabled = True
            Call cmdLogin_Click(sender, e)
        Else
            cboSchools.Enabled = False
            txtUsername.Enabled = False
            Call cmdLogin_Click(sender, e)
        End If

    End Sub

    Protected Sub cmdLogin_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLogin.Click
        Dim intSchoolID As Long = 0
        Dim strEmail As String = ""

        If Request.QueryString("l") = "ossaacoach" Or Request.QueryString("l") = "ossaastaff" Then
            ' Continue...
            Try
                intSchoolID = Request.QueryString("sid")
                strEmail = Request.QueryString("id")
                If intSchoolID = 8401116 Then
                    intSchoolID = Me.cboSchools.SelectedValue
                Else
                    intSchoolID -= 1234
                End If
            Catch ex As Exception
                intSchoolID = -1
                strEmail = ""
            End Try
        Else
            lblMessage.Text = "This site is currently unavailable.  Please check back soon..."
            Exit Sub
        End If

        Dim strInvalidCodeMessage As String = "Invalid code."

        If Me.cboSchools.SelectedValue = "Select School..." And (intSchoolID < 1) Then
            Me.lblMessage.Text = "You must select a school."
        ElseIf (UCase(Me.txtUsername.Text) <> System.Configuration.ConfigurationManager.AppSettings("CoachesLogin")) And (intSchoolID < 1) Then
            Me.lblMessage.Text = strInvalidCodeMessage
        Else
            ' Let's look up the code and see if it is valid...
            Dim intID As Integer = 0
            Dim strSQL As String = "SELECT TOP 1 teamID FROM ossaauser.viewTeamsFootball WHERE schoolID = " & intSchoolID & " ORDER BY teamID DESC"
            If strEmail <> "" Then      ' Added 9/19/2014...
                strSQL = "SELECT TOP 1 teamID FROM ossaauser.viewTeamsFootball WHERE schoolID = " & intSchoolID & " AND emailMain = '" & strEmail & "' ORDER BY teamID DESC"
            End If
            intID = SqlHelper.ExecuteScalar(SQLHelper.SQLConnection, CommandType.Text, strSQL)

            If intID > 0 Then       ' Found it, move on...
                Dim ds As DataSet
                strSQL = "SELECT * FROM ossaauser.viewTeamsFootball WHERE teamID = " & intID
                ds = SqlHelper.ExecuteDataset(SQLHelper.SQLConnection, CommandType.Text, strSQL)
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
                        Session("CoachName") = .Item("strFirstLast")
                        Session("SchoolName") = .Item("SchoolName")
                        Session("SchoolID") = .Item("schoolID")
                        Session("TeamID") = .Item("TeamID")
                        Session("MemberID") = .Item("MemberID")

                        If strEmail = "" Then
                            Session("user") = Session("SchoolName")
                        Else
                            Session("user") = strEmail
                        End If
                    End With
                    objDashboardScratch = New clsDashboard("COACHESSCRATCH", "Football", clsFunctions.GetCurrentYear)
                    If Now >= objDashboardScratch.gStartDate And Now <= objDashboardScratch.gEndDate Then
                        ' If Scratch List is active, then show the main menu to select from...
                        Response.Redirect("FBMainMenu.aspx")
                    Else
                        Response.Redirect("FBRatingEntry.aspx")
                    End If
                End If
                    Else
                Me.lblMessage.Text = "Your coaches information was NOT FOUND in OSSAARankings.com, please contact your Athletic Director."
            End If
        End If

    End Sub

    Private Sub cboSchools_DataBound(sender As Object, e As System.EventArgs) Handles cboSchools.DataBound
        cboSchools.Items.Insert(0, "Select School...")
    End Sub
End Class