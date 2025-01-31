using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthManagementSystem
{
    public class ConcreteAppointmentBuilder : AppointmentBuilder
    {
        public ConcreteAppointmentBuilder() { appointment = new Appointment(); }

        public Appointment Appointment
        {
            get => default;
            set
            {
            }
        }

        public override void SetPatient(IPatient p) { appointment.patient = p; }
        public override void SetDoctor(IDoctor d) { appointment.doctor = d; }

        public override void SetDate(DateTime date) { appointment.Date = date; }
        public override void SetTime(string time) { appointment.Time = time; }
        public override void SetStatus(AppointmentStatus s) { appointment.setStatus(s); }
        public override void setBill(IBill b) {  appointment.bill = b; }
    }

    public class Appointment
    {
        private AppointmentStatus status;
        public IPatient patient {  get; set; }
        public IDoctor doctor { get; set; } 
        public DateTime Date { get; set; }

        public string Time { get; set; }

        public IBill bill { get; set; }

        public void setStatus(AppointmentStatus s)
        {
            status = s;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"\nScheduled Date: {Date.ToString("dddd MMM,dd,yyyy")}\n");
            sb.AppendLine($"Appointment Time: {Time}");
            sb.AppendLine($"Appointment Status: {status}");
            return $"Appointment Info:\n{patient.ToString()}\nDoctor Information:\n{doctor.ToString()}\n\nSchedule:{sb.ToString()}\nBill:\n{bill.ToString()}";
        }
    }
}