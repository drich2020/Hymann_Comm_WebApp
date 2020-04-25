using Hyman_Communication.Contracts;
using Hyman_Communication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hyman_Communication.Repository
{
    public class DocumentCategoryRepository : IDocumentCategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public DocumentCategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(DocumentCategory entity)
        {
            _db.DocumentCategories.Add(entity);
            return Save();
        }

        public bool Delete(DocumentCategory entity)
        {
            _db.DocumentCategories.Remove(entity);
            return Save();
        }

        public ICollection<DocumentCategory> FinaAll()
        {
            var DocumentCategory = _db.DocumentCategories.ToList();
            return DocumentCategory;
        }

        public DocumentCategory FindById(int id)
        {
            var DocumentCategory = _db.DocumentCategories.Find(id);
            return DocumentCategory;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(DocumentCategory entity)
        {
            _db.DocumentCategories.Update(entity);
            return Save();
        }
    }
}
