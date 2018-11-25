
Namespace Logger
  Public Class LogEvent

    Public Property ID() As Long

    Public Property Message() As String

    Public Property EventType As EventTypes

    Public Property User() As String

    Public ReadOnly Property EventTypeString As String
      Get
        Return EventType.ToString()
      End Get
    End Property

    Public Property Timestamp() As DateTime

  End Class
End Namespace