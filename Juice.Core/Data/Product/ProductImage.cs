using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Juice.Core.Data.Product
{
    public class ProductImage
    {
        public ProductImage()
        {
        }

        [Key]
        public long ID { get; set; }

        public string ImagePath { get; set; }

        [ForeignKey("Product")]
        public long ProductID { get; set; }

        public virtual Product Product { get; set; }
    }
}
