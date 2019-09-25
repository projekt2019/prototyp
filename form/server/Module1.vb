Imports connector
Imports System.Net.Sockets
Imports System.Data.OleDb

Module Module1
     
    Public WithEvents connector As ServerConnector

    Sub Main()
        connector = New ServerConnector()
        connector.OnRecieve = AddressOf rec
        connector.connect()
    End Sub
    Sub rec(msg As String, client As TcpClient)
        connector.sendAll(msg)
        Console.WriteLine(msg)
    End Sub
 

    Public Sub Provider()
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data C:\Users\User\Source\Repos\prototyp\form\server\My Project\database\databasemsg.mdb;"
        cmd.Connection = con
    End Sub
    
    Public con As New OleDb.OleDbConnection
    Public cmd As New OleDb.OleDbCommand
    Public reader As OleDb.OleDbDataReader
    Public anzahl As Integer  
    
If txtSender.Text = "" Or txt_msg.Text = "" Then
            msgbox("Füllen Sie alle Felder aus!")
        Else
            Try
                con.Open() 'Verbindung zur Db öffnen
                cmd.CommandText = "INSERT INTO databasemsg(Sender, Nachricht) VALUES ('" & txtSender.text & "', '" & txtmsg.text & "')" 'Der Befehl für die DB
                anzahl = cmd.ExecuteNonQuery 'anzahl enthält nun ein Wert alle geänderten/ hinzugefügten/ gelöschten Einträge
                con.close 'Verbindung zur DB schließen
                If anzahl > 0 Then 'Nun wird kontrolliert ob überhaupt ein Eintrag hinzugefügt geworden ist, wenn ja dann die MSG
                    MsgBox("Sie haben eine Nachricht versendet", MsgBoxStyle.Information)
                End If
            Catch ex As Exception
                con.close 'ich schließe hier ebenfalls die Verbindung, weil wenn ein Fehler in dem oberen code passiert, passiert er vor dem schließen der Verbindung. Wenn ich das nicht machen würde käme der Fehler das die Verbindung noch offen ist, wenn ich das nächste mal eine Verbindung öffne.
                MsgBox(ex.Message)
            End Try
        End If



     Try
            con.Open()
            cmd.CommandText = "SELECT * FROM databasemsg WHERE ID = 0"
            reader = cmd.ExecuteReader
            Do While reader.Read
               txtSender.text = reader("Sender")
               txtmsg.text = reader("Nachricht")   
            Loop
            reader.Close()
              con.close
        Catch ex As Exception
            con.close
            MsgBox(ex.Message)
        End Try

End Module