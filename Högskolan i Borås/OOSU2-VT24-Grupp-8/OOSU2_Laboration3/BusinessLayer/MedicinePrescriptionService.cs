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
using OOSU2_Laboration3.PresentationLayer.ViewModels;

namespace OOSU2_Laboration3.BusinessLayer
{
    public interface IMedicinePrescriptionService //Interface defining the operations for managing medicine prescriptions.
    {
        Task<IEnumerable<MedicinePrescription>> GetAllMedicinePrescriptionsAsync();
        Task AddMedicinePrescriptionAsync(MedicinePrescription prescription);
        Task UpdateMedicinePrescriptionAsync(MedicinePrescription prescription);
        Task DeleteMedicinePrescriptionAsync(int prescriptionId);
        Task LoadMedicinePrescriptions();
        Task<IEnumerable<MedicinePrescription>> GetMedicinePrescriptionsForPatientAsync(int patientId);
        ObservableCollection<MedicinePrescription> MedicinePrescriptions { get; }
        Task<IEnumerable<Patient>> GetAllPatientsAsync();
    }
//Provides functionality for managing medicine prescriptions
    public class MedicinePrescriptionService : IMedicinePrescriptionService
    {
        private readonly IUnitOfWork _unitOfWork; //Unitofwork for handeling database operations

        public ObservableCollection<MedicinePrescription> MedicinePrescriptions { get; private set; }

        public MedicinePrescriptionService(IUnitOfWork unitOfWork) //constructor initializing the service w unitofwork
        {
            _unitOfWork = unitOfWork;
        }
//Retrieves all medicine prescriptions from the database
        public async Task<IEnumerable<MedicinePrescription>> GetAllMedicinePrescriptionsAsync()
        {
            try
            {
                var prescriptions = await _unitOfWork.MedicinePrescriptions.GetAllAsync();
                return prescriptions.AsQueryable().AsNoTracking();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to get all medicine prescriptions: {ex.Message}");
                return Enumerable.Empty<MedicinePrescription>();
            }
        }
//Adds a new medicine prescription to the database.
        public async Task AddMedicinePrescriptionAsync(MedicinePrescription prescription)
        {
            await _unitOfWork.MedicinePrescriptions.AddAsync(prescription);
            await _unitOfWork.CompleteAsync();
        }
//Updates an existing medicine prescription in the database.
        public async Task UpdateMedicinePrescriptionAsync(MedicinePrescription prescription)
        {
            _unitOfWork.MedicinePrescriptions.Update(prescription);
            await _unitOfWork.CompleteAsync();
        }
//Deletes a medicine prescription from the database using its ID.
        public async Task DeleteMedicinePrescriptionAsync(int prescriptionId)
        {
            var prescription = await _unitOfWork.MedicinePrescriptions.GetByIdAsync(prescriptionId);
            if (prescription != null)
            {
                _unitOfWork.MedicinePrescriptions.Remove(prescription);
                await _unitOfWork.CompleteAsync();
            }
        }
//Loads all medicine prescriptions into the observable collection
        public async Task LoadMedicinePrescriptions()
        {
            try
            {
                var prescriptions = await _unitOfWork.MedicinePrescriptions.GetAllAsync();
                MedicinePrescriptions = new ObservableCollection<MedicinePrescription>(prescriptions);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to load medicine prescriptions: {ex.Message}");
            }
        }
//Retrieves medicine prescriptions for a specific patient by their ID. /// </summary>
        public async Task<IEnumerable<MedicinePrescription>> GetMedicinePrescriptionsForPatientAsync(int patientId)
        {
            try
            {
                var prescriptions = await _unitOfWork.MedicinePrescriptions.GetPrescriptionsForPatientAsync(patientId);
                return prescriptions;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to get medicine prescriptions for patient: {ex.Message}");
                return Enumerable.Empty<MedicinePrescription>();
            }
        }
//Retrieves all patients from the database.
        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            return await _unitOfWork.Patients.GetAllAsync();
        }
    }
}
