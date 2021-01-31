using Business.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        // Bir iş sınıfı başka kesinlikle newlemez.

        InMemoryProductDal _productDal;

        public ProductManager(InMemoryProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            // İş kodları varsa yazıyoruz.
            // Yetkisi var mı?
            // Başka kural varsa onlara bak?
            return _productDal.GetAll();
        }
    }
}
