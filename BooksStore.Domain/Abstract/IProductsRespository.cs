using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//add
using BooksStore.Domain.Entities;

namespace BooksStore.Domain.Abstract
{
    public interface IProductsRespository
    {
        IEnumerable<Product> Products { get; }
        IEnumerable<Admin> Admins { get; }
        void SaveProduct(Product product);
        Product DeleteProduct(int productID);
    }
}
