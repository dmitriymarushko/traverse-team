namespace Juice.Core.Services.ProductServices
{
    using Data.Product;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class ProductService : IProductService
    {
        private IDBContext _context;
        private DbSet<Product> _products;

        public ProductService(IDBContext context)
        {
            this._context = context;
            this._products = this._context.Set<Product>();
        }
        public List<Product> GetProducts()
        {
            return this._products
                .Include(p => p.Brand)
                .Include(p => p.SubCategory)
                .ToList();
        }
        public Product GetProduct(string productCode)
        {
            return this._products
                .Where(x => x.ProductCode == productCode).FirstOrDefault();
        }
        public Product GetProduct(long productId)
        {
            return this._products
                .Where(x => x.ID == productId).FirstOrDefault();
        }
        public void InsertProduct(Product product)
        {
            this._products.Add(product);
        }
        public void DeleteProduct(long productId)
        {
            var product = this._products.Find(productId);
            this._products.Remove(product);
        }
        public void UpdateProduct(Product product)
        {
            this._context.Entry(product).State = EntityState.Modified;
        }
        public void Save()
        {
            this._context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this._context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
