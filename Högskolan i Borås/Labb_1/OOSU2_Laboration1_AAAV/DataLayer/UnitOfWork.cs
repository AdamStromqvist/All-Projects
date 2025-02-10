using OOSU2_Laboration1_AAAV.EntetiesLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OOSU2_Laboration1_AAAV.DataLayer
{
    namespace DataLayer
    {
        //-----------------------------------------------------------------------------------------------------------------------
        //UnityOfWork connects a specifik entity with the Generic Repository and the Database (DB).
        //-----------------------------------------------------------------------------------------------------------------------
        public class UnitOfWork
        {    // Private field to hold the database context
            private readonly DB db;
            // Constructor to initialize the database context
            public UnitOfWork()
            {
                db = new DB();
            }

            public Repository<Patient> PatientRepository => new Repository<Patient>(db.Patients); // Property to get a repository for patient entities
            public Repository<DoctorAppointment> DoctorAppointmentRepository => new Repository<DoctorAppointment>(db.DoctorAppointments); // Property to get a repository for DoctorAppointments
            public Repository<Diagnosis> DiagnosisRepository => new Repository<Diagnosis>(db.Diagnoses); // Property to get a repository for Diagnosis
            public Repository<MedicinePrescription> MedicinePrescriptionRepository => new Repository<MedicinePrescription>(db.MedicinePrescriptions); // Property to get a repository for MedicinePrescriptions
            // A placeholder properties for various managers in the BusinessLayer
            public BusinessLayer.PatientManager PatientManager
            {
                get => default;
                set
                {
                }
            }

            public BusinessLayer.DiagnosisManager DiagnosisManager
            {
                get => default;
                set
                {
                }
            }

            public BusinessLayer.DoctorAppointmentManager DoctorAppointmentManager
            {
                get => default;
                set
                {
                }
            }

            public BusinessLayer.MedicinePrescriptionManager MedicinePrescriptionManager
            {
                get => default;
                set
                {
                }
            }

            // Lägg till en anslutningssträng för din SQL-databas
            private string connectionString = "Server=sqlutb2-db.hb.se, 56077;Database=myDataBase;User Id=oosu2408;Password=UKB987;";
            private object value1;
            private object value2;

            // Method to save changes to the Database
            public void Save()
            {
                // No additional logic required if you are already saving to in-memory database (the DB class).
                // Skapa en anslutning till din SQL-databas
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        // Öppna anslutningen
                        connection.Open();

                        // Skapa en SQL-fråga för att infoga eller uppdatera data i din databas
                        string query = "INSERT INTO YourTableName (Column1, Column2, ...) VALUES (@Value1, @Value2, ...)";
                        SqlCommand command = new SqlCommand(query, connection);

                        // Lägg till parametrar för att undvika SQL-injektioner och för att göra din kod säkrare
                        command.Parameters.AddWithValue("@Value1", value1);
                        command.Parameters.AddWithValue("@Value2", value2);
                        // Lägg till fler parametrar för andra kolumnvärden om det behövs

                        // Kör SQL-frågan
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        // Hantera fel
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
        }
    }
}
