using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SAKURA.NZB.Seed.Data;

namespace SAKURA.NZB.Seed.Data.Migrations
{
    [DbContext(typeof(NZBContext))]
    partial class NZBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SAKURA.NZB.Seed.Domain.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("SAKURA.NZB.Seed.Domain.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("SAKURA.NZB.Seed.Domain.Configuration", b =>
                {
                    b.Property<string>("Key")
                        .HasAnnotation("MaxLength", 200);

                    b.Property<string>("Value")
                        .HasAnnotation("MaxLength", 1000);

                    b.HasKey("Key");

                    b.ToTable("Configs");
                });

            modelBuilder.Entity("SAKURA.NZB.Seed.Domain.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("Address1")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 255);

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("FullName")
                        .HasAnnotation("MaxLength", 10);

                    b.Property<bool?>("IsAgent");

                    b.Property<int?>("Level");

                    b.Property<string>("NamePinYin")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("Phone1")
                        .HasAnnotation("MaxLength", 20);

                    b.Property<string>("Phone2")
                        .HasAnnotation("MaxLength", 20);

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("SAKURA.NZB.Seed.Domain.ExchangeRate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("ModifiedTime");

                    b.Property<float>("NZDCNY");

                    b.Property<string>("Source")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<float>("USDCNY");

                    b.Property<float>("USDNZD");

                    b.HasKey("Id");

                    b.ToTable("ExchangeRates");
                });

            modelBuilder.Entity("SAKURA.NZB.Seed.Domain.ExchangeRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Agent");

                    b.Property<float>("Cny");

                    b.Property<DateTimeOffset>("CreatedTime");

                    b.Property<float>("Nzd");

                    b.Property<float>("Rate");

                    b.Property<float>("ReceiverCharge");

                    b.Property<float>("SponsorCharge");

                    b.HasKey("Id");

                    b.ToTable("ExchangeRecords");
                });

            modelBuilder.Entity("SAKURA.NZB.Seed.Domain.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<DateTimeOffset?>("CompleteTime");

                    b.Property<DateTimeOffset?>("DeliveryTime");

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 255);

                    b.Property<float?>("Freight");

                    b.Property<int>("OrderState");

                    b.Property<DateTimeOffset>("OrderTime");

                    b.Property<DateTimeOffset?>("PayTime");

                    b.Property<int>("PaymentState");

                    b.Property<string>("Phone")
                        .HasAnnotation("MaxLength", 20);

                    b.Property<DateTimeOffset?>("ReceiveTime");

                    b.Property<string>("Recipient")
                        .HasAnnotation("MaxLength", 10);

                    b.Property<string>("TrackingNumber")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<float?>("Weight");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("SAKURA.NZB.Seed.Domain.OrderProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Cost");

                    b.Property<int>("CustomerId");

                    b.Property<int>("OrderId");

                    b.Property<bool>("PrePurchased");

                    b.Property<float>("Price");

                    b.Property<int>("ProductId");

                    b.Property<string>("ProductName")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<int>("Qty");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("OrderProduct");
                });

            modelBuilder.Entity("SAKURA.NZB.Seed.Domain.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BrandId");

                    b.Property<int>("CategoryId");

                    b.Property<string>("Desc")
                        .HasAnnotation("MaxLength", 1000);

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<float>("Price");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SAKURA.NZB.Seed.Domain.ProductQuote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Price");

                    b.Property<int>("ProductId");

                    b.Property<int>("SupplierId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SupplierId");

                    b.ToTable("ProductQuote");
                });

            modelBuilder.Entity("SAKURA.NZB.Seed.Domain.Shipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("ArrivedTime");

                    b.Property<string>("Destination")
                        .HasAnnotation("MaxLength", 20);

                    b.Property<string>("From")
                        .HasAnnotation("MaxLength", 20);

                    b.Property<string>("ItemCount")
                        .HasAnnotation("MaxLength", 10);

                    b.Property<DateTimeOffset>("ModifiedTime");

                    b.Property<string>("Recipient")
                        .HasAnnotation("MaxLength", 20);

                    b.Property<string>("Status")
                        .HasAnnotation("MaxLength", 20);

                    b.Property<string>("TrackingNumber")
                        .HasAnnotation("MaxLength", 20);

                    b.HasKey("Id");

                    b.ToTable("Shipments");
                });

            modelBuilder.Entity("SAKURA.NZB.Seed.Domain.ShipmentEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content")
                        .HasAnnotation("MaxLength", 200);

                    b.Property<int>("ShipmentId");

                    b.Property<DateTime?>("When");

                    b.Property<string>("Where")
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("Id");

                    b.HasIndex("ShipmentId");

                    b.ToTable("ShipmentEntry");
                });

            modelBuilder.Entity("SAKURA.NZB.Seed.Domain.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("Phone")
                        .HasAnnotation("MaxLength", 20);

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("SAKURA.NZB.Seed.Domain.OrderProduct", b =>
                {
                    b.HasOne("SAKURA.NZB.Seed.Domain.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SAKURA.NZB.Seed.Domain.Order")
                        .WithMany("Products")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SAKURA.NZB.Seed.Domain.Product", "Product")
                        .WithOne()
                        .HasForeignKey("SAKURA.NZB.Seed.Domain.OrderProduct", "ProductId");
                });

            modelBuilder.Entity("SAKURA.NZB.Seed.Domain.Product", b =>
                {
                    b.HasOne("SAKURA.NZB.Seed.Domain.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SAKURA.NZB.Seed.Domain.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SAKURA.NZB.Seed.Domain.ProductQuote", b =>
                {
                    b.HasOne("SAKURA.NZB.Seed.Domain.Product")
                        .WithMany("Quotes")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SAKURA.NZB.Seed.Domain.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SAKURA.NZB.Seed.Domain.ShipmentEntry", b =>
                {
                    b.HasOne("SAKURA.NZB.Seed.Domain.Shipment")
                        .WithMany("Entries")
                        .HasForeignKey("ShipmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
