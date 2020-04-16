Public Class ucViewHomePage
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strHeader As String

        ' CDW 11/14/2019.. For Ad Testing...
        Dim objHL01 As HyperLink
        Dim objHL02 As HyperLink
		Dim objHL03 As HyperLink
		Dim objHL04 As HyperLink
		objHL01 = RadRotator1.Items(0).FindControl("hlAd01")
        objHL02 = RadRotator1.Items(1).FindControl("hlAd02")
		objHL03 = RadRotator1.Items(2).FindControl("hlAd03")
		objHL04 = RadRotator1.Items(3).FindControl("hlAd04")
		Try
            'If Request.QueryString("ads") = "VYPE" Then
            objHL01.NavigateUrl = "http://www.skordle.com/"
            objHL01.ImageUrl = "~/images/sponsors/Ad_Skordle_250x250.png"
            objHL02.NavigateUrl = "https://cicad.us/2XwwOmE"
            objHL02.ImageUrl = "~/images/sponsors/Ad_Army_250x250.jpg"
            objHL03.NavigateUrl = "http://buyfordnow.com"
			objHL03.ImageUrl = "~/images/sponsors/Ad_Ford_250x250.jpg"
			objHL04.NavigateUrl = "https://oerb.com?utm_source=displayspon&utm_medium=display&utm_campaign=InspiringFutureLeaders-2billion-p"
			objHL04.ImageUrl = "~/images/sponsors/OKOilAndNaturalGasSquare1.jpg"
			RadRotator1.Width = 250
            RadRotator1.Height = 250
            RadRotator1.ItemWidth = 251
            RadRotator1.ItemHeight = 251
            'Else
            'objHL01.NavigateUrl = "http://www.skordle.com/"
            'objHL01.ImageUrl = "~/images/sponsors/Skordle300.png"
            'objHL02.NavigateUrl = "http://www.skordle.com/"
            'objHL02.ImageUrl = "~/images/sponsors/Skordle300.png"
            'lblHeader.Visible = True
            'End If
        Catch
        End Try

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