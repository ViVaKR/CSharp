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
            var get = new List<string> { "A", "B", "C", "D", "A", "S", "A" }
                        .Select((p, i) => new { id = i, ch = p })
                        .Where(x => x.ch.Equals("A")).ToList();
            
            Console.WriteLine("=============== 추 출 ===============");
            Console.WriteLine(string.Join(", ", get.Select(x=> x.id)));
        }
    }

}
