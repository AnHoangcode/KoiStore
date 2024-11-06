using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Models;
using DAOs;
using Repositories.Interface;

namespace Repositories.Implement
{
	public class KoiProfileRepo : IKoiProfileRepo
	{

		public List<KoiProfile> GetAllKoiProfiles()
		=> KoiProfileDAO.Instance.GetAllKoiProfiles();

		public KoiProfile GetKoiProfileById(int id)
		=> KoiProfileDAO.Instance.GetKoiProfileById(id);

		public bool DeleteKoiProfile(int id)
		=> KoiProfileDAO.Instance.DeleteKoiProfile(id);

		public bool UpdateKoiProfile(KoiProfile o)
		=> KoiProfileDAO.Instance.UpdateKoiProfile(o);

		public bool CreateKoiProfile(KoiProfile o)
		=> KoiProfileDAO.Instance.CreateKoiProfile(o);
	}
}
