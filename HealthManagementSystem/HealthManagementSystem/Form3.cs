using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthManagementSystem
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            HealthcareFacility H = HealthcareFacility.GetInstance();
            label1.Text = H.ToString();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
