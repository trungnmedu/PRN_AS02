using BusinessObject;
using DataAccess.DAO;
using System.Collections.Generic;

namespace DataAccess.Repository.ProductRepo
{
    public class ProductRepository : IProductRepository
    {
        public void AddProduct(Product product) => ProductDao.GetProductDao.AddProduct(product);

        public void Delete(int productId) => ProductDao.GetProductDao.Delete(productId);


        public Product GetProduct(int productId, IEnumerable<Product> searchList = null)
        {
            return ProductDao.GetProductDao.GetProductByProductId(productId, searchList);
        }
        public Product GetProduct(string productName, IEnumerable<Product> searchList = null)
        {
            return ProductDao.GetProductDao.GetProductByProductName(productName, searchList);
        }

        public IEnumerable<Product> GetProductsList() => ProductDao.GetProductDao.GetProductsList();


        public IEnumerable<Product> SearchProduct(string name, IEnumerable<Product> searchList = null)
        {
            return ProductDao.GetProductDao.SearchProduct(name, searchList);
        }

        public IEnumerable<Product> SearchProduct(int startUnit, int endUnit, IEnumerable<Product> searchList = null)
        {
            return ProductDao.GetProductDao.SearchProduct(startUnit, endUnit, searchList);
        }

        public IEnumerable<Product> SearchProduct(decimal startPrice, decimal endPrice, IEnumerable<Product> searchList = null)
        {
            return ProductDao.GetProductDao.SearchProduct(startPrice, endPrice, searchList);
        }

        public void Update(Product product) => ProductDao.GetProductDao.Update(product);
    }
}
