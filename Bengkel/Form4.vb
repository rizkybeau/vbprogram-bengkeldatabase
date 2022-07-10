Imports MySql.Data.MySqlClient
Public Class Form4
    Dim mysqlconn As MySqlConnection
    Dim COMMAND As MySqlCommand
    Sub isigrid()
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;userid=root;password=;database=databasebengkel"
        Dim sda As New MySqlDataAdapter
        Dim dbdataset As New DataTable
        Dim bsource As New BindingSource
        Try
            mysqlconn.Open()
            Dim query As String
            query = "select * from mekanik"
            COMMAND = New MySqlCommand(query, mysqlconn)
            sda.SelectCommand = COMMAND
            sda.Fill(dbdataset)
            bsource.DataSource = dbdataset
            DataGridViewMekanik.DataSource = bsource
            sda.Update(dbdataset)
            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub
    Sub insertdatabase() 'fungsi untuk insert data vb to databse mysql
        mysqlconn = New MySqlConnection 'mysqllconn di deklarasi terlebih dahulu
        mysqlconn.ConnectionString = "server=localhost;userid=root;password=;database=databasebengkel"
        Dim reader As MySqlDataReader 'reader diperlukan membaca kode query
        Try

            mysqlconn.Open() 'menghubungkan vb.net ke database mysql
            Dim query As String 'query bertipe string
            'kode query mysql
            query = "insert into mekanik  (idmekanik,namamekanik) values ('" & TextBox9.Text & "','" & TextBox1.Text & "')"
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


    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        isigrid()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        insertdatabase()
        DataGridViewMekanik.Refresh()
        isigrid()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isigrid()
    End Sub
End Class