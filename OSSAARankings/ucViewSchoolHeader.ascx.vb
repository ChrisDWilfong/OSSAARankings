Public Class ucViewSchoolHeader
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim SchoolID As Integer = 0
        Try
            SchoolID = Session("gSchoolID")
        Catch ex As Exception
            SchoolID = 0
        End Try
        Dim objSchoolInfo As New clsSchool("", SchoolID)
        lblSchool.Text = objSchoolInfo.getSchool & " Sports Page"
    End Sub

End Class