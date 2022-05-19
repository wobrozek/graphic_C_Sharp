using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace quiz_projekt.model
{
    class DataAccess : IDataAccess
    {
        
        public void saveQuiz(List<Quiz> list)
        {
            foreach (Quiz q in list)
            {
                var str = JsonSerializer.Serialize(q);
                str = this.Encrypt(str);
                var path = "../../zapisane/" + q.Name + "dane.quiz";
                File.WriteAllText(path, str);
            }
        }

        public string Encrypt(string text)
        {
            char[] txt = text.ToCharArray();
            for (int i = 0; i < txt.Length; i++)
            {
                if (txt[i] + 2 > 255)
                    txt[i] = (char)(txt[i] + 2 - 255);
                else
                    txt[i] = (char)(txt[i] + 2);
            }
            text = new string(txt);
            return text;
        }

        public Quiz ReadJSON(string path)
        {
            string s = File.ReadAllText(@path);
            s = this.Decrypt(s);
            var Quiz = JsonSerializer.Deserialize<Quiz>(s);
            return Quiz;
        }

        public string Decrypt(string text)
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
