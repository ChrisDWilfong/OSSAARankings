Public Class ucMyDistrict
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objControl As UserControl
        Dim strControlName As String = ""

        strControlName = "../ucDistrictStandingsFootball.ascx"

        objControl = CType(LoadControl(strControlName), UserControl)
        PlaceHolderDistricts.Controls.Add(objControl)

    End Sub

End Class