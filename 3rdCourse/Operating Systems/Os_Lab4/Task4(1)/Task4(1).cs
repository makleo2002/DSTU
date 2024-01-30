using System.IO.Pipes;
class Server
{
    static void  StartServer()
    {
            var server = new NamedPipeServerStream("PipesOfPiece");
            server.WaitForConnection();


            StreamReader reader = new StreamReader(server);
            StreamWriter writer = new StreamWriter(server);
            while (true)
            {
               
                string line = reader.ReadLine();
                Console.WriteLine("Server's response: ");
                writer.WriteLine(line);
                writer.Flush();
                Console.WriteLine(reader.ReadLine());
                CopyFileonServer(line.Split()[0], line.Split()[1]);
              
            }
        
    }
    static void CopyFileonServer(string name, string name1)
    {
        string path = "C:\\Users\\Максим\\source\\repos\\Os_Lab4\\Task4\\";
        string path1 = path + name1;
        path += name;
        File.Copy(path, path1);
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Server started");
        StartServer();
      
    }
}
