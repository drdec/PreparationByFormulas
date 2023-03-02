using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WpfApp1.Service
{
    public class WorkWithPath
    {
        public string GetCurrentDirectoryPath(string item)
        {
            var cz = 0;
            var path = Directory.GetCurrentDirectory();

            var tempPathRes = path + item;

            while (!File.Exists(path + item) && !Directory.Exists(path + item))
            {
                cz++;

                for (int i = path.Length - 1, j = 0; i >= 0; i--, j++)
                {
                    if (path[i] == '\\')
                    {
                        path = path.Remove(path.Length - j - 1);
                        tempPathRes = path + item;
                        break;
                    }
                    if (cz > 25)
                    {
                        throw new FileNotFoundException("Не найдена папка UserFiles, проверьте целостность или наличие файла");
                    }


                }
            }

            path += item;

            return path;
        }
    }

}
