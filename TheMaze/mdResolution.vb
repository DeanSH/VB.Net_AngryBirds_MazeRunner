Module mdResolution
    'No data base stuff here, this is purely for graphical purposes to set screen resolutions if fullscreen
    Public BLOCK_WIDTH As Byte = 28
    Public BLOCK_HEIGHT As Byte = 28
    Public GAME_RESOLUTIONX As Integer = 1366
    Public GAME_RESOLUTIONY As Integer = 768
    Public IsWindowed As Boolean = False
    Public ScreenRes As System.Drawing.Size = System.Windows.Forms.SystemInformation.PrimaryMonitorSize

    Private Declare Function EnumDisplaySettings Lib "user32" Alias "EnumDisplaySettingsA" (ByVal lpszDeviceName As Integer, ByVal iModeNum As Integer, ByRef lpDevMode As DEVMODE) As Boolean
    Private Declare Function ChangeDisplaySettings Lib "user32" Alias "ChangeDisplaySettingsA" (ByRef lpDevMode As DEVMODE, ByVal dwflags As Integer) As Integer

    Private Const ENUM_CURRENT_SETTINGS As Integer = -1&
    Private Const CCDEVICENAME As Short = 32
    Private Const CCFORMNAME As Short = 32
    Private Const DM_BITSPERPEL = &H60000
    Private Const DM_PELSWIDTH As Integer = &H80000
    Private Const DM_PELSHEIGHT As Integer = &H100000
    Private Const DM_DISPLAYFREQUENCY As Integer = &H400000

    Private Structure DEVMODE

        <VBFixedString(CCDEVICENAME), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=CCDEVICENAME)> Private dmDeviceName As String
        Dim dmSpecVersion As Short
        Dim dmDriverVersion As Short
        Dim dmSize As Short
        Dim dmDriverExtra As Short
        Dim dmFields As Integer
        Dim dmOrientation As Short
        Dim dmPaperSize As Short
        Dim dmPaperLength As Short
        Dim dmPaperWidth As Short
        Dim dmScale As Short
        Dim dmCopies As Short
        Dim dmDefaultSource As Short
        Dim dmPrintQuality As Short
        Dim dmColor As Short
        Dim dmDuplex As Short
        Dim dmYResolution As Short
        Dim dmTTOption As Short
        Dim dmCollate As Short
        <VBFixedString(CCFORMNAME), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=CCFORMNAME)> Private dmFormName As String
        Dim dmUnusedPadding As Short
        Dim dmBitsPerPel As Integer
        Dim dmPelsWidth As Integer
        Dim dmPelsHeight As Integer
        Dim dmDisplayFlags As Integer
        Dim dmDisplayFrequency As Integer

    End Structure

    Public Sub Initialize_Resolution()
        frmMain.Height = GAME_RESOLUTIONY
        frmMain.Width = GAME_RESOLUTIONX
        Dim BlockRes As Integer = CInt(GAME_RESOLUTIONX / 49)
        BLOCK_WIDTH = BlockRes
        BLOCK_HEIGHT = BlockRes
        If IsWindowed = False Then
            'Me.Left = 0
            'Me.Top = 0
            Call ChangeScrnRes(GAME_RESOLUTIONX, GAME_RESOLUTIONY)
            frmMain.FormBorderStyle = FormBorderStyle.None
            frmMain.WindowState = FormWindowState.Maximized
        End If
    End Sub

    Public Sub ChangeScrnRes(ByVal Width As Integer, ByVal Height As Integer)

        Dim DevM As New DEVMODE
        Dim i As Integer

        i = EnumDisplaySettings(0, 0, DevM)

        With DevM
            .dmFields = DM_PELSWIDTH Or DM_PELSHEIGHT
            .dmPelsWidth = Width
            .dmPelsHeight = Height
            .dmBitsPerPel = 24
        End With

        i = ChangeDisplaySettings(DevM, 0)
        i = EnumDisplaySettings(0, 0, DevM)

    End Sub
End Module
