Public Class About
	Public Sub New(IEVersionString As String)
		' This call is required by the designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.
		Me.IEVersion.Text = IEVersionString
	End Sub
	Private Sub About_Load(sender As Object, e As EventArgs) Handles MyBase.Load

	End Sub
End Class