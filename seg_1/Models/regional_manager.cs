using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace seg_1.Models
{
    public class regional_manager
    {
        [Key]
        [DisplayName ("ID")]
        public int regional_manager_id { get; set; }

        [DisplayName("Name")]
        public string regional_manager_name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [DisplayName("Passowrd")]
        public string regional_manager_password { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Confirm Password")]
        [Compare("regional_manager_password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [DisplayName("Mobile Number")]
        public string regional_manager_mobile_no { get; set; }

        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        public string regional_manager_email { get; set; }
        [DisplayName("Starting Date")]
        public DateTime regional_manager_start_date { get; set; }

        public virtual distribution distributor { get; set; }
        [DisplayName("Distributor ID")]

        public int distributor_id { get; set; }



    }
}