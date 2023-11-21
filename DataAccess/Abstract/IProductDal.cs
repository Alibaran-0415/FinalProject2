using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    #region Notes
    /*
    ->Dal(Data Access Layer)=>Veri Erişim Katmanı
    ->Add reference to entities olmazsa:
    Bulunduğum projeye(DataAccess) sağ tık=>Add=>Project Reference=>Referansı seç(Entities)=>using olanı seç
     */
    #endregion
    public interface IProductDal:IEntityRepository<Product>
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto
                             {
                                 ProductId = p.ProductId, ProductName = p.ProductName,
                                 CategoryName=c.CategoryName,UnitsInStock=p.UnitsInStock
                             };
                return result.ToList();
            }
        }
    }
}