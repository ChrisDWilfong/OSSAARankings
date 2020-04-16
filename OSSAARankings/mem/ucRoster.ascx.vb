Public Class ucRoster
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Page.Form.Enctype = "multipart/form-data"
        End If

        ShowPicture()

        Select Case Session("memsel")
            Case "Roster"
                PanelRosterAdd.Visible = False
            Case "RosterEdit"
                If Request.QueryString("r") = "" Then
                Else
                    PanelRosterAdd.Visible = True
                    Session("memgRosterID") = Request.QueryString("r")
                End If
            Case "RosterAdd"
                Session("memgRosterID") = 0
                PanelRosterAdd.Visible = True
            Case Else
                PanelRosterAdd.Visible = False
        End Select

        ' If we are adding, hid the List...
        If ucRosterAdd1.Visible Then
            PanelRosterList.Enabled = False
        Else
            PanelRosterList.Enabled = True
        End If

    End Sub

    Private Sub cmdAdd_Click(sender As Object, e As System.EventArgs) Handles cmdAdd.Click
        Response.Redirect("Home.aspx?sel=RosterAdd")
    End Sub

    Private Sub cmdUpload_Click(sender As Object, e As System.EventArgs) Handles cmdUpload.Click
        Dim strFileName As String
        Dim x As Integer
        Dim strExt As String
        Dim strSQL As String

        If FileUpload1.HasFile Then
            If (FileUpload1.PostedFile.ContentLength > 8192000) Then
                lblStatus.Text = "File is too big to upload."
            Else
                strFileName = System.IO.Path.GetFileName(FileUpload1.FileName)
                x = InStr(strFileName, ".")
                strExt = Mid(strFileName, x, 100)
                strFileName = Session("memgTeamID") & strExt
                If strFileName.ToUpper.Contains(".DOC") Or strFileName.ToUpper.Contains(".PDF") Or strFileName.ToUpper.Contains(".XLS") Then
                    lblStatus.Text = "Upload canceled.  Invalid file type.  Must be a graphic (.JPG, .GIF, .BMP, etc)."
                Else
                    FileUpload1.SaveAs(MapPath(clsTeams.GetTeamPixLocation) & strFileName)
                End If

                ' Write to database...
                strSQL = "UPDATE tblTeams SET teamPicture = '" & strFileName & "', teamPictureView = 1 WHERE teamID = " & Session("memgTeamID")
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
                Session("memgTeamPicture") = strFileName
                Dim strPictureLocation As String = clsTeams.GetTeamPixLocation
                strPictureLocation = strPictureLocation.Replace("~", "http://www.ossaarankings.com")
                Dim strContent As String = "Picture uploaded : " & strPictureLocation & Session("memgTeamPicture") & " : " & Session("memgSchool") & " " & Session("memgSportDisplay")
                clsEmail.SendEmail(Me, strContent, "cwilfong@ossaa.com", "cwilfong@ossaa.com", "OSSAARankings.com Picture Uploaded by " & Session("memgSchool") & " " & Session("memgSportDisplay"))
                lblStatus.Text = "Picture uploaded"
                ShowPicture()
            End If
        End If
    End Sub

    Private Sub cmdRemove_Click(sender As Object, e As System.EventArgs) Handles cmdRemove.Click
        Dim strSQL As String
        strSQL = "UPDATE tblTeams SET teamPicture = '' WHERE teamID = " & Session("memgTeamID")
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
        Session("memgTeamPicture") = ""
        lblStatus.Text = "Picture Removed."
        ShowPicture()
    End Sub

    Public Sub ShowPicture()
        If Session("memgTeamPicture") = "" Then
            imgTeamPicture.Visible = False
        Else
            imgTeamPicture.Visible = True
            imgTeamPicture.ImageUrl = clsTeams.GetTeamPixLocation & Session("memgTeamPicture")
            imgTeamPicture.DataBind()
        End If
    End Sub
End Class