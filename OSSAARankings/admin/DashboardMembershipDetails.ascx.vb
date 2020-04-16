Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Configuration
Imports System.IO
Imports System.Data.SqlClient

Imports Telerik.Web.UI

Public Class DashboardMembershipDetails
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub UploadDocument_Click(sender As Object, e As EventArgs)

        Dim strReturnURL As String = ""

        If RadAsyncUpload1.InitialFileInputsCount < 1 Then
            UploadStatusLabel.Text = "Selected Image is required."
            Session("ReturnURL") = strReturnURL
            Exit Sub
        End If

        'Dim savePath As String = Server.MapPath(ConfigurationManager.AppSettings("documentsSavePath")) & "\"
        Dim savePath As String = ConfigurationManager.AppSettings("documentsSavePath")
        Dim linkPath As String = ConfigurationManager.AppSettings("documentsLinkPath")

        If Session("RadMenu2") = "" Then
        Else
            linkPath = linkPath & Session("RadMenu2")
        End If

        If RadAsyncUpload1.UploadedFiles.Count > 0 Then

            Dim file As UploadedFile = RadAsyncUpload1.UploadedFiles(0)
            Dim fileName As String = file.FileName

            'If Not Directory.Exists(savePath) Then
            '    Directory.CreateDirectory(savePath)
            'End If
            If Session("RadMenu2") = "" Then
                savePath = savePath & fileName
            Else
                savePath = savePath & Session("RadMenu2") & "\" & fileName
            End If
            savePath = Replace(savePath, "\admin", "")

            lblMessage.Text = savePath
            'Exit Sub

            RadAsyncUpload1.UploadedFiles(0).SaveAs(savePath)

            If Session("RadMenu2") = "" Then
                linkPath += fileName
            Else
                linkPath = linkPath & "\" & fileName
            End If
            strReturnURL = ConfigurationManager.AppSettings("documentsURL") & Replace(linkPath, "\", "/")
            Session("ReturnURL") = strReturnURL

            UploadStatusLabel.Text = "Link uploaded : " & linkPath
            lblMessage.Text = savePath
            'UploadStatusLabel.Text = "Link uploaded "

        Else
            ' Notify the user that a file was not uploaded.
            UploadStatusLabel.Text = "You did not specify a file to upload."
        End If

            If Session("ReturnURL") = "" Then
            Else
                Me.strLink.Text = Session("ReturnURL")
            End If

    End Sub

End Class