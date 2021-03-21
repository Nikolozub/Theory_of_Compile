//Rextester.Program.Main is the entry point for your code. Don't change it.
//Microsoft (R) Visual C# Compiler version 2.9.0.63208 (958f2354)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rextester
{
    /* состояния конечного автомата */
    public static class S
    {
        public const int A1 = 0;
        public const int B1 = 1;
        public const int C1 = 2;
        public const int D1 = 3;
        public const int E1 = 4;
        
        public const int A21 = 5;
        public const int B21 = 6;
        public const int C21 = 7;
        public const int D21 = 8;
        public const int E21 = 9;
        public const int A31 = 10;
        public const int B31 = 11;        
        public const int C31 = 12;
        public const int D31 = 13;
        public const int E31 = 14;
        public const int A41 = 15;
        public const int B41 = 16;
        public const int C41 = 17;        
        public const int D41 = 18;
        
        public const int A22 = 19;
        public const int B22 = 20;
        public const int C22 = 21;
        public const int D22 = 22;
        public const int E22 = 23;
        public const int A32 = 24;
        public const int B32 = 25;        
        public const int C32 = 26;
        public const int D32 = 27;
        public const int E32 = 28;
        public const int A42 = 29;
        public const int B42 = 30;
        public const int C42 = 31;        
        public const int D42 = 32;    
        
        public const int A23 = 33;
        public const int B23 = 32;
        public const int C23 = 33;
        public const int D23 = 34;
        public const int A33 = 35;
        public const int B33 = 36;        
        public const int C33 = 37;
        public const int D33 = 38;
        public const int A43 = 39;
        public const int B43 = 40;
        public const int C43 = 41;
        public const int K = 42;
        public const int Err = 43;
    }
      
    

    
    public class Program
    {
        
        
    public static  S[,] table = { {S.Err, S.Err, S.B1,  S.B1,  S.B1,  S.B1,  S.B1,  S.Err, S.Err, S.Err, S.Err, S.Err}, 
                   {S.C1,  S.C1,  S.C1,  S.C1,  S.C1,  S.C1,  S.C1,  S.C1,  S.C1,  S.C1,  S.Err, S.Err},
                   {S.D1,  S.D1,  S.D1,  S.D1,  S.D1,  S.D1,  S.D1,  S.D1,  S.D1,  S.D1,  S.Err, S.Err},
                   {S.E1,  S.E1,  S.E1,  S.E1,  S.E1,  S.E1,  S.E1,  S.E1,  S.E1,  S.E1,  S.Err, S.Err},
                   {S.A23, S.A23, S.A23, S.A23, S.A23, S.A23, S.A23, S.A23, S.A23, S.A23, S.A21, S.A22},
                   {S.B21, S.B21, S.B21, S.B21, S.B21, S.B21, S.B21, S.B21, S.B21, S.B21, S.Err, S.Err},
                   {S.C21, S.C21, S.C21, S.C21, S.C21, S.C21, S.C21, S.C21, S.C21, S.C21, S.Err, S.Err},
                   {S.D21, S.D21, S.D21, S.D21, S.D21, S.D21, S.D21, S.D21, S.D21, S.D21, S.Err, S.Err},
                   {S.E21, S.E21, S.E21, S.E21, S.E21, S.E21, S.E21, S.E21, S.E21, S.E21, S.Err, S.Err},
                   {S.Err, S.Err, S.Err, S.Err, S.Err, S.Err, S.Err, S.Err, S.Err, S.Err, S.A31, S.Err}
                 }; 
        
        public static bool validChain(string chain, Func<string, string, string> transFunction, string startState, string endState)
        {
            string state = startState;
            int i = 0;
            int lenght = chain.Length;
            
            while (state != endState)
            {
                if (i >= lenght) return false;
                string new_state = transFunction(state, chain[i++].ToString());
                if (new_state == state) return false;
                state = new_state;
            }
            return true;
        }
        
        public static string transFunction(string state, string _char)
        {
            if (state == "A1" && _char == "a") return "B";
            if (state == "B" && _char == "b") return "C";
            if (state == "C" && _char == "c") return "D";
            return state;
        }
        
        public static void Main(string[] args)
        {
            //Console.WriteLine(validChain("ab", transFunction, "A", "D"));
            Console.WriteLine(S.A33);
        }
    }
}




