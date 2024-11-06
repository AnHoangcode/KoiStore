using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Models;
using Repositories.Implement;
using Repositories.Interface;
using Services.Interface;

namespace Services.Implement
{
	public class KoiProfileService : IKoiProfileService
	{

        private IKoiProfileRepo _repo = null;
        public KoiProfileService()
        {
            if (_repo == null)
            {
                _repo = new KoiProfileRepo();
            }
        }
        public List<KoiProfile> GetAllKoiProfiles()
        {
            return _repo.GetAllKoiProfiles();
        }

        public KoiProfile GetKoiProfileById(int id)
        {
            return _repo.GetKoiProfileById(id);
        }

        public bool DeleteKoiProfile(int id)
        {
            return _repo.DeleteKoiProfile(id);
        }

        public bool UpdateKoiProfile(KoiProfile o)
        {
            return _repo.UpdateKoiProfile(o);
        }

        public bool CreateKoiProfile(KoiProfile o)
        {
            return _repo.CreateKoiProfile(o);
        }
	}
}
