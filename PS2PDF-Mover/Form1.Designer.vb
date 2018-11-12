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
		Me.ListBox1 = New System.Windows.Forms.ListBox()
		Me.LabelIn = New System.Windows.Forms.Label()
		Me.LabelOut = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.TextBoxDirectoryOutput = New System.Windows.Forms.TextBox()
		Me.TextBoxDirectoryInput = New System.Windows.Forms.TextBox()
		Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
		Me.ButtonSelectInputFolder = New System.Windows.Forms.Button()
		Me.ButtonSelectOutFolder = New System.Windows.Forms.Button()
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
		Me.ButtonStart.Location = New System.Drawing.Point(383, 31)
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
		'ListBox1
		'
		Me.ListBox1.FormattingEnabled = True
		Me.ListBox1.Location = New System.Drawing.Point(16, 93)
		Me.ListBox1.Name = "ListBox1"
		Me.ListBox1.Size = New System.Drawing.Size(221, 251)
		Me.ListBox1.TabIndex = 6
		'
		'LabelIn
		'
		Me.LabelIn.AutoSize = True
		Me.LabelIn.Location = New System.Drawing.Point(282, 93)
		Me.LabelIn.Name = "LabelIn"
		Me.LabelIn.Size = New System.Drawing.Size(51, 13)
		Me.LabelIn.TabIndex = 7
		Me.LabelIn.Text = "In-Ordner"
		'
		'LabelOut
		'
		Me.LabelOut.AutoSize = True
		Me.LabelOut.Location = New System.Drawing.Point(282, 130)
		Me.LabelOut.Name = "LabelOut"
		Me.LabelOut.Size = New System.Drawing.Size(59, 13)
		Me.LabelOut.TabIndex = 8
		Me.LabelOut.Text = "Out-Ordner"
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(282, 165)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(0, 13)
		Me.Label2.TabIndex = 9
		'
		'TextBoxDirectoryOutput
		'
		Me.TextBoxDirectoryOutput.Location = New System.Drawing.Point(358, 127)
		Me.TextBoxDirectoryOutput.Name = "TextBoxDirectoryOutput"
		Me.TextBoxDirectoryOutput.Size = New System.Drawing.Size(304, 20)
		Me.TextBoxDirectoryOutput.TabIndex = 10
		'
		'TextBoxDirectoryInput
		'
		Me.TextBoxDirectoryInput.Location = New System.Drawing.Point(358, 90)
		Me.TextBoxDirectoryInput.Name = "TextBoxDirectoryInput"
		Me.TextBoxDirectoryInput.Size = New System.Drawing.Size(304, 20)
		Me.TextBoxDirectoryInput.TabIndex = 11
		'
		'OpenFileDialog1
		'
		Me.OpenFileDialog1.FileName = "OpenFileDialog1"
		'
		'ButtonSelectInputFolder
		'
		Me.ButtonSelectInputFolder.Location = New System.Drawing.Point(668, 88)
		Me.ButtonSelectInputFolder.Name = "ButtonSelectInputFolder"
		Me.ButtonSelectInputFolder.Size = New System.Drawing.Size(25, 23)
		Me.ButtonSelectInputFolder.TabIndex = 12
		Me.ButtonSelectInputFolder.Text = "..."
		Me.ButtonSelectInputFolder.UseVisualStyleBackColor = True
		'
		'ButtonSelectOutFolder
		'
		Me.ButtonSelectOutFolder.Location = New System.Drawing.Point(668, 125)
		Me.ButtonSelectOutFolder.Name = "ButtonSelectOutFolder"
		Me.ButtonSelectOutFolder.Size = New System.Drawing.Size(25, 23)
		Me.ButtonSelectOutFolder.TabIndex = 13
		Me.ButtonSelectOutFolder.Text = "..."
		Me.ButtonSelectOutFolder.UseVisualStyleBackColor = True
		'
		'Form1
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(781, 431)
		Me.Controls.Add(Me.ButtonSelectOutFolder)
		Me.Controls.Add(Me.ButtonSelectInputFolder)
		Me.Controls.Add(Me.TextBoxDirectoryInput)
		Me.Controls.Add(Me.TextBoxDirectoryOutput)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.LabelOut)
		Me.Controls.Add(Me.LabelIn)
		Me.Controls.Add(Me.ListBox1)
		Me.Controls.Add(Me.LinkLabel1)
		Me.Controls.Add(Me.ButtonStart)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.TextBoxIntervall)
		Me.Name = "Form1"
		Me.Text = "DruckjobsMover"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents TextBoxIntervall As TextBox
	Friend WithEvents Label1 As Label
	Friend WithEvents ButtonStart As Button
	Friend WithEvents LinkLabel1 As LinkLabel
	Friend WithEvents ListBox1 As ListBox
	Friend WithEvents LabelIn As Label
	Friend WithEvents LabelOut As Label
	Friend WithEvents Label2 As Label
	Friend WithEvents TextBoxDirectoryOutput As TextBox
	Friend WithEvents TextBoxDirectoryInput As TextBox
	Friend WithEvents OpenFileDialog1 As OpenFileDialog
	Friend WithEvents ButtonSelectInputFolder As Button
	Friend WithEvents ButtonSelectOutFolder As Button
End Class
