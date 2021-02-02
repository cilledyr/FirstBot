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
        public BuildingBot(string filePathName, int delay)
        {
            Filepath = filePathName;
            Delay = delay;
            t = new Task(delegate { loopBuild(); });
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
            while(building)
            {
                doBuild();
                Thread.Sleep(Delay * 1000);
            }
        }

        public void setBuilding(Boolean isbuildingOn)
        {
            building = isbuildingOn;
        }
    }
}
