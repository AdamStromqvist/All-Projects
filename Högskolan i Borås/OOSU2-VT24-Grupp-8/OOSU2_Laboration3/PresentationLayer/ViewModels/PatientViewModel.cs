using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using OOSU2_Laboration3.BusinessLayer;
using OOSU2_Laboration3.DataLayer;
using OOSU2_Laboration3.EntetiesLayer;
using OOSU2_Laboration3.PresentationLayer.ViewModels;

public class PatientViewModel : ObservableObject
{
    private readonly IPatientService _patientService; //Service for patient-related data operations.
    private readonly PatientManagementContext _context; //Database context for patient management.

    private ObservableCollection<Patient> _patients = new ObservableCollection<Patient>();

    public ObservableCollection<Patient> Patients
    {
        get => _patients;
        set => SetProperty(ref _patients, value);
    }

    private Patient _selectedPatient; //Holds the selcted patient in the UI
    public Patient SelectedPatient
    {
        get => _selectedPatient;
        set => SetProperty(ref _selectedPatient, value);
    }
//properties to for holding a new patient from input fields
    public string NewPatientName { get; set; }
    public string NewPatientSocialSecurityNr { get; set; }
    public string NewPatientAddress { get; set; }
    public string NewPatientPhoneNr { get; set; }
    public string NewPatientEmailAddress { get; set; }
//Command to interact w the UI
    public ICommand AddPatientCommand { get; private set; }
    public ICommand RemovePatientCommand { get; private set; }
    public ICommand UpdatePatientCommand { get; private set; }
    public ICommand BackCommand { get; private set; }

//Starts a new instance of the patientviewmodel
    public PatientViewModel(IPatientService patientService, PatientManagementContext context)
    {
        _patientService = patientService;
        _context = context;
//Commands with actions and conditions
        AddPatientCommand = new RelayCommand(async () => await AddPatient(), () => true);
        RemovePatientCommand = new RelayCommand(async () => await RemovePatient(), () => SelectedPatient != null);
        UpdatePatientCommand = new RelayCommand(async () => await UpdatePatient(), () => SelectedPatient != null);
        BackCommand = new RelayCommand(Back);

        LoadPatients(); 
    }
//Loads patients
    public async Task LoadPatients()
    {
        var patients = await _patientService.GetAllPatientsAsync();
        Patients = new ObservableCollection<Patient>(patients);
    }
//Adds patient to the db
    private async Task AddPatient()
    {
        try
        {
            if (!CanAddPatient())
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Patient newPatient = new Patient
            {
                PatientName = NewPatientName,
                SocialSecurityNr = NewPatientSocialSecurityNr,
                Address = NewPatientAddress,
                PhoneNr = NewPatientPhoneNr,
                EmailAddress = NewPatientEmailAddress
            };

            await _patientService.AddPatientAsync(newPatient);
            await LoadPatients();
            ClearTextBoxes();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred while adding the patient: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
//Clears input fields after adding or updating a patient
    private void ClearTextBoxes()
    {
        Application.Current.Dispatcher.Invoke(() =>
        {
            NewPatientName = string.Empty;
            NewPatientSocialSecurityNr = string.Empty;
            NewPatientAddress = string.Empty;
            NewPatientPhoneNr = string.Empty;
            NewPatientEmailAddress = string.Empty;

            // Force UI update
            OnPropertyChanged(nameof(NewPatientName));
            OnPropertyChanged(nameof(NewPatientSocialSecurityNr));
            OnPropertyChanged(nameof(NewPatientAddress));
            OnPropertyChanged(nameof(NewPatientPhoneNr));
            OnPropertyChanged(nameof(NewPatientEmailAddress));

            // Reset focus to another control if needed
            // e.g., FocusManager.SetFocusedElement(this, otherControl);
        });
    }
//Removes selected patients from db
    private async Task RemovePatient()
    {
        if (SelectedPatient != null)
        {
            await _patientService.DeletePatientAsync(SelectedPatient.Id);
            await LoadPatients();
        }
    }
//Updates existing selected patient from db w new data
    private async Task UpdatePatient()
    {
        if (SelectedPatient != null)
        {
            try
            {
                // Check which textbox was edited and update the corresponding property of SelectedPatient
                if (!string.IsNullOrEmpty(NewPatientName))
                {
                    SelectedPatient.PatientName = NewPatientName;
                }
                else if (!string.IsNullOrEmpty(NewPatientSocialSecurityNr))
                {
                    SelectedPatient.SocialSecurityNr = NewPatientSocialSecurityNr;
                }
                else if (!string.IsNullOrEmpty(NewPatientAddress))
                {
                    SelectedPatient.Address = NewPatientAddress;
                }
                else if (!string.IsNullOrEmpty(NewPatientPhoneNr))
                {
                    SelectedPatient.PhoneNr = NewPatientPhoneNr;
                }
                else if (!string.IsNullOrEmpty(NewPatientEmailAddress))
                {
                    SelectedPatient.EmailAddress = NewPatientEmailAddress;
                }

                // Call the service to update the patient
                await _patientService.UpdatePatientAsync(SelectedPatient);

                // Reload patients after update
                await LoadPatients();

                // Clear the selection in the DataGrid
                SelectedPatient = null;

                // Clear the text boxes
                ClearTextBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the patient: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

//Closes current window
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
//Controlling the input fields if adding a new patient is possible
    private bool CanAddPatient()
    {
        return !string.IsNullOrWhiteSpace(NewPatientName)
            && !string.IsNullOrWhiteSpace(NewPatientSocialSecurityNr)
            && !string.IsNullOrWhiteSpace(NewPatientAddress)
            && !string.IsNullOrWhiteSpace(NewPatientPhoneNr)
            && !string.IsNullOrWhiteSpace(NewPatientEmailAddress);
    }
}
