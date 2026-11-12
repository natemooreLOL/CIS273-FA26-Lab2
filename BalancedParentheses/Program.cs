namespace BalancedParentheses;

public class Program
{
    static void Main(string[] args)
    {
    }

    /// <summary>
    /// Write a method IsBalanced() that tests a string for balanced parentheses.
    /// The string is balanced when every opening parenthesis has a matching closing
    /// parenthesis of the same kind, and they are closed in the correct order.
    /// Your code must work for all four kinds: &lt; &gt;, { }, [ ], and ( ).
    /// Ignore any other characters in the string.
    /// </summary>
    /// <example>
    /// <code>
    /// IsBalanced("{ int a = new int[ ] ( ( ) ) }"); // true
    /// IsBalanced("{ () ) ) ( ( }");                 // false
    /// IsBalanced(" ( ( [ &lt; ] &gt; ) ) ");        // false (closed in the wrong order)
    /// IsBalanced(" ( ( [ ");                        // false (never closed)
    /// IsBalanced(" ] ");                            // false (nothing to close)
    /// </code>
    /// </example>
    /// <param name="s">The string to check. It may contain any characters.</param>
    /// <returns>true if the parentheses in <paramref name="s"/> are balanced; otherwise, false.</returns>
    public static bool IsBalanced(string s)
    {
        if(s is null)
        {
            return false;
        }
        Stack<char> BalanceCheck = new Stack<char>();
        foreach(char c in s)
        {
            if(c == '(' || c == '[' || c == '{' || c == '<')
            {
                BalanceCheck.Push(c);
            }
            if(c == ')' || c == ']' || c == '}' || c == '>')
            {
                if(BalanceCheck.Count == 0)
                {
                    return false;
                }
                char Popped = BalanceCheck.Pop();
                if(c == ')' && Popped == '(')
                {
                    continue;
                }
                else if(c == ']' && Popped == '[')
                {
                    continue;
                }
                else if(c == '}' && Popped == '{')
                {
                    continue;
                }
                else if(c == '>' && Popped == '<')
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
        }
        if(BalanceCheck.Count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

