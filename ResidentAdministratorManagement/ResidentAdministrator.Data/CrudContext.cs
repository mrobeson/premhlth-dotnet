using ResidentAdministratorManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentAdministrator.Data
{
    public class CrudContext : DbContext
    {

        public CrudContext()
        : base("name=ResourceCalendarContext")
        {
        }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Resident> Residents { get; set; }

    }

    public class TestInitializerForCrudContext : DropCreateDatabaseAlways<CrudContext>
    {
        protected override void Seed(CrudContext context)
        {
            base.Seed(context);

            // Add Residents
            var testResident = new Resident { FullName = "Test Resident" };
            context.Residents.Add(testResident);

            // Add Administrators
            var testAdministrator = new Administrator { FullName = "Test Administrator" };
            context.Administrators.Add(testAdministrator);

        }
    }
}
