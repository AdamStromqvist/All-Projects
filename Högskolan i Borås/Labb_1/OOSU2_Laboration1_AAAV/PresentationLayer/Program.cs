using OOSU2_Laboration1_AAAV.BusinessLayer;
using OOSU2_Laboration1_AAAV.DataLayer.DataLayer;
using OOSU2_Laboration1_AAAV.EntetiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOSU2_Laboration1_AAAV.PresentationLayer
{
    //-------------------------------------------------
    //User interface
    //-------------------------------------------------
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWork unitOfWork = new UnitOfWork(); // defines and uses unitofwork

            // This is the main menu of the program
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Patient Application");
                Console.WriteLine("1. Patient Manager");
                Console.WriteLine("2. Doctor Appointment Manager");
                Console.WriteLine("3. Diagnosis Manager");
                Console.WriteLine("4. Medicine Prescription Manager");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();
                Console.Clear();
                
                // Switch for 5 diffrent cases that is in the main menu
                switch (choice)
                {
                    case "1": // Patient Manager
                        PatientManagerMenu(unitOfWork);
                        break;
                    case "2": // Doctor Appointment Manager
                        DoctorAppointmentManagerMenu(unitOfWork);
                        break;
                    case "3": // Diagnosis Manager
                        DiagnosisManagerMenu(unitOfWork);
                        break;
                    case "4": // Medicine Prescription Manager
                        MedicinePrescriptionManagerMenu(unitOfWork);
                        break;
                    case "5": // Exit
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        //-------------------------
        // PatientManager
        //-------------------------
        static void PatientManagerMenu(UnitOfWork unitOfWork)
        {
            PatientManager patientManager = new PatientManager(unitOfWork);

            // Menu for the patient manager
            while (true)
            {
                Console.WriteLine("Patient Manager Menu");
                Console.WriteLine("1. Register Patient");
                Console.WriteLine("2. Update Patient");
                Console.WriteLine("3. Remove Patient");
                Console.WriteLine("4. Back to Main Menu");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();
                Console.Clear();

                // Switch for patient manager menu
                switch (choice)
                {
                    case "1": // Register Patient
                        RegisterPatient(patientManager);
                        break;
                    case "2": // Update Patient
                        UpdatePatient(patientManager);
                        break;
                    case "3": // Remove Patient
                        RemovePatient(patientManager);
                        break;
                    case "4": // Back to Main Menu
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        // Reads data for method RegisterPatient in businesslayer
        static void RegisterPatient(PatientManager patientManager)
        {
            Console.Write("Enter Patient ID: ");
            int patientID = int.Parse(Console.ReadLine());

            Console.Write("Enter Patient Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Social Security Number: ");
            string ssn = Console.ReadLine();
            Console.Write("Enter Address: ");
            string address = Console.ReadLine();
            Console.Write("Enter Phone Number: ");
            string phone = Console.ReadLine();
            Console.Write("Enter Email Address: ");
            string email = Console.ReadLine();

            Patient newPatient = new Patient
            {
                PatientID = patientID,
                PatientName = name,
                SocialSecurityNr = ssn,
                Address = address,
                PhoneNr = phone,
                EmailAddress = email
            };

            patientManager.RegisterPatient(newPatient);
            Console.WriteLine("Patient registered successfully!");
        }

        // Reads data for updating existing patients in BusinessLayer
        static void UpdatePatient(PatientManager patientManager)
        {
            Console.Write("Enter Patient ID to Update: ");
            int patientID = int.Parse(Console.ReadLine());

            Console.Write("Enter New Patient Name: ");
            string newName = Console.ReadLine();
            Console.Write("Enter New Social Security Number: ");
            string newSSN = Console.ReadLine();
            Console.Write("Enter New Address: ");
            string newAddress = Console.ReadLine();
            Console.Write("Enter New Phone Number: ");
            string newPhone = Console.ReadLine();
            Console.Write("Enter New Email Address: ");
            string newEmail = Console.ReadLine();

            Patient updatedPatient = new Patient
            {
                PatientName = newName,
                SocialSecurityNr = newSSN,
                Address = newAddress,
                PhoneNr = newPhone,
                EmailAddress = newEmail
            };

            patientManager.UpdatePatient(updatedPatient, patientID);
            Console.WriteLine("Patient updated successfully!");
        }

        // Reads data for removing existing patients in BusinessLayer
        static void RemovePatient(PatientManager patientManager)
        {
            Console.Write("Enter Patient ID to Remove: ");
            int patientID = int.Parse(Console.ReadLine());

            if (patientManager.RemovePatient(patientID))
            {
                Console.WriteLine("Patient removed successfully!");
            }
            else
            {
                Console.WriteLine("Patient not found.");
            }
        }

        //-------------------------
        // DoctorAppointmentManager
        //-------------------------
        static void DoctorAppointmentManagerMenu(UnitOfWork unitOfWork)
        {
            DoctorAppointmentManager doctorAppointmentManager = new DoctorAppointmentManager(unitOfWork);

            // Menu for doctor appointment manager
            while (true)
            {
                Console.WriteLine("Doctor Appointment Manager Menu");
                Console.WriteLine("1. Register Doctor Appointment");
                Console.WriteLine("2. Update Doctor Appointment");
                Console.WriteLine("3. Remove Doctor Appointment");
                Console.WriteLine("4. Back to Main Menu");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();
                Console.Clear();

                // Switch for doctor appointment manager with 4 cases. 
                switch (choice)
                {
                    case "1": // Register Doctor Appointment
                        RegisterDoctorAppointment(doctorAppointmentManager);
                        break;
                    case "2": // Update Doctor Appointment
                        UpdateDoctorAppointment(doctorAppointmentManager);
                        break;
                    case "3": // Remove Doctor Appointment
                        RemoveDoctorAppointment(doctorAppointmentManager);
                        break;
                    case "4": // Back to Main Menu
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
        
        // Reads data to able to register a new doctors appointment in BusinessLayer
        static void RegisterDoctorAppointment(DoctorAppointmentManager doctorAppointmentManager)
        {
            Console.WriteLine("Enter Doctor Appointment ID: ");
            int DoctorAppointmentID = int.Parse(Console.ReadLine());

            Console.Write("Enter Patient ID: ");
            int patientID = int.Parse(Console.ReadLine());

            Console.Write("Enter Date (YYYY-MM-DD): ");
            DateTime date = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter Time From 00.00 to 00.00: ");
            string time = Console.ReadLine();

            Console.Write("Enter Purpose: ");
            string purpose = Console.ReadLine();

            Console.Write("Enter Employment ID: ");
            int employmentID = int.Parse(Console.ReadLine());

            DoctorAppointment newAppointment = new DoctorAppointment
            {
                DoctorAppointmentID = DoctorAppointmentID,
                PatientID = patientID,
                Date = date,
                Time = time,
                Purpose = purpose,
                EmploymentID = employmentID
            };

            doctorAppointmentManager.BookDoctorAppointment(newAppointment);
            Console.WriteLine("Doctor Appointment registered successfully!");
        }

        // Reads data for updating an existing doctors appointment in BusinessLayer
        static void UpdateDoctorAppointment(DoctorAppointmentManager doctorAppointmentManager)
        {
            Console.Write("Enter Doctor Appointment ID to Update: ");
            int doctorAppointmentID = int.Parse(Console.ReadLine());

            Console.Write("Enter Patient ID: ");
            int patientID = int.Parse(Console.ReadLine());

            Console.Write("Enter Date (YYYY-MM-DD): ");
            DateTime date = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter Time From 00.00 to 00.00: ");
            string time = Console.ReadLine();

            Console.Write("Enter Purpose: ");
            string purpose = Console.ReadLine();

            Console.Write("Enter Employment ID: ");
            int employmentID = int.Parse(Console.ReadLine());

            DoctorAppointment updatedDoctorAppointment = new DoctorAppointment
            {
                PatientID = patientID,
                Date = date,
                Time = time,
                Purpose = purpose,
                EmploymentID = employmentID
            };

            doctorAppointmentManager.UpdateDoctorAppointment(updatedDoctorAppointment, doctorAppointmentID);
            Console.WriteLine("Doctor Appointment updated successfully!");
     
        }

         // Reads data for removing an existing doctors appointment in BusinessLayer
        static void RemoveDoctorAppointment(DoctorAppointmentManager doctorAppointmentManager)
        {
            Console.Write("Enter Doctor Appointment ID to Remove: ");
            int doctorAppointmentID = int.Parse(Console.ReadLine());

            if (doctorAppointmentManager.RemoveDoctorAppointment(doctorAppointmentID))
            {
                Console.WriteLine("Doctor Appointment removed successfully!");
            }
            else
            {
                Console.WriteLine("Doctor Appointment not found.");
            }
        }

        //-------------------------
        // DiagnosisManager
        //-------------------------
        static void DiagnosisManagerMenu(UnitOfWork unitOfWork)
        {
            DiagnosisManager diagnosisManager = new DiagnosisManager(unitOfWork);

            // Menu for diagnosis manager 
            while (true)
            {
                Console.WriteLine("Diagnosis Manager Menu");
                Console.WriteLine("1. Register Diagnosis");
                Console.WriteLine("2. Back to Main Menu");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();
                Console.Clear();

                // Switch for diagnosis menu 
                switch (choice)
                {
                    case "1": // Register Diagnosis
                        RegisterDiagnosis(diagnosisManager);
                        break;
                    case "2": // Back to Main Menu
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        //  // Reads data for register a new diagnosis in BusinessLayer
        static void RegisterDiagnosis(DiagnosisManager diagnosisManager)
        {
            Console.Write("Enter Patient ID: ");
            int patientID = int.Parse(Console.ReadLine());

            Console.Write("Enter Diagnosis Description: ");
            string diagnosisDescription = Console.ReadLine();

            Console.Write("Enter Date (YYYY-MM-DD): ");
            DateTime date = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter Treatment Proposal: ");
            string treatmentProposal = Console.ReadLine();

            Diagnosis newDiagnosis = new Diagnosis
            {
                PatientID = patientID,
                DiagnosisDescription = diagnosisDescription,
                Date = date,
                TreatmentProposal = treatmentProposal
            };

            diagnosisManager.RegisterDiagnosis(newDiagnosis);
            Console.WriteLine("Diagnosis registered successfully!");
        }

        //-------------------------
        // MedicinePrescriptionManager
        //-------------------------
        static void MedicinePrescriptionManagerMenu(UnitOfWork unitOfWork)
        {
            MedicinePrescriptionManager medicinePrescriptionManager = new MedicinePrescriptionManager(unitOfWork);

            // Menu for medicine prescrption manager
            while (true)
            {
                Console.WriteLine("Medicine Prescription Manager Menu");
                Console.WriteLine("1. Register Medicine Prescription");
                Console.WriteLine("2. Back to Main Menu");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();
                Console.Clear();

                // Switch for medicine prescription menu
                switch (choice)
                {
                    case "1": // Register Medicine Prescription
                        RegisterMedicinePrescription(medicinePrescriptionManager);
                        break;
                    case "2": // Back to Main Menu
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

         // Reads data to register a new medicine prescription in BusinessLayer
        static void RegisterMedicinePrescription(MedicinePrescriptionManager medicinePrescriptionManager)
        {
            Console.Write("Enter Patient ID: ");
            int patientID = int.Parse(Console.ReadLine());

            Console.Write("Enter Medicine Name: ");
            string nameMedicine = Console.ReadLine();

            Console.Write("Enter Dosage: ");
            string dosage = Console.ReadLine();

            Console.Write("Enter Discharge Date (YYYY-MM-DD): ");
            DateTime dischargeDate = DateTime.Parse(Console.ReadLine());

            MedicinePrescription newPrescription = new MedicinePrescription
            {
                PatientID = patientID,
                NameMedicine = nameMedicine,
                Dosage = dosage,
                DischargeDate = dischargeDate
            };

            medicinePrescriptionManager.RegisterMedicinePrescription(newPrescription);
            Console.WriteLine("Medicine Prescription registered successfully!");
        }

    }

}
