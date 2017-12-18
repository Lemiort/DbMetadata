﻿// <auto-generated />
using DbMetadata.Models.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace DbMetadata.Migrations
{
    [DbContext(typeof(MetadataContext))]
    partial class MetadataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DbMetadata.Models.Metadata.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("OrganizationId1");

                    b.HasKey("DepartmentId");

                    b.HasIndex("OrganizationId1");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("DbMetadata.Models.Metadata.Organization", b =>
                {
                    b.Property<int>("OrganizationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("OrganizationId");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("DbMetadata.Models.Metadata.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("DepartmentId1");

                    b.Property<string>("Name");

                    b.HasKey("ProjectId");

                    b.HasIndex("DepartmentId1");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("DbMetadata.Models.Metadata.Property", b =>
                {
                    b.Property<int>("PropertyId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("DepartmentId");

                    b.Property<int?>("OrganizationId");

                    b.Property<int?>("ProjectId");

                    b.Property<string>("Title");

                    b.Property<string>("Value");

                    b.HasKey("PropertyId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("DbMetadata.Models.Metadata.Department", b =>
                {
                    b.HasOne("DbMetadata.Models.Metadata.Organization", "OrganizationId")
                        .WithMany()
                        .HasForeignKey("OrganizationId1");
                });

            modelBuilder.Entity("DbMetadata.Models.Metadata.Project", b =>
                {
                    b.HasOne("DbMetadata.Models.Metadata.Department", "DepartmentId")
                        .WithMany()
                        .HasForeignKey("DepartmentId1");
                });

            modelBuilder.Entity("DbMetadata.Models.Metadata.Property", b =>
                {
                    b.HasOne("DbMetadata.Models.Metadata.Department")
                        .WithMany("Properties")
                        .HasForeignKey("DepartmentId");

                    b.HasOne("DbMetadata.Models.Metadata.Organization")
                        .WithMany("Properties")
                        .HasForeignKey("OrganizationId");

                    b.HasOne("DbMetadata.Models.Metadata.Project")
                        .WithMany("Properties")
                        .HasForeignKey("ProjectId");
                });
#pragma warning restore 612, 618
        }
    }
}
