Public Class clsMazeWall
    'This class holds all the info for a single maze wall block for wall collision detection
    Private _Top As Integer
    Private _Left As Integer
    Private _Width As Integer
    Private _Height As Integer
    Private _Type As Integer

    Public Property Top() As Integer
        Get
            Return _Top
        End Get
        Set(ByVal Value As Integer)
            _Top = Value
        End Set
    End Property

    Public Property Left() As Integer
        Get
            Return _Left
        End Get
        Set(ByVal Value As Integer)
            _Left = Value
        End Set
    End Property

    Public Property Width() As Integer
        Get
            Return _Width
        End Get
        Set(ByVal Value As Integer)
            _Width = Value
        End Set
    End Property

    Public Property Height() As Integer
        Get
            Return _Height
        End Get
        Set(ByVal Value As Integer)
            _Height = Value
        End Set
    End Property

    Public Property Type As Integer
        Get
            Return _Type
        End Get
        Set(value As Integer)
            _Type = value
        End Set
    End Property
End Class
