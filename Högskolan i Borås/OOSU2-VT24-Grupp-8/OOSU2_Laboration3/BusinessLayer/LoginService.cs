using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OOSU2_Laboration3.DataLayer;

namespace OOSU2_Laboration3.BusinessLayer
{

    public interface ILoginService //Declares a public interface with the name ILoginService
    {
        Task<bool> ValidateLoginAsync(string username, string password); //Recieves a username and password, controlling if the typed information matches a db, returning true or false
    }

    public class LoginService : ILoginService //public class that implements the ILoginService interface. 
    {
        private readonly IUnitOfWork _unitOfWork;

        public LoginService(IUnitOfWork unitOfWork)
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
