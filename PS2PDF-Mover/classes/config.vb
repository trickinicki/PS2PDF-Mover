Option Explicit On

Imports System.IO

Public Class config

	Public Property Intervall As Integer = 1
	Public Property appPath As String = Application.StartupPath() & Path.DirectorySeparatorChar
	Public Property ConfigFileName As String = "ps2pdf.config"

	Public Property folderConfigurations As List(Of folderConfiguration)
	Private Property configFile As New XDocument



	Public Function OpenConfig() As config
		'Überprüft ob Konfigurationsdatei existiert undd öffnet diese
		'Falls die Datei noch nicht vorhanden ist wird sie generiert
		'und mit den nötigen Nodes versehen

		Dim aMainConfig As New config
		Dim saveConfig As Boolean = False

		'Überprüfen ob Dokument existiert
		Dim FI As New FileInfo(appPath & ConfigFileName)
		If FI.Exists Then
			configFile = XDocument.Load(appPath & ConfigFileName) 'Öffnen der Konfigurationsdatei
		Else 'create File
			configFile = <?xml version="1.0" encoding="UTF-8"?>
									 <config>
										 <main>
										 </main>
										 <folders>
										 </folders>
									 </config>
			saveConfig = True
		End If

		If saveConfig Then configFile.Save(appPath & ConfigFileName)

		aMainConfig = getMainValues(aMainConfig)
		aMainConfig = getFoldersConfiguration(aMainConfig)

		Return aMainConfig
	End Function


	Private Function getMainValues(aMainConfig As config)
		Dim saveConfig As Boolean = False
		'https://stackoverflow.com/questions/752271/how-to-get-xml-node-from-xdocument

		Dim mainConfiguration As XElement = (From xml In configFile.Descendants("main")).FirstOrDefault()

		Dim IntervallElement As XElement = mainConfiguration.Descendants("Intervall").Descendants("Value").FirstOrDefault()
		If IsNothing(IntervallElement) Then
			Dim newNode As XElement = New XElement("Intervall", New XElement("Value", Intervall))
			mainConfiguration.Add(newNode)
			saveConfig = True

		Else
			Intervall = IntervallElement
		End If

		'Falls neue Standardwerte übergeben wurden, müssen diese gespeichert werden (bei neuinstallation)
		If saveConfig Then saveConfigFile()

		aMainConfig.Intervall = Intervall
		Return aMainConfig

	End Function

	Private Sub saveMainValues()

		configFile.Descendants("main").Descendants("Intervall").FirstOrDefault().Value = Intervall
		saveConfigFile()

	End Sub

	Private Function getFoldersConfiguration(aMainConfig As config) As config
		'https://stackoverflow.com/questions/752271/how-to-get-xml-node-from-xdocument

		Dim xmlFolderConfiguration As XElement = (From xml In configFile.Descendants("folders")).First
		Dim manyFolderConfigutations As New List(Of folderConfiguration)

		If xmlFolderConfiguration.Nodes().Count > 0 Then
			For Each aNode As XElement In xmlFolderConfiguration.Descendants("folderConfiguration")
				Dim aNewFolderConfiguration As New folderConfiguration
				aNewFolderConfiguration.inFolder = aNode.Descendants("inFolder").First.Value
				aNewFolderConfiguration.outFolder = aNode.Descendants("outFolder").First.Value
				manyFolderConfigutations.Add(aNewFolderConfiguration)
			Next
		End If
		aMainConfig.folderConfigurations = manyFolderConfigutations

		Return aMainConfig
	End Function


	Public Sub saveFolderConfiguration(newfolderConfiguration As folderConfiguration, oldFolderConfiguration As folderConfiguration)

		Dim xmlfolderConfiguration As XElement = (From xml In configFile.Descendants("folders").Descendants("folderConfiguration") Where xml.Element("inFolder").Value = oldFolderConfiguration.inFolder).First

		If Not IsNothing(xmlfolderConfiguration) Then 'Update Entry

			xmlfolderConfiguration.Descendants("inFolder").First.SetValue(newfolderConfiguration.inFolder)
			xmlfolderConfiguration.Descendants("outFolder").First.SetValue(newfolderConfiguration.outFolder)
		Else 'New Entry
			Dim folderConfiguration As XElement = (From xml In configFile.Descendants("folders")).First
			Dim newConfiguration As XElement = New XElement("folderConfiguration", New XElement("inFolder", newfolderConfiguration.inFolder))
			Dim outFolder As XElement = New XElement("outFolder", newfolderConfiguration.outFolder)
			newConfiguration.Add(outFolder)
			folderConfiguration.Add(newConfiguration)
		End If

		saveConfigFile()
		'getFoldersConfiguration()

	End Sub

	Public Sub deleteFolderConfiguration(aFolderConfiguration As folderConfiguration)


		Dim folderConfiguration As XElement = (From xml In configFile.Descendants("folders").Descendants("folderConfiguration") Where xml.Element("inFolder").Value = aFolderConfiguration.inFolder).First
		folderConfiguration.Remove()

		saveConfigFile()
		'getFoldersConfiguration()

	End Sub

	Public Sub saveConfigFile()
		configFile.Save(appPath & ConfigFileName)

	End Sub

End Class
