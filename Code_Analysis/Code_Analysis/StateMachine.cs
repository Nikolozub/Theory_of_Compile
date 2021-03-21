using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Analysis
{
    public static class StateMachine
    {
        /*Выполнение конечного автомата на цепочке символов chain.
          Если пришли в конечное состояние, то возвращает true,
          иначе возвращает false.
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
            if (state == "A" && _char == "a") return "B";
            if (state == "B" && _char == "b") return "C";
            if (state == "C" && _char == "c") return "D";
            return "ERROR";
        }

        /*Функция переходов*/
        public static string transFunction2(string state, string _char)
        {
            if (state == "A" && char.IsNumber(_char[0])) return "B";
            if (state == "B" && char.IsNumber(_char[0])) return "C";
            if (state == "C" && char.IsNumber(_char[0])) return "D";
            if (state == "D" && char.IsNumber(_char[0])) return "E";
            return "ERROR";
        }

    }
}
