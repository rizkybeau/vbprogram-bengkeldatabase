Imports MySql.Data.MySqlClient

Public Class Form6
    Dim mysqlconn As New MySqlConnection
    Dim COMMAND As New MySqlCommand
    Sub insertdatabase() 'fungsi untuk insert data vb to databse mysql
        mysqlconn = New MySqlConnection 'mysqllconn di deklarasi terlebih dahulu
        mysqlconn.ConnectionString = "server=localhost;userid=root;password=;database=databasebengkel"
        Dim reader As MySqlDataReader 'reader diperlukan membaca kode query
        Try

            mysqlconn.Open() 'menghubungkan vb.net ke database mysql
            Dim query As String 'query bertipe string
            'kode query mysql
            query = "insert into parts  (kodeparts,namaparts,harga,stok) values ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "')"
            COMMAND = New MySqlCommand(query, mysqlconn) 'eksekutor
            reader = COMMAND.ExecuteReader

            MessageBox.Show("data saved")
            mysqlconn.Close()


        Catch ex As Exception
            MessageBox.Show(ex.ToString)

        Finally
            mysqlconn.Dispose()
        End Try

    End Sub


    Sub isigrid3()
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;userid=root;password=;database=databasebengkel"
        Dim sda As New MySqlDataAdapter
        Dim dbdataset As New DataTable
        Dim bsource As New BindingSource
        Try
            mysqlconn.Open()
            Dim query As String
            query = "select * from parts"
            COMMAND = New MySqlCommand(query, mysqlconn)
            sda.SelectCommand = COMMAND
            sda.Fill(dbdataset)
            bsource.DataSource = dbdataset
            DataGridView1.DataSource = bsource
            sda.Update(dbdataset)
            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub











    Private Sub Form6_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        isigrid3()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isigrid3()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        insertdatabase()

        isigrid3()
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DataGridView1.Refresh()
    End Sub
End Class