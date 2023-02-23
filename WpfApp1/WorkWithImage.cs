using System.Diagnostics.Contracts;
using System.IO;
using System.Windows.Media.Imaging;
using System;

namespace WpfApp1
{
    public class WorkWithImage
    {
        private string _path;

        public WorkWithImage()
        {
            _path = GetCurrentDirectoryPath("\\UserFiles\\Image");
        }

        public BitmapImage FindPhoto(int item)
        {
            BitmapImage image = new BitmapImage();

            try
            {
                var fileName = ReadPhoto(item);

                using (FileStream stream = File.OpenRead(fileName))
                {
                    image.BeginInit();
                    image.StreamSource = stream;
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.EndInit();
                }

                return image;
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private string ReadPhoto(int item)
        {
            var path = _path + "\\" + item + ".png";
            if (File.Exists(path))
            {
                return path;
            }
            else
            {
                throw new FileNotFoundException("Такого файла не существует");
            }
        }

        private string GetCurrentDirectoryPath(string item)
        {
            var path = Directory.GetCurrentDirectory();

            while (!Directory.Exists(path + item))
            {
                for (int i = path.Length - 1, j = 0; i >= 0; i--, j++)
                {
                    if (path[i] == '\\')
                    {
                        path = path.Remove(path.Length - j - 1);
                        break;
                    }
                }
            }

            path += item;

            return path;
        }
    }
}
