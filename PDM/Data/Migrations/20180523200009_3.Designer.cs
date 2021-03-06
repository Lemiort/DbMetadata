﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using PDM;
using System;

namespace PDM.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180523200009_3")]
    partial class _3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("PDM.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("PDM.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("OwnerOrganizationOrganizationId");

                    b.HasKey("DepartmentId");

                    b.HasIndex("OwnerOrganizationOrganizationId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("PDM.Models.DepartmentProperty", b =>
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

            modelBuilder.Entity("PDM.Models.Document", b =>
                {
                    b.Property<int>("DocumentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("FileDocumentFileId");

                    b.Property<int?>("ProjectId");

                    b.HasKey("DocumentId");

                    b.HasIndex("FileDocumentFileId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("PDM.Models.DocumentFile", b =>
                {
                    b.Property<int>("DocumentFileId")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Data");

                    b.Property<DateTime>("ModifiedTime");

                    b.Property<string>("Name");

                    b.Property<int>("OwnerDocumentId");

                    b.HasKey("DocumentFileId");

                    b.ToTable("DocumentFiles");
                });

            modelBuilder.Entity("PDM.Models.Link", b =>
                {
                    b.Property<int>("LinkId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ProjectId");

                    b.Property<int>("SourceTaskId");

                    b.Property<int>("TargetTaskId");

                    b.Property<string>("Type");

                    b.HasKey("LinkId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Links");
                });

            modelBuilder.Entity("PDM.Models.Organization", b =>
                {
                    b.Property<int>("OrganizationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("OrganizationId");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("PDM.Models.OrganizationProperty", b =>
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

            modelBuilder.Entity("PDM.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("OwnerDepartmentDepartmentId");

                    b.HasKey("ProjectId");

                    b.HasIndex("OwnerDepartmentDepartmentId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("PDM.Models.ProjectProperty", b =>
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

            modelBuilder.Entity("PDM.Models.Task", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Duration");

                    b.Property<bool>("Editable");

                    b.Property<DateTime>("EndDate");

                    b.Property<bool>("Open");

                    b.Property<int?>("ParentId");

                    b.Property<decimal>("Progress");

                    b.Property<int>("ProjectId");

                    b.Property<bool>("Readonly");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("Text");

                    b.Property<string>("Type");

                    b.HasKey("TaskId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("PDM.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("PDM.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PDM.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("PDM.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PDM.Models.Department", b =>
                {
                    b.HasOne("PDM.Models.Organization", "OwnerOrganization")
                        .WithMany("Departments")
                        .HasForeignKey("OwnerOrganizationOrganizationId");
                });

            modelBuilder.Entity("PDM.Models.DepartmentProperty", b =>
                {
                    b.HasOne("PDM.Models.Department", "OwnerDepartment")
                        .WithMany("Properties")
                        .HasForeignKey("OwnerDepartmentDepartmentId");
                });

            modelBuilder.Entity("PDM.Models.Document", b =>
                {
                    b.HasOne("PDM.Models.DocumentFile", "File")
                        .WithMany()
                        .HasForeignKey("FileDocumentFileId");

                    b.HasOne("PDM.Models.Project")
                        .WithMany("Documents")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("PDM.Models.Link", b =>
                {
                    b.HasOne("PDM.Models.Project")
                        .WithMany("Links")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PDM.Models.OrganizationProperty", b =>
                {
                    b.HasOne("PDM.Models.Organization", "OwnerOrganization")
                        .WithMany("Properties")
                        .HasForeignKey("OwnerOrganizationOrganizationId");
                });

            modelBuilder.Entity("PDM.Models.Project", b =>
                {
                    b.HasOne("PDM.Models.Department", "OwnerDepartment")
                        .WithMany("Projects")
                        .HasForeignKey("OwnerDepartmentDepartmentId");
                });

            modelBuilder.Entity("PDM.Models.ProjectProperty", b =>
                {
                    b.HasOne("PDM.Models.Project", "OwnerProject")
                        .WithMany("Properties")
                        .HasForeignKey("OwnerProjectProjectId");
                });

            modelBuilder.Entity("PDM.Models.Task", b =>
                {
                    b.HasOne("PDM.Models.Project")
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
