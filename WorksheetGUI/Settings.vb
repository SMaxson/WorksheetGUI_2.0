Public Class Settings
	Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Me.CenterToParent()
		codingBuddyActiveCheck.Checked = wsGUIWindow.codingBuddy.codingBuddyActive
		codingBuddyReadAllCheck.Checked = wsGUIWindow.codingBuddy.codingBuddyReadAll
		Select Case wsGUIWindow.codingBuddy.codingBuddyID
			Case 1
				RadioButton1.Checked = True
			Case 2
				RadioButton2.Checked = True
			Case 3
				RadioButton3.Checked = True
			Case 4
				RadioButton4.Checked = True
			Case 5
				RadioButton5.Checked = True
			Case 6
				RadioButton6.Checked = True
			Case 7
				RadioButton7.Checked = True
			Case 8
				RadioButton8.Checked = True
			Case 9
				RadioButton9.Checked = True
		End Select
		If wsGUIWindow.autoRefresh = True Then autoRefreshCheckbox.Checked = True
		If wsGUIWindow.supressScriptErrors = True Then surpressScriptErrorsCheckbox.Checked = True
		refreshRateInput.Value = wsGUIWindow.refreshRate / 1000
		If CanvasForm.drawSelect = True Then drawSelectedElement.Checked = True
		If CanvasForm.drawSelectChildren = True Then drawSelectedElementChildren.Checked = True
		backgroundColorDemo.BackColor = wsGUIWindow.bgColor
		If System.IO.File.Exists(wsGUIWindow.bgImage) Then
			Try
				backgroundImageDemo.BackgroundImage = Image.FromFile(wsGUIWindow.bgImage)
				backgroundImageRadioButton.Checked = True
			Catch ex As Exception
				backgroundColorRadioButton.Checked = True
				backgroundImageRadioButton.Checked = False
			End Try
		Else
			backgroundColorRadioButton.Checked = True
			backgroundImageRadioButton.Checked = False
		End If

		If CanvasForm.drawSelect Then
			drawSelectedElement.Checked = True
		Else
			drawSelectedElement.Checked = False
		End If

		If CanvasForm.drawSelectChildren Then
			drawSelectedElementChildren.Checked = True
		Else
			drawSelectedElementChildren.Checked = False
		End If

		If wsGUIWindow.codingBuddy.codingBuddyID = 8 Then
			Dim sPlayer As New System.Media.SoundPlayer
			Try
				sPlayer.Stream = My.Resources.OOT_PauseMenu_Open_Mono
				sPlayer.Stream.Seek(0, IO.SeekOrigin.Begin)
				sPlayer.Play()
			Catch ex As Exception
				MsgBox(ex.ToString)
			End Try
			If sPlayer IsNot Nothing Then sPlayer = Nothing
		End If

	End Sub

	Private Sub appearancePage_Click(sender As Object, e As EventArgs) Handles appearancePage.Click

	End Sub

	Private Sub settingsAcceptButton_Click(sender As Object, e As EventArgs) Handles settingsAcceptButton.Click
		wsGUIWindow.codingBuddy.codingBuddyActive = codingBuddyActiveCheck.Checked
		wsGUIWindow.codingBuddy.codingBuddyReadAll = codingBuddyReadAllCheck.Checked
		If RadioButton1.Checked Then wsGUIWindow.codingBuddy.codingBuddyID = 1
		If RadioButton2.Checked Then wsGUIWindow.codingBuddy.codingBuddyID = 2
		If RadioButton3.Checked Then wsGUIWindow.codingBuddy.codingBuddyID = 3
		If RadioButton4.Checked Then wsGUIWindow.codingBuddy.codingBuddyID = 4
		If RadioButton5.Checked Then wsGUIWindow.codingBuddy.codingBuddyID = 5
		If RadioButton6.Checked Then wsGUIWindow.codingBuddy.codingBuddyID = 6
		If RadioButton7.Checked Then wsGUIWindow.codingBuddy.codingBuddyID = 7
		If RadioButton8.Checked Then wsGUIWindow.codingBuddy.codingBuddyID = 8
		If RadioButton9.Checked Then wsGUIWindow.codingBuddy.codingBuddyID = 9
		wsGUIWindow.refreshRate = refreshRateInput.Value * 1000
		wsGUIWindow.refreshTimer.Interval = refreshRateInput.Value * 1000

		Dim oldColorButton = wsGUIWindow.colorButton
		Dim oldColorGray1 = wsGUIWindow.colorGray1
		Dim oldColorGray2 = wsGUIWindow.colorGray2
		Dim oldColorGray3 = wsGUIWindow.colorGray3
		Dim oldColorGray4 = wsGUIWindow.colorGray4
		Dim oldColorGray5 = wsGUIWindow.colorGray5
		Dim oldColorText = wsGUIWindow.colorText

		Select Case colorSetList.SelectedItem
			Case "Electric"
				wsGUIWindow.colorButton = Color.DeepSkyBlue
				wsGUIWindow.colorGray1 = System.Drawing.ColorTranslator.FromHtml("#1F1F1F")
				wsGUIWindow.colorGray2 = System.Drawing.ColorTranslator.FromHtml("#000F4A")
				wsGUIWindow.colorGray3 = System.Drawing.ColorTranslator.FromHtml("#02020A")
				wsGUIWindow.colorGray4 = Color.Black
				wsGUIWindow.colorGray5 = System.Drawing.ColorTranslator.FromHtml("#D3D3E3")
				wsGUIWindow.colorText = Color.LightSkyBlue
			Case "Default"
				wsGUIWindow.colorButton = Color.DeepSkyBlue
				wsGUIWindow.colorGray1 = Color.Gainsboro
				wsGUIWindow.colorGray2 = SystemColors.Control
				wsGUIWindow.colorGray3 = SystemColors.ControlLight
				wsGUIWindow.colorGray4 = Color.Silver
				wsGUIWindow.colorGray5 = SystemColors.ControlDark
				wsGUIWindow.colorText = SystemColors.ControlText
		End Select
		wsGUIWindow.UpdateAllColors(oldColorGray1, oldColorGray2, oldColorGray3, oldColorGray4, oldColorGray5, oldColorButton, oldColorText)
		If surpressScriptErrorsCheckbox.Checked = True Then
			wsGUIWindow.supressScriptErrors = True
			wsGUIWindow.displayArea.ScriptErrorsSuppressed = True
		Else
			wsGUIWindow.supressScriptErrors = False
			wsGUIWindow.displayArea.ScriptErrorsSuppressed = False
		End If
		wsGUIWindow.BackColor = wsGUIWindow.bgColor
		If backgroundImageRadioButton.Checked = True Then
			If System.IO.File.Exists(wsGUIWindow.bgImage) Then
				Try
					wsGUIWindow.BackgroundImage = Image.FromFile(wsGUIWindow.bgImage)
				Catch ex As Exception
					wsGUIWindow.BackgroundImage = Nothing
					wsGUIWindow.bgImage = ""
				End Try
			Else
				wsGUIWindow.BackgroundImage = Nothing
				wsGUIWindow.bgImage = ""
			End If
		Else
			wsGUIWindow.BackgroundImage = Nothing
			wsGUIWindow.bgImage = ""
		End If
		If wsGUIWindow.codingBuddy.codingBuddyID = 8 Then
			Dim sPlayer As New System.Media.SoundPlayer
			Try
				sPlayer.Stream = My.Resources.OOT_PauseMenu_Close_Mono
				sPlayer.Stream.Seek(0, IO.SeekOrigin.Begin)
				sPlayer.Play()
			Catch ex As Exception
				MsgBox(ex.ToString)
			End Try
			If sPlayer IsNot Nothing Then sPlayer = Nothing
		End If
		wsGUIWindow.Refresh()

		Me.Close()
		wsGUIWindow.saveSettings()
	End Sub

	Private Sub codingBuddingBuddyActiveCheck_CheckedChanged(sender As Object, e As EventArgs) Handles codingBuddyActiveCheck.CheckedChanged
		If codingBuddyActiveCheck.Checked = True Then
			codingBuddyFrame.Enabled = True
		Else
			codingBuddyFrame.Enabled = False
		End If
	End Sub

	Private Sub autoRefreshCheckbox_CheckedChanged(sender As Object, e As EventArgs) Handles autoRefreshCheckbox.CheckedChanged
		If autoRefreshCheckbox.Checked = True Then
			wsGUIWindow.autoRefresh = True
		Else
			wsGUIWindow.autoRefresh = False
		End If
	End Sub

	Private Sub drawSelectedElement_CheckedChanged(sender As Object, e As EventArgs) Handles drawSelectedElement.CheckedChanged
		If drawSelectedElement.Checked = True Then
			CanvasForm.drawSelect = True
		Else
			CanvasForm.drawSelect = False
		End If
	End Sub

	Private Sub drawSelectedElementChildren_CheckedChanged(sender As Object, e As EventArgs) Handles drawSelectedElementChildren.CheckedChanged
		If drawSelectedElementChildren.Checked = True Then
			CanvasForm.drawSelectChildren = True
		Else
			CanvasForm.drawSelectChildren = False
		End If
	End Sub

	Private Sub debugPage_Click(sender As Object, e As EventArgs) Handles debugPage.Click

	End Sub

	Private Sub refreshRateInput_ValueChanged(sender As Object, e As EventArgs) Handles refreshRateInput.ValueChanged

	End Sub

	Private Sub backgroundColorRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles backgroundColorRadioButton.CheckedChanged
		If backgroundColorRadioButton.Checked = True Then backgroundImageRadioButton.Checked = False
	End Sub

	Private Sub backgroundImageRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles backgroundImageRadioButton.CheckedChanged
		If backgroundImageRadioButton.Checked = True Then backgroundColorRadioButton.Checked = False
	End Sub

	Private Sub backgroundColorDemo_Paint(sender As Object, e As EventArgs) Handles backgroundColorDemo.Click
		wsGUIWindow.colorPicker.Color = wsGUIWindow.bgColor
		wsGUIWindow.colorPicker.ShowDialog(Me)
		wsGUIWindow.bgColor = wsGUIWindow.colorPicker.Color
		backgroundColorDemo.BackColor = wsGUIWindow.bgColor
		Me.Refresh()
	End Sub

	Private Sub backgroundImageDemo_Click(sender As Object, e As EventArgs) Handles backgroundImageDemo.Click
		Dim openBGPicture As OpenFileDialog = New OpenFileDialog
		openBGPicture.InitialDirectory = wsGUIWindow.bgImage
		openBGPicture.Title = "Choose your background image."
		AddHandler openBGPicture.FileOk, AddressOf openBGPicture_FileOk
		openBGPicture.ShowDialog(Me)
	End Sub

	Private Sub openBGPicture_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs)
		Try
			backgroundImageDemo.BackgroundImage = Image.FromFile(sender.FileName)
			wsGUIWindow.bgImage = sender.FileName
		Catch ex As Exception
			wsGUIWindow.showStatus.Text = "Not able to load image."
		End Try
	End Sub

	Private Sub settingsTabs_Selecting(sender As Object, e As TabControlCancelEventArgs) Handles settingsTabs.Selecting
		If wsGUIWindow.codingBuddy.codingBuddyID = 8 Then
			Dim sPlayer As New System.Media.SoundPlayer
			Try
				sPlayer.Stream = My.Resources.OOT_PauseMenu_Turn_Mono
				sPlayer.Stream.Seek(0, IO.SeekOrigin.Begin)
				sPlayer.Play()
			Catch ex As Exception
				MsgBox(ex.ToString)
			End Try
			If sPlayer IsNot Nothing Then sPlayer = Nothing
		End If
	End Sub

	Private Sub Settings_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
		Me.Dispose()
	End Sub
End Class