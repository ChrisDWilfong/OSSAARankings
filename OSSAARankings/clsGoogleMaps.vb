Imports System
Imports System.IO
Imports System.Net
Imports System.Text

Public Class clsGoogleMaps

    Shared Function GetMiles(ByVal strZip1 As String, ByVal strZip2 As String) As Integer
        Dim request As HttpWebRequest
        Dim response As HttpWebResponse = Nothing
        Dim reader As StreamReader
        Dim strURL As String
        Dim strResult As String
        Dim intResult As String
        Dim intPtr As Integer

        If strZip1 = "" Then
            Return 0
        Else
            strURL = "https://maps.googleapis.com/maps/api/distancematrix/xml?origins=" & strZip1 & "+USA&destinations=" & strZip2 & "+USA&mode=driving&language=EN&sensor=false&units=imperial&key=AIzaSyAvOBxoMkhEDUXnyByDEy7E428u7Meymes"
            Try
                ' Create the web request  
                request = DirectCast(WebRequest.Create(strURL), HttpWebRequest)

                ' Get response  
                response = DirectCast(request.GetResponse(), HttpWebResponse)

                ' Get the response stream into a reader  
                reader = New StreamReader(response.GetResponseStream())

                ' Console application output  
                'Console.WriteLine(reader.ReadToEnd())
                strResult = reader.ReadToEnd.ToString

                'intPtr = strResult.Contains(" mi</text>")
                intPtr = InStr(strResult, " mi</text>")
                If intPtr > 0 Then
                    Try
                        intResult = CInt(Replace(Mid(strResult, intPtr - 12, 12), "<text>", ""))
                    Catch
                        intResult = 9999
                    End Try
                Else
                    intResult = 9999
                End If
            Finally
                If Not response Is Nothing Then response.Close()
            End Try

            Return intResult
        End If

    End Function
End Class
