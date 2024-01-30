using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task8
{
    public class Task8
    {
        private static Semaphore semaphore = new Semaphore(5, 5);
        static HttpListener server1=new();
        static HttpListener server2= new();
        static Process process = new Process();
        public static void Main(string[] args)
        {
            Console.WriteLine("Server");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Server started");
            server1.Prefixes.Add("http://127.0.0.1:8080/");
            server1.Start();
          
         
            for (int i = 0; i < 5; i++)
              {
                if (semaphore.WaitOne(0))//waitOne ждет 0 мс и возвращает true если место есть и false,если нет
                {
                    process = Process.Start("C:\\Users\\Максим\\source\\repos\\Os_Lab4\\Task8(1)\\bin\\Debug\\net6.0\\Task8(1).exe");
                }
           ь  }
            Draw(server1);
        }
        public static void Draw(HttpListener server)
        {
            string path = "C:\\Users\\Максим\\source\\repos\\Os_Lab4\\Task8\\SharedMemory.txt";
            HttpListenerContext context = server.GetContext();
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;
            char[] message;
            //Размер введенного сообщения
            int size;

            MemoryMappedFile SharedMemory = MemoryMappedFile.OpenExisting("SharedMemory", MemoryMappedFileRights.Read);
           
            using (MemoryMappedViewAccessor reader = SharedMemory.CreateViewAccessor(0, 4, MemoryMappedFileAccess.Read))
            {
                size = reader.ReadInt32(0);
            }
            using (MemoryMappedViewAccessor reader = SharedMemory.CreateViewAccessor(4, size * 2, MemoryMappedFileAccess.Read))
            {
                //Массив символов сообщения
                message = new char[size];
                reader.ReadArray<char>(0, message, 0, size);
              
            }
            while (true)
            {
              
                string[] line = (new string(message)).Split();

                int x, y, x1, y1;
                int.TryParse(line[0], out x);
                int.TryParse(line[1], out y);
                int.TryParse(line[2], out x1);
                int.TryParse(line[3], out y1);
                string width = Math.Abs(x1 - x) + "";
                string height = Math.Abs(y1 - y) + "";
                string color = line[4];
                string rect = "<svg>\r\n    <rect x=\"" + line[0] + "\" y=\"" + line[1] + "\" width=\"" + width + "\" height=\"" + height + "\" style=\"fill:" + color + "\"/>\r\n</svg>";
                //     Data.figures.Add(rect);+ height +
              
                string html = "<HTML><BODY>" +rect+ "</BODY></HTML>";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(html);
               
                System.IO.Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                output.Close();

              
            }
        }
    }
}
