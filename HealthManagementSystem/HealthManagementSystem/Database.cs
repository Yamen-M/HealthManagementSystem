using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthManagementSystem
{
    internal class Database
    {
        private List<NewAppointment> appointments = new List<NewAppointment>();
        static Database _instance;
        private Database() { }

        public static Database GetDatabase() { 

            if (_instance == null)
            {
                _instance = new Database();
            }
            return _instance; 
        }
        public void addAppointment(NewAppointment appointment)
        {
            appointments.Add(appointment);
        }
        public override string  ToString()
        {
            if (appointments.Count > 0)
            {
                int i = 0;
                StringBuilder sb = new StringBuilder();
                foreach (NewAppointment appointment in appointments)
                {
                    sb.AppendLine($"Appointment {++i}\n");
                    sb.Append(appointment.ToString());
                    sb.AppendLine().AppendLine();
                }
                return sb.ToString();
            }
            return "The Database Is Empty!";
        }
    }
}
