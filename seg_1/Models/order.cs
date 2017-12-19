using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace seg_1.Models
{
    public class order
    {
        [Key]
        [DisplayName("Order ID")]
        public int order_id { get; set; }

        [DisplayName("Distributor ID")]
        public int distributor_id { get; set; }

        [DisplayName("Shopkeeper ID")]
        public int shopkeeper_id { get; set; }

        [DisplayName("Order Status")]
        public bool order_status { get; set; }

        [DisplayName("Order Date")]
        public DateTime order_date { get; set; }

        public virtual shopkeeper shopkeeper { get; set; }
        public virtual distributor distributor { get; set; }






    }
}