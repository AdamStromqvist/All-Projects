using Microsoft.EntityFrameworkCore;
using ProjektOOSU2_Test.EntetiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektOOSU2_Test.DataLayer
{

//A class working together with the database to create migrations

    public class PatientManagementContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<DoctorAppointment> DoctorAppointments { get; set; }
        public DbSet<MedicinePrescription> MedicinePrescriptions { get; set; }

        // A method overide that configure the connection string to the SQL database 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = @"Server=sqlutb2-db.hb.se,56077;Database=oosu2408;User ID=oosu2408;Password=UKB987;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }
            
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Coding directly a test employee into the database
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1, // Set a unique ID
                    Username = "testuser",
                    NameEmployee = "Test User",
                    Profession = "Tester",
                    Password = "testpassword", // The password should be hashed, the recommended way
                    Specialization = "Testing"
                }
            );
        }

        public PatientManagementContext(DbContextOptions<PatientManagementContext> options) : base(options)
        {
        }
    }
}
