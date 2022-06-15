﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LabBigSchool_DuongGiaBao.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
         
        public DbSet<Course> courses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>()
                   .HasRequired(a => a.course)
                   .WithMany()
                   .WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }

    }
}