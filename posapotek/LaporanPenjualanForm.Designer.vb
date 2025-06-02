<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LaporanPenjualanForm
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
        Me.lblTotalPenjualan = New System.Windows.Forms.Label()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnUnduhPDF = New System.Windows.Forms.Button()
        Me.cmbSort = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnCariBarcode = New System.Windows.Forms.Button()
        Me.txtBarcodeCari = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpTanggalAkhir = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpTanggalAwal = New System.Windows.Forms.DateTimePicker()
        Me.rtbStokPeringatan = New System.Windows.Forms.RichTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnFilterStok = New System.Windows.Forms.Button()
        Me.txtFilterStok = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnUnduhStokPeringatan = New System.Windows.Forms.Button()
        Me.timerStopwatch = New System.Windows.Forms.Timer(Me.components)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(30, 150)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(750, 300)
        Me.DataGridView1.TabIndex = 0
        '
        'lblTotalPenjualan
        '
        Me.lblTotalPenjualan.AutoSize = True
        Me.lblTotalPenjualan.Location = New System.Drawing.Point(30, 470)
        Me.lblTotalPenjualan.Name = "lblTotalPenjualan"
        Me.lblTotalPenjualan.Size = New System.Drawing.Size(87, 13)
        Me.lblTotalPenjualan.TabIndex = 1
        Me.lblTotalPenjualan.Text = "Total Penjualan: "
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(535, 461)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(100, 30)
        Me.btnRefresh.TabIndex = 2
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Yu Gothic UI", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(204, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(386, 47)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "LAPORAN PENJUALAN"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.GhostWhite
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnUnduhPDF)
        Me.GroupBox1.Controls.Add(Me.cmbSort)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btnCariBarcode)
        Me.GroupBox1.Controls.Add(Me.txtBarcodeCari)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.dtpTanggalAkhir)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.dtpTanggalAwal)
        Me.GroupBox1.Controls.Add(Me.btnRefresh)
        Me.GroupBox1.Controls.Add(Me.lblTotalPenjualan)
        Me.GroupBox1.Controls.Add(Me.DataGridView1)
        Me.GroupBox1.Controls.Add(Me.rtbStokPeringatan)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.btnFilterStok)
        Me.GroupBox1.Controls.Add(Me.txtFilterStok)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.btnUnduhStokPeringatan)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(800, 859)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(680, 462)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(92, 29)
        Me.Button1.TabIndex = 21
        Me.Button1.Text = "Tutup"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnUnduhPDF
        '
        Me.btnUnduhPDF.Location = New System.Drawing.Point(425, 461)
        Me.btnUnduhPDF.Name = "btnUnduhPDF"
        Me.btnUnduhPDF.Size = New System.Drawing.Size(100, 30)
        Me.btnUnduhPDF.TabIndex = 14
        Me.btnUnduhPDF.Text = "Unduh PDF"
        Me.btnUnduhPDF.UseVisualStyleBackColor = True
        '
        'cmbSort
        '
        Me.cmbSort.FormattingEnabled = True
        Me.cmbSort.Items.AddRange(New Object() {"Alfabet Nama Obat", "Tanggal Waktu"})
        Me.cmbSort.Location = New System.Drawing.Point(30, 106)
        Me.cmbSort.Name = "cmbSort"
        Me.cmbSort.Size = New System.Drawing.Size(200, 21)
        Me.cmbSort.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(30, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Sortir:"
        '
        'btnCariBarcode
        '
        Me.btnCariBarcode.Location = New System.Drawing.Point(586, 60)
        Me.btnCariBarcode.Name = "btnCariBarcode"
        Me.btnCariBarcode.Size = New System.Drawing.Size(100, 67)
        Me.btnCariBarcode.TabIndex = 11
        Me.btnCariBarcode.Text = "Cari"
        Me.btnCariBarcode.UseVisualStyleBackColor = True
        '
        'txtBarcodeCari
        '
        Me.txtBarcodeCari.Location = New System.Drawing.Point(30, 63)
        Me.txtBarcodeCari.Name = "txtBarcodeCari"
        Me.txtBarcodeCari.Size = New System.Drawing.Size(200, 20)
        Me.txtBarcodeCari.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(250, 107)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Tanggal Akhir:"
        '
        'dtpTanggalAkhir
        '
        Me.dtpTanggalAkhir.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTanggalAkhir.Location = New System.Drawing.Point(350, 107)
        Me.dtpTanggalAkhir.Name = "dtpTanggalAkhir"
        Me.dtpTanggalAkhir.Size = New System.Drawing.Size(200, 20)
        Me.dtpTanggalAkhir.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(250, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Tanggal Awal:"
        '
        'dtpTanggalAwal
        '
        Me.dtpTanggalAwal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTanggalAwal.Location = New System.Drawing.Point(350, 60)
        Me.dtpTanggalAwal.Name = "dtpTanggalAwal"
        Me.dtpTanggalAwal.Size = New System.Drawing.Size(200, 20)
        Me.dtpTanggalAwal.TabIndex = 6
        '
        'rtbStokPeringatan
        '
        Me.rtbStokPeringatan.Location = New System.Drawing.Point(30, 587)
        Me.rtbStokPeringatan.Name = "rtbStokPeringatan"
        Me.rtbStokPeringatan.Size = New System.Drawing.Size(750, 150)
        Me.rtbStokPeringatan.TabIndex = 15
        Me.rtbStokPeringatan.Text = ""
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Yu Gothic UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(30, 567)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(169, 21)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Stok Obat Peringatan:"
        '
        'btnFilterStok
        '
        Me.btnFilterStok.Location = New System.Drawing.Point(576, 746)
        Me.btnFilterStok.Name = "btnFilterStok"
        Me.btnFilterStok.Size = New System.Drawing.Size(100, 30)
        Me.btnFilterStok.TabIndex = 17
        Me.btnFilterStok.Text = "Filter"
        Me.btnFilterStok.UseVisualStyleBackColor = True
        '
        'txtFilterStok
        '
        Me.txtFilterStok.Location = New System.Drawing.Point(30, 756)
        Me.txtFilterStok.Name = "txtFilterStok"
        Me.txtFilterStok.Size = New System.Drawing.Size(200, 20)
        Me.txtFilterStok.TabIndex = 18
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(31, 740)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(102, 13)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Filter Stok Dibawah:"
        '
        'btnUnduhStokPeringatan
        '
        Me.btnUnduhStokPeringatan.Location = New System.Drawing.Point(680, 746)
        Me.btnUnduhStokPeringatan.Name = "btnUnduhStokPeringatan"
        Me.btnUnduhStokPeringatan.Size = New System.Drawing.Size(100, 30)
        Me.btnUnduhStokPeringatan.TabIndex = 20
        Me.btnUnduhStokPeringatan.Text = "Unduh PDF"
        Me.btnUnduhStokPeringatan.UseVisualStyleBackColor = True
        '
        'LaporanPenjualanForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(824, 883)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LaporanPenjualanForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents lblTotalPenjualan As Label
    Friend WithEvents btnRefresh As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnUnduhPDF As Button
    Friend WithEvents cmbSort As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnCariBarcode As Button
    Friend WithEvents txtBarcodeCari As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpTanggalAkhir As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents dtpTanggalAwal As DateTimePicker
    Friend WithEvents rtbStokPeringatan As RichTextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btnFilterStok As Button
    Friend WithEvents txtFilterStok As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents btnUnduhStokPeringatan As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents timerStopwatch As Timer
End Class