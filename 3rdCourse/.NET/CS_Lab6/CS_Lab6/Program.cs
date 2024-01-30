
using System.Text;

static void CopyFile(string path, string newName)
{
    try
    {
        newName += Path.GetExtension(path);//получаем расширение
        string dir = Path.GetDirectoryName(path);//имя директории
        dir += "\\";
        string path2 = dir + newName;//совмещаем
        File.Copy(path, path2);
    }
    catch (IOException) { Console.WriteLine("Указанный файл не существует либо в директории,в которую копируется файл,есть файл с таким же именем"); }
}

static void MoveFile(string path, string path1)
{
    try
    {
        path1 += Path.GetFileName(path);
        File.Move(path, path1);
    }
    catch (IOException) { Console.WriteLine("Такого файла не существует,либо путь перемещения указан неправильно, либо файл с таким названием уже есть в директории перемещения"); }
}

static void DeleteFile(string path)
{
    try
    {
        File.Delete(path);
    }
    catch (IOException) { Console.WriteLine("Такого файла не существует"); }
}

static void CreateDir(string path)
{
    try
    {
        Directory.CreateDirectory(path);
    }
    catch (IOException) { Console.WriteLine("Такая директория уже есть"); }
}

static void ChangeDir(string path)
{
    try
    {
        Directory.SetCurrentDirectory(path);
        Console.WriteLine("Текущая директория:\n", Directory.GetCurrentDirectory());
    }
    catch (IOException) { Console.WriteLine("Директория пуста"); }
}

static void CheckDir(string path)
{
    try
    {
        string[] mas = Directory.GetFiles(path);
        string[] mas1 = Directory.GetDirectories(path);
        Console.WriteLine("Файлы директории:");
        foreach (var i in mas) Console.WriteLine(Path.GetFileName(i));

        Console.WriteLine("Папки директории:");
        foreach (var i in mas1) Console.WriteLine(Path.GetFileName(i));

    }
    catch (IOException) { Console.WriteLine("Директория пуста"); }
}

static void BubbleSort(DateTime[] a, int n)
{
    DateTime tmp;
    int L = 0, R = n - 1;
    bool flag = false;
    while (R > 0)
    {
        int j = 0;
        while (j < R)
        {
            if (a[j] > a[j + 1])
            {
                tmp = a[j];
                a[j] = a[j + 1];
                a[j + 1] = tmp;
                flag = true;
            }
            j++;
        }
        if (flag == false)
        {
            break;
        }
        R--;
    }
}
static void SortDir(string path)
{
    try
    {
        string[] mas = Directory.GetFiles(path);
        DateTime[] dateTimes = new DateTime[mas.Length];
        Console.WriteLine("Файлы директории:");
        for (int i = 0; i < mas.Length; i++) dateTimes[i] = File.GetLastWriteTime(mas[i]);
        BubbleSort(dateTimes, dateTimes.Length);
        for (int i = 0; i < dateTimes.Length; i++)
        {
            for (int j = 0; j < mas.Length; j++)
                if (dateTimes[i] == File.GetLastWriteTime(mas[j]))
                    Console.Write(Path.GetFileName(mas[j]));
            Console.WriteLine(" " + dateTimes[i]);
        }
    }
    catch (IOException) { Console.WriteLine("Директория пуста"); }
}


string path = "", path1 = "";

Console.WriteLine("Файловый менеджер\n\n");
Console.WriteLine("1)Копировать файл\n");
Console.WriteLine("2)Переместить файл\n");
Console.WriteLine("3)Удалить файл\n");
Console.WriteLine("4)Создать каталог\n");
Console.WriteLine("5)Изменить каталог\n");
Console.WriteLine("6)Просмотреть каталог\n");
Console.WriteLine("7)Сортировать каталог по дате\n");
Console.WriteLine("8)Выход\n\n");

while (true)
{

    Console.WriteLine("Выбор : ");

    string select = Console.ReadLine();

    Console.WriteLine();

    if (select == "1")
    {
        path = Console.ReadLine();
        string name = Console.ReadLine();
        CopyFile(path, name);
    }
    else if (select == "2")
    {

        path = Console.ReadLine();
        path1 = Console.ReadLine();
        MoveFile(path, path1);
    }
    else if (select == "3")
    {
        path = Console.ReadLine();
        DeleteFile(path);
    }
    else if (select == "4")
    {
        path = Console.ReadLine();
        CreateDir(path);
    }
    else if (select == "5")
    {
        path = Console.ReadLine();
        ChangeDir(path);
    }
    else if (select == "6")
    {
        path = Console.ReadLine();
        CheckDir(path);
    }
    else if (select == "7")
    {
        path = Console.ReadLine();
        SortDir(path);
    }
    else if (select == "8")
    {
        Console.WriteLine("Программа завершена");
        break;
    }
}
