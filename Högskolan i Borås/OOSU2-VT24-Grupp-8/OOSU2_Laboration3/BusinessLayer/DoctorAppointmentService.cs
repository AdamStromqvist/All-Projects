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
    public interface IDoctorAppointmentService //Defines the contract for services that manages doctor appointments
    {
        Task<IEnumerable<DoctorAppointment>> GetAllDoctorAppointmentsAsync();
        Task AddDoctorAppointmentAsync(DoctorAppointment appointment);
        Task UpdateDoctorAppointmentAsync(DoctorAppointment appointment);
        Task DeleteDoctorAppointmentAsync(int appointmentId);
        Task LoadDoctorAppointments();
        Task<IEnumerable<DoctorAppointment>> GetDoctorAppointmentsForPatientAsync(int patientId);
        ObservableCollection<DoctorAppointment> DoctorAppointments { get; }
        Task<IEnumerable<Patient>> GetAllPatientsAsync();
    }
//Provides implementation of the operations to manage doctor appointments
    public class DoctorAppointmentService : IDoctorAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;
//Holds a collection of doctor appointments for binding to the UI.
        public ObservableCollection<DoctorAppointment> DoctorAppointments { get; private set; }

        public DoctorAppointmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
//Retrieves all doctor appointments from the database
        public async Task<IEnumerable<DoctorAppointment>> GetAllDoctorAppointmentsAsync()
        {
            try
            {
                var appointments = await _unitOfWork.DoctorAppointments.GetAllAsync();
                return appointments.AsQueryable().AsNoTracking();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to get all doctor appointments: {ex.Message}");
                return Enumerable.Empty<DoctorAppointment>();
            }
        }
//Adds a new doctor appointment to the database.
        public async Task AddDoctorAppointmentAsync(DoctorAppointment appointment)
        {
            await _unitOfWork.DoctorAppointments.AddAsync(appointment);
            await _unitOfWork.CompleteAsync();
        }
//Updates a existing doctor appointment to the database.
        public async Task UpdateDoctorAppointmentAsync(DoctorAppointment appointment)
        {
            _unitOfWork.DoctorAppointments.Update(appointment);
            await _unitOfWork.CompleteAsync();
        }
//removes a new doctor appointment from the database by using its ID.
        public async Task DeleteDoctorAppointmentAsync(int appointmentId)
        {
            var appointment = await _unitOfWork.DoctorAppointments.GetByIdAsync(appointmentId);
            if (appointment != null)
            {
                _unitOfWork.DoctorAppointments.Remove(appointment);
                await _unitOfWork.CompleteAsync();
            }
        }
//Loads all doctor appointments into the observable collection.
        public async Task LoadDoctorAppointments()
        {
            try
            {
                var appointments = await _unitOfWork.DoctorAppointments.GetAllAsync();
                DoctorAppointments = new ObservableCollection<DoctorAppointment>(appointments);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to load doctor appointments: " + ex.Message);
            }
        }
//Retrieves doctor appointments for a specific patient by their ID.
        public async Task<IEnumerable<DoctorAppointment>> GetDoctorAppointmentsForPatientAsync(int patientId)
        {
            try
            {
                var appointments = await _unitOfWork.DoctorAppointments.GetAppointmentsForPatientAsync(patientId);
                return appointments;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to get doctor appointments for patient: " + ex.Message);
                return Enumerable.Empty<DoctorAppointment>();
            }
        }

//Retrieves all patients from the database.
        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            return await _unitOfWork.Patients.GetAllAsync();
        }
    }
}
