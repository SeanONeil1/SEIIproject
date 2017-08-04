namespace rushMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Question
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Question()
        {
            Form_Assignment = new HashSet<Form_Assignment>();
            Form_Template = new HashSet<Form_Template>();
        }

        [Key]
        public int Question_ID { get; set; }

        [Column("Question")]
        [StringLength(50)]
        public string Question1 { get; set; }

        public int Type { get; set; }

        [Required]
        [StringLength(50)]
        public string Input_Option { get; set; }

        public bool? Active { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Form_Assignment> Form_Assignment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Form_Template> Form_Template { get; set; }

        public virtual Input_Type Input_Type { get; set; }
    }
}
