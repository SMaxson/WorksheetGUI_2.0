'This is a custom WebBrowser class to allow for certain inputs to be overridden
Public Class WSWebbrowser
	Inherits WebBrowser

	Protected Overrides Function IsInputKey(ByVal keyData As System.Windows.Forms.Keys) As Boolean
		If keyData = Keys.Return Or keyData = Keys.Enter Then
			Return True
		Else
			Return MyBase.IsInputKey(keyData)
		End If

	End Function

	Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
		If keyData = Keys.Return Or keyData = Keys.Enter Then
			Return True
		Else
			Return MyBase.ProcessCmdKey(msg, keyData)
		End If
	End Function

End Class