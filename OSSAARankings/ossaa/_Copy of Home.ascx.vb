Partial Class Home2
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objControl1 As New UserControl
        objControl1 = CType(LoadControl("HomeColumn1.ascx"), UserControl)
        PlaceHolder1a.Controls.Add(objControl1)
        Dim objControl2 As New UserControl
        objControl2 = CType(LoadControl("HomeColumn2.ascx"), UserControl)
        PlaceHolder2a.Controls.Add(objControl2)
        Dim objControl3 As New UserControl
        objControl3 = CType(LoadControl("HomeColumn3.ascx"), UserControl)
        PlaceHolder3a.Controls.Add(objControl3)
    End Sub

End Class