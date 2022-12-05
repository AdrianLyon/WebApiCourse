using Curso.Models;
using Microsoft.EntityFrameworkCore;

namespace Curso.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            
        }

        public DbSet<Product> Products{get; set;}
        public DbSet<User> Users{get; set;}
    }
}