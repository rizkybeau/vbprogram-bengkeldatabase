Imports MySql.Data.MySqlClient
Public Class Form8
    Dim mysqlconn As MySqlConnection
    Dim COMMAND As MySqlCommand
    Dim jumlah As Integer
    Private Sub Form8_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        isigridutama()
        Label2.Text = jumlah
    End Sub
    Sub isigridutama()
        Dim READER As MySqlDataReader
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;userid=root;password=;database=databasebengkel"
        Dim sda As New MySqlDataAdapter
        Dim dbdataset As New DataTable
        Dim bsource As New BindingSource
        Try
            mysqlconn.Open()
            Dim query As String
            query = "select a.idmekanik,d.namamekanik,b.kodeparts,c.namaparts,b.qty,b.harga,b.diskon,(b.qty*b.harga)-(b.qty*b.diskon) as jumlah,a.potongan,(select sum((qty*harga)-(qty*diskon))-a.potongan from transaksiparts where nofaktur=a.nofaktur) as total from bonpembelian as a " _
            + "join transaksiparts  as b ON a.nofaktur=b.nofaktur " _
            + "join parts as c ON b.kodeparts=c.kodeparts " _
            + "join mekanik as d ON a.idmekanik=d.idmekanik join kendaraan as e ON a.nopol= e.nopol"

            COMMAND = New MySqlCommand(query, mysqlconn)
            sda.SelectCommand = COMMAND
            sda.Fill(dbdataset)
            bsource.DataSource = dbdataset
            'DataGridView1.DataSource = bsource
            DataGridView1.DataSource = bsource
            sda.Update(dbdataset)
            READER = COMMAND.ExecuteReader
            While READER.Read
                Dim sName = READER.GetString("total")

                jumlah = jumlah + sName
            End While

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub
End Class