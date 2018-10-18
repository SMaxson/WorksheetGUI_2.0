Public Class ListOfChanges
	Private _Uri As Uri
	Public Property Uri() As Uri
		Get
			Return _Uri
		End Get
		Set(ByVal value As Uri)
			_Uri = value
		End Set
	End Property

	Private _CachedDocument As String
	Public Property CachedDocument() As String
		Get
			Return _CachedDocument
		End Get
		Set(ByVal value As String)
			_CachedDocument = value
		End Set
	End Property

	Public Sub New(url As String)
		Me.Uri = New Uri(url)
	End Sub
End Class