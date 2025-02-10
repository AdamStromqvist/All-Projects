using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOSU2_Laboration1_AAAV.EntetiesLayer
{
    // Entity class representing a MedicinePrescription
    public class MedicinePrescription
    {
        public int PatientID { get; set; }   // ID of the patient for whom the prescription is issued
        public string NameMedicine { get; set; } // Name of the prescribed medicine
        public string Dosage { get; set; }    // Dosage instructions
        public DateTime DischargeDate { get; set; } // Date when the prescription is discharged

        public DataLayer.Repository<object> Repository
        {
            get => default;
            set
            {
            }
        }

        public DataLayer.DB DB
        {
            get => default;
            set
            {
            }
        }
    }
}
