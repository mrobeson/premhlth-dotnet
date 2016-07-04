using PremiseResidentProgram.SharedKernel;
using PremiseResidentProgram.SharedKernel.Enums;
using ResourceCalendar.Core.Model.ScheduleAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentAdministratorManagement.Core.Models.ScheduleAggregate
{
    public class Schedule : Entity<Guid>//, IHandle<AppointmentUpdatedEvent>
    {
        public int ResidentId { get; private set; }

        // not persisted
        public DateTime Start { get; private set; }

        public DateTime End { get; private set; }

        private List<Shift> _shifts;
        public IEnumerable<Shift> Shifts
        {
            get
            {
                return _shifts.AsEnumerable();
            }
            set
            {
                _shifts = (List<Shift>) value;
            }
        }

        public Schedule(Guid id, DateTime start, DateTime end, int residentId)
            : base(id)
        {
            Start = start;
            End = end;
            ResidentId = residentId;
            _shifts = new List<Shift>();

            //DomainEvents.Register<ShiftUpdatedEvent>(Handle);
        }

        private Schedule()
            : base(Guid.NewGuid()) // required for EF
        {
            _shifts = new List<Shift>();
        }

        public void AddExistingAppointments(IEnumerable<Shift> shifts)
        {
            shifts.ToList().ForEach(a => _shifts.Add(a));

            //MarkConflictingShift();
        }

        public Shift AddNewAppointment(Shift shift)
        {
            if (_shifts.Any(a => a.Id == shift.Id))
            {
                throw new ArgumentException("Cannot add duplicate shift to schedule.", "shift");
            }

            shift.State = TrackingState.Added;
            _shifts.Add(shift);

            //MarkConflictingAppointments();

            //var appointmentScheduledEvent = new AppointmentScheduledEvent(appointment);
            //DomainEvents.Raise(appointmentScheduledEvent);

            return shift;
        }

        public void DeleteAppointment(Shift shift)
        {
            // mark the appointment for deletion by the repository
            var shiftToDelete = this.Shifts.Where(a => a.Id == shift.Id).FirstOrDefault();
            if (shiftToDelete != null)
            {
                shiftToDelete.State = TrackingState.Deleted;
            }

            //MarkConflictingShifts();
        }

        //private void MarkConflictingShifts()
        //{
        //    foreach (var appointment in _appointments)
        //    {
        //        var potentiallyConflictingAppointments = _appointments
        //            .Where(a => a.PatientId == appointment.PatientId &&
        //            a.TimeRange.Overlaps(appointment.TimeRange) &&
        //            a.Id != appointment.Id &&
        //            a.State != TrackingState.Deleted).ToList();

        //        potentiallyConflictingAppointments.ForEach(a => a.IsPotentiallyConflicting = true);

        //        appointment.IsPotentiallyConflicting = potentiallyConflictingAppointments.Any();
        //    }
        //}

        //public void Handle(AppointmentUpdatedEvent args)
        //{
        //    MarkConflictingAppointments();
        //}
    }
}
