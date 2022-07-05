using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.DAO
{
    public class ProductDao
    {
        private static ProductDao _instance;
        private static readonly object InstanceLock = new object();

        public static ProductDao GetProductDao
        {
            get
            {
                lock (InstanceLock)
                {
                    return _instance ??= new ProductDao();
                }
            }
        }

        public IEnumerable<Product> GetProductsList()
        {
            try
            {
                return new SalesManagementContext().Products.Include(pro => pro.Category);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Product GetProductByProductId(int productId, IEnumerable<Product> searchList = null)
        {
            try
            {
                if (searchList == null)
                {
                    return new SalesManagementContext().Products.SingleOrDefault(pro => pro.ProductId == productId);
                }
                else
                {
                    return searchList.SingleOrDefault(pro => pro.ProductId == productId);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Product GetProductByProductName(string productName, IEnumerable<Product> searchList = null)
        {
            try
            {
                if (searchList == null)
                {
                    return new SalesManagementContext().Products.SingleOrDefault(product => product.ProductName.Equals(productName));
                }
                else
                {
                   return searchList.SingleOrDefault(product => product.ProductName.Equals(productName));
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int GetNextProductId()
        { 
            try
            {
                return new SalesManagementContext().Products.Max(product => product.ProductId) + 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void AddProduct(Product product)
        {
            if (product == null)
            {
                throw new Exception("Product is undefined!!");
            }
            try
            {
                if (GetProductByProductId(product.ProductId) == null)
                {
                    var context = new SalesManagementContext();
                    context.Products.Add(product);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Product is existed!!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(Product product)
        {
            if (product == null)
            {
                throw new Exception("Product is undefined!!");
            }
            try
            {
                Product existProductByProductId = GetProductByProductId(product.ProductId);
                if (existProductByProductId != null)
                {
                    var context = new SalesManagementContext();
                    context.Products.Update(product);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Product does not exist!!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public void Delete(int productId)
        {
            try
            {
                Product productExistByProductId = GetProductByProductId(productId);
                if (productExistByProductId != null)
                {
                    var context = new SalesManagementContext();
                    context.Products.Remove(productExistByProductId);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Product does not exist!!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<Product> SearchProduct(string name, IEnumerable<Product> searchList)
        {
            try
            {
                if (searchList == null)
                {
                    return new SalesManagementContext().Products
                                        .Where(pro => pro.ProductName.ToLower().Contains(name.ToLower()))
                                        .Include(pro => pro.Category);
                }
                else
                {
                   return searchList.Where(pro => pro.ProductName.ToLower().Contains(name.ToLower()));
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Product> SearchProduct(int startUnit, int endUnit, IEnumerable<Product> searchList = null)
        {
            try
            {
                if (searchList == null)
                {
                    return new SalesManagementContext().Products
                                    .Where(pro => pro.UnitsInStock >= startUnit && pro.UnitsInStock <= endUnit)
                                    .Include(pro => pro.Category);
                }
                else
                {
                   return searchList.Where(pro => pro.UnitsInStock >= startUnit && pro.UnitsInStock <= endUnit);
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Product> SearchProduct(decimal startPrice, decimal endPrice, IEnumerable<Product> searchList = null)
        {
            try
            {
                if (searchList == null)
                {
                    return new SalesManagementContext().Products
                                        .Where(pro => pro.UnitPrice >= startPrice && pro.UnitPrice <= endPrice)
                                        .Include(pro => pro.Category);
                }
                else
                {
                    return searchList.Where(pro => pro.UnitPrice >= startPrice && pro.UnitPrice <= endPrice);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
