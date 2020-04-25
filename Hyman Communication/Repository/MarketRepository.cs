using Hyman_Communication.Contracts;
using Hyman_Communication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hyman_Communication.Repository
{
    public class MarketRepository : IMarketRepository
    {
        private readonly ApplicationDbContext _db;

        public MarketRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(Market entity)
        {
            _db.Markets.Add(entity);
            return Save();
        }

        public bool Delete(Market entity)
        {
            _db.Markets.Remove(entity);
            return Save();
        }

        public ICollection<Market> FinaAll()
        {
            var Market = _db.Markets.ToList();
            return Market;
        }

        public Market FindById(int id)
        {
            var Market = _db.Markets.Find(id);
            return Market;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(Market entity)
        {
            _db.Markets.Update(entity);
            return Save();
        }
    }
}
