Public Class WHReportEntry
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("gYear") = clsFunctions.GetCurrentYear
    End Sub

End Class