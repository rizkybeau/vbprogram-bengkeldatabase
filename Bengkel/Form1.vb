Imports MySql.Data.MySqlClient

Public Class Form1
    Dim mysqlconn As MySqlConnection
    Dim COMMAND As MySqlCommand
    Sub isigridutama()
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;userid=root;password=;database=databasebengkel"
        Dim sda As New MySqlDataAdapter
        Dim dbdataset As New DataTable
        Dim bsource As New BindingSource
        Try
            mysqlconn.Open()
            Dim query As String
            query = "SELECT * FROM bonpembelian"

            COMMAND = New MySqlCommand(query, mysqlconn)
            sda.SelectCommand = COMMAND
            sda.Fill(dbdataset)
            bsource.DataSource = dbdataset
            'DataGridView1.DataSource = bsource
            MetroGrid1.DataSource = bsource
            sda.Update(dbdataset)
            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MetroGrid1.Refresh()
        isigridutama()

    End Sub

    Private Sub KendaraanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form3.Show()
    End Sub

    Private Sub MekanikToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form4.Show()
    End Sub

    Private Sub TransaksiPartsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form5.Show()
    End Sub

    Private Sub TransaksiPartsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form6.Show()
    End Sub

    Private Sub BonPembelianToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form7.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isigridutama()
    End Sub

    Sub isitextbox(ByVal x As Integer)
        Try
            TextBox1.Text = MetroGrid1.Rows(x).Cells(0).Value 'ngambil  id untuk keperluan cetak
        Catch ex As Exception

        End Try

    End Sub


    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form2.Show()
    End Sub

    Private Sub MetroButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton1.Click

        formCetak.CrystalReportViewer1.SelectionFormula = "{Command.NoFaktur} ='" & TextBox1.Text.ToString & "'"
        formCetak.Refresh()
        formCetak.Show()
    End Sub


    Private Sub InsertToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form3.Show()

    End Sub

    Private Sub MetroGrid1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles MetroGrid1.CellClick
        isitextbox(e.RowIndex)
    End Sub

    Private Sub PartsToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form6.Show()
    End Sub

    Private Sub MetroButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton2.Click
        isigridutama()

    End Sub

    Private Sub KeluarToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        End
    End Sub

    Private Sub LoginToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form2.Show()
    End Sub

    Private Sub PartsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form6.Show()
    End Sub

    Private Sub DataMekanikToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataMekanikToolStripMenuItem.Click
        Form4.Show()
    End Sub

    Private Sub DataKendaraanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataKendaraanToolStripMenuItem.Click
        Form3.Show()
    End Sub

    Private Sub DataAntrianToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataAntrianToolStripMenuItem.Click
        Form7.Show()
    End Sub

    Private Sub KeluarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        End
    End Sub

    Private Sub TransaksiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransaksiToolStripMenuItem.Click
        'Form5.Show()
    End Sub

    Private Sub DataPartsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataPartsToolStripMenuItem.Click
        Form6.Show()
    End Sub

    

    

    Private Sub BantuanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BantuanToolStripMenuItem.Click
        MsgBox("1. INPUT DATA di master data,2.konfirmasi di transaksi,3.cetak", MsgBoxStyle.Information)
    End Sub

    Private Sub InptKendaraanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InptKendaraanToolStripMenuItem.Click
        Form7.Show()
    End Sub

    Private Sub InptKendaraanToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InptKendaraanToolStripMenuItem1.Click
        Form3.Show()
    End Sub

    Private Sub TransaksiFaktrToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransaksiFaktrToolStripMenuItem.Click
        Form5.Show()
    End Sub

    Private Sub BantuanToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BantuanToolStripMenuItem1.Click
        MsgBox("untuk inputan cara mengisinya sebagai berikut 1. input kendaraan 2. input antrian 3. transaksi faktur. selamat bekerja", MsgBoxStyle.Information)
    End Sub

    
End Class
