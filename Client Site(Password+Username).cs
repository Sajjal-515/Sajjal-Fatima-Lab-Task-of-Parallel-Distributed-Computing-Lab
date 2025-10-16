
using System;
using System.Net.Sockets;
using System.Text;
class AuthClient
{
    static void Main()
    {

        var c = new TcpClient("10.10.20.18", 5000);
        var ns = c.GetStream();
        Console.Write("Username:");
        string user = Console.ReadLine();
        Console.Write("Password:");
        string pas = Console.ReadLine();
        ns.Write(Encoding.UTF8.GetBytes($"{user},{pas}"));
        byte[] buf = new byte[256];
        int n = ns.Read(buf);
        Console.WriteLine("Server Response:" + Encoding.UTF8.GetString(buf, 0, n));


    }
}
