using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Models;
using DAOs;
using Repositories.Interfaces;

namespace Repositories.Implement
{
    public class OrderDetailRepo : IOrderDetailRepo
    {

        public List<OrderDetail> GetAllOrderDetails()
        => OrderDetailDAO.Instance.GetAllOrderDetails();

        public OrderDetail GetOrderDetailById(int id)
        => OrderDetailDAO.Instance.GetOrderDetailById(id);

        public bool DeleteOrderDetail(int id)
        => OrderDetailDAO.Instance.DeleteOrderDetail(id);

        public bool UpdateOrderDetail(OrderDetail o)
        => OrderDetailDAO.Instance.UpdateOrderDetail(o);

        public bool CreateOrderDetail(OrderDetail o)
        => OrderDetailDAO.Instance.CreateOrderDetail(o);

        public List<OrderDetail> GetOrderDetailByOrderId(int? id)
        {
            return OrderDetailDAO.Instance.GetOrderDetailByOrderId(id);
        }
    }
}
