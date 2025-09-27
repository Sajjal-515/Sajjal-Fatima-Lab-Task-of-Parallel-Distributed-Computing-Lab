using System;
using System.Threading;

class RainAnimation
{
    static void Main()
    {
        string[] frames = new string[]
        {
            @"
   |     |       |     |
      |       |     |    
   |     |       |     |
",
            @"
      |       |     |    
   |     |       |     |
      |       |     |    
",
            @"
   |     |       |     |
      |       |     |    
   |     |       |     |
"
        };
        Console.CursorVisible = false;
        for (int i = 0; i < 50; i++)
        {
            foreach (string frame in frames)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(frame);
                Thread.Sleep(300);
            }
        }
        Console.CursorVisible = false;
    }
}