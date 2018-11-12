Imports System.IO

Module FolderWatcher

	Private WithEvents m_fsw As IO.FileSystemWatcher

	Public Sub start(folderName As String)
		MsgBox(folderName)

		m_fsw = New IO.FileSystemWatcher(folderName)
		m_fsw.EnableRaisingEvents = True

	End Sub

	Private Sub m_fsw_Created(sender As Object, e As FileSystemEventArgs) Handles m_fsw.Created
		Try
			Await       MsgBox("hallo Welt")
		Catch ex As Exception

		End Try


	End Sub

	Public Function IsFileReady(ByVal filename As String) As Boolean
		Try

			Using inputStream As FileStream = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.None)
				Return inputStream.Length > 0
			End Using

		Catch __unusedException1__ As Exception
			Return False
		End Try
	End Function
End Module
