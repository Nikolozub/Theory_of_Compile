using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace Code_Analysis
{
    public class RegularExp
    {
        public static string typeCard(string number)
        {
            int type_number = number[0] - '0';
            switch (type_number)
            {
                case 2:
                    return "Мир";
                    break;
                case 3:
                    return "American Express, Maestro, JCB";
                    break;
                case 4:
                    return "Visa";
                    break;
                case 5:
                    return "MasterCard, Maestro";
                    break;
                case 6:
                    return "Maestro, Union Pay";
                    break;
                default:
                    return "Undefined";
            }
        }

        public static string printCards(string text, string type = "")
        {
            string[] lines = text.Split('\n');


            Regex regex = new Regex(@"\b[2-6]([0-9]{15}|[0-9]{3}-[0-9]{4}-[0-9]{4}-[0-9]{4}|[0-9]{3} [0-9]{4} [0-9]{4} [0-9]{4})\b");
            string outText = "";
            int n_line = 1;

            foreach (string line in lines) 
            {
                MatchCollection matches = regex.Matches(line);

                foreach (Match match in matches)
                {
                    outText += match.Value + " " + typeCard(match.Value) + " (Строка: " + n_line.ToString() + " Столбец: " +
                            match.Index.ToString() + ")\n";
                
                }
                n_line++;
            }

            return outText;
        }
    }
}
