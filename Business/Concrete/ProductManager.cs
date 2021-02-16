using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorResult();
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), true, "Ürünler Listelendi.");

        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(x => x.CategoryId == id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(x => x.UnitPrice >= min && x.UnitPrice <= max);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }

        public Product GetById(int productId)
        {
            return _productDal.Get(x => x.ProductId == productId);
        }

        public IResult Add(Product product)
        {
            if (product.ProductName.Length < 2)
            {// magic strings
                return new ErrorResult(Messages.ProductNameInValid);
            }
            _productDal.Add(product);
            return new Result(true, Messages.ProductAdded);
        }
    }
}
