using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;

namespace DAOs
{
	public class OrderDetailDAO
	{
		private static KoiStoreDBContext _context;


        private static OrderDetailDAO instance = null;
        public OrderDetailDAO() { _context = new KoiStoreDBContext(); }

        public static OrderDetailDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OrderDetailDAO();
                }
                return instance;
            }
        }

        public List<OrderDetail> GetAllOrderDetails()
        {
            return _context.OrderDetails.Include(u => u.User).Include(p => p.Koi).Include(o => o.Order).ToList();
        }

        public OrderDetail GetOrderDetailById(int id)
        {
            try
            {
                return _context.OrderDetails.Include(u => u.User).Include(p => p.Koi).Include(o => o.Order).SingleOrDefault(o => o.Order_Detail_Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public bool CreateOrderDetail(OrderDetail o)
        {
            bool isSucess = false;
            try
            {
                OrderDetail ca = _context.OrderDetails.SingleOrDefault(c => c.Order_Detail_Id == o.Order_Detail_Id);
                if (ca == null)
                {
                    _context.OrderDetails.Add(o);
                    _context.SaveChanges();
					_context.Entry(o).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
					isSucess = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSucess;
        }

        public bool UpdateOrderDetail(OrderDetail o)
        {
            bool isSucess = false;
            try
            {
                isSucess = true;
                _context.OrderDetails.Update(o);
                _context.SaveChanges();
                _context.Entry(o).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSucess;
        }

        public bool DeleteOrderDetail(int id)
        {
            bool isSucess = false;
            try
            {
                OrderDetail o = GetOrderDetailById(id);
                if (o != null)
                {
                    _context.OrderDetails.Remove(o);
                    _context.SaveChanges();
					_context.Entry(o).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
					isSucess = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSucess;
        }

        public List<OrderDetail> GetOrderDetailByOrderId(int? id)
        {
            return _context.OrderDetails.Include(od => od.Koi).Where(od => od.Order_Id == id).ToList();
        }
    }
}
