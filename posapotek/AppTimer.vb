Module AppTimer
    Public GlobalStopwatch As Stopwatch = Nothing

    Public Sub StartTimer()
        If GlobalStopwatch Is Nothing Then
            GlobalStopwatch = New Stopwatch()
        End If
        If Not GlobalStopwatch.IsRunning Then
            GlobalStopwatch.Start()
        End If
    End Sub

    Public Function GetElapsedTime() As String
        If GlobalStopwatch Is Nothing Then
            Return "00:00:00"
        End If
        Return GlobalStopwatch.Elapsed.ToString("hh\:mm\:ss")
    End Function

    Public Sub ResetTimer()
        If GlobalStopwatch IsNot Nothing Then
            GlobalStopwatch.Reset()
        End If
    End Sub
End Module