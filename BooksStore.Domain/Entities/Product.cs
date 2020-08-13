using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//add
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BooksStore.Domain.Entities
{
    public class Product
    {
        [HiddenInput(DisplayValue = false)]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "请输入图书的名字")]
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]

        [Required(ErrorMessage = "请输入图书的摘要")]
        public string Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "请输入图书的定价")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "请您为图书分类")]
        public string Category { get; set; }
    }
    
}
