using BusinessObject;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.OrderRepo
{
    public class OrderRepository : IOrderRepository
    {
        public Order AddOrder(Order order) => OrderDao.GetOrderDao.AddOrder(order);

        public void DeleteByMember(int memberId) => OrderDao.GetOrderDao.DeleteByMember(memberId);
        public void DeleteOrder(int orderId) => OrderDao.GetOrderDao.DeleteOrder(orderId);

        public IEnumerable<Order> GetAllOrder() => OrderDao.GetOrderDao.GetAllOrder();

        public IEnumerable<Order> GetAllOrderFilterByDate( DateTime? startDate, DateTime? endDate) => OrderDao.GetOrderDao.GetAllOrderFilterByDate( startDate, endDate);
    }
}
