﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Models;

namespace Services.Interface
{
	public interface IKoiProfileService
	{
		List<KoiProfile> GetAllKoiProfiles();

		KoiProfile GetKoiProfileById(int id);

		bool DeleteKoiProfile(int o);

		bool UpdateKoiProfile(KoiProfile o);

		bool CreateKoiProfile(KoiProfile o);
	}
}
