using System;
namespace SequentialScan
{
internal class Program
{
static void Main(string[] args)
{
int[] input = { 3, 1, 7, 0, 4, 1, 6, 3 };
int[] output = new int[input.Length];
output[0] = input[0];
// Sequential Scan (Prefix Sum)
for (int i = 1; i < input.Length; i++)
{
output[i] = output[i - 1] + input[i];
}
Console.WriteLine("Sequential Scan (Prefix Sum):");
Console.WriteLine(string.Join(", ", output));
}
}
}