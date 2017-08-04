namespace rushMVC.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Therapy")
        {
        }

        public virtual DbSet<Assignment> Assignments { get; set; }
        public virtual DbSet<Form_Assignment> Form_Assignment { get; set; }
        public virtual DbSet<Form_Template> Form_Template { get; set; }
        public virtual DbSet<Input_Type> Input_Type { get; set; }
        public virtual DbSet<Medical_History> Medical_History { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assignment>()
                .Property(e => e.Assignment_Desc)
                .IsUnicode(false);

            modelBuilder.Entity<Assignment>()
                .HasMany(e => e.Form_Template)
                .WithOptional(e => e.Assignment)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Form_Assignment>()
                .Property(e => e.Answer)
                .IsUnicode(false);

            modelBuilder.Entity<Form_Assignment>()
                .Property(e => e.Date_Time)
                .IsFixedLength();

            modelBuilder.Entity<Form_Template>()
                .Property(e => e.Form_Desc)
                .IsUnicode(false);

            modelBuilder.Entity<Input_Type>()
                .Property(e => e.Input_Type_Desc)
                .IsUnicode(false);

            modelBuilder.Entity<Medical_History>()
                .Property(e => e.DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.First_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.Last_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.Middle_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.Gender)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.Phone_Number)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.Condition)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .HasMany(e => e.Form_Assignment)
                .WithRequired(e => e.Patient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Question>()
                .Property(e => e.Question1)
                .IsUnicode(false);

            modelBuilder.Entity<Question>()
                .Property(e => e.Input_Option)
                .IsUnicode(false);

            modelBuilder.Entity<Question>()
                .HasMany(e => e.Form_Assignment)
                .WithRequired(e => e.Question)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Question>()
                .HasMany(e => e.Form_Template)
                .WithOptional(e => e.Question)
                .WillCascadeOnDelete();

            modelBuilder.Entity<User>()
                .Property(e => e.User_Name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.First_Name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Last_Name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Course_Number)
                .IsUnicode(false);
        }
    }
}
