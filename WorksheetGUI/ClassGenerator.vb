Imports System
Imports System.Collections.Generic
Imports System.Text

Public Class ClassGenerator
	Dim ClassDB As List(Of String)

	Public Sub New()
		ClassDB = New List(Of String)()
	End Sub


	Public Function ContainsClass(ByVal name As String) As Boolean
		Return ClassDB.Contains(name.ToLower)
	End Function


	Public Sub SetClass(ByVal name As String)
		Dim oldValue As String = ""

		If (Not name.Length > 0) Then
			Throw New ArgumentException("Parameter name cannot be zero-length.")
		End If

		If Not (ClassDB.Contains(name.ToLower)) Then
			ClassDB.Add(name.ToLower)
		End If
	End Sub

	Public Function GetClass(ByVal name As String) As String
		If (Not name.Length > 0) Then
			Throw New ArgumentException("Parameter name cannot be zero-length.")
		End If

		If (ClassDB.Contains(name)) Then
			Return ClassDB(name)
		Else
			Return ""
		End If
	End Function

	Public Sub RemoveClass(ByVal name As String)
		If (ClassDB.Contains(name)) Then
			ClassDB.Remove(name)
		End If
	End Sub

	Public Function GetClassString() As String
		If (ClassDB.Count > 0) Then
			Dim ClassString As New StringBuilder("")
			Dim key As Integer
			For key = 0 To (ClassDB.Count - 1)
				ClassString.Append(ClassDB.Item(key))
				If key < ClassDB.Count - 1 Then ClassString.Append(" ")
			Next key

			Return ClassString.ToString()
		Else
			Return ""
		End If
	End Function

	Public Sub ParseClassString(ByVal classes As String)
		If (classes.Length) > 0 Then
			Dim ClassPairs As String() = classes.Split(New Char() {" "})
			Dim ClassPair As String
			For Each ClassPair In ClassPairs
				If (ClassPair.Length > 0) Then
					ClassDB.Add(ClassPair.ToLower)
				End If
			Next ClassPair
		End If
	End Sub


	Public Sub Clear()
		ClassDB.Clear()
	End Sub
End Class