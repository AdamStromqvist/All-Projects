using Microsoft.EntityFrameworkCore;
using ProjektOOSU2_Test.DataLayer;
using ProjektOOSU2_Test.EntetiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace ProjektOOSU2_Test.BusinessLayer
{

//interface for employees connected to login form

    public interface IEmployeeService 
    {
        Task<bool> ValidateLoginAsync(string username, string password);
    }
    
//Introduce EmployeeService class connected to UnitOfWork
    
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> ValidateLoginAsync(string username, string password)
        {
            var employee = await _unitOfWork.Employees.Find(e => e.Username == username && e.Password == password).FirstOrDefaultAsync();
            return employee != null;
        }
    }
}
