using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RGB_img.Models
{
    internal class ImageMatrix
    {
        public const int Width = 640;
        public const int Height = 360;

        // [sor, oszlop]
        public Pixel[,] Pixels { get; private set; }

        public ImageMatrix()
        {
            Pixels = new Pixel[Height, Width];
        }

        public void LoadFromFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            if (lines.Length != Height) 
                throw new Exception("Hibás sorszám a fájlban.");

            for (int y = 0; y < Height; y++)
            {
                string[] values = lines[y].Split(';'); 

                if (values.Length != Width * 3)
                    throw new Exception($"Hibás adatszám a(z) {y}. sorban.");

                int index = 0;
                for (int x = 0; x < Width; x++)
                {
                    byte r = byte.Parse(values[index]);
                    byte g = byte.Parse(values[index]);
                    byte b = byte.Parse(values[index]);

                    Pixels[y, x] = new Pixel(r, g, b);
                }
            }
        }
    }
}
