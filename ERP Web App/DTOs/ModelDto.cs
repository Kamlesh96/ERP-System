using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_Web_App.DTOs
{
    public class ModelDto
    {
        public long ModelId { get; set; }
        public string ModelName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }

        // Foreign key to Brand
        public int BrandId { get; set; }
        //public virtual Brand Brand { get; set; }
    }
}
