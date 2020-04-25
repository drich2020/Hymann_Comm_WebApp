using Hyman_Communication.Contracts;
using Hyman_Communication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hyman_Communication.Repository
{
    public class PromotionRepository : IPromotionRepository
    {
        private readonly ApplicationDbContext _db;

        public PromotionRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(Promotion entity)
        {
            _db.Promotions.Add(entity);
            return Save();
        }

        public bool Delete(Promotion entity)
        {
            _db.Promotions.Remove(entity);
            return Save();
        }

        public ICollection<Promotion> FinaAll()
        {
            var Promotion = _db.Promotions.ToList();
            return Promotion;
        }

        public Promotion FindById(int id)
        {
            var Promotion = _db.Promotions.Find(id);
            return Promotion;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(Promotion entity)
        {
            _db.Promotions.Update(entity);
            return Save();
        }
    }
}
