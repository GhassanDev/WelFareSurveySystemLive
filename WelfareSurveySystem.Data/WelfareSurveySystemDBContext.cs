using Microsoft.EntityFrameworkCore;
using WelfareSurveySystem.Domain.Entities;
namespace WelfareSurveySystem.Data
{
    public class WelfareSurveySystemDBContext : DbContext
    {
        // configure db 

        public WelfareSurveySystemDBContext(DbContextOptions<WelfareSurveySystemDBContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=WelfareSurveySystemDB;Integrated Security=True");
                //optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().UseTpcMappingStrategy();
            modelBuilder.Entity<WelfareForm>().UseTpcMappingStrategy();
        }

        // cofigure tables
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Addresss { get; set; }
        public DbSet<Children> Childrens { get; set; }

        public DbSet<DeceasedForm> DeceasedForms { get; set; }
        public DbSet<Document> Documents { get; set; }
        //public DbSet<Employees> Employeess { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<RealEstate> RealEstates { get; set; }
        public DbSet<RealEstateType> RealEstateTypes { get; set; }

        public DbSet<Sibling> Siblings { get; set; }
        public DbSet<Spouse> Spouses { get; set; }
        public DbSet<WelfareForm> WelfareForms { get; set; }
        public DbSet<TaskRequest> TaskRequests { get; set; }
        public DbSet<Domain.Entities.TaskStatus> TaskStatuses { get; set; }

        // TODO

        // add remaining entities

        // use TPC inheritance strategy

        // add migrations and update database


    }
}
