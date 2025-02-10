using Microsoft.EntityFrameworkCore;
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
//Defines the contract for diagnosis-related services that handle data fetching and manipulation.
    public interface IDiagnosisService
    {
        Task<IEnumerable<Diagnosis>> GetAllDiagnosesAsync();
        Task AddDiagnosisAsync(Diagnosis diagnosis);
        Task UpdateDiagnosisAsync(Diagnosis diagnosis);
        Task DeleteDiagnosisAsync(int diagnosisId);
        Task LoadDiagnoses();
        Task<IEnumerable<Diagnosis>> GetDiagnosesForPatientAsync(int patientId);
        ObservableCollection<Diagnosis> Diagnoses { get; }
        Task<IEnumerable<Patient>> GetAllPatientsAsync();
    }
//Provides implementation of diagnosis-related operations interfacing with the database.
    public class DiagnosisService : IDiagnosisService
    {
        private readonly IUnitOfWork _unitOfWork;
//Holds a collection of laoded diagnoses for binding w the UI
        public ObservableCollection<Diagnosis> Diagnoses { get; private set; }
//Constructor initializing the diagnosisservice w the unitofwork
        public DiagnosisService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
//Fetches all diagnoses from the database
        public async Task<IEnumerable<Diagnosis>> GetAllDiagnosesAsync()
        {
            try
            {
                var diagnoses = await _unitOfWork.Diagnoses.GetAllAsync();
                return diagnoses.AsQueryable().AsNoTracking();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to get all diagnoses: {ex.Message}");
                return Enumerable.Empty<Diagnosis>();
            }
        }
//Adds a diagnosis to the db
        public async Task AddDiagnosisAsync(Diagnosis diagnosis)
        {
            await _unitOfWork.Diagnoses.AddAsync(diagnosis);
            await _unitOfWork.CompleteAsync();
        }
//Updates a diagnosis to the db
        public async Task UpdateDiagnosisAsync(Diagnosis diagnosis)
        {
            _unitOfWork.Diagnoses.Update(diagnosis);
            await _unitOfWork.CompleteAsync();
        }
//Removes a diagnosis from the db using its ID
        public async Task DeleteDiagnosisAsync(int diagnosisId)
        {
            var diagnosis = await _unitOfWork.Diagnoses.GetByIdAsync(diagnosisId);
            if (diagnosis != null)
            {
                _unitOfWork.Diagnoses.Remove(diagnosis);
                await _unitOfWork.CompleteAsync();
            }
        }
//Loads all the diangosis from the cb
        public async Task LoadDiagnoses()
        {
            try
            {
                var diagnoses = await _unitOfWork.Diagnoses.GetAllAsync();
                Diagnoses = new ObservableCollection<Diagnosis>(diagnoses);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to load diagnoses: " + ex.Message);
            }
        }
//Fetches all diagnosis associated with a specific patient
        public async Task<IEnumerable<Diagnosis>> GetDiagnosesForPatientAsync(int patientId)
        {
            try
            {
                var diagnoses = await _unitOfWork.Diagnoses.GetDiagnosesForPatientAsync(patientId);
                return diagnoses;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to get diagnoses for patient: " + ex.Message);
                return Enumerable.Empty<Diagnosis>();
            }
        }
//Fetched alll patients from the database
        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            return await _unitOfWork.Patients.GetAllAsync();
        }
    }
}
