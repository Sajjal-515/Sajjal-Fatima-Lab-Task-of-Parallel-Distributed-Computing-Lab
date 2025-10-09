using System;
using System.Net.Sockets;
using System.Text;
class Client
{
    static void Main()
    {
        string ip = "10.10.20.14";
        using var c = new TcpClient(ip, 5000);
        for (int i = 1; i <= 10; i++)
        {
        var ns = c.GetStream();
        Console.Write("Meassage:");
        string msg = Console.ReadLine();
        ns.Write(Encoding.UTF8.GetBytes(msg));
        var buf = new Byte[1024];
        int n = ns.Read(buf, 0, buf.Length);
        Console.WriteLine("Server Reply:" + Encoding.UTF8.GetString(buf, 0, n));
        }

    }
}