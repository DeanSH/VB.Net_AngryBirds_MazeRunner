Module mdTasks

    ''' <summary>
    ''' ''''The Following code does not have any database actions they are sub tasks for the game
    ''' </summary>
    Public Sub HideMenus()
        frmMain.gbLobby.Visible = False
        frmMain.gbAdmin.Visible = False
        frmMain.gbLogin.Visible = False
        frmMain.gbMapSel.Visible = False
        frmMain.gbCharSel.Visible = False
        frmMain.gbCustomMaze.Visible = False
    End Sub

    Public Function GenRandomInt(min As Int32, max As Int32) As Int32
        Static staticRandomGenerator As New System.Random
        Return staticRandomGenerator.Next(min, max + 1)
    End Function

    Public Sub ResetLocalGameVars()
        PlayerDirection = 0
        frmMain.tmrFinish.Enabled = False
        IsPlaying = False
        frmMain.tmrMove.Enabled = False
    End Sub

    Public Function GetCharacterImage(TheChar As String) As Image
        Select Case TheChar
            Case "red"
                Return red1
            Case "yellow"
                Return yellow1
            Case "pink"
                Return pink1
            Case "bomb"
                Return bomb1
            Case "blue"
                Return blue1
            Case Else
                Return pig1
        End Select
    End Function

    Public Function GetCharacterName(TheChar As Integer) As String
        Select Case TheChar
            Case 1
                Return "Red"
            Case 2
                Return "Yellow"
            Case 3
                Return "Pink"
            Case 4
                Return "Bomb"
            Case 5
                Return "Blue"
            Case Else
                Return "Pig"
        End Select
    End Function
    Public Function GetObjectImage(TheObj As Integer) As Image
        If TheObj < 3 Then
            Return egg1
        Else
            Return tnt1
        End If
    End Function

    ' Loops for a specificied period of time (milliseconds)
    Public Sub PauseMe(ByVal interval As Integer)
        Dim sw As New Stopwatch
        sw.Start()
        Do While sw.ElapsedMilliseconds < interval
            ' Allows UI to remain responsive
            Application.DoEvents()
        Loop
        sw.Stop()
    End Sub

End Module
