Imports System.Net
Imports System.Net.Sockets

Public Class connector
    Dim TCPServer As Socket
    Dim TCPListenerz As TcpListener

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim sendbytes() As Byte = System.Text.Encoding.ASCII.GetBytes(Textbox2.Text)
        TCPServer.Send(sendbytes)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        TCPListenerz = New TcpListener(IPAddress.Any, 1000)
        TCPListenerz.Start()
        TCPServer = TCPListenerz.AcceptSocket()
        TCPServer.Blocking = False
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.Event Args) Handles Timer1.Tick
        Try
            Dim rcvbytes(TCPServer.ReceiveBufferSize) As Byte
            TCPServer.Receive(rcvbytes)
            Textbox3.Text = System.Text.Encoding.ASCII.GetString(rcvbytes)
        Catch ex As Exception
        End Try
    End Sub
End Class


Public Class Client
    Dim TCPClientz As Sockets.TcpClient
    Dim TCPClientStream As Sockets.NetworkStream

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim sendbytes() As Byte = System.Text.Encoding.ASCII.GetBytes(TextBox2.Text)
        TCPClientz.Client.Send(sendbytes)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TCPClientz = New Sockets.TcpClient(TextBox1.Text, 1000)
        Timer1.Enabled = True
        TCPClientStream = TCPClientz.GetStream()

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        If TCPClientStream.DataAvailable = True Then
            Dim rcvbytes(TCPClientz.ReceiveBufferSize) As Byte
            TCPClientStream.Read(rcvbytes, 0, CInt(TCPClientz.ReceiveBufferSize))
            TextBox3.Text = System.Text.Encoding.ASCII.GetString(rcvbytes)
        End If
    End Sub

End Class
