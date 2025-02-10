using ProjektOOSU2_Test.BusinessLayer;
using ProjektOOSU2_Test.EntetiesLayer;
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

//class for patientform
    public partial class PatientForm : Form
    {
        private readonly IPatientService _patientService;

        public PatientForm(IPatientService patientService)
        {
            InitializeComponent();
            _patientService = patientService;
            this.Load += PatientForm_Load;
        }

        private async void PatientForm_Load(object sender, EventArgs e)
        {
            var patients = await _patientService.GetAllPatientsAsync();
            listBoxPatients.DataSource = patients.ToList();
            listBoxPatients.DisplayMember = "PatientName"; //show patient name
            listBoxPatients.ValueMember = "Id"; // use Id as source
        }

        private async Task UpdatePatientListAsync()
        {
            var patients = await _patientService.GetAllPatientsAsync();
            listBoxPatients.DataSource = patients.ToList();
            listBoxPatients.DisplayMember = "PatientName";
            listBoxPatients.ValueMember = "Id";
        }

        private void listBoxPatients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxPatients.SelectedItem is Patient selectedPatient)
            {
                var patientDetails = new List<string>
                {
                    $"Id: {selectedPatient.Id}",
                    $"Name: {selectedPatient.PatientName}",
                    $"SSN: {selectedPatient.SocialSecurityNr}",
                    $"Address: {selectedPatient.Address}",
                    $"Phone: {selectedPatient.PhoneNr}",
                    $"Email: {selectedPatient.EmailAddress}"
                };

                listBoxPatientInformation.DataSource = patientDetails;
            }
        }

        private void listBoxPatientInformation_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void buttonDeletePatient_Click(object sender, EventArgs e)
        {
            if (listBoxPatients.SelectedItem is Patient selectedPatient)
            {
                await _patientService.DeletePatientAsync(selectedPatient.Id);
                // update list after removal
                await UpdatePatientListAsync();
            }
        }

        private void textBoxPatientName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxAdress_TextChanged(object sender, EventArgs e)
        {

        }

        private async void buttonAddPatient_Click(object sender, EventArgs e)
        {
            var newPatient = new Patient
            {
                PatientName = textBoxPatientName.Text,
                SocialSecurityNr = textBoxSocialSecurityNr.Text,
                Address = textBoxAdress.Text,
                PhoneNr = textBoxPhoneNr.Text,
                EmailAddress = textBoxEmailAdress.Text
            };

            await _patientService.AddPatientAsync(newPatient);
            // Update list after add
            await UpdatePatientListAsync();
        }

        private async void buttonUpdatePatient_Click(object sender, EventArgs e)
        {
            if (listBoxPatients.SelectedItem is Patient selectedPatient)
            {
                selectedPatient.PatientName = textBoxPatientName.Text;
                selectedPatient.SocialSecurityNr = textBoxSocialSecurityNr.Text;
                selectedPatient.Address = textBoxAdress.Text;
                selectedPatient.PhoneNr = textBoxPhoneNr.Text;
                selectedPatient.EmailAddress = textBoxEmailAdress.Text;

                await _patientService.UpdatePatientAsync(selectedPatient);
                // Update list after update
                await UpdatePatientListAsync();
            }
        }
    }
}
