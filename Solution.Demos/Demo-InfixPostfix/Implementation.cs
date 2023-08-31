using System.Text.RegularExpressions;
namespace Util;

public class Implementation
{
  public int precedence(char op)
  {
    if (op == '*' || op == '/' || op == '%') return 3;
    else if (op == '+' || op == '-') return 2;
    else if (op == '^') return 1;
    else return -1;
  }

  public string Infix_To_Postfix(ref string input)
  {
    Stack<char> stack = new Stack<char>();

    string output = string.Empty;
    char _out;

    foreach (var ch in input)
    {
      bool isAlphaBet = Regex.IsMatch(ch.ToString(), "[a-z]", RegexOptions.IgnoreCase);
      if (char.IsDigit(ch) || isAlphaBet)
      {
        output = output + ch;
      }
      else
      {
        switch (ch)
        {
          case '+':
          case '-':
          case '*':
          case '/':
          case '%':
          case '^':
            while (stack.Count > 0 && precedence(ch) <= precedence(stack.Peek()))
            {
              _out = stack.Peek();
              stack.Pop();
              output = output + " " + _out;
            }
            stack.Push(ch);
            output = output + " ";
            break;
          case '(':
            stack.Push(ch);
            break;
          case ')':
            while (stack.Count > 0 && (_out = stack.Peek()) != '(')
            {
              stack.Pop();
              output = output + " " + _out + " ";
            }
            if (stack.Count > 0 && (_out = stack.Peek()) == '(') stack.Pop();
            break;
        }
      }
    }
    while (stack.Count > 0)
    {
      _out = stack.Peek();
      stack.Pop();
      output = output + _out + " ";
    }
    return output;
  }
}
