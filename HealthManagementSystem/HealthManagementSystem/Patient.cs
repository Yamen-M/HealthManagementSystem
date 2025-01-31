using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthManagementSystem
{
    public interface IPatient
    {
        string Name { get; set; }
        string ID { get; set; }
        int Age { get; set; }
        List<string> MedicalHistory { get; set; }
        List<string> CurrentMedications { get; set; }

        void AddToMedicalHistory(string medicalHistory);
        void UpdateMedications(string medications);
        string GetPatientInfo();
    }
    public class Patient: IPatient
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }
        public List<string> MedicalHistory { get; set; }
        public List<string> CurrentMedications { get; set; }
        public Patient(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public Patient(string name, int age, List<string> mHistory, List<string> cMedicaton): this(name, age)
        {
            ID = Guid.NewGuid().ToString();
            MedicalHistory = mHistory;
            CurrentMedications = cMedicaton;
        }

        public void AddToMedicalHistory(string medicalHistory)
        {
            MedicalHistory.Add(medicalHistory);
        }

        public void UpdateMedications(string medications)
        {
            CurrentMedications.Add(medications);
        }

        public string GetPatientInfo()
        {
            return $"Patient: {Name}, ID: {ID}, Age: {Age}";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Patient: {Name}\nID: {ID}\nAge: {Age}\n");
            sb.AppendLine("Medication(s):");
            foreach (string c in CurrentMedications)
            {
                sb.AppendLine(c);
            }
            sb.AppendLine("\nMedical History:");
            foreach(string c in MedicalHistory)
            {
                sb.AppendLine(c);
            }
            return sb.ToString();
        }
    }
}