using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace workorder.Models
{
    public partial class testdbContext : DbContext
    {
        public testdbContext()
        {
        }

        public testdbContext(DbContextOptions<testdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employeedetail> Employeedetails { get; set; } = null!;
        public virtual DbSet<TechnicianTb> TechnicianTbs { get; set; } = null!;
        public virtual DbSet<WorkTb> WorkTbs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=RAMKI\\SQLSERVER;Database=testdb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employeedetail>(entity =>
            {
                entity.ToTable("employeedetails");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .HasColumnName("address");

                entity.Property(e => e.Employee)
                    .HasMaxLength(50)
                    .HasColumnName("employee");
            });

            modelBuilder.Entity<TechnicianTb>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("technician_tb");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.TId)
                    .ValueGeneratedNever()
                    .HasColumnName("t_id")
                    .HasComment("1 as active,0 as iactive");

                entity.Property(e => e.TStatus)
                    .ValueGeneratedNever()
                    .HasColumnName("t_status")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<WorkTb>(entity =>
            {
                entity.HasKey(e => e.WorkId);

                entity.ToTable("work_tb");

                entity.Property(e => e.WorkId)
                    .ValueGeneratedNever()
                    .HasColumnName("work_id");

                entity.Property(e => e.DateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("date_time");

                entity.Property(e => e.Place)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("place");

                entity.Property(e => e.TechicianRegisterno)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("techician_registerno");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
