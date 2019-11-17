<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.tmrDraw = New System.Windows.Forms.Timer(Me.components)
        Me.tmrFinish = New System.Windows.Forms.Timer(Me.components)
        Me.lblScore = New System.Windows.Forms.Label()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenMazeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitMazeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QuitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmrMove = New System.Windows.Forms.Timer(Me.components)
        Me.gbLogin = New System.Windows.Forms.GroupBox()
        Me.pbLogin = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.tbPW = New System.Windows.Forms.TextBox()
        Me.tbID = New System.Windows.Forms.TextBox()
        Me.gbCustomMaze = New System.Windows.Forms.GroupBox()
        Me.lblMapName = New System.Windows.Forms.Label()
        Me.tbMapName = New System.Windows.Forms.TextBox()
        Me.bgMaze2 = New System.Windows.Forms.PictureBox()
        Me.pbUpdateAddMap = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.gbAdmin = New System.Windows.Forms.GroupBox()
        Me.pbRefreshAdminLists = New System.Windows.Forms.PictureBox()
        Me.pbApplyAdminChanges = New System.Windows.Forms.PictureBox()
        Me.dgGamePlayersAdmin = New System.Windows.Forms.DataGridView()
        Me.lblUsers = New System.Windows.Forms.Label()
        Me.lblPlayers = New System.Windows.Forms.Label()
        Me.dgPlayersAdmin = New System.Windows.Forms.DataGridView()
        Me.dgGameList = New System.Windows.Forms.DataGridView()
        Me.lblGameList = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.gbMapSel = New System.Windows.Forms.GroupBox()
        Me.pbMapNext = New System.Windows.Forms.PictureBox()
        Me.dgMaps = New System.Windows.Forms.DataGridView()
        Me.lblMaps = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.gbLobby = New System.Windows.Forms.GroupBox()
        Me.pbRefreshLobby = New System.Windows.Forms.PictureBox()
        Me.pbMazeEdit = New System.Windows.Forms.PictureBox()
        Me.pbAdmin = New System.Windows.Forms.PictureBox()
        Me.pbJoin = New System.Windows.Forms.PictureBox()
        Me.pbHosts = New System.Windows.Forms.PictureBox()
        Me.dgHighscores = New System.Windows.Forms.DataGridView()
        Me.lblOnlines = New System.Windows.Forms.Label()
        Me.lblHighScores = New System.Windows.Forms.Label()
        Me.dgOnlines = New System.Windows.Forms.DataGridView()
        Me.dgGames = New System.Windows.Forms.DataGridView()
        Me.lblGames = New System.Windows.Forms.Label()
        Me.pbLogo2 = New System.Windows.Forms.PictureBox()
        Me.gbCharSel = New System.Windows.Forms.GroupBox()
        Me.pbStart = New System.Windows.Forms.PictureBox()
        Me.lbCharSel = New System.Windows.Forms.Label()
        Me.pbBomb = New System.Windows.Forms.PictureBox()
        Me.pbYellow = New System.Windows.Forms.PictureBox()
        Me.pbBlue = New System.Windows.Forms.PictureBox()
        Me.pbPink = New System.Windows.Forms.PictureBox()
        Me.pbPig = New System.Windows.Forms.PictureBox()
        Me.pbRed = New System.Windows.Forms.PictureBox()
        Me.dgScores = New System.Windows.Forms.DataGridView()
        Me.pbBack = New System.Windows.Forms.PictureBox()
        Me.bgMaze = New System.Windows.Forms.PictureBox()
        Me.ttGame = New System.Windows.Forms.ToolTip(Me.components)
        Me.gbLogin.SuspendLayout()
        CType(Me.pbLogin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCustomMaze.SuspendLayout()
        CType(Me.bgMaze2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbUpdateAddMap, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbAdmin.SuspendLayout()
        CType(Me.pbRefreshAdminLists, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbApplyAdminChanges, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgGamePlayersAdmin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgPlayersAdmin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgGameList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbMapSel.SuspendLayout()
        CType(Me.pbMapNext, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgMaps, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbLobby.SuspendLayout()
        CType(Me.pbRefreshLobby, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbMazeEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAdmin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbJoin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbHosts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgHighscores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgOnlines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgGames, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbLogo2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCharSel.SuspendLayout()
        CType(Me.pbStart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbBomb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbYellow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbBlue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbPink, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbPig, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbRed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgScores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbBack, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bgMaze, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tmrDraw
        '
        Me.tmrDraw.Enabled = True
        '
        'tmrFinish
        '
        Me.tmrFinish.Interval = 500
        '
        'lblScore
        '
        Me.lblScore.BackColor = System.Drawing.Color.Transparent
        Me.lblScore.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScore.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblScore.Location = New System.Drawing.Point(6, 70)
        Me.lblScore.Name = "lblScore"
        Me.lblScore.Size = New System.Drawing.Size(300, 500)
        Me.lblScore.TabIndex = 3
        Me.lblScore.Text = "Player1 0"
        Me.lblScore.Visible = False
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Padding = New System.Windows.Forms.Padding(0)
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(29, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'OpenMazeToolStripMenuItem
        '
        Me.OpenMazeToolStripMenuItem.Name = "OpenMazeToolStripMenuItem"
        Me.OpenMazeToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.OpenMazeToolStripMenuItem.Text = "&Open Maze"
        '
        'ExitMazeToolStripMenuItem
        '
        Me.ExitMazeToolStripMenuItem.Name = "ExitMazeToolStripMenuItem"
        Me.ExitMazeToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.ExitMazeToolStripMenuItem.Text = "&Exit Maze"
        '
        'QuitToolStripMenuItem
        '
        Me.QuitToolStripMenuItem.Name = "QuitToolStripMenuItem"
        Me.QuitToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.QuitToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.QuitToolStripMenuItem.Text = "&Quit"
        '
        'tmrMove
        '
        Me.tmrMove.Interval = 250
        '
        'gbLogin
        '
        Me.gbLogin.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.gbLogin.BackColor = System.Drawing.Color.Transparent
        Me.gbLogin.Controls.Add(Me.pbLogin)
        Me.gbLogin.Controls.Add(Me.Label1)
        Me.gbLogin.Controls.Add(Me.PictureBox1)
        Me.gbLogin.Controls.Add(Me.tbPW)
        Me.gbLogin.Controls.Add(Me.tbID)
        Me.gbLogin.Location = New System.Drawing.Point(1090, 122)
        Me.gbLogin.Name = "gbLogin"
        Me.gbLogin.Size = New System.Drawing.Size(690, 459)
        Me.gbLogin.TabIndex = 47
        Me.gbLogin.TabStop = False
        '
        'pbLogin
        '
        Me.pbLogin.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pbLogin.BackColor = System.Drawing.Color.Transparent
        Me.pbLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbLogin.Image = Global.AngryBirds3.My.Resources.Resources.play
        Me.pbLogin.Location = New System.Drawing.Point(394, 369)
        Me.pbLogin.Name = "pbLogin"
        Me.pbLogin.Size = New System.Drawing.Size(98, 84)
        Me.pbLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbLogin.TabIndex = 53
        Me.pbLogin.TabStop = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Segoe Script", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(19, 321)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(647, 52)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "MAZE RUNNER"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.AngryBirds3.My.Resources.Resources.angry_birds_logo
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(22, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(648, 299)
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'tbPW
        '
        Me.tbPW.Location = New System.Drawing.Point(205, 418)
        Me.tbPW.Name = "tbPW"
        Me.tbPW.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbPW.Size = New System.Drawing.Size(173, 20)
        Me.tbPW.TabIndex = 3
        Me.tbPW.Text = "Password"
        Me.tbPW.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbID
        '
        Me.tbID.Location = New System.Drawing.Point(205, 382)
        Me.tbID.Name = "tbID"
        Me.tbID.Size = New System.Drawing.Size(173, 20)
        Me.tbID.TabIndex = 2
        Me.tbID.Text = "UserID"
        Me.tbID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'gbCustomMaze
        '
        Me.gbCustomMaze.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.gbCustomMaze.BackColor = System.Drawing.Color.Transparent
        Me.gbCustomMaze.Controls.Add(Me.lblMapName)
        Me.gbCustomMaze.Controls.Add(Me.tbMapName)
        Me.gbCustomMaze.Controls.Add(Me.bgMaze2)
        Me.gbCustomMaze.Controls.Add(Me.pbUpdateAddMap)
        Me.gbCustomMaze.Controls.Add(Me.PictureBox5)
        Me.gbCustomMaze.Location = New System.Drawing.Point(312, 12)
        Me.gbCustomMaze.Name = "gbCustomMaze"
        Me.gbCustomMaze.Size = New System.Drawing.Size(691, 475)
        Me.gbCustomMaze.TabIndex = 55
        Me.gbCustomMaze.TabStop = False
        Me.gbCustomMaze.Visible = False
        '
        'lblMapName
        '
        Me.lblMapName.Font = New System.Drawing.Font("Segoe Script", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMapName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblMapName.Location = New System.Drawing.Point(30, 375)
        Me.lblMapName.Name = "lblMapName"
        Me.lblMapName.Size = New System.Drawing.Size(236, 33)
        Me.lblMapName.TabIndex = 57
        Me.lblMapName.Text = "Mapname:"
        '
        'tbMapName
        '
        Me.tbMapName.Location = New System.Drawing.Point(31, 414)
        Me.tbMapName.Name = "tbMapName"
        Me.tbMapName.Size = New System.Drawing.Size(217, 20)
        Me.tbMapName.TabIndex = 56
        '
        'bgMaze2
        '
        Me.bgMaze2.BackColor = System.Drawing.Color.Transparent
        Me.bgMaze2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bgMaze2.Location = New System.Drawing.Point(31, 19)
        Me.bgMaze2.Name = "bgMaze2"
        Me.bgMaze2.Size = New System.Drawing.Size(626, 348)
        Me.bgMaze2.TabIndex = 55
        Me.bgMaze2.TabStop = False
        Me.bgMaze2.Visible = False
        '
        'pbUpdateAddMap
        '
        Me.pbUpdateAddMap.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pbUpdateAddMap.BackColor = System.Drawing.Color.Transparent
        Me.pbUpdateAddMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbUpdateAddMap.Image = Global.AngryBirds3.My.Resources.Resources.hazard
        Me.pbUpdateAddMap.Location = New System.Drawing.Point(603, 381)
        Me.pbUpdateAddMap.Name = "pbUpdateAddMap"
        Me.pbUpdateAddMap.Size = New System.Drawing.Size(81, 80)
        Me.pbUpdateAddMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbUpdateAddMap.TabIndex = 54
        Me.pbUpdateAddMap.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.BackgroundImage = Global.AngryBirds3.My.Resources.Resources.angry_birds_logo
        Me.PictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox5.Location = New System.Drawing.Point(274, 373)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(147, 83)
        Me.PictureBox5.TabIndex = 6
        Me.PictureBox5.TabStop = False
        '
        'gbAdmin
        '
        Me.gbAdmin.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.gbAdmin.BackColor = System.Drawing.Color.Transparent
        Me.gbAdmin.Controls.Add(Me.pbRefreshAdminLists)
        Me.gbAdmin.Controls.Add(Me.pbApplyAdminChanges)
        Me.gbAdmin.Controls.Add(Me.dgGamePlayersAdmin)
        Me.gbAdmin.Controls.Add(Me.lblUsers)
        Me.gbAdmin.Controls.Add(Me.lblPlayers)
        Me.gbAdmin.Controls.Add(Me.dgPlayersAdmin)
        Me.gbAdmin.Controls.Add(Me.dgGameList)
        Me.gbAdmin.Controls.Add(Me.lblGameList)
        Me.gbAdmin.Controls.Add(Me.PictureBox3)
        Me.gbAdmin.Location = New System.Drawing.Point(1055, 144)
        Me.gbAdmin.Name = "gbAdmin"
        Me.gbAdmin.Size = New System.Drawing.Size(690, 459)
        Me.gbAdmin.TabIndex = 50
        Me.gbAdmin.TabStop = False
        Me.gbAdmin.Visible = False
        '
        'pbRefreshAdminLists
        '
        Me.pbRefreshAdminLists.BackgroundImage = Global.AngryBirds3.My.Resources.Resources.star
        Me.pbRefreshAdminLists.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbRefreshAdminLists.Location = New System.Drawing.Point(14, 368)
        Me.pbRefreshAdminLists.Name = "pbRefreshAdminLists"
        Me.pbRefreshAdminLists.Size = New System.Drawing.Size(91, 85)
        Me.pbRefreshAdminLists.TabIndex = 19
        Me.pbRefreshAdminLists.TabStop = False
        '
        'pbApplyAdminChanges
        '
        Me.pbApplyAdminChanges.BackgroundImage = Global.AngryBirds3.My.Resources.Resources.host
        Me.pbApplyAdminChanges.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbApplyAdminChanges.Location = New System.Drawing.Point(587, 368)
        Me.pbApplyAdminChanges.Name = "pbApplyAdminChanges"
        Me.pbApplyAdminChanges.Size = New System.Drawing.Size(91, 85)
        Me.pbApplyAdminChanges.TabIndex = 18
        Me.pbApplyAdminChanges.TabStop = False
        '
        'dgGamePlayersAdmin
        '
        Me.dgGamePlayersAdmin.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgGamePlayersAdmin.BackgroundColor = System.Drawing.Color.White
        Me.dgGamePlayersAdmin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgGamePlayersAdmin.Location = New System.Drawing.Point(375, 49)
        Me.dgGamePlayersAdmin.Name = "dgGamePlayersAdmin"
        Me.dgGamePlayersAdmin.Size = New System.Drawing.Size(303, 136)
        Me.dgGamePlayersAdmin.TabIndex = 12
        '
        'lblUsers
        '
        Me.lblUsers.Font = New System.Drawing.Font("Segoe Script", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsers.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblUsers.Location = New System.Drawing.Point(12, 188)
        Me.lblUsers.Name = "lblUsers"
        Me.lblUsers.Size = New System.Drawing.Size(236, 33)
        Me.lblUsers.TabIndex = 11
        Me.lblUsers.Text = "Player Details:"
        '
        'lblPlayers
        '
        Me.lblPlayers.Font = New System.Drawing.Font("Segoe Script", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlayers.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblPlayers.Location = New System.Drawing.Point(369, 13)
        Me.lblPlayers.Name = "lblPlayers"
        Me.lblPlayers.Size = New System.Drawing.Size(259, 33)
        Me.lblPlayers.TabIndex = 10
        Me.lblPlayers.Text = "Game Players:"
        '
        'dgPlayersAdmin
        '
        Me.dgPlayersAdmin.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgPlayersAdmin.BackgroundColor = System.Drawing.Color.White
        Me.dgPlayersAdmin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgPlayersAdmin.Location = New System.Drawing.Point(14, 223)
        Me.dgPlayersAdmin.Name = "dgPlayersAdmin"
        Me.dgPlayersAdmin.Size = New System.Drawing.Size(664, 139)
        Me.dgPlayersAdmin.TabIndex = 9
        '
        'dgGameList
        '
        Me.dgGameList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgGameList.BackgroundColor = System.Drawing.Color.White
        Me.dgGameList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgGameList.Location = New System.Drawing.Point(14, 49)
        Me.dgGameList.Name = "dgGameList"
        Me.dgGameList.ReadOnly = True
        Me.dgGameList.Size = New System.Drawing.Size(355, 136)
        Me.dgGameList.TabIndex = 8
        '
        'lblGameList
        '
        Me.lblGameList.Font = New System.Drawing.Font("Segoe Script", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGameList.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblGameList.Location = New System.Drawing.Point(12, 13)
        Me.lblGameList.Name = "lblGameList"
        Me.lblGameList.Size = New System.Drawing.Size(236, 33)
        Me.lblGameList.TabIndex = 7
        Me.lblGameList.Text = "Games:"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackgroundImage = Global.AngryBirds3.My.Resources.Resources.angry_birds_logo
        Me.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox3.Location = New System.Drawing.Point(268, 368)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(151, 85)
        Me.PictureBox3.TabIndex = 6
        Me.PictureBox3.TabStop = False
        '
        'gbMapSel
        '
        Me.gbMapSel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.gbMapSel.BackColor = System.Drawing.Color.Transparent
        Me.gbMapSel.Controls.Add(Me.pbMapNext)
        Me.gbMapSel.Controls.Add(Me.dgMaps)
        Me.gbMapSel.Controls.Add(Me.lblMaps)
        Me.gbMapSel.Controls.Add(Me.PictureBox4)
        Me.gbMapSel.Location = New System.Drawing.Point(1210, 36)
        Me.gbMapSel.Name = "gbMapSel"
        Me.gbMapSel.Size = New System.Drawing.Size(690, 459)
        Me.gbMapSel.TabIndex = 52
        Me.gbMapSel.TabStop = False
        Me.gbMapSel.Visible = False
        '
        'pbMapNext
        '
        Me.pbMapNext.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pbMapNext.BackColor = System.Drawing.Color.Transparent
        Me.pbMapNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbMapNext.Image = Global.AngryBirds3.My.Resources.Resources.hazard
        Me.pbMapNext.Location = New System.Drawing.Point(545, 315)
        Me.pbMapNext.Name = "pbMapNext"
        Me.pbMapNext.Size = New System.Drawing.Size(133, 125)
        Me.pbMapNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbMapNext.TabIndex = 54
        Me.pbMapNext.TabStop = False
        '
        'dgMaps
        '
        Me.dgMaps.AllowUserToAddRows = False
        Me.dgMaps.AllowUserToDeleteRows = False
        Me.dgMaps.AllowUserToResizeColumns = False
        Me.dgMaps.AllowUserToResizeRows = False
        Me.dgMaps.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgMaps.BackgroundColor = System.Drawing.Color.White
        Me.dgMaps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgMaps.Location = New System.Drawing.Point(14, 49)
        Me.dgMaps.Name = "dgMaps"
        Me.dgMaps.ReadOnly = True
        Me.dgMaps.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgMaps.ShowCellToolTips = False
        Me.dgMaps.Size = New System.Drawing.Size(400, 391)
        Me.dgMaps.TabIndex = 8
        '
        'lblMaps
        '
        Me.lblMaps.Font = New System.Drawing.Font("Segoe Script", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMaps.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblMaps.Location = New System.Drawing.Point(12, 13)
        Me.lblMaps.Name = "lblMaps"
        Me.lblMaps.Size = New System.Drawing.Size(236, 33)
        Me.lblMaps.TabIndex = 7
        Me.lblMaps.Text = "Select Map:"
        '
        'PictureBox4
        '
        Me.PictureBox4.BackgroundImage = Global.AngryBirds3.My.Resources.Resources.angry_birds_logo
        Me.PictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox4.Location = New System.Drawing.Point(420, 49)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(258, 162)
        Me.PictureBox4.TabIndex = 6
        Me.PictureBox4.TabStop = False
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblStatus.Font = New System.Drawing.Font("Showcard Gothic", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblStatus.Location = New System.Drawing.Point(1, 663)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(1361, 82)
        Me.lblStatus.TabIndex = 48
        Me.lblStatus.Text = "STATUS.."
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gbLobby
        '
        Me.gbLobby.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.gbLobby.BackColor = System.Drawing.Color.Transparent
        Me.gbLobby.Controls.Add(Me.pbRefreshLobby)
        Me.gbLobby.Controls.Add(Me.pbMazeEdit)
        Me.gbLobby.Controls.Add(Me.pbAdmin)
        Me.gbLobby.Controls.Add(Me.pbJoin)
        Me.gbLobby.Controls.Add(Me.pbHosts)
        Me.gbLobby.Controls.Add(Me.dgHighscores)
        Me.gbLobby.Controls.Add(Me.lblOnlines)
        Me.gbLobby.Controls.Add(Me.lblHighScores)
        Me.gbLobby.Controls.Add(Me.dgOnlines)
        Me.gbLobby.Controls.Add(Me.dgGames)
        Me.gbLobby.Controls.Add(Me.lblGames)
        Me.gbLobby.Controls.Add(Me.pbLogo2)
        Me.gbLobby.Location = New System.Drawing.Point(1166, 65)
        Me.gbLobby.Name = "gbLobby"
        Me.gbLobby.Size = New System.Drawing.Size(690, 459)
        Me.gbLobby.TabIndex = 49
        Me.gbLobby.TabStop = False
        Me.gbLobby.Visible = False
        '
        'pbRefreshLobby
        '
        Me.pbRefreshLobby.BackgroundImage = Global.AngryBirds3.My.Resources.Resources.star
        Me.pbRefreshLobby.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbRefreshLobby.Location = New System.Drawing.Point(14, 368)
        Me.pbRefreshLobby.Name = "pbRefreshLobby"
        Me.pbRefreshLobby.Size = New System.Drawing.Size(91, 85)
        Me.pbRefreshLobby.TabIndex = 18
        Me.pbRefreshLobby.TabStop = False
        '
        'pbMazeEdit
        '
        Me.pbMazeEdit.BackgroundImage = Global.AngryBirds3.My.Resources.Resources.hazard
        Me.pbMazeEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbMazeEdit.Location = New System.Drawing.Point(111, 368)
        Me.pbMazeEdit.Name = "pbMazeEdit"
        Me.pbMazeEdit.Size = New System.Drawing.Size(91, 85)
        Me.pbMazeEdit.TabIndex = 17
        Me.pbMazeEdit.TabStop = False
        '
        'pbAdmin
        '
        Me.pbAdmin.BackgroundImage = Global.AngryBirds3.My.Resources.Resources.man2
        Me.pbAdmin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbAdmin.Location = New System.Drawing.Point(208, 288)
        Me.pbAdmin.Name = "pbAdmin"
        Me.pbAdmin.Size = New System.Drawing.Size(91, 85)
        Me.pbAdmin.TabIndex = 16
        Me.pbAdmin.TabStop = False
        '
        'pbJoin
        '
        Me.pbJoin.BackgroundImage = Global.AngryBirds3.My.Resources.Resources.play
        Me.pbJoin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbJoin.Location = New System.Drawing.Point(111, 288)
        Me.pbJoin.Name = "pbJoin"
        Me.pbJoin.Size = New System.Drawing.Size(91, 85)
        Me.pbJoin.TabIndex = 15
        Me.pbJoin.TabStop = False
        '
        'pbHosts
        '
        Me.pbHosts.BackgroundImage = Global.AngryBirds3.My.Resources.Resources.newhost
        Me.pbHosts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbHosts.Location = New System.Drawing.Point(14, 288)
        Me.pbHosts.Name = "pbHosts"
        Me.pbHosts.Size = New System.Drawing.Size(91, 85)
        Me.pbHosts.TabIndex = 14
        Me.pbHosts.TabStop = False
        '
        'dgHighscores
        '
        Me.dgHighscores.AllowUserToAddRows = False
        Me.dgHighscores.AllowUserToDeleteRows = False
        Me.dgHighscores.AllowUserToResizeColumns = False
        Me.dgHighscores.AllowUserToResizeRows = False
        Me.dgHighscores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgHighscores.BackgroundColor = System.Drawing.Color.White
        Me.dgHighscores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgHighscores.Location = New System.Drawing.Point(425, 49)
        Me.dgHighscores.Name = "dgHighscores"
        Me.dgHighscores.ReadOnly = True
        Me.dgHighscores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgHighscores.ShowCellToolTips = False
        Me.dgHighscores.Size = New System.Drawing.Size(253, 248)
        Me.dgHighscores.TabIndex = 12
        '
        'lblOnlines
        '
        Me.lblOnlines.Font = New System.Drawing.Font("Segoe Script", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOnlines.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblOnlines.Location = New System.Drawing.Point(419, 300)
        Me.lblOnlines.Name = "lblOnlines"
        Me.lblOnlines.Size = New System.Drawing.Size(236, 33)
        Me.lblOnlines.TabIndex = 11
        Me.lblOnlines.Text = "Online Players:"
        '
        'lblHighScores
        '
        Me.lblHighScores.Font = New System.Drawing.Font("Segoe Script", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHighScores.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblHighScores.Location = New System.Drawing.Point(419, 13)
        Me.lblHighScores.Name = "lblHighScores"
        Me.lblHighScores.Size = New System.Drawing.Size(259, 33)
        Me.lblHighScores.TabIndex = 10
        Me.lblHighScores.Text = "Top 10 Leaderboard:"
        '
        'dgOnlines
        '
        Me.dgOnlines.AllowUserToAddRows = False
        Me.dgOnlines.AllowUserToDeleteRows = False
        Me.dgOnlines.AllowUserToResizeColumns = False
        Me.dgOnlines.AllowUserToResizeRows = False
        Me.dgOnlines.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgOnlines.BackgroundColor = System.Drawing.Color.White
        Me.dgOnlines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgOnlines.Location = New System.Drawing.Point(425, 336)
        Me.dgOnlines.Name = "dgOnlines"
        Me.dgOnlines.ReadOnly = True
        Me.dgOnlines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgOnlines.ShowCellToolTips = False
        Me.dgOnlines.Size = New System.Drawing.Size(253, 117)
        Me.dgOnlines.TabIndex = 9
        '
        'dgGames
        '
        Me.dgGames.AllowUserToAddRows = False
        Me.dgGames.AllowUserToDeleteRows = False
        Me.dgGames.AllowUserToResizeColumns = False
        Me.dgGames.AllowUserToResizeRows = False
        Me.dgGames.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgGames.BackgroundColor = System.Drawing.Color.White
        Me.dgGames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgGames.Location = New System.Drawing.Point(14, 49)
        Me.dgGames.Name = "dgGames"
        Me.dgGames.Size = New System.Drawing.Size(400, 233)
        Me.dgGames.TabIndex = 8
        '
        'lblGames
        '
        Me.lblGames.Font = New System.Drawing.Font("Segoe Script", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGames.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblGames.Location = New System.Drawing.Point(12, 13)
        Me.lblGames.Name = "lblGames"
        Me.lblGames.Size = New System.Drawing.Size(236, 33)
        Me.lblGames.TabIndex = 7
        Me.lblGames.Text = "Games:"
        '
        'pbLogo2
        '
        Me.pbLogo2.BackgroundImage = Global.AngryBirds3.My.Resources.Resources.angry_birds_logo
        Me.pbLogo2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbLogo2.Location = New System.Drawing.Point(247, 348)
        Me.pbLogo2.Name = "pbLogo2"
        Me.pbLogo2.Size = New System.Drawing.Size(172, 105)
        Me.pbLogo2.TabIndex = 6
        Me.pbLogo2.TabStop = False
        '
        'gbCharSel
        '
        Me.gbCharSel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.gbCharSel.BackColor = System.Drawing.Color.Transparent
        Me.gbCharSel.Controls.Add(Me.pbStart)
        Me.gbCharSel.Controls.Add(Me.lbCharSel)
        Me.gbCharSel.Controls.Add(Me.pbBomb)
        Me.gbCharSel.Controls.Add(Me.pbYellow)
        Me.gbCharSel.Controls.Add(Me.pbBlue)
        Me.gbCharSel.Controls.Add(Me.pbPink)
        Me.gbCharSel.Controls.Add(Me.pbPig)
        Me.gbCharSel.Controls.Add(Me.pbRed)
        Me.gbCharSel.Location = New System.Drawing.Point(1127, 91)
        Me.gbCharSel.Name = "gbCharSel"
        Me.gbCharSel.Size = New System.Drawing.Size(690, 459)
        Me.gbCharSel.TabIndex = 50
        Me.gbCharSel.TabStop = False
        Me.gbCharSel.Visible = False
        '
        'pbStart
        '
        Me.pbStart.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pbStart.BackColor = System.Drawing.Color.Transparent
        Me.pbStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbStart.Image = Global.AngryBirds3.My.Resources.Resources.snow
        Me.pbStart.Location = New System.Drawing.Point(604, 382)
        Me.pbStart.Name = "pbStart"
        Me.pbStart.Size = New System.Drawing.Size(86, 77)
        Me.pbStart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbStart.TabIndex = 52
        Me.pbStart.TabStop = False
        '
        'lbCharSel
        '
        Me.lbCharSel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbCharSel.BackColor = System.Drawing.Color.Transparent
        Me.lbCharSel.Font = New System.Drawing.Font("Comic Sans MS", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCharSel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbCharSel.Location = New System.Drawing.Point(54, 16)
        Me.lbCharSel.Name = "lbCharSel"
        Me.lbCharSel.Size = New System.Drawing.Size(581, 55)
        Me.lbCharSel.TabIndex = 51
        Me.lbCharSel.Text = "Character Selection"
        Me.lbCharSel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pbBomb
        '
        Me.pbBomb.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pbBomb.BackColor = System.Drawing.Color.Transparent
        Me.pbBomb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbBomb.Image = CType(resources.GetObject("pbBomb.Image"), System.Drawing.Image)
        Me.pbBomb.Location = New System.Drawing.Point(72, 234)
        Me.pbBomb.Name = "pbBomb"
        Me.pbBomb.Size = New System.Drawing.Size(160, 145)
        Me.pbBomb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbBomb.TabIndex = 50
        Me.pbBomb.TabStop = False
        Me.pbBomb.Tag = "4"
        '
        'pbYellow
        '
        Me.pbYellow.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pbYellow.BackColor = System.Drawing.Color.Transparent
        Me.pbYellow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbYellow.Image = CType(resources.GetObject("pbYellow.Image"), System.Drawing.Image)
        Me.pbYellow.Location = New System.Drawing.Point(264, 75)
        Me.pbYellow.Name = "pbYellow"
        Me.pbYellow.Size = New System.Drawing.Size(160, 145)
        Me.pbYellow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYellow.TabIndex = 49
        Me.pbYellow.TabStop = False
        Me.pbYellow.Tag = "2"
        '
        'pbBlue
        '
        Me.pbBlue.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pbBlue.BackColor = System.Drawing.Color.Transparent
        Me.pbBlue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbBlue.Image = CType(resources.GetObject("pbBlue.Image"), System.Drawing.Image)
        Me.pbBlue.Location = New System.Drawing.Point(264, 234)
        Me.pbBlue.Name = "pbBlue"
        Me.pbBlue.Size = New System.Drawing.Size(160, 145)
        Me.pbBlue.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbBlue.TabIndex = 48
        Me.pbBlue.TabStop = False
        Me.pbBlue.Tag = "5"
        '
        'pbPink
        '
        Me.pbPink.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pbPink.BackColor = System.Drawing.Color.Transparent
        Me.pbPink.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbPink.Image = CType(resources.GetObject("pbPink.Image"), System.Drawing.Image)
        Me.pbPink.Location = New System.Drawing.Point(458, 75)
        Me.pbPink.Name = "pbPink"
        Me.pbPink.Size = New System.Drawing.Size(160, 145)
        Me.pbPink.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbPink.TabIndex = 47
        Me.pbPink.TabStop = False
        Me.pbPink.Tag = "3"
        '
        'pbPig
        '
        Me.pbPig.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pbPig.BackColor = System.Drawing.Color.Transparent
        Me.pbPig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbPig.Image = CType(resources.GetObject("pbPig.Image"), System.Drawing.Image)
        Me.pbPig.Location = New System.Drawing.Point(458, 234)
        Me.pbPig.Name = "pbPig"
        Me.pbPig.Size = New System.Drawing.Size(160, 145)
        Me.pbPig.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbPig.TabIndex = 46
        Me.pbPig.TabStop = False
        Me.pbPig.Tag = "6"
        '
        'pbRed
        '
        Me.pbRed.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pbRed.BackColor = System.Drawing.Color.Transparent
        Me.pbRed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbRed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbRed.Image = CType(resources.GetObject("pbRed.Image"), System.Drawing.Image)
        Me.pbRed.Location = New System.Drawing.Point(72, 75)
        Me.pbRed.Name = "pbRed"
        Me.pbRed.Size = New System.Drawing.Size(160, 145)
        Me.pbRed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbRed.TabIndex = 45
        Me.pbRed.TabStop = False
        Me.pbRed.Tag = "1"
        '
        'dgScores
        '
        Me.dgScores.AllowUserToAddRows = False
        Me.dgScores.AllowUserToDeleteRows = False
        Me.dgScores.AllowUserToResizeColumns = False
        Me.dgScores.AllowUserToResizeRows = False
        Me.dgScores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgScores.BackgroundColor = System.Drawing.Color.White
        Me.dgScores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgScores.Location = New System.Drawing.Point(9, 70)
        Me.dgScores.Name = "dgScores"
        Me.dgScores.ReadOnly = True
        Me.dgScores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgScores.ShowCellToolTips = False
        Me.dgScores.ShowEditingIcon = False
        Me.dgScores.Size = New System.Drawing.Size(297, 242)
        Me.dgScores.TabIndex = 51
        Me.dgScores.TabStop = False
        Me.dgScores.Visible = False
        '
        'pbBack
        '
        Me.pbBack.BackColor = System.Drawing.Color.Transparent
        Me.pbBack.BackgroundImage = Global.AngryBirds3.My.Resources.Resources.close
        Me.pbBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbBack.Location = New System.Drawing.Point(-4, -4)
        Me.pbBack.Name = "pbBack"
        Me.pbBack.Size = New System.Drawing.Size(67, 68)
        Me.pbBack.TabIndex = 54
        Me.pbBack.TabStop = False
        '
        'bgMaze
        '
        Me.bgMaze.BackColor = System.Drawing.Color.Transparent
        Me.bgMaze.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bgMaze.Location = New System.Drawing.Point(7, 318)
        Me.bgMaze.Name = "bgMaze"
        Me.bgMaze.Size = New System.Drawing.Size(49, 123)
        Me.bgMaze.TabIndex = 46
        Me.bgMaze.TabStop = False
        Me.bgMaze.Visible = False
        '
        'ttGame
        '
        Me.ttGame.AutoPopDelay = 3000
        Me.ttGame.InitialDelay = 500
        Me.ttGame.ReshowDelay = 100
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(1362, 741)
        Me.Controls.Add(Me.gbCustomMaze)
        Me.Controls.Add(Me.pbBack)
        Me.Controls.Add(Me.gbMapSel)
        Me.Controls.Add(Me.gbLobby)
        Me.Controls.Add(Me.gbCharSel)
        Me.Controls.Add(Me.gbLogin)
        Me.Controls.Add(Me.dgScores)
        Me.Controls.Add(Me.gbAdmin)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.bgMaze)
        Me.Controls.Add(Me.lblScore)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.Text = "Angry Birds 3 Maze Runner"
        Me.gbLogin.ResumeLayout(False)
        Me.gbLogin.PerformLayout()
        CType(Me.pbLogin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCustomMaze.ResumeLayout(False)
        Me.gbCustomMaze.PerformLayout()
        CType(Me.bgMaze2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbUpdateAddMap, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbAdmin.ResumeLayout(False)
        CType(Me.pbRefreshAdminLists, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbApplyAdminChanges, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgGamePlayersAdmin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgPlayersAdmin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgGameList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbMapSel.ResumeLayout(False)
        CType(Me.pbMapNext, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgMaps, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbLobby.ResumeLayout(False)
        CType(Me.pbRefreshLobby, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbMazeEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAdmin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbJoin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbHosts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgHighscores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgOnlines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgGames, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbLogo2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCharSel.ResumeLayout(False)
        CType(Me.pbStart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbBomb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbYellow, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbBlue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbPink, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbPig, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbRed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgScores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbBack, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bgMaze, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tmrDraw As System.Windows.Forms.Timer
    Friend WithEvents tmrFinish As Timer
    Friend WithEvents lblScore As Label
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenMazeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents QuitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitMazeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tmrMove As Timer
    Friend WithEvents bgMaze As PictureBox
    Friend WithEvents gbLogin As GroupBox
    Friend WithEvents tbPW As TextBox
    Friend WithEvents tbID As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents gbLobby As GroupBox
    Friend WithEvents dgGames As DataGridView
    Friend WithEvents lblGames As Label
    Friend WithEvents pbLogo2 As PictureBox
    Friend WithEvents lblOnlines As Label
    Friend WithEvents lblHighScores As Label
    Friend WithEvents dgOnlines As DataGridView
    Friend WithEvents dgHighscores As DataGridView
    Friend WithEvents gbAdmin As GroupBox
    Friend WithEvents lblUsers As Label
    Friend WithEvents dgPlayersAdmin As DataGridView
    Friend WithEvents dgGameList As DataGridView
    Friend WithEvents lblGameList As Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents dgGamePlayersAdmin As DataGridView
    Friend WithEvents lblPlayers As Label
    Friend WithEvents gbCharSel As GroupBox
    Friend WithEvents pbStart As PictureBox
    Friend WithEvents lbCharSel As Label
    Friend WithEvents pbBomb As PictureBox
    Friend WithEvents pbYellow As PictureBox
    Friend WithEvents pbBlue As PictureBox
    Friend WithEvents pbPink As PictureBox
    Friend WithEvents pbPig As PictureBox
    Friend WithEvents pbRed As PictureBox
    Friend WithEvents dgScores As DataGridView
    Friend WithEvents gbMapSel As GroupBox
    Friend WithEvents dgMaps As DataGridView
    Friend WithEvents lblMaps As Label
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents pbHosts As PictureBox
    Friend WithEvents pbJoin As PictureBox
    Friend WithEvents pbBack As PictureBox
    Friend WithEvents pbAdmin As PictureBox
    Friend WithEvents pbMazeEdit As PictureBox
    Friend WithEvents pbLogin As PictureBox
    Friend WithEvents pbMapNext As PictureBox
    Friend WithEvents pbApplyAdminChanges As PictureBox
    Friend WithEvents pbRefreshAdminLists As PictureBox
    Friend WithEvents gbCustomMaze As GroupBox
    Friend WithEvents pbUpdateAddMap As PictureBox
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents bgMaze2 As PictureBox
    Friend WithEvents tbMapName As TextBox
    Friend WithEvents lblMapName As Label
    Friend WithEvents pbRefreshLobby As PictureBox
    Friend WithEvents ttGame As ToolTip
End Class
