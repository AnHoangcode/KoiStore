using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Models;

namespace Services.Interface
{
	public interface IOrderService
	{

		List<Order> GetAllOrders();

		Order GetOrderById(int id);

		bool DeleteOrder(int o);

		bool UpdateOrder(Order o);

		bool CreateOrder(Order o);
	}
}
