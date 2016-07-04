using PremiseResidentProgram.SharedKernel.Interfaces;
using ResourceCalendar.Core.Model.ScheduleAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceCalendar.Core.Models.Events
{
    public class ShiftScheduledEvent : IDomainEvent
    {
        public ShiftScheduledEvent(Shift shift) : this()
        {
            ShiftScheduled = shift;
        }

        public ShiftScheduledEvent()
        {
            this.Id = Guid.NewGuid();
            DateTimeEventOccurred = DateTime.Now;
        }

        public Guid Id { get; private set; }

        public DateTime DateTimeEventOccurred { get; private set; }

        public Shift ShiftScheduled { get; private set; }
    }
}
