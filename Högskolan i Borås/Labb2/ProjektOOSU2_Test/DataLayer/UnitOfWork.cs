using Microsoft.EntityFrameworkCore;
using ProjektOOSU2_Test.EntetiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektOOSU2_Test.DataLayer
{
//interface collecting everything for the forms
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Patient> Patients { get; }
        IRepository<Diagnosis> Diagnoses { get; }
        IRepository<Employee> Employees { get; }
        IRepository<DoctorAppointment> DoctorAppointments { get; }
        IRepository<MedicinePrescription> MedicinePrescriptions { get; }
        Task<int> CompleteAsync();
    }

    //A class collecting everything for Dbcontext

    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork(DbContext context)
        {
            _context = context;
            Patients = new Repository<Patient>(_context);
            Diagnoses = new Repository<Diagnosis>(_context);
            Employees = new Repository<Employee>(_context);
            DoctorAppointments = new Repository<DoctorAppointment>(_context);
            MedicinePrescriptions = new Repository<MedicinePrescription>(_context);
        }

        public IRepository<Patient> Patients { get; private set; }
        public IRepository<Diagnosis> Diagnoses { get; private set; }
        public IRepository<Employee> Employees { get; private set; }
        public IRepository<DoctorAppointment> DoctorAppointments { get; private set; }
        public IRepository<MedicinePrescription> MedicinePrescriptions { get; private set; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
