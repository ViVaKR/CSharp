using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace J_ListViewEx
{
    internal class Member
    {
        [Key]
        [DisplayName("아이디")]
        public int Id { get; set; }

        [DisplayName("이름")]
        public string Name { get; set; }

        [DisplayName("이메일")]
        public string Email { get; set; }

        [DisplayName("출생연도")]
        public DateTime BirthDay { get; set; }
    }
}
