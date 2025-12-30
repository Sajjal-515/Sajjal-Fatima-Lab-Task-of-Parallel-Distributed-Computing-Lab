using System;
using System.Diagnostics;
using System.Threading;
class Program
{
static bool running = true;
static void Main()
{
Console.WriteLine("Running 4 threads (~70% CPU for 30s)...");
Thread[] threads = new Thread[4];
for (int i = 0; i < 4; i++)
{
threads[i] = new Thread(Work);
threads[i].Start();
}
Thread.Sleep(30000); // Run for 30 seconds
running = false;
foreach (var t in threads) t.Join();
Console.WriteLine("Done. Check CPU usage in Task Manager.");
}
static void Work()
{
var sw = new Stopwatch();
while (running)
{
sw.Restart();
while (sw.ElapsedMilliseconds < 70)
Math.Sqrt(12345.6789); // Busy work (~70%)
Thread.Sleep(30); // Idle (~30%)
} } }