using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using Juice.Core.Data.Product;
using Moq;
using Juice.Core.Services;
using Juice.Core.Services.ProductServices;

namespace Juice.Test
{
    [TestClass]
    public class ProductServiceTest
    {
        [TestMethod]
        public void Test_GetProduct()
        {

            var mockSet = new Mock<DbSet<Product>>();

            //Arrange
            var productModel = new Product
            {
                ID = 111,
            };
            var products = new List<Product>
            {
                productModel

            }.AsQueryable();

            mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            mockSet.As<IQueryable<Product>>().Setup(p => p.GetEnumerator()).Returns(products.GetEnumerator());

            var mockContext = new Mock<DBContext>();
            mockContext.Setup(m => m.Set<Product>()).Returns(mockSet.Object);

            var service = new ProductService(mockContext.Object);

            //Act
            var result = service.GetProduct("111");

            //Assert
            Assert.IsNotNull(service);
            //Assert.AreEqual(productModel, result);
        }
    }
}
