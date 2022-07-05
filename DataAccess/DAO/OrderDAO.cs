using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.DAO
{
    public class OrderDao
    {
        private static OrderDao _instance;
        private static readonly object InstanceLock = new object();

        public static OrderDao GetOrderDao
        {
            get
            {
                lock (InstanceLock)
                {
                    return _instance ??= new OrderDao();
                }
            }
        }

        public Order AddOrder(Order order)
        {
            try
            {
                var context = new SalesManagementContext();
                context.Orders.Add(order);
                context.SaveChanges();
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return order;
        }
        public IEnumerable<Order> GetAllOrder()
        {
            try
            {
                return new SalesManagementContext().Orders;
                
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<Order> GetAllOrderFilterByDate(DateTime? startDate, DateTime? endDate)
        {
            try
            {
                var context = new SalesManagementContext();
                IEnumerable<Order> orders = context.Orders;
                if (startDate != null)
                {
                    orders = orders.Where(order => DateTime.Compare(order.OrderDate, (DateTime)startDate) >= 0);
                }
                
                if (endDate != null)
                {
                    orders = orders.Where(order => DateTime.Compare(order.OrderDate, (DateTime)endDate) <= 0);
                }

                return orders;

            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        private Order GetOrderByOrderId(int orderId)
        {
            try
            {
                return new SalesManagementContext().Orders.SingleOrDefault(or => or.OrderId == orderId);
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
        public void DeleteOrder(int orderId)
        {
            try
            {
                var context = new SalesManagementContext();
                context.Orders.Remove(GetOrderByOrderId(orderId));
                context.SaveChanges();
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteByMember(int memberId)
        {
            try
            {
                List<Order> orders = GetAllOrder().Where(order => order.MemberId == memberId).ToList();
                var context = new SalesManagementContext();
                foreach (var order in orders)
                {
                    context.Remove(order);
                }
                context.SaveChanges();
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
