using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IKoiFarmService
    {
        List<KoiFarm> GetAllKoiFarms();

        KoiFarm GetKoiFarmById(int id);

        bool DeleteKoiFarm(int id);

        bool UpdateKoiFarm(KoiFarm o);

        bool CreateKoiFarm(KoiFarm o);
    }
}
