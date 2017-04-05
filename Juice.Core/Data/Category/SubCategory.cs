using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Juice.Core.Data.Category
{
    public class SubCategory
    {
        public SubCategory()
        {
        }

        [Key]
        public long ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        [ForeignKey("Category")]
        public long CategoryID { get; set; }

        public virtual Category Category { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

    }
}
