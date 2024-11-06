using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Models;

namespace DAOs
{
	public class KoiTypeDAO
	{
		private static KoiStoreDBContext _context;


        private static KoiTypeDAO instance = null;
        public KoiTypeDAO() { _context = new KoiStoreDBContext(); }

        public static KoiTypeDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new KoiTypeDAO();
                }
                return instance;
            }
        }

        public List<KoiType> GetAllKoiTypes()
        {
            return _context.KoiTypes.ToList();
        }

        public KoiType GetKoiTypeById(int id)
        {
            try
            {
                return _context.KoiTypes.SingleOrDefault(o => o.Type_Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public bool CreateKoiType(KoiType o)
        {
            bool isSucess = false;
            try
            {
                KoiType ca = _context.KoiTypes.SingleOrDefault(c => c.Type_Id == o.Type_Id);
                if (ca == null)
                {
                    _context.KoiTypes.Add(o);
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

        public bool UpdateKoiType(KoiType o)
        {
            bool isSucess = false;
            try
            {
                isSucess = true;
                _context.KoiTypes.Update(o);
                _context.SaveChanges();
                _context.Entry(o).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSucess;
        }

        public bool DeleteKoiType(int id)
        {
            bool isSucess = false;
            try
            {
                KoiType o = GetKoiTypeById(id);
                if (o != null)
                {
                    _context.KoiTypes.Remove(o);
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
