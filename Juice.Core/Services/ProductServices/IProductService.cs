using Juice.Core.Data.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juice.Core.Services.ProductServices
{
    public interface IProductService : IServices<Product>
    {
        List<Product> GetProducts();
        Product GetProduct(long id);
        Product GetProduct(string productCode);
        void InsertProduct(Product p);
        void DeleteProduct(long id);
        void UpdateProduct(Product p);
        void Save();
    }
}
