Imports YAF.Classes
Imports YAF.Controls
Imports YAF.Core
Imports YAF.Types.Interfaces
Imports YAF.Utilities
Imports YAF.Utils

Public Class _DefaultYAF
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Try
            Dim csType As Type = GetType(Page)

            If Not YafContext.Current.[Get](Of YafBoardSettings)().ShowRelativeTime Then
                Return
            End If

            Dim uRLToResource = Config.JQueryFile

            If Not uRLToResource.StartsWith("http") Then
                uRLToResource = YafForumInfo.GetURLToResource(Config.JQueryFile)
            End If

            ScriptManager.RegisterClientScriptInclude(Me, csType, "JQuery", uRLToResource)

            ScriptManager.RegisterClientScriptInclude(Me, csType, "jqueryTimeagoscript", YafForumInfo.GetURLToResource("js/jquery.timeago.js"))

            ScriptManager.RegisterStartupScript(Me, csType, "timeagoloadjs", JavaScriptBlocks.TimeagoLoadJs, True)
        Catch generatedExceptionName As Exception
            Me.Response.Redirect("~/forum/install/default.aspx")
        End Try
    End Sub
End Class