using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Models;

namespace Repositories.Interfaces
{
    public interface IOrderDetailRepo
    {
        List<OrderDetail> GetAllOrderDetails();

        OrderDetail GetOrderDetailById(int id);

        bool DeleteOrderDetail(int o);

        bool UpdateOrderDetail(OrderDetail o);

        bool CreateOrderDetail(OrderDetail o);
        List<OrderDetail> GetOrderDetailByOrderId(int? id);
    }
}
