﻿Imports System.IO

Public Class Form1

	Private mainConfig As New config

	Private lastSelectedIndex As Integer = 0
	Public Sub New()

		' Dieser Aufruf ist für den Designer erforderlich.
		InitializeComponent()

		' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
		mainConfig.OpenConfig()

		TextBoxIntervall.Text = mainConfig.Intervall

		refreshFolderConfigutations()

		startWatching()
	End Sub

	Public Property logs() As String
		Get
			logs = TextBoxLogging.Text
		End Get

		Set(value As String)
			TextBoxLogging.Text = value
		End Set
	End Property


	Private Sub TextBoxIntervall_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxIntervall.KeyPress
		If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
			e.Handled = True
		End If
	End Sub

	Private Sub TextBoxIntervall_TextChanged(sender As Object, e As EventArgs) Handles TextBoxIntervall.TextChanged
		If CInt(TextBoxIntervall.Text) > 99 OrElse CInt(TextBoxIntervall.Text) < 1 Then

			Dim ToolTip1 As New ToolTip
			ToolTip1.IsBalloon = True
			ToolTip1.UseFading = True
			ToolTip1.ToolTipIcon = ToolTipIcon.Error
			ToolTip1.ToolTipTitle = "Bitte Wert von 1 bis 99 eingeben." & TextBoxIntervall.Text
			ToolTip1.Show("Falscher Wert", TextBoxIntervall, New Point(0, -80), 2500)
			'TextBox1.Text = ""

		End If
	End Sub

	Private Sub TextBoxIntervall_Leave(sender As Object, e As EventArgs) Handles TextBoxIntervall.Leave
		mainConfig.Intervall = TextBoxIntervall.Text

	End Sub


	Public Function selectFolder(oldValue As String) As String
		Dim OpenFolderDialog As New FolderBrowserDialog()
		OpenFolderDialog.Description = "Ordner auswählen"
		OpenFolderDialog.SelectedPath = oldValue

		' Show the Dialog.  
		If OpenFolderDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
			Return OpenFolderDialog.SelectedPath
		End If

		Return oldValue

	End Function

	Private Sub ButtonSaveMainSettings_Click(sender As Object, e As EventArgs) Handles ButtonSaveMainSettings.Click
		mainConfig.saveMainValues()
	End Sub

	Private Sub ButtonSaveFolderSettings_Click(sender As Object, e As EventArgs) Handles ButtonSaveFolderSettings.Click
		Dim oldFolderconfig As New folderConfiguration
		Dim newFolderConfig As New folderConfiguration

		oldFolderconfig.inFolder = ListBoxFolders.SelectedItem

		newFolderConfig.inFolder = TextBoxInFolder.Text
		newFolderConfig.outFolder = TextBoxOutFolder.Text

		mainConfig.saveFolderConfiguration(newFolderConfig, oldFolderconfig)

		Dim ToolTip1 As New ToolTip
		ToolTip1.IsBalloon = True
		ToolTip1.UseFading = True
		ToolTip1.ToolTipIcon = ToolTipIcon.None
		ToolTip1.ToolTipTitle = "Speichern" & TextBoxIntervall.Text
		ToolTip1.Show("Werte werden gespeichert", ButtonSaveFolderSettings, New Point(0, -80), 1000)

		refreshFolderConfigutations()
	End Sub

	Private Sub ButtonSelectInputFolder_Click_1(sender As Object, e As EventArgs) Handles ButtonSelectInputFolder.Click
		TextBoxInFolder.Text = selectFolder(TextBoxInFolder.Text)
	End Sub

	Private Sub ListBoxFolders_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxFolders.SelectedIndexChanged
		lastSelectedIndex = ListBoxFolders.SelectedIndex
		ConfigurationID.Text = lastSelectedIndex

		If lastSelectedIndex >= 0 Then
			Dim aFolderConfig As folderConfiguration = mainConfig.folderConfigurations.Item(lastSelectedIndex)
			TextBoxInFolder.Text = aFolderConfig.inFolder
			TextBoxOutFolder.Text = aFolderConfig.outFolder
		End If
	End Sub

	Private Sub ButtonNewDirectory_Click(sender As Object, e As EventArgs) Handles ButtonNewDirectory.Click
		lastSelectedIndex = -1
		ConfigurationID.Text = -1
		ListBoxFolders.SelectedIndex = -1

		TextBoxInFolder.Text = "Bitte Ordner auswählen ..."
		TextBoxOutFolder.Text = "Bitte Ordner auswählen ..."
	End Sub

	Private Sub ButtonSelectOutFolder_Click(sender As Object, e As EventArgs) Handles ButtonSelectOutFolder.Click
		TextBoxOutFolder.Text = selectFolder(TextBoxOutFolder.Text)
	End Sub

	Private Sub ButtonStart_Click(sender As Object, e As EventArgs) Handles ButtonStart.Click
		startWatching()

	End Sub

	Private Sub ButtonDeleteDirectory_Click(sender As Object, e As EventArgs) Handles ButtonDeleteDirectory.Click
		Dim aFolderConfig As New folderConfiguration
		aFolderConfig.inFolder = ListBoxFolders.SelectedItem
		mainConfig.deleteFolderConfiguration(aFolderConfig)
		refreshFolderConfigutations()

	End Sub

	Private Sub refreshFolderConfigutations()
		ListBoxFolders.Items.Clear()

		For Each aFolderConfig As folderConfiguration In mainConfig.folderConfigurations
			ListBoxFolders.Items.Add(aFolderConfig.inFolder)
		Next

		If mainConfig.folderConfigurations.Count > 0 Then
			If lastSelectedIndex > mainConfig.folderConfigurations.Count - 1 Then
				lastSelectedIndex = mainConfig.folderConfigurations.Count - 1
			End If
			ListBoxFolders.SelectedIndex = lastSelectedIndex
		End If
  End Sub

	Public Sub startWatching()
		If ButtonStart.Text = "Start" Then
			FolderWatcher.start()
			ButtonStart.Text = "Stop"
			LabelWatchedFolders.Text = mainConfig.folderConfigurations.Count & " Ordner werden überwacht."
		Else
			FolderWatcher.stopWatching()
			ButtonStart.Text = "Start"
			LabelWatchedFolders.Text = "Ordnerüberwachung gestoppt!"
		End If
	End Sub


End Class
