namespace rushMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Patient")]
    public partial class Patient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Patient()
        {
            Form_Assignment = new HashSet<Form_Assignment>();
            Medical_History = new HashSet<Medical_History>();
        }

        [Key]
        public int Patient_Id { get; set; }

        [Required]
        [StringLength(30)]
        public string First_Name { get; set; }

        [Required]
        [StringLength(30)]
        public string Last_Name { get; set; }

        [StringLength(255)]
        public string Middle_Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date_Of_Birth { get; set; }

        [StringLength(1)]
        public string Gender { get; set; }

        [StringLength(20)]
        public string Phone_Number { get; set; }

        [StringLength(100)]
        public string Condition { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Form_Assignment> Form_Assignment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Medical_History> Medical_History { get; set; }
    }
}
