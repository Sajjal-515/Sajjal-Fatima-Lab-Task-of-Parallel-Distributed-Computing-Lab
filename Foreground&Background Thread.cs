using System;
using System.Threading;
class Program
{
static void DoWork(string name)
{
for (int i = 1; i <= 5; i++)
{
Console.WriteLine($"{name} thread working... {i}");
Thread.Sleep(500);
}
}
static void Main()
{
// Foreground thread
Thread fgThread = new Thread(() => DoWork("Foreground"));
fgThread.IsBackground = false;
// Background thread
Thread bgThread = new Thread(() => DoWork("Background"));
bgThread.IsBackground = true;
fgThread.Start();
bgThread.Start();
Console.WriteLine("Main thread ends here.");
}
}