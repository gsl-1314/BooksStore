using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//add
using System.Web.Mvc;
using Ninject;
using BooksStore.Domain.Abstract;
using BooksStore.Domain.Entities;
using BooksStore.Domain.Concrete;
using Moq;

namespace BooksStore.WebUI.Infrastructure
{
    public class NinjectDependencyResolver:IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            ////将绑定放在这里
            //Mock<IProductsRespository> mock = new Mock<IProductsRespository>();
            //mock.Setup(m => m.Products).Returns(new List<Product> { 
            //    new Product{Name="公孙离",Price=58.8M},
            //    new Product{Name="东方镜",Price=68.8M},
            //    new Product{Name="庄周",Price=28.8M}
            //});
            kernel.Bind<IProductsRespository>().To<EFProductRepository>();
        }
    }
}