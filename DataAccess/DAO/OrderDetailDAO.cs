using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.DAO
{
    public class OrderDetailDao
    {
        // Using Singleton Pattern
        private static OrderDetailDao _instance;
        private static readonly object InstanceLock = new object();

        public static OrderDetailDao GetOrderDetailDao
        {
            get
            {
                lock (InstanceLock)
                {
                    return _instance ??= new OrderDetailDao();
                }
            }
        }

        public void AddOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                var context = new SalesManagementContext();
                context.OrderDetails.Add(orderDetail);
                context.SaveChanges();
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public decimal GetOrderTotal(int orderId)
        {
            decimal orderTotal = 0;

            try
            {
                var context = new SalesManagementContext();
                IEnumerable<OrderDetail> orderDetails = context.OrderDetails.Where(od => od.OrderId == orderId);
                foreach (var orderDetail in orderDetails)
                {
                    orderTotal += orderDetail.UnitPrice * (1 - Convert.ToDecimal(orderDetail.Discount));
                }
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Math.Round(orderTotal, 2);
        }

        public IEnumerable<OrderDetail> GetListOrderDetailsByOrderId(int orderId)
        {
            try
            {
                return new SalesManagementContext().OrderDetails.Where(od => od.OrderId == orderId);
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteOrderDetails(int orderId)
        {
            try
            {
                IEnumerable<OrderDetail> orderDetails = GetListOrderDetailsByOrderId(orderId);
                var context = new SalesManagementContext();
                foreach (var orderDetail in orderDetails)
                {
                    context.Remove(orderDetail);
                }
                context.SaveChanges();
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteOrderDetailsByProductId(int productId)
        {
            try
            {
                var context = new SalesManagementContext();
                IEnumerable<OrderDetail> orderDetails = context.OrderDetails.Where(od => od.ProductId == productId);
                foreach (var orderDetail in orderDetails)
                {
                    context.Remove(orderDetail);
                }
                context.SaveChanges();
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
