namespace rushMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Form_Assignment = new HashSet<Form_Assignment>();
        }

        [Required]
        [StringLength(50)]
        public string User_Name { get; set; }

        [Key]
        public int User_ID { get; set; }

        [Required]
        [StringLength(30)]
        public string First_Name { get; set; }

        [Required]
        [StringLength(30)]
        public string Last_Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        public bool? Admin { get; set; }

        public bool? Password_Reset { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Course_Number { get; set; }

        public bool? Active { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Form_Assignment> Form_Assignment { get; set; }
    }
}
