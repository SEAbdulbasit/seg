using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace seg_1.Models
{
    public class distributor
    {
        [Key]
        [Display(Name = "ID")]
        public int distributor_id { get; set; }
        [Display(Name = "Name")]
        public string distributor_name { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string distributor_password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("distributor_password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Address")]
        public string distributor_address { get; set; }
        [Display(Name = "Mobile No")]
        public string distribbutor_mobile_no { get; set; }
        [Display(Name = "Email")]
        public string distributor_email { get; set; }
        [Display(Name = "Start Date")]
        public DateTime distributior_start_date { get; set; }

        public virtual ICollection<distribution> distribution { get; set; }
        public virtual ICollection<regional_manager> regional_manger { get; set; }
        public virtual ICollection<order> order { get; set; }
        public virtual ICollection<communication> communication { get; set; }


    }
}