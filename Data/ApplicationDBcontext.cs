using Microsoft.EntityFrameworkCore;
using WebAPI.Models.Entities;

namespace WebAPI.Data
{
    public class ApplicationDBcontext : DbContext
    {
        public ApplicationDBcontext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
