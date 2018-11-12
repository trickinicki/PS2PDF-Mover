Imports System.IO

Public Class Form1
	Public Sub New()

		' Dieser Aufruf ist für den Designer erforderlich.
		InitializeComponent()

		' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
		OpenConfig()
		setMainValues()

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

	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ButtonStart.Click

		saveMainValues()
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



	Private Sub setMainValues()

		'https://stackoverflow.com/questions/752271/how-to-get-xml-node-from-xdocument

		Dim mainConfiguration As XElement = (From xml2 In configFile.Descendants("main")).FirstOrDefault()


		Dim IntervallElement As XElement = mainConfiguration.Descendants("Intervall").FirstOrDefault()
		If IsNothing(IntervallElement) Then
			Dim newNode As XElement = New XElement("Intervall", New XElement("Value", Intervall))
			mainConfiguration.Add(newNode)

		Else
			Intervall = IntervallElement.Descendants("Value").FirstOrDefault
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

	Private Sub saveConfigFile()
		configFile.Save(appPath & ConfigFileName)

	End Sub





#End Region

	Public Property Intervall As Integer = 1
	Public Property appPath As String = Application.StartupPath() & Path.DirectorySeparatorChar
	Public Property ConfigFileName As String = "ps2pdf.config"

	Private Property configFile As New XDocument


End Class
