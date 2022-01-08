using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_Web_App.Models
{
    public class Brand
    {
        [Key]
        [Display(Name = "Brand ID")]
        public int BrandId { get; set; }
        [Required]
        [Display(Name = "Brand Name")]
        public string BrandName { get; set; }
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
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy hh:mm:ss tt}")]
        [Display(Name = "Updated On")]
        public DateTime? UpdatedOn { get; set; } = null;
    }
}
