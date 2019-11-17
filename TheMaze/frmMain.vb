Public Class frmMain
    'Angry Birds 3 - Maze Runner by Dean Stanley-Hunt for DAT602 Assignment, S1, 2017, NMIT, NZ.
    'no database code in here! See frmMain,clsMySQLCalls,clsSQLDataGridBind,mdProcessDB << All Database actions.
    ' -- Timer and method to redraw characters and objects each tick
    Private Sub tmrDraw_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrDraw.Tick
        DrawGame()
    End Sub

    Private Sub DrawGame()
        'On Error Resume Next
        If IsPlaying = True Then
            Dim TempX As Integer
            Dim TempY As Integer
            Dim TempImage As Image

            'Erase current objects
            If OldGameObjectsTable.Count > 0 Then
                For i As Integer = 0 To OldGameObjectsTable.Count - 1
                    Dim aResultRow = OldGameObjectsTable.Item(i)
                    TempX = Split(aResultRow.obj_xy, ",")(0) * BLOCK_WIDTH
                        TempY = Split(aResultRow.obj_xy, ",")(1) * BLOCK_HEIGHT
                    Graphics.FromImage(bgMaze.Image).DrawImage(BackGameImage, New Rectangle(TempX, TempY, BLOCK_WIDTH, BLOCK_HEIGHT), New Rectangle(TempX + bgMaze.Left, TempY + bgMaze.Top, BLOCK_WIDTH, BLOCK_HEIGHT), GraphicsUnit.Pixel)
                Next i
            End If
            'Redraw objects in up to date locations
            OldGameObjectsTable = GameObjectsTable
            If GameObjectsTable.Count > 0 Then
                For i As Integer = 0 To GameObjectsTable.Count - 1
                    Dim aResultRow = GameObjectsTable.Item(i)
                    TempX = Split(aResultRow.obj_xy, ",")(0) * BLOCK_WIDTH
                    TempY = Split(aResultRow.obj_xy, ",")(1) * BLOCK_HEIGHT
                    TempImage = GetObjectImage(aResultRow.obj_id)
                    Graphics.FromImage(bgMaze.Image).DrawImage(TempImage, New Rectangle(TempX, TempY, BLOCK_WIDTH, BLOCK_HEIGHT), New Rectangle(0, 0, TempImage.Width, TempImage.Height), GraphicsUnit.Pixel)
                Next i
            End If
            If OldGameCharactersTable.Count > 0 Then
                For i As Integer = 0 To OldGameCharactersTable.Count - 1
                    Dim aResultRow = OldGameCharactersTable.Item(i)
                    TempX = Split(aResultRow.xypoint, ",")(0) * BLOCK_WIDTH
                        TempY = Split(aResultRow.xypoint, ",")(1) * BLOCK_HEIGHT
                    Graphics.FromImage(bgMaze.Image).DrawImage(BackGameImage, New Rectangle(TempX, TempY, BLOCK_WIDTH, BLOCK_HEIGHT), New Rectangle(TempX + bgMaze.Left, TempY + bgMaze.Top, BLOCK_WIDTH, BLOCK_HEIGHT), GraphicsUnit.Pixel)
                Next i
            End If
            'Redraw characters in up to date locations
            OldGameCharactersTable = GameCharactersTable
            If GameCharactersTable.Count > 0 Then
                For i As Integer = 0 To GameCharactersTable.Count - 1
                    Dim aResultRow = GameCharactersTable.Item(i)
                    TempX = Split(aResultRow.xypoint, ",")(0) * BLOCK_WIDTH
                        TempY = Split(aResultRow.xypoint, ",")(1) * BLOCK_HEIGHT
                    TempImage = GetCharacterImage(aResultRow.char_name)
                    Graphics.FromImage(bgMaze.Image).DrawImage(TempImage, New Rectangle(TempX, TempY, BLOCK_WIDTH, BLOCK_HEIGHT), New Rectangle(0, 0, TempImage.Width, TempImage.Height), GraphicsUnit.Pixel)
                Next i
            End If
            'Refresh picture box to show new draw changes
            bgMaze.Refresh()
        End If
    End Sub

    'Timer to count down to the end of the game (240 seconds)
    Private Sub tmrFinish_Tick(sender As Object, e As EventArgs) Handles tmrFinish.Tick
        If CInt((HowLong.ElapsedMilliseconds / 1000)) > 240 Then
            'If reach 240 seconds then end game, prompting user for if wants to replay after checking if need to update high score
            SoundFx("GameOver")
            HowLong.Stop()
            ResetLocalGameVars()
            Music("GameEnd")
            lblStatus.Text = "GAME OVER!"
            tmrFinish.Enabled = False
            'tmrMove.Enabled = 
            IsPlaying = False
            Dim DataBaseConn As clsMySQLCalls = New clsMySQLCalls
            DataBaseConn.CheckHighScore(PlayerID, "", PlayerScore)
        Else
            'While playing game, update time display and a few other visual refreshes and bring to fronts
            lblStatus.Text = "Time: " & CStr(CInt((HowLong.ElapsedMilliseconds / 1000))) & "/240"
            If lblScore.Visible = True Then bgMaze.BringToFront()
            lblStatus.BringToFront()
            lblScore.Refresh()
        End If
    End Sub

    'Main load point of form, loads all tool tips, positions group boxes, calculates things, sets graphics images and resolutions, starts music, etc
    Private Sub MainFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Resposition Objects / Setup
        'If IsWindowed = False Then Me.TopMost = 
        MessageBox.Show("Please make sure you are running the SSH Tunnel information provided in a text file with the game, to connect to todds singapore server or it will not work to play without connection string changes!")
        Dim MyPoint As New Point
        MyPoint.X = (Me.Width - gbLogin.Width) / 2
        MyPoint.Y = (Me.Height - gbLogin.Height) / 2.3
        gbLogin.Location = MyPoint
        gbLobby.Location = MyPoint
        gbAdmin.Location = MyPoint
        gbCharSel.Location = MyPoint
        gbMapSel.Location = MyPoint
        gbCustomMaze.Location = MyPoint
        bgMaze.Visible = False
        'Create Tooltips
        ttGame.SetToolTip(pbAdmin, "Goto Administration Area")
        ttGame.SetToolTip(pbApplyAdminChanges, "Apply All Admin Changes!")
        ttGame.SetToolTip(pbBack, "Go Back / Logout / Exit Game")
        ttGame.SetToolTip(pbHosts, "Host a New Game!")
        ttGame.SetToolTip(pbJoin, "Join the Selected Game!")
        ttGame.SetToolTip(pbLogin, "Login or Register!")
        ttGame.SetToolTip(pbMapNext, "Confirm Map Maze Selection")
        ttGame.SetToolTip(pbMazeEdit, "Goto Map Maze Creator / Editor")
        ttGame.SetToolTip(pbRefreshAdminLists, "Refresh all Admin Grids")
        ttGame.SetToolTip(pbRefreshLobby, "Refresh all Lobby Lists!")
        ttGame.SetToolTip(pbStart, "Confirm Character Selection an Start Playing!")
        ttGame.SetToolTip(pbUpdateAddMap, "Add / Update Map Maze!")
        'Initialize Graphics
        Me.UpdateStatus("Initializing Graphics.........")
        Initialize_Resolution()
        PauseMe(100)
        Me.Visible = True
        BackCharImage = New Bitmap(Width, Height)
        Graphics.FromImage(BackCharImage).DrawImage(My.Resources.background1, New Rectangle(0, 0, Width, Height), New Rectangle(0, 0, My.Resources.background1.Width, My.Resources.background1.Height), GraphicsUnit.Pixel)
        Me.BackgroundImage = BackCharImage
        'Music
        Music("CharSel")
        'Graphical Image Preperations
        LoadImages()
        'Show login group box and load user account if any, update status label
        gbLogin.Visible = True
        gbLogin.BringToFront()
        tbID.Text = GetSetting("AB3", "User", "Name", "UserID")
        tbPW.Text = GetSetting("AB3", "User", "Pswd", "12345678")
        Me.UpdateStatus("Welcome.. Login or Register to Play!")
    End Sub

    'Character Selection to set border and play sound
    Private Sub pbSelection_Click(sender As Object, e As EventArgs) Handles pbYellow.Click, pbBlue.Click, pbRed.Click, pbPink.Click, pbBomb.Click, pbPig.Click
        pbBlue.BorderStyle = BorderStyle.None
        pbRed.BorderStyle = BorderStyle.None
        pbYellow.BorderStyle = BorderStyle.None
        pbPink.BorderStyle = BorderStyle.None
        pbBomb.BorderStyle = BorderStyle.None
        pbPig.BorderStyle = BorderStyle.None
        sender.BorderStyle = BorderStyle.FixedSingle
        PlayerChar = sender.Tag
        Select Case sender.Tag
            Case 1
                SoundFx("selC1")
            Case 2
                SoundFx("selC2")
            Case 3
                SoundFx("selC3")
            Case 4
                SoundFx("selC4")
            Case 5
                SoundFx("selC5")
            Case 6
                SoundFx("selC6")
        End Select
    End Sub

    'Timer to move Player in direction desired, calls subtask
    Private Sub tmrMove_Tick(sender As Object, e As EventArgs) Handles tmrMove.Tick
        If IsPlaying = True Then
            If PlayerDirection > 0 Then
                'Dim eThread As New Threading.Thread(AddressOf MoveP1)
                'eThread.Start()
                MoveP1()
            End If
        End If
    End Sub

    'Start playing button at character selection, acts differently depending on if joining or hosting game
    Private Sub pbStart_Click(sender As Object, e As EventArgs) Handles pbStart.Click
        If IsHosting = True Then
            Me.UpdateStatus("Starting New Host Game...")
            'Start drawing the map user will host game on
            mdProcessDB.ProcessMaze(GameMap)
        Else
            Dim DataBaseConn As clsMySQLCalls = New clsMySQLCalls
            Me.UpdateStatus("Gathering Game Information...")
            'gather map info for game being joined, and will then draw the map out
            DataBaseConn.GetGameMap(GameID)
        End If
    End Sub

    'This event triggers if form closes, program closes and saves user login and password, and resets resolution back if changed
    Private Sub MainFrm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        SaveSetting("AB3", "User", "Name", tbID.Text)
        SaveSetting("AB3", "User", "Pswd", tbPW.Text)
        If gbLogin.Visible = False Then Logout()
        Me.Visible = False
        If IsWindowed = False Then
            Call ChangeScrnRes(ScreenRes.Width, ScreenRes.Height)
        End If
        End
    End Sub

    'Users keyboard actions detection, mostly movement with Arrows or AWSD, and TAB to show/hide more detailed player list in game, 1 to leave game, esc to close game!
    Private Sub MainFrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If IsPlaying = True Then

            Select Case e.KeyCode
                Case Keys.Down
                    PlayerDirection = 1
                Case Keys.Up
                    PlayerDirection = 2
                Case Keys.Left
                    PlayerDirection = 3
                Case Keys.Right
                    PlayerDirection = 4
                Case Keys.S
                    PlayerDirection = 1
                Case Keys.W
                    PlayerDirection = 2
                Case Keys.A
                    PlayerDirection = 3
                Case Keys.D
                    PlayerDirection = 4
                Case Keys.D1
                    If IsPlaying = True Then ExitMaze()
                Case Keys.Tab
                    'Tab in game to show or hide dataa grid of players details
                    If IsPlaying = True Then
                        If dgScores.Visible = True Then
                            dgScores.Visible = False
                            lblScore.Visible = True
                        Else
                            lblScore.Visible = False
                            dgScores.Visible = True
                            dgScores.BringToFront()
                        End If
                    End If
                Case Keys.Escape
                    TerminateSounds()
                    Me.Visible = False
                    Logout()
                    Me.Close()
            End Select

        Else
            Select Case e.KeyCode
                Case Keys.Escape
                    TerminateSounds()
                    Me.Visible = False
                    Logout()
                    Me.Close()
            End Select
        End If

    End Sub

    'This is used through out the program to update status label
    Public Sub UpdateStatus(Message As String)
        lblStatus.Text = Message
        If IsPlaying = True Then lblStatus.BringToFront()
    End Sub

    'The join selected game button
    Private Sub pbJoin_Click(sender As Object, e As EventArgs) Handles pbJoin.Click
        Dim i As Integer = dgGames.CurrentRow.Index
        Debug.Print(dgGames.Item(0, i).Value)
        Dim DataBaseConn As clsMySQLCalls = New clsMySQLCalls
        GettingHostID = True
        IsHosting = False
        Me.UpdateStatus("Connecting to Selected Game...")
        'Needs to verify the game exists still, and if does gather the game ID
        DataBaseConn.CheckOnlineStatus(-1, dgGames.Item(0, i).Value)
    End Sub

    'The start hosting new game button
    Private Sub pbHosts_Click(sender As Object, e As EventArgs) Handles pbHosts.Click
        Dim DataBaseConn As clsMySQLCalls = New clsMySQLCalls
        GettingHostID = False
        IsHosting = True
        Me.UpdateStatus("Gathering Game Map Mazes...")
        'Request list of all maps in DB to show user for selecting map maze for newly hosted game
        DataBaseConn.GetMapNames()
    End Sub

    'The login / register button, saves the user account and password then calls a DB procedure to verify account, or create it, etc
    Private Sub pbLogin_Click(sender As Object, e As EventArgs) Handles pbLogin.Click
        SaveSetting("AB3", "User", "Name", tbID.Text)
        SaveSetting("AB3", "User", "Pswd", tbPW.Text)
        Dim DataBaseConn As clsMySQLCalls = New clsMySQLCalls
        Me.UpdateStatus("Logging in to Game Server...")
        DataBaseConn.LoginUser(tbID.Text, tbPW.Text)
    End Sub

    'The confirm map selection button at map selection menu for hosting new game process
    Private Sub pbMapNext_Click(sender As Object, e As EventArgs) Handles pbMapNext.Click
        Dim i As Integer = dgMaps.CurrentRow.Index
        Debug.Print(dgMaps.Item(0, i).Value)
        GameMapname = dgMaps.Item(0, i).Value
        Dim DataBaseConn As clsMySQLCalls = New clsMySQLCalls
        GettingHostID = False
        IsHosting = True
        Me.UpdateStatus("Gathering Selected Map Maze Layout...")
        'Now get the map layout details for the selected mapname choosen.. and then show character selection
        DataBaseConn.GetPlayerMapInfo(0, GameMapname)
    End Sub

    'Show admin area button at lobby
    Private Sub pbAdmin_Click(sender As Object, e As EventArgs) Handles pbAdmin.Click
        gbLobby.Visible = False
        Me.UpdateStatus("Loading Admin Area....")
        gbAdmin.Visible = True
        'After hiding lobby and showing admin area, refresh the admin grids
        dgAdminRefresh()
        Me.UpdateStatus("Admin Control Lists Refreshed!!")
    End Sub

    'Sub task to refresh Admin Grids with Data Binding
    Private Sub dgAdminRefresh()
        Me.dgPlayersAdmin.DataSource = DataBindAccess.PlayersBinding
        Me.dgGameList.DataSource = DataBindAccess.GamesBinding
        Me.dgGamePlayersAdmin.DataSource = DataBindAccess.GPlayersBinding
    End Sub

    'The button in admin area to update database for all admin changes made
    Private Sub pbApplyAdminChanges_Click(sender As Object, e As EventArgs) Handles pbApplyAdminChanges.Click
        Me.UpdateStatus("Saving Admin Changes If Any....")
        'Closes out of editing mode to all grids, to enabled saving changes to them
        Me.dgPlayersAdmin.EndEdit()
        Me.dgGames.EndEdit()
        Me.dgGamePlayersAdmin.EndEdit()
        'Use the data binding to update all changes made to each grid
        DataBindAccess.PlayersBinding = Me.dgPlayersAdmin.DataSource
        DataBindAccess.GamesBinding = Me.dgGameList.DataSource
        DataBindAccess.GPlayersBinding = Me.dgGamePlayersAdmin.DataSource
        Me.UpdateStatus("Admin Changes Applied Where Possible!")
        'Refresh admin grids
        dgAdminRefresh()
    End Sub

    'Button at admin area to refresh the admin grids manually at any time
    Private Sub pbRefreshAdminLists_Click(sender As Object, e As EventArgs) Handles pbRefreshAdminLists.Click
        Me.UpdateStatus("Refreshing Admin Control Lists....")
        dgAdminRefresh()
        Me.UpdateStatus("Admin Control Lists Refreshed!!")
    End Sub

    'Button at lobby to show the Map Maze Creator / Editor (Gets map info if exist for player to load exisitng map if have)
    Private Sub pbMazeEdit_Click(sender As Object, e As EventArgs) Handles pbMazeEdit.Click
        Dim DataBaseConn As clsMySQLCalls = New clsMySQLCalls
        GettingHostID = False
        IsHosting = False
        Me.UpdateStatus("Checking for Existing Player Map Maze Data....")
        DataBaseConn.GetPlayerMapInfo(PlayerID, "")
    End Sub

    'Mouse click even for bgMaze2, the picture box used for designing and creating custom map mazes, to show/hide blocks!
    Private Sub bgMaze2_MouseClick(sender As Object, e As MouseEventArgs) Handles bgMaze2.MouseClick
        Dim TheX As Point = e.Location
        Debug.Print(TheX.X & " & " & TheX.Y)
        'Check first that tey not trying to click and remove a block from the outer walling
        If TheX.X < 16 Or TheX.X > (38 * 16) Or TheX.Y < 16 Or TheX.Y > (20 * 16) Then Exit Sub
        'Now show or hide the block, if showing it does  random block image each time, just for visual fun
        Dim rndHedge As Integer = 0
        For Each mCell As clsMazeWall In MazeCells
            If TheX.X > mCell.Left And TheX.X < (mCell.Left + 16) And TheX.Y > mCell.Top And TheX.Y < (mCell.Top + 16) Then
                If mCell.Type = 0 Then
                    mCell.Type = 1
                    rndHedge = GenRandomInt(1, 22)
                    If rndHedge > 15 Then
                        Graphics.FromImage(Me.bgMaze2.Image).DrawImage(stones1, New Rectangle(mCell.Left, mCell.Top, mCell.Width, mCell.Height), New Rectangle(0, 0, woods1.Width, woods1.Height), GraphicsUnit.Pixel)
                    ElseIf rndHedge > 14 Then
                        Graphics.FromImage(Me.bgMaze2.Image).DrawImage(woods2, New Rectangle(mCell.Left, mCell.Top, mCell.Width, mCell.Height), New Rectangle(0, 0, woods2.Width, woods3.Height), GraphicsUnit.Pixel)
                    ElseIf rndHedge > 13 Then
                        Graphics.FromImage(Me.bgMaze2.Image).DrawImage(woods3, New Rectangle(mCell.Left, mCell.Top, mCell.Width, mCell.Height), New Rectangle(0, 0, woods3.Width, woods3.Height), GraphicsUnit.Pixel)
                    ElseIf rndHedge > 12 Then
                        Graphics.FromImage(Me.bgMaze2.Image).DrawImage(woods4, New Rectangle(mCell.Left, mCell.Top, mCell.Width, mCell.Height), New Rectangle(0, 0, woods4.Width, woods4.Height), GraphicsUnit.Pixel)
                    ElseIf rndHedge > 11 Then
                        Graphics.FromImage(Me.bgMaze2.Image).DrawImage(woods5, New Rectangle(mCell.Left, mCell.Top, mCell.Width, mCell.Height), New Rectangle(0, 0, woods5.Width, woods5.Height), GraphicsUnit.Pixel)
                    ElseIf rndHedge > 10 Then
                        Graphics.FromImage(Me.bgMaze2.Image).DrawImage(woods6, New Rectangle(mCell.Left, mCell.Top, mCell.Width, mCell.Height), New Rectangle(0, 0, woods6.Width, woods6.Height), GraphicsUnit.Pixel)
                    ElseIf rndHedge > 9 Then
                        Graphics.FromImage(Me.bgMaze2.Image).DrawImage(woods1, New Rectangle(mCell.Left, mCell.Top, mCell.Width, mCell.Height), New Rectangle(0, 0, stones2.Width, stones2.Height), GraphicsUnit.Pixel)
                    Else
                        Graphics.FromImage(Me.bgMaze2.Image).DrawImage(stones2, New Rectangle(mCell.Left, mCell.Top, mCell.Width, mCell.Height), New Rectangle(0, 0, stones1.Width, stones1.Height), GraphicsUnit.Pixel)
                    End If
                Else
                    mCell.Type = 0
                    Graphics.FromImage(bgMaze2.Image).DrawImage(BackCharImage, New Rectangle(mCell.Left, mCell.Top, mCell.Width, mCell.Height), New Rectangle(mCell.Left + gbCustomMaze.Left + bgMaze2.Left, mCell.Top + gbCustomMaze.Top + bgMaze2.Top, mCell.Width, mCell.Height), GraphicsUnit.Pixel)
                End If
            End If
        Next
        'Refresh the Maze PB Control to show change made
        Me.bgMaze2.Refresh()
    End Sub

    'Button at Map maze creator to ADD or Update Maze for a user
    Private Sub pbUpdateAddMap_Click(sender As Object, e As EventArgs) Handles pbUpdateAddMap.Click
        Me.UpdateStatus("Compiling Current Maze Layout....")
        PauseMe(200)
        GameMap = ""
        'Builds the maze layout from drawn map maze, into 1's and spaces to store in the database!
        For Each mCell As clsMazeWall In MazeCells
            If mCell.Type = 1 Then
                GameMap = GameMap & "1"
            Else
                GameMap = GameMap & " "
            End If
        Next
        Dim DataBaseConn As clsMySQLCalls = New clsMySQLCalls
        Me.UpdateStatus("Attempting To Add/Update Map Maze Details....")
        'Call procedure to update/add map maze
        DataBaseConn.AddUpdateMap(PlayerID, tbMapName.Text, GameMap)
    End Sub

    'Button to navigate Leave game back to lobby, go back at anytime from any area, Logout from lobby, close game form login menu
    Private Sub pbBack_Click(sender As Object, e As EventArgs) Handles pbBack.Click
        If IsPlaying = True Then
            ExitMaze()
        ElseIf gbCustomMaze.Visible = True Then
            HideMenus()
            gbLobby.Visible = True
            gbLobby.BringToFront()
            Me.UpdateStatus("Back in Game Lobby.. Now Play A Game!")
            GetLobbyLists()
        ElseIf gbAdmin.Visible = True Then
            HideMenus()
            gbLobby.Visible = True
            gbLobby.BringToFront()
            Me.UpdateStatus("Back in Game Lobby.. Now Play A Game!")
            GetLobbyLists()
        ElseIf gbMapSel.Visible = True Then
            HideMenus()
            gbLobby.Visible = True
            gbLobby.BringToFront()
            Me.UpdateStatus("Back in Game Lobby.. Now Play A Game!")
            GetLobbyLists()
        ElseIf gbCharSel.Visible = True Then
            HideMenus()
            gbLobby.Visible = True
            gbLobby.BringToFront()
            Me.UpdateStatus("Back in Game Lobby.. Now Play A Game!")
            GetLobbyLists()
        ElseIf gbLobby.Visible = True Then
            HideMenus()
            gbLogin.Visible = True
            gbLogin.BringToFront()
            Logout()
        ElseIf gbLogin.Visible = True Then
            TerminateSounds()
            Me.Close()
        End If
    End Sub

    'Button to manually refresh lobby lists at any time
    Private Sub pbRefreshLobby_Click(sender As Object, e As EventArgs) Handles pbRefreshLobby.Click
        GetLobbyLists()
    End Sub
End Class
