using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace WpfApp1.Service
{
    public class WorkWithData
    {
        private List<(int, string)> _questions;
        private int _countQuestion;
        private readonly bool _isTimeUse;

        public int NumberOfImage { get; private set; }

        public int CountQuestion
        {
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

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="isRandom">Использовать рандомный список вопросов при true</param>
        /// <param name="isTimeUse">Использовать время при true</param>
        public WorkWithData(bool isRandom ,bool isTimeUse)
        {
            _questions = new List<(int, string)>();
            ReadData();
            CountQuestion = 0;
            _isTimeUse = isTimeUse; 

            if (isRandom)
            {
                Shufle();
            }
        }

        public string GetQuestion()
        {
            NumberOfImage = _questions[_countQuestion - 1].Item1;
            return _questions[_countQuestion - 1].Item2;
        }

        //public int GetQuestion(string str)
        //{
        //    return _questions.IndexOf(str); 
        //}

        private void ReadData()
        {
            var data = new WorkWithPath();
            using var reader = new StreamReader(data.GetCurrentDirectoryPath("\\UserFiles\\Questions.txt"));

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                _questions.Add(ParseStr(line));
            }
        }

        private (int, string) ParseStr(string item)
        {
            var sym = ' ';
            string num = "";
            string quest;

            int index = item.IndexOf(sym);

            for (int i = 0; i < index; i++)
            {
                num += item[i];
            }

            quest = item;

            for (int i = 0; i < index; i++)
            {
                quest = quest.TrimStart(item[i]);
            }

            int ind = Convert.ToInt32(num.Trim());

            (int, string) res;
            res.Item1 = ind;
            res.Item2 = quest.Trim();

            return res;
        }

        private void Shufle()
        {
            Random  rand = new Random();

            for (int i = _questions.Count - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);

                var tmp = _questions[j];
                _questions[j] = _questions[i];
                _questions[i] = tmp;
            }

        }
    }
}
