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
		Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
		Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
		Me.ListBoxFolders = New System.Windows.Forms.ListBox()
		Me.Panel1 = New System.Windows.Forms.Panel()
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
		Me.Panel1.SuspendLayout()
		Me.SuspendLayout()
		'
		'TextBoxIntervall
		'
		Me.TextBoxIntervall.Location = New System.Drawing.Point(173, 28)
		Me.TextBoxIntervall.Name = "TextBoxIntervall"
		Me.TextBoxIntervall.Size = New System.Drawing.Size(64, 20)
		Me.TextBoxIntervall.TabIndex = 0
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(13, 31)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(154, 13)
		Me.Label1.TabIndex = 1
		Me.Label1.Text = "Überprungsinterval (Sekunden)"
		'
		'ButtonStart
		'
		Me.ButtonStart.Location = New System.Drawing.Point(678, 396)
		Me.ButtonStart.Name = "ButtonStart"
		Me.ButtonStart.Size = New System.Drawing.Size(75, 23)
		Me.ButtonStart.TabIndex = 2
		Me.ButtonStart.Text = "Start"
		Me.ButtonStart.UseVisualStyleBackColor = True
		'
		'LinkLabel1
		'
		Me.LinkLabel1.AutoSize = True
		Me.LinkLabel1.Location = New System.Drawing.Point(47, 369)
		Me.LinkLabel1.Name = "LinkLabel1"
		Me.LinkLabel1.Size = New System.Drawing.Size(439, 13)
		Me.LinkLabel1.TabIndex = 5
		Me.LinkLabel1.TabStop = True
		Me.LinkLabel1.Text = "http://www.marcusnyberg.com/2010/01/12/how-to-create-a-printerqueu-with-net-and-w" &
		"mi/"
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
		Me.ListBoxFolders.Size = New System.Drawing.Size(221, 251)
		Me.ListBoxFolders.TabIndex = 7
		'
		'Panel1
		'
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
		Me.Panel1.Location = New System.Drawing.Point(16, 71)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(737, 295)
		Me.Panel1.TabIndex = 14
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
		Me.ButtonNewDirectory.Location = New System.Drawing.Point(576, -1)
		Me.ButtonNewDirectory.Name = "ButtonNewDirectory"
		Me.ButtonNewDirectory.Size = New System.Drawing.Size(75, 23)
		Me.ButtonNewDirectory.TabIndex = 23
		Me.ButtonNewDirectory.Text = "neu"
		Me.ButtonNewDirectory.UseVisualStyleBackColor = True
		'
		'ConfigurationID
		'
		Me.ConfigurationID.AutoSize = True
		Me.ConfigurationID.Location = New System.Drawing.Point(681, 28)
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
		Me.ButtonSelectOutFolder.Location = New System.Drawing.Point(626, 63)
		Me.ButtonSelectOutFolder.Name = "ButtonSelectOutFolder"
		Me.ButtonSelectOutFolder.Size = New System.Drawing.Size(25, 23)
		Me.ButtonSelectOutFolder.TabIndex = 20
		Me.ButtonSelectOutFolder.Text = "..."
		Me.ButtonSelectOutFolder.UseVisualStyleBackColor = True
		'
		'ButtonSelectInputFolder
		'
		Me.ButtonSelectInputFolder.Location = New System.Drawing.Point(626, 26)
		Me.ButtonSelectInputFolder.Name = "ButtonSelectInputFolder"
		Me.ButtonSelectInputFolder.Size = New System.Drawing.Size(25, 23)
		Me.ButtonSelectInputFolder.TabIndex = 19
		Me.ButtonSelectInputFolder.Text = "..."
		Me.ButtonSelectInputFolder.UseVisualStyleBackColor = True
		'
		'TextBoxInFolder
		'
		Me.TextBoxInFolder.Location = New System.Drawing.Point(316, 28)
		Me.TextBoxInFolder.Name = "TextBoxInFolder"
		Me.TextBoxInFolder.Size = New System.Drawing.Size(304, 20)
		Me.TextBoxInFolder.TabIndex = 18
		'
		'TextBoxOutFolder
		'
		Me.TextBoxOutFolder.Location = New System.Drawing.Point(316, 65)
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
		Me.LabelOut.Location = New System.Drawing.Point(240, 68)
		Me.LabelOut.Name = "LabelOut"
		Me.LabelOut.Size = New System.Drawing.Size(59, 13)
		Me.LabelOut.TabIndex = 15
		Me.LabelOut.Text = "Out-Ordner"
		'
		'LabelIn
		'
		Me.LabelIn.AutoSize = True
		Me.LabelIn.Location = New System.Drawing.Point(240, 31)
		Me.LabelIn.Name = "LabelIn"
		Me.LabelIn.Size = New System.Drawing.Size(51, 13)
		Me.LabelIn.TabIndex = 14
		Me.LabelIn.Text = "In-Ordner"
		'
		'ButtonSaveMainSettings
		'
		Me.ButtonSaveMainSettings.Location = New System.Drawing.Point(256, 26)
		Me.ButtonSaveMainSettings.Name = "ButtonSaveMainSettings"
		Me.ButtonSaveMainSettings.Size = New System.Drawing.Size(75, 23)
		Me.ButtonSaveMainSettings.TabIndex = 15
		Me.ButtonSaveMainSettings.Text = "speichern"
		Me.ButtonSaveMainSettings.UseVisualStyleBackColor = True
		'
		'Form1
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(781, 431)
		Me.Controls.Add(Me.ButtonSaveMainSettings)
		Me.Controls.Add(Me.LinkLabel1)
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
	Friend WithEvents LinkLabel1 As LinkLabel
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
End Class
