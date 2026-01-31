using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using RGB_img.Models;

namespace RGB_img
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
   


    public partial class MainWindow : Window
    {

        const int Columns = 640;
        const int Rows = 360;
        const int CellSize = 1;
        ImageMatrix image;
        string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "kep.txt");
        //string path = "kep.txt";
        public MainWindow()
        {
            InitializeComponent();
            image = new ImageMatrix();
            image.LoadFromFile(path);
            DrawGrid();
        }


        private void DrawGrid()
        {
            MainCanvas.Width = Columns * CellSize;
            MainCanvas.Height = Rows * CellSize;

            for (int x = 0; x < Rows; x++)
            {
                for (int y = 0; y < Columns; y++)
                {
                    Pixel p = image.Pixels[x, y]; 

                    var rect = new Rectangle
                    {
                        Width = CellSize,
                        Height = CellSize,
                        Fill = new SolidColorBrush(
                            Color.FromArgb(p.R, p.G, p.B))

                    };

                    Canvas.SetLeft(rect, x * CellSize); 
                    Canvas.SetTop(rect, y * CellSize);

                    MainCanvas.Children.Add(rect);
                }
            }
        }

    }
}
