using System.Security.Cryptography;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Data;
using System.Text.RegularExpressions;

namespace Util
{
    public class Util
    {
        public static void Main(string[] args)
        {
            // string input = "(((a*b)+(c/d))-e)";
            // string input = "((5+4) * 3)";
            // (((3*2)+(9/3))-5)
            System.Console.Write("수식을 입력하세요 => ");
            string input = Console.ReadLine();
            input = $"({input})";
            var imp = new Implementation();

            string result = imp.Infix_To_Postfix(ref input);

            var ops = result.Split(' ');

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

                        case string n when n.Equals("%"):
                            {
                                stack.TryPop(out double a);
                                stack.TryPop(out double b);
                                rs = Convert.ToInt32(a) % Convert.ToInt32(b);
                                stack.Push(rs);
                            }
                            break;
                        case string n when n.Equals("^"):
                            {
                                stack.TryPop(out double a);
                                stack.TryPop(out double b);
                                rs = Convert.ToInt32(a) ^ Convert.ToInt32(b);
                                stack.Push(rs);
                            }
                            break;
                    }
                }
            }
            System.Console.WriteLine("infix => " + input);
            System.Console.WriteLine("postfix => " + result);
            System.Console.WriteLine("result by postfix => " + stack.Pop());
        }

        private static Stack<string> stack = new Stack<string>();
        private static List<string> operators = new List<string> { "+", "-", "*", "/" };

        private static void Postfix()
        {
            System.Console.Write("수식입력 => ");
            string input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                List<string> results = Regex.Split(input, @"\s*([-+/*])\s*").Where(n => !string.IsNullOrEmpty(n)).ToList();
                results.ForEach(x => stack.Push(x));
                Stack<int> operand = new Stack<int>();
                while (stack.TryPop(out string op))
                {
                }
            }
        }
    }
}
