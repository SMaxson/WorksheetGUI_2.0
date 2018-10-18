
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices
Public Class Tutorial
	'Private target As Object
	'Private i As Integer = 0
	'Private FileMenuOffset As Point
	'Dim tutorialList As Dictionary(Of Object, String)
	Dim drawOverlayStartPos As Point
	Dim drawOverlayEndPos As Point
	Dim drawOverlay As Boolean = False
	Dim bmpLocation As Point
	Public Property bmpRectangle As Rectangle

	<DllImport("user32.dll", EntryPoint:="GetWindowLong")> Public Shared Function GetWindowLong(ByVal hWnd As IntPtr, ByVal nIndex As Integer) As Integer
	End Function
	<DllImport("user32.dll", EntryPoint:="SetWindowLong")> Public Shared Function SetWindowLong(ByVal hWnd As IntPtr, ByVal nIndex As Integer, ByVal dwNewLong As Integer) As Integer
	End Function

	Public Sub New(ByRef rect As Rectangle, ByRef loc As Point)
		' This call is required by the designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.
		bmpLocation = loc
		bmpRectangle = rect
	End Sub


	Private Sub Tutorial_Paint(sender As Object, e As PaintEventArgs)
		'If Me.BackColor = Color.DimGray Then
		'	Try
		'		Using b = New SolidBrush(Color.Pink)
		'			Dim g As Graphics = e.Graphics
		'			Dim rect As New Rectangle
		'			If IsNothing(TryCast(target, Control)) Then
		'				rect.Location = (target.Bounds.Location) - New Point(25, 25) - FileMenuOffset
		'				FileMenuOffset = rect.Location + New Point(25, 25)
		'			Else
		'				rect.Location = Me.PointToClient(target.PointToScreen(New Point(0, 0))) - New Point(25, 25)
		'			End If
		'			rect.Size = New Size(target.Bounds.Width + 50, target.Bounds.Height + 50)

		'			g.FillEllipse(b, rect)
		'			rect.Inflate(2, 2)
		'			g.DrawEllipse(Pens.DeepSkyBlue, rect)


		'		End Using
		'	Catch ex As Exception
		'		If Not IsNothing(ex.InnerException) Then
		'			wsGUIWindow.showStatus.Text = "Error occurred in tutorial. " & ex.Message & " " & ex.InnerException.Message
		'		Else
		'			wsGUIWindow.showStatus.Text = "Error occurred in tutorial. " & ex.Message
		'		End If

		'	End Try
		'	Try
		'		If wsGUIWindow.speechPanel.Visible Then
		'			Using b = New SolidBrush(Color.Pink)
		'				Dim g As Graphics = e.Graphics
		'				Dim rect As New Rectangle
		'				rect.Location = New Point(wsGUIWindow.speechPanel.Bounds.Location.X, wsGUIWindow.speechPanel.Bounds.Location.Y - 1)
		'				rect.Size = New Size(wsGUIWindow.speechPanel.Bounds.Width, wsGUIWindow.speechPanel.Bounds.Size.Height)
		'				g.FillRectangle(b, rect)
		'			End Using
		'		End If
		'	Catch ex As Exception
		'		wsGUIWindow.showStatus.Text = "Error occurred in tutorial. " & ex.Message
		'	End Try
		'End If
		Dim crpos As Point = Me.PointToClient(Me.DesktopLocation)
		If drawOverlay Then
			Using b = New SolidBrush(Color.Pink)
				Dim g As Graphics = e.Graphics
				Dim start As New Point(0, 0)
				Dim size As New Point(0, 0)
				size.X = Math.Abs(drawOverlayEndPos.X - drawOverlayStartPos.X)
				size.Y = Math.Abs(drawOverlayEndPos.Y - drawOverlayStartPos.Y)
				If MousePosition.X > drawOverlayStartPos.X Then
					start.X = drawOverlayStartPos.X
				Else
					start.X = drawOverlayEndPos.X
				End If
				start.X = start.X - Me.Location.X
				If drawOverlayEndPos.Y > drawOverlayStartPos.Y Then
					start.Y = drawOverlayStartPos.Y
				Else
					start.Y = drawOverlayEndPos.Y
				End If
				g.FillRectangle(b, New Rectangle(start.X, start.Y, size.X, size.Y))
			End Using
		End If
	End Sub

	Public Sub DrawDragRectangle() Handles Me.MouseDown

		'If Not wsGUIWindow.displayArea.ClientRectangle.Width > wsGUIWindow.displayArea.Document.Body.ClientRectangle.Width Then
		'	ClickPoint.X += SystemInformation.VerticalScrollBarWidth
		'Else
		'	ClickPoint.X += SystemInformation.VerticalScrollBarWidth / 2
		'End If

		'Screen.FromPoint(Cursor.Position).
		drawOverlayStartPos = MousePosition
		drawOverlay = True
	End Sub

	Public Sub DragRectangleUpdate() Handles Me.MouseMove
		'If Not wsGUIWindow.displayArea.ClientRectangle.Width > wsGUIWindow.displayArea.Document.Body.ClientRectangle.Width Then
		'	ClickPoint.X += SystemInformation.VerticalScrollBarWidth
		'Else
		'	ClickPoint.X += SystemInformation.VerticalScrollBarWidth / 2
		'End If
		drawOverlayEndPos = MousePosition
		Me.Invalidate()
	End Sub

	Public Sub DragRectangleStop() Handles Me.MouseUp
		drawOverlayEndPos = MousePosition
		Dim start As New Point(0, 0)
		Dim size As New Point(0, 0)
		size.X = Math.Abs(drawOverlayEndPos.X - drawOverlayStartPos.X)
		size.Y = Math.Abs(drawOverlayEndPos.Y - drawOverlayStartPos.Y)
		If drawOverlayEndPos.X > drawOverlayStartPos.X Then
			start.X = drawOverlayStartPos.X
		Else
			start.X = drawOverlayEndPos.X
		End If
		If drawOverlayEndPos.Y > drawOverlayStartPos.Y Then
			start.Y = drawOverlayStartPos.Y
		Else
			start.Y = drawOverlayEndPos.Y
		End If

		bmpRectangle = New Rectangle(start, size)
		drawOverlay = False
		Me.Refresh()
		drawOverlayStartPos = New Point(0.0)
		drawOverlayEndPos = New Point(0.0)
		Me.Close()
	End Sub

	Private Sub CanvasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Me.BackColor = Color.Gray
		Me.TransparencyKey = Color.Pink
		Me.Opacity = 0.8
		Me.FormBorderStyle = FormBorderStyle.None
		'Dim InitialStyle As Integer
		'target = wsGUIWindow.blorp
		'InitialStyle = GetWindowLong(Me.Handle, -20)
		'SetWindowLong(Me.Handle, -20, InitialStyle Or &H80000 Or &H20) 'Makes the window "click-throughable"
		AddHandler MyBase.Paint, AddressOf Tutorial_Paint
		Dim screenDictionary As New Dictionary(Of String, Integer)
		Dim h As Integer = SystemInformation.VirtualScreen.Height
		Dim w As Integer = SystemInformation.VirtualScreen.Width
		Dim top As Integer = SystemInformation.VirtualScreen.Top
		Dim left As Integer = SystemInformation.VirtualScreen.Left
		For Each Screen In System.Windows.Forms.Screen.AllScreens
			screenDictionary.Add(Screen.DeviceName, Screen.Bounds.Width)
		Next

		Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
		Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
		Me.Size = New System.Drawing.Size(w, h)
		Me.Location = New Point(left, top)

		'Me.DesktopLocation = New Point(0, 0)
	End Sub

	Public Sub Redraw()
		Me.Invalidate()
	End Sub

	'Public Sub NextElement(targetControl As Object)
	'	target = targetControl
	'	Redraw()
	'End Sub

	'Public Sub StartTutorial(list As Dictionary(Of Object, String))
	'	Me.BackColor = Color.DimGray
	'	Me.Visible = True
	'	i = 0
	'	FileMenuOffset = New Point(0, 0)
	'	tutorialList = New Dictionary(Of Object, String)(list)
	'	ProgressTutorial()
	'	Redraw()
	'End Sub

	'Public Sub EndTutorial()
	'	Me.BackColor = Color.Pink
	'	Me.Visible = False
	'	i = 0
	'End Sub

	'Public Sub ProgressTutorial()
	'	Me.BackColor = Color.DimGray
	'	NextElement(tutorialList.Keys(i))

	'	If i = tutorialList.Count Then
	'		EndTutorial()
	'		Exit Sub
	'	End If
	'	If tutorialList.Values(i).Length > 0 Then
	'		wsGUIWindow.mumbo(tutorialList.Values(i))
	'	End If
	'	'Dim nextUp
	'	If IsNothing(TryCast(tutorialList.Keys(i), Control)) Then
	'		AddHandler TryCast(tutorialList.Keys(i), ToolStripMenuItem).Click, AddressOf ProgressTutorial
	'	Else
	'		AddHandler TryCast(tutorialList.Keys(i), Control).Click, AddressOf ProgressTutorial
	'	End If
	'	If i > 0 Then
	'		Dim Handler As EventHandler = AddressOf ProgressTutorial
	'		If IsNothing(TryCast(tutorialList.Keys(i - 1), Control)) Then
	'			Dim targetToolStripItem = TryCast(tutorialList.Keys(i - 1), ToolStripMenuItem)
	'			RemoveHandler targetToolStripItem.Click , Handler
	'		Else
	'			RemoveHandler TryCast(tutorialList.Keys(i - 1), Control).Click, Handler
	'		End If
	'	End If
	'	i += 1
	'		Redraw()

	'End Sub
End Class