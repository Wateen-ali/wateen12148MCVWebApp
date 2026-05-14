using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace wateen12148MCVWebApp.Models
{
    public class wateen12148DbContext :DbContext
    {
        public wateen12148DbContext(): base("wateen12148ConnectionString")
        {

        }

        public DbSet<Room> rooms { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<Teacher> teachers { get; set; }
        public DbSet<Course> courses { get; set; }

    }
}