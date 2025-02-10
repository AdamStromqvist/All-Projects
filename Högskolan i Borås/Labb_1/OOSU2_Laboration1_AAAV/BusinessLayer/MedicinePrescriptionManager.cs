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
    //MedicinePrescriptionManager which only includes RegisterMedicinePrescription to short down the application a little bit!
    //-----------------------------------------------------------------------------------------------------------------------
    public class MedicinePrescriptionManager
    {
        private readonly UnitOfWork unitOfWork; // Here it defines and use UnitOfWork in the MedicinePrescriptionManager class. 

        // A constructor
        public MedicinePrescriptionManager(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // Association line between program.cs and MedicinePrescriptionManager
        internal PresentationLayer.Program Program
        {
            get => default;
            set
            {
            }
        }

        // Register a medcine prescription
        public void RegisterMedicinePrescription(MedicinePrescription prescription)
        {
            unitOfWork.MedicinePrescriptionRepository.Add(prescription);
            unitOfWork.Save();
        }
    }
}
