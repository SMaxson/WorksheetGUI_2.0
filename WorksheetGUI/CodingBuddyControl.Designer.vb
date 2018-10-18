<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CodingBuddyControl
	Inherits System.Windows.Forms.UserControl

	'UserControl overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> _
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		Try
			If disposing AndAlso components IsNot Nothing Then
				components.Dispose()
			End If
		Finally
			MyBase.Dispose(disposing)
		End Try
	End Sub

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
		Me.codingBuddyInputPanel = New System.Windows.Forms.Panel()
		Me.mumboNo = New System.Windows.Forms.Button()
		Me.mumboYes = New System.Windows.Forms.Button()
		Me.speechOutput = New System.Windows.Forms.Label()
		Me.talkingHeadBox = New System.Windows.Forms.PictureBox()
		Me.speechCompleteIndicator = New System.Windows.Forms.Label()
		Me.codingBuddyInputPanel.SuspendLayout()
		CType(Me.talkingHeadBox, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'codingBuddyInputPanel
		'
		Me.codingBuddyInputPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.codingBuddyInputPanel.BackColor = System.Drawing.Color.Gray
		Me.codingBuddyInputPanel.Controls.Add(Me.mumboNo)
		Me.codingBuddyInputPanel.Controls.Add(Me.mumboYes)
		Me.codingBuddyInputPanel.Location = New System.Drawing.Point(677, 3)
		Me.codingBuddyInputPanel.Name = "codingBuddyInputPanel"
		Me.codingBuddyInputPanel.Size = New System.Drawing.Size(70, 84)
		Me.codingBuddyInputPanel.TabIndex = 3
		Me.codingBuddyInputPanel.Visible = False
		'
		'mumboNo
		'
		Me.mumboNo.BackColor = System.Drawing.Color.OrangeRed
		Me.mumboNo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
		Me.mumboNo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Firebrick
		Me.mumboNo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon
		Me.mumboNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.mumboNo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.mumboNo.Location = New System.Drawing.Point(0, 43)
		Me.mumboNo.Name = "mumboNo"
		Me.mumboNo.Size = New System.Drawing.Size(70, 32)
		Me.mumboNo.TabIndex = 1
		Me.mumboNo.Text = "No"
		Me.mumboNo.UseMnemonic = False
		Me.mumboNo.UseVisualStyleBackColor = False
		'
		'mumboYes
		'
		Me.mumboYes.BackColor = System.Drawing.Color.LimeGreen
		Me.mumboYes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
		Me.mumboYes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green
		Me.mumboYes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGreen
		Me.mumboYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.mumboYes.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.mumboYes.Location = New System.Drawing.Point(0, 5)
		Me.mumboYes.Name = "mumboYes"
		Me.mumboYes.Size = New System.Drawing.Size(70, 32)
		Me.mumboYes.TabIndex = 0
		Me.mumboYes.Text = "Yes"
		Me.mumboYes.UseMnemonic = False
		Me.mumboYes.UseVisualStyleBackColor = False
		'
		'speechOutput
		'
		Me.speechOutput.AutoSize = True
		Me.speechOutput.BackColor = System.Drawing.Color.Gray
		Me.speechOutput.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.speechOutput.ForeColor = System.Drawing.Color.White
		Me.speechOutput.Location = New System.Drawing.Point(87, 3)
		Me.speechOutput.MaximumSize = New System.Drawing.Size(626, 0)
		Me.speechOutput.MinimumSize = New System.Drawing.Size(626, 80)
		Me.speechOutput.Name = "speechOutput"
		Me.speechOutput.Size = New System.Drawing.Size(626, 80)
		Me.speechOutput.TabIndex = 0
		'
		'talkingHeadBox
		'
		Me.talkingHeadBox.BackColor = System.Drawing.Color.Gray
		Me.talkingHeadBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.talkingHeadBox.Dock = System.Windows.Forms.DockStyle.Left
		Me.talkingHeadBox.Location = New System.Drawing.Point(0, 0)
		Me.talkingHeadBox.MaximumSize = New System.Drawing.Size(84, 84)
		Me.talkingHeadBox.Name = "talkingHeadBox"
		Me.talkingHeadBox.Size = New System.Drawing.Size(84, 84)
		Me.talkingHeadBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.talkingHeadBox.TabIndex = 2
		Me.talkingHeadBox.TabStop = False
		'
		'speechCompleteIndicator
		'
		Me.speechCompleteIndicator.BackColor = System.Drawing.Color.Gray
		Me.speechCompleteIndicator.Cursor = System.Windows.Forms.Cursors.Hand
		Me.speechCompleteIndicator.Font = New System.Drawing.Font("Segoe UI Black", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.speechCompleteIndicator.ForeColor = System.Drawing.Color.White
		Me.speechCompleteIndicator.Location = New System.Drawing.Point(719, 52)
		Me.speechCompleteIndicator.Name = "speechCompleteIndicator"
		Me.speechCompleteIndicator.Size = New System.Drawing.Size(28, 32)
		Me.speechCompleteIndicator.TabIndex = 1
		Me.speechCompleteIndicator.Text = "✓"
		Me.speechCompleteIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.speechCompleteIndicator.Visible = False
		'
		'CodingBuddyControl
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.AutoSize = True
		Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.BackColor = System.Drawing.Color.Gray
		Me.Controls.Add(Me.codingBuddyInputPanel)
		Me.Controls.Add(Me.talkingHeadBox)
		Me.Controls.Add(Me.speechOutput)
		Me.Controls.Add(Me.speechCompleteIndicator)
		Me.MaximumSize = New System.Drawing.Size(880, 180)
		Me.MinimumSize = New System.Drawing.Size(750, 84)
		Me.Name = "CodingBuddyControl"
		Me.Size = New System.Drawing.Size(750, 90)
		Me.codingBuddyInputPanel.ResumeLayout(False)
		CType(Me.talkingHeadBox, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents codingBuddyInputPanel As Panel
	Friend WithEvents mumboNo As Button
	Friend WithEvents mumboYes As Button
	Friend WithEvents speechOutput As Label
	Friend WithEvents talkingHeadBox As PictureBox
	Friend WithEvents speechCompleteIndicator As Label
End Class
