Public Class sbSlowPitch
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim strSportGenderClass As String = ""
            Dim strLevel As String = ""
            Dim strDate As String = ""
            Dim strHeader As String = ""
            Dim intButtonHeight As Integer = 60
            Dim intButtonFontSize As Integer = 12

            strSportGenderClass = Request.QueryString("sgc")
            strLevel = Request.QueryString("l")
            strDate = Request.QueryString("d")

            'strSportGenderClass = "BasketballGirlsA"
            'strLevel = "TOSSAAD"

            Select Case strSportGenderClass
                Case "SPSoftball6A"
                    strHeader = "CLASS 6A SLOW PITCH "
                Case "SPSoftball5A"
                    strHeader = "CLASS 5A SLOW PITCH "
                Case "SPSoftball4A"
                    strHeader = "CLASS 4A SLOW PITCH "
                Case "SPSoftball3A"
                    strHeader = "CLASS 3A SLOW PITCH "
                Case "SPSoftball2A"
                    strHeader = "CLASS 2A SLOW PITCH "
                Case "SPSoftballA"
                    strHeader = "CLASS A SLOW PITCH "
                Case "SPSoftballB"
                    strHeader = "CLASS B SLOW PITCH "
                Case Else
                    strHeader = "CLASS 6A SLOW PITCH"
                    strSportGenderClass = "SPSoftball6A"
            End Select

            Select Case strLevel
                Case "TOSSAAD", "D"
                    strHeader = strHeader & " DISTRICTS"
                    If strLevel = "D" Then strLevel = "TOSSAAD"
                Case "TOSSAAR", "R"
                    strHeader = strHeader & " REGIONALS"
                    If strLevel = "R" Then strLevel = "TOSSAAR"
                Case "TOSSAAA", "A"
                    strHeader = strHeader & " AREA"
                    If strLevel = "A" Then strLevel = "TOSSAAA"
                Case "TOSSAAS", "S"
                    strHeader = strHeader & " STATE"
                    If strLevel = "S" Then strLevel = "TOSSAAS"
            End Select

            ' Set the SIZE...
            If Request.UserAgent.ToUpper.Contains("IPHONE") Then
                lblHeader.Style("font-size") = "1.6em"
                'Page.Form.Style.Item("margin-top") = "-70px"
                intButtonHeight = 70
                intButtonFontSize = 14
                ButtonsChange(intButtonHeight, intButtonFontSize)
            ElseIf Request.UserAgent.ToUpper.Contains("ANDROID") Then
                lblHeader.Style("font-size") = "4.0em"
                intButtonHeight = 150
                intButtonFontSize = 40
                ButtonsChange(intButtonHeight, intButtonFontSize)
            ElseIf Request.UserAgent.ToUpper.Contains("WINDOWS PHONE") Then
                intButtonHeight = 70
                intButtonFontSize = 14
                ButtonsChange(intButtonHeight, intButtonFontSize)
                lblHeader.Style("font-size") = "1.25em"
            ElseIf Request.UserAgent.ToUpper.Contains("IPAD") Then
                lblHeader.Style("font-size") = "2.5em"
                intButtonHeight = 60
                intButtonFontSize = 16
                ButtonsChange(intButtonHeight, intButtonFontSize)
            End If

            lblHeader.Text = strHeader

            LoadGames(strSportGenderClass, strLevel, strDate)

        End If
    End Sub

    Public Sub LoadGames(strSportGenderClass As String, strLevel As String, strGameDate As String)
        Dim strSQL As String = ""
        Dim datFlipDate As Date

        If strGameDate = "" Then
            strGameDate = FormatDateTime(Now, DateFormat.ShortDate)
            datFlipDate = strGameDate & " 10:00:00 AM"
            If DateDiff(DateInterval.Minute, datFlipDate, Now) > 0 Then
                ' Do nothing, use today's date...
            Else
                strGameDate = FormatDateTime(DateAdd(DateInterval.Day, -1, Now), DateFormat.ShortDate)
            End If
        End If

        strSQL = "SELECT TOP 100 tblSchedules.*, allCoachesDetail.SchoolName AS SchoolNameTop, allCoachesDetail_1.SchoolName AS SchoolNameBottom "
        strSQL = strSQL & "FROM tblSchedules INNER JOIN allCoachesDetail ON tblSchedules.teamID = allCoachesDetail.teamID INNER JOIN "
        strSQL = strSQL & "allCoachesDetail AS allCoachesDetail_1 ON tblSchedules.oTeamID = allCoachesDetail_1.teamID "
        If strLevel = "" Then
            If strGameDate = "" Then
                strSQL = strSQL & "WHERE (((tblSchedules.totalScore = 0 AND tblSchedules.ototalScore = 0) AND (tblSchedules.teamID > tblSchedules.oteamID)) OR (tblSchedules.totalScore > tblSchedules.ototalScore)) AND tblSchedules.sportID = '" & strSportGenderClass & "' AND tblSchedules.intYear = " & clsFunctions.GetCurrentYear & " "
            Else
                strSQL = strSQL & "WHERE (((tblSchedules.totalScore = 0 AND tblSchedules.ototalScore = 0) AND (tblSchedules.teamID > tblSchedules.oteamID)) OR (tblSchedules.totalScore > tblSchedules.ototalScore)) AND tblSchedules.sportID = '" & strSportGenderClass & "' AND tblSchedules.intYear = " & clsFunctions.GetCurrentYear & " AND gameDate = '" & strGameDate & "' "
            End If
        Else
            If strGameDate = "" Then
                strSQL = strSQL & "WHERE (((tblSchedules.totalScore = 0 AND tblSchedules.ototalScore = 0) AND (tblSchedules.teamID > tblSchedules.oteamID)) OR (tblSchedules.totalScore > tblSchedules.ototalScore)) AND tblSchedules.sportID = '" & strSportGenderClass & "' AND tblSchedules.strType = '" & strLevel & "' AND tblSchedules.intYear = " & clsFunctions.GetCurrentYear & " "
            Else
                strSQL = strSQL & "WHERE (((tblSchedules.totalScore = 0 AND tblSchedules.ototalScore = 0) AND (tblSchedules.teamID > tblSchedules.oteamID)) OR (tblSchedules.totalScore > tblSchedules.ototalScore)) AND tblSchedules.sportID = '" & strSportGenderClass & "' AND tblSchedules.strType = '" & strLevel & "' AND tblSchedules.intYear = " & clsFunctions.GetCurrentYear & " AND gameDate = '" & strGameDate & "' "
            End If
        End If
        strSQL = strSQL & "ORDER BY tblSchedules.intGame"

        Dim ds As DataSet
        Dim x As Integer = 0
        Dim strContent As String = ""
        Dim strStatus As String

        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)


        For x = 0 To ds.Tables(0).Rows.Count - 1
            With ds.Tables(0).Rows(x)
                If .Item("gStatus") Is System.DBNull.Value Then
                    strStatus = ""
                Else
                    Select Case .Item("gStatus")
                        Case "Final"
                            strStatus = "F"
                        Case Else
                            strStatus = .Item("gStatus")
                            If strStatus.Contains("OT") Then
                                strStatus = "EX"
                            Else
                                strStatus = ""
                            End If
                    End Select
                End If
                Dim objControl As System.Web.UI.WebControls.LinkButton
                objControl = FindControl("LinkButton" & x)
                objControl.Text = GetScore(.Item("SchoolNameTop"), .Item("SchoolNameBottom"), .Item("TotalScore"), .Item("oTotalScore"), .Item("rank"), .Item("orank"), strStatus, .Item("Location"), .Item("gameTime"))
                objControl.Visible = True
            End With
        Next


    End Sub

    Public Sub ButtonsChange(intButtonHeight As Integer, intButtonFontSize As Integer)
        Dim x As Integer = 0

        For x = 0 To 99
            Dim objControl As System.Web.UI.WebControls.LinkButton
            objControl = FindControl("LinkButton" & x)
            objControl.Height = Web.UI.WebControls.Unit.Pixel(intButtonHeight)
            objControl.Font.Size() = Web.UI.WebControls.FontUnit.Point(intButtonFontSize)
        Next

    End Sub

    Public Function GetScore(strTopTeam As String, strBottomTeam As String, intTopScore As Integer, intBottomScore As Integer, rank As Integer, orank As Integer, strStatus As String, strLocation As String, strGameTime As String) As String
        Dim strReturn As String

        strReturn = "<table runat='server' width='90%' height='120px'>"
        strReturn = strReturn & "<tr height='50%'>"
        strReturn = strReturn & "<td width='65%'>"
        If (strStatus = "F" Or strStatus = "OT" Or strStatus.Contains("EX")) And intTopScore > intBottomScore Then
            strReturn = strReturn & "<span style='color:Yellow;font-weight:bold;'>"
        End If
        If strLocation = "Home" Then strReturn = strReturn & "@"
        strReturn = strReturn & strTopTeam
        If rank > 0 Then
            strReturn = strReturn & "  #" & rank
        End If
        If (strStatus = "F" Or strStatus = "OT" Or strStatus.Contains("EX")) And intTopScore > intBottomScore Then
            strReturn = strReturn & "</span>"
        End If
        strReturn = strReturn & "</td>"
        strReturn = strReturn & "<td width='20%' style='text-align: right;'>"
        If (strStatus = "F" Or strStatus = "OT" Or strStatus.Contains("EX")) And intTopScore > intBottomScore Then
            strReturn = strReturn & "<span style='color:Yellow;font-weight:bold;'>"
        End If
        strReturn = strReturn & intTopScore
        If (strStatus = "F" Or strStatus = "OT" Or strStatus.Contains("EX")) And intTopScore > intBottomScore Then
            strReturn = strReturn & "</span>"
        End If
        strReturn = strReturn & "</td>"
        strReturn = strReturn & "<td width='10%'>"
        strReturn = strReturn & "&nbsp;&nbsp;" & strStatus
        strReturn = strReturn & "</td>"
        strReturn = strReturn & "</tr>"
        strReturn = strReturn & "<tr height='50%'>"
        strReturn = strReturn & "<td width='75%'>"
        If (strStatus = "F" Or strStatus = "OT" Or strStatus.Contains("EX")) And intTopScore < intBottomScore Then
            strReturn = strReturn & "<span style='color:Yellow;font-weight:bold;'>"
        End If
        If strLocation = "Away" Then strReturn = strReturn & "@"
        strReturn = strReturn & strBottomTeam
        If orank > 0 Then
            strReturn = strReturn & "  #" & orank
        End If
        If (strStatus = "F" Or strStatus = "OT" Or strStatus.Contains("EX")) And intTopScore > intBottomScore Then
            strReturn = strReturn & "</span>"
        End If
        If (strStatus = "F" Or strStatus = "OT" Or strStatus.Contains("EX")) Then
        Else
            strReturn = strReturn & "<span style='color:Yellow;font-weight:bold;font-size:Small;'>&nbsp;@&nbsp;" & strGameTime & "</span>"
        End If
        strReturn = strReturn & "</td>"
        strReturn = strReturn & "<td width='20%' style='text-align: right;'>"
        If (strStatus = "F" Or strStatus = "OT" Or strStatus.Contains("EX")) And intTopScore < intBottomScore Then
            strReturn = strReturn & "<span style='color:Yellow;font-weight:bold;'>"
        End If
        strReturn = strReturn & intBottomScore
        If (strStatus = "F" Or strStatus = "OT" Or strStatus.Contains("EX")) And intTopScore > intBottomScore Then
            strReturn = strReturn & "</span>"
        End If
        strReturn = strReturn & "</td>"
        strReturn = strReturn & "<td>&nbsp;</td>"
        strReturn = strReturn & "</tr>"
        strReturn = strReturn & "</table>"

        Return strReturn
    End Function

End Class