Public Class DealPackInserter
	Private targetDealPacks As New List(Of Worksheet.ShellFile)
	Private Sub DealPackInserter_Load(sender As Object, e As EventArgs) Handles MyBase.Load

	End Sub

	Private Sub FileSelectBox_MouseUp(sender As Object, e As MouseEventArgs) Handles FileSelectBox.MouseUp
		'Gets the form to be inserted
		Dim getFile As New OpenFileDialog()
		With getFile
			.CheckFileExists = True
			.CheckPathExists = True
			.DefaultExt = ".xslt"
			.InitialDirectory = "C:\Projects\WorksheetsGit\Worksheets"
			.Title = "Select the file to be added."
			.ShowDialog(Me)
		End With
		FileSelectBox.Text = getFile.FileName
	End Sub

	Private Sub DealPackFilesList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DealPackFilesList.MouseUp
		'Gets the list of Deal Packs the file is to be added to
		Dim getFiles As New OpenFileDialog()
		With getFiles
			.CheckFileExists = True
			.CheckPathExists = True
			.Multiselect = True
			.DefaultExt = ".xslt"
			.InitialDirectory = "C:\Projects\WorksheetsGit\Worksheets"
			.Title = "Select the Deal Packs to update."
			.ShowDialog(Me)
		End With
		For i As Integer = 0 To getFiles.FileNames.Count - 1
			DealPackFilesList.Items.Add(getFiles.FileNames(i))
		Next
	End Sub

	Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
		If DealPackFilesList.SelectedItems.Count > 0 Then
			For i As Integer = 0 To DealPackFilesList.SelectedItems.Count - 1
				DealPackFilesList.Items.Remove(DealPackFilesList.SelectedItems(i))
			Next
		End If
	End Sub

	Private Sub DealPackFilesRemoveAll_Click(sender As Object, e As EventArgs) Handles DealPackFilesRemoveAll.Click
		DealPackFilesList.Items.Clear()
	End Sub

	Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles CancelButton.Click
		DealPackFilesList.Items.Clear()
		targetDealPacks.Clear()
	End Sub

	Private Sub ConfirmButton_Click(sender As Object, e As EventArgs) Handles ConfirmButton.Click
		If FileSelectBox.TextLength = 0 Then Throw New NullReferenceException("There is no file selected to be inserted.")
		If DealPackFilesList.Items.Count = 0 Then Throw New NullReferenceException("There are no Deal Packs selected.")
		Dim FileName As String = FileSelectBox.Text
		Dim Template As String = Replace(Strings.Right(FileName, (FileName.Length - InStrRev(FileName, "\", -1, CompareMethod.Text))), ".xslt", "")
		Dim ActiveDealPack As New Worksheet.ShellFile
		Dim templates As New List(Of String)
		Dim files As New List(Of String)

		For i As Integer = 0 To DealPackFilesList.Items.Count - 1
			ActiveDealPack.Load(DealPackFilesList.Items(i))
			templates = ActiveDealPack.GetTemplates
			files = ActiveDealPack.GetFiles
			files.Add(FileName)
			templates.Add(Template)
			wsGUIWindow.WriteWorksheet(DealPackFilesList.Items(i), ActiveDealPack.CreateShell(files, , templates))
		Next
		MsgBox("Complete!")
	End Sub
End Class
