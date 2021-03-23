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

            MatchCollection matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                RowCol rc = ConvertPosition.IndexToRowCol(text, match.Index);
                outText += match.Value + " " + typeCard(match.Value) + " (Строка: " + rc.row.ToString() + " Столбец: " +
                rc.col.ToString() + ")\n";
            }

            return outText;
        }
    }
}
