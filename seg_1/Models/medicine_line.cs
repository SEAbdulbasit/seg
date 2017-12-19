using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace seg_1.Models
{
    public class medicine_line
    {
        [Key]
        public int medicine_line_id { get; set; }

        public virtual sales sales { get; set; }
        [ForeignKey("sales")]
        public int sales_id { get; set; }

        public virtual medicine medicine { get; set; }
        [ForeignKey("medicine")]
        public int medicine_id { get; set; }

    }
}