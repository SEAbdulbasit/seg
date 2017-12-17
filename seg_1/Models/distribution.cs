using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace seg_1.Models
{
    public class distribution
    {
        [Key]
        [Display(Name ="ID") ]
        public int distribution_id { get; set; }
        [Display(Name ="Name")]
        public string distribution_name { get; set; }
        [Display(Name ="Distribution Address")]
        public string distribution_address { get; set; }

        public virtual distributor distributor { get; set; }
        public int distributor_id { get; set; }

    }
}