using SpryStore.BusinessLayer.Abstract;
using SpryStore.DataAccessLayer.Abstract;
using SpryStore.DataAccessLayer.Concrete;
using SpryStore.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpryStore.BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {

        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Insert(Product entity)
        {
            _productDal.Insert(entity);
        }

        public void Update(Product entity)
        {
            _productDal.Update(entity);
        }

        public void Delete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public Product GetById(int id)
        {
            return _productDal.GetById(id);
        }

        public List<Product> GetList()
        {
            return _productDal.GetList();
        }

        public List<Product> GetProductListWithCategory()
        {
            return _productDal.GetProductListWithCategory();
        }

        public List<Product> GetLast4Product()
        {
            return _productDal.GetLast4Product();
        }
    }
}
