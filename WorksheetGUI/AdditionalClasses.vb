Imports System.Drawing.Imaging
Imports mshtml

Public Class StringWriterWithEncoding
	Inherits IO.StringWriter

	Private _encoding As System.Text.Encoding

	Public Sub New(encoding As System.Text.Encoding)
		MyBase.New()
		_encoding = encoding
	End Sub

	Public Sub New(encoding As System.Text.Encoding, formatProvider As IFormatProvider)
		MyBase.New(formatProvider)
		_encoding = encoding
	End Sub

	Public Sub New(encoding As System.Text.Encoding, sb As System.Text.StringBuilder)
		MyBase.New(sb)
		_encoding = encoding
	End Sub

	Public Sub New(encoding As System.Text.Encoding, sb As System.Text.StringBuilder, formatProvider As IFormatProvider)
		MyBase.New(sb, formatProvider)
		_encoding = encoding
	End Sub

	Public Overrides ReadOnly Property Encoding As System.Text.Encoding
		Get
			Return _encoding
		End Get
	End Property

End Class

Public Class MumboButton
	Inherits Button
	Public Sub New(encoding As System.Text.Encoding)
		MyBase.New()
		Me.Font = New Drawing.Font("Segoe UI", 12, FontStyle.Bold)
		Me.FlatStyle = FlatStyle.Flat
		Me.AutoSize = False
		Me.Size = New Size(70, 32)
	End Sub
End Class

Public Class xPath
	Dim PathString As String = ""
	Public StartIndex As Integer = 0
	Public EndIndex As Integer = 0
	Dim PathDictionary As String() = {""}
	Public Function ParseFromString(input As String) As String
		If input.Contains("x:") Then
			StartIndex = input.IndexOf("x:")
			EndIndex = StartIndex
			Dim openBrackets As Boolean = False
			Dim openSecondary As Boolean = False
			Dim delimiterSingleQuote As Boolean = False
			Dim delimiterDoubleQuote As Boolean = False

			If StartIndex > 0 And input.Chars(StartIndex - 1) = "/" Then StartIndex -= 1
			Dim j As Integer = StartIndex
			Do While j > 0
				j -= 1
				Select Case input.Chars(j)
					Case """"
						delimiterSingleQuote = False
						delimiterDoubleQuote = True
						Exit Do
					Case "'"
						delimiterSingleQuote = True
						delimiterDoubleQuote = False
						Exit Do
				End Select
			Loop
			For i As Integer = StartIndex + 1 To input.Length - 1
				Select Case input.Chars(i)
					Case ","
						EndIndex = i - 1
						Exit For
					Case ")"
						EndIndex = i - 1
						Exit For
					Case "["
						openBrackets = True
					Case "]"
						openBrackets = False
					Case " "
						If openBrackets Then
							Continue For
						Else
							EndIndex = i - 1
							Exit For
						End If
					Case """"
						If delimiterDoubleQuote Then
							EndIndex = i - 1
							Exit For
						ElseIf Not delimiterSingleQuote And Not delimiterDoubleQuote And openBrackets Then
							delimiterSingleQuote = True
						End If
					Case "'"
						If Not delimiterDoubleQuote Then
							EndIndex = i - 1
							Exit For
						ElseIf Not delimiterSingleQuote And Not delimiterDoubleQuote And openBrackets Then
							delimiterDoubleQuote = True
						End If
					Case Else
						Continue For
				End Select

			Next
			PathString = input.Substring(StartIndex, EndIndex - StartIndex + 1)
			CreatePathDictionary()
			Return PathString
		Else
			Return "NULL"
		End If
	End Function

	Public Function Length() As Integer
		Return PathString.Length
	End Function

	Public Function InitialLength() As Integer
		Return EndIndex - StartIndex
	End Function

	Private Sub CreatePathDictionary()
		Dim Folders As String() = Split(PathString, "/")
		Dim DictionarySplit As String()
		Array.Clear(PathDictionary, 0, PathDictionary.Length)
		Array.Resize(PathDictionary, Folders.Length * 2)
		For i = 0 To Folders.Count - 1
			If Folders(i).Contains("[") Then
				DictionarySplit = Split(Folders(i), "[")
				PathDictionary(i * 2) = DictionarySplit(0)
				PathDictionary((i * 2) + 1) = "[" & DictionarySplit(1)
			Else
				PathDictionary(i * 2) = Folders(i)
				PathDictionary((i * 2) + 1) = ""
			End If
		Next
	End Sub

	Public Function GetxPath() As String
		Return PathString
	End Function

	Public Function GetxPathWithoutTests() As String
		Dim PathStringNoTests As String = ""
		For i = 0 To PathDictionary.Count - 1
			If Not i = 0 Then PathStringNoTests += "/"
			PathStringNoTests += PathDictionary(i * 2)
		Next
		If PathString.StartsWith("/") Then PathStringNoTests = "/" & PathStringNoTests
		Return PathStringNoTests
	End Function

	Public Function Folder(index As Integer) As String
		If index < PathDictionary.Count And index > 0 Then
			Return PathDictionary(index * 2)
		Else
			Return ""
		End If
	End Function

	Public Function Test(index As Integer) As String
		If index < PathDictionary.Count And index > 0 Then
			Return PathDictionary((index * 2) + 1)
		Else
			Return ""
		End If
	End Function

	Public Function MoveLevelDown(newLevel As String) As String
		If PathDictionary(0) = newLevel.Trim Then
			PathDictionary(0) = ""
			PathDictionary(1) = ""
		Else
			Dim temp As String() = PathDictionary.Clone
			Array.Clear(PathDictionary, 0, PathDictionary.Length)
			Array.Resize(PathDictionary, temp.Length + 2)
			PathDictionary(0) = "/x:AppSchemaBase"
			PathDictionary(1) = ""
			For i As Integer = 0 To temp.Count - 1
				PathDictionary(i + 2) = temp(i)
			Next
		End If
		PathString = ""
		For i As Integer = 0 To PathDictionary.Count - 1
			If Not i = 0 Then PathString += "/"
			PathString += PathDictionary((i * 2)) & PathDictionary((i * 2) + 1)
		Next
		Return PathString
	End Function

	Public Function MoveLevelUp(Optional oldLevel As String = "x:TradeIn", Optional oldLevelParentNode As String = "x:AppSchemaBase") As String
		If PathDictionary(0).Contains(oldLevelParentNode) Then
			PathDictionary(0) = ""
			PathDictionary(1) = ""
		Else
			Dim temp As String() = PathDictionary.Clone
			Array.Clear(PathDictionary, 0, PathDictionary.Length)
			Array.Resize(PathDictionary, temp.Length + 2)
			PathDictionary(0) = oldLevel
			PathDictionary(1) = ""
			For i As Integer = 0 To temp.Count - 1
				PathDictionary(i + 2) = temp(i)
			Next
		End If
		PathString = ""
		For i As Integer = 0 To PathDictionary.Count - 1
			If Not i = 0 Then PathString += "/"
			PathString += PathDictionary((i * 2)) & PathDictionary((i * 2) + 1)
		Next
		Return PathString
	End Function
End Class