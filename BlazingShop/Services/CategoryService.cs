using BlazingShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingShop.Services
{
    public class CategoryService
    {
        private readonly ApplicationDbContext _db;

        public CategoryService(ApplicationDbContext db)
        {
            _db = db;
        }

        public Category GetCategory(int categoryId)
        {
            Category obj = new Category();
            return _db.Categories.FirstOrDefault(c => c.Id == categoryId);
        }

        public List<Category> GetCategories()
        {
            return _db.Categories.ToList();
        }
        public bool CreateCategory(Category objCategory)
        {
            _db.Categories.Add(objCategory);
            _db.SaveChanges();
            return true;
        }
        public bool UpdateCategory(Category objCategory)
        {
            Category ExistingCategory = _db.Categories.FirstOrDefault(c => c.Id == objCategory.Id);

            if(ExistingCategory != null)
            {
                ExistingCategory.Name = objCategory.Name;
                _db.SaveChanges();
            }
            else
            {
                return false;
            }

            return true;
        }

        public bool DeleteCategory(Category objCategory)
        {
            Category existingCategory = _db.Categories.FirstOrDefault(c => c.Id == objCategory.Id);

            if (existingCategory != null)
            {
                _db.Categories.Remove(objCategory);
                _db.SaveChanges();
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}
