Module mdPics
    'This stores all the games images into variables and applies transparency to game objects and characters
    Public BackGameImage As System.Drawing.Bitmap
    Public BackCharImage As System.Drawing.Bitmap

    Public woods1 As System.Drawing.Bitmap
    Public woods2 As System.Drawing.Bitmap
    Public woods3 As System.Drawing.Bitmap
    Public woods4 As System.Drawing.Bitmap
    Public woods5 As System.Drawing.Bitmap
    Public woods6 As System.Drawing.Bitmap
    Public stones1 As System.Drawing.Bitmap
    Public stones2 As System.Drawing.Bitmap
    Public tnt1 As System.Drawing.Bitmap
    Public pig1 As System.Drawing.Bitmap
    Public red1 As System.Drawing.Bitmap
    Public yellow1 As System.Drawing.Bitmap
    Public blue1 As System.Drawing.Bitmap
    Public bomb1 As System.Drawing.Bitmap
    Public egg1 As System.Drawing.Bitmap
    Public pink1 As System.Drawing.Bitmap

    Public Sub LoadImages()
        woods1 = My.Resources.wood1
        woods2 = My.Resources.wood2
        woods3 = My.Resources.wood3
        woods4 = My.Resources.wood4
        woods5 = My.Resources.wood5
        woods6 = My.Resources.wood6
        tnt1 = My.Resources.tnt
        stones1 = My.Resources.stone1
        stones2 = My.Resources.stone2
        pig1 = My.Resources.pig
        red1 = My.Resources.red
        yellow1 = My.Resources.yellow
        blue1 = My.Resources.blue
        bomb1 = My.Resources.bomb
        egg1 = My.Resources.eggs
        pink1 = My.Resources.pink

        woods1.MakeTransparent(Color.FromArgb(200, 0, 255, 0))
        woods2.MakeTransparent(Color.FromArgb(200, 0, 255, 0))
        woods3.MakeTransparent(Color.FromArgb(200, 0, 255, 0))
        woods4.MakeTransparent(Color.FromArgb(200, 0, 255, 0))
        woods5.MakeTransparent(Color.FromArgb(200, 0, 255, 0))
        woods6.MakeTransparent(Color.FromArgb(200, 0, 255, 0))
        stones1.MakeTransparent(Color.FromArgb(200, 0, 255, 0))
        stones2.MakeTransparent(Color.FromArgb(200, 0, 255, 0))
        tnt1.MakeTransparent(Color.FromArgb(200, 0, 255, 0))
        pig1.MakeTransparent(Color.FromArgb(200, 0, 255, 0))
        red1.MakeTransparent(Color.FromArgb(200, 0, 255, 0))
        blue1.MakeTransparent(Color.FromArgb(200, 0, 255, 0))
        yellow1.MakeTransparent(Color.FromArgb(200, 0, 255, 0))
        bomb1.MakeTransparent(Color.FromArgb(200, 0, 255, 0))
        pink1.MakeTransparent(Color.FromArgb(200, 0, 255, 0))
        egg1.MakeTransparent(Color.FromArgb(200, 0, 255, 0))

        frmMain.pbBlue.Image = blue1
        frmMain.pbRed.Image = red1
        frmMain.pbYellow.Image = yellow1
        frmMain.pbPink.Image = pink1
        frmMain.pbBomb.Image = bomb1
        frmMain.pbPig.Image = pig1

        'PlayerCharacter = red1
        'Player2Character = pig1

    End Sub

End Module
