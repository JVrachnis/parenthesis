using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parenthesis
{
    class Program
    {
        static bool PrintData;
        static string parenthesisString ="";
        static string stack = "";
        static void Main(string[] args)
        {
            parseArgs(args);
            if (PrintData)
            {
                Console.WriteLine("{0} | {1} || {2} ||| {3}", "step", "stack", "parenthesis", "Length of stack");
            }
            if (NAS(getParenthesisFromString(parenthesisString), ref stack, 1)&&(stack.Length == 0))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
            Console.ReadLine();
        }
        static private void parseArgs(string[] args)
        {
            if (args.Length <1)
            {
                Console.WriteLine("Enter string to test parenthesis:");
                parenthesisString = Console.ReadLine();
            }
            if (args.Length < 2)
            {
                Console.WriteLine("Do you want to get inside data? (y/n):");
                PrintData = Console.ReadLine().ToString().ToLower() == "y";
            }else
            {
                PrintData = args[2].ToString().ToLower().Remove(' ') == "y";
            }
        }
        static bool NAS(string parenthesisStringToTest,ref string stack, int step=0)
        {
            bool canMove = true;
            if (parenthesisStringToTest.Length>0)
            {
                if (parenthesisStringToTest[0] == '(')
                {
                    stack += 'A';
                }else if (parenthesisStringToTest[0] == ')')
                {
                    if (stack.Length>0)
                    {
                        stack = stack.Substring(0, stack.Length - 1);
                    }else
                    {
                        canMove = false;
                    }
                    
                }
                parenthesisStringToTest =parenthesisStringToTest.Substring(1);
            }
            if (PrintData)
            {
                Console.WriteLine("{0} | {1} || {2} ||| {3}", step, stack, parenthesisStringToTest, stack.Length);
            }
            if (parenthesisStringToTest.Length>0&& canMove)
            {
                canMove = NAS(parenthesisStringToTest, ref stack, step+1);
            }
            return canMove;
        }
        static string getParenthesisFromString(string parenthesisString)
        {
            string onlyParenthesis = "";
            foreach (char c in parenthesisString)
            {
                if (c=='('||c==')')
                {
                    onlyParenthesis += c;
                }
            }
            if (PrintData) {
                Console.WriteLine("{0} |  || {1} ||| {2}",0,onlyParenthesis,0);
            }
            return onlyParenthesis;
        }
    }
}
