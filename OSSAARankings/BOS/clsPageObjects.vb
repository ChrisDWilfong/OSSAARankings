Public Class clsPageObjects

    Shared Function GetDropDown(strState As String, strSportGenderKey As String) As String
        Dim strReturn As String = ""
        Select Case strSportGenderKey
            Case "BaseballFall"

            Case "SoftballFP"

        End Select

        Return strReturn
    End Function

    Shared Function GetGridWith01Dropdown(intColumnCount As Integer, strSQL As String) As String
        Dim strGrid As String = ""
        Dim ds As DataSet

        ' Get



        Return strGrid
    End Function

#Region "Grid Headers"
    Shared Function GetBootstrapCardHeader() As String
        Dim strHeader As String = ""

        strHeader += "<div Class='card-standing-caption'>"
        strHeader += "<div Class='card-standing-position'>Rank</div>"
        strHeader += "<div Class='card-standing-caption-aside'>"
        strHeader += "<div Class='card-standing-team'>Coach</div>"
        strHeader += "<div Class='card-standing-number' >YRS</div>"
        strHeader += "<div Class='card-standing-number'> W</div>"
        strHeader += "<div Class='card-standing-number'>L</div>"
        strHeader += "</div>"
        strHeader += "</div>"

        Return strHeader
    End Function

    Shared Function GetBootstrapCardHeader1Column(strColumnHeader As String) As String
        Dim strHeader As String = ""

        strHeader += "<div Class='card-standing-caption'>"
        strHeader += "<div Class='card-standing-position'>Rank</div>"
        strHeader += "<div Class='card-standing-caption-aside'>"
        strHeader += "<div Class='card-standing-team'>" & strColumnHeader & "</div>"
        strHeader += "</div>"
        strHeader += "</div>"

        Return strHeader
    End Function

    Shared Function GetBootstrapCardHeaderStateChampions01() As String
        Dim strHeader As String = ""

        strHeader += "<div Class='card-standing-caption'>"
        strHeader += "<div Class='card-standing-position'>Class</div>"
        strHeader += "<div Class='card-standing-caption-aside'>"
        strHeader += "<div Class='card-standing-team'>STATE CHAMPIONS</div>"
        strHeader += "</div>"
        strHeader += "</div>"

        Return strHeader
    End Function

#End Region

    'Shared Function GetBootstrapCardRowsWithDetailStateChampions01(strState As String, strSportGenderKey As String, strYear As String, strSQL As String, strFieldNameTopLine As String, strFieldNameBottomLine As String) As String
    '    Dim strRows As String = ""
    '    Dim ds As DataSet
    '    Dim dsd As DataSet
    '    Dim x As Integer = 0
    '    Dim y As Integer = 0

    '    ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionIWATG, CommandType.Text, strSQL)

    '    For x = 0 To ds.Tables(0).Rows.Count - 1
    '        With ds.Tables(0).Rows(x)
    '            ' Header of Row...
    '            strRows += "<article class='card card-custom'>"
    '            'strRows += "<div Class='card-standing-position card-standing-counter'></div>"
    '            strRows += "<div Class='card-standing-position card-standingstyle'>" & .Item("strClass") & "</div>"
    '            strRows += "<div Class='card-header' id='accordion1Heading" & (x + 1) & "' role='tab'>"
    '            strRows += "<div Class='card-standing-team-item'>"
    '            strRows += "<div Class='card-standing-team'>"
    '            'strRows += "<div Class='card-standing-team-figure'><img src='site/images/football/football32.gif' alt='' width='32' height='41'/>"
    '            'strRows += "</div>"
    '            strRows += "<div Class='card-standing-team-title'>"
    '            strRows += "<div Class='card-standing-team-name'>" & .Item(strFieldNameTopLine) & "</div>"
    '            If .Item(strFieldNameBottomLine) Is System.DBNull.Value Then
    '                strRows += "<div Class='card-standing-team-country'></div>"
    '            Else
    '                strRows += "<div Class='card-standing-team-country'>COACHES : " & .Item(strFieldNameBottomLine) & "</div>"
    '            End If
    '            strRows += "</div>"
    '            strRows += "</div>"
    '            strRows += "<div Class='card-standing-button'><a class='card-standing-toogle material-icons-remove collapsed' role='button' data-toggle='collapse' data-parent='#accordion1' href='#accordion1Collapse" & (x + 1) & "' aria-controls='accordion1Collapse" & (x + 1) & "'></a></div>"
    '            strRows += "</div>"
    '            strRows += "</div>"

    '            If strState = "OK" Then
    '                strRows += GetBootStrapDetailsTourneyGames(strState, strSportGenderKey, strYear, .Item("strClass"), x + 1)
    '            End If

    '            strRows += "</Article>"
    '        End With
    '    Next

    '    Return strRows

    'End Function

    'Shared Function GetBootStrapDetailsTourneyGames(strState As String, strSportGenderKey As String, intYear As String, strClass As String, x As Integer) As String
    '    Dim strRows As String = ""
    '    Dim strSQL As String = ""
    '    Dim dsd As DataSet

    '    ' Accordian Collapse...
    '    strRows += "<div Class='collapse' id='accordion1Collapse" & x & "' role='tabpanel' aria-labelledby='accordion1Heading" & x & "'>"
    '    strRows += "<div Class='card-body'>"

    '    Select Case strSportGenderKey
    '        Case "BasketballBoys"
    '            strSQL = "SELECT * FROM tblBASKETBALLTOURNAMENTimport WHERE strSportGenderKey = '" & strSportGenderKey & "' AND intYear = " & intYear & " AND strClass = '" & strClass & "' ORDER BY intGameNo"
    '        Case "BasekballGirls"
    '            strSQL = "SELECT * FROM tblBASKETBALLTOURNAMENTimport WHERE strSportGenderKey = '" & strSportGenderKey & "' AND intYear = " & intYear & " AND strClass = '" & strClass & "' ORDER BY intGameNo"
    '        Case Else
    '            strSQL = ""
    '    End Select
    '    If strSQL = "" Then
    '        ' Just return...
    '    Else
    '        dsd = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionIWATG, CommandType.Text, strSQL)

    '        If dsd Is Nothing Then
    '        ElseIf dsd.Tables.Count = 0 Then
    '        ElseIf dsd.Tables(0).Rows.Count = 0 Then
    '        Else
    '            For y = 0 To dsd.Tables(0).Rows.Count - 1

    '                strRows += "<div Class='card-standing-team-details'>"
    '                strRows += "<div Class='card-standing-number'>" & dsd.Tables(0).Rows(y).Item("strRound") & "</div>"
    '                strRows += "<div Class='card-standing-game-status'>" & dsd.Tables(0).Rows(y).Item("strWinner") & " over " & dsd.Tables(0).Rows(y).Item("strLoser") & "</div>"
    '                strRows += "<div Class='card-standing-number'>" & dsd.Tables(0).Rows(y).Item("intWinner") & "</div>"
    '                strRows += "<div Class='card-standing-number'>" & dsd.Tables(0).Rows(y).Item("intLoser") & "</div>"
    '                strRows += "</div>"
    '            Next
    '        End If
    '        strRows += "</div>"
    '        strRows += "</div>"
    '    End If

    '    Return strRows

    'End Function
    Shared Function GetGamesList(strSportGenderKey As String, strScoreboardDate As String) As String
        Dim strReturn As String = ""
        Dim strSQL As String = ""
        Dim sqlDate As String = ""
        Dim ds As DataSet
        Dim x As Integer
        Dim strTeam1 As String = ""
        Dim strTeam2 As String = ""
        Dim dateLong As String = ""

        ' NOTE : strScoreboardDate format 'yyyy-mm-dd'
        dateLong = Convert.ToDateTime(strScoreboardDate).ToLongDateString

        strScoreboardDate = strScoreboardDate & " 00:00:00"

        strSQL = clsBSData.GetScheduleSportDaySQL(strSportGenderKey, "ALL", strScoreboardDate, "", False)
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        If ds Is Nothing Then
            strReturn += "<Article Class='post-inline'>"
            strReturn += "<time Class='post-inline-time' datetime='2019'>" & clsBSData.GetSportString(strSportGenderKey) & " - NO GAMES SCHEDULED</time>"
            strReturn += "</article>"
        ElseIf ds.Tables.Count = 0 Then
            strReturn += "<Article Class='post-inline'>"
            strReturn += "<time Class='post-inline-time' datetime='2019'>" & clsBSData.GetSportString(strSportGenderKey) & " - NO GAMES SCHEDULED</time>"
            strReturn += "</article>"
        ElseIf ds.Tables(0).Rows.Count = 0 Then
            strReturn += "<Article Class='post-inline'>"
            strReturn += "<time Class='post-inline-time' datetime='2019'>" & clsBSData.GetSportString(strSportGenderKey) & " - NO GAMES SCHEDULED</time>"
            strReturn += "</article>"
        Else
            For x = 0 To ds.Tables(0).Rows.Count - 1
                If Not ds.Tables(0).Rows(x).Item("oschool") Is System.DBNull.Value Then
                    If ds.Tables(0).Rows(x).Item("TotalScore") > ds.Tables(0).Rows(x).Item("oTotalScore") Then
                        ' GAMES WITH SCORES...
                        strReturn += "<Article Class='post-inline'>"
                        strReturn += "<time Class='post-inline-time' datetime='2019'>" & clsBSData.GetSportString(strSportGenderKey) & "-" & dateLong & "</time><br>"
                        If ds.Tables(0).Rows(x).Item("oschool") Is System.DBNull.Value Then
                        Else
                            If ds.Tables(0).Rows(x).Item("TotalScore") > ds.Tables(0).Rows(x).Item("oTotalScore") Then
                                strReturn += "<p Class='post-inline-title'>" & Left(ds.Tables(0).Rows(x).Item("school"), 15) & " " & ds.Tables(0).Rows(x).Item("TotalScore") & " " & Left(ds.Tables(0).Rows(x).Item("oschool"), 15) & " " & ds.Tables(0).Rows(x).Item("oTotalScore") & "</p>"
                            Else
                                strReturn += "<p Class='post-inline-title'>" & Left(ds.Tables(0).Rows(x).Item("oschool"), 15) & " " & ds.Tables(0).Rows(x).Item("oTotalScore") & " " & Left(ds.Tables(0).Rows(x).Item("school"), 15) & " " & ds.Tables(0).Rows(x).Item("TotalScore") & "</p>"
                            End If
                            strReturn += "</article>"
                        End If
                    Else
                        If Not ds.Tables(0).Rows(x).Item("school") Is System.DBNull.Value And Not ds.Tables(0).Rows(x).Item("oschool") Is System.DBNull.Value Then
                            strReturn += "<Article Class='post-inline'>"
                            strReturn += "<time Class='post-inline-time' datetime='2019'>" & clsBSData.GetSportString(strSportGenderKey) & "-" & dateLong & "</time><br>"
                            strReturn += "<p Class='post-inline-title'>" & Left(ds.Tables(0).Rows(x).Item("school"), 15) & " vs " & Left(ds.Tables(0).Rows(x).Item("oschool"), 15) & "</p>"
                            strReturn += "</article>"
                        End If
                    End If
                End If
            Next
        End If

        Return strReturn
    End Function


End Class
