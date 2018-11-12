Imports System.IO

Public Class Form1
	Public Property Intervall As Integer = 1
	Public Property appPath As String = Application.StartupPath() & Path.DirectorySeparatorChar
	Public Property ConfigFileName As String = "ps2pdf.config"

	Private Property configFile As New XDocument

	Private lastSelectedIndex As Integer = 0
	Public Sub New()

		' Dieser Aufruf ist für den Designer erforderlich.
		InitializeComponent()

		' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
		OpenConfig()
		getMainValues()
		getFoldersConfiguration()

	End Sub


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
		Intervall = TextBoxIntervall.Text

	End Sub


#Region "Read/Write Configuration"
	Private Sub OpenConfig()
		'Überprüft ob Konfigurationsdatei existiert undd öffnet diese
		'Falls die Datei noch nicht vorhanden ist wird sie generiert
		'und mit den nötigen Nodes versehen


		'Überprüfen ob Dokument existiert
		Dim FI As New FileInfo(appPath & ConfigFileName)
		If FI.Exists Then
			configFile = XDocument.Load(appPath & ConfigFileName) 'Öffnen der Konfigurationsdatei
		Else 'vreate File
			configFile = <?xml version="1.0" encoding="UTF-8"?>
									 <config>
										 <main>
										 </main>
										 <folders>
										 </folders>
									 </config>

		End If

		configFile.Save(appPath & ConfigFileName)

	End Sub



	Private Sub getMainValues()

		'https://stackoverflow.com/questions/752271/how-to-get-xml-node-from-xdocument

		Dim mainConfiguration As XElement = (From xml In configFile.Descendants("main")).FirstOrDefault()


		Dim IntervallElement As XElement = mainConfiguration.Descendants("Intervall").Descendants("Value").FirstOrDefault()
		If IsNothing(IntervallElement) Then
			Dim newNode As XElement = New XElement("Intervall", New XElement("Value", Intervall))
			mainConfiguration.Add(newNode)

		Else
			Intervall = IntervallElement
		End If

		'Fals neue Standardwerte übergeben wurden, müssen diese gespeichert werden
		saveConfigFile()

		'Werte in Felder übergeben
		TextBoxIntervall.Text = Intervall

	End Sub

	Private Sub saveMainValues()

		configFile.Descendants("main").Descendants("Intervall").FirstOrDefault().Value = Intervall
		saveConfigFile()

	End Sub

	Private Sub getFoldersConfiguration()
		'https://stackoverflow.com/questions/752271/how-to-get-xml-node-from-xdocument

		Dim folderConfiguration As XElement = (From xml In configFile.Descendants("folders")).First

		'Liste zuerst löschen
		ListBoxFolders.Items.Clear()

		If folderConfiguration.Nodes().Count > 0 Then
			For Each aNode As XElement In folderConfiguration.Descendants("folderConfiguration")
				ListBoxFolders.Items.Add(aNode.Descendants("inFolder").First.Value)
			Next
			ListBoxFolders.SelectedIndex = lastSelectedIndex

		Else
			ConfigurationID.Text = 0
		End If

	End Sub

	Private Sub getFolderConfiguration()

		If ListBoxFolders.SelectedIndex >= 0 Then
			Dim folderConfiguration As XElement = (From xml In configFile.Descendants("folders").Descendants("folderConfiguration") Where xml.Element("inFolder").Value = ListBoxFolders.SelectedItem).First

			TextBoxInFolder.Text = folderConfiguration.Descendants("inFolder").First
			TextBoxOutFolder.Text = folderConfiguration.Descendants("outFolder").First
		Else
			TextBoxInFolder.Text = "Bitte Ordner wählen..."
			TextBoxOutFolder.Text = "Bitte Ordner wählen..."
		End If

	End Sub

	Private Sub saveFolderConfiguration()


		If CInt(ConfigurationID.Text) >= 0 Then 'Update Entry
			Dim folderConfiguration As XElement = (From xml In configFile.Descendants("folders").Descendants("folderConfiguration") Where xml.Element("inFolder").Value = ListBoxFolders.SelectedItem).First
			folderConfiguration.Descendants("inFolder").First.SetValue(TextBoxInFolder.Text)
			folderConfiguration.Descendants("outFolder").First.SetValue(TextBoxOutFolder.Text)
		Else 'New Entry
			Dim folderConfiguration As XElement = (From xml In configFile.Descendants("folders")).First
			Dim newConfiguration As XElement = New XElement("folderConfiguration", New XElement("inFolder", TextBoxInFolder.Text))
			Dim outFolder As XElement = New XElement("outFolder", TextBoxOutFolder.Text)
			newConfiguration.Add(outFolder)
			folderConfiguration.Add(newConfiguration)

			lastSelectedIndex = ListBoxFolders.Items.Count
		End If

		saveConfigFile()
		getFoldersConfiguration()

	End Sub

	Private Sub saveConfigFile()
		configFile.Save(appPath & ConfigFileName)

	End Sub


#End Region

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
		saveConfigFile()
	End Sub

	Private Sub ButtonSaveFolderSettings_Click(sender As Object, e As EventArgs) Handles ButtonSaveFolderSettings.Click
		saveFolderConfiguration()

		Dim ToolTip1 As New ToolTip
		ToolTip1.IsBalloon = True
		ToolTip1.UseFading = True
		ToolTip1.ToolTipIcon = ToolTipIcon.None
		ToolTip1.ToolTipTitle = "Speichern" & TextBoxIntervall.Text
		ToolTip1.Show("Werte werden gespeichert", ButtonSaveFolderSettings, New Point(0, -80), 1000)
	End Sub

	Private Sub ButtonSelectInputFolder_Click_1(sender As Object, e As EventArgs) Handles ButtonSelectInputFolder.Click
		TextBoxInFolder.Text = selectFolder(TextBoxInFolder.Text)
	End Sub

	Private Sub ListBoxFolders_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxFolders.SelectedIndexChanged
		lastSelectedIndex = ListBoxFolders.SelectedIndex
		ConfigurationID.Text = lastSelectedIndex
		getFolderConfiguration()
	End Sub

	Private Sub ButtonNewDirectory_Click(sender As Object, e As EventArgs) Handles ButtonNewDirectory.Click
		lastSelectedIndex = -1
		ConfigurationID.Text = -1
		ListBoxFolders.SelectedIndex = -1
	End Sub

	Private Sub ButtonSelectOutFolder_Click(sender As Object, e As EventArgs) Handles ButtonSelectOutFolder.Click
		TextBoxOutFolder.Text = selectFolder(TextBoxOutFolder.Text)
	End Sub

	Private Sub ButtonStart_Click(sender As Object, e As EventArgs) Handles ButtonStart.Click
		FolderWatcher.start(ListBoxFolders.SelectedItem)
	End Sub
End Class
