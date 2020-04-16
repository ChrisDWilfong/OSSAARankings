Public Class OfficialWeekGrid
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("gYear") = clsFunctions.GetCurrentYear
    End Sub

End Class