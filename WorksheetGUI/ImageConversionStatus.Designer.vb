<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImageConversionStatus
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
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
		Me.components = New System.ComponentModel.Container()
		Me.ProgressBar = New System.Windows.Forms.ProgressBar()
		Me.CurrentStatus = New System.Windows.Forms.Label()
		Me.CancelButton = New System.Windows.Forms.Button()
		Me.StatusTimer = New System.Windows.Forms.Timer(Me.components)
		Me.CurrentCell = New System.Windows.Forms.Label()
		Me.ImageDisplayLeft = New System.Windows.Forms.PictureBox()
		Me.ImageDisplayRight = New System.Windows.Forms.PictureBox()
		CType(Me.ImageDisplayLeft, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.ImageDisplayRight, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'ProgressBar
		'
		Me.ProgressBar.ForeColor = System.Drawing.Color.DeepSkyBlue
		Me.ProgressBar.Location = New System.Drawing.Point(12, 12)
		Me.ProgressBar.MarqueeAnimationSpeed = 50
		Me.ProgressBar.Name = "ProgressBar"
		Me.ProgressBar.Size = New System.Drawing.Size(619, 23)
		Me.ProgressBar.Step = 5
		Me.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee
		Me.ProgressBar.TabIndex = 0
		'
		'CurrentStatus
		'
		Me.CurrentStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.CurrentStatus.Location = New System.Drawing.Point(12, 38)
		Me.CurrentStatus.Name = "CurrentStatus"
		Me.CurrentStatus.Size = New System.Drawing.Size(619, 66)
		Me.CurrentStatus.TabIndex = 1
		Me.CurrentStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'CancelButton
		'
		Me.CancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.CancelButton.Location = New System.Drawing.Point(556, 451)
		Me.CancelButton.Name = "CancelButton"
		Me.CancelButton.Size = New System.Drawing.Size(75, 23)
		Me.CancelButton.TabIndex = 2
		Me.CancelButton.Text = "Cancel"
		Me.CancelButton.UseVisualStyleBackColor = True
		'
		'StatusTimer
		'
		Me.StatusTimer.Interval = 1000
		'
		'CurrentCell
		'
		Me.CurrentCell.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.CurrentCell.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.CurrentCell.Location = New System.Drawing.Point(12, 451)
		Me.CurrentCell.Name = "CurrentCell"
		Me.CurrentCell.Size = New System.Drawing.Size(538, 23)
		Me.CurrentCell.TabIndex = 3
		Me.CurrentCell.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'ImageDisplayLeft
		'
		Me.ImageDisplayLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
		Me.ImageDisplayLeft.Location = New System.Drawing.Point(12, 107)
		Me.ImageDisplayLeft.Name = "ImageDisplayLeft"
		Me.ImageDisplayLeft.Size = New System.Drawing.Size(295, 341)
		Me.ImageDisplayLeft.TabIndex = 4
		Me.ImageDisplayLeft.TabStop = False
		'
		'ImageDisplayRight
		'
		Me.ImageDisplayRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
		Me.ImageDisplayRight.Location = New System.Drawing.Point(336, 107)
		Me.ImageDisplayRight.Name = "ImageDisplayRight"
		Me.ImageDisplayRight.Size = New System.Drawing.Size(295, 341)
		Me.ImageDisplayRight.TabIndex = 5
		Me.ImageDisplayRight.TabStop = False
		'
		'ImageConversionStatus
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(643, 486)
		Me.Controls.Add(Me.ImageDisplayRight)
		Me.Controls.Add(Me.ImageDisplayLeft)
		Me.Controls.Add(Me.CurrentCell)
		Me.Controls.Add(Me.CancelButton)
		Me.Controls.Add(Me.CurrentStatus)
		Me.Controls.Add(Me.ProgressBar)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "ImageConversionStatus"
		Me.ShowIcon = False
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Creating worksheet from image..."
		CType(Me.ImageDisplayLeft, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.ImageDisplayRight, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents ProgressBar As ProgressBar
	Friend WithEvents CurrentStatus As Label
	Private WithEvents CancelButton As Button
	Friend WithEvents StatusTimer As Timer
	Friend WithEvents CurrentCell As Label
	Friend WithEvents ImageDisplayLeft As PictureBox
	Friend WithEvents ImageDisplayRight As PictureBox
End Class
