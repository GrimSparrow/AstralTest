using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DBRepository
{
    public class PostgreDbContext : DbContext
    {
        public DbSet<Vacancy> Vacancies { get; set; }
        public PostgreDbContext(DbContextOptions<PostgreDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
