Imports MySql.Data.MySqlClient


Public Class Form7
    Dim mysqlconn As New MySqlConnection
    Dim COMMAND As New MySqlCommand
    Dim vtanggallahir As String
    Dim vtgl As String
    Dim vbln As String
    Dim vthn As String
        

    Sub insertdatabase() 'fungsi untuk insert data vb to databse mysql
        mysqlconn = New MySqlConnection 'mysqllconn di deklarasi terlebih dahulu
        mysqlconn.ConnectionString = "server=localhost;userid=root;password=;database=databasebengkel"
        vthn = DateTimePicker1.Value.Year
        vbln = DateTimePicker1.Value.Month
        vtgl = DateTimePicker1.Value.Day
        vtanggallahir = vthn & "-" & vbln & "-" & vtgl

        Dim reader As MySqlDataReader 'reader diperlukan membaca kode query
        Try
            If TextBox1.Text = "" Then
                MessageBox.Show("ID Wajib Diisi")
                Exit Sub
            Else
                mysqlconn.Open() 'menghubungkan vb.net ke database mysql
                Dim query As String 'query bertipe string
                'kode query mysql
                query = "INSERT INTO `databasebengkel`.`bonpembelian` (`NoFaktur`, `Tanggal`, `NoPol`, `IDMekanik`, `potongan`) values ('" & TextBox1.Text & "','" & vtanggallahir & "','" & ComboBox1.Text & "','" & ComboBox2.Text & "','" & TextBox3.Text & "')"
                COMMAND = New MySqlCommand(query, mysqlconn) 'eksekutor
                reader = COMMAND.ExecuteReader

                MessageBox.Show("data saved")
                mysqlconn.Close()
            End If

            


        Catch ex As Exception
            MessageBox.Show(ex.Message)

        Finally
            mysqlconn.Dispose()
        End Try

    End Sub

    Sub comboboxmysql1()
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;userid=root;password=;database=databasebengkel"
        Dim READER As MySqlDataReader
        Try
            mysqlconn.Open()
            Dim query As String
            query = "select nopol from kendaraan group by nopol"
            COMMAND = New MySqlCommand(query, mysqlconn)
            READER = COMMAND.ExecuteReader
            'ComboBox1.Items.Clear()
            'ComboBox2.Items.Clear()
            While READER.Read
                Dim sName = READER.GetString("nopol") 'mengambil string di database mysql per baris


                ComboBox1.Items.Add(sName)


            End While
            mysqlconn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try


    End Sub
    Sub comboboxmysql2()
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;userid=root;password=;database=databasebengkel"
        Dim READER As MySqlDataReader
        Try
            mysqlconn.Open()
            Dim query As String 'nofaktur ta
            query = "select mekanik.idmekanik from bonpembelian, mekanik group by mekanik.idmekanik"
            COMMAND = New MySqlCommand(query, mysqlconn)
            READER = COMMAND.ExecuteReader
            'ComboBox1.Items.Clear()
            'ComboBox2.Items.Clear()
            While READER.Read
                Dim tName = READER.GetString("idmekanik")


                ComboBox2.Items.Add(tName)

            End While
            mysqlconn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try


    End Sub
    Sub isigrid2()
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;userid=root;password=;database=databasebengkel"
        Dim sda As New MySqlDataAdapter
        Dim dbdataset As New DataTable
        Dim bsource As New BindingSource

        Try
            mysqlconn.Open()
            Dim query As String
            query = "select * from bonpembelian"
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
    Private Sub Form7_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        isigrid2()
        DateTimePicker1.Value = Date.Now
        comboboxmysql1()
        comboboxmysql2()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        insertdatabase()
        DataGridView1.Refresh()
        isigrid2()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isigrid2()
        comboboxmysql1()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        TextBox3.Text = "2000"
    End Sub
End Class