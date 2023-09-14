using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Exampls
{
    public class Program
    {
        static void Main(string[] args)
        {
            // GetIndex();
            var maxWord = new GetMaxRepeatedWord();
            maxWord.Start();
        }
    }

    /// <summary>
    /// 문장에서 가장 많이 사용된 단어 추출 하기 데모
    /// </summary>
    public class GetMaxRepeatedWord
    {
        public void Start()
        {
            Console.WriteLine("-----------------------------------------");
            string inStr = "내가 그의 이름을 불러주기 전에는 그는 다만 하나의 몸짓에 지나지 않았다.\n";
            inStr += "내가 그의 이름을 불러주었을 때, 그는 내게로 와 꽃이 되었다.\n";
            inStr += "내가 그의 이름을 불러준 것처럼 나의 이 빛깔과 향기에 알맞는 누가 나의 이름을 불러다오.\n";
            inStr += "그에게로 가서 나도 그의 꽃이 되고 싶다.\n";
            inStr += "우리들은 모두 무엇이 되고 싶다.\n";
            inStr += "나는 너에게 너는 나에게 잊혀지지 않는 하나의 눈짓이 되고 싶다.";
            Console.WriteLine("-----------------------------------------");

            var words = inStr.Split(' ', StringSplitOptions.TrimEntries).ToList();

            var rs = words.GroupBy(g => g.Trim()).Distinct().Select(x => new
            {
                단어 = x.Key,
                갯수 = x.Count()
            }).OrderByDescending(o => o.갯수).ToList();

            foreach (var item in rs)
            {
                Console.WriteLine($"{item.단어} -> {item.갯수}");
            }

            Console.WriteLine();
            Console.WriteLine();

            int max = rs.Max(x => x.갯수);
            foreach (var str in rs.Where(x => x.갯수 == max))
            {
                Console.WriteLine($"가장많이 나온 글자 중 하나는 ( {str.단어} ) 이고 글자가 ( {str.갯수} ) 회 나왔습니다.");
            }
        }
    }
}
