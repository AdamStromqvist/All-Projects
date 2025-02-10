using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektOOSU2_Test.EntetiesLayer
{

//Attributes for the entity MedicinePrescription
    public class MedicinePrescription
    {
        public int Id { get; set; }   // ID of the patient for whom the prescription is issued
        public string NameMedicine { get; set; } // Name of the prescribed medicine
        public string Dosage { get; set; }    // Dosage instructions
        public DateTime DischargeDate { get; set; } // Date when the prescription is discharged
    }
}
