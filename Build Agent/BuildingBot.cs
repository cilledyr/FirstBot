using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Build_Agent
{
    public class BuildingBot
    {
        private string Filepath;
        private int Delay;
        private Boolean building = true;
        private Task t;
        private CancellationTokenSource cts;
        public BuildingBot(string filePathName, int delay)
        {
            Filepath = filePathName;
            Delay = delay;
            cts = new CancellationTokenSource();
            t = new Task(delegate { loopBuild(); }, cts.Token);
            t.Start();
        }
        public void doBuild()
        {
            var process = new Process
            {
                StartInfo =
                {
                    FileName = "dotnet",
                    Arguments = "build",
                    WorkingDirectory = Filepath
                }
            };

            process.Start();
            process.WaitForExit();
            Console.Out.WriteLine("I finished building");
        }

        public void loopBuild()
        {
            while (building)
            {
                doBuild();
                try
                {
                    Task.Delay(Delay * 1000, cts.Token).Wait();
                }
                catch (Exception e)
                {
                    Console.Out.WriteLine(e);
                }
                
            }
            
        }

        public void Terminate()
        {
            building = false;
            cts.Cancel();
        }
    }
}
