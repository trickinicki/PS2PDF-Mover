Imports System.IO


Module FolderWatcher

	Private m_fsw As New List(Of IO.FileSystemWatcher)
	Private mainConfig As New config


	Public Sub start()

		mainConfig.OpenConfig()

		For Each aFolderConfig In mainConfig.folderConfigurations
			Dim aNewfsw As New FileSystemWatcher(aFolderConfig.inFolder)
			AddHandler aNewfsw.Changed, AddressOf OnChanged
			aNewfsw.EnableRaisingEvents = True
			m_fsw.Add(aNewfsw)
		Next

	End Sub

	Public Sub stopWatching()
		For Each aFileSystemWatcher As FileSystemWatcher In m_fsw
			aFileSystemWatcher.EnableRaisingEvents = False
			aFileSystemWatcher.Dispose()
		Next
	End Sub

	Private Async Sub OnChanged(sender As Object, e As FileSystemEventArgs)

		If Await IsFileReady(e.FullPath) Then

			'get outFolder name
			Dim inFolder As String = e.FullPath.Replace("\" & e.Name, "")
			Dim outFolder As String = ""
			For Each aFolderconfig In mainConfig.folderConfigurations
				If aFolderconfig.inFolder = inFolder Then
					outFolder = aFolderconfig.outFolder
					Exit For
				End If
			Next

			'Datei umbenamsen
			Dim newFileName As String = getJobNameFromPS(e.FullPath)


			If File.Exists(outFolder & "\" & newFileName) Then File.Delete(outFolder & "\" & newFileName)

			'Datei verschieben
			File.Move(e.FullPath, outFolder & "\" & newFileName)

			''Log
			'Dim aForm As New Form1
			'aForm.logs = Format(Now, "dd.mm.yy hh:mm:ss") & ": " & outFolder & "\" & newFileName & vbCrLf & Form1.TextBoxLogging.Text

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
