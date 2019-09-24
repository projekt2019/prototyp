Imports connector
Imports System.Net.Sockets


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
End Module