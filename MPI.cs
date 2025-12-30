using System;
using MPI;
class HelloMPI
{
static void Main(string[] args)
{
using (new MPI.Environment(ref args))
{
var comm = Communicator.world;
Console.WriteLine($"Hello World from process {comm.Rank} of

{comm.Size}");
}
}
}