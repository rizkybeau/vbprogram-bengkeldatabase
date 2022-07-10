Imports MySql.Data.MySqlClient

Public Class Form5
    Dim mysqlconn As MySqlConnection
    Dim COMMAND As MySqlCommand
    Dim stok As Integer
    Dim tName As String
    Sub pengambilan()
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;userid=root;password=;database=databasebengkel"
        Dim READER As MySqlDataReader
        Try
            mysqlconn.Open()
            Dim query As String
            query = "select stok from parts where kodeparts='" & ComboBox2.Text & "'"
            COMMAND = New MySqlCommand(query, mysqlconn)
            READER = COMMAND.ExecuteReader
            While READER.Read

                tName = READER.GetString("stok")
                If tName < 0 Or Val(TextBox1.Text) > tName Then
                    MessageBox.Show("habis stok silahkan beli lagi stoknya!")
                Else
                    stok = tName - Val(TextBox1.Text)
                    Label7.Text = stok
                End If


            End While
            mysqlconn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub
    
    Sub isiharga()
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;userid=root;password=;database=databasebengkel"
        Dim READER As MySqlDataReader
        Try
            mysqlconn.Open()
            Dim query As String
            query = "select kodeparts,harga from parts where kodeparts='" & ComboBox2.Text & "'"

            COMMAND = New MySqlCommand(query, mysqlconn)
            READER = COMMAND.ExecuteReader
            While READER.Read

                TextBox2.Text = READER.GetString("harga")
            End While
           

            mysqlconn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try

    End Sub
    Sub comboboxmysql()
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;userid=root;password=;database=databasebengkel"
        Dim READER As MySqlDataReader
        Try
            mysqlconn.Open()
            Dim query As String
            query = "select nofaktur from bonpembelian"
            COMMAND = New MySqlCommand(query, mysqlconn)
            READER = COMMAND.ExecuteReader
            While READER.Read
                Dim sName = READER.GetString("nofaktur")
                'Dim tName = READER.GetString("kodeparts")
                ComboBox1.Items.Add(sName)
                'ComboBox2.Items.Add(tName)

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
            Dim query As String
            query = "select kodeparts from parts"
            COMMAND = New MySqlCommand(query, mysqlconn)
            READER = COMMAND.ExecuteReader
            While READER.Read
                ' Dim sName = READER.GetString("nofaktur")
                Dim tName = READER.GetString("kodeparts")
                'ComboBox1.Items.Add(sName)
                ComboBox2.Items.Add(tName)

            End While
            mysqlconn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try


    End Sub

    Sub isigrid4()
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;userid=root;password=;database=databasebengkel"
        Dim sda As New MySqlDataAdapter
        Dim dbdataset As New DataTable
        Dim bsource As New BindingSource

        Try
            mysqlconn.Open()
            Dim query As String
            query = "select * from transaksiparts"
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
    Sub insertdatabase() 'fungsi untuk insert data vb to databse mysql
        mysqlconn = New MySqlConnection 'mysqllconn di deklarasi terlebih dahulu
        mysqlconn.ConnectionString = "server=localhost;userid=root;password=;database=databasebengkel"
        Dim reader As MySqlDataReader 'reader diperlukan membaca kode query
        Try

            mysqlconn.Open() 'menghubungkan vb.net ke database mysql
            Dim query As String 'query bertipe string
            'kode query mysql
            query = "insert into transaksiparts  (nofaktur,kodeparts,qty,harga,diskon) values ('" & ComboBox1.Text & "','" & ComboBox2.Text & "','" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox5.Text & "')"
            COMMAND = New MySqlCommand(query, mysqlconn) 'eksekutor
            reader = COMMAND.ExecuteReader

            MessageBox.Show("data saved")
            mysqlconn.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message)

        Finally
            mysqlconn.Dispose()
        End Try

    End Sub
    Sub updatestock()
        'fungsi untuk insert data vb to databse mysql
        mysqlconn = New MySqlConnection 'mysqllconn di deklarasi terlebih dahulu
        mysqlconn.ConnectionString = "server=localhost;userid=root;password=;database=databasebengkel"
        Dim reader As MySqlDataReader 'reader diperlukan membaca kode query
        Try

            mysqlconn.Open() 'menghubungkan vb.net ke database mysql
            Dim query As String 'query bertipe string
            'kode query mysql
            query = "UPDATE parts SET stok = '" & Label7.Text & "' WHERE KodeParts = '" & ComboBox2.Text & "'"
            COMMAND = New MySqlCommand(query, mysqlconn) 'eksekutor
            reader = COMMAND.ExecuteReader

            ' MessageBox.Show("data saved")
            mysqlconn.Close()


        Catch ex As Exception
            MessageBox.Show(ex.ToString)

        Finally
            mysqlconn.Dispose()
        End Try

    End Sub






    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        isigrid4()
        comboboxmysql()
        comboboxmysql2()

    End Sub

   
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isigrid4()
        ComboBox1.Items.Clear()
        ComboBox2.Items.Clear()
        comboboxmysql()
        comboboxmysql2()

    End Sub
   
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        insertdatabase()
        pengambilan()
        'updatestock() comming soon
        'Label6.Text = stok

        isigrid4()
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick


    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        isiharga()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TextBox3.Text = "5000"
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DataGridView1.Refresh()
    End Sub

    Private Sub ComboBox3_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form10.ShowDialog()
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        TextBox5.Text = "5000"
    End Sub
End Class