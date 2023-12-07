using System.Text;
using System.Text.RegularExpressions;

namespace Application
{
    class MainApplication
    { 
        static void Main()
        {
            int total = 0;

            StreamReader streamReader = new StreamReader("inputs");

            string line = streamReader.ReadLine();

            while (line != null)
            {
                total += SumOfLine(line);
                line = streamReader.ReadLine();
            }

            Console.WriteLine(total);
        }

        private static int SumOfLine(string line)
        {
            string parsedText = ConvertNumberWords(line);

            Regex rx = new Regex(@"(\d)");

            MatchCollection matches = rx.Matches(parsedText);

            string firstNumber = matches[0].Value;
            string secondNumber = (matches.Count == 1) ? firstNumber : matches[matches.Count - 1].Value;

            return int.Parse(firstNumber + secondNumber);
        }

        private static string ConvertNumberWords(string text)
        {
            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
            List<KeyValuePair<int, string>> secondList = new List<KeyValuePair<int, string>>();

            list.Add(new KeyValuePair<string, string>("one", "1"));
            list.Add(new KeyValuePair<string, string>("two", "2"));
            list.Add(new KeyValuePair<string, string>("three", "3"));
            list.Add(new KeyValuePair<string, string>("four", "4"));
            list.Add(new KeyValuePair<string, string>("five", "5"));
            list.Add(new KeyValuePair<string, string>("six", "6"));
            list.Add(new KeyValuePair<string, string>("seven", "7"));
            list.Add(new KeyValuePair<string, string>("eight", "8"));
            list.Add(new KeyValuePair<string, string>("nine", "9"));

            foreach (KeyValuePair<string, string> item in list)
            {
                int indexOfString = text.IndexOf(item.Key);
                while (indexOfString != -1) {
                    secondList.Add(new KeyValuePair<int, string>(indexOfString, item.Value));
                    indexOfString = text.IndexOf(item.Key, indexOfString + 1);
                }
            }

            foreach (KeyValuePair<int, string> numWord in secondList)
            {
                StringBuilder stringBuilder = new StringBuilder(text);
                stringBuilder[numWord.Key] = numWord.Value.ToCharArray()[0];
                text = stringBuilder.ToString();
            }

            return text;
        }
    }
}