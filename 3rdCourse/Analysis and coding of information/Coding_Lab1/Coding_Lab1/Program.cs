using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Zipper
{
    public class Node
    {
        public char Symbol { get; set; }
        public int Frequency { get; set; }
        public Node? R { get; set; }
        public Node? L { get; set; }

        public List<bool> EncodeSymbol(char symbol, List<bool> data)//кодирование символа
        {
          
            if (R == null && L== null) //если нет левой и правой ветки
            {
                if (symbol.Equals(this.Symbol))//если символ совпадает с символом узла,то возвращаем список битов
                {
                    return data;
                }
                else//если нет,возвращаем null
                {
                    return null;
                }
            }
            else 
            {
                List<bool> left = null;
                List<bool> right = null;

                if (L != null)//если есть левая ветка
                {
                    List<bool> leftPath = new List<bool>();//список битов левых путей
                    leftPath.AddRange(data);//добавляем к пути предыдущие ветки
                    leftPath.Add(false);//прибавляем 0

                    left = L.EncodeSymbol(symbol, leftPath);
                }

                if (R != null) //если есть правая ветка
                {
                    List<bool> rightPath = new List<bool>();//список битов правых путей
                    rightPath.AddRange(data);//добавляем к пути предыдущие ветки
                    rightPath.Add(true);//прибавляем 1

                    right = R.EncodeSymbol(symbol, rightPath);
                }

                if (left != null)
                {
                    return left;
                }
                else
                {
                    return right;
                }
            }
        }
    }

    public class HuffmanTree
    {
        private List<Node> nodes = new List<Node>();//список узлов дерева(очередь)
        public Node Root { get; set; } //корень дерева

        public Dictionary<char, int> Frequencies = new Dictionary<char, int>();//словарь частот

        public void Build(string path)//определяем частоты символов в строке
        {
            StreamReader sr = new StreamReader(path);

            string source = sr.ReadToEnd();

            for (int i = 0; i < source.Length; i++)
            {
                if (!Frequencies.ContainsKey(source[i]))//если такого символа в словаре нет,то добавляем
                {
                    Frequencies.Add(source[i], 0);
                }

                Frequencies[source[i]]++;
            }

            foreach (KeyValuePair<char, int> symbol in Frequencies)
            {
                nodes.Add(new Node() { Symbol = symbol.Key, Frequency = symbol.Value });//создаем узлы,в которые записываем символы и частоты
            }

            while (nodes.Count > 1)//если узлов больше 1
            {
                List<Node> orderedNodes = nodes.OrderBy(node => node.Frequency).ToList<Node>();//упорядочиваем узлы и записываем в новый список

                if (orderedNodes.Count >= 2)//если упорядоченных узлов больше 1
                {
                    // берем первые два узла с минимальными частотами
                    List<Node> taken = orderedNodes.Take(2).ToList<Node>();

                    // Создаем новый узел,складывая частоты
                    Node parent = new Node()
                    {
                        Symbol = '*',
                        Frequency = taken[0].Frequency + taken[1].Frequency,
                        //первую ноду вешаем на левую сторону, вторую – на правую
                        L = taken[0],
                        R = taken[1]
                    };

                    nodes.Remove(taken[0]);
                    nodes.Remove(taken[1]);
                    nodes.Add(parent);// добавляем полученный узел в список
                }

                this.Root = nodes.FirstOrDefault();//берем первый узел из списка

            }

        }

        public BitArray Encode(string path)//кодирование
        {
            StreamReader sr = new StreamReader(path);

            string source = sr.ReadToEnd();


            List<bool> encodedSource = new List<bool>();
            
            for (int i = 0; i < source.Length; i++)
            {
                List<bool> encodedSymbol = this.Root.EncodeSymbol(source[i], new List<bool>());//кодируем символ строки
                encodedSource.AddRange(encodedSymbol);//добавляем в список
            }

            BitArray bits = new BitArray(encodedSource.ToArray());//преобразуем список в массив битов.
            return bits;
        }

        public string Decode(BitArray bits)//декодирование
        {
            Node current = this.Root;//текущий узел(вначале корень)
            string decoded = "";//строка декода

            
            foreach (bool bit in bits)//смотрим биты в массиве
            {
                if (bit)//если бит единичный
                {
                    if (current.R != null)//если правый узел текущего узла сущ,то передвигаемся по нему
                    {
                        current = current.R;
                    }
                }
                else //если бит нулевой
                {
                    if (current.L != null)//если левый узел текущего узла сущ,то передвигаемся по нему
                    {
                        current = current.L;
                    }
                }

                if (IsLeaf(current))//если узел является листом
                {
                 
                    decoded += current.Symbol;//добавляем в декод символ
                    current = this.Root;//взовращаемся к корню
                }
            }

            return decoded;
        }

        public bool IsLeaf(Node node)//проверка узла на лист
        {
            return (node.L == null && node.R == null);
        }

    }
   
    class LZSS
    {
        // Выполняет поиск указанной последовательности в словаре
        
        private Int32 SearchInDict(IList<Byte> dictionary, IList<Byte> input, Int32 oldInd)// input- Подпоследовательность для поиска 
        {                                                                                  // dictionary - Входной массив/список в котором выполняем поиск подпоследовательности
            if (input.Count > dictionary.Count) return -1;
            for (var i = oldInd; i < dictionary.Count; i++)
            {
                for (byte j = 0; j < input.Count && i + j < dictionary.Count; j++)
                {
                    if (dictionary[i + j] == input[j])
                    {
                        if (j + 1 == input.Count)
                        {
                            return i;        // Если последовательность была найдена возвращает её индекс, иначе  -1
                        }
                    }
                    else break;
                }
            }
            return -1;
        }

        IEnumerable<Boolean> getBitList(Byte input) //перевод байта в массив бит
        {
            var arr = new Boolean[8];
            for (Byte i = 0; i < 8; i++)
            {
                arr[i] = (input & (1 << i)) > 0;
            }
            return arr;
        }


     
        // Сжимает входную последовательность с помощью алгоритма LZSS
        public BitArray Compress(IList<Byte> source)   // source- исходный поток данных для сжатия
        {
            //Словарь
            var dictionary = new List<Byte>(255);
            //Выходной поток
            var output = new List<Boolean>(source.Count / 5);
            //Буферное окно(скользящее окно)
            var buffer = new List<Byte>(255);

            for (var i = 0; i < source.Count; i++)//проходимся по массиву данных
            {
                buffer.Add(source[i]);//добавляем байт(слово) в буфер
                var oldInd = 0;//старый индекс
                do
                {
                    oldInd = SearchInDict(dictionary, buffer, oldInd);//ищем в словаре слово из буфера с определенного места
                    if (oldInd != -1 && i + 1 < source.Count)
                        buffer.Add(source[++i]);//добавляем слово в буфер
                    else
                        break;
                } while (true);

                if (buffer.Count > 1)
                {
                    buffer.RemoveAt(buffer.Count - 1);//удаляем последний жлемент из буфера
                    --i;
                }
                if (buffer.Count > 1)
                {
                    output.Add(true);
                    output.AddRange(getBitList((Byte)((dictionary.Count) - SearchInDict(dictionary, buffer, 0))));
                    output.AddRange(getBitList((Byte)buffer.Count));
                    dictionary.AddRange(buffer);
                    while (dictionary.Count > 255)
                    {
                        dictionary.RemoveAt(0);
                    }
                    buffer.Clear();
                }
                else
                {
                    output.Add(false);
                    output.AddRange(new BitArray(buffer.ToArray()).Cast<Boolean>());
                    dictionary.AddRange(buffer);
                    while (dictionary.Count > 255)
                    {
                        dictionary.RemoveAt(0);
                    }
                    buffer.Clear();
                }
               
            }
            var countBits = new BitArray(BitConverter.GetBytes(output.Count)).Cast<Boolean>();
            output.InsertRange(0, countBits);
            return new BitArray(output.ToArray());
        }

        /// Расжимает входную последовательность
        public Byte[] UnCompress(BitArray source, Int32 bitsCount)// bitsCount - Колличество бит в исходном файле (за исключением мусора)
        {
            var output = new List<Byte>();
            try {
                
                for (var i = 32; i < bitsCount + 24;)
                {
                    if (source[i] == false)
                    {
                        Byte tempByte = 0x0;
                        for (byte j = 0; j < 8 && j + i + 1 < source.Length; j++)
                        {
                            tempByte |= (byte)((source[++i] ? 1 : 0) << j);
                        }
                        output.Add(tempByte);
                        i++;
                    }
                    else
                    {
                        Byte offset = 0;
                        Byte count = 0;

                        for (byte j = 0; j < 8; j++)
                        {
                            offset |= (byte)((source[++i] ? 1 : 0) << j);
                        }
                        for (byte j = 0; j < 8; j++)
                        {
                            count |= (byte)((source[++i] ? 1 : 0) << j);
                        }
                        var dicCount = output.Count;
                        for (var c = 0; c < count; c++)
                        {
                            output.Add(output[dicCount - offset + c]);
                        }
                        i++;
                    }
                }
            }
            catch (Exception) { }
            //Выходной поток
            return output.ToArray();
        }
    }

    class Program
    {
        public static byte[] BitArrayToByteArray(BitArray bits)
        {
            byte[] ret = new byte[(bits.Length - 1) / 8 + 1];
            bits.CopyTo(ret, 0);       
            return ret;
        }

        static void Main(string[] args)
        {
            string enc_path = "C:\\Users\\Максим\\source\\repos\\Coding_Lab1\\Coding_Lab1\\enc.txt";
            string dec_path = "C:\\Users\\Максим\\source\\repos\\Coding_Lab1\\Coding_Lab1\\dec.txt";

            Console.WriteLine("Введите путь к файлу:");

            string path = Console.ReadLine();

            var ByteArr=File.ReadAllBytes(path);//массив байт исх.файла
            

            double input_bytes = ByteArr.Length;//кол-во байт исх.файла

            LZSS lzss = new LZSS();

            var lzssBitArr = lzss.Compress(ByteArr); //массив бит закодированного файла

            var lzssByteArr = BitArrayToByteArray(lzssBitArr); //массив бит декодированного файла


            File.WriteAllBytes(enc_path, lzssByteArr); //создаем файл с закодированным текстом,чтобы потом закодировать его хаффманом

            double lzss_bytes = lzssByteArr.Length;//кол-во байт закодированного файла


            Console.WriteLine("\nБайты входной строки" + input_bytes + "\nБайты выходной строки " + lzss_bytes);

            var  proc = ((input_bytes - lzss_bytes) / input_bytes) * 100;//считаем процент сжатия

            Console.WriteLine("Сжатие  " + proc + " %");


              var mas = lzss.UnCompress(lzssBitArr, lzssBitArr.Length); // декодируем и выводим в консоль

              var result = System.Text.Encoding.Default.GetString(mas);

              Console.WriteLine(result);



            HuffmanTree huffmanTree = new HuffmanTree();

            // Строим дерево Хаффмана
            huffmanTree.Build(enc_path);

            // Кодируем
            BitArray encoded = huffmanTree.Encode(enc_path);

            File.WriteAllBytes("C:\\Users\\Максим\\source\\repos\\Coding_Lab1\\Coding_Lab1\\huufman_enc.txt", BitArrayToByteArray(encoded));

            var HByteArr=BitArrayToByteArray(encoded);//массив байт закодированного файла

            double output_bytes = HByteArr.Length;//кол-во байт закодированного файла

            Console.WriteLine("\nБайты входной строки" + lzss_bytes + "\nБайты выходной строки " + output_bytes);

            var Hproc = ((lzss_bytes - output_bytes) / lzss_bytes)*100;//процент сжатия

            Console.WriteLine("Сжатие  " + Hproc + " %");


            // Декод

            string decoded = huffmanTree.Decode(encoded);//декодируем закодированный хаффманом файл

            File.WriteAllText("C:\\\\Users\\\\Максим\\\\source\\\\repos\\\\Coding_Lab1\\\\Coding_Lab1\\huufman_dec.txt", decoded);

            byte[] arr = Encoding.Default.GetBytes(decoded);

            BitArray bitsArray = new BitArray(arr);
           
            byte[] newDecode = lzss.UnCompress(bitsArray, bitsArray.Length);//декодируем еще раз через lzss

            var newresult = System.Text.Encoding.Default.GetString(newDecode);
           

            Console.WriteLine(newresult);

            File.WriteAllText(dec_path, newresult);
            

        }
    }

}

/*
1. Парсим ввод, считаем количество повторений символов
2. Определяем вероятность появления каждого символа
3. Сортируем список по вероятностям (самые частые вначале)
4. Создаём листы для каждого символа, и добавляем их в очередь
5. пока очередь состоит более, чем из одного символа:
— берём из очереди два листа с наименьшими вероятностями
— к коду первой прибавляем 0, к коду второй – 1
— создаём узел с вероятностью, равной сумме вероятностей двух нод
— первую ноду вешаем на левую сторону, вторую – на правую
— добавляем полученный узел в очередь
6. Последняя нода в очереди будет корнем двоичного дерева.
 */