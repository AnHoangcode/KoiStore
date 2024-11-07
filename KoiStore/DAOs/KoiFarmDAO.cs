using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs
{
    public class KoiFarmDAO
    {
        private static KoiStoreDBContext _context;
        private static KoiFarmDAO instance = null;

        public KoiFarmDAO()
        {
            _context = new KoiStoreDBContext();
        }
        public static KoiFarmDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new KoiFarmDAO();
                }
                return instance;
            }
        }

        public bool CreateKoiFarm(KoiFarm o)
        {
            bool isSucess = false;
            try
            {
                KoiFarm ca = _context.KoiFarms.SingleOrDefault(c => c.Farm_Id == o.Farm_Id);
                if (ca == null)
                {
                    _context.KoiFarms.Add(o);
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

        public bool DeleteKoiFarm(int id)
        {
            bool isSucess = false;
            try
            {
                KoiFarm o = GetKoiFarmById(id);
                if (o != null)
                {
                    _context.KoiFarms.Remove(o);
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

        public List<KoiFarm> GetAllKoiFarms() => _context.KoiFarms.ToList();

        public KoiFarm GetKoiFarmById(int id) => _context.KoiFarms.SingleOrDefault(c => c.Farm_Id == id);

        public bool UpdateKoiFarm(KoiFarm o)
        {
            bool isSucess = false;
            try
            {
                isSucess = true;
                _context.KoiFarms.Update(o);
                _context.SaveChanges();
                _context.Entry(o).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSucess;
        }
    }
}
