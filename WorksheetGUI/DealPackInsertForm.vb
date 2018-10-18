Public Class DealPackInsertForm
	Private Sub DealPackInsertForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Dim mainStuff As New DealPackInserter
		mainStuff.Dock = DockStyle.Fill
		Me.Controls.Add(mainStuff)
	End Sub
End Class