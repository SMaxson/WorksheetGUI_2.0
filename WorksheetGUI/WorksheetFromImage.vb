Imports System.Drawing.Imaging
Imports System.Text

Module WorksheetFromImage
	Public Class BitmapConverter
		Inherits Dictionary(Of Integer, Dictionary(Of Integer, Boolean))
		Private borders As BorderList
		Private minCellWidth As Integer = 10
		Private minCellHeight As Integer = 10
		Private minGapX As Integer = 20
		Private minGapY As Integer = 8
		Private minLengthX As Integer = 25
		Private minLengthY As Integer = 16
		Private threshhold As Single = 0.05 'Sets the minimum brightness variation between two pixels in order to be considered an edge.
		Private Verbose As Boolean = True
		Private HorizontalConversionRatio As Double
		Private VerticalConversionRatio As Double
		Public MonochromeBitMap As Bitmap
		Public CurrentStep As Bitmap = Nothing
		Dim MonochromeBitMapPath As String
		Dim BitmapMatrix(,) As Boolean
		Dim BorderMatrix(,) As Boolean
		Public Property DearDiary As String
		Public Property CurrentCell As String
		Public Property WhiteBackground As Boolean = True 'Used in the conversion process
		Public DisplayComparison As Boolean = False 'Used to determine whether or not to display the before and after image of the current step


		Public Sub New()
			If Not System.IO.Directory.Exists(IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WorksheetTools\WorksheetPreviewer")) Then
				System.IO.Directory.CreateDirectory(IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WorksheetTools\WorksheetPreviewer"))
			End If
			MonochromeBitMapPath = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WorksheetTools\WorksheetPreviewer\MonochromeBitMap.bmp")
		End Sub

		Public Function Start(ByVal b As Bitmap) As String
			'Determines the multipliers needed to scale the image to make it fit on one page
			DearDiary = "Preparing..."
			HorizontalConversionRatio = 750 / b.Width
			VerticalConversionRatio = Math.Min(Math.Max((970 / b.Height), HorizontalConversionRatio), 1)


			DearDiary = "Reducing to grayscale..."
			GetMonochrome(b) 'Gets a grayscale version of the provided image
			HorizontalConversionRatio = 750 / MonochromeBitMap.Width
			VerticalConversionRatio = Math.Min(Math.Max((970 / MonochromeBitMap.Height), HorizontalConversionRatio), 1)
			borders = New BorderList(MonochromeBitMap) 'Declares the new collection that will store the detected borders.


			'Declares the minimum dimensions accepted for horizontal and vertical borders. 
			'Anything less than this Is filtered out as noise. 
			DearDiary = "Calculating scale..."
			minLengthY = MonochromeBitMap.Height * 0.023
			minLengthX = MonochromeBitMap.Width * 0.048


			DearDiary = "Detecting edges..."
			InitializeBorders() 'Attempts to read the borders from the thresholded pixel data
			borders.CleanHorizontalNoise()
			borders.CleanVerticalNoise()


			'Check whether the image is rotated and correct if needed.
			DearDiary = "Checking rotation..."
			Dim angle = borders.getAngles()
			If (Math.Abs(angle) > 0.25) Then
				DearDiary = "Form in image is not at a right angle. Correcting..."
				borders.Clear()
				Dim newSide As Single = Convert.ToSingle(Math.Sqrt((b.Width * b.Width) + (b.Height * b.Height)))
				Dim newBMP As New Bitmap(newSide, newSide, Imaging.PixelFormat.Format24bppRgb)
				Using g As Graphics = Graphics.FromImage(newBMP)
					g.FillRectangle(Brushes.White, 0, 0, newSide, newSide)
					g.RotateTransform(angle)
					g.TranslateTransform(newSide / 2, newSide / 2)
					g.DrawImage(b, New Point(-b.Width / 2, -b.Height / 2))
				End Using
				GetMonochrome(newBMP)
				HorizontalConversionRatio = 750 / MonochromeBitMap.Width
				VerticalConversionRatio = Math.Min((970 / MonochromeBitMap.Height), HorizontalConversionRatio)
				borders = New BorderList(MonochromeBitMap)
				InitializeBorders()
			End If

			DearDiary = "Removing noise..."
			'MASSIVE TEST
			hideBorders(MonochromeBitMap)

			borders.CompressAll() 'Combines/corrects matching borders, and handles noise removal
			Me.GetImpliedBorders()
			If Verbose Then
				CurrentStep = New Bitmap(MonochromeBitMap.Width, MonochromeBitMap.Height, Imaging.PixelFormat.Format24bppRgb)
				Using g As Graphics = Graphics.FromImage(CurrentStep)
					g.FillRectangle(Brushes.White, 0, 0, MonochromeBitMap.Width, MonochromeBitMap.Height)
					For Each bor As BorderList.Border In borders
						g.DrawLine(Pens.Black, bor.StartPoint, bor.EndPoint)
					Next
				End Using
				CurrentStep.Save(MonochromeBitMapPath.Replace(".bmp", "_Borders.bmp"), Imaging.ImageFormat.MemoryBmp)
			End If

			DearDiary = "Generating Worksheet source code..."
			Dim output = Me.CreateHTML()
			Return output

		End Function

		Private Overloads Function IsBlankRow(y As Integer) As Boolean
			For i As Integer = 1 To MonochromeBitMap.Width - 2
				If BitmapMatrix(i, y) Then
					Return False
				End If
			Next
			Return True
		End Function
		Private Overloads Function IsBlankRow(y As Integer, minimumX As Integer, maximumX As Integer) As Boolean
			For i As Integer = Math.Max(minimumX, 1) To Math.Min(maximumX, MonochromeBitMap.Width - 2)
				If BitmapMatrix(i, y) Then
					Return False
				End If
			Next
			Return True
		End Function

		Private Overloads Function IsBlankColumn(x As Integer) As Boolean
			For i As Integer = 1 To MonochromeBitMap.Height - 2
				If BitmapMatrix(x, i) Then
					Return False
				End If
			Next
			Return True
		End Function
		Private Overloads Function IsBlankColumn(x As Integer, minimumY As Integer, maximumY As Integer) As Boolean
			For i As Integer = Math.Max(minimumY, 1) To Math.Min(maximumY, MonochromeBitMap.Height - 2)
				If BitmapMatrix(x, i) Then
					Return False
				End If
			Next
			Return True
		End Function

		Private Function GetLowerVerticalBound(sourcePoint As Point) As Integer
			If sourcePoint.Y <= 0 Then
				Return 0
			End If
			Dim i As Integer = sourcePoint.Y
			Do While i > 0
				If BitmapMatrix(sourcePoint.X, i) Then
					Return i
				End If
				i -= 1
			Loop
			Return sourcePoint.Y
		End Function

		Private Function GetUpperVerticalBound(sourcePoint As Point) As Integer
			If sourcePoint.Y >= MonochromeBitMap.Height - 1 Then
				Return MonochromeBitMap.Height - 1
			End If
			Dim i As Integer = sourcePoint.Y
			Do While i < MonochromeBitMap.Height - 1
				If BitmapMatrix(sourcePoint.X, i) Then
					Return i
				End If
				i += 1
			Loop
			Return sourcePoint.Y
		End Function

		Private Sub InitializeBorders()
			borders.Clear()
			Dim h As Integer = MonochromeBitMap.Height
			Dim w As Integer = MonochromeBitMap.Width
			Dim l As Integer = 0

			'Check for Vertical Borders
			For i As Integer = 0 To w - 2
				For j As Integer = 0 To h - 2
					If BitmapMatrix(i, j) Then
						l = 1 'set length to 1px
						If j = 0 Then
							Do While ((j + l + 1)) < h And (BitmapMatrix(i, j + l) = True)
								l += 1
							Loop
							If l >= minLengthY Then
								borders.Add(New Point(i, j), New Point(i, j + l - 1))
							End If
						Else
							If (Not BitmapMatrix(i, j - 1)) Then
								Do While (j + l + 1) < h And (BitmapMatrix(i, j + l) = True)
									l += 1
								Loop

								If l >= minLengthY Then
									borders.Add(New Point(i, j), New Point(i, j + l - 1))
								End If
							End If
						End If
					End If
				Next
			Next

			'Check for horizontal Borders
			For j As Integer = 0 To h - 2
				For i As Integer = 0 To w - 2
					If BitmapMatrix(i, j) Then
						l = 1 'set length to 1px
						If i = 0 Then
							Do While (i + l + 1) < w And BitmapMatrix(i + l, j)
								l += 1
							Loop

							If l >= minLengthX Then
								borders.Add(New Point(i, j), New Point(i + l - 1, j))
							End If
						Else
							If (Not BitmapMatrix(i - 1, j)) Then
								Do While (i + l + 1) < w And BitmapMatrix(i + l, j)
									l += 1
								Loop

								If l >= minLengthX Then
									borders.Add(New Point(i, j), New Point(i + l - 1, j))
								End If
							End If
						End If
					End If
				Next
			Next

			'Outer Edge Test
			borders.Add(New Point(1, 1), New Point(1, h - 2))
			borders.Add(New Point(1, 1), New Point(w - 2, 1))
			borders.Add(New Point(w - 2, 1), New Point(w - 2, h - 2))
			borders.Add(New Point(1, h - 2), New Point(w - 2, h - 2))

		End Sub

		''' <summary>
		''' Gets a monochrome version of the provided image.
		''' </summary>
		Private Sub GetMonochrome(b As Bitmap)
			Dim h As Integer = b.Height
			Dim w As Integer = b.Width
			Dim newB As New Bitmap(w, h, Imaging.PixelFormat.Format24bppRgb)
			Dim brightness As Single
			Dim cropFromStartY As Integer = h
			Dim cropFromStartX As Integer = w
			Dim cropFromEndY As Integer = h
			Dim cropFromEndX As Integer = w
			Dim brightest As Byte = 0

			cropFromStartY = h
			cropFromStartX = w
			cropFromEndY = h
			cropFromEndX = w
			Dim brght As Byte
			Using grp = Graphics.FromImage(newB)
				grp.FillRectangle(Brushes.White, 0, 0, newB.Width, newB.Height)
			End Using

			Dim inputBMPBytes As New BitmapByteHelper(b)
			Dim outputBMPBytes As New BitmapByteHelper(newB)

			inputBMPBytes.LockBitmap()
			outputBMPBytes.LockBitmap()

			Dim RowOffset As Integer = inputBMPBytes.RowSizeBytes - (3 * w)

			Dim currentByte As Integer
			For j As Integer = 0 To h - 1
				For i As Integer = 0 To w - 1
					' Process the pixel's bytes.
					brght = &H0
					currentByte = (j * (w * 3 + RowOffset)) + (i * 3)
					brightness = 0
					For k As Integer = 0 To 2 Step 1
						brightness += inputBMPBytes.ImageBytes(currentByte + k)
					Next
					brght = Convert.ToByte(Math.Round(brightness / 3))
					brightest = Math.Max(brightest, brght)

					''TEST
					If brght > &HF0 Then brght = &HFF
					''TEST

					For k As Integer = 0 To 2 Step 1
						outputBMPBytes.ImageBytes(currentByte + k) = brght
					Next
					If i < cropFromStartX And brght < Convert.ToByte(&HE6) Then cropFromStartX = i
					If j < cropFromStartY And brght < Convert.ToByte(&HE6) Then cropFromStartY = j
				Next
			Next
			For j As Integer = h - 1 To 0 Step -1
				For i As Integer = w - 1 To 0 Step -1
					currentByte = (j * (w * 3 + RowOffset)) + (i * 3)
					brght = outputBMPBytes.ImageBytes(currentByte)
					If (w - i - 1) < cropFromEndX And brght < Convert.ToByte(&HE6) Then cropFromEndX = (w - i - 1)
					If (h - j - 1) < cropFromEndY And brght < Convert.ToByte(&HE6) Then cropFromEndY = (h - j - 1)
				Next
			Next

			'Checks if image resulting from crop would be larger than 100 x 100
			If (newB.Width - cropFromStartX - cropFromEndX) < 100 Or (newB.Height - cropFromStartY - cropFromEndY) < 100 Then
				'If crop would produce an image smaller than 100 x 100, do not crop
				cropFromStartX = 0
				cropFromStartY = 0
				cropFromEndX = 0
				cropFromEndY = 0
			End If

			'START THRESHOLD
			'START THRESHOLD
			'START THRESHOLD
			'START THRESHOLD
			'START THRESHOLD
			Dim matrixW As Integer = (newB.Width - cropFromStartX - cropFromEndX) + 1
			Dim matrixH As Integer = (newB.Height - cropFromStartY - cropFromEndY) + 1
			ReDim BitmapMatrix(matrixW, matrixH)
			'ReDim BitmapMatrix(newB.Width, newB.Height)
			Dim brt As Double = 0

			'This sets the pixels on the edge of the image as white
			For i As Integer = 0 To matrixW - 1
				BitmapMatrix(i, 0) = False
				BitmapMatrix(i, matrixH - 1) = False
			Next
			For j As Integer = 0 To matrixH - 1
				BitmapMatrix(0, j) = False
				BitmapMatrix(matrixW - 1, j) = False
			Next

			'This iterates over the pixels in the image and checks their brightness against their neighbors. 
			'If the contrast between the pixel and one of its neighbors exceeds the minimum requirement, the pixel is set as black. 
			Dim topLeft As Integer = 0
			Dim topCenter As Integer = 0
			Dim topRight As Integer = 0
			Dim middleLeft As Integer = 0
			Dim middleRight As Integer = 0
			Dim bottomLeft As Integer = 0
			Dim bottomCenter As Integer = 0
			Dim bottomRight As Integer = 0
            For j As Integer = cropFromStartY To cropFromStartY + matrixH - 2
                For i As Integer = cropFromStartX To cropFromStartX + matrixW - 2
                    currentByte = (j * (w * 3 + RowOffset)) + (i * 3)
                    If j = 0 And cropFromStartY = 0 Then
                        topLeft = currentByte
                        topCenter = currentByte
                        topRight = currentByte
                    ElseIf j = 1 And i = 0 Then
                        topLeft = ((j - 1) * (w * 3 + RowOffset)) + ((i - 1) * 3)
                        topCenter = ((j - 1) * (w * 3 + RowOffset)) + (i * 3)
                        topRight = ((j - 1) * (w * 3 + RowOffset)) + ((i + 1) * 3)
                    Else
                        topLeft = ((j - 1) * (w * 3 + RowOffset)) + ((i - 1) * 3)
                        topCenter = ((j - 1) * (w * 3 + RowOffset)) + (i * 3)
                        topRight = ((j - 1) * (w * 3 + RowOffset)) + ((i + 1) * 3)
                    End If
                    If j = (cropFromStartY + matrixH - 2) And cropFromEndY = 0 Then
                        bottomLeft = currentByte
                        bottomCenter = currentByte
                        bottomRight = currentByte
                    Else
                        bottomLeft = ((j + 1) * (w * 3 + RowOffset)) + ((i - 1) * 3)
                        bottomCenter = ((j + 1) * (w * 3 + RowOffset)) + (i * 3)
                        bottomRight = ((j + 1) * (w * 3 + RowOffset)) + ((i + 1) * 3)
                    End If
                    If i = 0 And cropFromStartX = 0 Then
                        middleLeft = currentByte
                        middleRight = (j * (w * 3 + RowOffset)) + ((i + 1) * 3)
                    Else
                        middleLeft = (j * (w * 3 + RowOffset)) + ((i - 1) * 3)
                        middleRight = (j * (w * 3 + RowOffset)) + ((i + 1) * 3)
                    End If
                    brt = Convert.ToDouble(outputBMPBytes.ImageBytes(currentByte)) / 255

                    If ((Convert.ToDouble(outputBMPBytes.ImageBytes(topLeft)) / 255) - brt) > threshhold Or
                        ((Convert.ToDouble(outputBMPBytes.ImageBytes(topCenter)) / 255) - brt) > threshhold Or
                        ((Convert.ToDouble(outputBMPBytes.ImageBytes(topRight)) / 255) - brt) > threshhold Or
                        ((Convert.ToDouble(outputBMPBytes.ImageBytes(middleLeft)) / 255) - brt) > threshhold Or
                        ((Convert.ToDouble(outputBMPBytes.ImageBytes(middleRight)) / 255) - brt) > threshhold Or
                        ((Convert.ToDouble(outputBMPBytes.ImageBytes(bottomLeft)) / 255) - brt) > threshhold Or
                        ((Convert.ToDouble(outputBMPBytes.ImageBytes(bottomCenter)) / 255) - brt) > threshhold Or
                        ((Convert.ToDouble(outputBMPBytes.ImageBytes(bottomRight)) / 255) - brt) > threshhold Or
                        (WhiteBackground = True And brt < 0.2) Then

                        BitmapMatrix(i - cropFromStartX + 1, j - cropFromStartY + 1) = True

                    Else

                        ''TEST'
                        'If (((Convert.ToDouble(outputBMPBytes.ImageBytes(topLeft)) / 255) - brt) > 0 Or
                        '((Convert.ToDouble(outputBMPBytes.ImageBytes(topCenter)) / 255) - brt) > 0 Or
                        '((Convert.ToDouble(outputBMPBytes.ImageBytes(topRight)) / 255) - brt) > 0 Or
                        '((Convert.ToDouble(outputBMPBytes.ImageBytes(middleLeft)) / 255) - brt) > 0 Or
                        '((Convert.ToDouble(outputBMPBytes.ImageBytes(middleRight)) / 255) - brt) > 0 Or
                        '((Convert.ToDouble(outputBMPBytes.ImageBytes(bottomLeft)) / 255) - brt) > 0 Or
                        '((Convert.ToDouble(outputBMPBytes.ImageBytes(bottomCenter)) / 255) - brt) > 0 Or
                        '((Convert.ToDouble(outputBMPBytes.ImageBytes(bottomRight)) / 255) - brt) > 0) And
                        '(WhiteBackground = True And brt > 0.85) Then
                        '	outputBMPBytes.ImageBytes(currentByte) = &HFF
                        '	outputBMPBytes.ImageBytes(currentByte + 1) = &HFF
                        '	outputBMPBytes.ImageBytes(currentByte + 2) = &HFF

                        'ElseIf (CInt(Int(Convert.ToDouble(outputBMPBytes.ImageBytes(topLeft) > 250))) +
                        'CInt(Int(Convert.ToDouble(outputBMPBytes.ImageBytes(topCenter) > 250))) +
                        'CInt(Int(Convert.ToDouble(outputBMPBytes.ImageBytes(topRight) > 250))) +
                        'CInt(Int(Convert.ToDouble(outputBMPBytes.ImageBytes(middleLeft) > 250))) +
                        'CInt(Int(Convert.ToDouble(outputBMPBytes.ImageBytes(middleRight) > 250))) +
                        'CInt(Int(Convert.ToDouble(outputBMPBytes.ImageBytes(bottomLeft) > 250))) +
                        'CInt(Int(Convert.ToDouble(outputBMPBytes.ImageBytes(bottomCenter) > 250))) +
                        'CInt(Int(Convert.ToDouble(outputBMPBytes.ImageBytes(bottomRight) > 250))) > 7) And
                        'WhiteBackground = True Then
                        '	outputBMPBytes.ImageBytes(currentByte) = &HFF
                        '	outputBMPBytes.ImageBytes(currentByte + 1) = &HFF
                        '	outputBMPBytes.ImageBytes(currentByte + 2) = &HFF
                        'End If
                        ''TEST'

                        BitmapMatrix(i - cropFromStartX + 1, j - cropFromStartY + 1) = False

                    End If

                Next
            Next

            ''Noise removal test. This should in theory remove random noise pixels.
            ''Reasonably successful for dirty images, but can result in a loss of detail for clean images. Need a means of identifying dirty images, and only applying this when the test comes back true. 
            'For n As Integer = 0 To 8
            '	For j As Integer = cropFromStartY To cropFromStartY + matrixH - 2
            '		For i As Integer = cropFromStartX To cropFromStartX + matrixW - 2
            '			currentByte = (j * (w * 3 + RowOffset)) + (i * 3)
            '			If j = 0 And cropFromStartY = 0 Then
            '				topLeft = currentByte
            '				topCenter = currentByte
            '				topRight = currentByte
            '			Else
            '				topLeft = ((j - 1) * (w * 3 + RowOffset)) + ((i - 1) * 3)
            '				topCenter = ((j - 1) * (w * 3 + RowOffset)) + (i * 3)
            '				topRight = ((j - 1) * (w * 3 + RowOffset)) + ((i + 1) * 3)
            '			End If
            '			If j = (cropFromStartY + matrixH - 2) And cropFromEndY = 0 Then
            '				bottomLeft = currentByte
            '				bottomCenter = currentByte
            '				bottomRight = currentByte
            '			Else
            '				bottomLeft = ((j + 1) * (w * 3 + RowOffset)) + ((i - 1) * 3)
            '				bottomCenter = ((j + 1) * (w * 3 + RowOffset)) + (i * 3)
            '				bottomRight = ((j + 1) * (w * 3 + RowOffset)) + ((i + 1) * 3)
            '			End If
            '			middleLeft = (j * (w * 3 + RowOffset)) + ((i - 1) * 3)
            '			middleRight = (j * (w * 3 + RowOffset)) + ((i + 1) * 3)

            '			If (CInt(Int(Convert.ToDouble(outputBMPBytes.ImageBytes(topLeft) > 250))) +
            '			CInt(Int(Convert.ToDouble(outputBMPBytes.ImageBytes(topCenter) > 250))) +
            '			CInt(Int(Convert.ToDouble(outputBMPBytes.ImageBytes(topRight) > 250))) +
            '			CInt(Int(Convert.ToDouble(outputBMPBytes.ImageBytes(middleLeft) > 250))) +
            '			CInt(Int(Convert.ToDouble(outputBMPBytes.ImageBytes(middleRight) > 250))) +
            '			CInt(Int(Convert.ToDouble(outputBMPBytes.ImageBytes(bottomLeft) > 250))) +
            '			CInt(Int(Convert.ToDouble(outputBMPBytes.ImageBytes(bottomCenter) > 250))) +
            '			CInt(Int(Convert.ToDouble(outputBMPBytes.ImageBytes(bottomRight) > 250))) >= 7) And
            '			Convert.ToDouble(outputBMPBytes.ImageBytes(currentByte)) > 50 And
            '			WhiteBackground = True Then

            '				outputBMPBytes.ImageBytes(currentByte) = &HFF
            '				outputBMPBytes.ImageBytes(currentByte + 1) = &HFF
            '				outputBMPBytes.ImageBytes(currentByte + 2) = &HFF

            '			End If

            '		Next
            '	Next
            'Next
            ''END Noise removal test.
            'END THRESHOLD
            'END THRESHOLD
            'END THRESHOLD
            'END THRESHOLD
            'END THRESHOLD

            ' Unlock the bitmap.
            outputBMPBytes.UnlockBitmap()
			inputBMPBytes.UnlockBitmap()

			newB = crop(newB, cropFromStartX, cropFromStartY, cropFromEndX, cropFromEndY) 'Crop image


			''This can be used to output an HTML file with image code embedded directly, rather than needing a url
			'Dim ms = New IO.MemoryStream()
			'newB.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg) ' Use appropriate format here
			'Dim imgData = String.Format("data:image/bmp;base64,{0}", Convert.ToBase64String(ms.ToArray()))
			'imgData = "<html><img src=""" & imgData & """ width=""750px"" /></html>"
			'Using tw = IO.File.CreateText("C:\Users\SMaxson\Desktop\Worksheets\Science\htmlImgData.html")
			'	tw.Write(imgData)
			'End Using

			newB.Save(MonochromeBitMapPath, Imaging.ImageFormat.MemoryBmp)
			MonochromeBitMap = newB
		End Sub

		''' <summary>
		''' Crops the provided image.
		''' </summary>
		Private Function crop(bmp As Bitmap, left As Integer, top As Integer, right As Integer, bottom As Integer)
			Dim CropRect As New Rectangle(left, top, bmp.Width - left - right, bmp.Height - top - bottom)
			Dim CropImage = New Bitmap(CropRect.Width + 2, CropRect.Height + 2)
			Using grp = Graphics.FromImage(CropImage)
				grp.FillRectangle(Brushes.White, 0, 0, CropImage.Width, CropImage.Height)
				grp.DrawImage(bmp, New Rectangle(1, 1, CropRect.Width, CropRect.Height), CropRect, GraphicsUnit.Pixel)
				bmp.Dispose()
			End Using
			Return CropImage
		End Function


		''' <summary>
		''' Gets a monochrome version of the provided image.
		''' </summary>
		Private Sub hideBorders(b As Bitmap)
			Dim h As Integer = b.Height
			Dim w As Integer = b.Width
			Dim newB As New Bitmap(b)

			Dim inputBMPBytes As New BitmapByteHelper(b)
			Dim outputBMPBytes As New BitmapByteHelper(newB)

			inputBMPBytes.LockBitmap()
			outputBMPBytes.LockBitmap()

			Dim RowOffset As Integer = inputBMPBytes.RowSizeBytes - (3 * w)

			Dim currentByte As Integer
			For Each bor As BorderList.Border In borders
				If bor.IsHorizontal Then
					For i As Integer = bor.StartX To bor.EndX - 1
						' Process the pixel's bytes.
						currentByte = (bor.StartY * (w * 3 + RowOffset)) + (i * 3)
						For k As Integer = 0 To 2 Step 1
							outputBMPBytes.ImageBytes(currentByte + k) = &HFF
						Next

						'Clear the horizontal line before the border
						If bor.StartY > 0 Then
							currentByte = ((bor.StartY - 1) * (w * 3 + RowOffset)) + (i * 3)
							For k As Integer = 0 To 2 Step 1
								outputBMPBytes.ImageBytes(currentByte + k) = &HFF
							Next
						End If

						'Clear the horizontal line after the border
						If bor.StartY > 0 Then
							currentByte = ((bor.StartY + 1) * (w * 3 + RowOffset)) + (i * 3)
							For k As Integer = 0 To 2 Step 1
								outputBMPBytes.ImageBytes(currentByte + k) = &HFF
							Next
						End If
					Next
				Else
					For i As Integer = bor.StartY To bor.EndY - 1
						' Process the pixel's bytes.
						currentByte = (i * (w * 3 + RowOffset)) + (bor.StartX * 3)
						For k As Integer = 0 To 2 Step 1
							outputBMPBytes.ImageBytes(currentByte + k) = &HFF
						Next

						'Clear the vertical line before the border
						currentByte = (i * (w * 3 + RowOffset)) + ((bor.StartX - 1) * 3)
						For k As Integer = 0 To 2 Step 1
							outputBMPBytes.ImageBytes(currentByte + k) = &HFF
						Next

						'Clear the vertical line after the border
						currentByte = (i * (w * 3 + RowOffset)) + ((bor.StartX + 1) * 3)
						For k As Integer = 0 To 2 Step 1
							outputBMPBytes.ImageBytes(currentByte + k) = &HFF
						Next
					Next
				End If
			Next

			' Unlock the bitmap.
			outputBMPBytes.UnlockBitmap()
			inputBMPBytes.UnlockBitmap()

			newB.Save(MonochromeBitMapPath.Replace(".bmp", "_HiddenStuff.bmp"), Imaging.ImageFormat.MemoryBmp)
		End Sub

		Private Function GetIntersects() As PointDictionary
			Dim pointList As New List(Of Point)
			pointList = borders.GetIntersections()
			Return pointList
		End Function


		''' <summary>
		''' Finds invisible borders implied by the start or end points of other borders in the collection. 
		''' </summary>
		Public Sub GetImpliedBorders()
			'This is used to find invisible borders implied by the start or end points of other borders. 
			'If multiple borders start or end at the same x coordinate, this area is evaluated to check for an invisible border.
			Dim UniqueStartPoints As New List(Of Integer)
			Dim UniqueEndPoints As New List(Of Integer)
			Dim TargetPerpendicularAxisPoints As New List(Of Integer)
			Dim UniquePerpendicularBorders As New List(Of Integer)

			Dim impliedBorderPrimaryAxisStart As Integer = 0
			Dim impliedBorderPrimaryAxisEnd As Integer = MonochromeBitMap.Height - 1

			Dim TargetBorders As New BorderList()
			Dim PerpendicularBorders As New BorderList()
			Dim SectionClear As Boolean = True

			UniqueStartPoints.Clear()
			UniqueEndPoints.Clear()

			For Each b As BorderList.Border In borders
				If b.IsHorizontal = True Then
					TargetBorders.Add(b)
					If Not (UniqueStartPoints.Contains(b.StartX) _
						Or UniqueStartPoints.Contains(b.StartX - 1) _
						Or UniqueStartPoints.Contains(b.StartX + 1)) Then
						UniqueStartPoints.Add(b.StartX)
					End If
					If Not (UniqueEndPoints.Contains(b.EndX) _
						Or UniqueEndPoints.Contains(b.EndX - 1) _
						Or UniqueEndPoints.Contains(b.EndX + 1)) _
						And b.EndX < MonochromeBitMap.Width - 3 Then
						UniqueEndPoints.Add(b.EndX)
					End If
				Else
					If Not UniquePerpendicularBorders.Contains(b.EndX) Then UniquePerpendicularBorders.Add(b.EndX)
					PerpendicularBorders.Add(b)
				End If
			Next


			'Checks for invisible borders implied by visible start points
			For Each StartPoint In UniqueStartPoints 'Iterates over each unique X Coordinate containing at least one start point
				TargetPerpendicularAxisPoints.Clear()
				For Each b In TargetBorders 'Creates a list of all borders whose starting x position are within 1 pixel of the currently selected coordinate.
					If Math.Abs(b.StartX - StartPoint) <= 1 Then TargetPerpendicularAxisPoints.Add(b.StartY)
				Next
				TargetPerpendicularAxisPoints.Sort() 'Sorts the Points of Interest on the Y-Axis based on ascending value

				For x = TargetPerpendicularAxisPoints.Count - 1 To 1 Step -1 'Checks for borders between the points on this list. Clears out the rejects.
					For i As Integer = TargetPerpendicularAxisPoints(x - 1) + 1 To TargetPerpendicularAxisPoints(x) - 1
						If BitmapMatrix(StartPoint, i) Then
							TargetPerpendicularAxisPoints.RemoveAt(x)
							Exit For
						End If
					Next
				Next

				impliedBorderPrimaryAxisStart = TargetPerpendicularAxisPoints.First 'Initializes Starting Y Position of implied border to the lowest Y Position from the collection of Y Values of interest for the current X Value
				impliedBorderPrimaryAxisEnd = TargetPerpendicularAxisPoints.Last 'Initializes Ending Y Position of implied border to the highest Y Position from the collection of Y Values of interest for the current X Value
				If TargetPerpendicularAxisPoints.Count > 1 Then
					For Each b In TargetBorders
						If b.StartX <= (StartPoint - 1) _
							And b.EndX >= (StartPoint) Then
							If b.EndY < impliedBorderPrimaryAxisStart Then
								SectionClear = True
								'For i As Integer = b.EndY + 1 To impliedBorderPrimaryAxisStart - 1
								For i As Integer = b.EndY + (0.1 * (impliedBorderPrimaryAxisStart - b.EndY)) To impliedBorderPrimaryAxisStart
									If BitmapMatrix(StartPoint - 1, i) Then
										SectionClear = False
										Exit For
									End If
								Next
								If SectionClear Then impliedBorderPrimaryAxisStart = b.EndY
							ElseIf b.EndY > impliedBorderPrimaryAxisEnd Then
								SectionClear = True
								'For i As Integer = impliedBorderPrimaryAxisEnd + 1 To b.EndY - 1
								For i As Integer = impliedBorderPrimaryAxisEnd To impliedBorderPrimaryAxisEnd + (0.9 * (b.EndY - impliedBorderPrimaryAxisEnd))
									If BitmapMatrix(StartPoint - 1, i) Then
										SectionClear = False
										Exit For
									End If
								Next
								If SectionClear Then impliedBorderPrimaryAxisEnd = b.EndY
							End If
						End If
					Next
					If Not impliedBorderPrimaryAxisStart = impliedBorderPrimaryAxisEnd Then borders.Add(New Point(StartPoint, impliedBorderPrimaryAxisStart), New Point(StartPoint, impliedBorderPrimaryAxisEnd))
				End If
			Next

			'Checks for invisible borders implied by visible end points 
			For Each EndPoint In UniqueEndPoints 'Iterates over each unique X Coordinate containing at least one end point
				TargetPerpendicularAxisPoints.Clear()
				For Each b In TargetBorders 'Creates a list of all borders whose ending x position are within 1 pixel of the currently selected coordinate.
					If Math.Abs(b.EndX - EndPoint) <= 1 Then TargetPerpendicularAxisPoints.Add(b.EndY)
				Next
				TargetPerpendicularAxisPoints.Sort() 'Sorts the Points of Interest on the Y-Axis based on ascending value

				For x = TargetPerpendicularAxisPoints.Count - 1 To 1 Step -1 'Checks for borders between the points on this list. Clears out the rejects.
					For i As Integer = TargetPerpendicularAxisPoints(x - 1) + 1 To TargetPerpendicularAxisPoints(x) - 1
						If BitmapMatrix(EndPoint, i) Then
							TargetPerpendicularAxisPoints.RemoveAt(x)
							Exit For
						End If
					Next
				Next

				impliedBorderPrimaryAxisStart = TargetPerpendicularAxisPoints.First
				impliedBorderPrimaryAxisEnd = TargetPerpendicularAxisPoints.Last
				If TargetPerpendicularAxisPoints.Count > 1 Then
					For Each b In TargetBorders
						If b.StartX <= (EndPoint) _
							And b.EndX >= (EndPoint + 1) Then
							If b.EndY < impliedBorderPrimaryAxisStart Then
								SectionClear = True
								'For i As Integer = b.EndY To impliedBorderPrimaryAxisStart
								'If BitmapMatrix(EndPoint + 1, i) And i > b.EndY + (0.1 * (impliedBorderPrimaryAxisStart - b.EndY)) Then
								For i As Integer = b.EndY + (0.1 * (impliedBorderPrimaryAxisStart - b.EndY)) To impliedBorderPrimaryAxisStart - 1
									If BitmapMatrix(EndPoint + 1, i) Then
										SectionClear = False
										Exit For
									End If
								Next
								If SectionClear Then impliedBorderPrimaryAxisStart = b.EndY
							ElseIf b.EndY > impliedBorderPrimaryAxisEnd Then
								SectionClear = True
								'For i As Integer = impliedBorderPrimaryAxisEnd To b.EndY
								'If BitmapMatrix(EndPoint + 1, i) And i < impliedBorderPrimaryAxisEnd + (0.9 * (b.EndY - impliedBorderPrimaryAxisEnd)) Then
								For i As Integer = impliedBorderPrimaryAxisEnd + 1 To impliedBorderPrimaryAxisEnd + (0.9 * (b.EndY - impliedBorderPrimaryAxisEnd))
									If BitmapMatrix(EndPoint + 1, i) Then
										SectionClear = False
										Exit For
									End If
								Next
								If SectionClear Then impliedBorderPrimaryAxisEnd = b.EndY
							End If
						End If
					Next
					borders.Add(New Point(EndPoint, impliedBorderPrimaryAxisStart), New Point(EndPoint, impliedBorderPrimaryAxisEnd))
				End If
			Next

			borders.GetIntersections()

		End Sub

		''' <summary>
		''' Generates and returns the HTML source code for the document. 
		''' </summary>
		''' <param name="IsLandscape">States whether the output should be landscape, and scales it accordingly.</param>
		''' <returns></returns>
		Private Function CreateHTML(Optional IsLandscape As Boolean = False) As String
			Dim htmlOutput As String = ""
			Dim scale As Integer = 4 'This determines the scaling factor for the image. In most cases, a larger number means more accurate output
			Dim Converter As New Tesseract.BitmapToPixConverter
			Dim ScaledImage = Converter.Convert(MonochromeBitMap).Scale(scale, scale) 'Scales size. Often results in better output
			Dim currentLine As New TextLine
			Dim Paragraphs As Paragraphs
			Dim TextModificationStorage As String

			Using tess = New Tesseract.TesseractEngine("C:\Projects\WorksheetsGit\.WorksheetTools\Program Files (Do Not Modify)\Tesseract.3.0.2.0\tessdata", "eng", Tesseract.EngineMode.TesseractAndCube, "C:\Projects\WorksheetsGit\.WorksheetTools\Program Files (Do Not Modify)\Tesseract.3.0.2.0\tessdata\config.txt")
                'Using page As Tesseract.Page = tess.Process(ScaledImage, Tesseract.PageSegMode.Auto)
                Using page As Tesseract.Page = tess.Process(ScaledImage, Tesseract.PageSegMode.AutoOsd)
                    '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                    'Transform v2.0. Uses the new ConverterTable classes.
                    '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                    Dim MasterTable As ConverterTable = borders.GetLayout
                    Dim TotalCells As Integer = 0
                    Dim CurrentPosition As Integer = 0
                    For Each r In MasterTable.Rows
                        TotalCells += r.Cells.Count
                    Next
                    Dim CurrentBoundingBox As Tesseract.Rect
                    htmlOutput = "<style>" & vbCrLf
                    htmlOutput &= "	td{padding:2px;}" & vbCrLf
                    htmlOutput &= "	.b{border:1px solid black;}" & vbCrLf
                    htmlOutput &= "	.br{border-right:1px solid black;}" & vbCrLf
                    htmlOutput &= "	.bl{border-left:1px solid black;}" & vbCrLf
                    htmlOutput &= "	.bt{border-top:1px solid black;}" & vbCrLf
                    htmlOutput &= "	.bb{border-bottom:1px solid black;}" & vbCrLf
                    htmlOutput &= "</style>" & vbCrLf
                    htmlOutput &= "<div style=""width:750px;"">" & vbCrLf
                    htmlOutput &= "	<table style=""width:100%; border-collapse: collapse; font-family:arial; font-size:12px; table-layout:fixed;"">" & vbCrLf
                    htmlOutput &= "		<tr>" & vbCrLf
                    For i As Integer = 0 To MasterTable.ColumnWidthsPercentage.Count - 1
                        htmlOutput &= String.Format("			<td style=""width:{0}%; line-height:0px;"">&#160;</td>", Math.Round(MasterTable.ColumnWidthsPercentage(i), 2).ToString)
                        htmlOutput &= vbCrLf
                    Next
                    htmlOutput &= "		</tr>" & vbCrLf

                    Dim additionalAttributes As String 'For use with the TD's rowspan and colspan
                    Dim tdStyleString As String 'For use with the TD CSS


                    'This iterates over every row in the table
                    For Each row As ConverterRow In MasterTable.Rows
                        htmlOutput &= String.Format("		<tr style=""height:{0}px;"">", Math.Round(row.Height * VerticalConversionRatio))
                        htmlOutput &= vbCrLf

                        'This iterates over each cell in the given row.
                        For Each cell As ConverterCell In row.Cells
                            If cell.RowSpan > 0 And cell.ColSpan > 0 Then
                                CurrentPosition += 1 'Increment current cell index
                                Me.CurrentCell = CurrentPosition & "/" & TotalCells 'Store current progress
                                additionalAttributes = "" 'Initialize additional attributes for this cell
                                tdStyleString = " " 'Initialize CSS for this cell
                                page.RegionOfInterest = New Tesseract.Rect((cell.Rectangle.X + 2) * scale, (cell.Rectangle.Y + 2) * scale, (cell.Rectangle.Width - 2) * scale, (cell.Rectangle.Height - 2) * scale) 'Accommodates for the scaling
                                If cell.ColSpan > 1 Then additionalAttributes &= String.Format(" colspan=""{0}""", cell.ColSpan)
                                If cell.RowSpan > 1 Then additionalAttributes &= String.Format(" rowspan=""{0}""", cell.RowSpan)

                                'Check Cell Borders
                                'LEFT
                                If CInt(Int(BitmapMatrix(cell.Left, cell.Top + 2) Or BitmapMatrix(cell.Left - 1, cell.Top + 2) Or BitmapMatrix(cell.Left + 1, cell.Top + 2))) _
                                    + CInt(Int(BitmapMatrix(cell.Left, cell.Top + Math.Round(cell.Height / 2)) Or BitmapMatrix(cell.Left - 1, cell.Top + Math.Round(cell.Height / 2)) Or BitmapMatrix(cell.Left + 1, cell.Top + Math.Round(cell.Height / 2)))) _
                                    + CInt(Int(BitmapMatrix(cell.Left, cell.Bottom - 2) Or BitmapMatrix(cell.Left - 1, cell.Bottom - 2) Or BitmapMatrix(cell.Left + 1, cell.Bottom - 2))) < 3 _
                                    Then cell.BorderLeftWidth = 0
                                'TOP
                                If CInt(Int(BitmapMatrix(cell.Left + 1, cell.Top) Or BitmapMatrix(cell.Left + 1, cell.Top - 1) Or BitmapMatrix(cell.Left + 1, cell.Top + 1))) _
                                    + CInt(Int(BitmapMatrix(cell.Left + Math.Round(cell.Width / 2), cell.Top) Or BitmapMatrix(cell.Left + Math.Round(cell.Width / 2), cell.Top - 1) Or BitmapMatrix(cell.Left + Math.Round(cell.Width / 2), cell.Top + 1))) _
                                    + CInt(Int(BitmapMatrix(cell.Right - 1, cell.Top) Or BitmapMatrix(cell.Right - 1, cell.Top - 1) Or BitmapMatrix(cell.Right - 1, cell.Top + 1))) < 3 _
                                    Then cell.BorderTopWidth = 0
                                'RIGHT
                                If CInt(Int(BitmapMatrix(cell.Right, cell.Top + 2) Or BitmapMatrix(cell.Right - 1, cell.Top + 2) Or BitmapMatrix(cell.Right + 1, cell.Top + 2))) _
                                    + CInt(Int(BitmapMatrix(cell.Right, cell.Top + Math.Round(cell.Height / 2)) Or BitmapMatrix(cell.Right - 1, cell.Top + Math.Round(cell.Height / 2)) Or BitmapMatrix(cell.Right + 1, cell.Top + Math.Round(cell.Height / 2)))) _
                                    + CInt(Int(BitmapMatrix(cell.Right, cell.Bottom - 2) Or BitmapMatrix(cell.Right - 1, cell.Bottom - 2) Or BitmapMatrix(cell.Right + 1, cell.Bottom - 2))) < 3 _
                                    Then cell.BorderRightWidth = 0
                                'BOTTOM
                                If CInt(Int(BitmapMatrix(cell.Left + 2, cell.Bottom) Or BitmapMatrix(cell.Left + 2, cell.Bottom - 1) Or BitmapMatrix(cell.Left + 2, cell.Bottom + 1))) _
                                    + CInt(Int(BitmapMatrix(cell.Left + Math.Round(cell.Width / 2), cell.Bottom) Or BitmapMatrix(cell.Left + Math.Round(cell.Width / 2), cell.Bottom - 1) Or BitmapMatrix(cell.Left + Math.Round(cell.Width / 2), cell.Bottom + 1))) _
                                    + CInt(Int(BitmapMatrix(cell.Right - 2, cell.Bottom) Or BitmapMatrix(cell.Right - 2, cell.Bottom - 1) Or BitmapMatrix(cell.Right - 2, cell.Bottom + 1))) < 3 _
                                    Then cell.BorderBottomWidth = 0


                                ''Cell Borders CSS
                                'If cell.BorderLeftWidth >= cell.BorderTopWidth _
                                '	And cell.BorderTopWidth >= cell.BorderRightWidth _
                                '	And cell.BorderRightWidth >= cell.BorderBottomWidth Then
                                '	If cell.BorderLeftWidth > 0 Then tdStyleString &= String.Format(" border:{0}px solid black;", cell.BorderLeftWidth)
                                'Else
                                '	If cell.BorderLeftWidth > 0 Then tdStyleString &= String.Format(" border-left:{0}px solid black;", cell.BorderLeftWidth)
                                '	If cell.BorderTopWidth > 0 Then tdStyleString &= String.Format(" border-top:{0}px solid black;", cell.BorderTopWidth)
                                '	If cell.BorderRightWidth > 0 Then tdStyleString &= String.Format(" border-right:{0}px solid black;", cell.BorderRightWidth)
                                '	If cell.BorderBottomWidth > 0 Then tdStyleString &= String.Format(" border-bottom:{0}px solid black;", cell.BorderBottomWidth)
                                'End If

                                If page.RegionOfInterest.Height > 10 And page.RegionOfInterest.Width > 10 Then


                                    'This is for a test concerning inputs
                                    If cell.Rectangle.Height > 100 Or cell.Rectangle.Width > 100 Then cell.ContainedBorders = borders.GetHorizontalBordersInArea(cell.Rectangle)


                                    Using iter = page.GetIterator
                                        iter.Begin()
                                        Do 'Iterate over blocks in selected cell

                                            Do 'Iterate over paragraphs in selected block
                                                Paragraphs = New Paragraphs
                                                Paragraphs.Add(New Paragraph)

                                                Do 'Iterate over lines in selected paragraph
                                                    If Not IsNothing(iter.GetText(Tesseract.PageIteratorLevel.TextLine)) Then
                                                        currentLine = New TextLine

                                                        If iter.TryGetBoundingBox(Tesseract.PageIteratorLevel.TextLine, CurrentBoundingBox) Then
                                                            If (Math.Abs((CurrentBoundingBox.X1 / scale) - cell.Left)) - Math.Abs(cell.Right + scale - (CurrentBoundingBox.X2 / scale)) > 10 Then
                                                                currentLine.TextAlign = CellAlignHorizontal.Right
                                                            ElseIf ((CurrentBoundingBox.X1 / scale) + scale - cell.Left) < (cell.Right - (CurrentBoundingBox.X2 / scale)) Then
                                                                currentLine.TextAlign = CellAlignHorizontal.Left
                                                            ElseIf ((CurrentBoundingBox.X1 / scale) - cell.Left) > 10 Then
                                                                currentLine.TextAlign = CellAlignHorizontal.Center
                                                            End If

                                                            currentLine.BoundingBox = New Rectangle(
                                                                    Math.Round((CurrentBoundingBox.X1 / scale) * HorizontalConversionRatio),
                                                                    Math.Round((CurrentBoundingBox.Y1 / scale) * VerticalConversionRatio),
                                                                    Math.Round((CurrentBoundingBox.Width / scale) * HorizontalConversionRatio),
                                                                    Math.Round((CurrentBoundingBox.Height / scale) * VerticalConversionRatio)
                                                                )
                                                        End If

                                                        If cell.ContainedBorders.Count > 1 Then 'Checks to see if there is more than one horizontal border contained in the current cell
                                                            Do
                                                                If Not IsNothing(iter.GetText(Tesseract.PageIteratorLevel.Word)) Then
                                                                    Dim tempString As String = iter.GetText(Tesseract.PageIteratorLevel.Word).Trim
                                                                    If tempString.Length > 0 Then
                                                                        currentLine.Words.Add(New OCRWord(tempString, 12))
                                                                        If Not IsNothing(iter.GetWordFontAttributes) Then
                                                                            'currentLine.FontSize = Math.Round((Math.Pow(iter.GetWordFontAttributes.PointSize, 0.95) / scale) * VerticalConversionRatio)
                                                                            With currentLine.Words.Last
                                                                                '.FontSize = Math.Round(Math.Pow((iter.GetWordFontAttributes.PointSize / scale), 0.95))
                                                                                .FontSize = Math.Round((Math.Pow(iter.GetWordFontAttributes.PointSize, 0.95) / scale) * VerticalConversionRatio)
                                                                                .IsBold = iter.GetWordFontAttributes.FontInfo.IsBold
                                                                                If iter.TryGetBoundingBox(Tesseract.PageIteratorLevel.Word, CurrentBoundingBox) Then
                                                                                    '.BoundingBox = New Rectangle(
                                                                                    '		Math.Round((CurrentBoundingBox.X1 / scale) * HorizontalConversionRatio),
                                                                                    '		Math.Round((CurrentBoundingBox.Y1 / scale) * VerticalConversionRatio),
                                                                                    '		Math.Round((CurrentBoundingBox.Width / scale) * HorizontalConversionRatio),
                                                                                    '		Math.Round((CurrentBoundingBox.Height / scale) * VerticalConversionRatio)
                                                                                    '	)
                                                                                    .BoundingBox = New Rectangle(
                                                                                            Math.Round(CurrentBoundingBox.X1 / scale),
                                                                                            Math.Round(CurrentBoundingBox.Y1 / scale),
                                                                                            Math.Round(CurrentBoundingBox.Width / scale),
                                                                                            Math.Round(CurrentBoundingBox.Height / scale)
                                                                                        )
                                                                                End If
                                                                            End With
                                                                            If Paragraphs.Lines.Count > 0 And Paragraphs.Last.Lines.Count > 0 Then
                                                                                If Math.Abs(currentLine.FontSize - Paragraphs.Last.Lines.Last.FontSize) >= 2 Then
                                                                                    Paragraphs.Add(New Paragraph)
                                                                                End If
                                                                            End If
                                                                            currentLine.FontSize = 12
                                                                        Else
                                                                            currentLine.FontSize = 12
                                                                        End If
                                                                    End If
                                                                End If
                                                            Loop While iter.Next(Tesseract.PageIteratorLevel.TextLine, Tesseract.PageIteratorLevel.Word)
                                                        Else
                                                            currentLine.Text = vbCrLf & String.Format("					{0}", iter.GetText(Tesseract.PageIteratorLevel.TextLine).Trim)
                                                            iter.Next(Tesseract.PageIteratorLevel.TextLine, Tesseract.PageIteratorLevel.Word)

                                                            If Not IsNothing(iter.GetWordFontAttributes) Then
                                                                currentLine.FontSize = Math.Round((Math.Pow(iter.GetWordFontAttributes.PointSize, 0.95) / scale) * VerticalConversionRatio)
                                                                'currentLine.FontSize = Math.Round(Math.Pow((iter.GetWordFontAttributes.PointSize / scale), 0.95))
                                                                If Paragraphs.Lines.Count > 0 And Paragraphs.Last.Lines.Count > 0 Then
                                                                    If Math.Abs(currentLine.FontSize - Paragraphs.Last.Lines.Last.FontSize) >= 2 Then
                                                                        Paragraphs.Add(New Paragraph)
                                                                    End If
                                                                End If
                                                            Else
                                                                currentLine.FontSize = 12
                                                            End If
                                                        End If
                                                        'Checks for common symbol misreads
                                                        If currentLine.Text.Trim.Length > 0 Then
                                                            TextModificationStorage = currentLine.Text.TrimEnd

                                                            If TextModificationStorage.Length = 1 Then
                                                                Select Case TextModificationStorage.ToLower
                                                                    Case "s"
                                                                        TextModificationStorage = "$"
                                                                End Select
                                                            End If

                                                            TextModificationStorage = RegularExpressions.Regex.Replace(TextModificationStorage, ",(?=[a-z, A-Z]+)", ", ")
                                                            TextModificationStorage = RegularExpressions.Regex.Replace(TextModificationStorage, "(?<=\d+)\s*,\s*(?=\d+)", ",")
                                                            TextModificationStorage = RegularExpressions.Regex.Replace(TextModificationStorage, "(?<=\d+)\s*\.\s*(?=\d+)", ".")
                                                            TextModificationStorage = RegularExpressions.Regex.Replace(TextModificationStorage, "(?<=\d+)\s(?=\d+)", "")
                                                            TextModificationStorage = RegularExpressions.Regex.Replace(TextModificationStorage, "(?<=[B-H,J-Z])\s+(?=[a-z]+)", "")
                                                            TextModificationStorage = RegularExpressions.Regex.Replace(TextModificationStorage, "\s+[Il\|1]$", "")
                                                            TextModificationStorage = RegularExpressions.Regex.Replace(TextModificationStorage, """/INtt", "VIN #")
                                                            TextModificationStorage = TextModificationStorage.Replace(" tt", " #")

                                                            currentLine.Text = TextModificationStorage
                                                        End If

                                                        Paragraphs.Last.Add(currentLine)
                                                        Paragraphs.Last.FontSize = currentLine.FontSize

                                                        Paragraphs.Last.TextAlign = currentLine.TextAlign
                                                    End If
                                                Loop While iter.Next(Tesseract.PageIteratorLevel.Para, Tesseract.PageIteratorLevel.TextLine)

                                                For Each par In Paragraphs 'Iterate over all paragraphs
                                                    With par
                                                        If .Text.Trim.Length > 0 Then 'If paragraph is not blank
                                                            If cell.Paragraphs.Count > 0 Then
                                                                If cell.Paragraphs.Last.Text.Trim.Length = 1 Then
                                                                    cell.Paragraphs.Last.Text = cell.Paragraphs.Last.Text.TrimEnd & .Text.TrimStart
                                                                    .Text = " "
                                                                ElseIf Not (New String("!.?").Contains(cell.Paragraphs.Last.Text.Trim.Last.ToString)) And (Math.Abs(.FontSize - cell.Paragraphs.Last.FontSize) <= 2) Then
                                                                    For Each line In par.Lines
                                                                        cell.Paragraphs.Last.Lines.Add(line)
                                                                    Next
                                                                    par.Lines.Clear()
                                                                End If
                                                            End If
                                                        End If
                                                    End With

                                                    'Adds current paragraph to current block
                                                    If par.Text.Trim.Length > 0 Then
                                                        cell.Paragraphs.Add(par)
                                                    End If
                                                Next


                                            Loop While iter.Next(Tesseract.PageIteratorLevel.Block, Tesseract.PageIteratorLevel.Para)
                                        Loop While iter.Next(Tesseract.PageIteratorLevel.Block)

                                    End Using
                                End If

                                htmlOutput &= cell.GetHTML
                            End If
                        Next

                        htmlOutput &= "		</tr>" & vbCrLf
                    Next
                    htmlOutput &= String.Format("	</table>") & vbCrLf
                    htmlOutput &= String.Format("</div>") & vbCrLf

                End Using
            End Using

			MonochromeBitMap.Dispose()
			ScaledImage.Dispose()

			Return htmlOutput
		End Function
	End Class



	'START BORDERLIST CLASS
	Public Class BorderList
		Inherits List(Of Border)
		Private KeyRowTop As Integer = -1
		Private Intersections As PointDictionary
		Public ReadOnly Property bmp As Bitmap
		Private height As Integer
		Private width As Integer
		Public Sub New(bitMap As Bitmap)
			MyBase.New
			bmp = bitMap
			height = bmp.Height
			width = bmp.Width
		End Sub
		Public Sub New()
			MyBase.New
		End Sub
		Public Overloads Sub Add(point As Point, length As Integer, isHorizontal As Boolean)
			MyBase.Add(New Border(point, length, isHorizontal))
		End Sub
		Public Overloads Sub Add(startPoint As Point, endPoint As Point)
			MyBase.Add(New Border(startPoint, endPoint))
		End Sub
		Public Overloads Sub Add(border As Border)
			MyBase.Add(border)
		End Sub
		Public Function GetHorizontalBorders() As BorderList
			Dim horizontalList As New BorderList(bmp)
			For Each b As Border In Me
				If b.IsHorizontal Then horizontalList.Add(b)
			Next
			Return horizontalList
		End Function
		Public Function GetFirstHorizontalBorder() As Border
			Dim horizontalList As New BorderList(bmp)
			Dim hbY As Integer = bmp.Height
			Dim hb As Border = Nothing
			For Each b As Border In Me
				If b.IsHorizontal And b.StartPoint.Y < hbY Then
					hbY = b.StartPoint.Y
					hb = b
				End If
			Next
			Return hb
		End Function
		Public Function GetLastHorizontalBorder() As Border
			Dim horizontalList As New BorderList(bmp)
			Dim hbY As Integer = 0
			Dim hb As Border = Nothing
			For Each b As Border In Me
				If b.IsHorizontal And b.StartPoint.Y > hbY Then
					hbY = b.StartPoint.Y
					hb = b
				End If
			Next
			Return hb
		End Function

		''' <summary>
		''' Estimates the angle of rotation for the document contained in the image. 
		''' </summary>
		Public Function getAngles() As Double
			Dim Targets As New Random()
			Dim sampleAngles As New List(Of Double)
			Dim nonRight As New List(Of Double)
			Dim i As Integer
			Dim numRight As Integer = 0
			For count As Integer = 0 To 19
				i = Targets.Next(0, Me.Count - 1)
				sampleAngles.Add(GetAngle(Me.Item(i)))
				If Math.Abs(sampleAngles(count)) < 0.1 Then
					numRight += 1
				Else
					nonRight.Add(sampleAngles(count))
				End If
			Next
			If numRight > (sampleAngles.Count * 0.7) Then
				Return 0
			Else
				Return (nonRight.Sum / nonRight.Count) * -1
			End If
		End Function
		Private Function GetAngle(border As Border, Optional maxDistance As Integer = 4) As Double
			Dim theta As Double = 0
			Dim cStartX As Integer = border.StartPoint.X
			Dim cStartY As Integer = border.StartPoint.Y
			Dim cEndX As Integer = border.EndPoint.X
			Dim cEndY As Integer = border.EndPoint.Y
			Dim neighbors As New BorderList()
			neighbors.Clear()
			Dim merged As Boolean
			Dim noMerges As Boolean = True
			If border.IsHorizontal Then
				For Each b As Border In Me.GetHorizontalBorders()
					merged = False
					If (cStartX <= b.StartPoint.X) And (b.StartPoint.X <= cEndX) Then
						If Math.Abs(b.StartPoint.Y - cEndY) < maxDistance Then
							If (cEndX < b.EndPoint.X) Then
								cEndX = b.EndPoint.X
								cEndY = b.EndPoint.Y
								merged = True
							End If
						End If
					End If
					If (cStartX <= b.EndPoint.X) And (b.EndPoint.X <= cEndX) Then
						If Math.Abs(b.EndPoint.Y - cStartY) < maxDistance Then
							If (b.StartPoint.X < cStartX) Then
								cStartX = b.StartPoint.X
								cStartY = b.StartPoint.Y
								merged = True
							End If
						End If
					End If
					If merged Then
						noMerges = False
					End If
				Next
			Else
				For Each b As Border In Me.GetVerticalBorders()
					merged = False
					If (cStartY <= b.StartPoint.Y) And (b.StartPoint.Y <= cEndY) Then
						If Math.Abs(b.StartPoint.X - cEndX) < maxDistance Then
							If (cEndY < b.EndPoint.Y) Then
								cEndY = b.EndPoint.Y
								cEndX = b.EndPoint.X
								merged = True
							End If
						End If
					End If
					If (cStartY <= b.EndPoint.Y) And (b.EndPoint.Y <= cEndY) Then
						If Math.Abs(b.EndPoint.X - cStartX) < maxDistance Then
							If (b.StartPoint.Y < cStartY) Then
								cStartY = b.StartPoint.Y
								cStartX = b.StartPoint.X
								merged = True
							End If
						End If
					End If
					If merged Then
						noMerges = False
					End If
				Next
			End If
			If Not noMerges Then
				Dim dX As Double = cEndX - cStartX
				Dim dY As Double = cEndY - cStartY
				If dX = 0 Or dY = 0 Then
					theta = 0
				Else
					theta = Math.Atan2(dY, dX)
					theta = theta * (180 / Math.PI)
					theta = theta Mod 90
					If theta > 45 Then theta -= 90
				End If
			End If

			Return theta
		End Function

		Private Sub Compress(border As Border, Optional maxDistance As Integer = 2)
			Dim cStartX As Integer = border.StartPoint.X
			Dim cStartY As Integer = border.StartPoint.Y
			Dim cEndX As Integer = border.EndPoint.X
			Dim cEndY As Integer = border.EndPoint.Y
			Dim neighbors As New BorderList()
			neighbors.Clear()
			Dim merged As Boolean
			Dim noMerges As Boolean = True
			Dim b1_InitialVal As Integer
			Dim b2_InitialVal As Integer
			Dim spread As Integer
			If border.IsHorizontal Then 'Compress Horizontal Border
				For Each b As Border In Me.GetHorizontalBorders()
					spread = Math.Abs(b.StartPoint.Y - border.StartPoint.Y)
					If spread <= maxDistance And spread >= 0 Then
						neighbors.Add(b)
					End If
				Next
				For Each b As Border In neighbors
					merged = False
					spread = (2 + Math.Abs(b.StartY - border.StartY)) * 2
					b1_InitialVal = cStartY
					b2_InitialVal = b.StartY
					If ((b.EndX >= cStartX) And (b.EndX <= cEndX)) And ((b.StartX >= cStartX) And (b.StartX <= cEndX)) And (Not border.StartY = b.StartY) Then
						merged = True
					ElseIf (cStartX <= b.StartX) And (b.StartX <= (cEndX - spread)) Then
						If (cEndX < b.EndPoint.X) Then
							cEndX = b.EndPoint.X
							merged = True
							If b.Length > border.Length Then
								cStartY = b.StartPoint.Y
								cEndY = cStartY
							ElseIf b.Length < border.Length Then
								cStartY = border.StartPoint.Y
								cEndY = cStartY
							ElseIf cStartY <= (Me.height / 2) Then
								cStartY = Math.Min(b.StartY, border.StartY)
								cEndY = cStartY
							Else
								cStartY = Math.Max(b.StartY, border.StartY)
								cEndY = cStartY
							End If
						End If
					ElseIf ((cStartX + spread) <= b.EndX) And (b.EndX <= cEndX) Then
						If (b.StartX < cStartX) Then
							cStartX = b.StartPoint.X
							merged = True
							If b.Length > border.Length Then
								cStartY = b.StartPoint.Y
								cEndY = cStartY
							ElseIf b.Length < border.Length Then
								cStartY = border.StartPoint.Y
								cEndY = cStartY
							ElseIf cStartY <= (Me.height / 2) Then
								cStartY = Math.Min(b.StartY, border.StartY)
								cEndY = cStartY
							Else
								cStartY = Math.Max(b.StartY, border.StartY)
								cEndY = cStartY
							End If
						End If
					End If
					If merged Then
						If Not b1_InitialVal = cStartY Then
							For Each perp As Border In Me.GetIntersectingBorders(border)
								perp.StretchToY(cStartY, 3)
							Next
						End If
						If Not b2_InitialVal = cStartY Then
							For Each perp As Border In Me.GetIntersectingBorders(b)
								perp.StretchToY(cStartY, 3)
							Next
						End If
						noMerges = False
						Me.Remove(b)
					End If
				Next
			Else 'Compress Vertical Border
				For Each b As Border In Me.GetVerticalBorders()
					spread = Math.Abs(b.StartPoint.X - border.StartPoint.X)
					If spread <= maxDistance And spread > 0 Then
						neighbors.Add(b)
					End If
				Next
				For Each b As Border In neighbors
					merged = False
					spread = (2 + Math.Abs(b.StartX - border.StartX)) * 2
					b1_InitialVal = cStartX
					b2_InitialVal = b.StartX
					If (cStartY <= b.EndY) And (b.EndY <= cEndY) And ((cStartY <= b.StartY) And (b.StartY <= cEndY)) And (Not border.StartX = b.StartX) Then
						merged = True
					ElseIf (cStartY <= b.StartY) And (b.StartY <= (cEndY - spread)) Then
						If (cEndY < b.EndY) Then
							cEndY = b.EndY
							merged = True
							If b.Length > border.Length Then
								cStartX = b.StartX
								cEndX = cStartX
							ElseIf b.Length > border.Length Then
								cStartX = border.StartX
								cEndX = cStartX
							ElseIf cStartX <= (Me.width / 2) Then
								cStartX = Math.Min(b.StartX, border.StartX)
								cEndX = cStartX
							Else
								cStartX = Math.Max(b.StartX, border.StartX)
								cEndX = cStartX
							End If
						End If
					ElseIf ((cStartY + spread) <= b.EndPoint.Y) And (b.EndPoint.Y <= cEndY) Then
						If (b.StartY < cStartY) Then
							cStartY = b.StartY
							merged = True
							If b.Length > border.Length Then
								cStartX = b.StartX
								cEndX = cStartX
							ElseIf b.Length > border.Length Then
								cStartX = border.StartX
								cEndX = cStartX
							ElseIf cStartX <= (Me.width / 2) Then
								cStartX = Math.Min(b.StartX, border.StartX)
								cEndX = cStartX
							Else
								cStartX = Math.Max(b.StartX, border.StartX)
								cEndX = cStartX
							End If
						End If
					End If
					If merged Then
						If Not b1_InitialVal = cStartX Then
							For Each perp As Border In Me.GetIntersectingBorders(border)
								perp.StretchToX(cStartX, 3)
							Next
						End If
						If Not b2_InitialVal = cStartX Then
							For Each perp As Border In Me.GetIntersectingBorders(b)
								perp.StretchToX(cStartX, 3)
							Next
						End If
						noMerges = False
						Me.Remove(b)
					End If
				Next
			End If
			If Not noMerges Then
				Dim index As Integer = Me.IndexOf(border)
				Me.Item(Me.IndexOf(border)) = New Border(New Point(cStartX, cStartY), New Point(cEndX, cEndY))
			End If
		End Sub

		''' <summary>
		''' Combines and removes redundant borders from the collection.
		''' </summary>
		Public Sub CompressAll()
			Dim initialCount As Integer = Me.Count
			Dim count As Integer = initialCount
			Dim i = 0
			For j As Integer = 0 To 4
				i = 0
				Do While i < count
					RepairGaps(Me.Item(i), 4)
					count = Me.Count
					i += 1
				Loop
			Next
			For j As Integer = 0 To 2
				Me.CleanVerticalNoise()
				Me.CleanHorizontalNoise()
				count = Me.Count
			Next
			Do While i < count
				Compress(Me.Item(i))
				count = Me.Count
				i += 1
			Loop

			For j As Integer = 0 To initialCount * 2
				i = 0
				Do While i < count
					Compress(Me.Item(i), 4)
					count = Me.Count
					i += 1
				Loop
			Next
			For j As Integer = 0 To 4
				i = 0
				Do While i < count
					Compress(Me.Item(i), 6)
					count = Me.Count
					i += 1
				Loop
			Next
			If Not count = initialCount Then
				Me.GetIntersections()
			End If
		End Sub

		Private Sub RepairGaps(border As Border, Optional maxDistance As Integer = 2)
			Dim cStartX As Integer = border.StartPoint.X
			Dim cStartY As Integer = border.StartPoint.Y
			Dim cEndX As Integer = border.EndPoint.X
			Dim cEndY As Integer = border.EndPoint.Y
			Dim neighbors As New BorderList()
			neighbors.Clear()
			Dim noMerges As Boolean = True
			If border.IsHorizontal Then
				For Each b As Border In Me.GetHorizontalBorders()
					If b.StartY = border.StartY And (Math.Min(Math.Abs(b.EndX - border.StartX), Math.Abs(b.StartX - border.EndX)) <= maxDistance) Then
						If Not (b.StartPoint = border.StartPoint And b.EndPoint = border.EndPoint) Then neighbors.Add(b)
					End If
				Next
				For Each b As Border In neighbors
					noMerges = False
					cStartX = Math.Min(b.StartX, cStartX)
					cEndX = Math.Max(b.EndX, cEndX)
					Me.Remove(b)
				Next
			Else
				For Each b As Border In Me.GetVerticalBorders()
					If b.StartX = border.StartX And (Math.Min(Math.Abs(b.EndY - border.StartY), Math.Abs(b.StartY - border.EndY)) <= maxDistance) Then
						If Not (b.StartPoint = border.StartPoint And b.EndPoint = border.EndPoint) Then neighbors.Add(b)
					End If
				Next
				For Each b As Border In neighbors
					noMerges = False
					cStartY = Math.Min(b.StartY, cStartY)
					cEndY = Math.Max(b.EndY, cEndY)
					Me.Remove(b)
				Next
			End If
			If Not noMerges Then
				Dim index As Integer = Me.IndexOf(border)
				Me.Item(Me.IndexOf(border)) = New Border(New Point(cStartX, cStartY), New Point(cEndX, cEndY))
			End If
		End Sub

		Public Function GetVerticalBorders() As BorderList
			Dim verticalList As New BorderList(bmp)
			For Each b As Border In Me
				If Not b.IsHorizontal Then verticalList.Add(b)
			Next
			Return verticalList
		End Function

		Public Overloads Sub StretchToX(x As Integer)
			For Each b As Border In Me
				If b.IsHorizontal Then
					If x < b.StartX Then
						b.StartPoint = New Point(x, b.StartY)
					ElseIf x > b.EndX Then
						b.EndPoint = New Point(x, b.EndY)
					End If
				End If
			Next
		End Sub

		Public Overloads Sub StretchToX(x As Integer, tolerance As Integer)
			For Each b As Border In Me
				If b.IsHorizontal Then
					If x < b.StartX Or Math.Abs(x - b.StartX) <= tolerance Then
						b.StartPoint = New Point(x, b.StartY)
					ElseIf x > b.EndX Or Math.Abs(x - b.EndX) <= tolerance Then
						b.EndPoint = New Point(x, b.EndY)
					End If
				End If
			Next
		End Sub

		Public Sub CleanVerticalNoise()
			Dim initialCount As Integer = Me.Count
			Dim count As Integer = initialCount
			Dim b As Border
			Dim i = 0

			Do While i < count
				b = Me.Item(i)
				If (Not b.IsHorizontal) And b.Length < 16 Then
					Me.Remove(b)
					count = Me.Count
				ElseIf (Not b.IsHorizontal) And b.Length < 50 And (GetIntersections(b).Count = 0) Then
					Me.Remove(b)
					count = Me.Count
				End If
				i += 1
			Loop
			If Not count = initialCount Then
				Me.GetIntersections()
			End If
		End Sub

		Public Sub CleanHorizontalNoise()
			Dim initialCount As Integer = Me.Count
			Dim count As Integer = initialCount
			Dim b As Border
			Dim i = 0

			Do While i < count
				b = Me.Item(i)
				If (b.IsHorizontal) And b.Length < 80 And (GetIntersections(b).Count = 0) Then
					Me.Remove(b)
					count = Me.Count
				ElseIf b.IsHorizontal And b.Length < 20 Then
					Me.Remove(b)
					count = Me.Count
				End If
				i += 1
			Loop
			If Not count = initialCount Then
				Me.GetIntersections()
			End If
		End Sub

		Public Function GetLongBorders(width As Integer, height As Integer) As BorderList
			Dim longList As New BorderList(bmp)
			For Each b As Border In Me
				If b.IsHorizontal And b.Length > (width) Then longList.Add(b)
				If (Not b.IsHorizontal) And b.Length > (height / 2) Then longList.Add(b)
			Next
			Return longList
		End Function

		Public Overloads Function GetBorderFromPoint(point As Point, Optional isHorizontal As Boolean = False) As Border
			Dim perpendicularBorders As New BorderList
			If isHorizontal Then
				perpendicularBorders = Me.GetHorizontalBorders()
			Else
				perpendicularBorders = Me.GetVerticalBorders()
			End If
			For Each b In perpendicularBorders
				If b.Contains(point) Then
					Return b
					Exit Function
				End If
			Next
			Return Nothing
		End Function

		Public Overloads Function GetIntersections() As PointDictionary
			If IsNothing(Intersections) Then
				Intersections = New PointDictionary(bmp)
			End If
			Intersections.Clear()
			Dim horbor = Me.GetHorizontalBorders()
			Dim verbor = Me.GetVerticalBorders()
			For Each border In horbor
				For Each b In verbor
					If border.Intersects(b) Then
						If Not Intersections.Contains(border.GetIntersection(b)) Then
							Intersections.Add(border.GetIntersection(b))
						End If
					End If
				Next
			Next
			Return Intersections
		End Function

		Public Overloads Function GetIntersections(border As Border) As PointDictionary
			Dim BorderIntersections As New PointDictionary()
			Dim perpendicularBorders As New BorderList
			If border.IsHorizontal Then
				perpendicularBorders = Me.GetVerticalBorders()
			Else
				perpendicularBorders = Me.GetHorizontalBorders()
			End If
			For Each b In perpendicularBorders
				If border.Intersects(b) Then BorderIntersections.Add(border.GetIntersection(b))
			Next
			Return BorderIntersections
		End Function

		Public Overloads Function GetIntersectingBorders(border As Border) As BorderList
			Dim BorderIntersections As New BorderList
			Dim perpendicularBorders As New BorderList
			If border.IsHorizontal Then
				perpendicularBorders = Me.GetVerticalBorders()
			Else
				perpendicularBorders = Me.GetHorizontalBorders()
			End If
			For Each b In perpendicularBorders
				If border.Intersects(b) Then BorderIntersections.Add(b)
			Next
			Return BorderIntersections
		End Function

		Public Function GetCorners() As PointDictionary
			If IsNothing(Intersections) Then
				GetIntersections()
			End If
			Intersections.Clear()
			Dim horbor = Me.GetHorizontalBorders()
			Dim verbor = Me.GetVerticalBorders()
			For Each border In horbor
				For Each b In verbor
					If border.Intersects(b) Then Intersections.Add(border.GetIntersection(b))
				Next
			Next
			Return Intersections
		End Function

		Public Overloads Function GetBordersThroughVerticalRange(lowerLimit As Integer, upperLimit As Integer) As BorderList
			Dim BordersThroughRange As New BorderList
			For Each b In Me.GetVerticalBorders()
				If b.StartY <= lowerLimit And b.EndY >= upperLimit Then
					BordersThroughRange.Add(b)
				End If
			Next
			Return BordersThroughRange
		End Function
		Public Overloads Function GetHorizontalBordersInArea(area As Rectangle) As BorderList
			Dim BordersInArea As New BorderList
			For Each b In Me 'Iterates over all borders
				If b.IsHorizontal And b.StartY < area.Bottom And b.StartY > area.Top Then 'Checks to make sure that the Y coordinate of the border falls inside the range permitted by the rectangle.
					If b.StartX < area.Right And b.EndX > area.Left Then
						BordersInArea.Add(New Border(
								New Point(Math.Max(b.StartX, area.Left), b.StartY),
								New Point(Math.Min(b.EndX, area.Right), b.StartY))
							)
					End If
				End If
			Next
			Return BordersInArea
		End Function
		Public Overloads Function GetXThroughVerticalRange(lowerLimit As Integer, upperLimit As Integer) As List(Of Integer)
			Dim X_Values As New List(Of Integer)
			For Each b In Me.GetVerticalBorders()
				If b.StartY <= lowerLimit And b.EndY >= upperLimit Then
					If Not X_Values.Contains(b.StartX) Then X_Values.Add(b.StartX)
				End If
			Next
			Return X_Values
		End Function
		Public Overloads Function GetYThroughHorizontalRange(lowerLimit As Integer, upperLimit As Integer) As List(Of Integer)
			Dim Y_Values As New List(Of Integer)
			For Each b In Me.GetHorizontalBorders()
				If b.StartX <= (lowerLimit + 2) And (b.EndX >= upperLimit - 2) Then
					If Not Y_Values.Contains(b.StartY) Then Y_Values.Add(b.StartY)
				End If
			Next
			Return Y_Values
		End Function

		''' <summary>
		''' Analyzes the layout of the document, and returns the results.
		''' </summary>
		Public Function GetLayout() As ConverterTable
			Dim DocTable As New ConverterTable
			If IsNothing(Intersections) Then GetIntersections()
			If Intersections.Count = 0 Then GetIntersections()
			If Intersections.Count > 0 Then
				Dim CurrentRow As New ConverterRow
				Dim CurrentCell As New ConverterCell
				Dim notableYValues As New List(Of Integer)
				Dim notableXValues As New Dictionary(Of Integer, List(Of Integer))
				Dim listOfXValues As New List(Of Integer)
				Dim GridValuesY As New List(Of Integer)
				Dim GridValuesX As New List(Of Integer)
				Dim GridWidths As New List(Of Integer)
				Dim GridHeights As New List(Of Integer)

				For Each p As Point In Intersections
					If Not notableYValues.Contains(p.Y) Then
						listOfXValues = New List(Of Integer)
						listOfXValues.Clear()
						For Each p2 As Point In Intersections
							If p2.Y = p.Y Then
								listOfXValues.Add(p2.X)
							End If
						Next
						If listOfXValues.Count > 1 Then
							listOfXValues.Sort()
							GridValuesY.Add(p.Y)
							For Each x As Integer In listOfXValues
								If Not GridValuesX.Contains(x) Then GridValuesX.Add(x)
							Next
							notableYValues.Add(p.Y)
							notableXValues.Add(p.Y, listOfXValues)
						End If
					End If
				Next

				'Sorts the lists
				notableYValues.Sort()
				GridValuesY.Sort()
				GridValuesX.Sort()

				Dim OverallWidth As Integer = GridValuesX.Last - GridValuesX.First
				'Calculates column widths
				For i As Integer = 1 To GridValuesX.Count - 1
					GridWidths.Add(GridValuesX(i) - GridValuesX(i - 1))
				Next

				'Calculates row heights
				For i As Integer = 1 To GridValuesY.Count - 1
					GridHeights.Add(GridValuesY(i) - GridValuesY(i - 1))
				Next

				''TEST
				For kill As Integer = GridHeights.Count - 1 To 1 Step -1
					If GridHeights(kill) < 5 Then
						GridHeights(kill - 1) = GridHeights(kill - 1) + GridHeights(kill)
						GridHeights.RemoveAt(kill)
					End If
				Next
				''TEST

				'Declare overall table. 
				DocTable.Width = 100 'Set Width to 100%
				DocTable.MarginTop = GridValuesY.First
				DocTable.MarginLeft = GridValuesX.First
				For Each Width As Integer In GridWidths
					DocTable.ColumnWidthsPercentage.Add((Width / OverallWidth) * 100) 'Define widths for each column in the table
					DocTable.ColumnWidths.Add(Width) 'Define widths for each column in the table
				Next

				DocTable.Rows.Clear()
				Dim LocalNotable As New List(Of Integer)
				'Create rows
				For i As Integer = 0 To GridHeights.Count - 1

					LocalNotable.Clear()

					CurrentRow = New ConverterRow
					CurrentRow.Cells.Clear()
					CurrentRow.Index = i
					CurrentRow.Height = GridHeights(i)

					LocalNotable = GetXThroughVerticalRange(notableYValues(i), notableYValues(i + 1))
					LocalNotable.Sort()

					For kill As Integer = LocalNotable.Count - 1 To 1 Step -1
						If Math.Abs(LocalNotable(kill) - LocalNotable(kill - 1)) < 5 Then LocalNotable.RemoveAt(kill)
					Next

					If LocalNotable.Count > 1 Then
						'Create cells
						For j As Integer = 0 To LocalNotable.Count - 2
							CurrentCell = New ConverterCell
							CurrentCell.Index = j
							CurrentCell.Parent = CurrentRow

							'Gets the colspan amount as IndexOfNextBorder - IndexOfCurrentBorder. Using Math.Max(X,0) prevents this from producing negative values
							CurrentCell.ColSpan = Math.Max(GridValuesX.IndexOf(LocalNotable(j + 1)), 0) _
												- Math.Max(GridValuesX.IndexOf(LocalNotable(j)), 0)

							CurrentRow.Cells.Add(CurrentCell)
						Next

						CurrentRow.Parent = DocTable
						DocTable.Rows.Add(CurrentRow)
					End If
				Next

				Dim tempIndex As Integer = 0
				Dim maxRowspan As Integer = 1
				Dim killIt As Boolean = False
				For Each row In DocTable.Rows
					If Not row.Index = DocTable.Rows.Count - 1 Then
						For Each cell In row.Cells
							If cell.RowSpan > 0 Then
								maxRowspan = 1
								LocalNotable = GetYThroughHorizontalRange(cell.Left, cell.Right)
								LocalNotable.Sort()
								tempIndex = LocalNotable.IndexOf(row.Location_Y)


								If tempIndex = LocalNotable.Count - 1 Then
									maxRowspan = (DocTable.Rows.Count - 1) - row.Index
								ElseIf tempIndex = -1 Then
									Dim nextBorder As Integer = 0
									For Each val As Integer In LocalNotable
										If val > row.Location_Y Then
											nextBorder = val
											Exit For
										End If
									Next
									If Not GridValuesY.IndexOf(nextBorder) = -1 Then
										maxRowspan = Math.Min((GridValuesY.IndexOf(nextBorder) - row.Index), (DocTable.Rows.Count - 1) - row.Index)
									Else
										For i As Integer = 1 To GridValuesY.Count - 1
											If GridValuesY(i) >= row.Location_Y Then
												nextBorder = GridValuesY(i - 1)
												Exit For
											End If
										Next
										maxRowspan = Math.Min((GridValuesY.IndexOf(nextBorder) - row.Index), (DocTable.Rows.Count - 1) - row.Index)
									End If
								Else
									maxRowspan = Math.Min((GridValuesY.IndexOf(LocalNotable(tempIndex + 1)) - GridValuesY.IndexOf(LocalNotable(tempIndex))), (DocTable.Rows.Count - 1) - row.Index)
								End If
								If maxRowspan > 1 Then
									killIt = False
									For i As Integer = row.Index + 1 To row.Index + maxRowspan - 1
										For Each victim In DocTable.Rows(i).Cells
											If (victim.AdjustedIndex = cell.AdjustedIndex) Then
												If (victim.ColSpan = cell.ColSpan) Then
													victim.RowSpan = 0
													cell.RowSpan += 1
												Else
													killIt = True
													Exit For
												End If
											End If
										Next
										If killIt Then Exit For
									Next
								End If
							End If
						Next
					End If
				Next

			End If
			Return DocTable
		End Function

		Public Class Border
			Public Property StartPoint As Point
			Public Property EndPoint As Point
			Public ReadOnly Property Length As Integer
				Get
					If (StartPoint.Y = EndPoint.Y) Then
						Return (EndPoint.X - StartPoint.X)
					Else
						Return (EndPoint.Y - StartPoint.Y)
					End If
				End Get
			End Property
			Public ReadOnly Property StartX As Integer
				Get
					Return StartPoint.X
				End Get
			End Property
			Public ReadOnly Property StartY As Integer
				Get
					Return StartPoint.Y
				End Get
			End Property
			Public ReadOnly Property EndX As Integer
				Get
					Return EndPoint.X
				End Get
			End Property
			Public ReadOnly Property EndY As Integer
				Get
					Return EndPoint.Y
				End Get
			End Property
			Public ReadOnly Property IsHorizontal As Boolean
			Public Property Visible = True

			Public Sub New(startPoint As Point, endPoint As Point)
				If startPoint = endPoint Then
					Throw New NullReferenceException("The Start and End Points cannot be the same.")
				End If
				Me.StartPoint = startPoint
				Me.EndPoint = endPoint
				IsHorizontal = (startPoint.Y = endPoint.Y)
			End Sub
			Public Sub New(startPoint As Point, length As Integer, isHorizontal As Boolean)
				If (startPoint = Nothing Or length = Nothing Or isHorizontal = Nothing) Then
					Throw New NullReferenceException("All parameters must be specified.")
				End If
				Me.StartPoint = startPoint
				Me.IsHorizontal = isHorizontal
				If isHorizontal Then
					Me.EndPoint = startPoint + New Point(length, 0)
				Else
					Me.EndPoint = startPoint + New Point(0, length)
				End If
			End Sub
			Public Function Contains(point As Point) As Boolean
				If Me.IsHorizontal Then
					If (Me.StartPoint.Y = point.Y) And (Me.StartPoint.X <= point.X And point.X <= Me.EndPoint.X) Then
						Return True
					Else
						Return False
					End If
				Else
					If (Me.StartPoint.X = point.X) And (Me.StartPoint.Y <= point.Y And point.Y <= Me.EndPoint.Y) Then
						Return True
					Else
						Return False
					End If
				End If
			End Function
			Public Function Intersects(border As Border) As Boolean
				Dim output As Boolean = False
				With border
					If (Me.IsHorizontal = .IsHorizontal) Then Return False
					If Me.IsHorizontal Then
						If (border.StartPoint.Y <= Me.StartPoint.Y) And (Me.StartPoint.Y <= border.EndPoint.Y) Then
							If (Me.StartPoint.X <= border.StartPoint.X) And (border.StartPoint.X <= Me.EndPoint.X) Then
								output = True
							End If
						End If
					Else
						If (border.StartPoint.X <= Me.StartPoint.X) And (Me.StartPoint.X <= border.EndPoint.X) Then
							If (Me.StartPoint.Y <= border.StartPoint.Y) And (border.StartPoint.Y <= Me.EndPoint.Y) Then
								output = True
							End If
						End If
					End If
				End With
				Return output
			End Function
			Public Function GetIntersection(border As Border) As Point
				Dim outputPoint As New Point(-1, -1)
				With border
					If (Me.IsHorizontal = .IsHorizontal) Then Return New Point(-1, -1)
					If Me.IsHorizontal Then
						If (border.StartPoint.Y <= Me.StartPoint.Y) And (Me.StartPoint.Y <= border.EndPoint.Y) Then
							If (Me.StartPoint.X <= border.StartPoint.X) And (border.StartPoint.X <= Me.EndPoint.X) Then
								outputPoint = New Point(border.StartPoint.X, Me.StartPoint.Y)
							End If
						End If
					Else
						If (border.StartPoint.X <= Me.StartPoint.X) And (Me.StartPoint.X <= border.EndPoint.X) Then
							If (Me.StartPoint.Y <= border.StartPoint.Y) And (border.StartPoint.Y <= Me.EndPoint.Y) Then
								outputPoint = New Point(Me.StartPoint.X, border.StartPoint.Y)
							End If
						End If
					End If
				End With
				Return outputPoint
			End Function
			Public Overloads Sub StretchToY(y As Integer)
				If Not Me.IsHorizontal Then
					If y < Me.StartY Then
						Me.StartPoint = New Point(Me.StartX, y)
					ElseIf y > Me.EndY Then
						Me.EndPoint = New Point(Me.EndX, y)
					End If
				End If
			End Sub
			Public Overloads Sub StretchToY(y As Integer, tolerance As Integer)
				If Not Me.IsHorizontal Then
					If y < Me.StartY Or y - Me.StartY <= tolerance Then
						Me.StartPoint = New Point(Me.StartX, y)
					ElseIf y > Me.EndY Or Me.EndY - y <= tolerance Then
						Me.EndPoint = New Point(Me.EndX, y)
					End If
				End If
			End Sub

			Public Overloads Sub StretchToX(x As Integer)
				If Me.IsHorizontal Then
					If x < Me.StartX Then
						Me.StartPoint = New Point(x, Me.StartY)
					ElseIf x > Me.EndX Then
						Me.EndPoint = New Point(x, Me.EndY)
					End If
				End If
			End Sub
			Public Overloads Sub StretchToX(x As Integer, tolerance As Integer)
				If Me.IsHorizontal Then
					If x < Me.StartX Or x - Me.StartX <= tolerance Then
						Me.StartPoint = New Point(x, Me.StartY)
					ElseIf x > Me.EndX Or Me.EndX - x <= tolerance Then
						Me.EndPoint = New Point(x, Me.EndY)
					End If
				End If
			End Sub
		End Class
	End Class

	Public Class PointDictionary
		Inherits List(Of Point)
		Public ReadOnly Property XCoordinates As New List(Of Integer)
		Public ReadOnly Property YCoordinates As New List(Of Integer)
		Public ReadOnly Property Bounds As New Rectangle(0, 0, 0, 0)
		Public ReadOnly Property bmp As Bitmap
		Public Sub New(bitMap As Bitmap)
			MyBase.New
			bmp = bitMap
		End Sub
		Public Sub New()
			MyBase.New
		End Sub
		Public Shadows Sub Add(point As Point)
			MyBase.Add(point)
			XCoordinates.Add(point.X)
			YCoordinates.Add(point.Y)
		End Sub
		Public Shadows Sub Clear()
			MyBase.Clear()
			XCoordinates.Clear()
			YCoordinates.Clear()
		End Sub
		Public Function GetItemsFromX(X As Integer) As List(Of Point)
			Dim outputList As New List(Of Point)
			For i As Integer = 0 To Me.Count - 1
				If XCoordinates(i) = X Then
					outputList.Add(Me.Item(i))
				End If
			Next
			Return outputList
		End Function
		Public Function GetYValuesFromX(X As Integer) As List(Of Integer)
			Dim outputList As New List(Of Integer)
			For i As Integer = 0 To Me.Count - 1
				If XCoordinates(i) = X Then
					outputList.Add(YCoordinates.Item(i))
				End If
			Next
			Return outputList
		End Function
		Public Function GetItemsFromY(Y As Integer) As List(Of Point)
			Dim outputList As New List(Of Point)
			For i As Integer = 0 To Me.Count - 1
				If YCoordinates(i) = Y Then
					outputList.Add(Me.Item(i))
				End If
			Next
			Return outputList
		End Function
		Public Function GetXValuesFromY(Y As Integer) As List(Of Integer)
			Dim outputList As New List(Of Integer)
			For i As Integer = 0 To Me.Count - 1
				If YCoordinates(i) = Y Then
					outputList.Add(XCoordinates.Item(i))
				End If
			Next
			Return outputList
		End Function
		Public Function GetImageContentCorners() As List(Of Point)
			Dim outputList As New List(Of Point)
			Dim minX As Integer = XCoordinates.Min
			Dim minY As Integer = YCoordinates.Min
			Dim maxX As Integer = XCoordinates.Max
			Dim maxY As Integer = YCoordinates.Max

			Dim Ylist As List(Of Integer) = GetYValuesFromX(minX)

			If Ylist.Count = 1 Then
				If GetYValuesFromX(minX)(0) > GetYValuesFromX(maxX)(0) Then
					outputList.Add(New Point(GetXValuesFromY(maxY)(0), maxY))
					outputList.Add(New Point(maxX, GetYValuesFromX(maxX)(0)))
					outputList.Add(New Point(GetXValuesFromY(minY)(0), minY))
					outputList.Add(New Point(minX, GetYValuesFromX(minX)(0)))
				Else
					outputList.Add(New Point(minX, GetYValuesFromX(minX)(0)))
					outputList.Add(New Point(GetXValuesFromY(maxY)(0), maxY))
					outputList.Add(New Point(maxX, GetYValuesFromX(maxX)(0)))
					outputList.Add(New Point(GetXValuesFromY(minY)(0), minY))
				End If
			End If
			GetYValuesFromX(minX)
			GetXValuesFromY(minY)
			GetYValuesFromX(maxX)
			GetXValuesFromY(maxY)
			Return outputList
		End Function
		Public Function GetNextPointHorizontal(point As Point) As Point
			Dim outputPoint As Point
			If Not IsNothing(bmp) Then
				outputPoint = New Point(bmp.Size)
			Else
				outputPoint = New Point(-1, -1)
			End If
			Dim paralellList = GetXValuesFromY(point.Y)
			For i As Integer = 0 To paralellList.Count - 1
				If paralellList(i) = point.X And Not i = paralellList.Count - 1 Then
					outputPoint = New Point(paralellList(i + 1), point.Y)
				End If
			Next
			Return outputPoint
		End Function
		Public Function GetNextPointVertical(point As Point) As Point
			Dim outputPoint As Point
			If Not IsNothing(bmp) Then
				outputPoint = New Point(bmp.Size)
			Else
				outputPoint = New Point(-1, -1)
			End If

			Dim paralellList = GetYValuesFromX(point.X)
			For i As Integer = 0 To paralellList.Count - 2
				If paralellList(i) = point.Y Then
					outputPoint = New Point(point.X, paralellList(i + 1))
				End If
			Next
			Return outputPoint

		End Function
	End Class


	Public Class ConverterTable
		Public Property Rows As New List(Of ConverterRow)
		Public Property Width As Integer = 100
		Public ReadOnly Property Height As Integer
			Get
				Dim totalHeight As Integer = 0
				For Each row In Me.Rows
					totalHeight += row.Height
				Next
				Return totalHeight
			End Get
		End Property
		Public Property MarginTop As Integer = 0
		Public Property MarginLeft As Integer = 0
		Public Property ColumnWidths As New List(Of Integer)
		Public Property ColumnWidthsPercentage As New List(Of Single)
	End Class

	Public Class ConverterRow
		Public Property Parent As ConverterTable
		Public Property Cells As New List(Of ConverterCell)
		Public Property Height As Integer
		Public ReadOnly Property Location_Y As Integer
			Get
				If Me.Index = 0 Then
					Return Me.Parent.MarginTop
				Else
					Dim PreviousHeights As Integer = Me.Parent.MarginTop
					For i As Integer = 0 To Me.Index - 1
						PreviousHeights += Me.Parent.Rows(i).Height
					Next
					Return PreviousHeights
				End If
			End Get
		End Property
		Public Property Index As Integer
	End Class

	'Current version as of 9/15/2017
	'Public Class ConverterCell
	'	Public ReadOnly Property Rectangle As Rectangle
	'		Get
	'			Return New Rectangle(Me.Location_X, Me.Location_Y, Me.Width, Me.Height)
	'		End Get
	'	End Property
	'	Public Property Parent As ConverterRow
	'	Public Property Align As CellAlignHorizontal = CellAlignHorizontal.Left
	'	Public Property VAlign As CellAlignVertical = CellAlignVertical.Middle
	'	Public Property BorderBottomWidth As Integer = 1
	'	Public Property BorderRightWidth As Integer = 1
	'	Public Property BorderLeftWidth As Integer = 1
	'	Public Property BorderTopWidth As Integer = 1
	'	Public Property ColSpan As Integer = 1
	'	Public Property RowSpan As Integer = 1
	'	Public Property Index As Integer = 0
	'	Public ReadOnly Property AdjustedIndex As Integer
	'		Get
	'			Dim AI As Integer = 0
	'			If Me.Index > 0 Then
	'				For i As Integer = 0 To Me.Index - 1
	'					AI += Me.Parent.Cells(i).ColSpan
	'				Next
	'			End If
	'			Return AI
	'		End Get
	'	End Property
	'	Public ReadOnly Property Location_X As Integer
	'		Get
	'			Dim PreviousWidths As Integer = Me.Parent.Parent.MarginLeft
	'			If Me.Index > 0 Then
	'				Dim AdjustedIndex As Integer = 0
	'				For i As Integer = 0 To Me.Index - 1
	'					AdjustedIndex += Me.Parent.Cells(i).ColSpan
	'				Next
	'				For i As Integer = 0 To (AdjustedIndex - 1)
	'					PreviousWidths += Me.Parent.Parent.ColumnWidths(i)
	'				Next
	'			End If
	'			Return PreviousWidths
	'		End Get
	'	End Property
	'	Public ReadOnly Property Left As Integer
	'		Get
	'			Return Me.Location_X
	'		End Get
	'	End Property
	'	Public ReadOnly Property Location_Y As Integer
	'		Get
	'			Return Me.Parent.Location_Y
	'		End Get
	'	End Property
	'	Public ReadOnly Property Top As Integer
	'		Get
	'			Return Me.Parent.Location_Y
	'		End Get
	'	End Property
	'	Public ReadOnly Property Width As Integer
	'		Get
	'			Dim TotalWidth As Integer = 0
	'			If Me.Index = 0 And Me.ColSpan = 1 Then
	'				TotalWidth = Me.Parent.Parent.ColumnWidths(0)
	'			Else
	'				Dim AdjustedIndex As Integer = 0
	'				If Not Me.Index = 0 Then
	'					For i As Integer = 0 To Me.Index - 1
	'						AdjustedIndex += Me.Parent.Cells(i).ColSpan
	'					Next
	'				End If
	'				For i As Integer = AdjustedIndex To (AdjustedIndex + Me.ColSpan - 1)
	'					TotalWidth += Me.Parent.Parent.ColumnWidths(i)
	'				Next
	'			End If
	'			Return TotalWidth
	'		End Get
	'	End Property
	'	Public ReadOnly Property Height As Integer
	'		Get
	'			Dim TotalHeight As Integer = Me.Parent.Height
	'			If Me.RowSpan > 1 Then
	'				For i As Integer = (Me.Parent.Index + 1) To (Me.Parent.Index + Me.RowSpan - 1)
	'					TotalHeight += Me.Parent.Parent.Rows(i).Height
	'				Next
	'			End If
	'			Return TotalHeight
	'		End Get
	'	End Property
	'	Public ReadOnly Property Right As Integer
	'		Get
	'			Return Me.Location_X + Me.Width
	'		End Get
	'	End Property
	'	Public ReadOnly Property Bottom As Integer
	'		Get
	'			Return Me.Location_Y + Me.Height
	'		End Get
	'	End Property
	'End Class


	Public Class ConverterCell
		Public ReadOnly Property AdjustedIndex As Integer
			Get
				Dim AI As Integer = 0
				If Me.Index > 0 Then
					For i As Integer = 0 To Me.Index - 1
						AI += Me.Parent.Cells(i).ColSpan
					Next
				End If
				Return AI
			End Get
		End Property
		Public Property Align As CellAlignHorizontal = CellAlignHorizontal.Left
		Public Property BorderBottomWidth As Integer = 1
		Public Property BorderLeftWidth As Integer = 1
		Public Property BorderRightWidth As Integer = 1
		Public Property BorderTopWidth As Integer = 1
		Public ReadOnly Property Bottom As Integer
			Get
				Return Me.Location_Y + Me.Height
			End Get
		End Property
		Public Property ColSpan As Integer = 1
		Public Property ContainedBorders As New BorderList
		Public Property Index As Integer = 0
		Public ReadOnly Property Height As Integer
			Get
				Dim TotalHeight As Integer = Me.Parent.Height
				If Me.RowSpan > 1 Then
					For i As Integer = (Me.Parent.Index + 1) To (Me.Parent.Index + Me.RowSpan - 1)
						TotalHeight += Me.Parent.Parent.Rows(i).Height
					Next
				End If
				Return TotalHeight
			End Get
		End Property
		Public ReadOnly Property Left As Integer
			Get
				Return Me.Location_X
			End Get
		End Property
		Public ReadOnly Property Location_X As Integer
			Get
				Dim PreviousWidths As Integer = Me.Parent.Parent.MarginLeft
				If Me.Index > 0 Then
					Dim AdjustedIndex As Integer = 0
					For i As Integer = 0 To Me.Index - 1
						AdjustedIndex += Me.Parent.Cells(i).ColSpan
					Next
					For i As Integer = 0 To (AdjustedIndex - 1)
						PreviousWidths += Me.Parent.Parent.ColumnWidths(i)
					Next
				End If
				Return PreviousWidths
			End Get
		End Property
		Public ReadOnly Property Location_Y As Integer
			Get
				Return Me.Parent.Location_Y
			End Get
		End Property
		Public Property Paragraphs As New Paragraphs
		Public Property Parent As ConverterRow
		Public ReadOnly Property Rectangle As Rectangle
			Get
				Return New Rectangle(Me.Location_X, Me.Location_Y, Me.Width, Me.Height)
			End Get
		End Property
		Public ReadOnly Property Right As Integer
			Get
				Return Me.Location_X + Me.Width
			End Get
		End Property
		Public Property RowSpan As Integer = 1
		Public ReadOnly Property Top As Integer
			Get
				Return Me.Parent.Location_Y
			End Get
		End Property
		Public Property VAlign As CellAlignVertical = CellAlignVertical.Middle
		Public ReadOnly Property Width As Integer
			Get
				Dim TotalWidth As Integer = 0
				If Me.Index = 0 And Me.ColSpan = 1 Then
					TotalWidth = Me.Parent.Parent.ColumnWidths(0)
				Else
					Dim AdjustedIndex As Integer = 0
					If Not Me.Index = 0 Then
						For i As Integer = 0 To Me.Index - 1
							AdjustedIndex += Me.Parent.Cells(i).ColSpan
						Next
					End If
					For i As Integer = AdjustedIndex To (AdjustedIndex + Me.ColSpan - 1)
						TotalWidth += Me.Parent.Parent.ColumnWidths(i)
					Next
				End If
				Return TotalWidth
			End Get
		End Property
		Public Function GetHTML()
			Dim resultingHTML As String = ""
			Dim WordIsBordered As Boolean = False
			Dim tdstylestring As String = ""
			If RowSpan > 0 Then

				For Each par In Me.Paragraphs
					If par.Lines.Count > 1 Then
						For i As Integer = 0 To par.Lines.Count - 2
							With par.Lines(i)
								If .BoundingBox.Width < Math.Round(Me.Rectangle.Width * 0.7) Then
									Dim newLine As New TextLine
									newLine.Text = .Text.TrimEnd & "<br/>"
									newLine.FontSize = .FontSize
									newLine.BoundingBox = .BoundingBox
									newLine.TextAlign = .TextAlign
									par.Lines.Item(i) = newLine
								End If
							End With
						Next
					End If
				Next

				resultingHTML = "<td"

				'Strictly for Debug
				If Me.ContainedBorders.Count > 0 Then resultingHTML &= String.Format(" ContainedBorders=""{0}""", Me.ContainedBorders.Count)
				'Strictly for Debug

				resultingHTML &= " class="""
				If BorderLeftWidth = BorderTopWidth _
					And BorderTopWidth = BorderRightWidth _
					And BorderRightWidth = BorderBottomWidth _
					And BorderBottomWidth > 0 Then
					resultingHTML &= "b"
				Else
					If BorderLeftWidth > 0 Then resultingHTML &= "bl "
					If BorderTopWidth > 0 Then resultingHTML &= "bt "
					If BorderRightWidth > 0 Then resultingHTML &= "br "
					If BorderBottomWidth > 0 Then resultingHTML &= "bb "
				End If
				resultingHTML = resultingHTML.TrimEnd & """"

				If ColSpan > 1 Then resultingHTML &= String.Format(" colspan=""{0}""", Me.ColSpan)
				If RowSpan > 1 Then resultingHTML &= String.Format(" rowspan=""{0}""", Me.RowSpan)

				If Me.Paragraphs.Count = 1 Then 'Checks to see if there is exactly 1 paragraph in the current cell
					With Me.Paragraphs.Item(0)
						tdstylestring &= String.Format(" font-size:{0}px;", .FontSize)
						If Not .TextAlign = CellAlignHorizontal.Left Then tdstylestring &= String.Format(" text-align:{0};", .TextAlign.ToString.ToLower)
						If tdstylestring.Trim.Length > 0 Then tdstylestring = String.Format(" style=""{0}""", tdstylestring.Trim)
						resultingHTML &= tdstylestring
						resultingHTML &= ">" & vbCrLf
						For Each line In Me.Paragraphs.Item(0).Lines
							resultingHTML &= "				" & line.Text.Trim & vbCrLf
						Next
					End With
				ElseIf Me.Paragraphs.Count > 0 Then 'Checks to see if there is at least 1 paragraph
					resultingHTML &= ">" & vbCrLf
					If Me.ContainedBorders.Count > 0 Then
						For Each par In Me.Paragraphs
							For Each line In par.Lines
								For i As Integer = 0 To line.Words.Count - 1
									With line.Words(i)
										If .BoundingBox.Width > 0 Then
											WordIsBordered = False
											For Each b In Me.ContainedBorders

												If b.StartX < .BoundingBox.Left And
												b.EndX > .BoundingBox.Right And
												(
													(
														b.StartY > .BoundingBox.Bottom - (.FontSize / 2) And
														b.StartY < .BoundingBox.Bottom + .FontSize
													)
												) Then
													WordIsBordered = True
													resultingHTML &= String.Format(" <span style=""display:inline-block; text-align:center; border-bottom:1px solid black; width:{0}%;"">{1}", Math.Round((b.Length * 100) / Me.Width), .Text)
													resultingHTML &= vbCrLf
													If i < line.Words.Count - 1 Then
														For j As Integer = i + 1 To line.Words.Count - 1
															If b.StartX < line.Words(j).BoundingBox.Left And b.EndX > line.Words(j).BoundingBox.Right Then
																resultingHTML &= " " & line.Words(j).Text
																i += 1
															Else
																Exit For
															End If
														Next
													End If
													resultingHTML &= vbCrLf
													resultingHTML &= "</span>"
													resultingHTML &= vbCrLf
													Exit For
												End If
											Next
											If Not WordIsBordered Then
												resultingHTML &= " " & .Text
											End If
										Else
											resultingHTML &= " " & .Text
										End If
									End With
								Next
							Next
						Next
					Else


						'If Me.Paragraphs.Count = 1 Then 'Checks to see if there is exactly 1 paragraph in the current cell
						'	With Me.Paragraphs.Item(0)
						'		tdStyleString &= String.Format(" font-size:{0}px;", .FontSize)
						'		If Not .TextAlign = CellAlignHorizontal.Left Then tdStyleString &= String.Format(" text-align:{0};", .TextAlign.ToString.ToLower)
						'		If tdStyleString.Trim.Length > 0 Then tdStyleString = String.Format(" style=""{0}""", tdStyleString.Trim)
						'		htmlOutput &= String.Format("			<td{0}{1}>", tdStyleString, additionalAttributes)
						'		htmlOutput &= vbCrLf
						'		For Each line In cell.Paragraphs.Item(0).Lines
						'			htmlOutput &= "				" & line.Text.Trim & vbCrLf
						'		Next
						'	End With
						'Else 'More than one paragraph in current cell
						If Me.Paragraphs.Lines.Count = 2 And Me.Paragraphs.Lines.First.FontSize < Me.Paragraphs.Lines.Last.FontSize Then
							With Me.Paragraphs.Lines.First
								resultingHTML &= vbCrLf & "				"
								resultingHTML &= String.Format("<div style=""font-size:{0}px;", .FontSize)
								If Not .TextAlign = CellAlignHorizontal.Left Then resultingHTML &= String.Format(" text-align:{0};", .TextAlign.ToString.ToLower)
								resultingHTML &= """>"
								resultingHTML &= vbCrLf
								resultingHTML &= "					" & .Text.TrimEnd
								resultingHTML &= vbCrLf & "				</div>"
							End With
							With Me.Paragraphs.Lines.Last
								resultingHTML &= vbCrLf & "				"
								resultingHTML &= String.Format("<div style=""font-size:{0}px; font-weight:bold;", .FontSize)
								If Not .TextAlign = CellAlignHorizontal.Left Then resultingHTML &= String.Format(" text-align:{0};", .TextAlign.ToString.ToLower)
								resultingHTML &= String.Format(" padding-top:{0}px;", Me.Paragraphs.Lines.Last.BoundingBox.Top - Me.Paragraphs.Lines.First.BoundingBox.Bottom)
								resultingHTML &= """ EntityType=""UnIdentified"">"
								resultingHTML &= vbCrLf
								resultingHTML &= "					" & .Text.TrimEnd
								resultingHTML &= vbCrLf & "				</div>" & vbCrLf
							End With
						Else
							For i As Integer = 0 To Me.Paragraphs.Count - 1
								With Me.Paragraphs(i)
									resultingHTML &= vbCrLf & "				"
									resultingHTML &= String.Format("<div style=""font-size:{0}px;", .FontSize)
									If Not .TextAlign = CellAlignHorizontal.Left Then resultingHTML &= String.Format(" text-align:{0};", .TextAlign.ToString.ToLower)
									If i > 0 Then resultingHTML &= String.Format(" padding-top:{0}px;", Me.Paragraphs(i).BoundingBox.Top - Me.Paragraphs(i - 1).BoundingBox.Bottom)
									resultingHTML &= """>"
									resultingHTML &= vbCrLf
									resultingHTML &= "					" & .Text.TrimEnd
									resultingHTML &= vbCrLf & "				</div>" & vbCrLf
								End With
							Next
						End If
					End If
				Else 'No paragraphs in current cell
					resultingHTML &= ">" & vbCrLf
					resultingHTML &= vbCrLf & "				&#160;" & vbCrLf
				End If

				resultingHTML &= "			</td>" & vbCrLf

			End If

			Return resultingHTML
		End Function
	End Class


	Public Enum CellAlignHorizontal
		Left
		Center
		Right
	End Enum
	Public Enum CellAlignVertical
		Top
		Middle
		Bottom
	End Enum
	Public Enum EntityCategory
		Buyer
		CoBuyer
		Dealership
		ProbableData_Unidentified
		SoughtVehicle
		Text
		TradeVehicle
	End Enum
	Public Enum EntityCategory_PersonOrBusiness
		FirstName
		MiddleInitial
		MiddleName
		LastName
		FullName
		Birthday
		AddressLine1
		City
		State
		Zip
	End Enum

	Public Class Paragraphs
		Inherits List(Of Paragraph)
		Public ReadOnly Property Text As String
			Get
				Dim completeText As String = ""
				If Me.Lines.Count > 0 Then
					For Each line In Me.Lines
						completeText &= line.Text
					Next
				End If
				Return completeText
			End Get
		End Property
		Public ReadOnly Property Lines As List(Of TextLine)
			Get
				Dim allLines As New List(Of TextLine)
				For Each par In Me
					For Each line In par.Lines
						allLines.Add(line)
					Next
				Next
				Return allLines
			End Get
		End Property
	End Class
	Public Class Paragraph
		Public ReadOnly Property BoundingBox As Rectangle
			Get
				Dim totalBox As New Rectangle(0, 0, 0, 0)
				If Me.Lines.Count > 0 Then
					totalBox.X = Me.Lines.First.BoundingBox.X
					totalBox.Width = Me.Lines.First.BoundingBox.Width
					totalBox.Y = Me.Lines.First.BoundingBox.Y
					For Each line In Me.Lines
						If line.BoundingBox.X < totalBox.X Then totalBox.X = line.BoundingBox.X
						If line.BoundingBox.Width < totalBox.Width Then totalBox.Width = line.BoundingBox.Width
					Next
					totalBox.Height = Math.Abs(totalBox.Y - Me.Lines.Last.BoundingBox.Bottom)
				End If
				Return totalBox
			End Get
		End Property
		Public Property Text As String
			Get
				Dim completeText As String = ""
				If Me.Lines.Count > 0 Then
					For Each line In Me.Lines
						completeText &= line.Text & vbCrLf
					Next
				End If
				Return completeText
			End Get
			Set(newText As String)
				If newText.Length > 0 Then
					Me.Lines.Clear()
					For Each parsedLine In newText.Split(vbCrLf)
						Me.Lines.Add(New TextLine(parsedLine, 12))
					Next
				End If
			End Set
		End Property
		Public Property Lines As New List(Of TextLine)
		Public Property FontSize As Integer = 12
		Public Property TextAlign As CellAlignHorizontal = CellAlignHorizontal.Left
		Public Sub New()
		End Sub
		Public Sub New(fontSize As Integer)
			Me.FontSize = fontSize
		End Sub
		Public Sub New(fontSize As Integer, align As CellAlignHorizontal)
			Me.FontSize = fontSize
			Me.TextAlign = align
		End Sub
		Public Sub Add(ByVal line As TextLine)
			'Public Sub Add(ByRef line As TextLine)
			Me.Lines.Add(line)
		End Sub
	End Class

	Public Class TextLine
		Public Property FontSize As Integer
			Get
				Return FontSizeValue
			End Get
			Set(newFontSize As Integer)
				If newFontSize > 12 Then
					Me.FontSizeValue = newFontSize - (newFontSize Mod 2)
				ElseIf newFontSize < 6 Then
					Me.FontSizeValue = 6
				Else
					Me.FontSizeValue = newFontSize
				End If
			End Set
		End Property
		Private Property FontSizeValue As Integer
		Public Property TextAlign As CellAlignHorizontal
		Public Property BoundingBox As Rectangle
		Public Property Text As String
			Get
				Dim completeText As String = ""
				If Me.Words.Count > 0 Then
					For Each line In Me.Words
						completeText &= line.Text & " "
					Next
				End If
				Return completeText.TrimEnd
			End Get
			Set(newText As String)
				If newText.Length > 0 Then
					'Me.Words.Clear()
					'For Each parsedWord In newText.Split(" ")
					'	Me.Words.Add(New OCRWord(parsedWord, Me.FontSize))
					'Next
					Dim splitWords = newText.Trim.Split(" ")
					For i As Integer = 0 To splitWords.Length - 1
						If i > Me.Words.Count - 1 Then
							Me.Words.Add(New OCRWord(splitWords(i), Me.FontSize))
						Else
							Me.Words.Item(i).Text = splitWords(i)
						End If
					Next
					If Me.Words.Count > splitWords.Length Then
						For i As Integer = Me.Words.Count - 1 To splitWords.Length Step -1
							Me.Words.RemoveAt(i)
						Next
					End If
				End If
			End Set
		End Property
		Public Property Words As New List(Of OCRWord)
		Public Sub New(text As String, fontSize As Integer)
			Me.Text = text
			Me.FontSize = fontSize
			Me.TextAlign = CellAlignHorizontal.Left
			Me.BoundingBox = New Rectangle(0, 0, 0, 0)
		End Sub
		Public Sub New()
			Me.Text = ""
			Me.FontSize = 0
			Me.TextAlign = CellAlignHorizontal.Left
			Me.BoundingBox = New Rectangle(0, 0, 0, 0)
		End Sub
		Public Sub Clear()
			Me.Text = ""
			Me.FontSize = 0
			Me.TextAlign = CellAlignHorizontal.Left
			Me.BoundingBox = New Rectangle(0, 0, 0, 0)
		End Sub
	End Class

	Public Class OCRWord
		Public Property BoundingBox As Rectangle
		Public Property EntityType As EntityCategory = EntityCategory.Text
		Public Property FontSize As Integer
			Get
				Return FontSizeValue
			End Get
			Set(newFontSize As Integer)
				If newFontSize > 12 Then
					Me.FontSizeValue = newFontSize - (newFontSize Mod 2)
				ElseIf newFontSize < 6 Then
					Me.FontSizeValue = 6
				Else
					Me.FontSizeValue = newFontSize
				End If
			End Set
		End Property
		Private Property FontSizeValue As Integer
		Public Property IsBold As Boolean
		Public Property IsEntity As Boolean
		Public Property Text As String

		Public Sub New(text As String, fontSize As Integer)
			Me.Text = text
			Me.FontSize = fontSize
			Me.BoundingBox = New Rectangle(0, 0, 0, 0)
			Me.IsEntity = False
			Me.IsBold = False
		End Sub
		Public Sub New(text As String)
			Me.Text = text
			Me.FontSize = 12
			Me.BoundingBox = New Rectangle(0, 0, 0, 0)
			Me.IsEntity = False
			Me.IsBold = False
		End Sub
		Public Sub New()
			Me.Text = ""
			Me.FontSize = 12
			Me.BoundingBox = New Rectangle(0, 0, 0, 0)
			Me.IsEntity = False
			Me.IsBold = False
		End Sub
		Public Sub Clear()
			Me.Text = ""
			Me.FontSize = 0
			Me.BoundingBox = New Rectangle(0, 0, 0, 0)
			Me.IsEntity = False
			Me.IsBold = False
		End Sub
	End Class
End Module