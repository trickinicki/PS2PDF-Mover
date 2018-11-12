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
		'Form1
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(781, 431)
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
End Class
