using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentAdministratorManagement.Core.Models.Events
{
    public class AppointmentUpdatedEvent : IDomainEvent
    {
        public AppointmentUpdatedEvent(Appointment appointment)
            : this()
        {
            AppointmentUpdated = appointment;
        }
        public AppointmentUpdatedEvent()
        {
            this.Id = Guid.NewGuid();
            DateTimeEventOccurred = DateTime.Now;
        }

        public Guid Id { get; private set; }
        public DateTime DateTimeEventOccurred { get; private set; }
        public Appointment AppointmentUpdated { get; private set; }
    }
}
