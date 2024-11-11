using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;

namespace DAOs
{
	public class OrderDAO
	{
		private static KoiStoreDBContext _context;


        private static OrderDAO instance = null;
        public OrderDAO() { _context = new KoiStoreDBContext(); }

        public static OrderDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OrderDAO();
                }
                return instance;
            }
        }

        public List<Order> GetAllOrders()
        {
            return _context.Orders.Include(u => u.User).ToList();
        }

        public Order GetOrderById(int id)
        {
            try
            {
                return _context.Orders.Include(u => u.User).SingleOrDefault(o => o.Order_Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Order> GetOrdersByUserId(int userId)
        {
            try
            {
                return _context.Orders
                    .Include(o => o.User) 
                    .Where(o => o.User_Id == userId) 
                    .ToList(); 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool CreateOrder(Order o)
        {
            bool isSucess = false;
            try
            {
                Order ca = _context.Orders.SingleOrDefault(c => c.Order_Id == o.Order_Id);
                if (ca == null)
                {
                    _context.Orders.Add(o);
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

        public bool UpdateOrder(Order o)
        {
            bool isSucess = false;
            try
            {
                isSucess = true;
                _context.Orders.Update(o);
                _context.SaveChanges();
                _context.Entry(o).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSucess;
        }

        public bool DeleteOrder(int id)
        {
            bool isSucess = false;
            try
            {
                Order o = GetOrderById(id);
                if (o != null)
                {
                    _context.Orders.Remove(o);
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
	}
}
