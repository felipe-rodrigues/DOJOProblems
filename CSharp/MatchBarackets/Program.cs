using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MatchBarackets
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfStrings = int.Parse(Console.ReadLine());

            List<string> toCheck = new List<string>();
            for(var i=0; i < numberOfStrings; i++)
            {
                toCheck.Add(Console.ReadLine());
            }


            foreach (var item in toCheck)
            {
                Console.WriteLine(isBalanced(item));
            }
        }

        private static string isBalanced(string s)
        {
            bool valid = true;

            var openingBrackets = new List<char>() { '{', '(', '[' };
            var closingBrackets = new List<char>() { '}', ')', ']' };


            Stack<char> stack = new Stack<char>();

            for(int i =0; i < s.Length; i++)
            {
                var currentCharacter = s[i];
                if (openingBrackets.Contains(currentCharacter))
                {
                    stack.Push(currentCharacter);
                }
                else
                {
                    if (stack.Any())
                    {
                        var expecting = stack.Pop();
                        if (!isExpected(expecting, currentCharacter))
                        {
                            return "NO";
                        }
                    }
                    else
                    {
                        return "NO";
                    }
                    
                }
            }
            
            
            return valid ? "YES" : "NO";         
           
        }

        private static bool isExpected(char open, char close)
        {
            switch (open) 
            {

                case '{':
                    return close == '}';

                case '[':
                    return close == ']';

                case '(':
                    return close == ')';

                default:
                    return false;
            }
        }
    }
}
