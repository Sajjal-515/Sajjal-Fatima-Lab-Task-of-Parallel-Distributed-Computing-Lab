using System;
using System.Threading;
class Program
{
    void Apple(int n)
    {
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("Apple");
            Thread.Sleep(n);
        }
    }
    void Banana(int m)
    {
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("Banana");
            Thread.Sleep(m);
        }
    }
    void Cherry(int o)
    {
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("Cherry");
            Thread.Sleep(o);
        }
    }
    static void Main()
    {  
        Program p = new Program();
        int q = 1000;
        int m = 2000;
        int o = 3000;
        Thread t1 = new Thread(() => p.Apple(q));
        Thread t2 = new Thread(() => p.Banana(m));
        Thread t3 = new Thread(() => p.Cherry(o));
        t1.Start(); 

        t2.Start();

        t3.Start();  
        
        t1.Join();

        t2.Join();

        t3.Join();    
       
        Console.WriteLine("All threads finished.");
    }
}