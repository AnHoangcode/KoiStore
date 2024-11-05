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
    public class OrderRepo : IOrderRepo
    {

        public List<Order> GetAllOrders()
        => OrderDAO.Instance.GetAllOrders();

        public Order GetOrderById(int id)
        => OrderDAO.Instance.GetOrderById(id);

        public bool DeleteOrder(int id)
        => OrderDAO.Instance.DeleteOrder(id);

        public bool UpdateOrder(Order o)
        => OrderDAO.Instance.UpdateOrder(o);

        public bool CreateOrder(Order o)
        => OrderDAO.Instance.CreateOrder(o);
    }
}
