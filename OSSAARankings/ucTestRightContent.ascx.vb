Public Class ucTestRightContent
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not IsPostBack Then
        Dim objControl As UserControl
        objControl = CType(LoadControl("ucTestContent.ascx"), UserControl)
        Me.PlaceHolderRightContent.Controls.Add(objControl)
        'End If
    End Sub

End Class