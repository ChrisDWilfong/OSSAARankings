Public Class BBRatingEntry
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub cmdShowOfficials_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdShowOfficials.Click
        Me.EligibleOfficialsBasketball1.Visible = True
        Me.lblEOff.Visible = True
    End Sub
End Class