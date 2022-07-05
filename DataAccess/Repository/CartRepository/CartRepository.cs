using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DAO;

namespace DataAccess.Repository.CartRepo
{
    public class CartRepository : ICartRepository
    {
        public void AddToCart(int productId, int quantity, decimal price) => CartDao.GetCartDao.AddToCart(productId, quantity, price);

        public Dictionary<int, CartProduct> GetCart() => CartDao.GetCartDao.GetCart();

        public void RemoveFromCart(int productId) => CartDao.GetCartDao.RemoveFromCart(productId);

        public void UpdateCart(int productId, int quantity, decimal price) => CartDao.GetCartDao.UpdateCart(productId, quantity, price);
        public void DeleteCart() => CartDao.GetCartDao.DeleteCart();
    }
}
