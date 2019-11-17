Imports System.Linq

Public Class clsMySQLCalls
    'Angry Birds 3 - Maze Runner by Dean Stanley-Hunt for DAT602 Assignment, S1, 2017, NMIT, NZ.
    'no database code in here! See frmMain,clsMySQLCalls,clsSQLDataGridBind,mdProcessDB << All Database actions.
    Public Sub AddGameObject(prGameID As Integer, prObjID As Integer, prObjPos As String)
        'reads and returns the first column of first row
        Using adb As angrybirds3Entities = New angrybirds3Entities()
            Dim theResultInfo = adb.AddGameObject(prGameID, prObjID, prObjPos).ToList
            Dim aResultRecord = theResultInfo.Item(0)
            Debug.Print(aResultRecord.ToString)
            mdProcessDB.ProcessDBMessage(aResultRecord.ToString)
        End Using
    End Sub

    Public Sub AddGamePlayer(prGameID As Integer, prUserID As Integer, prCharID As Integer, prCharPos As String)
        'reads and returns the first column of first row
        Using adb As angrybirds3Entities = New angrybirds3Entities()
            Dim theResultInfo = adb.AddGamePlayer(prGameID, prUserID, prCharID, prCharPos, 0).ToList
            Dim aResultRecord = theResultInfo.Item(0)
            Debug.Print(aResultRecord.ToString)
            mdProcessDB.ProcessDBMessage(aResultRecord.ToString)
        End Using
    End Sub

    Public Sub AddGameSession(prUserID As Integer, prMapName As String, prMapLayout As String)
        'reads and returns the first column of first row
        Using adb As angrybirds3Entities = New angrybirds3Entities()
            Dim theResultInfo = adb.AddGameSession(prUserID, prMapName, prMapLayout).ToList
            Dim aResultRecord = theResultInfo.Item(0)
            Debug.Print(aResultRecord.ToString)
            mdProcessDB.ProcessDBMessage(aResultRecord.ToString)
        End Using
    End Sub

    Public Sub AddUpdateMap(prUserID As Integer, prMapName As String, prMapLayout As String)
        'reads and returns the first column of first row
        Using adb As angrybirds3Entities = New angrybirds3Entities()
            Dim theResultInfo = adb.AddUpdateMap(prUserID, prMapName, prMapLayout).ToList
            Dim aResultRecord = theResultInfo.Item(0)
            Debug.Print(aResultRecord.ToString)
            mdProcessDB.ProcessDBMessage(aResultRecord.ToString)
        End Using
    End Sub

    Public Sub AddUser(prName As String, prPass As String)
        'reads and returns the first column of first row
        Using adb As angrybirds3Entities = New angrybirds3Entities()
            Dim theResultInfo = adb.AddUser(prName, prPass).ToList
            Dim aResultRecord = theResultInfo.Item(0)
            Debug.Print(aResultRecord.ToString)
            mdProcessDB.ProcessDBMessage(aResultRecord.ToString)
        End Using
    End Sub

    Public Sub ChangePassword(Optional prUserID As Integer = vbNull, Optional prName As String = "", Optional prPass As String = "")
        'reads and returns the first column of first row
        Using adb As angrybirds3Entities = New angrybirds3Entities()
            Dim theResultInfo = adb.ChangePassword(prUserID, prName, prPass).ToList
            Dim aResultRecord = theResultInfo.Item(0)
            Debug.Print(aResultRecord.ToString)
            mdProcessDB.ProcessDBMessage(aResultRecord.ToString)
        End Using
    End Sub

    Public Sub CheckHighScore(prUserID As Integer, prName As String, prScore As Integer)
        'reads and returns the first column of first row
        Using adb As angrybirds3Entities = New angrybirds3Entities()
            Dim theResultInfo = adb.CheckHighScore(prUserID, prName, prScore).ToList
            Dim aResultRecord = theResultInfo.Item(0)
            Debug.Print(aResultRecord.ToString)
            mdProcessDB.ProcessDBMessage(aResultRecord.ToString)
        End Using
    End Sub

    Public Sub CheckMapNameExists(prMapName As String)
        'reads and returns the first column of first row
        Using adb As angrybirds3Entities = New angrybirds3Entities()
            Dim theResultInfo = adb.CheckMapNameExists(prMapName).ToList
            Dim aResultRecord = theResultInfo.Item(0)
            Debug.Print(aResultRecord.ToString)
            mdProcessDB.ProcessDBMessage(aResultRecord.ToString)
        End Using
    End Sub

    Public Sub CheckOnlineStatus(Optional prUserID As Integer = vbNull, Optional prName As String = "")
        'reads and returns the first column of first row
        Using adb As angrybirds3Entities = New angrybirds3Entities()
            Dim theResultInfo = adb.CheckOnlineStatus(prUserID, prName).ToList
            Dim aResultRecord = theResultInfo.Item(0)
            Debug.Print(aResultRecord.ToString)
            mdProcessDB.ProcessDBMessage(aResultRecord.ToString)
        End Using
    End Sub

    Public Sub DeletePlayer(Optional prUserID As Integer = vbNull, Optional prName As String = "")
        'reads and returns the first column of first row
        Using adb As angrybirds3Entities = New angrybirds3Entities()
            Dim theResultInfo = adb.DeletePlayer(prUserID, prName).ToList
            Dim aResultRecord = theResultInfo.Item(0)
            Debug.Print(aResultRecord.ToString)
            mdProcessDB.ProcessDBMessage(aResultRecord.ToString)
        End Using
    End Sub

    Public Sub GetactiveGames()
        'reads and returns all rows with specified coloumns
        Using adb As angrybirds3Entities = New angrybirds3Entities()
            Dim theResultTable = adb.GetActiveGames().ToList()
            'For i As Integer = 0 To theResultTable.Count - 1
            'Dim aResultRow = theResultTable.Item(i)
            'Debug.Print(aResultRow.HOST & " | " & aResultRow.MAZE & " | " & aResultRow.PLAYERS)
            'Console.WriteLine(aResultRow.HOST & " | " & aResultRow.MAZE & " | " & aResultRow.PLAYERS)
            'Next i
            frmMain.dgGames.DataSource = Nothing
            frmMain.dgGames.DataSource = theResultTable
        End Using
    End Sub

    Public Sub GetCharacterList()
        'reads and returns all rows with specified coloumns
        Using adb As angrybirds3Entities = New angrybirds3Entities()
            Dim theResultTable = adb.GetCharacterList().ToList()
            GameCharactersList = theResultTable
            'For i As Integer = 0 To theResultTable.Count - 1
            'Dim aResultRow = theResultTable.Item(i)
            'Console.WriteLine(aResultRow.char_id & " | " & aResultRow.char_name)
            'Next i
        End Using
    End Sub

    Public Sub GetGameObjectStats(prGameID As Integer)
        'reads and returns all rows with specified coloumns
        Using adb As angrybirds3Entities = New angrybirds3Entities()
            Dim theResultTable = adb.GetGameObjectStats(prGameID).ToList
            'GameCharactersTable = theResultTable
            GameObjectsTable = theResultTable
            'For Each Item As gameobject In theResultTable
            '.WriteLine(Item.obj_id & " | " & Item.obj_xy)
            'Next
            'For i As Integer = 0 To theResultTable.Count - 1
            'Dim aResultRow = theResultTable.Item(i)
            'Console.WriteLine(aResultRow.obj_id & " | " & aResultRow.obj_xy)
            'Next i
        End Using
    End Sub

    Public Sub GetGamePlayerStats(prGameID As Integer)
        'reads and returns all rows with specified coloumns
        Using adb As angrybirds3Entities = New angrybirds3Entities()
            Dim theResultTable = adb.GetGamePlayerStats(prGameID).ToList()
            GameCharactersTable = theResultTable
            Dim TempScores As String = ""
            For i As Integer = 0 To theResultTable.Count - 1
                Dim aResultRow = theResultTable.Item(i)
                If UCase(aResultRow.username) = UCase(PlayerName) Then PlayerScore = aResultRow.score
                TempScores = TempScores & aResultRow.username & "  " & aResultRow.char_name & "  " & aResultRow.score & vbCrLf
            Next i
            frmMain.lblScore.Text = TempScores
            frmMain.dgScores.DataSource = Nothing
            frmMain.dgScores.DataSource = theResultTable
        End Using
    End Sub

    Public Sub GetGamePlayerTable()
        'reads and returns all rows with specified coloumns
        Using adb As angrybirds3Entities = New angrybirds3Entities()
            Dim theResultTable = adb.GetGamePlayerTable().ToList()
            'For i As Integer = 0 To theResultTable.Count - 1
            'Dim aResultRow = theResultTable.Item(i)
            'Console.WriteLine(aResultRow.gameid & " | " & aResultRow.userid & " | " & aResultRow.char_id & " | " & aResultRow.xypoint & " | " & aResultRow.score)
            'Next i
            frmMain.dgGamePlayersAdmin.DataSource = Nothing
            frmMain.dgGamePlayersAdmin.DataSource = theResultTable
        End Using
    End Sub

    Public Sub GetGameTable()
        'reads and returns all rows with specified coloumns
        Using adb As angrybirds3Entities = New angrybirds3Entities()
            Dim theResultTable = adb.GetGameTable().ToList()
            'For i As Integer = 0 To theResultTable.Count - 1
            'Dim aResultRow = theResultTable.Item(i)
            'Console.WriteLine(aResultRow.gameid & " | " & aResultRow.mapname & " | " & aResultRow.layout)
            'Next i
            frmMain.dgGameList.DataSource = Nothing
            frmMain.dgGameList.DataSource = theResultTable
        End Using
    End Sub

    Public Sub GetGameMap(TheGameID As Integer)
        'reads and returns all rows with specified coloumns
        Using adb As angrybirds3Entities = New angrybirds3Entities()
            Dim theResultTable = adb.GetGameTable().ToList()
            For i As Integer = 0 To theResultTable.Count - 1
                Dim aResultRow = theResultTable.Item(i)
                If aResultRow.gameid = TheGameID Then
                    GameMap = aResultRow.layout
                    frmMain.UpdateStatus("Got Game Map Maze Data...")
                    PauseMe(300)
                    mdProcessDB.ProcessMaze(GameMap)
                    Exit Sub
                End If
                'Console.WriteLine(aResultRow.gameid & " | " & aResultRow.mapname & " | " & aResultRow.layout)
            Next i
            mdProcessDB.ProcessDBMessage("ERROR: Failed To Get Map Layout For Game ID: " & TheGameID)
        End Using
    End Sub

    Public Sub GetMapNames()
        'reads and returns all rows with specified coloumns
        Using adb As angrybirds3Entities = New angrybirds3Entities()
            Dim theResultTable = adb.GetMapNames().ToList()
            'If frmMain.gbCustomMaze.Visible = True Then
            '    For i As Integer = 0 To theResultTable.Count - 1
            '        Dim aResultRow = theResultTable.Item(i)
            '        If LCase(aResultRow.MAZE) = LCase(frmMain.tbMapName.Text) Then
            '            frmMain.UpdateStatus("Sorry Mapname already exists")
            '            Exit Sub
            '        End If
            '    Next i

            'Else
            frmMain.dgMaps.DataSource = Nothing
            frmMain.dgMaps.DataSource = theResultTable
            frmMain.gbLobby.Visible = False
            frmMain.gbMapSel.Visible = True
            'End If
        End Using
    End Sub

    Public Sub GetObjectList()
        'reads and returns all rows with specified coloumns
        Using adb As angrybirds3Entities = New angrybirds3Entities()
            Dim theResultTable = adb.GetObjectList().ToList()
            GameObjectsList = theResultTable
            'For i As Integer = 0 To theResultTable.Count - 1
            'Dim aResultRow = theResultTable.Item(i)
            'Console.WriteLine(aResultRow.obj_id & " | " & aResultRow.obj_type)
            'Next i
        End Using
    End Sub

    Public Sub GetOnlinePlayers()
        'reads and returns all rows with specified coloumns
        Using adb As angrybirds3Entities = New angrybirds3Entities()
            Dim theResultTable = adb.GetOnlinePlayers().ToList()
            'For i As Integer = 0 To theResultTable.Count - 1
            'Dim aResultRow = theResultTable.Item(i)
            'Console.WriteLine(aResultRow.username & " | " & aResultRow.highscore)
            'Next i
            frmMain.dgOnlines.DataSource = Nothing
            frmMain.dgOnlines.DataSource = theResultTable
        End Using
    End Sub

    Public Sub GetPlayerMapInfo(Optional prUserID As Integer = vbNull, Optional prMapName As String = "")
        'reads and returns the first column of first row
        Using adb As angrybirds3Entities = New angrybirds3Entities()
            Dim theResultInfo = adb.GetPlayerMapInfo(prUserID, prMapName).ToList
            Dim aResultRecord = theResultInfo.Item(0)
            Debug.Print(aResultRecord.ToString)
            mdProcessDB.ProcessDBMessage(aResultRecord.ToString)
        End Using
    End Sub

    Public Sub GetPlayerTable()
        'reads and returns all rows with specified coloumns
        Using adb As angrybirds3Entities = New angrybirds3Entities()
            Dim theResultTable = adb.GetPlayerTable().ToList()
            'For i As Integer = 0 To theResultTable.Count - 1
            'Dim aResultRow = theResultTable.Item(i)
            'Console.WriteLine(aResultRow.userid & " | " & aResultRow.username &
            ' " | " & aResultRow.passwrd & " | " & aResultRow.locked &
            ' " | " & aResultRow.isonline & " | " & aResultRow.admin &
            '" | " & aResultRow.attempts & " | " & aResultRow.highscore &
            '" | " & aResultRow.lastlogin)
            'Next i
            frmMain.dgPlayersAdmin.DataSource = Nothing
            frmMain.dgPlayersAdmin.DataSource = theResultTable
        End Using
    End Sub

    Public Sub GetTop10HighScores()
        'reads and returns all rows with specified coloumns
        Using adb As angrybirds3Entities = New angrybirds3Entities()
            Dim theResultTable = adb.GetTop10HighScores().ToList()
            'For i As Integer = 0 To theResultTable.Count - 1
            'Dim aResultRow = theResultTable.Item(i)
            'Console.WriteLine(aResultRow.username & " | " & aResultRow.highscore)
            'Next i
            frmMain.dgHighscores.DataSource = Nothing
            frmMain.dgHighscores.DataSource = theResultTable
        End Using
    End Sub

    Public Sub IncreasePlayerScore(prGameID As Integer, prUserID As Integer)
        'reads and returns the first column of first row
        Using adb As angrybirds3Entities = New angrybirds3Entities()
            Dim theResultInfo = adb.IncreasePlayerScore(prGameID, prUserID).ToList
            Dim aResultRecord = theResultInfo.Item(0)
            Debug.Print(aResultRecord.ToString)
            mdProcessDB.ProcessDBMessage(aResultRecord.ToString)
        End Using
    End Sub

    Public Sub LoginUser(prName As String, prPass As String)
        'reads and returns the first column of first row
        Using adb As angrybirds3Entities = New angrybirds3Entities()
            Dim theResultInfo = adb.LoginUser(prName, prPass).ToList
            Dim aResultRecord = theResultInfo.Item(0)
            Debug.Print(aResultRecord)
            mdProcessDB.ProcessDBMessage(aResultRecord)
        End Using
    End Sub

    Public Sub LogoutUser(Optional prUserID As Integer = vbNull, Optional prName As String = "")
        'reads and returns the first column of first row
        Using adb As angrybirds3Entities = New angrybirds3Entities()
            Dim theResultInfo = adb.LogoutUser(prUserID, prName).ToList
            Dim aResultRecord = theResultInfo.Item(0)
            Debug.Print(aResultRecord)
            mdProcessDB.ProcessDBMessage(aResultRecord)
        End Using
    End Sub

    Public Sub RemoveGame(prGameID As Integer)
        'reads and returns the first column of first row
        Using adb As angrybirds3Entities = New angrybirds3Entities()
            Dim theResultInfo = adb.RemoveGame(prGameID).ToList
            Dim aResultRecord = theResultInfo.Item(0)
            Debug.Print(aResultRecord.ToString)
            mdProcessDB.ProcessDBMessage(aResultRecord.ToString)
        End Using
    End Sub

    Public Sub RemoveGamePlayer(prUserID As Integer)
        'reads and returns the first column of first row
        Using adb As angrybirds3Entities = New angrybirds3Entities()
            Dim theResultInfo = adb.RemoveGamePlayer(prUserID).ToList
            Dim aResultRecord = theResultInfo.Item(0)
            Debug.Print(aResultRecord.ToString)
            mdProcessDB.ProcessDBMessage(aResultRecord.ToString)
        End Using
    End Sub

    Public Sub SetAdminStatus(Optional prUserID As Integer = vbNull, Optional prName As String = "", Optional prAdmin As String = "N")
        'reads and returns the first column of first row
        Using adb As angrybirds3Entities = New angrybirds3Entities()
            Dim theResultInfo = adb.SetAdminStatus(prUserID, prName, prAdmin).ToList
            Dim aResultRecord = theResultInfo.Item(0)
            Debug.Print(aResultRecord.ToString)
            mdProcessDB.ProcessDBMessage(aResultRecord.ToString)
        End Using
    End Sub

    Public Sub SetGameObjPosition(prGameID As Integer, prObjID As Integer, prObjPos As String)
        'reads and returns the first column of first row
        Using adb As angrybirds3Entities = New angrybirds3Entities()
            Dim theResultInfo = adb.SetGameObjPosition(prGameID, prObjID, prObjPos).ToList
            Dim aResultRecord = theResultInfo.Item(0)
            Debug.Print(aResultRecord.ToString)
            mdProcessDB.ProcessDBMessage(aResultRecord.ToString)
        End Using
    End Sub

    Public Sub SetGamePlayerPosition(prGameID As Integer, prUserID As Integer, prCharPos As String)
        'reads and returns the first column of first row
        Using adb As angrybirds3Entities = New angrybirds3Entities()
            Dim theResultTable = adb.SetGamePlayerPosition(prGameID, prUserID, prCharPos).ToList
            'Dim aResultRecord = theResultInfo.Item(0)
            'Debug.Print(aResultRecord.ToString)
            'mdProcessDB.ProcessDBMessage(aResultRecord.ToString)
            GameCharactersTable = theResultTable
            Dim TempScores As String = ""
            For i As Integer = 0 To theResultTable.Count - 1
                Dim aResultRow = theResultTable.Item(i)
                If UCase(aResultRow.username) = UCase(PlayerName) Then PlayerScore = aResultRow.score
                TempScores = TempScores & aResultRow.username & "  " & aResultRow.char_name & "  " & aResultRow.score & vbCrLf
            Next i
            frmMain.lblScore.Text = TempScores
            frmMain.dgScores.DataSource = Nothing
            frmMain.dgScores.DataSource = theResultTable
        End Using
    End Sub

    Public Sub SetGamePlayerScore(prGameID As Integer, prUserID As Integer, prScore As Integer)
        'reads and returns the first column of first row
        Using adb As angrybirds3Entities = New angrybirds3Entities()
            Dim theResultInfo = adb.SetGamePlayerScore(prGameID, prUserID, prScore).ToList
            Dim aResultRecord = theResultInfo.Item(0)
            Debug.Print(aResultRecord.ToString)
            mdProcessDB.ProcessDBMessage(aResultRecord.ToString)
        End Using
    End Sub

    Public Sub SetLockedStatus(Optional prUserID As Integer = vbNull, Optional prName As String = "", Optional prLocked As String = "N")
        'reads and returns the first column of first row
        Using adb As angrybirds3Entities = New angrybirds3Entities()
            Dim theResultInfo = adb.SetLockedStatus(prUserID, prName, prLocked).ToList
            Dim aResultRecord = theResultInfo.Item(0)
            Debug.Print(aResultRecord.ToString)
            mdProcessDB.ProcessDBMessage(aResultRecord.ToString)
        End Using
    End Sub

    Public Sub UpdateHighScore(Optional prUserID As Integer = vbNull, Optional prName As String = "", Optional prScore As Integer = 0)
        'reads and returns the first column of first row
        Using adb As angrybirds3Entities = New angrybirds3Entities()
            Dim theResultInfo = adb.UpdateHighScore(prUserID, prName, prScore).ToList
            Dim aResultRecord = theResultInfo.Item(0)
            Debug.Print(aResultRecord.ToString)
            mdProcessDB.ProcessDBMessage(aResultRecord.ToString)
        End Using
    End Sub

End Class
