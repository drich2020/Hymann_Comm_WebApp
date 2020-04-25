using Hyman_Communication.Contracts;
using Hyman_Communication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hyman_Communication.Repository
{
    public class ProductRepository : IProductRespository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(Product entity)
        {
            _db.Products.Add(entity);
            return Save();
        }

        public bool Delete(Product entity)
        {
            _db.Products.Remove(entity);
            return Save();
        }

        public ICollection<Product> FinaAll()
        {
            var Product = _db.Products.ToList();
            return Product;
        }

        public Product FindById(int id)
        {
            var Product = _db.Products.Find(id);
            return Product;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(Product entity)
        {
            _db.Products.Update(entity);
            return Save();
        }
    }
}
