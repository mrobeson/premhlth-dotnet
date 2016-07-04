using ResidentAdministratorManagement.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentAdministratorManagement.Core.Models
{
    public class Administrator: IEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }
}
