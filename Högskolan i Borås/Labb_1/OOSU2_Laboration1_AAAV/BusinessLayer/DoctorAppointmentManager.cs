using OOSU2_Laboration1_AAAV.DataLayer.DataLayer;
using OOSU2_Laboration1_AAAV.EntetiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOSU2_Laboration1_AAAV.BusinessLayer
{
    //-----------------------------------------------------------------------------------------------------------------------
    //DoctorAppointmentManager which includes BookDoctorAppointment, UpdateDoctorAppointment and RemoveDoctorAppointment.
    //-----------------------------------------------------------------------------------------------------------------------
    public class DoctorAppointmentManager
    {
        private readonly UnitOfWork unitOfWork; // Here it defines and use UnitOfWork in the DoctorAppointmentManager class. 

        // A constructor
        public DoctorAppointmentManager(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // An association line between DoctorAppointmentManager and program.cs
        internal PresentationLayer.Program Program
        {
            get => default;
            set
            {
            }
        }
        
        // Method for booking a doctors appointment
        public void BookDoctorAppointment(DoctorAppointment appointment)
        {
            unitOfWork.DoctorAppointmentRepository.Add(appointment);
            unitOfWork.Save();
        }
        
        // Updating existing doctors appointment and its attributes
        public void UpdateDoctorAppointment(DoctorAppointment updatedDoctorAppointment, int doctorAppointmentID)
        {
            var existingDoctorAppointment = unitOfWork.DoctorAppointmentRepository.FirstOrDefault(p => p.DoctorAppointmentID == doctorAppointmentID);
            if (existingDoctorAppointment != null)
            {
                existingDoctorAppointment.DoctorAppointmentID = updatedDoctorAppointment.DoctorAppointmentID;
                existingDoctorAppointment.PatientID = updatedDoctorAppointment.PatientID;
                existingDoctorAppointment.Date = updatedDoctorAppointment.Date;
                existingDoctorAppointment.Time = updatedDoctorAppointment.Time;
                existingDoctorAppointment.Purpose = updatedDoctorAppointment.Purpose;
                existingDoctorAppointment.EmploymentID = updatedDoctorAppointment.EmploymentID;
                unitOfWork.Save();
            }
        }
        
        // This method is not in use right now but we will use it for the labration2
        public DoctorAppointment GetDoctorAppointmentByDoctorAppointmentID(int doctorAppointmentID)
        {
            return unitOfWork.DoctorAppointmentRepository.FirstOrDefault(appointment => appointment.DoctorAppointmentID == doctorAppointmentID);
        }
        
        // This method removes an doctors appointment.
        public bool RemoveDoctorAppointment(int doctorAppointmentID)
        {
            var appointmentToRemove = unitOfWork.DoctorAppointmentRepository.FirstOrDefault(appointment => appointment.DoctorAppointmentID == doctorAppointmentID);
            if (appointmentToRemove != null)
            {
                unitOfWork.DoctorAppointmentRepository.Remove(appointmentToRemove);
                unitOfWork.Save();
                return true;
            }
            return false;
        }
    }
}
