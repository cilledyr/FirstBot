using System;
using System.Diagnostics;

namespace Build_Agent
{
    class Program
    {
        static void Main(string[] args)
        {
            var bot = new BuildingBot(@"D:\C# shared\Build Agent\Build Agent\", 10);
            var bot1 = new BuildingBot(@"D:\C# shared\Build Agent\Build Agent\", 3);
            Console.ReadKey();
        }

        
    }
}
