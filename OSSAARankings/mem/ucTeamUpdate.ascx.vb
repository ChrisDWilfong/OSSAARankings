Partial Class ucTeamUpdate
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            If Session("memgTeamID") Is Nothing Then
            Else
                LoadData(Session("memgTeamID"))
            End If
        End If

    End Sub

    Private Sub cmdSave_Click(sender As Object, e As System.EventArgs) Handles cmdSave.Click
        SaveChanges(Session("memgTeamID"))
    End Sub

    Public Sub LoadData(teamID As Long)

        If teamID = 0 Then

        Else
            Dim strSQL As String = "SELECT TOP 1 strUpdate FROM tblTeamsUpdate WHERE teamID = " & teamID & " ORDER BY Id DESC"
            Dim strTeamUpdate As String = ""

            strTeamUpdate = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, strSQL)
            If strTeamUpdate Is Nothing Then

            Else
                Me.txtMyTeamUpdate.Text = strTeamUpdate.Replace("<br>", vbCrLf)
            End If
        End If

    End Sub

    Public Sub SaveChanges(teamID As Long)

        Dim strVerify As String = VerifyData()
        strVerify = strVerify.Replace(vbLf, "<br>")
        Dim strSQL As String

        strSQL = "INSERT INTO tblTeamsUpdate (teamID, strUpdate) VALUES (" & teamID & ",  '" & strVerify & "')"
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        lblMessage.Text = "Changes have been saved."

    End Sub

    Public Function VerifyData() As String
        Dim strResult As String = Me.txtMyTeamUpdate.Text
        strResult = strResult.Replace("'", "")
        Return strResult
    End Function

    Private Sub Page_PreRender(sender As Object, e As System.EventArgs) Handles Me.PreRender
        LoadData(Session("memgTeamID"))
    End Sub

    Private Sub cmdClear_Click(sender As Object, e As EventArgs) Handles cmdClear.Click
        txtMyTeamUpdate.Text = "<br>"
        SaveChanges(Session("memgTeamID"))
    End Sub
End Class