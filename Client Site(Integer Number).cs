using System;
using System.Net.Sockets;
using System.Text;
class Client
{
    static void Main()
    {
        for (int i = 0; i < 10; i++)
        {
            var client = new TcpClient("10.10.20.18", 5000);
            var ns = client.GetStream();
            Console.Write("Enter Number:");
            string msg = Console.ReadLine();
            ns.Write(Encoding.UTF8.GetBytes(msg));
            byte[] data = new byte[4096];
            int n = ns.Read(data, 0, data.Length);
            Console.WriteLine("Server Reply:" + Encoding.UTF8.GetString(data, 0, n));
            ns.Close();
            client.Close();
        }
    }
}
