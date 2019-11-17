Public Class frmSettings
    Private recommendedRes As String
    'Angry Birds 3 - Maze Runner by Dean Stanley-Hunt for DAT602 Assignment, S1, 2017, NMIT, NZ.
    'no database code in here! See frmMain,clsMySQLCalls,clsSQLDataGridBind,mdProcessDB << All Database actions.
    'Form load code, get previous settings if any and apply them into the variables and on screen
    Private Sub settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Get current resolution and load previous resolution used if any
        recommendedRes = ScreenResolution()
        cmbRes.Items.Add(recommendedRes & " (Recommended)")
        cmbRes.Text = GetSetting("AB3", "Settings", "Resolution", recommendedRes & " (Recommended)")
        If cmbRes.Items.Contains(cmbRes.Text) = False Then
            cmbRes.Items.Add(cmbRes.Text)
        End If
        'set variables from saved settings or defaults
        IsWindowed = GetSetting("AB3", "Settings", "Windowed", True)
        GameMusicOn = GetSetting("AB3", "Settings", "MusicOn", True)
        GameMusicVol = GetSetting("AB3", "Settings", "MusicVol", 500)
        GameSoundsOn = GetSetting("AB3", "Settings", "SoundsOn", True)
        GameSoundsVol = GetSetting("AB3", "Settings", "SoundsVol", 1000)
        GameMenuMusicOn = GetSetting("AB3", "Settings", "MenuMusicOn", True)
        GameMenuMusicVol = GetSetting("AB3", "Settings", "MenuMusicVol", 500)
        'set interface controls to match variables
        cbWindowed.Checked = IsWindowed
        cbMusic.Checked = GameMusicOn
        cbSoundFx.Checked = GameSoundsOn
        cbMnuMusic.Checked = GameMenuMusicOn
        tbGmMusic.Value = GameMusicVol
        tbMnuMusic.Value = GameMenuMusicVol
        tbSndFx.Value = GameSoundsVol
        'Load tooltips for controls on form
        ttSettings.SetToolTip(cmbRes, "Display Resolution")
        ttSettings.SetToolTip(cbWindowed, "Windowed or Fullscreen Mode")
        ttSettings.SetToolTip(cbMusic, "Game Music On/Off")
        ttSettings.SetToolTip(tbGmMusic, "Game Music Volume")
        ttSettings.SetToolTip(cbSoundFx, "Sound Fx On/Off")
        ttSettings.SetToolTip(tbSndFx, "Sound Fx Volume")
        ttSettings.SetToolTip(cbMnuMusic, "Menu Music On/Off")
        ttSettings.SetToolTip(tbMnuMusic, "Menu Music Volume")

    End Sub

    'Get the current screen resolution
    Private Function ScreenResolution() As String
        Dim intX As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim intY As Integer = Screen.PrimaryScreen.Bounds.Height
        Return intX & " × " & intY
    End Function

    'Start the game, Set variabled according to current controls settings, and save settings for next time.
    Private Sub btnPlay_Click(sender As Object, e As EventArgs) Handles btnPlay.Click
        'Setup variables
        If InStr(cmbRes.Text, "Recommend") > 0 Then
            GAME_RESOLUTIONX = Split(recommendedRes, " × ")(0)
            GAME_RESOLUTIONY = Split(recommendedRes, " × ")(1)
        Else
            GAME_RESOLUTIONX = Split(cmbRes.Text, " × ")(0)
            GAME_RESOLUTIONY = Split(cmbRes.Text, " × ")(1)
        End If
        IsWindowed = cbWindowed.Checked
        GameMusicOn = cbMusic.Checked
        GameMusicVol = tbGmMusic.Value
        GameSoundsOn = cbSoundFx.Checked
        GameSoundsVol = tbSndFx.Value
        GameMenuMusicOn = cbMnuMusic.Checked
        GameMenuMusicVol = tbMnuMusic.Value
        'Save settings
        SaveSetting("AB3", "Settings", "Resolution", cmbRes.Text)
        SaveSetting("AB3", "Settings", "Windowed", IsWindowed)
        SaveSetting("AB3", "Settings", "MusicOn", GameMusicOn)
        SaveSetting("AB3", "Settings", "MusicVol", GameMusicVol)
        SaveSetting("AB3", "Settings", "SoundsOn", GameSoundsOn)
        SaveSetting("AB3", "Settings", "SoundsVol", GameSoundsVol)
        SaveSetting("AB3", "Settings", "MenuMusicOn", GameMenuMusicOn)
        SaveSetting("AB3", "Settings", "MenuMusicVol", GameMenuMusicVol)
        'Hide settings, show and load game
        Me.Hide()
        frmMain.Show()
    End Sub

End Class