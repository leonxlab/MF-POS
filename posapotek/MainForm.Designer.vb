<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.btnKasir = New System.Windows.Forms.Button()
        Me.btnUpdateStok = New System.Windows.Forms.Button()
        Me.btnLaporan = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblAktif = New System.Windows.Forms.Label()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.timerStopwatch = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnKasir
        '
        Me.btnKasir.BackgroundImage = CType(resources.GetObject("btnKasir.BackgroundImage"), System.Drawing.Image)
        Me.btnKasir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnKasir.Location = New System.Drawing.Point(36, 37)
        Me.btnKasir.Margin = New System.Windows.Forms.Padding(2)
        Me.btnKasir.Name = "btnKasir"
        Me.btnKasir.Size = New System.Drawing.Size(182, 133)
        Me.btnKasir.TabIndex = 0
        Me.btnKasir.UseVisualStyleBackColor = True
        '
        'btnUpdateStok
        '
        Me.btnUpdateStok.BackgroundImage = CType(resources.GetObject("btnUpdateStok.BackgroundImage"), System.Drawing.Image)
        Me.btnUpdateStok.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnUpdateStok.Location = New System.Drawing.Point(273, 37)
        Me.btnUpdateStok.Margin = New System.Windows.Forms.Padding(2)
        Me.btnUpdateStok.Name = "btnUpdateStok"
        Me.btnUpdateStok.Size = New System.Drawing.Size(182, 133)
        Me.btnUpdateStok.TabIndex = 1
        Me.btnUpdateStok.UseVisualStyleBackColor = True
        '
        'btnLaporan
        '
        Me.btnLaporan.BackgroundImage = CType(resources.GetObject("btnLaporan.BackgroundImage"), System.Drawing.Image)
        Me.btnLaporan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnLaporan.Location = New System.Drawing.Point(506, 37)
        Me.btnLaporan.Margin = New System.Windows.Forms.Padding(2)
        Me.btnLaporan.Name = "btnLaporan"
        Me.btnLaporan.Size = New System.Drawing.Size(182, 133)
        Me.btnLaporan.TabIndex = 2
        Me.btnLaporan.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.GhostWhite
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnLaporan)
        Me.GroupBox1.Controls.Add(Me.btnKasir)
        Me.GroupBox1.Controls.Add(Me.btnUpdateStok)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 75)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(1)
        Me.GroupBox1.Size = New System.Drawing.Size(737, 282)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Yu Gothic UI", 20.25!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(514, 172)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(168, 37)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "PENJUALAN"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Yu Gothic UI", 20.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(324, 172)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 37)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "STOK"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Yu Gothic UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(75, 172)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 37)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "KASIR"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.GroupBox1)
        Me.GroupBox2.Location = New System.Drawing.Point(49, 66)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1001, 359)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.GhostWhite
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Controls.Add(Me.lblAktif)
        Me.GroupBox3.Controls.Add(Me.lblUser)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Location = New System.Drawing.Point(741, 75)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(260, 282)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Yu Gothic UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(38, 157)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(191, 52)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Akhiri Sesi"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lblAktif
        '
        Me.lblAktif.AutoSize = True
        Me.lblAktif.Font = New System.Drawing.Font("Yu Gothic UI", 20.25!, System.Drawing.FontStyle.Bold)
        Me.lblAktif.Location = New System.Drawing.Point(117, 101)
        Me.lblAktif.Name = "lblAktif"
        Me.lblAktif.Size = New System.Drawing.Size(83, 37)
        Me.lblAktif.TabIndex = 8
        Me.lblAktif.Text = "NULL"
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Font = New System.Drawing.Font("Yu Gothic UI", 20.25!, System.Drawing.FontStyle.Bold)
        Me.lblUser.Location = New System.Drawing.Point(117, 64)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(83, 37)
        Me.lblUser.TabIndex = 7
        Me.lblUser.Text = "NULL"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Yu Gothic UI", 20.25!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(31, 101)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 37)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Aktif  :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Yu Gothic UI", 20.25!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(31, 62)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 37)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "User  :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Yu Gothic UI", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(381, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(277, 47)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "MENU APLIKASI"
        '
        'timerStopwatch
        '
        Me.timerStopwatch.Interval = 1000
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(1097, 479)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MainForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = " "
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnKasir As Button
    Friend WithEvents btnUpdateStok As Button
    Friend WithEvents btnLaporan As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents lblUser As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblAktif As Label
    Friend WithEvents timerStopwatch As Timer
End Class