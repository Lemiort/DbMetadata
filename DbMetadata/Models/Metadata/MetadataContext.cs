using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DbMetadata.Models.Metadata
{
    public class MetadataContext: DbContext
    {
        public DbSet<Project> Projects { get; set; }

        public DbSet<Organization> Organizations { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<OrganizationProperty> OrganizationProperties { get; set; }

        public DbSet<DepartmentProperty> DepartmentProperties { get; set; }

        public DbSet<ProjectProperty> ProjectProperties { get; set; }


        public MetadataContext(DbContextOptions<MetadataContext> options) :base(options) 
        {
               
        }
    }
}
