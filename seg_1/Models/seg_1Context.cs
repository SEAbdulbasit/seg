using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace seg_1.Models
{
    public class seg_1Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public seg_1Context() : base("name=seg_1Context")
        {
        }

        public System.Data.Entity.DbSet<seg_1.Models.shopkeeper> shopkeepers { get; set; }

        public System.Data.Entity.DbSet<seg_1.Models.shop> shops { get; set; }

        public System.Data.Entity.DbSet<seg_1.Models.distributor> distributors { get; set; }

        public System.Data.Entity.DbSet<seg_1.Models.distribution> distributions { get; set; }

        public System.Data.Entity.DbSet<seg_1.Models.regional_manager> regional_manager { get; set; }

        public System.Data.Entity.DbSet<seg_1.Models.salesman> salesmen { get; set; }

        public System.Data.Entity.DbSet<seg_1.Models.sales> sales { get; set; }

        public System.Data.Entity.DbSet<seg_1.Models.medicine> medicines { get; set; }

        public System.Data.Entity.DbSet<seg_1.Models.batch> batches { get; set; }

        public System.Data.Entity.DbSet<seg_1.Models.medicine_line> medicine_line { get; set; }

        public System.Data.Entity.DbSet<seg_1.Models.threashold> threasholds { get; set; }

        public System.Data.Entity.DbSet<seg_1.Models.communication> communications { get; set; }

        public System.Data.Entity.DbSet<seg_1.Models.order> orders { get; set; }

        public System.Data.Entity.DbSet<seg_1.Models.order_quantity> order_quantity { get; set; }
    }
}
