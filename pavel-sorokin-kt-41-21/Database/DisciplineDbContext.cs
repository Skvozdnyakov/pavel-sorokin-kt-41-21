using Microsoft.EntityFrameworkCore;
using pavel_sorokin_kt_41_21.Database.Configurations;
using pavel_sorokin_kt_41_21.Models;

namespace pavel_sorokin_kt_41_21.Database
{
    public class DisciplineDbContext : DbContext
    {
        //Добавляем таблицы
        DbSet<Student> Students { get; set; }
        DbSet<Group> Groups { get; set; }
        DbSet<Discipline> Disciplines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Добавляем конфигурации к таблицам
            modelBuilder.ApplyConfiguration(new DisciplineConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
        }

        public DisciplineDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {

        }

    }
}
