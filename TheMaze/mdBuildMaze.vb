Module mdBuildMaze
    'No database code in here, just code to generate the maze of a player for my maze creator feature
    Public Sub BuildMazeCreator(MazeLayout As String)
        frmMain.bgMaze2.Visible = True
        frmMain.bgMaze2.BringToFront()
        frmMain.bgMaze2.Height = ((21 + 1) * 16)
        frmMain.bgMaze2.Width = ((39 + 1) * 16)
        frmMain.bgMaze2.Image = New Bitmap(frmMain.bgMaze2.Width, frmMain.bgMaze2.Height)
        frmMain.bgMaze2.Refresh()
        frmMain.UpdateStatus("Loading Map Maze Into Maze Creator..")
        PauseMe(200)
        Dim _X As Integer = 0
        Dim _Y As Integer = 0
        MazeCells = New List(Of clsMazeWall)
        Dim maze_line As String
        Dim maze_pos As Integer = 1
        For I As Integer = 0 To 20


            maze_line = Mid(MazeLayout, maze_pos, 39)
            maze_pos = maze_pos + 39

            For Each mc As Char In maze_line

                Select Case mc
                    Case "1"c
                        Dim newCell As New clsMazeWall
                        With newCell
                            .Left = _X * 16
                            .Top = _Y * 16
                            .Width = 16
                            .Height = 16
                            .Type = 1
                        End With
                        MazeCells.Add(newCell)
                    Case " "
                        Dim newCell As New clsMazeWall
                        With newCell
                            .Left = _X * 16
                            .Top = _Y * 16
                            .Width = 16
                            .Height = 16
                            .Type = 0
                        End With
                        MazeCells.Add(newCell)
                End Select

                _X += 1
            Next
            _Y += 1
            _X = 0

        Next I

        frmMain.UpdateStatus("Drawing Map Maze Into Maze Creator..")
        PauseMe(200)
        Dim rndHedge As Integer = 0
        For Each mCell As clsMazeWall In MazeCells
            If mCell.Type = 1 Then
                rndHedge = GenRandomInt(1, 22)
                If rndHedge > 15 Then
                    Graphics.FromImage(frmMain.bgMaze2.Image).DrawImage(stones1, New Rectangle(mCell.Left, mCell.Top, mCell.Width, mCell.Height), New Rectangle(0, 0, woods1.Width, woods1.Height), GraphicsUnit.Pixel)
                ElseIf rndHedge > 14 Then
                    Graphics.FromImage(frmMain.bgMaze2.Image).DrawImage(woods2, New Rectangle(mCell.Left, mCell.Top, mCell.Width, mCell.Height), New Rectangle(0, 0, woods2.Width, woods3.Height), GraphicsUnit.Pixel)
                ElseIf rndHedge > 13 Then
                    Graphics.FromImage(frmMain.bgMaze2.Image).DrawImage(woods3, New Rectangle(mCell.Left, mCell.Top, mCell.Width, mCell.Height), New Rectangle(0, 0, woods3.Width, woods3.Height), GraphicsUnit.Pixel)
                ElseIf rndHedge > 12 Then
                    Graphics.FromImage(frmMain.bgMaze2.Image).DrawImage(woods4, New Rectangle(mCell.Left, mCell.Top, mCell.Width, mCell.Height), New Rectangle(0, 0, woods4.Width, woods4.Height), GraphicsUnit.Pixel)
                ElseIf rndHedge > 11 Then
                    Graphics.FromImage(frmMain.bgMaze2.Image).DrawImage(woods5, New Rectangle(mCell.Left, mCell.Top, mCell.Width, mCell.Height), New Rectangle(0, 0, woods5.Width, woods5.Height), GraphicsUnit.Pixel)
                ElseIf rndHedge > 10 Then
                    Graphics.FromImage(frmMain.bgMaze2.Image).DrawImage(woods6, New Rectangle(mCell.Left, mCell.Top, mCell.Width, mCell.Height), New Rectangle(0, 0, woods6.Width, woods6.Height), GraphicsUnit.Pixel)
                ElseIf rndHedge > 9 Then
                    Graphics.FromImage(frmMain.bgMaze2.Image).DrawImage(woods1, New Rectangle(mCell.Left, mCell.Top, mCell.Width, mCell.Height), New Rectangle(0, 0, stones2.Width, stones2.Height), GraphicsUnit.Pixel)
                Else
                    Graphics.FromImage(frmMain.bgMaze2.Image).DrawImage(stones2, New Rectangle(mCell.Left, mCell.Top, mCell.Width, mCell.Height), New Rectangle(0, 0, stones1.Width, stones1.Height), GraphicsUnit.Pixel)
                End If
            End If
        Next

        frmMain.bgMaze2.Refresh()
        frmMain.UpdateStatus("Loaded Map Maze Into Maze Creator, Ready To Build!")
    End Sub
End Module
