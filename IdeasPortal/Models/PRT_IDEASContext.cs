using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IdeasPortal.Models
{
    public partial class PRT_IDEASContext : DbContext
    {
        public PRT_IDEASContext()
        {
        }

        public PRT_IDEASContext(DbContextOptions<PRT_IDEASContext> options)
            : base(options)
        {
        }

        public virtual DbSet<IdeaBox> IdeaBoxes { get; set; } = null!;
        public virtual DbSet<IdeaBoxLike> IdeaBoxLikes { get; set; } = null!;
        public virtual DbSet<Userdetail> Userdetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=PRT_IDEAS;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdeaBox>(entity =>
            {
                entity.HasKey(e => e.IdeaId)
                    .HasName("PK__IdeaBox__CABD58306F087319");

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

                entity.HasOne(d => d.IdeaUser)
                    .WithMany(p => p.IdeaBoxes)
                    .HasForeignKey(d => d.IdeaUserid)
                    .HasConstraintName("FK_IdeaBox");
            });

            modelBuilder.Entity<IdeaBoxLike>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("IdeaBox_likes");

                entity.Property(e => e.IdeaId).HasColumnName("idea_ID");

                entity.Property(e => e.IsLiked).HasColumnName("is_liked");

                entity.Property(e => e.Userid).HasColumnName("USERID");

                entity.HasOne(d => d.Idea)
                    .WithMany()
                    .HasForeignKey(d => d.IdeaId)
                    .HasConstraintName("FK__IdeaBox_l__idea___29572725");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("FK__IdeaBox_l__USERI__2A4B4B5E");
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
