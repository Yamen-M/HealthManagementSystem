using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthManagementSystem
{
    public interface IDoctor
    {
        string Name { get; set; }
        string ID { get; set; }
        string Specialization { get; set; }
        string ToString();
    }
    public class Doctor: IDoctor
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public string Specialization {  get; set; }

        public Doctor(string name, string id, string specialization)
        {
            Name = name;
            ID = id;
            Specialization = specialization;
        }

        public override string ToString()
        {
            return $"Doctor: {Name}\nID: {ID}\nSpecialization: {Specialization}";
        }

        public Doctor(string name, string specialization) : this(name, Guid.NewGuid().ToString(), specialization)
        {
        }
    }
}