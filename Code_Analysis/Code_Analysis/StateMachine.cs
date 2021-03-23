using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Analysis
{
    public class Substring
    {
        public int index;
        public int lenght;

        public Substring(int index, int lenght)
        {
            this.index = index;
            this.lenght = lenght;
        }
    }

    public static class StateMachine
    {
        /*
        */
        public static List<string> validChains(string chain, Func<string, string, string> transFunction, string startState, string endState)
        {
            List<string> validChains = new List<string>();
            string validChain = "";
            string state = startState;
            int i = 0;
            while (i < chain.Length) 
            {
                string _char = chain[i].ToString();
                string new_state = transFunction(state, _char);

                if (new_state != "ERROR")
                {
                    state = new_state;
                    validChain += _char;

                    if (new_state == endState)
                    {
                        validChains.Add(validChain);
                        validChain = "";
                        state = startState;
                    }

                    i++;
                }
                else 
                {
                    if (state == startState) 
                        i++;
                    state = startState;
                    validChain = "";
                }
            }

            return validChains;

        }

        /*Функция переходов*/
        public static string transFunction(string state, string _char)
        {
            if (state == "A1" && char.IsNumber(_char[0])) return "B1";
            if (state == "B1" && char.IsNumber(_char[0])) return "C1";
            if (state == "C1" && char.IsNumber(_char[0])) return "D1";
            if (state == "D1" && char.IsNumber(_char[0])) return "E1";

            /*Последовательность 12 цифр*/

            if (state == "E1" && char.IsNumber(_char[0])) return "A23";
            if (state == "A23" && char.IsNumber(_char[0])) return "B23";
            if (state == "B23" && char.IsNumber(_char[0])) return "C23";
            if (state == "C23" && char.IsNumber(_char[0])) return "D23";

            if (state == "D23" && char.IsNumber(_char[0])) return "A33";
            if (state == "A33" && char.IsNumber(_char[0])) return "B33";
            if (state == "B33" && char.IsNumber(_char[0])) return "C33";
            if (state == "C33" && char.IsNumber(_char[0])) return "D33";

            if (state == "D33" && char.IsNumber(_char[0])) return "A43";
            if (state == "A43" && char.IsNumber(_char[0])) return "B43";
            if (state == "B43" && char.IsNumber(_char[0])) return "C43";
            if (state == "C43" && char.IsNumber(_char[0])) return "K";

            /*Последовательность 12 цифр через дефис*/
            if (state == "E1" && (_char == "-")) return "A22";
            if (state == "A22" && char.IsNumber(_char[0])) return "B22";
            if (state == "B22" && char.IsNumber(_char[0])) return "C22";
            if (state == "C22" && char.IsNumber(_char[0])) return "D22";
            if (state == "D22" && char.IsNumber(_char[0])) return "E22";

            if (state == "E22" && (_char == "-")) return "A32";
            if (state == "A32" && char.IsNumber(_char[0])) return "B32";
            if (state == "B32" && char.IsNumber(_char[0])) return "C32";
            if (state == "C32" && char.IsNumber(_char[0])) return "D32";
            if (state == "D32" && char.IsNumber(_char[0])) return "E32";

            if (state == "E32" && (_char == "-")) return "A42";
            if (state == "A42" && char.IsNumber(_char[0])) return "B42";
            if (state == "B42" && char.IsNumber(_char[0])) return "C42";
            if (state == "C42" && char.IsNumber(_char[0])) return "D42";
            if (state == "D42" && char.IsNumber(_char[0])) return "K";

            /*Последовательность 12 цифр через пробел*/
            if (state == "E1" && (_char == " ")) return "A21";
            if (state == "A21" && char.IsNumber(_char[0])) return "B21";
            if (state == "B21" && char.IsNumber(_char[0])) return "C21";
            if (state == "C21" && char.IsNumber(_char[0])) return "D21";
            if (state == "D21" && char.IsNumber(_char[0])) return "E21";

            if (state == "E21" && (_char == " ")) return "A31";
            if (state == "A31" && char.IsNumber(_char[0])) return "B31";
            if (state == "B31" && char.IsNumber(_char[0])) return "C31";
            if (state == "C31" && char.IsNumber(_char[0])) return "D31";
            if (state == "D31" && char.IsNumber(_char[0])) return "E31";

            if (state == "E31" && (_char == " ")) return "A41";
            if (state == "A41" && char.IsNumber(_char[0])) return "B41";
            if (state == "B41" && char.IsNumber(_char[0])) return "C41";
            if (state == "C41" && char.IsNumber(_char[0])) return "D41";
            if (state == "D41" && char.IsNumber(_char[0])) return "K";


            return "ERROR";
        }

    }
}
