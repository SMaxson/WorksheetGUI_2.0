Imports System.Runtime.InteropServices

Public Class BitmapByteHelper
	' Provide public access to the picture's byte data.
	Public ImageBytes() As Byte
	Public RowSizeBytes As Integer
	Public Const PixelDataSize As Integer = 24

	' Save a reference to the bitmap.
	Public Sub New(ByVal bm As Bitmap)
		m_Bitmap = bm
	End Sub

	' A reference to the Bitmap.
	Private m_Bitmap As Bitmap

	' Bitmap data.
	Private m_BitmapData As Imaging.BitmapData

	' Lock the bitmap's data.
	Public Sub LockBitmap()
		' Lock the bitmap data.
		Dim bounds As Rectangle = New Rectangle(
			0, 0, m_Bitmap.Width, m_Bitmap.Height)
		m_BitmapData = m_Bitmap.LockBits(bounds,
			Imaging.ImageLockMode.ReadWrite,
			Imaging.PixelFormat.Format24bppRgb)
		RowSizeBytes = m_BitmapData.Stride

		' Allocate room for the data.
		Dim total_size As Integer = (m_BitmapData.Stride *
			m_BitmapData.Height)
		ReDim ImageBytes(total_size + 1)

		' Copy the data into the ImageBytes array.
		'Marshal.Copy(m_BitmapData.Scan0, ImageBytes,
		'	0, total_size)
		Marshal.Copy(m_BitmapData.Scan0, ImageBytes,
			0, ImageBytes.Length)
	End Sub

	' Copy the data back into the Bitmap
	' and release resources.
	Public Sub UnlockBitmap()
		' Copy the data back into the bitmap.
		Dim total_size As Integer = m_BitmapData.Stride *
			m_BitmapData.Height
		'Marshal.Copy(ImageBytes, 0,
		'	m_BitmapData.Scan0, total_size)
		Marshal.Copy(ImageBytes, 0,
			m_BitmapData.Scan0, ImageBytes.Length)

		' Unlock the bitmap.
		m_Bitmap.UnlockBits(m_BitmapData)

		' Release resources.
		Me.ImageBytes = Nothing
		Me.m_BitmapData = Nothing
	End Sub
End Class
