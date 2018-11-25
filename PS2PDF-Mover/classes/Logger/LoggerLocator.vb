Namespace Logger
  ''' <summary>
  ''' Easy access to the active Logger.
  ''' </summary>
  Public Class LoggerLocator

    Private Sub New()
      'NOP
    End Sub

    Public Shared ReadOnly Property Instance() As BaseLogger
      Get
				If (_instance Is Nothing) Then
					'_instance = DatabaseLogger.Instance
					_instance = FileLogger.Instance
				End If
				Return _instance
      End Get
    End Property

    Public Sub LogEvent(ByVal eventType As LogEvent, Optional ByVal sendMail As Boolean = False)
      Instance.LogEvent(eventType, sendMail)
    End Sub

    Public Sub LogException(ByVal ex As Exception, Optional ByVal sendMail As Boolean = False)
      Instance.LogException(ex, sendMail)
    End Sub

    Public Shared Sub SetLogger(ByRef logger As BaseLogger)
      _instance = logger
    End Sub

    Private Shared _instance As BaseLogger

  End Class
End Namespace