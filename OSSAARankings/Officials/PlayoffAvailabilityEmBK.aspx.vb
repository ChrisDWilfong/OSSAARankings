Public Class PlayoffAvailabilityEmBK
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("OSSAAID") Is Nothing Then
            Response.Redirect("LoginBBO.aspx")
        ElseIf Session("user") = "" Then
            Response.Redirect("LoginBBO.aspx")
        End If

        If Not IsPostBack Then
            Session.Timeout = 40
            LoadData(Session("OSSAAID"))
            Me.lblMessage.Text = "The OSSAA must have your Part 1 (>=74) and Part 2 scores, Concussion and Heat certificates in order for you to be eligible for playoffs."
        End If

    End Sub


    Protected Sub cmdSave1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSave1.Click
        Dim strReturn As String
        strReturn = SaveData(Session("OSSAAID"))
        If strReturn = "OK" Then
        Else
            Me.lblMessage.Text = strReturn
        End If
    End Sub

    Protected Sub cmdSave2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSave2.Click
        Dim strReturn As String
        strReturn = SaveData(Session("OSSAAID"))
        If strReturn = "OK" Then
        Else
            Me.lblMessage.Text = strReturn
        End If
    End Sub

    Protected Sub cmdGoBack_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdGoBack.Click
        Response.Redirect("BBMainMenu.aspx")
    End Sub

#Region "Functions"

    Public Function SaveData(ByVal intOSSAAID As Integer) As String
        Dim strReturn As String = "OK"
        Dim strSQL As String

        strReturn = VerifyData()

        If strReturn = "OK" Then
            strSQL = "UPDATE prodOfficialsPlayoffsBB SET "

            ' Availability...
            strSQL = strSQL & "intPlayoffAvail15 = " & cboSessionW3D1.SelectedValue & ", "
            strSQL = strSQL & "intPlayoffAvail16 = " & cboSessionW3D2.SelectedValue & ", "
            strSQL = strSQL & "intPlayoffAvail17 = " & cboSessionW3D3.SelectedValue

            strSQL = strSQL & " WHERE intOSSAAID = " & intOSSAAID & " AND intYear = " & clsFunctions.GetCurrentYear

            Try
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
                strReturn = "Changes Saved."
            Catch
                strReturn = "FAILED"
            End Try

            If 1 = 2 Then
                clsEmail.SendEmail(Me, strReturn & " : " & strSQL, "cwilfong@ossaa.com", "", "Officials Availability : " & intOSSAAID & " (" & Session("OfficialName") & ")")
                clsEmail.SendEmail(Me, strReturn & " : " & strSQL, "sriddell@ossaa.com", "", "Officials Availability : " & intOSSAAID & " (" & Session("OfficialName") & ")")
            End If

        Else
                ' Return message...
            End If

        Return strReturn

    End Function

    Public Function LoadData(ByVal intOSSAAID As Integer) As String
        On Error Resume Next
        Dim strReturn As String = "OK"
        Dim strSQL As String
        Dim ds As DataSet
        Dim e As Object

        strSQL = "SELECT * FROM prodOfficialsPlayoffsBB WHERE intOSSAAID = " & intOSSAAID & " AND intYear = " & clsFunctions.GetCurrentYear
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

        If ds Is Nothing Then
            CreateRecord(Session("OSSAAID"), Session("OfficialName"))
        ElseIf ds.Tables.Count = 0 Then
            CreateRecord(Session("OSSAAID"), Session("OfficialName"))
        ElseIf ds.Tables(0).Rows.Count = 0 Then
            CreateRecord(Session("OSSAAID"), Session("OfficialName"))
        Else
            ' Load info...
            With ds.Tables(0).Rows(0)

                Me.cboSessionW3D1.SelectedValue = .Item("intPlayoffAvail15")
                Me.cboSessionW3D2.SelectedValue = .Item("intPlayoffAvail16")
                Me.cboSessionW3D3.SelectedValue = .Item("intPlayoffAvail17")

            End With

        End If

        Return strReturn

    End Function

    Public Sub CreateRecord(ByVal intOSSAAID As Integer, ByVal strPlayoffCrewName As String)
        Dim strSQL As String

        strSQL = "INSERT INTO prodOfficialsPlayoffsBB (intOSSAAID, strSport, intYear) VALUES (" & intOSSAAID & ", 'BB', " & clsOfficials.GetDefaultYear & ")"
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

    End Sub

    Public Function VerifyData() As String
        Dim strReturn As String = "OK"
        Return strReturn
    End Function

    Public Function ParseString(ByVal strIn As Object) As String
        Dim strTemp As String = ""

        Try
            strTemp = strIn
            strTemp = strTemp.Replace("'", "")
            strTemp = strTemp.Replace("""", "")
            strTemp = strTemp.Replace("DELETE", "")
            strTemp = strTemp.Replace("SELECT ", "")
            strTemp = strTemp.Replace("INSERT INTO ", "")
        Catch

        End Try

        Return strTemp
    End Function
#End Region

End Class