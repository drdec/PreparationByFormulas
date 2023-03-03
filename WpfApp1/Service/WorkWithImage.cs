using System.Diagnostics.Contracts;
using System.IO;
using System.Windows.Media.Imaging;
using System;

namespace WpfApp1.Service
{
    public class WorkWithImage
    {
        private string _path;

        public WorkWithImage()
        {
            var data = new WorkWithPath();
            _path = data.GetCurrentDirectoryPath("\\UserFiles\\Image");
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
            catch (FileNotFoundException)
            {
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

       
    }
}
