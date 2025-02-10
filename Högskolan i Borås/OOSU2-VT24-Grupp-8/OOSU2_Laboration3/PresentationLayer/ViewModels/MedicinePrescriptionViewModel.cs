using OOSU2_Laboration3.BusinessLayer;
using OOSU2_Laboration3.EntetiesLayer;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OOSU2_Laboration3.PresentationLayer.ViewModels
{
//Viewmodel for handling medicine prescriptions
    public class MedicinePrescriptionViewModel : INotifyPropertyChanged
    {
        private readonly IMedicinePrescriptionService _medicinePrescriptionService;
        private ObservableCollection<MedicinePrescription> _medicationPrescriptions;
        private MedicinePrescription _selectedMedicationPrescription;
        private string _patientIDFilter;
        private MedicinePrescription _newMedicinePrescription;
//Starts a new instance of the medicineprescriptionviewmodel
        public MedicinePrescriptionViewModel(IMedicinePrescriptionService medicinePrescriptionService)
        {
            _medicinePrescriptionService = medicinePrescriptionService;
            _newMedicinePrescription = new MedicinePrescription();
//Relaycommands that execute operations and checks their conditions
            ShowMedicationPrescriptionsCommand = new RelayCommand(async () => await ShowMedicationPrescriptionsAsync(), () => !string.IsNullOrEmpty(PatientIDFilter));
            AddMedicinePrescriptionCommand = new RelayCommand(async () => await AddMedicinePrescriptionAsync());
            RemoveMedicinePrescriptionCommand = new RelayCommand(async () => await RemoveMedicinePrescriptionAsync(), () => SelectedMedicationPrescription != null);
            UpdateMedicinePrescriptionCommand = new RelayCommand(async () => await UpdateMedicinePrescriptionAsync(), () => SelectedMedicationPrescription != null);
            BackCommand = new RelayCommand(Back);

            LoadMedicationPrescriptions();
        }
//getssets the collection of medicine prescriptions
        public ObservableCollection<MedicinePrescription> MedicationPrescriptions
        {
            get { return _medicationPrescriptions; }
            set { _medicationPrescriptions = value; OnPropertyChanged(); }
        }
//Assingn getssets the selected medicine prescriptions
        public MedicinePrescription SelectedMedicationPrescription
        {
            get { return _selectedMedicationPrescription; }
            set { _selectedMedicationPrescription = value; OnPropertyChanged(); }
        }
//Assign getset the patient idfilter
        public string PatientIDFilter
        {
            get { return _patientIDFilter; }
            set { _patientIDFilter = value; OnPropertyChanged(); }
        }
////Assign getset the new medicine prescriptions
        public MedicinePrescription NewMedicinePrescription
        {
            get { return _newMedicinePrescription; }
            set { _newMedicinePrescription = value; OnPropertyChanged(); }
        }
//Command properties for handling UI actions
        public ICommand ShowMedicationPrescriptionsCommand { get; private set; }
        public ICommand AddMedicinePrescriptionCommand { get; private set; }
        public ICommand RemoveMedicinePrescriptionCommand { get; private set; }
        public ICommand UpdateMedicinePrescriptionCommand { get; private set; }
        public ICommand BackCommand { get; private set; }
//Shows the medicine prescriptions for a specific patient by their ID
        private async Task ShowMedicationPrescriptionsAsync()
        {
            if (int.TryParse(PatientIDFilter, out int patientId))
            {
                MedicationPrescriptions = new ObservableCollection<MedicinePrescription>(await _medicinePrescriptionService.GetMedicinePrescriptionsForPatientAsync(patientId));
            }
            else
            {
                MessageBox.Show("Invalid patient ID.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
//Adds a new medicine prescriptions if the patient exists
        private async Task AddMedicinePrescriptionAsync()
        {
            if (await IsPatientExists(NewMedicinePrescription.PatientID))
            {
                await _medicinePrescriptionService.AddMedicinePrescriptionAsync(NewMedicinePrescription);
                await LoadMedicationPrescriptions();
                ClearTextBoxes();
            }
            else
            {
                MessageBox.Show("Patient with the provided ID does not exist.", "Error", MessageBoxButton.OK, MessageBoxImage.Error); //error messagebox
            }
        }
//Removes the selcted medicine presciptions
        private async Task RemoveMedicinePrescriptionAsync()
        {
            if (SelectedMedicationPrescription != null)
            {
                await _medicinePrescriptionService.DeleteMedicinePrescriptionAsync(SelectedMedicationPrescription.Id);
                LoadMedicationPrescriptions();
            }
        }
//Updates prescriptions
        private async Task UpdateMedicinePrescriptionAsync()
        {
            if (SelectedMedicationPrescription != null)
            {
                try
                {
                    //gets all prescriptions for the selected patient
                  
                    var patientPrescriptions = await _medicinePrescriptionService.GetMedicinePrescriptionsForPatientAsync(SelectedMedicationPrescription.PatientID);
                    //Finds the selected prescriptions based on ID
                   
                    var existingPrescription = patientPrescriptions.FirstOrDefault(p => p.Id == SelectedMedicationPrescription.Id);

                    if (existingPrescription != null)
                    {    
                        //Update attributs based on users input
                     
                        if (!string.IsNullOrEmpty(NewMedicinePrescription.PatientID.ToString()))
                        {
                            if (await IsPatientExists(NewMedicinePrescription.PatientID))
                            {
                                existingPrescription.PatientID = NewMedicinePrescription.PatientID;
                            }
                            else
                            {
                                MessageBox.Show("Patient with the provided ID does not exist.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }
                        }

                        if (!string.IsNullOrEmpty(NewMedicinePrescription.NameMedicine))
                        {
                            existingPrescription.NameMedicine = NewMedicinePrescription.NameMedicine;
                        }

                        if (!string.IsNullOrEmpty(NewMedicinePrescription.Dosage))
                        {
                            existingPrescription.Dosage = NewMedicinePrescription.Dosage;
                        }

                        if (!string.IsNullOrEmpty(NewMedicinePrescription.DischargeDate.ToString()))
                        {
                            if (DateTime.TryParse(NewMedicinePrescription.DischargeDate.ToString(), out DateTime newDate))
                            {
                                existingPrescription.DischargeDate = newDate;
                            }
                            else
                            {
                                MessageBox.Show("Invalid date format.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }
                        }

                        if (!string.IsNullOrEmpty(NewMedicinePrescription.CompatibilityComment))
                        {
                            existingPrescription.CompatibilityComment = NewMedicinePrescription.CompatibilityComment;
                        }

                        // Utför uppdateringen i databasen utan att spåra gamla entiteter
                        await _medicinePrescriptionService.UpdateMedicinePrescriptionAsync(existingPrescription);

                        // Uppdatera gränssnittet
                        await LoadMedicationPrescriptions();
                        ClearTextBoxes();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
//Loads all medicine prescriptions
        private async Task LoadMedicationPrescriptions()
        {
            await _medicinePrescriptionService.LoadMedicinePrescriptions();
            MedicationPrescriptions = _medicinePrescriptionService.MedicinePrescriptions;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
//Closes the current view/window
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
//Clears input fields 
        private void ClearTextBoxes()
        {
            NewMedicinePrescription = new MedicinePrescription();
        }
//Controls that a specific patientid exists
        private async Task<bool> IsPatientExists(int patientId)
        {
            var patients = await _medicinePrescriptionService.GetAllPatientsAsync();
            return patients.Any(p => p.Id == patientId);
        }
    }
}
