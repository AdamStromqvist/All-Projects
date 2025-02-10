using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOSU2_Laboration3.DataLayer
{
    //A class collaborating with DBcontext and db to create migrations
    // EnablES Entity Framework Core command-line tools to create migrations and update the database.
    public class PatientManagementContextFactory : IDesignTimeDbContextFactory<PatientManagementContext>
    {
        public PatientManagementContext CreateDbContext(string[] args)
        //"This is the method required by the IDesignTimeDbContextFactory.
        //It is used to create an instance of the PatientManagementContext."
        {
            // Instantiates a builder for DbContextOptions targeting the PatientManagementContext.
            var optionsBuilder = new DbContextOptionsBuilder<PatientManagementContext>();
            optionsBuilder.UseSqlServer(@"Server=sqlutb2-db.hb.se,56077;Database=oosu2408;User ID=oosu2408;Password=UKB987;TrustServerCertificate=True;");

            return new PatientManagementContext(optionsBuilder.Options);
        }
    }
}
