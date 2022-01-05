using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_Web_App.DTOs
{
    public class BrandDto
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public bool IsActive { get; set; }
    }
}
