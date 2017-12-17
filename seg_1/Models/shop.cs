using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace seg_1.Models
{
    public class shop
    {
        [Key]

        [Display(Name ="ID")]
        public int shop_id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string shop_name { get; set; }
        [Display(Name = "Address")]
        public string shop_address { get; set; }
        [Display(Name = "Mobile Number")]
        public string shop_mobile_num { get; set; }

        public virtual shopkeeper shopkeeper { get; set; }
        [Display(Name = "Shop ID")]
        public int shopkeeper_id { get; set; }

    }
}