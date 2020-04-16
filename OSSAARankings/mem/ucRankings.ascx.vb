Partial Class ucRankings
    Inherits System.Web.UI.UserControl

    Public gNumOfTeams As Integer
    Dim strSportIDLocal As String
    Dim strSportGenderKeyLocal As String

    Public Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("memgUsername") = "" Then
            Response.Redirect("Login.aspx")
        End If

        If Session("event") = "EnterRankings" Or Session("event") = "EnterRankings1" Or Session("event") = "EnterRankings8" Or Session("event") = "EnterRankingsEW" Then

            ' Also Update RankingsPrevious.aspx and RankingsOthers.aspx...
            If Session("event") = "EnterRankings1" Or (Session("event") = "EnterRankings8" And Not Session("memgSportID1") Is Nothing) Then
                ' Get the dual sportID...
                If InStr(Session("memgSportID"), "Wrestling") > 0 Then      ' CDW added 10/6/2019...
                    strSportIDLocal = Session("memgSportID1")
                    strSportGenderKeyLocal = Session("memgSportGenderKey1")
                Else
                    strSportIDLocal = Session("memgSportID")
                    strSportGenderKeyLocal = Session("memgSportGenderKey")
                End If
            Else
                If Session("memgSportID") Is Nothing Then
                    strSportIDLocal = ""
                    strSportGenderKeyLocal = ""
                Else
                    strSportIDLocal = Session("memgSportID")
                    strSportGenderKeyLocal = Session("memgSportGenderKey")
                End If
            End If

            ' Added 8/27/2013...
            If Session("inRankings") Is Nothing Then
                Session("inRankings") = 1
            End If

            Select Case Session("memsel")
                Case "RankingsTeam"
                    PanelScheduleTeam.Visible = True
                Case Else
                    PanelScheduleTeam.Visible = False
            End Select

            RefreshRankingsInfo()

            ' Count the Records...
            Dim intCount As Integer = 0
            Dim ds1 As DataSet = clsRankings.GetRankingsForCoachDS(Session("memgCurrentWeekIDPeriod"), Session("memgTeamID"), Session("memgSplitWeek"), Session("event"))
            If ds1 Is Nothing Then
            ElseIf ds1.Tables.Count = 0 Then
            ElseIf ds1.Tables(0).Rows.Count = 0 Then
            Else
                intCount = ds1.Tables(0).Rows.Count - 1
            End If

            If Session("memgCurrentWeekIDRank") = 0 Then
                cmdContinue.Visible = False
                lblClickOnce.Visible = False
                cmdCancel.Visible = False
                ' RANKINGS ARE CLOSED...
                lblMessage.Text = "Enter Rankings are currently unavailable.&nbsp;<a href='Hoaspx?sel=RankingsSchedule'>Click Here For Schedule</a>"
                If Session("memgCurrentWeekIDDisplay") > 0 Then
                    LoadSubmittedRankings(ds1, True, 0)
                Else
                    TurnOnOffObjects(False, False)
                End If
            Else
                ' RANKINGS ARE OPEN...
                ' See if rankings have already been submitted...
                cmdContinue.Visible = True
                lblClickOnce.Visible = True
                cmdCancel.Visible = True
                LoadSubmittedRankings(ds1, False, Session("memgRankingsThisSeason"))
            End If

        Else

        End If

        ' Let's refresh the Unranked...         1/19/2015...
        LoadLastWeeksRankings(False)
        lblLastWeeks.Text = LastWeeksRankingsString()

    End Sub


    Public Sub RefreshRankingsInfo()

        If clsRankings.ShowRankingsStatus = False Then
            Session("memgCurrentWeekIDRank") = 0
            Session("memgCurrentWeekIDDisplay") = 0
            Session("memgCurrentWeekIDPeriod") = 0
            Session("memgCurrentWeekID12to4") = 0
            Session("memgRankingsThisSeason") = 0
            Session("memgCurrentWeekNoDisplay") = 0
            Session("memgCurrentWeekNoRank") = 0
            Session("memgPreviousWeekID") = 0
            Session("memgRankingsStatus") = ""
            Session("memgSplitWeek") = 0
            Session("memgSplitWeek12to4") = 0
            Session("memgSplitWeekDisplay") = 0
        Else
            If strSportIDLocal = "" Then
                Session("memgCurrentWeekIDRank") = 0
                Session("memgCurrentWeekIDDisplay") = 0
                Session("memgCurrentWeekIDPeriod") = 0
                Session("memgCurrentWeekID12to4") = 0
                Session("memgRankingsThisSeason") = 0
            Else
                Session("memgCurrentWeekIDRank") = clsRankings.GetCurrentRankingWeekIDRankingWindow(strSportIDLocal, Now.ToString)
                Session("memgCurrentWeekIDDisplay") = clsRankings.GetCurrentRankingWeekIDDisplayWindow(strSportIDLocal, Now.ToString)
                Session("memgCurrentWeekIDPeriod") = clsRankings.GetCurrentRankingWeekIDPeriodWindow(strSportIDLocal, Now.ToString)
                Session("memgCurrentWeekID12to4") = clsRankings.GetCurrentRankingWeekID12to4(strSportIDLocal, Now.ToString)
                Session("memgRankingsThisSeason") = clsRankings.GetCurrentRankCount(Session("memgTeamID"))
            End If
            Session("memgCurrentWeekNoDisplay") = clsRankings.GetCurrentRankingintWeekNo(Session("memgCurrentWeekIDDisplay"))
            Session("memgCurrentWeekNoRank") = clsRankings.GetCurrentRankingintWeekNo(Session("memgCurrentWeekIDRank"))
            Session("memgPreviousWeekID") = clsRankings.GetPreviousRankingWeekID(strSportIDLocal, clsFunctions.GetCurrentYear, Session("memgCurrentWeekNoDisplay"))
            Session("memgRankingsStatus") = clsRankings.GetRankingsStatus(strSportIDLocal, Session("memgTeamID"), Session("memgCurrentWeekIDRank"), Session("memgCurrentWeekIDDisplay"), Session("memgCurrentWeekIDPeriod"), Session("memgCurrentWeekNoRank"), Session("memgCurrentWeekNoDisplay"), Session("memgPreviousWeekID"), Session("memgCurrentWeekID12to4"), Session("memgRankingsThisSeason"), Session("event"))
            Session("memgSplitWeek") = clsRankings.GetSplitWeek(Session("memgCurrentWeekIDRank"))
            Session("memgSplitWeek12to4") = clsRankings.GetSplitWeek(Session("memgCurrentWeekID12to4"))
            Session("memgSplitWeekDisplay") = clsRankings.GetSplitWeek(Session("memgCurrentWeekIDDisplay"))
        End If
    End Sub

    Public Sub EnableObjects(ysnEnabled As Boolean)
        cboTeam1.Enabled = ysnEnabled
        cboTeam2.Enabled = ysnEnabled
        cboTeam3.Enabled = ysnEnabled
        cboTeam4.Enabled = ysnEnabled
        cboTeam5.Enabled = ysnEnabled
        cboTeam6.Enabled = ysnEnabled
        cboTeam7.Enabled = ysnEnabled
        cboTeam8.Enabled = ysnEnabled
        cboTeam9.Enabled = ysnEnabled
        cboTeam10.Enabled = ysnEnabled
        cboTeam11.Enabled = ysnEnabled
        cboTeam12.Enabled = ysnEnabled
        cboTeam13.Enabled = ysnEnabled
        cboTeam14.Enabled = ysnEnabled
        cboTeam15.Enabled = ysnEnabled
        cboTeam16.Enabled = ysnEnabled
        cboTeam17.Enabled = ysnEnabled
        cboTeam18.Enabled = ysnEnabled
        cboTeam19.Enabled = ysnEnabled
        cboTeam20.Enabled = ysnEnabled
    End Sub

    Public Sub LoadSubmittedRankings(ByVal ds1 As DataSet, ByVal ysnRankingsEntryClosed As Boolean, ByVal intWeeksRanked As Integer)
        ' CLEAN THIS LOGIC UP!!! IT IS A MESS!!!

        ' Let's see if the user is locked out...
        Dim ysnLockedOut As Boolean = False
        Dim intLockoutValue As Integer = 0

        ' Get the Lockout value from RankingsWeeks for the selected week...
        intLockoutValue = clsRankings.GetLockoutCount(Session("memgCurrentWeekIDRank"), Session("memgSport"), Session("memgTeamID"), Session("event"))

        ' Compare the Weeks ranked to the Lockout value...
        If intLockoutValue = 0 Then
            ysnLockedOut = False
        Else
            If intWeeksRanked < intLockoutValue Then
                ysnLockedOut = True
            Else
                ysnLockedOut = False
            End If
        End If

        ' Get the number of teams to be ranked...
        Try
            gNumOfTeams = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT NumberOfRankings FROM tblSports WHERE sportID = '" & strSportIDLocal & "'")
        Catch
            gNumOfTeams = 20
        End Try
        If Session("event") = "EnterRankings8" Then
            If Session("memgSport") = "Volleyball" Or Session("memgSport") = "FPSoftball" Then
                gNumOfTeams = 7     ' You cannot rank yourself...
            Else
                gNumOfTeams = 8
            End If
        ElseIf Session("event") = "EnterRankingsEW" Then
            gNumOfTeams = 15
        End If
        TurnOnOffObjects(True, False)

        If Session("event") = "EnterRankings8" Then
            If Session("memgSport") = "Volleyball" Then
                lblMessage.Text = "Volleyball - State Qualifier Rankings"
            ElseIf Session("memgSport") = "FPSoftball" Then     ' CDW added 9/27/2019...
                lblMessage.Text = "Fast Pitch - State Qualifier Rankings"
            Else
                lblMessage.Text = "Wrestling Dual - 8 Rankings"
            End If
        ElseIf Session("event") = "EnterRankingsEW" Then
            lblMessage.Text = "Basketball East-West Rankings"
        Else
            lblMessage.Text = ""
        End If

        ' Now load the data...
        Dim objTeamID As New ArrayList
        Dim objSchool As New ArrayList
        Dim x As Integer

        For x = 0 To ds1.Tables(0).Rows.Count - 1
            objTeamID.Add(ds1.Tables(0).Rows(x).Item("teamID"))
            objSchool.Add(ds1.Tables(0).Rows(x).Item("School"))
        Next

        If Session("memarrTeamID") Is Nothing Or Session("RefreshRankingsList") = 1 Then        ' 11/27/2013 added RefreshRankingsList...
            Session("memarrSchool") = objSchool
            Session("memarrTeamID") = objTeamID
        End If

        If Session("RefreshRankingsList") = 1 Then
            Session("memdsClassTeams") = Nothing
            LoadDropDowns()
        End If
        Session("RefreshRankingsList") = 0

        If Not IsPostBack Then
            LoadDropDowns()
        ElseIf cboTeam1.Items.Count < 2 Then
            LoadDropDowns()
        End If

        If ysnLockedOut Then
            If (Session("memgSport") = "Volleyball" Or Session("memgSport") = "FPSoftball") And intLockoutValue = 99 Then   ' CDW added FPSoftball on 9/26/2019...
                lblHeader.Text = "RANKINGS ARE ONLY AVAILABLE FOR STATE QUALIFYING COACHES."
            Else
                lblHeader.Text = "RANKINGS ARE UNAVAILABLE DUE TO LOCKOUT PERIOD."
            End If
            rowButton.Visible = False
            'cmdPreviousWeeks.Visible = False           ' Removed 11/28/2016...
            TurnOnOffObjects(True, False)
            EnableObjects(False)
            Dim sql As String = "INSERT INTO tblLockout (sportID, memberID, teamID, weekID, numWeeksVoted, numLockoutValue) VALUES ('" & strSportIDLocal & "', " & Session("memgMemberID") & ", " & Session("memgTeamID") & ", " & Session("memgCurrentWeekIDRank") & ", " & intWeeksRanked & ", " & intLockoutValue & ")"
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, sql)
        Else
            ' Now enable and hide objects...
            If ds1.Tables(0).Rows.Count = 0 Then        ' No Rankings submitted...
                If Session("memgCurrentWeekNoRank") > 0 Then
                    lblHeader.Text = "NO RANKINGS CONFIRMED FOR WEEK #" & Session("memgCurrentWeekNoRank")
                Else
                    If Session("memgCurrentWeekID12to4") > 0 Then           ' 9/5/2013 added...
                        lblHeader.Text = "NO RANKINGS CONFIRMED FOR THIS WEEK"
                    Else
                        lblHeader.Text = "NO RANKINGS CONFIRMED FOR WEEK #" & Session("memgCurrentWeekNoDisplay")
                    End If
                End If
                If ysnRankingsEntryClosed Then
                    rowButton.Visible = False
                    ' cmdPreviousWeeks.Visible = False
                    TurnOnOffObjects(True, False)
                    EnableObjects(False)
                Else
                    rowButton.Visible = True
                    TurnOnOffObjects(True, False)
                    EnableObjects(True)
                End If
            Else
                If Session("memgCurrentWeekNoRank") > 0 Then
                    lblHeader.Text = "CONFIRMED RANKINGS FOR WEEK #" & Session("memgCurrentWeekNoRank")
                Else
                    If Session("memgCurrentWeekID12to4") > 0 Then
                        lblHeader.Text = "CONFIRMED RANKINGS FOR THIS WEEK"
                    Else
                        lblHeader.Text = "CONFIRMED RANKINGS FOR WEEK #" & Session("memgCurrentWeekNoDisplay")
                    End If
                End If
                rowButton.Visible = False
                'cmdPreviousWeeks.Visible = False
                TurnOnOffObjects(True, False)
                EnableObjects(False)
            End If
        End If

    End Sub

    Public Sub TurnOnOffObjects(ysnVisible As Boolean, ysnAll As Boolean)

        cboTeam1.Visible = ysnVisible
        cboTeam2.Visible = ysnVisible
        cboTeam3.Visible = ysnVisible
        cboTeam4.Visible = ysnVisible
        cboTeam5.Visible = ysnVisible
        cboTeam6.Visible = ysnVisible
        cboTeam7.Visible = ysnVisible
        cboTeam8.Visible = ysnVisible

        imgSchedule1.Visible = ysnVisible
        imgSchedule2.Visible = ysnVisible
        imgSchedule3.Visible = ysnVisible
        imgSchedule4.Visible = ysnVisible
        imgSchedule5.Visible = ysnVisible
        imgSchedule6.Visible = ysnVisible
        imgSchedule7.Visible = ysnVisible
        imgSchedule8.Visible = ysnVisible

        Label1.Visible = ysnVisible
        Label2.Visible = ysnVisible
        Label3.Visible = ysnVisible
        Label4.Visible = ysnVisible
        Label5.Visible = ysnVisible
        Label6.Visible = ysnVisible
        Label7.Visible = ysnVisible
        Label8.Visible = ysnVisible

        If gNumOfTeams > 8 Or ysnAll Then                 ' 1/27/2014 added...
            cboTeam9.Visible = ysnVisible
            cboTeam10.Visible = ysnVisible
            cboTeam11.Visible = ysnVisible
            cboTeam12.Visible = ysnVisible
            imgSchedule9.Visible = ysnVisible
            imgSchedule10.Visible = ysnVisible
            imgSchedule11.Visible = ysnVisible
            imgSchedule12.Visible = ysnVisible
            Label9.Visible = ysnVisible
            Label10.Visible = ysnVisible
            Label11.Visible = ysnVisible
            Label12.Visible = ysnVisible

            If gNumOfTeams > 12 Or ysnAll Then                ' 11/4/2013 added...
                cboTeam13.Visible = ysnVisible
                cboTeam14.Visible = ysnVisible
                cboTeam15.Visible = ysnVisible
                imgSchedule13.Visible = ysnVisible
                imgSchedule14.Visible = ysnVisible
                imgSchedule15.Visible = ysnVisible
                Label13.Visible = ysnVisible
                Label14.Visible = ysnVisible
                Label15.Visible = ysnVisible

                If gNumOfTeams > 15 Or ysnAll Then
                    cboTeam16.Visible = ysnVisible
                    imgSchedule16.Visible = ysnVisible
                    Label16.Visible = ysnVisible

                    If gNumOfTeams > 16 Then
                        cboTeam17.Visible = ysnVisible
                        cboTeam18.Visible = ysnVisible
                        cboTeam19.Visible = ysnVisible
                        cboTeam20.Visible = ysnVisible

                        imgSchedule17.Visible = ysnVisible
                        imgSchedule18.Visible = ysnVisible
                        imgSchedule19.Visible = ysnVisible
                        imgSchedule20.Visible = ysnVisible

                        Label17.Visible = ysnVisible
                        Label18.Visible = ysnVisible
                        Label19.Visible = ysnVisible
                        Label20.Visible = ysnVisible
                    Else
                        cboTeam17.Visible = False
                        cboTeam18.Visible = False
                        cboTeam19.Visible = False
                        cboTeam20.Visible = False
                        imgSchedule17.Visible = False
                        imgSchedule18.Visible = False
                        imgSchedule19.Visible = False
                        imgSchedule20.Visible = False
                        Label17.Visible = False
                        Label18.Visible = False
                        Label19.Visible = False
                        Label20.Visible = False
                    End If

                Else
                    cboTeam16.Visible = False
                    cboTeam17.Visible = False
                    cboTeam18.Visible = False
                    cboTeam19.Visible = False
                    cboTeam20.Visible = False
                    imgSchedule16.Visible = False
                    imgSchedule17.Visible = False
                    imgSchedule18.Visible = False
                    imgSchedule19.Visible = False
                    imgSchedule20.Visible = False
                    Label16.Visible = False
                    Label17.Visible = False
                    Label18.Visible = False
                    Label19.Visible = False
                    Label20.Visible = False
                End If
            Else
                cboTeam13.Visible = False
                cboTeam14.Visible = False
                cboTeam15.Visible = False
                cboTeam16.Visible = False
                cboTeam17.Visible = False
                cboTeam18.Visible = False
                cboTeam19.Visible = False
                cboTeam20.Visible = False
                imgSchedule13.Visible = False
                imgSchedule14.Visible = False
                imgSchedule15.Visible = False
                imgSchedule16.Visible = False
                imgSchedule17.Visible = False
                imgSchedule18.Visible = False
                imgSchedule19.Visible = False
                imgSchedule20.Visible = False
                Label13.Visible = False
                Label14.Visible = False
                Label15.Visible = False
                Label16.Visible = False
                Label17.Visible = False
                Label18.Visible = False
                Label19.Visible = False
                Label20.Visible = False
            End If
        Else
            If gNumOfTeams = 7 Then     ' you can't rank yourself...
                cboTeam8.Visible = False
                imgSchedule8.Visible = False
                Label8.Visible = False
            End If
            cboTeam9.Visible = False
            cboTeam10.Visible = False
            cboTeam11.Visible = False
            cboTeam12.Visible = False
            cboTeam13.Visible = False
            cboTeam14.Visible = False
            cboTeam15.Visible = False
            cboTeam16.Visible = False
            cboTeam17.Visible = False
            cboTeam18.Visible = False
            cboTeam19.Visible = False
            cboTeam20.Visible = False
            imgSchedule9.Visible = False
            imgSchedule10.Visible = False
            imgSchedule11.Visible = False
            imgSchedule12.Visible = False
            imgSchedule13.Visible = False
            imgSchedule14.Visible = False
            imgSchedule15.Visible = False
            imgSchedule16.Visible = False
            imgSchedule17.Visible = False
            imgSchedule18.Visible = False
            imgSchedule19.Visible = False
            imgSchedule20.Visible = False
            Label9.Visible = False
            Label10.Visible = False
            Label11.Visible = False
            Label12.Visible = False
            Label13.Visible = False
            Label14.Visible = False
            Label15.Visible = False
            Label16.Visible = False
            Label17.Visible = False
            Label18.Visible = False
            Label19.Visible = False
            Label20.Visible = False
        End If
    End Sub

    Private Function LoadLastWeeksRankings(ysnLoadLastWeeks As Boolean) As String
        ' Added 4/17/2013...12/18/2009...
        Dim objTeamID As New ArrayList
        Dim objSchool As New ArrayList
        Dim ds As DataSet
        Dim intLastWeekRankID As Long
        Dim x As Integer
        Dim strReturn As String = "OK"

        intLastWeekRankID = Session("memgPreviousWeekID")

        If intLastWeekRankID > 0 Then
            ds = clsRankings.GetRankingsForCoachDS(intLastWeekRankID, Session("memgTeamID"), Session("memgSplitWeek"), Session("event"))
            If ds Is Nothing Then
                strReturn = "No rankings submitted last week."
            ElseIf ds.Tables.Count = 0 Then
                strReturn = "No rankings submitted last week."
            ElseIf ds.Tables(0).Rows.Count = 0 Then
                strReturn = "No rankings submitted last week."
            Else
                For x = 0 To ds.Tables(0).Rows.Count - 1
                    objTeamID.Add(ds.Tables(0).Rows(x).Item("teamID"))
                    objSchool.Add(ds.Tables(0).Rows(x).Item("school"))
                Next
                If ysnLoadLastWeeks Then
                    Session("memarrTeamID") = objTeamID
                Else
                    Session("memarrSchoolLW") = objSchool
                    Session("memarrTeamIDLW") = objTeamID
                End If
            End If
        Else
            strReturn = "Rankings information unavailable."
        End If

        Return strReturn

    End Function

    Public Function LastWeeksRankingsString() As String
        ' Get last weeks rankings, pull out the current selected rankings and return the string...
        Dim strResult As String = ""
        Dim x As Integer
        '''''Dim y As Integer
        Dim objTeamIDLW As New ArrayList
        Dim objSchoolID As New ArrayList
        Dim intMatch As Integer = 0

        objTeamIDLW = Session("memarrTeamIDLW")
        objSchoolID = Session("memarrSchoolLW")

        If objTeamIDLW Is Nothing Then
            strResult = "<strong>LAST WEEKS RANKINGS YOU SUBMITTED</strong><br>- None submitted."
        Else
            strResult = "<strong>LAST WEEKS RANKINGS YOU SUBMITTED</strong><br>"
            For x = 0 To objTeamIDLW.Count - 1
                intMatch = 0
                If cboTeam1.Visible Then
                    If cboTeam1.SelectedIndex <= 0 Then
                    Else
                        If cboTeam1.SelectedValue = objTeamIDLW(x) Then
                            intMatch = 1
                        End If
                    End If
                End If
                If cboTeam2.Visible Then
                    If cboTeam2.SelectedIndex <= 0 Then
                    Else
                        If cboTeam2.SelectedValue = objTeamIDLW(x) Then
                            intMatch = 1
                        End If
                    End If
                End If
                If cboTeam3.Visible Then
                    If cboTeam3.SelectedIndex <= 0 Then
                    Else
                        If cboTeam3.SelectedValue = objTeamIDLW(x) Then
                            intMatch = 1
                        End If
                    End If
                End If
                If cboTeam4.Visible Then
                    If cboTeam4.SelectedIndex <= 0 Then
                    Else
                        If cboTeam4.SelectedValue = objTeamIDLW(x) Then
                            intMatch = 1
                        End If
                    End If
                End If
                If cboTeam5.Visible Then
                    If cboTeam5.SelectedIndex <= 0 Then
                    Else
                        If cboTeam5.SelectedValue = objTeamIDLW(x) Then
                            intMatch = 1
                        End If
                    End If
                End If
                If cboTeam6.Visible Then
                    If cboTeam6.SelectedIndex <= 0 Then
                    Else
                        If cboTeam6.SelectedValue = objTeamIDLW(x) Then
                            intMatch = 1
                        End If
                    End If
                End If
                If cboTeam7.Visible Then
                    If cboTeam7.SelectedIndex <= 0 Then
                    Else
                        If cboTeam7.SelectedValue = objTeamIDLW(x) Then
                            intMatch = 1
                        End If
                    End If
                End If
                If cboTeam8.Visible Then
                    If cboTeam8.SelectedIndex <= 0 Then
                    Else
                        If cboTeam8.SelectedValue = objTeamIDLW(x) Then
                            intMatch = 1
                        End If
                    End If
                End If
                If cboTeam9.Visible Then
                    If cboTeam9.SelectedIndex <= 0 Then
                    Else
                        If cboTeam9.SelectedValue = objTeamIDLW(x) Then
                            intMatch = 1
                        End If
                    End If
                End If
                If cboTeam10.Visible Then
                    If cboTeam10.SelectedIndex <= 0 Then
                    Else
                        If cboTeam10.SelectedValue = objTeamIDLW(x) Then
                            intMatch = 1
                        End If
                    End If
                End If
                If cboTeam11.Visible Then
                    If cboTeam11.SelectedIndex <= 0 Then
                    Else
                        If cboTeam11.SelectedValue = objTeamIDLW(x) Then
                            intMatch = 1
                        End If
                    End If
                End If
                If cboTeam12.Visible Then
                    If cboTeam12.SelectedIndex <= 0 Then
                    Else
                        If cboTeam12.SelectedValue = objTeamIDLW(x) Then
                            intMatch = 1
                        End If
                    End If
                End If
                If cboTeam13.Visible Then
                    If cboTeam13.SelectedIndex <= 0 Then
                    Else
                        If cboTeam13.SelectedValue = objTeamIDLW(x) Then
                            intMatch = 1
                        End If
                    End If
                End If
                If cboTeam14.Visible Then
                    If cboTeam14.SelectedIndex <= 0 Then
                    Else
                        If cboTeam14.SelectedValue = objTeamIDLW(x) Then
                            intMatch = 1
                        End If
                    End If
                End If
                If cboTeam15.Visible Then
                    If cboTeam15.SelectedIndex <= 0 Then
                    Else
                        If cboTeam15.SelectedValue = objTeamIDLW(x) Then
                            intMatch = 1
                        End If
                    End If
                End If
                If cboTeam16.Visible Then
                    If cboTeam16.SelectedIndex <= 0 Then
                    Else
                        If cboTeam16.SelectedValue = objTeamIDLW(x) Then
                            intMatch = 1
                        End If
                    End If
                End If
                If cboTeam17.Visible Then
                    If cboTeam17.SelectedIndex <= 0 Then
                    Else
                        If cboTeam17.SelectedValue = objTeamIDLW(x) Then
                            intMatch = 1
                        End If
                    End If
                End If
                If cboTeam18.Visible Then
                    If cboTeam18.SelectedIndex <= 0 Then
                    Else
                        If cboTeam18.SelectedValue = objTeamIDLW(x) Then
                            intMatch = 1
                        End If
                    End If
                End If
                If cboTeam19.Visible Then
                    If cboTeam19.SelectedIndex <= 0 Then
                    Else
                        If cboTeam19.SelectedValue = objTeamIDLW(x) Then
                            intMatch = 1
                        End If
                    End If
                End If
                If cboTeam20.Visible Then
                    If cboTeam20.SelectedIndex <= 0 Then
                    Else
                        If cboTeam20.SelectedValue = objTeamIDLW(x) Then
                            intMatch = 1
                        End If
                    End If
                End If
                If intMatch = 1 Then
                    strResult = strResult & (x + 1) & ".<br>"
                Else
                    strResult = strResult & (x + 1) & ". " & objSchoolID(x) & "<br>"
                End If
            Next
        End If

        Return strResult
    End Function

    Public Sub LoadDropDowns()
        Dim ds As DataSet

        If Session("memdsClassTeams") Is Nothing Then
            ds = clsTeams.GetSportTeamsForClass(strSportIDLocal, clsFunctions.GetCurrentYear, Session("memgTeamID"), Session("event"), Session("memgPlayoffsRegionals"))
            Session("memdsClassTeams") = ds
        ElseIf Session("memdsClassTeams").Tables(0).rows.count = 0 Then
            ds = clsTeams.GetSportTeamsForClass(strSportIDLocal, clsFunctions.GetCurrentYear, Session("memgTeamID"), Session("event"), Session("memgPlayoffsRegionals"))
            Session("memdsClassTeams") = ds
        Else
            ds = Session("memdsClassTeams")
        End If

        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            cboViewDetail.DataSource = ds
            cboViewDetail.DataBind()
            cboViewDetail.Items.Insert(0, "Select...")

            cboTeam1.DataSource = ds
            cboTeam1.DataBind()
            cboTeam1.Items.Insert(0, "Select...")

            Try
                If Not Session("memarrTeamID")(0) Is Nothing Then
                    cboTeam1.SelectedValue = Session("memarrTeamID")(0)
                    PopupControlExtender1.DynamicContextKey = Session("memarrTeamID")(0)
                End If
            Catch
            End Try

            cboTeam2.DataSource = ds
            cboTeam2.DataBind()
            cboTeam2.Items.Insert(0, "Select...")

            Try
                If Not Session("memarrTeamID")(1) Is Nothing Then
                    cboTeam2.SelectedValue = Session("memarrTeamID")(1)
                    PopupControlExtender2.DynamicContextKey = Session("memarrTeamID")(1)
                End If
            Catch
            End Try

            cboTeam3.DataSource = ds
            cboTeam3.DataBind()
            cboTeam3.Items.Insert(0, "Select...")

            Try
                If Not Session("memarrTeamID")(2) Is Nothing Then
                    cboTeam3.SelectedValue = Session("memarrTeamID")(2)
                    PopupControlExtender3.DynamicContextKey = Session("memarrTeamID")(2)
                End If
            Catch
            End Try

            cboTeam4.DataSource = ds
            cboTeam4.DataBind()
            cboTeam4.Items.Insert(0, "Select...")

            Try
                If Not Session("memarrTeamID")(3) Is Nothing Then
                    cboTeam4.SelectedValue = Session("memarrTeamID")(3)
                    PopupControlExtender4.DynamicContextKey = Session("memarrTeamID")(3)
                End If
            Catch
            End Try

            cboTeam5.DataSource = ds
            cboTeam5.DataBind()
            cboTeam5.Items.Insert(0, "Select...")

            Try
                If Not Session("memarrTeamID")(4) Is Nothing Then
                    cboTeam5.SelectedValue = Session("memarrTeamID")(4)
                    PopupControlExtender5.DynamicContextKey = Session("memarrTeamID")(4)
                End If
            Catch
            End Try

            cboTeam6.DataSource = ds
            cboTeam6.DataBind()
            cboTeam6.Items.Insert(0, "Select...")

            Try
                If Not Session("memarrTeamID")(5) Is Nothing Then
                    cboTeam6.SelectedValue = Session("memarrTeamID")(5)
                    PopupControlExtender6.DynamicContextKey = Session("memarrTeamID")(5)
                End If
            Catch
            End Try

            cboTeam7.DataSource = ds
            cboTeam7.DataBind()
            cboTeam7.Items.Insert(0, "Select...")

            Try
                If Not Session("memarrTeamID")(6) Is Nothing Then
                    cboTeam7.SelectedValue = Session("memarrTeamID")(6)
                    PopupControlExtender7.DynamicContextKey = Session("memarrTeamID")(6)
                End If
            Catch
            End Try

            cboTeam8.DataSource = ds
            cboTeam8.DataBind()
            cboTeam8.Items.Insert(0, "Select...")

            Try
                If Not Session("memarrTeamID")(7) Is Nothing Then
                    cboTeam8.SelectedValue = Session("memarrTeamID")(7)
                    PopupControlExtender8.DynamicContextKey = Session("memarrTeamID")(7)
                End If
            Catch
            End Try

            cboTeam9.DataSource = ds
            cboTeam9.DataBind()
            cboTeam9.Items.Insert(0, "Select...")

            Try
                If Not Session("memarrTeamID")(8) Is Nothing Then
                    cboTeam9.SelectedValue = Session("memarrTeamID")(8)
                    PopupControlExtender9.DynamicContextKey = Session("memarrTeamID")(8)
                End If
            Catch
            End Try

            cboTeam10.DataSource = ds
            cboTeam10.DataBind()
            cboTeam10.Items.Insert(0, "Select...")

            Try
                If Not Session("memarrTeamID")(9) Is Nothing Then
                    cboTeam10.SelectedValue = Session("memarrTeamID")(9)
                    PopupControlExtender10.DynamicContextKey = Session("memarrTeamID")(9)
                End If
            Catch
            End Try

            cboTeam11.DataSource = ds
            cboTeam11.DataBind()
            cboTeam11.Items.Insert(0, "Select...")

            Try
                If Not Session("memarrTeamID")(10) Is Nothing Then
                    cboTeam11.SelectedValue = Session("memarrTeamID")(10)
                    PopupControlExtender11.DynamicContextKey = Session("memarrTeamID")(10)
                End If
            Catch
            End Try

            cboTeam12.DataSource = ds
            cboTeam12.DataBind()
            cboTeam12.Items.Insert(0, "Select...")

            Try
                If Not Session("memarrTeamID")(11) Is Nothing Then
                    cboTeam12.SelectedValue = Session("memarrTeamID")(11)
                    PopupControlExtender12.DynamicContextKey = Session("memarrTeamID")(11)
                End If
            Catch
            End Try

            cboTeam13.DataSource = ds
            cboTeam13.DataBind()
            cboTeam13.Items.Insert(0, "Select...")

            Try
                If Not Session("memarrTeamID")(12) Is Nothing Then
                    cboTeam13.SelectedValue = Session("memarrTeamID")(12)
                    PopupControlExtender13.DynamicContextKey = Session("memarrTeamID")(12)
                End If
            Catch
            End Try

            cboTeam14.DataSource = ds
            cboTeam14.DataBind()
            cboTeam14.Items.Insert(0, "Select...")

            Try
                If Not Session("memarrTeamID")(13) Is Nothing Then
                    cboTeam14.SelectedValue = Session("memarrTeamID")(13)
                    PopupControlExtender14.DynamicContextKey = Session("memarrTeamID")(13)
                End If
            Catch
            End Try

            cboTeam15.DataSource = ds
            cboTeam15.DataBind()
            cboTeam15.Items.Insert(0, "Select...")

            Try
                If Not Session("memarrTeamID")(14) Is Nothing Then
                    cboTeam15.SelectedValue = Session("memarrTeamID")(14)
                    PopupControlExtender15.DynamicContextKey = Session("memarrTeamID")(14)
                End If
            Catch
            End Try

            If gNumOfTeams > 15 Then
                cboTeam16.DataSource = ds
                cboTeam16.DataBind()
                cboTeam16.Items.Insert(0, "Select...")

                Try
                    If Not Session("memarrTeamID")(15) Is Nothing Then
                        cboTeam16.SelectedValue = Session("memarrTeamID")(15)
                        PopupControlExtender16.DynamicContextKey = Session("memarrTeamID")(15)
                    End If
                Catch
                End Try

                If gNumOfTeams > 16 Then
                    cboTeam17.DataSource = ds
                    cboTeam17.DataBind()
                    cboTeam17.Items.Insert(0, "Select...")

                    Try
                        If Not Session("memarrTeamID")(16) Is Nothing Then
                            cboTeam17.SelectedValue = Session("memarrTeamID")(16)
                            PopupControlExtender17.DynamicContextKey = Session("memarrTeamID")(16)
                        End If
                    Catch
                    End Try

                    cboTeam18.DataSource = ds
                    cboTeam18.DataBind()
                    cboTeam18.Items.Insert(0, "Select...")

                    Try
                        If Not Session("memarrTeamID")(17) Is Nothing Then
                            cboTeam18.SelectedValue = Session("memarrTeamID")(17)
                            PopupControlExtender18.DynamicContextKey = Session("memarrTeamID")(17)
                        End If
                    Catch
                    End Try

                    cboTeam19.DataSource = ds
                    cboTeam19.DataBind()
                    cboTeam19.Items.Insert(0, "Select...")

                    Try
                        If Not Session("memarrTeamID")(18) Is Nothing Then
                            cboTeam19.SelectedValue = Session("memarrTeamID")(18)
                            PopupControlExtender19.DynamicContextKey = Session("memarrTeamID")(18)
                        End If
                    Catch
                    End Try

                    cboTeam20.DataSource = ds
                    cboTeam20.DataBind()
                    cboTeam20.Items.Insert(0, "Select...")

                    Try
                        If Not Session("memarrTeamID")(19) Is Nothing Then
                            cboTeam20.SelectedValue = Session("memarrTeamID")(19)
                            PopupControlExtender20.DynamicContextKey = Session("memarrTeamID")(19)
                        End If
                    Catch
                    End Try
                End If
            End If
        End If

    End Sub

    Private Sub cmdPreviousWeeks_Click(sender As Object, e As System.EventArgs) Handles cmdPreviousWeeks.Click
        Dim strResult As String = ""
        strResult = LoadLastWeeksRankings(True)
        ' Now load the dropdowns...
        If strResult = "OK" Then
            LoadDropDowns()
        Else
            lblMessage.Text = strResult
        End If
    End Sub

    Private Sub cboViewDetail_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboViewDetail.SelectedIndexChanged
        SaveTheDropDowns()
        Response.Redirect("Hoaspx?sel=RankingsTeam&t=" & cboViewDetail.SelectedValue)
    End Sub

    Protected Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        If Session("event") = "EnterRankings1" Then
            Response.Redirect("Hoaspx?sel=EnterRankings1")
        ElseIf Session("event") = "EnterRankings8" Then
            Response.Redirect("Hoaspx?sel=EnterRankings8")
        Else
            Response.Redirect("Hoaspx?sel=EnterRankings")
        End If
    End Sub

    Private Sub SaveTheDropDowns()

        Try
            gNumOfTeams = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT NumberOfRankings FROM tblSports WHERE sportID = '" & strSportIDLocal & "'")
        Catch
            gNumOfTeams = 20
        End Try
        If Session("event") = "EnterRankings8" Then
            If Session("memgSport") = "Volleyball" Or Session("memgSport") = "FPSoftball" Then
                gNumOfTeams = 7     ' You cannot rank yourself...
            Else
                gNumOfTeams = 8
            End If
        ElseIf Session("event") = "EnterRankingsEW" Then
            gNumOfTeams = 15
        End If

        Dim objTeamID As New ArrayList
        Dim objSchool As New ArrayList

        objTeamID.Add(cboTeam1.SelectedValue)
        objSchool.Add(cboTeam1.SelectedItem.Text)
        objTeamID.Add(cboTeam2.SelectedValue)
        objSchool.Add(cboTeam2.SelectedItem.Text)
        objTeamID.Add(cboTeam3.SelectedValue)
        objSchool.Add(cboTeam3.SelectedItem.Text)
        objTeamID.Add(cboTeam4.SelectedValue)
        objSchool.Add(cboTeam4.SelectedItem.Text)
        objTeamID.Add(cboTeam5.SelectedValue)
        objSchool.Add(cboTeam5.SelectedItem.Text)
        objTeamID.Add(cboTeam6.SelectedValue)
        objSchool.Add(cboTeam6.SelectedItem.Text)
        objTeamID.Add(cboTeam7.SelectedValue)
        objSchool.Add(cboTeam7.SelectedItem.Text)
        objTeamID.Add(cboTeam8.SelectedValue)
        objSchool.Add(cboTeam8.SelectedItem.Text)

        If gNumOfTeams > 8 Then
            objTeamID.Add(cboTeam9.SelectedValue)
            objSchool.Add(cboTeam9.SelectedItem.Text)
            objTeamID.Add(cboTeam10.SelectedValue)
            objSchool.Add(cboTeam10.SelectedItem.Text)
        End If

        If gNumOfTeams > 10 Then
            objTeamID.Add(cboTeam11.SelectedValue)
            objSchool.Add(cboTeam11.SelectedItem.Text)
            objTeamID.Add(cboTeam12.SelectedValue)
            objSchool.Add(cboTeam12.SelectedItem.Text)
        End If

        If gNumOfTeams > 12 Then
            objTeamID.Add(cboTeam13.SelectedValue)
            objSchool.Add(cboTeam13.SelectedItem.Text)
            objTeamID.Add(cboTeam14.SelectedValue)
            objSchool.Add(cboTeam14.SelectedItem.Text)
            objTeamID.Add(cboTeam15.SelectedValue)
            objSchool.Add(cboTeam15.SelectedItem.Text)
        End If

        If gNumOfTeams > 15 Then
            objTeamID.Add(cboTeam16.SelectedValue)
            objSchool.Add(cboTeam16.SelectedItem.Text)
            If gNumOfTeams > 16 Then
                objTeamID.Add(cboTeam17.SelectedValue)
                objSchool.Add(cboTeam17.SelectedItem.Text)
                objTeamID.Add(cboTeam18.SelectedValue)
                objSchool.Add(cboTeam18.SelectedItem.Text)
                objTeamID.Add(cboTeam19.SelectedValue)
                objSchool.Add(cboTeam19.SelectedItem.Text)
                objTeamID.Add(cboTeam20.SelectedValue)
                objSchool.Add(cboTeam20.SelectedItem.Text)
            End If
        End If

        Session("memarrSchool") = objSchool
        Session("memarrTeamID") = objTeamID

    End Sub

    Private Sub cmdContinue_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdContinue.Click
        ' Submit the rankings...

        Dim strResults As String = VerifyChoices(gNumOfTeams, Session("memgTeamID"))
        SaveTheDropDowns()
        If strResults = "0TEAM" Then                ' Added 12/5/2016 to resolve Multiple rankings entries by a team...
            Response.Redirect("Login.aspx")
        ElseIf strResults = "OK" Then
            ' Let's save an move on...
            SaveTheDropDowns()
            Session("memnumberofrankings") = gNumOfTeams
            SaveDataToDb()
            Dim strContent As String = GetRankingsContent(gNumOfTeams)
            Dim strSubject As String = ""

            If strContent = "" Then
                ' Skip it...
                '''''clsEmail.SendEmail(Me, "Error in Content : " & gNumOfTeams & " : " & strResults, "cwilfong@ipa.net", "cwilfong@ossaa.com", "by " & Session("memgSchool") & " " & Session("memgSportDisplay"))
                clsEmail.SendEmailNew("cwilfong@ipa.net", "", "by " & Session("memgSchool") & " " & Session("memgSportDisplay"), "Error in Content : " & gNumOfTeams & " : " & strResults, False, "OSSAARankings.com Email")
            Else
                If Session("event") = "EnterRankings1" Or Session("event") = "EnterRankings8" Then
                    If InStr(Session("memgSportDisplay"), "Volleyball") > 0 Then
                        strSubject = "OSSAARankings.com RANKINGS SUBMITTED by " & Session("memgSchool") & " Volleyball (State Tourney)"
                    ElseIf InStr(Session("memgSportDisplay"), "Fast Pitch") > 0 Then    ' CDW added 9/26/2019...
                        strSubject = "OSSAARankings.com RANKINGS SUBMITTED by " & Session("memgSchool") & " Fast Pitch (State Tourney)"
                    Else
                        strSubject = "OSSAARankings.com RANKINGS SUBMITTED by " & Session("memgSchool") & " Wrestling (Dual)"
                    End If
                ElseIf Session("event") = "EnterRankingsEW" Then
                    strSubject = "OSSAARankings.com E-W RANKINGS SUBMITTED by " & Session("memgSchool") & " " & Session("memgSportDisplay")
                Else
                    strSubject = "OSSAARankings.com RANKINGS SUBMITTED by " & Session("memgSchool") & " " & Session("memgSportDisplay")
                End If

                '''''clsEmail.SendEmail(Me, strContent, Session("memgEmailMain"), "cwilfong@ossaa.com", strSubject)
                clsEmail.SendEmailNew(Session("memgEmailMain"), "", strSubject, strContent, False, "OSSAARankings.com Verification")
                If InStr(Session("memgSport"), "CrossCountry") > 0 Then
                    '''''clsEmail.SendEmail(Me, strContent, "cwilfong@ossaa.com", "cwilfong@ossaa.com", strSubject)
                End If

                If Session("event") = "EnterRankings1" Then
                    Response.Redirect("Home.aspx?sel=EnterRankings1")
                ElseIf Session("event") = "EnterRankings8" Then
                    Response.Redirect("Home.aspx?sel=EnterRankings8")
                ElseIf Session("event") = "EnterRankingsEW" Then
                    Response.Redirect("Home.aspx?sel=EnterRankingsEW")
                Else
                    Response.Redirect("Home.aspx?sel=EnterRankings")
                End If
            End If
        Else
            SaveDataToDbTemp()          ' 2/14/2014 added...
            lblMessage.Text = strResults
        End If

    End Sub

    Public Function GetRankingsContent(gNumOfTeams As Integer) As String
        Dim strResult As String = ""

        If gNumOfTeams = 8 Then
            strResult = "Your rankings were submitted for Week #" & Session("memgCurrentWeekNoRank") & "<br>"
            strResult = strResult & " 1. " & Session("memarrSchool")(0).ToString & "<br>"
            strResult = strResult & " 2. " & Session("memarrSchool")(1).ToString & "<br>"
            strResult = strResult & " 3. " & Session("memarrSchool")(2).ToString & "<br>"
            strResult = strResult & " 4. " & Session("memarrSchool")(3).ToString & "<br>"
            strResult = strResult & " 5. " & Session("memarrSchool")(4).ToString & "<br>"
            strResult = strResult & " 6. " & Session("memarrSchool")(5).ToString & "<br>"
            strResult = strResult & " 7. " & Session("memarrSchool")(6).ToString & "<br>"
            strResult = strResult & " 8. " & Session("memarrSchool")(7).ToString & "<br>"
        ElseIf gNumOfTeams = 7 Then     ' CDW added 10/6/2019...
            strResult = "Your rankings were submitted for Week #" & Session("memgCurrentWeekNoRank") & "<br>"
            strResult = strResult & " 1. " & Session("memarrSchool")(0).ToString & "<br>"
            strResult = strResult & " 2. " & Session("memarrSchool")(1).ToString & "<br>"
            strResult = strResult & " 3. " & Session("memarrSchool")(2).ToString & "<br>"
            strResult = strResult & " 4. " & Session("memarrSchool")(3).ToString & "<br>"
            strResult = strResult & " 5. " & Session("memarrSchool")(4).ToString & "<br>"
            strResult = strResult & " 6. " & Session("memarrSchool")(5).ToString & "<br>"
            strResult = strResult & " 7. " & Session("memarrSchool")(6).ToString & "<br>"
        Else
            If gNumOfTeams > 8 Then
                strResult = "Your rankings were submitted for Week #" & Session("memgCurrentWeekNoRank") & "<br>"
                strResult = strResult & " 1. " & Session("memarrSchool")(0).ToString & "<br>"
                strResult = strResult & " 2. " & Session("memarrSchool")(1).ToString & "<br>"
                strResult = strResult & " 3. " & Session("memarrSchool")(2).ToString & "<br>"
                strResult = strResult & " 4. " & Session("memarrSchool")(3).ToString & "<br>"
                strResult = strResult & " 5. " & Session("memarrSchool")(4).ToString & "<br>"
                strResult = strResult & " 6. " & Session("memarrSchool")(5).ToString & "<br>"
                strResult = strResult & " 7. " & Session("memarrSchool")(6).ToString & "<br>"
                strResult = strResult & " 8. " & Session("memarrSchool")(7).ToString & "<br>"
                strResult = strResult & " 9. " & Session("memarrSchool")(8).ToString & "<br>"
                strResult = strResult & "10. " & Session("memarrSchool")(9).ToString & "<br>"
                strResult = strResult & "11. " & Session("memarrSchool")(10).ToString & "<br>"
                strResult = strResult & "12. " & Session("memarrSchool")(11).ToString & "<br>"
            End If

            If gNumOfTeams > 12 Then
                strResult = strResult & "13. " & Session("memarrSchool")(12).ToString & "<br>"
                strResult = strResult & "14. " & Session("memarrSchool")(13).ToString & "<br>"
                strResult = strResult & "15. " & Session("memarrSchool")(14).ToString & "<br>"
            End If

            If gNumOfTeams > 15 Then
                strResult = strResult & "16. " & Session("memarrSchool")(15).ToString & "<br>"
                If gNumOfTeams > 16 Then
                    strResult = strResult & "17. " & Session("memarrSchool")(16).ToString & "<br>"
                    strResult = strResult & "18. " & Session("memarrSchool")(17).ToString & "<br>"
                    strResult = strResult & "19. " & Session("memarrSchool")(18).ToString & "<br>"
                    strResult = strResult & "20. " & Session("memarrSchool")(19).ToString & "<br>"
                End If
            End If
        End If

        Return strResult

    End Function

    Public Function VerifyChoices(gNumOfTeams As Integer, teamID As Long) As String

        Dim strReturn As String = "OK"

        If teamID = 0 Then              ' Added 12/5/2016...
            strReturn = "0TEAM"
        Else

            If cboTeam1.SelectedIndex = 0 And cboTeam1.Visible Then
                strReturn = "You must select a #1 team."
            ElseIf cboTeam2.SelectedIndex = 0 And cboTeam2.Visible Then
                strReturn = "You must select a #2 team."
            ElseIf cboTeam3.SelectedIndex = 0 And cboTeam3.Visible Then
                strReturn = "You must select a #3 team."
            ElseIf cboTeam4.SelectedIndex = 0 And cboTeam4.Visible Then
                strReturn = "You must select a #4 team."
            ElseIf cboTeam5.SelectedIndex = 0 And cboTeam5.Visible Then
                strReturn = "You must select a #5 team."
            ElseIf cboTeam6.SelectedIndex = 0 And cboTeam6.Visible Then
                strReturn = "You must select a #6 team."
            ElseIf cboTeam7.SelectedIndex = 0 And cboTeam7.Visible Then
                strReturn = "You must select a #7 team."
            ElseIf cboTeam8.SelectedIndex = 0 And cboTeam8.Visible Then
                strReturn = "You must select a #8 team."
            End If

            ' Check 9 thru 10 (if applicable)...
            If cboTeam9.Visible Then
                If cboTeam9.SelectedIndex = 0 Then
                    strReturn = "You must select a #9 team."
                ElseIf cboTeam10.SelectedIndex = 0 Then
                    strReturn = "You must select a #10 team."
                End If
            End If

            If cboTeam11.Visible Then
                If strReturn = "OK" Then
                    If cboTeam11.SelectedIndex = 0 Then
                        strReturn = "You must select a #11 team."
                    ElseIf cboTeam12.SelectedIndex = 0 Then
                        strReturn = "You must select a #12 team."
                    End If
                    If cboTeam13.Visible Then
                        If cboTeam13.SelectedIndex = 0 Then
                            strReturn = "You must select a #13 team."
                        ElseIf cboTeam14.SelectedIndex = 0 Then
                            strReturn = "You must select a #14 team."
                        ElseIf cboTeam15.SelectedIndex = 0 Then
                            strReturn = "You must select a #15 team."
                        End If
                    End If
                End If
            End If

            ' Check 16 thru 20 (if applicable)....
            If cboTeam16.Visible Then
                If strReturn = "OK" Then
                    If cboTeam16.SelectedIndex = 0 Then
                        strReturn = "You must select a #16 team."
                    ElseIf cboTeam17.SelectedIndex = 0 Then
                        strReturn = "You must select a #17 team."
                    ElseIf cboTeam18.SelectedIndex = 0 Then
                        strReturn = "You must select a #18 team."
                    ElseIf cboTeam19.SelectedIndex = 0 Then
                        strReturn = "You must select a #19 team."
                    ElseIf cboTeam20.SelectedIndex = 0 Then
                        strReturn = "You must select a #20 team."
                    End If
                End If
            End If

            ' Now check for duplicates...
            If strReturn = "OK" Then
                strReturn = IsDuplicateChosen(gNumOfTeams)
            End If

        End If

        Return strReturn

    End Function

    Public Function DupLoop(ByVal intControlNumber As Integer, ByVal intValue As Long, numOfTeams As Integer) As String
        Dim strReturn As String = "OK"

        ' Check cboTeam...
        If (cboTeam1.SelectedIndex = intValue) And (intControlNumber <> 1) Then
            strReturn = "Duplicate Selection (#1 and #" & intControlNumber & ")"
        ElseIf (cboTeam2.SelectedIndex = intValue) And (intControlNumber <> 2) Then
            strReturn = "Duplicate Selection (#2 and #" & intControlNumber & ")"
        ElseIf (cboTeam3.SelectedIndex = intValue) And (intControlNumber <> 3) Then
            strReturn = "Duplicate Selection (#3 and #" & intControlNumber & ")"
        ElseIf (cboTeam4.SelectedIndex = intValue) And (intControlNumber <> 4) Then
            strReturn = "Duplicate Selection (#4 and #" & intControlNumber & ")"
        ElseIf (cboTeam5.SelectedIndex = intValue) And (intControlNumber <> 5) Then
            strReturn = "Duplicate Selection (#5 and #" & intControlNumber & ")"
        ElseIf (cboTeam6.SelectedIndex = intValue) And (intControlNumber <> 6) Then
            strReturn = "Duplicate Selection (#6 and #" & intControlNumber & ")"
        ElseIf (cboTeam7.SelectedIndex = intValue) And (intControlNumber <> 7) Then
            strReturn = "Duplicate Selection (#7 and #" & intControlNumber & ")"
        ElseIf (cboTeam8.SelectedIndex = intValue) And (intControlNumber <> 8) Then
            strReturn = "Duplicate Selection (#8 and #" & intControlNumber & ")"
        End If

        If numOfTeams > 8 Then
            If strReturn = "OK" Then
                If (cboTeam9.SelectedIndex = intValue) And (intControlNumber <> 9) Then
                    strReturn = "Duplicate Selection (#9 and #" & intControlNumber & ")"
                ElseIf (cboTeam10.SelectedIndex = intValue) And (intControlNumber <> 10) Then
                    strReturn = "Duplicate Selection (#10 and #" & intControlNumber & ")"
                End If
            End If
        End If

        If numOfTeams > 10 Then
            If strReturn = "OK" Then
                If (cboTeam11.SelectedIndex = intValue) And (intControlNumber <> 11) Then
                    strReturn = "Duplicate Selection (#11 and #" & intControlNumber & ")"
                ElseIf (cboTeam12.SelectedIndex = intValue) And (intControlNumber <> 12) Then
                    strReturn = "Duplicate Selection (#12 and #" & intControlNumber & ")"
                ElseIf (cboTeam13.SelectedIndex = intValue) And (intControlNumber <> 13) Then
                    strReturn = "Duplicate Selection (#13 and #" & intControlNumber & ")"
                ElseIf (cboTeam14.SelectedIndex = intValue) And (intControlNumber <> 14) Then
                    strReturn = "Duplicate Selection (#14 and #" & intControlNumber & ")"
                ElseIf (cboTeam15.SelectedIndex = intValue) And (intControlNumber <> 15) Then
                    strReturn = "Duplicate Selection (#15 and #" & intControlNumber & ")"
                End If
            End If
        End If

        If numOfTeams > 15 Then
            If strReturn = "OK" Then
                If (cboTeam16.SelectedIndex = intValue) And (intControlNumber <> 16) Then
                    strReturn = "Duplicate Selection (#16 and #" & intControlNumber & ")"
                ElseIf (cboTeam17.SelectedIndex = intValue) And (intControlNumber <> 17) Then
                    strReturn = "Duplicate Selection (#17 and #" & intControlNumber & ")"
                ElseIf (cboTeam18.SelectedIndex = intValue) And (intControlNumber <> 18) Then
                    strReturn = "Duplicate Selection (#18 and #" & intControlNumber & ")"
                ElseIf (cboTeam19.SelectedIndex = intValue) And (intControlNumber <> 19) Then
                    strReturn = "Duplicate Selection (#19 and #" & intControlNumber & ")"
                ElseIf (cboTeam20.SelectedIndex = intValue) And (intControlNumber <> 20) Then
                    strReturn = "Duplicate Selection (#20 and #" & intControlNumber & ")"
                End If
            End If
        End If

        Return strReturn

    End Function

    Public Function IsDuplicateChosen(numOfTeams As Integer) As String
        Dim x As Integer
        Dim strReturn As String = "OK"

        For x = 1 To numOfTeams
            Select Case x
                Case 1
                    strReturn = DupLoop(x, cboTeam1.SelectedIndex, numOfTeams)
                Case 2
                    strReturn = DupLoop(x, cboTeam2.SelectedIndex, numOfTeams)
                Case 3
                    strReturn = DupLoop(x, cboTeam3.SelectedIndex, numOfTeams)
                Case 4
                    strReturn = DupLoop(x, cboTeam4.SelectedIndex, numOfTeams)
                Case 5
                    strReturn = DupLoop(x, cboTeam5.SelectedIndex, numOfTeams)
                Case 6
                    strReturn = DupLoop(x, cboTeam6.SelectedIndex, numOfTeams)
                Case 7
                    strReturn = DupLoop(x, cboTeam7.SelectedIndex, numOfTeams)
                Case 8
                    strReturn = DupLoop(x, cboTeam8.SelectedIndex, numOfTeams)
                Case 9
                    strReturn = DupLoop(x, cboTeam9.SelectedIndex, numOfTeams)
                Case 10
                    strReturn = DupLoop(x, cboTeam10.SelectedIndex, numOfTeams)
                Case 11
                    strReturn = DupLoop(x, cboTeam11.SelectedIndex, numOfTeams)
                Case 12
                    strReturn = DupLoop(x, cboTeam12.SelectedIndex, numOfTeams)
                Case 13
                    strReturn = DupLoop(x, cboTeam13.SelectedIndex, numOfTeams)
                Case 14
                    strReturn = DupLoop(x, cboTeam14.SelectedIndex, numOfTeams)
                Case 15
                    strReturn = DupLoop(x, cboTeam15.SelectedIndex, numOfTeams)
                Case 16
                    strReturn = DupLoop(x, cboTeam16.SelectedIndex, numOfTeams)
                Case 17
                    strReturn = DupLoop(x, cboTeam17.SelectedIndex, numOfTeams)
                Case 18
                    strReturn = DupLoop(x, cboTeam18.SelectedIndex, numOfTeams)
                Case 19
                    strReturn = DupLoop(x, cboTeam19.SelectedIndex, numOfTeams)
                Case 20
                    strReturn = DupLoop(x, cboTeam20.SelectedIndex, numOfTeams)
            End Select
            If strReturn <> "OK" Then
                Exit For
            End If
        Next

        Return strReturn

    End Function

    Public Sub SaveDataToDbTemp()
        Dim strSQLUpdate As String
        Dim rankcount As Integer = 0
        'Dim numberofrankings As Integer = Session("memnumberofrankings")
        'Dim points As Integer = 0
        Dim strRankString As String = ""

        strSQLUpdate = "INSERT INTO tblCoachesRanksTemp (sportID, CoachID, CoachIDTeamID, WeekID, RankString) VALUES ("

        Do While rankcount < gNumOfTeams
            'points = gNumOfTeams - rankcount
            If Session("memgTeamID") = 0 Then
                Session("memgTeamID") = clsTeams.GetTeamID(Session("memgSportID"), Session("memgSchoolID"), clsFunctions.GetCurrentYear)
            End If
            If strRankString = "" Then
                strRankString = strRankString & Session("memarrTeamID")(rankcount)
            Else
                strRankString = strRankString & ", " & Session("memarrTeamID")(rankcount)
            End If
            rankcount = rankcount + 1
        Loop

        strSQLUpdate = strSQLUpdate & "'" & strSportIDLocal & "', "
        strSQLUpdate = strSQLUpdate & Session("memgMemberID") & ", "
        strSQLUpdate = strSQLUpdate & Session("memgTeamID") & ", "
        strSQLUpdate = strSQLUpdate & Session("memgCurrentWeekIDRank") & ", "
        strSQLUpdate = strSQLUpdate & "'" & strRankString & "')"
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQLUpdate)

    End Sub

    Public Sub SaveDataToDb()
        Dim rankcount As Integer = 0
        Dim numberofrankings As Integer = Session("memnumberofrankings")
        Dim points As Integer
        Dim sql As String
        'Dim intCurrentVotes As Integer = 0
        Dim strSQLUpdate As String = ""
        Dim strSQLDelete As String = ""
        Dim strRankString As String = ""

        'If Session("event") = "EnterRankingsEW" Then
        '    sql = "SELECT COUNT(rankID) FROM tblCoachesRanksEW WHERE weekID = " & Session("memgCurrentWeekIDRank") & " AND coachIDTeamID = " & Session("memgTeamID")
        'Else
        '    sql = "SELECT COUNT(rankID) FROM tblCoachesRanks WHERE weekID = " & Session("memgCurrentWeekIDRank") & " AND coachIDTeamID = " & Session("memgTeamID")
        'End If
        'intCurrentVotes = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, sql)

        'If intCurrentVotes >= 8 Then
        '    ' Do nothing, something is already posted...

        'Else
        Dim strSQLLog As String = ""

        ' 1/31/2015 @ 10:50AM changed from Count to simply Delete if it is there and then update...
        If Session("event") = "EnterRankingsEW" Then
            strSQLDelete = "DELETE FROM tblCoachesRanksEW WHERE weekID = " & Session("memgCurrentWeekIDRank") & " AND coachIDTeamID = " & Session("memgTeamID")
        Else
            strSQLDelete = "DELETE FROM tblCoachesRanks WHERE weekID = " & Session("memgCurrentWeekIDRank") & " AND coachIDTeamID = " & Session("memgTeamID")
        End If
        ' 11/29/2016 added...
        clsLog.LogSQL(strSQLDelete, "", "")
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQLDelete)

        ' 11/7/2013 added...
        strSQLUpdate = "INSERT INTO tblCoachesRanksTemp (sportID, CoachID, CoachIDTeamID, WeekID, RankString) VALUES ("

        Do While rankcount < numberofrankings
            points = numberofrankings - rankcount
            If Session("event") = "EnterRankingsEW" Then
                sql = "INSERT INTO tblCoachesRanksEW (coachID, coachIDTeamID, teamID, weekID, rank, points) "
            Else
                sql = "INSERT INTO tblCoachesRanks (coachID, coachIDTeamID, teamID, weekID, rank, points) "
            End If
            If Session("memgTeamID") = 0 Then       ' To fix a bug 9/3/2013...
                Session("memgTeamID") = clsTeams.GetTeamID(Session("memgSportID"), Session("memgSchoolID"), clsFunctions.GetCurrentYear)
            End If
            sql = sql & "VALUES (" & Session("memgMemberID") & "," & Session("memgTeamID") & ", " & Session("memarrTeamID")(rankcount) & ", " & Session("memgCurrentWeekIDRank") & "," & (rankcount + 1) & "," & points & ")"
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, sql)

            ' 11/29/2016 added ...
            If rankcount = 0 Then
                clsLog.LogSQL(sql, "", "")
            End If

            If strRankString = "" Then
                strRankString = strRankString & Session("memarrTeamID")(rankcount)
            Else
                strRankString = strRankString & ", " & Session("memarrTeamID")(rankcount)
            End If
            rankcount = rankcount + 1
        Loop

        strSQLUpdate = strSQLUpdate & "'" & strSportIDLocal & "', "
        strSQLUpdate = strSQLUpdate & Session("memgMemberID") & ", "
        strSQLUpdate = strSQLUpdate & Session("memgTeamID") & ", "
        strSQLUpdate = strSQLUpdate & Session("memgCurrentWeekIDRank") & ", "
        strSQLUpdate = strSQLUpdate & "'" & strRankString & "')"
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQLUpdate)

    End Sub


    Private Sub cmdCancel_Click(sender As Object, e As System.EventArgs) Handles cmdCancel.Click
        Response.Redirect("Hoaspx?sel=Done")
    End Sub

    Private Sub cboTeam1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboTeam1.SelectedIndexChanged
        PopupControlExtender1.DynamicContextKey = cboTeam1.Text
    End Sub

    Private Sub cboTeam2_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboTeam2.SelectedIndexChanged
        PopupControlExtender2.DynamicContextKey = cboTeam2.Text
    End Sub

    Private Sub cboTeam3_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboTeam3.SelectedIndexChanged
        PopupControlExtender3.DynamicContextKey = cboTeam3.Text
    End Sub

    Private Sub cboTeam4_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboTeam4.SelectedIndexChanged
        PopupControlExtender4.DynamicContextKey = cboTeam4.Text
    End Sub

    Private Sub cboTeam5_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboTeam5.SelectedIndexChanged
        PopupControlExtender5.DynamicContextKey = cboTeam5.Text
    End Sub

    Private Sub cboTeam6_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboTeam6.SelectedIndexChanged
        PopupControlExtender6.DynamicContextKey = cboTeam6.Text
    End Sub

    Private Sub cboTeam7_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboTeam7.SelectedIndexChanged
        PopupControlExtender7.DynamicContextKey = cboTeam7.Text
    End Sub

    Private Sub cboTeam8_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboTeam8.SelectedIndexChanged
        PopupControlExtender8.DynamicContextKey = cboTeam8.Text
    End Sub

    Private Sub cboTeam9_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboTeam9.SelectedIndexChanged
        PopupControlExtender9.DynamicContextKey = cboTeam9.Text
    End Sub

    Private Sub cboTeam10_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboTeam10.SelectedIndexChanged
        PopupControlExtender10.DynamicContextKey = cboTeam10.Text
    End Sub

    Private Sub cboTeam11_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboTeam11.SelectedIndexChanged
        PopupControlExtender11.DynamicContextKey = cboTeam11.Text
    End Sub

    Private Sub cboTeam12_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboTeam12.SelectedIndexChanged
        PopupControlExtender12.DynamicContextKey = cboTeam12.Text
    End Sub

    Private Sub cboTeam13_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboTeam13.SelectedIndexChanged
        PopupControlExtender13.DynamicContextKey = cboTeam13.Text
    End Sub

    Private Sub cboTeam14_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboTeam14.SelectedIndexChanged
        PopupControlExtender14.DynamicContextKey = cboTeam14.Text
    End Sub

    Private Sub cboTeam15_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboTeam15.SelectedIndexChanged
        PopupControlExtender15.DynamicContextKey = cboTeam15.Text
    End Sub

    Private Sub cboTeam16_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboTeam16.SelectedIndexChanged
        PopupControlExtender16.DynamicContextKey = cboTeam16.Text
    End Sub

    Private Sub cboTeam17_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboTeam17.SelectedIndexChanged
        PopupControlExtender17.DynamicContextKey = cboTeam17.Text
    End Sub

    Private Sub cboTeam18_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboTeam18.SelectedIndexChanged
        PopupControlExtender18.DynamicContextKey = cboTeam18.Text
    End Sub

    Private Sub cboTeam19_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboTeam19.SelectedIndexChanged
        PopupControlExtender19.DynamicContextKey = cboTeam19.Text
    End Sub

    Private Sub cboTeam20_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboTeam20.SelectedIndexChanged
        PopupControlExtender20.DynamicContextKey = cboTeam20.Text
    End Sub

End Class