// LoginView.xaml.cs
using System.Windows.Controls;
using System.Windows;
using OOSU2_Laboration3.PresentationLayer.ViewModels;
using System.Configuration;
using OOSU2_Laboration3.DataLayer;
using Microsoft.EntityFrameworkCore;
using OOSU2_Laboration3.BusinessLayer;
using System.Linq;

namespace OOSU2_Laboration3.PresentationLayer.Views
{
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();

            var connectionString = ConfigurationManager.ConnectionStrings["PatientManagementContext"].ConnectionString;
            var optionsBuilder = new DbContextOptionsBuilder<PatientManagementContext>().UseSqlServer(connectionString);
            var dbContext = new PatientManagementContext(optionsBuilder.Options);
            var unitOfWork = new UnitOfWork(dbContext);

            DataContext = new LoginViewModel(new LoginService(unitOfWork));
            if (DataContext is LoginViewModel viewModel)
            {
                viewModel.CloseAction = CloseParentWindow;
            }
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginViewModel viewModel)
            {
                viewModel.Password = ((PasswordBox)sender).Password;
            }
        }

        private void CloseParentWindow()
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow?.Close();
        }
    }
}
