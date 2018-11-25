Imports System.Net.Mail

Namespace Logger
	Public Class MailNotification
		''' <summary>
		''' Sends a mail to technik@froehlich.ch.
		''' </summary>
		''' <param name="msg">provide a msg for example an exception</param>
		Public Shared Sub SendLogMail(ByVal msg As String)
			Try
				Dim smtpServer As New SmtpClient("msscript1")
				Dim mail As MailMessage = New MailMessage()
				mail.HeadersEncoding = System.Text.Encoding.UTF8
				mail.BodyEncoding = System.Text.Encoding.UTF8
				mail.SubjectEncoding = System.Text.Encoding.UTF8

				mail.From = New MailAddress("ps2pdfMover@froehlich.ch")
				mail.To.Add("technik@froehlich.ch")
				mail.To.Add("niklaus@niklaus.com")
				mail.Subject = "Crash in PS2PDF-Mover"
				mail.IsBodyHtml = True

				mail.Body += "<h3>Fehlermeldung</h3>"

				msg = msg.Replace(" at ", "<br/>at ").Replace(" --->", "<br/>---> ").Replace(" in ", "<br/>in ")
				mail.Body += "<p>" + msg + "</p>"

				smtpServer.Send(mail)
			Catch ex As Exception
				MsgBox("Mailnotification hat nicht funktioniert!")
			End Try
		End Sub
	End Class
End Namespace