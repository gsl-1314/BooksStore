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
    public class Admin
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "请输入管理员名")]
        public string adminName { get; set; }
        [Required(ErrorMessage = "请输入管理员密码")]
        public string pwd { get; set; }
    }
}
