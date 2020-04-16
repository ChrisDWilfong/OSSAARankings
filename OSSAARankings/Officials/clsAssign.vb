Public Class clsAssign


	Shared Sub WriteToLog(strEntry As String)
		Dim strSQL As String = ""
		strSQL = "INSERT INTO __assignOfficialsLog (strEntry) VALUES ('" & strEntry & "')"
		SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
	End Sub

	Shared Function GetAnOfficial(ysnCheckPreviousRegionKey As Boolean, intSlotNo As Integer, intWeekNo As Integer, intDayNo As Integer, strDay As String, strClass As String, strArea As String, strDistricts As String, strGender As String, strSiteZip As String, strSiteKey As String, strRegionalKey As String, ysnUsePreferential As Boolean, strGet As String, strPrefixName As String, strAdditionalCriteria As String, strOrderBy As String, intOverrideValue As Long, ByRef strOfficialName As String, ByRef intOfficialMiles As Long, ByRef intOfficialRating As Long, ByRef intOfficialPrefRating As Long, ByRef strOfficialEmail As String, ByRef strOfficialFlag As String)

		Dim strSourceDistanceTable As String = GetSourceDistanceTable(intWeekNo, intDayNo, ysnUsePreferential, strDay, strClass, strGender)    ' __assignDISTANCESWeek#UsePreferentials
		' NOTE : strDistricts contains '', '1-4', '2-3', '5-8' or '6-7'
		Dim intOSSAAID As Long = 0
		Dim strSQL As String = ""
		Dim x As Integer = 0
		Dim ds As DataSet
		Dim strDistanceWhereClause As String = ""

		If intWeekNo = 3 Then
			If strClass = "6A" Or strClass = "5A" Then
				'strSQL = "SELECT * FROM " & strSourceDistanceTable & " WHERE (SiteKey = '" & strSiteKey & "') AND " & strAdditionalCriteria & " ORDER BY intPreferentialLists DESC, intDistrictPrefRank"
				If strDay = "SAT" Then
					'strSQL = "SELECT * FROM " & strSourceDistanceTable & " WHERE (MainKeyGender = '" & strSiteKey & "') AND " & strAdditionalCriteria & " ORDER BY rankRating, intDistrictPrefRank, intPreferentialLists DESC"
					strSQL = "SELECT * FROM " & strSourceDistanceTable & " WHERE " & strAdditionalCriteria & " ORDER BY rankRating, intDistrictPrefRank, intPreferentialLists DESC"
				Else
					strSQL = "SELECT * FROM " & strSourceDistanceTable & " WHERE (MainKeyGender = '" & strSiteKey & "') AND " & strAdditionalCriteria & " ORDER BY intDistrictPrefRank, intPreferentialLists DESC"
				End If
			ElseIf strClass = "4A" Or strClass = "3A" Or strClass = "2A" Or strClass = "4A2A" Then
				If strOrderBy = "" Then
					strSQL = "SELECT * FROM " & strSourceDistanceTable & " WHERE (SiteKey = '" & strSiteKey & "') AND " & strAdditionalCriteria & " ORDER BY rankRating, intDistance"
				Else
					strSQL = "SELECT * FROM " & strSourceDistanceTable & " WHERE (SiteKey = '" & strSiteKey & "') AND " & strAdditionalCriteria & " ORDER BY " & strOrderBy
				End If
			End If

		ElseIf intWeekNo > 1 And intDayNo > 1 Then
			If intWeekNo = 2 And (intDayNo = 2 Or intDayNo = 3) And (strClass = "4A" Or strClass = "3A" Or strClass = "2A" Or strClass = "A" Or strClass = "B") Then
				If ysnUsePreferential Then
					If strClass = "A" Or strClass = "B" Then
						strSQL = "SELECT * FROM " & strSourceDistanceTable & " WHERE (SiteKey = '" & strSiteKey & "') AND " & strAdditionalCriteria & " ORDER BY intPreferentialLists DESC, rankpercTOTAL"
					Else
						strSQL = "SELECT * FROM " & strSourceDistanceTable & " WHERE (SiteKey = '" & strSiteKey & "') AND " & strAdditionalCriteria & " ORDER BY intPreferentialLists DESC, intDistrictPrefRank"  ' 2/14/2020 change this???
					End If

				Else
					strSQL = "SELECT * FROM " & strSourceDistanceTable & " WHERE (SiteKey = '" & strSiteKey & "') AND " & strAdditionalCriteria & " ORDER BY rankRating"
					'strSQL = "SELECT * FROM " & strSourceDistanceTable & " WHERE " & strAdditionalCriteria & " ORDER BY rankRating"
				End If
			Else
				strSQL = ""
			End If
		Else
			' USE this for WEEK #1 and Week #2 / Day 1 (Thurs)...
			If ysnUsePreferential Then
				' USING preferential so EVERYONE is available on Preferential...
				' Get the Best official based on Preferenital Rank...
				If strAdditionalCriteria = "" Then
					If intSlotNo = 2 Then   ' If 2nd Slot of Preferential, get the remainging Official on the least amount of lists...
						strSQL = "SELECT * FROM " & strSourceDistanceTable & " WHERE (SiteKey = '" & strSiteKey & "') ORDER BY intPreferentialLists DESC, intDistrictPrefRank"
					Else
						strSQL = "SELECT * FROM " & strSourceDistanceTable & " WHERE (SiteKey = '" & strSiteKey & "') ORDER BY intDistrictPrefRank"
					End If
				Else
					If strSiteKey.Contains("-D") Then
						strSQL = "SELECT * FROM " & strSourceDistanceTable & " WHERE (SiteKey = '" & strSiteKey & "') AND " & strAdditionalCriteria & " ORDER BY intDistrictPrefRank"
					Else
						strSQL = "SELECT * FROM " & strSourceDistanceTable & " WHERE (SiteKey = '" & strSiteKey & "') AND " & strAdditionalCriteria & " ORDER BY intPreferentialLists DESC, rankPercTOTAL"
					End If
				End If
				'End If
			Else
				' Not using preferential so check the distance in __assignDISTANCESWeek#...
				'If strAdditionalCriteria = "" Then
				'	If strGet = "BEST" Then
				'		strSQL = "SELECT * FROM " & strSourceDistanceTable & " WHERE intDistance <= intDistanceMax AND SiteZip = '" & strSiteZip & "' ORDER BY rankPercTOTAL"
				'	Else
				'		strSQL = "SELECT * FROM " & strSourceDistanceTable & " WHERE intDistance <= intDistanceMax AND SiteZip = '" & strSiteZip & "' ORDER BY intDistance, rankpercTOTAL"
				'	End If
				'Else
				'	If strGet = "BEST" Then
				'		strSQL = "SELECT * FROM " & strSourceDistanceTable & " WHERE intDistance <= intDistanceMax AND SiteZip = '" & strSiteZip & "' AND " & strAdditionalCriteria & " ORDER BY rankPercTOTAL"
				'	Else
				'		strSQL = "SELECT * FROM " & strSourceDistanceTable & " WHERE intDistance <= intDistanceMax AND SiteZip = '" & strSiteZip & "' AND " & strAdditionalCriteria & " ORDER BY intDistance, rankpercTOTAL"
				'	End If
				'End If
				If strAdditionalCriteria = "" Then
					If strGet = "BEST" Then
						strSQL = "SELECT * FROM " & strSourceDistanceTable & " WHERE SiteZip = '" & strSiteZip & "' ORDER BY rankPercTOTAL"
					Else
						strSQL = "SELECT * FROM " & strSourceDistanceTable & " WHERE SiteZip = '" & strSiteZip & "' ORDER BY intDistance, rankpercTOTAL"
					End If
				Else
					If strGet = "BEST" Then
						strSQL = "SELECT * FROM " & strSourceDistanceTable & " WHERE SiteZip = '" & strSiteZip & "' AND " & strAdditionalCriteria & " ORDER BY rankPercTOTAL"
					Else
						strSQL = "SELECT * FROM " & strSourceDistanceTable & " WHERE SiteZip = '" & strSiteZip & "' AND " & strAdditionalCriteria & " ORDER BY intDistance, rankpercTOTAL"
					End If
				End If
			End If
		End If

		If strSQL = "" Then

		Else

			ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

			If ds Is Nothing Then
				intOSSAAID = intOverrideValue     ' "Flag it" to be assigned in the next function call...
			ElseIf ds.Tables.Count = 0 Then
				intOSSAAID = intOverrideValue     ' "Flag it" to be assigned in the next function call...
			ElseIf ds.Tables(0).Rows.Count = 0 Then
				intOSSAAID = intOverrideValue     ' "Flag it" to be assigned in the next function call...
			Else
				For x = 0 To ds.Tables(0).Rows.Count - 1
					intOSSAAID = 0
					strOfficialName = ""
					intOfficialMiles = 0
					intOfficialRating = 0

					' Check the preferenital...
					If ysnUsePreferential Then
						intOSSAAID = ds.Tables(0).Rows(x).Item("intOSSAAID")
						strOfficialName = ds.Tables(0).Rows(x).Item("strOfficialName")
						strOfficialFlag = strPrefixName
						strOfficialEmail = ds.Tables(0).Rows(x).Item("strEmail")
						intOfficialMiles = ds.Tables(0).Rows(x).Item("intDistance")
						intOfficialRating = ds.Tables(0).Rows(x).Item("rankPercTotal")
						Try
							intOfficialPrefRating = ds.Tables(0).Rows(x).Item("intDistrictPrefRank")
						Catch
							intOfficialPrefRating = 0
						End Try
					Else
						intOSSAAID = ds.Tables(0).Rows(x).Item("intOSSAAID")
						strOfficialName = ds.Tables(0).Rows(x).Item("strOfficialName")
						strOfficialEmail = ds.Tables(0).Rows(x).Item("strEmail")
						strOfficialFlag = strPrefixName
						intOfficialMiles = ds.Tables(0).Rows(x).Item("intDistance")
						intOfficialRating = ds.Tables(0).Rows(x).Item("rankPercTotal")
						intOfficialPrefRating = 999
					End If
					'If intOSSAAID = 2675 Then
					'	Stop
					'End If

					If ysnCheckPreviousRegionKey Then       ' CDW added 2/12/2020...
						If PreviousDistrictConflictsFromRegionalKey(ds.Tables(0).Rows(x).Item("intOSSAAID"), ds.Tables(0).Rows(x).Item("regionalKey")) Then
							If strClass = "5A" Or strClass = "6A" Then
							Else
								WriteToLog("DISTRICT CONFLICT OSSAA ID# " & ds.Tables(0).Rows(x).Item("intOSSAAID") & " (" & ds.Tables(0).Rows(x).Item("strOfficialName") & ") @ " & ds.Tables(0).Rows(x).Item("SiteLocation") & " : SiteKey = " & ds.Tables(0).Rows(x).Item("SiteKey"))
							End If
							intOSSAAID = -1
						End If
					End If
					If SchoolConflictsFromDistrict(ds.Tables(0).Rows(x).Item("intOSSAAID"), strClass, strArea, strDistricts, ds.Tables(0).Rows(x).Item("regionalKey")) Then
						If strClass = "5A" Or strClass = "6A" Then
						Else
							WriteToLog("DISTRICT CONFLICT OSSAA ID# " & ds.Tables(0).Rows(x).Item("intOSSAAID") & " (" & ds.Tables(0).Rows(x).Item("strOfficialName") & ") @ " & ds.Tables(0).Rows(x).Item("SiteLocation") & " : SiteKey = " & ds.Tables(0).Rows(x).Item("SiteKey"))
						End If
						intOSSAAID = -1
					End If

					' Check the Conflicts table...
					If intOSSAAID = -1 Then

					Else
						If SchoolConflict(ds.Tables(0).Rows(x).Item("intOSSAAID"), IIf(ds.Tables(0).Rows(x).Item("TeamTop") Is System.DBNull.Value, 0, ds.Tables(0).Rows(x).Item("TeamTop")), IIf(ds.Tables(0).Rows(x).Item("TeamBottom") Is System.DBNull.Value, 0, ds.Tables(0).Rows(x).Item("TeamBottom")), 9999, 9999) Then
							If strClass = "6A" Or strClass = "5A" Then

							Else
								WriteToLog("CONFLICT OSSAA ID# " & ds.Tables(0).Rows(x).Item("intOSSAAID") & " (" & ds.Tables(0).Rows(x).Item("strOfficialName") & ") @ " & ds.Tables(0).Rows(x).Item("SiteLocation") & " : SiteKey = " & ds.Tables(0).Rows(x).Item("SiteKey"))
							End If
							intOSSAAID = 0
						Else
							If intOSSAAID > 0 Then
								' Do nothing, we got who we want...
							Else
								intOSSAAID = ds.Tables(0).Rows(x).Item("intOSSAAID")
								strOfficialName = ds.Tables(0).Rows(x).Item("strOfficialName")
								strOfficialEmail = ds.Tables(0).Rows(x).Item("strEmail")
								strOfficialFlag = strPrefixName
								intOfficialMiles = ds.Tables(0).Rows(x).Item("intDistance")
								intOfficialRating = ds.Tables(0).Rows(x).Item("rankPercTotal")
								intOfficialPrefRating = 999
							End If
						End If
					End If

					' If we have an OSSAAID, we are done, move on out...
					If intOSSAAID > 0 Then
						Exit For
					End If

				Next
				If intOSSAAID <= 0 Then intOSSAAID = 99900     ' CDW removed 2/13/2020...
			End If
		End If

		Return intOSSAAID

	End Function

	Shared Function PlaceAnOfficial(intOSSAAID As Long, strMainKey As String, strGameKey As String, strLevel As String, intSlot As Integer, strOfficialName As String, intOfficialMiles As Long, intOfficialRating As Long, intOfficialsRatingPref As Long, strOfficialsEmail As String, strOfficialFlag As String, intGameRankings As Long, strDay As String, strFlag As String) As String
		Dim strReturn As String = "OK"
		Dim strSQL As String = ""

		If strLevel = "D" Then
			strSQL = "UPDATE tblTournamentDetailBB SET officialID" & intSlot & " = " & intOSSAAID & ", officialName" & intSlot & " = '" & strOfficialName & "', officialEmail" & intSlot & " = '" & strOfficialsEmail & "', officialFlag" & intSlot & " = '" & strFlag & "', officialMiles" & intSlot & " = " & intOfficialMiles & ", officialRating" & intSlot & " = " & intOfficialRating & ", officialRatingPref" & intSlot & " = " & intOfficialsRatingPref & ", intGameRankings = " & intGameRankings & " WHERE siteKey = '" & strGameKey & "'"
		ElseIf strLevel = "R" Then
			If strGameKey.Contains("-6A-") Or strGameKey.Contains("-5A-") Then
				If strDay = "SAT" Then
					strSQL = "UPDATE tblTournamentDetailBB SET officialID" & intSlot & " = " & intOSSAAID & ", officialName" & intSlot & " = '" & strOfficialName & "', officialEmail" & intSlot & " = '" & strOfficialsEmail & "', officialFlag" & intSlot & " = '" & strFlag & "', officialMiles" & intSlot & " = " & intOfficialMiles & ", officialRating" & intSlot & " = " & intOfficialRating & ", officialRatingPref" & intSlot & " = " & intOfficialsRatingPref & ", intGameRankings = " & intGameRankings & " WHERE intDayNo = 3 AND mainKeyGender = '" & strGameKey & "'"
				Else
					strSQL = "UPDATE tblTournamentDetailBB SET officialID" & intSlot & " = " & intOSSAAID & ", officialName" & intSlot & " = '" & strOfficialName & "', officialEmail" & intSlot & " = '" & strOfficialsEmail & "', officialFlag" & intSlot & " = '" & strFlag & "', officialMiles" & intSlot & " = " & intOfficialMiles & ", officialRating" & intSlot & " = " & intOfficialRating & ", officialRatingPref" & intSlot & " = " & intOfficialsRatingPref & ", intGameRankings = " & intGameRankings & " WHERE intDayNo < 3 AND mainKeyGender = '" & strGameKey & "'"
				End If
			ElseIf strGameKey.Contains("-A-") Or strGameKey.Contains("-B-") Or strGameKey.Contains("-4A-") Or strGameKey.Contains("-3A-") Or strGameKey.Contains("-2A-") Then
				Dim strSiteKeyNew As String = strGameKey.Replace("-L", "")
				strSiteKeyNew = strSiteKeyNew.Replace("-W", "")
				Dim strDayFilter As String
				If strDay = "THURS" Then
					strDayFilter = "Thur"
				ElseIf strDay = "FRI" Then
					strDayFilter = "Fri"
				ElseIf strDay = "SAT" Then
					strDayFilter = "Sat"
				Else
					strDayFilter = ""
				End If
				If strDay = "THURS" Then
					If strMainKey.Contains("-L") Then
						strSQL = "UPDATE tblTournamentDetailBB SET officialID" & intSlot & " = " & intOSSAAID & ", officialName" & intSlot & " = '" & strOfficialName & "', officialEmail" & intSlot & " = '" & strOfficialsEmail & "', officialFlag" & intSlot & " = '" & strFlag & "', officialMiles" & intSlot & " = " & intOfficialMiles & ", officialRating" & intSlot & " = " & intOfficialRating & ", officialRatingPref" & intSlot & " = " & intOfficialsRatingPref & ", intGameRankings = " & intGameRankings & " WHERE regionalKeyGame = '" & strSiteKeyNew & "' AND strBracket = 'L' AND strDay = '" & strDayFilter & "'"
						'strSQL = "UPDATE tblTournamentDetailBB SET officialID" & intSlot & " = " & intOSSAAID & ", officialName" & intSlot & " = '" & strOfficialName & "', officialEmail" & intSlot & " = '" & strOfficialsEmail & "', officialFlag" & intSlot & " = '" & strFlag & "', officialMiles" & intSlot & " = " & intOfficialMiles & ", officialRating" & intSlot & " = " & intOfficialRating & ", officialRatingPref" & intSlot & " = " & intOfficialsRatingPref & ", intGameRankings = " & intGameRankings & " WHERE regionalKeyGame = '" & strMainKey & "' AND strBracket = 'L' AND strDay = '" & strDayFilter & "'"
					Else
						strSQL = "UPDATE tblTournamentDetailBB SET officialID" & intSlot & " = " & intOSSAAID & ", officialName" & intSlot & " = '" & strOfficialName & "', officialEmail" & intSlot & " = '" & strOfficialsEmail & "', officialFlag" & intSlot & " = '" & strFlag & "', officialMiles" & intSlot & " = " & intOfficialMiles & ", officialRating" & intSlot & " = " & intOfficialRating & ", officialRatingPref" & intSlot & " = " & intOfficialsRatingPref & ", intGameRankings = " & intGameRankings & " WHERE regionalKeyGame = '" & strSiteKeyNew & "' AND strBracket = 'W' AND strDay = '" & strDayFilter & "'"
						'strSQL = "UPDATE tblTournamentDetailBB SET officialID" & intSlot & " = " & intOSSAAID & ", officialName" & intSlot & " = '" & strOfficialName & "', officialEmail" & intSlot & " = '" & strOfficialsEmail & "', officialFlag" & intSlot & " = '" & strFlag & "', officialMiles" & intSlot & " = " & intOfficialMiles & ", officialRating" & intSlot & " = " & intOfficialRating & ", officialRatingPref" & intSlot & " = " & intOfficialsRatingPref & ", intGameRankings = " & intGameRankings & " WHERE regionalKeyGame = '" & strMainKey & "' AND strBracket = 'W' AND strDay = '" & strDayFilter & "'"
					End If
				ElseIf strDay = "FRI" Then
					strSQL = "UPDATE tblTournamentDetailBB SET officialID" & intSlot & " = " & intOSSAAID & ", officialName" & intSlot & " = '" & strOfficialName & "', officialEmail" & intSlot & " = '" & strOfficialsEmail & "', officialFlag" & intSlot & " = '" & strFlag & "', officialMiles" & intSlot & " = " & intOfficialMiles & ", officialRating" & intSlot & " = " & intOfficialRating & ", officialRatingPref" & intSlot & " = " & intOfficialsRatingPref & ", intGameRankings = " & intGameRankings & " WHERE regionalKeyGame = '" & strGameKey & "' AND strDay = '" & strDayFilter & "'"
				ElseIf strDay = "SAT" Then
					If strMainKey.Contains("-L") Then
						strSQL = "UPDATE tblTournamentDetailBB SET officialID" & intSlot & " = " & intOSSAAID & ", officialName" & intSlot & " = '" & strOfficialName & "', officialEmail" & intSlot & " = '" & strOfficialsEmail & "', officialFlag" & intSlot & " = '" & strFlag & "', officialMiles" & intSlot & " = " & intOfficialMiles & ", officialRating" & intSlot & " = " & intOfficialRating & ", officialRatingPref" & intSlot & " = " & intOfficialsRatingPref & ", intGameRankings = " & intGameRankings & " WHERE regionalKeyGame = '" & strSiteKeyNew & "' AND strBracket = 'L' AND strDay = '" & strDayFilter & "'"
					Else
						strSQL = "UPDATE tblTournamentDetailBB SET officialID" & intSlot & " = " & intOSSAAID & ", officialName" & intSlot & " = '" & strOfficialName & "', officialEmail" & intSlot & " = '" & strOfficialsEmail & "', officialFlag" & intSlot & " = '" & strFlag & "', officialMiles" & intSlot & " = " & intOfficialMiles & ", officialRating" & intSlot & " = " & intOfficialRating & ", officialRatingPref" & intSlot & " = " & intOfficialsRatingPref & ", intGameRankings = " & intGameRankings & " WHERE regionalKeyGame = '" & strSiteKeyNew & "' AND strBracket = 'W' AND strDay = '" & strDayFilter & "'"
					End If
				End If
			End If
		End If

		' Lets PLACE THE OFFICIAL...
		strReturn = SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

		Return strReturn
	End Function

	Shared Function SchoolConflict(intOSSAAID As Long, intSchoolID1 As Integer, intSchoolID2 As Integer, intSchoolID3 As Integer, intSchoolID4 As Integer) As Boolean
		Dim intConflict As Long = 0
		If intSchoolID2 = 0 Then intSchoolID2 = 9999
		If intSchoolID3 = 0 Then intSchoolID3 = 9999
		If intSchoolID4 = 0 Then intSchoolID4 = 9999

		Dim strSQL As String = "SELECT intSchoolIDConflict FROM __assignCONFLICTS WHERE intOSSAAID = " & intOSSAAID & " AND (intSchoolIDConflict = " & intSchoolID1 & " OR intSchoolIDConflict = " & intSchoolID2 & " OR intSchoolIDConflict = " & intSchoolID3 & " OR intSchoolIDConflict = " & intSchoolID4 & ")"
		intConflict = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

		If intConflict > 0 Then
			Return True
		Else
			Return False
		End If

	End Function

	Shared Function PreviousDistrictConflictsFromRegionalKey(intOSSAAID As Long, strRegionalKey As String) As Boolean
		Dim strSQL As String = ""
		Dim strResult As String = ""

		strSQL = "SELECT regionalKey FROM tblTournamentDetailBB WHERE regionalKey = '" & strRegionalKey & "' AND intYear = " & clsFunctions.GetCurrentYear() & " AND (officialID1 = " & intOSSAAID & " OR officialID2 = " & intOSSAAID & " OR officialID3 = " & intOSSAAID & ")"
		strResult = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

		If strResult = "" Then
			Return False
		Else
			Return True
		End If
	End Function

	Shared Function SchoolConflictsFromDistrict(intOSSAAID As Long, strClass As String, strArea As String, strDistricts As String, strRegionalKey As String) As Boolean
		' CDW added strRegionalKey 2/19/2020...
		' Checks ALL 8 teams in a Regional for a conflict...
		' Get possible Conflicts from schools in DISTRICTS 1-4, 5-8, 2-3 or 6-7... CDW added 2/4/2019...
		Dim strSQL As String = ""
		Dim strResult As String = ""
		Dim ds As DataSet
		Dim intDistrict1 As Integer = 0
		Dim intDistrict2 As Integer = 0
		Dim intSchoolID1 As Integer = 0
		Dim intSchoolID2 As Integer = 0
		Dim intSchoolID3 As Integer = 0
		Dim intSchoolID4 As Integer = 0

		Dim ysnConflict As Boolean = False
		Dim x As Integer = 0

		Dim strRegionalKeyOther As String = ""

		If intOSSAAID = 1674 Then
			Stop
		End If
		' Get the DISTRICT numbers...
		Select Case strDistricts
			Case "1-4"
				intDistrict1 = 1
				intDistrict2 = 4
			Case "5-8"
				intDistrict1 = 5
				intDistrict2 = 8
			Case "2-3"
				intDistrict1 = 2
				intDistrict2 = 3
			Case "6-7"
				intDistrict1 = 6
				intDistrict2 = 7
			Case Else
				intDistrict1 = 0
				intDistrict2 = 0
		End Select
		' Get the list of schools in these districts...
		If intDistrict1 > 0 Or intDistrict2 > 0 Then

			' Get the other Regional key for this district...
			If strRegionalKey.Contains("R1-4") Then
				strRegionalKeyOther = strRegionalKey.Replace("R1-4", "R2-3")
			ElseIf strRegionalKey.Contains("R2-3") Then
				strRegionalKeyOther = strRegionalKey.Replace("R2-3", "R1-4")
			ElseIf strRegionalKey.Contains("R5-8") Then
				strRegionalKeyOther = strRegionalKey.Replace("R5-8", "R6-7")
			ElseIf strRegionalKey.Contains("R6-7") Then
				strRegionalKeyOther = strRegionalKey.Replace("R6-7", "R5-8")
			Else
				strRegionalKeyOther = strRegionalKey
			End If
			'strSQL = "SELECT schoolID1, schoolID2, schoolID3, schoolID4 FROM __assignDistrictPrefsBB WHERE strClass = '" & strClass & "' AND strArea = '" & strArea & "' AND (intDistrict = " & intDistrict1 & " OR intDistrict = " & intDistrict2 & ")"
			strSQL = "SELECT schoolID1, schoolID2, schoolID3, schoolID4, regionalKey FROM __assignDistrictPrefsBB WHERE regionalKey = '" & strRegionalKey & "' OR regionalKey = '" & strRegionalKeyOther & "'"
			ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
			If ds Is Nothing Then
				ysnConflict = False
			ElseIf ds.Tables.Count = 0 Then
				ysnConflict = False
			ElseIf ds.Tables(0).Rows.Count = 0 Then
				ysnConflict = False
			Else
				For x = 0 To ds.Tables(0).Rows.Count - 1
					If ds.Tables(0).Rows(x).Item("schoolID1") Is System.DBNull.Value Then intSchoolID1 = 0 Else intSchoolID1 = ds.Tables(0).Rows(x).Item("schoolID1")
					If ds.Tables(0).Rows(x).Item("schoolID2") Is System.DBNull.Value Then intSchoolID2 = 0 Else intSchoolID2 = ds.Tables(0).Rows(x).Item("schoolID2")
					If ds.Tables(0).Rows(x).Item("schoolID3") Is System.DBNull.Value Then intSchoolID3 = 0 Else intSchoolID3 = ds.Tables(0).Rows(x).Item("schoolID3")
					If ds.Tables(0).Rows(x).Item("schoolID4") Is System.DBNull.Value Then intSchoolID4 = 0 Else intSchoolID4 = ds.Tables(0).Rows(x).Item("schoolID4")
					ysnConflict = SchoolConflict(intOSSAAID, intSchoolID1, intSchoolID2, intSchoolID3, intSchoolID4)
					If ysnConflict Then Exit For
				Next
			End If
		Else
			ysnConflict = False
		End If

		Return ysnConflict

	End Function

	Shared Function GetSourceDistanceTable(intWeekNo As Integer, intDayNo As Integer, ysnUsePreferential As Boolean, strDay As String, strClass As String, strGender As String) As String

		If ysnUsePreferential Then
			Select Case intWeekNo
				Case 1
					Return "__assignDISTANCESWeek1UsePreferentials"
				Case 2
					If strDay = "FRISAT" Or strDay = "THURS" Then
						If intDayNo = 1 Then
							Return "__assignDISTANCESWeek2UsePreferentialsThurs"
						ElseIf intDayNo = 2 Then
							Return "__assignDISTANCESWeek2UsePreferentialsFriSat"
						Else
							Return "__assignDISTANCESWeek2UsePreferentials"
						End If
					Else
						If strDay = "FRI" Then
							If strClass = "A" Or strClass = "B" Then
								Return "__assignDISTANCESWeek2UsePreferentialsFriTemp"
							Else
								Return "__assignDISTANCESWeek2UsePreferentialsFri"
							End If

						ElseIf strDay = "SAT" Then
							If strClass = "A" Or strClass = "B" Then
								Return "__assignDISTANCESWeek2UsePreferentialsSatTemp"
							Else
								Return "__assignDISTANCESWeek2UsePreferentialsSat"
							End If

						Else
							Return "__assignDISTANCESWeek2UsePreferentialsFriSat"
						End If
					End If
				Case 3
					If strClass = "6A" Or strClass = "5A" Or strClass = "6A5A" Then
						If strDay = "THURS" Then        ' Girls
							If strClass = "6A" Then
								If strGender = "Girls" Then
									Return "___assignOFFICIALS_Week3__6AGirls_Prefs_DISTANCES_Unassigned_Thurs"
								ElseIf strGender = "Boys" Then
									Return "___assignOFFICIALS_Week3__6ABoys_Prefs_DISTANCES_Unassigned_Thurs"
								Else
									Return "NONE"
								End If
							ElseIf strClass = "5A" Then
								If strGender = "Girls" Then
									Return "___assignOFFICIALS_Week3__5AGirls_Prefs_DISTANCES_Unassigned_Thurs"
								ElseIf strGender = "Boys" Then
									Return "___assignOFFICIALS_Week3__5ABoys_Prefs_DISTANCES_Unassigned_Thurs"
								Else
									Return "NONE"
								End If
							Else
								Return "NONE"
							End If
						ElseIf strDay = "FRI" Then
							If strClass = "6A" Then
								If strGender = "Girls" Then
									Return "___assignOFFICIALS_Week3__6AGirls_Prefs_DISTANCES_Unassigned_Fri"
								ElseIf strGender = "Boys" Then
									Return "___assignOFFICIALS_Week3__6ABoys_Prefs_DISTANCES_Unassigned_Fri"
								Else
									Return "NONE"
								End If
							ElseIf strClass = "5A" Then
								If strGender = "Girls" Then
									Return "___assignOFFICIALS_Week3__5AGirls_Prefs_DISTANCES_Unassigned_Fri"
								ElseIf strGender = "Boys" Then
									Return "___assignOFFICIALS_Week3__5ABoys_Prefs_DISTANCES_Unassigned_Fri"
								Else
									Return "NONE"
								End If
							Else
								Return "NONE"
							End If
						ElseIf strDay = "SAT" Then
							If strClass = "6A" Then
								If strGender = "Girls" Then
									Return "___assignOFFICIALS_Week3__6AGirls_Prefs_DISTANCES_Unassigned_Sat"
								ElseIf strGender = "Boys" Then
									Return "___assignOFFICIALS_Week3__6ABoys_Prefs_DISTANCES_Unassigned_Sat"
								Else
									Return "NONE"
								End If
							ElseIf strClass = "5A" Then
								If strGender = "Girls" Then
									Return "___assignOFFICIALS_Week3__5AGirls_Prefs_DISTANCES_Unassigned_Sat"
								ElseIf strGender = "Boys" Then
									Return "___assignOFFICIALS_Week3__5ABoys_Prefs_DISTANCES_Unassigned_Sat"
								Else
									Return "NONE"
								End If
							Else
								Return "NONE"
							End If
						Else
							Return "NONE"
						End If
					ElseIf strClass = "4A" Or strClass = "3A" Or strClass = "2A" Or strClass = "4A2A" Then
						If strDay = "THURS" Then
							Return "__assignDISTANCESWeek3_4A2A_UsePreferentials_Thurs"
						ElseIf strDay = "FRI" Then
							Return "__assignDISTANCESWeek3_4A2A_UsePreferentials_Fri"
						ElseIf strDay = "SAT" Then
							Return "__assignDISTANCESWeek3_4A2A_UsePreferentials_Sat"
						Else
							Return "NONE"
						End If
					End If
				Case 4
					Return "__assignDISTANCESWeek4UsePreferentials"
				Case 5
					Return "__assignDISTANCESWeek5UsePreferentials"
				Case Else
					Return "__assignDISTANCESWeek1UsePreferentials"
			End Select
		Else
			Select Case intWeekNo
				Case 1
					Return "__assignDISTANCESWeek1"
				Case 2
					If intDayNo = 1 Then
						Return "__assignDISTANCESWeek2Thurs"
					ElseIf intDayNo = 2 Or intDayNo = 3 Then
						If strDay = "SAT" Then
							Return "__assignDISTANCESWeek2ALLRemainingSat"
						ElseIf strDay = "FRI" Then
							Return "__assignDISTANCESWeek2ALLRemainingFri"
						Else
							Return "__assignDISTANCESWeek2ALLRemainingFriSat"
						End If

					End If
				Case 3
					If strClass = "4A" Or strClass = "3A" Or strClass = "2A" Or strClass = "4A2A" Then
						If strDay = "THURS" Then
							Return "__assignDISTANCESWeek3_4A2A_UsePreferentialsNO_Thurs"
						ElseIf strDay = "FRI" Then
							Return "__assignDISTANCESWeek3_4A2A_UsePreferentialsNO_Fri"
						ElseIf strDay = "SAT" Then
							Return "__assignDISTANCESWeek3_4A2A_UsePreferentialsNO_Sat"
						Else
							Return "NONE"
						End If
					End If
				Case 4
					Return "__assignDISTANCESWeek4"
				Case 5
					Return "__assignDISTANCESWeek5"
				Case Else
					Return "__assignDISTANCESWeek1"
			End Select
		End If
	End Function

	Shared Function GetSourceGamesTable(intWeekNo As Integer, intDayNo As Integer, strClasses As String, strDays As String) As String
		' strClasses = "6A5A", "4A2A", "AB"

		Select Case intWeekNo
			Case 1
				Return "__assignGAMESWeek1USE"
			Case 2
				If intDayNo = 1 Then
					If strClasses = "AB" Then
						Return "__assignGAMESWeek2ThursUSE"
					ElseIf strClasses = "2A" Then
						Return "__assignGAMESWeek2_ABFriSatUSE"
					ElseIf strClasses = "3A" Or strClasses = "4A" Then
						Return "__assignGAMESWeek2_ABFriUSE"
					Else
						Return "__assignGAMESWeek2_ABFriSatUSE"
					End If
				ElseIf intDayNo = 2 Then
					If strClasses = "4A2A" Then
						If strDays = "FRISAT" Then
							Return "__assignGAMESWeek2_4A2AUSE"
						ElseIf strDays = "FRI" Then
							Return "__assignGAMESWeek2_FriUSE"
						ElseIf strDays = "SAT" Then
							Return "__assignGAMESWeek2_SatUSE"
						Else
							Return "__assignGAMESWeek2_4A2AUSE"
						End If
					ElseIf strClasses = "AB" Then
						If strDays = "FRI" Then
							Return "__assignGAMESWeek2_FriUSE"
						ElseIf strDays = "SAT" Then
							Return "__assignGAMESWeek2_SatUSE"
						End If
					Else
						Return "__assignGAMESWeek2_ABFriSatUSE"
					End If
				Else
					If strClasses = "A" Or strClasses = "B" Or strClasses = "AB" Then
						If strDays = "FRI" Then
							Return "__assignGAMESWeek2_FriUSE"
						ElseIf strDays = "SAT" Then
							Return "__assignGAMESWeek2_SatUSE"
						End If
					Else
						Return "__assignGAMESWeek2USE"
					End If
				End If
			Case 3
				If intDayNo = 1 Then
					Select Case strClasses
						Case "6A5A"
							Select Case strDays
								Case "THURS"
									Return "___assignGAMES_Week3_6A5A_ThursRANKED"
								Case "FRI"
									Return "___assignGAMES_Week3_6A5A_FriRANKED"
								Case "SAT"
									Return "___assignGAMES_Week3_6A5A_SatRANKED"
								Case Else
									Return "NONE"
							End Select
						Case "4A2A"
							Return "__assignGAMESWeek3_4A2A_ThursUSE"
						Case Else
					End Select
				ElseIf intDayNo = 2 Then
					If strClasses = "4A2A" Then
						Return "__assignGAMESWeek3_4A2A_FriUSE"
					ElseIf strClasses = "6A5A" Then
						Select Case strDays
							Case "THURS"
								Return "___assignGAMES_Week3_6A5A_ThursRANKED"
							Case "FRI"
								Return "___assignGAMES_Week3_6A5A_FriRANKED"
							Case "SAT"
								Return "___assignGAMES_Week3_6A5A_SatRANKED"
							Case Else
								Return "NONE"
						End Select
					Else
						Return "NONE"
					End If
				ElseIf intDayNo = 3 Then
					If strClasses = "4A2A" Then
						Return "__assignGAMESWeek3_4A2A_SatUSE"
					ElseIf strClasses = "6A5A" Then
						Select Case strDays
							Case "THURS"
								Return "___assignGAMES_Week3_6A5A_ThursRANKED"
							Case "FRI"
								Return "___assignGAMES_Week3_6A5A_FriRANKED"
							Case "SAT"
								Return "___assignGAMES_Week3_6A5A_SatRANKED"
							Case Else
								Return "NONE"
						End Select
					Else
						Return "NONE"
					End If
				Else
				End If
			Case Else

		End Select
	End Function
End Class
