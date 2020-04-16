Public Class OneTimeUtils
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dsS As DataSet
        Dim strSQLS As String = ""
        Dim strSQLD As String = ""
        Dim strSQL As String = ""
        Dim x As Integer
        Dim strSchoolName As String
        Dim intSchoolID As Integer

        strSQLS = "SELECT * FROM tblSchools ORDER BY SchoolMatch1"
        dsS = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQLS)

        For x = 0 To dsS.Tables(0).Rows.Count - 1
            strSchoolName = ""
            strSchoolName = dsS.Tables(0).Rows(x).Item("SchoolMatch1")
            strSchoolName = strSchoolName.ToUpper
            strSQL = "SELECT schoolID FROM tblSchool WHERE SchoolName = '" & strSchoolName & "'"
            intSchoolID = 0
            Try
                intSchoolID = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            Catch ex As Exception
                intSchoolID = 0
            End Try
            If intSchoolID > 0 Then
                With dsS.Tables(0).Rows(x)
                    strSQLD = "UPDATE tblSchool SET xrefID = " & .Item("schoolID") & " "
                    If Not .Item("coor") Is System.DBNull.Value Then
                        strSQLD = strSQLD & ", strCoor = '" & .Item("coor") & "' "
                    End If
                    If Not .Item("lat") Is System.DBNull.Value Then
                        strSQLD = strSQLD & ", strLat = '" & .Item("lat") & "' "
                    End If
                    If Not .Item("long") Is System.DBNull.Value Then
                        strSQLD = strSQLD & ", strLong = '" & .Item("long") & "' "
                    End If
                    strSQLD = strSQLD & "WHERE schoolID = " & intSchoolID
                    SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQLD)
                End With
            End If
        Next

        lblMessage.Text = "Process complete."
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim strSQL As String
        Dim strSQLD As String
        Dim ds As DataSet
        Dim x As Integer
        Dim intSchoolID As Integer = 0
        Dim intNewMemberID As Integer = 0


        ' Change existing tblRankingsWeeks from intYear = 9 to 13...
        'strSQL = "UPDATE tblRankingsWeeks SET intYear = 13, seasonID = 13, startDate = DATEADD(YEAR, 4, startDate), endDate = DATEADD(YEAR, 4, endDate), showStartDate = DATEADD(YEAR, 4, showStartDate), showEndDate = DATEADD(YEAR, 4, showEndDate)  WHERE intYear = 9"
        'strSQL = "UPDATE tblRankingsWeeks SET intYear = 13, seasonID = 13, startDate = DATEADD(DAY, 2, startDate), endDate = DATEADD(DAY, 2, endDate), showStartDate = DATEADD(DAY, 2, showStartDate), showEndDate = DATEADD(DAY, 2, showEndDate)  WHERE intYear = 13"





        strSQL = "SELECT * FROM tblMembers WHERE intYear = 9"
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        For x = 0 To ds.Tables(0).Rows.Count - 1
            intSchoolID = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT schoolID FROM tblSchool WHERE xrefID = " & ds.Tables(0).Rows(x).Item("schoolID"))
            With ds.Tables(0).Rows(x)

                ' Create new tblMembers...
                strSQLD = "INSERT INTO tblMembers (Username, Password, Role, schoolID, FirstName, LastName, Title, emailMain, emailAlt, intYear) VALUES ("
                If .Item("emailMain") Is System.DBNull.Value Then
                    strSQLD = strSQLD & "'" & .Item("Username") & "', 'password', 'Coach', "
                Else
                    strSQLD = strSQLD & "'" & .Item("emailMain") & "', 'password', 'Coach', "
                End If
                strSQLD = strSQLD & intSchoolID & ", "
                strSQLD = strSQLD & "'" & .Item("FirstName") & "', '" & .Item("LastName") & "', '" & .Item("Title") & "', "
                If Not .Item("emailMain") Is System.DBNull.Value Then
                    strSQLD = strSQLD & "'" & .Item("emailMain") & "', "
                End If
                If Not .Item("emailAlt") Is System.DBNull.Value Then
                    strSQLD = strSQLD & "'" & .Item("emailAlt") & "', "
                End If
                strSQLD = strSQLD & "13)"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQLD)

                ' Get the new memberid...
                strSQL = "SELECT TOP 1 memberID FROM tblMembers ORDER BY memberID DESC"
                intNewMemberID = 0
                intNewMemberID = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, strSQL)



                ' Create UPDATE tblRankings for 13...
                strSQL = "UPDATE tblRankings SET tblRankings.schoolID = (SELECT tblSchool.SchoolID FROM tblSchool WHERE tblSchool.xrefID=tblRankings.schoolID), "


            End With
        Next

    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim strSQL As String
        Dim ds As DataSet
        Dim x As Integer
        Dim intMemberID As Integer = 0

        strSQL = "SELECT * FROM tblTeams WHERE intYear = 13 AND memberID = 0"
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            For x = 0 To ds.Tables(0).Rows.Count - 1
                intMemberID = 0
                intMemberID = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT TOP 1 coachID FROM tblCoachTeams WHERE teamID = " & ds.Tables(0).Rows(x).Item("teamID"))
                If intMemberID > 0 Then
                    strSQL = "UPDATE tblTeams SET memberID = " & intMemberID & " WHERE teamID = " & ds.Tables(0).Rows(x).Item("teamID")
                    SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
                End If
            Next
            lblMessage.Text = "Process complete (" & x & ")"
        End If

    End Sub
End Class