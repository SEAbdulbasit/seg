using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace seg_1.Models
{
    public class shopkeeper
    {
       
        [Key]
        [Required]
        [Display(Name ="Shopkeeper ID")]
        public int shopkeeper_id  { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string shopkeeper_name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string shopkeeper_password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("shopkeeper_password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }


        [Display(Name = "Address")]
        public string shopkeeper_address { get; set; }
        [Display(Name = "Mobile No")]
        public string shopkeeper_mobile_no { get; set; }
        [Display(Name = "Email")]
        public string shopeeper_email { get; set; }
        [Display(Name = "Shop Start Date")]
        public DateTime shop_start_date { get; set; }

        public virtual ICollection<shop> shop { get; set; }
        public virtual ICollection<salesman> salesman { get; set; }
        public virtual ICollection<order> order { get; set; }
        public virtual ICollection<communication> communication { get; set; }

    }

}