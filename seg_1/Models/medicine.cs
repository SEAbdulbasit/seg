using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace seg_1.Models
{
    public class medicine
    {
        [Key]
        [DisplayName("ID")]
        public int medicine_id { get; set; }

        [DisplayName("Name")]
        public string medicine_name { get; set; }

        [DisplayName("Description")]
        public string medicine_description { get; set; }

        [DisplayName("Purchase Price")]
        public int medicine_purchasee_price { get; set; }

        [DisplayName("saling Price")]
        public int medicine_siling_price { get; set; }

        [DisplayName("Dose")]
        public string medicine_dose { get; set; }

        public virtual ICollection<medicine_line> medicineline { get; set; }
        public virtual ICollection<batch> batch { get; set; }
        public virtual threashold threashold { get; set; }        
        public virtual order_quantity order_quantity { get; set; }

    }
}