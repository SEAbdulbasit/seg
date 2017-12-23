using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace seg_1.Models
{
    public class batch
    {
        [Key]
        [DisplayName("ID")]
        public int batch_id { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Arrival Date & Time")]
        public DateTime medicine_arrival_date { get; set; }

        [DataType(DataType.Date)]

        [DisplayName("Expiry Date")]
        public DateTime medicine_expiry_date { get; set; }

        public virtual medicine medicine { get; set; }
        public int medicine_id { get; set; }

}
    }
