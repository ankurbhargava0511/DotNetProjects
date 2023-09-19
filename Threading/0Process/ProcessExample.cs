using System.Diagnostics;

namespace Threading.ProcessExample

{
    public static class ProcessExample    
    {
        public static  void runTask()
        {

            Process.Start("notepad.exe");
            Process.Start("notepad.exe", "C:\\tmp\\Hello.txt");
            //Process.Start("C:\\tmp\\Hello1.txt"); // it will give error

            var app = new Process();
            app.StartInfo.FileName = @"notepad.exe";
            app.StartInfo.Arguments= "C:\\tmp\\Hello2.txt";
            app.Start();
            app.PriorityClass = ProcessPriorityClass.Normal; // Priority is set after start else it will give error

            

            

            Console.WriteLine("Get all process and kill them");
            var Pro = Process.GetProcesses();
            // 
            foreach (var proc in Pro)
            {
                if (proc.ProcessName == "notepad")
                {
                    Console.WriteLine("Processname" + proc.ProcessName);
                    proc.Kill();
                }

            }
            Console.WriteLine("To make main thread wait it processes are closed.");
            app.WaitForExit();
            Console.WriteLine("Process name app closed");



        }


    }


    }
