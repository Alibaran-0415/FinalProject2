using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

ProductTest();
//CategoryTest();

static void ProductTest()
{
    ProductManager productManager = new ProductManager(new EfProductDal());

    foreach (var product in productManager.GetAll())
    {
        Console.WriteLine(product.ProductName);
    }

    Console.WriteLine("-----------------------");

    foreach (var product in productManager.GetAllByCategoryId(2))
    {
        Console.WriteLine(product.ProductName);
    }

    Console.WriteLine("-----------------------");

    foreach (var product in productManager.GetByUnitPrice(60, 100))
    {
        Console.WriteLine(product.ProductName + "-" + product.CategoryId);
    }

    Console.WriteLine("-----------------------");

    foreach (var product in productManager.GetProductDetails())
    {
        Console.WriteLine(product.ProductName + "-" + product.CategoryName);
    }
}

static void CategoryTest()
{
    CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
    foreach (var category in categoryManager.GetAll())
    {
        Console.WriteLine(category.CategoryName);
    }
}