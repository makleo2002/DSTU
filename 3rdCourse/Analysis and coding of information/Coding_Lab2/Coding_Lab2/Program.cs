
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

#pragma warning disable CA1416 // Проверка совместимости платформы
#pragma warning restore CA1416 // Проверка совместимости платформы

string path = "C:\\Users\\Максим\\source\\repos\\Coding_Lab2\\Coding_Lab2\\bin\\Debug\\net6.0\\img1.bmp";

static Bitmap GetBlue(Bitmap bmp)
{
    Rectangle rect = new Rectangle(Point.Empty, bmp.Size);
    BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
    int stride = Math.Abs(bmpData.Stride);
    int length = stride * bmp.Height;
    byte[] buffer = new byte[length];
    Marshal.Copy(bmpData.Scan0, buffer, 0, bmpData.Stride * bmp.Height);
    bmp.UnlockBits(bmpData);
    for (int row = 0; row < bmp.Height; row++)
    {
        int rowOffset = stride * row;
        for (int col = 0; col < bmp.Width; col++)
        {
            int offset = rowOffset + col * 3;
            buffer[offset + 1] = 0;
            buffer[offset + 2] = 0;
        }
    }
    Bitmap result = new Bitmap(bmp.Width, bmp.Height, PixelFormat.Format24bppRgb);
    BitmapData resultData = result.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
    Marshal.Copy(buffer, 0, resultData.Scan0, length);
    result.UnlockBits(resultData);
    return result;
}

static Bitmap GetGreen(Bitmap bmp)
{
    Rectangle rect = new Rectangle(Point.Empty, bmp.Size);
    BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
    int stride = Math.Abs(bmpData.Stride);
    int length = stride * bmp.Height;
    byte[] buffer = new byte[length];
    Marshal.Copy(bmpData.Scan0, buffer, 0, bmpData.Stride * bmp.Height);
    bmp.UnlockBits(bmpData);
    for (int row = 0; row < bmp.Height; row++)
    {
        int rowOffset = stride * row;
        for (int col = 0; col < bmp.Width; col++)
        {
            int offset = rowOffset + col * 3;
            buffer[offset] = 0;
            buffer[offset + 2] = 0;
        }
    }
    Bitmap result = new Bitmap(bmp.Width, bmp.Height, PixelFormat.Format24bppRgb);
    BitmapData resultData = result.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
    Marshal.Copy(buffer, 0, resultData.Scan0, length);
    result.UnlockBits(resultData);
    return result;
}

static Bitmap GetRed(Bitmap bmp)
{
    Rectangle rect = new Rectangle(Point.Empty, bmp.Size);//создаем прямоугольник равный нашему изображению
    BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);//формируем данные об изображении(размер,глубину)
    int stride = Math.Abs(bmpData.Stride);//если шаг(stride) положителен,то растровое изображение находится сверху вниз,в противном случае снизу вверх
    int length = stride * bmp.Height;//находим длину 
    byte[] buffer = new byte[length];//создаем массив пикселей
    Marshal.Copy(bmpData.Scan0, buffer, 0, bmpData.Stride * bmp.Height);//переносим информацию о пикселях в наш массив
    bmp.UnlockBits(bmpData);//разблокируем растровое изображение из системной памяти
    for (int row = 0; row < bmp.Height; row++)
    {
        int rowOffset = stride * row;//определяем смещение по строкам
        for (int col = 0; col < bmp.Width; col++)
        {
            int offset = rowOffset + col * 3;//определяем смещение для массива пикселей
            buffer[offset] = 0;//зануляем байт синего цвета
            buffer[offset + 1] = 0;//зануляем байт зеленого цвета
        }
    }
    Bitmap result = new Bitmap(bmp.Width, bmp.Height, PixelFormat.Format24bppRgb);//создаем изображение с разложением на красный цвет
    BitmapData resultData = result.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);//формируем данные об изображении(размер,глубину)
    Marshal.Copy(buffer, 0, resultData.Scan0, length);//копируем из буфера информацию о пикселях в наши данные об изображении
    result.UnlockBits(resultData);//разблокируем растровое изображение из системной памяти
    return result;//вовзращаем полученное изображение
}

static List<Bitmap> cutImage(Bitmap bmp)
{
    List<Bitmap> cuts = new();
    Rectangle rect = new Rectangle(Point.Empty, bmp.Size);
    BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
    int stride = Math.Abs(bmpData.Stride);
    int length = stride * bmp.Height;
    byte[] buffer = new byte[length];
    Marshal.Copy(bmpData.Scan0, buffer, 0, bmpData.Stride * bmp.Height);
    bmp.UnlockBits(bmpData);
    for (int k = 0; k < 8; k++)
    {
        for (int row = 0; row < bmp.Height; row++)
        {
            int rowOffset = stride * row;
            for (int col = 0; col < bmp.Width; col++)
            {
                int offset = rowOffset + col * 3;
                var gray = (byte)((0.3 * buffer[offset + 2]) + (buffer[offset + 1] * 0.6) + (buffer[offset] * 0.1));//формула для серого цвета
                buffer[offset] =(byte) (gray>>k);
                buffer[offset + 1] = (byte)(gray>>k);
                buffer[offset + 2] = (byte)(gray>>k);
            }

        }

        Bitmap result = new Bitmap(bmp.Width, bmp.Height, PixelFormat.Format24bppRgb);
        BitmapData resultData = result.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
        Marshal.Copy(buffer, 0, resultData.Scan0, length);
        result.UnlockBits(resultData);
        cuts.Add(result);
    }
    return cuts;
}

using (var breader = new BinaryReader(File.OpenRead(path)))
{
    Console.Write("Тип файла: {0}", breader.ReadChar());//0

    Console.WriteLine(breader.ReadChar());//1

    Console.WriteLine("Размер файла: {0}", breader.ReadInt32(), " байт");//2

    Console.WriteLine("Резервное поле 1: {0}", breader.ReadInt16());//6

    Console.WriteLine("Резервное поле 2: {0}", breader.ReadInt16());//8

    Console.WriteLine("Смещение: {0}", breader.ReadInt32());//10

    Console.WriteLine("Размер заголовка: {0}", breader.ReadInt32());//14

    Console.WriteLine("Ширина: {0}", breader.ReadInt32());//18

    Console.WriteLine("Высота: {0}", breader.ReadInt32());//22

    Console.WriteLine("Число плоскостей: {0}", breader.ReadInt16());//26

    Console.WriteLine("Глубина: {0}", breader.ReadInt16());//28

    Console.WriteLine("Тип сжатия: {0}", breader.ReadInt32());//30

    Console.WriteLine("Размер сжатого файла: {0}", breader.ReadInt32());//34

    Console.WriteLine("Горизонтальное разрешение: {0}", breader.ReadInt32());//38

    Console.WriteLine("Вертикальное разрешение: {0}", breader.ReadInt32());//42

    Console.WriteLine("Кол-во используемых цветов: {0}", breader.ReadInt32());//46

    Console.WriteLine("Кол-во важных цветов: {0}", breader.ReadInt32());//50

    Console.WriteLine("Палитра цветов: {0}", breader.ReadInt32());//54

}


Bitmap bmp = new Bitmap("img1.bmp");
Bitmap red = GetRed(bmp);
red.Save("red.bmp", ImageFormat.Bmp);
Bitmap green = GetGreen(bmp);
green.Save("green.bmp", ImageFormat.Bmp);
Bitmap blue = GetBlue(bmp);
blue.Save("blue.bmp", ImageFormat.Bmp);

List<Bitmap> cuts = cutImage(bmp);
int count = 1;
foreach(Bitmap c in cuts)
{
    c.Save("cut"+count+".bmp", ImageFormat.Bmp);
    count++;
}
