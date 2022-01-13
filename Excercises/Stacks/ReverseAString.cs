using System;
using SC = System.Collections;
using System.Linq;
using System.Text;

namespace Stacks
{
    public class StackExcercises
    {
        private static char[] initSymbols = { '(', '{', '[', '<' };
        private static char[] exitSymbols = { ')', '}', ']', '>' };

        //O[n]
        public static string ReverseAString(string str)
        {
            if (string.IsNullOrEmpty(str))
                throw new ArgumentException("Input string is either null or empty");


            SC.Stack charArrayStack = new SC.Stack(str.ToCharArray());
            StringBuilder reversedString = new StringBuilder();
            while (charArrayStack.Count > 0)
            {
                reversedString.Append(charArrayStack.Pop());
            }

            return reversedString?.ToString();

        }

        public static bool CheckBalancedExpression(string expression)
        {
            if (string.IsNullOrEmpty(expression))
                throw new ArgumentException("Input string is either null or empty");

            SC.Stack expStack = new SC.Stack();

            foreach (var character in expression.ToCharArray())
            {
                if (Enum.IsDefined(typeof(InitSymbols), (int)character))
                {
                    expStack.Push(character);
                }

                else if (Enum.IsDefined(typeof(ExitSymbols), (int)character))
                {
                    if (expStack.Count == 0)
                        return false;
                    var left = Enum.GetName(typeof(InitSymbols), expStack.Pop());
                    if (!left.Equals(Enum.GetName(typeof(ExitSymbols), character), StringComparison.OrdinalIgnoreCase))
                        return false;
                }
            }

            return true;
        }
    }


    public enum InitSymbols
    {
        CommonBracket = '(',
        SquareBracket = '[',
        CurlyBracket = '{',
        AngleBracket = '<'
    }

    public enum ExitSymbols
    {
        CommonBracket = ')',
        SquareBracket = ']',
        CurlyBracket = '}',
        AngleBracket = '>'
    }
}