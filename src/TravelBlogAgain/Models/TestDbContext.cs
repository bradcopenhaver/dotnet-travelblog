using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TravelBlogAgain.Models
{
    public class TestDbContext : TravelBlogAgainContext
    {
        public TestDbContext()
        {

        }

        public override DbSet<Location> Locations { get; set; }
        public override DbSet<Experience> Experiences { get; set; }
        public override DbSet<Person> Persons { get; set; }
        public override DbSet<Experience_Person> Experience_Person { get; set; }

        public override DbSet<Suggestion> Suggestions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=TravelBlogAgainTest;integrated security=True;");
        }

        public TestDbContext(DbContextOptions<TravelBlogAgainContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
