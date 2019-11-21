using BlazingShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BlazingShop.Services
{
    public class ProductService
    {
        private readonly ApplicationDbContext _db;

        public ProductService(ApplicationDbContext db)
        {
            _db = db;
        }

        public Product GetProduct(int ProductId)
        {
            Product obj = new Product();
            return _db.Products.Include(p => p.Category).FirstOrDefault(c => c.Id == ProductId);
        }

        public List<Product> GetProducts()
        {
            return _db.Products.Include(p => p.Category).ToList();
        }

        public List<Category> GetCategoryList()
        {
            return _db.Categories.ToList();
        }

        public bool CreateProduct(Product objProduct)
        {
            _db.Products.Add(objProduct);
            _db.SaveChanges();
            return true;
        }
        public bool UpdateProduct(Product objProduct)
        {
            Product ExistingProduct = _db.Products.FirstOrDefault(c => c.Id == objProduct.Id);

            if(ExistingProduct != null)
            {
                if(objProduct.Image == null)
                {
                    objProduct.Image = ExistingProduct.Image;
                }
                _db.Products.Update(objProduct);
                _db.SaveChanges();
            }
            else
            {
                return false;
            }

            return true;
        }

        public bool DeleteProduct(Product objProduct)
        {
            Product existingProduct = _db.Products.FirstOrDefault(c => c.Id == objProduct.Id);

            if (existingProduct != null)
            {
                _db.Products.Remove(objProduct);
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
