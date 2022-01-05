using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_Web_App.Models
{
    public class Source
    {
        [Key]
        public long SourceId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        [Display(Name = "Source Name")]
        public string SourceName { get; set; }
        [Required]
        [Display(Name = "Lot No.")]
        public string LotNo { get; set; }
        [Required]
        public string RAM { get; set; }
        [Required]
        public string ROM { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public string IMEI { get; set; }
        public string IMEI2 { get; set; }
        [Required]
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        [Required]
        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        [Display(Name = "Updated By")]
        public string UpdatedBy { get; set; }
        [Display(Name = "Updated On")]
        public DateTime UpdatedOn { get; set; }

        // Foreign key to Brand
        [ForeignKey("BrandMaster")]
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }
        // Foreign key to Model
        [ForeignKey("ModelMaster")]
        public int ModelId { get; set; }
        public virtual Model Model { get; set; }
    }
}
