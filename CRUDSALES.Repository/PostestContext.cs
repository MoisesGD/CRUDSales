using CRUDSales.Entity.Models;
using CRUDSALES.Interfaces.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDSALES.Repository
{
	public partial class PostestContext : DbContext, IPostestContext
	{
		public PostestContext()
		{
		}

		public PostestContext(DbContextOptions<PostestContext> options)
			: base(options)
		{
		}

		public virtual DbSet<Concept> Concepts { get; set; }

		public virtual DbSet<Customer> Customers { get; set; }

		public virtual DbSet<Product> Products { get; set; }

		public virtual DbSet<Sale> Sales { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
			=> optionsBuilder.UseSqlServer("Server=DESKTOP-185TVRC\\LOCALDB;Initial Catalog=POSTest;Integrated Security=True;TrustServerCertificate=True");

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Concept>(entity =>
			{
				entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");
				entity.Property(e => e.Quantity).HasColumnType("decimal(18, 0)");
				entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 0)");

				entity.HasOne(d => d.Product).WithMany(p => p.Concepts)
					.HasForeignKey(d => d.ProductId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_Concepts_Products");

				entity.HasOne(d => d.Sale).WithMany(p => p.Concepts)
					.HasForeignKey(d => d.SaleId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_Concepts_Sales");
			});

			modelBuilder.Entity<Customer>(entity =>
			{
				entity.Property(e => e.Name).HasMaxLength(50);
			});

			modelBuilder.Entity<Product>(entity =>
			{
				entity.Property(e => e.Cost).HasColumnType("decimal(18, 0)");
				entity.Property(e => e.Name)
					.HasMaxLength(50)
					.IsUnicode(false);
				entity.Property(e => e.UnitPrice).HasMaxLength(50);
			});

			modelBuilder.Entity<Sale>(entity =>
			{
				entity.Property(e => e.Date).HasColumnType("datetime");
				entity.Property(e => e.Total).HasColumnType("decimal(18, 0)");

				entity.HasOne(d => d.Customer).WithMany(p => p.Sales)
					.HasForeignKey(d => d.CustomerId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_Sales_Customers");
			});

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}
