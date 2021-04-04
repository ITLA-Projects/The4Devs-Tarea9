using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace homework9.Models
{
    public partial class bnbrrzrnk96lt9i9njkrContext : DbContext
    {
        public bnbrrzrnk96lt9i9njkrContext()
        {
        }

        public bnbrrzrnk96lt9i9njkrContext(DbContextOptions<bnbrrzrnk96lt9i9njkrContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Applicants> Applicants { get; set; }
        public virtual DbSet<Bloods> Bloods { get; set; }
        public virtual DbSet<Provinces> Provinces { get; set; }
        public virtual DbSet<Requests> Requests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=bnbrrzrnk96lt9i9njkr-mysql.services.clever-cloud.com;uid=umb1v5nfyhasjarf;pwd=NvI04PbceAu7uCKFR5Wj;database=bnbrrzrnk96lt9i9njkr", x => x.ServerVersion("8.0.22-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Applicants>(entity =>
            {
                entity.HasIndex(e => e.BloodId)
                    .HasName("blood_id");

                entity.HasIndex(e => e.Cedula)
                    .HasName("cedula")
                    .IsUnique();

                entity.HasIndex(e => e.Email)
                    .HasName("email")
                    .IsUnique();

                entity.HasIndex(e => e.RequestId)
                    .HasName("request_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BirthDate)
                    .HasColumnName("birth_date")
                    .HasColumnType("date");

                entity.Property(e => e.BloodId).HasColumnName("blood_id");

                entity.Property(e => e.Cedula)
                    .IsRequired()
                    .HasColumnName("cedula")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Covid19Flag).HasColumnName("covid19_flag");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(25)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RequestId).HasColumnName("request_id");

                entity.HasOne(d => d.Blood)
                    .WithMany(p => p.Applicants)
                    .HasForeignKey(d => d.BloodId)
                    .HasConstraintName("Applicants_ibfk_1");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.Applicants)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("Applicants_ibfk_3");
            });

            modelBuilder.Entity<Bloods>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(5)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Provinces>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Requests>(entity =>
            {
                entity.HasIndex(e => e.ApplicantId)
                    .HasName("applicant_id");

                entity.HasIndex(e => e.ProvinceId)
                    .HasName("province_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasColumnType("varchar(500)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ApplicantId).HasColumnName("applicant_id");

                entity.Property(e => e.Latitude)
                    .HasColumnName("latitude")
                    .HasColumnType("decimal(15,12)");

                entity.Property(e => e.Longitude)
                    .HasColumnName("longitude")
                    .HasColumnType("decimal(15,12)");

                entity.Property(e => e.ProvinceId).HasColumnName("province_id");

                entity.Property(e => e.WrittenRequest)
                    .IsRequired()
                    .HasColumnName("written_request")
                    .HasColumnType("varchar(3000)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Applicant)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.ApplicantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Requests_ibfk_2");

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.ProvinceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Requests_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
