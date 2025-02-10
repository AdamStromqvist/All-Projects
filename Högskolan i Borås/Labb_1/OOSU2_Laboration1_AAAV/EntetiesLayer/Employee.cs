using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOSU2_Laboration1_AAAV.EntetiesLayer
{
    // Entity class representing an Employee
    public class Employee
    {
        public int EmploymentID { get; set; }  // Unique employment identifier
        public string NameEmployee { get; set; } // Name of the employee
        public string Profession { get; set; }   // Profession or job title
        public string Password { get; set; }    // Employee's password (for authentication)
        public string Specialization { get; set; } // Specialization (if applicable)

        public DataLayer.DB DB
        {
            get => default;
            set
            {
            }
        }

        public DataLayer.Repository<object> Repository
        {
            get => default;
            set
            {
            }
        }
    }
}
