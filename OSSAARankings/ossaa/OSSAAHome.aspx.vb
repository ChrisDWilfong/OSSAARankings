Public Class OSSAAHome
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objControl1 As New UserControl
        objControl1 = CType(LoadControl("Home.ascx"), UserControl)
        PlaceHolderHome.Controls.Add(objControl1)
        Page.Title = "OSSAA.com (Oklahoma Secondary School Activities Association)"
    End Sub

End Class