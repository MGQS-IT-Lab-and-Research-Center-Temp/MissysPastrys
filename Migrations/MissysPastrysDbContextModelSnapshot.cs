﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MissysPastrys.Context;

#nullable disable

namespace MissysPastrys.Migrations
{
    [DbContext(typeof(MissysPastrysDbContext))]
    partial class MissysPastrysDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MissysPastrys.Entities.Category", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CategoryName")
                        .IsUnique();

                    b.ToTable("Categories", (string)null);
                });

            modelBuilder.Entity("MissysPastrys.Entities.Delivery", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DeliveryAddress")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DeliveryGroup")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("longtext");

                    b.Property<string>("ShoppingCartId")
                        .HasColumnType("varchar(255)");

                    b.Property<short>("Status")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("ShoppingCartId");

                    b.ToTable("Deliveries", (string)null);
                });

            modelBuilder.Entity("MissysPastrys.Entities.Order", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("OrderDeliveryDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("OrderPlacedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("OrderTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ReferenceNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders", (string)null);
                });

            modelBuilder.Entity("MissysPastrys.Entities.OrderDetail", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<decimal>("CostPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("longtext");

                    b.Property<string>("OrderId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("PastryId")
                        .HasColumnType("varchar(255)");

                    b.Property<decimal>("SellingPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("PastryId");

                    b.ToTable("OrderDetailss", (string)null);
                });

            modelBuilder.Entity("MissysPastrys.Entities.Pastry", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<decimal>("CostPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LongDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("OrderId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<decimal>("SellingPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("OrderId");

                    b.ToTable("Pastries", (string)null);
                });

            modelBuilder.Entity("MissysPastrys.Entities.PastryCategory", b =>
                {
                    b.Property<string>("PastryId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CategoryId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("longtext");

                    b.HasKey("PastryId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("PastryCategories", (string)null);
                });

            modelBuilder.Entity("MissysPastrys.Entities.Review", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("longtext");

                    b.Property<string>("PastryId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<short>("Rating")
                        .HasColumnType("smallint");

                    b.Property<string>("ReviewText")
                        .HasMaxLength(500)
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("PastryId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews", (string)null);
                });

            modelBuilder.Entity("MissysPastrys.Entities.Role", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("RoleName")
                        .IsUnique();

                    b.ToTable("Roles", (string)null);
                });

            modelBuilder.Entity("MissysPastrys.Entities.ShoppingCart", b =>
                {
                    b.Property<string>("ShoppingCartId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("ShoppingCartId");

                    b.ToTable("ShoppingCart", (string)null);
                });

            modelBuilder.Entity("MissysPastrys.Entities.ShoppingCartItem", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("longtext");

                    b.Property<string>("PastryId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ShoppingCartId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("PastryId");

                    b.HasIndex("ShoppingCartId");

                    b.ToTable("ShoppingCartItems", (string)null);
                });

            modelBuilder.Entity("MissysPastrys.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("HashSalt")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("longtext");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("MissysPastrys.Entities.Delivery", b =>
                {
                    b.HasOne("MissysPastrys.Entities.ShoppingCart", "ShoppingCart")
                        .WithMany()
                        .HasForeignKey("ShoppingCartId");

                    b.Navigation("ShoppingCart");
                });

            modelBuilder.Entity("MissysPastrys.Entities.Order", b =>
                {
                    b.HasOne("MissysPastrys.Entities.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MissysPastrys.Entities.OrderDetail", b =>
                {
                    b.HasOne("MissysPastrys.Entities.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId");

                    b.HasOne("MissysPastrys.Entities.Pastry", "Pastry")
                        .WithMany()
                        .HasForeignKey("PastryId");

                    b.Navigation("Order");

                    b.Navigation("Pastry");
                });

            modelBuilder.Entity("MissysPastrys.Entities.Pastry", b =>
                {
                    b.HasOne("MissysPastrys.Entities.Order", "Order")
                        .WithMany("Pastries")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("MissysPastrys.Entities.PastryCategory", b =>
                {
                    b.HasOne("MissysPastrys.Entities.Category", "Category")
                        .WithMany("PastryCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MissysPastrys.Entities.Pastry", "Pastry")
                        .WithMany("PastryCategories")
                        .HasForeignKey("PastryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Pastry");
                });

            modelBuilder.Entity("MissysPastrys.Entities.Review", b =>
                {
                    b.HasOne("MissysPastrys.Entities.Pastry", "Pastry")
                        .WithMany("Reviews")
                        .HasForeignKey("PastryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MissysPastrys.Entities.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pastry");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MissysPastrys.Entities.ShoppingCartItem", b =>
                {
                    b.HasOne("MissysPastrys.Entities.Pastry", "Pastry")
                        .WithMany()
                        .HasForeignKey("PastryId");

                    b.HasOne("MissysPastrys.Entities.ShoppingCart", "ShoppingCart")
                        .WithMany("ShoppingCartItems")
                        .HasForeignKey("ShoppingCartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pastry");

                    b.Navigation("ShoppingCart");
                });

            modelBuilder.Entity("MissysPastrys.Entities.User", b =>
                {
                    b.HasOne("MissysPastrys.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("MissysPastrys.Entities.Category", b =>
                {
                    b.Navigation("PastryCategories");
                });

            modelBuilder.Entity("MissysPastrys.Entities.Order", b =>
                {
                    b.Navigation("Pastries");
                });

            modelBuilder.Entity("MissysPastrys.Entities.Pastry", b =>
                {
                    b.Navigation("PastryCategories");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("MissysPastrys.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("MissysPastrys.Entities.ShoppingCart", b =>
                {
                    b.Navigation("ShoppingCartItems");
                });

            modelBuilder.Entity("MissysPastrys.Entities.User", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
