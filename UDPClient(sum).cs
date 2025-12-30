using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
class UDPClient
{
static void Main()
{
UdpClient client = new UdpClient();
client.Connect("127.0.0.1", 9000);
Console.Write("Enter your integer value (client side): ");
int clientValue = int.Parse(Console.ReadLine());
byte[] data =
Encoding.ASCII.GetBytes(clientValue.ToString());
client.Send(data, data.Length);
IPEndPoint serverEP = new IPEndPoint(IPAddress.Any,
0);
byte[] receivedData = client.Receive(ref serverEP);
string result = Encoding.ASCII.GetString(receivedData);
Console.WriteLine($"Sum received from server:
{result}");
client.Close();
}
}