Module mdSounds
    'Hold variables for sounds, and plays them, no database stuff here
    Public GameMusicOn As Boolean = False
    Public GameMusicVol As Integer = 500
    Public GameSoundsOn As Boolean = False
    Public GameSoundsVol As Integer = 1000
    Public GameMenuMusicOn As Boolean = False
    Public GameMenuMusicVol As Integer = 500

    Public Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" (ByVal lpstrCommand As String, ByVal lpstrReturnString As String, ByVal uReturnLength As Integer, ByVal hwndCallback As Integer) As Integer

    Public Sub SoundFx(SFX As String)
        If GameSoundsOn = False Then Exit Sub
        Select Case SFX
            Case "Warp"
                KillSound("selScreen")
                KillSound("gameLoad")
                PlaySound("BlackHoleOpen.mp3", "gameLoad", False, GameSoundsVol)
            Case "Egg"
                KillSound("gameEgg")
                PlaySound("bird next military a1.mp3", "gameEgg", False, GameSoundsVol)
            Case "Pig1"
                KillSound("gameEgg2")
                PlaySound("pig_commander_laugh_3.mp3", "gameEgg2", False, GameSoundsVol)
            Case "Tnt"
                KillSound("gameTnt")
                PlaySound("AT-ST_explosion-01.mp3", "gameTnt", False, GameSoundsVol)
            Case "GameOver"
                KillSound("gameOver")
                PlaySound("birds_luke_cutscene_bespin2_02.mp3", "gameOver", False, GameSoundsVol)
            Case "ExitGame"
                KillSound("exitGame")
                PlaySound("highscore.mp3", "exitGame", False, GameSoundsVol / 2)
            Case "selC1"
                KillSound("selC1")
                PlaySound("sound-effects-redbird-yell02.mp3", "selC1", False, GameSoundsVol)
            Case "selC2"
                KillSound("selC2")
                PlaySound("sound-effects-bird-misc-a11.mp3", "selC2", False, GameSoundsVol)
            Case "selC3"
                KillSound("selC3")
                PlaySound("sound-effects-bird-misc-a12.mp3", "selC3", False, GameSoundsVol)
            Case "selC4"
                KillSound("selC4")
                PlaySound("sound-effects-bird-misc-a9.mp3", "selC4", False, GameSoundsVol)
            Case "selC5"
                KillSound("selC5")
                PlaySound("sound-effects-bird-misc-a5.mp3", "selC5", False, GameSoundsVol)
            Case "selC6"
                KillSound("selC6")
                PlaySound("pig_bunker_idle_04.mp3", "selC6", False, GameSoundsVol)
        End Select
    End Sub

    Public Sub Music(Play As String)
        Select Case Play
            Case "CharSel"
                KillSound("selScreen")
                KillSound("gameOver2")
                KillSound("gameMusic")
                If GameMenuMusicOn = False Then Exit Sub
                PlaySound("Angry Birds Go - Selection Screen.mp3", "selScreen", True, GameMenuMusicVol)
            Case "InGame"
                KillSound("selScreen")
                KillSound("gameOver2")
                KillSound("gameMusic")
                If GameMusicOn = False Then Exit Sub
                PlaySound("Angry Birds Go - Main Theme.mp3", "gameMusic", False, GameMusicVol)
            Case "GameEnd"
                KillSound("gameOver2")
                If GameMusicOn = False Then Exit Sub
                PlaySound("Angry Birds.mp3", "gameOver2", True, CInt(GameMusicVol / 2))
            Case "Intro"

        End Select
    End Sub

    Public Sub TerminateSounds()
        KillSound("selScreen")
        KillSound("gameOver2")
        KillSound("gameMusic")
        KillSound("gameLoad")
        KillSound("gameEgg")
        KillSound("gameEgg2")
        KillSound("gameTnt")
        KillSound("gameOver")
        KillSound("exitGame")
        KillSound("selC1")
        KillSound("selC2")
        KillSound("selC3")
        KillSound("selC4")
        KillSound("selC5")
        KillSound("selC6")
    End Sub

    Private Sub PlaySound(ByVal TheFile As String, ByVal id As String, ByVal repeat As Boolean, Optional volume As Integer = 1000)

        Dim filePath As String = Chr(34) & Application.StartupPath & "/Sounds/" & TheFile & Chr(34)

        If repeat = True Then

            mciSendString("Open " & filePath & " alias " & id, CStr(0), 0, 0) 'Open the file
            mciSendString("play " & id & " repeat ", CStr(0), 0, 0) 'then play with repeating value

        Else

            mciSendString("Open " & filePath & " alias " & id, CStr(0), 0, 0)
            mciSendString("play " & id, CStr(0), 0, 0)

        End If

        'Optionally Set Volume
        mciSendString("setaudio " & id & " volume to " & volume, CStr(0), 0, 0)

    End Sub

    Private Sub KillSound(ByVal song As String)

        mciSendString("close " & song, CStr(0), 0, 0)

    End Sub

End Module
