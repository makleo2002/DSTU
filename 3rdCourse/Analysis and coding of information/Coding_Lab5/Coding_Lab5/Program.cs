
using System.Collections.Generic;
using System.Text;

class Hamming
{
    private List<List<int>> matrix;//матрица
    private List<int> controlBits;
    private int width, height; //ширина и высота
    public Hamming()
    {
        matrix = new();
    }

    //добавляем слева нули к числу и переворачиваем строку
    private string СheckNum(string value)
    {
        while (value.Length < controlBits.Count)
        {
            value = 0 + value;
        }
        return new string(value.Reverse().ToArray());
    }
    private void FindControlBits(string code)
    {
        controlBits = new();
        int pow;
        int newLength = code.Length;
        for (int i = 0; i < newLength; i++)//ищем индексы равные cтепени двойки
        {
            pow = i + 1;
            while (pow % 2 == 0)
            {
                pow = pow / 2;
            }
            if (pow == 1)
            {
                controlBits.Add(i);
                newLength++;
            }

        }
        width = code.Length;//ширина
        height = controlBits.Count();//высота равная количеству контрольных бит
        
    }
    private void InitMatrix(string code)
    {
        matrix = new();
        for (int i = 0; i < height + 1; i++) //заполняем все нулями        
        {
            List<int> list = new List<int>();
            for (int j = 0; j < width; j++) list.Add(0);
            matrix.Add(list);

        }

        for (int j = 0; j < width; j++) //заполняем первую строку кодом
        {
            matrix[0][j] = (int)Char.GetNumericValue(code[j]);
            Console.Write(matrix[0][j]);
        }
        Console.WriteLine();

        for (int m = 0; m < controlBits.Count; m++) //вставляем контрольные биты
        {
            matrix[0].Insert(controlBits[m], 0);
            for (int k = 1; k < controlBits.Count + 1; k++)
            {
                matrix[k].Insert(controlBits[m], 0);
            }

        }
        height = matrix.Count();
        width = matrix[0].Count();
    }
    private void HemmingAlg()
    {
        for (int k = 0; k < width; k++)//меняем все строки кроме первой(столбики равны индексам переведенным в 2чную СС)
        {
            string value = Convert.ToString(k + 1, 2);
            value = СheckNum(value);
            for (int i = 1; i < height; i++)
            {

                matrix[i][k] = (int)Char.GetNumericValue(value[i - 1]);
            }

        }

        for (int m = 0; m < controlBits.Count; m++)//считаем сумму произведений для каждой r строки
        {
            int ind = m + 1, sum = 0;
            for (int j = 0; j < width; j++)//работаем с одной строкой
            {
                sum += matrix[0][j] * matrix[ind][j];
               
            }

            if (sum > 1) sum = sum % 2;
           // Console.WriteLine("sum " + sum);
            matrix[0][controlBits[m]] = sum;
        }


        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
                Console.Write(matrix[i][j] + " ");
            Console.WriteLine();
        }
    }
    //Кодирование
    public List<List<int>> Encode(string code)
    {
      //список индексов степеней двойки

        FindControlBits(code);

        Console.WriteLine("width " + width);
        Console.WriteLine("height " + height);

        InitMatrix(code);

        Console.WriteLine("width " + width);
        Console.WriteLine("height " + height);

        HemmingAlg();
      
        return matrix;
    }
    private string Decode(List<List<int>> matrix)
    {
        int errorPosition = 0;
        string decodedCode = "";

        for (int i = 0; i < controlBits.Count; i++)
        {
            int sum = 0;
            int bitPosition = controlBits[i];
            for (int j = 1; j < height; j++)
            {
                sum += matrix[j][bitPosition];
            }

            if (sum % 2 != matrix[0][bitPosition])
            {
                errorPosition += (int)Math.Pow(2, i);
            }
        }

        if (errorPosition != 0)
        {
            matrix[0][errorPosition - 1] = matrix[0][errorPosition - 1] == 0 ? 1 : 0;
        }

        for (int i = 0; i < controlBits.Count; i++)
        {
            matrix[0].RemoveAt(controlBits[i] - i);
        }

        for (int i = 0; i < width - controlBits.Count; i++)
        {
            decodedCode += matrix[0][i];
        }

        return decodedCode;
    }

    static void Main(string[] args)
    {
        Hamming hamming = new();
     var list = hamming.Encode("100100101110001");

        Console.WriteLine(hamming.Decode(list));
    }

}
