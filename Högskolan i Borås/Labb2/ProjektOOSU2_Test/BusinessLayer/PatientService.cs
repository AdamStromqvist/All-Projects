using ProjektOOSU2_Test.DataLayer;
using ProjektOOSU2_Test.EntetiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektOOSU2_Test.BusinessLayer
{

//Interface connected to Patientform

        public interface IPatientService
        {
            Task<IEnumerable<Patient>> GetAllPatientsAsync();
            Task AddPatientAsync(Patient patient);
            Task UpdatePatientAsync(Patient patient);
            Task DeletePatientAsync(int patientId);
            
        }
//Introduce class PatientService connected to UnitOfWork
        
        public class PatientService : IPatientService
        {
            private readonly IUnitOfWork _unitOfWork;

            public PatientService(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
            {
                return await _unitOfWork.Patients.GetAllAsync();
            }

            public async Task AddPatientAsync(Patient patient)
            {
                await _unitOfWork.Patients.AddAsync(patient);
                await _unitOfWork.CompleteAsync();
            }

            public async Task UpdatePatientAsync(Patient patient)
            {
                _unitOfWork.Patients.Update(patient);
                await _unitOfWork.CompleteAsync();
            }

            public async Task DeletePatientAsync(int patientId)
            {
                var patient = await _unitOfWork.Patients.GetByIdAsync(patientId);
                if (patient != null)
                {
                    _unitOfWork.Patients.Remove(patient);
                    await _unitOfWork.CompleteAsync();
                }
            }
        }
    
}
