using PremiseResidentProgram.SharedKernel;
using PremiseResidentProgram.SharedKernel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceCalendar.Core.Model.ScheduleAggregate
{
    public class Shift : Entity<Guid>
    {
        public Guid ShiftId { get; private set; }
        public int ResidentId { get; private set; }      
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }
        public string Title { get; set; }

        #region More Properties
        public DateTime? DateTimeConfirmed { get; set; }

        // not persisted
        public TrackingState State { get; set; }
        public bool IsPotentiallyConflicting { get; set; }
        #endregion

        public Shift(Guid id)
            : base(id)
        {
        }

        private Shift()
            : base(Guid.NewGuid()) // required for EF
        {
        }

        //public void UpdateRoom(int newRoomId)
        //{
        //    if (newRoomId == RoomId) return;

        //    RoomId = newRoomId;

        //    var appointmentUpdatedEvent = new AppointmentUpdatedEvent(this);
        //    DomainEvents.Raise(appointmentUpdatedEvent);
        //}

        //public void UpdateTime(DateTimeRange newStartEnd)
        //{
        //    if (newStartEnd == TimeRange) return;

        //    TimeRange = newStartEnd;

        //    var appointmentUpdatedEvent = new AppointmentUpdatedEvent(this);
        //    DomainEvents.Raise(appointmentUpdatedEvent);
        //}

        //public void Confirm(DateTime dateConfirmed)
        //{
        //    if (DateTimeConfirmed.HasValue) return; // no need to reconfirm

        //    DateTimeConfirmed = dateConfirmed;

        //    var appointmentConfirmedEvent = new AppointmentConfirmedEvent(this);
        //    DomainEvents.Raise(appointmentConfirmedEvent);
        //}

        // Factory method for creation
        public static Shift Create(Guid scheduleId,
            int residentId, DateTime startTime, DateTime endTime,
            string title)
        {
            Guard.ForLessEqualZero(residentId, "residentId");
            Guard.ForNullOrEmpty(title, "title");
            Guard.ForNullOrEmpty(title, "start");
            Guard.ForNullOrEmpty(title, "end");
            var shift = new Shift(Guid.NewGuid());
            shift.ResidentId = residentId;
            shift.Start = startTime;    
            shift.Title = title;
            return shift;
        }
    }
}
