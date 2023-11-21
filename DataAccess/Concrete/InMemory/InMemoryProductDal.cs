using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    #region Notes
    /*
    ->LINQ=>Language Integrated Query
     */
    #endregion
    public class InMemoryProductDal : IProductDal
    {

        List<Product> _products; //global

        public InMemoryProductDal()
        {
            _products = new List<Product> {
                new Product{ProductId=1,CategoryId=1,ProductName="Glass",UnitPrice=15,UnitsInStock=1256},
                new Product{ProductId=2,CategoryId=1,ProductName="Camera",UnitPrice=10000,UnitsInStock=100},
                new Product{ProductId=3,CategoryId=2,ProductName="Phone",UnitPrice=30000,UnitsInStock=10000},
                new Product{ProductId=4,CategoryId=2,ProductName="Keyboard",UnitPrice=2000,UnitsInStock=1100},
                new Product{ProductId=5,CategoryId=2,ProductName="Mouse",UnitPrice=500,UnitsInStock=2300}
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            /*Product productToDelete=null;
            foreach (var p in _products)
            {
                if (product.ProductId==p.ProductId)
                {
                    productToDelete = p;
                }
            }*/
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId); //system.Linq lazım
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün id'sine sahip olan listedeki ürünü bul.
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId); //system.Linq lazım
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}