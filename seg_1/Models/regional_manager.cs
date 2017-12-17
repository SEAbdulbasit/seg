using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace seg_1.Models
{
    public class regional_manager
    {
        [Key]
        [Dispaly(Name ="ID")]
        public int regional_manager_id { get; set; }
        [Dispaly(Name ="Name")]
        public string regional_manager_name { get; set; }
        [Dispaly(Name ="Password")]
        public string regional_manager_password { get; set; }
        [Dispaly(Name ="Mobile Number")]
        public string regional_manager_mobile_no { get; set; }
        [Dispaly(Name = "Email")]
        public string regional_manager_email { get; set; }
        [Dispaly(Name = "Start Date")]
        public DateTime regional_manager_start_date { get; set; }

        public virtual distribution distributor { get; set; }
        [Dispaly(Name ="Distributor")]
        public int distributor_id { get; set; }



    }
}