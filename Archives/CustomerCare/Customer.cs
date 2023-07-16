using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace CustomerCare
{
    public enum Sex
    {
        Male,
        FeMale,
        Unknown
    }

    public class Customer
    {
        [Key]
        [Order]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "고객번호", Order = 0, AutoGenerateField = true, AutoGenerateFilter = true)]
        public int Id { get; set; }

        [Required]
        [Order]
        [StringLength(20, ErrorMessage ="20자 이내로 입력하세요")]
        [Display(Name = "성명", Order =1, AutoGenerateField = true, AutoGenerateFilter = true)]
        public string Name { get; set; }

        [Required]
        [Order]
        [EnumDataType(typeof(Sex))]
        [Display(Name = "성별", Order = 2, AutoGenerateField = true, AutoGenerateFilter = true)]
        public Sex Sex { get; set; }

        [Order]
        [StringLength(20)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "전화번호", Order = 3, AutoGenerateField = true, AutoGenerateFilter = true)]
        public string Phone { get; set; }


        [Order]
        [StringLength(20)]
        [Display(Name = "지역", Order =4, AutoGenerateField = true, AutoGenerateFilter = true)]
        public string Region { get; set; }

        [Order]
        [MaxLength]
        [Display(Name = "메모", Order = 5, AutoGenerateField = true, AutoGenerateFilter = true)]
        public string Memo { get; set; }

    }

    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class OrderAttribute : Attribute
    {
        private readonly int order_;
        public OrderAttribute([CallerLineNumber] int order = 0)
        {
            order_ = order;
        }

        public int Order { get { return order_; } }
    }
}
