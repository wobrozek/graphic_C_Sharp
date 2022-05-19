using System.Collections.Generic;

namespace quiz_projekt.model
{
    interface IDataAccess
    {
        void saveQuiz(List<Quiz> list);
        string Decrypt(string text);
        string Encrypt(string text);
        Quiz ReadJSON(string path);
    }
}