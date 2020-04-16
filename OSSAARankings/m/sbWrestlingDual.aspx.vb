Public Class sbWrestlingDual
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Dim strSportGenderClass As String = ""
            Dim strLevel As String = ""
            Dim strHeader As String = ""
            Dim intButtonHeight As Integer = 60
            Dim intButtonFontSize As Integer = 12

            strSportGenderClass = Request.QueryString("sgc")
            strLevel = Request.QueryString("l")

            If strLevel = "" Then strLevel = "TOSSAASD"

            'strSportGenderClass = "Wrestling6A"
            'strLevel = "TOSSAASD"

            Select Case strSportGenderClass
                Case "Wrestling6A"
                    strHeader = "CLASS 6A DUAL "
                Case "Wrestling5A"
                    strHeader = "CLASS 5A DUAL "
                Case "Wrestling4A"
                    strHeader = "CLASS 4A DUAL "
                Case "Wrestling3A"
                    strHeader = "CLASS 3A DUAL "
                Case Else
                    strHeader = ""
            End Select

            Select Case strLevel
                Case "TOSSAASD"
                    strHeader = strHeader & " STATE"
            End Select

            Select Case strSportGenderClass
                Case "Wrestling6A"
                    lblHeader1.Text = "@ Firelake (Shawnee)"
                    lblHeader2.Text = "February 10-11, 2017"
                Case "Wrestling5A"
                    lblHeader1.Text = "@ Firelake (Shawnee)"
                    lblHeader2.Text = "February 10-11, 2017"
                Case "Wrestling4A"
                    lblHeader1.Text = "@ Firelake (Shawnee)"
                    lblHeader2.Text = "February 10-11, 2017"
                Case "Wrestling3A"
                    lblHeader1.Text = "@ Firelake (Shawnee)"
                    lblHeader2.Text = "February 10-11, 2017"
                Case Else
                    lblHeader1.Text = ""
                    lblHeader2.Text = ""
            End Select

            lblHeader.Text = strHeader

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

            If strSportGenderClass = "" Or strLevel = "" Then
            Else
                LoadGames(strSportGenderClass, strLevel)
            End If

        End If
    End Sub

    Public Sub ButtonsChange(intButtonHeight As Integer, intButtonFontSize As Integer)
        Dim x As Integer = 0

        For x = 0 To 15
            Dim objControl As System.Web.UI.WebControls.LinkButton
            objControl = FindControl("LinkButton" & x)
            objControl.Height = Web.UI.WebControls.Unit.Pixel(intButtonHeight)
            objControl.Font.Size() = Web.UI.WebControls.FontUnit.Point(intButtonFontSize)
            If Request.UserAgent.ToUpper.Contains("IPHONE") Then
                objControl.Style("padding-top") = "10px"
                'objControl.Style("padding-bottom") = "5px"
            End If
        Next

    End Sub

    Public Sub LoadGames(strSportGenderClass As String, strLevel As String)
        Dim strSQL As String = ""

        strSQL = "SELECT TOP 100 *, allCoachesDetail.SchoolName AS SchoolNameTop, allCoachesDetail_1.SchoolName AS SchoolNameBottom "
        'strSQL = strSQL & "FROM tblSchedules INNER JOIN allCoachesDetail ON tblSchedules.teamID = allCoachesDetail.teamID INNER JOIN "
        strSQL = strSQL & "FROM tblSchedules LEFT OUTER JOIN allCoachesDetail ON tblSchedules.teamID = allCoachesDetail.teamID LEFT OUTER JOIN "
        strSQL = strSQL & "allCoachesDetail AS allCoachesDetail_1 ON tblSchedules.oTeamID = allCoachesDetail_1.teamID "
        strSQL = strSQL & "WHERE tblSchedules.sportID = '" & strSportGenderClass & "' AND tblSchedules.strType = '" & strLevel & "' AND tblSchedules.intYear = " & clsFunctions.GetCurrentYear & " "
        strSQL = strSQL & "ORDER BY intGame, scheduleID"

        Dim ds As DataSet
        Dim x As Integer = 0
        Dim strContent As String = ""
        Dim strStatus As String
        Dim strTopTeam As String = ""
        Dim strBottomTeam As String = ""
        Dim strTopTeamTemp As String = ""
        Dim strBottomTeamTemp As String = ""
        Dim intGame As Integer = 0

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
                            strStatus = ""
                    End Select
                End If

                'If .Item("SchoolNameBottom") Is System.DBNull.Value And .Item("SchoolNameTop") Is System.DBNull.Value Then
                '    Dim objControl1 As System.Web.UI.WebControls.LinkButton
                '    objControl1 = FindControl("LinkButton" & x)
                '    objControl1.Text = GetScore(ds, .Item("OtherTeam"), .Item("OtherTeam"), 0, 0, strStatus)
                '    objControl1.Visible = True

                If .Item("SchoolNameBottom") Is System.DBNull.Value Then
                    strBottomTeamTemp = .Item("OtherTeam")
                Else
                    strBottomTeamTemp = .Item("SchoolNameBottom")
                End If

                If .Item("SchoolNameTop") Is System.DBNull.Value Then
                    strTopTeamTemp = .Item("OtherTeam")
                Else
                    strTopTeamTemp = .Item("SchoolNameTop")
                End If

                If .Item("intGame") > 1104 Then
                    If intGame = .Item("intGame") Then
                        ' Skip it...
                    Else
                        Dim objControl1 As System.Web.UI.WebControls.LinkButton
                        objControl1 = FindControl("LinkButton" & x)
                        objControl1.Text = GetScore(ds.Tables(0).Rows(x), strTopTeamTemp, strBottomTeamTemp, .Item("TotalScore"), .Item("oTotalScore"), strStatus)
                        objControl1.Visible = True
                    End If
                Else
                    If strTopTeam = strBottomTeamTemp And strBottomTeam = strTopTeamTemp Then
                        ' Skip it...
                    Else
                        Dim objControl As System.Web.UI.WebControls.LinkButton
                        objControl = FindControl("LinkButton" & x)
                        objControl.Text = GetScore(ds.Tables(0).Rows(x), strTopTeamTemp, strBottomTeamTemp, .Item("TotalScore"), .Item("oTotalScore"), strStatus)
                        objControl.Visible = True
                    End If
                End If

                If .Item("SchoolNameTop") Is System.DBNull.Value Then
                    strTopTeam = .Item("OtherTeam")
                Else
                    strTopTeam = .Item("SchoolNameTop")
                End If
                If .Item("SchoolNameBottom") Is System.DBNull.Value Then
                    strBottomTeam = .Item("OtherTeam")
                Else
                    strBottomTeam = .Item("SchoolNameBottom")
                End If
                intGame = .Item("intGame")

            End With
        Next

    End Sub

    Public Function GetScore(drow As System.Data.DataRow, strTopTeam As String, strBottomTeam As String, intTopScore As Integer, intBottomScore As Integer, strStatus As String) As String
        Dim strReturn As String

        strReturn = "<table runat='server' width='90%' height='120px'>"
        '================================
        strReturn = strReturn & "<tr height='33%'>"
        strReturn = strReturn & "<td width='65%'>"
        If strStatus = "F" And intTopScore > intBottomScore Then
            strReturn = strReturn & "<span style='color:Yellow;font-weight:bold;'>"
        End If
        If strTopTeam.Contains(" vs ") Then
            If strTopTeam = strBottomTeam Then
                strReturn = strReturn & strTopTeam
            Else
                Dim objSplitTop() As String = Split(strTopTeam, " vs ")
                strReturn = strReturn & objSplitTop(0)
            End If
        Else
            strReturn = strReturn & strTopTeam
        End If
            If strStatus = "F" And intTopScore > intBottomScore Then
                strReturn = strReturn & "</span>"
            End If
            strReturn = strReturn & "</td>"
            strReturn = strReturn & "<td width='20%' style='text-align: right;'>"
            If strTopTeam = strBottomTeam Then

            Else
                If strStatus = "F" And intTopScore > intBottomScore Then
                    strReturn = strReturn & "<span style='color:Yellow;font-weight:bold;'>"
                End If
                strReturn = strReturn & intTopScore
                If strStatus = "F" And intTopScore > intBottomScore Then
                    strReturn = strReturn & "</span>"
                End If
            End If
            strReturn = strReturn & "</td>"
            strReturn = strReturn & "<td width='10%'>"
            strReturn = strReturn & "&nbsp;&nbsp;" & strStatus
            strReturn = strReturn & "</td>"
            strReturn = strReturn & "</tr>"

            '================================
            strReturn = strReturn & "<tr height='33%'>"
            strReturn = strReturn & "<td width='75%'>"
            If strTopTeam = strBottomTeam Then

            Else
                If strStatus = "F" And intTopScore < intBottomScore Then
                    strReturn = strReturn & "<span style='color:Yellow;font-weight:bold;'>"
                End If
                If strBottomTeam.Contains(" vs ") Then
                    If strTopTeam = strBottomTeam Then
                        strReturn = strReturn & strBottomTeam
                    Else
                        Dim objSplitBottom() As String = Split(strBottomTeam, " vs ")
                        strReturn = strReturn & objSplitBottom(1)
                    End If
                Else
                    strReturn = strReturn & strBottomTeam
                End If
                If strStatus = "F" And intTopScore > intBottomScore Then
                    strReturn = strReturn & "</span>"
                End If
                strReturn = strReturn & "</td>"
                strReturn = strReturn & "<td width='20%' style='text-align: right;'>"
                If strStatus = "F" And intTopScore < intBottomScore Then
                    strReturn = strReturn & "<span style='color:Yellow;font-weight:bold;'>"
                End If
                strReturn = strReturn & intBottomScore
                If strStatus = "F" And intTopScore > intBottomScore Then
                    strReturn = strReturn & "</span>"
                End If
            End If
            strReturn = strReturn & "</td>"
            strReturn = strReturn & "<td>&nbsp;</td>"
            strReturn = strReturn & "</tr>"

            '================================
            strReturn = strReturn & "<tr height='33%'>"
            strReturn = strReturn & "<td width='75%'>"
            strReturn = strReturn & "<span style='color:Yellow;font-weight:normal;'>"

            strReturn = strReturn & clsFunctions.GetDayOfTheWeekString(Weekday(drow.Item("gameDate"))) & " " & drow.Item("gameTime") & " @ " & drow.Item("neutralSiteCoor")
            strReturn = strReturn & "</span>"
            strReturn = strReturn & "</td>"

            strReturn = strReturn & "</td>"
            strReturn = strReturn & "<td>&nbsp;</td>"
            strReturn = strReturn & "</tr>"
            strReturn = strReturn & "</table>"

            Return strReturn
    End Function

End Class