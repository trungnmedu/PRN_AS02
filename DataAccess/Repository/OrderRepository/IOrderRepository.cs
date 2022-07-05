using BusinessObject;
using System;
using System.Collections.Generic;

namespace DataAccess.Repository.OrderRepo
{
    public interface IOrderRepository
    {
        public Order AddOrder(Order order);
        public IEnumerable<Order> GetAllOrder();
        public IEnumerable<Order> GetAllOrderFilterByDate(DateTime? startDate, DateTime? endDate);
        public void DeleteOrder(int orderId);
        public void DeleteByMember(int memberId);
    }
}
