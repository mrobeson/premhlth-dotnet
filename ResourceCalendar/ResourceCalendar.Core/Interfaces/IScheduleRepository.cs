using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceCalendar.Core.Interfaces
{
    public interface IScheduleRepository
    {
        Schedule GetScheduledAppointmentsForDate(int clinicId, DateTime date);
        void Update(Schedule schedule);
    }
}
