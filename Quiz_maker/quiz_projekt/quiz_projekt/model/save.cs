using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace quiz_projekt.model
{
    class save
    {
        public static void saveQuiz(List<Quiz> list)
        {
            foreach(Quiz q in list) {
                var str = JsonSerializer.Serialize(q);
                str = save.Encrypt(str);
                var path = "../../zapisane/"+q.Name+"dane.quiz";
                File.WriteAllText(path, str);
            }
        }

        public static string Encrypt(string text)
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

    }
}
