﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//add
using BooksStore.Domain.Entities;
using System.Data.Entity;

namespace BooksStore.Domain.Concrete
{
    public class EFDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
