Imports System.IO


Module FolderWatcher

	Private m_fsw As New List(Of IO.FileSystemWatcher)
	Private mainConfig As New config

	''' <summary>
	''' Start Folder wacthing
	''' </summary>
	''' <returns>Number of active FileSystemWatcher</returns>
	Public Function start() As Integer

		'Stop any ongoing filewatcher
		stopWatching()


		mainConfig.LoadConfig()
		Dim aCounter As Integer
		For Each aFolderConfig In mainConfig.folderConfigurations
			If aFolderConfig.active Then
				Dim aNewfsw As New FileSystemWatcher(aFolderConfig.inFolder)
				AddHandler aNewfsw.Changed, AddressOf OnChanged
				aNewfsw.EnableRaisingEvents = True
				m_fsw.Add(aNewfsw)
				aCounter += 1
			End If
		Next
		Return aCounter
	End Function

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
		Dim lineCounter As Integer

		Dim PSFieldNames As New List(Of String)
		PSFieldNames = (From s In mainConfig.PSFieldNames.Split(";") Select s).ToList()


		Dim fileExtension As New List(Of String)
		fileExtension = (From s In mainConfig.FileExtensions.Split(";") Select s).ToList()

		Dim ProgramPrefixes As New List(Of String) 
		ProgramPrefixes = (From s In mainConfig.ProgramPrefixes.Split(";") Select s).ToList()

		Do
			aLine = reader.ReadLine
			For Each aName As String In PSFieldNames

				If aLine.IndexOf(aName) > 0 Then
					reader.Close()

					Dim startIndex As Integer = aLine.IndexOf(">")
					Dim StopIndex As Integer = aLine.IndexOf("<", startIndex)

					Dim newName As String = aLine.Substring(startIndex + 1, StopIndex - startIndex - 1)
					For Each aExtension In fileExtension
						If aExtension <> "" Then newName = newName.Replace(aExtension, "")
					Next

					For Each aProgramPrefixes In ProgramPrefixes
						If aProgramPrefixes <> "" Then newName = newName.Replace(aProgramPrefixes, "")
					Next


					Return newName & ".ps"

				End If

			Next
			lineCounter += 1
			If lineCounter > 100 Then Exit Do
		Loop Until aLine Is Nothing
		reader.Close()

		Return "Unbekanntes Dokument" & CStr(Date.Today).Replace(".", "-") & ".ps"


	End Function

End Module
