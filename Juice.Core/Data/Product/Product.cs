using Juice.Core.Data.Brands;
using Juice.Core.Data.Category;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Juice.Core.Data.Product
{
    public class Product
    {
        private ICollection<ProductImage> _productImages;

        public Product()
        {
        }

        [Key]
        public long ID { get; set; }
        public string Name { get; set; }
        public string FrontImage { get; set; }
        public string ProductCode { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string Description { get; set; }

        // TODO:
        [ForeignKey("SubCategory")]
        public long SubCategoryID { get; set; }

        // TODO:
        [ForeignKey("Brand")]
        public long BrandID { get; set; }

        public virtual SubCategory SubCategory { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual ICollection<ProductImage> Images
        {
            get { return _productImages ?? (_productImages = new List<ProductImage>()); }
            protected set { _productImages = value; }
        }
    }
}
