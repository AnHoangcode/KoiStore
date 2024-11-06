using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Models;

namespace Repositories.Interface
{
	public interface IKoiTypeRepo
	{
		List<KoiType> GetAllKoiTypes();

		KoiType GetKoiTypeById(int id);

		bool DeleteKoiType(int o);

		bool UpdateKoiType(KoiType o);

		bool CreateKoiType(KoiType o);
	}
}
