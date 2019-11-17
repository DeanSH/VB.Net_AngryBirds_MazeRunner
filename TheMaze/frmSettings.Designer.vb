<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSettings))
        Me.cmbRes = New System.Windows.Forms.ComboBox()
        Me.cbWindowed = New System.Windows.Forms.CheckBox()
        Me.cbMusic = New System.Windows.Forms.CheckBox()
        Me.cbSoundFx = New System.Windows.Forms.CheckBox()
        Me.cbMnuMusic = New System.Windows.Forms.CheckBox()
        Me.tbGmMusic = New System.Windows.Forms.TrackBar()
        Me.tbMnuMusic = New System.Windows.Forms.TrackBar()
        Me.tbSndFx = New System.Windows.Forms.TrackBar()
        Me.lblRes = New System.Windows.Forms.Label()
        Me.btnPlay = New System.Windows.Forms.Button()
        Me.ttSettings = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.tbGmMusic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbMnuMusic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbSndFx, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbRes
        '
        Me.cmbRes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRes.FormattingEnabled = True
        Me.cmbRes.Items.AddRange(New Object() {"1366 × 768", "1280 × 768", "1024 × 768", "800 × 600"})
        Me.cmbRes.Location = New System.Drawing.Point(15, 32)
        Me.cmbRes.Name = "cmbRes"
        Me.cmbRes.Size = New System.Drawing.Size(249, 21)
        Me.cmbRes.TabIndex = 0
        '
        'cbWindowed
        '
        Me.cbWindowed.AutoSize = True
        Me.cbWindowed.Location = New System.Drawing.Point(187, 11)
        Me.cbWindowed.Name = "cbWindowed"
        Me.cbWindowed.Size = New System.Drawing.Size(77, 17)
        Me.cbWindowed.TabIndex = 1
        Me.cbWindowed.Text = "Windowed"
        Me.cbWindowed.UseVisualStyleBackColor = True
        '
        'cbMusic
        '
        Me.cbMusic.AutoSize = True
        Me.cbMusic.Checked = True
        Me.cbMusic.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbMusic.Location = New System.Drawing.Point(187, 74)
        Me.cbMusic.Name = "cbMusic"
        Me.cbMusic.Size = New System.Drawing.Size(85, 17)
        Me.cbMusic.TabIndex = 2
        Me.cbMusic.Text = "Game Music"
        Me.cbMusic.UseVisualStyleBackColor = True
        '
        'cbSoundFx
        '
        Me.cbSoundFx.AutoSize = True
        Me.cbSoundFx.Checked = True
        Me.cbSoundFx.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbSoundFx.Location = New System.Drawing.Point(187, 156)
        Me.cbSoundFx.Name = "cbSoundFx"
        Me.cbSoundFx.Size = New System.Drawing.Size(71, 17)
        Me.cbSoundFx.TabIndex = 3
        Me.cbSoundFx.Text = "Sound Fx"
        Me.cbSoundFx.UseVisualStyleBackColor = True
        '
        'cbMnuMusic
        '
        Me.cbMnuMusic.AutoSize = True
        Me.cbMnuMusic.Checked = True
        Me.cbMnuMusic.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbMnuMusic.Location = New System.Drawing.Point(187, 114)
        Me.cbMnuMusic.Name = "cbMnuMusic"
        Me.cbMnuMusic.Size = New System.Drawing.Size(84, 17)
        Me.cbMnuMusic.TabIndex = 4
        Me.cbMnuMusic.Text = "Menu Music"
        Me.cbMnuMusic.UseVisualStyleBackColor = True
        '
        'tbGmMusic
        '
        Me.tbGmMusic.Location = New System.Drawing.Point(15, 59)
        Me.tbGmMusic.Maximum = 750
        Me.tbGmMusic.Name = "tbGmMusic"
        Me.tbGmMusic.Size = New System.Drawing.Size(153, 45)
        Me.tbGmMusic.TabIndex = 5
        Me.tbGmMusic.TickFrequency = 50
        Me.tbGmMusic.TickStyle = System.Windows.Forms.TickStyle.Both
        Me.tbGmMusic.Value = 500
        '
        'tbMnuMusic
        '
        Me.tbMnuMusic.Location = New System.Drawing.Point(15, 100)
        Me.tbMnuMusic.Maximum = 750
        Me.tbMnuMusic.Name = "tbMnuMusic"
        Me.tbMnuMusic.Size = New System.Drawing.Size(152, 45)
        Me.tbMnuMusic.TabIndex = 6
        Me.tbMnuMusic.TickFrequency = 50
        Me.tbMnuMusic.TickStyle = System.Windows.Forms.TickStyle.Both
        Me.tbMnuMusic.Value = 500
        '
        'tbSndFx
        '
        Me.tbSndFx.Location = New System.Drawing.Point(15, 142)
        Me.tbSndFx.Maximum = 1000
        Me.tbSndFx.Name = "tbSndFx"
        Me.tbSndFx.Size = New System.Drawing.Size(153, 45)
        Me.tbSndFx.TabIndex = 7
        Me.tbSndFx.TickFrequency = 55
        Me.tbSndFx.TickStyle = System.Windows.Forms.TickStyle.Both
        Me.tbSndFx.Value = 1000
        '
        'lblRes
        '
        Me.lblRes.AutoSize = True
        Me.lblRes.Location = New System.Drawing.Point(15, 12)
        Me.lblRes.Name = "lblRes"
        Me.lblRes.Size = New System.Drawing.Size(60, 13)
        Me.lblRes.TabIndex = 8
        Me.lblRes.Text = "Resolution:"
        '
        'btnPlay
        '
        Me.btnPlay.Location = New System.Drawing.Point(187, 200)
        Me.btnPlay.Name = "btnPlay"
        Me.btnPlay.Size = New System.Drawing.Size(83, 39)
        Me.btnPlay.TabIndex = 9
        Me.btnPlay.Text = "Launch"
        Me.btnPlay.UseVisualStyleBackColor = True
        '
        'ttSettings
        '
        Me.ttSettings.AutoPopDelay = 3000
        Me.ttSettings.InitialDelay = 500
        Me.ttSettings.ReshowDelay = 100
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(276, 246)
        Me.Controls.Add(Me.btnPlay)
        Me.Controls.Add(Me.lblRes)
        Me.Controls.Add(Me.tbSndFx)
        Me.Controls.Add(Me.tbMnuMusic)
        Me.Controls.Add(Me.tbGmMusic)
        Me.Controls.Add(Me.cbMnuMusic)
        Me.Controls.Add(Me.cbSoundFx)
        Me.Controls.Add(Me.cbMusic)
        Me.Controls.Add(Me.cbWindowed)
        Me.Controls.Add(Me.cmbRes)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmSettings"
        Me.Text = "Graphics & Audio"
        CType(Me.tbGmMusic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbMnuMusic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbSndFx, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbRes As ComboBox
    Friend WithEvents cbWindowed As CheckBox
    Friend WithEvents cbMusic As CheckBox
    Friend WithEvents cbSoundFx As CheckBox
    Friend WithEvents cbMnuMusic As CheckBox
    Friend WithEvents tbGmMusic As TrackBar
    Friend WithEvents tbMnuMusic As TrackBar
    Friend WithEvents tbSndFx As TrackBar
    Friend WithEvents lblRes As Label
    Friend WithEvents btnPlay As Button
    Friend WithEvents ttSettings As ToolTip
End Class
