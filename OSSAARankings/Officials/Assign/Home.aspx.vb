Public Class Home1
    Inherits System.Web.UI.Page
    Dim intWeekNo As Integer
    Dim intDayNo As Integer     ' 1 = Thurs; 2 = Fri; 3 = Sat...
    Dim strClasses As String    ' 6A5A, 4A2A, AB...
    Dim intMilesLow As Integer = 0
    Dim intMilesHigh As Integer = 0
    Dim strDay As String = "NONE"

    Public Const constPlayoffAvailNONE = 0
    Public Const constPlayoffAvailDAYONLY = 1
    Public Const constPlayoffAvailNIGHTONLY = 2
    Public Const constPlayoffAvailDAYNIGHT = 3

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

		' NOTE : Run the following on the DB before starting Week #1....
		'UPDATE tblTournamentDetailBB Set intDayNo = 1 WHERE intYear = 20 And strDay = 'Fri' AND (strClass = 'A' OR strClass = 'B' OR strClass = '2A') AND strLevel = 'D'
		'UPDATE tblTournamentDetailBB Set intDayNo = 2 WHERE intYear = 20 And strDay = 'Sat' AND (strClass = 'A' OR strClass = 'B' OR strClass = '2A') AND strLevel = 'D'
		'UPDATE tblTournamentDetailBB Set intDayNo = 1 WHERE intYear = 20 And (strDay = 'Fri' OR strDay = 'Sat') AND (strClass = '3A' OR strClass = '4A') AND strLevel = 'D'
		'UPDATE tblTournamentDetailBB Set intDayNo = 1 WHERE intYear = 20 And strDay = 'Thur' AND (strLevel = 'R' OR strLevel = 'A' OR strLevel = 'S')
		'UPDATE tblTournamentDetailBB Set intDayNo = 2 WHERE intYear = 20 And strDay = 'Fri' AND (strLevel = 'R' OR strLevel = 'A' OR strLevel = 'S')
		'UPDATE tblTournamentDetailBB Set intDayNo = 3 WHERE intYear = 20 And strDay = 'Sat' AND (strLevel = 'R' OR strLevel = 'A' OR strLevel = 'S')

		If 1 = 2 Then
			intWeekNo = 1
			intDayNo = 1
			strClasses = "AB"
			intMilesLow = 95
			intMilesHigh = 120
		End If

		' Ran 2/12/2020...
		If 1 = 2 Then
			intWeekNo = 2
			intDayNo = 1
			strClasses = "AB"
			intMilesLow = 95
			intMilesHigh = 105
			strDay = "THURS"
		End If

		' Ran 2/13/2020... (1st)
		If 1 = 2 Then
			intWeekNo = 2
			intDayNo = 2
			strClasses = "4A2A"
			intMilesLow = 80
			intMilesHigh = 90
		End If

		' Ran 2/13/2020... (2nd)
		If 1 = 2 Then
			intWeekNo = 2
			intDayNo = 2
			strClasses = "AB"
			intMilesLow = 105
			intMilesHigh = 115
			strDay = "FRI"
		End If

		If 1 = 2 Then
			intWeekNo = 2
			intDayNo = 2
			strClasses = "AB"
			intMilesLow = 105
			intMilesHigh = 115
			strDay = "SAT"
		End If

		If 1 = 2 Then
			intWeekNo = 3
			intDayNo = 1
			strClasses = "6A5A"
			intMilesLow = 85
			intMilesHigh = 100
		End If
		If 1 = 1 Then
			intWeekNo = 3
			intDayNo = 1
			strClasses = "4A2A"
			intMilesLow = 85
			intMilesHigh = 115
			strDay = "THURS"
		End If
		If 1 = 2 Then
			intWeekNo = 3
			intDayNo = 2
			strClasses = "4A2A"
			intMilesLow = 90
			intMilesHigh = 115
			strDay = "FRI"
		End If
		If 1 = 2 Then
			intWeekNo = 3
			intDayNo = 3
			strClasses = "4A2A"
			intMilesLow = 85
			intMilesHigh = 120
			strDay = "SAT"
		End If
	End Sub

	Private Sub cmdPlaceOfficials1_Click(sender As Object, e As EventArgs) Handles cmdPlaceOfficials1.Click
        Dim strSourceView As String = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, "FRISAT")      ' __assignGAMESWeek#USE
        Dim strSQL As String = ""
        Dim strSQLCount As String = ""

		' SELECT FROM __assignGAMESWeek#USE...
		' When Official is assigned, D will be assigned to Fri and Sat games for A & B...   
		Select Case intWeekNo
			' ====================================================== WEEK #1...
			Case 1
				' Prefixes
				'   * = Saturday only official...
				'   ** = Not preferential...

				' A/B officialID1 using Preferentials... Day 2 (Sat) only games first....
				strSQL = "SELECT * FROM " & strSourceView & " WHERE (officialID1 Is Null) AND intRound = 2 ORDER BY WinsTotalAndDiff DESC"
				PlaceOfficialsInSlotNo(False, 1, strDay, strSQL, strSQLCount, False, "SAT ONLY", "(intPlayoffAvail01 <= " & constPlayoffAvailDAYONLY & " AND intPlayoffAvail02 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0)", "", 99996)
				' A/B officialID2 using Preferentials... Day 2 (Sat) only games...
				strSQL = "SELECT * FROM " & strSourceView & " WHERE (officialID2 Is Null) AND intRound = 2 ORDER BY WinsTotalAndDiff DESC"
				PlaceOfficialsInSlotNo(False, 2, strDay, strSQL, strSQLCount, False, "SAT ONLY", "(intPlayoffAvail01 <= " & constPlayoffAvailDAYONLY & " AND intPlayoffAvail02 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0)", "", 99996)

				' A/B officialID1 using Preferentials... Day 1 games...
				strSQL = "SELECT * FROM " & strSourceView & " WHERE (officialID1 Is Null OR officialID1 = 99996) ORDER BY WinsTotalAndDiff DESC"
				PlaceOfficialsInSlotNo(False, 1, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail01 >= " & constPlayoffAvailNIGHTONLY & " AND intPlayoffAvail02 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0)", "", 99997)
				' A/B officialID2 using Preferentials... Day 1 games...
				strSQL = "SELECT * FROM " & strSourceView & " WHERE (officialID2 Is Null OR officialID2 = 99996) ORDER BY WinsTotalAndDiff DESC"
				PlaceOfficialsInSlotNo(False, 2, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail01 >= " & constPlayoffAvailNIGHTONLY & " AND intPlayoffAvail02 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0)", "", 99997)

				' A/B officialID2 using all the rest available...
				strSQL = "SELECT * FROM " & strSourceView & " WHERE (officialID1 Is Null OR officialID1 = 99997) ORDER BY WinsTotalAndDiff DESC"
				PlaceOfficialsInSlotNo(False, 1, strDay, strSQL, strSQLCount, True, "NON-PREF", "(intPlayoffAvail01 >= " & constPlayoffAvailNIGHTONLY & " AND intPlayoffAvail02 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0)", "", 99998)
				' A/B officialID2 using all the rest available...
				strSQL = "SELECT * FROM " & strSourceView & " WHERE (officialID2 Is Null OR officialID2 = 99997) ORDER BY WinsTotalAndDiff DESC"
				PlaceOfficialsInSlotNo(False, 2, strDay, strSQL, strSQLCount, True, "NON-PREF", "(intPlayoffAvail01 >= " & constPlayoffAvailNIGHTONLY & " AND intPlayoffAvail02 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0)", "", 99998)

				' ANY REMAINING WILL HAVE 99998 and will be manually assigned by GG and SR... or COULD AUTO ASSIGN FROM OFFICIALS THAT DO NOT APPEAR ON A PREFERENTIAL LIST...
				'   Print list from : __assignRemainingWeek1Unassigned (this shows the remaining officials that were on a preferential but were not assigned).
			' ====================================================== WEEK #2...
			Case 2
				If intDayNo = 1 Then
					' ORDER BY GAMELEVEL (PM Games 1st), OfficialID1 and use only NON-AFTERNOON guys...  
					' Select the games... Evening games only...
					strSQL = "SELECT DISTINCT * FROM " & strSourceView & " WHERE (officialID1 Is Null AND intOfficialGameLevel = 11) ORDER BY intOfficialGameLevel, intSort"
					PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail03 >= " & constPlayoffAvailNIGHTONLY & ") AND (intDistance < " & intMilesLow & ")", "", 99996)
					strSQL = "SELECT DISTINCT * FROM " & strSourceView & " WHERE (officialID2 Is Null AND intOfficialGameLevel = 11) ORDER BY intOfficialGameLevel, intSort DESC"
					PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, False, "", "((intPlayoffAvail03 >= " & constPlayoffAvailNIGHTONLY & ") AND (intDistance < " & intMilesHigh & ") OR (intPlayoffAvail03 = " & constPlayoffAvailNIGHTONLY & ") AND (intDistance < " & intMilesHigh & "))", "", 99996)
					' Afternoon Games...
					strSQL = "SELECT DISTINCT * FROM " & strSourceView & " WHERE (officialID1 Is Null AND intOfficialGameLevel = 12) ORDER BY intOfficialGameLevel DESC, intSort DESC"
					PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, True, "", "(intPlayoffAvail03 > " & constPlayoffAvailNONE & ") AND (intPlayoffAvail03 <> " & constPlayoffAvailNIGHTONLY & ") AND (intDistance < " & (intMilesLow + 10) & ")", "", 99997)
					strSQL = "SELECT DISTINCT * FROM " & strSourceView & " WHERE (officialID2 Is Null AND intOfficialGameLevel = 12) ORDER BY intOfficialGameLevel, intSort"
					PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, True, "", "(intPlayoffAvail03 > " & constPlayoffAvailNONE & ") AND (intPlayoffAvail03 <> " & constPlayoffAvailNIGHTONLY & ") AND (intDistance < " & (intMilesHigh + 10) & ")", "", 99997)

					strSQL = "SELECT DISTINCT * FROM " & strSourceView & " WHERE ((officialID1 Is Null OR officialID1 = 99997) AND intOfficialGameLevel = 12) ORDER BY intOfficialGameLevel, intSort DESC"
					PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, True, "*", "(intPlayoffAvail03 > " & constPlayoffAvailNONE & ") AND (intPlayoffAvail03 <> " & constPlayoffAvailNIGHTONLY & ") AND (intDistance < " & (intMilesLow + 30) & ")", "", 99998)
					strSQL = "SELECT DISTINCT * FROM " & strSourceView & " WHERE ((officialID2 Is Null OR officialID2 = 99997) AND intOfficialGameLevel = 12) ORDER BY intOfficialGameLevel, intSort"
					PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, True, "*", "(intPlayoffAvail03 > " & constPlayoffAvailNONE & ") AND (intPlayoffAvail03 <> " & constPlayoffAvailNIGHTONLY & ") AND (intDistance < " & (intMilesHigh + 30) & ")", "", 99998)

				ElseIf intDayNo = 2 Then
					' ====================================== WEEK #2, DAY #2, "4A2A"...								
					If strClasses = "4A2A" Then
						strDay = "SAT"
						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						' 4A-2A, Order Games by WinsTotalAndDiff, Get all officials AVAIL FRI OR SAT AND are on a Preferential.  Set the Mileage limits for Officials selection...
						strSQL = "SELECT * FROM " & strSourceView & " WHERE (strClass = '4A' AND intDayNo = 2) AND (officialID1 Is Null) ORDER BY WinsTotalAndDiff DESC"
						PlaceOfficialsInSlotNo(False, 1, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail05 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0 AND intDistance < " & intMilesLow & ")", "", 99996)

						strDay = "FRI"
						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT * FROM " & strSourceView & " WHERE (strClass = '3A' AND intDayNo = 1) AND (officialID1 Is Null) ORDER BY WinsTotalAndDiff DESC"
						PlaceOfficialsInSlotNo(False, 1, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail04 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0 AND intDistance < " & intMilesLow & ")", "", 99996)

						strDay = "FRISAT"
						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT * FROM " & strSourceView & " WHERE (strClass = '2A') AND (officialID1 Is Null) ORDER BY WinsTotalAndDiff DESC"
						PlaceOfficialsInSlotNo(False, 1, strDay, strSQL, strSQLCount, False, "", "((intPlayoffAvail04 >= " & constPlayoffAvailNIGHTONLY & " AND intPlayoffAvail05 > 1) AND intPreferentialLists > 0 AND intDistance < " & intMilesLow + 10 & ")", "", 99996)

						strDay = "FRI"
						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT * FROM " & strSourceView & " WHERE (strClass = '4A' AND intDayNo = 1) AND (officialID1 Is Null) ORDER BY WinsTotalAndDiff DESC"
						PlaceOfficialsInSlotNo(False, 1, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail04 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0 AND intDistance < " & intMilesLow + 5 & ")", "", 99996)

						strDay = "SAT"
						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT * FROM " & strSourceView & " WHERE (strClass = '3A' AND intDayNo = 2) AND (officialID1 Is Null) ORDER BY WinsTotalAndDiff DESC"
						PlaceOfficialsInSlotNo(False, 1, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail05 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0 AND intDistance < " & intMilesLow + 5 & ")", "", 99996)

						' Official #2...
						strDay = "SAT"
						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT * FROM " & strSourceView & " WHERE (strClass = '4A' AND intDayNo = 2) AND (officialID2 Is Null) ORDER BY WinsTotalAndDiff DESC"
						PlaceOfficialsInSlotNo(False, 2, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail05 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0 AND intDistance < " & intMilesHigh & ")", "", 99997)

						strDay = "FRI"
						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT * FROM " & strSourceView & " WHERE (strClass = '3A' AND intDayNo = 1) AND (officialID2 Is Null) ORDER BY WinsTotalAndDiff DESC"
						PlaceOfficialsInSlotNo(False, 2, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail04 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0 AND intDistance < " & intMilesHigh & ")", "", 99997)

						strDay = "FRISAT"
						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT * FROM " & strSourceView & " WHERE (strClass = '2A') AND (officialID2 Is Null) ORDER BY WinsTotalAndDiff DESC"
						PlaceOfficialsInSlotNo(False, 2, strDay, strSQL, strSQLCount, False, "", "((intPlayoffAvail04 >= " & constPlayoffAvailNIGHTONLY & " AND intPlayoffAvail05 >= " & constPlayoffAvailNIGHTONLY & ") AND intPreferentialLists > 0 AND intDistance < " & intMilesHigh & ")", "", 99997)

						strDay = "FRI"
						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT * FROM " & strSourceView & " WHERE (strClass = '4A' AND intDayNo = 1) AND (officialID2 Is Null) ORDER BY WinsTotalAndDiff DESC"
						PlaceOfficialsInSlotNo(False, 2, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail04 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0 AND intDistance < " & intMilesHigh & ")", "", 99997)

						strDay = "SAT"
						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT * FROM " & strSourceView & " WHERE (strClass = '3A' AND intDayNo = 2) AND (officialID2 Is Null) ORDER BY WinsTotalAndDiff DESC"
						PlaceOfficialsInSlotNo(False, 2, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail05 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0 AND intDistance < " & intMilesHigh & ")", "", 99997)

						' LET'S FILL IN "THE BLANKS"...
						strDay = "FRI"
						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT * FROM " & strSourceView & " WHERE ((strClass = '3A' OR strClass = '4A') AND intDayNo = 1) AND (officialID1 = 99990 OR officialID1 = 99996 OR officialID1 = 99997) ORDER BY WinsTotalAndDiff DESC"
						PlaceOfficialsInSlotNo(False, 1, strDay, strSQL, strSQLCount, True, "", "(intPlayoffAvail04 >= " & constPlayoffAvailNIGHTONLY & " AND intDistance < " & intMilesHigh + 20 & ")", "", 99998)

						strDay = "SAT"
						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT * FROM " & strSourceView & " WHERE ((strClass = '3A' OR strClass = '4A') AND intDayNo = 2) AND (officialID1 = 99990 OR officialID1 = 99996 OR officialID1 = 99997) ORDER BY WinsTotalAndDiff DESC"
						PlaceOfficialsInSlotNo(False, 1, strDay, strSQL, strSQLCount, True, "", "(intPlayoffAvail05 >= " & constPlayoffAvailNIGHTONLY & " AND intDistance < " & intMilesHigh + 20 & ")", "", 99998)

						strDay = "FRI"
						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT * FROM " & strSourceView & " WHERE ((strClass = '3A' OR strClass = '4A') AND intDayNo = 1) AND (officialID2 = 99990 OR officialID2 = 99996 OR officialID2 = 99997) ORDER BY WinsTotalAndDiff DESC"
						PlaceOfficialsInSlotNo(False, 2, strDay, strSQL, strSQLCount, True, "", "(intPlayoffAvail04 >= " & constPlayoffAvailNIGHTONLY & " AND intDistance < " & intMilesHigh + 20 & ")", "", 99998)

						strDay = "SAT"
						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT * FROM " & strSourceView & " WHERE ((strClass = '3A' OR strClass = '4A') AND intDayNo = 2) AND (officialID2 = 99990 OR officialID2 = 99996 OR officialID2 = 99997) ORDER BY WinsTotalAndDiff DESC"
						PlaceOfficialsInSlotNo(False, 2, strDay, strSQL, strSQLCount, True, "", "(intPlayoffAvail05 >= " & constPlayoffAvailNIGHTONLY & " AND intDistance < " & intMilesHigh + 20 & ")", "", 99998)

						strDay = "FRI"
						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT * FROM " & strSourceView & " WHERE (strClass = '2A' AND intDayNo = 1) AND (officialID1 = 99990 OR officialID1 = 99996 OR officialID1 = 99997) ORDER BY WinsTotalAndDiff DESC"
						PlaceOfficialsInSlotNo(False, 1, strDay, strSQL, strSQLCount, True, "", "(intPlayoffAvail04 >= " & constPlayoffAvailNIGHTONLY & " AND intDistance < " & intMilesHigh + 20 & ")", "", 99998)

						strDay = "SAT"
						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT * FROM " & strSourceView & " WHERE (strClass = '2A' AND intDayNo = 2) AND (officialID1 = 99990 OR officialID1 = 99996 OR officialID1 = 99997) ORDER BY WinsTotalAndDiff DESC"
						PlaceOfficialsInSlotNo(False, 1, strDay, strSQL, strSQLCount, True, "", "(intPlayoffAvail05 >= " & constPlayoffAvailNIGHTONLY & " AND intDistance < " & intMilesHigh + 20 & ")", "", 99998)

						strDay = "FRI"
						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT * FROM " & strSourceView & " WHERE (strClass = '2A' AND intDayNo = 1) AND (officialID2 = 99990 OR officialID2 = 99996 OR officialID2 = 99997) ORDER BY WinsTotalAndDiff DESC"
						PlaceOfficialsInSlotNo(False, 2, strDay, strSQL, strSQLCount, True, "", "(intPlayoffAvail04 >= " & constPlayoffAvailNIGHTONLY & " AND intDistance < " & intMilesHigh + 20 & ")", "", 99998)

						strDay = "SAT"
						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT * FROM " & strSourceView & " WHERE (strClass = '2A' AND intDayNo = 2) AND (officialID2 = 99990 OR officialID2 = 99996 OR officialID2 = 99997) ORDER BY WinsTotalAndDiff DESC"
						PlaceOfficialsInSlotNo(False, 2, strDay, strSQL, strSQLCount, True, "", "(intPlayoffAvail05 >= " & constPlayoffAvailNIGHTONLY & " AND intDistance < " & intMilesHigh + 20 & ")", "", 99998)
						' ====================================== WEEK #2, DAY #2, "AB"...
					ElseIf strClasses = "AB2019" Then
						'GoTo CleanUp
						' AFTERNOON ONLY...
						' NOTE : 2019 OLD VERSION...
						strDay = "SAT"
						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT * FROM " & strSourceView & " WHERE (strClass = 'A' OR strClass = 'B' AND intDayNo = 3) AND (officialID1 Is Null OR officialID1 = '') ORDER BY intOfficialGameLevel"
						PlaceOfficialsInSlotNo(False, 1, strDay, strSQL, strSQLCount, True, "", "(intPlayoffAvail05 = " & constPlayoffAvailDAYONLY & " AND intDistance < " & intMilesLow & ")", "", 99996)

						strDay = "FRI"
						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT * FROM " & strSourceView & " WHERE (strClass = 'A' OR strClass = 'B' AND intDayNo = 2) AND (officialID1 Is Null OR officialID1 = '') ORDER BY intOfficialGameLevel"
						PlaceOfficialsInSlotNo(False, 1, strDay, strSQL, strSQLCount, True, "", "(intPlayoffAvail04 = " & constPlayoffAvailDAYONLY & " AND intDistance < " & intMilesLow & ")", "", 99996)

						strDay = "SAT"
						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT * FROM " & strSourceView & " WHERE (strClass = 'A' OR strClass = 'B' AND intDayNo = 3) AND (officialID2 Is Null OR officialID2 = '') ORDER BY intOfficialGameLevel"
						PlaceOfficialsInSlotNo(False, 2, strDay, strSQL, strSQLCount, True, "", "(intPlayoffAvail05 = " & constPlayoffAvailDAYONLY & " AND intDistance < " & intMilesLow & ")", "", 99996)

						strDay = "FRI"
						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT * FROM " & strSourceView & " WHERE (strClass = 'A' OR strClass = 'B' AND intDayNo = 2) AND (officialID2 Is Null OR officialID2 = '') ORDER BY intOfficialGameLevel"
						PlaceOfficialsInSlotNo(False, 2, strDay, strSQL, strSQLCount, True, "", "(intPlayoffAvail04 = " & constPlayoffAvailDAYONLY & " AND intDistance < " & intMilesLow & ")", "", 99996)

						' NIGHT or BOTH...
						strDay = "SAT"
						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT * FROM " & strSourceView & " WHERE (strClass = 'A' OR strClass = 'B' AND intDayNo = 3) AND (officialID1 Is Null OR officialID1 = '' OR officialID1 = 99996) ORDER BY intOfficialGameLevel"
						PlaceOfficialsInSlotNo(False, 1, strDay, strSQL, strSQLCount, True, "", "(intPlayoffAvail05 >= " & constPlayoffAvailNIGHTONLY & " AND intDistance < " & intMilesLow & ")", "", 99997)

						strDay = "FRI"
						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT * FROM " & strSourceView & " WHERE (strClass = 'A' OR strClass = 'B' AND intDayNo = 2) AND (officialID1 Is Null OR officialID1 = '' OR officialID1 = 99996) ORDER BY intOfficialGameLevel"
						PlaceOfficialsInSlotNo(False, 1, strDay, strSQL, strSQLCount, True, "", "(intPlayoffAvail04 >= " & constPlayoffAvailNIGHTONLY & " AND intDistance < " & intMilesLow & ")", "", 99997)

						strDay = "SAT"
						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT * FROM " & strSourceView & " WHERE (strClass = 'A' OR strClass = 'B' AND intDayNo = 3) AND (officialID2 Is Null OR officialID2 = '' OR officialID2 = 99996) ORDER BY intOfficialGameLevel"
						PlaceOfficialsInSlotNo(False, 2, strDay, strSQL, strSQLCount, True, "", "(intPlayoffAvail05 >= " & constPlayoffAvailNIGHTONLY & " AND intDistance < " & intMilesLow & ")", "", 99997)

						strDay = "FRI"
						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT * FROM " & strSourceView & " WHERE (strClass = 'A' OR strClass = 'B' AND intDayNo = 2) AND (officialID2 Is Null OR officialID2 = '' OR officialID2 = 99996) ORDER BY intOfficialGameLevel"
						PlaceOfficialsInSlotNo(False, 2, strDay, strSQL, strSQLCount, True, "", "(intPlayoffAvail04 >= " & constPlayoffAvailNIGHTONLY & " AND intDistance < " & intMilesLow & ")", "", 99997)

Cleanup:

						' CLEAN UP...
						strDay = "SAT"
						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT * FROM " & strSourceView & " WHERE (strClass = 'A' OR strClass = 'B' AND intDayNo = 3) AND (officialID1 = 99998) ORDER BY intOfficialGameLevel"
						PlaceOfficialsInSlotNo(False, 1, strDay, strSQL, strSQLCount, True, "", "(intPlayoffAvail05 >= " & constPlayoffAvailNIGHTONLY & " AND intDistance < " & intMilesHigh + 20 & ")", "", 99999)

						strDay = "FRI"
						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT * FROM " & strSourceView & " WHERE (strClass = 'A' OR strClass = 'B' AND intDayNo = 2) AND (officialID1 = 99998) ORDER BY intOfficialGameLevel"
						PlaceOfficialsInSlotNo(False, 1, strDay, strSQL, strSQLCount, True, "", "(intPlayoffAvail04 >= " & constPlayoffAvailNIGHTONLY & " AND intDistance < " & intMilesHigh + 20 & ")", "", 99999)

						strDay = "SAT"
						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT * FROM " & strSourceView & " WHERE (strClass = 'A' OR strClass = 'B' AND intDayNo = 3) AND (officialID2 = 99998) ORDER BY intOfficialGameLevel"
						PlaceOfficialsInSlotNo(False, 2, strDay, strSQL, strSQLCount, True, "", "(intPlayoffAvail05 >= " & constPlayoffAvailNIGHTONLY & " AND intDistance < " & intMilesHigh + 20 & ")", "", 99999)

						strDay = "FRI"
						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT * FROM " & strSourceView & " WHERE (strClass = 'A' OR strClass = 'B' AND intDayNo = 2) AND (officialID2 = 99998) ORDER BY intOfficialGameLevel"
						PlaceOfficialsInSlotNo(False, 2, strDay, strSQL, strSQLCount, True, "", "(intPlayoffAvail04 >= " & constPlayoffAvailNIGHTONLY & " AND intDistance < " & intMilesHigh + 20 & ")", "", 99999)

					ElseIf strClasses = "AB" Then

						If strDay = "FRI" Then
							'	
							'GoTo ComeHere
							intDayNo = 2
							' Official #1 NIGHT...
							strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
							strSQL = "SELECT * FROM " & strSourceView & " WHERE (strClass = 'B') AND (officialID1 Is Null OR officialID1 = 99989) AND intOfficialGameLevel = 10 ORDER BY GameLocationID"
							PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail04 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0 AND intDistance < " & intMilesLow + 5 & ")", "rankRating, intDistance", 99990)

							strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
							strSQL = "SELECT * FROM " & strSourceView & " WHERE (strClass = 'A') AND (officialID1 Is Null OR officialID1 = 99989) AND intOfficialGameLevel = 10 ORDER BY GameLocationID"
							PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail04 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0 AND intDistance < " & intMilesLow & ")", "rankRating, intDistance", 99990)

							' Official #1 AFTERNOON...
							strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
							strSQL = "SELECT * FROM " & strSourceView & " WHERE (strClass = 'A') AND (officialID1 Is Null OR officialID1 = 99989 OR officialID1 = 99990) AND intOfficialGameLevel = 10 ORDER BY GameLocationID DESC"
							PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, False, "", "((intPlayoffAvail04 = " & constPlayoffAvailDAYONLY & " OR intPlayoffAvail04 = " & constPlayoffAvailDAYNIGHT & ") AND intPreferentialLists > 0 AND intDistance < " & intMilesLow & ")", "rankRating, intDistance", 99991)

							strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
							strSQL = "SELECT * FROM " & strSourceView & " WHERE (strClass = 'B') AND (officialID1 Is Null OR officialID1 = 99989 OR officialID1 = 99990) AND intOfficialGameLevel = 10 ORDER BY GameLocationID DESC"
							PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, False, "", "((intPlayoffAvail04 = " & constPlayoffAvailDAYONLY & " OR intPlayoffAvail04 = " & constPlayoffAvailDAYNIGHT & ") AND intPreferentialLists > 0 AND intDistance < " & intMilesLow + 5 & ")", "rankRating, intDistance", 99991)

							' Official #2 NIGHT ...
							strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
							strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = 'B') AND (officialID2 Is Null  OR officialID2 = 99989 OR officialID1 = 99990 OR officialID2 = 99991) AND intOfficialGameLevel = 10 ORDER BY GameLocationID"
							PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail04 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0 AND intDistance < " & intMilesLow & ")", "rankRating, intDistance", 99992)

							strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
							strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = 'A') AND (officialID2 Is Null OR officialID2 = 99989 OR officialID2 = 99990 OR officialID2 = 99991) AND intOfficialGameLevel = 10 ORDER BY GameLocationID"
							PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail04 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0 AND intDistance < " & intMilesLow & ")", "rankRating, intDistance", 99992)

							' Official #2 AFTERNOON ...
							strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
							strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = 'A') AND (officialID2 Is Null OR officialID2 = 99989 OR officialID2 = 99990 OR officialID2 = 99991 OR officialID2 = 99992) AND intOfficialGameLevel = 10 ORDER BY GameLocationID"
							PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, False, "", "((intPlayoffAvail04 = " & constPlayoffAvailDAYONLY & " OR intPlayoffAvail04 = " & constPlayoffAvailDAYNIGHT & ") AND intPreferentialLists > 0 AND intDistance < " & intMilesLow & ")", "rankRating, intDistance", 99993)

							strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
							strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = 'B') AND (officialID2 Is Null OR officialID2 = 99989 OR officialID2 = 99990 OR officialID2 = 99991 OR officialID2 = 99992) AND intOfficialGameLevel = 10 ORDER BY GameLocationID"
							PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, False, "", "((intPlayoffAvail04 = " & constPlayoffAvailDAYONLY & " OR intPlayoffAvail04 = " & constPlayoffAvailDAYNIGHT & ") AND intPreferentialLists > 0 AND intDistance < " & intMilesLow & ")", "rankRating, intDistance", 99993)
ComeHere:
							' CLEANUP...
							' Official #1 NIGHT ...
							strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
							strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = 'B') AND (officialID1 Is Null  OR officialID1 = 99989 OR officialID1 = 99990 OR officialID1 = 99991 OR officialID1 = 99992 OR officialID1 = 99993) AND intOfficialGameLevel = 10 ORDER BY GameLocationID DESC"
							PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, True, "*", "(intPlayoffAvail04 >= " & constPlayoffAvailNIGHTONLY & " AND intDistance < " & intMilesHigh & ") AND rankRating <= 500", "intDistance, rankRating", 99994)

							strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
							strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = 'A') AND (officialID1 Is Null OR officialID1 = 99989 OR officialID1 = 99990 OR officialID1 = 99991 OR officialID1 = 99992 OR officialID1 = 99993) AND intOfficialGameLevel = 10 ORDER BY GameLocationID DESC"
							PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, True, "*", "(intPlayoffAvail04 >= " & constPlayoffAvailNIGHTONLY & " AND intDistance < " & intMilesHigh & ") AND rankRating <= 500", "intDistance, rankRating", 99994)

							' Official #1 AFTERNOON ...
							strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
							strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = 'A') AND (officialID1 Is Null OR officialID2 = 99989 OR officialID1 = 99990 OR officialID2 = 99991 OR officialID1 = 99992 OR officialID1 = 99993 OR officialID1 = 99994) AND intOfficialGameLevel = 10 ORDER BY GameLocationID DESC"
							PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, True, "*", "((intPlayoffAvail04 = " & constPlayoffAvailDAYONLY & " OR intPlayoffAvail04 = " & constPlayoffAvailDAYNIGHT & ") AND intDistance < " & intMilesHigh & ") AND rankRating <= 500", "intDistance, rankRating", 99995)

							strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
							strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = 'B') AND (officialID1 Is Null OR officialID2 = 99989 OR officialID1 = 99990 OR officialID2 = 99991 OR officialID1 = 99992 OR officialID1 = 99993 OR officialID1 = 99994) AND intOfficialGameLevel = 10 ORDER BY GameLocationID DESC"
							PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, True, "*", "((intPlayoffAvail04 = " & constPlayoffAvailDAYONLY & " OR intPlayoffAvail04 = " & constPlayoffAvailDAYNIGHT & ") AND intDistance < " & intMilesHigh & ") AND rankRating <= 500", "intDistance, rankRating", 99995)

							' Official #2 NIGHT ...
							strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
							strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = 'B') AND (officialID2 Is Null  OR officialID2 = 99989 OR officialID2 = 99990 OR officialID2 = 99991 OR officialID2 = 99992 OR officialID2 = 99993) AND intOfficialGameLevel = 10 ORDER BY GameLocationID DESC"
							PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, True, "*", "(intPlayoffAvail04 >= " & constPlayoffAvailNIGHTONLY & " AND intDistance < " & intMilesHigh & ") AND rankRating <= 500", "intDistance, rankRating", 99994)

							strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
							strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = 'A') AND (officialID2 Is Null OR officialID2 = 99989 OR officialID2 = 99990 OR officialID2 = 99991 OR officialID2 = 99992 OR officialID2 = 99993) AND intOfficialGameLevel = 10 ORDER BY GameLocationID DESC"
							PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, True, "*", "(intPlayoffAvail04 >= " & constPlayoffAvailNIGHTONLY & " AND intDistance < " & intMilesHigh & ") AND rankRating <= 500", "intDistance, rankRating", 99994)

							' Official #2 AFTERNOON ...
							strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
							strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = 'A') AND (officialID2 Is Null OR officialID2 = 99989 OR officialID2 = 99990 OR officialID2 = 99991 OR officialID2 = 99992 OR officialID2 = 99993 OR officialID2 = 99994) AND intOfficialGameLevel = 10 ORDER BY GameLocationID DESC"
							PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, True, "*", "((intPlayoffAvail04 = " & constPlayoffAvailDAYONLY & " OR intPlayoffAvail04 = " & constPlayoffAvailDAYNIGHT & ") AND intDistance < " & intMilesHigh & ") AND rankRating <= 500", "intDistance, rankRating", 99995)

							strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
							strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = 'B') AND (officialID2 Is Null OR officialID2 = 99989 OR officialID2 = 99990 OR officialID2 = 99991 OR officialID2 = 99992 OR officialID2 = 99993 OR officialID2 = 99994) AND intOfficialGameLevel = 10 ORDER BY GameLocationID DESC"
							PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, True, "*", "((intPlayoffAvail04 = " & constPlayoffAvailDAYONLY & " OR intPlayoffAvail04 = " & constPlayoffAvailDAYNIGHT & ") AND intDistance < " & intMilesHigh & ") AND rankRating <= 500", "intDistance, rankRating", 99995)

						ElseIf strDay = "SAT" Then

							intDayNo = 3
							GoTo ABCD
							' Official #1 NIGHT...							
							strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
							strSQL = "SELECT * FROM " & strSourceView & " WHERE (strClass = 'A') AND (officialID1 Is Null) ORDER BY GameLocationID"
							PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail05 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0 AND intDistance < " & intMilesLow & ")", "rankRating, intDistance", 99990)

							strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
							strSQL = "SELECT * FROM " & strSourceView & " WHERE (strClass = 'B') AND (officialID1 Is Null) ORDER BY GameLocationID"
							PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail05 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0 AND intDistance < " & intMilesLow + 5 & ")", "rankRating, intDistance", 99990)

							' Official #1 AFTERNOON...
							strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
							strSQL = "SELECT * FROM " & strSourceView & " WHERE (strClass = 'A') AND (officialID1 Is Null OR officialID1 = 99989 OR officialID1 = 99990) ORDER BY GameLocationID DESC"
							PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, False, "", "((intPlayoffAvail05 = " & constPlayoffAvailDAYONLY & " OR intPlayoffAvail05 = " & constPlayoffAvailDAYNIGHT & ") AND intPreferentialLists > 0 AND intDistance < " & intMilesLow & ")", "rankRating, intDistance", 99991)

							strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
							strSQL = "SELECT * FROM " & strSourceView & " WHERE (strClass = 'B') AND (officialID1 Is Null OR officialID1 = 99989 OR officialID1 = 99990)  ORDER BY GameLocationID DESC"
							PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, False, "", "((intPlayoffAvail05 = " & constPlayoffAvailDAYONLY & " OR intPlayoffAvail05 = " & constPlayoffAvailDAYNIGHT & ") AND intPreferentialLists > 0 AND intDistance < " & intMilesLow + 5 & ")", "rankRating, intDistance", 99991)

							' Official #2 NIGHT ...
							strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
							strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = 'B') AND (officialID2 Is Null OR officialID2 = 99991) ORDER BY GameLocationID"
							PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail05 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0 AND intDistance < " & intMilesLow & ")", "rankRating, intDistance", 99992)

							strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
							strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = 'A') AND (officialID2 Is Null OR officialID2 = 99991) ORDER BY GameLocationID"
							PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail05 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0 AND intDistance < " & intMilesLow & ")", "rankRating, intDistance", 99992)

							' Official #2 AFTERNOON ...
							strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
							strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = 'A') AND (officialID2 Is Null OR officialID2 = 99991 OR officialID2 = 99992) ORDER BY GameLocationID"
							PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, False, "", "((intPlayoffAvail05 = " & constPlayoffAvailDAYONLY & " OR intPlayoffAvail05 = " & constPlayoffAvailDAYNIGHT & ") AND intPreferentialLists > 0 AND intDistance < " & intMilesLow & ")", "rankRating, intDistance", 99993)

							strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
							strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = 'B') AND (officialID2 Is Null OR officialID2 = 99991 OR officialID2 = 99992) ORDER BY GameLocationID"
							PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, False, "", "((intPlayoffAvail05 = " & constPlayoffAvailDAYONLY & " OR intPlayoffAvail05 = " & constPlayoffAvailDAYNIGHT & ") AND intPreferentialLists > 0 AND intDistance < " & intMilesLow & ")", "rankRating, intDistance", 99993)

							' CLEANUP...
							' Official #1 NIGHT ...

							strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
							strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = 'A') AND (officialID1 Is Null OR officialID1 = 99989 OR officialID1 = 99990 OR officialID1 = 99991 OR officialID1 = 99992 OR officialID1 = 99993) ORDER BY GameLocationID DESC"
							PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, True, "*", "(intPlayoffAvail05 >= " & constPlayoffAvailNIGHTONLY & " AND intDistance < " & intMilesHigh & ") AND rankRating <= 500", "intDistance, rankRating", 99994)

							strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
							strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = 'B') AND (officialID1 Is Null  OR officialID1 = 99989 OR officialID1 = 99990 OR officialID1 = 99991 OR officialID1 = 99992 OR officialID1 = 99993) ORDER BY GameLocationID DESC"
							PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, True, "*", "(intPlayoffAvail05 >= " & constPlayoffAvailNIGHTONLY & " AND intDistance < " & intMilesHigh & ") AND rankRating <= 500", "intDistance, rankRating", 99994)

							' Official #1 AFTERNOON ...
							'strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
							'strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = 'A') AND (officialID1 Is Null OR officialID2 = 99989 OR officialID1 = 99990 OR officialID2 = 99991 OR officialID1 = 99992 OR officialID1 = 99993 OR officialID1 = 99994) ORDER BY GameLocationID DESC"
							'PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, True, "*", "((intPlayoffAvail05 = " & constPlayoffAvailDAYONLY & " OR intPlayoffAvail05 = " & constPlayoffAvailDAYNIGHT & ") AND intDistance < " & intMilesHigh & ") AND rankRating <= 500", "intDistance, rankRating", 99995)

							'strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
							'strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = 'B') AND (officialID1 Is Null OR officialID2 = 99989 OR officialID1 = 99990 OR officialID2 = 99991 OR officialID1 = 99992 OR officialID1 = 99993 OR officialID1 = 99994) ORDER BY GameLocationID DESC"
							'PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, True, "*", "((intPlayoffAvail05 = " & constPlayoffAvailDAYONLY & " OR intPlayoffAvail05 = " & constPlayoffAvailDAYNIGHT & ") AND intDistance < " & intMilesHigh & ") AND rankRating <= 500", "intDistance, rankRating", 99995)
ABCD:
							' Official #2 NIGHT ...
							strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
							strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = 'B') AND (officialID2 Is Null OR officialID2 = 99900 OR officialID2 = 99989 OR officialID2 = 99990 OR officialID2 = 99991 OR officialID2 = 99992 OR officialID2 = 99993) ORDER BY GameLocationID DESC"
							PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, True, "*", "(intPlayoffAvail05 >= " & constPlayoffAvailNIGHTONLY & " AND intDistance < " & intMilesHigh & ") AND rankRating <= 500", "intDistance, rankRating", 99994)

							strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
							strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = 'A') AND (officialID2 Is Null OR officialID2 = 99900 OR officialID2 = 99989 OR officialID2 = 99990 OR officialID2 = 99991 OR officialID2 = 99992 OR officialID2 = 99993) ORDER BY GameLocationID DESC"
							PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, True, "*", "(intPlayoffAvail05 >= " & constPlayoffAvailNIGHTONLY & " AND intDistance < " & intMilesHigh & ") AND rankRating <= 500", "intDistance, rankRating", 99994)

							' Official #2 AFTERNOON ...
							strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
							strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = 'A') AND (officialID2 Is Null OR officialID2 = 99900 OR officialID2 = 99989 OR officialID2 = 99990 OR officialID2 = 99991 OR officialID2 = 99992 OR officialID2 = 99993 OR officialID2 = 99994) ORDER BY GameLocationID DESC"
							PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, True, "*", "((intPlayoffAvail05 = " & constPlayoffAvailDAYONLY & " OR intPlayoffAvail05 = " & constPlayoffAvailDAYNIGHT & ") AND intDistance < " & intMilesHigh & ") AND rankRating <= 500", "intDistance, rankRating", 99995)

							strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
							strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = 'B') AND (officialID2 Is Null OR officialID2 = 99900 OR officialID2 = 99989 OR officialID2 = 99990 OR officialID2 = 99991 OR officialID2 = 99992 OR officialID2 = 99993 OR officialID2 = 99994) ORDER BY GameLocationID DESC"
							PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, True, "*", "((intPlayoffAvail05 = " & constPlayoffAvailDAYONLY & " OR intPlayoffAvail05 = " & constPlayoffAvailDAYNIGHT & ") AND intDistance < " & intMilesHigh & ") AND rankRating <= 500", "intDistance, rankRating", 99995)
						End If


				Else
						' Do nothing...
					End If
				End If
			' ====================================================== WEEK #3...
			Case 3

				If strClasses = "6A5A" Then
					' TO CLEAR : UPDATE tblTournamentDetailBB SET officialID1 = Null, officialID2 = Null, officialID3 = Null, officialName1 = Null, officialName2 = Null, officialName3 = Null, officialMiles1 = Null, officialMiles2 = Null, officialMiles3 = Null, officialRating1 = Null, officialRating2 = Null, officialRating3 = Null WHERE (intYear = 19) AND (strClass = '6A' OR strClass = '5A') AND (intWeekNo = 3) AND (intManualAssign = 0) AND strLevel = 'R'
					'___assignGAMES_Week3_6A5A_ThursRANKED
					'GoTo DoRemaining
					GoTo FinishFriday
					' =======================================
					intDayNo = 1

					strDay = "THURS"
					strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
					strSQL = "SELECT * FROM " & strSourceView & " WHERE (officialID3 Is Null) ORDER BY WinsTotalAndDiff DESC"
					PlaceOfficialsInSlotNo(True, 3, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail06 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists = 1 AND intDistrictPrefRank > 0 AND intDistance < " & intMilesLow & ")", "", 99990)

					strDay = "THURS"
					strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
					strSQL = "SELECT * FROM " & strSourceView & " WHERE (officialID1 Is Null) ORDER BY WinsTotalAndDiff DESC"
					PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail06 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0 AND intDistrictPrefRank > 0 AND intDistance < " & intMilesLow & ")", "", 99990)

					strDay = "THURS"
					strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
					strSQL = "SELECT * FROM " & strSourceView & " WHERE (officialID2 Is Null) ORDER BY WinsTotalAndDiff DESC"
					PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail06 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0 AND intDistrictPrefRank > 0 AND intDistance < " & intMilesLow & ")", "", 99990)
IAMHere:
					strDay = "THURS"
					strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
					strSQL = "SELECT * FROM " & strSourceView & " WHERE (officialID2 Is Null OR officialID2 = '' OR officialID2 = 99990) ORDER BY WinsTotalAndDiff DESC"
					PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail06 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0 AND intDistrictPrefRank > 0 AND intDistance < " & intMilesHigh & ")", "", 99991)
DoFriday:
					' ============================
					intDayNo = 2
					strDay = "FRI"
					strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
					strSQL = "SELECT * FROM " & strSourceView & " WHERE (officialID3 Is Null) ORDER BY WinsTotalAndDiff DESC"
					PlaceOfficialsInSlotNo(True, 3, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail07 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists = 1 AND intDistrictPrefRank > 0 AND intDistance < " & intMilesLow & ")", "", 99990)

					strDay = "FRI"
					strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
					strSQL = "SELECT * FROM " & strSourceView & " WHERE (officialID1 Is Null) ORDER BY WinsTotalAndDiff DESC"
					PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail07 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0 AND intDistrictPrefRank > 0 AND intDistance < " & intMilesLow & ")", "", 99990)

					strDay = "FRI"
					strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
					strSQL = "SELECT * FROM " & strSourceView & " WHERE (officialID2 Is Null) ORDER BY WinsTotalAndDiff DESC"
					PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail07 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0 AND intDistrictPrefRank > 0 AND intDistance < " & intMilesLow & ")", "", 99990)

					strDay = "FRI"
					strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
					strSQL = "SELECT * FROM " & strSourceView & " WHERE (officialID3 Is Null or officialID3 = 99990) ORDER BY WinsTotalAndDiff DESC"
					PlaceOfficialsInSlotNo(True, 3, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail07 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0 AND intDistrictPrefRank > 0 AND intDistance < " & intMilesLow & ")", "", 99991)

DoSaturday:
					' ===================================
					intDayNo = 3
					strDay = "SAT"
					strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
					strSQL = "SELECT * FROM " & strSourceView & " WHERE (officialID1 Is Null) ORDER BY WinsTotalAndDiff DESC"
					PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail08 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 1 AND intDistance < " & intMilesLow + 20 & ")", "", 99990)

					strDay = "SAT"
					strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
					strSQL = "SELECT * FROM " & strSourceView & " WHERE (officialID2 Is Null) ORDER BY WinsTotalAndDiff DESC"
					PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail08 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0 AND intDistance < " & intMilesLow + 20 & ")", "", 99990)

					strDay = "SAT"
					strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
					strSQL = "SELECT * FROM " & strSourceView & " WHERE (officialID3 Is Null or officialID3 = 99990) ORDER BY WinsTotalAndDiff DESC"
					PlaceOfficialsInSlotNo(True, 3, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail08 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0 AND intDistance < " & intMilesLow + 20 & ")", "", 99991)

DoRemaining:
					intDayNo = 1
					strDay = "THURS"
					strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
					strSQL = "SELECT * FROM " & strSourceView & " WHERE (officialID1 Is Null or officialID1 = 99990) ORDER BY WinsTotalAndDiff DESC"
					PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail06 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0 AND intDistrictPrefRank > 0 AND intDistance < " & intMilesHigh & ")", "", 99990)

					strDay = "THURS"
					strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
					strSQL = "SELECT * FROM " & strSourceView & " WHERE (officialID2 Is Null or officialID2 = 99990) ORDER BY WinsTotalAndDiff DESC"
					PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail06 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0 AND intDistrictPrefRank > 0 AND intDistance < " & intMilesHigh & ")", "", 99990)

					strDay = "THURS"
					strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
					strSQL = "SELECT * FROM " & strSourceView & " WHERE (officialID3 Is Null or officialID3 = 99990) ORDER BY WinsTotalAndDiff DESC"
					PlaceOfficialsInSlotNo(True, 3, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail06 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0 AND intDistrictPrefRank > 0 AND intDistance < " & intMilesHigh & ")", "", 99991)

intDayNo = 3
					strDay = "SAT"
					strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
					strSQL = "SELECT * FROM " & strSourceView & " WHERE (officialID1 Is Null or officialID1 = 99990) ORDER BY WinsTotalAndDiff DESC"
					PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail08 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0 AND intDistance < " & intMilesHigh & ")", "", 99992)

					strDay = "SAT"
					strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
					strSQL = "SELECT * FROM " & strSourceView & " WHERE (officialID2 Is Null or officialID2 = 99990) ORDER BY WinsTotalAndDiff DESC"
					PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail08 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0 AND intDistance < " & intMilesHigh & ")", "", 99992)

					strDay = "SAT"
					strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
					strSQL = "SELECT * FROM " & strSourceView & " WHERE (officialID3 Is Null or officialID3 = 99990) ORDER BY WinsTotalAndDiff DESC"
					PlaceOfficialsInSlotNo(True, 3, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail08 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0 AND intDistance < " & intMilesHigh & ")", "", 99992)
FinishFriday:
					intDayNo = 2
					strDay = "FRI"
					strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
					strSQL = "SELECT * FROM " & strSourceView & " WHERE (officialID1 Is Null or officialID1 = 99990) ORDER BY WinsTotalAndDiff DESC"
					PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail07 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0 AND intDistance < " & intMilesHigh & ")", "", 99992)

					strDay = "FRI"
					strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
					strSQL = "SELECT * FROM " & strSourceView & " WHERE (officialID2 Is Null or officialID2 = 99990) ORDER BY WinsTotalAndDiff DESC"
					PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail07 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0 AND intDistance < " & intMilesHigh & ")", "", 99992)

					strDay = "FRI"
					strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
					strSQL = "SELECT * FROM " & strSourceView & " WHERE (officialID3 Is Null or officialID3 = 99990) ORDER BY WinsTotalAndDiff DESC"
					PlaceOfficialsInSlotNo(True, 3, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail07 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0 AND intDistance < " & intMilesHigh & ")", "", 99992)

					'====================================================================== WEEK #3...
					'====================================================================== 4A-2A...
				ElseIf strClasses = "4A2A" Then

					If strDay = "THURS" Then
						'GoTo FinalCleanup
						intDayNo = 1
						' Official #1 NIGHT...
						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT * FROM " & strSourceView & " WHERE (strClass = '2A') AND (officialID1 Is Null OR officialID1 = 99989) AND intOfficialGameLevel = 11 ORDER BY GameLocationID"
						PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail06 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0 AND intDistance < " & intMilesLow + 5 & ")", "rankRating, intDistance", 99990)

						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT * FROM " & strSourceView & " WHERE (strClass = '3A') AND (officialID1 Is Null OR officialID1 = 99989) AND intOfficialGameLevel = 11 ORDER BY GameLocationID"
						PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail06 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0 AND intDistance < " & intMilesLow & ")", "rankRating, intDistance", 99990)

						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT * FROM " & strSourceView & " WHERE (strClass = '4A') AND (officialID1 Is Null OR officialID1 = 99989) AND intOfficialGameLevel = 11 ORDER BY GameLocationID"
						PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail06 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0 AND intDistance < " & intMilesLow & ")", "rankRating, intDistance", 99990)

						' Official #1 AFTERNOON...
						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT * FROM " & strSourceView & " WHERE (strClass = '3A') AND (officialID1 Is Null OR officialID1 = 99989 OR officialID1 = 99990) AND intOfficialGameLevel = 12 ORDER BY GameLocationID DESC"
						PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, False, "", "((intPlayoffAvail06 = " & constPlayoffAvailDAYONLY & " OR intPlayoffAvail06 = " & constPlayoffAvailDAYNIGHT & ") AND intPreferentialLists > 0 AND intDistance < " & intMilesLow & ")", "rankRating, intDistance", 99991)

						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT * FROM " & strSourceView & " WHERE (strClass = '4A') AND (officialID1 Is Null OR officialID1 = 99989 OR officialID1 = 99990) AND intOfficialGameLevel = 12 ORDER BY GameLocationID DESC"
						PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, False, "", "((intPlayoffAvail06 = " & constPlayoffAvailDAYONLY & " OR intPlayoffAvail06 = " & constPlayoffAvailDAYNIGHT & ") AND intPreferentialLists > 0 AND intDistance < " & intMilesLow & ")", "rankRating, intDistance", 99991)

						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT * FROM " & strSourceView & " WHERE (strClass = '2A') AND (officialID1 Is Null OR officialID1 = 99989 OR officialID1 = 99990) AND intOfficialGameLevel = 12 ORDER BY GameLocationID DESC"
						PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, False, "", "((intPlayoffAvail06 = " & constPlayoffAvailDAYONLY & " OR intPlayoffAvail06 = " & constPlayoffAvailDAYNIGHT & ") AND intPreferentialLists > 0 AND intDistance < " & intMilesLow + 5 & ")", "rankRating, intDistance", 99991)

						' Official #2 NIGHT ...
						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '4A') AND (officialID2 Is Null OR officialID2 = 99989 OR officialID2 = 99990 OR officialID2 = 99991) AND intOfficialGameLevel = 11 ORDER BY GameLocationID"
						PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail06 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0 AND intDistance < " & intMilesLow & ")", "rankRating, intDistance", 99992)

						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '2A') AND (officialID2 Is Null  OR officialID2 = 99989 OR officialID1 = 99990 OR officialID2 = 99991) AND intOfficialGameLevel = 11 ORDER BY GameLocationID"
						PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail06 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0 AND intDistance < " & intMilesLow & ")", "rankRating, intDistance", 99992)

						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '3A') AND (officialID2 Is Null OR officialID2 = 99989 OR officialID2 = 99990 OR officialID2 = 99991) AND intOfficialGameLevel = 11 ORDER BY GameLocationID"
						PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail06 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0 AND intDistance < " & intMilesLow & ")", "rankRating, intDistance", 99992)

						' Official #2 AFTERNOON ...
						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '4A') AND (officialID2 Is Null OR officialID2 = 99989 OR officialID2 = 99990 OR officialID2 = 99991 OR officialID2 = 99992) AND intOfficialGameLevel = 12 ORDER BY GameLocationID"
						PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, False, "", "((intPlayoffAvail06 = " & constPlayoffAvailDAYONLY & " OR intPlayoffAvail06 = " & constPlayoffAvailDAYNIGHT & ") AND intPreferentialLists > 0 AND intDistance < " & intMilesLow & ")", "rankRating, intDistance", 99993)

						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '3A') AND (officialID2 Is Null OR officialID2 = 99989 OR officialID2 = 99990 OR officialID2 = 99991 OR officialID2 = 99992) AND intOfficialGameLevel = 12 ORDER BY GameLocationID"
						PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, False, "", "((intPlayoffAvail06 = " & constPlayoffAvailDAYONLY & " OR intPlayoffAvail06 = " & constPlayoffAvailDAYNIGHT & ") AND intPreferentialLists > 0 AND intDistance < " & intMilesLow & ")", "rankRating, intDistance", 99993)

						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '2A') AND (officialID2 Is Null OR officialID2 = 99989 OR officialID2 = 99990 OR officialID2 = 99991 OR officialID2 = 99992) AND intOfficialGameLevel = 12 ORDER BY GameLocationID"
						PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, False, "", "((intPlayoffAvail06 = " & constPlayoffAvailDAYONLY & " OR intPlayoffAvail06 = " & constPlayoffAvailDAYNIGHT & ") AND intPreferentialLists > 0 AND intDistance < " & intMilesLow & ")", "rankRating, intDistance", 99993)

						' CLEANUP...
						' Official #2 NIGHT ...
						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '2A') AND (officialID2 Is Null  OR officialID2 = 99989 OR officialID2 = 99990 OR officialID2 = 99991 OR officialID2 = 99992 OR officialID2 = 99993) AND intOfficialGameLevel = 11 ORDER BY GameLocationID DESC"
						PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, True, "*", "(intPlayoffAvail06 >= " & constPlayoffAvailNIGHTONLY & " AND intDistance < " & intMilesHigh & ") AND rankRating <= 300", "intDistance, rankRating", 99994)

						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '4A') AND (officialID2 Is Null OR officialID2 = 99989 OR officialID2 = 99990 OR officialID2 = 99991 OR officialID2 = 99992 OR officialID2 = 99993) AND intOfficialGameLevel = 11 ORDER BY GameLocationID DESC"
						PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, True, "*", "(intPlayoffAvail06 >= " & constPlayoffAvailNIGHTONLY & " AND intDistance < " & intMilesHigh & ") AND rankRating <= 300", "intDistance, rankRating", 99994)

						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '3A') AND (officialID2 Is Null OR officialID2 = 99989 OR officialID2 = 99990 OR officialID2 = 99991 OR officialID2 = 99992 OR officialID2 = 99993) AND intOfficialGameLevel = 11 ORDER BY GameLocationID DESC"
						PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, True, "*", "(intPlayoffAvail06 >= " & constPlayoffAvailNIGHTONLY & " AND intDistance < " & intMilesHigh & ") AND rankRating <= 300", "intDistance, rankRating", 99994)

						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '2A') AND (officialID1 Is Null  OR officialID1 = 99989 OR officialID1 = 99990 OR officialID1 = 99991 OR officialID1 = 99992 OR officialID1 = 99993) AND intOfficialGameLevel = 12 ORDER BY GameLocationID DESC"
						PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, True, "*", "(intPlayoffAvail06 <> " & constPlayoffAvailNIGHTONLY & " AND intDistance < " & intMilesHigh & ") AND rankRating <= 300", "intDistance, rankRating", 99994)

						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '4A') AND (officialID1 Is Null OR officialID1 = 99989 OR officialID1 = 99990 OR officialID1 = 99991 OR officialID1 = 99992 OR officialID1 = 99993) AND intOfficialGameLevel = 12 ORDER BY GameLocationID DESC"
						PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, True, "*", "(intPlayoffAvail06 <> " & constPlayoffAvailNIGHTONLY & " AND intDistance < " & intMilesHigh & ") AND rankRating <= 300", "intDistance, rankRating", 99994)

						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '3A') AND (officialID1 Is Null OR officialID1 = 99989 OR officialID1 = 99990 OR officialID1 = 99991 OR officialID1 = 99992 OR officialID1 = 99993) AND intOfficialGameLevel = 12 ORDER BY GameLocationID DESC"
						PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, True, "*", "(intPlayoffAvail06 <> " & constPlayoffAvailNIGHTONLY & " AND intDistance < " & intMilesHigh & ") AND rankRating <= 300", "intDistance, rankRating", 99994)

						' Official #2 AFTERNOON ...
						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '4A') AND (officialID2 Is Null OR officialID2 = 99989 OR officialID2 = 99990 OR officialID2 = 99991 OR officialID2 = 99992 OR officialID2 = 99993 OR officialID2 = 99994) AND intOfficialGameLevel = 12 ORDER BY GameLocationID DESC"
						PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, True, "*", "((intPlayoffAvail06 = " & constPlayoffAvailDAYONLY & " OR intPlayoffAvail06 = " & constPlayoffAvailDAYNIGHT & ") AND intDistance < " & intMilesHigh & ") AND rankRating <= 300", "intDistance, rankRating", 99995)

						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '3A') AND (officialID2 Is Null OR officialID2 = 99989 OR officialID2 = 99990 OR officialID2 = 99991 OR officialID2 = 99992 OR officialID2 = 99993 OR officialID2 = 99994) AND intOfficialGameLevel = 12 ORDER BY GameLocationID DESC"
						PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, True, "*", "((intPlayoffAvail06 = " & constPlayoffAvailDAYONLY & " OR intPlayoffAvail06 = " & constPlayoffAvailDAYNIGHT & ") AND intDistance < " & intMilesHigh & ") AND rankRating <= 300", "intDistance, rankRating", 99995)

						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '2A') AND (officialID2 Is Null OR officialID2 = 99989 OR officialID2 = 99990 OR officialID2 = 99991 OR officialID2 = 99992 OR officialID2 = 99993 OR officialID2 = 99994) AND intOfficialGameLevel = 12 ORDER BY GameLocationID DESC"
						PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, True, "*", "((intPlayoffAvail06 = " & constPlayoffAvailDAYONLY & " OR intPlayoffAvail06 = " & constPlayoffAvailDAYNIGHT & ") AND intDistance < " & intMilesHigh & ") AND rankRating <= 300", "intDistance, rankRating", 99995)

						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '2A' OR strClass = '3A' OR strClass = '4A') AND (officialID1 Is Null OR officialID1 = 99900) AND strDayNight = 'A' ORDER BY GameLocationID DESC"
						PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, True, "*", "(intPlayoffAvail06 <> " & constPlayoffAvailNIGHTONLY & " AND intDistance < " & intMilesHigh + 20 & ") AND rankRating <= 500", "intDistance, rankRating", 99999)

						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '2A' OR strClass = '3A' OR strClass = '4A') AND (officialID2 Is Null OR officialID2 = 99900) AND strDayNight = 'A' ORDER BY GameLocationID DESC"
						PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, True, "*", "(intPlayoffAvail06 <> " & constPlayoffAvailNIGHTONLY & " AND intDistance < " & intMilesHigh + 25 & ") AND rankRating <= 500", "intDistance, rankRating", 99999)

						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '2A' OR strClass = '3A' OR strClass = '4A') AND (officialID1 Is Null OR officialID1 = 99900) AND strDayNight = 'N' ORDER BY GameLocationID DESC"
						PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, True, "*", "(intPlayoffAvail06 >= " & constPlayoffAvailNIGHTONLY & " AND intDistance < " & intMilesHigh + 20 & ") AND rankRating <= 500", "intDistance, rankRating", 99999)

						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '2A' OR strClass = '3A' OR strClass = '4A') AND (officialID2 Is Null OR officialID2 = 99900) AND strDayNight = 'N' ORDER BY GameLocationID DESC"
						PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, True, "*", "(intPlayoffAvail06 >= " & constPlayoffAvailNIGHTONLY & " AND intDistance < " & intMilesHigh + 25 & ") AND rankRating <= 500", "intDistance, rankRating", 99999)


						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '2A' OR strClass = '3A' OR strClass = '4A') AND (officialID1 Is Null OR officialID1 = 99994) AND strDayNight = 'A' ORDER BY GameLocationID DESC"
						PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, True, "*", "(intPlayoffAvail06 <> " & constPlayoffAvailNIGHTONLY & " AND intDistance < " & intMilesHigh + 20 & ") AND rankRating <= 500", "intDistance, rankRating", 99999)

						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '2A' OR strClass = '3A' OR strClass = '4A') AND (officialID2 Is Null OR officialID2 = 99995) AND strDayNight = 'A' ORDER BY GameLocationID DESC"
						PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, True, "*", "(intPlayoffAvail06 <> " & constPlayoffAvailNIGHTONLY & " AND intDistance < " & intMilesHigh + 35 & ") AND rankRating <= 500", "intDistance, rankRating", 99999)

FinalCleanup:
						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '2A' OR strClass = '3A' OR strClass = '4A') AND (officialID2 Is Null OR officialID2 = 99900) AND strDayNight = 'A' ORDER BY GameLocationID DESC"
						PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, True, "*", "(intPlayoffAvail06 <> " & constPlayoffAvailNIGHTONLY & " AND intDistance < " & intMilesHigh + 35 & ") AND rankRating <= 500", "intDistance, rankRating", 99999)


					ElseIf strDay = "FRI" Then
						GoTo FinFriday
						intDayNo = 2
						' Official #1 NIGHT...
						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT * FROM " & strSourceView & " WHERE (strClass = '2A') AND (officialID1 Is Null OR officialID1 = 99989) AND intOfficialGameLevel = 10 AND strDayNight = 'N' ORDER BY GameLocationID"
						PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail07 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0 AND intDistance < " & intMilesLow + 5 & ")", "rankRating, intDistance", 99990)

						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT * FROM " & strSourceView & " WHERE (strClass = '3A') AND (officialID1 Is Null OR officialID1 = 99989) AND intOfficialGameLevel = 10 AND strDayNight = 'N' ORDER BY GameLocationID"
						PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail07 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0 AND intDistance < " & intMilesLow & ")", "rankRating, intDistance", 99990)

						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT * FROM " & strSourceView & " WHERE (strClass = '4A') AND (officialID1 Is Null OR officialID1 = 99989) AND intOfficialGameLevel = 10 AND strDayNight = 'N' ORDER BY GameLocationID"
						PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail07 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0 AND intDistance < " & intMilesLow & ")", "rankRating, intDistance", 99990)

						' Official #1 AFTERNOON...
						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT * FROM " & strSourceView & " WHERE (strClass = '3A') AND (officialID1 Is Null OR officialID1 = 99989 OR officialID1 = 99990) AND intOfficialGameLevel = 10 AND strDayNight = 'A' ORDER BY GameLocationID DESC"
						PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, False, "", "((intPlayoffAvail07 = " & constPlayoffAvailDAYONLY & " OR intPlayoffAvail07 = " & constPlayoffAvailDAYNIGHT & ") AND intPreferentialLists > 0 AND intDistance < " & intMilesLow & ")", "rankRating, intDistance", 99991)

						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT * FROM " & strSourceView & " WHERE (strClass = '4A') AND (officialID1 Is Null OR officialID1 = 99989 OR officialID1 = 99990) AND intOfficialGameLevel = 10 AND strDayNight = 'A' ORDER BY GameLocationID DESC"
						PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, False, "", "((intPlayoffAvail07 = " & constPlayoffAvailDAYONLY & " OR intPlayoffAvail07 = " & constPlayoffAvailDAYNIGHT & ") AND intPreferentialLists > 0 AND intDistance < " & intMilesLow & ")", "rankRating, intDistance", 99991)

						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT * FROM " & strSourceView & " WHERE (strClass = '2A') AND (officialID1 Is Null OR officialID1 = 99989 OR officialID1 = 99990) AND intOfficialGameLevel = 10 AND strDayNight = 'A' ORDER BY GameLocationID DESC"
						PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, False, "", "((intPlayoffAvail07 = " & constPlayoffAvailDAYONLY & " OR intPlayoffAvail07 = " & constPlayoffAvailDAYNIGHT & ") AND intPreferentialLists > 0 AND intDistance < " & intMilesLow + 5 & ")", "rankRating, intDistance", 99991)

						' Official #2 NIGHT ...
						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '4A') AND (officialID2 Is Null OR officialID2 = 99989 OR officialID2 = 99990 OR officialID2 = 99991) AND intOfficialGameLevel = 10 AND strDayNight = 'N' ORDER BY GameLocationID"
						PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail07 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0 AND intDistance < " & intMilesLow & ")", "rankRating, intDistance", 99992)

						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '2A') AND (officialID2 Is Null  OR officialID2 = 99989 OR officialID1 = 99990 OR officialID2 = 99991) AND intOfficialGameLevel = 10 AND strDayNight = 'N' ORDER BY GameLocationID"
						PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail07 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0 AND intDistance < " & intMilesLow & ")", "rankRating, intDistance", 99992)

						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '3A') AND (officialID2 Is Null OR officialID2 = 99989 OR officialID2 = 99990 OR officialID2 = 99991) AND intOfficialGameLevel = 10 AND strDayNight = 'N' ORDER BY GameLocationID"
						PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail07 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0 AND intDistance < " & intMilesLow & ")", "rankRating, intDistance", 99992)

						' Official #2 AFTERNOON ...
						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '4A') AND (officialID2 Is Null OR officialID2 = 99989 OR officialID2 = 99990 OR officialID2 = 99991 OR officialID2 = 99992) AND intOfficialGameLevel = 10 AND strDayNight = 'A' ORDER BY GameLocationID"
						PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, False, "", "((intPlayoffAvail07 = " & constPlayoffAvailDAYONLY & " OR intPlayoffAvail07 = " & constPlayoffAvailDAYNIGHT & ") AND intPreferentialLists > 0 AND intDistance < " & intMilesLow & ")", "rankRating, intDistance", 99993)

						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '3A') AND (officialID2 Is Null OR officialID2 = 99989 OR officialID2 = 99990 OR officialID2 = 99991 OR officialID2 = 99992) AND intOfficialGameLevel = 10 AND strDayNight = 'A' ORDER BY GameLocationID"
						PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, False, "", "((intPlayoffAvail07 = " & constPlayoffAvailDAYONLY & " OR intPlayoffAvail07 = " & constPlayoffAvailDAYNIGHT & ") AND intPreferentialLists > 0 AND intDistance < " & intMilesLow & ")", "rankRating, intDistance", 99993)

						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '2A') AND (officialID2 Is Null OR officialID2 = 99989 OR officialID2 = 99990 OR officialID2 = 99991 OR officialID2 = 99992) AND intOfficialGameLevel = 10 AND strDayNight = 'A' ORDER BY GameLocationID"
						PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, False, "", "((intPlayoffAvail07 = " & constPlayoffAvailDAYONLY & " OR intPlayoffAvail07 = " & constPlayoffAvailDAYNIGHT & ") AND intPreferentialLists > 0 AND intDistance < " & intMilesLow & ")", "rankRating, intDistance", 99993)

						' CLEANUP...
						' Official #2 NIGHT ...
						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '2A') AND (officialID2 Is Null  OR officialID2 = 99989 OR officialID2 = 99990 OR officialID2 = 99991 OR officialID2 = 99992 OR officialID2 = 99993) AND intOfficialGameLevel = 10 AND strDayNight = 'N' ORDER BY GameLocationID DESC"
						PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, True, "*", "(intPlayoffAvail07 >= " & constPlayoffAvailNIGHTONLY & " AND intDistance < " & intMilesHigh & ") AND rankRating <= 250", "intDistance, rankRating", 99994)

						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '4A') AND (officialID2 Is Null OR officialID2 = 99989 OR officialID2 = 99990 OR officialID2 = 99991 OR officialID2 = 99992 OR officialID2 = 99993) AND intOfficialGameLevel = 10 AND strDayNight = 'N' ORDER BY GameLocationID DESC"
						PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, True, "*", "(intPlayoffAvail07 >= " & constPlayoffAvailNIGHTONLY & " AND intDistance < " & intMilesHigh & ") AND rankRating <= 250", "intDistance, rankRating", 99994)

						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '3A') AND (officialID2 Is Null OR officialID2 = 99989 OR officialID2 = 99990 OR officialID2 = 99991 OR officialID2 = 99992 OR officialID2 = 99993) AND intOfficialGameLevel = 10 AND strDayNight = 'N' ORDER BY GameLocationID DESC"
						PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, True, "*", "(intPlayoffAvail07 >= " & constPlayoffAvailNIGHTONLY & " AND intDistance < " & intMilesHigh & ") AND rankRating <= 250", "intDistance, rankRating", 99994)

						' Official #2 AFTERNOON ...
						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '4A') AND (officialID2 Is Null OR officialID2 = 99989 OR officialID2 = 99990 OR officialID2 = 99991 OR officialID2 = 99992 OR officialID2 = 99993 OR officialID2 = 99994) AND intOfficialGameLevel = 10 AND strDayNight = 'A' ORDER BY GameLocationID DESC"
						PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, True, "*", "((intPlayoffAvail07 = " & constPlayoffAvailDAYONLY & " OR intPlayoffAvail07 = " & constPlayoffAvailDAYNIGHT & ") AND intDistance < " & intMilesHigh & ") AND rankRating <= 250", "intDistance, rankRating", 99995)

						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '3A') AND (officialID2 Is Null OR officialID2 = 99989 OR officialID2 = 99990 OR officialID2 = 99991 OR officialID2 = 99992 OR officialID2 = 99993 OR officialID2 = 99994) AND intOfficialGameLevel = 10 AND strDayNight = 'A' ORDER BY GameLocationID DESC"
						PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, True, "*", "((intPlayoffAvail07 = " & constPlayoffAvailDAYONLY & " OR intPlayoffAvail07 = " & constPlayoffAvailDAYNIGHT & ") AND intDistance < " & intMilesHigh & ") AND rankRating <= 250", "intDistance, rankRating", 99995)

						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '2A') AND (officialID2 Is Null OR officialID2 = 99989 OR officialID2 = 99990 OR officialID2 = 99991 OR officialID2 = 99992 OR officialID2 = 99993 OR officialID2 = 99994) AND intOfficialGameLevel = 10 AND strDayNight = 'A' ORDER BY GameLocationID DESC"
						PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, True, "*", "((intPlayoffAvail07 = " & constPlayoffAvailDAYONLY & " OR intPlayoffAvail07 = " & constPlayoffAvailDAYNIGHT & ") AND intDistance < " & intMilesHigh & ") AND rankRating <= 25	0", "intDistance, rankRating", 99995)
FinFriday:
						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '2A' OR strClass = '3A' OR strClass = '4A') AND (officialID1 Is Null OR officialID1 = 99900) AND strDayNight = 'A' ORDER BY GameLocationID DESC"
						PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, True, "*", "(intPlayoffAvail07 <> " & constPlayoffAvailNIGHTONLY & " AND intDistance < " & intMilesHigh + 20 & ") AND rankRating <= 500", "intDistance, rankRating", 99999)

						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '2A' OR strClass = '3A' OR strClass = '4A') AND (officialID2 Is Null OR officialID2 = 99900) AND strDayNight = 'A' ORDER BY GameLocationID DESC"
						PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, True, "*", "(intPlayoffAvail07 <> " & constPlayoffAvailNIGHTONLY & " AND intDistance < " & intMilesHigh + 25 & ") AND rankRating <= 500", "intDistance, rankRating", 99999)

						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '2A' OR strClass = '3A' OR strClass = '4A') AND (officialID1 Is Null OR officialID1 = 99900) AND strDayNight = 'N' ORDER BY GameLocationID DESC"
						PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, True, "*", "(intPlayoffAvail07 >= " & constPlayoffAvailNIGHTONLY & " AND intDistance < " & intMilesHigh + 20 & ") AND rankRating <= 500", "intDistance, rankRating", 99999)

						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '2A' OR strClass = '3A' OR strClass = '4A') AND (officialID2 Is Null OR officialID2 = 99900) AND strDayNight = 'N' ORDER BY GameLocationID DESC"
						PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, True, "*", "(intPlayoffAvail07 >= " & constPlayoffAvailNIGHTONLY & " AND intDistance < " & intMilesHigh + 25 & ") AND rankRating <= 500", "intDistance, rankRating", 99999)

					ElseIf strDay = "SAT" Then

						intDayNo = 3
						' Official #1 NIGHT...
						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT * FROM " & strSourceView & " WHERE (strClass = '2A') AND (officialID1 Is Null OR officialID1 = 99989) AND intOfficialGameLevel = 10 AND strDayNight = 'N' ORDER BY GameLocationID"
						PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail08 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0 AND intDistance < " & intMilesLow + 5 & ")", "rankRating, intDistance", 99990)

						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT * FROM " & strSourceView & " WHERE (strClass = '3A') AND (officialID1 Is Null OR officialID1 = 99989) AND intOfficialGameLevel = 10 AND strDayNight = 'N' ORDER BY GameLocationID"
						PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail08 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0 AND intDistance < " & intMilesLow & ")", "rankRating, intDistance", 99990)

						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT * FROM " & strSourceView & " WHERE (strClass = '4A') AND (officialID1 Is Null OR officialID1 = 99989) AND intOfficialGameLevel = 10 AND strDayNight = 'N' ORDER BY GameLocationID"
						PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail08 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0 AND intDistance < " & intMilesLow & ")", "rankRating, intDistance", 99990)

						' Official #1 AFTERNOON...
						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT * FROM " & strSourceView & " WHERE (strClass = '3A') AND (officialID1 Is Null OR officialID1 = 99989 OR officialID1 = 99990) AND intOfficialGameLevel = 10 AND strDayNight = 'A' ORDER BY GameLocationID DESC"
						PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, False, "", "((intPlayoffAvail08 = " & constPlayoffAvailDAYONLY & " OR intPlayoffAvail08 = " & constPlayoffAvailDAYNIGHT & ") AND intPreferentialLists > 0 AND intDistance < " & intMilesLow & ")", "rankRating, intDistance", 99991)

						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT * FROM " & strSourceView & " WHERE (strClass = '4A') AND (officialID1 Is Null OR officialID1 = 99989 OR officialID1 = 99990) AND intOfficialGameLevel = 10 AND strDayNight = 'A' ORDER BY GameLocationID DESC"
						PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, False, "", "((intPlayoffAvail08 = " & constPlayoffAvailDAYONLY & " OR intPlayoffAvail08 = " & constPlayoffAvailDAYNIGHT & ") AND intPreferentialLists > 0 AND intDistance < " & intMilesLow & ")", "rankRating, intDistance", 99991)

						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT * FROM " & strSourceView & " WHERE (strClass = '2A') AND (officialID1 Is Null OR officialID1 = 99989 OR officialID1 = 99990) AND intOfficialGameLevel = 10 AND strDayNight = 'A' ORDER BY GameLocationID DESC"
						PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, False, "", "((intPlayoffAvail08 = " & constPlayoffAvailDAYONLY & " OR intPlayoffAvail08 = " & constPlayoffAvailDAYNIGHT & ") AND intPreferentialLists > 0 AND intDistance < " & intMilesLow + 5 & ")", "rankRating, intDistance", 99991)

						' Official #2 NIGHT ...
						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '4A') AND (officialID2 Is Null OR officialID2 = 99989 OR officialID2 = 99990 OR officialID2 = 99991) AND intOfficialGameLevel = 10 AND strDayNight = 'N' ORDER BY GameLocationID"
						PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail08 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0 AND intDistance < " & intMilesLow & ")", "rankRating, intDistance", 99992)

						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '2A') AND (officialID2 Is Null  OR officialID2 = 99989 OR officialID1 = 99990 OR officialID2 = 99991) AND intOfficialGameLevel = 10 AND strDayNight = 'N' ORDER BY GameLocationID"
						PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail08 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0 AND intDistance < " & intMilesLow & ")", "rankRating, intDistance", 99992)

						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '3A') AND (officialID2 Is Null OR officialID2 = 99989 OR officialID2 = 99990 OR officialID2 = 99991) AND intOfficialGameLevel = 10 AND strDayNight = 'N' ORDER BY GameLocationID"
						PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, False, "", "(intPlayoffAvail08 >= " & constPlayoffAvailNIGHTONLY & " AND intPreferentialLists > 0 AND intDistance < " & intMilesLow & ")", "rankRating, intDistance", 99992)

						' Official #2 AFTERNOON ...
						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '4A') AND (officialID2 Is Null OR officialID2 = 99989 OR officialID2 = 99990 OR officialID2 = 99991 OR officialID2 = 99992) AND intOfficialGameLevel = 10 AND strDayNight = 'A' ORDER BY GameLocationID"
						PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, False, "", "((intPlayoffAvail08 = " & constPlayoffAvailDAYONLY & " OR intPlayoffAvail08 = " & constPlayoffAvailDAYNIGHT & ") AND intPreferentialLists > 0 AND intDistance < " & intMilesLow & ")", "rankRating, intDistance", 99993)

						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '3A') AND (officialID2 Is Null OR officialID2 = 99989 OR officialID2 = 99990 OR officialID2 = 99991 OR officialID2 = 99992) AND intOfficialGameLevel = 10 AND strDayNight = 'A' ORDER BY GameLocationID"
						PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, False, "", "((intPlayoffAvail08 = " & constPlayoffAvailDAYONLY & " OR intPlayoffAvail08 = " & constPlayoffAvailDAYNIGHT & ") AND intPreferentialLists > 0 AND intDistance < " & intMilesLow & ")", "rankRating, intDistance", 99993)

						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '2A') AND (officialID2 Is Null OR officialID2 = 99989 OR officialID2 = 99990 OR officialID2 = 99991 OR officialID2 = 99992) AND intOfficialGameLevel = 10 AND strDayNight = 'A' ORDER BY GameLocationID"
						PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, False, "", "((intPlayoffAvail08 = " & constPlayoffAvailDAYONLY & " OR intPlayoffAvail08 = " & constPlayoffAvailDAYNIGHT & ") AND intPreferentialLists > 0 AND intDistance < " & intMilesLow & ")", "rankRating, intDistance", 99993)

						' CLEANUP...
						' Official #2 NIGHT ...
						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '2A') AND (officialID2 Is Null  OR officialID2 = 99989 OR officialID2 = 99990 OR officialID2 = 99991 OR officialID2 = 99992 OR officialID2 = 99993) AND intOfficialGameLevel = 10 AND strDayNight = 'N' ORDER BY GameLocationID DESC"
						PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, True, "*", "(intPlayoffAvail08 >= " & constPlayoffAvailNIGHTONLY & " AND intDistance < " & intMilesHigh & ") AND rankRating <= 250", "intDistance, rankRating", 99994)

						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '4A') AND (officialID2 Is Null OR officialID2 = 99989 OR officialID2 = 99990 OR officialID2 = 99991 OR officialID2 = 99992 OR officialID2 = 99993) AND intOfficialGameLevel = 10 AND strDayNight = 'N' ORDER BY GameLocationID DESC"
						PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, True, "*", "(intPlayoffAvail08 >= " & constPlayoffAvailNIGHTONLY & " AND intDistance < " & intMilesHigh & ") AND rankRating <= 250", "intDistance, rankRating", 99994)

						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '3A') AND (officialID2 Is Null OR officialID2 = 99989 OR officialID2 = 99990 OR officialID2 = 99991 OR officialID2 = 99992 OR officialID2 = 99993) AND intOfficialGameLevel = 10 AND strDayNight = 'N' ORDER BY GameLocationID DESC"
						PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, True, "*", "(intPlayoffAvail08 >= " & constPlayoffAvailNIGHTONLY & " AND intDistance < " & intMilesHigh & ") AND rankRating <= 250", "intDistance, rankRating", 99994)

						' Official #2 AFTERNOON ...
						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '4A') AND (officialID2 Is Null OR officialID2 = 99989 OR officialID2 = 99990 OR officialID2 = 99991 OR officialID2 = 99992 OR officialID2 = 99993 OR officialID2 = 99994) AND intOfficialGameLevel = 10 AND strDayNight = 'A' ORDER BY GameLocationID DESC"
						PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, True, "*", "((intPlayoffAvail08 = " & constPlayoffAvailDAYONLY & " OR intPlayoffAvail08 = " & constPlayoffAvailDAYNIGHT & ") AND intDistance < " & intMilesHigh & ") AND rankRating <= 250", "intDistance, rankRating", 99995)

						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '3A') AND (officialID2 Is Null OR officialID2 = 99989 OR officialID2 = 99990 OR officialID2 = 99991 OR officialID2 = 99992 OR officialID2 = 99993 OR officialID2 = 99994) AND intOfficialGameLevel = 10 AND strDayNight = 'A' ORDER BY GameLocationID DESC"
						PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, True, "*", "((intPlayoffAvail08 = " & constPlayoffAvailDAYONLY & " OR intPlayoffAvail08 = " & constPlayoffAvailDAYNIGHT & ") AND intDistance < " & intMilesHigh & ") AND rankRating <= 250", "intDistance, rankRating", 99995)

						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '2A') AND (officialID2 Is Null OR officialID2 = 99989 OR officialID2 = 99990 OR officialID2 = 99991 OR officialID2 = 99992 OR officialID2 = 99993 OR officialID2 = 99994) AND intOfficialGameLevel = 10 AND strDayNight = 'A' ORDER BY GameLocationID DESC"
						PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, True, "*", "((intPlayoffAvail08 = " & constPlayoffAvailDAYONLY & " OR intPlayoffAvail08 = " & constPlayoffAvailDAYNIGHT & ") AND intDistance < " & intMilesHigh & ") AND rankRating <= 25	0", "intDistance, rankRating", 99995)

						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '2A' OR strClass = '3A' OR strClass = '4A') AND (officialID1 Is Null OR officialID1 = 99900) AND strDayNight = 'A' ORDER BY GameLocationID DESC"
						PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, True, "*", "(intPlayoffAvail08 <> " & constPlayoffAvailNIGHTONLY & " AND intDistance < " & intMilesHigh + 20 & ") AND rankRating <= 500", "intDistance, rankRating", 99999)

						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '2A' OR strClass = '3A' OR strClass = '4A') AND (officialID2 Is Null OR officialID2 = 99900) AND strDayNight = 'A' ORDER BY GameLocationID DESC"
						PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, True, "*", "(intPlayoffAvail08 <> " & constPlayoffAvailNIGHTONLY & " AND intDistance < " & intMilesHigh + 25 & ") AND rankRating <= 500", "intDistance, rankRating", 99999)

						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '2A' OR strClass = '3A' OR strClass = '4A') AND (officialID1 Is Null OR officialID1 = 99900) AND strDayNight = 'N' ORDER BY GameLocationID DESC"
						PlaceOfficialsInSlotNo(True, 1, strDay, strSQL, strSQLCount, True, "*", "(intPlayoffAvail08 >= " & constPlayoffAvailNIGHTONLY & " AND intDistance < " & intMilesHigh + 20 & ") AND rankRating <= 500", "intDistance, rankRating", 99999)

						strSourceView = clsAssign.GetSourceGamesTable(intWeekNo, intDayNo, strClasses, strDay)
						strSQL = "SELECT *, siteKey + '-' + strBracket AS siteKeyWL FROM " & strSourceView & " WHERE (strClass = '2A' OR strClass = '3A' OR strClass = '4A') AND (officialID2 Is Null OR officialID2 = 99900) AND strDayNight = 'N' ORDER BY GameLocationID DESC"
						PlaceOfficialsInSlotNo(True, 2, strDay, strSQL, strSQLCount, True, "*", "(intPlayoffAvail08 >= " & constPlayoffAvailNIGHTONLY & " AND intDistance < " & intMilesHigh + 25 & ") AND rankRating <= 500", "intDistance, rankRating", 99999)

					End If

				End If

			Case 4
			Case 5
		End Select


		lblMessage.Text = "Process complete."

    End Sub


	Public Sub PlaceOfficialsInSlotNo(ysnCheckPreviousRegionKey As Boolean, intSlotNo As Integer, strDay As String, strSQL As String, strSQLCount As String, ysnTurnOffPreferentialConcideration As Boolean, strFlag As String, strAdditionalCriteria As String, strOrderBy As String, intOverrideValue As Long)
		Dim ds As DataSet
		Dim intOSSAAID As Long
		Dim ysnUsePreferential As Boolean = True
		Dim strOfficialName As String = ""
		Dim strOfficialEmail As String = ""         ' CDW added 1/29/2020...
		Dim strOfficialFlag As String = ""
		Dim intOfficialMiles As Long = 0
		Dim intRating As Long = 0
		Dim intRatingPref As Long = 0
		Dim strKey As String = ""
		Dim intRecordsRemaining As Integer = 0
		Dim intRecordsRemainingLast As Integer = 0
		Dim intGameRankings As Integer = 0
		Dim x As Integer = 0
		Dim strMainKey As String = ""

DoItAgain:
		ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

		If ds Is Nothing Then
			Exit Sub
		ElseIf ds.Tables.Count = 0 Then
			Exit Sub
		ElseIf ds.Tables(0).Rows.Count = 0 Then
			Exit Sub
		Else
			x = 0
			If ysnTurnOffPreferentialConcideration Then     ' Override Preferential...
				ysnUsePreferential = False
			Else
				'If ds.Tables(0).Rows(x).Item("strLevel") = "D" Then ysnUsePreferential = True Else ysnUsePreferential = False
			End If

			' Find the official for this game...
			strOfficialName = ""
			strOfficialEmail = ""
			strOfficialFlag = ""
			intOfficialMiles = 0
			intRating = 0
			intRatingPref = 0
			intGameRankings = 0

			If ds.Tables(0).Rows(x).Item("strClass") = "6A" Or ds.Tables(0).Rows(x).Item("strClass") = "5A" Then
				intOSSAAID = clsAssign.GetAnOfficial(ysnCheckPreviousRegionKey, intSlotNo, intWeekNo, intDayNo, strDay, ds.Tables(0).Rows(x).Item("strClass"), ds.Tables(0).Rows(x).Item("strArea"), ds.Tables(0).Rows(x).Item("strDistricts"), ds.Tables(0).Rows(x).Item("strGender"), ds.Tables(0).Rows(x).Item("SiteZip"), ds.Tables(0).Rows(x).Item("mainKeyGender"), ds.Tables(0).Rows(x).Item("regionalKey"), ysnUsePreferential, "BEST", strFlag, strAdditionalCriteria, strOrderBy, intOverrideValue, strOfficialName, intOfficialMiles, intRating, intRatingPref, strOfficialEmail, strOfficialFlag)
			Else
				intOSSAAID = clsAssign.GetAnOfficial(ysnCheckPreviousRegionKey, intSlotNo, intWeekNo, intDayNo, strDay, ds.Tables(0).Rows(x).Item("strClass"), ds.Tables(0).Rows(x).Item("strArea"), ds.Tables(0).Rows(x).Item("strDistricts"), ds.Tables(0).Rows(x).Item("strGender"), ds.Tables(0).Rows(x).Item("SiteZip"), ds.Tables(0).Rows(x).Item("SiteKey"), ds.Tables(0).Rows(x).Item("regionalKey"), ysnUsePreferential, "BEST", strFlag, strAdditionalCriteria, strOrderBy, intOverrideValue, strOfficialName, intOfficialMiles, intRating, intRatingPref, strOfficialEmail, strOfficialFlag)
			End If

			' If an official is found, place the official at the game or site games...
			If intOSSAAID > 0 Then
				' Let's get the key we are using to place the game...
				Select Case ds.Tables(0).Rows(x).Item("strLevel")
					Case "D"
						strKey = ds.Tables(0).Rows(x).Item("siteKey")
					Case "R"
						If ds.Tables(0).Rows(x).Item("strClass") = "6A" Or ds.Tables(0).Rows(x).Item("strClass") = "5A" Then
							strKey = ds.Tables(0).Rows(x).Item("mainKeyGender")
						ElseIf ds.Tables(0).Rows(x).Item("strClass") = "4A" Or ds.Tables(0).Rows(x).Item("strClass") = "3A" Or ds.Tables(0).Rows(x).Item("strClass") = "2A" Then
							If strDay = "THURS" Then
								strKey = ds.Tables(0).Rows(x).Item("regionalKeyGame")
								strMainKey = ds.Tables(0).Rows(x).Item("mainKey")
							ElseIf strDay = "FRI" Then
								strKey = ds.Tables(0).Rows(x).Item("regionalKeyGame")
								strMainKey = ds.Tables(0).Rows(x).Item("mainKey")
								'strKey = ds.Tables(0).Rows(x).Item("siteKey")
							ElseIf strDay = "SAT" Then
								strKey = ds.Tables(0).Rows(x).Item("regionalKeyGame")
								strMainKey = ds.Tables(0).Rows(x).Item("mainKey")
								'strKey = ds.Tables(0).Rows(x).Item("siteKeyWL")
							End If
						ElseIf ds.Tables(0).Rows(x).Item("strClass") = "A" Or ds.Tables(0).Rows(x).Item("strClass") = "B" Then
							If strDay = "THURS" Then
								strKey = ds.Tables(0).Rows(x).Item("regionalKeyGame")
								strMainKey = ds.Tables(0).Rows(x).Item("mainKey")
							ElseIf strDay = "FRI" Then
								strKey = ds.Tables(0).Rows(x).Item("regionalKeyGame")
							ElseIf strDay = "SAT" Then
								strKey = ds.Tables(0).Rows(x).Item("regionalKeyGame")       ' CDW changed 2/13/2020...
								strMainKey = ds.Tables(0).Rows(x).Item("mainKey")
								'strKey = ds.Tables(0).Rows(x).Item("siteKeyWL")
							End If
						End If
					Case "A"
						strKey = ds.Tables(0).Rows(x).Item("mainKey")
					Case "S"
						strKey = ds.Tables(0).Rows(x).Item("mainKey")
				End Select
				If intOSSAAID = 99900 Then
					strOfficialName = ""
					strOfficialEmail = ""
				End If
				clsAssign.PlaceAnOfficial(intOSSAAID, strMainKey, strKey, ds.Tables(0).Rows(x).Item("strLevel"), intSlotNo, strOfficialName, intOfficialMiles, intRating, intRatingPref, strOfficialEmail, strOfficialFlag, ds.Tables(0).Rows(x).Item("intGameRankingsCalc"), strDay, strFlag)
			End If
		End If

			GoTo DoItAgain

	End Sub

End Class