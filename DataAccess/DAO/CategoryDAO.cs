using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.DAO
{
    public class CategoryDao
    {
        private static CategoryDao _instance;
        private static readonly object InstanceLock = new object();

        public static CategoryDao GetCategoryDao
        {
            get
            {
                lock (InstanceLock)
                {
                    return _instance ??= new CategoryDao();
                }
            }
        }

        public IEnumerable<Category> GetCategoryList()
        {
            try
            {
                return new SalesManagementContext().Categories;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Category GetCategory(int categoryId)
        {
            try
            {
                return new SalesManagementContext().Categories.SingleOrDefault(cate => cate.CategoryId == categoryId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Category GetCategory(string categoryName)
        {
            try
            {
                return new SalesManagementContext().Categories.SingleOrDefault(cate =>
                    cate.CategoryName.Equals(categoryName.Trim()));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddCategory(string categoryName)
        {
            try
            {
                if (GetCategory(categoryName) != null)
                {
                    throw new Exception("Category name is existed!!!");
                }
                else
                {
                    SalesManagementContext context = new SalesManagementContext();
                    context.Categories.Add(new Category
                    {
                        CategoryName = categoryName
                    });
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}