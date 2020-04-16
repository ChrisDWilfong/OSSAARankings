Public Class RegistrationA
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strURL As String = ""

        If Session("userEMAIL") Is Nothing Then
            Response.Redirect("Portal.aspx")
        ElseIf Session("userEMAIL") = "" Then
            Response.Redirect("Portal.aspx")
        End If

        If Session("doRegistration") = "NEW-MEMBER" Or Session("doRegistration") = "OUT-OF-STATE" Or Session("doRegistration") = "RETURNING-MEMBER" Then
            ' CDW added 5/29/2019...
            strURL = clsOfficials.GetRegistrationURL(Session("doRegistration"), Session("doRegSport"))
        Else
            lblMessage.Text = "You have made an invalid selection.  Click the button below to return to the PORTAL HOME"
            cmdGoHome.Visible = True
            cmdRegister.Visible = False
            cmdRegister1.Visible = False
            rowIFrame.Visible = False
        End If

        Session("iframeURL") = "<iframe runat='server' name='regIFrame' src='" & strURL & "' width='1000' height='900' frameborder='0' security='restricted'></iframe>"

    End Sub

    Private Sub cmdRegister1_Click(sender As Object, e As EventArgs) Handles cmdRegister1.Click
        clsOfficials.LogRegistration("Registration", "Later", Session("doRegSport"), Request.UserHostAddress, Request.UserAgent, Session("userOSSAAID"), Session("userEMAIL"), Session("userRES"), Session("userZIPCODE"), Session("doRegistration"), Session("regStatus"))
        Response.Redirect("Portal.aspx")
    End Sub

    Private Sub cmdRegister_Click(sender As Object, e As EventArgs) Handles cmdRegister.Click
        ' Log the SPORTS registration to the OSSAARegLog database...
        clsOfficials.LogRegistration("Registration", "Complete", Session("doRegSport"), Request.UserHostAddress, Request.UserAgent, Session("userOSSAAID"), Session("userEMAIL"), Session("userRES"), Session("userZIPCODE"), Session("doRegistration"), Session("regStatus"))
        ' Go HOME...
        Response.Redirect("Portal.aspx")
    End Sub

    Private Sub cmdGoHome_Click(sender As Object, e As EventArgs) Handles cmdGoHome.Click
        clsOfficials.LogRegistration("Registration", "GoHome", Session("doRegSport"), Request.UserHostAddress, Request.UserAgent, Session("userOSSAAID"), Session("userEMAIL"), Session("userRES"), Session("userZIPCODE"), Session("doRegistration"), Session("regStatus"))
        Response.Redirect("Portal.aspx")
    End Sub
End Class