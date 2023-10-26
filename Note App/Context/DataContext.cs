using Microsoft.EntityFrameworkCore;
using Note_App.Entities;
using Note_App.EntityConfig;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace Note_App.Context
{
    internal class DataContext : DbContext
    {
        public DbSet<NoteEntity> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=Notizen;Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NoteEntityConfig).Assembly);
        }

    }
}
