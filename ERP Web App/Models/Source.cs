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
        [Column(TypeName = "Date")]
        [DisplayFormat(DataFormatString = "{0:dd MMM, yyyy}")]
        [Display(Name = "Source Date")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Source Name")]
        public string SourceName { get; set; }

        [RegularExpression("[0-9]*")]
        [Display(Name = "Lot No.")]
        public string LotNo { get; set; }

        [Required]
        public string RAM { get; set; }

        [Required]
        public string ROM { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        [Display(Name = "IMEI 1")]
        [StringLength(20)]
        [RegularExpression("[0-9]*")]
        public string IMEI { get; set; }
        
        [Display(Name = "IMEI 2")]
        [RegularExpression("[0-9]*")]
        [StringLength(20)]
        public string IMEI2 { get; set; }

        [Required]
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; } = true;

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        
        [Display(Name = "Created On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy hh:mm:ss tt}")]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        
        [Display(Name = "Updated By")]
        public string UpdatedBy { get; set; }
        
        [Display(Name = "Updated On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy hh:mm:ss tt}")]
        public DateTime? UpdatedOn { get; set; } = null;

        // Foreign key to Brand
        [ForeignKey("BrandMaster")]
        [Display(Name = "Brand Name")]
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }
        // Foreign key to Model
        [ForeignKey("ModelMaster")]
        [Display(Name = "Model Name")]
        public int ModelId { get; set; }
        public virtual Model Model { get; set; }
    }
}
