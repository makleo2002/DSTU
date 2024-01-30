using System.IO.Pipes;

public class CesarEncrypt
{
    //символы русской азбуки
    const string alfabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

    private string CodeEncode(string text, int k)
    {
        //добавляем в алфавит маленькие буквы
        var fullAlfabet = alfabet + alfabet.ToLower();
        var letterQty = fullAlfabet.Length;
        var retVal = "";
        for (int i = 0; i < text.Length; i++)
        {
            var c = text[i];//берем символ текста
            var index = fullAlfabet.IndexOf(c);//берем его индекс
            //если символ не найден, то добавляем его в неизменном виде
            if (index < 0)
            {
                
                retVal += c.ToString();
            }
            else //иначе меняем
            {
                var codeIndex = (letterQty + index + k) % letterQty;//формула
                retVal += fullAlfabet[codeIndex];
            }
        }

        return retVal;
    }

    //шифрование текста
    public string Encrypt(string plainMessage, int key)
        => CodeEncode(plainMessage, key);

    //дешифрование текста
    public string Decrypt(string encryptedMessage, int key)
        => CodeEncode(encryptedMessage, -key);
}
class Server
{

    static void StartServer()
    {
        var server = new NamedPipeServerStream("PipesOfPiece");

        server.WaitForConnection();

        Console.WriteLine("Client connected to server");

        StreamReader reader = new StreamReader(server);
        StreamWriter writer = new StreamWriter(server);

        while (true)
        {
            var line = reader.ReadLine();
            var lines = line.Split();

            Console.WriteLine("Server Response: ");
            writer.WriteLine(line);
            writer.Flush();
            if (lines[2] == "encrypt") EncryptServer(lines[0], lines[1]);
            else if (lines[2] == "decrypt") DecryptServer(lines[0], lines[1]);
        }

    }
    static void EncryptServer(string name, string name1)
    {
        string path = "C:\\Users\\Максим\\source\\repos\\Os_Lab4\\Task5\\";
        string path1 = path + name1;
        path += name;
        StreamReader streamReader = new StreamReader(path);
        string text = streamReader.ReadToEnd();

        CesarEncrypt cesarEncrypt = new CesarEncrypt();
        text = cesarEncrypt.Encrypt(text, 3);
        File.WriteAllText(path1, text);


    }

    static void DecryptServer(string name, string name1)
    {
        string path = "C:\\Users\\Максим\\source\\repos\\Os_Lab4\\Task5\\";
        string path1 = path + name1;
        path += name;
        StreamReader streamReader = new StreamReader(path);
        string text = streamReader.ReadToEnd();

        CesarEncrypt cesarEncrypt = new CesarEncrypt();
        text = cesarEncrypt.Decrypt(text, 3);

        File.WriteAllText(path1, text);
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Сервер запущен");

        StartServer();
    }
}