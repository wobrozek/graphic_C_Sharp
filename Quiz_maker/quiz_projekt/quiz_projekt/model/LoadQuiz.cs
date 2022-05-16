using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using quiz_projekt.model;

namespace quiz_projekt.model
{
    class LoadQuiz
    {
        public static Quiz ReadJSON(string path)
        {
            string s = File.ReadAllText(@path);
            s = LoadQuiz.Decrypt(s);
            var Quiz = JsonSerializer.Deserialize<Quiz>(s);
            return Quiz;
        }


 

        public static string Decrypt(string text)
        {
            char[] txt = text.ToCharArray();
            for (int i = 0; i < txt.Length; i++)
            {
                if (txt[i] - 2 < 0)
                    txt[i] = (char)(txt[i] - 2 + 255);
                else
                    txt[i] = (char)(txt[i] - 2);
            }
            text = new string(txt);
            return text;
        }
    }
}
