using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOSU2_Laboration3.EntetiesLayer
{
    //Attributes for the entity DoctorAppointment
    public class DoctorAppointment
    {
        public int Id { get; set; } // Unique appointment identifier
        public int PatientID { get; set; }           // ID of the patient for whom the appointment is booked
        public DateTime Date { get; set; }           // Date of the appointment
        public string Time { get; set; }             // Time of the appointment
        public string Purpose { get; set; }          // Purpose of the appointment
        public int EmploymentID { get; set; }        // Employment ID of the responsible doctor
        public string Comment { get; set; }          // A comment for the DoctorAppointment
    }
}
