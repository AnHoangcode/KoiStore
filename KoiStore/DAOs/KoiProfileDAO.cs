using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;

namespace DAOs
{
	public class KoiProfileDAO
	{
		private static KoiStoreDBContext _context;


        private static KoiProfileDAO instance = null;
        public KoiProfileDAO() { _context = new KoiStoreDBContext(); }

        public static KoiProfileDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new KoiProfileDAO();
                }
                return instance;
            }
        }

        public List<KoiProfile> GetAllKoiProfiles()
        {
            return _context.KoiProfiles.Include(t => t.Type_Id).Include(f => f.Farm_Id).ToList();
        }

        public KoiProfile GetKoiProfileById(int id)
        {
            try
            {
                return _context.KoiProfiles.Include(t => t.Type_Id).Include(f => f.Farm_Id).SingleOrDefault(o => o.Koi_Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public bool CreateKoiProfile(KoiProfile o)
        {
            bool isSucess = false;
            try
            {
                KoiProfile ca = _context.KoiProfiles.SingleOrDefault(c => c.Koi_Id == o.Koi_Id);
                if (ca == null)
                {
                    _context.KoiProfiles.Add(o);
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

        public bool UpdateKoiProfile(KoiProfile o)
        {
            bool isSucess = false;
            try
            {
                isSucess = true;
                _context.KoiProfiles.Update(o);
                _context.SaveChanges();
                _context.Entry(o).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSucess;
        }

        public bool DeleteKoiProfile(int id)
        {
            bool isSucess = false;
            try
            {
                KoiProfile o = GetKoiProfileById(id);
                if (o != null)
                {
                    _context.KoiProfiles.Remove(o);
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
