using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;
using System.Collections.Generic;

namespace VectorGraphicEditor
{
    public partial class MainWindow : Window
    {
        private int cnt;//счетчики линий
        private int freeCnt;
        private int maxLines;
        private int point_index;//1 точка прямой линии;
        private string mode;
        private double x1, y1;//координаты для рисования карандашом
        private Pen[] pen;
        private List<List<Polyline>> freeLines;
        private Line line_cur;//текущая линия(для реализации редактирования)
        private Point currentPoint;//точка,в которую мы кликнули
        private Point startPoint;//нач.точка для прямоугольника, окружности и треугольника
        private Rectangle rectangle;
        private Ellipse circle;
        private Polygon triangle;
        public MainWindow()
        {
            maxLines = 100;
            freeLines = new();
            for (int i = 0; i < maxLines; i++) freeLines.Add(new());
            freeCnt = -1;
            point_index = 0;
            line_cur = null;
            mode = "line";
            currentPoint = new Point();
            cnt = 0;
            x1 = y1 = 0;     
      
            InitializeComponent();
            pen = new Pen[maxLines];
            for (int i = 0; i < maxLines; i++)
                pen[i] = new Pen(SystemColors.WindowFrameBrush, 2f);
            paintSurface.Background = new SolidColorBrush(Colors.White);
        }
        private void paintSurface_MouseUp(object sender, MouseButtonEventArgs e)
        {
            circle = null;
            triangle = null;
            rectangle = null;
            if (mode != "pen") cnt++;
            else freeCnt++;
        }
        private void paintSurface_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (mode == "pen")          
            {
                x1 = e.GetPosition(paintSurface).X; //записываем текущие координаты
                y1 = e.GetPosition(paintSurface).Y;
            }
            else if (mode == "line")
            {
                double marker_x = -1, marker_y = -1;//координаты,где будет рисоваться квадрат

                if (e.LeftButton == MouseButtonState.Pressed) currentPoint = e.GetPosition(paintSurface);
                Line line;
                foreach (Line line1 in paintSurface.Children.OfType<Line>())//проходим по всем линиям канваса
                {
                    line = line1;
                    if (Math.Abs(line.X1 - e.GetPosition(paintSurface).X) < 5 && Math.Abs(e.GetPosition(paintSurface).Y - line.Y1) < 5)
                    {
                        point_index = 0;//редактируем точку 0
                        marker_x = line.X1;//задаем координаты маркера
                        marker_y = line.Y1;
                        line_cur = line;//запоминаем линию
                    }
                    else if (Math.Abs(line.X2 - e.GetPosition(paintSurface).X) < 5 && Math.Abs(e.GetPosition(paintSurface).Y - line.Y2) < 5)
                    {
                        point_index = 1;//редактируем точку 1
                        marker_x = line.X2;
                        marker_y = line.Y2;
                        line_cur = line;
                    }
                }
            }
            else if (mode == "rectangle")
            {
                startPoint = e.GetPosition(paintSurface);

                rectangle = new Rectangle
                {
                    Stroke = pen[cnt].Brush,
                    StrokeThickness = pen[cnt].Thickness

                };
                Canvas.SetLeft(rectangle, startPoint.X);
                Canvas.SetTop(rectangle, startPoint.Y);
                paintSurface.Children.Add(rectangle);
            }
            else if (mode == "circle")
            {

                startPoint = e.GetPosition(paintSurface);

                circle = new Ellipse
                {
                    Stroke = pen[cnt].Brush,
                    StrokeThickness = pen[cnt].Thickness
                };
                Canvas.SetLeft(circle, startPoint.X);
                Canvas.SetTop(circle, startPoint.Y);
                paintSurface.Children.Add(circle);
            }
            else if (mode == "triangle")
            {
                startPoint = e.GetPosition(paintSurface);

                triangle = new Polygon
                {
                    Stroke = pen[cnt].Brush,
                    StrokeThickness = pen[cnt].Thickness
                };

                triangle.Points.Add(startPoint);
                triangle.Points.Add(startPoint);
                triangle.Points.Add(startPoint);
                paintSurface.Children.Add(triangle);
            }
            else if (mode == "fill")
            {
                foreach (Rectangle rec in paintSurface.Children.OfType<Rectangle>())
                    if ((e.GetPosition(paintSurface).X > Canvas.GetLeft(rec) && e.GetPosition(paintSurface).X < Canvas.GetLeft(rec) + rec.Width)
                        && (e.GetPosition(paintSurface).Y < Canvas.GetTop(rec) + rec.Height && e.GetPosition(paintSurface).Y > Canvas.GetTop(rec)))
                        rec.Fill = pen[cnt].Brush;
                foreach (Ellipse elp in paintSurface.Children.OfType<Ellipse>())
                {
                    if ((e.GetPosition(paintSurface).X > Canvas.GetLeft(elp) && e.GetPosition(paintSurface).X < Canvas.GetLeft(elp) + elp.Width)
                        && (e.GetPosition(paintSurface).Y < Canvas.GetTop(elp) + elp.Height && e.GetPosition(paintSurface).Y > Canvas.GetTop(elp)))
                        elp.Fill = pen[cnt].Brush;
                }
                foreach (Polygon pol in paintSurface.Children.OfType<Polygon>())
                {
                    double a = (pol.Points[0].X - e.GetPosition(paintSurface).X) * (pol.Points[1].Y - pol.Points[0].Y) -
                        (pol.Points[1].X - pol.Points[0].X) * (pol.Points[0].Y - e.GetPosition(paintSurface).Y);
                    double b = (pol.Points[1].X - e.GetPosition(paintSurface).X) * (pol.Points[2].Y - pol.Points[1].Y) -
                        (pol.Points[2].X - pol.Points[1].X) * (pol.Points[1].Y - e.GetPosition(paintSurface).Y);
                    double c = (pol.Points[2].X - e.GetPosition(paintSurface).X) * (pol.Points[0].Y - pol.Points[2].Y) -
                        (pol.Points[0].X - pol.Points[2].X) * (pol.Points[2].Y - e.GetPosition(paintSurface).Y);

                    if ((a >= 0 && b >= 0 && c >= 0) || (a <= 0 && b <= 0 && c <= 0)) pol.Fill = pen[cnt].Brush;
                }
            }
        }
        private void paintSurface_MouseMove(object sender, MouseEventArgs e)
        {
            double marker_x = -1, marker_y = -1;
            if (e.LeftButton == MouseButtonState.Pressed)//если нажата ЛКМ
            {
                Line line = null;
                if (line_cur != null)//если текущая линия не нулевая
                {
                    //определяем,какой край линии мы редактируем
                    if (point_index == 0)
                    {
                        line_cur.X1 = e.GetPosition(paintSurface).X;//меняем координаты на текущие
                        line_cur.Y1 = e.GetPosition(paintSurface).Y;
                        marker_x = line_cur.X1;//исправляем координаты маркера
                        marker_y = line_cur.Y1;
                        Console.WriteLine("Правлю точку 0");
                    }
                    else
                    {
                        line_cur.X2 = e.GetPosition(paintSurface).X;
                        line_cur.Y2 = e.GetPosition(paintSurface).Y;
                        marker_x = line_cur.X2;
                        marker_y = line_cur.Y2;
                        Console.WriteLine("Правлю точку 1");
                    }
                    for (int i = 0; i < 10; i++)//удаляем ненужные прямоугольники
                        foreach (Rectangle rect1 in paintSurface.Children.OfType<Rectangle>())
                        {
                            if (rect1.Width == 10 && rect1.Height == 10)
                            {
                                paintSurface.Children.Remove(rect1);
                                break;
                            }
                        }
                    //добавляем новый прямоугольник
                    Rectangle rect = new Rectangle();
                    rect.Stroke = new SolidColorBrush(Colors.Red);
                    rect.Fill = new SolidColorBrush(Colors.Transparent);
                    rect.Width = 10;
                    rect.Height = 10;
                    Canvas.SetLeft(rect, marker_x - 5); //смещаем на 5,чтобы треугольник был в центре конца линии
                    Canvas.SetTop(rect, marker_y - 5);
                    paintSurface.Children.Add(rect);//добавляем в канвас
                    return;
                }
                else  //нет текущей линии
                {
                    //растягиваем линии.
                    foreach (Line line1 in paintSurface.Children.OfType<Line>())
                    {
                        line = line1;

                        if (line.Name == "line_" + cnt) break; //если есть cnt линия,то прерываемся и записываем в Line,какую линию мы редактируем
                        else line = null;//если нет линии
                    }
                }
                if (line_cur == null) //если мы не в режиме редактирования
                {
                    if (line == null)//если новая линия тоже null
                    {
                        if (mode == "line")
                        {
                            //создаем линию
                            line = new Line();
                            line.Stroke = SystemColors.WindowFrameBrush;
                            line.X1 = currentPoint.X;//координаты где произошел клик ЛКМ
                            line.Y1 = currentPoint.Y;
                            line.X2 = e.GetPosition(paintSurface).X;//текущие координаты мыши
                            line.Y2 = e.GetPosition(paintSurface).Y;

                            currentPoint = e.GetPosition(paintSurface);
                            line.Name = "line_" + cnt;//создаем линию с именем line_cnt

                            line.Stroke = pen[cnt].Brush; //берем цвет из текущего карандаша
                            line.StrokeThickness = pen[cnt].Thickness;//берем толщину из текущего карандаша

                            paintSurface.Children.Add(line);
                        }
                        else if (mode == "pen")//если режим карандаша включен
                        {
                            if (e.LeftButton == MouseButtonState.Pressed)
                            {
                                //создаем линию,координатами которой является предыдущая точка и текущие координаты мыши
                                Polyline line_ = new Polyline();
                                line_.Points.Add(new Point(e.GetPosition(paintSurface).X, e.GetPosition(paintSurface).Y));
                                line_.Points.Add(new Point(x1, y1));
                                line_.StrokeThickness = pen[cnt].Thickness;
                                line_.Stroke = pen[cnt].Brush;

                                paintSurface.Children.Add(line_);
                                freeLines[freeCnt+1].Add(line_);

                                x1 = e.GetPosition(paintSurface).X;//запоминаем текущую точку,теперь она стала "предыдущей"
                                y1 = e.GetPosition(paintSurface).Y;
                            }
                        }
                        else if (mode == "rectangle")
                        {
                            if (e.LeftButton == MouseButtonState.Released || rectangle == null) return; //если мышка отжата или прямоугольника нет

                            var pos = e.GetPosition(paintSurface); //запоминаем текущую позицию мыши

                            var x = Math.Min(pos.X, startPoint.X); //математические формулы для определения положения фигуры
                            var y = Math.Min(pos.Y, startPoint.Y);

                            var w = Math.Max(pos.X, startPoint.X) - x;
                            var h = Math.Max(pos.Y, startPoint.Y) - y;

                            rectangle.Width = w;
                            rectangle.Height = h;

                            Canvas.SetLeft(rectangle, x);//устанавливаем левую границу
                            Canvas.SetTop(rectangle, y); // устанавливаем верхнюю границу
                        }
                        else if (mode == "circle")
                        {
                            if (e.LeftButton == MouseButtonState.Released || circle == null) return;

                            var pos = e.GetPosition(paintSurface); //запоминаем текущую позицию мыши

                            var x = Math.Min(pos.X, startPoint.X); //математические формулы для определения положения фигуры
                            var y = Math.Min(pos.Y, startPoint.Y);

                            var w = Math.Max(pos.X, startPoint.X) - x;
                            var h = Math.Max(pos.Y, startPoint.Y) - y;

                            circle.Width = w;
                            circle.Height = h;

                            Canvas.SetLeft(circle, x); //устанавливаем левую границу
                            Canvas.SetTop(circle, y); // устанавливаем верхнюю границу
                        }
                        else if (mode == "triangle")
                        {
                            if (e.LeftButton == MouseButtonState.Released || triangle == null) return;

                            var pos = e.GetPosition(paintSurface); //запоминаем текущую позицию мыши

                            var x = Math.Min(pos.X, startPoint.X); //математические формулы для определения положения фигуры
                            var y = Math.Min(pos.Y, startPoint.Y);

                            var w = Math.Max(pos.X, startPoint.X) - x;
                            var h = Math.Max(pos.Y, startPoint.Y) - y;

                            if (e.GetPosition(paintSurface).Y > startPoint.Y)
                            {
                                triangle.Points[1] = new Point(startPoint.X - w, startPoint.Y + h);
                                triangle.Points[2] = new Point(startPoint.X + w, startPoint.Y + h);
                            }
                            else
                            {
                                triangle.Points[1] = new Point(startPoint.X - w, startPoint.Y - h);
                                triangle.Points[2] = new Point(startPoint.X + w, startPoint.Y - h);
                            }
                        }
                    }
                    else //если мы в режиме редактирования,изменяем координаты конца линии
                    {
                        line.X2 = e.GetPosition(paintSurface).X;
                        line.Y2 = e.GetPosition(paintSurface).Y;
                        paintSurface.InvalidateVisual();//обновляем прорисовку канваса
                    }
                }
            }
            else //если ЛКМ не нажата
            {
                Line line = null;
                foreach (Line line1 in paintSurface.Children.OfType<Line>())
                {
                    //проходимся по линиям канваса и определяем,находимся ли мы у края линии
                    line = line1;
                    if ((Math.Abs(line.X1 - e.GetPosition(paintSurface).X) < 5) && (Math.Abs(e.GetPosition(paintSurface).Y - line.Y1) < 5))
                    {
                        point_index = 0;
                        marker_x = line.X1;
                        marker_y = line.Y1;
                        line_cur = line;
                    }
                    else if (Math.Abs(line.X2 - e.GetPosition(paintSurface).X) < 5 && (Math.Abs(e.GetPosition(paintSurface).Y - line.Y2) < 5))
                    {
                        point_index = 1;
                        marker_x = line.X2;
                        marker_y = line.Y2;
                        line_cur = line;
                    }
                }
            }
            if (marker_x != -1)//если мы нашли линию и курсор попадает в область, рисуем прямуогольник
            {
                Rectangle rect= new Rectangle();
                rect.Stroke = new SolidColorBrush(Colors.Red);
                rect.Fill = new SolidColorBrush(Colors.Transparent);
                rect.Width = 10;
                rect.Height = 10;
                Canvas.SetLeft(rect, marker_x - 5);
                Canvas.SetTop(rect, marker_y - 5);
                paintSurface.Children.Add(rect);
            }
            else // если маркер не найден и кнопка мыши не нажата,то удаляем старый маркер
            {
                foreach (Rectangle rect in paintSurface.Children.OfType<Rectangle>())
                {
                    if (rect.Width == 10 && rect.Height == 10)
                    {
                        paintSurface.Children.Remove(rect);
                        line_cur = null;
                        paintSurface.InvalidateVisual();
                        break;
                    }
                }
            }
        }
        private void Color_Click(object sender, RoutedEventArgs e)
        {
            if (mode != "erase")
                for (int i = cnt; i < maxLines; i++)
                    pen[i].Brush = ((Button)sender).Background;
        }
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            for (int i = cnt; i < maxLines; i++)
                pen[i].Thickness = slider.Value;
        }
        private void NewFile(object sender, RoutedEventArgs e)
        {
            paintSurface.Background = new SolidColorBrush(Colors.White);
            paintSurface.Children.Clear();
        }
        private void OpenFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dl1 = new OpenFileDialog();
            dl1.FileName = "MYFileSave";
            dl1.DefaultExt = ".png";
            dl1.Filter = "Image documents (.png)|*.png";
            bool? result = dl1.ShowDialog();

            if (result == true)
            {
                string filename = dl1.FileName;
                ImageBrush brush = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri(@filename, UriKind.Relative));
                paintSurface.Background = brush;
            }
        }
        public static void ToImageSource(Canvas canvas, string filename, int actualWidth, int actualHeight)
        {
            RenderTargetBitmap bmp = new RenderTargetBitmap(actualWidth, actualHeight , 96d, 96d, PixelFormats.Pbgra32);
            canvas.Measure(new Size(actualWidth, actualHeight));
            canvas.Arrange(new Rect(new Size(actualWidth, actualHeight)));
            bmp.Render(canvas);
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bmp));

            using (FileStream file = File.Create(filename))
            {
                encoder.Save(file);
            }
        }
        private void SaveFile()
        {
            SaveFileDialog saveimg = new SaveFileDialog();
            saveimg.DefaultExt = ".PNG";
            saveimg.Filter = "Image (.PNG)|*.PNG";
            if (saveimg.ShowDialog() == true)
                ToImageSource(paintSurface, saveimg.FileName, (int)paintSurface.ActualWidth, (int)paintSurface.ActualHeight + 100);
        }
        private void SaveFile(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveimg = new SaveFileDialog();
            saveimg.DefaultExt = ".PNG";
            saveimg.Filter = "Image (.PNG)|*.PNG";
            if (saveimg.ShowDialog() == true)
                ToImageSource(paintSurface, saveimg.FileName, (int)paintSurface.ActualWidth, (int)paintSurface.ActualHeight + 100);
        }
        private void Exit(object sender, RoutedEventArgs e)
        {
            string messageBoxText = "Хотите сохранить изменения?";
            string caption = "VectorGraphicEditor";
            MessageBoxButton button = MessageBoxButton.YesNoCancel;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    SaveFile();
                    Close();
                    break;
                case MessageBoxResult.No:
                    Close();
                    break;
                case MessageBoxResult.Cancel:
                    break;
            }
        }
        private void AboutProgram_Click(object sender, RoutedEventArgs e)
        {
            string messageBoxText = "VectorGraphicEditor version 1.0\n(c) Maxim Lapardin 2023\nEmail: makleo2002@gmail.com";
            string caption = "О программе";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Information;
            MessageBox.Show(messageBoxText, caption, button, icon);
        }
        private void Line_Click(object sender, RoutedEventArgs e)
        {
            if (mode == "pen")
                for (int i = cnt; i < maxLines; i++)
                    pen[i].Brush = SystemColors.WindowFrameBrush;
            mode = "line";
        }
        private void Circle_Click(object sender, RoutedEventArgs e)
        {
            if (mode == "pen")
                for (int i = cnt; i < maxLines; i++)
                    pen[i].Brush = SystemColors.WindowFrameBrush;
            mode = "circle";
        }
        private void Rectangle_Click(object sender, RoutedEventArgs e)
        {
            if (mode == "pen")
                for (int i = cnt; i < maxLines; i++)
                    pen[i].Brush = SystemColors.WindowFrameBrush;
            mode = "rectangle";
        }
        private void Triangle_Click(object sender, RoutedEventArgs e)
        {
            if (mode == "pen")
                for (int i = cnt; i < maxLines; i++)
                    pen[i].Brush = SystemColors.WindowFrameBrush;
            mode = "triangle";
        }
        private void Bucket_Click(object sender, RoutedEventArgs e)
        {
            mode = "fill";
        }
        private void Eraser_Click(object sender, RoutedEventArgs e)
        {
            mode = "pen";
            for (int i = cnt; i < maxLines; i++)
            {
                pen[i].Brush = new SolidColorBrush(Colors.White);
                pen[i].Thickness = 3f;
            }
        }
        private void Pencil_Click(object sender, RoutedEventArgs e)
        {
            if(mode=="pen")
                for (int i = cnt; i < maxLines; i++)
                    pen[i].Brush =SystemColors.WindowFrameBrush;
            mode = "pen";
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            paintSurface.Children.Clear();
        }
        private void Undo_Click(object sender, RoutedEventArgs e)
        {
            int count = paintSurface.Children.Count;
            try
            {
                if (paintSurface.Children[count - 1] is Polyline)
                {
                    foreach (var freeLine in freeLines[freeCnt])
                        paintSurface.Children.Remove(freeLine);
                    freeLines[freeCnt].Clear();

                    if (freeCnt > 0) freeCnt--; 
                }
                else paintSurface.Children.RemoveAt(count - 1);
            }
            catch { }
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            string messageBoxText = "Хотите сохранить изменения?";
            string caption = "VectorGraphicEdtor";
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    SaveFile();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
    }
}
