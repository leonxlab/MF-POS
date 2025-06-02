<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UpdateStokForm
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.txtNamaObat = New System.Windows.Forms.TextBox()
        Me.txtSatuan = New System.Windows.Forms.TextBox()
        Me.txtHargaJual = New System.Windows.Forms.TextBox()
        Me.txtHargaModal = New System.Windows.Forms.TextBox()
        Me.txtNoBatch = New System.Windows.Forms.TextBox()
        Me.txtKategoriObat = New System.Windows.Forms.TextBox()
        Me.txtJumlahStok = New System.Windows.Forms.TextBox()
        Me.btnTambahObat = New System.Windows.Forms.Button()
        Me.btnUpdateObat = New System.Windows.Forms.Button()
        Me.btnHapusObat = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtKeuntungan = New System.Windows.Forms.TextBox()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(54, 91)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(1068, 372)
        Me.DataGridView1.TabIndex = 0
        '
        'txtBarcode
        '
        Me.txtBarcode.Location = New System.Drawing.Point(177, 504)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(200, 20)
        Me.txtBarcode.TabIndex = 1
        '
        'txtNamaObat
        '
        Me.txtNamaObat.Location = New System.Drawing.Point(177, 534)
        Me.txtNamaObat.Name = "txtNamaObat"
        Me.txtNamaObat.Size = New System.Drawing.Size(200, 20)
        Me.txtNamaObat.TabIndex = 2
        '
        'txtSatuan
        '
        Me.txtSatuan.Location = New System.Drawing.Point(177, 564)
        Me.txtSatuan.Name = "txtSatuan"
        Me.txtSatuan.Size = New System.Drawing.Size(200, 20)
        Me.txtSatuan.TabIndex = 3
        '
        'txtHargaJual
        '
        Me.txtHargaJual.Location = New System.Drawing.Point(177, 594)
        Me.txtHargaJual.Name = "txtHargaJual"
        Me.txtHargaJual.Size = New System.Drawing.Size(200, 20)
        Me.txtHargaJual.TabIndex = 4
        '
        'txtHargaModal
        '
        Me.txtHargaModal.Location = New System.Drawing.Point(177, 624)
        Me.txtHargaModal.Name = "txtHargaModal"
        Me.txtHargaModal.Size = New System.Drawing.Size(200, 20)
        Me.txtHargaModal.TabIndex = 5
        '
        'txtNoBatch
        '
        Me.txtNoBatch.Location = New System.Drawing.Point(177, 654)
        Me.txtNoBatch.Name = "txtNoBatch"
        Me.txtNoBatch.Size = New System.Drawing.Size(200, 20)
        Me.txtNoBatch.TabIndex = 7
        '
        'txtKategoriObat
        '
        Me.txtKategoriObat.Location = New System.Drawing.Point(177, 684)
        Me.txtKategoriObat.Name = "txtKategoriObat"
        Me.txtKategoriObat.Size = New System.Drawing.Size(200, 20)
        Me.txtKategoriObat.TabIndex = 8
        '
        'txtJumlahStok
        '
        Me.txtJumlahStok.Location = New System.Drawing.Point(177, 714)
        Me.txtJumlahStok.Name = "txtJumlahStok"
        Me.txtJumlahStok.Size = New System.Drawing.Size(200, 20)
        Me.txtJumlahStok.TabIndex = 9
        '
        'btnTambahObat
        '
        Me.btnTambahObat.Font = New System.Drawing.Font("Microsoft YaHei UI", 17.25!, System.Drawing.FontStyle.Bold)
        Me.btnTambahObat.Location = New System.Drawing.Point(397, 504)
        Me.btnTambahObat.Name = "btnTambahObat"
        Me.btnTambahObat.Size = New System.Drawing.Size(192, 50)
        Me.btnTambahObat.TabIndex = 10
        Me.btnTambahObat.Text = "Tambah Obat"
        Me.btnTambahObat.UseVisualStyleBackColor = True
        '
        'btnUpdateObat
        '
        Me.btnUpdateObat.Font = New System.Drawing.Font("Microsoft YaHei UI", 17.25!, System.Drawing.FontStyle.Bold)
        Me.btnUpdateObat.Location = New System.Drawing.Point(397, 564)
        Me.btnUpdateObat.Name = "btnUpdateObat"
        Me.btnUpdateObat.Size = New System.Drawing.Size(192, 50)
        Me.btnUpdateObat.TabIndex = 11
        Me.btnUpdateObat.Text = "Update Obat"
        Me.btnUpdateObat.UseVisualStyleBackColor = True
        '
        'btnHapusObat
        '
        Me.btnHapusObat.Font = New System.Drawing.Font("Microsoft YaHei UI", 17.25!, System.Drawing.FontStyle.Bold)
        Me.btnHapusObat.Location = New System.Drawing.Point(397, 624)
        Me.btnHapusObat.Name = "btnHapusObat"
        Me.btnHapusObat.Size = New System.Drawing.Size(192, 50)
        Me.btnHapusObat.TabIndex = 12
        Me.btnHapusObat.Text = "Hapus Obat"
        Me.btnHapusObat.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(57, 504)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Barcode:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(57, 534)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Nama Obat:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(57, 564)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Satuan:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(57, 594)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Harga Jual:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(57, 624)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 13)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Harga Modal:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(57, 654)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 13)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "No Batch:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(57, 684)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 13)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Kategori Obat:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(57, 714)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 13)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Jumlah Stok:"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.GhostWhite
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.TextBox2)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtKeuntungan)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnHapusObat)
        Me.GroupBox1.Controls.Add(Me.btnUpdateObat)
        Me.GroupBox1.Controls.Add(Me.btnTambahObat)
        Me.GroupBox1.Controls.Add(Me.txtJumlahStok)
        Me.GroupBox1.Controls.Add(Me.txtKategoriObat)
        Me.GroupBox1.Controls.Add(Me.txtNoBatch)
        Me.GroupBox1.Controls.Add(Me.txtHargaModal)
        Me.GroupBox1.Controls.Add(Me.txtHargaJual)
        Me.GroupBox1.Controls.Add(Me.txtSatuan)
        Me.GroupBox1.Controls.Add(Me.txtNamaObat)
        Me.GroupBox1.Controls.Add(Me.txtBarcode)
        Me.GroupBox1.Controls.Add(Me.DataGridView1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 70)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1179, 798)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft YaHei UI", 17.25!, System.Drawing.FontStyle.Bold)
        Me.Button1.Location = New System.Drawing.Point(662, 573)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(460, 50)
        Me.Button1.TabIndex = 31
        Me.Button1.Text = "Tambah Stok"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(739, 538)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(383, 20)
        Me.TextBox2.TabIndex = 30
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(659, 534)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(74, 13)
        Me.Label12.TabIndex = 29
        Me.Label12.Text = "Tambah Stok:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(683, 504)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(50, 13)
        Me.Label11.TabIndex = 28
        Me.Label11.Text = "Barcode:"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(739, 504)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(383, 20)
        Me.TextBox1.TabIndex = 27
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Yu Gothic UI", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(395, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(343, 47)
        Me.Label10.TabIndex = 26
        Me.Label10.Text = "UPDATE STOK OBAT"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(57, 749)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 13)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Keuntungan:"
        '
        'txtKeuntungan
        '
        Me.txtKeuntungan.Location = New System.Drawing.Point(177, 749)
        Me.txtKeuntungan.Name = "txtKeuntungan"
        Me.txtKeuntungan.ReadOnly = True
        Me.txtKeuntungan.Size = New System.Drawing.Size(200, 20)
        Me.txtKeuntungan.TabIndex = 23
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft YaHei", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(-993, 69)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(999, 43)
        Me.txtSearch.TabIndex = 25
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft YaHei UI", 17.25!, System.Drawing.FontStyle.Bold)
        Me.Button2.Location = New System.Drawing.Point(397, 684)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(192, 50)
        Me.Button2.TabIndex = 32
        Me.Button2.Text = "Pesan Obat"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'UpdateStokForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1204, 880)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtSearch)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "UpdateStokForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents txtBarcode As TextBox
    Friend WithEvents txtNamaObat As TextBox
    Friend WithEvents txtSatuan As TextBox
    Friend WithEvents txtHargaJual As TextBox
    Friend WithEvents txtHargaModal As TextBox
    Friend WithEvents txtNoBatch As TextBox
    Friend WithEvents txtKategoriObat As TextBox
    Friend WithEvents txtJumlahStok As TextBox
    Friend WithEvents btnTambahObat As Button
    Friend WithEvents btnUpdateObat As Button
    Friend WithEvents btnHapusObat As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtKeuntungan As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Button2 As Button
End Class