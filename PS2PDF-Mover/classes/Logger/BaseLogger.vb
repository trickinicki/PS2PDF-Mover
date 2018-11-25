Imports System
Imports System.ComponentModel

Namespace Logger

  ''' <summary>
  ''' Abstract base class for all loggers.
  ''' </summary>
  Public MustInherit Class BaseLogger

    Public MustOverride Sub LogEvent(ByVal eventType As LogEvent, Optional ByVal sendMail As Boolean = False)

    Public MustOverride Sub LogException(ByVal ex As Exception, Optional ByVal sendMail As Boolean = False)

    Public Sub LogExceptionAsync(ByVal ex As Exception, Optional ByVal sendMail As Boolean = False)
      Try
        Dim worker As New BackgroundWorker
        worker.WorkerReportsProgress = False
        worker.WorkerSupportsCancellation = False
        AddHandler worker.DoWork, AddressOf DoWorkExceptionLog
        worker.RunWorkerAsync(ex)
      Catch exception As InvalidOperationException
        ex.ToLog()
      End Try
      If (sendMail) Then
        MailNotification.SendLogMail(ex.ToString())
      End If
    End Sub

    Public Sub LogEventAsync(ByVal eventType As LogEvent, Optional ByVal sendMail As Boolean = False)
      Try
        Dim worker As New BackgroundWorker
        worker.WorkerReportsProgress = False
        worker.WorkerSupportsCancellation = False
        AddHandler worker.DoWork, AddressOf DoWorkEventLog
        worker.RunWorkerAsync(eventType)
      Catch ex As Exception
        ex.ToLog()
      End Try
      If (sendMail) Then
        MailNotification.SendLogMail(String.Format("{0}; {1}; {2}", eventType.EventType, eventType.User, eventType.Message))
      End If
    End Sub

    Private Sub DoWorkExceptionLog(ByVal sender As Object, ByVal e As DoWorkEventArgs)
      Dim ex As Exception = CType(e.Argument, Exception)
      LogException(ex)
    End Sub

    Private Sub DoWorkEventLog(ByVal sender As Object, ByVal e As DoWorkEventArgs)
      Dim ev As LogEvent = CType(e.Argument, LogEvent)
      LogEvent(ev)
    End Sub

  End Class
End Namespace