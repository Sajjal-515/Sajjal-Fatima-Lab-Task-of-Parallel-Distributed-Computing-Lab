using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Collections.Generic;
class AuthServer
{
    static void Main()
    {
        var users = new Dictionary<string, string>
        {
            {"admin","1234"},{"user","pass"},{"test","1111"} 
        };
        var s = new TcpListener(IPAddress.Any, 5000);
        s.Start();
        Console.WriteLine(" Auth Server Running...");
        while (true)
        {
            using var c = s.AcceptTcpClient();
            using var ns = c.GetStream();
            byte[] buf = new byte[256];
            int n= ns.Read(buf);
            string[] creds = Encoding.UTF8.GetString(buf, 0, n).Split(',');
            string user=creds[0],pass=creds[1];
            string msg= users.ContainsKey(user)&&users[user]==pass?"Login Successful":"Invalid Credentials";
                ns.Write(Encoding.UTF8.GetBytes(msg));
                Console.WriteLine($"{user}->{msg}");
            }
        }
    }
