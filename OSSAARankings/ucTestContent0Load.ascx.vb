Public Class ucTestContent0Load
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'Me.Label1.Text = Now & " page load"
            Me.Label2.Text = Now & " page load 2"
        Else
            Dim objControl1 As UserControl
            objControl1 = CType(LoadControl("ucTestContent0Load.ascx"), UserControl)
            objControl1.Session.Add("value", Session("value"))
        End If
    End Sub

    Private Sub cmdRefresh_Load(sender As Object, e As System.EventArgs) Handles cmdRefresh.Load
        Me.Label2.Text = Now
    End Sub

End Class