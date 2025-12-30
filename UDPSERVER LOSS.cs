using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
class UDPServerLossDemo
{
static void Main()
{
UdpClient server = new UdpClient(9000);
IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);
Console.WriteLine("Server started. Waiting for packets...");
int count = 0;
while (count < 50) // expect 50 messages
{
byte[] data = server.Receive(ref remoteEP);
string msg = Encoding.ASCII.GetString(data);
Console.WriteLine($"Received: {msg}");
count++;
}
Console.WriteLine("Finished receiving packets.");
server.Close();
}
}