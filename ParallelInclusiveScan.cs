using System;
using System.Diagnostics;
using System.Threading.Tasks;
class ParallelInclusiveScanInPlace
{
static void Main()
{
int n = 100000;
int[] data = new int[n];
// Initialize array with values
for (int i = 0; i < n; i++)
data[i] = 1;
Console.WriteLine("Running Parallel Inclusive Scan (In-Place)...");
Stopwatch sw = Stopwatch.StartNew();
// Perform in-place parallel inclusive scan
for (int offset = 1; offset < n; offset++)
{
Parallel.For(offset, n, i =>
{
data[i] += data[i - offset];
});
}
sw.Stop();
Console.WriteLine($"Completed in {sw.ElapsedMilliseconds} ms");
}
}