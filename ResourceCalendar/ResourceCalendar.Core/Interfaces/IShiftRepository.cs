using ResourceCalendar.Core.Model.ScheduleAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceCalendar.Core.Interfaces
{
    public interface IAppointmentRepository
    {
        IEnumerable<Shift> List();
    }
}
