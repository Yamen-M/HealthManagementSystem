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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            SetPlaceholder(FullDate, "(dd/mm/yyyy)");
            FullDate.GotFocus += (s, e) => RemovePlaceholder(FullDate, "(dd/mm/yyyy)");
            FullDate.LostFocus += (s, e) => SetPlaceholder(FullDate, "(dd/mm/yyyy)");

            SetPlaceholder(FullTime, "(hh:mm)");
            FullTime.GotFocus += (s, e) => RemovePlaceholder(FullTime, "(hh:mm)");
            FullTime.LostFocus += (s, e) => SetPlaceholder(FullTime, "(hh:mm)");
        }

        private void SetPlaceholder(TextBox textBox, string placeholder) 
        { 
            if (string.IsNullOrWhiteSpace(textBox.Text))
            { textBox.Text = placeholder;
              textBox.ForeColor = Color.Gray;
            }
        }
        private void RemovePlaceholder(TextBox textBox, string placeholder) 
        { 
            if (textBox.Text == placeholder) 
            { textBox.Text = "";
              textBox.ForeColor = Color.Black;
            }
        }

        private List<string> MedicalHistory = new List<string>();

        private List<string> MedicationList = new List<string>();
        
        private IBillingStrategy BillingStrategy;

        private void Form2_Load(object sender, EventArgs e)
        {
            SetPlaceholder(FullDate, "(dd/mm/yyyy)");
            FullDate.GotFocus += (s, ev) => RemovePlaceholder(FullDate, "(dd/mm/yyyy)");
            FullDate.LostFocus += (s, ev) => SetPlaceholder(FullDate, "(dd/mm/yyyy)");
            
            SetPlaceholder(FullTime, "(hh:mm)");
            FullTime.GotFocus += (s, ev) => RemovePlaceholder(FullTime, "(hh:mm)");
            FullTime.LostFocus += (s, ev) => SetPlaceholder(FullTime, "(hh:mm)");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (BillingStrategy == null)
            {
                MessageBox.Show("Please select a billing strategy before proceeding.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string patientName = PatientName.Text;
            int patientAge = Convert.ToInt32(PatientAge.Text);

            string doctorName = DoctorName.Text;
            string speciality = Specialty.Text;

            string Date = FullDate.Text;
            string[] date = Date.Split('/');
            DateTime formattedDate = new DateTime(Convert.ToInt32(date[2]), Convert.ToInt32(date[1]), Convert.ToInt32(date[0]));

            string Time = FullTime.Text;
            decimal amount = Convert.ToDecimal(Amount.Text);

            List<string> MH = new List<string>(MedicalHistory);
            List<string> Medication = new List<string>(MedicationList);

            IPatient P = new Patient(patientName, patientAge, MH, Medication);
            IDoctor D = new Doctor(doctorName, speciality);
            IBill B = new Bill(amount, BillingStrategy);

            NewAppointment A = new NewAppointment();
            A.CreateAppointment(P, D, formattedDate, Time, AppointmentStatus.Scheduled, B);

            HealthcareFacility h = HealthcareFacility.GetInstance();
            h.addToDatabase(A);

            // Clear fields
            MedicalHistory.Clear();
            MedicationList.Clear();
            PatientName.Text = string.Empty;
            DoctorName.Text = string.Empty;
            Specialty.Text = string.Empty;
            FullDate.Text = string.Empty;
            FullTime.Text = string.Empty;
            PatientAge.Text = string.Empty;
            Amount.Text = string.Empty;
            comboBox1.Text = string.Empty;
        }


        private void AddMedication_Click(object sender, EventArgs e)
        {
            string MH = MHistory.Text;
            MHistory.Text = string.Empty;
            MedicalHistory.Add(MH);
        }

        private void AddMedHistory_Click(object sender, EventArgs e)
        {
            string M = Medication.Text;
            Medication.Text = string.Empty;
            MedicationList.Add(M);
        }

        private void FullTime_TextChanged(object sender, EventArgs e)
        {

        }

        private void CloseForm2_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Normal")
            {
                BillingStrategy = new NormalBillingStrategy();
            }
            else if (comboBox1.SelectedItem.ToString() == "Discounted")
            {
                BillingStrategy = new DiscountBillingStrategy();
            }
        }


        private void FullTime_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
