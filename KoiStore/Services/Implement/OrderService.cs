using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Models;
using Repositories.Implement;
using Repositories.Interfaces;
using Services.Interface;

namespace Services.Implement
{
	public class OrderService : IOrderService
	{

        private IOrderRepo _repo = null;
        public OrderService()
        {
            if (_repo == null)
            {
                _repo = new OrderRepo();
            }
        }
        public List<Order> GetAllOrders()
        {
            return _repo.GetAllOrders();
        }

        public Order GetOrderById(int id)
        {
            return _repo.GetOrderById(id);
        }

        public bool DeleteOrder(int id)
        {
            return _repo.DeleteOrder(id);
        }

        public bool UpdateOrder(Order o)
        {
            return _repo.UpdateOrder(o);
        }

        public bool CreateOrder(Order o)
        {
            return _repo.CreateOrder(o);
        }
	}
}
