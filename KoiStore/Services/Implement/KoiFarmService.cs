
using BusinessObjects.Models;
using Repositories.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implement
{
    public class KoiFarmService : IKoiFarmService
    {
        private readonly IKoiFarmRepo? _repo;
        public KoiFarmService(IKoiFarmRepo repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        public bool CreateKoiFarm(KoiFarm o) => _repo.CreateKoiFarm(o);

        public bool DeleteKoiFarm(int id) => _repo.DeleteKoiFarm(id);

        public List<KoiFarm> GetAllKoiFarms() => _repo.GetAllKoiFarms();

        public KoiFarm GetKoiFarmById(int id) => _repo.GetKoiFarmById(id);

        public bool UpdateKoiFarm(KoiFarm o) => _repo.UpdateKoiFarm(o);
    }
}
