using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Juice.Core.Data.Category
{
    public class Category
    {
        private ICollection<SubCategory> _subcategory;

        public Category()
        {
        }

        [Key]
        public long ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<SubCategory> SubCategories
        {
            get { return _subcategory ?? (_subcategory = new List<SubCategory>()); }
            protected set { _subcategory = value; }
        }
    }
}
