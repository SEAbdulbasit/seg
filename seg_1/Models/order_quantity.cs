using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace seg_1.Models
{
    public class order_quantity
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("order")]
        [DisplayName("order ID")]
        public int order_id { get; set; }


        [Key]
        [Column(Order = 2)]
        [ForeignKey("medicine")]
        [DisplayName("Medicine ID")]
        public int medicine_id { get; set; }

        

        [DisplayName("Order Quantity")]
        public int order_quantityy { get; set; }




        public virtual ICollection<medicine> medicine { set; get; }
        public virtual ICollection<order> order { set; get; }


    }
}