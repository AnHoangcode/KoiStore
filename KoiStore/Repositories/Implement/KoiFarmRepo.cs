using BusinessObjects.Models;
using DAOs;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implement
{
    public class KoiFarmRepo : IKoiFarmRepo
    {
        public bool CreateKoiFarm(KoiFarm o) => KoiFarmDAO.Instance.CreateKoiFarm(o);

        public bool DeleteKoiFarm(int id) => KoiFarmDAO.Instance.DeleteKoiFarm(id);

        public List<KoiFarm> GetAllKoiFarms() => KoiFarmDAO.Instance.GetAllKoiFarms();

        public KoiFarm GetKoiFarmById(int id) => KoiFarmDAO.Instance.GetKoiFarmById(id);

        public bool UpdateKoiFarm(KoiFarm o) => KoiFarmDAO.Instance.UpdateKoiFarm(o);
    }
}
