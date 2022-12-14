// <auto-generated />
using System;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(GolestanTestDbContext))]
    [Migration("20221115045303_alterPROC_UpdateWorkStations")]
    partial class alterPROCUpdateWorkStations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataAccess.Models.PROC_AddRetailStore_Result", b =>
                {
                    b.Property<bool>("IsSuccessful")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TheId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable((string)null);

                    b.ToView("PROC_AddRetailStore_Result", (string)null);
                });

            modelBuilder.Entity("DataAccess.Models.PROC_AddWorkStations_Result", b =>
                {
                    b.Property<bool>("IsSuccessful")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TheId")
                        .HasColumnType("int");

                    b.ToTable((string)null);

                    b.ToView("PROC_AddWorkStations_Result", (string)null);
                });

            modelBuilder.Entity("DataAccess.Models.PROC_DeleteRetailStore_Result", b =>
                {
                    b.Property<bool>("IsSuccessful")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable((string)null);

                    b.ToView("PROC_DeleteRetailStore_Result", (string)null);
                });

            modelBuilder.Entity("DataAccess.Models.PROC_DeleteWorkStation_Result", b =>
                {
                    b.Property<bool>("IsSuccessful")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable((string)null);

                    b.ToView("PROC_DeleteWorkStation_Result", (string)null);
                });

            modelBuilder.Entity("DataAccess.Models.PROC_UpdateRetailStore_Result", b =>
                {
                    b.Property<bool>("IsSuccessful")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable((string)null);

                    b.ToView("PROC_UpdateRetailStore_Result", (string)null);
                });

            modelBuilder.Entity("DataAccess.Models.PROC_UpdateWorkStations_Result", b =>
                {
                    b.Property<bool>("IsSuccessful")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable((string)null);

                    b.ToView("PROC_UpdateWorkStations_Result", (string)null);
                });

            modelBuilder.Entity("DataAccess.Models.RetailStore", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Ipaddress")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsTell")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("OpeningDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ParenetId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ParenetId");

                    b.ToTable("RetailStores");
                });

            modelBuilder.Entity("DataAccess.Models.WorkStation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid?>("RetailStoreId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RetailStoreId");

                    b.ToTable("WorkStations");
                });

            modelBuilder.Entity("DataAccess.Models.RetailStore", b =>
                {
                    b.HasOne("DataAccess.Models.RetailStore", "Parenet")
                        .WithMany("InverseParenet")
                        .HasForeignKey("ParenetId");

                    b.Navigation("Parenet");
                });

            modelBuilder.Entity("DataAccess.Models.WorkStation", b =>
                {
                    b.HasOne("DataAccess.Models.RetailStore", "RetailStore")
                        .WithMany("WorkStations")
                        .HasForeignKey("RetailStoreId");

                    b.Navigation("RetailStore");
                });

            modelBuilder.Entity("DataAccess.Models.RetailStore", b =>
                {
                    b.Navigation("InverseParenet");

                    b.Navigation("WorkStations");
                });
#pragma warning restore 612, 618
        }
    }
}
