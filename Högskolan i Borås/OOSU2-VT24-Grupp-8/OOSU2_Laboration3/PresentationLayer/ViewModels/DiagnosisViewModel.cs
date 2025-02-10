using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using OOSU2_Laboration3.BusinessLayer;
using OOSU2_Laboration3.EntetiesLayer;

namespace OOSU2_Laboration3.PresentationLayer.ViewModels
{
//ViewModel for managing diagnosis-related operations and interactions.

    public class DiagnosisViewModel : INotifyPropertyChanged
    {
        private readonly IDiagnosisService _diagnosisService;
        private ObservableCollection<Diagnosis> _diagnoses;
        private Diagnosis _selectedDiagnosis;
        private string _patientIDFilter;
        private Diagnosis _newDiagnosis;
        
//Constructor initializes the ViewModel with a diagnosis service.
        public DiagnosisViewModel(IDiagnosisService diagnosisService)
        {
            _diagnosisService = diagnosisService;
            _newDiagnosis = new Diagnosis();
            
// Initializing commands with their execution logic and conditions.
            ShowDiagnosesCommand = new RelayCommand(async () => await ShowDiagnosesAsync(), () => !string.IsNullOrEmpty(PatientIDFilter));
            AddDiagnosisCommand = new RelayCommand(async () => await AddDiagnosisAsync());
            RemoveDiagnosisCommand = new RelayCommand(async () => await RemoveDiagnosisAsync(), () => SelectedDiagnosis != null);
            UpdateDiagnosisCommand = new RelayCommand(async () => await UpdateDiagnosisAsync(), () => SelectedDiagnosis != null);
            BackCommand = new RelayCommand(Back);

            LoadDiagnoses();
        }
//Filter string to load diagnoses for a specific patient ID.
        public string PatientIDFilter
        {
            get { return _patientIDFilter; }
            set { _patientIDFilter = value; OnPropertyChanged(); }
        }
//Collection of diagnoses to be displayed in the UI.
        public ObservableCollection<Diagnosis> Diagnoses
        {
            get { return _diagnoses; }
            set { _diagnoses = value; OnPropertyChanged(); }
        }
//Currently selected diagnosis in the UI.
        public Diagnosis SelectedDiagnosis
        {
            get { return _selectedDiagnosis; }
            set { _selectedDiagnosis = value; OnPropertyChanged(); }
        }
//New diagnosis instance to be added.
        public Diagnosis NewDiagnosis
        {
            get { return _newDiagnosis; }
            set { _newDiagnosis = value; OnPropertyChanged(); }
        }
//Command properties for UI interactions.
        public ICommand ShowDiagnosesCommand { get; }
        public ICommand AddDiagnosisCommand { get; }
        public ICommand RemoveDiagnosisCommand { get; }
        public ICommand UpdateDiagnosisCommand { get; }
        public ICommand BackCommand { get; }

//Shows diagnoses for a specific patient, determined by PatientIDFilter.
      
        private async Task ShowDiagnosesAsync()
        {
            try
            {
                Diagnoses = new ObservableCollection<Diagnosis>(await _diagnosisService.GetDiagnosesForPatientAsync(Convert.ToInt32(PatientIDFilter)));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while fetching diagnoses: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
//Adds a new diagnosis to the system.
        private async Task AddDiagnosisAsync()
        {
            if (await IsPatientExists(NewDiagnosis.PatientID))
            {
                try
                {
                    await _diagnosisService.AddDiagnosisAsync(NewDiagnosis);
                    await LoadDiagnoses(); 
                    ClearTextBoxes(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while adding diagnosis: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Patient with the provided ID does not exist.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

//Removes the selected diagnosis from the system.
        private async Task RemoveDiagnosisAsync()
        {
            try
            {
                await _diagnosisService.DeleteDiagnosisAsync(SelectedDiagnosis.Id);
                await ShowDiagnosesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while removing diagnosis: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
//Updates the selected diagnosis with new details.
        private async Task UpdateDiagnosisAsync()
        {
            if (SelectedDiagnosis != null)
            {
                try
                {
                    // Get all diagnoses for the selected patient
                    var patientDiagnoses = await _diagnosisService.GetDiagnosesForPatientAsync(SelectedDiagnosis.PatientID);

                    // Find the selected diagnosis based on its ID
                    var existingDiagnosis = patientDiagnoses.FirstOrDefault(d => d.Id == SelectedDiagnosis.Id);

                    if (existingDiagnosis != null)
                    {
                        // Update the attributes based on user input
                        if (!string.IsNullOrEmpty(NewDiagnosis.PatientID.ToString()))
                        {
                            if (await IsPatientExists(NewDiagnosis.PatientID))
                            {
                                existingDiagnosis.PatientID = NewDiagnosis.PatientID;
                            }
                            else
                            {
                                MessageBox.Show("Patient with the provided ID does not exist.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }
                        }

                        if (!string.IsNullOrEmpty(NewDiagnosis.DiagnosisDescription))
                        {
                            existingDiagnosis.DiagnosisDescription = NewDiagnosis.DiagnosisDescription;
                        }

                        if (!string.IsNullOrEmpty(NewDiagnosis.Date.ToString()))
                        {
                            if (DateTime.TryParse(NewDiagnosis.Date.ToString(), out DateTime newDate))
                            {
                                existingDiagnosis.Date = newDate;
                            }
                            else
                            {
                                MessageBox.Show("Invalid date format.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }
                        }

                        if (!string.IsNullOrEmpty(NewDiagnosis.TreatmentProposal))
                        {
                            existingDiagnosis.TreatmentProposal = NewDiagnosis.TreatmentProposal;
                        }

                        // Perform the update in the database without tracking old entities
                        await _diagnosisService.UpdateDiagnosisAsync(existingDiagnosis);

                        // Update the interface
                        await LoadDiagnoses();
                        ClearTextBoxes();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


        private void Back()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.DataContext == this)
                {
                    window.Close();
                    break;
                }
            }
        }
//Loads all diagnoses into the ObservableCollection.
        private async Task LoadDiagnoses()
        {
            try
            {
                await _diagnosisService.LoadDiagnoses(); // Assuming this method loads diagnoses from the service
                Diagnoses = _diagnosisService.Diagnoses; // Assuming Diagnoses is a property holding the loaded diagnoses
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load diagnoses: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
//Clears all text boxes in the UI, resetting the new diagnosis entry
        private void ClearTextBoxes()
        {
            NewDiagnosis = new Diagnosis(); // Resetting the NewDiagnosis object to a new instance
        }
//Checks if a patient with a specific ID exists in the database.
        private async Task<bool> IsPatientExists(int patientId)
        {
            var patients = await _diagnosisService.GetAllPatientsAsync();
            return patients.Any(p => p.Id == patientId);
        }
    }
}
