<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class KasirForm
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Barcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NamaObat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Jumlah = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Harga = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Stok = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.lblTotalHarga = New System.Windows.Forms.Label()
        Me.btnSelesai = New System.Windows.Forms.Button()
        Me.btnHapus = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.lblAktif = New System.Windows.Forms.Label()
        Me.timerStopwatch = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Barcode, Me.NamaObat, Me.Jumlah, Me.Harga, Me.Stok})
        Me.DataGridView1.Location = New System.Drawing.Point(14, 18)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(2)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(666, 310)
        Me.DataGridView1.TabIndex = 0
        '
        'Barcode
        '
        Me.Barcode.FillWeight = 200.0!
        Me.Barcode.HeaderText = "Barcode"
        Me.Barcode.Name = "Barcode"
        Me.Barcode.Width = 140
        '
        'NamaObat
        '
        Me.NamaObat.FillWeight = 200.0!
        Me.NamaObat.HeaderText = "Nama Obat"
        Me.NamaObat.Name = "NamaObat"
        Me.NamaObat.Width = 200
        '
        'Jumlah
        '
        Me.Jumlah.FillWeight = 200.0!
        Me.Jumlah.HeaderText = "Jumlah"
        Me.Jumlah.Name = "Jumlah"
        Me.Jumlah.Width = 50
        '
        'Harga
        '
        Me.Harga.FillWeight = 200.0!
        Me.Harga.HeaderText = "Harga"
        Me.Harga.Name = "Harga"
        Me.Harga.Width = 150
        '
        'Stok
        '
        Me.Stok.FillWeight = 200.0!
        Me.Stok.HeaderText = "Stok"
        Me.Stok.Name = "Stok"
        Me.Stok.Width = 80
        '
        'txtBarcode
        '
        Me.txtBarcode.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarcode.Location = New System.Drawing.Point(14, 38)
        Me.txtBarcode.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(528, 42)
        Me.txtBarcode.TabIndex = 1
        '
        'lblTotalHarga
        '
        Me.lblTotalHarga.AutoSize = True
        Me.lblTotalHarga.Font = New System.Drawing.Font("Cambria", 72.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalHarga.ForeColor = System.Drawing.Color.GhostWhite
        Me.lblTotalHarga.Location = New System.Drawing.Point(154, 82)
        Me.lblTotalHarga.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblTotalHarga.Name = "lblTotalHarga"
        Me.lblTotalHarga.Size = New System.Drawing.Size(168, 112)
        Me.lblTotalHarga.TabIndex = 2
        Me.lblTotalHarga.Text = "Rp"
        '
        'btnSelesai
        '
        Me.btnSelesai.Location = New System.Drawing.Point(731, 38)
        Me.btnSelesai.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSelesai.Name = "btnSelesai"
        Me.btnSelesai.Size = New System.Drawing.Size(152, 42)
        Me.btnSelesai.TabIndex = 3
        Me.btnSelesai.Text = "Selesai"
        Me.btnSelesai.UseVisualStyleBackColor = True
        '
        'btnHapus
        '
        Me.btnHapus.Location = New System.Drawing.Point(731, 82)
        Me.btnHapus.Margin = New System.Windows.Forms.Padding(2)
        Me.btnHapus.Name = "btnHapus"
        Me.btnHapus.Size = New System.Drawing.Size(152, 45)
        Me.btnHapus.TabIndex = 4
        Me.btnHapus.Text = "Hapus"
        Me.btnHapus.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.GhostWhite
        Me.GroupBox1.Controls.Add(Me.DataGridView1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 94)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(691, 345)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(731, 129)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(152, 44)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "Kembali"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.GhostWhite
        Me.Label1.Location = New System.Drawing.Point(8, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(161, 33)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Total Harga : "
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Font = New System.Drawing.Font("Segoe UI Symbol", 20.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUser.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.lblUser.Location = New System.Drawing.Point(727, 176)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(76, 37)
        Me.lblUser.TabIndex = 6
        Me.lblUser.Text = "User:"
        '
        'lblAktif
        '
        Me.lblAktif.AutoSize = True
        Me.lblAktif.Font = New System.Drawing.Font("Segoe UI Symbol", 20.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAktif.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.lblAktif.Location = New System.Drawing.Point(727, 213)
        Me.lblAktif.Name = "lblAktif"
        Me.lblAktif.Size = New System.Drawing.Size(186, 37)
        Me.lblAktif.TabIndex = 7
        Me.lblAktif.Text = "Aktif: 00:00:00"
        '
        'timerStopwatch
        '
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 28)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox2.Size = New System.Drawing.Size(691, 67)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Yu Gothic UI", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(300, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 47)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "KASIR"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtBarcode)
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Controls.Add(Me.lblAktif)
        Me.GroupBox3.Controls.Add(Me.btnSelesai)
        Me.GroupBox3.Controls.Add(Me.btnHapus)
        Me.GroupBox3.Controls.Add(Me.lblTotalHarga)
        Me.GroupBox3.Controls.Add(Me.lblUser)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 784)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(922, 268)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        '
        'Timer1
        '
        '
        'KasirForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1202, 1064)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "KasirForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Kasir"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents txtBarcode As TextBox
    Friend WithEvents lblTotalHarga As Label
    Friend WithEvents btnSelesai As Button
    Friend WithEvents btnHapus As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblUser As Label
    Friend WithEvents lblAktif As Label
    Friend WithEvents timerStopwatch As Timer
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Barcode As DataGridViewTextBoxColumn
    Friend WithEvents NamaObat As DataGridViewTextBoxColumn
    Friend WithEvents Jumlah As DataGridViewTextBoxColumn
    Friend WithEvents Harga As DataGridViewTextBoxColumn
    Friend WithEvents Stok As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Timer1 As Timer
End Class