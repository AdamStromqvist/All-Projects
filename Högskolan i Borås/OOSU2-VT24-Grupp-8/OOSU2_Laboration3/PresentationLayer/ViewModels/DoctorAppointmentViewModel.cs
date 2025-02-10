using Microsoft.IdentityModel.Tokens;
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
//ViewModel for managing doctor appointments.

    public class DoctorAppointmentViewModel : INotifyPropertyChanged
    {
        private readonly IDoctorAppointmentService _doctorAppointmentService;
        private ObservableCollection<DoctorAppointment> _appointments;
        private DoctorAppointment _selectedAppointment;
        private string _patientIDFilter;
        private DoctorAppointment _newDoctorAppointment;

//Constructor initializes the ViewModel with a doctor appointment service. 

        public DoctorAppointmentViewModel(IDoctorAppointmentService doctorAppointmentService)
        {
            _doctorAppointmentService = doctorAppointmentService;
            _newDoctorAppointment = new DoctorAppointment();

// Commands are initialized with their respective execution logic.

            ShowAppointmentsCommand = new RelayCommand(async () => await ShowAppointmentsAsync(), () => !string.IsNullOrEmpty(PatientIDFilter));
            AddAppointmentCommand = new RelayCommand(async () => await AddAppointmentAsync());
            RemoveAppointmentCommand = new RelayCommand(async () => await RemoveAppointmentAsync(), () => SelectedAppointment != null);
            UpdateAppointmentCommand = new RelayCommand(async () => await UpdateAppointmentAsync(), () => SelectedAppointment != null);
            BackCommand = new RelayCommand(Back);

            LoadDoctorAppointments();
        }
// Properties for data binding.
        public ObservableCollection<DoctorAppointment> Appointments
        {
            get { return _appointments; }
            set { _appointments = value; OnPropertyChanged(); }
        }

        public DoctorAppointment SelectedAppointment
        {
            get { return _selectedAppointment; }
            set { _selectedAppointment = value; OnPropertyChanged(); }
        }

        public string PatientIDFilter
        {
            get { return _patientIDFilter; }
            set { _patientIDFilter = value; OnPropertyChanged(); }
        }

        public DoctorAppointment NewDoctorAppointment
        {
            get { return _newDoctorAppointment; }
            set { _newDoctorAppointment = value; OnPropertyChanged(); }
        }
// Commands for UI interactions.
        public ICommand ShowAppointmentsCommand { get; private set; }
        public ICommand AddAppointmentCommand { get; private set; }
        public ICommand RemoveAppointmentCommand { get; private set; }
        public ICommand UpdateAppointmentCommand { get; private set; }
        public ICommand BackCommand { get; private set; }

//Loads appointments for a given patient ID.
        private async Task ShowAppointmentsAsync()
        {
            if (int.TryParse(PatientIDFilter, out int patientId))
            {
                Appointments = new ObservableCollection<DoctorAppointment>(await _doctorAppointmentService.GetDoctorAppointmentsForPatientAsync(patientId));
            }
            else
            {
                MessageBox.Show("Invalid patient ID.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
//Adds a new doctor appointment.
        private async Task AddAppointmentAsync()
        {
            if (await IsPatientExists(NewDoctorAppointment.PatientID))
            {
                await _doctorAppointmentService.AddDoctorAppointmentAsync(NewDoctorAppointment);
                LoadDoctorAppointments();
                ClearTextBoxes();
            }
            else
            {
                MessageBox.Show("Patient with the provided ID does not exist.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
//Removes the selected doctor appointment.
        private async Task RemoveAppointmentAsync()
        {
            if (SelectedAppointment != null)
            {
                await _doctorAppointmentService.DeleteDoctorAppointmentAsync(SelectedAppointment.Id);
                LoadDoctorAppointments();
            }
        }
//Updates the selected doctor appointment.
        private async Task UpdateAppointmentAsync()
        {
            if (SelectedAppointment != null) // Logic to update appointment attributes
            {
                try
                {
                 
                    // Gets all bookings for the selected patient
                    var patientAppointments = await _doctorAppointmentService.GetDoctorAppointmentsForPatientAsync(SelectedAppointment.PatientID);

                  
                    // Find the chosen appointment based on its ID
                    var existingAppointment = patientAppointments.FirstOrDefault(a => a.Id == SelectedAppointment.Id);

                    if (existingAppointment != null)
                    {
                       
                        // Update attributes based on users input
                        if (!string.IsNullOrEmpty(NewDoctorAppointment.PatientID.ToString()))
                        {
                            if (await IsPatientExists(NewDoctorAppointment.PatientID))
                            {
                                existingAppointment.PatientID = NewDoctorAppointment.PatientID;
                            }
                            else
                            {
                                MessageBox.Show("Patient with the provided ID does not exist.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }
                        }

                        if (!string.IsNullOrEmpty(NewDoctorAppointment.Date.ToString()))
                        {
                            if (DateTime.TryParse(NewDoctorAppointment.Date.ToString(), out DateTime newDate))
                            {
                                existingAppointment.Date = newDate;
                            }
                            else
                            {
                                MessageBox.Show("Invalid date format.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }
                        }

                        if (!string.IsNullOrEmpty(NewDoctorAppointment.Time))
                        {
                            existingAppointment.Time = NewDoctorAppointment.Time;
                        }

                        if (!string.IsNullOrEmpty(NewDoctorAppointment.Purpose))
                        {
                            existingAppointment.Purpose = NewDoctorAppointment.Purpose;
                        }

                        if (!string.IsNullOrEmpty(NewDoctorAppointment.EmploymentID.ToString()))
                        {
                            if (int.TryParse(NewDoctorAppointment.EmploymentID.ToString(), out int newEmploymentID))
                            {
                                existingAppointment.EmploymentID = newEmploymentID;
                            }
                            else
                            {
                                MessageBox.Show("Employment ID must be a valid integer.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }
                        }

                        if (!string.IsNullOrEmpty(NewDoctorAppointment.Comment))
                        {
                            existingAppointment.Comment = NewDoctorAppointment.Comment;
                        }

                        // Utför uppdateringen i databasen utan att spåra gamla entiteter
                        await _doctorAppointmentService.UpdateDoctorAppointmentAsync(existingAppointment);

                        // Uppdatera gränssnittet
                        await LoadDoctorAppointments();
                        ClearTextBoxes();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


        private async Task<bool> IsPatientExists(int patientId) //Checks if a patient exists in the database.
        {
            var patients = await _doctorAppointmentService.GetAllPatientsAsync();
            return patients.Any(p => p.Id == patientId);
        }
//Loads all doctor appointments from the database.
        private async Task LoadDoctorAppointments()
        {
            await _doctorAppointmentService.LoadDoctorAppointments();
            Appointments = _doctorAppointmentService.DoctorAppointments;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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

        private void ClearTextBoxes() //Clears input fields after adding or updating an appointment.
        {
            NewDoctorAppointment = new DoctorAppointment();
        }
    }
}
