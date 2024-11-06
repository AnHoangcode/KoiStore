using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Models;
using Repositories.Implement;
using Repositories.Interface;

namespace Services.Implement
{
	public class KoiTypeService
	{

        private IKoiTypeRepo _repo = null;
        public KoiTypeService()
        {
            if (_repo == null)
            {
                _repo = new KoiTypeRepo();
            }
        }
        public List<KoiType> GetAllKoiTypes()
        {
            return _repo.GetAllKoiTypes();
        }

        public KoiType GetKoiTypeById(int id)
        {
            return _repo.GetKoiTypeById(id);
        }

        public bool DeleteKoiType(int id)
        {
            return _repo.DeleteKoiType(id);
        }

        public bool UpdateKoiType(KoiType o)
        {
            return _repo.UpdateKoiType(o);
        }

        public bool CreateKoiType(KoiType o)
        {
            return _repo.CreateKoiType(o);
        }
	}
}
