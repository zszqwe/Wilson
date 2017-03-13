﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wilson.Companies.Core.Entities;

namespace Wilson.Companies.Data.Configurations
{
    public class ProjectTypeConfiguration : EntityTypeConfiguration<Project>
    {
        public ProjectTypeConfiguration(ModelBuilder modelBuilder)
        {
            this.Map(modelBuilder.Entity<Project>());
        }

        public override void Map(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(900).IsRequired();
            builder.HasOne(x => x.Contract).WithOne(x => x.Project).HasForeignKey<Project>(x => x.ContractId);
            builder.HasOne(x => x.Location).WithOne().HasForeignKey<Project>(x => x.LocationId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}