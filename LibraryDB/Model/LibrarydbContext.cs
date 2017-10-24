using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LibraryDB.Model
{
    public partial class LibrarydbContext : DbContext
    {
        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Library> Library { get; set; }
        public virtual DbSet<Loan> Loan { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DKO-S010A-006\SQLEXPRESS;Initial Catalog=librarydb;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasOne(d => d.Library)
                    .WithMany(p => p.Book)
                    .HasForeignKey(d => d.LibraryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Book_Library");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasOne(d => d.Library)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.LibraryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_Library");
            });

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Loan)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Loan_Book");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Loan)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Loan_Customer");

                entity.HasOne(d => d.Library)
                    .WithMany(p => p.Loan)
                    .HasForeignKey(d => d.LibraryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Loan_Library");
            });
        }
    }
}
