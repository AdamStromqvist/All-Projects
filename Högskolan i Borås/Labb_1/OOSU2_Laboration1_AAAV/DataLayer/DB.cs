using OOSU2_Laboration1_AAAV.EntetiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOSU2_Laboration1_AAAV.DataLayer
{
    //-------------------------------------------
    //Database
    //-------------------------------------------
    public class DB
    {
        public List<Patient> Patients { get; set; } // Represents list for patients
        public List<DoctorAppointment> DoctorAppointments { get; set; } // Represents list for Doctorappointments
        public List<Diagnosis> Diagnoses { get; set; } // Represents a list for Diagnoses
        public List<MedicinePrescription> MedicinePrescriptions { get; set; } // Represents a list for MedicinePrescriptions
        
        // Missing references but is an association line between UnitofWork and the database
        public DataLayer.UnitOfWork UnitOfWork
        {
            get => default;
            set
            {
            }
        }
        
        // Constructor for Database
        public DB()
        {
            Patients = new List<Patient>();
            DoctorAppointments = new List<DoctorAppointment>();
            Diagnoses = new List<Diagnosis>();
            MedicinePrescriptions = new List<MedicinePrescription>();
        }
    }
}
