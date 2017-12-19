using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace seg_1.Models
{
    public class threashold
    {
        [Key]
        [ForeignKey("medicine")]
        public int medicine_id { get; set; }

        [DisplayName("Current Quantity")]
        public int medicine_quantity { get; set; }

        [DisplayName("Threashold Quantity")]
        public int medicine_threashold_quantity { get; set; }

        public virtual medicine medicine { get; set; }
    }
}