using Microsoft.EntityFrameworkCore;
using OOSU2_Laboration3.EntetiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOSU2_Laboration3.DataLayer
{
    //interface collecting everything for the forms. Also implements IDisposable to allow for resource cleanup
    public interface IUnitOfWork : IDisposable
    {
        // Properties representing different repositories, each encapsulating CRUD(create, read, update, delete) operations for their respective entity types
        IRepository<Patient> Patients { get; }
        IRepository<Diagnosis> Diagnoses { get; }
        IRepository<Employee> Employees { get; }
        IRepository<DoctorAppointment> DoctorAppointments { get; }
        IRepository<MedicinePrescription> MedicinePrescriptions { get; }
        Task<int> CompleteAsync(); // saves the changes to the database. 
    }

    //A class collecting everything for Dbcontext

   //Concrete implementation of the IUnitOfWork interface
    public class UnitOfWork : IUnitOfWork 
    {
        private readonly DbContext _context; // DbContext instance used for database interactions

        public UnitOfWork(DbContext context) //Constructor initializing the UnitOfWork with the specified DbContext

        {
            _context = context;
            //Each repository below is initialized with the same DbContext instance, ensuring they share the same database context.
            Patients = new Repository<Patient>(_context);
            Diagnoses = new Repository<Diagnosis>(_context);
            Employees = new Repository<Employee>(_context);
            DoctorAppointments = new Repository<DoctorAppointment>(_context);
            MedicinePrescriptions = new Repository<MedicinePrescription>(_context);
        }
        // Properties representing different repositories, each encapsulating CRUD operations for their respective entity types.
        public IRepository<Patient> Patients { get; private set; }
        public IRepository<Diagnosis> Diagnoses { get; private set; }
        public IRepository<Employee> Employees { get; private set; }
        public IRepository<DoctorAppointment> DoctorAppointments { get; private set; }
        public IRepository<MedicinePrescription> MedicinePrescriptions { get; private set; }

        public async Task<int> CompleteAsync() // Asynchronously saves changes to the underlying database
        {
            return await _context.SaveChangesAsync();
        }

        // // Disposes the DbContext, releasing its resources
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
