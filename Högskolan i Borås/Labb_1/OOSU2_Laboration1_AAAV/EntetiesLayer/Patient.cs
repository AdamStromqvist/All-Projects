using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOSU2_Laboration1_AAAV.EntetiesLayer
{
    // Entity class representing a Patient
    public class Patient
    {
        public int PatientID { get; set; }         // Unique patient identifier
        public string PatientName { get; set; }    // Name of the patient
        public string SocialSecurityNr { get; set; } // Social security number of the patient
        public string Address { get; set; }         // Address of the patient
        public string PhoneNr { get; set; }         // Phone number of the patient
        public string EmailAddress { get; set; }    // Email address of the patient

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
