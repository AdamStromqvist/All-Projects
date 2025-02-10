using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjektOOSU2_Test.BusinessLayer;
using ProjektOOSU2_Test.DataLayer;
using ProjektOOSU2_Test.EntetiesLayer;
using ProjektOOSU2_Test.PresentationLayer;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace ProjektOOSU2_Test
{

    //A class that has everything for starting the program
    static class Program
    {


        // Global access to UnitOfWork if required
       
        public static IUnitOfWork UnitOfWork { get; private set; }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Configurate DbContextOptions
            var optionsBuilder = new DbContextOptionsBuilder<PatientManagementContext>();
            optionsBuilder.UseSqlServer(@"Server=sqlutb2-db.hb.se,56077;Database=oosu2408;User ID=oosu2408;Password=UKB987;TrustServerCertificate=True;");

            // Create an instans of DbContext
            var context = new PatientManagementContext(optionsBuilder.Options);
            
            var unitOfWork = new UnitOfWork(context);
            var employeeService = new EmployeeService(unitOfWork);
            var loginForm = new LoginForm(employeeService);

            // Create a global instans of UnitOfWork (optional, depending on design)
            UnitOfWork = new UnitOfWork(context);

            // Start application with main form
          
            // Assume MainForm is your startup form, replace it with your actual startup form
           
            Application.Run(loginForm);
        }
    }



}
