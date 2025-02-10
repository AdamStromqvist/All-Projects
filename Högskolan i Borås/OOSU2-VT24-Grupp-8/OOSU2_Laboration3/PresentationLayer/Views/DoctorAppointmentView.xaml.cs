using Microsoft.EntityFrameworkCore;
using OOSU2_Laboration3.BusinessLayer;
using OOSU2_Laboration3.DataLayer;
using OOSU2_Laboration3.PresentationLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OOSU2_Laboration3.PresentationLayer.Views
{
    /// <summary>
    /// Interaction logic for DoctorAppointmentView.xaml
    /// </summary>
    public partial class DoctorAppointmentView : Window
    {

        private readonly PatientManagementContext _context;

        public DoctorAppointmentView()
        {
            InitializeComponent();
            
            // Set up DbContext options
            var optionsBuilder = new DbContextOptionsBuilder<PatientManagementContext>();
            optionsBuilder.UseSqlServer(@"Server=sqlutb2-db.hb.se,56077;Database=oosu2408;User ID=oosu2408;Password=UKB987;TrustServerCertificate=True;");

            // Create DbContext with the specified options
            _context = new PatientManagementContext(optionsBuilder.Options);

            DataContext = new DoctorAppointmentViewModel(new DoctorAppointmentService(new UnitOfWork(_context)));
        }
    }
}
