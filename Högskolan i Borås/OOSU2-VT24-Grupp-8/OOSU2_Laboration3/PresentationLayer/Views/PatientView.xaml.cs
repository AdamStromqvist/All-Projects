using Microsoft.EntityFrameworkCore;
using OOSU2_Laboration3.BusinessLayer;
using OOSU2_Laboration3.DataLayer;
using System;
using System.Windows;

namespace OOSU2_Laboration3.PresentationLayer.Views
{
    /// <summary>
    /// Interaction logic for PatientView.xaml
    /// </summary>
    public partial class PatientView : Window
    {
        private readonly PatientManagementContext _context;

        public PatientView()
        {
            InitializeComponent();

            // Set up DbContext options
            var optionsBuilder = new DbContextOptionsBuilder<PatientManagementContext>();
            optionsBuilder.UseSqlServer(@"Server=sqlutb2-db.hb.se,56077;Database=oosu2408;User ID=oosu2408;Password=UKB987;TrustServerCertificate=True;");

            // Creates DbContext with the specified options
            _context = new PatientManagementContext(optionsBuilder.Options);

            // Pass the DbContext to the UnitOfWork
            DataContext = new PatientViewModel(new PatientService(new UnitOfWork(_context)), _context);
        }
    }
}
