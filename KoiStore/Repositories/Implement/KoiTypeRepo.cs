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
	public class KoiTypeRepo : IKoiTypeRepo
	{

		public List<KoiType> GetAllKoiTypes()
		=> KoiTypeDAO.Instance.GetAllKoiTypes();

		public KoiType GetKoiTypeById(int id)
		=> KoiTypeDAO.Instance.GetKoiTypeById(id);

		public bool DeleteKoiType(int id)
		=> KoiTypeDAO.Instance.DeleteKoiType(id);

		public bool UpdateKoiType(KoiType o)
		=> KoiTypeDAO.Instance.UpdateKoiType(o);

		public bool CreateKoiType(KoiType o)
		=> KoiTypeDAO.Instance.CreateKoiType(o);
	}
}
