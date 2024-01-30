using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Net;
using System.Text;

class Task4 {


    static void Main(string[] args)
    {
        Process process = Process.Start("C:\\Users\\Максим\\source\\repos\\Os_Lab4\\Task4(1)\\bin\\Debug\\net6.0\\Task4(1).exe");
       
        var client = new NamedPipeClientStream("PipesOfPiece");
        client.Connect();

        Console.WriteLine("Client connected");
        StreamReader reader = new StreamReader(client);
        StreamWriter writer = new StreamWriter(client);

        while (true)
        {
            Console.WriteLine("Enter name of file and name of destination file");
            string input = Console.ReadLine();
            if (String.IsNullOrEmpty(input)) continue;
            writer.WriteLine(input);
            writer.Flush();
            Console.WriteLine(reader.ReadLine());
        }


    }
}
