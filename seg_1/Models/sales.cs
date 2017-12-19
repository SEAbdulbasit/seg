using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace seg_1.Models
{
    public class sales
    {
        [Key]
        [Required]
        [Display(Name = "Sale ID")]
        public int sales_id { get; set; }
        [Required]
        [Display(Name = "Date")]
        public DateTime sales_date { get; set; }

        [Display(Name = "Sale Amount")]
        public int sales_total_amount { get; set; }

        public virtual salesman salesman { get;  set; }
        [Dispaly(Name ="Salesman ID")]
        [ForeignKey("salesman")]
        public int salesman_id { get; set; } // 1 salesman can have many sales
        public virtual ICollection<medicine_line> medicineline { get; set; }

    }
}