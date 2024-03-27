using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_StudentTest
{
    public class Person
    {
        // (요청사항) 문자열 타입의 프로퍼티
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public Person(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }

}
