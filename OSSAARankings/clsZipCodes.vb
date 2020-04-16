Imports System.Math

Public Class clsZipCodes

    Const PI As Double = 3.14159265358979
    Const Circumference As Double = 40123.648 'kilometers
    Const MilesPerKilometer As Double = 0.6214

    Private Function GetDistance(ByVal Latitude1 As Double, ByVal Longitude1 As Double, ByVal Latitude2 As Double, ByVal Longitude2 As Double) As Double

        Dim CosArc As Double
        Dim Arc As Double

        Latitude1 = Radians(Latitude1)
        Longitude1 = Radians(Longitude1)
        Latitude2 = Radians(Latitude2)
        Longitude2 = Radians(Longitude2)
        CosArc = (Sin(Latitude1) * Sin(Latitude2)) + _
        (Cos(Latitude1) * Cos(Latitude2) * Cos(Longitude1 - Longitude2))

        Arc = Degrees(Atan(-CosArc / System.Math.Sqrt(-CosArc * CosArc + 1)) + 2 * Atan(1))
        Return (Arc / 360 * Circumference) * MilesPerKilometer

    End Function
    Private Function Radians(ByVal Degrees As Double) As Double
        Radians = PI * Degrees / 180
    End Function
    Private Function Degrees(ByVal Radians As Double) As Double
        Degrees = Radians / PI * 180
    End Function

    Shared Function CalcDistance(ByVal strZipCode1 As String, ByVal strZipCode2 As String) As Integer
        Dim strSQL As String
        Dim ds As DataSet
        Dim dblLat1 As Double = 0
        Dim dblLat2 As Double = 0
        Dim dblLong1 As Double = 0
        Dim dblLong2 As Double = 0
        Dim x As Integer

        Try
            strZipCode1 = Left(strZipCode1, 5)
        Catch ex As Exception
            strZipCode1 = "99999"
        End Try

        Try
            strZipCode2 = Left(strZipCode2, 5)
        Catch ex As Exception
            strZipCode2 = "99999"
        End Try

        strSQL = "SELECT * FROM ZipCodeDatabase WHERE ZipCode = '" & strZipCode1 & "' OR ZipCode = '" & strZipCode2 & "'"

        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            For x = 0 To ds.Tables(0).Rows.Count - 1
                If dblLat1 = 0 Then
                    dblLat1 = ds.Tables(0).Rows(x).Item("Lat")
                    dblLong1 = ds.Tables(0).Rows(x).Item("Long")
                Else
                    dblLat2 = ds.Tables(0).Rows(x).Item("Lat")
                    dblLong2 = ds.Tables(0).Rows(x).Item("Long")
                End If
            Next
        End If

        Dim objZip As New clsZipCodes

        Return CInt(objZip.GetDistance(dblLat1, dblLong1, dblLat2, dblLong2))

    End Function

    Public Sub CalculateDistancesForOfficials()

    End Sub

End Class
