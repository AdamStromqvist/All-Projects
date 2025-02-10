using System.Windows;
using OOSU2_Laboration3.PresentationLayer.Views;
using System.Windows.Input;
using OOSU2_Laboration3.PresentationLayer.ViewModels;

namespace OOSU2_Laboration3.PresentationLayer.Views
{
//ViewModel for the Main Menu. This ViewModel handles navigation and operations from the main menu interface.
    public class MainMenuViewModel : ObservableObject
    {
    //ICommand properties for handling UI actions. These commands are bound to buttons in the MainMenu view.
        public ICommand OpenPatientHandlerCommand { get; }
        public ICommand OpenVisitHandlerCommand { get; }
        public ICommand OpenDiagnosisHandlerCommand { get; }
        public ICommand OpenPrescriptionHandlerCommand { get; }
        public ICommand ShutdownCommand { get; }
//Constructor initializes commands for opening different views and shutting down the application.
        public MainMenuViewModel()
        {
       //Initialize commands with specific actions using RelayCommand, which allows for the execution of a method when the command is invoked.
            OpenPatientHandlerCommand = new RelayCommand(() => OpenHandler("Patient"));
            OpenVisitHandlerCommand = new RelayCommand(() => OpenHandler("Visit"));
            OpenDiagnosisHandlerCommand = new RelayCommand(() => OpenHandler("Diagnosis"));
            OpenPrescriptionHandlerCommand = new RelayCommand(() => OpenHandler("Prescription"));
            ShutdownCommand = new RelayCommand(App.Current.Shutdown);
        }
//Opens a window based on the provided window object.
        private void OpenWindow(Window window)
        {
            window.Show(); // Use Show for non-modal or ShowDialog for modal windows
            
        }


//A string that identifies the type of view to open
        private void OpenHandler(string handlerType)
        {
            // Implement navigation or opening of different views based on handlerType
            switch (handlerType)
            {
            //Opens the Patient management view
                case "Patient":
                    OpenWindow(new PatientView());
                    break;
             // Opens the Visit management view       
                case "Visit":
                    OpenWindow(new DoctorAppointmentView());
                    break;
            //opens the diagnosis management view
                case "Diagnosis":
                    OpenWindow(new DiagnosisView());
                    break;
            //opens the prescription management view
                case "Prescription":
                    OpenWindow(new MedicinePrescriptionView());
                    break;
                default:
                    MessageBox.Show("Unknown handler type."); //error message for unknown
                    break;
            }
        }
    }
}
