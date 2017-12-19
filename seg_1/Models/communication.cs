using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace seg_1.Models
{
    public class communication
    {
        [Key]
        [DisplayName("communication ID")]
        public int communication_id { get; set; }

        [ForeignKey("distributor")]
        [DisplayName("Distributor ID")]
        public int distributor_id { get; set; }

        [ForeignKey("shopkeeper")]
        [DisplayName("Shopkeeper ID")]
        public int shopkeeper_id { get; set; }


        [DisplayName("Message")]
        public string message { get; set; }

        [DisplayName("Status")]
        public bool msg_status { get; set; }

        [DisplayName("Time & Date")]
        public DateTime send_time { get; set; }


        public virtual distributor distributor { get; set; }
        public virtual shopkeeper shopkeeper { get; set; }



    }
}