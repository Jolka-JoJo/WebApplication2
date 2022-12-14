using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebApplication2.Models
{
    public partial class new_databaseContext : DbContext
    {
        public new_databaseContext()
        {
        }

        public new_databaseContext(DbContextOptions<new_databaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Office> Offices { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Productline> Productlines { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;user=root;password=;database=new_database");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerNumber)
                    .HasName("PRIMARY");

                entity.ToTable("customers");

                entity.HasIndex(e => e.SalesRepEmployeeNumber, "salesRepEmployeeNumber");

                entity.Property(e => e.CustomerNumber).HasColumnName("customerNumber");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("address");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("country");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("lastName");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("phone");

                entity.Property(e => e.SalesRepEmployeeNumber).HasColumnName("salesRepEmployeeNumber");

                entity.HasOne(d => d.SalesRepEmployeeNumberNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.SalesRepEmployeeNumber)
                    .HasConstraintName("customers_ibfk_1");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmployeeNumber)
                    .HasName("PRIMARY");

                entity.ToTable("employees");

                entity.HasIndex(e => e.OfficeCode, "officeCode");

                entity.HasIndex(e => e.ReportsTo, "reportsTo");

                entity.Property(e => e.EmployeeNumber).HasColumnName("employeeNumber");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("firstName");

                entity.Property(e => e.JobTitle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("jobTitle");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("lastName");

                entity.Property(e => e.OfficeCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("officeCode");

                entity.Property(e => e.ReportsTo).HasColumnName("reportsTo");

                entity.HasOne(d => d.OfficeCodeNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.OfficeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("employees_ibfk_2");

                entity.HasOne(d => d.ReportsToNavigation)
                    .WithMany(p => p.InverseReportsToNavigation)
                    .HasForeignKey(d => d.ReportsTo)
                    .HasConstraintName("employees_ibfk_1");
            });

            modelBuilder.Entity<Office>(entity =>
            {
                entity.HasKey(e => e.OfficeCode)
                    .HasName("PRIMARY");

                entity.ToTable("offices");

                entity.Property(e => e.OfficeCode)
                    .HasMaxLength(10)
                    .HasColumnName("officeCode");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("address");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("country");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("phone");

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .HasColumnName("state");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrderNumber)
                    .HasName("PRIMARY");

                entity.ToTable("orders");

                entity.HasIndex(e => e.CustomerNumber, "customerNumber");

                entity.Property(e => e.OrderNumber).HasColumnName("orderNumber");

                entity.Property(e => e.CustomerNumber).HasColumnName("customerNumber");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("date")
                    .HasColumnName("orderDate");

                entity.Property(e => e.ShippedDate)
                    .HasColumnType("date")
                    .HasColumnName("shippedDate");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("status");

                entity.HasOne(d => d.CustomerNumberNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("orders_ibfk_1");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductCode)
                    .HasName("PRIMARY");

                entity.ToTable("products");

                entity.HasIndex(e => e.ProductLine, "productLine");

                entity.Property(e => e.ProductCode)
                    .HasMaxLength(15)
                    .HasColumnName("productCode");

                entity.Property(e => e.BuyPrice)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("buyPrice");

                entity.Property(e => e.ProductDescription)
                    .IsRequired()
                    .HasColumnName("productDescription");

                entity.Property(e => e.ProductLine)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("productLine");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("productName");

                entity.Property(e => e.QuantityInStock).HasColumnName("quantityInStock");

                entity.HasOne(d => d.ProductLineNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductLine)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("products_ibfk_1");
            });

            modelBuilder.Entity<Productline>(entity =>
            {
                entity.HasKey(e => e.ProductLine1)
                    .HasName("PRIMARY");

                entity.ToTable("productlines");

                entity.Property(e => e.ProductLine1)
                    .HasMaxLength(50)
                    .HasColumnName("productLine");

                entity.Property(e => e.HtmlDescription)
                    .HasColumnType("mediumtext")
                    .HasColumnName("htmlDescription");

                entity.Property(e => e.Image)
                    .HasColumnType("mediumblob")
                    .HasColumnName("image");

                entity.Property(e => e.TextDescription)
                    .HasMaxLength(4000)
                    .HasColumnName("textDescription");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
