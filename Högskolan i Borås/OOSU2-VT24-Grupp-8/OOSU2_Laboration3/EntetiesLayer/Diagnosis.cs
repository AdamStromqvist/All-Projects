﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOSU2_Laboration3.EntetiesLayer
{
    //Attributes for the entity Diagnosis
    public class Diagnosis
    {
        public int Id { get; set; }  // Primarykey
        public int PatientID { get; set; }             // ID of the patient for whom the diagnosis is recorded
        public string DiagnosisDescription { get; set; } // Description of the diagnosis
        public DateTime Date { get; set; }             // Date when the diagnosis was recorded
        public string TreatmentProposal { get; set; }  // Proposed treatment for the diagnosis
    }
}
