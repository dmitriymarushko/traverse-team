using Juice.Core.Data.Product;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Juice.Core.Data.Brands
{
    public class Brand
    {
        private ICollection<Product.Product> _product;

        public Brand()
        {
        }

        [Key]
        public long ID { get; set; }
        public string BrandName { get; set; }
        public string BrandCode { get; set; }

        [ScaffoldColumn(false)]
        public bool IsActive { get; set; }

        [ScaffoldColumn(false)]
        public bool IsDeleted { get; set; }

        public virtual ICollection<Product.Product> Products
        {
            get { return _product ?? (_product = new List<Product.Product>()); }
            protected set { _product = value; }
        }
    }
}
