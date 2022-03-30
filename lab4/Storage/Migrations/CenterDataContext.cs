using lab4.Storage.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab4.Storage.Migrations
{
    public class CenterDataContext : DbContext
    {
        public CenterDataContext(DbContextOptions<CenterDataContext> options) : base(options)
        { }
        public DbSet<University> University { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Professor> Professor { get; set; }
    }

}
