Public Class SnippetPreProcess
	Dim img As Bitmap
	Dim clickX As Integer
	Dim clickY As Integer
	'Dim rotationVal As Integer

	Private Sub RotationSlider_Scroll(sender As Object, e As EventArgs) Handles RotationSlider.Scroll, RotationUpDown.ValueChanged
		RotationUpDown.Value = sender.value
		RotationSlider.Value = sender.value
		UpdateDraw()
	End Sub

	Private Sub ZoomSlider_Scroll(sender As Object, e As EventArgs) Handles ZoomSlider.Scroll, ZoomUpDown.ValueChanged
		ZoomSlider.Value = sender.value
		ZoomUpDown.Value = sender.value
		UpdateDraw()
	End Sub

	Private Sub SnippetPreProcess_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		img = SnippetImage.InitialImage
		MakeDraggable(mapPoint1)
		MakeDraggable(mapPoint2)
		MakeDraggable(mapPoint3)
		MakeDraggable(mapPoint4)
		Dim offsetY As Single = (SnippetImage.InitialImage.Height) / 2
		Dim offsetX As Single = (SnippetImage.InitialImage.Width) / 2
		Dim translateOffset As Point = New Point(SnippetImage.Width / 2, SnippetImage.Height / 2)
		mapPoint1.Location = translateOffset + New Point(-offsetX, -offsetY) + New Point(-2, -3)
		mapPoint2.Location = translateOffset + New Point(offsetX, -offsetY) + New Point(2, -3)
		mapPoint3.Location = translateOffset + New Point(-offsetX, offsetY) + New Point(-2, 3)
		mapPoint4.Location = translateOffset + New Point(offsetX, offsetY) + New Point(2, 3)
	End Sub

	Private Sub MakeDraggable(ByVal Control As Control)
		AddHandler Control.MouseDown, Sub(sender As Object, e As MouseEventArgs) StartDrag(Control)
		AddHandler Control.MouseMove, Sub(sender As Object, e As MouseEventArgs) Drag(Control)
		AddHandler Control.MouseUp, Sub(sender As Object, e As MouseEventArgs) StopDrag(Control)
	End Sub
	Private Sub StartDrag(ByVal Control As Control)
		Control.Tag = New DragInfo(Form.MousePosition, Control.Location)
	End Sub
	Private Sub Drag(ByVal Control As Control)
		If Control.Tag IsNot Nothing AndAlso TypeOf Control.Tag Is DragInfo Then
			Dim info As DragInfo = CType(Control.Tag, DragInfo)
			Dim newLoc As Point = info.NewLocation(Form.MousePosition)
			If Me.ClientRectangle.Contains(New Rectangle(newLoc, Control.Size)) Then Control.Location = newLoc
			UpdateDraw()
		End If
	End Sub
	Private Sub StopDrag(ByVal Control As Control)
		Control.Tag = Nothing
	End Sub

	Private Sub UpdateDraw()
		Me.Invalidate()
	End Sub

	Private Sub SnippetPreProcess_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
		Dim radius As Integer = Math.Max(SnippetImage.InitialImage.Width, SnippetImage.InitialImage.Height)
		'Dim imgTopLeft As New Bitmap(img.Width / 2, img.Height / 2, Imaging.PixelFormat.Format32bppArgb)
		'Dim imgTopLeft2 As New Bitmap(img.Width / 2, img.Height / 2, Imaging.PixelFormat.Format32bppArgb)

		Dim imgTopLeft As New Bitmap(img.Width, img.Height, Imaging.PixelFormat.Format32bppArgb)
		Dim imgTopLeft2 As New Bitmap(img.Width, img.Height, Imaging.PixelFormat.Format32bppArgb)

		Dim imgTopRight As New Bitmap(img.Width / 2, img.Height / 2, Imaging.PixelFormat.Format32bppArgb)
		Dim imgTopRight2 As New Bitmap(img.Width / 2, img.Height / 2, Imaging.PixelFormat.Format32bppArgb)
		Dim imgRight As New Bitmap(img.Width, img.Height, Imaging.PixelFormat.Format32bppArgb)
		Dim imgBottom As New Bitmap(img.Width, img.Height, Imaging.PixelFormat.Format32bppArgb)
		'Dim imgLeft As New Bitmap(img.Width, img.Height, Imaging.PixelFormat.Format32bppArgb)
		Dim imgLeft As New Bitmap(img.Width / 2, img.Height / 2, Imaging.PixelFormat.Format32bppArgb)
		Dim imgLeft2 As New Bitmap(img.Width / 2, img.Height / 2, Imaging.PixelFormat.Format32bppArgb)
		Dim scaleFactor As Single = ZoomSlider.Value * 0.01
		Dim newImg As New Bitmap(SnippetImage.Width, SnippetImage.Height, Imaging.PixelFormat.Format32bppArgb)
		Dim newPrevImg As New Bitmap(SnippetImage.Width, SnippetImage.Height, Imaging.PixelFormat.Format32bppArgb)
		Dim offsetY As Single = (SnippetImage.InitialImage.Height) / 2
		Dim offsetX As Single = (SnippetImage.InitialImage.Width) / 2
		Dim offset As Point = New Point(offsetX, offsetY)
		Dim translateOffset As Point = New Point(SnippetImage.Width / 2, SnippetImage.Height / 2)
		Dim map1 As Point = mapPoint1.Location - translateOffset + New Point(2, 2)
		Dim map2 As Point = mapPoint2.Location - translateOffset + New Point(2, 2)
		Dim map3 As Point = mapPoint3.Location - translateOffset + New Point(2, 2)
		Dim map4 As Point = mapPoint4.Location - translateOffset + New Point(2, 2)
		Dim center As Point = New Point(0, 0)
		Dim offsetTL As Point = New Point((-(offsetX * 2) - (map1.X / scaleFactor)), (-(offsetY * 2) - (map1.Y / scaleFactor)))
		Dim offsetTR As Point = New Point(((offsetX * 2) - (map2.X / scaleFactor)), (-(offsetY * 2) - (map2.Y / scaleFactor)))
		Dim offsetBL As Point = New Point((-(offsetX * 2) - (map3.X / scaleFactor)), ((offsetY * 2) - (map3.Y / scaleFactor)))
		Dim offsetBR As Point = New Point(((offsetX * 2) - (map4.X / scaleFactor)), ((offsetY * 2) - (map4.Y / scaleFactor)))

		Dim TC As Point = New Point((offsetTL.X + offsetTR.X) / 2, (offsetTL.Y + offsetTR.Y) / 2)
		Dim LM As Point = New Point((offsetTL.X + offsetBL.X) / 2, (offsetTL.Y + offsetBL.Y) / 2)
		Dim RM As Point = New Point((offsetTR.X + offsetBR.X) / 2, (offsetTR.Y + offsetBR.Y) / 2)
		Dim BC As Point = New Point((offsetBL.X + offsetBR.X) / 2, (offsetBL.Y + offsetBR.Y) / 2)
		Dim CalcCenter As Point = New Point((LM.X + RM.X) / 2, (TC.Y + BC.Y) / 2)



		Using g As Graphics = Graphics.FromImage(imgTopLeft)
			'g.DrawImage(img, New Rectangle(0, 0, img.Width / 2, img.Height / 2), New Rectangle(0, 0, img.Width / 2, img.Height / 2), GraphicsUnit.Pixel)
			g.DrawImage(img, New Rectangle(0, 0, img.Width, img.Height), New Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel)
			imgTopLeft.RotateFlip(RotateFlipType.RotateNoneFlipY)
			g.Save()
		End Using
		Using g As Graphics = Graphics.FromImage(imgTopLeft2)
			'g.DrawImage(img, New Rectangle(0, 0, img.Width / 2, img.Height / 2), New Rectangle(0, 0, img.Width / 2, img.Height / 2), GraphicsUnit.Pixel)
			g.DrawImage(img, New Rectangle(0, 0, img.Width, img.Height), New Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel)
			imgTopLeft2.RotateFlip(RotateFlipType.RotateNoneFlipX)
			g.Save()
		End Using


		Using g As Graphics = Graphics.FromImage(imgTopRight)
			g.DrawImage(img, New Rectangle(0, 0, img.Width / 2, img.Height / 2), New Rectangle(img.Width / 2, 0, img.Width / 2, img.Height / 2), GraphicsUnit.Pixel)
			imgTopRight.RotateFlip(RotateFlipType.RotateNoneFlipNone)
			g.Save()
		End Using
		Using g As Graphics = Graphics.FromImage(imgTopRight2)
			g.DrawImage(img, New Rectangle(0, 0, img.Width / 2, img.Height / 2), New Rectangle(img.Width / 2, 0, img.Width / 2, img.Height / 2), GraphicsUnit.Pixel)
			imgTopRight2.RotateFlip(RotateFlipType.RotateNoneFlipXY)
			g.Save()
		End Using

		Using g As Graphics = Graphics.FromImage(imgRight)
			g.DrawImage(img, New Point(0, 0))
			imgRight.RotateFlip(RotateFlipType.RotateNoneFlipX)
			g.Save()
		End Using
		Using g As Graphics = Graphics.FromImage(imgBottom)
			g.DrawImage(img, New Point(0, 0))
			imgBottom.RotateFlip(RotateFlipType.RotateNoneFlipXY)
			g.Save()
		End Using
		Using g As Graphics = Graphics.FromImage(imgLeft)
			g.DrawImage(img, New Rectangle(0, 0, img.Width / 2, img.Height / 2), New Rectangle(0, img.Height / 2, img.Width / 2, img.Height / 2), GraphicsUnit.Pixel)
			imgLeft.RotateFlip(RotateFlipType.RotateNoneFlipX)
			g.Save()
		End Using
		Using g As Graphics = Graphics.FromImage(imgLeft2)
			g.DrawImage(img, New Rectangle(0, 0, img.Width / 2, img.Height / 2), New Rectangle(0, img.Height / 2, img.Width / 2, img.Height / 2), GraphicsUnit.Pixel)
			imgLeft.RotateFlip(RotateFlipType.RotateNoneFlipY)
			g.Save()
		End Using

		Using g As Graphics = Graphics.FromImage(newImg)
			g.TranslateTransform(SnippetImage.Width / 2, SnippetImage.Height / 2)
			g.ScaleTransform(scaleFactor, scaleFactor)
			g.DrawImage(img, -offsetX, -offsetY)

			g.ScaleTransform(1 / scaleFactor, 1 / scaleFactor)
			g.DrawLine(Pens.Red, map1, map2)
			g.DrawLine(Pens.Red, map2, map4)
			g.DrawLine(Pens.Red, map1, map3)
			g.DrawLine(Pens.Red, map3, map4)
		End Using

		Using g As Graphics = Graphics.FromImage(newPrevImg)
			g.TranslateTransform(PreviewImage.Width / 2, PreviewImage.Height / 2)
			g.ScaleTransform(scaleFactor, scaleFactor)
			g.RotateTransform(RotationSlider.Value)
			g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality

			Dim destinationPointsTopLeft As Point() = {LM, CalcCenter, offsetTL + New Point(1, -1)}
			Dim destinationPointsTopLeft2 As Point() = {TC, offsetTL + New Point(-1, 1), CalcCenter}
			Dim destinationPointsTopRight As Point() = {RM, CalcCenter, offsetTR}
			Dim destinationPointsTopRight2 As Point() = {TC, offsetTR, CalcCenter}
			Dim destinationPointsRight As Point() = {offsetTR, offsetTL, offsetBR}
			Dim destinationPointsBottom As Point() = {offsetBR, offsetBL, offsetTR}

			Dim destinationPointsRight2 As Point() = {offsetBL, offsetBR, offsetTL}
			Dim destinationPointsBottom2 As Point() = {offsetBL, offsetBR, offsetTL}
			Dim destinationPointsLeft2 As Point() = {BC, offsetBL, CalcCenter}
			Dim destinationPointsLeft As Point() = {LM, CalcCenter, offsetBL}

			'Dim pathTopLeft As Point() = {
			'New Point(-offsetX, -offsetY),
			'New Point(0, -offsetY),
			'New Point(0, 0),
			'New Point(-offsetX, 0)}
			Dim pathTopLeft2 As Point() = {
			New Point(-offsetX, -offsetY),
			New Point(TC.X + 1, -offsetY),
			New Point(CalcCenter.X + 1, CalcCenter.Y + 1)}
			Dim pathTopLeft As Point() = {
			New Point(CalcCenter.X + 1, CalcCenter.Y + 1),
			New Point(-offsetX, LM.Y + 1),
			New Point(-offsetX, -offsetY)}


			Dim pathTopRight As Point() = {
			New Point(TC.X - 1, -offsetY),
			New Point(offsetX, -offsetY),
			New Point(CalcCenter.X - 1, CalcCenter.Y + 1)}
			Dim pathTopRight2 As Point() = {
			New Point(offsetX, -offsetY),
			New Point(offsetX, RM.Y + 1),
			New Point(CalcCenter.X - 1, CalcCenter.Y + 1)}

			Dim pathBottomRight As Point() = {
			New Point(offsetX, offsetY),
			New Point(BC.X, offsetY),
			New Point(CalcCenter.X - 1, CalcCenter.Y - 1),
			New Point(offsetX, RM.Y)}
			'Dim pathBottomLeft As Point() = {
			'New Point(-offsetX, offsetY),
			'New Point(0, offsetY),
			'New Point(0, 0),
			'New Point(-offsetX, 0)}
			Dim pathBottomLeft As Point() = {
			New Point(-offsetX, offsetY),
			CalcCenter,
			New Point(-offsetX, LM.Y - 1)}
			Dim pathBottomLeft2 As Point() = {
			New Point(-offsetX, offsetY),
			New Point(BC.X + 1, offsetY),
			CalcCenter}

			Dim path = New Drawing2D.GraphicsPath(Drawing2D.FillMode.Winding)
			path.AddLines({pathTopLeft(0), pathTopLeft(1), pathTopLeft(2), pathTopLeft(0)})
			g.SetClip(path)
			g.DrawImage(imgTopLeft, destinationPointsTopLeft, New Rectangle(0, img.Height / 2, img.Width / 2, img.Height / 2), GraphicsUnit.Pixel)

			path = New Drawing2D.GraphicsPath(Drawing2D.FillMode.Winding)
			path.AddLines({pathTopLeft2(0), pathTopLeft2(1), pathTopLeft2(2), pathTopLeft2(0)})
			g.SetClip(path)
			g.DrawImage(imgTopLeft2, destinationPointsTopLeft2, New Rectangle(img.Width / 2, 0, img.Width / 2, img.Height / 2), GraphicsUnit.Pixel)


			path.AddLines({pathTopRight(0), pathTopRight(1), pathTopRight(2), pathTopRight(0)})
			g.SetClip(path)
			'g.DrawImage(imgTopRight2, destinationPointsTopRight)
			imgTopLeft.RotateFlip(RotateFlipType.Rotate180FlipY)
			g.DrawImage(imgTopLeft, destinationPointsTopRight, New Rectangle(0, img.Height / 2, img.Width / 2, img.Height / 2), GraphicsUnit.Pixel)
			imgTopLeft.RotateFlip(RotateFlipType.Rotate180FlipNone)
			path = New Drawing2D.GraphicsPath(Drawing2D.FillMode.Winding)
			path.AddLines({pathTopRight2(0), pathTopRight2(1), pathTopRight2(2), pathTopRight2(0)})
			g.SetClip(path)
			'imgTopLeft.RotateFlip(RotateFlipType.RotateNoneFlipY)
			g.DrawImage(imgTopLeft, destinationPointsTopRight2, New Rectangle(img.Width / 2, 0, img.Width / 2, img.Height / 2), GraphicsUnit.Pixel)
			imgTopLeft.RotateFlip(RotateFlipType.RotateNoneFlipY)
			'g.DrawImage(imgTopRight, destinationPointsTopRight2)


			path = New Drawing2D.GraphicsPath(Drawing2D.FillMode.Winding)
			path.AddLines({pathBottomRight(0), pathBottomRight(1), pathBottomRight(2), pathBottomRight(3)})
			g.SetClip(path)
			g.DrawImage(imgBottom, destinationPointsBottom)

			path = New Drawing2D.GraphicsPath(Drawing2D.FillMode.Winding)
			path.AddLines({pathBottomLeft(0), pathBottomLeft(1), pathBottomLeft(2), pathBottomLeft(0)})
			g.SetClip(path)
			imgTopLeft2.RotateFlip(RotateFlipType.RotateNoneFlipX)
			'g.DrawImage(imgLeft2, destinationPointsLeft)
			g.DrawImage(imgTopLeft2, destinationPointsLeft, New Rectangle(0, img.Height / 2, img.Width / 2, img.Height / 2), GraphicsUnit.Pixel)

			path = New Drawing2D.GraphicsPath(Drawing2D.FillMode.Winding)
			path.AddLines({pathBottomLeft2(0), pathBottomLeft2(1), pathBottomLeft2(2), pathBottomLeft2(0)})
			g.SetClip(path)
			g.DrawImage(imgLeft, destinationPointsLeft2)

			path = New Drawing2D.GraphicsPath(Drawing2D.FillMode.Winding)
			path.AddLines({New Point(-offsetX, -offsetY), New Point(offsetX, -offsetY), New Point(offsetX, offsetY), New Point(-offsetX, offsetY)})
			g.SetClip(path)
			g.DrawRectangle(Pens.OliveDrab, New Rectangle(LM.X - 1, LM.Y - 1, 3, 3))
			g.DrawRectangle(Pens.OliveDrab, New Rectangle(RM.X - 1, RM.Y - 1, 3, 3))
			g.DrawRectangle(Pens.OliveDrab, New Rectangle(TC.X - 1, TC.Y - 1, 3, 3))
			g.DrawRectangle(Pens.OliveDrab, New Rectangle(BC.X - 1, BC.Y - 1, 3, 3))
			g.DrawRectangle(Pens.OliveDrab, New Rectangle(CalcCenter.X - 1, CalcCenter.Y - 1, 3, 3))

			'g.FillPolygon(New TextureBrush(img), New Point() {offsetTL, offsetTR, offsetBR, offsetBL})

			g.RotateTransform(-RotationSlider.Value)
		End Using
		SnippetImage.Image = newImg
		PreviewImage.Image = newPrevImg
	End Sub
End Class

Public Class DragInfo
	Public Property InitialMouseCoords As Point
	Public Property InitialLocation As Point

	Public Sub New(ByVal MouseCoords As Point, ByVal Location As Point)
		InitialMouseCoords = MouseCoords
		InitialLocation = Location
	End Sub

	Public Function NewLocation(ByVal MouseCoords As Point) As Point
		Dim loc As New Point(InitialLocation.X + (MouseCoords.X - InitialMouseCoords.X), InitialLocation.Y + (MouseCoords.Y - InitialMouseCoords.Y))
		Return loc
	End Function
End Class