namespace rushMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Form_Template
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Form_Template()
        {
            Form_Assignment = new HashSet<Form_Assignment>();
        }

        [Key]
        public int Form_ID { get; set; }

        [StringLength(50)]
        public string Form_Desc { get; set; }

        public int? Question_ID { get; set; }

        public int? Assignment_ID { get; set; }

        public bool? Active { get; set; }

        public virtual Assignment Assignment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Form_Assignment> Form_Assignment { get; set; }

        public virtual Question Question { get; set; }
    }
}
