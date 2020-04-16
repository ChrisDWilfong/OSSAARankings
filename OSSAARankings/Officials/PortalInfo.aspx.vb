Public Class PortalInfo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim strPersonalInfo As String = ""
        Dim strOfficialsInfo As String = ""
        Dim strMeetingsInfo As String = ""
        Dim id As Long = 0

        If Session("userEMAIL") Is Nothing Then
            Response.Redirect("Portal.aspx")
        ElseIf Session("userEMAIL") = "" Then
            Response.Redirect("Portal.aspx")
        End If

        ' Load the Info...
        If Session("ds") Is Nothing Then
            lblPersonalInfo.Text = strPersonalInfo
            lblOfficialsInfo.Text = strOfficialsInfo
            lblMeetings.Text = strMeetingsInfo
        Else
            Dim ds As DataSet
            ds = Session("ds")
            id = ds.Tables(0).Rows(0).Item("id")

            ' Load The Personal Info...
            strPersonalInfo = strPersonalInfo & "OSSAA ID# : " & ds.Tables(0).Rows(0).Item("intOSSAAID") & "<br>"
            strPersonalInfo = strPersonalInfo & "NAME : " & ds.Tables(0).Rows(0).Item("strFirstName") & " " & ds.Tables(0).Rows(0).Item("strLastName") & "<br>"
            strPersonalInfo = strPersonalInfo & "EMAIL : " & ds.Tables(0).Rows(0).Item("strEmail") & "<br>"
            lblPersonalInfo.Text = strPersonalInfo

            ' Load the Officials Info...
            strOfficialsInfo = strOfficialsInfo
            If ds.Tables(0).Rows(0).Item("ysnCurrentBasketball") <> 0 Then
                strOfficialsInfo = strOfficialsInfo & "BASKETBALL"
                strOfficialsInfo = strOfficialsInfo & "<br>&nbsp;- TEST : #1 = " & ds.Tables(0).Rows(0).Item("intTestBasketball") & " - #2 = " & IIf(ds.Tables(0).Rows(0).Item("intTestBasketball2") Is System.DBNull.Value, "", ds.Tables(0).Rows(0).Item("intTestBasketball2"))
                strOfficialsInfo = strOfficialsInfo & "<br>&nbsp;- RATINGS : Class = " & ds.Tables(0).Rows(0).Item("strClassBasketball") & " - Rating = " & IIf(ds.Tables(0).Rows(0).Item("dblRatingBasketball") Is System.DBNull.Value, "", ds.Tables(0).Rows(0).Item("dblRatingBasketball"))
                strOfficialsInfo = strOfficialsInfo & "<br>"
            End If
            If ds.Tables(0).Rows(0).Item("ysnCurrentFootball") <> 0 Then
                strOfficialsInfo = strOfficialsInfo & "FOOTBALL"
                strOfficialsInfo = strOfficialsInfo & "<br>&nbsp;- TEST : #1 = " & ds.Tables(0).Rows(0).Item("intTestFootball") & " - #2 = " & IIf(ds.Tables(0).Rows(0).Item("intTestFootball2") Is System.DBNull.Value, "", ds.Tables(0).Rows(0).Item("intTestFootball2"))
                strOfficialsInfo = strOfficialsInfo & "<br>&nbsp;- RATINGS : Class = " & ds.Tables(0).Rows(0).Item("strClassFootball") & " - Rating = " & IIf(ds.Tables(0).Rows(0).Item("dblRatingFootball") Is System.DBNull.Value, "", ds.Tables(0).Rows(0).Item("dblRatingFootball"))
                strOfficialsInfo = strOfficialsInfo & "<br>"
            End If
            If ds.Tables(0).Rows(0).Item("ysnCurrentBaseball") <> 0 Then
            End If
            If ds.Tables(0).Rows(0).Item("ysnCurrentSoftball") <> 0 Then
            End If
            If ds.Tables(0).Rows(0).Item("ysnCurrentSoftballSP") <> 0 Then
            End If
            If ds.Tables(0).Rows(0).Item("ysnCurrentSoccer") <> 0 Then
            End If
            If ds.Tables(0).Rows(0).Item("ysnCurrentTrack") <> 0 Then
            End If
            If ds.Tables(0).Rows(0).Item("ysnCurrentVolleyball") <> 0 Then
                strOfficialsInfo = strOfficialsInfo & "VOLLEYBALL"
                strOfficialsInfo = strOfficialsInfo & "<br>&nbsp;- TESTS #1 = " & ds.Tables(0).Rows(0).Item("intTestVolleyball")
                strOfficialsInfo = strOfficialsInfo & "<br>"
            End If
            If ds.Tables(0).Rows(0).Item("ysnCurrentWrestling") <> 0 Then
            End If
            lblOfficialsInfo.Text = strOfficialsInfo

            ' Load the Meetings Info...
            strMeetingsInfo = strMeetingsInfo & GetMeetingInformation(ds)
            lblMeetings.Text = strMeetingsInfo

        End If

    End Sub

    Private Sub cmdReturn_Click(sender As Object, e As EventArgs) Handles cmdReturn.Click
        Response.Redirect("Portal.aspx")
    End Sub

    Public Function GetMeetingInformation(ds As DataSet) As String
        Dim strResult As String

        strResult = ""

        If ds.Tables(0).Rows(0).Item("ysnMeeting1") = True Then
            strResult = strResult & SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, "SELECT strDesc FROM prodMeetingHeader WHERE intMeetingNo = 1") & "<br>"
        End If

        If ds.Tables(0).Rows(0).Item("ysnMeeting2") = True Then
            strResult = strResult & SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, "SELECT strDesc FROM prodMeetingHeader WHERE intMeetingNo = 2") & "<br>"
        End If

        If ds.Tables(0).Rows(0).Item("ysnMeeting3") = True Then
            strResult = strResult & SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, "SELECT strDesc FROM prodMeetingHeader WHERE intMeetingNo = 3") & "<br>"
        End If

        If ds.Tables(0).Rows(0).Item("ysnMeeting4") = True Then
            strResult = strResult & SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, "SELECT strDesc FROM prodMeetingHeader WHERE intMeetingNo = 4") & "<br>"
        End If

        If ds.Tables(0).Rows(0).Item("ysnMeeting5") = True Then
            strResult = strResult & SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, "SELECT strDesc FROM prodMeetingHeader WHERE intMeetingNo = 5") & "<br>"
        End If

        If ds.Tables(0).Rows(0).Item("ysnMeeting6") = True Then
            strResult = strResult & SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, "SELECT strDesc FROM prodMeetingHeader WHERE intMeetingNo = 6") & "<br>"
        End If

        If ds.Tables(0).Rows(0).Item("ysnMeeting7") = True Then
            strResult = strResult & SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, "SELECT strDesc FROM prodMeetingHeader WHERE intMeetingNo = 7") & "<br>"
        End If

        If ds.Tables(0).Rows(0).Item("ysnMeeting8") = True Then
            strResult = strResult & SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, "SELECT strDesc FROM prodMeetingHeader WHERE intMeetingNo = 8") & "<br>"
        End If

        If ds.Tables(0).Rows(0).Item("ysnMeeting9") = True Then
            strResult = strResult & SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, "SELECT strDesc FROM prodMeetingHeader WHERE intMeetingNo = 9") & "<br>"
        End If

        If ds.Tables(0).Rows(0).Item("ysnMeeting10") = True Then
            strResult = strResult & SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, "SELECT strDesc FROM prodMeetingHeader WHERE intMeetingNo = 10") & "<br>"
        End If

        If ds.Tables(0).Rows(0).Item("ysnMeeting11") = True Then
            strResult = strResult & SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, "SELECT strDesc FROM prodMeetingHeader WHERE intMeetingNo = 11") & "<br>"
        End If

        ' Football On-Line...
        If ds.Tables(0).Rows(0).Item("ysnMeeting12") = True Then
            strResult = strResult & SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, "SELECT strDesc FROM prodMeetingHeader WHERE intMeetingNo = 12") & "<br>"
        End If

        ' Slow-Pitch On-Line...
        If ds.Tables(0).Rows(0).Item("ysnMeeting13") = True Then
            strResult = strResult & SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, "SELECT strDesc FROM prodMeetingHeader WHERE intMeetingNo = 13") & "<br>"
        End If

        ' Baseball On-Line...
        If ds.Tables(0).Rows(0).Item("ysnMeeting14") = True Then
            strResult = strResult & SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, "SELECT strDesc FROM prodMeetingHeader WHERE intMeetingNo = 14") & "<br>"
        End If

        ' Basketball On-Line...
        If ds.Tables(0).Rows(0).Item("ysnMeeting15") = True Then
            strResult = strResult & SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, "SELECT strDesc FROM prodMeetingHeader WHERE intMeetingNo = 15") & "<br>"
        End If

        ' Soccer On-Line...
        If ds.Tables(0).Rows(0).Item("ysnMeeting16") = True Then
            strResult = strResult & SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, "SELECT strDesc FROM prodMeetingHeader WHERE intMeetingNo = 16") & "<br>"
        End If

        ' Wrestling On-Line...
        If ds.Tables(0).Rows(0).Item("ysnMeeting17") = True Then
            strResult = strResult & SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, "SELECT strDesc FROM prodMeetingHeader WHERE intMeetingNo = 17") & "<br>"
        End If

        ' LOCAL MEETINGS... Added 10/29/2012...
        If ds.Tables(0).Rows(0).Item("ysnMeeting31") <> 0 Then
            strResult = strResult & SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, "SELECT strDesc FROM prodMeetingHeader WHERE intMeetingNo = 31") & "<br>"
            'strResult = strResult & DLookup("strDesc", "prodMeetingHeader", "intMeetingNo = 31") & " (" & Me.ysnMeeting31 & ")" & "<br>"
        End If

        If ds.Tables(0).Rows(0).Item("ysnMeeting32") <> 0 Then
            strResult = strResult & SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, "SELECT strDesc FROM prodMeetingHeader WHERE intMeetingNo = 32") & "<br>"
            'strResult = strResult & DLookup("strDesc", "prodMeetingHeader", "intMeetingNo = 32") & " (" & Me.ysnMeeting32 & ")" & "<br>"
        End If

        Return strResult

    End Function
End Class