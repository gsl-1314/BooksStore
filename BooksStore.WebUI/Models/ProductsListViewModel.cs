using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//add
using BooksStore.Domain.Entities;

namespace BooksStore.WebUI.Models
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Admin> Admins { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}