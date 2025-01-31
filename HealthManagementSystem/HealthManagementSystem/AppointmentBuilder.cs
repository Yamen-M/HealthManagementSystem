using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace HealthManagementSystem
{
    public abstract class AppointmentBuilder
    {
        public Appointment appointment {  get; set; }

        public abstract void SetPatient(IPatient p);
        public abstract void SetDoctor(IDoctor d);

        public abstract void SetDate(DateTime date);
        public abstract void SetTime(string time);
        public abstract void SetStatus(AppointmentStatus s);
        public abstract void setBill(IBill b);
    }
}