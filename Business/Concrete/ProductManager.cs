using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        // Bir iş sınıfı başka kesinlikle newlemez.

        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            // doğrulama yapıları direkt iş katmanında kullanılmaz uygulanmaz bunun yerine Bussiness katmanında Farklı validasyon kuralları yazılır.
            //if (product.ProductName.Length < 2)
            //{
            //    return new ErrorResult(Messages.ProductNameInvalid);
            //}

            // bunlar cross cutting concerns gibi yapılarda tutulur.
                    ValidationTool.Validate(new ProductValidator(), product);
            //loglama
            //cacheRemove
            //transaction
            //vs vs. Bir sürü code. Bunlar yerine AOP kullanacağız

            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            // İş kodları varsa yazıyoruz.
            // Yetkisi var mı?
            // Başka kural varsa onlara bak?

            if (DateTime.Now.Hour == 21)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId), Messages.ProductDetail);

        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails(), Messages.ProductsListed);
        }
    }
}
