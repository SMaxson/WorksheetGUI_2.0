Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices
Public Class CanvasForm
	Public drawSelect As Boolean = False
	Public drawSelectChildren As Boolean = False
	Public drawOverlay As Boolean = False
	Private drawOverlayStartPos As Point = New Point(0, 0)
	Private drawOverlayEndPos As Point = New Point(0, 0)
	<DllImport("user32.dll", EntryPoint:="GetWindowLong")> Public Shared Function GetWindowLong(ByVal hWnd As IntPtr, ByVal nIndex As Integer) As Integer
	End Function
	<DllImport("user32.dll", EntryPoint:="SetWindowLong")> Public Shared Function SetWindowLong(ByVal hWnd As IntPtr, ByVal nIndex As Integer, ByVal dwNewLong As Integer) As Integer
	End Function

	Private Sub CanvasForm_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
		If Not wsGUIWindow.displayAreaSourceBoxRich.Visible And Not IsNothing(wsGUIWindow.targetElement) Then
			If drawSelect = True Then
				Try
					Dim targetElementHorizontal = wsGUIWindow.targetElement.OffsetRectangle.Left ' + wsGUIWindow.displayArea.Left
					Dim targetElementVertical = wsGUIWindow.targetElement.OffsetRectangle.Top ' + wsGUIWindow.displayArea.Top
					Dim tempParent = wsGUIWindow.targetElement.OffsetParent
					Do While tempParent IsNot Nothing
						targetElementHorizontal += tempParent.OffsetRectangle.Left
						targetElementVertical += tempParent.OffsetRectangle.Top
						tempParent = tempParent.OffsetParent
					Loop
					Dim rc = New Rectangle()
					rc.Size = wsGUIWindow.targetElement.ScrollRectangle.Size
					If wsGUIWindow.displayArea.Document.Body IsNot Nothing Then
						rc.Location = New Point(targetElementHorizontal - wsGUIWindow.displayArea.Document.Body.ScrollLeft, targetElementVertical - wsGUIWindow.displayArea.Document.Body.ScrollTop)
					Else
						rc.Location = New Point(targetElementHorizontal, targetElementVertical)
					End If

					Using b = New LinearGradientBrush(New Point(0, 0), New Point(100, 100), Color.SlateBlue, Color.DarkSlateBlue)
						Using p = New Pen(b, 4)
							Using g As Graphics = Me.CreateGraphics
								g.DrawRectangle(p, rc)
							End Using
						End Using
					End Using
					If drawSelectChildren = True Then
						For i As Integer = 0 To wsGUIWindow.targetElement.Children.Count - 1
							rc = New Rectangle()
							Dim child = wsGUIWindow.targetElement.Children.Item(i)
							targetElementHorizontal = child.OffsetRectangle.Left
							targetElementVertical = child.OffsetRectangle.Top
							tempParent = child.OffsetParent
							Do While tempParent IsNot Nothing
								targetElementHorizontal += tempParent.OffsetRectangle.Left
								targetElementVertical += tempParent.OffsetRectangle.Top
								tempParent = tempParent.OffsetParent
							Loop
							rc.Size = child.ScrollRectangle.Size
							rc.Location = New Point(targetElementHorizontal - wsGUIWindow.displayArea.Document.Body.ScrollLeft, targetElementVertical + child.ScrollRectangle.Top - wsGUIWindow.displayArea.Document.Body.ScrollTop)
							Using b = New LinearGradientBrush(New Point(0, 0), New Point(25, 25), Color.SteelBlue, Color.DimGray)
								Using p = New Pen(b, 1)
									p.DashPattern = New Single() {3.0F, 1.0F}
									Using g As Graphics = Me.CreateGraphics
										g.DrawRectangle(p, rc)
									End Using
								End Using
							End Using
						Next
					End If
				Catch ex As Exception
					wsGUIWindow.showStatus.Text = ex.Message
				End Try
			End If
			Try
				If wsGUIWindow.previewPageBreaks = True Then
					Using b = New LinearGradientBrush(New Point(0, 0), New Point(Me.Width, 0), Color.LightSeaGreen, Color.LightSkyBlue)
						Using p = New Pen(b, 8)
							Using g As Graphics = Me.CreateGraphics
								If wsGUIWindow.displayStyle = 1 Then
									g.DrawLine(p, New Point(0, 982 - wsGUIWindow.displayArea.Document.Body.ScrollTop), New Point(Me.Width, 982 - wsGUIWindow.displayArea.Document.Body.ScrollTop))
								End If
								If wsGUIWindow.displayStyle = 2 Then
									g.DrawLine(p, New Point(0, 752 - wsGUIWindow.displayArea.Document.Body.ScrollTop), New Point(Me.Width, 752 - wsGUIWindow.displayArea.Document.Body.ScrollTop))
								End If
								If wsGUIWindow.displayStyle = 3 Then
									g.DrawLine(p, New Point(0, 1272 - wsGUIWindow.displayArea.Document.Body.ScrollTop), New Point(Me.Width, 1272 - wsGUIWindow.displayArea.Document.Body.ScrollTop))
								End If
							End Using
						End Using
					End Using
				End If
			Catch ex As Exception
			End Try
			If drawOverlay Then
				Try
					Using b = New SolidBrush(Color.FromArgb(255, 0, 0, 139))
						'Using g As Graphics = e.Graphics
						Dim g As Graphics = e.Graphics
						If wsGUIWindow.displayStyle = 1 Then
							Dim start As New Point(0, 0)
							Dim size As New Point(0, 0)
							If drawOverlayEndPos.X > drawOverlayStartPos.X Then
								start.X = drawOverlayStartPos.X
								size.X = drawOverlayEndPos.X - drawOverlayStartPos.X
							Else
								start.X = drawOverlayEndPos.X
								size.X = drawOverlayStartPos.X - drawOverlayEndPos.X
							End If
							If drawOverlayEndPos.Y > drawOverlayStartPos.Y Then
								start.Y = drawOverlayStartPos.Y
								size.Y = drawOverlayEndPos.Y - drawOverlayStartPos.Y
							Else
								start.Y = drawOverlayEndPos.Y
								size.Y = drawOverlayStartPos.Y - drawOverlayEndPos.Y
							End If
							g.FillRectangle(b, New Rectangle(start.X - wsGUIWindow.displayArea.Document.Body.ScrollLeft, start.Y - wsGUIWindow.displayArea.Document.Body.ScrollTop, size.X, size.Y))
						End If
						'End Using
					End Using
				Catch ex As Exception
					wsGUIWindow.showStatus.Text = ex.Message
				End Try
			End If
		End If
	End Sub

	Private Sub CanvasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Me.BackColor = Color.Pink
		Me.TransparencyKey = Color.Pink
		Me.Opacity = 0.7
		Me.FormBorderStyle = FormBorderStyle.None
		Dim InitialStyle As Integer
		InitialStyle = GetWindowLong(Me.Handle, -20)
		SetWindowLong(Me.Handle, -20, InitialStyle Or &H80000 Or &H20) 'Makes the window "click-throughable"
	End Sub

	Public Sub Redraw()
		Me.Invalidate()
	End Sub

	Public Sub DrawDragRectangle(ClickPoint As Point)
		If Not wsGUIWindow.displayArea.ClientRectangle.Width > wsGUIWindow.displayArea.Document.Body.ClientRectangle.Width Then
			ClickPoint.X += SystemInformation.VerticalScrollBarWidth
		Else
			ClickPoint.X += SystemInformation.VerticalScrollBarWidth / 2
		End If
		drawOverlayStartPos = ClickPoint
		drawOverlay = True
	End Sub

	Public Sub DragRectangleUpdate(ClickPoint As Point)
		If Not wsGUIWindow.displayArea.ClientRectangle.Width > wsGUIWindow.displayArea.Document.Body.ClientRectangle.Width Then
			ClickPoint.X += SystemInformation.VerticalScrollBarWidth
		Else
			ClickPoint.X += SystemInformation.VerticalScrollBarWidth / 2
		End If
		drawOverlayEndPos = ClickPoint
		Me.Invalidate()
	End Sub

	Public Function DragRectangleStop(ClickPoint As Point) As List(Of Point)
		Dim output As New List(Of Point)
		drawOverlayEndPos = ClickPoint
		Dim start As New Point(0, 0)
		Dim size As New Point(0, 0)
		If drawOverlayEndPos.X > drawOverlayStartPos.X Then
			start.X = drawOverlayStartPos.X
			size.X = drawOverlayEndPos.X - drawOverlayStartPos.X
		Else
			start.X = drawOverlayEndPos.X
			size.X = drawOverlayStartPos.X - drawOverlayEndPos.X
		End If
		If drawOverlayEndPos.Y > drawOverlayStartPos.Y Then
			start.Y = drawOverlayStartPos.Y - 8
			size.Y = drawOverlayEndPos.Y - drawOverlayStartPos.Y
		Else
			start.Y = drawOverlayEndPos.Y -
			size.Y = drawOverlayStartPos.Y - drawOverlayEndPos.Y
		End If
		If Not wsGUIWindow.displayArea.ClientRectangle.Width > wsGUIWindow.displayArea.Document.Body.ClientRectangle.Width Then
			start.X -= SystemInformation.VerticalScrollBarWidth - 1
			size.X += SystemInformation.VerticalScrollBarWidth
		Else
			start.X -= SystemInformation.VerticalScrollBarWidth / 2 - 1
			size.X += SystemInformation.VerticalScrollBarWidth / 2
		End If
		output.Add(start)
		output.Add(size)
		drawOverlay = False
		Me.Refresh()
		drawOverlayStartPos = New Point(0.0)
		drawOverlayEndPos = New Point(0.0)
		Return output
	End Function
End Class