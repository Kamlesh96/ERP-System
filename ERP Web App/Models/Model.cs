using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_Web_App.Models
{
    public class Model
    {
        [Key]
        [Display(Name = "Model ID")]
        public long ModelId { get; set; }
        [Required]
        [Display(Name = "Model Name")]
        public string ModelName { get; set; }
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
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
    }
}
