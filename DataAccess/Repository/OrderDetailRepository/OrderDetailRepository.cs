using BusinessObject;
using DataAccess.DAO;
using System.Collections.Generic;

namespace DataAccess.Repository.OrderDetailRepo
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public void AddOrderDetail(OrderDetail orderDetail) => OrderDetailDao.GetOrderDetailDao.AddOrderDetail(orderDetail);

        public void DeleteByProduct(int productId) => OrderDetailDao.GetOrderDetailDao.DeleteOrderDetailsByProductId(productId);

        public void DeleteOrderDetails(int orderId) => OrderDetailDao.GetOrderDetailDao.DeleteOrderDetails(orderId);

        public IEnumerable<OrderDetail> GetOrderDetails(int orderId) => OrderDetailDao.GetOrderDetailDao.GetListOrderDetailsByOrderId(orderId);

        public decimal GetOrderTotal(int orderId) => OrderDetailDao.GetOrderDetailDao.GetOrderTotal(orderId);
    }
}
