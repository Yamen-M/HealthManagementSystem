using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthManagementSystem
{
    public class HealthcareFacility
    {
        private static HealthcareFacility _instance;

        private Database Database;
        private HealthcareFacility() { 
            Database = Database.GetDatabase();
        }



        public static HealthcareFacility GetInstance()
        {
            
            
                if (_instance == null)
                {
                    _instance = new HealthcareFacility();
                }
                return _instance;
            
        }
        public override string ToString()
        {
            return Database.ToString();
        }

        public void addToDatabase(NewAppointment appointment)
        {
            Database.addAppointment(appointment);
        }
        
    }

}
