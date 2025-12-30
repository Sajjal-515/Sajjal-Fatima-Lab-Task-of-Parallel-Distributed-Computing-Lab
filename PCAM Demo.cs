using System;
using System.Runtime.InteropServices;
using System.Threading;
class PCAMCompact
{
[DllImport("kernel32.dll")] static extern IntPtr GetCurrentThread();
[DllImport("kernel32.dll")] static extern IntPtr SetThreadAffinityMask(IntPtr hThread, IntPtr mask);
static void Main()
{
int cores = Environment.ProcessorCount;
Console.WriteLine($"Detected CPU Cores: {cores}\n");
Thread[] threads = new Thread[cores];
for (int i = 0; i < cores; i++)
{
int id = i; // closure
threads[i] = new Thread(() =>
{
Console.WriteLine($"Thread-{id}: Mapping to Core {id}");
SetThreadAffinityMask(GetCurrentThread(), (IntPtr)(1 << id));
Console.WriteLine($"Thread-{id}: Partitioning & Agglomeration");
int sum = 0;
for (int n = 1; n <= 10; n++) sum += n;
if (id > 0) Console.WriteLine($"Thread-{id}: Communicating with Thread-{id - 1}");
Console.WriteLine($"Thread-{id}: Result = {sum}\n");
});
threads[i].Start();
}
foreach (var t in threads) t.Join();
Console.WriteLine("=== ALL THREADS FINISHED ===");
}}