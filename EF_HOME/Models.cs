using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EFForms_P35.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; } = "None";
        public Specialization Specialization { get; set; } = new Specialization { Name = "None" };
        public double Salary { get; set; } = 0;

        public override string ToString()
        {
            return $"{Id}. {Name,10} | {Specialization} | Зарплата: {Salary} грн";
        }
    }


    public class Specialization
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Id}. {Name}";
        }
    }

    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; } = "None";
        public int Age { get; set; } = 0;

        public Doctor Doctor { get; set; } = new Doctor();

        public override string ToString()
        {
            return $"{Id}. {Name}, Вік: {Age} | Лікар: {Doctor.Name}";
        }
    }

    public class DoctorsContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Patient> Patients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "server=localhost;database=doctors;user=root;password=";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}