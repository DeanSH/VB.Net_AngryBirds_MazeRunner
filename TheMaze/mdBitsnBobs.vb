Module mdBitsnBobs
    'Variables for the game, including 1 databinding class for admin grids, and 6 SQL Tables as objects
    Public IsPlaying As Boolean = False
    Public MazeSizeX As Integer = 0
    Public MazeSizeY As Integer = 0

    Public HowLong As New Stopwatch
    Public MazeCells As New List(Of clsMazeWall)

    Public DataBindAccess As clsSQLDataGridBind = New clsSQLDataGridBind()

    Public PlayerID As Integer = 0
    Public HighScore As Integer
    Public Admin As String = "N"
    Public GameID As Integer = 0
    Public PlayerMap As String
    Public GameMap As String
    Public GameMapname As String

    Public GameCharactersTable As Object
    Public GameObjectsTable As Object
    Public OldGameCharactersTable As Object
    Public OldGameObjectsTable As Object
    Public GameCharactersList As Object
    Public GameObjectsList As Object

    Public PlayerName As String
    Public PlayerScore As Long = 0
    Public PlayerXY As Point = New Point(1, 1)
    Public PlayerDirection As Integer = 0
    Public PlayerChar As Integer = "1"

    Public GettingHostID As Boolean
    Public AdminGameDelete As Boolean
    Public IsHosting As Boolean
End Module
