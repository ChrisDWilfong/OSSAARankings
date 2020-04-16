Partial Class sbSwimming
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Page.Session.Timeout = 120
            ' Load the dropdown of Tournaments...
            Dim strSQL As String = "SELECT [Id], [strPeriod] AS strDisplay FROM tblPlayoffDetail WHERE intYear = " & clsFunctions.GetCurrentYear & " AND intActive = 1 AND strType Like 'Swimming%' ORDER BY intSort"
            Dim ds As DataSet
            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAAScoreboard, CommandType.Text, strSQL)
            cboDetail.DataSource = ds
            cboDetail.DataBind()
        End If

    End Sub

    Public Sub LoadRecord()
        Dim strSQL As String
        If Me.cboDetail.SelectedIndex >= 0 Then
            Dim ds As DataSet
            strSQL = "SELECT * FROM tblPlayoffDetail WHERE Id = " & Me.cboDetail.SelectedValue
            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAAScoreboard, System.Data.CommandType.Text, strSQL)
            If ds Is Nothing Then
            ElseIf ds.Tables.Count = 0 Then
            ElseIf ds.Tables(0).Rows.Count = 0 Then
            Else
                With ds.Tables(0).Rows(0)
                    Me.intScore1.SelectedValue = .Item("intScore1")
                End With
            End If
        End If
    End Sub

    Protected Sub cmdGo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdGo.Click
        LoadRecord()
    End Sub

    Protected Sub cmdSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSave.Click
        Dim strSQL As String
        Dim intScore1 As Integer = 0

        Try
            intScore1 = Me.intScore1.SelectedValue
        Catch
            intScore1 = 0
        End Try

        strSQL = "UPDATE tblPlayoffDetail SET intScore1 = " & intScore1 & " WHERE Id = " & Me.cboDetail.SelectedValue
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAAScoreboard, System.Data.CommandType.Text, strSQL)

        lblMessage.Text = "Changes Saved"

    End Sub

    Public Function FilterString(strIn As String) As String
        Dim strOut As String
        strOut = strIn
        strOut = strIn.Replace("'", "")
        Return strOut
    End Function

    Public Sub ClearFields()
        Me.intScore1.SelectedIndex = 0
        Me.cboDetail.SelectedIndex = 0
    End Sub

    Protected Sub cboDetail_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDetail.SelectedIndexChanged
        LoadRecord()
    End Sub

    Private Sub UploadButton_Click(sender As Object, e As System.EventArgs) Handles UploadButton.Click

        Dim savePath As [String] = Server.MapPath("..\docs") & "\"
        Dim strFileName As String = ""
        Dim strFileNameDest As String = ""
        Dim id As Long = 0

        id = cboDetail.SelectedValue
        strFileName = FileUpload1.FileName

        strFileNameDest = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAAScoreboard, CommandType.Text, "SELECT txtLink FROM tblPlayoffDetail WHERE Id = " & id)
        strFileName = Replace(strFileNameDest, "http://www.ossaarankings.com/docs/", "")

        'Select Case cboDetail.SelectedItem.ToString
        '    Case "Class 6A State"
        '        strFileName = "SW_2015-16_6AState_Final_Results.pdf"
        '    Case "Class 6A Prelims"
        '        strFileName = "SW_2015-16_6AState_Prelim_Results.pdf"
        '    Case "Class 5A State"
        '        strFileName = "SW_2015-16_5AState_Final_Results.pdf"
        '    Case "Class 5A Prelims"
        '        strFileName = "SW_2015-16_5AState_Prelim_Results.pdf"
        'End Select

        If FileUpload1.HasFile Then
            savePath += strFileName
            FileUpload1.SaveAs(savePath)
            UploadStatusLabel.Text = "Your PDF was uploaded."
        Else
            UploadStatusLabel.Text = "You did not specify a file to upload."
        End If

    End Sub
End Class