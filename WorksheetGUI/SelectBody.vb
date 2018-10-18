Public Class SelectBody
	Public BodyFileList As List(Of String)
	Public Selected As String = ""
	Private Sub SelectBody_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		For i As Integer = 0 To BodyFileList.Count - 1
			FileList.Items.Add(Strings.Right(BodyFileList(i), BodyFileList(i).Length - InStrRev(BodyFileList(i), "\", -1, CompareMethod.Text)))
		Next
		FileList.SelectedItem = FileList.Items.Item(0)
	End Sub

	Private Sub CancelSelectionButton_Click(sender As Object, e As EventArgs) Handles CancelSelectionButton.Click
		Me.Close()
	End Sub

	Private Sub ConfirmSelectionButton_Click(sender As Object, e As EventArgs) Handles ConfirmSelectionButton.Click
		Selected = BodyFileList(FileList.SelectedIndex)
		Me.Close()
	End Sub
End Class