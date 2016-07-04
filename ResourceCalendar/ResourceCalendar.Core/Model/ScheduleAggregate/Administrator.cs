using PremiseResidentProgram.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentAdministratorManagement.Core.Models.ScheduleAggregate
{
    public class Administrator : Entity<int>
    {
        public string FullName { get; private set; }
        public IList<Administrator> Administrators { get; private set; }

        public Administrator(int id)
        {
            this.Id = id;
            Administrators = new List<Administrator>();
        }

        protected Administrator() //required for EF
        {
        }
    }
}
