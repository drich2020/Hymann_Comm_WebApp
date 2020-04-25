using Hyman_Communication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hyman_Communication.Repository
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly ApplicationDbContext _db;

        public DocumentRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(Document entity)
        {
            _db.Documents.Add(entity);
            return Save();
        }

        public bool Delete(Document entity)
        {
            _db.Documents.Remove(entity);
            return Save();
        }

        public ICollection<Document> FinaAll()
        {
            var documents = _db.Documents.ToList();
            return documents;
        }

        public Document FindById(int id)
        {
            var documents = _db.Documents.Find(id);
            return documents;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(Document entity)
        {
            _db.Documents.Update(entity);
            return Save();
        }
    }
}
