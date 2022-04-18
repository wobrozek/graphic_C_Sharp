using System;
using System.Collections.Generic;
using System.Text;

namespace quiz.Model
{
    class Quiz
    {
        public string Name { get; set; }
        public List<object> Questions { get; set; }

        public Quiz()
        {
            Name = String.Empty;
            Questions= new List<object>();
        }
        public Quiz(string name)
        {
            Name = name;
        }

        public void Add(object qestion)
        {
            Questions.Add(qestion);
        }

        public void Delete(object qestion)
        {
            Questions.Remove(qestion);
        }
    }

    class Qestion
    {
        
        public string Name { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }

        public bool[] Correct { get; set; }

    public Qestion()
        {
            Name = string.Empty;
            Answer1 = string.Empty;
            Answer2 = string.Empty;
            Answer3 = string.Empty;
            Answer4 = string.Empty;
            Correct = new bool[4] { false, false, false, false };
        }
        public Qestion(string name, string answer1, string answer2, string answer3, string answer4, bool[] correct)
        {
            Name = name;
            Answer1 = answer1;
            Answer2 = answer2;
            Answer3 = answer3;
            Answer4 = answer4;
            Correct = correct;
        }          
        

    }
}
