Imports System.IO


Module FolderWatcher

	'	Private WithEvents m_fsw As New List(Of IO.FileSystemWatcher)
	Private outFolder As String

	Public Sub start(aInfolder As String, aOutFolder As String)

		outFolder = aOutFolder

		Dim aNewfsw As New FileSystemWatcher(aInfolder)
		AddHandler aNewfsw.Changed, AddressOf OnChanged
		aNewfsw.EnableRaisingEvents = True


	End Sub

	Public Sub stopWatching()
		'	m_fsw.EnableRaisingEvents = False
	End Sub

	Private Async Sub OnChanged(sender As Object, e As FileSystemEventArgs)

		If Await IsFileReady(e.FullPath) Then

			'Datei umbenamsen
			Dim newFileName As String = getJobNameFromPS(e.FullPath)

			If File.Exists(outFolder & "\" & newFileName) Then File.Delete(outFolder & "\" & newFileName)

			'Datei verschieben
			File.Move(e.FullPath, outFolder & "\" & newFileName)

		End If

	End Sub


	Public Async Function IsFileReady(ByVal filename As String) As Task(Of Boolean)
		Try
			Await Task.Delay(100)
			Using inputStream As FileStream = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.None)
				Return inputStream.Length > 0
			End Using

		Catch __unusedException1__ As Exception
			Return False
		End Try
	End Function

	Public Function getJobNameFromPS(filename As String) As String
		'<job-name syntax= "name" xml:Space = "preserve" > Microsoft Word - Brief an Neff 26-06-2018.docx</job-name>
		'<file-name syntax="text" xml:space="preserve">Microsoft Word - Brief an Neff 26-06-2018.docx</file-name>
		Dim aLine As String
		Dim reader As New StreamReader(filename, System.Text.Encoding.Default)

		Dim lineNames As New List(Of String)
		lineNames.Add("job-name")
		lineNames.Add("file-name")


		Dim fileExtension As New List(Of String)
		fileExtension.Add(".docx")
		fileExtension.Add(".doc")
		fileExtension.Add(".xlsx")
		fileExtension.Add(".xls")
		fileExtension.Add(".indd")

		Dim relpaceTexts As New List(Of String)
		relpaceTexts.Add("Microsoft Word - ")
		relpaceTexts.Add("Microsoft Excel - ")

		Do
			aLine = reader.ReadLine
			For Each aName As String In lineNames
				If aLine.IndexOf(aName) > 0 Then
					reader.Close()

					Dim startIndex As Integer = aLine.IndexOf(">")
					Dim StopIndex As Integer = aLine.IndexOf("<", startIndex)

					Dim newName As String = aLine.Substring(startIndex + 1, StopIndex - startIndex - 1)
					For Each aExtension In fileExtension
						newName = newName.Replace(aExtension, "")
					Next

					For Each aText In relpaceTexts
						newName = newName.Replace(aText, "")
					Next


					Return newName & ".ps"

				End If
			Next

		Loop Until aLine Is Nothing
		reader.Close()

		Return "Unbekanntes Dokument" & CStr(Date.Today).Replace(".", "-") & ".ps"


	End Function

End Module
