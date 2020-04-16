Partial Class test
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub cmdRefresh_Click(sender As Object, e As EventArgs) Handles cmdRefresh.Click

        ' ''Session("value") = 1

        ' ''Dim objControl1 As UserControl
        ' ''objControl1 = CType(LoadControl("ucTestRightContent.ascx"), UserControl)
        ' ''objControl1.Session.Add("value", Session("value"))

        'Dim objPlaceHolder As PlaceHolder
        'objPlaceHolder = Page.FindControl("ctl01$ucTestRightContent1$UpdatePanelRightContent$PlaceHolderRightContent")
        'objPlaceHolder.Controls.Add(objControl1)

    End Sub

    Private Sub cmdEnterSchedule_Click(sender As Object, e As System.EventArgs) Handles cmdEnterSchedule.Click
        Response.Redirect("test.aspx?sel=ScheduleLoad")
    End Sub
End Class