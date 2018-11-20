<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
	Inherits System.Windows.Forms.Form

	'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
	<System.Diagnostics.DebuggerNonUserCode()>
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		Try
			If disposing AndAlso components IsNot Nothing Then
				components.Dispose()
			End If
		Finally
			MyBase.Dispose(disposing)
		End Try
	End Sub

	'Wird vom Windows Form-Designer benötigt.
	Private components As System.ComponentModel.IContainer

	'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
	'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
	'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
	<System.Diagnostics.DebuggerStepThrough()>
	Private Sub InitializeComponent()
		Me.TextBoxIntervall = New System.Windows.Forms.TextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.ButtonStart = New System.Windows.Forms.Button()
		Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
		Me.ListBoxFolders = New System.Windows.Forms.ListBox()
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.CheckBoxActive = New System.Windows.Forms.CheckBox()
		Me.ButtonDeleteDirectory = New System.Windows.Forms.Button()
		Me.ButtonNewDirectory = New System.Windows.Forms.Button()
		Me.ConfigurationID = New System.Windows.Forms.Label()
		Me.ButtonSaveFolderSettings = New System.Windows.Forms.Button()
		Me.ButtonSelectOutFolder = New System.Windows.Forms.Button()
		Me.ButtonSelectInputFolder = New System.Windows.Forms.Button()
		Me.TextBoxInFolder = New System.Windows.Forms.TextBox()
		Me.TextBoxOutFolder = New System.Windows.Forms.TextBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.LabelOut = New System.Windows.Forms.Label()
		Me.LabelIn = New System.Windows.Forms.Label()
		Me.ButtonSaveMainSettings = New System.Windows.Forms.Button()
		Me.LabelWatchedFolders = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.TextBoxFileExtensions = New System.Windows.Forms.TextBox()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.TextBoxProgramPrefixes = New System.Windows.Forms.TextBox()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.TextBoxPSFiledNames = New System.Windows.Forms.TextBox()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.Label8 = New System.Windows.Forms.Label()
		Me.Panel1.SuspendLayout()
		Me.SuspendLayout()
		'
		'TextBoxIntervall
		'
		Me.TextBoxIntervall.Location = New System.Drawing.Point(216, 131)
		Me.TextBoxIntervall.Name = "TextBoxIntervall"
		Me.TextBoxIntervall.Size = New System.Drawing.Size(64, 20)
		Me.TextBoxIntervall.TabIndex = 0
		Me.TextBoxIntervall.Visible = False
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(35, 131)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(154, 13)
		Me.Label1.TabIndex = 1
		Me.Label1.Text = "Überprungsinterval (Sekunden)"
		Me.Label1.Visible = False
		'
		'ButtonStart
		'
		Me.ButtonStart.Location = New System.Drawing.Point(674, 393)
		Me.ButtonStart.Name = "ButtonStart"
		Me.ButtonStart.Size = New System.Drawing.Size(75, 23)
		Me.ButtonStart.TabIndex = 2
		Me.ButtonStart.Text = "Start"
		Me.ButtonStart.UseVisualStyleBackColor = True
		'
		'OpenFileDialog1
		'
		Me.OpenFileDialog1.FileName = "OpenFileDialog1"
		'
		'ListBoxFolders
		'
		Me.ListBoxFolders.FormattingEnabled = True
		Me.ListBoxFolders.Location = New System.Drawing.Point(3, 3)
		Me.ListBoxFolders.Name = "ListBoxFolders"
		Me.ListBoxFolders.Size = New System.Drawing.Size(221, 121)
		Me.ListBoxFolders.TabIndex = 7
		'
		'Panel1
		'
		Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Panel1.Controls.Add(Me.CheckBoxActive)
		Me.Panel1.Controls.Add(Me.ButtonDeleteDirectory)
		Me.Panel1.Controls.Add(Me.ButtonNewDirectory)
		Me.Panel1.Controls.Add(Me.ConfigurationID)
		Me.Panel1.Controls.Add(Me.ButtonSaveFolderSettings)
		Me.Panel1.Controls.Add(Me.ButtonSelectOutFolder)
		Me.Panel1.Controls.Add(Me.ButtonSelectInputFolder)
		Me.Panel1.Controls.Add(Me.TextBoxInFolder)
		Me.Panel1.Controls.Add(Me.TextBoxOutFolder)
		Me.Panel1.Controls.Add(Me.Label2)
		Me.Panel1.Controls.Add(Me.LabelOut)
		Me.Panel1.Controls.Add(Me.LabelIn)
		Me.Panel1.Controls.Add(Me.ListBoxFolders)
		Me.Panel1.Location = New System.Drawing.Point(16, 172)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(737, 136)
		Me.Panel1.TabIndex = 14
		'
		'CheckBoxActive
		'
		Me.CheckBoxActive.AutoSize = True
		Me.CheckBoxActive.Checked = True
		Me.CheckBoxActive.CheckState = System.Windows.Forms.CheckState.Checked
		Me.CheckBoxActive.Location = New System.Drawing.Point(316, 103)
		Me.CheckBoxActive.Name = "CheckBoxActive"
		Me.CheckBoxActive.Size = New System.Drawing.Size(50, 17)
		Me.CheckBoxActive.TabIndex = 25
		Me.CheckBoxActive.Text = "Aktiv"
		Me.CheckBoxActive.UseVisualStyleBackColor = True
		'
		'ButtonDeleteDirectory
		'
		Me.ButtonDeleteDirectory.Location = New System.Drawing.Point(495, 103)
		Me.ButtonDeleteDirectory.Name = "ButtonDeleteDirectory"
		Me.ButtonDeleteDirectory.Size = New System.Drawing.Size(75, 23)
		Me.ButtonDeleteDirectory.TabIndex = 24
		Me.ButtonDeleteDirectory.Text = "löschen"
		Me.ButtonDeleteDirectory.UseVisualStyleBackColor = True
		'
		'ButtonNewDirectory
		'
		Me.ButtonNewDirectory.Location = New System.Drawing.Point(576, 5)
		Me.ButtonNewDirectory.Name = "ButtonNewDirectory"
		Me.ButtonNewDirectory.Size = New System.Drawing.Size(75, 23)
		Me.ButtonNewDirectory.TabIndex = 23
		Me.ButtonNewDirectory.Text = "neu"
		Me.ButtonNewDirectory.UseVisualStyleBackColor = True
		'
		'ConfigurationID
		'
		Me.ConfigurationID.AutoSize = True
		Me.ConfigurationID.Location = New System.Drawing.Point(681, 34)
		Me.ConfigurationID.Name = "ConfigurationID"
		Me.ConfigurationID.Size = New System.Drawing.Size(39, 13)
		Me.ConfigurationID.TabIndex = 22
		Me.ConfigurationID.Text = "Label3"
		'
		'ButtonSaveFolderSettings
		'
		Me.ButtonSaveFolderSettings.Location = New System.Drawing.Point(576, 103)
		Me.ButtonSaveFolderSettings.Name = "ButtonSaveFolderSettings"
		Me.ButtonSaveFolderSettings.Size = New System.Drawing.Size(75, 23)
		Me.ButtonSaveFolderSettings.TabIndex = 21
		Me.ButtonSaveFolderSettings.Text = "speichern"
		Me.ButtonSaveFolderSettings.UseVisualStyleBackColor = True
		'
		'ButtonSelectOutFolder
		'
		Me.ButtonSelectOutFolder.Location = New System.Drawing.Point(626, 69)
		Me.ButtonSelectOutFolder.Name = "ButtonSelectOutFolder"
		Me.ButtonSelectOutFolder.Size = New System.Drawing.Size(25, 23)
		Me.ButtonSelectOutFolder.TabIndex = 20
		Me.ButtonSelectOutFolder.Text = "..."
		Me.ButtonSelectOutFolder.UseVisualStyleBackColor = True
		'
		'ButtonSelectInputFolder
		'
		Me.ButtonSelectInputFolder.Location = New System.Drawing.Point(626, 32)
		Me.ButtonSelectInputFolder.Name = "ButtonSelectInputFolder"
		Me.ButtonSelectInputFolder.Size = New System.Drawing.Size(25, 23)
		Me.ButtonSelectInputFolder.TabIndex = 19
		Me.ButtonSelectInputFolder.Text = "..."
		Me.ButtonSelectInputFolder.UseVisualStyleBackColor = True
		'
		'TextBoxInFolder
		'
		Me.TextBoxInFolder.Location = New System.Drawing.Point(316, 34)
		Me.TextBoxInFolder.Name = "TextBoxInFolder"
		Me.TextBoxInFolder.Size = New System.Drawing.Size(304, 20)
		Me.TextBoxInFolder.TabIndex = 18
		'
		'TextBoxOutFolder
		'
		Me.TextBoxOutFolder.Location = New System.Drawing.Point(316, 71)
		Me.TextBoxOutFolder.Name = "TextBoxOutFolder"
		Me.TextBoxOutFolder.Size = New System.Drawing.Size(304, 20)
		Me.TextBoxOutFolder.TabIndex = 17
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(240, 103)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(0, 13)
		Me.Label2.TabIndex = 16
		'
		'LabelOut
		'
		Me.LabelOut.AutoSize = True
		Me.LabelOut.Location = New System.Drawing.Point(240, 74)
		Me.LabelOut.Name = "LabelOut"
		Me.LabelOut.Size = New System.Drawing.Size(59, 13)
		Me.LabelOut.TabIndex = 15
		Me.LabelOut.Text = "Out-Ordner"
		'
		'LabelIn
		'
		Me.LabelIn.AutoSize = True
		Me.LabelIn.Location = New System.Drawing.Point(240, 37)
		Me.LabelIn.Name = "LabelIn"
		Me.LabelIn.Size = New System.Drawing.Size(51, 13)
		Me.LabelIn.TabIndex = 14
		Me.LabelIn.Text = "In-Ordner"
		'
		'ButtonSaveMainSettings
		'
		Me.ButtonSaveMainSettings.Location = New System.Drawing.Point(678, 131)
		Me.ButtonSaveMainSettings.Name = "ButtonSaveMainSettings"
		Me.ButtonSaveMainSettings.Size = New System.Drawing.Size(75, 23)
		Me.ButtonSaveMainSettings.TabIndex = 15
		Me.ButtonSaveMainSettings.Text = "speichern"
		Me.ButtonSaveMainSettings.UseVisualStyleBackColor = True
		'
		'LabelWatchedFolders
		'
		Me.LabelWatchedFolders.AutoSize = True
		Me.LabelWatchedFolders.ForeColor = System.Drawing.Color.Red
		Me.LabelWatchedFolders.Location = New System.Drawing.Point(598, 373)
		Me.LabelWatchedFolders.Name = "LabelWatchedFolders"
		Me.LabelWatchedFolders.Size = New System.Drawing.Size(39, 13)
		Me.LabelWatchedFolders.TabIndex = 17
		Me.LabelWatchedFolders.Text = "Label3"
		Me.LabelWatchedFolders.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(12, 35)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(148, 13)
		Me.Label3.TabIndex = 19
		Me.Label3.Text = "Dateiendungen (; als Trenner)"
		'
		'TextBoxFileExtensions
		'
		Me.TextBoxFileExtensions.Location = New System.Drawing.Point(216, 32)
		Me.TextBoxFileExtensions.Name = "TextBoxFileExtensions"
		Me.TextBoxFileExtensions.Size = New System.Drawing.Size(537, 20)
		Me.TextBoxFileExtensions.TabIndex = 18
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Location = New System.Drawing.Point(12, 64)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(195, 13)
		Me.Label4.TabIndex = 20
		Me.Label4.Text = "Prefixes von Programmen (; als Trenner)"
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label5.Location = New System.Drawing.Point(12, 16)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(140, 13)
		Me.Label5.TabIndex = 21
		Me.Label5.Text = "Löschen in Dateinamen"
		'
		'TextBoxProgramPrefixes
		'
		Me.TextBoxProgramPrefixes.Location = New System.Drawing.Point(216, 61)
		Me.TextBoxProgramPrefixes.Name = "TextBoxProgramPrefixes"
		Me.TextBoxProgramPrefixes.Size = New System.Drawing.Size(537, 20)
		Me.TextBoxProgramPrefixes.TabIndex = 22
		'
		'Label6
		'
		Me.Label6.AutoSize = True
		Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label6.Location = New System.Drawing.Point(13, 88)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(307, 13)
		Me.Label6.TabIndex = 23
		Me.Label6.Text = "Felder mit Dateinamen in der PS-Datei (; als Trenner)"
		'
		'TextBoxPSFiledNames
		'
		Me.TextBoxPSFiledNames.Location = New System.Drawing.Point(16, 104)
		Me.TextBoxPSFiledNames.Name = "TextBoxPSFiledNames"
		Me.TextBoxPSFiledNames.Size = New System.Drawing.Size(737, 20)
		Me.TextBoxPSFiledNames.TabIndex = 24
		'
		'Label7
		'
		Me.Label7.AutoSize = True
		Me.Label7.Location = New System.Drawing.Point(326, 88)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(95, 13)
		Me.Label7.TabIndex = 25
		Me.Label7.Text = "job-name;file-name"
		Me.Label7.Visible = False
		'
		'Label8
		'
		Me.Label8.AutoSize = True
		Me.Label8.Location = New System.Drawing.Point(17, 409)
		Me.Label8.Name = "Label8"
		Me.Label8.Size = New System.Drawing.Size(148, 13)
		Me.Label8.TabIndex = 26
		Me.Label8.Text = "Version 0.1 - 20.11.2018 - ND"
		'
		'Form1
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(781, 431)
		Me.Controls.Add(Me.Label8)
		Me.Controls.Add(Me.Label7)
		Me.Controls.Add(Me.TextBoxPSFiledNames)
		Me.Controls.Add(Me.Label6)
		Me.Controls.Add(Me.TextBoxProgramPrefixes)
		Me.Controls.Add(Me.Label5)
		Me.Controls.Add(Me.Label4)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.TextBoxFileExtensions)
		Me.Controls.Add(Me.LabelWatchedFolders)
		Me.Controls.Add(Me.ButtonSaveMainSettings)
		Me.Controls.Add(Me.ButtonStart)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.TextBoxIntervall)
		Me.Controls.Add(Me.Panel1)
		Me.Name = "Form1"
		Me.Text = "DruckjobsMover"
		Me.Panel1.ResumeLayout(False)
		Me.Panel1.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents TextBoxIntervall As TextBox
	Friend WithEvents Label1 As Label
	Friend WithEvents ButtonStart As Button
	Friend WithEvents OpenFileDialog1 As OpenFileDialog
	Friend WithEvents ListBoxFolders As ListBox
	Friend WithEvents Panel1 As Panel
	Friend WithEvents ButtonSelectOutFolder As Button
	Friend WithEvents ButtonSelectInputFolder As Button
	Friend WithEvents TextBoxInFolder As TextBox
	Friend WithEvents TextBoxOutFolder As TextBox
	Friend WithEvents Label2 As Label
	Friend WithEvents LabelOut As Label
	Friend WithEvents LabelIn As Label
	Friend WithEvents ButtonSaveMainSettings As Button
	Friend WithEvents ButtonSaveFolderSettings As Button
	Friend WithEvents ConfigurationID As Label
	Friend WithEvents ButtonDeleteDirectory As Button
	Friend WithEvents ButtonNewDirectory As Button
	Friend WithEvents LabelWatchedFolders As Label
	Friend WithEvents CheckBoxActive As CheckBox
	Friend WithEvents Label3 As Label
	Friend WithEvents TextBoxFileExtensions As TextBox
	Friend WithEvents Label4 As Label
	Friend WithEvents Label5 As Label
	Friend WithEvents TextBoxProgramPrefixes As TextBox
	Friend WithEvents Label6 As Label
	Friend WithEvents TextBoxPSFiledNames As TextBox
	Friend WithEvents Label7 As Label
	Friend WithEvents Label8 As Label
End Class
