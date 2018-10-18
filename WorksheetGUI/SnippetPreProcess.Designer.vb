<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SnippetPreProcess
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SnippetPreProcess))
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.mapPoint4 = New System.Windows.Forms.Panel()
		Me.mapPoint3 = New System.Windows.Forms.Panel()
		Me.mapPoint2 = New System.Windows.Forms.Panel()
		Me.mapPoint1 = New System.Windows.Forms.Panel()
		Me.SnippetImage = New System.Windows.Forms.PictureBox()
		Me.RotationSlider = New System.Windows.Forms.TrackBar()
		Me.Rotation = New System.Windows.Forms.GroupBox()
		Me.RotationUpDown = New System.Windows.Forms.NumericUpDown()
		Me.Zoom = New System.Windows.Forms.GroupBox()
		Me.ZoomUpDown = New System.Windows.Forms.NumericUpDown()
		Me.ZoomSlider = New System.Windows.Forms.TrackBar()
		Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
		Me.PreviewImage = New System.Windows.Forms.PictureBox()
		Me.Panel1.SuspendLayout()
		CType(Me.SnippetImage, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.RotationSlider, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Rotation.SuspendLayout()
		CType(Me.RotationUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Zoom.SuspendLayout()
		CType(Me.ZoomUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.ZoomSlider, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SplitContainer1.Panel1.SuspendLayout()
		Me.SplitContainer1.Panel2.SuspendLayout()
		Me.SplitContainer1.SuspendLayout()
		CType(Me.PreviewImage, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.mapPoint4)
		Me.Panel1.Controls.Add(Me.mapPoint3)
		Me.Panel1.Controls.Add(Me.mapPoint2)
		Me.Panel1.Controls.Add(Me.mapPoint1)
		Me.Panel1.Controls.Add(Me.SnippetImage)
		Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Panel1.Location = New System.Drawing.Point(0, 0)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(593, 707)
		Me.Panel1.TabIndex = 0
		'
		'mapPoint4
		'
		Me.mapPoint4.BackColor = System.Drawing.SystemColors.ActiveCaptionText
		Me.mapPoint4.Cursor = System.Windows.Forms.Cursors.SizeAll
		Me.mapPoint4.Location = New System.Drawing.Point(351, 395)
		Me.mapPoint4.Name = "mapPoint4"
		Me.mapPoint4.Size = New System.Drawing.Size(5, 5)
		Me.mapPoint4.TabIndex = 2
		'
		'mapPoint3
		'
		Me.mapPoint3.BackColor = System.Drawing.SystemColors.ActiveCaptionText
		Me.mapPoint3.Cursor = System.Windows.Forms.Cursors.SizeAll
		Me.mapPoint3.Location = New System.Drawing.Point(207, 395)
		Me.mapPoint3.Name = "mapPoint3"
		Me.mapPoint3.Size = New System.Drawing.Size(5, 5)
		Me.mapPoint3.TabIndex = 3
		'
		'mapPoint2
		'
		Me.mapPoint2.BackColor = System.Drawing.SystemColors.ActiveCaptionText
		Me.mapPoint2.Cursor = System.Windows.Forms.Cursors.SizeAll
		Me.mapPoint2.Location = New System.Drawing.Point(351, 283)
		Me.mapPoint2.Name = "mapPoint2"
		Me.mapPoint2.Size = New System.Drawing.Size(5, 5)
		Me.mapPoint2.TabIndex = 2
		'
		'mapPoint1
		'
		Me.mapPoint1.BackColor = System.Drawing.SystemColors.ActiveCaptionText
		Me.mapPoint1.Cursor = System.Windows.Forms.Cursors.SizeAll
		Me.mapPoint1.Location = New System.Drawing.Point(207, 283)
		Me.mapPoint1.Name = "mapPoint1"
		Me.mapPoint1.Size = New System.Drawing.Size(5, 5)
		Me.mapPoint1.TabIndex = 1
		'
		'SnippetImage
		'
		Me.SnippetImage.Dock = System.Windows.Forms.DockStyle.Fill
		Me.SnippetImage.Image = CType(resources.GetObject("SnippetImage.Image"), System.Drawing.Image)
		Me.SnippetImage.InitialImage = CType(resources.GetObject("SnippetImage.InitialImage"), System.Drawing.Image)
		Me.SnippetImage.Location = New System.Drawing.Point(0, 0)
		Me.SnippetImage.Name = "SnippetImage"
		Me.SnippetImage.Size = New System.Drawing.Size(593, 707)
		Me.SnippetImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
		Me.SnippetImage.TabIndex = 0
		Me.SnippetImage.TabStop = False
		'
		'RotationSlider
		'
		Me.RotationSlider.Location = New System.Drawing.Point(0, 19)
		Me.RotationSlider.Maximum = 180
		Me.RotationSlider.Minimum = -180
		Me.RotationSlider.Name = "RotationSlider"
		Me.RotationSlider.Size = New System.Drawing.Size(379, 45)
		Me.RotationSlider.TabIndex = 1
		Me.RotationSlider.TickFrequency = 10
		'
		'Rotation
		'
		Me.Rotation.Controls.Add(Me.RotationUpDown)
		Me.Rotation.Controls.Add(Me.RotationSlider)
		Me.Rotation.Location = New System.Drawing.Point(12, 713)
		Me.Rotation.Name = "Rotation"
		Me.Rotation.Size = New System.Drawing.Size(487, 64)
		Me.Rotation.TabIndex = 2
		Me.Rotation.TabStop = False
		Me.Rotation.Text = "Rotation"
		'
		'RotationUpDown
		'
		Me.RotationUpDown.Location = New System.Drawing.Point(385, 19)
		Me.RotationUpDown.Maximum = New Decimal(New Integer() {180, 0, 0, 0})
		Me.RotationUpDown.Minimum = New Decimal(New Integer() {180, 0, 0, -2147483648})
		Me.RotationUpDown.Name = "RotationUpDown"
		Me.RotationUpDown.Size = New System.Drawing.Size(96, 20)
		Me.RotationUpDown.TabIndex = 2
		'
		'Zoom
		'
		Me.Zoom.Controls.Add(Me.ZoomUpDown)
		Me.Zoom.Controls.Add(Me.ZoomSlider)
		Me.Zoom.Location = New System.Drawing.Point(505, 713)
		Me.Zoom.Name = "Zoom"
		Me.Zoom.Size = New System.Drawing.Size(487, 64)
		Me.Zoom.TabIndex = 3
		Me.Zoom.TabStop = False
		Me.Zoom.Text = "Zoom"
		'
		'ZoomUpDown
		'
		Me.ZoomUpDown.Location = New System.Drawing.Point(385, 19)
		Me.ZoomUpDown.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
		Me.ZoomUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
		Me.ZoomUpDown.Name = "ZoomUpDown"
		Me.ZoomUpDown.Size = New System.Drawing.Size(96, 20)
		Me.ZoomUpDown.TabIndex = 2
		Me.ZoomUpDown.Value = New Decimal(New Integer() {100, 0, 0, 0})
		'
		'ZoomSlider
		'
		Me.ZoomSlider.Location = New System.Drawing.Point(0, 19)
		Me.ZoomSlider.Maximum = 500
		Me.ZoomSlider.Minimum = 1
		Me.ZoomSlider.Name = "ZoomSlider"
		Me.ZoomSlider.Size = New System.Drawing.Size(379, 45)
		Me.ZoomSlider.TabIndex = 1
		Me.ZoomSlider.TickFrequency = 10
		Me.ZoomSlider.Value = 100
		'
		'SplitContainer1
		'
		Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Top
		Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
		Me.SplitContainer1.Name = "SplitContainer1"
		'
		'SplitContainer1.Panel1
		'
		Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
		'
		'SplitContainer1.Panel2
		'
		Me.SplitContainer1.Panel2.Controls.Add(Me.PreviewImage)
		Me.SplitContainer1.Size = New System.Drawing.Size(1186, 707)
		Me.SplitContainer1.SplitterDistance = 593
		Me.SplitContainer1.TabIndex = 4
		'
		'PreviewImage
		'
		Me.PreviewImage.Dock = System.Windows.Forms.DockStyle.Fill
		Me.PreviewImage.Image = CType(resources.GetObject("PreviewImage.Image"), System.Drawing.Image)
		Me.PreviewImage.InitialImage = CType(resources.GetObject("PreviewImage.InitialImage"), System.Drawing.Image)
		Me.PreviewImage.Location = New System.Drawing.Point(0, 0)
		Me.PreviewImage.Name = "PreviewImage"
		Me.PreviewImage.Size = New System.Drawing.Size(589, 707)
		Me.PreviewImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
		Me.PreviewImage.TabIndex = 1
		Me.PreviewImage.TabStop = False
		'
		'SnippetPreProcess
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(1186, 789)
		Me.Controls.Add(Me.SplitContainer1)
		Me.Controls.Add(Me.Zoom)
		Me.Controls.Add(Me.Rotation)
		Me.Name = "SnippetPreProcess"
		Me.Text = "SnippetPreProcess"
		Me.Panel1.ResumeLayout(False)
		CType(Me.SnippetImage, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.RotationSlider, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Rotation.ResumeLayout(False)
		Me.Rotation.PerformLayout()
		CType(Me.RotationUpDown, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Zoom.ResumeLayout(False)
		Me.Zoom.PerformLayout()
		CType(Me.ZoomUpDown, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.ZoomSlider, System.ComponentModel.ISupportInitialize).EndInit()
		Me.SplitContainer1.Panel1.ResumeLayout(False)
		Me.SplitContainer1.Panel2.ResumeLayout(False)
		CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.SplitContainer1.ResumeLayout(False)
		CType(Me.PreviewImage, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents Panel1 As Panel
	Friend WithEvents SnippetImage As PictureBox
	Friend WithEvents RotationSlider As TrackBar
	Friend WithEvents Rotation As GroupBox
	Friend WithEvents RotationUpDown As NumericUpDown
	Friend WithEvents mapPoint1 As Panel
	Friend WithEvents mapPoint4 As Panel
	Friend WithEvents mapPoint3 As Panel
	Friend WithEvents mapPoint2 As Panel
	Friend WithEvents Zoom As GroupBox
	Friend WithEvents ZoomUpDown As NumericUpDown
	Friend WithEvents ZoomSlider As TrackBar
	Friend WithEvents SplitContainer1 As SplitContainer
	Friend WithEvents PreviewImage As PictureBox
End Class
