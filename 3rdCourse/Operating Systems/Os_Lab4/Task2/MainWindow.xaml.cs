using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Task2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            Window window = new Window();
            window.MouseDown += draw;
            window.Show();
            InitializeComponent();


        }

        private void draw(object sender, MouseButtonEventArgs e)
        {
            List<SolidColorBrush> list = new()
            {
                new SolidColorBrush(Colors.Red),
                new SolidColorBrush(Colors.Green),
                new SolidColorBrush(Colors.Blue),
                new SolidColorBrush(Colors.Yellow),
                new SolidColorBrush(Colors.Orange),
                new SolidColorBrush(Colors.Pink),
                new SolidColorBrush(Colors.Black),
            };

            Random rnd = new Random();
           
            int value;
            int x = -30;
            int y = -30;
         
            for (int i = 0; i < 10; i++)
            {
                y += 70;
                x = 0;
                for (int j = 0; j < 10; j++)
                {
                    x += 70;

                    switch (rnd.Next(0, 3))
                    {
                        case 0:
                            value = rnd.Next(0, list.Count - 1);
                            Rectangle rect = new Rectangle();
                            rect.Height = 30;
                            rect.Width = 30;
                            rect.Stroke = list[value];
                            rect.Margin = new Thickness(x, y, 0, 0);
                            rect.HorizontalAlignment = HorizontalAlignment.Left;
                            rect.VerticalAlignment = VerticalAlignment.Top;
                            Grid.Children.Add(rect);
                            break;
                        case 1:
                            value = rnd.Next(0, list.Count - 1);
                            Ellipse ellipse=new Ellipse();
                         
                            ellipse.Width = 30;
                            ellipse.Height = 30;
                            ellipse.Stroke = list[value];
                            ellipse.HorizontalAlignment = HorizontalAlignment.Left;
                            ellipse.VerticalAlignment = VerticalAlignment.Top;
                            ellipse.Margin=new Thickness(x, y, 0, 0);
                            Grid.Children.Add(ellipse);
                            break;
                        case 2:
                            value = rnd.Next(0, list.Count - 1);
                            Polygon triangle = new Polygon();
                      
                            triangle.Stroke = list[value];
                            triangle.HorizontalAlignment = HorizontalAlignment.Left;
                            triangle.VerticalAlignment = VerticalAlignment.Top;
                            triangle.Points.Add(new Point(x + 15, y));
                            triangle.Points.Add(new Point(x, y + 30));
                            triangle.Points.Add(new Point(x + 30, y+30));
                           
                            Grid.Children.Add(triangle);
                            break;
                    }
                

                }
               
            }

        }

    
     

     
    }

   
}


