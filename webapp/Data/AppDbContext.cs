using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace webapp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions optionsBuilder):base(optionsBuilder)
        {
            
        }
        public DbSet<Person> People { get; set; }
    }


    public class Person
    {
        public int Id { get; set; }
        
        [MaxLength(32)]
        public string FirstName { get; set; }
        
        [MaxLength(32)]
        public string LastName { get; set; }

        [MaxLength(32)]
        public string Street { get; set; }
        
        [MaxLength(32)]
        public string City { get; set; }
    }
}