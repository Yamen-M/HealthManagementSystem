using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthManagementSystem
{
    public class NewAppointment
    {
        private AppointmentBuilder ab;
        public NewAppointment() { ab = new ConcreteAppointmentBuilder(); }

        public void CreateAppointment(IPatient p, IDoctor d, DateTime date, string time, AppointmentStatus s, IBill b )
        {
            ab.SetPatient( p );
            ab.SetDoctor( d );
            ab.SetDate( date );
            ab.SetTime(time);
            ab.SetStatus( s );
            ab.setBill( b );
        }
        public override string ToString()
        {
            return ab.appointment.ToString();
        }
    }
}