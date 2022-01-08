using Microsoft.AspNetCore.Mvc;
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
    }
}
