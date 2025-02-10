using Microsoft.EntityFrameworkCore;
using ProjektOOSU2_Test.BusinessLayer;
using ProjektOOSU2_Test.DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektOOSU2_Test.PresentationLayer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void labelHeading_Click(object sender, EventArgs e)
        {

        }

        private void buttonViewAll_Click(object sender, EventArgs e)
        {
            var viewAllForm = new ViewAllForm();
            viewAllForm.Show(); 
        }

        private void buttonPatientService_Click(object sender, EventArgs e)
        {
            // Skapa DbContextOptions för PatientManagementContext
            var optionsBuilder = new DbContextOptionsBuilder<PatientManagementContext>();
            optionsBuilder.UseSqlServer("Server=sqlutb2-db.hb.se,56077;Database=oosu2408;User ID=oosu2408;Password=UKB987;TrustServerCertificate=True;"); // Ersätt med din faktiska anslutningssträng

            // Skapa en instans av PatientManagementContext med de angivna options
            var dbContext = new PatientManagementContext(optionsBuilder.Options);

            // Skapa en UnitOfWork-instans med dbContext
            IUnitOfWork unitOfWork = new UnitOfWork(dbContext);

            // Skapa en PatientService-instans med unitOfWork
            IPatientService patientService = new PatientService(unitOfWork);

            // Skapa och visa PatientForm med patientService
            var patientForm = new PatientForm(patientService);
            patientForm.Show();
        }

        private void buttonDoctorAppointmentService_Click(object sender, EventArgs e)
        {
            var doctorAppointmentForm = new DoctorAppointmentForm();
            doctorAppointmentForm.Show();
        }

        private void buttonDiagnosisService_Click(object sender, EventArgs e)
        {
            var diagnosisForm = new DiagnosisForm();
            diagnosisForm.Show();
        }

        private void buttonMedicinePrescriptionService_Click(object sender, EventArgs e)
        {
            var medicinePrescriptionForm = new MedicinePrescriptionForm();
            medicinePrescriptionForm.Show();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Closes the application
        }
    }
}
