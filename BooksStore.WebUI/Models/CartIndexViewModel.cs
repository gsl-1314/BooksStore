using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//add
using BooksStore.Domain.Entities;

namespace BooksStore.WebUI.Models
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}