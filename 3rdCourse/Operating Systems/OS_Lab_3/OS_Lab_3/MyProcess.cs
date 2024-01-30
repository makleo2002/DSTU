using System;
using System.Diagnostics;
using System.IO;


namespace OS_Lab_1 // Note: actual namespace depends on the project name.
{
 internal class MyProcess
    {
        private List<Process> processes = new List<Process>();
        private List<DateTime> time=new List<DateTime>();

      public List<DateTime> Time
        {
            get { return time; }
            set { time = value; }
        }

        public void startProcessesFromFile(string path) //1
        {
            String line;
            int count = -1;
            StreamReader sr = new StreamReader(path);
            line = sr.ReadLine();
            
            while (line != null)
            {         
                    if (Char.IsDigit(line[0]))
                    {   
                    time.Add(new DateTime(2022,10,21,0,0,int.Parse(line)));
                    Console.WriteLine("Максимально допустимое время процесса № " + (Time.Count - 1)+" : "+Time[Time.Count-1].Second);
                    }
                    else
                    {
                    Console.WriteLine("Имя процесса: "+line);
                    Process process = Process.Start(line);
                    processes.Add(process);
                    count++;

                    process.WaitForExit();

                    DateTime newTime = new DateTime(2022, 10, 21, process.ExitTime.Hour - process.StartTime.Hour,
                         process.ExitTime.Minute - process.StartTime.Minute, process.ExitTime.Second - process.StartTime.Second);

                    Console.WriteLine("\nВремя жизни процесса " + newTime + "\n");
                    if ((newTime.Hour <= Time[count].Hour && newTime.Minute <= Time[count].Minute && newTime.Second <= Time[count].Second))
                        Console.WriteLine("Процесс уложился в максимально допустимое время\n");
                    else Console.WriteLine("Процесс не уложился в максимально допустимое время\n");
                    process.Kill();
                }
                line = sr.ReadLine();
            }
            sr.Close();
            /*
            for (int i = 0; i < processes.Count; i++)
            {
                processes[i].WaitForExit();

                DateTime newTime = new DateTime(2022,10,21, processes[i].ExitTime.Hour - processes[i].StartTime.Hour, 
                    processes[i].ExitTime.Minute - processes[i].StartTime.Minute, processes[i].ExitTime.Second - processes[i].StartTime.Second);

                Console.WriteLine("\nВремя жизни процесса " + processes[i].Id + " " + newTime+ "\n");
                if (newTime.Hour <= Time[i].Hour && newTime.Minute <= Time[i].Minute && newTime.Second <= Time[i].Second)
                    Console.WriteLine("Процесс уложился в максимально допустимое время");
                else Console.WriteLine("Процесс не уложился в максимально допустимое время");

            }

        */
        }

        public void startExecutableFile(string path) //2
        {
            if (File.Exists(path)&&(path.EndsWith(".exe")||path.EndsWith(".bat")||path.EndsWith(".cmd")))
            {
               Process process=Process.Start(path);
               process.WaitForExit();
               File.Delete(path);
            }
            else
            {
                Console.WriteLine("Файл не найден либо не является исполняемым\n");
                Thread.Sleep(10000);
                startExecutableFile(path);
            }
              
        }
       public void changeThreads() //3
        {
            StreamReader streamReader = new StreamReader("C:\\Users\\Максим\\source\\repos\\OS_Lab_3\\OS_Lab_3\\input.txt");
            StreamWriter streamWriter = new StreamWriter("C:\\Users\\Максим\\source\\repos\\OS_Lab_3\\OS_Lab_3\\output.txt");

            String line= streamReader.ReadLine();
            while (line != null)
            {
                streamWriter.WriteLine(line);
                line = streamReader.ReadLine();
            }
            streamReader.Close();
            streamWriter.Close();
        }

        public void copyFilesFromDir(string inputDir,string outputDir) //5
        {
           string[] files= Directory.GetFiles(inputDir);
            for (int i = 0; i < files.Length; i++)
            {  
                string fName = files[i].Substring(inputDir.Length + 1);
                try
                {
                    File.Copy(Path.Combine(inputDir, fName), Path.Combine(outputDir, fName));
                    
                }
                catch (Exception) { }
                
            }
        }
        public void startExecutableFileLinux(string path) //4
        {
            if (File.Exists(path) && (path.EndsWith(".exe") || path.EndsWith(".bat") || path.EndsWith(".cmd")))
            { 
                ProcessStartInfo info= new ProcessStartInfo(path);
                Process process=new Process();
                process = Process.Start(info);
                process.WaitForExit();
                File.Delete(path);
            }
            else
            {
                Console.WriteLine("Файл не найден либо не является исполняемым\n");
                Thread.Sleep(10000);
                startExecutableFile(path);
            }

        }
        static void Main(string[] args)
        {
      
            MyProcess myProcess = new MyProcess();
           //myProcess.startProcessesFromFile("C:\\Users\\Максим\\source\\repos\\OS_Lab_3\\OS_Lab_3\\config.txt");

          // myProcess.startExecutableFile("C:\\Users\\Максим\\Desktop\\myDir\\output\\explorer.exe");
          // myProcess.changeThreads();
          myProcess.copyFilesFromDir("C:\\Users\\Максим\\Desktop\\myDir\\input", "C:\\Users\\Максим\\Desktop\\myDir\\output");


        }
    }
   
}

/*
 * 
 *      newTime.AddYears(2022);
                newTime.AddMonths(10);
                newTime.AddDays(21);
                newTime.AddHours(processes[i].ExitTime.Hour - processes[i].StartTime.Hour);
                newTime.AddMinutes(processes[i].ExitTime.Minute - processes[i].StartTime.Minute);
                newTime.AddSeconds((processes[i].ExitTime.Second - processes[i].StartTime.Second));
                newTime.AddMilliseconds((processes[i].ExitTime.Millisecond - processes[i].StartTime.Millisecond));

                if (!process.HasExited)
                {
                    Thread.Sleep(3000);
                    lifeTimeProcess();
                }
                */