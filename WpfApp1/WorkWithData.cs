using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class WorkWithData
    {
        private List<string> _questions;
        private int _countQuestion;

        public int CountQuestion {
            get
            {
                return _countQuestion;
            } 
            set 
            {
                if (value < _questions.Count && value > 0)
                {
                    _countQuestion = value;
                }
                else if (value <= 0)
                {
                    _countQuestion = _questions.Count;
                }
                else if (value >= _questions.Count)
                {
                    _countQuestion = 1;
                }
            }
        }

        public WorkWithData()
        {
            _questions = new List<string>();
            ReadData();
            CountQuestion = 0;
        }

        public string GetQuestion()
        {
            return _questions[_countQuestion - 1];
        }

        public List<string> GetListQuestions()
        {
            return _questions;
        }

        private void ReadData()
        {
            using var reader = new StreamReader(GetCurrentDirectoryPath("\\UserFiles\\Questions.txt"));

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                _questions.Add(line);
            }
        }

        private string GetCurrentDirectoryPath(string item)
        {
            var path = Directory.GetCurrentDirectory();

            while (!File.Exists(path + item))
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
