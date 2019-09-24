
Imports connector

Public Class Form1
    Public WithEvents connector As ClientConnector

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connector = New ClientConnector()
        connector.OnRecieve = AddressOf recieve
        connector.connect()
        connector.send("Hallo!")
    End Sub
    Private Sub recieve(msg As String)
        Console.WriteLine("Recieved! " & msg)
    End Sub
End Class
