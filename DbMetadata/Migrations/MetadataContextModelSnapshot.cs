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

                    b.Property<int?>("OwnerOrganizationOrganizationId");

                    b.HasKey("DepartmentId");

                    b.HasIndex("OwnerOrganizationOrganizationId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("DbMetadata.Models.Metadata.DepartmentProperty", b =>
                {
                    b.Property<int>("DepartmentPropertyId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("OwnerDepartmentDepartmentId");

                    b.Property<string>("Title");

                    b.Property<string>("Value");

                    b.HasKey("DepartmentPropertyId");

                    b.HasIndex("OwnerDepartmentDepartmentId");

                    b.ToTable("DepartmentProperties");
                });

            modelBuilder.Entity("DbMetadata.Models.Metadata.Organization", b =>
                {
                    b.Property<int>("OrganizationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("OrganizationId");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("DbMetadata.Models.Metadata.OrganizationProperty", b =>
                {
                    b.Property<int>("OrganizationPropertyId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("OwnerOrganizationOrganizationId");

                    b.Property<string>("Title");

                    b.Property<string>("Value");

                    b.HasKey("OrganizationPropertyId");

                    b.HasIndex("OwnerOrganizationOrganizationId");

                    b.ToTable("OrganizationProperties");
                });

            modelBuilder.Entity("DbMetadata.Models.Metadata.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("OwnerDepartmentDepartmentId");

                    b.HasKey("ProjectId");

                    b.HasIndex("OwnerDepartmentDepartmentId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("DbMetadata.Models.Metadata.ProjectProperty", b =>
                {
                    b.Property<int>("ProjectPropertyId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("OwnerProjectProjectId");

                    b.Property<string>("Title");

                    b.Property<string>("Value");

                    b.HasKey("ProjectPropertyId");

                    b.HasIndex("OwnerProjectProjectId");

                    b.ToTable("ProjectProperties");
                });

            modelBuilder.Entity("DbMetadata.Models.Metadata.Department", b =>
                {
                    b.HasOne("DbMetadata.Models.Metadata.Organization", "OwnerOrganization")
                        .WithMany("Departments")
                        .HasForeignKey("OwnerOrganizationOrganizationId");
                });

            modelBuilder.Entity("DbMetadata.Models.Metadata.DepartmentProperty", b =>
                {
                    b.HasOne("DbMetadata.Models.Metadata.Department", "OwnerDepartment")
                        .WithMany("Properties")
                        .HasForeignKey("OwnerDepartmentDepartmentId");
                });

            modelBuilder.Entity("DbMetadata.Models.Metadata.OrganizationProperty", b =>
                {
                    b.HasOne("DbMetadata.Models.Metadata.Organization", "OwnerOrganization")
                        .WithMany("Properties")
                        .HasForeignKey("OwnerOrganizationOrganizationId");
                });

            modelBuilder.Entity("DbMetadata.Models.Metadata.Project", b =>
                {
                    b.HasOne("DbMetadata.Models.Metadata.Department", "OwnerDepartment")
                        .WithMany("Projects")
                        .HasForeignKey("OwnerDepartmentDepartmentId");
                });

            modelBuilder.Entity("DbMetadata.Models.Metadata.ProjectProperty", b =>
                {
                    b.HasOne("DbMetadata.Models.Metadata.Project", "OwnerProject")
                        .WithMany("Properties")
                        .HasForeignKey("OwnerProjectProjectId");
                });
#pragma warning restore 612, 618
        }
    }
}
