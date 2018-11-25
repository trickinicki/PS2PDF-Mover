Imports System
Imports System.Runtime.CompilerServices

Namespace Logger
  ''' <summary>
  ''' Extension methods for the logger classes.
  ''' </summary>
  ''' <remarks></remarks>
  Public Module LoggerExtensions

    ''' <summary>
    ''' Logs the errror async using a background worker.
    ''' Will fall back to normal logging if async task are not allowed in this context.
    ''' </summary>
    <Extension()>
    Public Sub ToLogAsync(ByVal exception As Exception, Optional ByVal sendMail As Boolean = False)
      LoggerLocator.Instance.LogExceptionAsync(exception, sendMail)
    End Sub

    ''' <summary>
    ''' Logs the event async using a background worker.
    ''' Will fall back to normal logging if async task are not allowed in this context.
    ''' </summary>
    <Extension()>
    Public Sub ToLogAsync(ByVal type As LogEvent, Optional ByVal sendMail As Boolean = False)
      LoggerLocator.Instance.LogEventAsync(type, sendMail)
    End Sub

    ''' <summary>
    ''' Logs the exception to the log.
    ''' </summary>
    <Extension()>
    Public Sub ToLog(ByVal exception As Exception, Optional ByVal sendMail As Boolean = False)
      LoggerLocator.Instance.LogException(exception, sendMail)
    End Sub

    ''' <summary>
    ''' Logs the event to the log.
    ''' </summary>
    <Extension()>
    Public Sub ToLog(ByVal type As LogEvent, Optional ByVal sendMail As Boolean = False)
      LoggerLocator.Instance.LogEvent(type, sendMail)
    End Sub

  End Module
End Namespace