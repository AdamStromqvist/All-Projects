using OOSU2_Laboration1_AAAV.DataLayer.DataLayer;
using OOSU2_Laboration1_AAAV.EntetiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOSU2_Laboration1_AAAV.BusinessLayer
{
    //-----------------------------------------------------------------------------------------------------------------------
    //DiagnosisManager which only includes RegisterDiagnosis to short down the application a little bit!
    //-----------------------------------------------------------------------------------------------------------------------
    public class DiagnosisManager
    {
        private readonly UnitOfWork unitOfWork; // Here it defines and use UnitOfWork in the DiagnosisManager class. 

        // The line below is a constructor
        public DiagnosisManager(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        
        // Association line between DiagnosisManager and program.cs
        internal PresentationLayer.Program Program 
        {
            get => default;
            set
            {
            }
        }
        
        // method for RegisterDiagnosis
        public void RegisterDiagnosis(Diagnosis diagnosis)
        {
            unitOfWork.DiagnosisRepository.Add(diagnosis);
            unitOfWork.Save();
        }
    }
}
