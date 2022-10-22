using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SimpleTester
{
    class TestProvider
    {
        private const int testSize = 21;
        // словники міститимуть запитання тестів і коди правильних відповідей
        private static Dictionary<string, string[]> captions;
        private static Dictionary<string, string[]> codes;

        static TestProvider()
        {
            captions = new Dictionary<string, string[]>();
            codes = new Dictionary<string, string[]>();
        }
        public static string[] LoadTests(string testFile, string codeFile)
        {
            string line;
            string[] lines;
            List<string> Subjects = new List<string>();
            using (StreamReader sr = new StreamReader(testFile))
            {
                // поки є ключі у файлі, створюємо елементи словника
                while ((line = sr.ReadLine()) != null)
                {
                    Subjects.Add(line);
                    lines = new string[testSize];
                    for (int i = 0; i < testSize; ++i) lines[i] = sr.ReadLine();
                    captions[line] = lines;
                }
            }
            using (StreamReader sr = new StreamReader(codeFile))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    lines = new string[5];
                    for (int i = 0; i < 5; ++i) lines[i] = sr.ReadLine();
                    codes[line] = lines;
                }
            }
            return Subjects.ToArray();
        }

        public static void FillCaptions(string subject, GroupBox[] C)
        {
            string[] lines = captions[subject];
            fillRadioCaptions(C[0], lines, 0);
            fillRadioCaptions(C[1], lines, 5);
            fillCheckCaptions(C[2], lines, 10);
            fillCheckCaptions(C[3], lines, 15);
            fillTextCaptions(C[4], lines, 20);
        }

        public static string CheckUnswer(string subject, GroupBox[] C)
        {
            int point = 0;
            StringBuilder result = new StringBuilder(Environment.NewLine + subject);
            result.Append(" (");
            Func<GroupBox, string, int>[] Checkers = new Func<GroupBox, string, int>[]
            { radioAnswerChecker, radioAnswerChecker, checkAnswerChecker, checkAnswerChecker, textAnswerChecker };
            for (int i = 0; i < C.Length; ++i)
            {
                int q = Checkers[i](C[i], codes[subject][i]);
                point += q;
                result.AppendFormat(" {0}", q);
            }
            result.AppendFormat(" ) = {0}", point);
            return result.ToString();
        }

        // допоміжні методи для виведення запитання і варіантів відповідей
        // одного теста. метод також скидає раніше введені відповіді
        private static void fillRadioCaptions(GroupBox grBox, string[] names, int pos)
        {
            grBox.Text = names[pos];
            for (int i = 0; i < 4; ++i)
            {
                grBox.Controls[3 - i].Text = names[pos + i + 1];
                (grBox.Controls[i] as RadioButton).Checked = false;
            }
        }
        private static void fillCheckCaptions(GroupBox grBox, string[] names, int pos)
        {
            grBox.Text = names[pos];
            for (int i = 0; i < 4; ++i)
            {
                grBox.Controls[3 - i].Text = names[pos + i + 1];
                (grBox.Controls[i] as CheckBox).Checked = false;
            }
        }
        private static void fillTextCaptions(GroupBox grBox, string[] names, int pos)
        {
            grBox.Text = names[pos];
            (grBox.Controls[0] as TextBox).Clear();
        }

        // допоміжні методи фомують рядок відповіді за станом вибраних перемикачів,
        // порівнюють його з еталоном і нараховують бали
        private static int radioAnswerChecker(GroupBox grBox, string pattern)
        {
            string answer = String.Empty;
            for (int i = 0; i < 4; ++i)
                if ((grBox.Controls[i] as RadioButton).Checked)
                {
                    answer = (3 - i).ToString();
                }
            return (answer == pattern) ? 5 : 0;
        }
        private static int checkAnswerChecker(GroupBox grBox, string pattern)
        {
            string result = String.Empty;
            for (int i = 0; i < 4; ++i)
                if ((grBox.Controls[i] as CheckBox).Checked)
                {
                    result = (3 - i).ToString() + result;
                }
            if (result == pattern) return 10;
            else if (pattern.IndexOf(result) >= 0) return 5;
            else return 0;
        }
        private static int textAnswerChecker(GroupBox grBox, string pattern)
        {
            return (grBox.Controls[0] as TextBox).Text == pattern ? 20 : 0;
        }
    }
}
