using System;
using System.Threading;
class Program
{
    static void Main()
    {
        string line = "-------";
        int length = line.Length;
        for (int i = 0; i < length; i++)
        {
            Console.Write("\r" + new string(' ', i) + "C" + line.Substring(i + 1));
            Thread.Sleep(200);
            Console.Write("\r" + new string(' ', i + 1) + line.Substring(i + 1));
            Thread.Sleep(200);
        }
        Console.Write("\r" + new string(' ', length) + "C");
        Console.WriteLine("\n\n Game over!Pac-Man ate all the dots!");
    }
}