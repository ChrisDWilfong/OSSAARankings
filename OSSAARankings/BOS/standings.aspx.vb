
Public Class standings
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("BootstrapCardHeader") = clsPageObjects.GetBootstrapCardHeader
        Session("BootstrapRows") = clsBSData.GetBootstrapCardRowsWithDetail
        Session("BootstrapScores") = clsPageObjects.GetGamesList("BaseballFall", "2019-08-20")
    End Sub

End Class