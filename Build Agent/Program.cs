using System;
using System.Diagnostics;

namespace Build_Agent
{
    class Program
    {
        static void Main(string[] args)
        {
            var bot = new BuildingBot(@"D:\C# shared\Build Agent\Build Agent\", 10);
            Console.ReadKey();
            bot.Terminate();
            Console.ReadKey();
        }

        
    }
}
