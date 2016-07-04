using PremiseResidentProgram.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentAdministratorManagement.Core.Models.ScheduleAggregate
{
    public class Resident : Entity<int>
    {
        public string FullName { get; private set; }
        public IList<Resident> Residents { get; private set; }

        public Resident(int id)
        {
            this.Id = id;
            Residents = new List<Resident>();
        }

        protected Resident() //required for EF
        {
        }
    }
}
