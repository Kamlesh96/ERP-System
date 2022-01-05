using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_Web_App.DTOs
{
    public class SourceDto
    {
        public long SourceId { get; set; }
        public DateTime Date { get; set; }
        public string SourceName { get; set; }
        public string LotNo { get; set; }
        public string RAM { get; set; }
        public string ROM { get; set; }
        public string Color { get; set; }
        public string IMEI { get; set; }
        public string IMEI2 { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }

        // Foreign key to Brand
        public int BrandId { get; set; }
        //public virtual Brand Brand { get; set; }
        // Foreign key to Model
        public int ModelId { get; set; }
        //public virtual Model Model { get; set; }
    }
}
