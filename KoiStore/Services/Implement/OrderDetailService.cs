using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Models;
using Repositories.Implement;
using Repositories.Interfaces;

namespace Services.Implement
{
	public class OrderDetailService
	{

        private IOrderDetailRepo _repo = null;
        public OrderDetailService()
        {
            if (_repo == null)
            {
                _repo = new OrderDetailRepo();
            }
        }
        public List<OrderDetail> GetAllOrderDetails()
        {
            return _repo.GetAllOrderDetails();
        }

        public OrderDetail GetOrderDetailById(int id)
        {
            return _repo.GetOrderDetailById(id);
        }

        public bool DeleteOrderDetail(int id)
        {
            return _repo.DeleteOrderDetail(id);
        }

        public bool UpdateOrderDetail(OrderDetail o)
        {
            return _repo.UpdateOrderDetail(o);
        }

        public bool CreateOrderDetail(OrderDetail o)
        {
            return _repo.CreateOrderDetail(o);
        }
	}
}
