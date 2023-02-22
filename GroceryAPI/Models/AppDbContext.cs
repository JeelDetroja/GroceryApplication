using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GroceryAPI.Models
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> JdTblProduct { get; set; }
        public virtual DbSet<ProductCategory> JdTblProductCategory { get; set; }
        public virtual DbSet<User> JdTblUser { get; set; }
        public virtual DbSet<UserTypes> JdTblUserType { get; set; }
        public virtual DbSet<CartItem> JdTblCartItem { get; set; }
        public virtual DbSet<Order> JdTblOrder { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=192.168.100.24;Database=ContisTraineeLab;Trusted_Connection=True;");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.ToTable("JD_tblProduct");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.IsActivated).HasColumnName("isActivated");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ProductPhotoPath)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ProductPrice).HasColumnType("money");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.JdTblProductCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JD_tblProduct_JD_tblUser");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.JdTblProductUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JD_tblProduct_JD_tblUser1");
            });

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.HasKey(e => e.CartItemId);

                entity.ToTable("JD_tblCartItem");

                entity.Property(e => e.CreatedOn)
                   .HasColumnType("datetime")
                   .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                //entity.HasOne(d => d.CreatedByNavigation)
                //    .WithMany(p => p.JdTblCartItemCreatedByNavigation)
                //    .HasForeignKey(d => d.CreatedBy)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_JD_tblCartItem_JD_User");

                //entity.HasOne(d => d.UpdatedByNavigation)
                //    .WithMany(p => p.JdTblCartItemUpdatedByNavigation)
                //    .HasForeignKey(d => d.UpdatedBy)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_JD_tblCartItem_JD_tblUser1");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.ToTable("JD_tblOrder");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FK_JD_tblOrder_JD_tblUser)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JD_tblOrder_JD_tblUser");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasKey(e => e.ProductCategoryId);

                entity.ToTable("JD_tblProductCategory");

                entity.HasIndex(e => e.ProductCategoryName)
                    .HasName("IX_JD_tblProductCategory")
                    .IsUnique();

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActivated).HasColumnName("isActivated");

                entity.Property(e => e.ProductCategoryName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.CreationByNavigation)
                    .WithMany(p => p.JdTblProductCategoryCreationByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JD_tblProductCategory_JD_tblUser");

                entity.HasOne(d => d.UpdationByNavigation)
                    .WithMany(p => p.JdTblProductCategoryUpdationByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JD_tblProductCategory_JD_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("JD_tblUser");

                entity.HasIndex(e => e.UserEmail)
                    .HasName("IX_JD_tblUser")
                    .IsUnique();

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActivated).HasColumnName("isActivated");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserDob)
                    .HasColumnName("UserDOB")
                    .HasColumnType("date");

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.UserMobileNo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.JdTblUser)
                    .HasForeignKey(d => d.UserTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JD_tblUser_JD_tblUserType");
            });

            modelBuilder.Entity<UserTypes>(entity =>
            {
                entity.HasKey(e => e.UserTypeId);

                entity.ToTable("JD_tblUserType");

                entity.HasIndex(e => e.UserType)
                    .HasName("IX_JD_tblUserType")
                    .IsUnique();

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActivated).HasColumnName("isActivated");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserType)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
