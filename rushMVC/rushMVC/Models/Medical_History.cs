namespace rushMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Medical_History
    {
        [Key]
        public int Medical_ID { get; set; }

        public int Patient_ID { get; set; }

        [StringLength(100)]
        public string DESCRIPTION { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DATE_TIME { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
