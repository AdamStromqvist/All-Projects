using OOSU2_Laboration3.DataLayer;
using OOSU2_Laboration3.EntetiesLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOSU2_Laboration3.BusinessLayer
{
//Defines the operations for managing patients in the system.
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetAllPatientsAsync();
        Task AddPatientAsync(Patient patient);
        Task UpdatePatientAsync(Patient patient);
        Task DeletePatientAsync(int patientId);
        Task LoadPatients();
    }
//Provides implementation for patient-related services that handle data fetching and manipulation.
    public class PatientService : IPatientService
    {
        private readonly IUnitOfWork _unitOfWork;
        private object _patientService;

        public ObservableCollection<Patient> Patients { get; private set; }

        public PatientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
//Retrieves all patients from the database, a collection of all patients
        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            return await _unitOfWork.Patients.GetAllAsync();
        }
//Adds a new patient to the db
        public async Task AddPatientAsync(Patient patient)
        {
            await _unitOfWork.Patients.AddAsync(patient);
            await _unitOfWork.CompleteAsync();
        }
//Updates an existing patient in the db
        public async Task UpdatePatientAsync(Patient patient)
        {
            _unitOfWork.Patients.Update(patient);
            await _unitOfWork.CompleteAsync();
        }
//Deletes a patient from the db using its ID
        public async Task DeletePatientAsync(int patientId)
        {
            var patient = await _unitOfWork.Patients.GetByIdAsync(patientId);
            if (patient != null)
            {
                _unitOfWork.Patients.Remove(patient);
                await _unitOfWork.CompleteAsync();
            }
        }
//Loads all patient into the observablecollections
        public async Task LoadPatients()
        {
            try
            {
                var patients = await _unitOfWork.Patients.GetAllAsync(); // Using _unitOfWork.Patients to access repository methods
                Patients = new ObservableCollection<Patient>(patients);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to load patients: " + ex.Message);
            }
        }
    }
}
