using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface IKoiFarmRepo
    {
        bool CreateKoiFarm(KoiFarm o);
        bool DeleteKoiFarm(int id);
        List<KoiFarm> GetAllKoiFarms();
        KoiFarm GetKoiFarmById(int id);
        bool UpdateKoiFarm(KoiFarm o);
    }
}
