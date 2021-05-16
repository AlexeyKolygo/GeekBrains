using System;
using System.Diagnostics;
using System.Linq;

namespace Lesson6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task Manager Processes:");
            GetAllProcess();
            Console.WriteLine("");
        }
     
        static void GetAllProcess()
        {
            var allProcesses = Process.GetProcesses();
            foreach(var proc in allProcesses) { 
                Console.WriteLine($"ID: {proc.Id} ; ProcessName: { proc.ProcessName}"); 
            }

            Console.WriteLine("Enter ID or ProcessName to kill it naher");
            var input = Console.ReadLine();

            if (int.TryParse(input, out _))
            {
                try
                {
                    var b = Convert.ToInt32(input);
                    //Process.GetProcessById(b).Kill();
                    Console.WriteLine(Process.GetProcessById(b));
                }

                catch
                {
                    Console.WriteLine("No process with such ID was found!");
                }

            }
            else
            { 
                var p = Process.GetProcessesByName(input);
                foreach(var proc in p) { proc.Kill(); }
            }


        }
    }
}
