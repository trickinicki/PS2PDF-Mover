Imports System.IO
Imports PS2PDF_Mover.Logger

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
				Try
					Dim aNewfsw As New FileSystemWatcher(aFolderConfig.inFolder)
					AddHandler aNewfsw.Changed, AddressOf OnChanged
					aNewfsw.EnableRaisingEvents = True
					m_fsw.Add(aNewfsw)
					aCounter += 1
				Catch ex As Exception
					ToLog(ex)
				End Try
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

			Try 'Allenfalls vorhande Datei löschen

				If File.Exists(outFolder & "\" & newFileName) Then
					File.Delete(outFolder & "\" & newFileName)

					Dim aEvent As New LogEvent
					aEvent.EventType = EventTypes.fileDeleted
					aEvent.Message = outFolder & "\" & newFileName
					ToLog(aEvent)
				End If
			Catch ex As Exception
				ToLog(ex)
			End Try

			Try 'Datei verschieben
				File.Move(e.FullPath, outFolder & "\" & newFileName)

				Dim aEvent As New LogEvent
				aEvent.EventType = EventTypes.fileMoved
				aEvent.Message = outFolder & "\" & newFileName
				ToLog(aEvent)
			Catch ex As Exception
				ToLog(ex)
			End Try

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
		'%%Title: Testseite
		Dim aLine As String
		Dim reader As New StreamReader(filename, System.Text.Encoding.Default)
		Dim lineCounter As Integer

		Dim badCharcter As New List(Of String())
		badCharcter.Add((":,").Split(","))
		badCharcter.Add(("&,-").Split(","))
		badCharcter.Add((":,-").Split(","))

		badCharcter.Add(("\328,Ä").Split(","))
		badCharcter.Add(("\336,Ö").Split(","))
		badCharcter.Add(("\334,Ü").Split(","))

		badCharcter.Add(("\344,ä").Split(","))
		badCharcter.Add(("\366,ö").Split(","))
		badCharcter.Add(("\374,ü").Split(","))

		badCharcter.Add(("\307,C").Split(","))  'Ç
		badCharcter.Add(("\347,C").Split(","))  'ç

		badCharcter.Add(("/,-").Split(","))
		badCharcter.Add(("\,-").Split(","))


		Dim PSFieldNames As New List(Of String)
		PSFieldNames = (From s In mainConfig.PSFieldNames.Split(";") Select s).ToList()


		Dim fileExtension As New List(Of String)
		fileExtension = (From s In mainConfig.FileExtensions.Split(";") Select s).ToList()

		Dim ProgramPrefixes As New List(Of String) 
		ProgramPrefixes = (From s In mainConfig.ProgramPrefixes.Split(";") Select s).ToList()

		Do
			aLine = reader.ReadLine
			For Each aName As String In PSFieldNames

				If aLine.IndexOf(aName) >= 0 Then
					Dim newName As String = aLine
					reader.Close()

					Dim startIndex As Double = aLine.IndexOf(">") 'Defined as double because returns -1 if not found
					If startIndex > 0 Then
						Dim StopIndex As Double = aLine.IndexOf("<", CInt(startIndex))
						newName = newName.Substring(startIndex + 1, StopIndex - startIndex - 1)
					Else
						newName = newName.Replace(aName, "")
					End If

					For Each aExtension In fileExtension
						If aExtension <> "" Then newName = newName.Replace(aExtension, "")
					Next

					For Each aProgramPrefixes In ProgramPrefixes
						If aProgramPrefixes <> "" Then newName = newName.Replace(aProgramPrefixes, "")
					Next

					For Each aCharacter In badCharcter
						newName = newName.Replace(aCharacter(0), aCharacter(1))
					Next

					newName = newName.Trim
					newName = newName.Replace("  ", " ")

					If Left(newName, 1) = "(" Then
						newName = Right(newName, newName.Length - 1)
					End If

					If Right(newName, 1) = ")" Then
						newName = Left(newName, newName.Length - 1)
					End If

					Return newName.Trim & ".ps"

				End If

			Next
			lineCounter += 1
			If lineCounter > 100 Then Exit Do
		Loop Until aLine Is Nothing
		reader.Close()

		Return "Unbekanntes Dokument" & CStr(Date.Now).Replace(".", "-").Replace(":", "-") & ".ps"


	End Function

End Module
