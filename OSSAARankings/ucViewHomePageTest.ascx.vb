Public Class ucViewHomePageTest
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strHeader As String

        strHeader = "<img src='../images/sponsors/titleSponsor.gif'><span style='font-size:20px;text-align:center;font-weight:bold'><br>Welcome to OSSAARANKINGS.COM</span><br><br><span style='font-size:18px;text-align:center;font-weight:normal;'>The official site of the Oklahoma Secondary School Activities Association for Oklahoma High School rankings, rosters, results, schedules and more.</span><br><br>"

        '===================================================
        strHeader = strHeader & "<span style='font-weight:normal;font-size:12px;height:50px;'>"
        strHeader = strHeader & "&nbsp;<br>"
        'strHeader = strHeader & "&nbsp;<br>"
        'strHeader = strHeader & "&nbsp;<br>"
        'strHeader = strHeader & "&nbsp;<br>"
        'strHeader = strHeader & "&nbsp;<br>"
        'strHeader = strHeader & "&nbsp;<br>"
        'strHeader = strHeader & "&nbsp;<br>"
        'strHeader = strHeader & "&nbsp;<br>"
        'strHeader = strHeader & "&nbsp;<br>"
        'strHeader = strHeader & "&nbsp;<br>"
        'strHeader = strHeader & "&nbsp;<br>"
        'strHeader = strHeader & "&nbsp;<br>"
        'strHeader = strHeader & "&nbsp;<br>"
        'strHeader = strHeader & "&nbsp;<br>"
        'strHeader = strHeader & "&nbsp;<br>"
        'strHeader = strHeader & "&nbsp;<br>"
        'strHeader = strHeader & "&nbsp;<br>"
        'strHeader = strHeader & "&nbsp;<br>"
        'strHeader = strHeader & "&nbsp;<br>"
        'strHeader = strHeader & "&nbsp;<br>"
        'strHeader = strHeader & "&nbsp;<br>"
        'strHeader = strHeader & "&nbsp;<br>"
        'strHeader = strHeader & "&nbsp;<br>"
        'strHeader = strHeader & "&nbsp;<br>"
        'strHeader = strHeader & "&nbsp;<br>"
        'strHeader = strHeader & "&nbsp;<br>"
        '''''strHeader = strHeader & "Thank you to our sponsors for providing our State Tournament Passes"      ' CDW removed 11/20/2019...
        strHeader = strHeader & "<br><br>"
        strHeader = strHeader & "</span>"
        lblHeader.Text = strHeader

    End Sub

End Class