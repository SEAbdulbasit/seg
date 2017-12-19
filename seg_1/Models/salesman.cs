using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace seg_1.Models
{
    public class salesman
    {
        [Key]
        [DisplayName("ID")]
        public int salesman_id { get; set; }

        [DisplayName("Name")]
        public string salesman_name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string saleman_password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("shopkeeper_password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [DisplayName("Address")]
        public string salesman_address { get; set; }

        [DisplayName("Mobile Number")]
        public string  salesman_mobile_num { get; set; }

        [DisplayName("Email")]
        public string salesman_email { get; set; }

        [DisplayName("Start Date")]
        public DateTime salesman_start_date { get; set; }

        public virtual shopkeeper shopkeeper { get; set; } //for 1 to many relation with shopkeeper
        public virtual ICollection<sales> sales { get; set; }// for 1 t0 many relation with sales

        [DisplayName("Shopkeeper ID")]
        [ForeignKey("shopkeeper")]
        public int shopkeeper_id { get; set; }

    }
}