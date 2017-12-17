using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace seg_1.Models
{
    public class distributor
    {

        [Display(Name = "ID")]
        public int distributor_id { get; set; }
        [Display(Name = "Name")]
        public string distributor_name { get; set; }
        [Display(Name = "Password")]
        public string distributor_password { get; set; }
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


    }
}