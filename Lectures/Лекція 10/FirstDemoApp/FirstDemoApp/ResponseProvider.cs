using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemoApp
{
    class ResponseProvider
    {
        static string[] Answers = { "???",
            "Це неявка: одиницею позначають відсутність на іспиті",
            "Незадовільно - це, либонь, такий жарт",
            "Задовільно - не варто й починати: треба краще",
            "Вже добре, а можна й краще!",
            "Відмінно, але треба постаратися!!!" };
        public static string GetAnswer(int i)
        {
            return Answers[i];
        }
    }
}
