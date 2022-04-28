using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Ideas.WebApi.Models
{
    public partial class PRT_IDEAsContext : DbContext
    {
        public PRT_IDEAsContext()
        {
        }

        public PRT_IDEAsContext(DbContextOptions<PRT_IDEAsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<IdeaBox> IdeaBoxes { get; set; } = null!;
        public virtual DbSet<Userdetail> Userdetails { get; set; } = null!;

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //                optionsBuilder.UseSqlServer("Server=DESKTOP-CH1ORDD;Database=PRT_IDEAs;Trusted_Connection=True;");
        //            }
        //        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdeaBox>(entity =>
            {
                entity.HasKey(e => e.IdeaId)
                    .HasName("PK__IdeaBox__CABD5830DA966EB4");

                entity.ToTable("IdeaBox");

                entity.Property(e => e.IdeaId).HasColumnName("idea_ID");

                entity.Property(e => e.IdeaMesaage)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("idea_mesaage");

                entity.Property(e => e.IdeaPosteddate)
                    .HasColumnType("datetime")
                    .HasColumnName("idea_posteddate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdeaTag)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("idea_tag");

                entity.Property(e => e.IdeaUserid).HasColumnName("idea_Userid");

                entity.Property(e => e.Liked).HasColumnName("liked");
            });

            modelBuilder.Entity<Userdetail>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("PK__USERDETA__7B9E7F35E1C65CE4");

                entity.ToTable("USERDETAILS");

                entity.Property(e => e.Userid).HasColumnName("USERID");

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USER_password");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
