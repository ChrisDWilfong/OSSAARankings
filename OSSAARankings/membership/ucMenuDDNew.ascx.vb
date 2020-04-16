Public Class ucMenuDDNew
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Session("membersLinksBoardPanel") = clsLinks.GetLinksNoTable("OSSAAMembers", "BOARDP", clsFunctions.GetCurrentYear)
        Session("membersLinksBoard") = clsLinks.GetLinksNoTable("OSSAAMembers", "BOARD", clsFunctions.GetCurrentYear)
        Session("membersLinksFinancials") = clsLinks.GetLinksNoTable("OSSAAMembers", "FIN", clsFunctions.GetCurrentYear)

    End Sub

End Class