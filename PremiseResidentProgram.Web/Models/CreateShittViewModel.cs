using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PremiseResidentProgram.Web.Models
{
    public class CreateShiftViewModel
    {
        public int PatientId { get; set; }
        public int ClientId { get; set; }
        public DateTime DateOfAppointment { get; set; }
        public TimeSpan Duration { get; set; }
        public Guid SelectedDoctor { get; set; }
        public string Details { get; set; }
    }

    public class ResidentViewModel
    {
        public string FullName { get; set; }
        public IEnumerable<ResidentViewModel> Residents { get; set; }
    }

    public class AdministratorViewModel
    {
        public String FullName { get; set; }
        //public IEnumerable<AdministratortViewModel> Residents { get; set; }
    }

    public class ShiftViewModel
    {
        public Guid ShiftId { get; set; }
        //public int AppointmentTypeId { get; set; }
        public int ResidentId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public object StartTimezone { get; set; }
        public object EndTimezone { get; set; }
        public object RecurrenceRule { get; set; }
        public object RecurrenceID { get; set; }
        public object RecurrenceException { get; set; }
        public string Title { get; set; }
        public bool IsPotentiallyConflicting { get; set; }
        public bool IsConfirmed { get; set; }
    }
}