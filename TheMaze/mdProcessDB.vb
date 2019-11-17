Module mdProcessDB
    'Identifies and Processes all the string type messages returned from the database
    Public Sub ProcessDBMessage(Message As String)
        Select Case Message.Substring(0, 5)
            Case "ERROR" 'errors
                MessageBox.Show(Message.Substring(7))
            Case "ADDED" 'new account created and logged in
                LoggedIn(Message.Substring(7))
            Case "NOADD" 'Only admins will get this
                SetStatusMessage(Message.Substring(7))
            Case "LOCKD" 'locked out
                SetStatusMessage(Message.Substring(7))
                MessageBox.Show(Message.Substring(7))
            Case "LOGIN" 'good login
                LoggedIn(Message.Substring(7))
            Case "FAILD" 'bad login
                SetStatusMessage(Message.Substring(7))
            Case "ADMIN" 'admin status's
                SetStatusMessage(Message.Substring(7))
            Case "NGAME" 'No game found or player found in a game

            Case "DGAME" 'Deleted game

            Case "AGAME" 'game still active and not removed

            Case "LGAME" 'player (self) has left a game

            Case "LGOUT" 'Player (self) logged out
                If frmMain.gbLogin.Visible = False Then Logout()
            Case "NOACC" 'Occurs if checking online status of self and account doesnt exist anymore, deleted!

            Case "ISONL" 'online status return, to verify still online or not.
                If GettingHostID = True Then
                    GettingHostID = False
                    GotHostID(Message.Substring(7))
                Else

                End If
            Case "NOMAP" 'if user has no map for account this is recieved
                frmMain.gbLobby.Visible = False
                frmMain.UpdateStatus("No Existing Map Maze Data Found...")
                PauseMe(200)
                frmMain.gbCustomMaze.Visible = True
                frmMain.tbMapName.Text = PlayerName & " Maze"
                frmMain.UpdateStatus("Loading Default Blank Map Maze...")
                PauseMe(200)
                BuildMazeCreator("1111111111111111111111111111111111111111                                     11                                     11                                     11                                     11                                     11                                     11                                     11                                     11                                     11                                     11                                     11                                     11                                     11                                     11                                     11                                     11                                     11                                     11                                     1111111111111111111111111111111111111111")
            Case "MYMAP" 'if user has map this provides all its details
                If IsHosting = True Then
                    GotHostMapData(Message.Substring(7))
                Else
                    GotPlayerMapData(Message.Substring(7))
                End If
            Case "MAPNM" 'returns true or false and message for if mapname is taken or not
                SetStatusMessage(Message.Substring(7))
            Case "MAPNW" 'new map added to DB
                SetStatusMessage(Message.Substring(7))
            Case "MAPUP" 'Updated user map in DB
                SetStatusMessage(Message.Substring(7))
            Case "ERROB" 'Error adding object to game cause dont exist

            Case "OBJGM" 'Game object added for game

            Case "NJOIN" 'failed to join game cause game dont exist
                SetStatusMessage(Message.Substring(7))
            Case "YJOIN" 'User has joined game successfully

            Case "UHOST" 'user started new game and is now host and joined game

            Case "OBJXY" 'updated postion of an object in the game

            Case "YOUXY" 'updated postion of your own character in the game

            Case "SCORE" 'returns new score whenever user increases score

            Case "SCRST" 'Used to process that score was reset to zero

            Case "HIGHS" 'returned if user beats their highscore
                HighScore = PlayerScore
                If MessageBox.Show("Time is up!" & vbCrLf & "You Collected: " & PlayerScore & " Eggs" & vbCrLf & "Congatulations on a New Highscore!" & vbCrLf & "Do you want to Play again?", "New High Score!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    ResetGame()
                Else
                    ExitMaze()
                End If
                SetStatusMessage(Message.Substring(7))
            Case "SAMES" 'same score is the meaning user has not beaten their highscore
                If MessageBox.Show("Time is up!" & vbCrLf & "You Collected: " & PlayerScore & " Eggs" & vbCrLf & "Do you want to Play again?", "Game Over!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    ResetGame()
                Else
                    ExitMaze()
                End If
        End Select

    End Sub

    Public Sub SetStatusMessage(Message As String)
        frmMain.UpdateStatus(Message)
    End Sub

    Private Sub LoggedIn(Data As String)
        frmMain.gbLogin.Visible = False
        frmMain.UpdateStatus("Logged In... Processing Data...")
        frmMain.gbLobby.Visible = True
        frmMain.UpdateStatus(Split(Data, " (")(0))
        Dim PlayerInfo() As String
        Dim TempData As String
        Dim DataBaseConn As clsMySQLCalls = New clsMySQLCalls
        'DataBaseConn.GetCharacterList()
        PlayerName = Split(Split(Data, " (")(0), " as ")(1)
        TempData = Split(Split(Data, "(")(1), ")")(0)
        PlayerInfo = Split(TempData, ",")
        PlayerID = PlayerInfo(0)
        Admin = PlayerInfo(1)
        If Admin = "Y" Then
            frmMain.pbAdmin.Visible = True
        Else
            frmMain.pbAdmin.Visible = False
        End If
        HighScore = PlayerInfo(2)
        GetLobbyLists()
        frmMain.pbBack.BackgroundImage = My.Resources.back
        frmMain.UpdateStatus("You Successfully Logged In as " & PlayerName)
    End Sub

    Public Sub GetLobbyLists()
        Dim DataBaseConn As clsMySQLCalls = New clsMySQLCalls
        DataBaseConn.GetactiveGames()
        DataBaseConn.GetTop10HighScores()
        DataBaseConn.GetOnlinePlayers()
        'DataBaseConn.GetCharacterList()
    End Sub

    Private Sub GotHostID(Data As String) 'Begining process of joining, or deleting if admin
        Dim PlayerInfo() As String
        Dim TempData As String
        Dim DataBaseConn As clsMySQLCalls = New clsMySQLCalls
        TempData = Split(Split(Data, "(")(1), ")")(0)
        PlayerInfo = Split(TempData, ",")
        GameID = PlayerInfo(0)
        If AdminGameDelete = True Then
            AdminGameDelete = False
            DataBaseConn.RemoveGame(GameID)
        Else
            DataBaseConn.RemoveGamePlayer(PlayerID)
            frmMain.gbLobby.Visible = False
            frmMain.UpdateStatus("Select your Character!!")
            frmMain.gbCharSel.Visible = True
        End If
    End Sub

    Private Sub GotHostMapData(Data As String) 'Begining process of hosting
        Dim TempData As String
        Dim DataBaseConn As clsMySQLCalls = New clsMySQLCalls
        TempData = Split(Split(Data, "(")(3), ")")(0)
        GameID = PlayerID
        GameMap = TempData
        'User is hosting a new game so I remove any existing game hosted,
        'and just incase I remove from the host from any game
        DataBaseConn.RemoveGame(GameID)
        DataBaseConn.RemoveGamePlayer(PlayerID)
        frmMain.gbMapSel.Visible = False
        frmMain.UpdateStatus("Select your Character!!")
        frmMain.gbCharSel.Visible = True
    End Sub

    Private Sub GotPlayerMapData(Data As String) 'Begining processing map info for maze builder
        Dim TempData As String
        Dim DataBaseConn As clsMySQLCalls = New clsMySQLCalls
        TempData = Split(Split(Data, "(")(3), ")")(0)
        GameMap = TempData
        GameMapname = Split(Split(Data, "(")(1), ")")(0)
        frmMain.tbMapName.Text = GameMapname
        frmMain.gbLobby.Visible = False
        frmMain.gbCustomMaze.Visible = True
        frmMain.UpdateStatus("Got Existing Map Maze Data... Loading...")
        BuildMazeCreator(GameMap)
    End Sub

    Public Sub ExitMaze()
        SoundFx("ExitGame")
        frmMain.bgMaze.Visible = False
        HowLong.Stop()
        'Remove player from game
        Dim DataBaseConn As clsMySQLCalls = New clsMySQLCalls
        DataBaseConn.RemoveGamePlayer(PlayerID)
        IsPlaying = False
        PlayerScore = 0
        PlayerDirection = 0
        frmMain.dgScores.Visible = False
        frmMain.tmrFinish.Enabled = False
        frmMain.tmrMove.Enabled = False
        frmMain.lblScore.Visible = False
        frmMain.BackgroundImage = BackCharImage
        frmMain.gbLobby.Visible = True
        frmMain.UpdateStatus("Back in Game Lobby.. Now Play A Game!")
        Music("CharSel")
        GetLobbyLists()
    End Sub

    Public Sub ResetGame()
        Music("InGame")
        PlayerScore = 0
        'Reset player score to zero
        Dim DataBaseConn As clsMySQLCalls = New clsMySQLCalls
        DataBaseConn.SetGamePlayerScore(GameID, PlayerID, 0)
        HowLong.Reset()
        HowLong.Start()
        frmMain.tmrFinish.Enabled = True
        IsPlaying = True
        'Run over an over getting the Game object stats for eggs an tnts for smoother gameplay
        Dim eThread = New Threading.Thread(AddressOf UpdateStats)
        eThread.Start
        frmMain.tmrMove.Enabled = True
    End Sub

    Public Sub Logout()
        On Error Resume Next
        HideMenus()
        frmMain.gbLogin.Visible = True
        frmMain.pbBack.BackgroundImage = My.Resources.close
        PlayerID = 0
        PlayerName = ""
        PlayerScore = 0
        GameID = 0
        IsHosting = False
        AdminGameDelete = False
        GettingHostID = False
        IsPlaying = False
        Admin = "N"
        frmMain.UpdateStatus("You have logged out or been DC!")
        'Set user to logged out and remove any existing game hosted if any
        Dim DataBaseConn As clsMySQLCalls = New clsMySQLCalls
        DataBaseConn.LogoutUser(PlayerID, PlayerName)
        DataBaseConn.RemoveGame(PlayerID)
    End Sub

    ' -- Collision control
    Public Sub UpdateStats()
        Do
            If IsPlaying = True Then
                Dim DataBaseConn As clsMySQLCalls = New clsMySQLCalls
                DataBaseConn.GetGameObjectStats(GameID)
            Else
                Exit Do
            End If
        Loop
    End Sub

    'Collision detection checking against my mazewall cell class
    Public Function CheckWallCollision(ByVal prevPosition As Point, ByVal curPosition As Point) As Boolean
        For Each mWall As clsMazeWall In MazeCells
            If mWall.Left = curPosition.X And mWall.Top = curPosition.Y Then Return True : Exit Function
        Next
        Return False
    End Function

    Public Sub NewPlayerLocation(AddToGame As Boolean)
        Dim NewPlayer As New Point
        Dim OldPlayer As New Point(PlayerXY.X, PlayerXY.Y)
Redo:
        NewPlayer.Y = GenRandomInt(1, MazeSizeY - 1)
        NewPlayer.X = GenRandomInt(1, MazeSizeX - 1)
        If GameCharactersTable.Count > 0 Then
            For i As Integer = 0 To GameCharactersTable.Count - 1
                Dim aResultRow = GameCharactersTable.Item(i)
                If Split(aResultRow.xypoint, ",")(0) = NewPlayer.X And Split(aResultRow.xypoint, ",")(1) = NewPlayer.Y Then GoTo Redo
                'Console.WriteLine(aResultRow.username & " | " & aResultRow.char_name & " | " & aResultRow.xypoint & " | " & aResultRow.score)
            Next i
        End If
        If GameObjectsTable.Count > 0 Then
            For i As Integer = 0 To GameObjectsTable.Count - 1
                Dim aResultRow = GameObjectsTable.Item(i)
                If Split(aResultRow.obj_xy, ",")(0) = NewPlayer.X And Split(aResultRow.obj_xy, ",")(1) = NewPlayer.Y Then GoTo Redo
                'Console.WriteLine(aResultRow.username & " | " & aResultRow.char_name & " | " & aResultRow.xypoint & " | " & aResultRow.score)
            Next i
        End If
        If CheckWallCollision(OldPlayer, NewPlayer) = True Then
            GoTo Redo
        Else
            Dim DataBaseConn As clsMySQLCalls = New clsMySQLCalls
            PlayerXY = NewPlayer
            If AddToGame = True Then
                DataBaseConn.AddGamePlayer(GameID, PlayerID, PlayerChar, NewPlayer.X & "," & NewPlayer.Y)
            Else
                DataBaseConn.SetGamePlayerPosition(GameID, PlayerID, NewPlayer.X & "," & NewPlayer.Y)
            End If
        End If

    End Sub

    Public Sub NewObjectLocation(ByVal ObjectID As Integer, AddToGame As Boolean)
        Dim NewObj As New Point
        Dim OldObj As New Point(1, 1)
Redo:
        NewObj.Y = GenRandomInt(1, MazeSizeY - 1)
        NewObj.X = GenRandomInt(1, MazeSizeX - 1)
        If GameCharactersTable.Count > 0 Then
            For i As Integer = 0 To GameCharactersTable.Count - 1
                Dim aResultRow = GameCharactersTable.Item(i)
                If Split(aResultRow.xypoint, ",")(0) = NewObj.X And Split(aResultRow.xypoint, ",")(1) = NewObj.Y Then GoTo Redo
            Next i
        End If
        If GameObjectsTable.Count > 0 Then
            For i As Integer = 0 To GameObjectsTable.Count - 1
                Dim aResultRow = GameObjectsTable.Item(i)
                If Split(aResultRow.obj_xy, ",")(0) = NewObj.X And Split(aResultRow.obj_xy, ",")(1) = NewObj.Y Then GoTo Redo
            Next i
        End If
        If CheckWallCollision(OldObj, NewObj) = True Then
            GoTo Redo
        Else
            Dim DataBaseConn As clsMySQLCalls = New clsMySQLCalls
            If AddToGame = True Then
                DataBaseConn.AddGameObject(GameID, ObjectID, NewObj.X & "," & NewObj.Y)
            Else
                DataBaseConn.SetGameObjPosition(GameID, ObjectID, NewObj.X & "," & NewObj.Y)
            End If

        End If
    End Sub

    Public Sub MoveP1()
        If IsPlaying = False Then Exit Sub

        Dim DataBaseConn As clsMySQLCalls = New clsMySQLCalls
        Dim newPosition As New Point(PlayerXY.X, PlayerXY.Y)
        Dim oldPosition As New Point(PlayerXY.X, PlayerXY.Y)

        Select Case PlayerDirection
            Case 1
                newPosition.Y += 1
            Case 2
                newPosition.Y -= 1
            Case 3
                newPosition.X -= 1
            Case 4
                newPosition.X += 1
        End Select

        If CheckWallCollision(oldPosition, newPosition) = True Then
            'Do nothing just keeps them in same location
        Else
            PlayerXY = newPosition
            DataBaseConn.SetGamePlayerPosition(GameID, PlayerID, newPosition.X & "," & newPosition.Y)
            'Graphics.FromImage(frmMain.bgMaze.Image).DrawImage(BackGameImage, New Rectangle(oldPosition.X, oldPosition.Y, PlayerSpritz(pIndex).Width, PlayerSpritz(pIndex).Height), New Rectangle(oldPosition.X + frmMain.bgMaze.Left, oldPosition.Y + frmMain.bgMaze.Top, PlayerSpritz(pIndex).Width, PlayerSpritz(pIndex).Height), GraphicsUnit.Pixel)
        End If

        For i As Integer = 0 To GameObjectsTable.Count - 1
            Dim aResultRow = GameObjectsTable.Item(i)
            If Split(aResultRow.obj_xy, ",")(0) = newPosition.X And Split(aResultRow.obj_xy, ",")(1) = newPosition.Y Then
                If aResultRow.obj_id < 3 Then
                    SoundFx("Egg")
                    DataBaseConn.IncreasePlayerScore(GameID, PlayerID)
                    NewObjectLocation(aResultRow.obj_id, False)
                Else
                    SoundFx("Tnt")
                    NewPlayerLocation(False)
                    NewObjectLocation(aResultRow.obj_id, False)
                End If
                Exit For
            End If
        Next i

    End Sub

    Public Sub ProcessMaze(ByVal MazeLayout As String)
        SoundFx("Warp")
        Dim _X As Integer = 0
        Dim _Y As Integer = 0
        MazeSizeX = 0
        MazeSizeY = 0
        MazeCells = New List(Of clsMazeWall)

        ResetLocalGameVars()
        PlayerScore = 0
        HideMenus()
        frmMain.UpdateStatus("Loading Game Graphics...")
        PauseMe(200)
        BackGameImage = New Bitmap(frmMain.Width, frmMain.Height)
        Graphics.FromImage(BackGameImage).DrawImage(My.Resources.background2, New Rectangle(0, 0, frmMain.Width, frmMain.Height), New Rectangle(0, 0, My.Resources.background2.Width, My.Resources.background2.Height), GraphicsUnit.Pixel)
        frmMain.BackgroundImage = BackGameImage

        frmMain.bgMaze.Visible = True
        frmMain.bgMaze.BringToFront()
        frmMain.bgMaze.Height = ((21 + 1) * BLOCK_HEIGHT) + 15
        frmMain.bgMaze.Width = ((39 + 1) * BLOCK_WIDTH)
        frmMain.bgMaze.Top = (frmMain.Height - frmMain.bgMaze.Height) / 2
        frmMain.bgMaze.Left = (frmMain.Width - frmMain.bgMaze.Width) / 2
        frmMain.bgMaze.Image = New Bitmap(frmMain.bgMaze.Width, frmMain.bgMaze.Height)
        frmMain.bgMaze.Refresh()

        frmMain.UpdateStatus("Loading Game Map Maze Cells...")
        PauseMe(200)

        Dim maze_line As String
        Dim maze_pos As Integer = 1
        For I As Integer = 0 To 20

            If I = 0 Then
                maze_line = Mid(MazeLayout, maze_pos, 39)
            Else
                maze_pos = maze_pos + 39
                maze_line = Mid(MazeLayout, maze_pos, 39)
            End If

            If MazeSizeX = 0 Then MazeSizeX = Len(maze_line)

            For Each mc As Char In maze_line

                Select Case mc
                    Case "1"c
                        Dim newCell As New clsMazeWall
                        With newCell
                            .Left = _X
                            .Top = _Y
                            .Width = BLOCK_WIDTH
                            .Height = BLOCK_HEIGHT
                            .Type = 1
                        End With
                        MazeCells.Add(newCell)
                End Select

                _X += 1
            Next
            MazeSizeY += 1
            _Y += 1
            _X = 0
        Next I

        frmMain.UpdateStatus("Drawing Game Map Maze...")
        PauseMe(200)

        Dim rndHedge As Integer = 0
        For Each mCell As clsMazeWall In MazeCells
            rndHedge = GenRandomInt(1, 22)
            If rndHedge > 15 Then
                Graphics.FromImage(frmMain.bgMaze.Image).DrawImage(stones1, New Rectangle(mCell.Left * BLOCK_WIDTH, mCell.Top * BLOCK_HEIGHT, mCell.Width, mCell.Height), New Rectangle(0, 0, woods1.Width, woods1.Height), GraphicsUnit.Pixel)
            ElseIf rndHedge > 14 Then
                Graphics.FromImage(frmMain.bgMaze.Image).DrawImage(woods2, New Rectangle(mCell.Left * BLOCK_WIDTH, mCell.Top * BLOCK_HEIGHT, mCell.Width, mCell.Height), New Rectangle(0, 0, woods2.Width, woods3.Height), GraphicsUnit.Pixel)
            ElseIf rndHedge > 13 Then
                Graphics.FromImage(frmMain.bgMaze.Image).DrawImage(woods3, New Rectangle(mCell.Left * BLOCK_WIDTH, mCell.Top * BLOCK_HEIGHT, mCell.Width, mCell.Height), New Rectangle(0, 0, woods3.Width, woods3.Height), GraphicsUnit.Pixel)
            ElseIf rndHedge > 12 Then
                Graphics.FromImage(frmMain.bgMaze.Image).DrawImage(woods4, New Rectangle(mCell.Left * BLOCK_WIDTH, mCell.Top * BLOCK_HEIGHT, mCell.Width, mCell.Height), New Rectangle(0, 0, woods4.Width, woods4.Height), GraphicsUnit.Pixel)
            ElseIf rndHedge > 11 Then
                Graphics.FromImage(frmMain.bgMaze.Image).DrawImage(woods5, New Rectangle(mCell.Left * BLOCK_WIDTH, mCell.Top * BLOCK_HEIGHT, mCell.Width, mCell.Height), New Rectangle(0, 0, woods5.Width, woods5.Height), GraphicsUnit.Pixel)
            ElseIf rndHedge > 10 Then
                Graphics.FromImage(frmMain.bgMaze.Image).DrawImage(woods6, New Rectangle(mCell.Left * BLOCK_WIDTH, mCell.Top * BLOCK_HEIGHT, mCell.Width, mCell.Height), New Rectangle(0, 0, woods6.Width, woods6.Height), GraphicsUnit.Pixel)
            ElseIf rndHedge > 9 Then
                Graphics.FromImage(frmMain.bgMaze.Image).DrawImage(woods1, New Rectangle(mCell.Left * BLOCK_WIDTH, mCell.Top * BLOCK_HEIGHT, mCell.Width, mCell.Height), New Rectangle(0, 0, stones2.Width, stones2.Height), GraphicsUnit.Pixel)
            Else
                Graphics.FromImage(frmMain.bgMaze.Image).DrawImage(stones2, New Rectangle(mCell.Left * BLOCK_WIDTH, mCell.Top * BLOCK_HEIGHT, mCell.Width, mCell.Height), New Rectangle(0, 0, stones1.Width, stones1.Height), GraphicsUnit.Pixel)
            End If
        Next

        frmMain.bgMaze.Refresh()

        Dim DataBaseConn As clsMySQLCalls = New clsMySQLCalls
        If IsHosting = True Then
            frmMain.UpdateStatus("Adding Game Session...")
            DataBaseConn.AddGameSession(PlayerID, GameMapname, GameMap)
            DataBaseConn.GetGamePlayerStats(GameID)
            frmMain.UpdateStatus("Adding Game Objects...")
            DataBaseConn.GetGameObjectStats(GameID)
            NewObjectLocation(1, True)
            NewObjectLocation(2, True)
            NewObjectLocation(3, True)
            NewObjectLocation(4, True)
            frmMain.UpdateStatus("Getting Game Info...")
            DataBaseConn.GetGamePlayerStats(GameID)
            DataBaseConn.GetGameObjectStats(GameID)
            frmMain.UpdateStatus("Adding Your Character...")
            NewPlayerLocation(True)
            frmMain.UpdateStatus("Game Successfully Hosted!!")
        Else
            DataBaseConn.GetGamePlayerStats(GameID)
            DataBaseConn.GetGameObjectStats(GameID)
            frmMain.UpdateStatus("Joining Game...")
            PauseMe(100)
            NewPlayerLocation(True)
            frmMain.UpdateStatus("Game Successfully Joined!!")
        End If
        DataBaseConn.GetGamePlayerStats(GameID)
        OldGameCharactersTable = GameCharactersTable
        OldGameObjectsTable = GameObjectsTable

        frmMain.lblScore.Text = ""
        frmMain.lblScore.Visible = True
        HowLong.Reset()
        HowLong.Start()
        frmMain.tmrFinish.Enabled = True
        frmMain.UpdateStatus("Drawing Objects/Characters...")
        IsPlaying = True
        Dim eThread = New Threading.Thread(AddressOf UpdateStats)
        eThread.Start
        frmMain.tmrMove.Enabled = True
        Music("InGame")

    End Sub

End Module
