using Microsoft.EntityFrameworkCore;
using OOSU2_Laboration3.EntetiesLayer;
using OOSU2_Laboration3.PresentationLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OOSU2_Laboration3.DataLayer
{
    // // Interface defining common repository operations for a specific entity type T
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        void Remove(T entity);
        void Update(T entity);
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<DoctorAppointment>> GetAppointmentsForPatientAsync(int patientId);
        Task<IEnumerable<MedicinePrescription>> GetPrescriptionsForPatientAsync(int patientId);
        Task<IEnumerable<Diagnosis>> GetDiagnosesForPatientAsync(int patientId);
    }
    // Generic class implementing the IRepository interface
    public class Repository<T> : IRepository<T> where T : class 
    {
        protected readonly DbContext _context; //DbContext instance used for database interactions
        private readonly DbSet<T> _entities; // DbSet instance for entities of type T

        public Repository(DbContext context) // Constructor initializing the DbContext and DbSet instances
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id) // Asynchronously retrieves an entity by its unique identifier
        {
            return await _entities.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync() // // Asynchronously retrieves all entities of type T
        {
            return await _entities.ToListAsync();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate) // allows querying entities based on a predicate
        {
            return _entities.Where(predicate);
        }

        public async Task AddAsync(T entity) // // Asynchronously adds a new entity to the repository
        {
            await _entities.AddAsync(entity);
        }

        public void Remove(T entity) // Removes an entity from the repository
        {
            _entities.Remove(entity);
        }

        public void Update(T entity) // Updates an existing entity in the repository
        {
            _entities.Update(entity);
        }

        public async Task<IEnumerable<DoctorAppointment>> GetAppointmentsForPatientAsync(int patientId) //Asynchronously retrieves appointments for a specific patient
        {
            // Assuming DoctorAppointment is the entity type you want to retrieve appointments for
            return await _context.Set<DoctorAppointment>()
                .Where(appointment => appointment.PatientID == patientId)
                .ToListAsync();
        }

        public async Task<IEnumerable<MedicinePrescription>> GetPrescriptionsForPatientAsync(int patientId)
        {
            // Assuming MedicinePrescriptionViewModel is the entity type you want to retrieve prescriptions for
            return await _context.Set<MedicinePrescription>()
                .Where(prescription => prescription.PatientID == patientId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Diagnosis>> GetDiagnosesForPatientAsync(int patientId)
        {
            // Assuming Diagnosis is the entity type you want to retrieve diagnoses for
            return await _context.Set<Diagnosis>()
                .Where(diagnosis => diagnosis.PatientID == patientId)
                .ToListAsync();
        }
    }
}
