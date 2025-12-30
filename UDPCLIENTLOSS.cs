using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
class UDPClientLossDemo
{
static void Main()
{
UdpClient client = new UdpClient();
client.Connect("127.0.0.1", 9000);
for (int i = 1; i <= 50; i++)
{
string msg = $"Packet {i}";
byte[] data = Encoding.ASCII.GetBytes(msg);
client.Send(data, data.Length);
}
Console.WriteLine("All packets sent!");
client.Close();
}
}