using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Models;

namespace SalesWebMVC.Data
{
    public class SalesWebMVCContext : DbContext
    {
        public SalesWebMVCContext(DbContextOptions<SalesWebMVCContext> options)
            : base(options)
        {
        }

        // DbSet da tabela Department
        public DbSet<Department> Departments { get; set; }

        // Configuração adicional (opcional)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Mapear a entidade para a tabela Department
            modelBuilder.Entity<Department>().ToTable("Department");
        }
    }
}
