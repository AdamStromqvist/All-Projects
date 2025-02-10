using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOSU2_Laboration1_AAAV.EntetiesLayer
{
    // Entity class representing a DoctorAppointment
    public class DoctorAppointment
    {
        public int DoctorAppointmentID { get; set; } // Unique appointment identifier
        public int PatientID { get; set; }           // ID of the patient for whom the appointment is booked
        public DateTime Date { get; set; }           // Date of the appointment
        public string Time { get; set; }             // Time of the appointment
        public string Purpose { get; set; }          // Purpose of the appointment
        public int EmploymentID { get; set; }        // Employment ID of the responsible doctor

        public DataLayer.DB DB
        {
            get => default;
            set
            {
            }
        }

        public DataLayer.Repository<object> Repository
        {
            get => default;
            set
            {
            }
        }
    }
}
