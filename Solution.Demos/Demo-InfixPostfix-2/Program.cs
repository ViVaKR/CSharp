using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace infix2postfix
{
  public class Program
  {
    static string input = ""; // 입력 문자열 
    static char[] stack = new char[100]; // 스택 
    static int point = 0; // 스택 포인트 
    static string output = ""; // 출력 문자열 (postfix) 

    static void Main(string[] args)
    {
      Console.Out.Write("infix 수식을 입력하시오 : ");
      input = Console.In.ReadLine(); // 입력 
      Console.Out.WriteLine("입력하신 infix 수식 : " + input + "\n");

      for (int i = 0; i < input.Length; i++) // 한글자씩 반복하기 
      {
        char c = input[i]; // 한글자씩 가져오기 
        if (c >= '0' && c <= '9') // 피연산자의 경우 
        {
          output += c.ToString();
        }
        else if (c == '+' || c == '-')
        {
          while (!Stack_IsEmpty())
          {
            // 기존 스택이 비어있지 않다면 
            char prev_c = Stack_Pop(); // 스택 최상단의 연산자를 가져옴 
            if (prev_c == '*' || prev_c == '/' || prev_c == '+' || prev_c == '-')
            {
              // 스택 최상단 연산자가 현재 연산자 보다 상위 연산자라면 
              output += prev_c.ToString();
            }
            else
            {
              Stack_Push(prev_c);
              break;
            }
          }
          Stack_Push(c);
        }
        else if (c == '*' || c == '/')
        {
          while (!Stack_IsEmpty())
          {
            // 기존 스택이 비어있지 않다면 
            char prev_c = Stack_Pop(); // 스택 최상단의 연산자를 가져옴 
            if (prev_c == '*' || prev_c == '/')
            {
              // 스택 최상단 연산자가 현재 연산자 보다 상위 연산자라면 
              output += prev_c.ToString();
            }
            else
            {
              Stack_Push(prev_c);
              break;
            }
          }
          Stack_Push(c);
        }
        else if (c == '(')
        {
          Stack_Push(c);
        }
        else if (c == ')')
        {
          while (true)
          {
            char prev_oper = Stack_Pop(); // 기존 스택의 최상위 연산자를 꺼내온다. 
            if (prev_oper == '(')
              break;
            output += prev_oper.ToString(); // 기존 스택의 최상위 연산자를 출력으로 빼낸다. 
          }
        }
      }
      // stack에 있는 모든 연산자를 순차적으로 꺼내서 output에 넣는다. 
      while (!Stack_IsEmpty())
      {
        output += Stack_Pop().ToString();
      }

      // 결과 출력 
      Console.Out.WriteLine();
      System.Console.WriteLine("==");
      foreach (var item in output)
      {
        System.Console.WriteLine(item);
      }
      System.Console.WriteLine("==");
      Console.Out.WriteLine("Postfix => " + output);
      Console.Out.Write("아무키나 입력하시오.");
      Console.In.ReadLine(); // 종료전 일시 정지 

      Calc(output);
    }

    private static void Calc(string output)
    {
      var ops = Regex.Split(output, @"\s*([+-/*])\s*", RegexOptions.IgnoreCase);

      Stack<double> stack = new Stack<double>();
      foreach (var ch in ops)
      {
        if (double.TryParse(ch.ToString(), out double c))
        {
          stack.Push(c);
        }
        else
        {

          double rs = default;
          switch (ch)
          {
            case string n when n.Equals("+"):
              {
                stack.TryPop(out double a);
                stack.TryPop(out double b);
                rs = b + a;
                stack.Push(rs);
              }
              break;
            case string n when n.Equals("-"):
              {
                stack.TryPop(out double a);
                stack.TryPop(out double b);
                rs = b - a;
                stack.Push(rs);
              }
              break;
            case string n when n.Equals("*"):
              {
                stack.TryPop(out double a);
                stack.TryPop(out double b);
                rs = b * a;
                stack.Push(rs);
              }
              break;
            case string n when n.Equals("/"):
              {
                stack.TryPop(out double a);
                stack.TryPop(out double b);
                rs = b / a;
                stack.Push(rs);
              }
              break;
          }
        }
      }
      System.Console.WriteLine("infix => " + input);
      System.Console.WriteLine("postfix => " + output);
      System.Console.WriteLine("result by postfix => " + stack.Pop());
    }

    private static void Stack_Show()
    {
      // 스택 내용을 모두 보여준다. 
      for (int i = 0; i < point; i++)
      {
        Console.Out.Write(stack[i]);
      }
      Console.Out.WriteLine();
    }
    private static void Stack_Push(char c)
    {
      // 스택의 최상위에 값을 추가한다. 
      stack[point] = c;
      point++;
      return;
    }
    private static char Stack_Pop()
    {
      // 스택의 최상위에 값을 가져온다. 
      point--;
      char result = stack[point];
      stack[point] = '\0';
      return result;
    }
    private static bool Stack_IsEmpty()
    {
      // 스택이 비었다면 true를 비어있지 않다면 false를 반환한다. 
      return (point == 0 ? true : false);
    }
  }
}
