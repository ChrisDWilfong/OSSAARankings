Public Class PlayoffAvailabilityWR
    Inherits System.Web.UI.Page

    Public objDashboard As clsDashboard

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'If Session("OSSAAID") Is Nothing Then
        '    Response.Redirect("LoginBBO.aspx")
        'ElseIf Session("user") = "" Then
        '    Response.Redirect("LoginBBO.aspx")
        'End If

        objDashboard = New clsDashboard("PLAYOFFAVAIL", "Wrestling", clsFunctions.GetCurrentYear)

        If Session("user") = "" Then
            Response.Redirect(objDashboard.gLoginPage)
        End If

        If Not IsPostBack Then
            Session.Timeout = 40
            LoadData(Session("OSSAAID"))
            ' 1/5/2018 changed...
            'Me.lblMessage.Text = "The OSSAA must have your Part 1 scores (>=74), concussion and record of your attendance of the State Rules Meeting in order for you to be eligible for playoffs."
            Me.lblMessage.Text = "Please make selections below."
            LoadLabels()
        End If

    End Sub


    Private Sub LoadLabels()

        lblWeek1.Text = objDashboard.gTourney101
        lblWeek2.Text = objDashboard.gTourney102
        lblWeek3.Text = objDashboard.gTourney103

    End Sub

    Private Sub cboTeamConflict1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTeamConflict1.DataBound
        Dim objItem As New System.Web.UI.WebControls.ListItem
        objItem.Value = 0
        objItem.Text = "Select Team..."
        cboTeamConflict1.Items.Insert(0, objItem)
    End Sub

    Private Sub cboTeamConflict2_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTeamConflict2.DataBound
        Dim objItem As New System.Web.UI.WebControls.ListItem
        objItem.Value = 0
        objItem.Text = "Select Team..."
        cboTeamConflict2.Items.Insert(0, objItem)
    End Sub

    Private Sub cboTeamConflict3_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTeamConflict3.DataBound
        Dim objItem As New System.Web.UI.WebControls.ListItem
        objItem.Value = 0
        objItem.Text = "Select Team..."
        cboTeamConflict3.Items.Insert(0, objItem)
    End Sub

    Private Sub cboTeamConflict4_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTeamConflict4.DataBound
        Dim objItem As New System.Web.UI.WebControls.ListItem
        objItem.Value = 0
        objItem.Text = "Select Team..."
        cboTeamConflict4.Items.Insert(0, objItem)
    End Sub

    Private Sub cboTeamConflict5_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTeamConflict5.DataBound
        Dim objItem As New System.Web.UI.WebControls.ListItem
        objItem.Value = 0
        objItem.Text = "Select Team..."
        cboTeamConflict5.Items.Insert(0, objItem)
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

#Region "Functions"

    Public Function SaveData(ByVal intOSSAAID As Integer) As String
        Dim strReturn As String = "OK"
        Dim strSQL As String

        strReturn = VerifyData()

        If strReturn = "OK" Then
            strSQL = "UPDATE prodOfficialsPlayoffsWR SET "

            If cbLevel1.Checked Then
                strSQL = strSQL & "intLevel1None = 1, "
            Else
                strSQL = strSQL & "intLevel1None = 0, "
            End If
            If cbLevel2.Checked Then
                strSQL = strSQL & "intLevel2DualState = 1, "
            Else
                strSQL = strSQL & "intLevel2DualState = 0, "
            End If
            If cbLevel3.Checked Then
                strSQL = strSQL & "intLevel3Regionals = 1, "
            Else
                strSQL = strSQL & "intLevel3Regionals = 0, "
            End If
            If cbLevel4.Checked Then
                strSQL = strSQL & "intLevel4State = 1, "
            Else
                strSQL = strSQL & "intLevel4State = 0, "
            End If

            strSQL = strSQL & "strHSGames = '" & Me.cboHSGames.SelectedValue & "', "

            ' Availability...
            strSQL = strSQL & "intPlayoffAvail01 = " & cboSessionDualState.SelectedValue & ", "
            strSQL = strSQL & "intPlayoffAvail02 = " & cboSessionRegionals.SelectedValue & ", "
            strSQL = strSQL & "intPlayoffAvail03 = " & cboSessionState.SelectedValue & ", "

            strSQL = strSQL & "intSchoolIDConflict1 = " & Me.cboTeamConflict1.SelectedValue & ", "
            If Me.cboTeamConflict1.SelectedValue > 0 Then
                strSQL = strSQL & "strSchoolConflict1 = '" & Me.cboTeamConflict1.SelectedItem.ToString & "', "
            End If
            strSQL = strSQL & "intSchoolIDConflict2 = " & Me.cboTeamConflict2.SelectedValue & ", "
            If Me.cboTeamConflict2.SelectedValue > 0 Then
                strSQL = strSQL & "strSchoolConflict2 = '" & Me.cboTeamConflict2.SelectedItem.ToString & "', "
            End If
            strSQL = strSQL & "intSchoolIDConflict3 = " & Me.cboTeamConflict3.SelectedValue & ", "
            If Me.cboTeamConflict3.SelectedValue > 0 Then
                strSQL = strSQL & "strSchoolConflict3 = '" & Me.cboTeamConflict3.SelectedItem.ToString & "', "
            End If
            strSQL = strSQL & "intSchoolIDConflict4 = " & Me.cboTeamConflict4.SelectedValue & ", "
            If Me.cboTeamConflict4.SelectedValue > 0 Then
                strSQL = strSQL & "strSchoolConflict4 = '" & Me.cboTeamConflict4.SelectedItem.ToString & "', "
            End If
            If Me.cboTeamConflict5.SelectedValue > 0 Then
                strSQL = strSQL & "strSchoolConflict5 = '" & Me.cboTeamConflict5.SelectedItem.ToString & "', "
            End If
            strSQL = strSQL & "intSchoolIDConflict5 = " & Me.cboTeamConflict5.SelectedValue & " "

            strSQL = strSQL & " WHERE intOSSAAID = " & intOSSAAID & " AND intYear = " & clsFunctions.GetCurrentYear

            Try
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
                strReturn = "Changes Saved."
            Catch
                strReturn = "FAILED"
            End Try

            If 1 = 2 Then
                clsEmail.SendEmail(Me, strReturn & " : " & strSQL, "cwilfong@ossaa.com", "", "WR Officials Availability : " & intOSSAAID & " (" & Session("OfficialName") & ")")
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

        strSQL = "SELECT * FROM prodOfficialsPlayoffsWR WHERE intOSSAAID = " & intOSSAAID & " AND intYear = " & clsFunctions.GetCurrentYear
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

                ' Playoff Level...
                Me.cbLevel1.Checked = .Item("intLevel1None")
                Me.cbLevel2.Checked = .Item("intLevel2DualState")
                Me.cbLevel3.Checked = .Item("intLevel3Regionals")
                Me.cbLevel4.Checked = .Item("intLevel4State")

                Me.cboHSGames.SelectedValue = .Item("strHSGames")

                Me.cboSessionDualState.SelectedValue = .Item("intPlayoffAvail01")
                Me.cboSessionRegionals.SelectedValue = .Item("intPlayoffAvail02")
                Me.cboSessionState.SelectedValue = .Item("intPlayoffAvail03")

                If .Item("intSchoolIDConflict1") > 0 Then
                    Me.cboTeamConflict1.SelectedValue = .Item("intSchoolIDConflict1")
                End If
                If .Item("intSchoolIDConflict2") > 0 Then
                    Me.cboTeamConflict2.SelectedValue = .Item("intSchoolIDConflict2")
                End If
                If .Item("intSchoolIDConflict3") > 0 Then
                    Me.cboTeamConflict3.SelectedValue = .Item("intSchoolIDConflict3")
                End If
                If .Item("intSchoolIDConflict4") > 0 Then
                    Me.cboTeamConflict4.SelectedValue = .Item("intSchoolIDConflict4")
                End If
                If .Item("intSchoolIDConflict5") > 0 Then
                    Me.cboTeamConflict5.SelectedValue = .Item("intSchoolIDConflict5")
                End If

            End With

        End If

        Return strReturn

    End Function

    Public Sub CreateRecord(ByVal intOSSAAID As Integer, ByVal strPlayoffCrewName As String)
        Dim strSQL As String

        strSQL = "INSERT INTO " & objDashboard.gTableSource & " (intOSSAAID, strSport, intYear) VALUES (" & intOSSAAID & ", 'WR', " & clsOfficials.GetDefaultYear & ")"
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

    End Sub

    Public Function VerifyData() As String
        Dim strReturn As String = "OK"

        If cboHSGames.SelectedValue = "Select..." Then
            strReturn = "You must select : Number of High School Dates worked THIS SEASON."
        Else
            strReturn = "OK"
        End If


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