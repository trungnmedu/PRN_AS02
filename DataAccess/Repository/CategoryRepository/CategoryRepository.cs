using BusinessObject;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.CategoryRepo
{
    public class CategoryRepository : ICategoryRepository
    {
        public void AddCategory(string categoryName) => CategoryDao.GetCategoryDao.AddCategory(categoryName);

        public Category GetCategory(int categoryId)
        {
            return CategoryDao.GetCategoryDao.GetCategory(categoryId);
        }

        public Category GetCategory(string categoryName)
        {
            return CategoryDao.GetCategoryDao.GetCategory(categoryName);
        }

        public IEnumerable<Category> GetCategoryList()
        {
            return CategoryDao.GetCategoryDao.GetCategoryList();
        }
    }
}
