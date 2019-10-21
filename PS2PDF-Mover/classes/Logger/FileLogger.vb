Imports System
Imports System.IO

Namespace Logger
  ''' <summary>
  ''' Basic concrete Logger class
  ''' Logs exeception and events in /Logs
  ''' </summary>
  Public Class FileLogger
    Inherits BaseLogger

    Private Sub New()
      ''NOP
    End Sub

    Public Shared ReadOnly Property Instance() As BaseLogger
      Get
        If (IsNothing(_fileLogger)) Then
          _fileLogger = New FileLogger()
        End If
        Return _fileLogger
      End Get
    End Property

    Public Overrides Sub LogEvent(ByVal eventType As LogEvent, Optional ByVal sendMail As Boolean = False)
      CheckLogfile(_filenameEvents)

      Try
				Using writer As StreamWriter = File.AppendText(_filepath + _filenameEvents)
					writer.WriteLine(String.Format("{0}; {1}; {2}; {3};", DateTime.Now, eventType.EventType.ToString(), eventType.User, eventType.Message))
					writer.Flush()
				End Using

				Form1.TextBoxLog.Text = String.Format("{0}; {1}; {2}; {3};", DateTime.Now, eventType.EventType.ToString(), eventType.User, eventType.Message) & vbCrLf & Form1.TextBoxLog.Text
				If (sendMail) Then
          MailNotification.SendLogMail(String.Format("{0}; {1}; {2}", eventType.EventType, eventType.User, eventType.Message))
        End If
      Catch ex As Exception
				' Throw
			End Try

      CheckLogSize(_filenameEvents)
    End Sub

    Public Overrides Sub LogException(ByVal exception As Exception, Optional ByVal sendMail As Boolean = False)
      CheckLogfile(_filenameExceptions)

      Try
				Using writer As StreamWriter = File.AppendText(_filepath + _filenameExceptions)
					writer.WriteLine(String.Format("{0}; {1};", DateTime.Now, exception.ToString()))
					writer.Flush()
				End Using

				If (sendMail) Then
          MailNotification.SendLogMail(exception.ToString())
        End If
      Catch ex As Exception
				Throw
			End Try

      CheckLogSize(_filenameExceptions)
    End Sub

    Private Sub CheckLogfile(ByRef filename As String)
      Try
        If (Not Directory.Exists(_filepath)) Then
          Directory.CreateDirectory(_filepath)
        End If
        If (Not File.Exists(_filepath + filename)) Then
          File.Create(_filepath + filename).Close()
        End If
      Catch ex As Exception
        Throw
      End Try
    End Sub

    Private Sub CheckLogSize(ByRef filename As String)
      Try
        Dim fileInfo = New FileInfo(_filepath + filename)
        Dim sizeBytes = fileInfo.Length

        If (sizeBytes > 5120000) Then
          Dim lines As List(Of String) = File.ReadAllLines(_filepath + filename).ToList()
          File.Delete(_filepath + filename)
          CheckLogfile(filename)
          Dim count = Convert.ToInt32(lines.Count / 2)
          File.WriteAllLines(_filepath + filename, lines.GetRange(count, lines.Count - count))
        End If
      Catch ex As Exception
        Throw
      End Try
    End Sub

    Private Shared _fileLogger As FileLogger

    Private _filenameEvents As String = "EventLog.txt"

    Private _filenameExceptions As String = "ExceptionLog.txt"

		Private ReadOnly _filepath As String = Application.StartupPath() & Path.DirectorySeparatorChar & "logs" & Path.DirectorySeparatorChar

	End Class
End Namespace