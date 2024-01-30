
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.IO.Pipes;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Task8;

namespace Task8 {

 
    public class Client
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\Максим\\source\\repos\\Os_Lab4\\Task8\\SharedMemory.txt";

            Console.WriteLine("Client");
            Console.WriteLine("------------------------------------");
            
                Console.WriteLine("Enter angles coordinates and color");

                char[] message = Console.ReadLine().ToCharArray();
                //Размер введенного сообщения
                int size = message.Length;

                using (MemoryMappedFile SharedMemory = MemoryMappedFile.CreateFromFile(path, FileMode.OpenOrCreate, "SharedMemory", 4096, MemoryMappedFileAccess.ReadWrite))
                {

                    //Создаем объект для записи в разделяемый участок памяти
                    using (MemoryMappedViewAccessor writer = SharedMemory.CreateViewAccessor(0, size * 2 + 4))
                    {
                        //запись в разделяемую память
                        //запись размера с нулевого байта в разделяемой памяти
                        writer.Write(0, size);
                        //запись сообщения с четвертого байта в разделяемой памяти
                        writer.WriteArray<char>(4, message, 0, message.Length);
                    }
                    string str = new string(message);
                    Console.WriteLine(message);

                    Console.WriteLine("Сообщение записано в разделяемую память");

                }
          
            } 


          

        }
    }






