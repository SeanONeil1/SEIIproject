namespace rushMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Form_Assignment
    {
        [Key]
        public int Form_Assingment_ID { get; set; }

        public int User_ID { get; set; }

        public int Form_ID { get; set; }

        public int Question_ID { get; set; }

        public int Patient_ID { get; set; }

        [StringLength(50)]
        public string Answer { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] Date_Time { get; set; }

        public bool? ACTIVE { get; set; }

        public virtual Form_Template Form_Template { get; set; }

        public virtual Patient Patient { get; set; }

        public virtual Question Question { get; set; }

        public virtual User User { get; set; }
    }
}
