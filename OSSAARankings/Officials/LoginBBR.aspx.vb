Public Class LoginBBR
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            DoLogin2()
        End If

    End Sub

    Public Sub DoLogin2()

        Dim strInvalidCodeMessage As String
        Dim strSQL As String
        Dim intID As Integer = 0
        Dim intGirlsID As Integer = -999
        Dim intBoysID As Integer = -999
        Dim ds As DataSet

        Dim intMemberID As Long = 0
        Dim strEmail As String = ""
        Dim strGender As String = ""
        Dim strLoginCode As String = ""

        If Request.QueryString("l") = "ossaacoach" Or Request.QueryString("l") = "ossaastaff" Then
            ' Continue...
            Try
                strLoginCode = Request.QueryString("l")
                intMemberID = Request.QueryString("sid")
                strEmail = Request.QueryString("id")
                strGender = Request.QueryString("g")

                If strGender.ToUpper.Contains("BOYS") Then
                    strGender = "Boys"
                ElseIf strGender.ToUpper.Contains("GIRLS") Then
                    strGender = "Girls"
                ElseIf strGender.ToUpper.Contains("BOTH") Then
                    strGender = "BOTH"
                Else
                    strGender = ""
                End If

                If intMemberID = 8401116 Then
                    intMemberID = Me.cboSchools.SelectedValue
                Else
                    intMemberID -= 1234
                End If

            Catch ex As Exception
                intMemberID = -1
                strEmail = ""
            End Try

        Else

            lblMessage.Text = "This site is currently unavailable.  Please check back soon..."
            Exit Sub
        End If

        strInvalidCodeMessage = "Invalid code."

        If intMemberID <= 0 Then
            Me.lblMessage.Text = "Invalid school."
        ElseIf strGender <> "Boys" And strGender <> "Girls" And strGender <> "BOTH" Then
            Me.lblMessage.Text = "Invalid Gender."
        Else
            If strGender = "Boys" Or strGender = "BOTH" Then
                strSQL = "SELECT TOP 1 teamID FROM allCoachesDetail WHERE MemberID = " & intMemberID & " AND sportID Like 'BasketballBoys%' AND intYear = " & clsFunctions.GetCurrentYear
                intBoysID = SqlHelper.ExecuteScalar(SQLHelper.SQLConnection, CommandType.Text, strSQL)
            End If
            If strGender = "Girls" Or strGender = "BOTH" Then
                strSQL = "SELECT TOP 1 teamID FROM allCoachesDetail WHERE MemberID = " & intMemberID & " AND sportID Like 'BasketballGirls%' AND intYear = " & clsFunctions.GetCurrentYear
                intGirlsID = SqlHelper.ExecuteScalar(SQLHelper.SQLConnection, CommandType.Text, strSQL)
            End If

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
                Session("CoachId") = intBoysID
            End If

            strSQL = "SELECT * FROM allCoachesDetail WHERE teamID = " & Session("CoachId")
            ds = SqlHelper.ExecuteDataset(SQLHelper.SQLConnection, CommandType.Text, strSQL)

            If ds Is Nothing Then
                lblMessage.Text = strInvalidCodeMessage
            ElseIf ds.Tables.Count = 0 Then
                lblMessage.Text = strInvalidCodeMessage
            ElseIf ds.Tables(0).Rows.Count = 0 Then
                lblMessage.Text = strInvalidCodeMessage
            Else
                With ds.Tables(0).Rows(0)
                    Session("intSchoolID") = .Item("schoolID")
                    Session("CoachName") = .Item("FirstName") & " " & .Item("LastName")
                    Session("SchoolName") = .Item("SchoolName")
                    Session("SchoolID") = .Item("schoolID")
                    Session("user") = strEmail
                End With
                Response.Redirect("BBMainMenu.aspx")
            End If

        End If

    End Sub

    Protected Sub cmdLogin_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLogin.Click

        DoLogin2()

    End Sub

End Class