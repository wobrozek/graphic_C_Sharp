using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System.Text.Json.Serialization;

public class Answer
{
    [JsonInclude]
    public string Content { get; set; }
    [JsonInclude]
    public bool Correct { get; set; }

    [JsonConstructor]
    public Answer()
    {

    }
    public Answer(String content, bool correct)
    {
        Content = content;
        Correct = correct;
    }

    public Answer(Answer a)
    {
        Content = a.Content;
        Correct = a.Correct;
    }

}



public class Question
{
    [JsonInclude]
    public string Content { get; set; }
    [JsonInclude]
    public List<Answer> Answers { get; set; }

    [JsonConstructor]
    public Question()
    {
        
    }

    
    public Question(string name, List<Answer> lista)
    {
        Content = name;
        Answers = lista;
    }
    
  

    public Question(Question q)
    {
        Content = q.Content;
        Answers = q.Answers;
    }

    public override string ToString()
    {
        string p = $"{Content}";
        return p;
    }
}





public class Quiz
{
    [JsonInclude]
    public string Name { get; set; }
    [JsonInclude]
    public List<Question> Questions { get; set; }

    
    public Quiz(string name, List<Question> list) /*=> (Name, Qestions) = (name, new List<Question>() list);*/
    {
        Name = name;
        Questions = list;
    }
  
    [JsonConstructor]
    public Quiz()
    {
       
    }
    public Quiz(string name)
    {
        Name = name;
        Questions = new List<Question>();
    }
    public Quiz(Quiz q)
    {
        Name = q.Name;
        Questions = q.Questions;
    }



    public void Add(Question q)
    {
        Questions.Add(q);
    }

    public void Delete(Question q)
    {
        Questions.Remove(q);
    }
    public override string ToString()
    {
        string p = $"{Name}";
        return p;
    }
}







//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace quiz_projekt.model
//{
//    class Quiz
//    {
//        public string Name { get; set; }
//        public List<Question> Pytania = new List<Question>();

//        public Quiz()
//        {
//            Name = String.Empty;
//            Pytania = new List<Question>();
//        }
//        public Quiz(string name)
//        {
//            Name = name;
//        } 
//        public Quiz(Quiz q)
//        {
//            Name = q.Name;
//            Pytania = q.Pytania;
//        }

//        public void Add(Question q)
//        {
//            Pytania.Add(q);
//        }

//        public void Delete(Question q)
//        {
//            Pytania.Remove(q);
//        }
//        public override string ToString()
//        {
//            string p = $"{Name}";
//            return p;
//        }
//    }

//    class Question
//    {

//        public string Name { get; set; }
//        public string Answer1 { get; set; }
//        public string Answer2 { get; set; }
//        public string Answer3 { get; set; }
//        public string Answer4 { get; set; }

//        public bool[] Correct { get; set; }

//        public Question()
//        {
//            Name = string.Empty;
//            Answer1 = string.Empty;
//            Answer2 = string.Empty;
//            Answer3 = string.Empty;
//            Answer4 = string.Empty;
//            Correct = new bool[4] { false, false, false, false };
//        }
//        public Question(string name, string answer1, string answer2, string answer3, string answer4, bool[] correct)
//        {
//            Name = name;
//            Answer1 = answer1;
//            Answer2 = answer2;
//            Answer3 = answer3;
//            Answer4 = answer4;
//            Correct = correct;
//        }

//        public Question(Question q)
//        {
//            Name = q.Name;
//            Answer1 = q.Answer1;
//            Answer2 = q.Answer2;
//            Answer3 = q.Answer3;
//            Answer4 = q.Answer4;
//            Correct = q.Correct;
//        }

//        public override string ToString()
//        {
//            string p = $"{Name}";
//            return p;
//        }


//    }
//}






